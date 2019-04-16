# DMR.UserDB.RadioConverter
Application to download the DMR User Database and Convert it to a CSV file for import into a DMR Radio.

Currenly the Applicaiton supports the AnyTone and TYT UV Model Radios.

Contact me if you would like to add more and have the file specs or Git and create your own and merge them back in.

Other than simply executing the Application you can control what CSV files are created for the type(s) of radio you have.
Simple edit the .config file located with the executable and use Y/N to manipulate the application. 
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
  <appSettings>
    <add key="URL" value="https://www.radioid.net/static/users.json"/>
    <!--Y/N value only-->
    <add key="AnyTone" value="Y"/>
    <add key="TYT-UV" value="Y"/>
  </appSettings>
</configuration>
```

The CSV files are writen to the same location as the executable named:
```
AnyTone_Users.csv
TYT-UV_Users.csv
```

Since this is a console application you can use Windows Task Scheduler to run this in the backgroud on a schedule of your choosing.
Use your radios CPS to import and write to your radio.
