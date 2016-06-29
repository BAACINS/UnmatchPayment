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
    public partial class Config : System.Web.UI.Page
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        C001_DataMng dtGetUnmatchCause = new C001_DataMng();
        UnmatchCause newCause = new UnmatchCause();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               GetUnmatchCause();
            }
            
        }

        protected void GetUnmatchCause()
        {
            try
            {
                DataTable _dt = new DataTable();
                _dt = dtGetUnmatchCause.GetCauseConfig();

                this.gvCause.DataSource = _dt;
                this.gvCause.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ClearForm()
        {
            ((TextBox)gvCause.FooterRow.FindControl("NewCauseDescription")).Text = string.Empty;
            ((CheckBox)gvCause.FooterRow.FindControl("NewCompCode")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewAmount")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewRef1")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewRef2")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewRefName")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewPaymentdate")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewRefund")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewUploadFile")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewSpin")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewGL")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewUnmatch")).Checked = false;
            ((CheckBox)gvCause.FooterRow.FindControl("NewActive")).Checked = false;

        }

        protected void btnAddCause_Click(object sender, EventArgs e)
        {
            TextBox txtCauseName = (TextBox)gvCause.FooterRow.FindControl("NewCauseDescription");
            newCause.CauseDescription = txtCauseName.Text;
            CheckBox NewCompCode = (CheckBox)gvCause.FooterRow.FindControl("NewCompCode");
            newCause.isCompCode = NewCompCode.Checked;
            CheckBox NewAmount = (CheckBox)gvCause.FooterRow.FindControl("NewAmount");
            newCause.isAmount = NewAmount.Checked;
            CheckBox NewRef1 = (CheckBox)gvCause.FooterRow.FindControl("NewRef1");
            newCause.isRef1 = NewRef1.Checked;
            CheckBox NewRef2 = (CheckBox)gvCause.FooterRow.FindControl("NewRef2");
            newCause.isRef2 = NewRef2.Checked;
            CheckBox NewRefName = (CheckBox)gvCause.FooterRow.FindControl("NewRefName");
            newCause.isRefName = NewRefName.Checked;
            CheckBox NewPaymentdate = (CheckBox)gvCause.FooterRow.FindControl("NewPaymentdate");
            newCause.isPaymentdate = NewPaymentdate.Checked;
            CheckBox NewRefund = (CheckBox)gvCause.FooterRow.FindControl("NewRefund");
            newCause.isRefund = NewRefund.Checked;
            CheckBox NewUploadFile = (CheckBox)gvCause.FooterRow.FindControl("NewUploadFile");
            newCause.isUploadFile = NewUploadFile.Checked;
            CheckBox NewSpin = (CheckBox)gvCause.FooterRow.FindControl("NewSpin");
            newCause.isSpin = NewSpin.Checked;
            CheckBox NewGL = (CheckBox)gvCause.FooterRow.FindControl("NewGL");
            newCause.isGL = NewGL.Checked;
            CheckBox NewUnmatch = (CheckBox)gvCause.FooterRow.FindControl("NewUnmatch");
            newCause.isUpdateUnmatched = NewUnmatch.Checked;
            CheckBox NewActive = (CheckBox)gvCause.FooterRow.FindControl("NewActive");
            newCause.isActive = NewActive.Checked;

            dbAcc.UnmatchCauses.InsertOnSubmit(newCause);
            dbAcc.SubmitChanges();
            gvCause.DataSource = dtGetUnmatchCause.GetCauseConfig();
            gvCause.DataBind();

            ClearForm();

        }

        protected void btnDeleteCause_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            var strCauseID = btn.CommandArgument;
            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isActive = false;
            dbAcc.SubmitChanges();

            gvCause.DataSource = dtGetUnmatchCause.GetCauseConfig();
            gvCause.DataBind();
        }

        protected void chkCompCode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb  = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isCompCode = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkAmount_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isAmount = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkRef1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isRef1 = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkRef2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isRef2 = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkRefName_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isRefName = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkPaymentdate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isPaymentdate = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkRefund_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isRefund = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkUploadFile_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isUploadFile = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkSpin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isSpin = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkGL_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isGL = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkUnmatch_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isUpdateUnmatched = cb.Checked;
            dbAcc.SubmitChanges();
        }

        protected void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = ((CheckBox)sender);
            var strCauseID = cb.Attributes["CommandArgument"];

            UnmatchCause a = dbAcc.UnmatchCauses.Single(cause => cause.CauseID == Convert.ToInt32(strCauseID));
            a.isActive = cb.Checked;
            dbAcc.SubmitChanges();
        }
    }
}