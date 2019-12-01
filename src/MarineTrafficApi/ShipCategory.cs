
namespace MarineTrafficApi
{
    /// <summary>
    /// AIS Shiptype number (first digit).
    /// </summary>
    /// <remarks>
    /// https://help.marinetraffic.com/hc/en-us/articles/205579997-What-is-the-significance-of-the-AIS-SHIPTYPE-number-
    /// </remarks>
    public enum ShipCategory
    {
        /// <summary>
        /// Status in unknown to this library. Please report observed status.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// 1 = Reserved
        /// </summary>
        Reserved1 = 1,

        /// <summary>
        /// 2 = Wing In Ground
        /// </summary>
        WingInGround = 2,

        /// <summary>
        /// 3 = Special Category
        /// </summary>
        SpecialCategory3 = 3,

        /// <summary>
        /// 4 = High-Speed Craft
        /// </summary>
        HighSpeedCraft = 4,

        /// <summary>
        /// 5 = Special Category
        /// </summary>
        SpecialCategory5 = 5,

        /// <summary>
        /// 6 = Passenger
        /// </summary>
        Passenger = 6,

        /// <summary>
        /// 7 = Cargo
        /// </summary>
        Cargo = 7,

        /// <summary>
        /// 8 = Tanker
        /// </summary>
        Tanker = 8,

        /// <summary>
        /// 9 = Other
        /// </summary>
        Other = 9,

        /// <summary>
        /// See ObjectCategory.
        /// </summary>
        OtherThanShip = -2,
    }
}
