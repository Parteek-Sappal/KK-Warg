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
public partial class media : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptmediatype, "select '0' as typeid,'All' as typename,0 as displayorder  union all select typeid,typename+' Gallery',displayorder from albumtype where status=1 order by displayorder", parameters);
            binddata();

        }
    }
    private void binddata()
    {
        parameters.Clear();
        string sql = "select albumid,albumtitle,typeid,albumdesc,uploadaimage from album where Status=1 ";
        if (Conversion.Val(Request.QueryString["typeid"]) == 1)
        {
            sql += " and typeid=1";
        }
        else if (Conversion.Val(Request.QueryString["typeid"]) == 2)
        {
            sql += " and typeid=2";
        }
        sql += " order by displayorder";

        clsm.repeaterDatashow_Parameter(rptalbum, sql, parameters);
    }
    protected void rptmediatype_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");            
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            if (Conversion.Val(Request.QueryString["typeid"]) == Conversion.Val(littypeid.Text))
            {
                anchlink.Attributes.Add("class", "active");
            }
            anchlink.HRef = "/media.aspx?mpgid=31&pgid1=32&pgidtrail=38&typeid=" + Conversion.Val(littypeid.Text);           
        }
    }
    protected void rptalbum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");
            Literal litlitalbumid = (Literal)e.Item.FindControl("litalbumid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Label lblcount = (Label)e.Item.FindControl("lblcount");
            HtmlImage img = (HtmlImage)e.Item.FindControl("img");

            if (Conversion.Val(littypeid.Text) == 1)
            {
                ank.Attributes.Add("class", "gallery-thumb image");
                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(litlitalbumid.Text));
                double count = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) as cnt from albumphoto where albumid=@albumid", parameters));
                lblcount.Text = count.ToString() + " Photos";
                img.Src = "/images/icon-feather-image.png";
                ank.HRef = "/mediadetail.aspx?mpgid=31&pgid1=32&pgidtrail=38&albumid=" + Conversion.Val(litlitalbumid.Text);
            }
            else
            {
                ank.Attributes.Add("class", "gallery-thumb video");
                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(litlitalbumid.Text));
                double count = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) as cnt from vedio where albumid=@albumid", parameters));
                lblcount.Text = count.ToString() + " Videos";
                img.Src = "/images/video-icon-red.svg";
                ank.HRef = "/videodetail.aspx?mpgid=31&pgid1=32&pgidtrail=38&albumid=" + Conversion.Val(litlitalbumid.Text);
            }
           
           
           
        }
    }
}