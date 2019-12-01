
namespace MarineTrafficApi
{
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///   <para>Request vessel positions. </para>
    ///   <para>[PS02] Vessel Positions of a Static Fleet</para>
    ///   <para>[PS03] Vessel Positions of a Dynamic Fleet</para>
    ///   <para>[PS04] Vessel Positions within a Port</para>
    ///   <para>[PS05] Vessel Positions in a Predefined Area</para>
    ///   <para>[PS06] Vessel Positions in a Custom Area</para>
    /// </summary>
    public sealed class ExportVesselsV8Request : IMarineTrafficRequest
    {
        /// <summary>
        /// Prefer using the static methods to create you request.
        /// </summary>
        public ExportVesselsV8Request()
        {
        }

        /// <summary>
        /// The maximum age, in minutes, of the returned positions. Maximum value for terrestrial coverage is 60. Maximum value for satellite coverage is 180. Use -1 not to specify the option.
        /// </summary>
        public int Timespan { get; set; }

        /// <summary>
        /// If used with the value extended or full, the response includes scheduled static and voyage related vessel data report (AIS Message 5). In this case your request frequency might be limited (depending on your service terms). If omitted, the returned records include only position reports(AIS Messages 1, 2, 3/ 18, 19). 
        /// </summary>
        public ExportVesselsMessageType MessageType { get; set; }

        /// <summary>
        /// Data filter: Vessel type. (2=Fishing / 4=High Speed Craft / 6=Passenger / 7=Cargo / 8=Tanker) 
        /// </summary>
        public ShipTypeFilter ShipType { get; set; }

        public double? MinLatitude { get; set; }

        public double? MaxLatitude { get; set; }

        public double? MinLongitude { get; set; }

        public double? MaxLongitude { get; set; }

        public string Path
        {
            get
            {
                var path = new StringBuilder("api/exportvessels/v:8/{ApiKey}");
                if (this.MessageType != ExportVesselsMessageType.Normal)
                {
                    path.Append("/msgtype:");
                    path.Append(this.MessageType.ToString().ToLowerInvariant());
                }

                if (this.ShipType != ShipTypeFilter.Any)
                {
                    path.Append("/shiptype:");
                    path.Append(((int)this.ShipType).ToString(CultureInfo.InvariantCulture));
                }

                if (this.MinLatitude != null && this.MinLongitude != null && this.MaxLatitude != null && this.MaxLongitude != null)
                {
                    path.Append("/MINLAT:");
                    path.Append(this.MinLatitude.Value.ToString("F6", CultureInfo.InvariantCulture));
                    path.Append("/MAXLAT:");
                    path.Append(this.MaxLatitude.Value.ToString("F6", CultureInfo.InvariantCulture));
                    path.Append("/MINLON:");
                    path.Append(this.MinLongitude.Value.ToString("F6", CultureInfo.InvariantCulture));
                    path.Append("/MAXLON:");
                    path.Append(this.MaxLongitude.Value.ToString("F6", CultureInfo.InvariantCulture));
                }

                if (this.Timespan >= 0)
                {
                    path.Append("/timespan:");
                    path.Append(this.Timespan.ToString(CultureInfo.InvariantCulture));
                }

                path.Append("/protocol:csv");

                return path.ToString();
            }
        }

        /// <summary>
        /// <para>[PS06] Vessel Positions in a Custom Area</para>
        /// </summary>
        /// <param name="timespanMinutes">The maximum age, in minutes, of the returned positions. Maximum value for terrestrial coverage is 60. Maximum value for satellite coverage is 180. Use -1 not to specify the option.</param>
        /// <param name="messageType">If used with the value extended or full, the response includes scheduled static and voyage related vessel data report (AIS Message 5). In this case your request frequency might be limited (depending on your service terms). If omitted, the returned records include only position reports(AIS Messages 1, 2, 3/ 18, 19). </param>
        /// <param name="shipType">Data filter: Vessel type. (2=Fishing / 4=High Speed Craft / 6=Passenger / 7=Cargo / 8=Tanker) </param>
        public static ExportVesselsV8Request VesselPositions(int timespanMinutes, ExportVesselsMessageType messageType, ShipTypeFilter shipType)
        {
            // https://www.marinetraffic.com/en/ais-api-services/documentation#apidocps05
            // Typical API call:
            // https://services.marinetraffic.com/api/exportvessels/v:8/YOUR-API-KEY/timespan:#minutes/protocol:value
            // Example API call:
            // https://services.marinetraffic.com/api/exportvessels/v:8/8205c862d0572op1655989d939f1496c092ksvs4/timespan:10/protocol:json 
            var me = new ExportVesselsV8Request();
            me.MessageType = messageType;
            me.ShipType = shipType;
            me.Timespan = timespanMinutes;
            return me;
        }

        /// <summary>
        /// <para>[PS06] Vessel Positions in a Custom Area</para>
        /// </summary>
        public static ExportVesselsV8Request VesselPositions()
        {
            var me = VesselPositions(-1, ExportVesselsMessageType.Normal, ShipTypeFilter.Any);
            return me;
        }

        public ExportVesselsV8Request InCustomArea(double minLatitude, double maxLatitude, double minLongitude, double maxLongitude)
        {
            // https://www.marinetraffic.com/en/ais-api-services/documentation#apidocps06
            // Typical API call:
            // https://services.marinetraffic.com/api/exportvessels/v:8/YOUR-API-KEY/MINLAT:value/MAXLAT:value/MINLON:value/MAXLON:value/timespan:#minutes/protocol:value
            // Example API call:
            // https://services.marinetraffic.com/api/exportvessels/v:8/8205c862d0572op1655989d939f1496c092ksvs4/MINLAT:38.20882/MAXLAT:40.24562/MINLON:-6.7749/MAXLON:-4.13721/timespan:10/protocol:json 
            this.MinLatitude = minLatitude;
            this.MaxLatitude = maxLatitude;
            this.MinLongitude = minLongitude;
            this.MaxLongitude = maxLongitude;
            return this;
        }

        public async Task<ExportVesselsV8Result> Execute(IMarineTrafficApiClient client)
        {
            var result = new ExportVesselsV8Result();
            await client.ExecuteAsync(this, result);
            return result;
        }

        void IMarineTrafficRequest.PrepareHttpMessage(IMarineTrafficApiClient client, HttpRequestMessage message)
        {
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri(client.BaseUrl + this.Path, UriKind.Absolute);
        }
    }

    public enum ExportVesselsMessageType
    {
        Normal,
        Extended,
        Full,
    }

    public enum ShipTypeFilter
    {
        Any = 0,
        Fishing = 2,
        HighSpeedCraft = 4,
        Passenger = 6,
        Cargo = 7,
        Tanker = 8,
    }
}
