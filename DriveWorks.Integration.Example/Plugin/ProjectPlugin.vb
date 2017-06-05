Imports DriveWorks.Extensibility

Public Class ProjectPlugin
    Inherits SharedProjectExtender

    Protected Overrides Sub OnInitialize()
        MyBase.OnInitialize()

        If Me.Project.SpecificationContext Is Nothing Then
            ' We are editing a project
        Else
            ' We are in a specification
        End If
    End Sub

    <Udf>
    Public Function GetTestValue(value As String) As String
        Return value?.ToUpper()
    End Function

    <Udf>
    Public Function GetTextFromFile(path As String) As String
        Try
            Return System.IO.File.ReadAllText(path)
        Catch ex As Exception
            Return "#IO! " & ex.Message
        End Try
    End Function

End Class
