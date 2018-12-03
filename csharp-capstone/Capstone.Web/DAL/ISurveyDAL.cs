using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ISurveyDal
    {
        void AddSurvey(Survey survey);
        Dictionary<string, int> GetSurveyResults();
    }

}
