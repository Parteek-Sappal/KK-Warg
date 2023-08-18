using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class Testimonials : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            BindData();
        }
    }
    private void BindData()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rpttesttype, "select tesid,testimonialtype from testimonials_type where status=1 order by displayorder", parameters);

        parameters.Clear();
        parameters.Add("@tesid", Conversion.Val(Request.QueryString["tesid"]));
        clsm.repeaterDatashow_Parameter(rpttestimonials, "select tesid,testimonialname,testimonialdesc,desg,Uploadphoto from testimonials where status=1 and showonhome=1 and tesid=@tesid order by displayorder", parameters);
    }
    protected void rpttesttype_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littesid = (Literal)e.Item.FindControl("littesid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Label lblcnt = (Label)e.Item.FindControl("lblcnt");

            if (!string.IsNullOrEmpty(littesid.Text))
            {                
                if (Conversion.Val(Request.QueryString["tesid"]) == Conversion.Val(littesid.Text))
                {
                    ank.Attributes.Add("class", "active");
                }
                ank.HRef = "/testimonials.aspx?mpgid=44&pgidtrail=57&tesid=" + Conversion.Val(littesid.Text);
            }
            parameters.Clear();
            parameters.Add("@tesid", Conversion.Val(littesid.Text));
            lblcnt.Text=Convert.ToString(clsm.SendValue_Parameter("select count(*)cnt from testimonials where status=1 and showonhome=1 and tesid=@tesid",parameters));
            if (lblcnt.Text == "0")
            {
                e.Item.Visible = false;
            }
        }
    }
}