using System;
using System.Windows.Navigation;

//Meal class: contains
namespace INFOTC4400_FinalProject
{
	public class Meal
	{
		//properties: MealName, List of ingredients, Link, 
		public string MealName {  get; set; }
		public string Link {  get; set; }
		public List<Ingredient> Ingredients { get; set; }
		public List<String> MealDays { get; set; }
		public string Notes { get; set; }

		//constructor
		public Meal(string mealName, string link, List<Ingredient> ingredients, List<string> mealDays, string notes)
		{
			MealName = mealName;
			Link = link;
			Ingredients = ingredients;
			MealDays = mealDays;
			Notes = notes;
		}

		//Methods
		//add ingredient
		public void AddIngredient(Ingredient ingredient)
		{
			Ingredients.Add(ingredient);
		}

		//remove ingredient
		public void RemoveIngredient(Ingredient ingredient)
		{
			Ingredients.Remove(ingredient);
		}

		//assign days
		public void AssignDay(string day)
		{
			MealDays.Add(day);
		}

		//remove days
		public void RemoveDay(string day)
		{
            MealDays.Remove(day);
        }
		
	}
}
