using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.IBLL.Database;
using MyProject.BLL.Database;
using MyProject.DAL.EntityModels.DataSources.SQLSERVER;
using MyProject.Model;
using MyProject.Model.ViewModels;


namespace MyProject.DAL.Database
{
    public static class DatabaseAccess
    {
        private static readonly string DataBaseName = "MOLDID_DB";
        private static readonly string DbServerIP = "localhost";
        //private static readonly string ConnectionString = $"Persist Security Info=False;User ID=moldid;Password=22d3m0stration!;Initial Catalog={DataBaseName};Data Source={DbServerIP}\\SQLExpress";
        private static readonly string ConnectionString = $"Persist Security Info=False;User ID=moldid;Password=22d3m0stration!;Initial Catalog={DataBaseName};Data Source={DbServerIP}";
        private static readonly string ConnectionStringEF = $"metadata = res://*/EntityModels.DataSources.SQLSERVER.MOLDID_DB_DataModel_SQLSERVER.csdl|res://*/EntityModels.DataSources.SQLSERVER.MOLDID_DB_DataModel_SQLSERVER.ssdl|res://*/EntityModels.DataSources.SQLSERVER.MOLDID_DB_DataModel_SQLSERVER.msl;provider=System.Data.SqlClient;provider connection string=';Data Source={DbServerIP};Initial Catalog={DataBaseName};User ID=sa;Password=dbAdmin17;MultipleActiveResultSets=True';";
        ///metadata=res://*/MyModel.csdl|res://*/MyModel.ssdl|res://*/MyModel.msl;
        private static readonly string DataProvider = "System.Data.SqlClient";
        private static DatabaseProviderHelper _databaseProvider;
        
        public static List<User> GetUsersDb()
        {
            _databaseProvider = new DatabaseProvider(DataProvider, ConnectionString);
            
            try
            {
                List<User> Users = new List<User>();
                using (var connection = _databaseProvider.GetConnection())
                {
                    var command = _databaseProvider.CreateCommand(@"OPEN SYMMETRIC KEY SymmetricKey1
                            DECRYPTION BY CERTIFICATE Certificate1
                            SELECT u.idUser
                                    ,u.usr_FirstName
                                    ,u.usr_LastName
                                    ,u.usr_name
                                    ,u.usr_gender
                                    ,u.usr_YrsOld
                                    ,u.usr_Active
                                    ,u.usr_Title
                                    ,u.usr_Approbation
                                    ,u.usr_TagInit
                                    ,u.usr_Email
                                    ,u.idwrkShift
                                    ,u.idwrkArea
                                    ,u.idProfile
                                    ,CONVERT(varchar,DECRYPTBYKEY(u.usr_Pass)) AS Password
                                    ,u.usr_IsConnected
                                    ,u.idLoginType
                                ,ISNULL(l.lgtype_Name,'') as LastLoginDevice
	                            from " + DataBaseName + @".dbo.tbl_User u
                            left join " + DataBaseName + @".dbo.Cat_LoginType l
                            on l.idLoginType = u.idLoginType
                            close symmetric key SymmetricKey1", connection);
                    
                    connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Users.Add(new User
                            {
                                ID = int.Parse(dataReader["idUser"].ToString()),
                                FirstName = dataReader["usr_FirstName"].ToString(),
                                LastName = dataReader["usr_LastName"].ToString(),
                                UserName = dataReader["usr_name"].ToString(),
                                Gender = dataReader["usr_gender"].ToString(),
                                Age = byte.Parse(dataReader["usr_YrsOld"].ToString()),
                                IsActive = bool.Parse(dataReader["usr_Active"].ToString()),
                                Title = dataReader["usr_Title"].ToString(),
                                Approbation = int.Parse(dataReader["usr_Approbation"].ToString()),
                                TagInit = dataReader["usr_TagInit"].ToString(),
                                Email = dataReader["usr_Email"].ToString(),
                                idWorkShift = int.Parse(dataReader["idwrkShift"].ToString()),
                                idWorkArea = int.Parse(dataReader["idwrkArea"].ToString()),
                                Password = dataReader["Password"].ToString(),
                                idProfile = int.Parse(dataReader["idProfile"].ToString()),
                                IsConnected = bool.Parse(dataReader["usr_IsConnected"].ToString()),
                                idLoginType = int.Parse(dataReader["idLoginType"].ToString()),
                                LastLoginDevice = dataReader["LastLoginDevice"].ToString()
                            });
                        }
                    }
                }
                return Users;
            }
            catch (Exception ex)
            {
                var Error = ex;
                return default(List<User>);
            }
        }

        public static List<tbl_User> GetAllUsers()
        {
            _databaseProvider = new DatabaseProvider(DataProvider,ConnectionStringEF);
            using (var ctx = new MOLDID_DB_SQLSERVER_ConnectionString(ConnectionStringEF))
            {
                return ctx.tbl_User.ToList();
                //students = ctx.tbl_User.Include("StudentAddress")
                //    .Select(s => new StudentViewModel()
                //    {
                //        Id = s.StudentID,
                //        FirstName = s.FirstName,
                //        LastName = s.LastName
                //    }).ToList<StudentViewModel>();
            }

            //if (students.Count == 0)
            //{
            //    return NotFound();
            //}

            //return Ok(students);
        }

    }
}
