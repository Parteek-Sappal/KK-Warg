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

public partial class videodetail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Conversion.Val(Request.QueryString["albumid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@albumid", Conversion.Val(Request.QueryString["albumid"]));
            lbltitle.Text = Convert.ToString(clsm.SendValue_Parameter("select albumtitle from album where albumid=@albumid and status=1", parameters));

            parameters.Clear();
            parameters.Add("@albumid", Conversion.Val(Request.QueryString["albumid"]));
            clsm.repeaterDatashow_Parameter(rptvediodetail, "select * from vedio where albumid=@albumid and status=1", parameters);
        }
    }
}