using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group1BookshopCA
{
    public partial class _Default : Page
    {
        Model1 A = new Model1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AllButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string defSearchString = searchTextBox.Text;
            string defCriteria = RadioButtonList1.SelectedValue.ToString();

            Response.Redirect("Books.aspx?defSearchString=" + defSearchString + "&defCriteria=" + defCriteria);
        }
    }
}