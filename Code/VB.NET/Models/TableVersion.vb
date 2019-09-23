Namespace Models
    Public Class TableVersion
        Public Const Endpoint As String = "tableversions"
        Public Property TableVersionId As Integer
        Public Property TableId As Integer
        Public Property PublishDate As Date
        Public Property Properties As PropertyValue()
        Public Property DivisionClassificationBriefs As ClassificationBrief()
    End Class
End Namespace