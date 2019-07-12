using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace Data

{
    [DataObject(true)]
    public static class ProductsDB
    {
        //public static SqlConnection GetConnection()
        //    {
        //    string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog = TravelExperts; Integrated Security = True";
        //    //@ allows you to put the entire path
        //    //regardless of special characters
        //    return new SqlConnection(connectionString);
        //    }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Product> GetProducts()  //name in <> has to match a class name
        {
            List<Product> product = new List<Product>();  //empty list
            Product prod;  //for reading

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProductId, ProdName " +
                                "From Products " + //name in sqlserver database
                               "ORDER BY ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    // build product object to return
                    while (reader.Read())
                    {
                        prod = new Product();//empty
                        prod.ProductId = (int)reader["ProductId"];//fill with data from the reader
                        prod.ProdName = reader["ProdName"].ToString();
                        product.Add(prod); //adds prod to list
                    }
                }//cmd object recycled
            }
            return product;

        }


        //add product
        public static int AddNewProduct(Product p)
        {
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "insert into Products(ProdName) values(@ProductName)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductName", p.ProdName);

                    connection.Open();
                    int productId = (int)cmd.ExecuteNonQuery();

                    if (productId > 0)
                        return productId;
                    else return -1;
                }
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateProduct(Product original_Product, Product product)
        {
            int success = -1;// not updated
            // connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string updateStatement = "UPDATE Products " + " SET ProdName = @ProdName " +
                //identify customer
                "WHERE ProductId = @original_ProductId "
                + "AND ProdName = @original_ProdName";

            SqlCommand cmd = new SqlCommand(updateStatement, connection);

            // supply value


            cmd.Parameters.AddWithValue("ProdName", product.ProdName);
            cmd.Parameters.AddWithValue("original_ProdName", original_Product.ProdName);
            cmd.Parameters.AddWithValue("original_ProductId", original_Product.ProductId);

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
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void AddProduct(Product prod)
        {
            // create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create INSERT command
                // ProductID is IDENTITY so no value provided
                string query = "insert into Products(ProdName) values(@ProdName)";
                try
                {

                    if (prod.ProdName != null)
                    {
                        using (SqlConnection con = TravelExpertsDB.GetConnection())
                        {
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.Parameters.AddWithValue("ProdName", prod.ProdName);
                                //cmd.Parameters.AddWithValue("ProductId", prod.ProductId);
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
    }

}