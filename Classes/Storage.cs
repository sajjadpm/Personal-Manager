


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PM.Classes
{
    public partial class Storage
    {
        private static IStoragePersister _DefaultPersister;
        private IStoragePersister _Persister;
        private int _ID;
        private string _filename;
        private string _Path;

        static Storage()
        {
            // Assign default persister
            _DefaultPersister = new SqlServerStoragePersister();
        }

        public Storage()
        {
            // Assign default persister to instance persister
            _Persister = _DefaultPersister; 
        }

        public Storage(int _ID)
        {
            // Assign default persister to instance persister
            _Persister = _DefaultPersister; 

            // Assign method parameter to private fields
            this._ID = _ID; 

            // Call associated retrieve method
            Retrieve();
        }

        public Storage(DataRow row)
        {
            // Assign default persister to instance persister
            _Persister = _DefaultPersister; 

            // Assign column values to private members
            for (int  i = 0; i < row.Table.Columns.Count; i++)
            {
                switch (row.Table.Columns[i].ColumnName.ToUpper())
                {
                    case "ID":
                        this.ID = Convert.ToInt32(row[i, DataRowVersion.Current]); 
                        break;
                    
                    case "FILENAME":
                        if(row.IsNull(i) == false)
                        {
                            this.filename = (string)row[i, DataRowVersion.Current]; 
                        }
                        break;
                    
                    case "PATH":
                        if(row.IsNull(i) == false)
                        {
                            this.Path = (string)row[i, DataRowVersion.Current]; 
                        }
                        break;
                    
                }
            }
        }

        public static IStoragePersister DefaultPersister
        {
            get { return _DefaultPersister; }
            set { _DefaultPersister = value; }
        }

        public IStoragePersister Persister
        {
            get { return _Persister; }
            set { _Persister = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }

        public virtual void Clone(Storage sourceObject)
        {
            if(sourceObject == null)
            {
                throw new ArgumentNullException("sourceObject"); 
            }
            
            // Clone attributes from source object
            this._ID = sourceObject.ID; 
            this._filename = sourceObject.filename; 
            this._Path = sourceObject.Path; 
        }

        public virtual int Retrieve()
        {
            return _Persister.Retrieve(this); 
        }

        public virtual int Update()
        {
            return _Persister.Update(this); 
        }

        public virtual int Delete()
        {
            return _Persister.Delete(this); 
        }

        public virtual int Insert()
        {
            return _Persister.Insert(this); 
        }

        public static IReader<Storage> ListAll()
        {
            return _DefaultPersister.ListAll(); 
        }

    }
    
    public partial interface IStoragePersister
    {
        int Retrieve(Storage storage);
        int Update(Storage storage);
        int Delete(Storage storage);
        int Insert(Storage storage);
        IReader<Storage> ListAll();
    }
    
    public partial class SqlServerStoragePersister : SqlPersisterBase, IStoragePersister
    {
        public SqlServerStoragePersister()
        {
        }

        public SqlServerStoragePersister(string connectionString) : base(connectionString)
        {
        }

        public SqlServerStoragePersister(SqlConnection connection) : base(connection)
        {
        }

        public SqlServerStoragePersister(SqlTransaction transaction) : base(transaction)
        {
        }

        public int Retrieve(Storage storage)
        {
            int __rowsAffected = 1;
            
            // Create command
            using (SqlCommand sqlCommand = new SqlCommand("StorageGet"))
            {
                // Set command type
                sqlCommand.CommandType = CommandType.StoredProcedure; 

                try
                {
                    // Attach command
                    AttachCommand(sqlCommand);

                    // Add command parameters
                    SqlParameter vID = new SqlParameter("@ID", SqlDbType.Int);
                    vID.Direction = ParameterDirection.InputOutput; 
                    sqlCommand.Parameters.Add(vID);
                    SqlParameter vfilename = new SqlParameter("@filename", SqlDbType.NVarChar, 50);
                    vfilename.Direction = ParameterDirection.Output; 
                    sqlCommand.Parameters.Add(vfilename);
                    SqlParameter vPath = new SqlParameter("@Path", SqlDbType.NVarChar, 50);
                    vPath.Direction = ParameterDirection.Output; 
                    sqlCommand.Parameters.Add(vPath);

                    // Set input parameter values
                    SqlServerHelper.SetParameterValue(vID, storage.ID);

                    // Execute command
                    sqlCommand.ExecuteNonQuery();

                    try
                    {
                        // Get output parameter values
                        storage.ID = SqlServerHelper.ToInt32(vID); 
                        storage.filename = SqlServerHelper.ToString(vfilename); 
                        storage.Path = SqlServerHelper.ToString(vPath); 

                    }
                    catch(Exception ex)
                    {
                        if(ex is System.NullReferenceException)
                        {
                            __rowsAffected = 0; 
                        }
                        else
                        {
                            throw ex; 
                        }
                    }
                }
                finally
                {
                    // Detach command
                    DetachCommand(sqlCommand);
                }

            }
            
            return __rowsAffected; 
        }

        public int Update(Storage storage)
        {
            int __rowsAffected = 0;
            
            // Create command
            using (SqlCommand sqlCommand = new SqlCommand("StorageUpdate"))
            {
                // Set command type
                sqlCommand.CommandType = CommandType.StoredProcedure; 

                // Add command parameters
                SqlParameter vID = new SqlParameter("@ID", SqlDbType.Int);
                vID.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vID);
                SqlParameter vfilename = new SqlParameter("@filename", SqlDbType.NVarChar, 50);
                vfilename.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vfilename);
                SqlParameter vPath = new SqlParameter("@Path", SqlDbType.NVarChar, 50);
                vPath.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vPath);

                // Set input parameter values
                SqlServerHelper.SetParameterValue(vID, storage.ID);
                SqlServerHelper.SetParameterValue(vfilename, storage.filename);
                SqlServerHelper.SetParameterValue(vPath, storage.Path);

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
                    

                }
                finally
                {
                    // Detach command
                    DetachCommand(sqlCommand);
                }

            }
            
            return __rowsAffected; 
        }

        public int Delete(Storage storage)
        {
            int __rowsAffected = 0;
            
            // Create command
            using (SqlCommand sqlCommand = new SqlCommand("StorageDelete"))
            {
                // Set command type
                sqlCommand.CommandType = CommandType.StoredProcedure; 

                try
                {
                    // Attach command
                    AttachCommand(sqlCommand);

                    // Add command parameters
                    SqlParameter vID = new SqlParameter("@ID", SqlDbType.Int);
                    vID.Direction = ParameterDirection.Input; 
                    sqlCommand.Parameters.Add(vID);

                    // Set input parameter values
                    SqlServerHelper.SetParameterValue(vID, storage.ID);

                    // Execute command
                    __rowsAffected = sqlCommand.ExecuteNonQuery(); 

                }
                finally
                {
                    // Detach command
                    DetachCommand(sqlCommand);
                }

            }
            
            return __rowsAffected; 
        }

        public int Insert(Storage storage)
        {
            int __rowsAffected = 0;
            
            // Create command
            using (SqlCommand sqlCommand = new SqlCommand("StorageInsert"))
            {
                // Set command type
                sqlCommand.CommandType = CommandType.StoredProcedure; 

                // Add command parameters
                SqlParameter vID = new SqlParameter("@ID", SqlDbType.Int);
                vID.Direction = ParameterDirection.InputOutput; 
                sqlCommand.Parameters.Add(vID);
                SqlParameter vfilename = new SqlParameter("@filename", SqlDbType.NVarChar, 50);
                vfilename.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vfilename);
                SqlParameter vPath = new SqlParameter("@Path", SqlDbType.NVarChar, 50);
                vPath.Direction = ParameterDirection.Input; 
                sqlCommand.Parameters.Add(vPath);

                // Set input parameter values
                SqlServerHelper.SetParameterValue(
                    vID, 
                    storage.ID, 
                    0);
                SqlServerHelper.SetParameterValue(vfilename, storage.filename);
                SqlServerHelper.SetParameterValue(vPath, storage.Path);

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
                    storage.ID = SqlServerHelper.ToInt32(vID); 

                }
                finally
                {
                    // Detach command
                    DetachCommand(sqlCommand);
                }

            }
            
            return __rowsAffected; 
        }

        public IReader<Storage> ListAll()
        {
            // Create command
            using (SqlCommand sqlCommand = new SqlCommand("StorageListAll"))
            {
                // Set command type
                sqlCommand.CommandType = CommandType.StoredProcedure; 

                // Execute command
                SqlDataReader reader = sqlCommand.ExecuteReader(AttachReaderCommand(sqlCommand));

                // Return reader
                return new SqlServerStorageReader(reader); 
            }
        }

    }

    public partial class SqlServerStorageReader : IReader<Storage>
    {
        private SqlDataReader sqlDataReader;

        private Storage _Storage;

        private int _IDOrdinal = -1;
        private int _filenameOrdinal = -1;
        private int _PathOrdinal = -1;

        public SqlServerStorageReader(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader; 
            for (int  i = 0; i < sqlDataReader.FieldCount; i++)
            {
                string columnName = sqlDataReader.GetName(i);
                columnName = columnName.ToUpper(); 
                switch (columnName)
                {
                    case "ID":
                        _IDOrdinal = i; 
                        break;
                    
                    case "FILENAME":
                        _filenameOrdinal = i; 
                        break;
                    
                    case "PATH":
                        _PathOrdinal = i; 
                        break;
                    
                }
            }
        }

        #region IReader<Storage> Implementation
        
        public bool Read()
        {
            _Storage = null; 
            return this.sqlDataReader.Read(); 
        }

        public Storage Current
        {
            get
            {
                if(_Storage == null)
                {
                    _Storage = new Storage();
                    if(_IDOrdinal != -1)
                    {
                        _Storage.ID = SqlServerHelper.ToInt32(sqlDataReader, _IDOrdinal); 
                    }
                    _Storage.filename = SqlServerHelper.ToString(sqlDataReader, _filenameOrdinal); 
                    _Storage.Path = SqlServerHelper.ToString(sqlDataReader, _PathOrdinal); 
                }
                

                return _Storage; 
            }
        }

        public void Close()
        {
            sqlDataReader.Close();
        }

        public List<Storage> ToList()
        {
            List<Storage> list = new List<Storage>();
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
        
        #region IEnumerable<Storage> Implementation
        
        public IEnumerator<Storage> GetEnumerator()
        {
            return new StorageEnumerator(this); 
        }

        #endregion
        
        #region IEnumerable Implementation
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StorageEnumerator(this); 
        }

        #endregion
        
        private partial class StorageEnumerator : IEnumerator<Storage>
        {
            private IReader<Storage> storageReader;

            public StorageEnumerator(IReader<Storage> storageReader)
            {
                this.storageReader = storageReader; 
            }

            #region IEnumerator<Storage> Members
            
            public Storage Current
            {
                get { return this.storageReader.Current; }
            }

            #endregion
            
            #region IDisposable Members
            
            public void Dispose()
            {
                this.storageReader.Dispose();
            }

            #endregion
            
            #region IEnumerator Members
            
            object IEnumerator.Current
            {
                get { return this.storageReader.Current; }
            }

            public bool MoveNext()
            {
                return this.storageReader.Read(); 
            }

            public void Reset()
            {
                throw new Exception("Reset of storage reader is not supported."); 
            }

            #endregion
            
        }
    }
}
