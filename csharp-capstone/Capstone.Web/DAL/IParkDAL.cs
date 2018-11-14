using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkDAL
    {
        /// <summary>
        /// Returns a list of all parks
        /// </summary>
        /// <returns></returns>
        IList<Park> GetParks();

        //IList<Park> GetPark()
    }
}
