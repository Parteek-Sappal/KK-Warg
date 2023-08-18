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

public partial class usercontrols_courselevelsearch : System.Web.UI.UserControl
{
    public mainclass clsm = new mainclass();
    public string StrMetakey;
    public string StrMetadesc;
    public HttpCookie UserSession;
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
        }
    }
    public void binddata()
    {
        DataSet ds1 = new DataSet();
        parameters.Clear();
        parameters.Add("@Pageid", Conversion.Val(110));
        ds1 = clsm.senddataset_Parameter("select PageName,pagemeta,PageMetaDesc,PageTitle,UploadBanner,pagename,PageDescription,smalldesc from PageMaster with (nolock) where pagestatus=1 and Pageid=@Pageid", parameters);
    }

    protected void LinkButton5_click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtcoursesearch11.Text))
        {        
            parameters.Clear();
            parameters.Add("@coursename", txtcoursesearch11.Text.Trim());
            string sql = "select distinct top 1 c.coursename,c.courseid,c.externalurl from course c  where 1=1 and status=1  and c.coursename=@coursename";
            DataSet ds = clsm.senddataset_Parameter(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string courseid = Convert.ToString(ds.Tables[0].Rows[0]["courseid"]);
                //string collegetype = Convert.ToString(ds.Tables[0].Rows[0]["collegetype"]);
                //string cmpgid = Convert.ToString(ds.Tables[0].Rows[0]["cmpgid"]);
                //string cpgidtrail = Convert.ToString(ds.Tables[0].Rows[0]["cpgidtrail"]);
                //string collageid = Convert.ToString(ds.Tables[0].Rows[0]["collageid"]);
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["externalurl"])))
                {
                    string qry = Convert.ToString(ds.Tables[0].Rows[0]["externalurl"]);
                    Response.Redirect(qry);
                }
                else
                {
                    string qry = "/engineering/coursedetail.aspx?mpgid=102&pgidtrail=102&courseid=" + Conversion.Val(courseid) + "";
                    Response.Redirect(qry);
                }
            }
        }
    }
}