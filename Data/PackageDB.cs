﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [DataObject(true)]
    public static class PackageDB
    {

        /// <summary>
        ///                   get all info from the table
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Package> GetAllPackage()
        {
            Package pkg = null;
            List<Package> pkgList = new List<Package>();
            // create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {

                // creat select command
                string query = "select PackageId, PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission from Packages order by PackageId";
                SqlCommand cmd = new SqlCommand(query, connection);

                // run the command, select query

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    // build Package object to return
                    while (reader.Read()) // if there is a Package with this ID
                    {

                        pkg = new Package();
                        pkg.PackageId = (int)reader["PackageId"];// not null
                        pkg.PkgName = reader["PkgName"].ToString(); // not null

                        pkg.PkgStartDate = ReadNullableData(reader, "PkgStartDate");// nullable
                        pkg.PkgEndDate = ReadNullableData(reader, "PkgEndDate");// nullable

                        pkg.PkgDesc = ReadNullableData(reader, "PkgDesc");// nullable

                        pkg.PkgBasePrice = (decimal)reader["PkgBasePrice"];//null

                        pkg.PkgAgencyCommission = ReadNullableData(reader, "PkgAgencyCommission");// nullable

                        pkgList.Add(pkg);
                    }

                    return pkgList;
                }
            }
        }// end of GetPackages

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Package GetPackageByID(int packageID)
        {
            Package pkg = new Package();
            // create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {

                // creat select command
                string query = "select PackageId, PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission from Packages " +
                               "where PackageId=@PackageId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PackageId", packageID);
                // run the command, select query

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {


                        pkg.PackageId = (int)reader["PackageId"];// not null
                        pkg.PkgName = reader["PkgName"].ToString(); // not null

                        pkg.PkgStartDate = ReadNullableData(reader, "PkgStartDate");// nullable
                        pkg.PkgEndDate = ReadNullableData(reader, "PkgEndDate");// nullable

                        pkg.PkgDesc = ReadNullableData(reader, "PkgDesc");// nullable

                        pkg.PkgBasePrice = (decimal)reader["PkgBasePrice"];//null

                        pkg.PkgAgencyCommission = ReadNullableData(reader, "PkgAgencyCommission");// nullable
                        break;


                    }
                    return pkg;
                }
            }
        }// end of GetPackage

        // delete a package and return a sign 
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static bool DeletePackage(Package pkg)
        {
            bool success = false;
            // connection
            SqlConnection connection = TravelExpertsDB.GetConnection();
            
                // create DELETE commond
                string deleteStatement = "DELETE FROM Packages WHERE PackageId = @PackageId " +// needed for identification
                    "AND PkgName=@PkgName " +
                    "AND (PkgStartDate=@PkgStartDate OR (PkgStartDate IS NULL AND @PkgStartDate IS NULL)) " +
                    "AND (PkgEndDate= @PkgEndDate  OR (PkgEndDate IS NULL AND @PkgEndDate IS NULL)) " +
                    "AND (PkgDesc=@PkgDesc OR (PkgDesc IS NULL AND @PkgDesc IS NULL)) " +
                    "AND PkgBasePrice=@PkgBasePrice " +
                    "AND (PkgAgencyCommission=@PkgAgencyCommission  OR (PkgAgencyCommission IS NULL AND @PkgAgencyCommission IS NULL))";
                SqlCommand cmd = new SqlCommand(deleteStatement, connection);
                try
                {
                    cmd.Parameters.AddWithValue("@PackageID", pkg.PackageId);
                    cmd.Parameters.AddWithValue("@PkgName", pkg.PkgName);

                    if (pkg.PkgStartDate == null)
                        cmd.Parameters.AddWithValue("@PkgStartDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgStartDate", pkg.PkgStartDate);

                    if (pkg.PkgEndDate == null)
                        cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgEndDate", pkg.PkgEndDate);

                    if (pkg.PkgDesc == null)
                        cmd.Parameters.AddWithValue("@PkgDesc", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PkgDesc", pkg.PkgDesc);

                    cmd.Parameters.AddWithValue("@PkgBasePrice", pkg.PkgBasePrice);

                    //if (pkg.PkgAgencyCommission == null)
                    //    cmd.Parameters.AddWithValue("@PkgAgencyCommission", DBNull.Value);
                    //else
                    //    cmd.Parameters.AddWithValue("@PkgAgencyCommission", pkg.PkgAgencyCommission);

                    AddWithValueNullable(cmd, "@PkgAgencyCommission", pkg.PkgAgencyCommission);

                    connection.Open();
                    // execute the command
                    int count = cmd.ExecuteNonQuery();
                    // check if successful
                    if (count > 0)
                        success = true;// check if successful
                    
                }
                catch
                {
                    success = false;
                    //throw new Exception("Concurrency is occured");
                }
                finally
                {
                    connection.Close();
                }
            
            return success;
        }// end of deletion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="original_Package"></param>
        /// <param name="package"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdatePackage(Package original_Package,
            Package package)
        {
            if (!ValidatePackage(package)) return -1;
            int success = -1;// not updated
            // connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create Update command
            // select PackageId, PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission

            string updateStatement = "UPDATE Packages SET PkgName=@NewPkgName, PkgStartDate=@NewPkgStartDate, PkgEndDate=@NewPkgEndDate, " +
                "PkgDesc=@NewPkgDesc, PkgBasePrice=@NewPkgBasePrice, PkgAgencyCommission=@NewPkgAgencyCommission " + //indetify customer
                "WHERE PackageId=@OldPackageId "
                + "AND PkgName=@OldPkgName ";
            //+ "AND PkgStartDate=@OldPkgStartDate "
            //+ "AND PkgEndDate=@OldPkgEndDate "
            //+ "AND PkgDesc=@OldPkgDesc "
            //+ "AND PkgBasePrice=@OldPkgBasePrice "
            //+ "AND PkgAgencyCommission=@OldPkgAgencyCommission "; // optimistic concurrency
            SqlCommand cmd = new SqlCommand(updateStatement, connection);

            // supply value
            cmd.Parameters.AddWithValue("@NewPkgName", package.PkgName);
            AddWithValueNullable(cmd, "@NewPkgStartDate", package.PkgStartDate);
            AddWithValueNullable(cmd, "@NewPkgEndDate", package.PkgEndDate);
            AddWithValueNullable(cmd, "@NewPkgDesc", package.PkgDesc);
            cmd.Parameters.AddWithValue("@NewPkgBasePrice", package.PkgBasePrice);
            AddWithValueNullable(cmd, "@NewPkgAgencyCommission", package.PkgAgencyCommission);

            cmd.Parameters.AddWithValue("@OldPackageId", original_Package.PackageId);
            cmd.Parameters.AddWithValue("@OldPkgName", original_Package.PkgName);
            AddWithValueNullable(cmd, "@OldPkgStartDate", original_Package.PkgStartDate);
            AddWithValueNullable(cmd, "@OldPkgEndDate", original_Package.PkgEndDate);
            AddWithValueNullable(cmd, "@OldPkgDesc", original_Package.PkgDesc);
            cmd.Parameters.AddWithValue("@OldPkgBasePrice", original_Package.PkgBasePrice);
            AddWithValueNullable(cmd, "@OldPkgAgencyCommission", original_Package.PkgAgencyCommission);

            try
            {
                connection.Open();
                //execute command
                int count = cmd.ExecuteNonQuery();

                //if successful
                if (count > 0)
                    success = count; // updated
            }
            catch (Exception ex)
            {
                throw ex;
                success = -1;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }


        // insert new row to table Packages
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddPackage(Package pkg)
        {
            if (!ValidatePackage(pkg)) return -1;
            int pkgID = 0;
            // creat connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create INSERT command
            // PackageID is IDENTITY so no value provided
            string insertStatement = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission) " +
                "OUTPUT inserted.PackageId " +
                "VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
            SqlCommand cmd = new SqlCommand(insertStatement, connection);

            cmd.Parameters.AddWithValue("@PkgName", pkg.PkgName);
            AddWithValueNullable(cmd, "@PkgStartDate", pkg.PkgStartDate);
            AddWithValueNullable(cmd, "@PkgEndDate", pkg.PkgEndDate);
            AddWithValueNullable(cmd, "@PkgDesc", pkg.PkgDesc);
            cmd.Parameters.AddWithValue("@PkgBasePrice", pkg.PkgBasePrice);
            AddWithValueNullable(cmd, "@PkgAgencyCommission", pkg.PkgAgencyCommission);

            try
            {
                connection.Open();
                // execute insert command and get inserted ID
                pkgID = (int)cmd.ExecuteScalar();

                //cmd.ExecuteNonQuery();

                // retrive generated pkgomer ID to return
                //string selectStatement = "SELECT IDENT_CURRENT('Packages')";
                //SqlCommand selectCmd = new SqlCommand(selectStatement, connection);
                //pkgID = Convert.ToInt32( selectCmd.ExecuteScalar()); // returns single value
                // (int) doesn't work in this case
            }

            catch (Exception ex)
            {
                // throw ex;
                pkgID = -1;
            }
            finally
            {
                connection.Close();
            }
            // return
            return pkgID;
        }


        // add value
        private static void AddWithValueNullable(SqlCommand cmd, string parameterName, object value)
        {
            if (value == null)
                cmd.Parameters.AddWithValue(parameterName, DBNull.Value);
            else
                cmd.Parameters.AddWithValue(parameterName, value);
        }

        private static List<T> DeleteRow<T>(List<T> original, int rowIndx)
        {
            if (original.Count > 0 && rowIndx <= original.Count)
            {
                original.RemoveAt(rowIndx);
                return original;
            }
            else
                return null;
        }



        /// <summary>
        ///                       read a nullable value from SqlDataReader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        private static dynamic ReadNullableData(SqlDataReader reader, string colName)
        {
            object colValue = reader[colName];

            //if (colValue is DBNull)
            //    return null;
            //return (T?)colValue;
            return (colValue == DBNull.Value ? null : colValue);
        }


        /// <summary>
        ///              easy reader all columns from a reader; will use later
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<T> Fill<T>(this SqlDataReader reader) where T : new()
        {
            List<T> res = new List<T>();
            while (reader.Read())
            {
                T t = new T();
                for (int inc = 0; inc < reader.FieldCount; inc++)
                {
                    Type type = t.GetType();
                    string name = reader.GetName(inc);
                    PropertyInfo prop = type.GetProperty(name);
                    if (prop != null)
                    {
                        if (name == prop.Name)
                        {
                            var value = reader.GetValue(inc);
                            if (value != DBNull.Value)
                            {
                                prop.SetValue(t, Convert.ChangeType(value, prop.PropertyType), null);
                            }
                            //prop.SetValue(t, value, null);

                        }
                    }
                }
                res.Add(t);
            }
            reader.Close();

            return res;
        }

        private static bool ValidatePackage(Package pkg)
        {
            return (pkg.PkgAgencyCommission > pkg.PkgBasePrice || 
                    pkg.PkgEndDate < pkg.PkgStartDate || 
                    pkg.PkgName == "" || 
                    pkg.PkgDesc == "") ? false : true;
        }

    }// end of class
}// end of namespace
