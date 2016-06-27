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
                                        where tb.TellerPaymentDetailID == UP.TellerPaymentDetailID
                                        select tb).SingleOrDefault();
            //check insert or update
            if(OldUnmatch == null)
            {
                OldUnmatch = new tbUnmatchPayment();
                dbAcc.tbUnmatchPayments.InsertOnSubmit(OldUnmatch);
            }

            //check null to insert
            if (OldUnmatch.CauseID != UP.CauseID && UP.CauseID != null)
                OldUnmatch.CauseID = UP.CauseID;
            if (OldUnmatch.TellerPaymentDetailID != UP.TellerPaymentDetailID && UP.TellerPaymentDetailID != null)
                OldUnmatch.TellerPaymentDetailID = UP.TellerPaymentDetailID;
            if (OldUnmatch.CompCode != UP.CompCode && UP.CompCode != null)
                OldUnmatch.CompCode = UP.CompCode;
            if (OldUnmatch.Amount != UP.Amount && UP.Amount != null)
                OldUnmatch.Amount = UP.Amount;
            if (OldUnmatch.Ref1 != UP.Ref1 && UP.Ref1 != null)
                OldUnmatch.Ref1 = UP.Ref1;
            if (OldUnmatch.Ref2 != UP.Ref2 && UP.Ref2 != null)
                OldUnmatch.Ref2 = UP.Ref2;
            if (OldUnmatch.RefName != UP.RefName && UP.RefName != null)
                OldUnmatch.RefName = UP.RefName;
            if (OldUnmatch.PaymentDate != UP.PaymentDate && UP.PaymentDate != null)
                OldUnmatch.PaymentDate = UP.PaymentDate;
            if (OldUnmatch.DepNo != UP.DepNo && UP.DepNo != null)
                OldUnmatch.DepNo = UP.DepNo;
            if (OldUnmatch.StatusCode != UP.StatusCode && UP.StatusCode != null)
                OldUnmatch.StatusCode = UP.StatusCode;
            if (OldUnmatch.CreateDate != UP.CreateDate && UP.CreateDate != null)
                OldUnmatch.CreateDate = UP.CreateDate;
            if (OldUnmatch.CreateBy != UP.CreateBy && UP.CreateBy != null)
                OldUnmatch.CreateBy = UP.CreateBy;
            if (OldUnmatch.ApproveDate != UP.ApproveDate && UP.ApproveDate != null)
                OldUnmatch.ApproveDate = UP.ApproveDate;
            if (OldUnmatch.ApproveBy != UP.ApproveBy && UP.ApproveBy != null)
                OldUnmatch.ApproveBy = UP.ApproveBy;
            if (OldUnmatch.ModifiedBy != UP.ModifiedBy && UP.ModifiedBy != null)
                OldUnmatch.ModifiedBy = UP.ModifiedBy;
            if (OldUnmatch.ModifiedDate != UP.ModifiedDate && UP.ModifiedDate != null)
                OldUnmatch.ModifiedDate = UP.ModifiedDate;
            if (OldUnmatch.ReturnTypeID != UP.ReturnTypeID && UP.ReturnTypeID != null)
                OldUnmatch.ReturnTypeID = UP.ReturnTypeID;

            dbAcc.SubmitChanges();
            return OldUnmatch.ID;
        }

        public DataTable GetCauseConfig()
        {

            try
            {
                var dtAcc = from cause in dbAcc.UnmatchCauses
                            orderby cause.CauseID ascending
                            select cause;

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