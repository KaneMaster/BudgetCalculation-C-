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

        public List<BudgetElement> GetExpensesList(DateTime dateStart, DateTime dateEnd)
        {
            List<BudgetElement> res = new List<BudgetElement>();
            SQLiteCommand comm = new SQLiteCommand(
                "select l.id, g.name as groups, sg.name as subgroup, g2.name as product,  l.price, l.count_products " +
                "from [list_content] l "+
                    "left join [group] g on l.group_id = g.id "+
                    "left join [subgroup] sg on l.subgroup_id = sg.id "+
                    "left join [goods] g2 on l.product_id = g2.id "+
                "where[purchases_date] >= '"+dateStart.ToString("yyyy-MM-dd")+"' and [purchases_date] < '"+dateEnd.ToString("yyyy-MM-dd") +"'", conn);
            SQLiteDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                res.Add(new BudgetElement {
                    Id = Convert.ToInt32(reader[0]),
                    //Date = (DateTime)reader[1],
                    Group = reader[1].ToString(),
                    SubGroup = reader[2].ToString(),
                    Name = reader[3].ToString(),
                    Price = Convert.ToDouble(reader[4]),
                    CountGoods = Convert.ToInt32(reader[5]),
                    Units = "Ед. изм."
                });
            }
            return res;
        }

    }
}
