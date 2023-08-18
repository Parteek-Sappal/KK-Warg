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

public partial class index : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    Boolean d2 = false, d5 = false, d1 = false;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            form1.Attributes.Add("Action", Request.RawUrl);
            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(73));
            litacademics.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select pagedescription from pagemaster where pageid=@pageid", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(31));
            litlifeatkkwarg.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(22));
            litsmalldesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(2));
            litabout.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(44));
            litrecruiters.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid", parameters)));

            litplacement.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select pagedescription1 from pagemaster where pageid=@pageid", parameters)));

           binddata();
           
        }
    }
    private void binddata()
    {

     

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptnotice, "select eventsid,eventstitle,tagline,uploadevents,uploadfile,colorcode,eventsdate from events where ntypeid=10 and status=1 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptfacilities, "select pageid,pagename,linkname,pageurl,rewriteurl from pagemaster where pagestatus=1 and parentid=22 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptfacilitydetail, "select pageid,pagename,linkname,pageurl,smalldesc,uploadbanner,rewriteurl from pagemaster where pagestatus=1 and parentid=22 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptplacement, "select spid,name,course,session,company,photo,branch,shortdesc from Placedstudent where status=1 and showonhome=1 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rpttestimonials, "select distinct ttype.* from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid where t.status=1 and t.showonhome=1 order by ttype.displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rpttestimonialsdetail, "select distinct ttype.* from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid where t.status=1 and t.showonhome=1 order by ttype.displayorder", parameters);
  
        //11/08/223
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptmediatype, "select distinct ntype.* from events e inner join newstype ntype on ntype.ntypeid=e.ntypeid where e.status=1 and ntype.status=1 and ntype.ntypeid in (1,2,6) order by ntype.displayorder", parameters);


    }
    protected void rptnotice_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            ank.HRef = "/uploads/files/" + lituploadfile.Text;
            ank.Attributes.Add("target", "_blank");
        }
    }
    #region By Poonam old code
  
    //protected void rpttab_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
    //        Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

    //        if (e.Item.ItemIndex == 0)
    //        {
    //            ank.Attributes.Add("class", "active");
    //        }
    //        ank.Attributes.Add("data-bs-target", ".happening-tab" + Conversion.Val(litntypeid.Text));
    //        ank.Attributes.Add("data-bs-toggle", "tab");
    //    }
    //}
    //protected void rpttabcontent_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");
    //        Repeater rptnews = (Repeater)e.Item.FindControl("rptnews");
    //        HtmlContainerControl divmain = (HtmlContainerControl)e.Item.FindControl("divmain");

    //        if (e.Item.ItemIndex == 0)
    //        {
    //            divmain.Attributes.Add("class", "tab-pane active happening-tab" + Conversion.Val(litntypeid.Text));
    //        }
    //        else
    //        {
    //            divmain.Attributes.Add("class", "tab-pane happening-tab" + Conversion.Val(litntypeid.Text));
    //        }

    //        parameters.Clear();
    //        parameters.Add("@ntypeid", Conversion.Val(litntypeid.Text));
    //        clsm.repeaterDatashow_Parameter(rptnews, "select top 6 ntypeid,eventsid,eventstitle,eventsdate,shortdesc,uploadevents,colorcode from events where ntypeid=@ntypeid and status=1 and showonhome=1 order by displayorder", parameters);
    //    }
    //}
    //protected void rptnews_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        HtmlContainerControl div1 = (HtmlContainerControl)e.Item.FindControl("div1");
    //        HtmlContainerControl div2 = (HtmlContainerControl)e.Item.FindControl("div2");
    //        HtmlContainerControl div3 = (HtmlContainerControl)e.Item.FindControl("div3");
    //        HtmlContainerControl div4 = (HtmlContainerControl)e.Item.FindControl("div4");
    //        HtmlContainerControl div5 = (HtmlContainerControl)e.Item.FindControl("div5");
    //        HtmlContainerControl div6 = (HtmlContainerControl)e.Item.FindControl("div6");
    //        Literal litntypeid=(Literal)e.Item.FindControl("litntypeid");
    //        Literal liteventsid=(Literal)e.Item.FindControl("liteventsid");
    //        Literal liteventstitle = (Literal)e.Item.FindControl("liteventstitle");
    //        Literal Lituploadevents = (Literal)e.Item.FindControl("Lituploadevents");
    //        HtmlAnchor a1 = (HtmlAnchor)e.Item.FindControl("a1");
    //        HtmlAnchor a2 = (HtmlAnchor)e.Item.FindControl("a2");
    //        HtmlAnchor a3 = (HtmlAnchor)e.Item.FindControl("a3");
    //        HtmlAnchor a4 = (HtmlAnchor)e.Item.FindControl("a4");
    //        HtmlAnchor a5 = (HtmlAnchor)e.Item.FindControl("a5");
    //        HtmlAnchor a6 = (HtmlAnchor)e.Item.FindControl("a6");
    //        double ntypeid, eventsid;

    //        ntypeid=Conversion.Val(litntypeid.Text);
    //        eventsid = Conversion.Val(liteventsid.Text);
    //        if (!string.IsNullOrEmpty(Lituploadevents.Text))
    //        {
    //            LinkDetail(ntypeid, eventsid, liteventstitle.Text, a1);
    //            div1.Visible = true;
    //        }
    //        else
    //        {
    //            if (!d2)
    //            {
    //                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a2);
    //                div2.Visible = true;
    //                d2 = true;
    //                d5 = false;
    //            }
    //            else
    //            {
    //                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a5);
    //                div5.Visible = true;
    //                d5 = true;
    //                d2 = false;
    //            }
    //        }
    //    }
    //}
    #endregion

    private void LinkDetail(double ntypeid, double eventsid, string eventstitle, HtmlAnchor a)
    {
        if (ntypeid == 1)
        {
            a.HRef = "/news-detail/" + clsm.replacestring(eventstitle) + "/" + Conversion.Val(eventsid);
        }
        else
        {
            a.HRef = "/events-detail/" + clsm.replacestring(eventstitle) + "/" + Conversion.Val(eventsid);
        }
    }
    protected void rptfacilities_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            if (e.Item.ItemIndex == 0)
            {
                anchlink.Attributes.Add("class", "active");
            }
            anchlink.Attributes.Add("data-bs-target", ".facility-tab" + (e.Item.ItemIndex + 1));

            if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
            {
                anchlink.HRef = litpageurl.Text;
                anchlink.Target = "_blank";
            }
            else
            {
                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                }
                else
                {
                    anchlink.HRef = "~/" + litpageurl.Text;
                }
            }
        }
    }
    protected void rptfacilitydetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            HtmlContainerControl panel2 = (HtmlContainerControl)e.Item.FindControl("panel2");


            if (e.Item.ItemIndex == 0)
            {
                panel1.Attributes.Add("class", "tab-pane active facility-tab" + (e.Item.ItemIndex + 1));
                panel2.Attributes.Add("class", "panel-collapse collapse show in facility-collapse" + (e.Item.ItemIndex + 1));
            }
            else
            {
                panel1.Attributes.Add("class", "tab-pane facility-tab" + (e.Item.ItemIndex + 1));
                panel2.Attributes.Add("class", "panel-collapse collapse in facility-collapse" + (e.Item.ItemIndex + 1));
            }
           
        }
    }

    protected void rpttestimonials_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littesid = (Literal)e.Item.FindControl("littesid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            if (e.Item.ItemIndex == 0)
            {
                ank.Attributes.Add("class", "active");
            }
            ank.Attributes.Add("data-bs-target", ".testimonials-tab" + (e.Item.ItemIndex + 1));
        }
    }
    protected void rpttestimonialsdetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littesid = (Literal)e.Item.FindControl("littesid");
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            Repeater rptinner = (Repeater)e.Item.FindControl("rptinner");

            if (e.Item.ItemIndex == 0)
            {
                panel1.Attributes.Add("class", "tab-pane active testimonials-tab" + (e.Item.ItemIndex + 1));
            }
            else
            {
                panel1.Attributes.Add("class", "tab-pane testimonials-tab" + (e.Item.ItemIndex + 1));
            }
            parameters.Clear();
            parameters.Add("@tesid", Conversion.Val(littesid.Text));
            clsm.repeaterDatashow_Parameter(rptinner, "select t.testimonialid,t.testimonialname,t.testimonialdesc,t.desg,t.uploadphoto,t.detaildesc,t.placed,t.branch,t.batch,t.tesid from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid where t.status=1 and t.showonhome=1 and t.tesid=@tesid order by t.displayorder", parameters);
            
        }
    }


    // 11/08/2023
    protected void rptmediatype_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            if (e.Item.ItemIndex == 0)
            {
                ank.Attributes.Add("class", "active");
            }

            ank.Attributes.Add("data-bs-target", ".happening-tab" + (e.Item.ItemIndex + 1));

            parameters.Clear();
            parameters.Add("@ntypeid", Conversion.Val(litntypeid.Text));
            clsm.repeaterDatashow_Parameter(rptmediadetail, "select distinct ntype.* from events e inner join newstype ntype on ntype.ntypeid=e.ntypeid where e.status=1 and ntype.status=1 and ntype.ntypeid in (1,2,6) order by ntype.displayorder", parameters);
        }
    }

    protected void rptmediadetail_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("emp");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");            
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            Repeater rptevenstone = (Repeater)e.Item.FindControl("rpteventsone");
            Repeater rptevensttwo = (Repeater)e.Item.FindControl("rpteventstwo");
            Repeater rptevenstthree = (Repeater)e.Item.FindControl("rptevenstthree");
            Repeater rpteventsfour = (Repeater)e.Item.FindControl("rpteventsfour");
            Repeater rpteventsfive = (Repeater)e.Item.FindControl("rpteventsfive");
            Repeater rpteventssix = (Repeater)e.Item.FindControl("rpteventssix");

            if (e.Item.ItemIndex == 0)
            {
                panel1.Attributes.Add("class", "tab-pane active happening-tab" + (e.Item.ItemIndex + 1));
            }
            else
            {
                panel1.Attributes.Add("class", "tab-pane happening-tab" + (e.Item.ItemIndex + 1));
            }
            string strsql = "select top 6 e.* from events e inner join newstype ntype on ntype.ntypeid=e.ntypeid where e.status=1 and ntype.status=1 and ntype.ntypeid='"+ Conversion.Val(litntypeid.Text) +"' order by ntype.displayorder";
            SqlDataAdapter sda = new SqlDataAdapter(strsql, clsm.strconnect);
            sda.Fill(ds, 0, 1, "emp");
            rptevenstone.DataSource = ds.Tables["emp"].DefaultView;
            rptevenstone.DataBind();

            ds.Tables.Clear();
            sda.Fill(ds, 1, 1, "emp");
            rptevensttwo.DataSource = ds.Tables["emp"].DefaultView;
            rptevensttwo.DataBind();

            ds.Tables.Clear();
            sda.Fill(ds, 2, 1, "emp");
            rptevenstthree.DataSource = ds.Tables["emp"].DefaultView;
            rptevenstthree.DataBind();

            ds.Tables.Clear();
            sda.Fill(ds, 3, 1, "emp");
            rpteventsfour.DataSource = ds.Tables["emp"].DefaultView;
            rpteventsfour.DataBind();

            ds.Tables.Clear();
            sda.Fill(ds, 4, 1, "emp");
            rpteventsfive.DataSource = ds.Tables["emp"].DefaultView;
            rpteventsfive.DataBind();

            ds.Tables.Clear();
            sda.Fill(ds, 5, 1, "emp");
            rpteventssix.DataSource = ds.Tables["emp"].DefaultView;
            rpteventssix.DataBind();
            
        }
    }
    protected void rptevenstone_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl fg1 = (HtmlContainerControl)e.Item.FindControl("fg1");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

            if (string.IsNullOrEmpty(lituploadevents.Text))
            {
                fg1.Visible = false;
            }
            if (litcolorcode.Text != "FFFFFF")
            {
                ank.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
            }
            if (Conversion.Val(litntypeid.Text) == 1)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
            }
        }
    }
    protected void rptevensttwo_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

            if (Conversion.Val(litntypeid.Text) == 1)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
            }
        }
    }
    protected void rptevenstthree_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl fg1 = (HtmlContainerControl)e.Item.FindControl("fg1");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

            if (string.IsNullOrEmpty(lituploadevents.Text))
            {
                fg1.Visible = false;
            }
            if (litcolorcode.Text != "FFFFFF")
            {
                ank.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
            }

            if (Conversion.Val(litntypeid.Text) == 1)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
            }
        }
    }
    protected void rpteventsfour_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl fg1 = (HtmlContainerControl)e.Item.FindControl("fg1");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

            if (string.IsNullOrEmpty(lituploadevents.Text))
            {
                fg1.Visible = false;
            }
            if (litcolorcode.Text != "FFFFFF")
            {
                ank.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
            }
            if (Conversion.Val(litntypeid.Text) == 1)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
            }
        }
    }
    protected void rptevenstfive_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

            if (litcolorcode.Text != "FFFFFF")
            {
                ank.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
            }
            if (Conversion.Val(litntypeid.Text) == 1)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
            }
        }
    }
    protected void rpteventssix_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl fg1 = (HtmlContainerControl)e.Item.FindControl("fg1");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

            if (string.IsNullOrEmpty(lituploadevents.Text))
            {
                fg1.Visible = false;
            }
            if (litcolorcode.Text != "FFFFFF")
            {
                ank.Attributes.Add("style", "background-color:#" + litcolorcode.Text);
            }
            if (Conversion.Val(litntypeid.Text) == 1)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=133&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=34&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/news-details.aspx?mpgid=32&pgidtrail=198&eventsid=" + Conversion.Val(liteventsid.Text);
            }
        }
    }

  
   
}