using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using UnmatchPayment.Database;

namespace UnmatchPayment.Class
{
    public class C006_UploadFile
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();
        C001_DataMng DataMng = new C001_DataMng();
        public int InsertUploadDetail(string FileTypeID,Int32 TellerID,string FileOriginName, string FileSize, string UploadBy)
        {
            try
            {
                var GetFileDup = (from c in dbAcc.UploadFileDetails
                                  where c.TellerPaymentDetailID == TellerID && c.FileOriginName == FileOriginName && c.IsDelete == false
                                  select c).Count();
                if (GetFileDup > 0)
                    return -1;

                UploadFileDetail record = new UploadFileDetail();
                record.FileTypeID = int.Parse(FileTypeID);
                record.TellerPaymentDetailID = TellerID;
                record.FileOriginName = FileOriginName;
                record.FileSize = Convert.ToDecimal(FileSize);
                record.UploadDate = DateTime.Now;
                record.UploadBy = UploadBy;
                record.IsDelete = false;
                dbAcc.UploadFileDetails.InsertOnSubmit(record);
                dbAcc.SubmitChanges();
                return (int)record.FileID;
            }
            catch (Exception ex)
            {
                //return 0;
                throw ex;
            }
        }

        public void UpdateUploadFile(Int32 TellerID, string ProjectCode, int UPID)
        {
            dbAcc.UploadFileDetails
                .Where(x => x.TellerPaymentDetailID == TellerID && x.UPID == 0)
                .ToList()
                .ForEach(a =>
                {
                    a.UPID = UPID;
                }
                );
            dbAcc.SubmitChanges();
        }

        public DataTable SearchFileUploadDetail(Int32 TellerID)
        {
            DataTable _dt = new DataTable();
            try
            {
                var upload = (from query in dbAcc.UploadFileDetails.AsEnumerable()
                              join fileType in dbAcc.FileTypes on query.FileTypeID equals fileType.FileTypeID
                              where query.TellerPaymentDetailID == TellerID && query.IsDelete == false
                              select new
                              {
                                  FileID = query.FileID,
                                  FileName = fileType.FileTypeName,
                                  FileOriginName = query.FileOriginName,
                                  FileSize = query.FileSize / 1000,
                                  UploadDate = query.UploadDate,
                                  UploadBy = query.UploadBy,
                                  EncryptCode = query.EncryptCode
                              });
                _dt = DataMng.LINQToDataTable(upload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public string GetSha1Hash(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                SHA1 sha = new SHA1Managed();
                string strHash = BitConverter.ToString(sha.ComputeHash(fs));

                return strHash;
            }
        }

        public void UpdateEncrypt(int FileID, string strEncryptCode)
        {
            try
            {
                UploadFileDetail Upload = (from u in dbAcc.UploadFileDetails
                                           where u.FileID == FileID
                                           select u).SingleOrDefault();
                Upload.EncryptCode = strEncryptCode;
                dbAcc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFile(int FileID, string UserID)
        {
            //DataTable _dt = new DataTable();
            try
            {
                var qry = from upload in dbAcc.UploadFileDetails
                          where upload.FileID == FileID
                          select upload;
                var item = qry.Single();
                item.IsDelete = true;
                item.DeleteDate = DateTime.Now;
                item.DeleteBy = UserID;
                dbAcc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return _dt;
        }

        public DataTable DeleteFileAll(string CIF, string projectNo, string UserID)
        {
            DataTable _dt = new DataTable();
            try
            {
                //C002_DataAccess _dbConn = new C002_DataAccess();
                //SqlConnection SqlConn = _dbConn.GetConnection();
                //SqlDataAdapter adapter;
                //SqlCommand command = new SqlCommand();

                //command.Connection = SqlConn;
                //command.CommandType = CommandType.StoredProcedure;
                //command.CommandText = "[baacl].[UploadFileDetail_ForClaim_Delete]";
                ////command.Parameters.Add(new SqlParameter("@FileID", FileID));
                //command.Parameters.Add(new SqlParameter("@CIF", CIF));
                //command.Parameters.Add(new SqlParameter("@ProjectNo", projectNo));
                //command.Parameters.Add(new SqlParameter("@UserID", UserID));
                ////command.CommandTimeout = _TimeOut;

                //adapter = new SqlDataAdapter(command);
                //adapter.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }
    }
}