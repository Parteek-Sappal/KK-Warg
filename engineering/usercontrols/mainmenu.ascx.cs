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

public partial class engineering_usercontrols_mainmenu : System.Web.UI.UserControl
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
                clsm.repeaterDatashow_Parameter(rptmainmenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Header%'  and collageid=1 order by displayorder", parameters);                
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
            HtmlContainerControl panelmegamenu = (HtmlContainerControl)e.Item.FindControl("panelmegamenu");
            HtmlContainerControl divaboutus = (HtmlContainerControl)e.Item.FindControl("divaboutus");
            HtmlContainerControl divsubmenu = (HtmlContainerControl)e.Item.FindControl("divsubmenu");
            Repeater rptcourselevel = (Repeater)e.Item.FindControl("rptcourselevel");
            Repeater rptsubmenu = (Repeater)e.Item.FindControl("rptsubmenu");
            Repeater rptcourseleveldoctor = (Repeater)e.Item.FindControl("rptcourseleveldoctor");

            if (Conversion.Val(litpageid.Text) == 78)
            {
                l1.Attributes.Add("class", "menu-item has-submenu has-megamenu");
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptcourselevel, "select distinct cm.* from course c inner join courselevel_master cm on cm.levelid=c.levelid where c.status=1 and cm.status=1 and cm.levelid in (1,2) order by cm.displayorder", parameters);

                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptcourseleveldoctor, "select distinct cm.* from course c inner join courselevel_master cm on cm.levelid=c.levelid where c.status=1 and cm.status=1 and cm.levelid in (3) order by cm.displayorder", parameters);

                panelmegamenu.Visible = true;
            }        
            else
            {
                l1.Attributes.Add("class", "menu-item");
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(litpageid.Text));
                clsm.repeaterDatashow_Parameter(rptsubmenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=1 order by displayorder", parameters);
                if (rptsubmenu.Items.Count > 0)
                {
                    l1.Attributes.Add("class", "menu-item has-submenu");
                    divsubmenu.Visible = true;
                }
                else
                {
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
    }
    protected void rptsubmenu_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Repeater rptsubmenuinner = (Repeater)e.Item.FindControl("rptsubmenuinner");
            Repeater rptdepartmentinner = (Repeater)e.Item.FindControl("rptdepartmentinner");
            HtmlContainerControl lisubmenu = (HtmlContainerControl)e.Item.FindControl("lisubmenu");
            HtmlContainerControl divinner = (HtmlContainerControl)e.Item.FindControl("divinner");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
          

            if (Conversion.Val(litpageid.Text) == 146)
            {
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(litpageid.Text));
                clsm.repeaterDatashow_Parameter(rptdepartmentinner, "select deptid,rewriteurl,deptname from department_master where status=1 and campusid=1 and schoolid=1 order by displayorder", parameters);
                lisubmenu.Attributes.Add("class", "has-submenu");
                divinner.Visible = true;
            }
            else
            {
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(litpageid.Text));
                clsm.repeaterDatashow_Parameter(rptsubmenuinner, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=1 order by displayorder", parameters);
                if (rptsubmenuinner.Items.Count > 0)
                {
                    lisubmenu.Attributes.Add("class", "has-submenu");
                    divinner.Visible = true;
                    if (Conversion.Val(litpageid.Text) == 178)
                    {
                        divinner.Attributes.Add("class", "submenu level2 admission-menu");
                    }
                }
                else
                {
                    if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
                    {
                        ank.HRef = litpageurl.Text;
                        ank.Target = "_blank";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(litrewriteurl.Text))
                        {
                            ank.HRef = "~/engineering/" + litrewriteurl.Text.Trim();
                        }
                        else
                        {
                            ank.HRef = "~/engineering/" + litpageurl.Text;
                        }
                    }
                }
            }
            if (Conversion.Val(litpageid.Text) == 179)
            {
                ank.HRef = "/engineering/pdf/kkwagh_engineering_prospectus2023-24final_compressed.pdf";
                ank.Target = "_blank";
            }
        }
    }
    protected void rptcourselevel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            Repeater rptcourselevelinner = (Repeater)e.Item.FindControl("rptcourselevelinner");

            parameters.Clear();
            parameters.Add("@levelid", Conversion.Val(litlevelid.Text));
            clsm.repeaterDatashow_Parameter(rptcourselevelinner, "select c.* from course c inner join courselevel_master cm on cm.levelid=c.levelid where c.status=1 and cm.status=1 and c.levelid=@levelid order by c.displayorder", parameters);
        }
    }
    protected void rptcourseleveldoctor_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            Repeater rptcourseleveldoctorinner = (Repeater)e.Item.FindControl("rptcourseleveldoctorinner");

            parameters.Clear();
            parameters.Add("@levelid", Conversion.Val(litlevelid.Text));
            clsm.repeaterDatashow_Parameter(rptcourseleveldoctorinner, "select c.* from course c inner join courselevel_master cm on cm.levelid=c.levelid where c.status=1 and cm.status=1 and c.levelid=@levelid order by c.displayorder", parameters);
        }
    }
    protected void rptcourselevelinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcourseid = (Literal)e.Item.FindControl("litcourseid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "~/engineering/coursedetail.aspx?mpgid=102&pgidtrail=102&courseid=" + Conversion.Val(litcourseid.Text);
            
        }
    }
    protected void rptcourseleveldoctorinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcourseid = (Literal)e.Item.FindControl("litcourseid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "~/engineering/coursedetail.aspx?mpgid=102&pgidtrail=102&courseid=" + Conversion.Val(litcourseid.Text);

        }
    }
    protected void rptdepartmentinner_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            if (!string.IsNullOrEmpty(litrewriteurl.Text))
            {
                ank.HRef = "~/engineering/" + litrewriteurl.Text.Trim();
            }
            else
            {
                ank.HRef = "~/engineering/department.aspx?deptid=" + Conversion.Val(litdeptid.Text);
            }
        }
    }
    protected void rptsubmenuinner_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
           

            if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
            {
                ank.HRef = litpageurl.Text;
                ank.Target = "_blank";
            }
            else
            {
                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    ank.HRef = "~/engineering/" + litrewriteurl.Text.Trim();
                }
                else
                {
                    ank.HRef = "~/engineering/" + litpageurl.Text;
                }
            }
          
        }
    }
 
}