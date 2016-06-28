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
    public partial class W006_Approve : System.Web.UI.Page
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
            var statusList = new string[] { "01" };
            DataTable dtUnmatch = new DataTable();
            var dtAcc = (from claim in dbAcc.tbUnmatchPayments
                         join cause in dbAcc.UnmatchCauses on claim.CauseID equals cause.CauseID
                         where statusList.Contains(claim.StatusCode)
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

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Empty;
                string _strTellerID = ((Button)sender).CommandArgument;
                Application["TellerID"] = _strTellerID;
                Application["isEdit"] = "2";

                Response.Redirect("W002_AddTransaction.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvUnmatchList.Rows)
            {
                RadioButton rdbSPIN = (RadioButton)row.FindControl("rdbSPIN");
                RadioButton rdbGL = (RadioButton)row.FindControl("rdbGL");
                CheckBox cbApproved = (CheckBox)row.FindControl("chkApp");
                if (cbApproved != null)
                {
                    if (cbApproved.Checked.ToString().ToLower() == "true" && !(rdbGL.Enabled==true && rdbSPIN.Enabled==true && rdbGL.Checked==false && rdbSPIN.Checked==false))
                    {
                        string _strTellerID = row.Cells[0].Text;
                        
                        if (!string.IsNullOrEmpty(_strTellerID))
                        {
                            tbUnmatchPayment UP = new tbUnmatchPayment();

                            UP.TellerPaymentDetailID = Convert.ToInt32(_strTellerID);
                            UP.StatusCode = "02";
                            UP.ApproveBy = Emp.USER_ID;
                            UP.ApproveDate = DateTime.Now;
                            UP.ModifiedBy = Emp.USER_ID;
                            UP.ModifiedDate = DateTime.Now;
                            //check Return Type
                            if (rdbSPIN.Checked)
                                UP.ReturnTypeID = 1;
                            else if (rdbGL.Checked)
                                UP.ReturnTypeID = 2;
                            else
                                UP.ReturnTypeID = 0;

                            DataMNG.EditUnmatchpayment(UP);

                        }

                    }
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('อนุมัติเสร็จสิ้น');", true);
            GetdataClaim();
        }

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvUnmatchList.HeaderRow.FindControl("chkboxSelectAll");
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