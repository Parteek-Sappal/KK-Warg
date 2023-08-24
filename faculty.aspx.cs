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
            Filltype();
            FillAlpha();
            bindfaculty();
            //BindData();
        }
    }

    public void Filltype()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(repftype, "select distinct ft.*  from  Addfacultymaster fm left join Facultytype ft on fm.fid=ft.fid  left join collage_master cm on fm.schid=cm.collageid left join  Facultydesignation fd on fm.Designation=fd.fdid   where fm.status=1 order by ft.displayorder", parameters);
    }


    public void FillAlpha()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptalpha, "select alpha from alphabet  order by alphaid asc", parameters);
    }
    public void bindfaculty()
    {
        parameters.Clear();
     
        //string sqlstr = "select distinct fm.fname,fm.Specialization,fm.fimage,ft.facultytype,fm.displayorder,fm.facultyid,fm.salutation from  Addfacultymaster fm left join Facultytype ft on fm.fid=ft.fid  left join collage_master cm on fm.schid=cm.collageid left join map_institiute_faculty mf on fm.facultyid=mf.facultyid  where fm.status=1 and ft.status=1";
        string sqlstr = "select distinct fm.*,fd.designation as fdesignation  from  Addfacultymaster fm left join Facultytype ft on fm.fid=ft.fid  left join collage_master cm on fm.schid=cm.collageid left join  Facultydesignation fd on fm.Designation=fd.fdid   where fm.status=1 ";
        
        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["pname"])) && Convert.ToString(ViewState["pname"]) != "All")
        {

            parameters.Add("@ptitle", Convert.ToString(ViewState["pname"]));
            sqlstr += " and    fm.fname like +''+@ptitle+'%'";
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["fid"])))
        {

            parameters.Add("@fid", Convert.ToString(ViewState["fid"]));
            sqlstr += " and    fm.fid=@fid";
        }


        sqlstr += " order by fm.displayorder ";
      
        clsm.repeaterDatashow_Parameter(rptfaculty, sqlstr, parameters);
        if (rptfaculty.Items.Count > 12)
        {
            divloadcurrent.Visible = true;
        }
        else
        {
            divloadcurrent.Visible = false;
        }

    }
    //private void BindData()
    //{
      

    //    string strsql;
    //    strsql = "select afm.*,fdesignation.designation as designationname from Addfacultymaster afm inner join Facultydesignation fdesignation on fdesignation.fdid=afm.Designation where afm.status=1 ";
    //    if (!string.IsNullOrEmpty(Request.QueryString["alpha"]))
    //    {
    //        if (Request.QueryString["alpha"].ToLower() != "all")
    //        {
    //            strsql += " and afm.fname like '" + Request.QueryString["alpha"] + "%' ";
    //        }                
    //    }
    //    if (!string.IsNullOrEmpty(Request.QueryString["deptid"]))
    //    {
    //        strsql += " and deptid=" + Conversion.Val(Request.QueryString["deptid"]);
    //    }
    //    strsql+=" order by afm.displayorder";
    //    parameters.Clear();
    //    clsm.repeaterDatashow_Parameter(rptfaculty,strsql, parameters);
    //}
    protected void rptalpha_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            LinkButton lnkalpha = e.Item.FindControl("lnkalpha") as LinkButton;
            Literal litalpha = e.Item.FindControl("litalpha") as Literal;
            HtmlGenericControl liclass = e.Item.FindControl("liclass") as HtmlGenericControl;
            string strsql1 = "";
            parameters.Clear();
           

            //strsql1 = "select fm.facultyid,fm.salutation from  Addfacultymaster fm left join Facultytype ft on fm.fid=ft.fid  left join collage_master cm on fm.schid=cm.collageid left join map_institiute_faculty mf on fm.facultyid=mf.facultyid  where fm.status=1 and ft.status=1 and fm.fname like '" + litalpha.Text + "%'";


            strsql1 = "select fm.facultyid from  Addfacultymaster fm left join Facultytype ft on fm.fid=ft.fid  left join collage_master cm on fm.schid=cm.collageid   where fm.status=1  and fm.fname like '" + litalpha.Text + "%'";


            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["fid"])))
            {

                parameters.Add("@fid", Convert.ToString(ViewState["fid"]));
                strsql1 += " and    fm.fid=@fid";
            }

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
                    //liclass.Attributes.Add("class", "selected");
                    //lnkalpha.Attributes.Remove("title");
                    lnkalpha.Enabled = true;

                }
            }
        }

    }

    protected void rptalpha_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cmdalpha")
        {

            Literal litalpha = (Literal)e.Item.FindControl("litalpha");
            if (Convert.ToString(litalpha.Text) == "All")
            {
                ViewState["fid"] = "";
            }
            ViewState["pname"] = Convert.ToString(e.CommandArgument);
            bindfaculty();
            FillAlpha();
        }
    }
    protected void rptfaculty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfaculityid = (Literal)e.Item.FindControl("litfaculityid");
            Literal litfname = (Literal)e.Item.FindControl("litfname");
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

            ank.HRef = "/faculty-detail/" + clsm.replacestring(litfname.Text) + "/" + Conversion.Val(litfaculityid.Text);
            //ank.HRef = "/facultydetail.aspx?mpgid=60&pgidtrail=60&facultyid=" + Conversion.Val(litfaculityid.Text);
        }
    }


    protected void repftype_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            //LinkButton lnkalpha = e.Item.FindControl("lnkalpha") as LinkButton;
            //Literal litalpha = e.Item.FindControl("litalpha") as Literal;
            //HtmlGenericControl liclass = e.Item.FindControl("liclass") as HtmlGenericControl;
             
            //if (Conversion.Val(strid) == 0)
            //{
            //    lnkalpha.Attributes.Add("class", "disabled");
            //    lnkalpha.Enabled = false;
            //    lnkalpha.Attributes.Add("title", "no record");
            //}
        }

    }

    protected void repftype_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cmdfid")
        {
           
            //**************
            Literal lifid = (Literal)e.Item.FindControl("lifid");
            LinkButton lnkfid = (LinkButton)e.Item.FindControl("lnkfid");

            foreach (RepeaterItem rp in repftype.Items)
            {
                LinkButton lnkbtnactive = rp.FindControl("lnkfid") as LinkButton;
                lnkbtnactive.Attributes.Add("class", "");
            }
            lnkfid.Attributes.Add("class", "active");
            //********************

            ViewState["fid"] = Convert.ToString(e.CommandArgument);
            ViewState["pname"] = "";
            bindfaculty();
            FillAlpha();




        }
    }
}