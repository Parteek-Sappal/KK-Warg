using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class engineering_usercontrols_search : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    string Str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }

    }  
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txtsearch.Text.Trim()))
        {
            Response.Redirect("~/engineering/search.aspx?mpgid=163&pgidtrail=163&search=" + Server.UrlEncode(txtsearch.Text).Trim(), true);
        }

    }
    protected void txtsearch_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtsearch.Text.Trim()))
        {
            Response.Redirect("~/engineering/search.aspx?mpgid=163&pgidtrail=163&search=" + Server.UrlEncode(txtsearch.Text).Trim(), false);
        }
    }
   
}