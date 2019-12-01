
namespace MarineTrafficApi
{
    using MarineTrafficApi.Internals;
    using SrkCsv;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    public sealed class ExportVesselsV8Result : MarineTrafficBaseResult
    {
        private static readonly Table<Vessel> csvTable;
        private static readonly CsvReader<Vessel> csvReader;

        static ExportVesselsV8Result()
        {
            var table = csvTable = new Table<Vessel>();
            int c = 0;

            // simple response
            table.AddColumn(c++, "MMSI", x => x.Target.MMSI = x.Value);
            table.AddColumn(c++, "IMO", x => x.Target.IMO = x.Value);
            table.AddColumn(c++, "SHIP_ID", x => x.Target.ShipId = x.Value);
            table.AddColumn(c++, "LAT", x => x.Target.Latitude = Utility.ParseDegrees(x));
            table.AddColumn(c++, "LON", x => x.Target.Longitude = Utility.ParseDegrees(x));
            table.AddColumn(c++, "SPEED", x => x.Target.Speed = Utility.ParseFloatValue(x));
            table.AddColumn(c++, "HEADING", x => x.Target.Heading = Utility.ParseIntegerValue(x));
            table.AddColumn(c++, "COURSE", x => x.Target.Course = Utility.ParseDegrees(x));
            table.AddColumn(c++, "STATUS", x => x.Target.Status = Utility.ParseVesselStatus(x)); // 0, 5
            table.AddColumn(c++, "TIMESTAMP", x => x.Target.Timestamp = Utility.ParseTimestampValue(x)); // 2017-05-19T09:39:57
            table.AddColumn(c++, "DSRC", x => x.Target.DSRC = Utility.ParseDSRC(x)); // "TER"
            table.AddColumn(c++, "UTC_SECONDS", x => x.Target.UtcSeconds = Utility.ParseIntegerValue(x)); // 54, 28

            // extended response
            table.AddColumn(c++, "SHIPNAME", x => x.Target.ShipName = x.Value); // "DORNUM", "TOUR MARGAUX"
            table.AddColumn(c++, "SHIPTYPE", x => x.Target.ShipType = Utility.ParseShipType(x)); // 70, 81
            table.AddColumn(c++, "CALLSIGN", x => x.Target.CallSign = x.Value); // "V2OZ", "9HBW8"
            table.AddColumn(c++, "FLAG", x => x.Target.Flag = Utility.ParseFlag(x)); // "AG", "MT", "PT"
            table.AddColumn(c++, "LENGTH", x => x.Target.Length = Utility.ParseFloat(x));
            table.AddColumn(c++, "WIDTH", x => x.Target.Width = Utility.ParseFloat(x));
            table.AddColumn(c++, "GRT", x => x.Target.GRT = x.Value);
            table.AddColumn(c++, "DWT", x => x.Target.DWT = x.Value);
            table.AddColumn(c++, "DRAUGHT", x => x.Target.Draught = Utility.ParseInteger(x));
            table.AddColumn(c++, "YEAR_BUILT", x => x.Target.YearBuilt = Utility.ParseInteger(x));
            table.AddColumn(c++, "ROT", x => x.Target.RateOfTurn = Utility.ParseInteger(x));
            table.AddColumn(c++, "TYPE_NAME", x => x.Target.TypeName = x.Value);
            table.AddColumn(c++, "AIS_TYPE_SUMMARY", x => x.Target.AisTypeSummary = x.Value);
            table.AddColumn(c++, "DESTINATION", x => x.Target.Destination = x.Value);
            table.AddColumn(c++, "ETA", x => x.Target.ETA = Utility.ParseTimestamp(x));

            // full response
            table.AddColumn(c++, "CURRENT_PORT", x => x.Target.CurrentPort = x.Value);
            table.AddColumn(c++, "LAST_PORT", x => x.Target.LastPort = x.Value);
            table.AddColumn(c++, "LAST_PORT_TIME", x => x.Target.LastPortTime = Utility.ParseTimestamp(x));
            table.AddColumn(c++, "CURRENT_PORT_ID", x => x.Target.CurrentPortId = Utility.ParseInteger(x));
            table.AddColumn(c++, "CURRENT_PORT_UNLOCODE", x => x.Target.CurrentPortUnlocode = x.Value);
            table.AddColumn(c++, "CURRENT_PORT_COUNTRY", x => x.Target.CurrentPortCountry = Utility.ParseFlag(x));
            table.AddColumn(c++, "LAST_PORT_ID", x => x.Target.LastPortId = Utility.ParseInteger(x));
            table.AddColumn(c++, "LAST_PORT_UNLOCODE", x => x.Target.LastPortUnlocode = x.Value);
            table.AddColumn(c++, "LAST_PORT_COUNTRY", x => x.Target.LastPortCountry = Utility.ParseFlag(x));
            table.AddColumn(c++, "NEXT_PORT_ID", x => x.Target.NextPortId = Utility.ParseInteger(x));
            table.AddColumn(c++, "NEXT_PORT_UNLOCODE", x => x.Target.NextPortUnlocode = x.Value);
            table.AddColumn(c++, "NEXT_PORT_NAME", x => x.Target.NextPortName = x.Value);
            table.AddColumn(c++, "NEXT_PORT_COUNTRY", x => x.Target.NextPortCountry = Utility.ParseFlag(x));
            table.AddColumn(c++, "ETA_CALC", x => x.Target.ETACalc = Utility.ParseTimestamp(x));
            table.AddColumn(c++, "ETA_UPDATED", x => x.Target.ETAUpdated = Utility.ParseTimestamp(x));
            table.AddColumn(c++, "DISTANCE_TO_GO", x => x.Target.DistanceToGo = Utility.ParseInteger(x));
            table.AddColumn(c++, "DISTANCE_TRAVELLED", x => x.Target.DistanceTravelled = Utility.ParseInteger(x));
            table.AddColumn(c++, "AVG_SPEED", x => x.Target.AverageSpeed = Utility.ParseFloat(x));
            table.AddColumn(c++, "MAX_SPEED", x => x.Target.MaxSpeed = Utility.ParseFloat(x));

            csvReader = new CsvReader<Vessel>(csvTable);
            csvReader.CellSeparator = ',';
            csvReader.HasHeaderLine = true;
            csvReader.AllowMissingColumns = true;
        }

        public ExportVesselsV8Result()
        {
        }

        public IList<Vessel> Items { get; set; }

        public override async Task ReadHttpMessage(HttpResponseMessage resultMessage)
        {
            var contents = await resultMessage.Content.ReadAsStringAsync();
            if (Utility.HandleErrorResultCsv(resultMessage, contents, this))
            {
                return;
            }

            if (contents.Length > 0)
            {
                this.succeed = true;
                var table = csvReader.ReadToEnd(new StringReader(contents));
                this.Items = new List<Vessel>(table.Rows.Count);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i];
                    if (row.IsHeader)
                    {
                        // skip headers
                    }
                    else
                    {
                        this.Items.Add(row.Target);

                        if (row.Errors != null && row.Errors.Count > 0)
                        {
                            for (int e = 0; e < row.Errors.Count; e++)
                            {
                                this.Errors.Add(new MarineTrafficError(MarineTrafficErrorCode.DataParseError, row.Errors[e], null, Messages.ErrorDetailPleaseReport));//// row.Line));
                            }
                        }
                    }
                }
            }
            else
            {
                this.succeed = true;
                this.Items = new List<Vessel>(0);
            }
        }
    }
}