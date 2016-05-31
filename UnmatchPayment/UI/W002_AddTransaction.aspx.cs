using System;
using System.Collections.Generic;
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

        protected void bntSave_Click(object sender, EventArgs e)
        {
            string _causeID = hdCauseID.Value;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = string.Empty;
                string FileSize = string.Empty;
                string FileType = string.Empty;
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
                        C006_UploadFile UploadFile = new C006_UploadFile();
                        string strAccNo = lblAccNo.Text;
                        string strProjectNo = lblPJcode.Text;
                        string strFileOriginName = Upload.FileName;
                        string strFileType = System.IO.Path.GetExtension(Upload.FileName);
                        string strFileName = ddlDocFileName.SelectedItem.Text;
                        string strFileTypeID = ddlDocFileName.SelectedValue;
                        string strFileSize = Upload.FileBytes.Length.ToString();
                        string strFilePath = ConfigurationSettings.AppSettings["Filepath"].ToString();
                        string strUserID = Emp.USER_ID;
                        string strComment = txtComment.Text;


                        int FileID = UploadFile.InsertUploadDetail(strFileOriginName, strFileTypeID, strFileSize, strProjectNo, strAccNo, strUserID, strComment, TVSID);
                        if (FileID > 0)
                        {
                            string strFullPath = strFilePath + FileID + "_" + strFileOriginName;
                            Upload.SaveAs(strFullPath);
                            string strEncrypt = UploadFile.GetSha1Hash(strFullPath);
                            UploadFile.UpdateEncrypt(FileID, strEncrypt);
                            lblFileUpload.Text = "อัพโหลดเสร็จสิ้น";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('อัพโหลดเสร็จสิ้น');", true);
                            lblFileUpload.ForeColor = Color.Green;
                            //Upload.Enabled = false;
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
    }
}