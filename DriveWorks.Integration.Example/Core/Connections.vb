Friend Class Connections

    Private mSettings As PluginSettings
    Public Shared ReadOnly Instance As New Connections

    ' make sure nothing else can create this
    Private Sub New()

    End Sub

    ' we do need to store the settings here for passing through to the integrationcore
    Friend Sub LoadSettings(ByVal settings As PluginSettings)

        ' Store the settings
        mSettings = settings

    End Sub

    ' this will create a new connection manager if one doesn't exist already
    Public Function GetConnection(project As DriveWorks.Project) As ConnectionManager

        Dim connectionMan = project.GetSharedObject(Of ConnectionManager)()

        connectionMan.InitializeSettings(mSettings)
        connectionMan.InitializeProject(project)

        Return connectionMan

    End Function


End Class
