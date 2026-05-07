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
                    //might need to add something that stops a meal from getting entered into an already used meal slot
                    foreach (string day in selectedDays)
                    {
                        if (day == "Monday")
                        {
                            if (mealTime == MealTimeType.Breakfast)
                            {
                                MondayBreakfast.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Lunch)
                            {
                                MondayLunch.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Dinner)
                            {
                                MondayDinner.Items.Add(mealName);
                            }
                        }
                        else if (day == "Tuesday")
                        {
                            if (mealTime == MealTimeType.Breakfast)
                            {
                                TuesdayBreakfast.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Lunch)
                            {
                                TuesdayLunch.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Dinner)
                            {
                                TuesdayDinner.Items.Add(mealName);
                            }
                        }
                        else if (day == "Wednesday")
                        {
                            if (mealTime == MealTimeType.Breakfast)
                            {
                                WednesdayBreakfast.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Lunch)
                            {
                                WednesdayLunch.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Dinner)
                            {
                                WednesdayDinner.Items.Add(mealName);
                            }
                        }
                        else if (day == "Thursday")
                        {
                            if (mealTime == MealTimeType.Breakfast)
                            {
                                ThursdayBreakfast.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Lunch)
                            {
                                ThursdayLunch.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Dinner)
                            {
                                ThursdayDinner.Items.Add(mealName);
                            }
                        }
                        else if (day == "Friday")
                        {
                            if (mealTime == MealTimeType.Breakfast)
                            {
                                FridayBreakfast.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Lunch)
                            {
                                FridayLunch.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Dinner)
                            {
                                FridayDinner.Items.Add(mealName);
                            }
                        }
                        else if (day == "Saturday")
                        {
                            if (mealTime == MealTimeType.Breakfast)
                            {
                                SaturdayBreakfast.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Lunch)
                            {
                                SaturdayLunch.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Dinner)
                            {
                                SaturdayDinner.Items.Add(mealName);
                            }
                        }
                        else if (day == "Sunday")
                        {
                            if (mealTime == MealTimeType.Breakfast)
                            {
                                SundayBreakfast.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Lunch)
                            {
                                SundayLunch.Items.Add(mealName);
                            }
                            else if (mealTime == MealTimeType.Dinner)
                            {
                                SundayDinner.Items.Add(mealName);
                            }
                        }
                    }

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
            //after an item on listbox is selected, pop up in the text boxes and deleted
            GroceryItem selected = GroceryListBox.SelectedItem as GroceryItem;

            if (selected != null)
            {
                groceryItems.Remove(selected);
            }

            //clear input fields
            ItemName_TexBox.Text = string.Empty;
            Quantity_TexBox.Text = string.Empty;
            Category_TexBox.Text = string.Empty;
            Measurement_TexBox.Text = string.Empty;
            IsBought_CheckBox.IsChecked = false;

            GroceryListBox.Items.Refresh();

            //need to add delete functionality for meals
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
    }
}


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
