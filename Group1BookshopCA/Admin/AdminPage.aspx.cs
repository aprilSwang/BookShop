using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group1BookshopCA.Logic;
using Group1BookshopCA.Models;

namespace Group1BookshopCA.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {

        static Model1 books = new Model1();

        protected void Page_Load(object sender, EventArgs e)
        {
            string bookAction = Request.QueryString["BookAction"];
            if (bookAction == "add")
            {
                LabelAddStatus.Text = "Book added!";
            }

            if (bookAction == "remove")
            {
                LabelRemoveStatus.Text = "Book removed!";
            }
        }

        static int Name2Cat(string cat)
        {
            List<Category> result = books.Categories.Where
                     (c => c.Name.Equals(cat)).ToList<Category>();
            if (result.Count == 0)
            {
                Category c = new Category { Name = cat };
                books.Categories.Add(c);
                books.SaveChanges();
                return c.CategoryID;
            }
            else
                return result[0].CategoryID;
        }


        protected void AddBookButton_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Images/");
            if (ProductImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    ProductImage.PostedFile.SaveAs("/Images/" + ProductImage.FileName);

                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                // Add product data to DB.
                Book b = new Book
                {
                    Title = AddTitle.Text,
                    CategoryID = Name2Cat(DropDownAddCategory.SelectedValue),
                    ISBN = AddISBN.Text,
                    Author = AddAuthor.Text,
                    Price = Decimal.Parse(AddProductPrice.Text),
                    Stock = 10
                };
                books.Books.Add(b);
                books.SaveChanges();

                bool addSuccess = Convert.ToBoolean(books.Books.Add(b));

                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?BookAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Unable to add new product to database.";
                }
            }
            else
            {
                LabelAddStatus.Text = "Unable to accept file type.";
            }
        }

        //public IQueryable GetCategories()
        //{
        //    var _db = new Group1BookshopCA.Models.ProductContext();
        //    IQueryable query = _db.Categories;
        //    return query;
        //}

        //public IQueryable GetBooks()
        //{
        //    var _db = new Group1BookshopCA.Models.ProductContext();
        //    IQueryable query = _db.Books;
        //    return query;
        //}

        //protected void RemoveProductButton_Click(object sender, EventArgs e)
        //{
        //    using (var _db = new Group1BookshopCA.Models.ProductContext())
        //    {
        //        int bookId = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
        //        var myItem = (from c in _db.Books where c.BookID == bookId select c).FirstOrDefault();
        //        if (myItem != null)
        //        {
        //            _db.Books.Remove(myItem);
        //            _db.SaveChanges();

        //            // Reload the page.
        //            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
        //            Response.Redirect(pageUrl + "?ProductAction=remove");
        //        }
        //        else
        //        {
        //            LabelRemoveStatus.Text = "Unable to locate product.";
        //        }
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm4.aspx");
        }
    }
}
