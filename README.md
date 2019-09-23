## CIE-API-Access
This GitHub project consolidates documentation and feedback for CSI's Construction Information Exchange (CIE) Web API service.

Included are code snippets with an open license which can be used directly within your commercial project or as a guide for creating your own implementation.  See the License file in this project for more details.  The license applies to all contents of this GitHub repository.

This Readme will be updated according to the current status of the API service.

### The CIE API service is currently in the beta testing phase.
- Only those organizations or individuals who have been accepted as beta testers will be able to use the service at this time.  Contact Ken Monblatt at [kmonblatt@cimatri.com](mailto:kmonblatt@cimatri.com) regarding becoming a beta tester.
- Errors, slow response times, and unfinished features are to be expected;  Please help us to improve the service by reporting problems to Jonathan Gordon at [jgordon@csinet.org](mailto:jgordon@csinet.org)
- New features and improvements to existing features are still being considered.  Please submit any suggestions to Ken Monblatt at [kmonblatt@cimatri.com](mailto:kmonblatt@cimatri.com).
- Existing features are subject to change or removal.  Such modifications will be noted on this document in addition to email notifications.

**All beta testers will receive an API Key** that is required when sending API requests.  This allows us to authenticate users and track utilization.  *(Please note: API keys are used only to access the CIE API services and cannot be used by anyone to access personal or organizational information or information located in any other CSI system.)*

The following list describes what is available **now** through the API:
- MasterFormat - All classifications, their hierarchy, properties, and version history
- MasterFormat1995 - A legacy table containing Number-Titles, their hierarchy, and transition information to modern MasterFormat versions
- OmniClass - All tables, classifications, their hierarchy, properties.  Only current versions of tables are supported at this time.
- UniFormat - All classifications, their hierarchy, properties.  Only the current version is supported at this time.

*(Properties include numbers, titles, descriptions, and (eventually) links to relevant objects within other classification systems.  Properties and links will be added as development and testing proceed.)*  
*(Each classification object at every level can provide its immediate children, and parent objects.)*  
*(Release status, publication date, and version numbers are all available for each Table.)*

We are working to implement the following in the future:
- API request filters for gathering, searching, and using information.

### Direct API Access
There are many ways to access the API.

Please see our documentation at getpostman.com for examples of the endpoints available and example responses:
https://documenter.getpostman.com/view/7286040/S1TbRZqt

All requests require the authorization header to have a value like the following:  
**bearer rA3C/LkhY5okP6O2k7Wj2KkGLTFJTkJP+TCo5DeWUUbT3HdwtCi/XmAQGI88aQj5HyCADPp7rJmq4TSF6x9LRw**

Where "bearer" is required to identify the type of token and the rest is the exact API key that is distributed to your project when accepted into the beta.

**JSON or XML?** Responses default to JSON as a payload format.  Any request can be modified to return a response in XML by including the "Accept" header with a value of "application/xml".

### API Endpoints Currently Available

The following endpoints are implemented.  More documentation will appear here as specifics become available.

- Get All Standards in the database
https://cie.csinet.org/api/standards

- Get a specific Standard (StandardId = 1)
https://cie.csinet.org/api/standards/1

- Get a specific version of a Standard (StandardVersionId = 1)
https://cie.csinet.org/api/standardversions/1

- Get All Tables in the database
https://cie.csinet.org/api/tables

- Get a specific Table (TableId = 1)
https://cie.csinet.org/api/tables/1

- Get a specific version of a Table (TableVersionId = 1)
https://cie.csinet.org/api/tableversions/1

- Get a specific Classification (ClassificationId = 1)
https://cie.csinet.org/api/classifications/1

- Get a specific version of a Classification (ClassificationVersionId = 1)
https://cie.csinet.org/api/classificationversions/1


### Feedback and Support
Please post all feedback and business concerns to Ken Monblatt at [kmonblatt@cimatri.com](mailto:kmonblatt@cimatri.com)
For direct contact on development issues or for technical assistance, please email Jonathan Gordon at [jgordon@csinet.org](mailto:jgordon@csinet.org)
