Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text.Json
Imports CSI_CIE_API.Models

''' <summary>
''' Create an instance of CIE_API_Accessor when you want to make calls to a CIE API application
''' </summary>
Public Class CIE_API_Accessor

    ''' <summary>
    ''' Gets the www domain targeted by this Accessor (i.e. cie.csinet.org)
    ''' </summary>
    Public ReadOnly Domain As String

    ''' <summary>
    ''' Gets the URL of the CIE API application targeted by this Accessor (i.e. https://cie.csinet.org/api/)
    ''' </summary>
    Public ReadOnly APIRootURL As String

    ''' <summary>
    ''' The HttpClient used by this Accessor to make API calls
    ''' </summary>
    Private Client As HttpClient = New HttpClient()

    ''' <summary>
    ''' Creates an instance of CIE_API_Accessor which can be used to access a CIE API application
    ''' </summary>
    ''' <param name="Domain">The www domain targeted by this Accessor (i.e. cie.csinet.org)</param>
    ''' <param name="BearerToken">The Bearer Token to include in API calls. This is a unique API Key issued by CSI.</param>
    Public Sub New(Domain As String, BearerToken As String)
        Me.Domain = Domain

        APIRootURL = "https://"
        APIRootURL &= Domain
        APIRootURL &= "/api/"

        Client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", BearerToken)
        Client.DefaultRequestHeaders.Accept.Clear()
        Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
    End Sub

    ''' <summary>
    ''' Deserializes a JSON string expected to contain an array of objects of Type T and returns the result
    ''' </summary>
    ''' <typeparam name="T">The Type expected to be represented in the JSON string</typeparam>
    ''' <param name="JSON">A JSON formatted string expected to contain a list of objects of the expected Type</param>
    ''' <returns></returns>
    Public Shared Function GetModelsFromJSON(Of T)(JSON As String) As T()
        Dim options As New JsonSerializerOptions()
        options.PropertyNameCaseInsensitive = True
        Return JsonSerializer.Deserialize(Of T())(JSON, options)
    End Function

    ''' <summary>
    ''' Deserializes a JSON string expected to contain an object of Type T and returns the result
    ''' </summary>
    ''' <typeparam name="T">The Type expected to be represented in the JSON string</typeparam>
    ''' <param name="JSON">A JSON formatted string expected to contain an object of the expected Type</param>
    ''' <returns></returns>
    Public Shared Function GetModelFromJSON(Of T)(JSON As String) As T
        Dim options As New JsonSerializerOptions()
        options.PropertyNameCaseInsensitive = True
        Return JsonSerializer.Deserialize(Of T)(JSON, options)
    End Function

    ''' <summary>
    ''' Deserializes the JSON-Formatted Content of an HttpResponseMessage expected to contain an array of objects of Type T and returns the result
    ''' On server error, returns Nothing/NULL
    ''' </summary>
    ''' <typeparam name="T">The Type expected to be represented in the HttpResponseMessage</typeparam>
    ''' <param name="Response">An HttpResponseMessage expected to contain a list of objects of the expected Type</param>
    ''' <returns></returns>
    Public Async Function GetModelsAsync(Of T)(Response As HttpResponseMessage) As Task(Of T())
        If Not Response.IsSuccessStatusCode Then Return Nothing
        Dim JSON = Await Response.Content.ReadAsStringAsync
        Return GetModelsFromJSON(Of T)(JSON)
    End Function

    ''' <summary>
    ''' Deserializes the JSON-Formatted Content of an HttpResponseMessage expected to contain an object of Type T and returns the result
    ''' On server error, returns Nothing/NULL
    ''' </summary>
    ''' <typeparam name="T">The Type expected to be represented in the HttpResponseMessage</typeparam>
    ''' <param name="Response">An HttpResponseMessage expected to contain an object of the expected Type</param>
    ''' <returns></returns>
    Public Async Function GetModelAsync(Of T)(Response As HttpResponseMessage) As Task(Of T)
        If Not Response.IsSuccessStatusCode Then Return Nothing
        Dim JSON = Await Response.Content.ReadAsStringAsync
        Return GetModelFromJSON(Of T)(JSON)
    End Function

    ''' <summary>
    ''' Makes an API request and returns the server response
    ''' </summary>
    ''' <param name="URL">A full URL, including endpoints, to make an API request to (i.e. https://cie.csinet.org/api/standards/1)</param>
    ''' <returns></returns>
    Public Async Function GetResponseFromURLAsync(URL As String) As Task(Of HttpResponseMessage)
        Return Await Client.GetAsync(URL)
    End Function

    ''' <summary>
    ''' Makes an API request and returns the server response. Generally an array of objects, since no ID is included.
    ''' </summary>
    ''' <param name="EndPoint">The endpoint to make an API request to (i.e. standards)</param>
    ''' <returns></returns>
    Public Async Function GetResponseFromEndpointAsync(EndPoint As String) As Task(Of HttpResponseMessage)
        Return Await GetResponseFromURLAsync(APIRootURL & EndPoint)
    End Function

    ''' <summary>
    ''' Makes an API request and returns the server response. Requests a single object with the given ID.
    ''' </summary>
    ''' <param name="EndPoint">The endpoint to make an API request to (i.e. standards)</param>
    ''' <param name="Id">The ID of the requested database object</param>
    ''' <returns></returns>
    Public Async Function GetResponseFromEndpointAsync(EndPoint As String, Id As String) As Task(Of HttpResponseMessage)
        Return Await GetResponseFromEndpointAsync(EndPoint & "/" & Id)
    End Function

    ''' <summary>
    ''' Makes an API request expected to return an array of objects of Type T, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelsAsync() individually.
    ''' </summary>
    ''' <typeparam name="T">The Type expected to be represented in the server response</typeparam>
    ''' <param name="EndPoint">The endpoint to make the API request to (i.e. standards)</param>
    ''' <returns></returns>
    Public Async Function GetModelsAsync(Of T)(EndPoint As String) As Task(Of T())
        Dim response As HttpResponseMessage = Await GetResponseFromEndpointAsync(EndPoint)
        Return Await GetModelsAsync(Of T)(response)
    End Function

    ''' <summary>
    ''' Makes an API request expected to return an object of Type T, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelAsync() individually.
    ''' </summary>
    ''' <typeparam name="T">The Type expected to be represented in the server response</typeparam>
    ''' <param name="EndPoint">The endpoint to make the API request to (i.e. standards)</param>
    ''' <param name="Id">The ID of the requested database object</param>
    ''' <returns></returns>
    Public Async Function GetModelAsync(Of T)(EndPoint As String, Id As String) As Task(Of T)
        Dim response As HttpResponseMessage = Await GetResponseFromEndpointAsync(EndPoint, Id)
        Return Await GetModelAsync(Of T)(response)
    End Function

    ''' <summary>
    ''' Makes an API request to get all Standards from the database, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelsAsync() individually.
    ''' </summary>
    ''' <returns></returns>
    Public Async Function GetStandardBriefsAsync() As Task(Of StandardBrief())
        Return Await GetModelsAsync(Of StandardBrief)(StandardBrief.Endpoint)
    End Function

    ''' <summary>
    ''' Makes an API request to get a specified Standard from the database, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelAsync() individually.
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Async Function GetStandardAsync(Id As String) As Task(Of Standard)
        Return Await GetModelAsync(Of Standard)(Standard.Endpoint, Id)
    End Function

    ''' <summary>
    ''' Makes an API request to get a specified StandardVersion from the database, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelAsync() individually.
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Async Function GetStandardVersionAsync(Id As String) As Task(Of StandardVersion)
        Return Await GetModelAsync(Of StandardVersion)(StandardVersion.Endpoint, Id)
    End Function

    ''' <summary>
    ''' Makes an API request to get a specified Table from the database, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelAsync() individually.
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Async Function GetTableAsync(Id As String) As Task(Of Table)
        Return Await GetModelAsync(Of Table)(Table.Endpoint, Id)
    End Function

    ''' <summary>
    ''' Makes an API request to get a specified TableVersion from the database, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelAsync() individually.
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Async Function GetTableVersionAsync(Id As String) As Task(Of TableVersion)
        Return Await GetModelAsync(Of TableVersion)(TableVersion.Endpoint, Id)
    End Function

    ''' <summary>
    ''' Makes an API request to get a specified Classification from the database, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelAsync() individually.
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Async Function GetClassificationAsync(Id As String) As Task(Of Classification)
        Return Await GetModelAsync(Of Classification)(Classification.Endpoint, Id)
    End Function

    ''' <summary>
    ''' Makes an API request to get a specified ClassificationVersion from the database, deserializes the JSON content of the server response, and returns the result.
    ''' On server error, returns Nothing/NULL.
    ''' To handle server errors, instead use GetResponseFromEndPointAsync() and GetModelAsync() individually.
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    Public Async Function GetClassificationVersionAsync(Id As String) As Task(Of ClassificationVersion)
        Return Await GetModelAsync(Of ClassificationVersion)(ClassificationVersion.Endpoint, Id)
    End Function

End Class
