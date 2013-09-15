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
	    private readonly IClock _clock;
	    private readonly IRecipeRepository _repository;

	    public HomeController(IClock clock, IRecipeRepository repository)
	    {
		    _clock = clock;
		    _repository = repository;
	    }

	    //
        // GET: /Home/

        public ActionResult Index()
        {
	        var recipeCount = new RecipeCount
		        {
			        Time = _clock.Now,
			        NumRecipes = _repository.Count
		        };

            return View(recipeCount);
        }

    }
}
