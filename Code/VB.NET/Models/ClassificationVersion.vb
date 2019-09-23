Namespace Models
    Public Class ClassificationVersion
        Public Const Endpoint As String = "classificationversions"
        Public Property ClassificationVersionId As Integer
        Public Property ClassificationId As Integer
        Public Property ParentClassificationBrief As ClassificationBrief
        Public Property PublishDate As Date
        Public Property Properties As PropertyValue()
        Public Property ChildClassificationVersionBriefs As ClassificationVersionBrief()
    End Class
End Namespace