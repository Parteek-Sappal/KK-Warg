using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class engineering_alumni_story : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptstory, "select e.eventsid,e.EventsTitle,e.tagline,e.uploadevents,e.largeimage from events e inner join map_happening_campus map on map.eventsid=e.eventsid where ntypeid=11 and status=1 order by eventsdate,displayorder", parameters);
        if (rptstory.Items.Count > 10)
        {
           // panelloadmore.Visible = true;
        }
    }
    protected void rptstory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/engineering/story-detail.aspx?mpgid=88&pgidtrail=92&eventsid=" + Conversion.Val(liteventsid.Text);

        }
    }
}