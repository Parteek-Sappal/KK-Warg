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
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            lititle.Text = Convert.ToString(clsm.SendValue_Parameter("select linkname from pagemaster where pageid=@pageid", parameters));
            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();
        string sql = "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and collageid=1 ";
        if (Conversion.Val(Request.QueryString["pgid1"]) == 112)
        {
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgid1"]));
            sql += " and Parentid=@pageid ";
        }
        else if (Conversion.Val(Request.QueryString["mpgid"]) == 87)
        {
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
            sql += " and Parentid=@pageid ";
        }
        sql += " order by displayorder";
        if (Conversion.Val(Request.QueryString["pgid1"]) == 112 || Conversion.Val(Request.QueryString["mpgid"]) == 87)
        {
            clsm.repeaterDatashow_Parameter(rptinnermenu, sql, parameters);
            if (rptinnermenu.Items.Count > 0)
            {
                innermenu.Visible = true;
            }
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
                    anchlink.HRef = "~/engineering/" + litpageurl.Text;
                }
            }
        }
    }
}
