using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CAServiceReference; //(allows just CAServiceClient to be used below)

public partial class GrantPage : System.Web.UI.Page
{
    CAServiceClient CASR = new CAServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userkey"]==null)
        {
            Response.Redirect("Default.aspx");

        }
        if(!IsPostBack)
        {
            FillGrantList();
        }

    }

    protected void FillGrantList()
    {
        GrantType[] grants = CASR.GetGrantTypes();
        GrantsDropDownList.DataSource = grants;
        GrantsDropDownList.DataTextField = "GrantTypeName";
        GrantsDropDownList.DataValueField = "GrantTypeKey";
        GrantsDropDownList.DataBind();
    }



    protected void GrantButton_Click(object sender, EventArgs e)
    {
        int key = (int)Session["userkey"];
        GrantRequest gr = new GrantRequest();
        gr.GrantRequestDate = DateTime.Now;
        gr.GrantRequestExplanation = ExplainTextBox.Text;
        gr.GrantRequestAmount = decimal.Parse(AmountTextBox.Text);
        gr.GrantTypeKey = int.Parse(GrantsDropDownList.Text.ToString());
            //int.Parse(GrantsDropDownList.SelectedValue).ToString();
        gr.PersonKey = key;
        bool result = CASR.ApplyForGrant(gr);
        if(result)
        {
            ResultLabel.Text = "Grant submitted";
        }
        else
        {
            ResultLabel.Text = "There was a problem";
        }
    }
}