CI Pipeline Build steps

2. Compile the solution and restore dependencies:
   cd solution-directory
   dotnet build WebShopTests.sln -c Release

2. Run tests
   cd solution-directory
   <directory>\vstest.console.exe WebShop.E2E.Tests\bin\Release\netcoreapp2.1\WebShop.E2E.Tests.dll /logger:ReportPortal /TestAdapterPath:C:\Users\<user>\.nuget\packages\<specrun-runner-folder>\tools\netcoreapp2.1

3. Kill browser processes

   e.g. for Chrome: taskkill /f /im chrome.exe
					taskkill /f /im chromedriver.exe


