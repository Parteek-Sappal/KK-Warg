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


public partial class backoffice_masters_view_discipline : System.Web.UI.Page
{
    mainclass Clsm = new mainclass();
    Hashtable Parameters = new Hashtable();


    protected void Page_Load(object sender, System.EventArgs e)
    {
        trsuccess.Visible = false;
        trnotice.Visible = false;
        trerror.Visible = false;
        if ((Page.IsPostBack == false))
        {
            gridshow();
        }
        if ((Request.QueryString["edit"] == "edit"))
        {
            trsuccess.Visible = true;
            lblsuccess.Text = "Record updated successfully..";
        }
    }
    protected void gridshow()
    {
        Parameters.Clear();
        Clsm.GridviewData_Parameter(GridView1, "select * from Discipline_Master order by displayorder", Parameters);
        if ((GridView1.Rows.Count == 0))
        {
            trnotice.Visible = true;
            lblnotice.Text = "Discipline (s) not found.";
        }

    }
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");

            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

            ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
            Label lblshowonhome = (Label)e.Row.FindControl("lblshowonhome");


            if (lblshowonhome.Text == "True")
            {
                lnkshowonhome.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkshowonhome.ToolTip = "Yes";
            }
            else 
            {
                lnkshowonhome.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkshowonhome.ToolTip = "No";
            }


            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "../assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }

            e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                            + (Server.HtmlDecode(Convert.ToString(Session["altColor"])) + "\'")));
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
        }

        // If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.Footer Then
        //     e.Row.Cells(3).Visible = False
        // End If
    }

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "redit"))
        {
            Response.Redirect(("add-discipline.aspx?dpid=" + Conversion.Val(e.CommandArgument)));

        }

        if ((e.CommandName == "lnkstatus"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if ((txtstatus.Text == "False"))
            {
                Parameters.Clear();
                Parameters.Add("@dpid", Conversion.Val(e.CommandArgument));
                Clsm.ExecuteQry_Parameter("update Discipline_Master set status=1 where dpid=@dpid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@dpid", Conversion.Val(e.CommandArgument));
                Clsm.ExecuteQry_Parameter("update Discipline_Master set status=0 where dpid=@dpid", Parameters);
            }

            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
            gridshow();
        }

        if (e.CommandName == "lnkshowonhome")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblshowonhome = (Label)row.FindControl("lblshowonhome");

            if (lblshowonhome.Text == "False")
            {
                // clsm.ExecuteQry("update Events set showonhome=1 where Eventsid=" & e.CommandArgument & "")
                Parameters.Clear();
                Parameters.Add("@dpid", Convert.ToInt32(e.CommandArgument));
                string strsql = "update Discipline_Master set showhome=1 where dpid=@dpid";
                Clsm.ExecuteQry_Parameter(strsql, Parameters);

            }
            else if (lblshowonhome.Text == "True")
            {
                //clsm.ExecuteQry("update Events set showonhome=0 where Eventsid=" & e.CommandArgument & "")
                Parameters.Clear();
                Parameters.Add("@dpid", Convert.ToInt32(e.CommandArgument));
                string strsql = "update Discipline_Master set showhome=0 where dpid=@dpid";
                Clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

    }

    protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridshow();
        }
        catch (Exception ex)
        {
        }

    }
}