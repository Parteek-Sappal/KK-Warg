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


public partial class engineering_facultydetail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();
        parameters.Add("@facultyid", Conversion.Val(Request.QueryString["facultyid"]));
        string sql = "select afm.*,fdesignation.designation as designationname from Addfacultymaster afm inner join Facultydesignation fdesignation on fdesignation.fdid=afm.Designation where afm.status=1 and fdesignation.status=1 and afm.facultyid=@facultyid order by afm.displayorder";    
        clsm.repeaterDatashow_Parameter(rptfacultydetail, sql, parameters);

    }
    protected void rptfacultydetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfaculityid = (Literal)e.Item.FindControl("litfaculityid");
            Literal litfimage = (Literal)e.Item.FindControl("litfimage");            
            HtmlImage img = (HtmlImage)e.Item.FindControl("img");
            HtmlContainerControl panelphone = (HtmlContainerControl)e.Item.FindControl("panelphone");

            if (string.IsNullOrEmpty(litfimage.Text))
            {
                img.Src = "/images/deafultimage.png";
            }
            else
            {
                img.Src = "/uploads/faculty/" + litfimage.Text;
            }

          

        }
    }
}