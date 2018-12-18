using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDal _surveyDal;
        private IParkDal _parkDal;

        public SurveyController(ISurveyDal surveyDal, IParkDal parkDal)
        {
            this._surveyDal = surveyDal;
            this._parkDal = parkDal;
        }

        public IActionResult Index()
        {
            Survey survey = new Survey();
            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSurvey(Survey survey)
        {
            _surveyDal.AddSurvey(survey);
            return RedirectToAction("SurveyResults", "Survey");
        }

        public IActionResult SurveyResults()
        {
            //call dal and return list of parks codes and counts
            Dictionary<string, int> surveyCount = _surveyDal.GetSurveyResults();

            IList<SurveyPark> surveyParks = new List<SurveyPark>();

            foreach (KeyValuePair<string, int> kvp in surveyCount)
            {
                var park = _parkDal.GetPark(kvp.Key);
                SurveyPark sp = new SurveyPark();
                sp.Park = park;
                sp.Count = kvp.Value;
                surveyParks.Add(sp);
            }
            return View(surveyParks);
        }
    }
}