using System;


//class for ingredient objects - contains information such as name, quantity needed for recipe
namespace INFOTC4400_FinalProject
{
	public class Ingredient
	{
		//properties: ingredientName, quantity, and measurement
		public string IngredientName { get; set; }
		public double Quantity { get; set; }
		public string Measurement { get; set; }

		//constructor
		public Ingredient(string ingredientName, double quantity, string measurement)
		{
			IngredientName = ingredientName;
			Quantity = quantity;
			Measurement = measurement;
		}

		//ToString method
		public override string ToString()
		{
			return $"{IngredientName} - {Quantity} {Measurement}";
		}
	}
}
