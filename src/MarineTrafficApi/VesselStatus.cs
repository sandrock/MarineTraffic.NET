
namespace MarineTrafficApi
{
    /// <summary>
    /// AIS Navigational Status.
    /// </summary>
    /// <remarks>
    /// https://help.marinetraffic.com/hc/en-us/articles/203990998-What-is-the-significance-of-the-AIS-Navigational-Status-Values-
    /// </remarks>
    public enum VesselStatus
    {
        /// <summary>
        /// Status in unknown to this library. Please report observed status.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// 15 = undefined = default (also used by AIS-SART, MOB-AIS and EPIRB-AIS under test)
        /// </summary>
        Undefined = 15,

        /// <summary>
        /// 0 = under way using engine
        /// </summary>
        UnderWayUsingEngine = 0,

        /// <summary>
        /// 1 = at anchor
        /// </summary>
        AtAnchor = 1,

        /// <summary>
        /// 2 = not under command 
        /// </summary>
        NotUnderCommand = 2,

        /// <summary>
        /// 3 = restricted maneuverability
        /// </summary>
        RestrictedManeuverability = 3,

        /// <summary>
        /// 4 = constrained by her draught
        /// </summary>
        ConstrainedByHerDraught = 4,

        /// <summary>
        /// 5 = moored
        /// </summary>
        Moored = 5,

        /// <summary>
        /// 6 = aground 
        /// </summary>
        Aground = 6,

        /// <summary>
        /// 7 = engaged in fishing
        /// </summary>
        EngagedInFishing = 7,

        /// <summary>
        /// 8 = under way sailing
        /// </summary>
        UnderWaySailing = 8,

        /// <summary>
        /// 9 = reserved for future amendment of navigational status for ships carrying DG, HS, or MP, or IMO hazard or pollutant category C, high-speed craft (HSC)
        /// </summary>
        Reserved9 = 9,

        /// <summary>
        /// 10 = reserved for future amendment of navigational status for ships carrying dangerous goods (DG), harmful substances (HS) or marine pollutants (MP), or IMO hazard or pollutant category A, wing in ground (WIG)
        /// </summary>
        Reserved10 = 10,

        /// <summary>
        /// 11 = power-driven vessel towing astern (regional use)
        /// </summary>
        PowerDrivenVesselTowingAstern = 11,

        /// <summary>
        /// 12 = power-driven vessel pushing ahead or towing alongside (regional use)
        /// </summary>
        PowerDrivenVesselPushingAheadOrTowingAlongside = 12,

        /// <summary>
        /// 13 = reserved for future use
        /// </summary>
        Reserved13 = 13,

        /// <summary>
        /// 14 = AIS-SART (active), MOB-AIS, EPIRB-AIS
        /// </summary>
        AisSartActive = 14,

        /// <summary>
        /// 95 = Base Station
        /// </summary>
        BaseStation = 95,

        /// <summary>
        /// 96 = Class B
        /// </summary>
        ClassB96 = 96,

        /// <summary>
        /// 97 = SAR Aircraft
        /// </summary>
        SarAircraft = 97,

        /// <summary>
        /// 98 = Aid to Navigation
        /// </summary>
        /// <example>
        /// MMSI:994701096 is a "Starboard Hand Mark" with Activity:AidToNavigation.
        /// </example>
        AidToNavigation = 98,

        /// <summary>
        /// 99 = Class B
        /// </summary>
        ClassB99 = 99,
    }
}