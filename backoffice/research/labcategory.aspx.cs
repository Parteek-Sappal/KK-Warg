﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

public partial class backoffice_research_labcategory : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public int appno;
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        trerror.Visible = false;
        trnotice.Visible = false;
        trsuccess.Visible = false;
        if ((Page.IsPostBack == false))
        {
            if ((Conversion.Val(Request.QueryString["lcid"]) > 0))
            {
                Parameters.Clear();
                Parameters.Add("@lcid", double.Parse(Request.QueryString["lcid"]));
                clsm.MoveRecord_Parameter(this, lcid.Parent, "select * from labcategory where lcid=@lcid", Parameters);
            }
            gridshow();
        }
    }
    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                if (Convert.ToInt32(clsm.MasterSave(this, lcid.Parent, 4, mainclass.Mode.modeCheckDuplicate, "labcategorySP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Lab Category already exist.";
                    return;
                }
                if (Conversion.Val(lcid.Text) == 0)
                {
                    Status.Checked = true;
                    clsm.MasterSave(this, lcid.Parent, 4, mainclass.Mode.modeAdd, "labcategorySP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                    clsm.ClearallPanel(this, lcid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {
                    clsm.MasterSave(this, lcid.Parent, 4, mainclass.Mode.modeModify, "labcategorySP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                    clsm.ClearallPanel(this, lcid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }

        }

    }



    protected void gridshow()
    {
        try
        {
            Parameters.Clear();
            clsm.GridviewData_Parameter(GridView1, "select * from labcategory order by displayorder", Parameters);
            appno = GridView1.Rows.Count;
            if ((GridView1.Rows.Count == 0))
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Record found.";
            }

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect(("labcategory.aspx?lcid=" + e.CommandArgument));
        }

        if (e.CommandName == "status")
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@lcid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update labcategory set status=1 where lcid=@lcid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@lcid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update labcategory set status=0 where lcid=@lcid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if (e.CommandName == "del")
        {
            Parameters.Clear();
            Parameters.Add("@lcid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from labcategory where lcid=@lcid", Parameters);
            gridshow();
            trnotice.Visible = true;
            lblnotice.Text = "Record deleted successfully.";
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");


            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                lnkstatus.ToolTip = "Yes";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "../assets/ico_block.png";
                lnkstatus.ToolTip = "No";
            }
        }

    }

    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("labcategory.aspx");
    }
}