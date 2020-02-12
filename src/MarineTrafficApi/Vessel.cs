
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
        /// Basic Info. International Maritime Organisation number - a seven-digit number that uniquely identifies vessels.
        /// </summary>
        public string IMO { get; internal set; }

        /// <summary>
        /// Basic Info. A uniquely assigned ID by MarineTraffic for the subject vessel.
        /// </summary>
        public string ShipId { get; internal set; }

        /// <summary>
        /// Basic Info. Latitude - a geographic coordinate that specifies the north-south position of the vessel on the Earth's surface.
        /// </summary>
        public double Latitude { get; internal set; }

        /// <summary>
        /// Basic Info. Longitude - a geographic coordinate that specifies the east-west position of the vessel on the Earth's surface.
        /// </summary>
        public double Longitude { get; internal set; }

        /// <summary>
        /// Speed over Ground - 0 to 102 knots (0.1-knot resolution). 
        /// The speed (in knots x10) that the subject vessel is reporting according to AIS transmissions. 
        /// </summary>
        public double Speed { get; internal set; }

        /// <summary>
        /// Heading - 0 to 359 degrees.
        /// The heading (in degrees) that the subject vessel is reporting according to AIS transmissions.
        /// </summary>
        public double Heading { get; internal set; }

        /// <summary>
        /// Course over Ground - up to 0.1° relative to true north.
        /// The course (in degrees) that the subject vessel is reporting according to AIS transmissions.
        /// </summary>
        public double Course { get; internal set; }

        /// <summary>
        /// Basic Info. The AIS Navigational Status of the subject vessel as input by the vessel's crew. There might be discrepancies with the vessel's detail page when vessel speed is near zero (0) knots.
        /// </summary>
        public VesselStatus? Status { get; set; }

        /// <summary>
        /// Basic Info. The date and time (in UTC) that the subject vessel's position was recorded by MarineTraffic.
        /// </summary>
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// Basic Info. Data Source - Defines whether the transmitted AIS data was received by a Terrestrial or a Satellite AIS Station.
        /// </summary>
        public string DSRC { get; internal set; }

        /// <summary>
        /// Basic Info. The time slot that the subject vessel uses to transmit information.
        /// </summary>
        public int UtcSeconds { get; internal set; }

        /// <summary>
        /// Extended info. The Shipname of the subject vessel.
        /// </summary>
        public string ShipName { get; internal set; }

        /// <summary>
        /// Extended info. The Shiptype of the subject vessel according to AIS transmissions.
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
        /// Extended info. A uniquely designated identifier for the vessel's transmitter station.
        /// </summary>
        public string CallSign { get; internal set; }

        /// <summary>
        /// Extended info. The flag of the subject vessel according to AIS transmissions.
        /// </summary>
        public string Flag { get; internal set; }

        /// <summary>
        /// Extended info. The overall Length (in metres) of the subject vessel.
        /// </summary>
        public double? Length { get; internal set; }

        /// <summary>
        /// Extended info. The Breadth (in metres) of the subject vessel.
        /// </summary>
        public double? Width { get; internal set; }

        /// <summary>
        /// Extended info. Gross Tonnage - unitless measure that calculates the moulded volume of all enclosed spaces of a ship.
        /// </summary>
        public string GRT { get; internal set; }

        /// <summary>
        /// Extended info. Deadweight - a measure (in metric tons) of how much weight a vessel can safely carry (excluding the vessel's own weight).
        /// </summary>
        public string DWT { get; internal set; }

        /// <summary>
        /// Extended info. The Draught (in metres x10) of the subject vessel according to the AIS transmissions.
        /// </summary>
        public int? Draught { get; internal set; }

        /// <summary>
        /// Extended info. The year that the subject vessel was built.
        /// </summary>
        public int? YearBuilt { get; internal set; }

        /// <summary>
        /// Extended info. Rate of Turn - right or left (0 to 720 degrees per minute).
        /// </summary>
        public int? RateOfTurn { get; internal set; }

        /// <summary>
        /// Extended info. The Type of the subject vessel.
        /// </summary>
        public string TypeName { get; internal set; }

        /// <summary>
        /// Extended info. Further explanation of the SHIPTYPE ID.
        /// </summary>
        public string AisTypeSummary { get; internal set; }

        /// <summary>
        /// Extended info. The Destination of the subject vessel according to the AIS transmissions.
        /// </summary>
        public string Destination { get; internal set; }

        /// <summary>
        /// Extended info. The Estimated Time of Arrival to Destination of the subject vessel according to the AIS transmissions.
        /// </summary>
        public DateTime? ETA { get; internal set; }

        /// <summary>
        /// Full info. The name of the Port the subject vessel is currently in (NULL if the vessel is underway).
        /// </summary>
        public string CurrentPort { get; internal set; }

        /// <summary>
        /// Full info. The Name of the Last Port the vessel has visited.
        /// </summary>
        public string LastPortName { get; internal set; }

        /// <summary>
        /// Full info. The Date and Time (in UTC) that the subject vessel departed from the Last Port.
        /// </summary>
        public DateTime? LastPortTime { get; internal set; }

        /// <summary>
        /// Full info. A uniquely assigned ID by MarineTraffic for the Current Port.
        /// </summary>
        public int? CurrentPortId { get; internal set; }

        /// <summary>
        /// Full info. A uniquely assigned ID by United Nations for the Current Port.
        /// </summary>
        public string CurrentPortUnlocode { get; internal set; }

        /// <summary>
        /// Full info. The Country that the Current Port is located at.
        /// </summary>
        public string CurrentPortCountry { get; internal set; }

        /// <summary>
        /// Full info. A uniquely assigned ID by MarineTraffic for the Last Port.
        /// </summary>
        public int? LastPortId { get; internal set; }

        /// <summary>
        /// Full info. A uniquely assigned ID by United Nations for the Last Port.
        /// </summary>
        public string LastPortUnlocode { get; internal set; }

        /// <summary>
        /// Full info. The Country that the Last Port is located at.
        /// </summary>
        public string LastPortCountry { get; internal set; }

        /// <summary>
        /// Full info. A uniquely assigned ID by MarineTraffic for the Next Port.
        /// </summary>
        public int? NextPortId { get; internal set; }

        /// <summary>
        /// Full info. A uniquely assigned ID by United Nations for the Next Port.
        /// </summary>
        public string NextPortUnlocode { get; internal set; }

        /// <summary>
        /// Full info. 
        /// </summary>
        public string NextPortName { get; internal set; }

        /// <summary>
        /// Full info. The Country that the Next Port is located at.
        /// </summary>
        public string NextPortCountry { get; internal set; }

        /// <summary>
        /// Full info. The Estimated Time of Arrival to Destination of the subject vessel according to the MarineTraffic calculations.
        /// </summary>
        public DateTime? ETACalc { get; internal set; }

        /// <summary>
        /// Full info. The date and time (in UTC) that the ETA was calculated by MarineTraffic.
        /// </summary>
        public DateTime? ETAUpdated { get; internal set; }

        /// <summary>
        /// Full info. The Remaining Distance (in NM) for the subject vessel to reach the reported Destination.
        /// </summary>
        public int? DistanceToGo { get; internal set; }

        /// <summary>
        /// Full info. The Distance (in NM) that the subject vessel has travelled since departing from Last Port.
        /// </summary>
        public int? DistanceTravelled { get; internal set; }

        /// <summary>
        /// Full info. The average speed calculated for the subject vessel during the latest voyage (port to port).
        /// </summary>
        public double? AverageSpeed { get; internal set; }

        /// <summary>
        /// Full info. The maximum speed reported by the subject vessel during the latest voyage (port to port).
        /// </summary>
        public double? MaxSpeed { get; internal set; }

        public override string ToString()
        {
            return "Vessel " 
                + (this.ShipId != null ? (this.ShipId + " ") : string.Empty)
                + (this.ShipName != null ? (this.ShipName + " ") : string.Empty)
                + (this.CallSign != null ? (this.CallSign + " ") : string.Empty)
                ;
        }
    }
}
