Friend Class ConnectionManager

    Private mIntegrationCore As IntegrationCore
    Private mSettings As PluginSettings
    Private mProject As Project

    ' the settings are required regardless of the entry point, so the connectionmanager needs to store them for when a connection is required.
    Public Sub InitializeSettings(settings As PluginSettings)

        If mSettings Is Nothing Then
            mSettings = settings
        End If

    End Sub

    ' if we are working with projects and specifications, we may also need one of those, mainly so that we can get hold of the specification report.
    Public Sub InitializeProject(project As Project)

        If mProject Is Nothing Then
            mProject = project
        End If

    End Sub

#Region "     Rety code     "

    ' make sure that we have a valid connection.
    Private Sub EnsureConnection()

        If mIntegrationCore Is Nothing Then
            mIntegrationCore = New IntegrationCore
            mIntegrationCore.LoadSettings(mSettings)

            ' check that we are in a specification, and if we are pass the specification report into the integrationcore object
            If mProject.SpecificationContext IsNot Nothing Then
                mIntegrationCore.Log = New ISpecificationReporting(mProject.SpecificationContext.Report)
            End If
        End If

        mIntegrationCore.Connect()

    End Sub

    ' if something goes wrong, we need to destroy the connection and re-connect
    Private Sub DestroyConnection()

        ' if we don't have an integrationcore, then we cannot disconnect
        If mIntegrationCore Is Nothing Then Return

        mIntegrationCore.Disconnect()

    End Sub

    ' this allows up to three attempts at each method or function
    Friend Function RunWithRetry(Of TReturn)(ByVal action As Func(Of IntegrationCore, TReturn)) As TReturn
        Dim i As Integer = 3

        While True
            i -= 1

            Try
                ' get hold of the existing connection if there is one, if there isn't, it will be created
                EnsureConnection()
                Return action(mIntegrationCore)
            Catch ex As Exception
                If i = 0 Then
                    Throw
                Else
                    ' it failed, throw away the connection
                    DestroyConnection()
                End If
            End Try
        End While

        ' Cant get here
        Throw New InvalidOperationException()
    End Function

#End Region

End Class
