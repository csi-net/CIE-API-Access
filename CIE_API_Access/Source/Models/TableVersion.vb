Namespace Models
    Public Class TableVersion
        Public Property Id As Integer
        Public Property TableId As Integer
        Public Property PublishDate() As Date
        Public Property Properties() As PropertyValue()
        Public Property DivisionIds() As Integer()
    End Class
End Namespace