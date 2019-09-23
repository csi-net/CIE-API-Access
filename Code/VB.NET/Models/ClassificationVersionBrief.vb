Namespace Models
    Public Class ClassificationVersionBrief
        Public Const Endpoint As String = "classificationversions"
        Public Property ClassificationVersionId As Integer
        Public Property ClassificationId As Integer
        Public Property ParentClassificationId As Integer?
        Public Property PublishDate As Date
        Public Property Number As String
        Public Property Title As String
        Public Property ChildClassificationsCount As Integer
    End Class
End Namespace