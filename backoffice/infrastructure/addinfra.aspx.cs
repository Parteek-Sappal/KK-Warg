﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;
public partial class backoffice_infrastructure_addinfra : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    HttpCookie AUserSession;


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if ((Page.IsPostBack == false))
        {

            Parameters.Clear();
            //clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", Parameters, collageid);
            clsm.Fillcombo_Parameter("select distinct (cm.collagename+' ('+cp.campus_name+')') as collagename,cm.collageid,cm.campusid,cm.displayorder from collage_master cm inner join campus cp on cm.campusid=cp.campusid  where cm.status=1 order by cm.displayorder", Parameters, collageid);

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select DeptName,deptid from department_Master where status=1 order by displayorder", Parameters, deptid);

            Parameters.Clear();
            clsm.Fillcombo_Parameter(" select infcattitle,lcid from infracategory where status=1 order by  displayorder", Parameters, lcid);

            binddepartment();
            // branch()
            if ((Conversion.Val(Request.QueryString["infid"]) != 0))
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;

                Parameters.Clear();
                Parameters.Add("@infid", Conversion.Val(Request.QueryString["infid"]));
                clsm.MoveRecord_Parameter(this, infid.Parent, "select * from infrastructure where infid=@infid", Parameters);

                binddepartment();

                Parameters.Add("@infid", Conversion.Val(Request.QueryString["infid"]));
                clsm.MoveRecord_Parameter(this, infid.Parent, "select * from infrastructure where infid=@infid", Parameters);

                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(longDesc.Text);
                CKeditor2.Text = Server.HtmlDecode(shortdesc.Text);
                if (UploadEvents.Text !="")
                {
                    lnkremove.Visible = true;
                    Image2.ImageUrl = "/Uploads/SmallImages/"+UploadEvents.Text;
                    Image2.Visible = true;
                }
                if (largeimage.Text != "")
                {
                    lnklarge.Visible = true;
                    imglarge.ImageUrl = "/Uploads/LargeImages/" + largeimage.Text;
                    imglarge.Visible = true;
                }
                if (uploadfile.Text != "")
                {
                    lnkremovefile.Visible = true;
                }


            }

            if (Request.QueryString["add"] != null)
            {
                if (Request.QueryString["add"].ToString() == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
            }

        }

    }


    public void binddepartment()
    {
        Parameters.Clear();
        Parameters.Add("@schoolid", Conversion.Val(collageid.SelectedValue));
        clsm.Fillcombo_Parameter("select DeptName,deptid from Department_Master where status=1 and schoolid=@schoolid order by displayorder", Parameters, deptid);

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string StrFileName;
            longDesc.Text = Server.HtmlEncode(CKeditor1.Text.Trim());
            shortdesc.Text = Server.HtmlEncode(CKeditor2.Text.Trim());

            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;


            if (infid.Text == "")
            {
                if (File4.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File4.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    UploadEvents.Text = HttpUtility.HtmlEncode(Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                }


                if (File6.PostedFile.FileName != "")
                {
                    if ((CheckFileType(Path.GetFileName(File6.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt";
                        return;
                    }
                    uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File6.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));

                }
                if (File5.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File5.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";

                        return;
                    }
                    largeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(File5.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                }

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;

                object var = clsm.MasterSave(this, infid.Parent, 23, mainclass.Mode.modeAdd, "infrastructureSP", Convert.ToString(Session["UserId"]));
               
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;



                if (File4.PostedFile.FileName != "")
                {
                    string strhomeimg = clsm.SendValue("Select UploadEvents from infrastructure where infid=" + Convert.ToInt32(var)).ToString();
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + strhomeimg);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + strhomeimg);
                }
                if (File6.PostedFile.FileName != "")
                {
                    Parameters.Clear();
                    Parameters.Add("@infid", Convert.ToInt32((var)));
                    String StrFileName1 = clsm.SendValue_Parameter("Select uploadfile from infrastructure where infid=@infid", Parameters).ToString();

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + StrFileName1);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File6.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + StrFileName1);
                }
                if (File5.PostedFile.FileName != "")
                {
                    string strhomeimg = clsm.SendValue("Select largeimage from infrastructure where infid=" + Convert.ToInt32(var)).ToString();

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + strhomeimg);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File5.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + strhomeimg);
                }



                clsm.ClearallPanel(this, infid.Parent);
                CKeditor1.Text = "";
                CKeditor2.Text = "";

                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
            else
            {
                if (File4.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File4.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }
                if (File6.PostedFile.FileName != "")
                {
                    if ((CheckFileType(Path.GetFileName(File6.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Pdf or Doc,Docx or txt";
                        return;
                    }
                }
                if (File5.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File5.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;

                object var = clsm.MasterSave(this, infid.Parent, 23, mainclass.Mode.modeModify, "infrastructureSP", Convert.ToString(Session["UserId"]));
              
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;


                if (File4.PostedFile.FileName != "")
                {
                    UploadEvents.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "infs-" + Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));


                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(UploadEvents.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();
                    SqlCommand objcmd2 = new SqlCommand("update infrastructure set UploadEvents=@UploadEvents where infid=" + var + "", objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@UploadEvents", UploadEvents.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Convert.ToString(UploadEvents.Text));
                }

                if (File6.PostedFile.FileName != "")
                {
                    uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "inff-" + Path.GetFileName(File6.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + Convert.ToString(uploadfile.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    // update banner file

                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();

                    SqlCommand objcmd = new SqlCommand("update infrastructure set uploadfile=@uploadfile where infid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadfile", Server.HtmlDecode(uploadfile.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File6.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Files\\" + Convert.ToString(uploadfile.Text));
                }

                if (File5.PostedFile.FileName != "")
                {

                    largeimage.Text = HttpUtility.HtmlEncode(var + "infl-" + Path.GetFileName(File5.PostedFile.FileName.Replace(" ", "").Replace("&", "")));

                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Convert.ToString(largeimage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();

                    SqlCommand objcmd2 = new SqlCommand("update infrastructure set largeimage=@largeimage where infid=" + var + "", objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@largeimage", largeimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File5.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + Convert.ToString(largeimage.Text));
                }

                Response.Redirect("viewinfra.aspx?edit=edit");
            }

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if ((Conversion.Val(infid.Text) == 0))
        {
            clsm.ClearallPanel(this, infid.Parent);
        }
        else
        {
            Response.Redirect("viewinfra.aspx");
        }

    }

    public bool CheckImgType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".gif":
                return true;
            case ".png":
                return true;
            case ".jpg":
                return true;
            case ".jpeg":
                return true;
            case ".bmp":
                return true;
            case ".webp":
                return true;
            default:
                return false;
        }
    }

    public bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".doc":
                return true;

            case ".pdf":
                return true;

            case ".docx":
                return true;

            case ".txt":
                return true;

            default:
                return false;

        }
    }


    protected void lnkremove_Click(object sender, EventArgs e)
    {
        Parameters.Clear();
        Parameters.Add("@infid", Convert.ToInt32((infid.Text)));
        string strsql = "update infrastructure set UploadEvents='' where infid=@infid";
        clsm.ExecuteQry_Parameter(strsql, Parameters);
        Parameters.Clear();
        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(UploadEvents.Text));
        if (F1.Exists)
        {
            F1.Delete();
        }
        UploadEvents.Text = "";
        lnkremove.Visible = false;
        trsuccess.Visible = true;
        Image2.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }

    protected void lnkremovefile_Click(object sender, EventArgs e)
    {

        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + Convert.ToString(uploadfile.Text));
        if (F1.Exists)
        {
            F1.Delete();

        }
        Parameters.Clear();
        Parameters.Add("@infid", Convert.ToInt32(infid.Text));
        clsm.ExecuteQry_Parameter("update infrastructure set uploadfile='' where infid=@infid", Parameters);
        lnkremovefile.Visible = false;
    }
    protected void lnklarge_Click(object sender, EventArgs e)
    {
        Parameters.Clear();
        Parameters.Add("@infid", Convert.ToInt32((infid.Text)));
        string strsql = "update infrastructure set largeimage='' where infid=@infid";
        clsm.ExecuteQry_Parameter(strsql, Parameters);
        Parameters.Clear();

        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Convert.ToString(largeimage.Text));
        largeimage.Text = "";
        if (F1.Exists)
        {
            F1.Delete();

        }
        lnklarge.Visible = false;
        trsuccess.Visible = true;
        imglarge.Visible = false;
        lblsuccess.Text = "Record deleted successfully.";
    }


    protected void collageid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        binddepartment();
    }
}