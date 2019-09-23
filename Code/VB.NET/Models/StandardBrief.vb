Namespace Models
    Public Class StandardBrief
        Public Const Endpoint As String = "standards"
        Public Property StandardId As Integer
        Public Property StandardVersionsCount As Integer
        Public Property LatestStandardVersionBrief As StandardVersionBrief
    End Class
End Namespace