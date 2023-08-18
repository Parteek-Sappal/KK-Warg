using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class engineering_newsdetail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    double ntypeid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["eventsid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rptnewdetail, "select eventsid,eventstitle,ntypeid,eventsdate,shortdesc,eventsdesc,uploadevents,colorcode,largeimage from events where status=1 and eventsid=@eventsid order by eventsdate desc", parameters);

                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"].ToString()));
                ntypeid = Conversion.Val(clsm.SendValue_Parameter("select ntypeid from events where eventsid=@eventsid", parameters));
                parameters.Add("@ntypeid", ntypeid);

                //clsm.repeaterDatashow_Parameter(rptewlatednews, "select top 3 eventsid,eventstitle,ntypeid,eventsdate,shortdesc,eventsdesc,uploadevents,colorcode,largeimage from events where status=1 and eventsid not in ('"+ Conversion.Val(ViewState["eventsid"]) +"') and ntypeid in (1,2) order by eventsdate desc", parameters);
                clsm.repeaterDatashow_Parameter(rptewlatednews, "select top 3 eventsid,eventstitle,ntypeid,eventsdate,shortdesc,eventsdesc,uploadevents,colorcode,largeimage from events where status=1 and eventsid not in ('" + Conversion.Val(ViewState["eventsid"]) + "') and ntypeid=@ntypeid order by eventsdate desc", parameters);

                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rptmediaphoto, "select photoid,albumid,phototitle,uploadphoto from mediaAlbumPhoto where status=1 and albumid=@albumid order by displayorder", parameters);
                if (rptmediaphoto.Items.Count > 0)
                {
                    paneleventsphoto.Visible = true;
                }
            }
        }
    }
    protected void rptnewdetail_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            Literal litlargeimage = (Literal)e.Item.FindControl("litlargeimage");
            HtmlContainerControl panlelarge = (HtmlContainerControl)e.Item.FindControl("panleimage");

            if (!string.IsNullOrEmpty(litlargeimage.Text))
            {
                panlelarge.Visible = true;
            }

            ViewState["eventsid"] = Conversion.Val(liteventsid.Text);
        }
    }
    protected void rptewlatednews_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            HtmlContainerControl fg1 = (HtmlContainerControl)e.Item.FindControl("fg1");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");

            if (litcolorcode.Text != "FFFFFF")
            {
                ank.Attributes.Add("class", "happening-thumb");
                ank.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
                fg1.Visible = false;
            }

            if (!string.IsNullOrEmpty(lituploadevents.Text))
            {
                ank.Attributes.Add("class", "");

            }
            else
            {
                fg1.Visible = false;
            }

            ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        UserControl breadcrumbs1 = (UserControl)Master.FindControl("breadcrumbs1");
        breadcrumbs1.Visible = false;
    }
}