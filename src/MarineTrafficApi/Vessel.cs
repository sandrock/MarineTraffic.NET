
namespace MarineTrafficApi
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Vessel
    {
        /// <summary>
        /// Basic Info. Maritime Mobile Service Identity number (MMSI) - a unique identification number for each vessel station (the vessel's flag can also be deducted from it).
        /// </summary>
        public string MMSI { get; set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public string IMO { get; internal set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public string ShipId { get; internal set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public double Latitude { get; internal set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public double Longitude { get; internal set; }

        /// <summary>
        /// Speed over Ground - 0 to 102 knots (0.1-knot resolution).
        /// </summary>
        public double Speed { get; internal set; }

        /// <summary>
        /// Heading - 0 to 359 degrees.
        /// </summary>
        public double Heading { get; internal set; }

        /// <summary>
        /// Course over Ground - up to 0.1° relative to true north.
        /// </summary>
        public double Course { get; internal set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public VesselStatus? Status { get; set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public string DSRC { get; internal set; }

        /// <summary>
        /// Basic Info. 
        /// </summary>
        public int UtcSeconds { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string ShipName { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string ShipType { get; internal set; }

        /// <summary>
        /// The first digit of the ShipType represents the general category of the subject vessel.
        /// </summary>
        public ShipCategory ShipCategory { get; internal set; }

        /// <summary>
        /// Note that, if you are using MarineTraffic API Services, it is possible to get SHIPTYPE responses such as those included in the next table (not AIS-derived).
        /// </summary>
        public ObjectCategory ObjectCategory { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string CallSign { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string Flag { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public double? Length { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public double? Width { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string GRT { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string DWT { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public int? Draught { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public int? YearBuilt { get; internal set; }

        /// <summary>
        /// Extended info. Rate of Turn - right or left (0 to 720 degrees per minute).
        /// </summary>
        public int? RateOfTurn { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string TypeName { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string AisTypeSummary { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string Destination { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public DateTime? ETA { get; internal set; }

        /// <summary>
        /// Extended info. 
        /// </summary>
        public string CurrentPort { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string LastPort { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public DateTime? LastPortTime { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public int? CurrentPortId { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string CurrentPortUnlocode { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string CurrentPortCountry { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public int? LastPortId { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string LastPortUnlocode { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string LastPortCountry { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public int? NextPortId { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string NextPortUnlocode { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string NextPortName { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string NextPortCountry { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public DateTime? ETACalc { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public DateTime? ETAUpdated { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public int? DistanceToGo { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public int? DistanceTravelled { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public double? AverageSpeed { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public double? MaxSpeed { get; internal set; }
    }
}
