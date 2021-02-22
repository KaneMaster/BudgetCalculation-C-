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

        /// <summary>
        /// Disconnect to database
        /// </summary>
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

        /// <summary>
        /// Get a list of subgroups of goods
        /// </summary>
        /// <returns>List of subgroups</returns>
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

        /// <summary>
        /// Get a products' list
        /// </summary>
        /// <param name="subGroupId">Subgroup's id</param>
        /// <returns>List of products</returns>
        public List<ProductInfo> GetGoods(int subGroupId)
        {
            SQLiteCommand comm = new SQLiteCommand("select * from [goods] where subgroup_id = " + subGroupId.ToString(), conn);
            SQLiteDataReader reader = comm.ExecuteReader();
            List<ProductInfo> res = new List<ProductInfo>();
            while (reader.Read())
            {
                res.Add(new ProductInfo { Id = Convert.ToInt32(reader[0]), Name = reader[2].ToString() });
            }
            reader.Close();
            return res;
        }

        /// <summary>
        /// Get information about budget list, which have a maximum beginning date of period  
        /// </summary>
        /// <returns>Information about budget list</returns>
        public ListInfo GetListInfo()
        {
            string sql = "SELECT * FROM[lists] where date_start = (select max(date_start) from[lists]) limit 1";
             
            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = comm.ExecuteReader();

            ListInfo res = null;
            while (reader.Read())
            {
                res = new ListInfo(Convert.ToInt32(reader[0]), Convert.ToDateTime(reader[1]), Convert.ToDateTime(reader[2]), reader[3].ToString(), Convert.ToDouble(reader[4]));
            }

            return res;
        }


        /// <summary>
        /// Get information about budget list, which have a beginning date of period lower then the parameter 
        /// </summary>
        /// <param name="lastDate">Data for search information</param>
        /// <returns>Information about budget list</returns>
        public ListInfo GetListInfo(DateTime lastDate)
        {
            string sql = "SELECT * FROM[lists] where date_start <= '"+lastDate.ToString("yyyy-MM-dd")+"' limit 1";

            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = comm.ExecuteReader();
            
            ListInfo res = null;
            while (reader.Read())
            {
                res = new ListInfo(Convert.ToInt32(reader[0]), Convert.ToDateTime(reader[1]), Convert.ToDateTime(reader[2]), reader[3].ToString(), Convert.ToDouble(reader[4]));
            }

            return res;
        }



    }
}
