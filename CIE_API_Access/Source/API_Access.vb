Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text.Json
Imports CSI_CIE_API_Access.Models

Public Class API_Access

    Private Client As HttpClient = New HttpClient()

    Public Sub New(Key As String, Optional AcceptHeaderValue As String = "application/json")
        Client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", Key)
        Client.DefaultRequestHeaders.Accept.Clear()
        Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(AcceptHeaderValue))
    End Sub

    Public Async Function GetResponseAsync(URL As String) As Task(Of HttpResponseMessage)
        Return Await Client.GetAsync(URL)
    End Function

    Public Async Function GetStringAsync(URL As String) As Task(Of String)
        Dim response As HttpResponseMessage = Await GetResponseAsync(URL)
        If response.IsSuccessStatusCode Then
            Return Await response.Content.ReadAsStringAsync()
        End If
        Return "Failed due to status code: " & response.StatusCode.ToString
    End Function

    Public Async Function GetClassificationResponseAsync(Id As String) As Task(Of HttpResponseMessage)
        Return Await GetResponseAsync("https://cie.csinet.org/api/classifications/" & Id)
    End Function

    Public Async Function GetClassificationAsync(Id As String) As Task(Of Classification)
        Dim response As HttpResponseMessage = Await GetClassificationResponseAsync(Id)
        If Not response.IsSuccessStatusCode Then
            Return Nothing
        End If

        Dim body = Await response.Content.ReadAsStringAsync

        Dim options As New JsonSerializerOptions()
        options.PropertyNameCaseInsensitive = True
        Dim Classification = JsonSerializer.Deserialize(Of Classification)(body, options)

        Return Classification
    End Function

End Class
