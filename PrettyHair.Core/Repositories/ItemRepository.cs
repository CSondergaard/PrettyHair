using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PrettyHair.Core.Interfaces;
using PrettyHair.Core.Entities;

namespace PrettyHair.Core.Repositories
{
    public class ItemRepository
    {
        private static string connectionstring = "Server=ealdb1.eal.local; Database=ejl06_db; User Id=ejl06_usr; Password=Baz1nga6";
        private Dictionary<int, IItem> Items = new Dictionary<int, IItem>();
        private int ID = 0;

        public ItemRepository()
        {

        }

        public Dictionary<int, IItem> GetItems()
        {
            return Items;
        }

        public void RefreshItems()
        {
            Clear();

            using (SqlConnection db = new SqlConnection(connectionstring))
            {
                db.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM ITEMS", db);
                sql.CommandType = CommandType.Text;

                SqlDataReader reader = sql.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IItem item       = new Item();
                        item.Name        = reader["ItemName"].ToString();
                        item.Description = reader["ItemDesc"].ToString();
                        item.Price       = (double)reader["ItemPrice"];
                        item.Amount      = (int)reader["ItemAmount"];

                        AddItem(item, (int)reader["ItemID"]);
                    }
                }
            }
        }

        public void CreateItem(IItem item)
        {
            using (SqlConnection db = new SqlConnection(connectionstring))
            {
                db.Open();

                SqlCommand sql = new SqlCommand("InsertItem", db);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.Add(new SqlParameter("ItemName",   item.Name));
                sql.Parameters.Add(new SqlParameter("ItemDesc",   item.Description));
                sql.Parameters.Add(new SqlParameter("ItemPrice",  item.Price));
                sql.Parameters.Add(new SqlParameter("ItemAmount", item.Amount));

                sql.ExecuteNonQuery();
            }

            AddItem(item, GetLastInsertedID());
        }

        public int GetLastInsertedID()
        {
            int ID = 0;

            using (SqlConnection db = new SqlConnection(connectionstring))
            {
                db.Open();

                SqlCommand sql  = new SqlCommand("LastItemID", db);
                sql.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sql.ExecuteReader();

                reader.Read();
                ID = (int)reader["ItemID"];
            }

            return ID;
        }

        private void AddItem(IItem item, int ID)
        {
            Items.Add(ID, item);
        }

        public void RemoveItemByID(int ID)
        {
            using (SqlConnection db = new SqlConnection(connectionstring))
            {
                db.Open();

                SqlCommand sql = new SqlCommand("RemoveItem", db);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.Add(new SqlParameter("ID", ID));

                sql.ExecuteNonQuery();
            }

            Items.Remove(ID);
        }

        public IItem GetItemByID(int ID)
        {
            return Items[ID];
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int NextID()
        {
            return ++ID;
        }
    }
}
