using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class course_list_group : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptcoursecms, "select top 1 smalldesc,uploadbanner from PageMaster where PageName='courses' and pagestatus=1", parameters);
            
            parameters.Clear();
            clsm.Fillcombo_Parameter("select dpname,dpid from Discipline_Master  where status=1 order by displayorder", parameters, dpid);
            dpid.Items[0].Text = "Select Stream";
            clsm.Fillcombo_Parameter("select levelname,levelid from courselevel_master where status=1 order by displayorder", parameters, courselevel_master);
            courselevel_master.Items[0].Text = "Select Level";
            BindData();
        }
    }
    private void BindData()
    {
        string strsql,strmain,strmid="",strlast="";
        int cnt;
        parameters.Clear();
        strmain = "select courseid,coursename,shortdesc,noofsemestor,d.dpname from course c left join discipline_master d on c.dpid=d.dpid left join courselevel_master l on c.levelid=l.levelid where c.status=1  ";
        if (Conversion.Val(dpid.SelectedIndex) != 0)
        {
            strmid = " and d.dpid= " + Conversion.Val(dpid.SelectedIndex);
        }
        if (Conversion.Val(courselevel_master.SelectedIndex) != 0)
        {
            strmid += " and c.levelid= " + Conversion.Val(courselevel_master.SelectedIndex);
        }
        strlast += " order by c.displayorder";
        strsql = strmain + strmid + strlast;
       
        clsm.repeaterDatashow_Parameter(rptcourse,strsql , parameters);
        strmain = "select count(*)cnt from course c left join discipline_master d on c.dpid=d.dpid left join courselevel_master l on c.levelid=l.levelid where c.status=1 and noofsemestor<>'' and d.status=1  ";
        strsql = strmain + strmid;
        cnt = (int)Conversion.Val(clsm.SendValue_Parameter(strsql, parameters).ToString());
        if (cnt == 0)
        {
            divcoursetitle.Visible = false;
        }
        else
        {
            divcoursetitle.Visible = true;
        }
    }
    protected void rptcourse_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcourseid = (Literal)e.Item.FindControl("litcourseid");
            Repeater rptcollege=(Repeater)e.Item.FindControl("rptcollege");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl pduration = (HtmlContainerControl)e.Item.FindControl("pduration");
            HtmlContainerControl pstream = (HtmlContainerControl)e.Item.FindControl("pstream");

            if (!string.IsNullOrEmpty(litcourseid.Text))
            {
                parameters.Clear();
                parameters.Add("@courseid", Conversion.Val(litcourseid.Text));
                clsm.repeaterDatashow_Parameter(rptcollege, "select c.collageid,collagename from map_course_institute m left join collage_master c on m.collageid=c.collageid where m.courseid=@courseid and c.status=1 order by c.displayorder", parameters);
            }
            parameters.Clear();
            parameters.Add("@courseid", Conversion.Val(litcourseid.Text));
            string duration = Convert.ToString(clsm.SendValue_Parameter("select noofsemestor from course where courseid=@courseid ", parameters));
            if (!string.IsNullOrEmpty(duration))
            {
                pduration.Visible = true;
            }
            parameters.Clear();
            parameters.Add("@courseid", Conversion.Val(litcourseid.Text));
            string semestor = Convert.ToString(clsm.SendValue_Parameter("select d.dpname from course c left join discipline_master d on c.dpid=d.dpid  where courseid=@courseid ", parameters));
            if (!string.IsNullOrEmpty(semestor))
            {
                pstream.Visible = true;
            }
            ank.HRef = "/coursedetail.aspx?mpgid=30&pgidtrail=30&courseid=" + Conversion.Val(litcourseid.Text);
        }
    }
    protected void dpid_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void courselevel_master_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}