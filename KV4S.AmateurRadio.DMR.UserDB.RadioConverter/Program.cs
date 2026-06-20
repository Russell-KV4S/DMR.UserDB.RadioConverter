using System.Text;
using System.Text.Json;

namespace KV4S.AmateurRadio.DMR.UserDB.RadioConverter;

class Program
{
    static async Task Main(string[] args)
    {
        var configJson = await File.ReadAllTextAsync("appsettings.json");
        var config = JsonSerializer.Deserialize<Dictionary<string, string>>(configJson)!;
        string url = config["URL"];

        try
        {
            Console.WriteLine("Welcome to the DMR User Database CSV Converter Application by KV4S!");
            Console.WriteLine();
            Console.WriteLine($"Beginning download from {url}");
            Console.WriteLine("Please Stand by.....");
            Console.WriteLine();

            using var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var ul = JsonSerializer.Deserialize<UserList>(json, options)!;

            Console.WriteLine($"Database download contains {ul.users.Count} unique IDs.");

            if (config.GetValueOrDefault("AnyTone") == "Y")
            {
                Console.WriteLine();
                Console.WriteLine("Begin writing Anytone CSV file, Please Stand by.....");
                SaveAnyToneCSV(ul);
            }
            if (config.GetValueOrDefault("TYT-UV") == "Y")
            {
                Console.WriteLine("Begin writing TYT-UV CSV file, Please Stand by.....");
                SaveTYTUVCSV(ul);
            }
            if (config.GetValueOrDefault("GD-77") == "Y")
            {
                Console.WriteLine("Begin writing GD-77 CSV file, Please Stand by.....");
                SaveGD77CSV(ul);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Program encountered an error:");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (config.GetValueOrDefault("Unattended") == "N")
            {
                Console.WriteLine("Press any key on your keyboard to quit...");
                Console.ReadKey();
            }
        }
    }

    static void SaveAnyToneCSV(UserList ul)
    {
        string csvFile = Path.Combine(Environment.CurrentDirectory, "AnyTone_Users.csv");
        using var sw = new StreamWriter(csvFile, false, Encoding.UTF8);
        sw.WriteLine("No.,Radio ID,Callsign,Name,City,State,Country,Remarks,Call Type,Call Alert");
        int i = 1;
        foreach (var u in ul.users)
        {
            sw.WriteLine($"{i},{u.radio_id},{u.callsign},{u.fname} {u.surname},{u.city},{u.state},{u.country},{u.remarks},0,0,");
            i++;
        }
        Console.WriteLine();
        Console.WriteLine($"Converted CSV file located here: {csvFile}");
        Console.WriteLine();
    }

    static void SaveTYTUVCSV(UserList ul)
    {
        string csvFile = Path.Combine(Environment.CurrentDirectory, "TYT-UV_Users.csv");
        using var sw = new StreamWriter(csvFile, false, Encoding.UTF8);
        sw.WriteLine("Radio ID,Callsign,Name,NickName,City,State,Country,,,,,,");
        foreach (var u in ul.users)
        {
            sw.WriteLine($"{u.radio_id},{u.callsign},{u.fname} {u.surname},,{u.city},{u.state},{u.country},,,,,");
        }
        Console.WriteLine();
        Console.WriteLine($"Converted CSV file located here: {csvFile}");
        Console.WriteLine();
    }

    static void SaveGD77CSV(UserList ul)
    {
        string csvFile = Path.Combine(Environment.CurrentDirectory, "GD-77_Users.csv");
        using var sw = new StreamWriter(csvFile, false, Encoding.UTF8);
        sw.WriteLine("Radio ID,Callsign,Name,NickName,City,State,Country,Remarks<br/>");
        foreach (var u in ul.users)
        {
            sw.WriteLine($"{u.radio_id},{u.callsign},{u.fname} {u.surname},,{u.city},{u.state},{u.country},<br/>");
        }
        Console.WriteLine();
        Console.WriteLine($"Converted CSV file located here: {csvFile}");
        Console.WriteLine();
    }
}
