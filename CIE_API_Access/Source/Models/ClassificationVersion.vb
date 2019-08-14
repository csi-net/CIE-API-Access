Namespace Models
    Public Class ClassificationVersion
        Public Property Id As Integer
        Public Property ClassificationId As Integer
        Public Property ParentClassificationId As Integer?
        Public Property PublishDate As Date
        Public Property Properties As PropertyValue()
        Public Property ChildClassificationVersionIds As Integer()
    End Class
End Namespace