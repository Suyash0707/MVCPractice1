using Microsoft.AspNetCore.Mvc;
using MVCPractice1.models;

namespace MVCPractice1.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			MvcpracticeContext db = new MvcpracticeContext();
			var passengers = db.Passengers.ToList();
			return View(passengers);
		}
		[HttpGet]
		public IActionResult Create()
		{
			Passenger passenger = new Passenger();
			return View (passenger);
		}
		[HttpPost]
        public IActionResult Create(Passenger passenger)
        {
            MvcpracticeContext db = new MvcpracticeContext();
			db.Passengers.Add(passenger);
			db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
