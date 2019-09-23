Namespace Models
    Public Class StandardVersionBrief
        Public Const Endpoint As String = "standardversions"
        Public Property StandardVersionId As Integer
        Public Property StandardId As Integer
        Public Property PublishDate As Date
        Public Property Name As String
        Public Property Description As String
        Public Property TablesCount As Integer
    End Class
End Namespace