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

public partial class engineering_department : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    string banner = "";
    int deptid;
    int collegeid = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
        }
    }
    private void binddata()
    {
        deptid = (int)Conversion.Val(Request.QueryString["deptid"]);
        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        banner = Convert.ToString(clsm.SendValue_Parameter("select admissionimg from department_master where deptid=@deptid and status=1", parameters));
        if (!string.IsNullOrEmpty(banner))
        {
            img.ImageUrl = "/uploads/banner/" + banner;
            img.AlternateText = banner;
            panelbanner.Visible = true;
        }
        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        litdeptshortdesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select departmentshortdetail from department_master where deptid=@deptid and status=1", parameters)));

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        litdeptdesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select departmentdetail from department_master where deptid=@deptid and status=1", parameters)));

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        litInfrastructure.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select rearchcontent from department_master where deptid=@deptid and status=1", parameters)));

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        litRecruiters.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select rearchlink from department_master where deptid=@deptid and status=1", parameters)));

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        litprograms.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select rearchimage from department_master where deptid=@deptid and status=1", parameters)));

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        litvission.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select admission from department_master where deptid=@deptid and status=1", parameters)));

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        litprogramoffered.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select deptfacilities from department_master where deptid=@deptid and status=1", parameters)));

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        parameters.Add("@pageid", Conversion.Val(1));
        litplacmenttitle.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemasterdept where pageid=@pageid and deptid=@deptid", parameters)));

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptplacement, "select p.spid,p.name,p.course,p.session,p.company,p.photo,p.branch,p.shortdesc from Placedstudent p inner join collage_master cm on cm.collageid=p.schoolid where p.status=1 and cm.status=1 and p.showonhome=1 and p.schoolid=1 order by p.displayorder", parameters);

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        clsm.repeaterDatashow_Parameter(rptfaculty, "select afm.*,fdesignation.designation as designationname from Addfacultymaster afm inner join Facultydesignation fdesignation on fdesignation.fdid=afm.Designation inner join map_institute_department_faculty map on map.facultyid=afm.facultyid and map.deptid=@deptid where afm.status=1 and fdesignation.status=1 and map.showonhome=1 order by afm.displayorder", parameters);
        if (rptfaculty.Items.Count > 0)
        {
            panelfaculty.Visible = true;
        }

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        clsm.repeaterDatashow_Parameter(rpttestimonials, "select distinct ttype.* from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and ttype.status=1 and t.showonhome=1 and map.deptid=@deptid order by ttype.displayorder", parameters);

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        clsm.repeaterDatashow_Parameter(rpttestimonialsdetail, "select distinct ttype.* from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and ttype.status=1 and t.showonhome=1 and map.deptid=@deptid order by ttype.displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rpttab, "select ntypeid,ntype from newstype where ntypeid in (1,2) and status=1 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rpttabcontent, "select ntypeid,ntype from newstype where ntypeid in (1,2) and status=1 order by displayorder", parameters);

        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        parameters.Add("@collegeid", collegeid);
        clsm.repeaterDatashow_Parameter(rptgallery, "select top 6 a.albumid,typeid,albumtitle,albumdesc,uploadaimage from album a inner join map_photo_gallery c on a.albumid=c.albumid where c.collageid=@collegeid and c.deptid=@deptid and status=1 and c.showonhome=1 order by c.displayorder", parameters);
    }
    protected void rptgallery_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            Label lblcnt=(Label)e.Item.FindControl("lblcnt");
            HtmlAnchor ank=(HtmlAnchor)e.Item.FindControl("ank");
            int cnt=0;

            parameters.Clear();
            parameters.Add("@albumid", Conversion.Val(litalbumid.Text));
            if (Conversion.Val(littypeid.Text) == 1)
            {
                cnt = (int)Conversion.Val(clsm.SendValue_Parameter("select count(*) from albumphoto where status=1 and albumid=@albumid", parameters).ToString());
                lblcnt.Text = cnt + " Photos";
                ank.HRef = "/engineering/mediadetail.aspx?mpgid=31&pgid1=32&pgidtrail=38&albumid=" + Conversion.Val(litalbumid.Text);
            }
            else if (Conversion.Val(littypeid.Text) == 2)
            {
                cnt = (int)Conversion.Val(clsm.SendValue_Parameter("select count(*) from vedio where status=1 and albumid=@albumid", parameters).ToString());
                lblcnt.Text = cnt + " videos";
                ank.HRef = "/engineering/videodetail.aspx?mpgid=31&pgid1=32&pgidtrail=38&albumid=" + Conversion.Val(litalbumid.Text);
            }
            if (cnt == 0)
            {
                e.Item.Visible = false;
            }
            if (e.Item.ItemIndex == 0)
            {
                ank.Attributes.Add("class", "gallery-thumb image");
            }
            if (e.Item.ItemIndex == 1)
            {
                ank.Attributes.Add("class", "gallery-thumb image full-height");
            }
            if (e.Item.ItemIndex == 2)
            {
                ank.Attributes.Add("class", "gallery-thumb video");
            }
            if (e.Item.ItemIndex == 3)
            {
                ank.Attributes.Add("class", "gallery-thumb image");
            }
            if (e.Item.ItemIndex == 4)
            {
                ank.Attributes.Add("class", "gallery-thumb video");
            }
            if (e.Item.ItemIndex >= 5)
            {
                ank.Attributes.Add("class", "gallery-thumb image full-height");
            }
        }
    }
    protected void rpttab_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");

            if (e.Item.ItemIndex == 0)
            {
                ank.Attributes.Add("class", "active");
            }
            ank.Attributes.Add("data-bs-target", ".happening-tab" + Conversion.Val(litntypeid.Text));
            ank.Attributes.Add("data-bs-toggle", "tab");
        }
    }
    protected void rpttabcontent_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");
            Repeater rptnews = (Repeater)e.Item.FindControl("rptnews");
            HtmlContainerControl divmain = (HtmlContainerControl)e.Item.FindControl("divmain");

            if (e.Item.ItemIndex == 0)
            {
                divmain.Attributes.Add("class", "tab-pane active happening-tab" + Conversion.Val(litntypeid.Text));
            }
            else
            {
                divmain.Attributes.Add("class", "tab-pane happening-tab" + Conversion.Val(litntypeid.Text));
            }

            parameters.Clear();
            parameters.Add("@ntypeid", Conversion.Val(litntypeid.Text));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            clsm.repeaterDatashow_Parameter(rptnews, "select top 6 ntypeid,e.eventsid,eventstitle,eventsdate,shortdesc,uploadevents,colorcode from events e inner join map_institute_happenings c on e.eventsid=c.eventsid where c.deptid=@deptid and ntypeid=@ntypeid and status=1 and c.showonhome=1 order by eventsdate desc", parameters);
        }
    }
    protected void rptnews_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlContainerControl div1 = (HtmlContainerControl)e.Item.FindControl("div1");
            HtmlContainerControl div2 = (HtmlContainerControl)e.Item.FindControl("div2");
            HtmlContainerControl div3 = (HtmlContainerControl)e.Item.FindControl("div3");
            HtmlContainerControl div4 = (HtmlContainerControl)e.Item.FindControl("div4");
            HtmlContainerControl div5 = (HtmlContainerControl)e.Item.FindControl("div5");
            HtmlContainerControl div6 = (HtmlContainerControl)e.Item.FindControl("div6");
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            Literal liteventstitle = (Literal)e.Item.FindControl("liteventstitle");
            HtmlAnchor a1 = (HtmlAnchor)e.Item.FindControl("a1");
            HtmlAnchor a2 = (HtmlAnchor)e.Item.FindControl("a2");
            HtmlAnchor a3 = (HtmlAnchor)e.Item.FindControl("a3");
            HtmlAnchor a4 = (HtmlAnchor)e.Item.FindControl("a4");
            HtmlAnchor a5 = (HtmlAnchor)e.Item.FindControl("a5");
            HtmlAnchor a6 = (HtmlAnchor)e.Item.FindControl("a6");
            double ntypeid, eventsid;

            ntypeid = Conversion.Val(litntypeid.Text);
            eventsid = Conversion.Val(liteventsid.Text);

            if (e.Item.ItemIndex == 0)
            {
                div1.Visible = true;
                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a1);
            }
            if (e.Item.ItemIndex == 1)
            {
                div2.Visible = true;
                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a2);
            }
            if (e.Item.ItemIndex == 2)
            {
                div3.Visible = true;
                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a3);
            }
            if (e.Item.ItemIndex == 3)
            {
                div4.Visible = true;
                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a4);
            }
            if (e.Item.ItemIndex == 4)
            {
                div5.Visible = true;
                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a5);
            }
            if (e.Item.ItemIndex == 5)
            {
                div6.Visible = true;
                LinkDetail(ntypeid, eventsid, liteventstitle.Text, a6);
            }
        }
    }
    private void LinkDetail(double ntypeid, double eventsid, string eventstitle, HtmlAnchor a)
    {
        if (ntypeid == 1)
        {
            a.HRef = "department/news-detail/" + clsm.replacestring(eventstitle) + "/" + Conversion.Val(eventsid) + "/" + deptid;
        }
        else if (ntypeid == 2)
        {
            a.HRef = "department/events-detail/" + clsm.replacestring(eventstitle) + "/" + Conversion.Val(eventsid) + "/" + deptid;
        }
    }
    protected void rptfaculty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfaculityid = (Literal)e.Item.FindControl("litfaculityid");
            Literal litfimage = (Literal)e.Item.FindControl("litfimage");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlImage img = (HtmlImage)e.Item.FindControl("img");

            if (string.IsNullOrEmpty(litfimage.Text))
            {
                img.Src = "/images/deafultimage.png";
            }
            else
            {
                img.Src = "/uploads/faculty/" + litfimage.Text;
            }

            ank.HRef = "/engineering/facultydetail.aspx?mpgid=104&pgidtrail=104&facultyid=" + Conversion.Val(litfaculityid.Text);

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
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            clsm.repeaterDatashow_Parameter(rptinner, "select t.testimonialid,t.testimonialname,t.testimonialdesc,t.desg,t.uploadphoto,t.detaildesc,t.placed,t.branch,t.batch,t.tesid from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and ttype.status=1 and t.showonhome=1 and t.tesid=@tesid and map.deptid=@deptid order by t.displayorder", parameters);
            if (rptinner.Items.Count > 0)
            {
                paneltestimonials.Visible = true;
            }


        }
    }

}