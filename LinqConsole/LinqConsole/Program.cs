using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Xml.Linq;
namespace LinqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //第一個練習();
            //第二個練習();
            //第三個練習();
            //第四個練習();
            //第五個練習();
            第六個練習_從XML中讀資料();
            Console.ReadLine();
        }
        public static void 第一個練習()
        {
            Console.WriteLine("第一個練習");
            int[] source = new int[] { 0, -5, 12, -54, 5, -67, 3, 6 };

            //p.5
            foreach (int item in source)
            {
                Console.WriteLine(item);
            }
        }
        public static void 第二個練習()
        {
            Console.WriteLine("第二個練習");
            int[] source = new int[] { 0, -5, 12, -54, 5, -67, 3, 6 };

            List<int> results = new List<int>();
            foreach (int interger in source)
            {
                if (interger > 0)
                {
                    results.Add(interger);
                }
            }
            Comparison<int> comparsion = delegate(int a, int b)
            {
                return b - a;
            };
            foreach (int item in results)
            {
                Console.WriteLine(item);
            }
        }
        public static void 第三個練習()
        {
            Console.WriteLine("第三個練習");
            int[] source = new int[] { 0, -5, 12, -54, 5, -67, 3, 6 };

            var results = from interger in source
                          where interger > 0
                          orderby interger descending
                          select interger;

            foreach (int item in results)
            {
                Console.WriteLine(item);
            }
        }
        public static void 第四個練習_ADONET讀DB資料()
        {
            Console.WriteLine("第四個練習");
            Dictionary<String, decimal> results = new Dictionary<String, decimal>();

            using (SqlConnection connection = new SqlConnection(@" data source=(localdb)\v11.0;initial catalog=Northwind;integrated security=True"))
            {
                using (SqlCommand command = new SqlCommand(
                    @"Select Products.ProductName,Products.UnitPrice  from 
                    ( 
                    Products 
                    left join Categories 
                    on  Products.CategoryID=Categories.CategoryID
                    )
                    WHERE Categories.CategoryName =@categoryName", connection))
                {
                    command.Parameters.AddWithValue("@categoryName", "Beverages");
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = (string)reader["ProductName"];
                            decimal unitPrice = (decimal)reader["UnitPrice"];
                            results.Add(productName, unitPrice);
                        }
                    }
                }


            }
            foreach (KeyValuePair<string, decimal> item in results)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value.ToString(CultureInfo.InvariantCulture));
            }

        }

        public static void 第五個練習_從Db中讀資料()
        {
            Console.WriteLine("第五個練習");

            using (NorthwindEntities database = new NorthwindEntities())
            {
                var results = from product in database.Products
                              where product.Categories.CategoryName == "Beverages"
                              select new
                                       {
                                           product.ProductName,
                                           product.UnitPrice
                                       };


                foreach (var item in results)
                {
                    Console.WriteLine("{0}: {1}", item.ProductName, item.UnitPrice.ToString());
                }
            }
        }

        public static void 第六個練習_從XML中讀資料()
        {
            XDocument xml = XDocument.Load(@"http://weblogs.asp.net/dixin/rss.aspx");
            var results = from item in xml.Root.Element("channel").Elements("item")
                          where item.Elements("category").Any(category => category.Value == "C#")
                          orderby DateTime.Parse(item.Element("pubDate").Value)
                          select item.Element("title").Value;
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static void 第七個練習_wikipedia()
        {
            //todo: 不知道引用資料
            //WikipediaContext datacontext = new WikipediaContext();

            //var opensearch = (
            //    from wikipedia in datacontext.OpenSearch
            //    where wikipedia.Keyword == "linq"
            //    select wikipedia).Take(10);

            //// dl_results is an ASP.NET DataList
            //dl_results.DataSource = opensearch;
            //dl_results.DataBind();
        }
        
    }
}
