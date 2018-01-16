using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Group1BookshopCA
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Title= Request.QueryString["bookID"];
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            GridView1.DataSource = BusinessLogic.ListOrdersBy(Title);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int bookId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Title = (row.FindControl("TextBox1") as TextBox).Text;
            int categoryid = Convert.ToInt32(row.FindControl("TextBox2") as TextBox);
            string isbn = (row.FindControl("TextBox3") as TextBox).Text;
            string author = (row.FindControl("TextBox4") as TextBox).Text;
            int stock =Convert.ToInt32(row.FindControl("TextBox5") as TextBox);
            decimal price = Convert.ToDecimal(row.FindControl("TextBox6") as TextBox);
            int discount = Convert.ToInt32(row.FindControl("TextBox7") as TextBox);
            BusinessLogic.UpdateOrder(bookId, Title, categoryid, isbn, author, stock, price, discount);
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }
    }
}