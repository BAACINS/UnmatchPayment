using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Class;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class W009_CancleApprove : System.Web.UI.Page
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

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUnmatchCause();
                GetdataClaim();
            }
        }
        public bool CheckReturnDefault(object item1, object item2)
        {

            if (item1.ToString().ToLower() == "true" && item2.ToString().ToLower() == "false")
                return true;
            else
                return false;
        }

        private void GetdataClaim()
        {
            var statusList = new string[] { "02" };
            List<string> CauseList = hdListCause.Value.ToString().Split(',').ToList<string>();
            //var CauseList = new int[] { 1,2 };
            DataTable dtUnmatch = new DataTable();
            var dtAcc = (from claim in dbAcc.tbUnmatchPayments
                         join cause in dbAcc.UnmatchCauses on claim.CauseID equals cause.CauseID
                         where statusList.Contains(claim.StatusCode)
                         && CauseList.Contains(claim.CauseID.ToString())
                         //&& claim.ModifiedBy != Emp.USER_ID
                         select new
                         {
                             claim.TellerPaymentDetailID,
                             claim.CompCode,
                             claim.Amount,
                             claim.Ref1,
                             claim.Ref2,
                             claim.RefName,
                             claim.PaymentDate,
                             cause.CauseID,
                             cause.CauseDescription,
                             cause.isSpin,
                             cause.isGL
                         }
                         ).OrderBy(x => x.CauseID);

            dtUnmatch = DataMNG.LINQToDataTable(dtAcc);

            gvUnmatchList.DataSource = dtUnmatch;
            gvUnmatchList.DataBind();
            if (dtUnmatch.Rows.Count > 0)
            {
                btnApprove.Visible = true;
                lblDataNotFound.Visible = false;
            }
            else
            {
                btnApprove.Visible = false;
                lblDataNotFound.Visible = true;
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
            List<string> listCause = new List<string>();
            hdMaxCause.Value = dtUnmatchedCause.Rows.Count.ToString();
            for (int i = 0; i < dtUnmatchedCause.Rows.Count; i++)
            {


                string strCauseID = dtUnmatchedCause.Rows[i]["CauseID"].ToString();
                string strCauseDes = dtUnmatchedCause.Rows[i]["CauseDescription"].ToString();

                listCause.Add(strCauseID);
                if (i % 2 == 0)
                {
                    //add radio in literal
                    strCause.Append(string.Format(@"
                    <div>
                    <span class='spanleft'>
                    <input type = 'checkbox' name='radio{0}' id='radio{0}' class='radio' runat='server' onclick='rdbChecked({0})' />
                    <label for= 'radio{0}' > {1} </label>
                    </span>", strCauseID, strCauseDes));
                }
                else
                {
                    strCause.Append(string.Format(@"
                    <span class='spanright'>
                    <input type = 'checkbox' name='radio{0}' id='radio{0}' class='radio' runat='server' onclick='rdbChecked({0})' />
                    <label for= 'radio{0}' > {1} </label>
                    </span>
                    </div>", strCauseID, strCauseDes));
                }
            }
            hdListCause.Value = listCause.Aggregate((x, y) => x + "," + y);
            ltrbl.Text = strCause.ToString();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Empty;
                string _strTellerID = ((Button)sender).CommandArgument;
                Application["TellerID"] = _strTellerID;
                Application["isEdit"] = "01";

                Response.Redirect("W002_AddTransaction.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvUnmatchList.Rows)
            {
                CheckBox cbApproved = (CheckBox)row.FindControl("chkApp");
                if (cbApproved != null)
                {
                    string _strTellerID = row.Cells[0].Text;

                    if (!string.IsNullOrEmpty(_strTellerID) && cbApproved.Checked)
                    {
                        tbUnmatchPayment UP = dbAcc.tbUnmatchPayments.Single(unMatched => unMatched.TellerPaymentDetailID == Convert.ToInt32(_strTellerID));

                        UP.StatusCode = "01";
                        UP.ModifiedBy = Emp.USER_ID;
                        UP.ModifiedDate = DateTime.Now;

                        dbAcc.SubmitChanges();

                    }
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('ยกเลิกอนุมัติเสร็จสิ้น');", true);
            GetdataClaim();
        }

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvUnmatchList.HeaderRow.FindControl("chkboxSelectAll");
            bool a = ((CheckBox)sender).Checked;
            foreach (GridViewRow row in gvUnmatchList.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkApp");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetdataClaim();
        }
    }
}