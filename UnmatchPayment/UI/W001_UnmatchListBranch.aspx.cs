﻿using System;
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
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        DataMng DataMNG = new DataMng();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtUnmatch = new DataTable();
                var dtAcc = from claim in dbAcc.VW_TellerPaymentDetails
                            where claim.BranchCode == "0413" && claim.MatchingID == null
                            select claim;

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
                //Application["CID"] = strCID;
                //Application["StatusCode"] = "02"; //01 insert,02 Update
                //Application["Type"] = "02"; //01 CanEdit,02 ReadOnly
                //if (_strCanEdit == "Edit")
                //    Application["type"] = "01";
                Response.Redirect("W002_AddTransaction.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}