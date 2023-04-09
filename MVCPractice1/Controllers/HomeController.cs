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
		public IActionResult Delete(int seat)
		{
            MvcpracticeContext db = new MvcpracticeContext();
			var passenger = db.Passengers.Find(seat);

			if(passenger != null)
			{
				db.Passengers.Remove(passenger);
				db.SaveChanges();
			}
			return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int seat)
        {
            MvcpracticeContext db = new MvcpracticeContext();
			var passenger = db.Passengers.Find(seat);
            return View(passenger);
        }
        [HttpPost]
        public IActionResult Edit(Passenger passenger)
        { 
            MvcpracticeContext db = new MvcpracticeContext();
            db.Passengers.Update(passenger);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
