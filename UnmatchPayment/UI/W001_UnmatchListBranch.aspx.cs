using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class UnmatchListBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dbAccountDataContext dbAcc = new dbAccountDataContext();
            DataTable dtUnmatch = new DataTable();
            dtUnmatch = dbAcc.VW_TellerPaymentDetails.FirstOrDefault();
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Empty;
                string _strClaimID = ((Button)sender).CommandArgument;
                string _strCanEdit = ((Button)sender).CommandName;
                //Application["TVSID"] = _strClaimID;
                //Application["CID"] = strCID;
                //Application["StatusCode"] = "02"; //01 insert,02 Update
                //Application["Type"] = "02"; //01 CanEdit,02 ReadOnly
                //if (_strCanEdit == "Edit")
                //    Application["type"] = "01";
                //Response.Redirect("W001_AddClaim.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}