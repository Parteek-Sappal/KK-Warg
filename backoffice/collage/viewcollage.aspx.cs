using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.IO;
using System.Data;

public partial class backoffice_collage_viewcollage : System.Web.UI.Page
{
    public int appno;
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }
        if (!IsPostBack)
        {
            bindcampus();
            gridshow();
            if( Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }
                
        }
    }

    public void bindcampus()
    {
        Parameters.Clear();

        string strsqlct = "select ctypename,ctid from collagetype  where status=1 order by displayorder ";
        clsm.Fillcombo_Parameter(strsqlct, Parameters, ctid);
    }
    public void gridshow()
    {
        string strsql="";
        strsql = "select cm.*,cp.ctypename from collage_master cm left join  collagetype cp on cm.ctid=cp.ctid left outer join collage_Management m on m.collageid=cm.collageid  where 1=1 ";
        if(Conversion.Val(AUserSession["Roleid"])!=1)
        {
            strsql += " and isnull(m.roleid,0)=" + Conversion.Val(AUserSession["Roleid"]) + "";
        }
        if (Conversion.Val(ctid.SelectedValue) > 0)
        {
            strsql += " and cm.ctid=" + Conversion.Val(ctid.SelectedValue) + "";
        }
      
        Parameters.Clear();
        strsql += " order by  cm.collagename ";

        clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
            if(GridView1.Rows.Count==0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Record(s) not found.";
            }
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
               try
               {
            GridView1.PageIndex = e.NewPageIndex;
            gridshow();;
               }
        catch(Exception ex)
               {
                   trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
        
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         if(e.CommandName == "btndel")
         {
           
             GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
             Label lblbanner = (Label)row.FindControl("lblbanner");

            Parameters.Clear();
            Parameters.Add("@collageid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from collage_Master where collageid=@collageid", Parameters);
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(lblbanner.Text));
            if (F1.Exists)
            {
                F1.Delete();
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record deleted successfully.";
         }


        if( e.CommandName == "lnkstatus")
        {
           GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
           TextBox txtstatus = (TextBox)row.FindControl("txtstatus");

            if( txtstatus.Text=="False")
            {
                Parameters.Clear();
                Parameters.Add("@collageid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update collage_Master set status=1 where collageid=@collageid", Parameters);
            }
            else if( txtstatus.Text=="True")
            {

                Parameters.Clear();
                Parameters.Add("@collageid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update collage_Master set status=0 where collageid=@collageid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }


        if (e.CommandName == "lnkstatus_mega")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblshowmegamenu = (Label)row.FindControl("lblshowmegamenu");

            if (lblshowmegamenu.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@collageid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update collage_Master set showmegamenu=1 where collageid=@collageid", Parameters);
            }
            else if (lblshowmegamenu.Text == "True")
            {

                Parameters.Clear();
                Parameters.Add("@collageid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update collage_Master set showmegamenu=0 where collageid=@collageid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }


        if( e.CommandName == "btnedit" )
        {
            Response.Redirect("addcollage.aspx?tid=" + Conversion.Val(e.CommandArgument));
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

            ImageButton lnkstatus_mega = (ImageButton)e.Row.FindControl("lnkstatus_mega");
            Label lblshowmegamenu = (Label)e.Row.FindControl("lblshowmegamenu");

            if (lblshowmegamenu.Text == "True")
            {
                lnkstatus_mega.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus_mega.ToolTip = "Active";
            }
            else
            {
                lnkstatus_mega.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus_mega.ToolTip = "Inactive";
            }


            if (txtstatus.Text == "True")
            {
               
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }
   
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" +Server.HtmlDecode(Convert.ToString(Session["altColor"])) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        gridshow();
    }
}