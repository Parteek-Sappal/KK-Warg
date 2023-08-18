using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class gallery_details_image : System.Web.UI.Page
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
        parameters.Add("@albumid", Conversion.Val(Request.QueryString["albumid"]));
        litalbumtitle.Text = clsm.SendValue_Parameter("select albumtitle from album where albumid=@albumid and status=1", parameters).ToString();
        litalbumdesc.Text = Server.HtmlDecode(clsm.SendValue_Parameter("select albumdesc from album where albumid=@albumid and status=1", parameters).ToString());

        clsm.repeaterDatashow_Parameter(rptimage, "select photoid,albumid,phototitle,uploadphoto from albumphoto where status=1 and albumid=@albumid order by displayorder", parameters);
    }
}