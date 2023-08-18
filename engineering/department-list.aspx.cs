using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class engineering_department_list : System.Web.UI.Page
{
    public mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptboard, "select deptid,deptname,departmentshortdetail,departmentdetail,banner,displayname,admissionimg from department_master where status=1 order by displayorder", parameters);
        }
    }
    protected void rptboard_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");


            ank.HRef = "/engineering/department.aspx?deptid=" + Conversion.Val(litdeptid.Text);
        }
    }
}