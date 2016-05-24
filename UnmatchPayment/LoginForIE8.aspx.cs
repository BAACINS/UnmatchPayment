using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;

namespace UnmatchPayment
{
    public partial class LoginForIE8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            dbAccountDataContext dbAcc = new dbAccountDataContext();

            string user = txtUserName.Text;
            string pass = txtPassword.Text;
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblLoginError.Text = "โปรดระบุรหัสพนักงาน และ รหัสผ่าน";
                return;
            }

            var dtAcc = from Acc in dbAcc.EMPLOYEE_SELECT(user, pass)
                        select Acc;
            EMPLOYEE_SELECTResult Emp = new EMPLOYEE_SELECTResult();
            foreach (EMPLOYEE_SELECTResult tmpEmp in dtAcc)
            {
                Emp.USER_ID = tmpEmp.USER_ID;
                Emp.USER_NAME = tmpEmp.USER_NAME;
                Emp.USER_ID = tmpEmp.USER_ID;
                Emp.USER_NAME = tmpEmp.USER_NAME;
                Emp.POSITIONNAME = tmpEmp.POSITIONNAME;
                Emp.ROLECODE = tmpEmp.ROLECODE;
                Emp.ROLENAME = tmpEmp.ROLENAME;
                Emp.BRANCH_NO = tmpEmp.BRANCH_NO;
                Emp.BRANCH_NAME = tmpEmp.BRANCH_NAME;
                Emp.PROVINCE_NO = tmpEmp.PROVINCE_NO;
                Emp.PROVINCE_NAME = tmpEmp.PROVINCE_NAME;
                Emp.REGION_NO = tmpEmp.REGION_NO;
                Emp.REGION_NAME = tmpEmp.REGION_NAME;
                Emp.isBranch = tmpEmp.isBranch;
            }

            if (Emp.USER_ID != null)
            {
                Session["Emp"] = Emp;
                lblLoginError.Text = "";
                Response.Redirect("UI/Default.aspx");

            }
            else
            {
                lblLoginError.Text = "รหัสพนักงาน หรือ รหัสผ่านไม่ถูกต้อง";
                //((Label)Login1.FindControl("lblLoginStatus")).Text = "รหัสพนักงาน หรือ รหัสผ่านไม่ถูกต้อง";
            }
        }
    }
}