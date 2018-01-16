using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.SessionState;

namespace Group1BookshopCA
{
    public partial class ShoppingCart : System.Web.UI.Page
    {

        List<GVI> i = new List<GVI>();

        List<Book> n = new List<Book>();
        decimal price = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Book> list = new List<Book>();
            //list = (List<Book>)Session["cart"];

            //foreach (var c in list)
            //{ Label1.Text += c.ToString(); }

            if (!IsPostBack)
            {
                Label2.Text = "";
                //List<string> list = new List<string>();
                //list = (List<string>)Session["cart"];

                if (Session["cart"] == null)
                {
                    //Label2.Text = "Your cart is empty.";
                    //Label2.Visible = true;
                }
                else
                {
                    GridView1.DataSource = Session["cart"];
                    GridView1.DataBind();

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        price += Convert.ToDecimal(row.Cells[4].Text) * Convert.ToDecimal(row.Cells[5].Text);
                    }

                    Label2.Text += "Total: $" + price.ToString();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int x = e.RowIndex;
            i = (List<GVI>)Session["cart"];
            i.RemoveAt(x);
            n = (List<Book>)Session["books"];
            n.RemoveAt(x);

            GridView1.DataSource = i;
            GridView1.DataBind();

            price = 0;

            foreach (GridViewRow r in GridView1.Rows)
            {
                price += Convert.ToDecimal(r.Cells[4].Text) * Convert.ToDecimal(r.Cells[5].Text);
            }
            Label2.Text = "Total: $"+ price.ToString();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            //string quantity = (row.FindControl("Quantity") as DropDownList).SelectedValue;
            //int z = i.Count;
            //int[] array = new int[z];

            price = 0;

            foreach (GridViewRow r in GridView1.Rows)
            {
                price += Convert.ToDecimal(r.Cells[4].Text) * Convert.ToDecimal(r.Cells[5].Text);
            }
            Label2.Text = "Total: $"+ price.ToString();

            //i[e.RowIndex].QUANTITY = Convert.ToInt32(quantity);
            GridView1.EditIndex = -1;
            BindGrid();
        }
        private void BindGrid()
        {
            GridView1.DataSource = i;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        private void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BusinessLogic b = new BusinessLogic();
            try
            {
                foreach (GridViewRow i in GridView1.Rows)
                {
                    int qty = 1;
                    int bookid = Convert.ToInt32(i.Cells[1].Text);
                    decimal price = Convert.ToDecimal(i.Cells[4].Text);
                    string email = "hello";

                    b.AddOrders(email, bookid, qty, price);

                    b.ReduceStock(bookid, qty);
                }

                Response.Write("<script language='javascript'>alert('Order Successful!');</script>");
                Session.Clear();
                Session["cart"] = new List<GVI>();

                Session["books"] = new List<Book>();
                Server.Transfer("Books.aspx", true);

                //Response.Write("<script>alert('Order Successful! Thank you shopping with us.');</script>");
                

               // Response.Redirect("Books.aspx");

            }
            catch (Exception)
            {
                Response.Write("Something Wrong.");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //BusinessLogic b = new BusinessLogic();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DropDownList ddl = (e.Row.FindControl("foodlist") as DropDownList);
            //    int stock = b.CheckStock();
            //    if (ddl != null)
            //    {
            //        ddl.DataSource = stock;
            //        ddl.DataTextField = "Stock";
            //        ddl.DataValueField = "Stock";
            //        ddl.DataBind();
            //        ddl.Items.FindByText(stock).Selected = true;
            //    }
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                GridView1.DataSource = i.ToList();

                DropDownList ddl = (e.Row.FindControl("ddlStock") as DropDownList);
                if (ddl != null)
                {
                    List<int> m = new List<int>();
                    string id = i[e.Row.RowIndex].BOOKID.ToString();

                    Model1 context = new Model1();
                    int s= context.Books.Where(x => x.BookID.ToString() == id).Select(v => v.Stock).First();

                    for(int i=1;i<s;i++)
                    {
                        m[i] = i;
                    }
                    ddl.DataSource = m.ToList();
                    ddl.DataBind();
                }
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Session["cart"] = new List<GVI>();

            Session["books"] = new List<Book>();

            Response.Redirect("Books.aspx");
        }
    }
}