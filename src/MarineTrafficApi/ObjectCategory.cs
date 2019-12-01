
namespace MarineTrafficApi
{
    /// <summary>
    /// Note that, if you are using MarineTraffic API Services, it is possible to get SHIPTYPE responses such as those included in the next table (not AIS-derived).
    /// </summary>
    /// <remarks>
    /// https://help.marinetraffic.com/hc/en-us/articles/205579997-What-is-the-significance-of-the-AIS-SHIPTYPE-number-
    /// </remarks>
    public enum ObjectCategory
    {
        /// <summary>
        /// Status in unknown to this library. Please report observed status.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// See the ShipCategory property instead.
        /// </summary>
        ShipCategory = 0,

        NavigationAid = 100,
        ReferencePoint = 101,
        Racon = 102,
        OffShoreStructure = 103,
        Spare = 104,
        LightWithoutSectors = 105,
        LightWithSectors = 106,
        LeadingLightFront = 107,
        LeadingLightRear = 108,
        BeaconCardinalNorth = 109,
        BeaconCardinalEast = 110,
        BeaconCardinalSouth = 111,
        BeaconCardinalWest = 112,
        BeaconPortHand = 113,
        BeaconStarboardHand = 114,
        BeaconPreferredChannelPortHand = 115,
        BeaconPreferredChannelStarboardHand = 116,
        BeaconIsolatedDanger = 117,
        BeaconSafeWater = 118,
        BeaconSpecialMark = 119,
        CardinalMarkNorth = 120,
        CardinalMarkEast = 121,
        CardinalMarkSouth = 122,
        CardinalMarkWest = 123,
        PortHandMark = 124,
        StarboardHandMark = 125,
        PreferredChannelPortHand = 126,
        PreferredChannelStarboardHand = 127,
        IsolatedDanger = 128,
        SafeWater = 129,
        MannedVTS = 130,
        LightVessel = 131,
    }
}