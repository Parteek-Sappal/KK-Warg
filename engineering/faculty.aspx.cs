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

public partial class faculty : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAlpha();
            BindData();
        }
    }
    public void FillAlpha()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptalpha, "select alpha from alphabet  order by alphaid asc", parameters);
    }
    private void BindData()
    {
        string sqlstr = "select distinct fm.*,fd.designation as fdesignation  from  Addfacultymaster fm left join Facultytype ft on fm.fid=ft.fid  left join collage_master cm on fm.schid=cm.collageid left join  Facultydesignation fd on fm.Designation=fd.fdid inner join map_institute_department_faculty map on map.facultyid=fm.facultyid   where fm.status=1 and map.collageid=1 ";

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["pname"])) && Convert.ToString(ViewState["pname"]) != "All")
        {

            parameters.Add("@ptitle", Convert.ToString(ViewState["pname"]));
            sqlstr += " and    fm.fname like +''+@ptitle+'%'";
        }
        sqlstr += " order by fm.displayorder ";
        clsm.repeaterDatashow_Parameter(rptfaculty, sqlstr, parameters);
       
    }
    protected void rptalpha_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            LinkButton lnkalpha = e.Item.FindControl("lnkalpha") as LinkButton;
            Literal litalpha = e.Item.FindControl("litalpha") as Literal;
            HtmlGenericControl liclass = e.Item.FindControl("liclass") as HtmlGenericControl;
            string strsql1 = "";
            parameters.Clear();

            strsql1 = "select fm.facultyid from  Addfacultymaster fm left join Facultytype ft on fm.fid=ft.fid  left join collage_master cm on fm.schid=cm.collageid   where fm.status=1  and fm.fname like '" + litalpha.Text + "%'";
            string strid = Convert.ToString(clsm.SendValue_Parameter(strsql1, parameters));

            if (Conversion.Val(strid) == 0)
            {
                lnkalpha.Attributes.Add("class", "disabled");
                lnkalpha.Enabled = false;
                lnkalpha.Attributes.Add("title", "no record");
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["pname"])))
            {

                if (Convert.ToString(ViewState["pname"]) == Convert.ToString(litalpha.Text))
                {
                    lnkalpha.Attributes.Remove("class");
                    lnkalpha.Attributes.Add("class", "active");
                }
                if (e.Item.ItemIndex == 0)
                {
                    if (Convert.ToString(ViewState["pname"]) == "All")
                    {
                        lnkalpha.Attributes.Remove("class");
                        lnkalpha.Attributes.Add("class", "active");
                        lnkalpha.Attributes.Remove("title");
                        lnkalpha.Enabled = true;

                    }
                    else
                    {
                        lnkalpha.Attributes.Remove("class");
                        lnkalpha.Attributes.Add("class", "active");
                        lnkalpha.Attributes.Remove("title");
                        lnkalpha.Enabled = true;

                    }

                }
            }
            else
            {
                if (e.Item.ItemIndex == 0)
                {
                    lnkalpha.Attributes.Remove("class");                    
                    lnkalpha.Enabled = true;
                }
            }
        }

    }

    protected void rptalpha_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cmdalpha")
        {
            ViewState["pname"] = Convert.ToString(e.CommandArgument);
            BindData();
            FillAlpha();
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

            ank.HRef = "facultydetail.aspx?mpgid=77&pgidtrail=147&facultyid=" + Conversion.Val(litfaculityid.Text);
        }
    }
}