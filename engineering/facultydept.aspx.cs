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

public partial class engineering_facultydept : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {
        string strsql;
        strsql = "select afm.*,fdesignation.designation as designationname from Addfacultymaster afm inner join Facultydesignation fdesignation on fdesignation.fdid=afm.Designation inner join map_institute_department_faculty map on map.facultyid=afm.facultyid and map.deptid=@deptid where afm.status=1 and fdesignation.status=1 ";
     
        strsql+=" order by afm.displayorder";
        parameters.Clear();
        parameters.Add("@deptid",Conversion.Val(Request.QueryString["deptid"]));
        clsm.repeaterDatashow_Parameter(rptfaculty, strsql, parameters);
        if (rptfaculty.Items.Count > 10)
        {
            panelloadmore.Visible = true;
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

            ank.HRef = "facultydetail.aspx?mpgid=60&pgidtrail=60&facultyid=" + Conversion.Val(litfaculityid.Text) + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);
        }
    }
}