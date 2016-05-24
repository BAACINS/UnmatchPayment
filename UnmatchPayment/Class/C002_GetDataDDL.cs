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
    }
}