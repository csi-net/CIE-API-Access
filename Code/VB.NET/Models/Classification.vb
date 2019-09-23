Namespace Models
    Public Class Classification
        Public Const Endpoint As String = "classifications"
        Public Property ClassificationId As Integer
        Public Property TableBrief As TableBrief
        Public Property SplitFromClassificationVersionBrief As ClassificationVersionBrief
        Public Property MergedFromClassificationVersionBriefs As ClassificationVersionBrief()
        Public Property ClassificationVersionBriefs As ClassificationVersionBrief()
        Public Property LatestClassificationVersion As ClassificationVersion
    End Class
End Namespace