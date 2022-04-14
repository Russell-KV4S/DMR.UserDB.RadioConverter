# Latest Version 1.0.3
https://github.com/Russell-KV4S/DMR.UserDB.RadioConverter/releases/download/v1.0.3/UserDB.RadioConverter.zip

Currently, the applicaiton supports the AnyTone, Radioddity GD-77 (unfiltered results), and TYT UV Model Radios.

Runs on .Net Framework 4.8 install here: https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48

# DMR.UserDB.RadioConverter
Application to download the DMR User Database from RadioID.net and Convert it to a CSV file for import into a DMR Radio.

Contact me if you would like to add more and have the file specs or use Git and create your own and merge them back in.

Other than simply executing the Application you can control what CSV files are created for the type(s) of radio you have.
Simple edit the .config file located with the executable and use Y/N to manipulate the application. 
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
  <appSettings>
    <add key="URL" value="https://database.radioid.net/static/users.json"/>
    <!--Set this to "Y" if you are scheduling this to run and don't need the console window to stay open.-->
    <add key="Unattended" value="N"/>
    <!--Y/N value only-->
    <add key="AnyTone" value="Y"/>
    <add key="TYT-UV" value="Y"/>
    <!--Manually filter your csv to just under 10k until I or someone builds something for filtering.-->
    <add key="GD-77" value="Y"/>
  </appSettings>
</configuration>
```

Since this is a console application you can use Windows Task Scheduler to run this in the backgroud on a schedule of your choosing.

The CSV files are writen to the same location as the executable named:
```
AnyTone_Users.csv
GD-77_Users.csv
TYT-UV_Users.csv
```

Use your radios CPS to import and write to your radio.
