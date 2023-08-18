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

public partial class engineering_course : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter("select dpname,dpid from discipline_master where status=1 order by displayorder", parameters, ddlstream);
            ddlstream.Items[0].Text = "Select Stream";

            parameters.Clear();
            clsm.Fillcombo_Parameter("select levelname,levelid from courselevel_master where status=1 order by displayorder", parameters, ddllevel);
            ddllevel.Items[0].Text = "Select Level";


            ddllevel.SelectedIndex=ddllevel.Items.IndexOf(ddllevel.Items.FindByValue(Request.QueryString["levelid"]));
            binddata();


            parameters.Clear();
            parameters.Add("@pageid",Conversion.Val(77));
            litsmalldesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pagestatus=1 and pageid=@pageid", parameters)));
            
        }
            
    }
    private void binddata()
    {
        string sql = "select d.dpname,c.* from course c left join discipline_master d on c.dpid=d.dpid inner join map_course_institute map on map.courseid=c.courseid where c.status=1 ";
        if (Conversion.Val(ddlstream.SelectedValue) > 0)
        {
            sql += " and c.dpid=" + Conversion.Val(ddlstream.SelectedValue);
        }
        if (Conversion.Val(ddllevel.SelectedValue) > 0)
        {
            sql += " and c.levelid=" + Conversion.Val(ddllevel.SelectedValue);
        }

        clsm.repeaterDatashow_Parameter(rptcourse, sql, parameters);
    }
    protected void rptcourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcourseid = (Literal)e.Item.FindControl("litcourseid");
            HtmlContainerControl pduration = (HtmlContainerControl)e.Item.FindControl("pduration");
            HtmlContainerControl pstream = (HtmlContainerControl)e.Item.FindControl("pstream");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            parameters.Clear();
            parameters.Add("@courseid", Conversion.Val(litcourseid.Text));
            string duration = Convert.ToString(clsm.SendValue_Parameter("select noofsemestor from course where courseid=@courseid ",parameters));
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
            ank.HRef = "/engineering/coursedetail.aspx?mpgid=30&pgidtrail=30&courseid=" + Conversion.Val(litcourseid.Text);


        }
    }
    protected void ddlstreamsearch(object sender, EventArgs e)
    {
        binddata();
    }
    protected void ddllevelsearch(object sender, EventArgs e)
    {
        binddata();
    }
}