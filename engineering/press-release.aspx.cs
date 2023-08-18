using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;


public partial class engineering_press_release : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", parameters, ddlcollage);
            ddlcollage.Items[0].Text = "Select Collage";

            parameters.Clear();
            clsm.Fillcombo_Parameter("select distinct year(eventsdate) as year,year(eventsdate) as yearid from events where status=1 and isnull(year(eventsdate),'')<>'' order by year(eventsdate) desc ", parameters, ddlyear);
            ddlyear.Items[0].Text = "Select Year";

            BindData();
        }
    }
    private void BindData()
    {
        parameters.Clear();
        string strsql;
        strsql = "select e.eventsid,e.eventstitle,e.ntypeid,e.eventsdate,e.shortdesc,e.eventsdesc,e.uploadevents,e.colorcode,e.largeimage,e.uploadfile from events e inner join map_happening_campus map on map.eventsid=e.eventsid where status=1 and e.ntypeid=3 ";
        if (Conversion.Val(ddlmonth.SelectedValue) > 0)
        {
            strsql += " and month(e.eventsdate)=" + Conversion.Val(ddlmonth.SelectedValue);
        }
        if (Conversion.Val(ddlyear.SelectedValue) > 0)
        {
            strsql += " and year(e.eventsdate)=" + Conversion.Val(ddlyear.SelectedValue);
        }
        if (Conversion.Val(ddlcollage.SelectedValue) > 0)
        {
            strsql += " and map.campusid=" + Conversion.Val(ddlcollage.SelectedValue);
        }
        strsql += " order by e.Eventsdate desc";
       
        clsm.repeaterDatashow_Parameter(rptfile, strsql, parameters);
        if (rptfile.Items.Count > 10)
        {
            panelloadmore.Visible = true;
        }
    }
    protected void rptfile_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");
        HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
        HtmlImage img = (HtmlImage)e.Item.FindControl("img");
        if (!string.IsNullOrEmpty(lituploadfile.Text))
        {
            img.Visible = true;
            ank.HRef = "/uploads/files/" + lituploadfile.Text;
        }
        else
        {
            img.Visible = false;
        }
    }
    protected void ddlcollageselect(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlmonthselect(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlyearselect(object sender, EventArgs e)
    {
        BindData();
    }
 
}