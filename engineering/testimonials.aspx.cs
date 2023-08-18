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

public partial class engineering_testimonials : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(1));
            clsm.repeaterDatashow_Parameter(rpttestimonials, "select distinct ttype.* from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and t.showonhome=1 and map.collageid=@collageid order by ttype.displayorder", parameters);

            if (Conversion.Val(Request.QueryString["tesid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(1));
                parameters.Add("@tesid", Conversion.Val(Request.QueryString["tesid"]));
                clsm.repeaterDatashow_Parameter(rpttestimonialsdetail, "select distinct t.testimonialid,t.testimonialname,t.testimonialdesc,t.desg,t.uploadphoto,t.detaildesc,t.placed,t.branch,t.batch,t.tesid,t.displayorder from testimonials t inner join Testimonials_Type ttype on ttype.Tesid=t.Tesid inner join map_institiute_testimonials map on map.testimonialid=t.testimonialid where t.status=1 and ttype.status=1 and t.showonhome=1 and t.tesid=@tesid and map.collageid=@collageid order by t.displayorder", parameters);
                if (rpttestimonialsdetail.Items.Count > 20)
                {
                    btnload.Visible = true;
                }
            }
        }
    }
    protected void rpttestimonials_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littesid = (Literal)e.Item.FindControl("littesid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            if (Conversion.Val(littesid.Text) == Conversion.Val(Request.QueryString["tesid"]))
            {
                ank.Attributes.Add("class", "active");
            }
            ank.HRef = "/engineering/testimonials.aspx?mpgid=93&pgidtrail=93&tesid=" + Conversion.Val(littesid.Text);
        }
    }
    protected void rpttestimonialsdetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littesid = (Literal)e.Item.FindControl("littesid");
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
           

           
            
           
        }
    }
}