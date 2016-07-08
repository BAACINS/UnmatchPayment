using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Class;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class WR001_AddEditPayment : System.Web.UI.Page
    {
        CultureInfo us = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        CultureInfo th = System.Globalization.CultureInfo.GetCultureInfo("th-TH");
        C005_Calculator calculator = new C005_Calculator();
        C002_GetDataDDL GetData = new C002_GetDataDDL();

        private EMPLOYEE_SELECTResult UserLogin
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetRegion();

                if (UserLogin.isBranch == 1)
                {
                    ddlRegion.SelectedValue = UserLogin.REGION_NO;
                    ddlRegion.Enabled = false;
                    this.GetProvince();
                    ddlProvince.SelectedValue = UserLogin.PROVINCE_NO;
                    ddlProvince.Enabled = false;
                    this.GetBranch();
                    ddlBranch.SelectedValue = ("0000" + UserLogin.BRANCH_NO).Substring(UserLogin.BRANCH_NO.Length);
                    ddlBranch.Enabled = false;
                    GetUserDDL();
                    GetStatus();
                    GetCause();
                    GetReturnType();
                }
                else
                {
                    GetProvince();
                    GetCause();
                    GetStatus();
                    GetBranch();
                    GetUserDDL();
                    GetReturnType();
                }
            }
        }

        #region METHOD
        private void GetRegion()
        {
            ddlRegion.DataSource = GetData.GetRegion();
            ddlRegion.DataTextField = "REGION_NAME";
            ddlRegion.DataValueField = "REGION_NO";
            ddlRegion.DataBind();

        }

        private void GetProvince()
        {
            ddlProvince.DataSource = GetData.GetProvince(ddlRegion.SelectedValue);
            ddlProvince.DataTextField = "PROVINCE_NAME";
            ddlProvince.DataValueField = "PROVINCE_NO";
            ddlProvince.DataBind();
        }

        private void GetBranch()
        {
            ddlBranch.DataSource = GetData.GetBranch(ddlRegion.SelectedValue, ddlProvince.SelectedValue);
            ddlBranch.DataTextField = "BRANCH_NAME";
            ddlBranch.DataValueField = "BRANCH_NO";
            ddlBranch.DataBind();
        }

        private void GetUserDDL()
        {
            ddlUserID.DataSource = GetData.GetDDLByRoleCode(UserLogin.ROLECODE.ToString(), UserLogin.BRANCH_NO.ToString());
            ddlUserID.DataTextField = "USERFULLNAME";
            ddlUserID.DataValueField = "USERID";
            ddlUserID.DataBind();
        }

        private void GetCause()
        {
            ddlCause.DataSource = GetData.GetCause();
            ddlCause.DataTextField = "CAUSEDESCRIPTION";
            ddlCause.DataValueField = "CAUSEID";
            ddlCause.DataBind();
        }

        private void GetStatus()
        {
            ddlStatus.DataSource = GetData.GetStatus(UserLogin.isBranch.ToString());
            ddlStatus.DataTextField = "STATUSNAME";
            ddlStatus.DataValueField = "STATUSCODE";
            ddlStatus.DataBind();
        }

        private void GetReturnType()
        {
            ddlReturnType.DataSource = GetData.GetReturnType();
            ddlReturnType.DataTextField = "RETURNTYPENAME";
            ddlReturnType.DataValueField = "RETURNTYPEID";
            ddlReturnType.DataBind();
        }

        protected void LoadReport()
        {
            string _pathReport = Server.MapPath("~/Reports/R001_AddEditPayment.rpt");
            ReportDocument rpt = new ReportDocument();
            rpt.Load(_pathReport);
            C003_ReportLogin _login = new C003_ReportLogin(rpt, C004_DatabaseInfo.Instance);

            string DateFrom = string.Empty;
            string DateTo = string.Empty;
            DateFrom = calculator.SetFormatdate(txtDateFrom.TextDate.ToString(), 0).ToString("yyyy-MM-dd");
            DateTo = calculator.SetFormatdate(txtDateTo.TextDate.ToString(), 0).ToString("yyyy-MM-dd");

            rpt.SetParameterValue("@REGION_NO", ddlRegion.SelectedValue);
            rpt.SetParameterValue("@PROVINCE_NO", ddlProvince.SelectedValue);
            rpt.SetParameterValue("@BRANCH_NO", ddlBranch.SelectedValue);
            rpt.SetParameterValue("@INPUT_DATE_FROM", DateFrom);
            rpt.SetParameterValue("@INPUT_DATE_TO", DateTo);
            rpt.SetParameterValue("@INPUT_CAUSE", ddlCause.SelectedValue);
            rpt.SetParameterValue("@STATUS_NO", ddlStatus.SelectedValue);
            rpt.SetParameterValue("@INPUT_RETURNTYPE", ddlReturnType.SelectedValue);
            rpt.SetParameterValue("@USERID", ddlUserID.SelectedValue);

            rpt.Load(_pathReport);
            if (rpt.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('ไม่พบข้อมูล');", true);
                return;
            }
            BinaryReader stream = new BinaryReader(rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=" + "R001.pdf");
            Response.AddHeader("content-length", stream.BaseStream.Length.ToString());
            Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            Response.Flush();
            Response.Close();
            rpt.Close();
            rpt.Dispose();

        }

        private void OpenPDF(string downloadAsFilename)
        {
            ReportDocument Rel = new ReportDocument();
            Rel.Load(Server.MapPath("~/Reports/R001_AddEditClaim.rpt"));
            BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=" + downloadAsFilename);
            Response.AddHeader("content-length", stream.BaseStream.Length.ToString());
            Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            Response.Flush();
            Response.Close();
        }
        #endregion

        #region EVENTS

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            LoadReport();

        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBranch();
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProvince();
            GetBranch();
        }

        #endregion

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedValue.ToString() != "01") //สาขาเลือกรายงานที่มีสถานะอนุมัติ
            {
                ddlReturnType.Enabled = true;
                ddlReturnType.BackColor = System.Drawing.ColorTranslator.FromHtml("#f8f8f8");
                ddlUserID.Enabled = false;
                ddlUserID.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddddd");

            }
            else
            {
                ddlReturnType.Enabled = false;
                ddlReturnType.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddddd");
                ddlUserID.Enabled = true;
                ddlUserID.BackColor = System.Drawing.ColorTranslator.FromHtml("#f8f8f8");
            }
        }
    }
}