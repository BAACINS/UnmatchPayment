﻿using System;
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
    public partial class AddTransaction : System.Web.UI.Page
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        C001_DataMng DataMNG = new C001_DataMng();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetUnmatchCause();
            }
        }

        private void GetUnmatchCause()
        {
            DataTable dtUnmatch = new DataTable();
            var dtAcc = from Cause in dbAcc.UnmatchCauses
                        select Cause;

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

        protected void bntSave_Click(object sender, EventArgs e)
        {
            string a = hdCauseID.Value;
        }
    }
}