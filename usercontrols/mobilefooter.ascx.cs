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

public partial class usercontrols_mobilefooter : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptmobilemenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Mobile%'  and collageid=0 order by displayorder", parameters);
        }
    }
    protected void rptmobilemenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
            {
                anchlink.HRef = litpageurl.Text;
                anchlink.Target = "_blank";
            }
            else
            {
                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                }
                else
                {
                    anchlink.HRef = "~/" + litpageurl.Text;
                }
            }
        }
    }
}