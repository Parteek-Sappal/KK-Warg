﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

public partial class backoffice_research_addresearch : System.Web.UI.Page
{
    HttpCookie AUserSession;
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!Page.IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter(" select ntype,ntypeid from researchtype where status=1 order by  displayorder", parameters, ntypeid);

            parameters.Clear();
            clsm.Fillcombo_Parameter("select labcattitle,lcid from labcategory where status=1 order by  displayorder", parameters, lcid);


            //bindstream();
            //binddcourse();
            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["nid"], out p) == true)
            {

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                //bindstream();

                parameters.Clear();
                parameters.Add("@nid", p);
                string strsql = "Select * from research where researchid=@nid";
                clsm.MoveRecord_Parameter(this, researchid.Parent, strsql, parameters);
                //binddcourse();
                parameters.Clear();
                parameters.Add("@nid", p);
                clsm.MoveRecord_Parameter(this, researchid.Parent, strsql, parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(researchDesc.Text);
                CKeditor2.Text = Server.HtmlDecode(shortdesc.Text);



                if (UploadEvents.Text != "")
                {

                    lnkremove.Visible = true;
                    Image1.ImageUrl = "../../Uploads/SmallImages/" + UploadEvents.Text;
                    Image1.Visible = true;
                }
                if (largeimage.Text != "")
                {

                    lnklarge.Visible = true;
                    imglarge.ImageUrl = "/Uploads/LargeImages/" + largeimage.Text;
                    imglarge.Visible = true;
                }
                if (homeimage.Text != "")
                {

                    lnkhome.Visible = true;
                    imghome.ImageUrl = "/Uploads/SmallImages/" + homeimage.Text;
                    imghome.Visible = true;
                }
                if (verylargeimage.Text != "")
                {

                    lnkverylarge.Visible = true;
                    imageverylarge.ImageUrl = "/Uploads/LargeImages/" + verylargeimage.Text;
                    imageverylarge.Visible = true;
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
    private string Pad(Int32 numberOfSpaces)
    {
        string Spaces = "";
        for (int i = 0; i < numberOfSpaces; i++)
        {
            Spaces += "&nbsp;&nbsp;&raquo;&nbsp;";
        }
        return Server.HtmlDecode(Spaces);
    }
    private DataTable GetData()
    {
        DataSet ds1 = new DataSet();
        DataTable tbl = new DataTable("data");
        ds1 = clsm.sendDataset("select * from project order by displayorder", false);
        tbl = ds1.Tables[0].Copy();
        ds1.Dispose();
        return tbl;
    }
    protected void lnkremove_Click(object sender, EventArgs e)
    {
        parameters.Clear();
        parameters.Add("@researchid", Convert.ToInt32((researchid.Text)));
        string strsql = "update research set UploadEvents='' where researchid=@researchid";
        clsm.ExecuteQry_Parameter(strsql, parameters);
        parameters.Clear();
        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(UploadEvents.Text));
        if (F1.Exists)
        {
            F1.Delete();
        }
        UploadEvents.Text = "";
        lnkremove.Visible = false;
        trsuccess.Visible = true;
        Image1.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
    public bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".pdf":
                return true;
            case ".doc":
                return true;
            case ".docx":
                return true;
            case ".txt":
                return true;
            default:
                return false;
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
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            researchDesc.Text = Server.HtmlEncode(CKeditor1.Text);
            shortdesc.Text = Server.HtmlEncode(CKeditor2.Text);
            if (researchsdate.Text == String.Empty)
            {
                researchsdate.Text = "01/01/1900";
            }
            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            if (researchid.Text == "")
            {
                if (File1.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    UploadEvents.Text = HttpUtility.HtmlEncode(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                }


                if (File2.PostedFile.FileName != "")
                {
                    if ((CheckFileType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt";
                        return;
                    }
                    uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    //'Else
                    //'    trnotice.Visible = True
                    //'    lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt"
                    //'    Exit Sub

                }
                if (File3.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File3.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";

                        return;
                    }
                    largeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                }
                if (File4.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File4.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";

                        return;
                    }
                    homeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
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
                    verylargeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(File5.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                }
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                string var = clsm.MasterSave(this, researchid.Parent, 31, mainclass.Mode.modeAdd, "researchSP", Session["UserId"].ToString());
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                if (File1.PostedFile.FileName != "")
                {
                    string strhomeimg = clsm.SendValue("Select UploadEvents from research where researchid=" + Convert.ToInt32(var)).ToString();
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + strhomeimg);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + strhomeimg);
                }
                if (File2.PostedFile.FileName != "")
                {
                    parameters.Clear();
                    parameters.Add("@researchid", Convert.ToInt32((var)));
                    string StrFileName = clsm.SendValue_Parameter("Select uploadfile from research where researchid=@researchid", parameters).ToString();

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + StrFileName);
                }
                if (File3.PostedFile.FileName != "")
                {
                    string strhomeimg = clsm.SendValue("Select largeimage from research where researchid=" + Convert.ToInt32(var)).ToString();

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + strhomeimg);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + strhomeimg);
                }

                if (File4.PostedFile.FileName != "")
                {
                    string homeimage = clsm.SendValue("Select homeimage from research where researchid=" + Convert.ToInt32(var)).ToString();

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + homeimage);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + homeimage);
                }
                if (File5.PostedFile.FileName != "")
                {
                    string verylargeimage = clsm.SendValue("Select verylargeimage from research where researchid=" + Convert.ToInt32(var)).ToString();

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + verylargeimage);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File5.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + verylargeimage);
                }
                Response.Redirect("addresearch.aspx?add=add");

            }
            else
            {
                if (File1.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }
                if (File2.PostedFile.FileName != "")
                {
                    if ((CheckFileType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Pdf or Doc,Docx or txt";
                        return;
                    }
                }
                if (File3.PostedFile.FileName != "")
                {
                    if ((CheckImgType(File3.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }
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


                string var = clsm.MasterSave(this, researchid.Parent, 31, mainclass.Mode.modeModify, "researchSP", Session["UserId"].ToString());
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;


                if (File1.PostedFile.FileName != "")
                {
                    UploadEvents.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "krs-" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));


                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(UploadEvents.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();
                    SqlCommand objcmd2 = new SqlCommand("update research set UploadEvents=@UploadEvents where researchid=" + var + "", objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@UploadEvents", UploadEvents.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Convert.ToString(UploadEvents.Text));
                }

                if (File2.PostedFile.FileName != "")
                {
                    uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "rcf-" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + Convert.ToString(uploadfile.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    // update banner file

                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();

                    SqlCommand objcmd = new SqlCommand("update research set uploadfile=@uploadfile where researchid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadfile", Server.HtmlDecode(uploadfile.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Files\\" + Convert.ToString(uploadfile.Text));
                }

                if (File3.PostedFile.FileName != "")
                {

                    largeimage.Text = HttpUtility.HtmlEncode(var + "rcl-" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "").Replace("&", "")));

                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Convert.ToString(largeimage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();

                    SqlCommand objcmd2 = new SqlCommand("update research set largeimage=@largeimage where researchid=" + var + "", objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@largeimage", largeimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + Convert.ToString(largeimage.Text));
                }


                if (File4.PostedFile.FileName != "")
                {

                    homeimage.Text = HttpUtility.HtmlEncode(var + "rch-" + Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(homeimage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();

                    SqlCommand objcmd2 = new SqlCommand("update research set homeimage=@homeimage where researchid=" + var + "", objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@homeimage", homeimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Convert.ToString(homeimage.Text));
                }
                if (File5.PostedFile.FileName != "")
                {

                    verylargeimage.Text = HttpUtility.HtmlEncode(var + "rchvl-" + Path.GetFileName(File5.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Convert.ToString(verylargeimage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();

                    SqlCommand objcmd2 = new SqlCommand("update research set verylargeimage=@verylargeimage     where researchid=" + var + "", objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@verylargeimage", verylargeimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File5.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + Convert.ToString(verylargeimage.Text));
                }


                Response.Redirect("viewresearch.aspx?edit=edit");
            }
        }
        catch (Exception ex)
        {

            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

        if (Conversion.Val(researchid.Text) == 0)
        {
            clsm.ClearallPanel(this, researchid.Parent);
            CKeditor1.Text = "";
            CKeditor2.Text = "";
        }
        else
        {
            Response.Redirect("viewresearch.aspx");
        }
    }
    protected void lnkremovefile_Click(object sender, EventArgs e)
    {

        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + Convert.ToString(uploadfile.Text));
        if (F1.Exists)
        {
            F1.Delete();

        }
        parameters.Clear();
        parameters.Add("@researchid", Convert.ToInt32(researchid.Text));
        clsm.ExecuteQry_Parameter("update research set uploadfile='' where researchid=@researchid", parameters);
        lnkremovefile.Visible = false;
    }
    protected void lnklarge_Click(object sender, EventArgs e)
    {
        parameters.Clear();
        parameters.Add("@researchid", Convert.ToInt32((researchid.Text)));
        string strsql = "update research set largeimage='' where researchid=@researchid";
        clsm.ExecuteQry_Parameter(strsql, parameters);
        parameters.Clear();

        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Convert.ToString(UploadEvents.Text));
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
    protected void lnkhome_Click(object sender, EventArgs e)
    {
        parameters.Clear();
        parameters.Add("@researchid", Convert.ToInt32((researchid.Text)));
        string strsql = "update research set homeimage='' where researchid=@researchid";
        clsm.ExecuteQry_Parameter(strsql, parameters);
        parameters.Clear();
        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + Convert.ToString(homeimage.Text));
        if (F1.Exists)
        {
            F1.Delete();
        }
        homeimage.Text = "";
        lnkhome.Visible = false;
        trsuccess.Visible = true;
        imghome.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
    protected void lnkverylarge_Click(object sender, EventArgs e)
    {
        parameters.Clear();
        parameters.Add("@researchid", Convert.ToInt32((researchid.Text)));
        string strsql = "update research set verylargeimage='' where researchid=@researchid";
        clsm.ExecuteQry_Parameter(strsql, parameters);
        parameters.Clear();
        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + Convert.ToString(verylargeimage.Text));
        if (F1.Exists)
        {
            F1.Delete();
        }
        verylargeimage.Text = "";
        lnkverylarge.Visible = false;
        trsuccess.Visible = true;
        imageverylarge.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
    //protected void streamid_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    binddcourse();

    //}
    //private void bindstream()
    //{
    //    parameters.Clear();
    //    clsm.Fillcombo_Parameter("select streamname,streamid from stream_master order by displayorder", parameters, streamid);

    //}
    //private void binddcourse()
    //{

    //    parameters.Clear();
    //    parameters.Add("@streamid", Conversion.Val(streamid.SelectedValue));
    //    clsm.Fillcombo_Parameter("select coursename,courseid from course where status=1 and streamid=@streamid order by  displayorder", parameters, courseid);



    //}

}