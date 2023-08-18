using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_footer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            anknews.HRef = "/news-list.aspx?mpgid=32&pgidtrail=133&ntypeid=1";
            ankevents.HRef = "/news-list.aspx?mpgid=32&pgidtrail=34&ntypeid=2";
        }
    }
}