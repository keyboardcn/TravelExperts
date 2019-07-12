using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;
using System.ComponentModel;

namespace Data
{
    [DataObject(true)]
    public class SuppliersDB
    {
        //public static int SupplierId { get; private set; }

        //public static SqlConnection GetConnection()  //method which needs a call and return  
        //    //this will be called in the StateDB (when connection needs to be made)
        //{
        //    string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog = TravelExperts; Integrated Security = True";  
        //    //@ allows you to put the entire path 
        //    //regardless of special characters
        //    return new SqlConnection(connectionString);
        //}
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Supplier> GetAllSuppliers()  //name in <> has to match a class name
        {
            List<Supplier> supplier = new List<Supplier>();  //empty list
            Supplier sup;  //for reading

            using (SqlConnection connection = TravelExpertsDB.GetConnection())

            {
                string query = "SELECT SupplierID, SupName " +
                               "FROM Suppliers " +
                               "ORDER by SupplierID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        sup = new Supplier(); //empty supplier object
                        //fill with data from the reader
                        sup.SupplierId = (int)reader["SupplierId"];
                        sup.SupName = reader["SupName"].ToString(); ;
                        supplier.Add(sup);  //add to the list
                    }
                } //cmd object recycled
            }//connection object recycled

            return supplier;

            //-----------------------
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Supplier> GetAllSuppliersHavingNoSpecificProduct(int productId)  //name in <> has to match a class name
        {
            List<Supplier> supplier = new List<Supplier>();  //empty list
            Supplier sup;  //for reading

            using (SqlConnection connection = TravelExpertsDB.GetConnection())

            {
                //string query = "SELECT SupplierID, SupName " +
                //               "FROM Suppliers " +
                //               "ORDER by SupplierID";

                string query = "SELECT DISTINCT SupplierId, SupName FROM Suppliers " +
                              "WHERE NOT EXISTS " +
                              "(SELECT* FROM Products_Suppliers " +
                              " WHERE Suppliers.SupplierId= Products_Suppliers.SupplierId AND ProductId = @ProductId) " +
                              " ORDER BY SupplierId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        sup = new Supplier(); //empty supplier object
                        //fill with data from the reader
                        sup.SupplierId = (int)reader["SupplierId"];
                        sup.SupName = reader["SupName"].ToString(); ;
                        supplier.Add(sup);  //add to the list
                    }
                } //cmd object recycled
            }//connection object recycled

            return supplier;

            //-----------------------
        }

        //add supplier

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void AddSupplier(Supplier sup)
        {
            // create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create INSERT command
                // SupplierID is IDENTITY so no value provided
                string query = "insert into Suppliers(SupplierId, SupName) values(@SupplierId, @SupName)";
                try
                {

                    if (sup.SupName != null)
                    {
                        using (SqlConnection con = TravelExpertsDB.GetConnection())
                        {
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.Parameters.AddWithValue("SupName", sup.SupName);
                                cmd.Parameters.AddWithValue("SupplierId", sup.SupplierId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }


        //public static bool DeleteSupplier(Supplier sup)
        //{
        //    bool success = false;

        //    // create connection
        //    using (SqlConnection connection = TravelExpertsDB.GetConnection())
        //    {

        //        // create DELETE command
        //        string deleteStatement1 =

        //        "DELETE FROM SupplierContacts " +
        //        "WHERE SupplierContactId = @SupplierContactId " + // needed for identification
        //        "AND SupConCompany = @SupConCompany "; // the rest - for optimistic concurrency

        //        SqlCommand cmd = new SqlCommand(deleteStatement1, connection);
        //        ////cmd.Parameters.AddWithValue("@SupplierContactId", sup.SupplierContactId);
        //        ////cmd.Parameters.AddWithValue("@SupConCompany", sup.SupConCompany);


        //        string deleteStatement2 =

        //        "DELETE FROM Suppliers " +
        //        "WHERE SupplierID = @SupplierID " + // needed for identification
        //        "AND SupName = @SupName "; // the rest - for optimistic concurrency

        //        SqlCommand cmd2 = new SqlCommand(deleteStatement2, connection);
        //        cmd.Parameters.AddWithValue("@SupplierId", sup.SupplierId);
        //        cmd.Parameters.AddWithValue("@SupName", sup.SupName);

        //        try
        //        {
        //            connection.Open();

        //            // execute the command
        //            int count = cmd.ExecuteNonQuery();
        //            int count2 = cmd2.ExecuteNonQuery();
        //            // check if successful
        //            if (count > 0)
        //                success = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return success;
        //}




        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateSupplier(Supplier original_Supplier, Supplier supplier)
        {
            int success = -1;// not updated
            // connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string updateStatement = "UPDATE Suppliers " +" SET SupName = @SupName " +
                //identify customer
                "WHERE SupplierId = @original_SupplierId "
                + "AND SupName = @original_SupName";

            SqlCommand cmd = new SqlCommand(updateStatement, connection);

            // supply value


            cmd.Parameters.AddWithValue("SupName", supplier.SupName);
            cmd.Parameters.AddWithValue("original_SupName", original_Supplier.SupName);
            cmd.Parameters.AddWithValue("original_SupplierId", original_Supplier.SupplierId);

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
            }
            finally
            {
                connection.Close();
            }

           // return success;
        }
    }


}




