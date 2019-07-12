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
    [DataObject(true)]
    public class PackageProductSupplierDB
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<PackageProductSupplier> GetAllPackageProductSuppliers()
        {
            List<PackageProductSupplier> ppsList = new List<PackageProductSupplier>();
            PackageProductSupplier pps;

            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create SELECT command
            string query = "SELECT PackageId, ProductSupplierId "
                            + "From Packages_Products_Suppliers " +
                           "ORDER BY PackageId";
            SqlCommand cmd = new SqlCommand(query, connection);

            // run the SELECT query

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build ProductSupplier object to return
            while (reader.Read()) // if there is a ProductSupplier with this ID
            {
                pps = new PackageProductSupplier();
                pps.PackageId = (int)reader["PackageId"];
                pps.ProductSupplierId = (int)reader["ProductSupplierId"];

                ppsList.Add(pps);

            }

            return ppsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<PackageProductSupplier> GetPackageProductSuppliersByPackageId(int packageId)
        {
            List<PackageProductSupplier> ppsList = new List<PackageProductSupplier>();
            PackageProductSupplier pps;

            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create SELECT command
            string query = "SELECT PackageId, ProductSupplierId "
                            + "From Packages_Products_Suppliers " +
                           "where PackageId=@PackageId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PackageId", packageId);

            // run the SELECT query

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build ProductSupplier object to return
            while (reader.Read()) // if there is a ProductSupplier with this ID
            {
                pps = new PackageProductSupplier();
                pps.PackageId = (int)reader["PackageId"];
                pps.ProductSupplierId = (int)reader["ProductSupplierId"];

                ppsList.Add(pps);

            }

            return ppsList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static void GetPackageProductSupplierDetailByPackageIdToGridview(int packageId, GridView gv)
        {

            // create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create SELECT command
            string query = "SELECT pps.PackageId, pps.ProductSupplierId, p.PkgName, Products.ProdName, Suppliers.SupName " +
                           " FROM Packages_Products_Suppliers pps " +
                           " JOIN Packages p ON pps.PackageId = p.PackageId " +
                           " JOIN Products_Suppliers ps ON ps.ProductSupplierId = pps.ProductSupplierId " +
                           " JOIN Products ON Products.ProductId = ps.ProductId " +
                           " JOIN Suppliers ON Suppliers.SupplierId = ps.SupplierId " +
                           " WHERE pps.PackageId = @PackageId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PackageId", packageId);

            // run the SELECT query

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build ProductSupplier object to return
            gv.DataSource = reader;
            gv.DataBind();
            connection.Close();


        }

        // insert new row to table PackagesProductSupplier
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddPackageProductSupplier(PackageProductSupplier pps)
        {
            int count = -1;
            // creat connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // create INSERT command
            string insertStatement = "insert into Packages_Products_Suppliers (PackageId, ProductSupplierId) "
                                    + "values (@PackageId, @ProductSupplierId)";
            SqlCommand cmd = new SqlCommand(insertStatement, connection);

            cmd.Parameters.AddWithValue("@PackageId", pps.PackageId);
            cmd.Parameters.AddWithValue("@ProductSupplierId", pps.ProductSupplierId);


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

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeletePackageProductSupplier(PackageProductSupplier pps)
        {
            int count = -1;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deletQuery = "DELETE FROM Packages_Products_Suppliers " +
                                "WHERE PackageId=@PackageId AND " +
                                "ProductSupplierId=@ProductSupplierId";
            SqlCommand cmd = new SqlCommand(deletQuery, connection);
            cmd.Parameters.AddWithValue("@PackageId", pps.PackageId);
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

    }
}
