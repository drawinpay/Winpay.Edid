namespace Edid.GeneralInfo
{
    /// <summary>
    /// EDID Time (Manufacture Date or Model Year)
    /// </summary>
    public struct EdidTime
    {
        #region Properties

        /// <summary>
        /// The year is used to represent the year of the display’s manufacture or the model year.
        /// </summary>
        public int Year { get;  }

        /// <summary>
        /// The week of manufacture field is set to a value in the range of 1-54 weeks.
        /// </summary>
        public int Week { get;  }

        /// <summary>
        /// Indicates whether the year is Manufacture year or Model year.
        /// </summary>
        public YearType Type { get;  }

        #endregion

        /// <summary>
        /// Initializes a new instance of the EdidTime struct with the specified year type, year, and week.
        /// </summary>
        /// <param name="type">The type of year to use.</param>
        /// <param name="year">The year value.</param>
        /// <param name="week">The week number within the year.</param>
        public EdidTime(YearType type, int year, int week)
        {
            Type = type;
            Year = year;
            Week = week;
        }
    }
}
