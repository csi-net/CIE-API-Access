Namespace Models
    Public Class Table
        Public Const Endpoint As String = "tables"
        Public Property TableId As Integer
        Public Property StandardBrief As StandardBrief
        Public Property TableVersionBriefs As TableVersionBrief()
        Public Property LatestTableVersion As TableVersion
    End Class
End Namespace