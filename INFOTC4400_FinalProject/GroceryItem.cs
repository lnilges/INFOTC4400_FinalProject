using System;

//GroceryItem - contains all information from ingredient + quantity to purchase 
//Sydney work on this - work on ingredient first
namespace INFOTC4400_FinalProject
{
	public class GroceryItem : Ingredient
	{
		//properties: isBought, quantityToPurchase, category (produce, meat, dairy, etc.)
		public bool IsBought { get; set; }
		public double QuantityToPurchase { get; set; }
		public string Category { get; set; }

		public GroceryItem(string ingredientName, int quantity, string measurement, double quantityToPurchase, string category) : base(ingredientName, quantity, measurement)
		{
			//I want to add items like ingredients to the grocerylist and then pull the list into the listbox - do with ingredient list in meal class??
			//List<string> GroceryList = new List<string>();

			IsBought = false;
			QuantityToPurchase = quantityToPurchase;
			Category = category;

		}

		//Methods:
		//method to increase quantity
		public void IncreaseQuantity(double amount)
		{
			QuantityToPurchase += amount;
		}

        //method to decrease quantity
        public void DecreaseQuantity(double amount)
        {
            if (QuantityToPurchase > 0)
			{
				QuantityToPurchase -= amount;
			}
			else
			{
				return;
			}
        }

        //toString method to display on grocery list
        public override string ToString()
        {
			string bought = IsBought ? "[X]" : "[ ]";
			return $"{bought}{IngredientName} - {QuantityToPurchase}";
        }

        //method to check off item on list ~~
		public void ToggleBought()
		{
			IsBought = !IsBought;
		}
    }
}
