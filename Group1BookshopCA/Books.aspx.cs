using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Group1BookshopCA;

namespace Group1BookshopCA
{
    public partial class Books : System.Web.UI.Page
    {   
        List<GVI> cartItem = new List<GVI>();
        Model1 m = new Model1();
        string stringCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            string defSearchString;
            string defCriteria;

            if (!IsPostBack)
            {
                Repeater1.DataSource = m.Books.ToList();
                Repeater1.DataBind();

                stringCount = Repeater1.Items.Count.ToString();
                BookNumLabel.Text = "Number of books found: " + stringCount;
            }
            if (Request.QueryString["defSearchString"] != "")
            {
                defSearchString = Request.QueryString["defSearchString"];
                defCriteria = Request.QueryString["defCriteria"];

                if (defCriteria == "Title")
                {
                    Repeater1.DataSource = m.Books.Where(x => x.Title.Contains(defSearchString)).ToList();
                    Repeater1.DataBind();
                }
                else if (defCriteria == "Author")
                {
                    Repeater1.DataSource = m.Books.Where(x => x.Author.Contains(defSearchString)).ToList();
                    Repeater1.DataBind();

                }
                else if (defCriteria == "ISBN")
                {
                    Repeater1.DataSource = m.Books.Where(x => x.ISBN.ToString().Contains(defSearchString)).ToList();
                    Repeater1.DataBind();
                }

                stringCount = Repeater1.Items.Count.ToString();
                if (stringCount == "0")
                {
                    BookNumLabel.Text = "No books found with this keyword";
                }
                else
                {
                    BookNumLabel.Text = "Number of books found: " + stringCount;
                }

            }

        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchString;
            string criteriaString;

            searchString = searchTextBox.Text;
            criteriaString = RadioButtonList1.SelectedValue.ToString();

            Repeater1.DataSource = BusinessLogic.ListSearch(criteriaString, searchString);
            Repeater1.DataBind();

            stringCount = Repeater1.Items.Count.ToString();
            if (stringCount == "0")
            {
                BookNumLabel.Text = "No books found with this keyword";
            }
            else
            {
                BookNumLabel.Text = "Number of books found: " + stringCount;
            }
        }
        protected void ViewAllButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");

            //Repeater1.DataSource = m.Books.ToList();
            //Repeater1.DataBind();

            //BookNumLabel.Text = "Number of books found: " + stringCount;
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if ((string)Session["user"] == "logged out")
            {
                Response.Write("<script language='javascript'>alert('Login first.');</script>");
                Server.Transfer("/Account/Login.aspx", true);
            }
            else
            {
                int qty = ((List<GVI>)Session["cart"]).Count + 1;
                int x = e.Item.ItemIndex + 1;
                GVI cartBook = new GVI();

                //var q = m.Books.Where(b => b.BookID == x).Select(b => new { b.BookID, b.Title, b.Author });
                //cartBook = ((List<Book>)q).First<Book>();

                List<Book> cartItemV2 = new List<Book>();
                Book cartBookV2 = m.Books.Where(h => h.BookID == x).First();

                cartBook.BOOKID = m.Books.Where(b => b.BookID == x).Select(v => v.BookID).First();
                cartBook.TITLE = m.Books.Where(b => b.BookID == x).Select(v => v.Title).First();
                cartBook.AUTHOR = m.Books.Where(b => b.BookID == x).Select(v => v.Author).First();
                //cartBook.STOCK = m.Books.Where(b => b.BookID == x).Select(v =>  v.Stock).First();
                cartBook.PRICE = m.Books.Where(b => b.BookID == x).Select(v => v.Price).First();

                cartBook.QUANTITY = 1;

                //cartBook. = m.Books.Where(b => b.BookID == x).Select(v => new { v.BookID, v.Title, v.Author, v.Price, v.Stock }).First();

                int stock = m.Books.Where(b => b.BookID == x).Select(b => b.Stock).First();

                if (stock < 1)
                {
                    Label3.Text = "Book out of stock";
                    Label3.Visible = true;
                }
                else
                {
                    Label3.Text = "Book added into cart.";
                    Label3.Visible = true;
                    cartItem = (List<GVI>)Session["cart"];
                    cartItem.Add(cartBook);
                    Session["cart"] = cartItem;

                    cartItemV2 = (List<Book>)Session["books"];
                    cartItemV2.Add(cartBookV2);
                    Session["books"] = cartItemV2;

                    Button b = e.Item.FindControl("Button1") as Button;
                }
                Label5.Text = qty.ToString();

            }
        }     
    }
}