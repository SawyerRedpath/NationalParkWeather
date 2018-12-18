using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.DAL
{
    public interface ISurveyDal
    {
        void AddSurvey(Survey survey);

        Dictionary<string, int> GetSurveyResults();
    }
}