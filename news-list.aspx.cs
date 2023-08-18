using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class news_list : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            if (Conversion.Val(Request.QueryString["ntypeid"]) == 1)
            {
                parameters.Add("@ntypeid", 1);
            }
            else if (Conversion.Val(Request.QueryString["ntypeid"]) == 2)
            {
                parameters.Add("@ntypeid", 2);
            }
            //litntype.Text= clsm.SendValue_Parameter("select ntype from newstype where ntypeid = @ntypeid and status=1 order by displayorder", parameters).ToString();
            clsm.Fillcombo_Parameter("select ntype,ntypeid from newstype where ntypeid in (1,6,2,12,4,10) and status=1 order by displayorder", parameters, newstype);
            newstype.Items[0].Text = "All Type";

            BindMainNews();
        }
    }
    private void BindMainNews()
    {
        ViewState["eventsid"] = "";
        parameters.Clear();
        string strsql;
        strsql = "select top 1 eventsid,ntypeid,eventstitle,shortdesc,EventsDesc,uploadevents,Eventsdate,displayorder from events where 1=1 and uploadevents<>'' and ntypeid in (1,6,2,12,4,10) and status=1 and showonhome=1 ";
        if (Conversion.Val(newstype.SelectedValue) > 0)
        {
            strsql += " and ntypeid=" + Conversion.Val(newstype.SelectedValue);
        }
        if (Conversion.Val(year.SelectedValue) > 0)
        {
            strsql += " and year(eventsdate)='" + Conversion.Val(year.SelectedValue) + "' ";
        }
        if (Conversion.Val(month.SelectedValue) > 0)
        {
            strsql += " and month(eventsdate)='" + Conversion.Val(month.SelectedValue) + "' ";
        }
        strsql += " order by Eventsdate desc";

        clsm.repeaterDatashow_Parameter(rptmainnews,strsql, parameters);

        BindOtherNews();
    }

    private void BindOtherNews()
    {
        string eventsid;
        eventsid = ViewState["eventsid"].ToString();
        eventsid = eventsid.TrimEnd(',');
        string strsql;
        strsql = "select eventsid,eventstitle,shortdesc,EventsDesc,uploadevents,Eventsdate,displayorder, colorcode,ntypeid from events where 1=1 and ntypeid in (1,6,2,12,4,10) and status=1 and showonhome=1 ";
        if (eventsid != "")
        {
            strsql += " and eventsid not in (" + eventsid + ") ";
        }
        if (Conversion.Val(newstype.SelectedValue) > 0)
        {
            strsql += " and ntypeid=" + Conversion.Val(newstype.SelectedValue);
        }
        if (Conversion.Val(year.SelectedValue) > 0)
        {
            strsql += " and year(eventsdate)='" + Conversion.Val(year.SelectedValue) + "' ";
        }
        if (Conversion.Val(month.SelectedValue) > 0)
        {
            strsql += " and month(eventsdate)='" + Conversion.Val(month.SelectedValue) + "' ";
        }
        strsql += " order by cast(Eventsdate as date) desc,DisplayOrder";
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptothernews, strsql, parameters);
        //Response.Write(strsql);
        if (rptothernews.Items.Count > 10)
        {
            //panelloadmore.Visible = true;
        }

    }
    protected void newstype_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindMainNews();
    }
    protected void month_OnSelectedIndexChanged(object sender,EventArgs e)
    {
        BindMainNews();
    }
    protected void year_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindMainNews();
    }
    protected void rptmainnews_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
        ViewState["eventsid"] += liteventsid.Text + ",";
        HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
        Literal litntyepid = (Literal)e.Item.FindControl("litntyepid");

        if (Conversion.Val(litntyepid.Text) == 1)
        {
            ank.HRef = "/news-details.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 2)
        {
            ank.HRef = "/news-details.aspx?mpgid=34&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 4)
        {
            ank.HRef = "/news-details.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 6)
        {
            ank.HRef = "/news-details.aspx?mpgid=198&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 10)
        {
            ank.HRef = "/news-details.aspx?mpgid=33&pgidtrail=33&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 12)
        {
            ank.HRef = "/news-details.aspx?mpgid=173&pgidtrail=173&eventsid=" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void rptothernews_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HtmlContainerControl divwithimage = (HtmlContainerControl)e.Item.FindControl("divwithimage");
        HtmlContainerControl divwithoutimage = (HtmlContainerControl)e.Item.FindControl("divwithoutimage");
        Literal litimg = (Literal)e.Item.FindControl("litimg");
        HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
        Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
        HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
        HtmlAnchor ank1 = (HtmlAnchor)e.Item.FindControl("ank1");
        Literal litntyepid = (Literal)e.Item.FindControl("litntyepid");
        Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");

        if (litcolorcode.Text != "FFFFFF")
        {
            panel1.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
        }

        if (litimg.Text == "")
        {
            divwithimage.Visible=false;
            divwithoutimage.Visible = true;
        }
        else
        {
            divwithimage.Visible=true ;
            divwithoutimage.Visible=false;
        }
       

        if (Conversion.Val(litntyepid.Text) == 1)
        {
            ank1.HRef = "/news-details.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
            ank.HRef = "/news-details.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 2)
        {
            ank1.HRef = "/news-details.aspx?mpgid=34&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
            ank.HRef = "/news-details.aspx?mpgid=34&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 4)
        {
            ank1.HRef = "/news-details.aspx?mpgid=38&pgidtrail=38&eventsid=" + Conversion.Val(liteventsid.Text);
            ank.HRef = "/news-details.aspx?mpgid=38&pgidtrail=38&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 6)
        {
            ank1.HRef = "/news-details.aspx?mpgid=198&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
            ank.HRef = "/news-details.aspx?mpgid=198&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 10)
        {
            ank1.HRef = "/news-details.aspx?mpgid=33&pgidtrail=33&eventsid=" + Conversion.Val(liteventsid.Text);
            ank.HRef = "/news-details.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
        }
        else if (Conversion.Val(litntyepid.Text) == 12)
        {
            ank1.HRef = "/news-details.aspx?mpgid=173&pgidtrail=173&eventsid=" + Conversion.Val(liteventsid.Text);
            ank.HRef = "/news-details.aspx?mpgid=173&pgidtrail=173&eventsid=" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Literal lititle = (Literal)Master.FindControl("lititle");
        if (Conversion.Val(newstype.SelectedValue) > 0)
        {
            lititle.Text = Convert.ToString(clsm.SendValue_Parameter("select ntype from newstype where ntypeid=" + Conversion.Val(newstype.SelectedValue), parameters));
        }

    }
}