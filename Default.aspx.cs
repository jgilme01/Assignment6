using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAServiceReference;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if ispostback here
        //if (!IsPostBack)
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CAServiceClient CASC = new CAServiceClient();
        int key = CASC.PersonLogin(UserNameTextBox.Text, PasswordTextBox.Text);
        if(key != 0)
        {
            Session["userkey"] = key;
            Response.Redirect("GrantPage.aspx");
       
        }
        else
        {
            ResultLabel.Text = "Login Failed";
        }
    }
}