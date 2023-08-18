using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class engineering_testpp : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Data> DropDownData = new List<Data>();
        DropDownData.Add(new Data { Value = "emp1", Text = "Adams" });
        DropDownData.Add(new Data { Value = "emp2", Text = "James" });
        DropDownData.Add(new Data { Value = "emp3", Text = "Maria" });
        DropDownData.Add(new Data { Value = "emp4", Text = "Jessica" });
        DropDownData.Add(new Data { Value = "emp5", Text = "Jenneth" });
        DropDownList1.DataSource = DropDownData;
        DropDownList1.DataBind();
    }
    protected void TextChanged(object sender, EventArgs e)
    {

    this.BindListBox();
}

private void BindListBox()
{        
    string conn = clsm.strconnect;
    using (SqlConnection con = new SqlConnection(conn))
    {
        using (SqlCommand cmd = new SqlCommand("select courseid,coursename from course WHERE coursename LIKE @Name + '%'", con))
        {
            cmd.Parameters.AddWithValue("@Name", txName.Text);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    lstCustomers.DataSource = dt;
                    lstCustomers.DataTextField = "coursename";
                    lstCustomers.DataValueField = "courseid";
                    lstCustomers.DataBind();
                }
            }
        }
    }
}
    public class Data
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        int sum = Convert.ToInt32(TextBox1.Text) + Convert.ToInt32(TextBox2.Text);
        lblsum.Text = "The Sum = " + sum.ToString();
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
}