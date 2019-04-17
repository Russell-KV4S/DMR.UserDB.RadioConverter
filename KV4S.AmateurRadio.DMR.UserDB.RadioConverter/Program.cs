using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KV4S.AmateurRadio.DMR.UserDB.RadioConverter
{
    class Program
    {
        public static string URL = ConfigurationManager.AppSettings["URL"];
        public static UserList ul;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the DMR User Database CSV Converter Application by KV4S!");
                Console.WriteLine(" ");
                Console.WriteLine("Beginning download from " + URL);
                Console.WriteLine("Please Stand by.....");
                Console.WriteLine(" ");
                using (WebClient wc = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var json = wc.DownloadString(URL);
                    ul = JsonConvert.DeserializeObject<UserList>(json);
                    Console.WriteLine("Database download contains " + ul.users.Count + " unique IDs.");
                    if (ConfigurationManager.AppSettings["AnyTone"] ==  "Y")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Begin writing Anytone CSV file, Please Stand by.....");
                        SaveAnyToneCSV();
                    }
                    if (ConfigurationManager.AppSettings["TYT-UV"] == "Y")
                    {
                        Console.WriteLine("Begin writing TYT-UV CSV file, Please Stand by.....");
                        SaveTYTUVCSV();
                    }
                    if (ConfigurationManager.AppSettings["GD-77"] == "Y")
                    {
                        Console.WriteLine("Begin writing GD-77 CSV file, Please Stand by.....");
                        SaveGD77CSV();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Program encountered and error:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key on your keyboard to quit...");
                Console.ReadKey();
            }
        }

        public static void SaveAnyToneCSV()
        {
            string csvFile = Environment.CurrentDirectory + @"\AnyTone_Users.csv";
            FileInfo fi = new FileInfo(csvFile);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(csvFile, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            string data = "";
            sw.WriteLine("Radio,Radio ID,Callsign,Name,City,State,Country,Remarks,Call Type,Call Alert");
            int i = 1;
            foreach (User u in ul.users)
            {
                data = string.Concat(i, ",");
                data = string.Concat(data, u.radio_id, ",");
                data = string.Concat(data, u.callsign, ",");
                string[] strArrays = new string[] { data, u.name, " ", u.surname, "," };
                data = string.Concat(strArrays);
                data = string.Concat(data, u.city, ",");
                data = string.Concat(data, u.state, ",");
                data = string.Concat(data, u.country, ",");
                data = string.Concat(data, u.remarks, ",");
                data = string.Concat(data, "0,");
                sw.WriteLine(string.Concat(data, "0,"));
                i++;
            }
            sw.Close();
            fs.Close();
            Console.WriteLine(" ");
            Console.WriteLine("Converted CSV file located here: " + csvFile);
            Console.WriteLine(" ");
        }

        public static void SaveTYTUVCSV()
        {
            string csvFile = Environment.CurrentDirectory + @"\TYT-UV_Users.csv";
            FileInfo fi = new FileInfo(csvFile);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(csvFile, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            string data = "";
            sw.WriteLine("Radio ID,Callsign,Name,NickName,City,State,Country,,,,,,");
            foreach (User u in ul.users)
            {
                data = string.Concat(u.radio_id, ",");
                data = string.Concat(data, u.callsign, ",");
                string[] strArrays = new string[] { data, u.name, " ", u.surname, "," };
                data = string.Concat(strArrays);
                data = string.Concat(data, ",");
                data = string.Concat(data, u.city, ",");
                data = string.Concat(data, u.state, ",");
                data = string.Concat(data, u.country, ",");
                sw.WriteLine(string.Concat(data, ",,,,,"));
            }
            sw.Close();
            fs.Close();
            Console.WriteLine(" ");
            Console.WriteLine("Converted CSV file located here: " + csvFile);
            Console.WriteLine(" ");
        }

        public static void SaveGD77CSV()
        {
            string csvFile = Environment.CurrentDirectory + @"\GD-77_Users.csv";
            FileInfo fi = new FileInfo(csvFile);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(csvFile, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            string data = "";
            sw.WriteLine("Radio ID,Callsign,Name,NickName,City,State,Country,Remarks<br/>");
            foreach (User u in ul.users)
            {
                data = string.Concat(u.radio_id, ",");
                data = string.Concat(data, u.callsign, ",");
                string[] strArrays = new string[] { data, u.name, " ", u.surname, "," };
                data = string.Concat(strArrays);
                data = string.Concat(data, ",");
                data = string.Concat(data, u.city, ",");
                data = string.Concat(data, u.state, ",");
                data = string.Concat(data, u.country, ",");
                sw.WriteLine(string.Concat(data, "<br/>"));
            }
            sw.Close();
            fs.Close();
            Console.WriteLine(" ");
            Console.WriteLine("Converted CSV file located here: " + csvFile);
            Console.WriteLine(" ");
        }
    }
}
