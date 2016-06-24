using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Class;

namespace UnmatchPayment.UI
{
    public partial class Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUnmatchCause();
        }

        protected void GetUnmatchCause()
        {
            try
            {
                C001_DataMng dtGetUnmatchCause = new C001_DataMng();

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
    }
}