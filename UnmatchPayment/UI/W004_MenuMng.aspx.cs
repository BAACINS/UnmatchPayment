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
    public partial class MenuMng : System.Web.UI.Page
    {
        //private EMPLOYEE_SELECTResult UserLogin
        //{
        //    get
        //    {
        //        if (Session["Emp"] == null)
        //        {
        //            Session["Emp"] = null;
        //        }
        //        return (EMPLOYEE_SELECTResult)Session["Emp"];
        //    }
        //    set
        //    {
        //        Session["Emp"] = value;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.GetAllAppMenu();
                    this.GetMenuGroup();
                }
            }
            catch
            { }
        }
        protected void GetAllAppMenu()
        {
            try
            {
                C002_GetDataDDL dtGetAppMenu = new C002_GetDataDDL();

                DataTable _dt = new DataTable();
                _dt = dtGetAppMenu.GetAllAppMenu("0");
                
                this.gvAllAppMenu.DataSource = _dt;
                this.gvAllAppMenu.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void bntAddMenu_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.ModalPopupForm.Show();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.ModalPopupForm.Show();
            C002_GetDataDDL MenuMng = new C002_GetDataDDL();
            DataTable _dt = new DataTable();
            try
            {
                string _strMenuNo = ((Button)sender).CommandArgument;
                _dt = MenuMng.GetAllAppMenu(_strMenuNo);
                this.txtMenuCode.Text = _dt.Rows[0]["MenuNo"].ToString();
                this.hdMenuCode.Value = _dt.Rows[0]["MenuNo"].ToString();
                this.txtMenuName.Text = _dt.Rows[0]["MenuDesc"].ToString();
                this.txtMenuSeq.Text = _dt.Rows[0]["MenuSeq"].ToString();
                this.txtMenuUrl.Text = _dt.Rows[0]["MenuUrl"].ToString();
                this.ddlMenuGroup.SelectedValue = _dt.Rows[0]["MenuGroup"].ToString();
                this.chbMenuShow.Checked = (bool)_dt.Rows[0]["MenuShow"];

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            C002_GetDataDDL MenuMng = new C002_GetDataDDL();
            dbAccountDataContext dbAcc = new dbAccountDataContext();
            DataTable _dt = new DataTable();
            try
            {
                string _strMenuNo = ((Button)sender).CommandArgument;
                MenuMng.DeleteAppMenu(_strMenuNo);

                var query = (from tb in dbAcc.AppMenus
                             where tb.MenuNo == Convert.ToInt16(_strMenuNo)
                             select tb).DefaultIfEmpty().ToList();
                if (query[0] == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('ลบข้อมูลเรียบร้อย');", true);
                    this.GetAllAppMenu();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            C002_GetDataDDL MenuMng = new C002_GetDataDDL();
            dbAccountDataContext dbAcc = new dbAccountDataContext();
            try
            {

                string menuNo = txtMenuCode.Text;
                string menuName = txtMenuName.Text;
                string menuSeq = txtMenuSeq.Text;
                string menuUrl = txtMenuUrl.Text;

                //string createBy = UserLogin.USER_ID;
                string createBy = "5601155";

                string menuGroup = ddlMenuGroup.SelectedValue;
                bool menuShow = chbMenuShow.Checked;
                DataTable _dtCheckDuplicate = new DataTable();
                _dtCheckDuplicate = MenuMng.CheckDuplicate(menuNo);

                if (_dtCheckDuplicate.Rows.Count > 0)
                {
                    if (_dtCheckDuplicate.Rows[0]["MenuNo"].ToString() != hdMenuCode.Value)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('รหัสเมนูซ้ำ ไม่สามารถบันทึกได้');", true);
                    }
                    else
                    {


                        if (Convert.ToInt32(menuNo) == MenuMng.UpdateAppMenu(menuNo, hdMenuCode.Value, menuSeq, menuName, menuUrl, createBy, menuGroup, menuShow)) ;
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('บันทึกข้อมูลเรียบร้อย');", true);
                            ClearForm();
                            this.GetAllAppMenu();
                        }
                    }


                }
                else
                {


                    if (Convert.ToInt32(menuNo) == MenuMng.InsertAppMenu(menuNo, menuSeq, menuName, menuUrl, createBy, menuGroup, menuShow)) ;
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('บันทึกข้อมูลเรียบร้อย');", true);
                        ClearForm();
                        this.GetAllAppMenu();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void GetMenuGroup()
        {
            C002_GetDataDDL Getddl = new C002_GetDataDDL();
            //C001_GetdataDDL Getddl = new C001_GetDataDDL();
            ddlMenuGroup.DataSource = Getddl.GetMenuGroup();
            ddlMenuGroup.DataTextField = "MenuDesc";
            ddlMenuGroup.DataValueField = "MenuNo";

            ddlMenuGroup.DataBind();
        }

        private void ClearForm()
        {
            this.txtMenuCode.Text = string.Empty;
            this.txtMenuName.Text = string.Empty;
            this.txtMenuSeq.Text = string.Empty;
            this.txtMenuUrl.Text = string.Empty;
            this.ddlMenuGroup.SelectedIndex = 0;
            this.chbMenuShow.Checked = false;
            this.hdMenuCode.Value = "";
        }
    }
}