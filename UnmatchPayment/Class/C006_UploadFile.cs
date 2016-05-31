using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UnmatchPayment.Database;

namespace UnmatchPayment.Class
{
    public class C006_UploadFile
    {
        dbAccountDataContext dbAcc = new dbAccountDataContext();

        public int InsertUploadDetail(string FileOriginName, string FileTypeID, string FileSize, string ProjectCode, string AccNo, string UploadBy, string strComment, int TVSID)
        {
            try
            {
                var GetFileDup = (from c in dbAcc.UploadFileDetails
                                  where c.ACCNO == AccNo && c.FileOriginName == FileOriginName && c.TVSID == TVSID && c.IsDelete == false
                                  select c).Count();
                if (GetFileDup > 0)
                    return -1;

                var GetFileSeq = (from c in dbAcc.UploadFileDetails
                                  where c.ACCNO == AccNo
                                  select new { c.FileSeq }).Count();
                int FileSeq = GetFileSeq + 1;

                UploadFileDetail record = new UploadFileDetail();
                record.FileSeq = FileSeq;
                record.FileTypeID = int.Parse(FileTypeID);
                record.FileOriginName = FileOriginName;
                record.FileSize = Convert.ToDecimal(FileSize);
                record.ProjectCode = ProjectCode;
                record.ACCNO = AccNo;
                record.TVSID = TVSID;
                record.UploadDate = DateTime.Now;
                record.UploadBy = UploadBy;
                record.Comment = strComment;
                //record.EncryptCode
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

        public void UpdateUploadFile(string AccNo, string ProjectCode, int TVSID)
        {
            dbAcc.UploadFileDetails
                .Where(x => x.ACCNO == AccNo && x.ProjectCode == ProjectCode && x.TVSID == 0)
                .ToList()
                .ForEach(a =>
                {
                    a.TVSID = TVSID;
                }
                );
            dbAcc.SubmitChanges();
            //UploadFileDetail upload = (from tb in dbAcc.UploadFileDetails
            //                           where tb.ACCNO == AccNo && tb.ProjectCode == ProjectCode && tb.TVSID == 0
            //                           select tb).FirstOrDefault();
            //if (upload != null)
            //{
            //    upload.TVSID = TVSID;
            //    dbAcc.UploadFileDetails.InsertOnSubmit(upload);
            //    dbAcc.SubmitChanges();
            //}
        }

        public DataTable SearchFileUploadDetail(string strAccNo, int TVSID)
        {
            //strAccNo = "010012038799";
            DataTable _dt = new DataTable();
            try
            {
                var upload = (from query in dbAcc.UploadFileDetails.AsEnumerable()
                              join fileType in dbAcc.FileTypes on query.FileTypeID equals fileType.FileTypeID
                              where query.ACCNO == strAccNo && query.TVSID == TVSID && query.IsDelete == false
                              select new
                              {
                                  FileID = query.FileID,
                                  FileName = fileType.FileName,
                                  FileOriginName = query.FileOriginName,
                                  FileSize = query.FileSize / 1000,
                                  UploadDate = query.UploadDate,
                                  UploadBy = query.UploadBy,
                                  EncryptCode = query.EncryptCode
                              });
                _dt = getData.LINQToDataTable(upload);
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
                string a = BitConverter.ToString(sha.ComputeHash(fs));

                return a;
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