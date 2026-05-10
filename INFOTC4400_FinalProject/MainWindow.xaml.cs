using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;


namespace INFOTC4400_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Meal> meals = new List<Meal>();

        //binding data to UI so using ObservableCollection
        public ObservableCollection<GroceryItem> groceryItems = new ObservableCollection<GroceryItem>();

        public MainWindow()
        {
            InitializeComponent();

            GroceryListBox.ItemsSource = groceryItems;

            MealTimeC_ComboBox.ItemsSource = Enum.GetValues(typeof(MealTimeType));
            MealTimeC_ComboBox.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //want to save either grociery items or meals
            try
            {
                //groceryItems
                GroceryItem selected = GroceryListBox.SelectedItem as GroceryItem;

                //if a meal is selected from the list, when save is clicked, it will updated the meal information using Update_Meal method
                if(selectedMeal != null)
                {
                    Update_Meal(selectedMeal);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(ItemName_TexBox.Text))
                {
                    if (double.TryParse(Quantity_TexBox.Text, out double quantityToPurchase))
                    {
                        //need to figure out how to implement isBought bool
                        string ingredientName = ItemName_TexBox.Text;
                        string category = Category_TexBox.Text;
                        string measurment = Measurement_TexBox.Text;
                        bool isBought = IsBought_CheckBox.IsChecked == true;

                        //autoset properties
                        int quantity = (int)quantityToPurchase;

                        if (selected != null)
                        {
                            selected.IngredientName = ingredientName;
                            selected.Category = category;
                            selected.Quantity = quantity;
                            selected.Measurement = measurment;
                            selected.IsBought = isBought;
                        }
                        else
                        {
                            //set and add grocery properties
                            groceryItems.Add(new GroceryItem(
                                ingredientName,
                                quantity,
                                measurment,
                                quantityToPurchase,
                                category,
                                isBought
                                ));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number");
                    }

                    //refresh and populate GroceryList_Listbox
                    GroceryListBox.Items.Refresh();

                    //clear input fields
                    ItemName_TexBox.Text = string.Empty;
                    Quantity_TexBox.Text = string.Empty;
                    Category_TexBox.Text = string.Empty;
                    Measurement_TexBox.Text = string.Empty;
                    IsBought_CheckBox.IsChecked = false;
                }

                //saving meals
                if (!string.IsNullOrWhiteSpace(Meal_TexBox.Text))
                {
                    string mealName = Meal_TexBox.Text;

                    //need to figure out what to do when link is attached to a meal
                    string link = Link_TexBox.Text;

                    //use pre-built list for checkboxes
                    List<String> selectedDays = new List<String>();

                    if (Monday_CheckBox.IsChecked == true)
                    {
                        selectedDays.Add("Monday");
                    }
                    if (Tuesday_CheckBox.IsChecked == true)
                    {
                        selectedDays.Add("Tuesday");
                    }
                    if (Wednesday_CheckBox.IsChecked == true)
                    {
                        selectedDays.Add("Wednesday");
                    }
                    if (Thursday_CheckBox.IsChecked == true)
                    {
                        selectedDays.Add("Thursday");
                    }
                    if (Friday_CheckBox.IsChecked == true)
                    {
                        selectedDays.Add("Friday");
                    }
                    if (Saturday_CheckBox.IsChecked == true)
                    {
                        selectedDays.Add("Saturday");
                    }
                    if (Sunday_CheckBox.IsChecked == true)
                    {
                        selectedDays.Add("Sunday");
                    }

                    if (selectedDays.Count == 0)
                    {
                        return;
                    }

                    //enum meal combo boxes
                    MealTimeType mealTime = (MealTimeType)MealTimeC_ComboBox.SelectedItem;

                    List<Ingredient> ingredients = new List<Ingredient>();

                    //set meal properties
                    Meal newMeal = new Meal(
                        mealName,
                        link,
                        ingredients,
                        selectedDays,
                        mealTime
                        );

                    //add to meal list
                    AddMeals(newMeal);

                    //Clear input fields
                    Meal_TexBox.Text = string.Empty;
                    MealTimeC_ComboBox.SelectedIndex = 0;
                    Link_TexBox.Text = string.Empty;

                    //checkbox 
                    Link_TexBox.Text = string.Empty;
                    Monday_CheckBox.IsChecked = false;
                    Tuesday_CheckBox.IsChecked = false;
                    Wednesday_CheckBox.IsChecked = false;
                    Thursday_CheckBox.IsChecked = false;
                    Friday_CheckBox.IsChecked = false;
                    Saturday_CheckBox.IsChecked = false;
                    Sunday_CheckBox.IsChecked = false;

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IsBought(object sender, RoutedEventArgs e)
        {
            try 
            {
                GroceryItem selected = GroceryListBox.SelectedItem as GroceryItem;

                if (selected == null)
                {
                    return;
                }

                selected.IsBought = IsBought_CheckBox.IsChecked == true;

                GroceryListBox.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GroceryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                GroceryItem selected = GroceryListBox.SelectedItem as GroceryItem;

                if (selected == null) 
                {
                    return;
                }

                ItemName_TexBox.Text = selected.IngredientName;
                Quantity_TexBox.Text = Convert.ToString(selected.Quantity);
                Category_TexBox.Text = selected.Category;
                Measurement_TexBox.Text = selected.Measurement;
                IsBought_CheckBox.IsChecked = selected.IsBought;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMeal != null)
            {
                Delete_Meal(selectedMeal);
                selectedMeal = null;
                return;
            }

            //after an item on listbox is selected, pop up in the text boxes and deleted
            GroceryItem selected = GroceryListBox.SelectedItem as GroceryItem;

            if (selected != null)
            {
                groceryItems.Remove(selected);
                GroceryListBox.Items.Refresh();
            }

            //clear input fields
            ItemName_TexBox.Text = string.Empty;
            Quantity_TexBox.Text = string.Empty;
            Category_TexBox.Text = string.Empty;
            Measurement_TexBox.Text = string.Empty;
            IsBought_CheckBox.IsChecked = false;
        }

        //Syd work on these
        private void ClearAllButton_Click(object sender, RoutedEventArgs e)
        {
            //need to clear all inputs and any lists
            //clear grocery items
            GroceryListBox.ItemsSource = groceryItems;
            groceryItems.Clear();

            //clear grocery list input fields
            ItemName_TexBox.Text = string.Empty;
            Quantity_TexBox.Text = string.Empty;
            Category_TexBox.Text = string.Empty;
            Measurement_TexBox.Text = string.Empty;
            IsBought_CheckBox.IsChecked = false;


            //Clear meal input fields
            Meal_TexBox.Text = string.Empty;
            MealTimeC_ComboBox.SelectedIndex = 0;
            Link_TexBox.Text = string.Empty;

            MondayBreakfast.Items.Clear();
            MondayLunch.Items.Clear();
            MondayDinner.Items.Clear();
            TuesdayBreakfast.Items.Clear();
            TuesdayLunch.Items.Clear();
            TuesdayDinner.Items.Clear();
            WednesdayBreakfast.Items.Clear();
            WednesdayLunch.Items.Clear();
            WednesdayDinner.Items.Clear();
            ThursdayBreakfast.Items.Clear();
            ThursdayLunch.Items.Clear();
            ThursdayDinner.Items.Clear();
            FridayBreakfast.Items.Clear();
            FridayLunch.Items.Clear();
            FridayDinner.Items.Clear();
            SaturdayBreakfast.Items.Clear();
            SaturdayLunch.Items.Clear();
            SaturdayDinner.Items.Clear();
            SundayBreakfast.Items.Clear();
            SundayLunch.Items.Clear();
            SundayDinner.Items.Clear();

            //checkbox 
            Link_TexBox.Text = string.Empty;
            Monday_CheckBox.IsChecked = false;
            Tuesday_CheckBox.IsChecked = false;
            Wednesday_CheckBox.IsChecked = false;
            Thursday_CheckBox.IsChecked = false;
            Friday_CheckBox.IsChecked = false;
            Saturday_CheckBox.IsChecked = false;
            Sunday_CheckBox.IsChecked = false;

            //clear meals list
            meals.Clear();
        }

        //need to sort by A-Z, Z-A, and category
        private void Filter_ComboBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = FilterComboBox.SelectedItem as ComboBoxItem;

            if (selectedItem == null)
            {
                return;
            }

            string filter = selectedItem.Content?.ToString();

            if (filter == null)
            {
                return;
            }

            List<GroceryItem> sortedList;

            if (filter == "A-Z")
            {
                sortedList = groceryItems.OrderBy(g => g.IngredientName).ToList();
            }
            else if (filter == "Z-A")
            {
                sortedList = groceryItems.OrderByDescending(g => g.IngredientName).ToList();
            }
            else if (filter == "Category")
            {
                sortedList = groceryItems.OrderBy(g => g.Category).ToList();
            }
            else
            {
                GroceryListBox.ItemsSource = groceryItems;
                return;
            }

            GroceryListBox.ItemsSource = sortedList;

        }

        //stores the meal that is being edited so that it can be updated by clicking the save button
        Meal selectedMeal;

        //method to display meal information in form when user selects meal in planner
        private void Meal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //get the listbox name from the xaml page
                ListBox listBox = sender as ListBox;

                //get the selected meal information 
                Meal selected = listBox?.SelectedItem as Meal;

                //save the meal that is selected to the editedMeal variable
                selectedMeal = selected;

                //if null, return
                if (selected == null)
                {
                    return;
                }
           
                //display the information associated with the meal in the form
                Meal_TexBox.Text = selected.MealName;
                Link_TexBox.Text = selected.Link;

                MealTimeC_ComboBox.SelectedItem = selected.MealTime;

                Monday_CheckBox.IsChecked = selected.MealDays.Contains("Monday");
                Tuesday_CheckBox.IsChecked = selected.MealDays.Contains("Tuesday");
                Wednesday_CheckBox.IsChecked = selected.MealDays.Contains("Wednesday");
                Thursday_CheckBox.IsChecked = selected.MealDays.Contains("Thursday");
                Friday_CheckBox.IsChecked = selected.MealDays.Contains("Friday");
                Saturday_CheckBox.IsChecked = selected.MealDays.Contains("Saturday");
                Sunday_CheckBox.IsChecked = selected.MealDays.Contains("Sunday");

                //clear the selected listbox
                //listBox.SelectedItem = null;
                //selectedMeal = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //method to update a meal - takes the meal that is selected 
        private void Update_Meal(Meal editedMeal)
        {
            //remove the current meal from the planner
            RemoveMeals(editedMeal);

            //get all parameters from the form to update meal object
            editedMeal.MealName = Meal_TexBox.Text;
            editedMeal.Link = Link_TexBox.Text;
            editedMeal.MealTime = (MealTimeType)MealTimeC_ComboBox.SelectedItem;

            editedMeal.MealDays.Clear();

            if (Monday_CheckBox.IsChecked == true)
            {
                editedMeal.MealDays.Add("Monday");
            }
            if (Tuesday_CheckBox.IsChecked == true)
            {
                editedMeal.MealDays.Add("Tuesday");
            }
            if (Wednesday_CheckBox.IsChecked == true)
            {
                editedMeal.MealDays.Add("Wednesday");
            }
            if (Thursday_CheckBox.IsChecked == true)
            {
                editedMeal.MealDays.Add("Thursday");
            }
            if (Friday_CheckBox.IsChecked == true)
            {
                editedMeal.MealDays.Add("Friday");
            }
            if (Saturday_CheckBox.IsChecked == true)
            {
                editedMeal.MealDays.Add("Saturday");
            }
            if (Sunday_CheckBox.IsChecked == true)
            {
                editedMeal.MealDays.Add("Sunday");
            }

            if (editedMeal.MealDays.Count == 0)
            {
                return;
            }

            //add updated meals to planner
            AddMeals(editedMeal);

            //refresh listboxes
            RefreshPlanner();

            //clear selected meal/form boxes
            selectedMeal = null;
            Meal_TexBox.Text = string.Empty;
            MealTimeC_ComboBox.SelectedIndex = 0;
            Link_TexBox.Text = string.Empty;
            Link_TexBox.Text = string.Empty;
            Monday_CheckBox.IsChecked = false;
            Tuesday_CheckBox.IsChecked = false;
            Wednesday_CheckBox.IsChecked = false;
            Thursday_CheckBox.IsChecked = false;
            Friday_CheckBox.IsChecked = false;
            Saturday_CheckBox.IsChecked = false;
            Sunday_CheckBox.IsChecked = false;
        }

        //method to delete meal from meal planner
        private void Delete_Meal(Meal deletedMeal)
        {
            //remove meals from planner
            RemoveMeals(deletedMeal);

            //remove meal from meal list
            meals.Remove(deletedMeal);

            //refresh listboxes
            RefreshPlanner();

            //clear selected meal/form boxes
            selectedMeal = null;
            Meal_TexBox.Text = string.Empty;
            MealTimeC_ComboBox.SelectedIndex = 0;
            Link_TexBox.Text = string.Empty;
            Link_TexBox.Text = string.Empty;
            Monday_CheckBox.IsChecked = false;
            Tuesday_CheckBox.IsChecked = false;
            Wednesday_CheckBox.IsChecked = false;
            Thursday_CheckBox.IsChecked = false;
            Friday_CheckBox.IsChecked = false;
            Saturday_CheckBox.IsChecked = false;
            Sunday_CheckBox.IsChecked = false;
        }

        //Method to add meals to planner
        private void AddMeals(Meal newMeal)
        {
            foreach (string day in newMeal.MealDays)
            {
                if (day == "Monday")
                {
                    if (newMeal.MealTime == MealTimeType.Breakfast)
                    {
                        MondayBreakfast.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Lunch)
                    {
                        MondayLunch.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Dinner)
                    {
                        MondayDinner.Items.Add(newMeal);
                    }
                }
                else if (day == "Tuesday")
                {
                    if (newMeal.MealTime == MealTimeType.Breakfast)
                    {
                        TuesdayBreakfast.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Lunch)
                    {
                        TuesdayLunch.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Dinner)
                    {
                        TuesdayDinner.Items.Add(newMeal);
                    }
                }
                else if (day == "Wednesday")
                {
                    if (newMeal.MealTime == MealTimeType.Breakfast)
                    {
                        WednesdayBreakfast.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Lunch)
                    {
                        WednesdayLunch.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Dinner)
                    {
                        WednesdayDinner.Items.Add(newMeal);
                    }
                }
                else if (day == "Thursday")
                {
                    if (newMeal.MealTime == MealTimeType.Breakfast)
                    {
                        ThursdayBreakfast.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Lunch)
                    {
                        ThursdayLunch.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Dinner)
                    {
                        ThursdayDinner.Items.Add(newMeal);
                    }
                }
                else if (day == "Friday")
                {
                    if (newMeal.MealTime == MealTimeType.Breakfast)
                    {
                        FridayBreakfast.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Lunch)
                    {
                        FridayLunch.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Dinner)
                    {
                        FridayDinner.Items.Add(newMeal);
                    }
                }
                else if (day == "Saturday")
                {
                    if (newMeal.MealTime == MealTimeType.Breakfast)
                    {
                        SaturdayBreakfast.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Lunch)
                    {
                        SaturdayLunch.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Dinner)
                    {
                        SaturdayDinner.Items.Add(newMeal);
                    }
                }
                else if (day == "Sunday")
                {
                    if (newMeal.MealTime == MealTimeType.Breakfast)
                    {
                        SundayBreakfast.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Lunch)
                    {
                        SundayLunch.Items.Add(newMeal);
                    }
                    else if (newMeal.MealTime == MealTimeType.Dinner)
                    {
                        SundayDinner.Items.Add(newMeal);
                    }
                }
            }
        }

        //method to remove items 
        private void RemoveMeals(Meal meal)
        {
            MondayBreakfast.Items.Remove(meal);
            MondayLunch.Items.Remove(meal);
            MondayDinner.Items.Remove(meal);

            TuesdayBreakfast.Items.Remove(meal);
            TuesdayLunch.Items.Remove(meal);
            TuesdayDinner.Items.Remove(meal);

            WednesdayBreakfast.Items.Remove(meal);
            WednesdayLunch.Items.Remove(meal);
            WednesdayDinner.Items.Remove(meal);

            ThursdayBreakfast.Items.Remove(meal);
            ThursdayLunch.Items.Remove(meal);
            ThursdayDinner.Items.Remove(meal);

            FridayBreakfast.Items.Remove(meal);
            FridayLunch.Items.Remove(meal);
            FridayDinner.Items.Remove(meal);

            SaturdayBreakfast.Items.Remove(meal);
            SaturdayLunch.Items.Remove(meal);
            SaturdayDinner.Items.Remove(meal);

            SundayBreakfast.Items.Remove(meal);
            SundayLunch.Items.Remove(meal);
            SundayDinner.Items.Remove(meal);
        }

        //method to update planner listboxes after changes have been made
        private void RefreshPlanner()
        {
            MondayBreakfast.Items.Refresh();
            MondayLunch.Items.Refresh();
            MondayDinner.Items.Refresh();

            TuesdayBreakfast.Items.Refresh();
            TuesdayLunch.Items.Refresh();
            TuesdayDinner.Items.Refresh();

            WednesdayBreakfast.Items.Refresh();
            WednesdayLunch.Items.Refresh();
            WednesdayDinner.Items.Refresh();

            ThursdayBreakfast.Items.Refresh();
            ThursdayLunch.Items.Refresh();
            ThursdayDinner.Items.Refresh();

            FridayBreakfast.Items.Refresh();
            FridayLunch.Items.Refresh();
            FridayDinner.Items.Refresh();

            SaturdayBreakfast.Items.Refresh();
            SaturdayLunch.Items.Refresh();
            SaturdayDinner.Items.Refresh();

            SundayBreakfast.Items.Refresh();
            SundayLunch.Items.Refresh();
            SundayDinner.Items.Refresh();
        }
    }
}

//To-do:
//add ingredients to meal in some way, need to use the ingredient class somewhere
//need to try to pull ingredients from link entered
//check for blank fields in meal form

//Components:

//Meal class 
//Ingredient class
//GroceryItem class - inherits from ingredient bc is an ingredient & need more of
//MealPlan, collection of meals
//notes

//requirements:
//Loops - loop through the items in a list of grocery items to display on grocery list
//Methods - to create meal objects, groceryItem objects, edit/delete from either
//Classes - classes for meal and GroceryItems
//Inheritance - groceryItems inherits from Ingredient
//Strings, Array or Lists - list to store ingredients/gorcerylist items
//Model-View-Controller (MVC) software architecture 
//Multithreading - loading meals from database
//Searching and Sorting, or LINQ - filtering groceryitems by name/ingredient
//Exception Handling
