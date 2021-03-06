﻿using System;
using System.Data;
using System.Data.SqlClient;

// Assignment 6 .net
public class SqlCommandDemo
{
    // Declare Sql Conncetion and name it conn
    SqlConnection conn;

    public SqlCommandDemo()
    {
        // Instantiate the connection, had a lot of trouble with this, the string connection for the database was different then what was needed
        conn = new SqlConnection("Data Source = lugh4.it.nuigalway.ie; Initial Catalog = msdb2782; Persist Security Info = True; UID=msdb2782; Password = msdb2782JO");
    }

    // call methods that demo SqlCommand capabilities
    static void Main()
    {
        SqlCommandDemo scd = new SqlCommandDemo();

        Console.WriteLine();
        Console.WriteLine("Customers Before Insert");
        Console.WriteLine("------------------------");
        Console.ReadKey();
        // use ExecuteReader method
        scd.ReadData();

        //Insert method 
        scd.Insertdata();
        Console.WriteLine();
        Console.WriteLine("Customers After Insert");
        Console.WriteLine("------------------------------");
        Console.ReadKey();
        scd.ReadData();

        // Update method
        scd.UpdateData();

        Console.WriteLine();
        Console.WriteLine("Customers After Update");
        Console.WriteLine("------------------------------");
        Console.ReadKey();
        scd.ReadData();

        //Delete method 
        scd.DeleteData();

        Console.WriteLine();
        Console.WriteLine("Customers After Delete");
        Console.WriteLine("------------------------------");
        Console.ReadKey();
        scd.ReadData();

        // use Count method
        int numberOfRecords = scd.GetNumberOfRecords();
        Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine("Number of Records: {0}", numberOfRecords);
        Console.ReadKey();

        // use Count method
        int meanOfItems = scd.GetmeanOfItems();
        Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine("Mean Of Shopping Basket: {0}c", meanOfItems);
        Console.ReadKey();

        // use Min method
        int minOfItems = scd.GetMinOfItems();
        Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine("Minimum Price Of Shopping Basket: {0}c", minOfItems);
        Console.ReadKey();

        // use Max method
        int maxOfItems = scd.GetMaxOfItems();
        Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine("Maximum Price Of Shopping Basket: {0}c", maxOfItems);
        Console.ReadKey();
    }

    //Read Data
    public void ReadData()
    {
        SqlDataReader rdr = null;

        try
        {
            // Open the connection
            conn.Open();

            // 1. Instantiate a new command with a query and connection
            SqlCommand cmd = new SqlCommand("select * from Customers", conn);

            // 2. Call Execute reader to get query results
            rdr = cmd.ExecuteReader();

            // print the records
            {
                Console.WriteLine("Customer ID\tName\tPhone Number\t\t");
                while (rdr.Read())
                {
                    Console.WriteLine(String.Format("{0} \t | {1}   |{2} \t",
                        rdr[0], rdr[1], rdr[2]));
                }
            }
        }
        finally
        {
            // close the reader
            if (rdr != null)
            {
                rdr.Close();
            }

            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
    }

    //Insert command
    public void Insertdata()
    {
        try
        {
            // Open the connection
            conn.Open();

            // prepare command string
            string insertString = @"
                 insert into Customers
                 (ID,Name, PhoneNo)
                 values (123234345,'John', 034535382)";

            // 1. Instantiate a new command with a query and connection
            SqlCommand cmd = new SqlCommand(insertString, conn);

            // 2. Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();
        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
    }

    //Update Command
    public void UpdateData()
    {
        try
        {
            // Open the connection
            conn.Open();

            // prepare command string
            string updateString = @"
                update Customers
                set Name = 'Other'
                where Name = 'John'";

            // 1. Instantiate a new command with command text only
            SqlCommand cmd = new SqlCommand(updateString);

            // 2. Set the Connection property
            cmd.Connection = conn;

            // 3. Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();
        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
    }


    // Delete Command

    public void DeleteData()
    {
        try
        {
            // Open the connection
            conn.Open();

            // prepare command string
            string deleteString = @"
                 delete from Customers
                 where Name = 'Other'";

            // 1. Instantiate a new command
            SqlCommand cmd = new SqlCommand();

            // 2. Set the CommandText property
            cmd.CommandText = deleteString;

            // 3. Set the Connection property
            cmd.Connection = conn;

            // 4. Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();
        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
    }

    //Count number of records 
    public int GetNumberOfRecords()
    {
        int count = -1;

        try
        {
            // Open the connection
            conn.Open();

            // 1. Instantiate a new command
            SqlCommand cmd = new SqlCommand("select count(*) from Customers", conn);

            // 2. Call ExecuteScalar to send command
            count = (int)cmd.ExecuteScalar();
        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
        return count;
    }

    public int GetmeanOfItems()
    {
        int mean;

        try
        {
            // Open the connection
            conn.Open();

            // 1. Instantiate a new command
            SqlCommand cmd = new SqlCommand("SELECT AVG(Price) AS PriceAverage FROM groceryBasket", conn);



            // 2. Call ExecuteScalar to send command
            mean = (int)cmd.ExecuteScalar();

        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
        return mean;
    }

    public int GetMinOfItems()
    {
        int min;

        try
        {
            // Open the connection
            conn.Open();

            // 1. Instantiate a new command
            SqlCommand cmd = new SqlCommand("SELECT MIN(Price) AS PriceAverage FROM groceryBasket", conn);



            // 2. Call ExecuteScalar to send command
            min = (int)cmd.ExecuteScalar();

        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
        return min;
    }

    public int GetMaxOfItems()
    {
        int max;

        try
        {
            // Open the connection
            conn.Open();

            // 1. Instantiate a new command
            SqlCommand cmd = new SqlCommand("SELECT MAX(Price) AS PriceAverage FROM groceryBasket", conn);



// 2. Call ExecuteScalar to send command
max = (int)cmd.ExecuteScalar();

        }
        finally
        {
            // Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
        return max;
    }
}