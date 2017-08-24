using System;
using System.Data;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace BuggyBits.Models
{
    /// <summary>
    /// Summary description for DataLayer
    /// </summary>
    public class DataLayer
    {
        private object syncobj = new Object();

        //This method gets all users and serializes the data the same way that 
        //a webservice would in order to simulate what would have happened if this dataset was 
        //returned by a webservice.
        public DataSet GetAllUsers()
        {
            //populate a table with the featured products
            DataTable dt = new DataTable();
            DataRow dr;
            DataColumn dc;

            dc = new DataColumn("ID", typeof(Int32));
            dc.Unique = true;
            dt.Columns.Add(dc);

            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            dt.Columns.Add(new DataColumn("UserName", typeof(string)));
            dt.Columns.Add(new DataColumn("IsUserAMemberOfTheAdministratorsGroup", typeof(string)));

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            for (int i = 0; i < 10000; i++)
            {
                dr = dt.NewRow();
                dr["id"] = i;
                dr["FirstName"] = "Jane";
                dr["LastName"] = "Doe";
                dr["UserName"] = "jd";
                dr["IsUserAMemberOfTheAdministratorsGroup"] = "No";
                dt.Rows.Add(dr);
            }

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(ms, ds);
            }
            catch (SerializationException ex)
            {
                //should do something with the exception here
                throw ex;
            }
            finally
            {
                ms.Close();
            }
            return ds;
        }

        public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataColumn dc;

            dc = new DataColumn("ID", typeof(Int32));
            dc.Unique = true;
            dt.Columns.Add(dc);

            dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));

            for (int i = 0; i < 10000; i++)
            {
                dr = dt.NewRow();
                dr["id"] = i;
                dr["ProductName"] = "Product " + i;
                dr["Description"] = "Description for Product " + i;
                dr["Price"] = "$100";
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public Product GetProductInfo(string ProductName)
        {
            Product p = new Product();
            ShippingInfo s = new ShippingInfo();

            p.ProductName = ProductName;
            s.Distributor = "Buggy Bits";
            s.DaysToShip = 5;
            p.shippingInfo = s;

            Type[] extraTypes = new Type[1];
            extraTypes[0] = typeof(ShippingInfo);

            MemoryStream ms = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(Product), extraTypes);
            xs.Serialize(ms, p);

            //Here we would save the data off to some xml file or similar but i'm skipping this part

            ms.Close();

            return p;

        }

        public DataTable GetFeaturedProducts()
        {
            lock (syncobj)
            {
                //faking a long running query to the database
                Thread.Sleep(5000);

                //populate a table with the featured products
                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add(new DataColumn("Product Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Description", typeof(string)));
                dt.Columns.Add(new DataColumn("Price", typeof(string)));

                dr = dt.NewRow();
                dr[0] = "Get out of meeting free card";
                dr[1] = "May be kept until needed or sold";
                dr[2] = "$500";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = "Solitaire cheat kit";
                dr[1] = "Tired of not being able to finish your spider solitaire? this is the kit for you";
                dr[2] = "$4999";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = "Bugspray";
                dr[1] = "Why use a debugger when you can use bugspray?";
                dr[2] = "$250.99";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = "In case of emergency push button";
                dr[1] = "Excellent for any type of emergency";
                dr[2] = "$1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = "Vanity plate";
                dr[1] = "Now available in 3 different colors and 5 different shapes";
                dr[2] = "£33";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = "w00t baseball cap";
                dr[1] = "Nothing will scare the other team as much as a w00t cap";
                dr[2] = "$345";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = "Extra base";
                dr[1] = "Are all your base belong to us? Purchase extra base upgrade";
                dr[2] = "$22";
                dt.Rows.Add(dr);

                return dt;
            }
        }
    }


    public class Product
    {
        public string ProductName;
        public ShippingInfo shippingInfo;

        public Product()
        {
        }
    }

    public class ShippingInfo
    {
        public string Distributor;
        public int DaysToShip;

        public ShippingInfo()
        {
        }
    }
}