## CIE-API-Access
This GitHub project consolidates documentation and feedback for CSI's Construction Information Exchange Web API service.

Included will also be a .NET solution that shows how one might access the API through code.  This solution and downloadable library are available on an open license and can be used directly within your commercial project or as a guide for creating your own software.  See the License file in this project for more details.

This Readme will be updated according to the current status of the API service.

### The CIE API service is currently in the beta testing phase.
- Only those organizations or individuals who have been accepted as beta testers will be able to use the service at this time.  [Contact CSI](mailto:omniclassbeta@csinet.org) regarding becoming a beta tester.
- Errors, slow response times, and unfinished features are to be expected;  Please help us to improve the service by reporting problems in our [issues section](https://github.com/csi-net/CIE-API-Access/issues), using the "bug" label.
- New features and improvements to existing features are still being considered.  Please submit any suggestions to our [issues section](https://github.com/csi-net/OmniClassBeta/issues), using the "enhancement" label.
- Existing features are subject to change or removal.  Such modifications will be noted on this document in addition to email notifications.

**All beta testers will receive an API Key** that is required when sending API requests.  This allows us to authenticate users and track utilization.  *(Please note: API keys are used only to access the CIE API services and cannot be used by anyone to access any other personal or organizational information in any other CSI system.)*

The following list describes what is available **now** through the API:
- MasterFormat - All classifications, their hierarchy, properties, and version history
- MasterFormat1995 - A legacy table containing Number-Titles, their hierarchy, and transition information to modern MasterFormat versions
- OmniClass - All tables, classifications, their hierarchy, properties.  Only current versions of tables are supported at this time.

*(Properties include numbers, titles, descriptions, and (eventually) links to relevant objects within other classification systems.  Properties and links will be added as development and testing proceed.)*  
*(Each classification object at every level can provide its immediate children, and parent objects.)*  
*(Release status, publication date, and version numbers are all available for each Table.)*

We are working to implement the following in the future:
- UniFormat
- API request filters for gathering, searching, and using information.

### CIE_API_Access.dll
CIE_API_Access will be a .NET package that provides an easy way to access the CIE API. You are free to use this library in your commercial projects. See the license file in this repository for more details.

- When it becomes available, Download CIE_API_Access.dll from this repository and add it as a reference in your .NET project.
- Included will be a class that exposes all implemented API endpoints and Response classes that encapsulate the returned data.
- The source code in will be provided as a reference.

### Direct API Access
There are many ways to access the API without linking to CIE_API_Access.dll.

Please see our documentation at getpostman.com for examples of the endpoints available and example responses:
https://documenter.getpostman.com/view/7286040/S1TbRZqt

All requests require the authorization header to have a value like the following:  
**bearer rA3C/LkhY5okP6O2k7Wj2KkGLTFJTkJP+TCo5DeWUUbT3HdwtCi/XmAQGI88aQj5HyCADPp7rJmq4TSF6x9LRw**

Where "bearer" is required to identify the type of token and the rest is the exact API key that is distributed to your project when accepted into the beta.

**JSON or XML?** Responses default to JSON as a payload format.  Any request can be modified to return a response in XML by including the "Accept" header with a value of "application/xml".

### API Endpoints Currently Available

The following endpoints are implemented.  More documentation will appear here as specifics become available.

- Get All Standards in the database
https://cie.csinet.org/api/specifications

- Get a specific Standard  
https://cie.csinet.org/api/specifications/1

- Get a specific version of a Standard
https://cie.csinet.org/api/specificationversions/1

- Get All Tables in the database
https://cie.csinet.org/api/tables

- Get a specific Table  
https://cie.csinet.org/api/tables/1

- Get a specific version of a Table
https://cie.csinet.org/api/tableversions/1

- Get All Classifications in the database
https://cie.csinet.org/api/classifications
(This is not recommended without filtering as it will produce a large result set)

- Get a specific Classification
https://cie.csinet.org/api/classifications/1

- Get a specific version of a Classification
https://cie.csinet.org/api/classificationversions/1


### Feedback and Support
Please post all service feedback or requests for technical support to the [issues section](https://github.com/csi-net/CIE-API-Access/issues) and apply an appropriate label (*bug* for service breaking issues, *enhancement* for feature requests or suggestions, or *help wanted* for questions and support).

**A free GitHub user account is required to submit or comment on issues**. Logging in and using this resource will allow for public discussion of issues by all beta testers.  As issues are created, we encourage testers to read and comment on issues if they feel they can contribute.

For direct contact on development issues, please email [omniclassbeta@csinet.org](mailto:omniclassbeta@csinet.org)
