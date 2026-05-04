using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace INFOTC4400_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Meal> meals = new List<Meal>();
        public List<GroceryItem> groceryItems = new List<GroceryItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //want to save either grociery items or meals
            try
            {
                //groceryItems
                string ingredientName = ItemName_TexBox.Text;
                double quantityToPurchase = Convert.ToDouble(Quantity_TexBox.Text);
                string category = Category_TexBox.Text;

                //autoset properties
                int quantity = Convert.ToInt32(quantityToPurchase);
                string measurment = "ounce";

                //set grocery properties
                GroceryItem newItem = new GroceryItem(
                    ingredientName,
                    quantity,
                    measurment,
                    quantityToPurchase,
                    category
                    );

                //add to list
                groceryItems.Add(newItem);

                //meals
                string mealName = Meal_TexBox.Text;
                string link = Link_TexBox.Text;

                //use pre-built list for checkboxes
                List<String> selectedDays = new List<String>();

                if(Monday_CheckBox.IsChecked == true)
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
                    MessageBox.Show("Please select at least 1 day.");
                    return;
                }

                string mealDays = string.Join(",", selectedDays);

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
                    else if(day == "Tuesday")
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
                    else if(day == "Wednesday")
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
                    else if(day == "Thursday")
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
                    else if(day == "Friday")
                    {
                        if(mealTime == MealTimeType.Breakfast)
                        {
                            FridayBreakfast.Items.Add(mealName);
                        }
                        else if(mealTime == MealTimeType.Lunch)
                        {
                            FridayLunch.Items.Add(mealName);
                        }
                        else if(mealTime == MealTimeType.Dinner)
                        {
                            FridayDinner.Items.Add(mealName);
                        }
                    }
                    else if(day == "Saturday")
                    {
                        if(mealTime == MealTimeType.Breakfast)
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
                    else if(day == "Sunday")
                    {
                        if(mealTime == MealTimeType.Breakfast)
                        {
                            SundayBreakfast.Items.Add(mealName);
                        }
                        else if(mealTime == MealTimeType.Lunch)
                        {
                            SundayLunch.Items.Add(mealName);
                        }
                        else if(mealTime == MealTimeType.Dinner)
                        {
                            SundayDinner.Items.Add(mealName);
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroceryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //after an item on listbox is selected, pop up in the text boxes and deleted

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
