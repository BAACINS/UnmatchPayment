using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnmatchPayment.Database;

namespace UnmatchPayment.UI
{
    public partial class RoleMenu : System.Web.UI.Page
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
        private DataTable dtLstLeftMenu
        {
            get
            {
                if (ViewState["dtLstLeftMenu"] == null)
                {
                    ViewState["dtLstLeftMenu"] = new DataTable();
                    DataTable _dt = new DataTable();
                    _dt.Columns.Add("menu_desc");
                    _dt.Columns.Add("menu_no");

                    ViewState["dtLstLeftMenu"] = _dt;
                }
                return (DataTable)ViewState["dtLstLeftMenu"];
            }
            set
            {
                ViewState["dtLstLeftMenu"] = value;
            }
        }

        private DataTable dtLstRightMenu
        {
            get
            {
                if (ViewState["dtLstRightMenu"] == null)
                {
                    ViewState["dtLstRightMenu"] = new DataTable();
                    DataTable _dt = new DataTable();
                    _dt.Columns.Add("menu_desc");
                    _dt.Columns.Add("menu_no");

                    ViewState["dtLstRightMenu"] = _dt;
                }
                return (DataTable)ViewState["dtLstRightMenu"];
            }
            set
            {
                ViewState["dtLstRightMenu"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetUserRole();
                this.GetAllAppMenu();
            }
        }
        private void GetUserRole()
        {
            //dbAccountDataContext dbAcc = new dbAccountDataContext();
            //var dtAcc = (from a in dbAcc.USERROLE_SELECT()
            //             select a).DefaultIfEmpty().ToList();

            //if (dtAcc[0] != null)
            //{
            //    //C009_GetdataDDL Getddl = new C009_GetdataDDL();
            //    ddlRole.DataSource = dtAcc;
            //    ddlRole.DataTextField = "ROLENAME";
            //    ddlRole.DataValueField = "ROLECODE";
            //    ddlRole.DataBind();
            //}
        }
        protected void GetAllAppMenu()
        {
            try
            {
                //dbAccountDataContext dbAcc = new dbAccountDataContext();

                //var dtAcc_left = (from appmenu in dbAcc.AppMenus
                //                  where !(from appmenuaccess in dbAcc.AppMenuAccesses
                //                          where appmenuaccess.UserRole == ddlRole.SelectedValue.ToString()
                //                          select appmenuaccess.MenuNo).Contains(appmenu.MenuNo)
                //                  select appmenu).DefaultIfEmpty().ToList();


                //var dtAcc_Right = (from appmenu in dbAcc.AppMenus
                //                   join appmenuaccress in dbAcc.AppMenuAccesses on appmenu.MenuNo equals appmenuaccress.MenuNo
                //                   where appmenuaccress.UserRole == ddlRole.SelectedValue
                //                   select appmenu).DefaultIfEmpty().ToList();

                //dtLstLeftMenu.Rows.Clear();
                //if (dtAcc_left[0] != null)
                //{

                //    foreach (var q in dtAcc_left)
                //    {
                //        DataRow drLeftMenu = dtLstLeftMenu.NewRow();
                //        drLeftMenu["menu_desc"] = q.MenuDesc.ToString();
                //        drLeftMenu["menu_no"] = q.MenuNo.ToString();
                //        dtLstLeftMenu.Rows.Add(drLeftMenu);
                //    }
                //}
                //this.lstLeftRoleMenu.DataSource = dtLstLeftMenu;
                //lstLeftRoleMenu.DataTextField = "menu_desc";
                //lstLeftRoleMenu.DataValueField = "menu_no";
                //this.lstLeftRoleMenu.DataBind();

                //dtLstRightMenu.Rows.Clear();
                //if (dtAcc_Right[0] != null)
                //{


                //    foreach (var q in dtAcc_Right)
                //    {
                //        DataRow drRightMenu = dtLstRightMenu.NewRow();
                //        drRightMenu["menu_desc"] = q.MenuDesc.ToString();
                //        drRightMenu["menu_no"] = q.MenuNo.ToString();
                //        dtLstRightMenu.Rows.Add(drRightMenu);
                //    }
                //}
                //this.lstRightRoleMenu.DataSource = dtLstRightMenu;
                //lstRightRoleMenu.DataTextField = "menu_desc";
                //lstRightRoleMenu.DataValueField = "menu_no";
                //this.lstRightRoleMenu.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //dbAccountDataContext dbAcc = new dbAccountDataContext();
            //string menuNo = string.Empty;
            //string userRole = string.Empty;
            //string createBy = string.Empty;
            //DateTime datenow = DateTime.Now;
            //var queryrole = (from q in dbAcc.AppMenuAccesses
            //                 where q.UserRole == ddlRole.SelectedValue
            //                 select q).DefaultIfEmpty();

            //foreach (var q in queryrole)
            //{
            //    if (q != null)
            //    {
            //        dbAcc.AppMenuAccesses.DeleteOnSubmit(q);
            //        dbAcc.SubmitChanges();
            //    }
            //}

            //for (int i = 0; i < dtLstRightMenu.Rows.Count; i++)
            //{
            //    menuNo = dtLstRightMenu.Rows[i]["menu_no"].ToString();
            //    userRole = ddlRole.SelectedValue;
            //    createBy = UserLogin.USER_ID;
            //    AppMenuAccess obj = new AppMenuAccess
            //    {
            //        MenuNo = Convert.ToInt16(menuNo),
            //        UserRole = userRole,
            //        CreateDate = datenow,
            //        CreateBy = createBy
            //    };
            //    dbAcc.AppMenuAccesses.InsertOnSubmit(obj);
            //    dbAcc.SubmitChanges();

        }

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "js", "alert('บันทึกข้อมูลเรียบร้อย');", true);
    


        protected void bntAllRight_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtLstLeftMenu.Rows.Count; i++)
            {
                DataRow _dr = dtLstRightMenu.NewRow();
                _dr["menu_no"] = dtLstLeftMenu.Rows[i]["menu_no"];
                _dr["menu_desc"] = dtLstLeftMenu.Rows[i]["menu_desc"];
                dtLstRightMenu.Rows.Add(_dr);
            }

            dtLstLeftMenu.Rows.Clear();

            this.lstRightRoleMenu.DataSource = dtLstRightMenu;
            lstRightRoleMenu.DataTextField = "menu_desc";
            lstRightRoleMenu.DataValueField = "menu_no";
            this.lstRightRoleMenu.DataBind();

            this.lstLeftRoleMenu.DataSource = dtLstLeftMenu;
            lstLeftRoleMenu.DataTextField = "menu_desc";
            lstLeftRoleMenu.DataValueField = "menu_no";
            this.lstLeftRoleMenu.DataBind();

        }
        protected void bntRight_Click(object sender, EventArgs e)
        {
            if (lstLeftRoleMenu.SelectedIndex == -1)
            {
                return;
            }

            DataRow _dr = dtLstRightMenu.NewRow();
            _dr["menu_no"] = lstLeftRoleMenu.SelectedValue;
            _dr["menu_desc"] = lstLeftRoleMenu.SelectedItem;
            dtLstRightMenu.Rows.Add(_dr);
            dtLstLeftMenu.Rows.RemoveAt(lstLeftRoleMenu.SelectedIndex);

            this.lstRightRoleMenu.DataSource = dtLstRightMenu;
            lstRightRoleMenu.DataTextField = "menu_desc";
            lstRightRoleMenu.DataValueField = "menu_no";
            this.lstRightRoleMenu.DataBind();

            this.lstLeftRoleMenu.DataSource = dtLstLeftMenu;
            lstLeftRoleMenu.DataTextField = "menu_desc";
            lstLeftRoleMenu.DataValueField = "menu_no";
            this.lstLeftRoleMenu.DataBind();

        }
        protected void btnAllLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtLstRightMenu.Rows.Count; i++)
            {
                DataRow _dr = dtLstLeftMenu.NewRow();
                _dr["menu_no"] = dtLstRightMenu.Rows[i]["menu_no"];
                _dr["menu_desc"] = dtLstRightMenu.Rows[i]["menu_desc"];
                dtLstLeftMenu.Rows.Add(_dr);
            }

            dtLstRightMenu.Rows.Clear();

            this.lstRightRoleMenu.DataSource = dtLstRightMenu;
            lstRightRoleMenu.DataTextField = "menu_desc";
            lstRightRoleMenu.DataValueField = "menu_no";
            this.lstRightRoleMenu.DataBind();

            this.lstLeftRoleMenu.DataSource = dtLstLeftMenu;
            lstLeftRoleMenu.DataTextField = "menu_desc";
            lstLeftRoleMenu.DataValueField = "menu_no";
            this.lstLeftRoleMenu.DataBind();
        }

        protected void btnLeft_Click(object sender, EventArgs e)
        {
            if (lstRightRoleMenu.SelectedIndex == -1)
            {
                return;
            }

            DataRow _dr = dtLstLeftMenu.NewRow();
            _dr["menu_no"] = lstRightRoleMenu.SelectedValue;
            _dr["menu_desc"] = lstRightRoleMenu.SelectedItem;
            dtLstLeftMenu.Rows.Add(_dr);
            dtLstRightMenu.Rows.RemoveAt(lstRightRoleMenu.SelectedIndex);

            this.lstRightRoleMenu.DataSource = dtLstRightMenu;
            lstRightRoleMenu.DataTextField = "menu_desc";
            lstRightRoleMenu.DataValueField = "menu_no";
            this.lstRightRoleMenu.DataBind();

            this.lstLeftRoleMenu.DataSource = dtLstLeftMenu;
            lstLeftRoleMenu.DataTextField = "menu_desc";
            lstLeftRoleMenu.DataValueField = "menu_no";
            this.lstLeftRoleMenu.DataBind();
        }
        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetAllAppMenu();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.GetAllAppMenu();
        }
    }
}