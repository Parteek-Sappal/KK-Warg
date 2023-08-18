﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

public partial class engineering_usercontrols_seosection : System.Web.UI.UserControl
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    string str = string.Empty;
    public string StrMetakey;
    public string StrMetadesc;
    public string strurl = "";
    public string strnoindex = "";
    public string Strtitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //if (Conversion.Val(Request.QueryString["mpgid"]) != null)
            //{
            ShowMetaData();
            //}
        }
    }

    private void ShowMetaData()
    {
        DataSet ds1 = new DataSet();

        string strcheck = Convert.ToString(Request.Url);
        if (strcheck.Contains("http://web") == true || strcheck.Contains("http://wserver") == true)
        {
            strnoindex = "noindex, nofollow";
        }
        else
        {
            strnoindex = "index, follow";
        }
        strurl = ConfigurationManager.AppSettings["canonicaltag"] + Request.RawUrl;

        if (Conversion.Val(Request.QueryString["courseid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
            ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,other_schema from Course with (nolock) where status=1 and courseid=@courseid", parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
                StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
                Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                Strtitle = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
                {
                    strnoindex = "noindex, nofollow";
                }
                litotherschema.Text = Convert.ToString((ds1.Tables[0].Rows[0]["other_schema"]));
            }
            //else
            //{
            //    strnoindex = "noindex, nofollow";
            //}
        }
        else if (Conversion.Val(Request.QueryString["eventsid"]) > 0)
        {

            parameters.Clear();
            parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
            ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,other_schema from Events with (nolock) where status=1 and Eventsid=@eventsid", parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
                StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
                Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                Strtitle = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
                {
                    strnoindex = "noindex, nofollow";
                }
                litotherschema.Text = Convert.ToString((ds1.Tables[0].Rows[0]["other_schema"]));
            }
            //else
            //{
            //    strnoindex = "noindex, nofollow";
            //}

        }
        else if (Conversion.Val(Request.QueryString["fid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@facultyid", Conversion.Val(Request.QueryString["fid"]));
            ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,other_schema from Addfacultymaster with (nolock) where status=1 and facultyid=@facultyid", parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
                StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
                Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                Strtitle = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
                {
                    strnoindex = "noindex, nofollow";
                }
                litotherschema.Text = Convert.ToString((ds1.Tables[0].Rows[0]["other_schema"]));
            }
            //else
            //{
            //    strnoindex = "noindex, nofollow";
            //}

        }
        else if (Conversion.Val(Request.QueryString["levelid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@levelid", Conversion.Val(Request.QueryString["levelid"]));
            ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,other_schema from CourseLevel_Master with (nolock) where status=1 and levelid=@levelid", parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
                StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
                Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                Strtitle = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
                {
                    strnoindex = "noindex, nofollow";
                }
                litotherschema.Text = Convert.ToString((ds1.Tables[0].Rows[0]["other_schema"]));
            }
            //else
            //{
            //    strnoindex = "noindex, nofollow";
            //}

        }
        else if (Conversion.Val(Request.QueryString["deptid"]) > 0)
        {

            parameters.Clear();
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,other_schema from Department_Master with (nolock) where status=1 and deptid=@deptid", parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
                StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
                Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                Strtitle = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
                {
                    strnoindex = "noindex, nofollow";
                }
                litotherschema.Text = Convert.ToString((ds1.Tables[0].Rows[0]["other_schema"]));
            }
            //else
            //{
            //    strnoindex = "noindex, nofollow";
            //}
        }
        else if (Conversion.Val(Request.QueryString["pgidtrail"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,other_schema from PageMaster with (nolock) where pagestatus=1 and Pageid=@Pageid", parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
                StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
                Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                Strtitle = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());

                if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
                {
                    strnoindex = "noindex, nofollow";
                }
                litotherschema.Text = Convert.ToString((ds1.Tables[0].Rows[0]["other_schema"]));
            }
            //else
            //{
            //    strnoindex = "noindex, nofollow";
            //}


        }
        else
        {
            parameters.Clear();
            parameters.Add("@Pageid", Conversion.Val(75));
            ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,other_schema from PageMaster with (nolock) where pagestatus=1 and Pageid=@Pageid", parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
                StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
                Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
                Strtitle = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());

                if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
                {
                    strnoindex = "noindex, nofollow";
                }
                litotherschema.Text = Convert.ToString((ds1.Tables[0].Rows[0]["other_schema"]));
            }
            //else
            //{
            //    strnoindex = "noindex, nofollow";
            //}
        }
        

    }
}