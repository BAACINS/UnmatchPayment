using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using UnmatchPayment.Database;

namespace UnmatchPayment.Class
{
    public class C002_GetDataDDL
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            //Column name
            PropertyInfo[] objProp = null;

            if (varlist == null)
            {
                return dtReturn;
            }

            foreach (T rec in varlist)
            {
                if (objProp == null)
                {
                    objProp = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in objProp)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in objProp)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);

                }

                dtReturn.Rows.Add(dr);
            }

            return dtReturn;

        }

        public DataTable GetRegion()
        {

            try
            {
                var dtAcc = from region in dbAcc.VW_REGIONs
                            orderby region.REGION_NO ascending
                            select region;

                DataTable _dt = LINQToDataTable(dtAcc);
                DataRow row;
                row = _dt.NewRow();
                row["REGION_NAME"] = "รวมทั้งหมด";
                row["REGION_NO"] = "00";
                _dt.Rows.InsertAt(row, 0);

                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetProvince(string regionNo)
        {
            try
            {
                var dtAcc = from province in dbAcc.VW_PROVINCEs
                            where province.REGION_NO == regionNo
                            orderby province.PROVINCE_NO ascending
                            select province;

                DataTable _dt = LINQToDataTable(dtAcc);

                if (_dt.Columns.Count == 0)
                {
                    _dt.Columns.Add("REGION_NAME", typeof(string));
                    _dt.Columns.Add("REGION_NO", typeof(string));
                    _dt.Columns.Add("PROVINCE_NAME", typeof(string));
                    _dt.Columns.Add("PROVINCE_NO", typeof(string));
                }

                DataRow row;
                row = _dt.NewRow();
                row["PROVINCE_NAME"] = "รวมทั้งหมด";
                row["PROVINCE_NO"] = "00";
                _dt.Rows.InsertAt(row, 0);
                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetBranch(string regionNo, string provinceNo)
        {
            try
            {
                var dtAcc = from branch in dbAcc.VW_BRANCHes
                            where branch.REGION_NO == regionNo
                            && branch.PROVINCE_NO == provinceNo
                            orderby branch.BRANCH_NO ascending
                            select branch;

                DataTable _dt = LINQToDataTable(dtAcc);
                if (_dt.Columns.Count == 0)
                {
                    _dt.Columns.Add("REGION_NAME", typeof(string));
                    _dt.Columns.Add("REGION_NO", typeof(string));
                    _dt.Columns.Add("PROVINCE_NAME", typeof(string));
                    _dt.Columns.Add("PROVINCE_NO", typeof(string));
                    _dt.Columns.Add("BRANCH_NAME", typeof(string));
                    _dt.Columns.Add("BRANCH_NO", typeof(string));
                }
                DataRow row;
                row = _dt.NewRow();
                row["BRANCH_NAME"] = "รวมทั้งหมด";
                row["BRANCH_NO"] = "00";
                _dt.Rows.InsertAt(row, 0);
                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetTitle()
        {
            try
            {
                var dtAcc = from title in dbAcc.VW_Titles
                            orderby title.TitleCode ascending
                            select title;

                DataTable _dt = LINQToDataTable(dtAcc);

                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCause(string causeID)
        {

            try
            {
                var dtAcc = from cause in dbAcc.UnmatchCauses
                            where cause.isActive == true
                            orderby cause.CauseID ascending
                            select cause;

                DataTable _dt = LINQToDataTable(dtAcc);
                DataRow row;
                row = _dt.NewRow();
                row["CAUSEDESCRIPTION"] = "รวมทั้งหมด";
                row["CAUSEID"] = "00";
                _dt.Rows.InsertAt(row, 0);

                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAddrProvince()
        {
            try
            {
                var dtAcc = from tb in dbAcc.VW_addrProvinces
                            orderby tb.StateCode ascending
                            select tb;

                DataTable _dt = LINQToDataTable(dtAcc);

                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAddrAmphur(string ProvinceCode)
        {
            try
            {
                var dtAcc = from tb in dbAcc.VW_addrAmphurs
                            where tb.StateCode == ProvinceCode
                            orderby tb.CityName ascending
                            select tb;

                DataTable _dt = LINQToDataTable(dtAcc);

                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAddrTambon(string ProvinceCode, string AmphurCode)
        {
            try
            {
                var dtAcc = from tb in dbAcc.VW_addrTambons
                            where tb.StateCode == ProvinceCode && tb.CityCode == AmphurCode
                            orderby tb.DistrictName ascending
                            select tb;

                DataTable _dt = LINQToDataTable(dtAcc);

                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDDLByRoleCode(string roleCode, string branchNo)
        {
            try
            {
                var dtAcc = from tb in dbAcc.GETUSERBYHQ_SELECT(branchNo)
                            orderby tb.USERID
                            select tb;

                DataTable _dt = LINQToDataTable(dtAcc);
                if (_dt.Columns.Count == 0)
                {
                    _dt.Columns.Add("USERID", typeof(string));
                    _dt.Columns.Add("USERFULLNAME", typeof(string));
                }
                DataRow row;
                row = _dt.NewRow();
                row["USERFULLNAME"] = "รวมทั้งหมด";
                row["USERID"] = "00";
                _dt.Rows.InsertAt(row, 0);
                return _dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFileType()
        {
            DataTable dtFileType = HttpContext.Current.Cache["dtFileType"] as DataTable;
            if (dtFileType == null)
            {
                var FileType = from FT in dbAcc.FileTypes
                               select new { FT.FileTypeID, FT.FileTypeName };

                dtFileType = LINQToDataTable(FileType);
                HttpContext.Current.Cache["dtFileType"] = dtFileType;
            }
            return dtFileType;
        }

        public DataTable GetStatus()
        {
            try
            {
                var dtAcc = from tb in dbAcc.StatusDetails
                            orderby tb.StatusCode
                            select tb;

                DataTable _dt = LINQToDataTable(dtAcc);
                if (_dt.Columns.Count == 0)
                {
                    _dt.Columns.Add("STATUSNAME", typeof(string));
                    _dt.Columns.Add("STATUSCODE", typeof(string));
                }
                DataRow row;
                row = _dt.NewRow();
                row["STATUSNAME"] = "รวมทั้งหมด";
                row["STATUSCODE"] = "00";
                _dt.Rows.InsertAt(row, 0);
                return _dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetMenuGroup()
        {
            DataTable _dt = new DataTable();
            try
            {
                var query = from tb in dbAcc.AppMenus
                            where (tb.MenuUrl == null || tb.MenuUrl.Equals(""))
                            select new
                            {
                                menuDesc = tb.MenuDesc,
                                menuNo = tb.MenuSeq.ToString()
                            };
                _dt = LINQToDataTable(query);

                DataRow _dr = _dt.NewRow();
                _dr["menuDesc"] = "ไม่ระบุ";
                _dr["menuNo"] = string.Empty;
                _dt.Rows.Add(_dr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public DataTable GetAllAppMenu(string menu_no)
        {
            DataTable _dt = new DataTable();
            try
            {

                if (menu_no == "0")
                {
                    var query = (from tb in dbAcc.AppMenus

                                 select tb).ToList();

                    _dt = LINQToDataTable(query);
                    return _dt;
                }
                else
                {
                    var query = from tb in dbAcc.AppMenus
                                where tb.MenuNo == Convert.ToInt16(menu_no)
                                select tb;
                    _dt = LINQToDataTable(query);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public DataTable CheckDuplicate(string menu_no)
        {
            DataTable _dt = new DataTable();
            try
            {


                var query = from tb in dbAcc.AppMenus
                            where tb.MenuNo == Convert.ToInt16(menu_no)
                            select tb;
                _dt = LINQToDataTable(query);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public int UpdateAppMenu(string menu_no, string menu_no_old, string menu_seq, string menu_desc, string menu_url,
                                    string create_by, string menu_group, bool menu_show)
        {
            DataTable _dt = new DataTable();
            try
            {

                var query = (from tb in dbAcc.AppMenus
                             where menu_no_old == tb.MenuNo.ToString()
                             select tb).SingleOrDefault();
                if (query != null)
                {
                    query.MenuSeq = Convert.ToInt16(menu_seq);
                    query.MenuDesc = menu_desc;
                    query.MenuUrl = menu_url;
                    query.CreateDate = DateTime.Now;
                    query.CreateBy = create_by;
                    if (!string.IsNullOrEmpty(menu_group))
                    {
                        query.MenuGroup = Convert.ToInt16(menu_group);
                    }
                    else
                    {
                        query.MenuGroup = null;
                    }

                    query.MenuShow = menu_show;

                    dbAcc.SubmitChanges();
                }
                //

                //foreach (var q in query) 
                //{
                //    q.MenuSeq =Convert.ToInt16(menu_seq) ;
                //    q.MenuDesc = menu_desc;
                //    q.MenuUrl = menu_url;
                //    q.CreateDate = DateTime.Now;
                //    q.CreateBy = create_by;
                //    if()
                //    {}
                //    q.MenuGroup = null;
                //    q.MenuShow= menu_show;

                //    dbAcc.SubmitChanges();
                //}




            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToInt16(menu_no);
        }

        public int InsertAppMenu(string menu_no, string menu_seq, string menu_desc, string menu_url,
                                    string create_by, string menu_group, bool menu_show)
        {
            DataTable _dt = new DataTable();
            try
            {
                if (menu_group == "")
                {

                    AppMenu appmenobj = new AppMenu
                    {
                        MenuNo = Convert.ToInt16(menu_no),
                        MenuSeq = Convert.ToInt16(menu_seq),
                        MenuDesc = menu_desc,
                        MenuUrl = menu_url,
                        CreateDate = DateTime.Now,
                        CreateBy = create_by,
                        MenuGroup = null,
                        MenuShow = menu_show

                    };
                    dbAcc.AppMenus.InsertOnSubmit(appmenobj);
                    dbAcc.SubmitChanges();
                }
                else
                {
                    AppMenu appmenobj = new AppMenu
                    {
                        MenuNo = Convert.ToInt16(menu_no),
                        MenuSeq = Convert.ToInt16(menu_seq),
                        MenuDesc = menu_desc,
                        MenuUrl = menu_url,
                        CreateDate = DateTime.Now,
                        CreateBy = create_by,
                        MenuGroup = Convert.ToInt16(menu_group),
                        MenuShow = menu_show
                    };
                    dbAcc.AppMenus.InsertOnSubmit(appmenobj);
                    dbAcc.SubmitChanges();

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToInt16(menu_no);
        }



        public void DeleteAppMenu(string menu_no)
        {
            DataTable _dt = new DataTable();
            try
            {

                var query = (from tb in dbAcc.AppMenus
                             where tb.MenuNo == Convert.ToInt16(menu_no)
                             select tb).DefaultIfEmpty().ToList();
                foreach (var q in query)
                {
                    dbAcc.AppMenus.DeleteOnSubmit(q);
                    dbAcc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return _dt;
        }

    }
}