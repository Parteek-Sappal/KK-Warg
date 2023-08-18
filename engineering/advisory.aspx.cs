using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic;


public partial class engineering_advisory : System.Web.UI.Page
{
    public mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptadvisory, "select teamid,ttypeid,name,uploadphoto,shortdesc from ourteam where status=1 and ttypeid=1 and collageid=1 order by  displayorder", parameters);
        }
    }
}