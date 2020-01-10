
MarineTraffic.NET
====================

**Unofficial .NET library for [MarineTraffic.com](https://www.marinetraffic.com/)'s [API](https://www.marinetraffic.com/en/ais-api-services). **

**Project status: experimental. **

License: *not yet decided*

Nuget: [MarineTrafficApi](https://www.nuget.org/packages/MarineTrafficApi/)


Usage
------------------------------

- Add a nuget reference to:  `MarineTrafficApi`
- Create a client object and keep it across calls.  
  `var client = new MarineTrafficApiClient("your-api-key");`
- Create a request for you needs  
  `var request = new ExportVesselsV8Request(); ...`
- Execute the request to get the result  
  `var result = request.Execute(client);`
- Always check for errors  
  `if (result.Succeed) { ... } else { /* display result.Errors */ }`


Frequently asked questions
------------------------------

Where can I get an API key? 

- See [MT credits](https://www.marinetraffic.com/en/online-services/marinetraffic-credits).

Something is missing in this library, can I contribute? Yes. Here are the main steps.

- [Fork](https://help.github.com/en/github/getting-started-with-github/fork-a-repo) this repository. 
- [Clone your fork](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository-from-github) on your PC. 
- [Make a branch](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-and-deleting-branches-within-your-repository) for you new feature with a name like: `dev/*new-feature-title*`
- Code your feature. 
    - Coding style is StyleCop's. 
- Commit and [push](https://help.github.com/en/github/using-git/pushing-commits-to-a-remote-repository) your changes on your fork. 
- [Submit a pull request](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request) on this repo to discuss and share your changes.

Why use the CSV export format? 

- CSV is the most lightweight format available. It works real well for objects without an important structure tree. 


