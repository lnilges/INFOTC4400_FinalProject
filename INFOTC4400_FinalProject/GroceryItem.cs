using System;

//GroceryItem - contains all information from ingredient + quantity to purchase 
//Sydney work on this
public class GroceryItem : Ingredient
{
	bool isBought = false;
	string itemName;
	int itemQuantity;

	public GroceryItem()
	{
		//I want to add items like ingredients to the grocerylist and then pull the list into the listbox
		List <string> GroceryList = new List<string> ();


	}
}
