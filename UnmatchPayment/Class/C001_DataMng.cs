using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using UnmatchPayment.Database;

namespace UnmatchPayment.Class
{
    public class C001_DataMng
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

        public int EditUnmatchpayment(tbUnmatchPayment UP)
        {
            tbUnmatchPayment OldUnmatch = (from tb in dbAcc.tbUnmatchPayments
                                        where tb.ID == UP.ID
                                        select tb).SingleOrDefault();
            //check insert or update
            if(OldUnmatch == null)
            {
                OldUnmatch = new tbUnmatchPayment();
                dbAcc.tbUnmatchPayments.InsertOnSubmit(OldUnmatch);
            }

            //check null to insert
            if (OldUnmatch.CauseID != UP.CauseID && UP.CauseID != null)
                OldUnmatch.ID = UP.ID;
            if (OldUnmatch.TellerPaymentDetailID != UP.CauseID && UP.CauseID != null)
                OldUnmatch.TellerPaymentDetailID = UP.ID;

            return 0;
        }
    }
}