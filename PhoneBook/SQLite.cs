using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using Dapper;
using System.Data.SQLite;
using System;

namespace PhoneBook
{
    internal static class ConnectionString
    {
        internal static string connectionString = @"Data Source=.\phonebook.db;Version=3;";
    }
    public class SqlitePersonsList
    {
        public static List<PersonInfo> LoadPersons(DynamicParameters dynamicParameters)
        {
            using (IDbConnection conn = new SQLiteConnection(ConnectionString.connectionString))
            {   var output = conn.Query<PersonInfo>("select * from abonent " +
                    "left join address on address.id_man = abonent.id_man " +
                    "left join phonenumber on phonenumber.id_man = abonent.id_man " +
                    "where phonenumber.phone_home like @phone " +
                    "or phonenumber.phone_work like @phone " +
                    "or phonenumber.phone_mobile like @phone " +
                    "order by id_man desc", dynamicParameters);
                return output.ToList();
            }
        }
    }
    public class SqliteStreetsList
    {
        public static List<StreetInfo> LoadStreets(DynamicParameters dynamicParameters)
        {
            using (IDbConnection conn = new SQLiteConnection(ConnectionString.connectionString))
            {
                var output = conn.Query<StreetInfo>("select street, count(*) as count from streets " +
                    "where streets.street like @street group by street " +
                    "order by street desc", dynamicParameters);
                return output.ToList();
            }
        }
        //public static void SavePerson(Person person)
        //{
        //    using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
        //    {
        //        conn.Execute("insert into Person (FirstName, LastName) values (@FirstName, @LastName)", person);
        //    }
        //}
    }
}