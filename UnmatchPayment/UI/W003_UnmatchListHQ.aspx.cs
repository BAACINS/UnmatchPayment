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
    public partial class W003_UnmatchListHQ : System.Web.UI.Page
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
        private DataTable dtUnmatch
        {
            get
            {
                DataTable dt = new DataTable();
                if ((DataTable)Session["dtUnmatchListHQ"] != null)
                    dt = (DataTable)Session["dtUnmatchListHQ"];
                return dt;
            }
            set
            {
                Session["dtUnmatchListHQ"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable _dtUnmatch = new DataTable();
                var dtAcc = (from claim in dbAcc.VW_TellerPaymentDetailHQs
                             where claim.MatchingID == null
                             && !(from up in dbAcc.tbUnmatchPayments select up.TellerPaymentDetailID).Contains(Convert.ToInt32(claim.TellerPaymentDetailID))
                             select claim).OrderBy(x => x.TellerPaymentDetailID);

                dtUnmatch = DataMNG.LINQToDataTable(dtAcc);
                //dtUnmatch = _dtUnmatch;

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

        protected void gvUnmatchList_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUnmatchList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //FillGrid();
            gvUnmatchList.DataSource = dtUnmatch;
            gvUnmatchList.PageIndex = e.NewPageIndex;
            gvUnmatchList.DataBind();
        }
    }
}