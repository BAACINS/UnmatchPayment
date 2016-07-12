using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class Default : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            string strFileName = "UnmatchManual.pdf";
            string strSourceFile = string.Empty;
            if (Emp.isBranch == 0)
                strSourceFile = Server.MapPath("~/UserManual/ManualforHQ.pdf");
            else
                strSourceFile = Server.MapPath("~/UserManual/ManualforBranch.pdf");
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition",
                               "attachment; filename=" + strFileName + ";");
            response.TransmitFile(strSourceFile);
            response.Flush();
            response.End();
        }
    }
}