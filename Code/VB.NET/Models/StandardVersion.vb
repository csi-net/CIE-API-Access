Namespace Models
    Public Class StandardVersion
        Public Const Endpoint As String = "standardversions"
        Public Property StandardVersionId As Integer
        Public Property StandardId As Integer
        Public Property PublishDate As Date
        Public Property Properties As PropertyValue()
        Public Property TableBriefs() As TableBrief()
    End Class
End Namespace