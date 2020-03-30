# Math Recognition example for Windows wpf
This example app shows how to recognize mathematical expressions using the **Selvy Pen SDK for Math** on Windows

## Prerequisite
1. Microsoft Visual Studio 2015 above
1. Microsoft .NET Framework 4.5.2 above
1. NuGet Package: [WpfMath v0.8.0](https://www.nuget.org/packages/WpfMath/0.8.0) (.NET library for rendering mathematical formula)

## Getting started
1. Download **Selvy Pen SDK for Math** and License key  
   go to [http://handwriting.selvasai.com/math/download.html](http://handwriting.selvasai.com/math/download.html)
1. Place *libspmath.dll* in `mathRecognitionExample/bin/Debug|Release` or `mathRecognitionExample/bin/x64/Debug|Release` 
1. Place *.hdb files in `mathRecognitionExample/bin/Debug|Release/hdb` or `mathRecognitionExample/bin/x64/Debug|Release/hdb`
1. Place a License file in `mathRecognitionExample/bin/Debug|Release/license_key` or `mathRecognitionExample/bin/x64/Debug|Release/license_key`
1. Open mathRecognitionExample.sln and build this project in Microsoft Visual Studio

## Documentation
The **Selvy Pen SDK for Math** API documentation is available on [Selvy Pen SDK website](http://handwriting.selvasai.com/math)

## Screenshot
* Launch example app  
![](/screenshot-1.png)

* Write mathematical expressions 
![](/screenshot-2.png)

* Result  
![](/screenshot-3.png)

## License
- Math Recognition example: © 2020. [SELVAS AI Inc.](http://www.selvasai.com) All Rights Reserved.
- WpfMath: [MIT](https://licenses.nuget.org/MIT)
