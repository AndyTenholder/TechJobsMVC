using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        private static List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.jobs = jobs;
            return View();
        }

        // Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType,searchTerm);
            }

            return Redirect("/Search");
        }
    }
}
