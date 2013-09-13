using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependencyInjectionDemo.Core;
using DependencyInjectionDemo.WebMvc.Models.Home;

namespace DependencyInjectionDemo.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
	        //todo: use dependency injection			
			var log = new Log();
	        var clock = new SystemClock();
	        var repository = new RecipeRepositoryUsingDependencyInjection(log, clock);

	        var recipeCount = new RecipeCount()
		        {
			        Time = clock.Now,
			        NumRecipes = repository.Count
		        };

            return View(recipeCount);
        }

    }
}
