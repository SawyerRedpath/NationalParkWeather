using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkDal
    {
        /// <summary>
        /// Returns a list of all parks
        /// </summary>
        /// <returns></returns>
        IList<Park> GetParks();

        /// <summary>
        /// Returns single park
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        Park GetPark(string parkCode);
    }
}
