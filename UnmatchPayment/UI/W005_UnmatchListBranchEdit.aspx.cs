using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Class;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class W005_UnmatchListBranchEdit : System.Web.UI.Page
    {
        #region Property
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        C001_DataMng DataMNG = new C001_DataMng();
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
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var statusList = new string[] { "01" };
                DataTable dtUnmatch = new DataTable();
                var dtAcc = (from claim in dbAcc.tbUnmatchPayments
                             join cause in dbAcc.UnmatchCauses on claim.CauseID equals cause.CauseID
                             where claim.BranchCode == Emp.BRANCH_NO && statusList.Contains(claim.StatusCode)
                             select new {
                                 claim.TellerPaymentDetailID,
                                 claim.CompCode,
                                 claim.Amount,
                                 claim.Ref1,
                                 claim.Ref2,
                                 claim.RefName,
                                 claim.PaymentDate,
                                 cause.CauseDescription
                             }
                             ).OrderBy(x => x.TellerPaymentDetailID);

                dtUnmatch = DataMNG.LINQToDataTable(dtAcc);

                gvUnmatchList.DataSource = dtUnmatch;
                gvUnmatchList.DataBind();
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Empty;
                string _strTellerID = ((Button)sender).CommandArgument;
                Application["TellerID"] = _strTellerID;
                Application["isEdit"] = "1";

                Response.Redirect("W002_AddTransaction.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}