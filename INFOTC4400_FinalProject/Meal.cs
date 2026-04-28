using System;
using System.Windows.Navigation;

//Meal class: contains
namespace INFOTC4400_FinalProject
{
	public class Meal
	{
		//properties: MealName, List of ingredients, Link, 
		public string mealName {  get; set; }
		public string link {  get; set; }
		public List<Ingredient> ingredients { get; set; }
		public List<String> mealDays { get; set; }
		public string notes { get; set; }

		//constructor
		public Meal(string mealName, string link, List<Ingredient> ingredients, List<string> mealDays, string notes)
		{
			this.mealName = mealName;
			this.link = link;
			this.ingredients = ingredients;
			this.mealDays = mealDays;
			this.notes = notes;
		}

		//Methods

		
	}
}
