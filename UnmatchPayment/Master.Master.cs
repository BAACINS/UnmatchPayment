using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;

namespace UnmatchPayment
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private EMPLOYEE_SELECTResult UserLogin
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

        private DataTable dtMenu
        {
            get
            {
                return (DataTable)ViewState["appMenu"];
            }
            set
            {
                ViewState["appMenu"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Emp"] != null)
                    {

                        if (UserLogin != null)
                        {
                            this.lblUserID.Text = "รหัสพนักงาน: " + UserLogin.USER_ID;
                            this.lblUserName.Text = "ชื่อ-สกุล: " + UserLogin.USER_NAME;
                            this.lblBranch.Text = "สาขา: " + UserLogin.BRANCH_NO + "-" + UserLogin.BRANCH_NAME;

                            this.GenerateMenu();
                        }
                    }
                }
                if (Session["Emp"] == null)
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }

            catch { }
        }

        private void GenerateMenu()
        {

        }
    }
}