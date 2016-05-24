using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class AddTransaction : System.Web.UI.Page
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetUnmatchCause()
        {

        }
    }
}