Namespace Models
    Public Class TableBrief
        Public Const Endpoint As String = "tables"
        Public Property TableId As Integer
        Public Property StandardBrief As StandardBrief
        Public Property TableVersionsCount As Integer
        Public Property LatestTableVersionBrief As TableVersionBrief
    End Class
End Namespace