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

public partial class engineering_usercontrols_homebanner : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    int collegeid = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@collegeid", collegeid);
            clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo from homebanner b inner join homebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.status=1 and b.devicetype='desktop'  and b.collageid=@collegeid order by b.displayorder", parameters);
        }
    }
}