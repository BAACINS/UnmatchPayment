﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnmatchPayment.Database
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BAACINS")]
	public partial class dbAccountDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAppMenu(AppMenu instance);
    partial void UpdateAppMenu(AppMenu instance);
    partial void DeleteAppMenu(AppMenu instance);
    partial void InsertAppMenuAccess(AppMenuAccess instance);
    partial void UpdateAppMenuAccess(AppMenuAccess instance);
    partial void DeleteAppMenuAccess(AppMenuAccess instance);
    partial void InsertFileType(FileType instance);
    partial void UpdateFileType(FileType instance);
    partial void DeleteFileType(FileType instance);
    #endregion
		
		public dbAccountDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BAACINSConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbAccountDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbAccountDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbAccountDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbAccountDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<AppMenu> AppMenus
		{
			get
			{
				return this.GetTable<AppMenu>();
			}
		}
		
		public System.Data.Linq.Table<AppMenuAccess> AppMenuAccesses
		{
			get
			{
				return this.GetTable<AppMenuAccess>();
			}
		}
		
		public System.Data.Linq.Table<FileType> FileTypes
		{
			get
			{
				return this.GetTable<FileType>();
			}
		}
		
		public System.Data.Linq.Table<VW_TellerPaymentDetail> VW_TellerPaymentDetails
		{
			get
			{
				return this.GetTable<VW_TellerPaymentDetail>();
			}
		}
		
		public System.Data.Linq.Table<VW_REGION> VW_REGIONs
		{
			get
			{
				return this.GetTable<VW_REGION>();
			}
		}
		
		public System.Data.Linq.Table<VW_PROVINCE> VW_PROVINCEs
		{
			get
			{
				return this.GetTable<VW_PROVINCE>();
			}
		}
		
		public System.Data.Linq.Table<VW_BRANCH> VW_BRANCHes
		{
			get
			{
				return this.GetTable<VW_BRANCH>();
			}
		}
		
		public System.Data.Linq.Table<VW_Title> VW_Titles
		{
			get
			{
				return this.GetTable<VW_Title>();
			}
		}
		
		public System.Data.Linq.Table<VW_addrAmphur> VW_addrAmphurs
		{
			get
			{
				return this.GetTable<VW_addrAmphur>();
			}
		}
		
		public System.Data.Linq.Table<VW_addrProvince> VW_addrProvinces
		{
			get
			{
				return this.GetTable<VW_addrProvince>();
			}
		}
		
		public System.Data.Linq.Table<VW_addrTambon> VW_addrTambons
		{
			get
			{
				return this.GetTable<VW_addrTambon>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="UP.EMPLOYEE_SELECT")]
		public ISingleResult<EMPLOYEE_SELECTResult> EMPLOYEE_SELECT([global::System.Data.Linq.Mapping.ParameterAttribute(Name="USER_ID", DbType="NVarChar(7)")] string uSER_ID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="USER_PASSWORD", DbType="NVarChar(50)")] string uSER_PASSWORD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), uSER_ID, uSER_PASSWORD);
			return ((ISingleResult<EMPLOYEE_SELECTResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="UP.AppMenu")]
	public partial class AppMenu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MenuNo;
		
		private System.Nullable<int> _MenuSeq;
		
		private string _MenuDesc;
		
		private string _MenuUrl;
		
		private System.Nullable<int> _MenuGroup;
		
		private System.Nullable<bool> _MenuShow;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private string _CreateBy;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMenuNoChanging(int value);
    partial void OnMenuNoChanged();
    partial void OnMenuSeqChanging(System.Nullable<int> value);
    partial void OnMenuSeqChanged();
    partial void OnMenuDescChanging(string value);
    partial void OnMenuDescChanged();
    partial void OnMenuUrlChanging(string value);
    partial void OnMenuUrlChanged();
    partial void OnMenuGroupChanging(System.Nullable<int> value);
    partial void OnMenuGroupChanged();
    partial void OnMenuShowChanging(System.Nullable<bool> value);
    partial void OnMenuShowChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    partial void OnCreateByChanging(string value);
    partial void OnCreateByChanged();
    #endregion
		
		public AppMenu()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuNo", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MenuNo
		{
			get
			{
				return this._MenuNo;
			}
			set
			{
				if ((this._MenuNo != value))
				{
					this.OnMenuNoChanging(value);
					this.SendPropertyChanging();
					this._MenuNo = value;
					this.SendPropertyChanged("MenuNo");
					this.OnMenuNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuSeq", DbType="Int")]
		public System.Nullable<int> MenuSeq
		{
			get
			{
				return this._MenuSeq;
			}
			set
			{
				if ((this._MenuSeq != value))
				{
					this.OnMenuSeqChanging(value);
					this.SendPropertyChanging();
					this._MenuSeq = value;
					this.SendPropertyChanged("MenuSeq");
					this.OnMenuSeqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuDesc", DbType="NVarChar(100)")]
		public string MenuDesc
		{
			get
			{
				return this._MenuDesc;
			}
			set
			{
				if ((this._MenuDesc != value))
				{
					this.OnMenuDescChanging(value);
					this.SendPropertyChanging();
					this._MenuDesc = value;
					this.SendPropertyChanged("MenuDesc");
					this.OnMenuDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuUrl", DbType="NVarChar(100)")]
		public string MenuUrl
		{
			get
			{
				return this._MenuUrl;
			}
			set
			{
				if ((this._MenuUrl != value))
				{
					this.OnMenuUrlChanging(value);
					this.SendPropertyChanging();
					this._MenuUrl = value;
					this.SendPropertyChanged("MenuUrl");
					this.OnMenuUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuGroup", DbType="Int")]
		public System.Nullable<int> MenuGroup
		{
			get
			{
				return this._MenuGroup;
			}
			set
			{
				if ((this._MenuGroup != value))
				{
					this.OnMenuGroupChanging(value);
					this.SendPropertyChanging();
					this._MenuGroup = value;
					this.SendPropertyChanged("MenuGroup");
					this.OnMenuGroupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuShow", DbType="Bit")]
		public System.Nullable<bool> MenuShow
		{
			get
			{
				return this._MenuShow;
			}
			set
			{
				if ((this._MenuShow != value))
				{
					this.OnMenuShowChanging(value);
					this.SendPropertyChanging();
					this._MenuShow = value;
					this.SendPropertyChanged("MenuShow");
					this.OnMenuShowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateBy", DbType="NVarChar(7)")]
		public string CreateBy
		{
			get
			{
				return this._CreateBy;
			}
			set
			{
				if ((this._CreateBy != value))
				{
					this.OnCreateByChanging(value);
					this.SendPropertyChanging();
					this._CreateBy = value;
					this.SendPropertyChanged("CreateBy");
					this.OnCreateByChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="UP.AppMenuAccess")]
	public partial class AppMenuAccess : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MenuNo;
		
		private string _UserRole;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private string _CreateBy;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMenuNoChanging(int value);
    partial void OnMenuNoChanged();
    partial void OnUserRoleChanging(string value);
    partial void OnUserRoleChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    partial void OnCreateByChanging(string value);
    partial void OnCreateByChanged();
    #endregion
		
		public AppMenuAccess()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuNo", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MenuNo
		{
			get
			{
				return this._MenuNo;
			}
			set
			{
				if ((this._MenuNo != value))
				{
					this.OnMenuNoChanging(value);
					this.SendPropertyChanging();
					this._MenuNo = value;
					this.SendPropertyChanged("MenuNo");
					this.OnMenuNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserRole", DbType="NVarChar(4) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserRole
		{
			get
			{
				return this._UserRole;
			}
			set
			{
				if ((this._UserRole != value))
				{
					this.OnUserRoleChanging(value);
					this.SendPropertyChanging();
					this._UserRole = value;
					this.SendPropertyChanged("UserRole");
					this.OnUserRoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateBy", DbType="NVarChar(8)")]
		public string CreateBy
		{
			get
			{
				return this._CreateBy;
			}
			set
			{
				if ((this._CreateBy != value))
				{
					this.OnCreateByChanging(value);
					this.SendPropertyChanging();
					this._CreateBy = value;
					this.SendPropertyChanged("CreateBy");
					this.OnCreateByChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="UP.FileType")]
	public partial class FileType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _FileTypeID;
		
		private string _FileTypeName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFileTypeIDChanging(int value);
    partial void OnFileTypeIDChanged();
    partial void OnFileTypeNameChanging(string value);
    partial void OnFileTypeNameChanged();
    #endregion
		
		public FileType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileTypeID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int FileTypeID
		{
			get
			{
				return this._FileTypeID;
			}
			set
			{
				if ((this._FileTypeID != value))
				{
					this.OnFileTypeIDChanging(value);
					this.SendPropertyChanging();
					this._FileTypeID = value;
					this.SendPropertyChanged("FileTypeID");
					this.OnFileTypeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileTypeName", DbType="NVarChar(100)")]
		public string FileTypeName
		{
			get
			{
				return this._FileTypeName;
			}
			set
			{
				if ((this._FileTypeName != value))
				{
					this.OnFileTypeNameChanging(value);
					this.SendPropertyChanging();
					this._FileTypeName = value;
					this.SendPropertyChanged("FileTypeName");
					this.OnFileTypeNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="UP.VW_TellerPaymentDetail")]
	public partial class VW_TellerPaymentDetail
	{
		
		private long _TellerPaymentDetailID;
		
		private string _RecordType;
		
		private System.Nullable<int> _SequenceNo;
		
		private string _BankCode;
		
		private string _CompanyAccount;
		
		private string _PaymentDate;
		
		private string _PaymentTime;
		
		private System.Nullable<System.DateTime> _PaymentDateTime;
		
		private string _CustomerName;
		
		private string _Ref1;
		
		private string _Ref2;
		
		private string _Ref3;
		
		private string _BranchCode;
		
		private string _TellerNo;
		
		private string _KindOfTransaction;
		
		private string _PaymentBy;
		
		private string _ChequeNo;
		
		private System.Nullable<decimal> _Amount;
		
		private string _ChequeBankCode;
		
		private string _Filler;
		
		private string _CompCode;
		
		private System.Data.Linq.Binary _timestamp;
		
		private System.Nullable<long> _MatchingID;
		
		private string _DivisionAreaCode;
		
		private string _UpperDivisionCode;
		
		private System.Nullable<System.DateTime> _MatchingDateTime;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private System.Nullable<System.DateTime> _ModifyDate;
		
		public VW_TellerPaymentDetail()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TellerPaymentDetailID", AutoSync=AutoSync.Always, DbType="BigInt NOT NULL IDENTITY", IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public long TellerPaymentDetailID
		{
			get
			{
				return this._TellerPaymentDetailID;
			}
			set
			{
				if ((this._TellerPaymentDetailID != value))
				{
					this._TellerPaymentDetailID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecordType", DbType="NVarChar(1)", UpdateCheck=UpdateCheck.Never)]
		public string RecordType
		{
			get
			{
				return this._RecordType;
			}
			set
			{
				if ((this._RecordType != value))
				{
					this._RecordType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SequenceNo", DbType="Int", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<int> SequenceNo
		{
			get
			{
				return this._SequenceNo;
			}
			set
			{
				if ((this._SequenceNo != value))
				{
					this._SequenceNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BankCode", DbType="NVarChar(3)", UpdateCheck=UpdateCheck.Never)]
		public string BankCode
		{
			get
			{
				return this._BankCode;
			}
			set
			{
				if ((this._BankCode != value))
				{
					this._BankCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompanyAccount", DbType="NVarChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string CompanyAccount
		{
			get
			{
				return this._CompanyAccount;
			}
			set
			{
				if ((this._CompanyAccount != value))
				{
					this._CompanyAccount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentDate", DbType="NVarChar(8)", UpdateCheck=UpdateCheck.Never)]
		public string PaymentDate
		{
			get
			{
				return this._PaymentDate;
			}
			set
			{
				if ((this._PaymentDate != value))
				{
					this._PaymentDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentTime", DbType="NVarChar(6)", UpdateCheck=UpdateCheck.Never)]
		public string PaymentTime
		{
			get
			{
				return this._PaymentTime;
			}
			set
			{
				if ((this._PaymentTime != value))
				{
					this._PaymentTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentDateTime", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> PaymentDateTime
		{
			get
			{
				return this._PaymentDateTime;
			}
			set
			{
				if ((this._PaymentDateTime != value))
				{
					this._PaymentDateTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerName", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string CustomerName
		{
			get
			{
				return this._CustomerName;
			}
			set
			{
				if ((this._CustomerName != value))
				{
					this._CustomerName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ref1", DbType="NVarChar(20)", UpdateCheck=UpdateCheck.Never)]
		public string Ref1
		{
			get
			{
				return this._Ref1;
			}
			set
			{
				if ((this._Ref1 != value))
				{
					this._Ref1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ref2", DbType="NVarChar(20)", UpdateCheck=UpdateCheck.Never)]
		public string Ref2
		{
			get
			{
				return this._Ref2;
			}
			set
			{
				if ((this._Ref2 != value))
				{
					this._Ref2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ref3", DbType="NVarChar(20)", UpdateCheck=UpdateCheck.Never)]
		public string Ref3
		{
			get
			{
				return this._Ref3;
			}
			set
			{
				if ((this._Ref3 != value))
				{
					this._Ref3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BranchCode", DbType="NVarChar(4)", UpdateCheck=UpdateCheck.Never)]
		public string BranchCode
		{
			get
			{
				return this._BranchCode;
			}
			set
			{
				if ((this._BranchCode != value))
				{
					this._BranchCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TellerNo", DbType="NVarChar(4)", UpdateCheck=UpdateCheck.Never)]
		public string TellerNo
		{
			get
			{
				return this._TellerNo;
			}
			set
			{
				if ((this._TellerNo != value))
				{
					this._TellerNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KindOfTransaction", DbType="NVarChar(1)", UpdateCheck=UpdateCheck.Never)]
		public string KindOfTransaction
		{
			get
			{
				return this._KindOfTransaction;
			}
			set
			{
				if ((this._KindOfTransaction != value))
				{
					this._KindOfTransaction = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentBy", DbType="NVarChar(3)", UpdateCheck=UpdateCheck.Never)]
		public string PaymentBy
		{
			get
			{
				return this._PaymentBy;
			}
			set
			{
				if ((this._PaymentBy != value))
				{
					this._PaymentBy = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChequeNo", DbType="NVarChar(7)", UpdateCheck=UpdateCheck.Never)]
		public string ChequeNo
		{
			get
			{
				return this._ChequeNo;
			}
			set
			{
				if ((this._ChequeNo != value))
				{
					this._ChequeNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Decimal(18,2)", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<decimal> Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this._Amount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChequeBankCode", DbType="NVarChar(3)", UpdateCheck=UpdateCheck.Never)]
		public string ChequeBankCode
		{
			get
			{
				return this._ChequeBankCode;
			}
			set
			{
				if ((this._ChequeBankCode != value))
				{
					this._ChequeBankCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Filler", DbType="NVarChar(77)", UpdateCheck=UpdateCheck.Never)]
		public string Filler
		{
			get
			{
				return this._Filler;
			}
			set
			{
				if ((this._Filler != value))
				{
					this._Filler = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompCode", DbType="NVarChar(12)", UpdateCheck=UpdateCheck.Never)]
		public string CompCode
		{
			get
			{
				return this._CompCode;
			}
			set
			{
				if ((this._CompCode != value))
				{
					this._CompCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_timestamp", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary timestamp
		{
			get
			{
				return this._timestamp;
			}
			set
			{
				if ((this._timestamp != value))
				{
					this._timestamp = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatchingID", DbType="BigInt", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<long> MatchingID
		{
			get
			{
				return this._MatchingID;
			}
			set
			{
				if ((this._MatchingID != value))
				{
					this._MatchingID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DivisionAreaCode", DbType="NVarChar(4)", UpdateCheck=UpdateCheck.Never)]
		public string DivisionAreaCode
		{
			get
			{
				return this._DivisionAreaCode;
			}
			set
			{
				if ((this._DivisionAreaCode != value))
				{
					this._DivisionAreaCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpperDivisionCode", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string UpperDivisionCode
		{
			get
			{
				return this._UpperDivisionCode;
			}
			set
			{
				if ((this._UpperDivisionCode != value))
				{
					this._UpperDivisionCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatchingDateTime", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> MatchingDateTime
		{
			get
			{
				return this._MatchingDateTime;
			}
			set
			{
				if ((this._MatchingDateTime != value))
				{
					this._MatchingDateTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this._CreateDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this._ModifyDate = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_REGION")]
	public partial class VW_REGION
	{
		
		private string _REGION_NO;
		
		private string _REGION_NAME;
		
		public VW_REGION()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NO", DbType="NVarChar(100)")]
		public string REGION_NO
		{
			get
			{
				return this._REGION_NO;
			}
			set
			{
				if ((this._REGION_NO != value))
				{
					this._REGION_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NAME", DbType="NVarChar(100)")]
		public string REGION_NAME
		{
			get
			{
				return this._REGION_NAME;
			}
			set
			{
				if ((this._REGION_NAME != value))
				{
					this._REGION_NAME = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_PROVINCE")]
	public partial class VW_PROVINCE
	{
		
		private string _REGION_NO;
		
		private string _REGION_NAME;
		
		private string _PROVINCE_NO;
		
		private string _PROVINCE_NAME;
		
		public VW_PROVINCE()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NO", DbType="NVarChar(100)")]
		public string REGION_NO
		{
			get
			{
				return this._REGION_NO;
			}
			set
			{
				if ((this._REGION_NO != value))
				{
					this._REGION_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NAME", DbType="NVarChar(100)")]
		public string REGION_NAME
		{
			get
			{
				return this._REGION_NAME;
			}
			set
			{
				if ((this._REGION_NAME != value))
				{
					this._REGION_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PROVINCE_NO", DbType="NVarChar(100)")]
		public string PROVINCE_NO
		{
			get
			{
				return this._PROVINCE_NO;
			}
			set
			{
				if ((this._PROVINCE_NO != value))
				{
					this._PROVINCE_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PROVINCE_NAME", DbType="NVarChar(100)")]
		public string PROVINCE_NAME
		{
			get
			{
				return this._PROVINCE_NAME;
			}
			set
			{
				if ((this._PROVINCE_NAME != value))
				{
					this._PROVINCE_NAME = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_BRANCH")]
	public partial class VW_BRANCH
	{
		
		private string _REGION_NO;
		
		private string _REGION_NAME;
		
		private string _PROVINCE_NO;
		
		private string _PROVINCE_NAME;
		
		private string _BRANCH_NO;
		
		private string _BRANCH_NAME;
		
		private string _BASE_CODE;
		
		public VW_BRANCH()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NO", DbType="NVarChar(100)")]
		public string REGION_NO
		{
			get
			{
				return this._REGION_NO;
			}
			set
			{
				if ((this._REGION_NO != value))
				{
					this._REGION_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NAME", DbType="NVarChar(100)")]
		public string REGION_NAME
		{
			get
			{
				return this._REGION_NAME;
			}
			set
			{
				if ((this._REGION_NAME != value))
				{
					this._REGION_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PROVINCE_NO", DbType="NVarChar(100)")]
		public string PROVINCE_NO
		{
			get
			{
				return this._PROVINCE_NO;
			}
			set
			{
				if ((this._PROVINCE_NO != value))
				{
					this._PROVINCE_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PROVINCE_NAME", DbType="NVarChar(100)")]
		public string PROVINCE_NAME
		{
			get
			{
				return this._PROVINCE_NAME;
			}
			set
			{
				if ((this._PROVINCE_NAME != value))
				{
					this._PROVINCE_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRANCH_NO", DbType="NVarChar(4)")]
		public string BRANCH_NO
		{
			get
			{
				return this._BRANCH_NO;
			}
			set
			{
				if ((this._BRANCH_NO != value))
				{
					this._BRANCH_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRANCH_NAME", DbType="NVarChar(100)")]
		public string BRANCH_NAME
		{
			get
			{
				return this._BRANCH_NAME;
			}
			set
			{
				if ((this._BRANCH_NAME != value))
				{
					this._BRANCH_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BASE_CODE", DbType="NVarChar(50)")]
		public string BASE_CODE
		{
			get
			{
				return this._BASE_CODE;
			}
			set
			{
				if ((this._BASE_CODE != value))
				{
					this._BASE_CODE = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_Title")]
	public partial class VW_Title
	{
		
		private string _TitleCode;
		
		private string _TitleName;
		
		public VW_Title()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TitleCode", DbType="NVarChar(10)")]
		public string TitleCode
		{
			get
			{
				return this._TitleCode;
			}
			set
			{
				if ((this._TitleCode != value))
				{
					this._TitleCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TitleName", DbType="NVarChar(50)")]
		public string TitleName
		{
			get
			{
				return this._TitleName;
			}
			set
			{
				if ((this._TitleName != value))
				{
					this._TitleName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_addrAmphur")]
	public partial class VW_addrAmphur
	{
		
		private string _StateCode;
		
		private string _CityCode;
		
		private string _CityName;
		
		public VW_addrAmphur()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateCode", DbType="NVarChar(2)")]
		public string StateCode
		{
			get
			{
				return this._StateCode;
			}
			set
			{
				if ((this._StateCode != value))
				{
					this._StateCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityCode", DbType="NVarChar(40)")]
		public string CityCode
		{
			get
			{
				return this._CityCode;
			}
			set
			{
				if ((this._CityCode != value))
				{
					this._CityCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityName", DbType="NVarChar(500)")]
		public string CityName
		{
			get
			{
				return this._CityName;
			}
			set
			{
				if ((this._CityName != value))
				{
					this._CityName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_addrProvince")]
	public partial class VW_addrProvince
	{
		
		private string _StateCode;
		
		private string _StateName;
		
		public VW_addrProvince()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateCode", DbType="NVarChar(10)")]
		public string StateCode
		{
			get
			{
				return this._StateCode;
			}
			set
			{
				if ((this._StateCode != value))
				{
					this._StateCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateName", DbType="NVarChar(500)")]
		public string StateName
		{
			get
			{
				return this._StateName;
			}
			set
			{
				if ((this._StateName != value))
				{
					this._StateName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_addrTambon")]
	public partial class VW_addrTambon
	{
		
		private string _StateCode;
		
		private string _CityCode;
		
		private string _DistrictCode;
		
		private string _DistrictName;
		
		public VW_addrTambon()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateCode", DbType="NVarChar(10)")]
		public string StateCode
		{
			get
			{
				return this._StateCode;
			}
			set
			{
				if ((this._StateCode != value))
				{
					this._StateCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityCode", DbType="NVarChar(40)")]
		public string CityCode
		{
			get
			{
				return this._CityCode;
			}
			set
			{
				if ((this._CityCode != value))
				{
					this._CityCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DistrictCode", DbType="NVarChar(10)")]
		public string DistrictCode
		{
			get
			{
				return this._DistrictCode;
			}
			set
			{
				if ((this._DistrictCode != value))
				{
					this._DistrictCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DistrictName", DbType="NVarChar(500)")]
		public string DistrictName
		{
			get
			{
				return this._DistrictName;
			}
			set
			{
				if ((this._DistrictName != value))
				{
					this._DistrictName = value;
				}
			}
		}
	}
	
	public partial class EMPLOYEE_SELECTResult
	{
		
		private string _USER_ID;
		
		private string _USER_NAME;
		
		private string _POSITIONNAME;
		
		private string _ROLECODE;
		
		private string _ROLENAME;
		
		private string _BRANCH_NO;
		
		private string _BRANCH_NAME;
		
		private string _REGION_NO;
		
		private string _REGION_NAME;
		
		private string _PROVINCE_NO;
		
		private string _PROVINCE_NAME;
		
		private int _isBranch;
		
		public EMPLOYEE_SELECTResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_ID", DbType="NVarChar(10)")]
		public string USER_ID
		{
			get
			{
				return this._USER_ID;
			}
			set
			{
				if ((this._USER_ID != value))
				{
					this._USER_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_NAME", DbType="NVarChar(251)")]
		public string USER_NAME
		{
			get
			{
				return this._USER_NAME;
			}
			set
			{
				if ((this._USER_NAME != value))
				{
					this._USER_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POSITIONNAME", DbType="NVarChar(255)")]
		public string POSITIONNAME
		{
			get
			{
				return this._POSITIONNAME;
			}
			set
			{
				if ((this._POSITIONNAME != value))
				{
					this._POSITIONNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROLECODE", DbType="NVarChar(30)")]
		public string ROLECODE
		{
			get
			{
				return this._ROLECODE;
			}
			set
			{
				if ((this._ROLECODE != value))
				{
					this._ROLECODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROLENAME", DbType="NVarChar(521)")]
		public string ROLENAME
		{
			get
			{
				return this._ROLENAME;
			}
			set
			{
				if ((this._ROLENAME != value))
				{
					this._ROLENAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRANCH_NO", DbType="NVarChar(30)")]
		public string BRANCH_NO
		{
			get
			{
				return this._BRANCH_NO;
			}
			set
			{
				if ((this._BRANCH_NO != value))
				{
					this._BRANCH_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRANCH_NAME", DbType="NVarChar(100)")]
		public string BRANCH_NAME
		{
			get
			{
				return this._BRANCH_NAME;
			}
			set
			{
				if ((this._BRANCH_NAME != value))
				{
					this._BRANCH_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NO", DbType="NVarChar(100)")]
		public string REGION_NO
		{
			get
			{
				return this._REGION_NO;
			}
			set
			{
				if ((this._REGION_NO != value))
				{
					this._REGION_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REGION_NAME", DbType="NVarChar(100)")]
		public string REGION_NAME
		{
			get
			{
				return this._REGION_NAME;
			}
			set
			{
				if ((this._REGION_NAME != value))
				{
					this._REGION_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PROVINCE_NO", DbType="NVarChar(100)")]
		public string PROVINCE_NO
		{
			get
			{
				return this._PROVINCE_NO;
			}
			set
			{
				if ((this._PROVINCE_NO != value))
				{
					this._PROVINCE_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PROVINCE_NAME", DbType="NVarChar(100)")]
		public string PROVINCE_NAME
		{
			get
			{
				return this._PROVINCE_NAME;
			}
			set
			{
				if ((this._PROVINCE_NAME != value))
				{
					this._PROVINCE_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isBranch", DbType="Int NOT NULL")]
		public int isBranch
		{
			get
			{
				return this._isBranch;
			}
			set
			{
				if ((this._isBranch != value))
				{
					this._isBranch = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
