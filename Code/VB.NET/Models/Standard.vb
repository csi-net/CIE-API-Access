Namespace Models
    Public Class Standard
        Public Const Endpoint As String = "standards"
        Public Property StandardId As Integer
        Public Property StandardVersionBriefs As StandardVersionBrief()
        Public Property LatestStandardVersion() As StandardVersion
    End Class
End Namespace