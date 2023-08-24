using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thankyou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] == "Sub")
            {
                lblsuccess.Text = "Thank you ! You have Successfully Subscribed for Us.";
            }
            if (Request.QueryString["msg"] == "order")
            {
                lblsuccess.Text = "<p class='fsize-3 font-heading text-prime'>Your Enquiry  has been Successfully Submitted.</p> <p class='fsize-5'>Our representative will contact you soon.</p>";

            }
            if (Request.QueryString["msg"] == "thankyou")
            {
                lblsuccess.Text = "<p class='fsize-3 font-heading text-prime'>Your Enquiry  has been Successfully Submitted.</p> <p class='fsize-5'>Our representative will contact you soon.</p>";
            }

            if (Request.QueryString["msg"] == "apply")
            {
                lblsuccess.Text = "<p class='fsize-3 font-heading text-prime'>Your Enquiry  has been Successfully Submitted.</p> <p class='fsize-5'>Our representative will contact you soon.</p>";
            }

            if (Request.QueryString["msg"] == "job")
            {
                lblsuccess.Text = "<p class='fsize-3 font-heading text-prime'>Your Enquiry  has been Successfully Submitted.</p> <p class='fsize-5'>Our representative will contact you soon.</p>";
            }


        }
    }
}