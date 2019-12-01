
namespace MarineTrafficApi.Internals
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
    using SrkCsv;

    public static class Utility
    {
        public static readonly Regex CsvErrorFormat = new Regex("ERROR_([0-9a-z]+)-([A-Za-z0-9 _-]+)(\\. )?(.*)?", RegexOptions.Compiled);

        public static bool HandleErrorResultCsv(HttpResponseMessage message, string contents, IMarineTrafficResult result)
        {
            if (contents.StartsWith("ERROR_"))
            {
                var reader = new StringReader(contents);
                var line = reader.ReadLine();
                var match = CsvErrorFormat.Match(line);
                result.Errors.Add(Utility.MarineTrafficError(match.Groups[1].Value, match.Groups[2].Value, line, match.Groups[4].Value));

                return true;
            }
            else
            {
                return false;
            }
        }

        public static MarineTrafficError MarineTrafficError(string code, string message, string line, string detail)
        {
            MarineTrafficErrorCode knownCode;
            if (!Constants.errorCodes.TryGetValue(code, out knownCode))
            {
                knownCode = MarineTrafficErrorCode.Unknown;
            }

            if (string.IsNullOrEmpty(detail))
            {
                Constants.errorCodeDetails.TryGetValue(code, out detail);
            }

            var item = new MarineTrafficError(code, knownCode, message, line, detail);

            return item;
        }

        public static double ParseDegrees<T>(Cell<T> cell)
        {
            if (!string.IsNullOrEmpty(cell.Value) && double.TryParse(cell.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double val))
            {
                if (val >= -360D && val <= 360D)
                {
                    return val;
                }
                else
                {
                    cell.Row.Errors.Add("Invalid degrees in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                    return double.NaN;
                }
            }
            else
            {
                cell.Row.Errors.Add("Invalid number in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return double.NaN;
            }
        }

        public static string ParseShipType(Cell<Vessel> cell)
        {
            if (string.IsNullOrEmpty(cell.Value))
            {
                return null;
            }
            else
            {
                if (cell.Value.Length == 1 || cell.Value.Length == 2)
                {
                    cell.Target.ObjectCategory = ObjectCategory.ShipCategory;
                    var first = cell.Value[0];
                    if (first == '1')
                    {
                        cell.Target.ShipCategory = ShipCategory.Reserved1;
                    }
                    else if (first == '2')
                    {
                        cell.Target.ShipCategory = ShipCategory.WingInGround;
                    }
                    else if (first == '3')
                    {
                        cell.Target.ShipCategory = ShipCategory.SpecialCategory3;
                    }
                    else if (first == '4')
                    {
                        cell.Target.ShipCategory = ShipCategory.HighSpeedCraft;
                    }
                    else if (first == '5')
                    {
                        cell.Target.ShipCategory = ShipCategory.SpecialCategory5;
                    }
                    else if (first == '6')
                    {
                        cell.Target.ShipCategory = ShipCategory.Passenger;
                    }
                    else if (first == '7')
                    {
                        cell.Target.ShipCategory = ShipCategory.Cargo;
                    }
                    else if (first == '8')
                    {
                        cell.Target.ShipCategory = ShipCategory.Tanker;
                    }
                    else if (first == '9')
                    {
                        cell.Target.ShipCategory = ShipCategory.Other;
                    }
                    else
                    {
                        cell.Target.ShipCategory = ShipCategory.Unknown;
                    }
                }
                else if (cell.Value.Length == 3)
                {
                    cell.Target.ShipCategory = ShipCategory.OtherThanShip;
                    if (Enum.TryParse<ObjectCategory>(cell.Value, out ObjectCategory val))
                    {
                        cell.Target.ObjectCategory = val;
                    }
                    else
                    {
                        cell.Target.ObjectCategory = ObjectCategory.Unknown;
                    }
                }

                return cell.Value;
            }
        }

        public static double? ParseFloat<T>(Cell<T> cell)
        {
            if (string.IsNullOrEmpty(cell.Value))
            {
                return null;
            }
            else if (double.TryParse(cell.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double val))
            {
                return val;
            }
            else
            {
                cell.Row.Errors.Add("Invalid number in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return double.NaN;
            }
        }

        public static double ParseFloatValue<T>(Cell<T> cell)
        {
            var val = ParseFloat(cell);
            if (val == null)
            {
                cell.Row.Errors.Add("Empty float in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return default(double);
            }
            else
            {
                return val.Value;
            }
        }

        public static VesselStatus ParseVesselStatus<T>(Cell<T> cell)
        {
            VesselStatus val;
            if (!string.IsNullOrEmpty(cell.Value) && Enum.TryParse< VesselStatus>(cell.Value, out val))
            {
                return val;
            }
            else
            {
                cell.Row.Errors.Add("Invalid number in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return VesselStatus.Unknown;
            }
        }

        public static DateTime ParseTimestampValue<T>(Cell<T> cell)
        {
            var val = ParseTimestamp(cell);
            if (val == null)
            {
                cell.Row.Errors.Add("Empty timestamp in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return default(DateTime);
            }
            else
            {
                return val.Value;
            }
        }

        public static DateTime? ParseTimestamp<T>(Cell<T> cell)
        {
            DateTime val;
            if (string.IsNullOrEmpty(cell.Value))
            {
                return null;
            }
            else if (DateTime.TryParse(cell.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out val))
            {
                return new DateTime(val.Ticks, DateTimeKind.Utc);
            }
            else
            {
                cell.Row.Errors.Add("Invalid timestamp in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return null;
            }
        }

        public static string ParseDSRC<T>(Cell<T> cell)
        {
            return cell.Value;
        }

        public static int ParseIntegerValue<T>(Cell<T> cell)
        {
            var val = ParseInteger(cell);
            if (val == null)
            {
                cell.Row.Errors.Add("Empty integer in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return default(int);
            }
            else
            {
                return val.Value;
            }
        }

        public static int? ParseInteger<T>(Cell<T> cell)
        {
            if (string.IsNullOrEmpty(cell.Value))
            {
                return null;
            }
            else if (int.TryParse(cell.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int val))
            {
                return val;
            }
            else
            {
                cell.Row.Errors.Add("Invalid integer in column " + cell.Column.Index + " " + cell.Column.Name + ": " + cell.Value + ". ");
                return default(int);
            }
        }

        public static string ParseFlag<T>(Cell<T> cell)
        {
            return cell.Value;
        }
    }
}
