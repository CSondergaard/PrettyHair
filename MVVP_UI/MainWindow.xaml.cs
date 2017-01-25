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
using System.Data;
using System.Windows.Forms;
using System.Collections;

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
                DisplayMemberBinding = new System.Windows.Data.Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new System.Windows.Data.Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Description",
                DisplayMemberBinding = new System.Windows.Data.Binding("Desc")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Amount",
                DisplayMemberBinding = new System.Windows.Data.Binding("Amount")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Price",
                DisplayMemberBinding = new System.Windows.Data.Binding("Price")
            });

            PrintStock();

        }

        private void PrintStock()
        {
            listView.Items.Clear();
            IR.RefreshItems();

            foreach (KeyValuePair<int, IItem> item in IR.GetItems())
            {
                this.listView.Items.Add(new MyItem { Id = item.Key, Name = item.Value.Name, Desc = item.Value.Description, Amount = item.Value.Amount, Price = item.Value.Price });
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            MyItem row = (MyItem)listView.SelectedItems[0];

            if (row != null)
            {
                DialogResult res = System.Windows.Forms.MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        int id;
                        id = Convert.ToInt32(row.Id);
                        IR.RemoveItemByID(id);

                        PrintStock();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                }
                   
               
            }
            else
            {
                PrintStock();
            }




        }

        private void button1_click(object sender, RoutedEventArgs e)
        {

            double price;
            string desc;
            string name;
            int amount;
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtDesc.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtAmount.Text))
                        {
                            if (double.TryParse(txtPrice.Text, out price))
                            {

                                if (int.TryParse(txtAmount.Text, out amount))
                                {
                                    desc = txtDesc.Text;
                                    name = txtName.Text;
                                    Item item = new Item(name, desc, price, amount);
                                    IR.CreateItem(item);

                                    PrintStock();
                                    txtName.Text = "";
                                    txtDesc.Text = "";
                                    txtPrice.Text = "";
                                    txtAmount.Text = "";
                                    System.Windows.Forms.MessageBox.Show(name + " is now created");
                                    
                                    
                                }
                                else
                                {
                                   System.Windows.Forms.MessageBox.Show("Amount is not a number");
                                }
                            }
                            else
                                System.Windows.Forms.MessageBox.Show("Price is not a number");
                        }
                        else
                            System.Windows.Forms.MessageBox.Show("You need to enter amount");
                    }
                    else
                        System.Windows.Forms.MessageBox.Show("You need to enter price.");
                }
                else
                    System.Windows.Forms.MessageBox.Show("You need to enter a description");
            }
            else
                System.Windows.Forms.MessageBox.Show("You need to enter a name");


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
