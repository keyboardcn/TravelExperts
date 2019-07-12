using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [DataObject(true)]
    public class ProductSupplierDetailDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<ProductSupplierDetail> GetAllProductSupplierDetails()
        {
            List<ProductSupplierDetail> psList = new List<ProductSupplierDetail>();
            ProductSupplierDetail ps;

            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create SELECT command
            //string query = "SELECT ProductSupplierId, ProductId, SupplierId "
            //                + "From Products_Suppliers " +
            //               "ORDER BY ProductSupplierId";

            string query = "SELECT ps.ProductSupplierId, ps.ProductId, p.ProdName, ps.SupplierId, s.SupName " +
                            "FROM Products_Suppliers ps " +
                            "JOIN Products p ON p.ProductId = ps.ProductId " +
                            "JOIN Suppliers s ON s.SupplierId = ps.SupplierId " +
                            "ORDER BY ps.ProductId, ps.ProductSupplierId, s.SupName";
            SqlCommand cmd = new SqlCommand(query, connection);

            // run the SELECT query

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build ProductSupplier object to return
            while (reader.Read()) // if there is a ProductSupplier with this ID
            {
                ps = new ProductSupplierDetail();
                ps.ProductSupplierId = (int)reader["ProductSupplierId"];
                ps.ProductId = (int)reader["ProductId"];
                ps.ProdName = (string)reader["ProdName"];
                ps.SupplierId = (int)reader["SupplierId"];

                ps.SupName = (string)reader["SupName"];
                psList.Add(ps);

            }

            return psList;

        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteProductSupplierDetail(ProductSupplierDetail ps)
        {
            int count = -1;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deletQuery = "DELETE FROM Products_Suppliers " +
                                "WHERE ProductSupplierId=@ProductSupplierId ";

            SqlCommand cmd = new SqlCommand(deletQuery, connection);
            //cmd.Parameters.AddWithValue("@PackageId", pps.PackageId);
            cmd.Parameters.AddWithValue("@ProductSupplierId", ps.ProductSupplierId);
            try
            {
                connection.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw ex;
                count = -1; // unsuccessful deletion
            }
            finally
            {
                connection.Close();
            }
            return count;
        }
    }
}
