using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class alumni_video : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptalumni, "select v.vedioid,v.vediotitle,v.uploadvedio,v.thumbnailimage,v.albumid,v.tagline from vedio v inner join map_photo_gallery map on map.albumid=v.albumid where v.albumid=3 and v.status=1 order by v.displayorder", parameters);
            if (rptalumni.Items.Count > 10)
            {
               // loadmore.Visible = true;
            }

        }
    }
}