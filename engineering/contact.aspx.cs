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


public partial class engineering_contact : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            litsmalldesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            litpagedesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select pagedescription from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

            parameters.Clear();
            clsm.Fillcombo_Parameter("select cityname,cityid from city_master where status=1 order by cityname", parameters, ddlcity);
            ddlcity.Items[0].Text = "Select City";
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string var = string.Empty;
        string ID = string.Empty;
        try
        {           
            SqlConnection cn = new SqlConnection(clsm.strconnect);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "enquirysp";

            cmd.Parameters.AddWithValue("@FName", txtname.Text);
            cmd.Parameters.AddWithValue("@Emailid", txtemail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtmobno.Text);
            cmd.Parameters.AddWithValue("@FMessage", txtmsg.Text);
            cmd.Parameters.AddWithValue("@category", "engineering");
            cmd.Parameters.AddWithValue("@uname", "user");
            cmd.Parameters.AddWithValue("@mode", 1);
            cmd.Parameters.Add("@eid", SqlDbType.Int, 0, "@eid").Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();

            ID = cmd.Parameters["@eid"].Value.ToString();
            cn.Close();
            var = ID;

            Response.Redirect("~/thankyou.aspx?mpgid=72&pgidtrail=72&msg=thankyou");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}