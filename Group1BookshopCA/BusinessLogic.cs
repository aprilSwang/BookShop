using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Group1BookshopCA
{
    public class BusinessLogic
    {
        public void AddOrders(string email, int bookid, int qty, decimal price)
        {
            using (Model3 entities = new Model3())
            {
                string email1 = email;
                int BookID1 = bookid;
                int Quantity1 = qty;
                decimal Price1 = price;
                string cons = "Data Source = (local); Initial Catalog = BookOrders; Integrated Security = SSPI";
                SqlConnection cn = new SqlConnection(cons);
                cn.Open();

                string InsertQuery = @"Insert into OrderedBooks Values ({0},{1},{2},{3});";
                entities.Database.ExecuteSqlCommand(InsertQuery, BookID1, email1,Quantity1,Price1);
                entities.SaveChanges();
                cn.Close();

            }
        }

        public int CheckStock(int x)
        {
            using (Model1 entities = new Model1())
            {
                return entities.Books.Where(b => b.BookID == x).Select(v => v.Stock).First();
            }
        }
        public void ReduceStock (int bookid, int qty)
        {
            using (Model1 entities = new Model1())
            {
                //Book m = new Book();
                Book m = entities.Books.Where(x => x.BookID == bookid).First();
                m.Stock-=qty;
            }
        }

        public static List<Book> ListSearch(string criteria, string keyword)
        {
            using (Model1 A = new Model1())
            {
                if (criteria == "Title")
                {
                    return (A.Books.Where(x => x.Title.Contains(keyword)).ToList<Book>());
                }
                if (criteria == "Author")
                {
                    return (A.Books.Where(x => x.Author.Contains(keyword)).ToList<Book>());
                }
                if (criteria == "ISBN")
                {
                    return (A.Books.Where(x => x.ISBN.ToString().Contains(keyword)).ToList<Book>());
                }
                else
                {
                    return null;
                }
            }
        }

        public static void UpdateOrder(int bookId,
       string Title, int categoryid, string isbn, string author, int stock, decimal price, int discount)
        {
            using (Model1 entities = new Model1())
            {
                Book order = entities.Books.Where(p => p.BookID == bookId).First<Book>();
                order.Title = Title;
                order.CategoryID = categoryid;
                order.ISBN = isbn;
                order.Author = author;
                order.Stock = stock;
                order.Price = price;
                // order = discount;
                entities.SaveChanges();
            }
        }
        public static List<Book> ListOrdersBy(string title)
        {
            using (Model1 entities = new Model1())
            {
                return entities.Books.Where(p => p.Title == title).ToList<Book>();
            }
        }
    }
}