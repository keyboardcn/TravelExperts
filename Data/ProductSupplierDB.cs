using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Data
{
    public static class ProductSupplierDB
    {
        public static List<ProductSupplier> GetAllProductSuppliers()
        {
            List<ProductSupplier> psList = new List<ProductSupplier>();
            ProductSupplier ps;

            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create SELECT command
            string query = "SELECT ProductSupplierId, ProductId, SupplierId "
                            + "From Products_Suppliers " +
                           "ORDER BY ProductSupplierId";
            SqlCommand cmd = new SqlCommand(query, connection);

            // run the SELECT query

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build ProductSupplier object to return
            while (reader.Read()) // if there is a ProductSupplier with this ID
            {
                ps = new ProductSupplier();
                ps.ProductSupplierId = (int)reader["ProductSupplierId"];
                ps.ProductId = (int)reader["ProductId"];
                ps.SupplierId = (int)reader["SupplierId"];
                psList.Add(ps);

            }

            return psList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static void GetProductSupplierDetailByProductSupplierIdToGridview(int productId, GridView gv)
        {

            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create SELECT command
            string query = "SELECT  pps.ProductSupplierId, pps.ProductId, Suppliers.SupName, Products.ProdName " +
                           " FROM Products_Suppliers pps" +
                           " JOIN Products ON Products.ProductId = pps.ProductId " +
                           " JOIN Suppliers ON Suppliers.SupplierId = pps.SupplierId " +
                           " WHERE pps.ProductId = @ProductId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            // run the SELECT query

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build ProductSupplier object to return
            gv.DataSource = reader;
            gv.DataBind();
            connection.Close();


        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteProductSupplier(ProductSupplier pps)
        {
            int count = -1;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deletQuery = "DELETE FROM Products_Suppliers " +
                                "WHERE ProductSupplierId=@ProductSupplierId ";
                                
            SqlCommand cmd = new SqlCommand(deletQuery, connection);
            //cmd.Parameters.AddWithValue("@PackageId", pps.PackageId);
            cmd.Parameters.AddWithValue("@ProductSupplierId", pps.ProductSupplierId);
            try
            {
                connection.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return count;
        }
        //SELECT  pps.ProductSupplierId, pps.ProductId, Suppliers.SupName, Products.ProdName
        //FROM Products_Suppliers pps
        // JOIN Products ON Products.ProductId = pps.ProductId
        //JOIN Suppliers ON Suppliers.SupplierId = pps.SupplierId

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddProductSupplier(ProductSupplier ps)
        {
            int count = -1;
            // creat connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create INSERT command
            string insertStatement = "insert into Products_Suppliers (ProductId, SupplierId) "
                                    + "values (@ProductId, @SupplierId)";
            SqlCommand cmd = new SqlCommand(insertStatement, connection);

            cmd.Parameters.AddWithValue("@ProductId", ps.ProductId);
            cmd.Parameters.AddWithValue("@SupplierId", ps.SupplierId);


            try
            {
                connection.Open();
                // execute insert command and get inserted ID
                //cmd.ExecuteScalar();

                count = cmd.ExecuteNonQuery();

                // retrive generated pkgomer ID to return
                //string selectStatement = "SELECT IDENT_CURRENT('Packages')";
                //SqlCommand selectCmd = new SqlCommand(selectStatement, connection);
                //pkgID = Convert.ToInt32( selectCmd.ExecuteScalar()); // returns single value
                // (int) doesn't work in this case
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            // return
            return count;
        }
    }
}
