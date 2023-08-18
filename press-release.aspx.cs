using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;


public partial class press_release : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {
        parameters.Clear();
        string strsql;
        strsql="select eventsid,eventstitle,eventsdate,shortdesc,EventsDesc,uploadevents,uploadfile,colorcode from events where status=1 and showonhome=1 and ntypeid=3 ";
        if (Conversion.Val(month.SelectedValue) > 0)
        {
            strsql += " and month(eventsdate)=" + Conversion.Val(month.SelectedValue);
        }
        if (Conversion.Val(year.SelectedValue) > 0)
        {
            strsql += " and year(eventsdate)=" + Conversion.Val(year.SelectedValue);
        }
        strsql += " order by Eventsdate desc";
        clsm.repeaterDatashow_Parameter(rptfile, strsql, parameters);
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
    protected void month_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void year_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}