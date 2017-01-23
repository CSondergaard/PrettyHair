using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;
using PrettyHair.Core.Repositories;
using PrettyHair.Core.Helpers;  

namespace MVVP_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ItemRepository IR = new ItemRepository();
        private CustomerRepository CR = new CustomerRepository();
        private OrderlineRepository OLR = new OrderlineRepository();
        private OrderRepository OR = new OrderRepository();

        public class MyItem
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Desc { get; set; }

            public int Amount { get; set; }
            public double Price { get; set; }
        }



        public MainWindow()
        {
            InitializeComponent();


            // ADD Columns
            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "ID",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Description",
                DisplayMemberBinding = new Binding("Desc")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Amount",
                DisplayMemberBinding = new Binding("Amount")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Price",
                DisplayMemberBinding = new Binding("Price")
            });
            IR.RefreshItems();
            PrintStock();
            
        }

        private void PrintStock()
        {
            foreach (KeyValuePair<int, IItem> item in IR.GetItems())
            {
                this.listView.Items.Add(new MyItem { Id = item.Key, Name = item.Value.Name, Desc = item.Value.Description, Amount = item.Value.Amount, Price = item.Value.Price });
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            IItem item = new Item();
            item.Name = AskForString("Write item name");
            item.Description = AskForString("Write item description");
            item.Amount = AskForInteger("Write item amount");
            item.Price = AskForDouble("Write item price");

            IR.CreateItem(item);

    
        }

        public string AskForString(string message = "")
        {
            if (message != "")
                Console.WriteLine(message);

            string s = "";
            Console.WriteLine("You must write something.");

            return s;
        }

        public double AskForDouble(string message = "")
        {
            if (message != "")
                Console.WriteLine(message);

            double i;
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out i))
                Console.WriteLine("You must write an number.");

            return i;
        }

        public int AskForInteger(string message = "")
        {
            if (message != "")
                Console.WriteLine(message);

            int i;
            while (!Int32.TryParse(Console.ReadLine(), out i))
                Console.WriteLine("You must write an number.");

            return i;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
