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

public partial class engineering_media : System.Web.UI.Page
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
        parameters.Add("@deptid",Conversion.Val(Request.QueryString["deptid"]));
        string sql = "select a.albumid,a.albumtitle,a.typeid,a.albumdesc,a.uploadaimage from album a inner join map_photo_gallery map on map.albumid=a.Albumid where Status=1 and map.collageid=1 and map.deptid=@deptid ";
        if (Conversion.Val(Request.QueryString["typeid"]) == 1)
        {
            sql += " and a.typeid=1";
        }
        else if (Conversion.Val(Request.QueryString["typeid"]) == 2)
        {
            sql += " and a.typeid=2";
        }
        sql += " order by a.displayorder";

        clsm.repeaterDatashow_Parameter(rptalbum, sql, parameters);
        if (rptalbum.Items.Count > 10)
        {
            panelloadmore.Visible = true;
        }
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
            anchlink.HRef = "/engineering/media.aspx?mpgid=105&pgidtrail=105&typeid=" + Conversion.Val(littypeid.Text);           
        }
    }
    protected void rptalbum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Label lblcount = (Label)e.Item.FindControl("lblcount");
            HtmlImage img = (HtmlImage)e.Item.FindControl("img");

            if (Conversion.Val(littypeid.Text) == 1)
            {
                ank.Attributes.Add("class", "gallery-thumb image");
                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(litalbumid.Text));
                double count = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) as cnt from albumphoto where albumid=@albumid and status=1", parameters));
                lblcount.Text = count.ToString() + " Photos";
                img.Src = "/images/icon-feather-image.png";
                ank.HRef = "/engineering/mediadetail.aspx?mpgid=105&pgidtrail=105&albumid=" + Conversion.Val(litalbumid.Text);
            }
            else
            {
                ank.Attributes.Add("class", "gallery-thumb video");
                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(litalbumid.Text));
                double count = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) as cnt from vedio where albumid=@albumid and status=1", parameters));
                lblcount.Text = count.ToString() + " Videos";
                img.Src = "/images/video-icon-red.svg";
                ank.HRef = "/engineering/videodetail.aspx?mpgid=105&pgidtrail=105&albumid=" + Conversion.Val(litalbumid.Text);
            }
        }
    }
}