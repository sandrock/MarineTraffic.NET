
namespace MarineTrafficApiTests
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MarineTrafficApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExportVesselsV8Tests
    {
        [TestMethod]
        public void VesselPositions_InCustomArea_VerifyPath()
        {
            var request = ExportVesselsV8Request.VesselPositions().InCustomArea(0.1, 0.2, 1.5, 1.6);
            Assert.AreEqual("api/exportvessels/v:8/{ApiKey}/MINLAT:0.100000/MAXLAT:0.200000/MINLON:1.500000/MAXLON:1.600000/protocol:csv", request.Path);
        }

        [TestMethod]
        public async Task VesselPositions_InCustomArea_NoApiKey()
        {
            var client = new MarineTrafficApiClient(null);
            var request = ExportVesselsV8Request.VesselPositions().InCustomArea(0.1, 0.2, 1.5, 1.6);
            var result = await request.Execute(client);
            LocalTests.VerifyFailed(result);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual("1", result.Errors[0].Code);
            Assert.AreEqual(MarineTrafficErrorCode.IncorrectCallCheckParameters, result.Errors[0].KnownCode);
        }

        [TestMethod]
        public async Task VesselPositions_InCustomArea_InvalidApiKey()
        {
            var client = new MarineTrafficApiClient("no-api-key");
            var request = ExportVesselsV8Request.VesselPositions().InCustomArea(0.1, 0.2, 1.5, 1.6);
            var result = await request.Execute(client);
            LocalTests.VerifyFailed(result);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual("10", result.Errors[0].Code);
            Assert.AreEqual(MarineTrafficErrorCode.ServiceKeyNotFound, result.Errors[0].KnownCode);
        }

        [TestMethod]
        public async Task VesselPositions_ParseSimple()
        {
            var contents = "MMSI, IMO, SHIP_ID, LAT, LON, SPEED, HEADING, COURSE, STATUS, TIMESTAMP, DSRC, UTC_SECONDS\r\n422070100,9727716,3636964,27.522440,52.557890,68,237,248,5,2019-11-30T16:02:02,TER,2";
            var resultMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            resultMessage.Content = new StringContent(contents);
            var result = new ExportVesselsV8Result();
            await result.ReadHttpMessage(resultMessage);
            LocalTests.VerifySucceed(result);
            Assert.IsNotNull(result.Items);
            Assert.AreEqual(1, result.Items.Count);

            int l = -1;
            Assert.AreEqual("422070100", result.Items[++l].MMSI);
            Assert.AreEqual("9727716", result.Items[l].IMO);
            Assert.AreEqual("3636964", result.Items[l].ShipId);
            Assert.AreEqual(27.522440, result.Items[l].Latitude);
            Assert.AreEqual(52.557890, result.Items[l].Longitude);
            Assert.AreEqual(68, result.Items[l].Speed);
            Assert.AreEqual(237, result.Items[l].Heading);
            Assert.AreEqual(248, result.Items[l].Course);
            Assert.AreEqual(VesselStatus.Moored, result.Items[l].Status);
            Assert.AreEqual("2019-11-30T16:02:02.0000000Z", result.Items[l].Timestamp.ToString("o"));
            Assert.AreEqual("TER", result.Items[l].DSRC);
            Assert.AreEqual(2, result.Items[l].UtcSeconds);
        }

        [TestMethod]
        public async Task VesselPositions_ParseExtended()
        {
            var contents = "MMSI, IMO, SHIP_ID, LAT, LON, SPEED, HEADING, COURSE, STATUS, TIMESTAMP, DSRC, UTC_SECONDS, SHIPNAME, SHIPTYPE, CALLSIGN, FLAG, LENGTH, WIDTH, GRT, DWT, DRAUGHT, YEAR_BUILT, ROT, TYPE_NAME, AIS_TYPE_SUMMARY, DESTINATION, ETA\r\n228081000,9247510,180700,42.701230,9.456000,0,196,179,5,2019-12-01T12:57:51,TER,48,PASCAL PAOLI,60,FQDN,FR,176,30.5,35760,7286,65,2003,0,Ro-Ro/Passenger Ship,Passenger,FR MRS,2019-12-02T05:30:00\r\n247079000,7205910,274985,42.703830,9.454667,0,511,292,5,2019-12-01T12:57:02,TER,3,SARDINIA REGINA,60,IBMS,IT,146.55,20.86,13004,2649,48,1972,0,Ro-Ro/Passenger Ship,Passenger,FRBIA,2019-12-01T07:00:00";
            var resultMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            resultMessage.Content = new StringContent(contents);
            var result = new ExportVesselsV8Result();
            await result.ReadHttpMessage(resultMessage);
            LocalTests.VerifySucceed(result);
            Assert.IsNotNull(result.Items);
            Assert.AreEqual(2, result.Items.Count);

            int l = -1;
            Assert.AreEqual("228081000", result.Items[++l].MMSI);
            Assert.AreEqual("9247510", result.Items[l].IMO);
            Assert.AreEqual("180700", result.Items[l].ShipId);
            Assert.AreEqual(42.701230, result.Items[l].Latitude);
            Assert.AreEqual(9.456000, result.Items[l].Longitude);
            Assert.AreEqual(0, result.Items[l].Speed);
            Assert.AreEqual(196, result.Items[l].Heading);
            Assert.AreEqual(179, result.Items[l].Course);
            Assert.AreEqual(VesselStatus.Moored, result.Items[l].Status);
            Assert.AreEqual("2019-12-01T12:57:51.0000000Z", result.Items[l].Timestamp.ToString("o"));
            Assert.AreEqual("TER", result.Items[l].DSRC);
            Assert.AreEqual(48, result.Items[l].UtcSeconds);
            Assert.AreEqual("PASCAL PAOLI", result.Items[l].ShipName);
            Assert.AreEqual("60", result.Items[l].ShipType);
            Assert.AreEqual(ShipCategory.Passenger, result.Items[l].ShipCategory);
            Assert.AreEqual(ObjectCategory.ShipCategory, result.Items[l].ObjectCategory);
            Assert.AreEqual("FQDN", result.Items[l].CallSign);
            Assert.AreEqual("FR", result.Items[l].Flag);
            Assert.AreEqual(176, result.Items[l].Length);
            Assert.AreEqual(30.5, result.Items[l].Width);
            Assert.AreEqual("35760", result.Items[l].GRT);
            Assert.AreEqual("7286", result.Items[l].DWT);
            Assert.AreEqual(65, result.Items[l].Draught);
            Assert.AreEqual(2003, result.Items[l].YearBuilt);
            Assert.AreEqual(0, result.Items[l].RateOfTurn);
            Assert.AreEqual("Ro-Ro/Passenger Ship", result.Items[l].TypeName);
            Assert.AreEqual("Passenger", result.Items[l].AisTypeSummary);
            Assert.AreEqual("FR MRS", result.Items[l].Destination);
            Assert.AreEqual("2019-12-02T05:30:00.0000000Z", result.Items[l].ETA.Value.ToString("o"));

            Assert.AreEqual("247079000", result.Items[++l].MMSI);
            Assert.AreEqual("7205910", result.Items[l].IMO);
            Assert.AreEqual("274985", result.Items[l].ShipId);
            Assert.AreEqual(42.703830, result.Items[l].Latitude);
            Assert.AreEqual(9.454667, result.Items[l].Longitude);
            Assert.AreEqual(0, result.Items[l].Speed);
            Assert.AreEqual(511, result.Items[l].Heading);
            Assert.AreEqual(292, result.Items[l].Course);
            Assert.AreEqual(VesselStatus.Moored, result.Items[l].Status);
            Assert.AreEqual("2019-12-01T12:57:02.0000000Z", result.Items[l].Timestamp.ToString("o"));
            Assert.AreEqual("TER", result.Items[l].DSRC);
            Assert.AreEqual(3, result.Items[l].UtcSeconds);
            Assert.AreEqual("SARDINIA REGINA", result.Items[l].ShipName);
            Assert.AreEqual("60", result.Items[l].ShipType);
            Assert.AreEqual(ShipCategory.Passenger, result.Items[l].ShipCategory);
            Assert.AreEqual(ObjectCategory.ShipCategory, result.Items[l].ObjectCategory);
            Assert.AreEqual("IBMS", result.Items[l].CallSign);
            Assert.AreEqual("IT", result.Items[l].Flag);
            Assert.AreEqual(146.55, result.Items[l].Length);
            Assert.AreEqual(20.86, result.Items[l].Width);
            Assert.AreEqual("13004", result.Items[l].GRT);
            Assert.AreEqual("2649", result.Items[l].DWT);
            Assert.AreEqual(48, result.Items[l].Draught);
            Assert.AreEqual(1972, result.Items[l].YearBuilt);
            Assert.AreEqual(0, result.Items[l].RateOfTurn);
            Assert.AreEqual("Ro-Ro/Passenger Ship", result.Items[l].TypeName);
            Assert.AreEqual("Passenger", result.Items[l].AisTypeSummary);
            Assert.AreEqual("FRBIA", result.Items[l].Destination);
            Assert.AreEqual("2019-12-01T07:00:00.0000000Z", result.Items[l].ETA.Value.ToString("o"));
        }

        ////[TestMethod]
        ////public async Task VesselPositions_ParseExtended()
        ////{
        ////    var contents = "MMSI, IMO, SHIP_ID, LAT, LON, SPEED, HEADING, COURSE, STATUS, TIMESTAMP, DSRC, UTC_SECONDS\r\n422070100,9727716,3636964,27.522440,52.557890,68,237,248,5,2019-11-30T16:02:02,TER,2";
        ////    var resultMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        ////    resultMessage.Content = new StringContent(contents);
        ////    await new ExportVesselsV8Result().ReadHttpMessage(resultMessage);
        ////}

        [TestMethod]
        public async Task VesselPositions_InCustomArea_OkApiKey()
        {
            if (LocalTests.LocalApiKey == null)
            {
                Assert.Inconclusive("Please set you API key. ");
            }

            var client = new MarineTrafficApiClient(LocalTests.LocalApiKey);
            var request = ExportVesselsV8Request.VesselPositions().InCustomArea(27.4950, 27.5824, 052.4975, 052.6310);
            ////request.MessageType = ExportVesselsMessageType.Extended;
            request.Timespan = 60;
            var result = await request.Execute(client);
            LocalTests.VerifySucceed(result);
        }

        [TestMethod]
        public async Task VesselPositions_InCustomAreaBastia_OkApiKey()
        {
            if (LocalTests.LocalApiKey == null)
            {
                Assert.Inconclusive("Please set you API key. ");
            }

            var client = new MarineTrafficApiClient(LocalTests.LocalApiKey);
            var request = ExportVesselsV8Request.VesselPositions().InCustomArea(42.6748, 42.7193, 009.4116, 009.4994);
            request.MessageType = ExportVesselsMessageType.Extended;
            request.Timespan = 60;
            var result = await request.Execute(client);
            LocalTests.VerifySucceed(result);
        }
    }
}
