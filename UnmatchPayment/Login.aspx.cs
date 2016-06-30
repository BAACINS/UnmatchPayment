using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;

namespace UnmatchPayment
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((Request.Browser.Browser.ToLower() == "ie" || Request.Browser.Browser.ToLower() == "internetexplorer") && (Request.Browser.MajorVersion < 10))
                    Response.Redirect("LoginForIE8.aspx");
            }
            catch
            {
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            dbAccountDataContext dbAcc = new dbAccountDataContext();
            //string user = Request.Form["username"]; //((TextBox).FindControl("UserName")).Text;
            //string pass = Request.Form["password"];//((TextBox)Login1.FindControl("Password")).Text;

            string user = String.Format("{0}", this.Request.Form["username"]);
            string pass = String.Format("{0}", this.Request.Form["password"]);
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblloginError.Text = "โปรดระบุรหัสพนักงาน และ รหัสผ่าน";
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
                Emp.BRANCH_NO = ("0000" + tmpEmp.BRANCH_NO).Substring(tmpEmp.BRANCH_NO.Length);
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
                lblloginError.Text = "";
                Thread.Sleep(1500);
                Response.Redirect("UI/Default.aspx");
            }
            else
            {
                lblloginError.Text = "รหัสพนักงาน หรือ รหัสผ่านไม่ถูกต้อง";
            }
        }

        public static string CheckLogin(string userName, string passWord)
        {
            return "";
        }
    }
}