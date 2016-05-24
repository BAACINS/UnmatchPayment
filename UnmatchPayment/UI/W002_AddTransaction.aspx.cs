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
    public partial class AddTransaction : System.Web.UI.Page
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        C001_DataMng DataMNG = new C001_DataMng();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.GetUnmatchCause();
                ltrbl.Text = @"
<div>
<input type=""radio"" name=""radio"" id=""radio1"" class=""radio"" checked/>
<label for= ""radio1"" > First Option </label>
 </div>

 ";
            }
        }

        private void GetUnmatchCause()
        {
            DataTable dtUnmatch = new DataTable();
            var dtAcc = from Cause in dbAcc.UnmatchCauses
                        select Cause;

            dtUnmatch = DataMNG.LINQToDataTable(dtAcc);

            rdbUnmatchCause.DataSource = dtUnmatch;
            rdbUnmatchCause.DataTextField = "CauseDescription";
            rdbUnmatchCause.DataValueField = "CauseID";
            rdbUnmatchCause.DataBind();
        }
    }
}