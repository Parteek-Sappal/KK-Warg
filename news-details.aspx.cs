using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class news_details : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    double ntypeid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindNewsDetail();

            parameters.Clear();
            parameters.Add("@albumid", Conversion.Val(Request.QueryString["eventsid"]));
            clsm.repeaterDatashow_Parameter(rptmediaphoto, "select photoid,albumid,phototitle,uploadphoto from mediaAlbumPhoto where status=1 and albumid=@albumid order by displayorder", parameters);
            if (rptmediaphoto.Items.Count > 0)
            {
                paneleventsphoto.Visible = true;
            }

        }
    }
    private void BindNewsDetail()
    {
        parameters.Clear();
        if (Conversion.Val(Request.QueryString["eventsid"]) > 0)
        {
            parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"].ToString()));
            ntypeid = Conversion.Val(clsm.SendValue_Parameter("select ntypeid from events where eventsid=@eventsid", parameters));
            parameters.Add("@ntypeid", ntypeid);
            clsm.repeaterDatashow_Parameter(rptnewsdetais, "select eventsid,eventstitle,eventsdate,shortdesc,eventsdesc,uploadevents,colorcode from events where eventsid=@eventsid and status=1", parameters);

            string strsql;
            //strsql = "select top 3 eventsid,eventstitle,shortdesc,EventsDesc,uploadevents,Eventsdate,displayorder,case when colorcode<>'FFFFFF' then 'background-color:#' + colorcode else '' end  colorcode from events where status=1 and showonhome=1 and eventsid<>@eventsid order by Eventsdate desc";
            strsql = "select top 3 eventsid,eventstitle,shortdesc,EventsDesc,uploadevents,Eventsdate,displayorder,case when colorcode<>'FFFFFF' then 'background-color:#' + colorcode else '' end  colorcode from events where status=1 and showonhome=1 and eventsid<>@eventsid and ntypeid=@ntypeid order by Eventsdate desc";

            clsm.repeaterDatashow_Parameter(rptothernews, strsql, parameters);
        }
    }
    protected void rptnewsdetais_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lituploadevents=(Literal)e.Item.FindControl("lituploadevents");
            HtmlContainerControl divimg=(HtmlContainerControl)e.Item.FindControl("divimg");
            
            if (lituploadevents.Text != "")
            {
                divimg.Visible = true;
            }
        }
    }
    protected void rptothernews_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {

            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            HtmlContainerControl divwithimage = (HtmlContainerControl)e.Item.FindControl("divwithimage");
            HtmlContainerControl divwithoutimage = (HtmlContainerControl)e.Item.FindControl("divwithoutimage");
            HtmlAnchor ankwithimage = (HtmlAnchor)e.Item.FindControl("ankwithimage");
            HtmlAnchor ankwithoutimage = (HtmlAnchor)e.Item.FindControl("ankwithoutimage");
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");

            if (lituploadevents.Text != "")
            {
                divwithimage.Visible = true;
                divwithoutimage.Visible = false;
            }
            else
            {
                divwithoutimage.Visible = true;
                divwithimage.Visible = false;
            }

            ankwithimage.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
            ankwithoutimage.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        UserControl breadcrumbs1 = (UserControl)Master.FindControl("breadcrumbs1");
        breadcrumbs1.Visible = false;
    }
}