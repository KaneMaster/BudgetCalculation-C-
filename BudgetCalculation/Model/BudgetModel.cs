using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;


namespace BudgetCalculation
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class BudgetModel
    {
        private readonly SQLiteConnection conn = new SQLiteConnection("Data Source=budget.db");

        public BudgetModel()
        {
            Connect();
        }

        ~BudgetModel()
        {
            Disconnect();
        }

        /// <summary>
        /// Connect to database
        /// </summary>
        void Connect()
        {
            conn.Open();
        }

        void Disconnect()
        {
            conn.Close();
        }

        /// <summary>
        /// Get a list of groups of goods
        /// </summary>
        /// <returns>List of groups</returns>
        public List<ProductInfo> GetGoups()
        {
            SQLiteCommand comm = new SQLiteCommand("select * from [group]", conn);
            SQLiteDataReader reader = comm.ExecuteReader();
            List<ProductInfo> res = new List<ProductInfo>();
            while (reader.Read())
            {
                res.Add(new ProductInfo { Id = Convert.ToInt32(reader[0]), Name = reader[1].ToString() });
            }
            reader.Close();
            return res;
        }

        public List<ProductInfo> GetSubGroups()
        {
            SQLiteCommand comm = new SQLiteCommand("select * from [subgroup]", conn);
            SQLiteDataReader reader = comm.ExecuteReader();
            List<ProductInfo> res = new List<ProductInfo>();
            while (reader.Read())
            {
                res.Add(new ProductInfo { Id = Convert.ToInt32(reader[0]), Name = reader[1].ToString() });
            }
            reader.Close();
            return res;
        }



    }
}
