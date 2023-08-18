using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI.HtmlControls;
public partial class engineering_layouts_inner : System.Web.UI.MasterPage
{
    public mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            lititle.Text = Convert.ToString(clsm.SendValue_Parameter("select deptname from department_master where deptid=@deptid", parameters));

            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();        
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        clsm.repeaterDatashow_Parameter(rptinnermenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMasterdept with(nolock) where PageStatus=1 and deptid=@deptid order by displayorder", parameters);
        if (rptinnermenu.Items.Count > 0)
        {
            innermenu.Visible = true;
        }
    }
    protected void rptinnermenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            if (Conversion.Val(litpageid.Text) == Conversion.Val(Request.QueryString["pgidtrail"]))
            {
                anchlink.Attributes.Add("class", "active");
            }

            if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
            {
                anchlink.HRef = litpageurl.Text;
                anchlink.Target = "_blank";
            }
            else
            {
                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    anchlink.HRef = "~/engineering/" + litrewriteurl.Text.Trim();
                }
                else
                {
                    anchlink.HRef = "~/engineering/" + litpageurl.Text + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);
                }
            }

            if (e.Item.ItemIndex == 0)
            {

                anchlink.HRef = "/engineering/department.aspx?deptid=" + Conversion.Val(Request.QueryString["deptid"]) + "";
                //if (Conversion.Val(Request.QueryString["deptid"]) != 0 && Conversion.Val(Request.QueryString["mpgid"]) == 0)
                //{
                //    l1.Attributes.Add("class", "active");
                //}

            }
        }
    }
}
