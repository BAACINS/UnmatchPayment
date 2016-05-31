using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnmatchPayment.Class;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class AddTransaction : System.Web.UI.Page
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        C001_DataMng DataMNG = new C001_DataMng();
        C002_GetDataDDL getDDL = new C002_GetDataDDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUnmatchCause();
                GetTellerpaymentDetail();
                GetFileType();
            }
        }

        private void GetUnmatchCause()
        {
            DataTable dtUnmatch = new DataTable();
            var dtAcc = from Cause in dbAcc.UnmatchCauses
                        select new { Cause.CauseID,Cause.CauseDescription };

            dtUnmatch = DataMNG.LINQToDataTable(dtAcc);

            StringBuilder strCause = new StringBuilder();

            for(int i = 0; i < dtUnmatch.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    strCause.Append(string.Format(@"
                    <div>
                    <span class='spanleft'>
                    <input type = 'radio' name='radio' id='radio{0}' class='radio' onclick='rdbChecked({0})'/>
                    <label for= 'radio{0}' > {1} </label>
                    </span>", dtUnmatch.Rows[i]["CauseID"].ToString(), dtUnmatch.Rows[i]["CauseDescription"].ToString()));
                }
                else
                {
                    strCause.Append(string.Format(@"
                    <span class='spanright'>
                    <input type = 'radio' name='radio' id='radio{0}' class='radio' onclick='rdbChecked({0})'/>
                    <label for= 'radio{0}' > {1} </label>
                    </span>
                    </div>", dtUnmatch.Rows[i]["CauseID"].ToString(), dtUnmatch.Rows[i]["CauseDescription"].ToString()));
                }
            }

            ltrbl.Text = strCause.ToString();
        }
        private void GetTellerpaymentDetail()
        {
            try
            {
                DateTimeFormatInfo fmt = (new CultureInfo("th-TH")).DateTimeFormat;
                if (Application["TellerID"] != null)
                {
                    int TellerID = int.Parse(Application["TellerID"].ToString());
                    var teller = (from tel in dbAcc.VW_TellerPaymentDetails
                                 where tel.TellerPaymentDetailID == TellerID
                                 select tel).FirstOrDefault();
                    lblCompCode.Text = teller.CompCode;
                    lblAmount.Text = teller.Amount.ToString();
                    lblRef1.Text = teller.Ref1;
                    lblRef2.Text = teller.Ref2;
                    lblRefName.Text = teller.CustomerName;
                    lblPaymentDate.Text = DateTime.Parse(teller.PaymentDateTime.ToString()).ToString("dd-MM-yyyy",fmt);
                }
            }
            catch
            {

            }
        }
        private void GetFileType()
        {
            ddlFileType.DataSource = getDDL.GetFileType();
            ddlFileType.DataTextField = "FileTypeName";
            ddlFileType.DataValueField = "FileTypeID";
            ddlFileType.DataBind();
        }

        protected void bntSave_Click(object sender, EventArgs e)
        {
            string _causeID = hdCauseID.Value;
        }
    }
}