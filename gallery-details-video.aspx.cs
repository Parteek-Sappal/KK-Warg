using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class gallery_details_video : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind();
        }
    }
    private void DataBind()
    {
        string strsqltitle;
        double albumid;
        albumid=Conversion.Val(Request.QueryString["albumid"]);
        parameters.Clear();
        parameters.Add("@albumid",albumid);
        strsqltitle = "select albumtitle from album where albumid=@albumid and status=1";
        litalbumtitle.Text = clsm.SendValue_Parameter(strsqltitle , parameters).ToString();
        litalbumdesc.Text =Server.HtmlDecode(clsm.SendValue_Parameter("select albumdesc from album where albumid=@albumid and status=1", parameters).ToString());

        clsm.repeaterDatashow_Parameter(rptvideo, "select vedioid,albumid,vediotitle,uploadvedio,thumbnailimage from vedio where status=1 and albumid=@albumid", parameters);
    }
    protected void rptvideo_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litvedioid = (Literal)e.Item.FindControl("litvedioid");
            Literal lituploadvedio = (Literal)e.Item.FindControl("lituploadvedio");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            if (!string.IsNullOrEmpty(lituploadvedio.Text))
            {
                ank.Attributes.Add("class", "video_url");
                ank.Attributes.Add("data-bs-toggle", "modal");
                ank.Attributes.Add("data-bs-target", "#video-modal" + Conversion.Val(litvedioid.Text));
            }
        }
    }
}