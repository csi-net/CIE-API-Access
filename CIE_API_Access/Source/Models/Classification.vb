Namespace Models
    Public Class Classification
        Public Property Id() As Integer
        Public Property SplitFromClassificationVersionId As Integer?
        Public Property MergedFromClassificationVersionIds As Integer()
        Public Property VersionIds() As Integer()
        Public Property LatestVersion() As ClassificationVersion
    End Class
End Namespace