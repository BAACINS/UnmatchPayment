﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnmatchPayment.Class;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class AddTransaction : System.Web.UI.Page
    {
        #region Property
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        C001_DataMng DataMNG = new C001_DataMng();
        C002_GetDataDDL getDDL = new C002_GetDataDDL();
        C006_UploadFile UploadFile = new C006_UploadFile();
        private EMPLOYEE_SELECTResult Emp
        {
            get
            {
                if (Session["Emp"] == null)
                {
                    Session["Emp"] = null;
                }
                return (EMPLOYEE_SELECTResult)Session["Emp"];
            }
            set
            {
                Session["Emp"] = value;
            }
        }
        private int TellerID
        {
            get
            {
                int ID = new int();
                if (ViewState["TellerID"] != null)
                    ID = (int)ViewState["TellerID"];
                return ID;
            }
            set
            {
                ViewState["TellerID"] = value;
            }
        }
        private DataTable dtUploadedFile
        {
            get
            {
                DataTable dt = new DataTable();
                if ((DataTable)ViewState["dtUploadFile"] != null)
                    dt = (DataTable)ViewState["dtUploadFile"];
                return dt;
            }
            set
            {
                ViewState["dtUploadFile"] = value;
            }
        }
        private string StatusCode
        {
            get
            {
                if (ViewState["StatusCode"] != null)
                    return ViewState["StatusCode"].ToString();
                return string.Empty;
            }
            set
            {
                ViewState["StatusCode"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUnmatchCause();
                GetTellerpaymentDetail();
                GetFileType();
                if(Application["TellerID"] != null)
                {
                    TellerID = Convert.ToInt32(Application["TellerID"]);
                    GetUploadedFile();
                }
            }
        }

        private void GetUnmatchCause()
        {
            DataTable dtUnmatch = new DataTable();
            var dtAcc = from Cause in dbAcc.UnmatchCauses
                        select new { Cause.CauseID,Cause.CauseDescription };

            dtUnmatch = DataMNG.LINQToDataTable(dtAcc);

            StringBuilder strCause = new StringBuilder();

            for(int i = 0; i < dtUnmatch.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    strCause.Append(string.Format(@"
                    <div>
                    <span class='spanleft'>
                    <input type = 'radio' name='radio' id='radio{0}' class='radio' onclick='rdbChecked({0})'/>
                    <label for= 'radio{0}' > {1} </label>
                    </span>", dtUnmatch.Rows[i]["CauseID"].ToString(), dtUnmatch.Rows[i]["CauseDescription"].ToString()));
                }
                else
                {
                    strCause.Append(string.Format(@"
                    <span class='spanright'>
                    <input type = 'radio' name='radio' id='radio{0}' class='radio' onclick='rdbChecked({0})'/>
                    <label for= 'radio{0}' > {1} </label>
                    </span>
                    </div>", dtUnmatch.Rows[i]["CauseID"].ToString(), dtUnmatch.Rows[i]["CauseDescription"].ToString()));
                }
            }

            ltrbl.Text = strCause.ToString();
        }
        private void GetTellerpaymentDetail()
        {
            try
            {
                DateTimeFormatInfo fmt = (new CultureInfo("th-TH")).DateTimeFormat;
                if (Application["TellerID"] != null)
                {
                    int TellerID = int.Parse(Application["TellerID"].ToString());
                    var teller = (from tel in dbAcc.VW_TellerPaymentDetails
                                 where tel.TellerPaymentDetailID == TellerID
                                 select tel).FirstOrDefault();
                    lblCompCode.Text = teller.CompCode;
                    lblAmount.Text = teller.Amount.ToString();
                    lblRef1.Text = teller.Ref1;
                    lblRef2.Text = teller.Ref2;
                    lblRefName.Text = teller.CustomerName;
                    lblPaymentDate.Text = DateTime.Parse(teller.PaymentDateTime.ToString()).ToString("dd-MM-yyyy",fmt);
                }
            }
            catch
            {

            }
        }
        private void GetFileType()
        {
            ddlFileType.DataSource = getDDL.GetFileType();
            ddlFileType.DataTextField = "FileTypeName";
            ddlFileType.DataValueField = "FileTypeID";
            ddlFileType.DataBind();
        }
        private void GetUploadedFile()
        {
            dtUploadedFile = UploadFile.SearchFileUploadDetail(TellerID);
            gvUploadFile.DataSource = dtUploadedFile;
            gvUploadFile.DataBind();
        }

        protected void bntSave_Click(object sender, EventArgs e)
        {
            string _causeID = hdCauseID.Value;

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                FileUpload Upload = BrowsFile;
                lblFileUpload.ForeColor = Color.Red;
                if (Upload.HasFile)
                {
                    string[] setFileName = Upload.FileName.Split('.');
                    if (Upload.FileBytes.Length > 600000)
                        lblFileUpload.Text = "ขนาดไฟล์เกิน 600 KB";
                    else if (setFileName[setFileName.Length - 1].ToLower() != "jpg" && setFileName[setFileName.Length - 1].ToLower() != "pdf")
                        lblFileUpload.Text = "ต้องเป็น PDF หรือ JPG เท่านั้น";
                    else
                    {
                        lblFileUpload.Text = string.Empty;
                        string strFileTypeID = ddlFileType.SelectedValue;
                        string strFileOriginName = Upload.FileName;
                        string strFileSize = Upload.FileBytes.Length.ToString();
                        string strUserID = Emp.USER_ID;

                        string strFilePath = ConfigurationSettings.AppSettings["Filepath"].ToString();

                        int FileID = UploadFile.InsertUploadDetail(strFileTypeID, TellerID, strFileOriginName, strFileSize, strUserID);
                        if (FileID > 0)
                        {
                            string strFullPath = strFilePath + FileID + "_" + strFileOriginName;
                            Upload.SaveAs(strFullPath);
                            string strEncrypt = UploadFile.GetSha1Hash(strFullPath);
                            UploadFile.UpdateEncrypt(FileID, strEncrypt);
                            lblFileUpload.Text = "อัพโหลดเสร็จสิ้น";
                            lblFileUpload.ForeColor = Color.Green;
                            GetUploadedFile();
                        }
                        else if (FileID == -1)
                        {
                            lblFileUpload.Text = "ไฟล์ซ้ำ";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('ไฟล์ซ้ำ');", true);
                        }
                        else
                            lblFileUpload.Text = "อัพโหลดไม่สำเร็จ";
                    }
                }
                else
                {
                    //if (Upload.Enabled == false)
                    //    lblFileUpload1.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('UploadFile ไม่สำเร็จ');", true);
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            string strFilePath = ConfigurationSettings.AppSettings["Filepath"].ToString();
            string _strFileID = ((LinkButton)sender).CommandArgument;
            string _strFileName = ((LinkButton)sender).Text.Replace("/", "_").Replace(" ", "");
            string _strFullPath = strFilePath + _strFileID;
            string[] _strFileType = _strFileID.Split('.');
            _strFileName = _strFileName + "." + _strFileType[_strFileType.Length - 1];

            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(_strFileName, System.Text.Encoding.UTF8) + "");

            // Write the file to the Response
            const int bufferLength = 10000;
            byte[] buffer = new Byte[bufferLength];
            int length = 0;
            Stream download = null;
            try
            {
                download = new FileStream(_strFullPath, FileMode.Open, FileAccess.Read);
                do
                {
                    if (Response.IsClientConnected)
                    {
                        length = download.Read(buffer, 0, bufferLength);
                        Response.OutputStream.Write(buffer, 0, length);
                        buffer = new Byte[bufferLength];
                    }
                    else
                    {
                        length = -1;
                    }
                }
                while (length > 0);
                Response.Flush();
                Response.End();
            }
            finally
            {
                if (download != null)
                    download.Close();
            }
        }

        protected void btnDelFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (new[] { "93", "94", "95" }.Contains(StatusCode))
                    return;
                C006_UploadFile Upload = new C006_UploadFile();
                string strFilePath = ConfigurationSettings.AppSettings["Filepath"].ToString();
                string _strFileID = ((Button)sender).CommandArgument;
                string _strUserID = Emp.USER_ID;

                var FileResults = from Row in dtUploadedFile.AsEnumerable()
                                  where Row.Field<long>("FIleID") == Convert.ToInt32(_strFileID)
                                  select Row;
                DataTable dtDelFile = FileResults.CopyToDataTable();

                string _strFullPath = strFilePath + _strFileID + "_" + dtDelFile.Rows[0]["FileOriginName"];
                string _strFileEncrypt = Upload.GetSha1Hash(_strFullPath);
                string _strdbEncrypt = dtDelFile.Rows[0]["EncryptCode"].ToString();
                if (_strdbEncrypt == _strFileEncrypt)
                {
                    Upload.DeleteFile(int.Parse(_strFileID), _strUserID);
                    System.IO.File.Delete(_strFullPath);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('ลบไฟล์เสร็จสิ้น!!!');", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('ลบไฟล์ไม่สำเร็จ!!!');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('ลบไฟล์ไม่สำเร็จ!!!');", true);
            }
            finally
            {
                GetUploadedFile();
            }
        }
    }
}