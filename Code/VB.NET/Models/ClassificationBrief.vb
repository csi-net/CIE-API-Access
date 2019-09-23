Namespace Models
    Public Class ClassificationBrief
        Public Const Endpoint As String = "classifications"
        Public Property ClassificationId As Integer
        Public Property TableBrief As TableBrief
        Public Property SplitFromClassificationVersionId As Integer?
        Public Property MergedFromClassificationVersionsCount As Integer
        Public Property ClassificationVersionsCount As Integer
        Public Property LatestClassificationVersionBrief As ClassificationVersionBrief
    End Class
End Namespace