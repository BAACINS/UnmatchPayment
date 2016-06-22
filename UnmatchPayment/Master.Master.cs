using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Class;
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
            C007_MenuMNG menu = new C007_MenuMNG();
            DataTable _dt;
            if (dtMenu == null)
                _dt = menu.GetAllAppMenuForMasterPage(UserLogin.ROLECODE);
            else
                _dt = dtMenu;
            StringBuilder strMenu = new StringBuilder();
            string strMenuUrl = Page.ResolveUrl("~/UI/Default.aspx");
            string strMenuDesc = "หน้าหลัก";
            strMenu.Append(string.Format("<li class= 'active'><a href='{0}'><span>{1}</span></a></li>", strMenuUrl, strMenuDesc));

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["MenuGroup"].ToString() == string.Empty) //menu
                {
                    int j = i - 1;
                    if (j < 0)
                        j = 0;
                    //if previos is submenu
                    if (_dt.Rows[j]["MenuGroup"].ToString() != string.Empty && j > 0)
                    {
                        strMenu.Append("</ul></li>");
                    }
                    strMenuUrl = Page.ResolveClientUrl(_dt.Rows[i]["MenuUrl"].ToString());
                    strMenuDesc = _dt.Rows[i]["MenuDesc"].ToString();
                    strMenu.Append(string.Format("</li><li><a href='{0}'><span>{1}</span></a>", strMenuUrl, strMenuDesc));
                    if (_dt.Rows[i]["MenuUrl"].ToString() == string.Empty) //is head menu
                    {
                        strMenu.Append("<ul>");
                    }
                    else //is sub menu
                    {
                        strMenu.Append("</li>");
                    }
                }
                else //sub menu
                {
                    strMenuUrl = Page.ResolveClientUrl(_dt.Rows[i]["MenuUrl"].ToString());
                    strMenuDesc = _dt.Rows[i]["MenuDesc"].ToString();
                    strMenu.Append(string.Format("<li><a href='{0}'><span>{1}</span></a></li>", strMenuUrl, strMenuDesc));
                }
            }
            if (_dt.Rows.Count > 1)
            {
                //if(_dt.Rows[_dt.Rows.Count-2]["MenuGroup"].ToString() != string.Empty)
                //    strMenu.Append("</li>");

                if (_dt.Rows[_dt.Rows.Count - 1]["MenuGroup"].ToString() == string.Empty)
                {
                    strMenu.Append("</li>");
                }
                else
                    strMenu.Append("</ul></li>");
            }


            string strLogoutMenu = Page.ResolveUrl("~/Login.aspx");
            strMenu.Append(string.Format("<li class='last'><a href='{0}'><span>ออกจากระบบ</span></a></li></ul>", strLogoutMenu));
            this.ltMenu.Text = strMenu.ToString();

        }
    }
}