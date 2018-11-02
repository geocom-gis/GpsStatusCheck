# GpsStatusCheck Tools

This is a simple ASP.NET ConsoleApp, which displays the status of computer's location.
The location information may come from multiple providers, such as GPS, Wi-Fi triangulation, and cell phone tower triangulation. It uses the **System.Device.Location** library (see https://docs.microsoft.com/en-us/dotnet/api/system.device.location).

The alternative is to use the **DotSpatial.Positioning** library, which allow to conntect to any external Bluetooth or Serial GPS-Device (see https://www.nuget.org/packages/DotSpatial.Positioning/ and https://github.com/DotSpatial/DotSpatial).

For more information please contact: support@geocom.ch. 

#### DISCLAMER: Please be aware this product is not supported. Further information can be found in the license file.


------
## Requirements

* Installation of Visual Studio 2017

------
## Installation and compilation

1. Download the GpsStatusCheck Solution
2. Open the solution file in Visual Studio
3. Compile the application
4. Run the Watch.bat or Watch-HighPrecision.bat Batch to start the application.

------
## Help
Start the application using provided Batch:
1. *Watch.bat* - using default accuracy level for the location data
2. *Watch-HighPrecision.bat* - location delivers the most accurate data possible (may consume higher levels of battery power or connection bandwidth)

After the application has started, the status and position from the Location-Device are displayed in the console. 
The **movement threshold distance** was set to 0.5m - that's the distance that must be moved, relative to the coordinate from the last position, before another position is obtained.
```
GeoCoordinateWatcher try start...
 status is 'Initializing'
 status is 'NoData'
 status is 'Ready'
 status is 'Ready'
watching gps position.
 accuracy: 'Default'
 permission is 'Granted'
Enter any key to quit.

==== Position obtained: 01.11.2018 11:36:06 ====
     long(X)=7.61263319599455 lat=(Y)=47.0634826270549
     h-accuracy (m): 78.0
     v-accuracy (m): NaN
     altitude (m): 0.0
     speed (m/s): NaN
     course (°N): NaN
```
------
## Known issues

Currently none.
