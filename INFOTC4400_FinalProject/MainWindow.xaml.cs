 using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
