CI Pipeline Build steps

2. Compile the solution and restore dependencies:
   cd solution-directory
   dotnet build WebShopTests.sln -c Release

2. Run tests
   cd solution-directory
   dotnet test WebShopTests.sln -c Release --filter <Expression>

3. Kill browser processes

   e.g. for Chrome: taskkill /f /im chrome.exe
					taskkill /f /im chromedriver.exe
