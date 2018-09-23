



using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PM.Classes
{
    public partial class billdetails
    {
        private static IbilldetailsPersister _DefaultPersister;
        private IbilldetailsPersister _Persister;
        private int _id;
        private string _billamount;
        private string _billdate;
        private string _notificationmail;
        private string _billtype;

        static billdetails()
        {
            // Assign default persister
            _DefaultPersister = new SqlServerbilldetailsPersister();
        }

        public billdetails()
        {
            // Assign default persister to instance persister
            _Persister = _DefaultPersister; 
        }

        public billdetails(DataRow row)
        {
            // Assign default persister to instance persister
            _Persister = _DefaultPersister; 

            // Assign column values to private members
            for (int  i = 0; i < row.Table.Columns.Count; i++)
            {
                switch (row.Table.Columns[i].ColumnName.ToUpper())
                {
                    case "ID":
                        this.id = Convert.ToInt32(row[i, DataRowVersion.Current]); 
                        break;
                    
                    case "BILLAMOUNT":
                        this.billamount = (string)row[i, DataRowVersion.Current]; 
                        break;
                    
                    case "BILLDATE":
                        this.billdate = (string)row[i, DataRowVersion.Current]; 
                        break;
                    
                    case "NOTIFICATIONMAIL":
                        this.notificationmail = (string)row[i, DataRowVersion.Current]; 
                        break;
                    
                    case "BILLTYPE":
                        this.billtype = (string)row[i, DataRowVersion.Current]; 
                        break;
                    
                }
            }
        }

        public static IbilldetailsPersister DefaultPersister
        {
            get { return _DefaultPersister; }
            set { _DefaultPersister = value; }
        }

        public IbilldetailsPersister Persister
        {
            get { return _Persister; }
            set { _Persister = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string billamount
        {
            get { return _billamount; }
            set { _billamount = value; }
        }

        public string billdate
        {
            get { return _billdate; }
            set { _billdate = value; }
        }

        public string notificationmail
        {
            get { return _notificationmail; }
            set { _notificationmail = value; }
        }

        public string billtype
        {
            get { return _billtype; }
            set { _billtype = value; }
        }

        public virtual void Clone(billdetails sourceObject)
        {
            if(sourceObject == null)
            {
                throw new ArgumentNullException("sourceObject"); 
            }
            
            // Clone attributes from source object
            this._id = sourceObject.id; 
            this._billamount = sourceObject.billamount; 
            this._billdate = sourceObject.billdate; 
            this._notificationmail = sourceObject.notificationmail; 
            this._billtype = sourceObject.billtype; 
        }

        public virtual int Insert()
        {
            return _Persister.Insert(this); 
        }

        public static IReader<billdetails> ListAll()
        {
            return _DefaultPersister.ListAll(); 
        }

    }
    
    public partial interface IbilldetailsPersister 
    {
        int Insert(billdetails billdetails);
        IReader<billdetails> ListAll();
    }
    
    public partial class SqlServerbilldetailsPersister : SqlPersisterBase, IbilldetailsPersister
    {
        public SqlServerbilldetailsPersister()
        {
        }

        public SqlServerbilldetailsPersister(string connectionString) : base(connectionString)
        {
        }

        public SqlServerbilldetailsPersister(SqlConnection connection) : base(connection)
        {
        }

        public SqlServerbilldetailsPersister(SqlTransaction transaction) : base(transaction)
        {
        }

        public int Insert(billdetails billdetails)
        {
            int __rowsAffected = 0;
            
            // Create command
            using (SqlCommand sqlCommand = new SqlCommand("billdetailsInsert"))
            {
                // Set command type
                sqlCommand.CommandType = CommandType.StoredProcedure; 

                // Add command parameters
                SqlParameter vid = new SqlParameter("@id", SqlDbType.Int);
                vid.Direction = ParameterDirection.InputOutput; 
                sqlCommand.Parameters.Add(vid);
                SqlParameter vbillamount = new SqlParameter("@billamount", SqlDbType.NVarChar, 50);
                vbillamount.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vbillamount);
                SqlParameter vbilldate = new SqlParameter("@billdate", SqlDbType.NVarChar, 50);
                vbilldate.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vbilldate);
                SqlParameter vnotificationmail = new SqlParameter("@notificationmail", SqlDbType.NVarChar, 50);
                vnotificationmail.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vnotificationmail);
                SqlParameter vbilltype = new SqlParameter("@billtype", SqlDbType.NVarChar, 50);
                vbilltype.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vbilltype);

                // Set input parameter values
                SqlServerHelper.SetParameterValue(
                    vid, 
                    billdetails.id, 
                    0);
                SqlServerHelper.SetParameterValue(vbillamount, billdetails.billamount);
                SqlServerHelper.SetParameterValue(vbilldate, billdetails.billdate);
                SqlServerHelper.SetParameterValue(vnotificationmail, billdetails.notificationmail);
                SqlServerHelper.SetParameterValue(vbilltype, billdetails.billtype);

                try
                {
                    // Attach command
                    AttachCommand(sqlCommand);

                    // Execute command
                    __rowsAffected = sqlCommand.ExecuteNonQuery(); 
                    if(__rowsAffected == 0)
                    {
                        return __rowsAffected; 
                    }
                    

                    // Get output parameter values
                    billdetails.id = SqlServerHelper.ToInt32(vid); 

                }
                finally
                {
                    // Detach command
                    DetachCommand(sqlCommand);
                }

            }
            
            return __rowsAffected; 
        }

        public IReader<billdetails> ListAll()
        {
            // Create command
            using (SqlCommand sqlCommand = new SqlCommand("billdetailsListAll"))
            {
                // Set command type
                sqlCommand.CommandType = CommandType.StoredProcedure; 

                // Execute command
                SqlDataReader reader = sqlCommand.ExecuteReader(AttachReaderCommand(sqlCommand));

                // Return reader
                return new SqlServerbilldetailsReader(reader); 
            }
        }

    }

    public partial class SqlServerbilldetailsReader : IReader<billdetails>
    {
        private SqlDataReader sqlDataReader;

        private billdetails _billdetails;

        private int _idOrdinal = -1;
        private int _billamountOrdinal = -1;
        private int _billdateOrdinal = -1;
        private int _notificationmailOrdinal = -1;
        private int _billtypeOrdinal = -1;

        public SqlServerbilldetailsReader(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader; 
            for (int  i = 0; i < sqlDataReader.FieldCount; i++)
            {
                string columnName = sqlDataReader.GetName(i);
                columnName = columnName.ToUpper(); 
                switch (columnName)
                {
                    case "ID":
                        _idOrdinal = i; 
                        break;
                    
                    case "BILLAMOUNT":
                        _billamountOrdinal = i; 
                        break;
                    
                    case "BILLDATE":
                        _billdateOrdinal = i; 
                        break;
                    
                    case "NOTIFICATIONMAIL":
                        _notificationmailOrdinal = i; 
                        break;
                    
                    case "BILLTYPE":
                        _billtypeOrdinal = i; 
                        break;
                    
                }
            }
        }

        #region IReader<billdetails> Implementation
        
        public bool Read()
        {
            _billdetails = null; 
            return this.sqlDataReader.Read(); 
        }

        public billdetails Current
        {
            get
            {
                if(_billdetails == null)
                {
                    _billdetails = new billdetails();
                    if(_idOrdinal != -1)
                    {
                        _billdetails.id = SqlServerHelper.ToInt32(sqlDataReader, _idOrdinal); 
                    }
                    _billdetails.billamount = SqlServerHelper.ToString(sqlDataReader, _billamountOrdinal); 
                    _billdetails.billdate = SqlServerHelper.ToString(sqlDataReader, _billdateOrdinal); 
                    _billdetails.notificationmail = SqlServerHelper.ToString(sqlDataReader, _notificationmailOrdinal); 
                    _billdetails.billtype = SqlServerHelper.ToString(sqlDataReader, _billtypeOrdinal); 
                }
                

                return _billdetails; 
            }
        }

        public void Close()
        {
            sqlDataReader.Close();
        }

        public List<billdetails> ToList()
        {
            List<billdetails> list = new List<billdetails>();
            while(this.Read())
            {
                list.Add(this.Current);
            }
            this.Close();
            return list; 
        }

        public DataTable ToDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            return dataTable; 
        }

        #endregion
        
        #region IDisposable Implementation
        
        public void Dispose()
        {
            sqlDataReader.Dispose();
        }
        #endregion
        
        #region IEnumerable<billdetails> Implementation
        
        public IEnumerator<billdetails> GetEnumerator()
        {
            return new billdetailsEnumerator(this); 
        }

        #endregion
        
        #region IEnumerable Implementation
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new billdetailsEnumerator(this); 
        }

        #endregion
        
        private partial class billdetailsEnumerator : IEnumerator<billdetails>
        {
            private IReader<billdetails> billdetailsReader;

            public billdetailsEnumerator(IReader<billdetails> billdetailsReader)
            {
                this.billdetailsReader = billdetailsReader; 
            }

            #region IEnumerator<billdetails> Members
            
            public billdetails Current
            {
                get { return this.billdetailsReader.Current; }
            }

            #endregion
            
            #region IDisposable Members
            
            public void Dispose()
            {
                this.billdetailsReader.Dispose();
            }

            #endregion
            
            #region IEnumerator Members
            
            object IEnumerator.Current
            {
                get { return this.billdetailsReader.Current; }
            }

            public bool MoveNext()
            {
                return this.billdetailsReader.Read(); 
            }

            public void Reset()
            {
                throw new Exception("Reset of billdetails reader is not supported."); 
            }

            #endregion
            
        }
    }
}
