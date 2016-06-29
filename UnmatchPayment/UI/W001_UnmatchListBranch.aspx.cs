using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;
using UnmatchPayment.Class;

namespace UnmatchPayment.UI
{
    public partial class UnmatchListBranch : System.Web.UI.Page
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
                DataTable dtUnmatch = new DataTable();
                var dtAcc = (from claim in dbAcc.VW_TellerPaymentDetailBranches
                            where claim.BranchCode == Emp.BRANCH_NO
                            && claim.MatchingID == null
                            && !(from up in dbAcc.tbUnmatchPayments select up.TellerPaymentDetailID).Contains(Convert.ToInt32(claim.TellerPaymentDetailID))
                            select claim).OrderBy(x => x.TellerPaymentDetailID);

                dtUnmatch = DataMNG.LINQToDataTable(dtAcc);

                gvUnmatchList.DataSource = dtUnmatch;
                gvUnmatchList.DataBind();
                if (dtUnmatch.Rows.Count > 0)
                    lblDataNotFound.Visible = false;
                else
                    lblDataNotFound.Visible = true;
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Empty;
                string _strTellerID = ((Button)sender).CommandArgument;
                Application["TellerID"] = _strTellerID;
                Application["isEdit"] = null;

                Response.Redirect("W002_AddTransaction.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}