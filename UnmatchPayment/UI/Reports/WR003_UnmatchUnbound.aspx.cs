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

namespace UnmatchPayment.UI.Reports
{
    public partial class WR003_UnmatchUnbound : System.Web.UI.Page
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

        protected void LoadReport()
        {
            string _pathReport = Server.MapPath("~/Reports/R003_UnmatchUnbound.rpt");
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
            Response.AddHeader("content-disposition", "attachment; filename=" + "R003.pdf");
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
            Rel.Load(Server.MapPath("~/Reports/R003_UnmatchUnbound.rpt"));
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
    }
}