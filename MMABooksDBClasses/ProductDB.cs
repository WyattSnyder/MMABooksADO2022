using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;
using MySqlX.XDevAPI.Relational;
using System.Security.Cryptography.X509Certificates;
//using System.Linq.Expressions;
//using System.Security.Cryptography.X509Certificates;
//using Org.BouncyCastle.Asn1.X509;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {

        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products"
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.OnHandsQuantity = (int)prodReader["OnHandsQuantity"];
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = prodReader["UnitPrice"].ToString();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

            public static int AddProduct(Product product)
            {
                MySqlConnection connection = MMABooksDB.GetConnection();
                string insertStatement
                    = "INSERT Products "
                    + "FROM ProductCode, Description, UnitPrice "
                    + "Values (@ProductCode, @Description, @UnitPrice)";
                MySqlCommand insertCommand =
                    new MySqlCommand(insertStatement, connection);
                insertCommand.Parameters.AddWithValue(
                    "@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                    "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                    "@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue(
                    "@OnHandQuantity", product.OnHandsQuantity);
                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    int onHandsInventory = Convert.ToInt32(insertCommand.ExecuteScalar());
                    return onHandsInventory;
                }
                catch (MySqlException ex) 
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
             }
        public static bool DeleteProduct(Product product) 
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "Where ProductCode = @ProductCode, " +
                "AND Description = @Description, " +
                "AND UnitPrice = @UnitPrice, " +
                "AND OnHandQuantity = @OnHandQuantity";
            MySqlCommand deleteCommand
                = new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", Product.ProductCode);
            try
            {
                connection.Open();
                int affectedRows = deleteCommand.ExecuteNonQuery();
                return affectedRows == 1;
            }
            catch (MySqlException ex) 
            {
                throw new ArgumentException("Cannot delete Product");
            }
            finally 
            { 
                connection.Close(); 
            }
        }
        
        public static bool UpdateProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Poducts SET" +
                "ProductCode = @NewProductCode, " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity, " +
                "WHERE ProductCode = @OldProductCode, " +
                "AND Description = @OldDescription, " +
                "And UnitPrice = @OldUnitPrice, " +
                "And OnHandQuantity = @OldOnHandQuantity";
            MySqlCommand UpdateCommand
                = new MySqlCommand(updateStatement, connection);
            try
            {
                connection.Open();
                if (oldProduct != newProduct)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException("Unable to Update Product");
            }
            finally 
            { 
                connection.Close();
            }
        }
    }
}
