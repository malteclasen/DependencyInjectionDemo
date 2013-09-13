using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionDemo.WebMvc.Models.Home
{
	public class RecipeCount
	{
		public DateTime Time { get; set; }
		public long NumRecipes { get; set; }
	}
}