using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAServiceReference;

public partial class ViewGrants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userkey"]==null)
        {
            Response.Redirect("Default.aspx");
        }

        GetGrants();
    }

    protected void GetGrants()
    {
        CAServiceClient CASC = new CAServiceClient();
        int key = (int)Session["userkey"];
        GrantInfo[] grants = CASC.GetGrantsByPerson(key);
        GrantsGridView.DataSource = grants;
        GrantsGridView.DataBind();

    }
}