using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;

public partial class engineering_careers : System.Web.UI.Page
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
        parameters.Add("@mpgid", Conversion.Val(Request.QueryString["mpgid"]));
        clsm.repeaterDatashow_Parameter(rptsmalldesc, "select smalldesc,pagedescription from pagemaster where pageid=@mpgid and pagestatus=1", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptjob, "select jobtitle,min_expyear,max_expyear,department,JobClosing_date from postedjobs p inner join map_career_campus map on map.jobid=p.Jobid where status=1 and JobClosing_date>getdate() order by displayorder", parameters);
    }
}