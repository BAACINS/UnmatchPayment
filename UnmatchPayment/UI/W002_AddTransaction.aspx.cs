using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
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
        private int UPID
        {
            get
            {
                int ID = new int();
                if (ViewState["UPID"] != null)
                    ID = (int)ViewState["UPID"];
                return ID;
            }
            set
            {
                ViewState["UPID"] = value;
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
        private DataTable dtUnmatchedCause
        {
            get
            {
                DataTable dt = new DataTable();
                if ((DataTable)ViewState["dtUnmatchedCause"] != null)
                    dt = (DataTable)ViewState["dtUnmatchedCause"];
                return dt;
            }
            set
            {
                ViewState["dtUnmatchedCause"] = value;
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
        private string urlPrev
        {
            get
            {
                if (ViewState["urlPrev"] != null)
                    return ViewState["urlPrev"].ToString();
                return string.Empty;
            }
            set
            {
                ViewState["urlPrev"] = value;
            }
        }
        private string strListCause
        {
            get
            {
                if (ViewState["strListCause"] != null)
                    return ViewState["strListCause"].ToString();
                return string.Empty;
            }
            set
            {
                ViewState["strListCause"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                urlPrev = Request.ServerVariables["HTTP_REFERER"];
                StatusCode = "01";
                GetTellerpaymentDetail();
                GetUnmatchCause();
                GetFileType();
                if(Application["isEdit"] != null)
                {
                    if (Application["isEdit"].ToString() == "2")
                    {
                        btnSave.Text = "อนุมัติ";
                        StatusCode = "02";
                    }
                }
                if(Application["TellerID"] != null)
                {
                    TellerID = Convert.ToInt32(Application["TellerID"]);
                    GetUploadedFile();
                }
                else
                {
                    Response.Redirect("~/UI/Default.aspx");
                }
                if (Application["UPID"] != null)
                {
                    UPID = Convert.ToInt32(Application["UPID"]);
                    //GetUnmatched detail
                }
            }
            if(string.IsNullOrEmpty(hdCauseID.Value) != true)
            {
                //int CauseID = int.Parse(hdCauseID.Value)-1;
                //txtCompCode.Enabled = !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isCompCode"]);
                //txtAmount.Enabled = !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isAmount"]);
                //txtRef1.Enabled = !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isRef1"]);
                //txtRef2.Enabled = !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isRef2"]);
                //txtRefName.Enabled= !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isRefName"]);
                //txtPaymentDate.Enable = !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isPaymentdate"]);
                //txtDepNo.Enabled= !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isRefund"]);
                //btnUpload.Enabled= !Convert.ToBoolean(dtUnmatchedCause.Rows[CauseID]["isUplaodFile"]);
            }
        }

        private void GetUnmatchCause()
        {
            //DataTable dtUnmatch = new DataTable();
            var dtAcc = from Cause in dbAcc.UnmatchCauses
                        where Cause.isActive == true
                        select new
                        {
                            Cause.CauseID,
                            Cause.CauseDescription,
                            isUpdateUnmatched = Convert.ToInt16(Cause.isUpdateUnmatched),
                            isCompCode = Convert.ToInt16(Cause.isCompCode),
                            isAmount = Convert.ToInt16(Cause.isAmount),
                            isRef1 = Convert.ToInt16(Cause.isRef1),
                            isRef2 = Convert.ToInt16(Cause.isRef2),
                            isRefName = Convert.ToInt16(Cause.isRefName),
                            isPaymentdate = Convert.ToInt16(Cause.isPaymentdate),
                            isRefund = Convert.ToInt16(Cause.isRefund),
                            isUplaodFile = Convert.ToInt16(Cause.isUploadFile)
                        };

            dtUnmatchedCause = DataMNG.LINQToDataTable(dtAcc);

            StringBuilder strCause = new StringBuilder();

            for (int i = 0; i < dtUnmatchedCause.Rows.Count; i++)
            {
                strListCause = "["
                        + dtUnmatchedCause.Rows[i]["isUpdateUnmatched"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isCompCode"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isAmount"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isRef1"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isRef2"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isRefName"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isPaymentdate"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isRefund"].ToString() + ","
                        + dtUnmatchedCause.Rows[i]["isUplaodFile"].ToString()
                        + "]";
                string strCauseID = dtUnmatchedCause.Rows[i]["CauseID"].ToString();
                string strCauseDes = dtUnmatchedCause.Rows[i]["CauseDescription"].ToString();
                string strIsEdit = Convert.ToString(Application["isEdit"]) ?? string.Empty;
                if (new[] {"1","2"}.Any(strIsEdit.Contains))
                {
                    if(strCauseID == hdCauseID.Value)
                    {
                        hdlistCause.Value = strListCause;
                    }
                }
                if (i % 2 == 0)
                {
                    //add radio in literal
                    strCause.Append(string.Format(@"
                    <div>
                    <span class='spanleft'>
                    <input type = 'radio' name='radio' id='radio{0}' class='radio' runat='server' onclick='rdbChecked({0},{1})'/>
                    <label for= 'radio{0}' > {2} </label>
                    </span>", strCauseID, strListCause, strCauseDes));
                }
                else
                {
                    strCause.Append(string.Format(@"
                    <span class='spanright'>
                    <input type = 'radio' name='radio' id='radio{0}' class='radio' runat='server' onclick='rdbChecked({0},{1})'/>
                    <label for= 'radio{0}' > {2} </label>
                    </span>
                    </div>", strCauseID, strListCause, strCauseDes));
                }
            }

            ltrbl.Text = strCause.ToString();
        }
        private void GetTellerpaymentDetail()
        {
            try
            {
                DateTimeFormatInfo fmt = (new CultureInfo("th-TH")).DateTimeFormat;
                //select data from tellerpayment
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

                    //select data from UnmatchedPayment [1=Edit,else = insert]
                    string strIsEdit = Convert.ToString(Application["isEdit"]) ?? string.Empty;
                    if (new[] { "1", "2" }.Any(strIsEdit.Contains))
                    {
                        var UP = (from Unmatch in dbAcc.tbUnmatchPayments
                                  where Unmatch.TellerPaymentDetailID == TellerID
                                  select Unmatch).FirstOrDefault();
                        if (UP != null)
                        {
                            txtCompCode.Text = UP.CompCode;
                            txtAmount.Text = UP.Amount.ToString();
                            txtRef1.Text = UP.Ref1;
                            txtRef2.Text = UP.Ref2;
                            txtRefName.Text = UP.RefName;
                            if(UP.PaymentDate != null)
                                txtPaymentDate.TextDate = DateTime.Parse(UP.PaymentDate.ToString()).ToString("dd-MM-yyyy", fmt);
                            txtDepNo.Text = UP.DepNo;
                            hdCauseID.Value = UP.CauseID.ToString();
                        }
                    }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //check Dep
            C008_CheckDep checkDep = new C008_CheckDep();
            if(txtDepNo.Enabled==true && txtDepNo.Text != string.Empty)
            {
                if (!checkDep.checkAccount(txtDepNo.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('เลขที่บัญชีเงินฝากไม่ถูกต้อง');", true);
                    return;
                }
            }

            //set detail Unmatchpayment
            tbUnmatchPayment UP = dbAcc.tbUnmatchPayments.SingleOrDefault(unMatched => unMatched.TellerPaymentDetailID == Convert.ToInt32(TellerID));
            if (UP == null)
            {
                UP = new tbUnmatchPayment();
                dbAcc.tbUnmatchPayments.InsertOnSubmit(UP);
            }

            if (!string.IsNullOrEmpty(hdCauseID.Value))
                UP.CauseID = int.Parse(hdCauseID.Value);

            if (TellerID != 0)
                UP.TellerPaymentDetailID = TellerID;

            //CompCode
            if (!string.IsNullOrEmpty(txtCompCode.Text) && txtCompCode.Enabled == true)
                UP.CompCode = txtCompCode.Text;
            else
                UP.CompCode = null;

            //Amount
            if (!string.IsNullOrEmpty(txtAmount.Text) && txtAmount.Enabled == true)
                UP.Amount = Convert.ToDecimal(txtAmount.Text);
            else
                UP.Amount = null;

            //Ref 1
            if (!string.IsNullOrEmpty(txtRef1.Text) && txtRef1.Enabled == true)
                UP.Ref1 = txtRef1.Text;
            else
                UP.Ref1 = null;

            //ref 2
            if (!string.IsNullOrEmpty(txtRef2.Text) && txtRef2.Enabled == true)
                UP.Ref2 = txtRef2.Text;
            else
                UP.Ref2 = null;

            //Ref Name
            if (!string.IsNullOrEmpty(txtRefName.Text) && txtRefName.Enabled == true)
                UP.RefName = txtRefName.Text;
            else
                UP.RefName = null;

            //PayDate
            if (!string.IsNullOrEmpty(txtPaymentDate.TextDate) && txtPaymentDate.Visible == true)
                UP.PaymentDate = Convert.ToDateTime(txtPaymentDate.TextDate);
            else
                UP.PaymentDate = null;

            //DepNo
            if (!string.IsNullOrEmpty(txtDepNo.Text) && txtDepNo.Enabled == true)
                UP.DepNo = txtDepNo.Text;
            else
                UP.DepNo = null;

            //statusCode
            if (!string.IsNullOrEmpty(StatusCode))
                UP.StatusCode = StatusCode;

            if (Application["isEdit"] != null)
            {
                if (Application["isEdit"].ToString() == "2") //Approve
                {
                    UP.ApproveBy = Emp.USER_ID;
                    UP.ApproveDate = DateTime.Now;
                }
            }
            else //Insert
            {
                UP.BranchCode = Emp.BRANCH_NO;
                UP.CreateBy = Emp.USER_ID;
                UP.CreateDate = DateTime.Now;
            }
            UP.ModifiedBy = Emp.USER_ID;
            UP.ModifiedDate = DateTime.Now;

            dbAcc.SubmitChanges();
            //DataMNG.EditUnmatchpayment(UP);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('บันทึกเสร็จสิ้น');window.location.replace('" + urlPrev + "');", true);
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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect(urlPrev);
        }

    }
}