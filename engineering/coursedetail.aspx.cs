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

public partial class engineering_coursedetail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["courseid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
                litcoursename.Text = Convert.ToString(clsm.SendValue_Parameter("select coursename from course where courseid=@courseid", parameters));

                parameters.Clear();
                parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
                litcollagename.Text = Convert.ToString(clsm.SendValue_Parameter("select cm.collagename from course c inner join map_course_institute map on map.courseid=c.courseid inner join collage_master cm on cm.collageid=map.collageid where c.courseid=@courseid", parameters));
                if (!string.IsNullOrEmpty(litcollagename.Text))
                {
                    panelcollage.Visible = true;
                }

                parameters.Clear();
                parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
                litstream.Text = Convert.ToString(clsm.SendValue_Parameter("select d.dpname from course c left join discipline_master d on c.dpid=d.dpid where courseid=@courseid", parameters));
                if (!string.IsNullOrEmpty(litstream.Text))
                {
                    panelstream.Visible = true;
                }

                binddata();
            }
        }
    }
    private void binddata()
    {
        parameters.Clear();
        parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
        DataSet ds = clsm.senddataset_Parameter("select c.* from course c inner join map_course_institute map on map.courseid=c.courseid inner join collage_master cm on cm.collageid=map.collageid where c.courseid=@courseid", parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            litoverview.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["shortdesc"]));
            litfees.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["feestructure"]));
            litelgibilty.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["eligiblitydetails"]));
            litSyllabus.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["Syllabus"]));
            litpeo.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["highlights"]));
            litprogram.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["intership_prog"]));
            litcareer.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["careerpath"]));
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelinner = (HtmlContainerControl)this.Master.FindControl("panelinner");
        panelinner.Visible = false;
    }

}