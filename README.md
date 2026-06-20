# Latest Version 1.0.4
https://github.com/Russell-KV4S/DMR.UserDB.RadioConverter/releases/download/v1.0.4/UserDB.RadioConverter.zip

Currently, the application supports the AnyTone, Radioddity GD-77 (unfiltered results), and TYT UV model radios.

Runs on .NET 10.

# DMR.UserDB.RadioConverter
Application to download the DMR User Database from RadioID.net and Convert it to a CSV file for import into a DMR Radio.

Contact me if you would like to add more and have the file specs or use Git and create your own and merge them back in.

Other than simply executing the application, you can control which CSV files are created for the radio types you have.
Edit the `appsettings.json` file located with the executable and use `Y`/`N` values to control the output.
```
{
  "URL": "https://database.radioid.net/static/users.json",
  "Unattended": "N",
  "AnyTone": "Y",
  "TYT-UV": "Y",
  "GD-77": "Y"
}
```

From the repository root, build the application locally with:
```
dotnet build UserDB.RadioConverter.sln
```

From the repository root, run the application with:
```
dotnet run --project KV4S.AmateurRadio.DMR.UserDB.RadioConverter/UserDB.RadioConverter.csproj
```

Since this is a console application, you can use Windows Task Scheduler to run it in the background on a schedule of your choosing.

The CSV files are written to the same location as the executable and are named:
```
AnyTone_Users.csv
GD-77_Users.csv
TYT-UV_Users.csv
```

Use your radios CPS to import and write to your radio.
