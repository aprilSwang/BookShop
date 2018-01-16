using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group1BookshopCA
{
    public class GVI
    {
        int BookID;
        string Title;
        string Author;
        decimal Price;
        //int Stock;
        int quantity;

        public GVI(int BookID,
        string Title,
        string Author,
        decimal Price,
        int quantity)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.Author = Author;
            this.Price = Price;
            //this.Stock = Stock;
            this.quantity= quantity;
        }

        public int BOOKID
        {
            get
            {
                return BookID;
            }
            set
            {
                BookID = value;
            }
        }

        public string TITLE
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
            }
        }

        public string AUTHOR
        {
            get
            {
                return Author;
            }
            set
            {
                Author = value;
            }
        }

        public decimal PRICE
        {
            get
            {
                return Price;
            }
            set
            {
                Price = value;
            }
        }

        public int QUANTITY
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        //public int STOCK
        //{
        //    get
        //    {
        //        return Stock;
        //    }
        //    set
        //    {
        //        Stock = value;
        //    }
        //}
        public GVI()
        { }
    }
}