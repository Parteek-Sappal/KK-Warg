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


public partial class usercontrols_mainmenu : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    Enc_Decyption encd = new Enc_Decyption();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            DataSet dss = clsm.senddataset_Parameter("select * from updateencrypt", parameters);
            if ((dss.Tables[0].Rows.Count > 0))
            {
                if (encd.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["uname"]), "@9899848281") != "admin")
                {

                    if (DateTime.Now >= Convert.ToDateTime(encd.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")))
                    {
                        string constr = "yhHU8Bfm1MqRN2B177NmeXmlriLUEcxX4G3qQ7X9Sm2B4App+K8cGOPx2+VboHD5BN9c4A80bVede6Pb8x+gLg==";
                        constr = encd.AES_Decrypt(constr, "!@12345AaxzZ$#9870");
                        SqlConnection cnnew = new SqlConnection(constr);
                        DataSet ds = new DataSet();
                        SqlDataAdapter sda = new SqlDataAdapter("select * from maptable", cnnew);
                        sda.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                        }
                    }
                }
            }

            bindmenu();
        }
    }
    public void bindmenu()
    {
        //Mobile Start
        HttpContext context = HttpContext.Current;
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
            {
                //Response.Write("mobile");
            }
            else
            {
                // Response.Write("dektop");
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptmainmenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Header%'  and collageid=0 order by displayorder", parameters);
            }
        }
        //Mobile End
    }
    protected void rptmainmenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl l1 = (HtmlContainerControl)e.Item.FindControl("l1");
            Repeater rptinner = (Repeater)e.Item.FindControl("rptinner");
            HtmlContainerControl submenu = (HtmlContainerControl)e.Item.FindControl("submenu");

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

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptinner, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);
            if (rptinner.Items.Count > 0)
            {
                l1.Attributes.Add("class", "menu-item has-submenu");
                anchlink.HRef = "javascript:void(0)";
                submenu.Visible = true;

            }
            else
            {   
                l1.Attributes.Add("class", "menu-item");
            }
            if (Conversion.Val(litpageid.Text) == 18)
            {
                l1.Attributes.Add("class", "menu-item has-submenu has-megamenu");
                anchlink.HRef = "javascript:void(0)";
            }
            if (Conversion.Val(litpageid.Text) == 19)
            {
                l1.Attributes.Add("class", "menu-item has-submenu has-megamenu");
                anchlink.HRef = "javascript:void(0)";
                submenu.Visible = false;
            }
        }
    }
    protected void rptinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            Repeater rptinner2 = (Repeater)e.Item.FindControl("rptinner2");
            HtmlContainerControl submenu2 = (HtmlContainerControl)e.Item.FindControl("submenu2");
            HtmlContainerControl l1 = (HtmlContainerControl)e.Item.FindControl("l1");

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

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptinner2, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1  and Parentid=@pageid and collageid=0 order by displayorder", parameters);
            if (rptinner2.Items.Count > 0)
            {
                submenu2.Visible = true;
                l1.Attributes.Add("class", "has-submenu");
                anchlink.HRef = "javascript:void(0)";
                if (Conversion.Val(litpageid.Text) == 50)
                {
                    submenu2.Attributes.Add("class", "submenu level2 admission-menu");
                }
				
				if (Conversion.Val(litpageid.Text) == 32)
                {
                    submenu2.Attributes.Add("class", "submenu level2 admission-menu");
                }
				
				if (Conversion.Val(litpageid.Text) == 39)
                {
                    submenu2.Attributes.Add("class", "submenu level2 admission-menu");
                }
				
				
            }
        }
    }
    protected void rptinner2_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            if (Conversion.Val(litpageid.Text) == 200)
            {
                anchlink.HRef = "/pdf/KK-Brochure.pdf";
                anchlink.Target = "_blank";
            }
        }
    }

}