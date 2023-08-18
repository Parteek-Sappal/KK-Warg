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
using System.Web.Services;

public partial class engineering_index : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    int collegeid = 1;
    Boolean d2 = false, d5 = false, d1 = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            litadmission.Text = "ADMISSIONS 2023";
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptnotice, "select e.eventsid,e.eventstitle,e.tagline,e.uploadevents,uploadfile,e.colorcode,e.eventsdate,map.collageid from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where ntypeid=10 and status=1 and map.collageid=1 order by e.displayorder", parameters);

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(103));
            litdepartmenttile.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and collageid=1 and pagestatus=1", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(103));
            littitle.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select pagedescription1 from pagemaster where pageid=@pageid and collageid=1 and pagestatus=1", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(113));
            litplacement.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and collageid=1 and pagestatus=1", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(75));
            litrec.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select pagedescription1 from pagemaster where pageid=@pageid and collageid=1 and pagestatus=1", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(75));
            litabouthome.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select pagedescription2 from pagemaster where pageid=@pageid and collageid=1 and pagestatus=1", parameters)));

            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptcourses, "select levelid,levelname,details  from courselevel_master  where levelid in (1,2) and status=1 order by displayorder", parameters);

            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptothercourses, "select levelid,levelname,details  from courselevel_master  where levelid not in (1,2) and status=1 order by displayorder", parameters);

            ankallcourse.HRef = "/engineering/course.aspx?mpgid=102&pgidtrail=102#course-select-panel";
            ankdeptcourse.HRef = "/engineering/department-list.aspx?mpgid=77&pgidtrail=146";

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(75));
            lithome.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and collageid=1 and pagestatus=1", parameters)));


            //parameters.Clear();
            ////clsm.repeaterDatashow_Parameter(rpttab, "select ntypeid,ntype from newstype where ntypeid in (1,2) and status=1 order by displayorder", parameters);
            //clsm.repeaterDatashow_Parameter(rpttab, "select distinct n.ntypeid,n.ntype,m.displayorder from newstype n join Events e on n.ntypeid=e.ntypeid join map_institute_happenings m on e.Eventsid=m.eventsid where n.status=1 and e.status=1 and e.showonhome=1 and m.showonhome=1 and deptid=0 order by m.displayorder", parameters);

            //parameters.Clear();
            ////clsm.repeaterDatashow_Parameter(rpttabcontent, "select ntypeid,ntype from newstype where ntypeid in (1,2) and status=1 order by displayorder", parameters);
            //clsm.repeaterDatashow_Parameter(rpttabcontent, "select distinct n.ntypeid,n.ntype,m.displayorder from newstype n join Events e on n.ntypeid=e.ntypeid join map_institute_happenings m on e.Eventsid=m.eventsid where n.status=1 and e.status=1 and e.showonhome=1 and m.showonhome=1 and deptid=0 order by m.displayorder", parameters);

            //parameters.Clear();
            //parameters.Add("@collegeid", collegeid);
            //clsm.repeaterDatashow_Parameter(rptgallery, "select top 6 a.albumid,typeid,albumtitle,albumdesc,uploadaimage from album a inner join map_photo_gallery c on a.albumid=c.albumid where c.collageid=@collegeid and c.deptid=0 and status=1 and c.showonhome=1 order by c.displayorder", parameters);

            //12/08/223
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptmediatype, "select distinct ntype.* from events e inner join newstype ntype on ntype.ntypeid=e.ntypeid inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.status=1 and ntype.status=1 and ntype.ntypeid in (1,2,6) and map.deptid=0 and map.showonhome=1 order by ntype.displayorder", parameters);

            binddeptlist();
        }
    }

    #region Code By Poonam
    //protected void rptgallery_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        Literal littypeid = (Literal)e.Item.FindControl("littypeid");
    //        Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
    //        Label lblcnt = (Label)e.Item.FindControl("lblcnt");
    //        HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
    //        int cnt = 0;

    //        parameters.Clear();
    //        parameters.Add("@albumid", Conversion.Val(litalbumid.Text));
    //        if (Conversion.Val(littypeid.Text) == 1)
    //        {
    //            cnt = (int)Conversion.Val(clsm.SendValue_Parameter("select count(*) from albumphoto where status=1 and albumid=@albumid", parameters).ToString());
    //            lblcnt.Text = cnt + " Photos";
    //            ank.HRef = "/engineering/mediadetail.aspx?mpgid=31&pgid1=32&pgidtrail=38&albumid=" + Conversion.Val(litalbumid.Text);
    //        }
    //        else if (Conversion.Val(littypeid.Text) == 2)
    //        {
    //            cnt = (int)Conversion.Val(clsm.SendValue_Parameter("select count(*) from vedio where status=1 and albumid=@albumid", parameters).ToString());
    //            lblcnt.Text = cnt + " videos";
    //            ank.HRef = "/engineering/videodetail.aspx?mpgid=31&pgid1=32&pgidtrail=38&albumid=" + Conversion.Val(litalbumid.Text);
    //        }
    //        if (cnt == 0)
    //        {
    //            e.Item.Visible = false;
    //        }

    //        if (e.Item.ItemIndex == 0)
    //        {
    //            if (Conversion.Val(littypeid.Text) == 1)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb image");
    //            }
    //            else if (Conversion.Val(littypeid.Text) == 2)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb video");
    //            }
    //        }
    //        if (e.Item.ItemIndex == 1)
    //        {
    //            if (Conversion.Val(littypeid.Text) == 1)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb image full-height");
    //            }
    //            else if (Conversion.Val(littypeid.Text) == 2)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb video full-height");
    //            }
    //        }
    //        if (e.Item.ItemIndex == 2)
    //        {
    //            if (Conversion.Val(littypeid.Text) == 1)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb image");
    //            }
    //            else if (Conversion.Val(littypeid.Text) == 2)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb video");
    //            }
    //        }
    //        if (e.Item.ItemIndex == 3)
    //        {
    //            if (Conversion.Val(littypeid.Text) == 1)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb image");
    //            }
    //            else if (Conversion.Val(littypeid.Text) == 2)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb video");
    //            }
    //        }
    //        if (e.Item.ItemIndex == 4)
    //        {
    //            if (Conversion.Val(littypeid.Text) == 1)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb image");
    //            }
    //            else if (Conversion.Val(littypeid.Text) == 2)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb video");
    //            }
    //        }
    //        if (e.Item.ItemIndex >= 5)
    //        {
    //            if (Conversion.Val(littypeid.Text) == 1)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb image full-height");
    //            }
    //            else if (Conversion.Val(littypeid.Text) == 2)
    //            {
    //                ank.Attributes.Add("class", "gallery-thumb video full-height");
    //            }
    //        }
    //    }
    //}
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
    //        clsm.repeaterDatashow_Parameter(rptnews, "select top 6 ntypeid,e.eventsid,eventstitle,eventsdate,shortdesc,uploadevents,colorcode from events e inner join map_institute_happenings c on e.eventsid=c.eventsid where c.deptid=0 and ntypeid=@ntypeid and status=1 and c.showonhome=1 order by eventsdate desc", parameters);
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
    //        Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");
    //        Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
    //        Literal liteventstitle = (Literal)e.Item.FindControl("liteventstitle");
    //        Literal Lituploadevents = (Literal)e.Item.FindControl("Lituploadevents");
    //        HtmlAnchor a1 = (HtmlAnchor)e.Item.FindControl("a1");
    //        HtmlAnchor a2 = (HtmlAnchor)e.Item.FindControl("a2");
    //        HtmlAnchor a3 = (HtmlAnchor)e.Item.FindControl("a3");
    //        HtmlAnchor a4 = (HtmlAnchor)e.Item.FindControl("a4");
    //        HtmlAnchor a5 = (HtmlAnchor)e.Item.FindControl("a5");
    //        HtmlAnchor a6 = (HtmlAnchor)e.Item.FindControl("a6");
    //        double ntypeid, eventsid;
    //        ntypeid = Conversion.Val(litntypeid.Text);
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
            a.HRef = "/engineering/news-detail/" + clsm.replacestring(eventstitle) + "/" + Conversion.Val(eventsid);
        }
        else if (ntypeid == 2)
        {
            a.HRef = "/engineering/events-detail/" + clsm.replacestring(eventstitle) + "/" + Conversion.Val(eventsid);
        }
        else if (ntypeid == 6)
        {
            a.HRef = "/engineering/activity-detail/" + clsm.replacestring(eventstitle) + "/" + Conversion.Val(eventsid);
        }
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
    protected void rptcourses_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            HtmlContainerControl divcourse = (HtmlContainerControl)e.Item.FindControl("divcourse");

            ank.HRef = "/engineering/course.aspx?mpgid=102&pgidtrail=102&levelid=" + Conversion.Val(litlevelid.Text) + "#course-select-panel";
            if (Conversion.Val(litlevelid.Text) == 1)
            {
                divcourse.Attributes.Add("class", "academics-bachelor-thumb blue_border");
            }
            else
            {
                divcourse.Attributes.Add("class", "academics-bachelor-thumb red_border");
            }
        }
    }
    protected void rptothercourses_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");

            ank.HRef = "/engineering/course.aspx?mpgid=102&pgidtrail=102&levelid=" + Conversion.Val(litlevelid.Text) + "#course-select-panel";
        }
    }    
    private void binddeptlist()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptdepartmentleft, "select dept.deptid,dept.schoolid,dept.deptname,dept.departmentshortdetail,dept.departmentdetail,dept.displayname,dept.campusid from department_master dept inner join collage_master cm on cm.collageid=dept.schoolid inner join campus c on c.campusid=dept.campusid where dept.status=1 and cm.status=1 and c.status=1 and dept.schoolid=1 order by dept.displayorder", parameters);

   
        parameters.Clear();
        parameters.Add("@collageid", Conversion.Val(1));
        clsm.repeaterDatashow_Parameter(rpttestimonials, "select distinct ttype.* from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and t.showonhome=1 and map.collageid=@collageid order by ttype.displayorder", parameters);

        parameters.Clear();
        parameters.Add("@collageid", Conversion.Val(1));
        clsm.repeaterDatashow_Parameter(rpttestimonialsdetail, "select distinct ttype.* from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and t.showonhome=1 and map.collageid=@collageid order by ttype.displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptplacement, "select p.spid,p.name,p.course,p.session,p.company,p.photo,p.branch,p.shortdesc from Placedstudent p inner join collage_master cm on cm.collageid=p.schoolid where p.status=1 and cm.status=1 and p.showonhome=1 and p.schoolid=1 order by p.displayorder", parameters);
    }

    protected void rptdepartmentleft_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            if (e.Item.ItemIndex == 0)
            {
                ank.Attributes.Add("class", "active");
            }
            ViewState["deptid"] += (litdeptid.Text) + ",";
            ank.HRef = "/engineering/department.aspx?mpgid=1&pgidtrail=1&deptid=" + Conversion.Val(litdeptid.Text);
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
            parameters.Add("@collageid", Conversion.Val(1));
            clsm.repeaterDatashow_Parameter(rptinner, "select t.testimonialid,t.testimonialname,t.testimonialdesc,t.desg,t.uploadphoto,t.detaildesc,t.placed,t.branch,t.batch,t.tesid from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and ttype.status=1 and t.showonhome=1 and t.tesid=@tesid and map.collageid=@collageid order by t.displayorder", parameters);
            if (rptinner.Items.Count > 0)
            {
                paneltestimonials.Visible = true;
            }
        }
    }
    #region Course Search

    [WebMethod]
    public static string GetGraduateCourse(string prefixText)
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        parameters.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "searchcourseSP";
        cmd.Parameters.AddWithValue("@coursename", Convert.ToString(prefixText));
        cmd.Parameters.AddWithValue("@levelid", 1);
        return GetData(cmd).GetXml();


    }
    [WebMethod]
    public static string GetPostGraduateCourse(string prefixText)
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        parameters.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "searchcourseSP";
        cmd.Parameters.AddWithValue("@coursename", Convert.ToString(prefixText));
        cmd.Parameters.AddWithValue("@levelid", 2);
        return GetData(cmd).GetXml();
    }
    [WebMethod]
    public static string Getsearchprogram(string prefixText)
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        parameters.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "searchcourseSP";
        cmd.Parameters.AddWithValue("@coursename", Convert.ToString(prefixText));
        cmd.Parameters.AddWithValue("@levelid", 3);
        return GetData(cmd).GetXml();
    }

    [WebMethod]
    public static string Getmobileprogram(string prefixText)
    {
        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        parameters.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "searchcourseSP";
        cmd.Parameters.AddWithValue("@coursename", Convert.ToString(prefixText));
        cmd.Parameters.AddWithValue("@levelid", 0);
        return GetData(cmd).GetXml();
    }

    private static DataSet GetData(SqlCommand cmd)
    {
        mainclass clsm = new mainclass();
        string strconnect = clsm.strconnect;
        using (SqlConnection con = new SqlConnection(strconnect))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "Customers");
                    return ds;
                }
            }
        }
    }

    #endregion

    // 12/08/2023
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
            clsm.repeaterDatashow_Parameter(rptmediadetail, "select distinct ntype.* from events e inner join newstype ntype on ntype.ntypeid=e.ntypeid inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.status=1 and ntype.status=1 and ntype.ntypeid in (1,2,6) and map.deptid=0 and map.showonhome=1 order by ntype.displayorder", parameters);
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
            string strsql = "select top 6 e.* from events e inner join newstype ntype on ntype.ntypeid=e.ntypeid inner join map_happening_campus map on map.eventsid=e.Eventsid where e.status=1 and ntype.status=1 and ntype.ntypeid='" + Conversion.Val(litntypeid.Text) + "' order by ntype.displayorder";
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
            Literal litntypeid = (Literal)e.Item.FindControl("litntypeid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl fg1 = (HtmlContainerControl)e.Item.FindControl("fg1");
            Literal litcolorcode = (Literal)e.Item.FindControl("litcolorcode");
            Literal lituploadevents = (Literal)e.Item.FindControl("lituploadevents");

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
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=174&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=170&eventsid=" + Conversion.Val(liteventsid.Text);
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
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=174&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=170&eventsid=" + Conversion.Val(liteventsid.Text);
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
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=174&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=170&eventsid=" + Conversion.Val(liteventsid.Text);
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
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=174&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=170&eventsid=" + Conversion.Val(liteventsid.Text);
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
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=174&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=170&eventsid=" + Conversion.Val(liteventsid.Text);
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
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=160&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 2)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=174&eventsid=" + Conversion.Val(liteventsid.Text);
            }
            else if (Conversion.Val(litntypeid.Text) == 6)
            {
                ank.HRef = "/engineering/newsdetail.aspx?mpgid=159&pgidtrail=170&eventsid=" + Conversion.Val(liteventsid.Text);
            }
        }
    }

}