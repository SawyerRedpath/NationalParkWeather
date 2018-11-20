using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;
        private IParkDAL parkDAL;
        public SurveyController(ISurveyDAL surveyDAL, IParkDAL parkDAL)
        {
            this.surveyDAL = surveyDAL;
            this.parkDAL = parkDAL;
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
            surveyDAL.AddSurvey(survey);
            return RedirectToAction("SurveyResults", "Survey");
        }
        public IActionResult SurveyResults()
        {
            //call dal and return list of parks codes and counts
            Dictionary<string, int> surveyCount = surveyDAL.GetSurveyResults();

            IList<SurveyPark> surveyParks = new List<SurveyPark>();
            
            foreach(KeyValuePair<string, int> kvp in surveyCount)
            {
                var park = parkDAL.GetPark(kvp.Key);
                SurveyPark sp = new SurveyPark();
                sp.park = park;
                sp.Count = kvp.Value;
                surveyParks.Add(sp);
            }
            return View(surveyParks);
        }
    }
}