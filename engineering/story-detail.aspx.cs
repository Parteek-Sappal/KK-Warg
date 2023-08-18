using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class engineering_story_detail : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["eventsid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rprdetail, "select eventsid,EventsTitle,tagline,uploadevents,largeimage,shortdesc,eventsdesc from events where ntypeid=11 and status=1 and eventsid=@eventsid order by eventsdate,displayorder", parameters);
            }
        }
    }
}