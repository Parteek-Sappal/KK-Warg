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


public partial class engineering_newsdept : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["deptid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptnewstop, "select top 1 e.eventsid,e.eventstitle,e.ntypeid,e.eventsdate,e.shortdesc,e.eventsdesc,e.uploadevents,e.colorcode,e.largeimage from events e inner join map_institute_happenings map on map.eventsid=e.eventsid where status=1 and e.ntypeid in (1,2) and map.deptid=@deptid order by e.eventsdate desc", parameters);

                parameters.Clear();
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptnewsevents, "select e.eventsid,e.eventstitle,e.ntypeid,e.eventsdate,e.shortdesc,e.eventsdesc,e.uploadevents,e.colorcode,e.largeimage from events e inner join map_institute_happenings map on map.eventsid=e.eventsid where status=1 and e.ntypeid in (1,2) and e.eventsid not in ('" + Conversion.Val(ViewState["eventsid"]) + "') and map.deptid=@deptid order by e.eventsdate desc", parameters);
                if (rptnewsevents.Items.Count > 10)
                {
                    panelloadmore.Visible = true;
                }

                parameters.Clear();
                clsm.Fillcombo_Parameter("select ntype,ntypeid from newstype where status=1 and ntypeid in (1,2) order by displayorder", parameters, ddltype);
                ddltype.Items[0].Text = "Select Type";

                parameters.Clear();
                clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", parameters, ddlcollage);
                ddlcollage.Items[0].Text = "Select Collage";

                parameters.Clear();
                clsm.Fillcombo_Parameter("select distinct year(eventsdate) as year,year(eventsdate) as yearid from events where status=1 and isnull(year(eventsdate),'')<>'' order by year(eventsdate) desc ", parameters, ddlyear);
                ddlyear.Items[0].Text = "Select Year";
            }
        }
    }
    private void binddata()
    {
        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));   
        string sql = "select e.eventsid,e.eventstitle,e.ntypeid,e.eventsdate,e.shortdesc,e.eventsdesc,e.uploadevents,e.colorcode,e.largeimage from events e inner join map_institute_happenings map on map.eventsid=e.eventsid where status=1 and e.eventsid not in ('" + Conversion.Val(ViewState["eventsid"]) + "') and deptid=@deptid ";
        if (Conversion.Val(ddltype.SelectedValue) > 0)
        {
            sql += " and e.ntypeid=" + Conversion.Val(ddltype.SelectedValue);
        }
        else
        {
            sql += " and e.ntypeid in (1,2)";
        }
        if (Conversion.Val(ddlcollage.SelectedValue) > 0)
        {
            sql += " and map.campusid=" + Conversion.Val(ddlcollage.SelectedValue);
        }
        if (Conversion.Val(ddlmonth.SelectedValue) > 0)
        {
            sql += " and month(e.eventsdate)=" + Conversion.Val(ddlmonth.SelectedValue);
        }
        if (Conversion.Val(ddlyear.SelectedValue) > 0)
        {
            sql += " and year(e.eventsdate)=" + Conversion.Val(ddlyear.SelectedValue);
        }
        sql += "  order by e.eventsdate desc";
        clsm.repeaterDatashow_Parameter(rptnewsevents, sql, parameters);
    }
    protected void rptnewstop_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            ViewState["eventsid"] = Conversion.Val(liteventsid.Text);

            ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
        }
    }

    protected void rptnewsevents_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            HtmlContainerControl fg1 = (HtmlContainerControl)e.Item.FindControl("fg1");

            if (litcolorcode.Text != "FFFFFF")
            {
                ank.Attributes.Add("class", "happening-thumb");
                ank.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
                fg1.Visible = false;
            }          
            ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void ddltypeselect(object sender, EventArgs e)
    {
        binddata();
    }
    protected void ddlcollageselect(object sender, EventArgs e)
    {
        binddata();
    }
    protected void ddlmonthselect(object sender, EventArgs e)
    {
        binddata();
    }
    protected void ddlyearselect(object sender, EventArgs e)
    {
        binddata();
    }

 
}