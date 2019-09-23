Namespace Models
    Public Class TableVersionBrief
        Public Const Endpoint As String = "tableversions"
        Public Property TableVersionId As Integer
        Public Property TableId As Integer
        Public Property PublishDate As Date
        Public Property Number As String
        Public Property Name As String
        Public Property Status As String
        Public Property Version As String
        Public Property Definition As String
        Public Property DivisionClassificationsCount As Integer
    End Class
End Namespace