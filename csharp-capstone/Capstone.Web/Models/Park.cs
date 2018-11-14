using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    /// <summary>
    /// Represents a park .
    /// </summary>
    public class Park
    {
        /// <summary>
        /// The code for the park.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// The parks name.
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// The state the park is in.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The acreage of the park.
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        /// The elevation in feet of the park.
        /// </summary>
        public int ElevationInFeet { get; set; }

        /// <summary>
        /// The miles of trail for the park.
        /// </summary>
        public int MilesOfTrail { get; set; }

        /// <summary>
        /// The number of campsites in the park.
        /// </summary>
        public int NumberOfCampsites { get; set; }

        /// <summary>
        /// The climate of the park.
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// The year the park was founded.
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// The number of annual visitors for the park.
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// The inspirational quote for the park.
        /// </summary>
        public string InspirationalQuote { get; set; }

        /// <summary>
        /// The author of the inspirational quote.
        /// </summary>
        public string InspirationalQuoteSource { get; set; }

        /// <summary>
        /// The description of the park.
        /// </summary>
        public string ParkDescription { get; set; }

        /// <summary>
        /// The entry fee of the park.
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// The number of different animal species found in the park.
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }
    }
}
