Imports DriveWorks.Applications
Imports DriveWorks.Applications.Extensibility
Imports DriveWorks.Extensibility
Imports System.Windows.Forms

<ApplicationPlugin( _
    "DriveWorks.Integration.Example", _
    "DriveWorks Integration Example", _
    "An example plugin showing the basics of Integration methods with DriveWorks")> _
Public NotInheritable Class IntegrationPlugIn

    ' This is the main interface a standard application plugin MUST implement
    Implements IApplicationPlugin

    ' This optional interface lets the plugin screen in DriveWorks applications know
    ' to show a settings button
    Implements IHasConfiguration

    ' Allow the various generation/specification handlers to notify the plugin
    ' of exceptions
    Implements IExceptionHandler

    Friend Const SOURCE_INVARIANT_NAME As String = "urn://driveworks/plugins/core/examples/integration"

    Private mApplication As IApplication
    Private mEventService As IApplicationEventService
    Private mSettings As PluginSettings

    Private mGenerationHandler As GenerationServiceHandler
    Private mSpecificationHandler As SpecificationServiceHandler

    Private mBaseIntegrationCore As IntegrationCore

    Public Sub Initialize(application As IApplication) Implements IApplicationPlugin.Initialize

        ' Store the application in case we need it 
        mApplication = application

        ' get hold of the connections class through the shared property
        mBaseIntegrationCore = New IntegrationCore

        If mBaseIntegrationCore.Log Is Nothing Then
            mBaseIntegrationCore.Log = application.ServiceManager.GetService(Of IApplicationEventService)()
        End If

        ' Create a wrapper around the application's settings manager
        ' which we'll use to read/write our own settings
        mSettings = New PluginSettings(application.SettingsManager)

        ' Get the logging service
        mEventService = application.ServiceManager.GetService(Of IApplicationEventService)()

        ' Create an object which will handle events raised by the generation service
        mGenerationHandler = New GenerationServiceHandler(application, mBaseIntegrationCore, Me)

        ' Create an object which will handle events raised by the specification service
        mSpecificationHandler = New SpecificationServiceHandler(application, mBaseIntegrationCore, Me)

        ' Load settings
        Me.LoadSettings()

    End Sub

    Public Sub ShowConfiguration(owner As IWin32Window) Implements IHasConfiguration.ShowConfiguration

        ' Create a new settings form and make sure it is disposed when we're done
        Using configForm = New PlugInSettingsForm()

            ' Apply current settings
            configForm.UserName.Text = Me.Settings.UserName
            configForm.Password.Text = Me.Settings.Password
            configForm.ConnectionString.Text = Me.Settings.ConnectionString
            configForm.ModelEventsCheck.Checked = Me.Settings.RespondToGenerationEvents
            configForm.SpecificationEventsCheck.Checked = Me.Settings.RespondToSpecificationEvents

            ' Show it, and if they cancel, exit straight away
            If Not configForm.ShowDialog(owner) = Windows.Forms.DialogResult.OK Then
                Return
            End If

            ' If we got here, time to save the settings
            Me.Settings.UserName = configForm.UserName.Text
            Me.Settings.Password = configForm.Password.Text
            Me.Settings.ConnectionString = configForm.ConnectionString.Text
            Me.Settings.RespondToGenerationEvents = configForm.ModelEventsCheck.Checked
            Me.Settings.RespondToSpecificationEvents = configForm.SpecificationEventsCheck.Checked
           
            ' Load settings into our handlers
            Me.LoadSettings()
        End Using
    End Sub

#Region " Properties "

    ''' <summary>
    ''' Gets the application hosting the plugin.
    ''' </summary>
    Friend ReadOnly Property Application() As IApplication
        Get
            Return mApplication
        End Get
    End Property

    ''' <summary>
    ''' Provides access to the plugin's settings.
    ''' </summary>
    Friend ReadOnly Property Settings() As PluginSettings
        Get
            Return mSettings
        End Get
    End Property

#End Region

#Region " Helpers "

    Private Sub LoadSettings()

        ' load the settings onto the base integration core
        mBaseIntegrationCore.LoadSettings(Me.Settings)

        ' and onto the connections module
        Connections.Instance.LoadSettings(Me.Settings)

        mGenerationHandler.Enabled = mSettings.RespondToGenerationEvents
        mSpecificationHandler.Enabled = mSettings.RespondToSpecificationEvents

        If mEventService IsNot Nothing Then
            mEventService.AddEvent(ApplicationEventType.Information, SOURCE_INVARIANT_NAME, "DriveWorks Integration Example", String.Format("Setting loaded ({0}:{1})", "User name", mSettings.UserName), Nothing, Nothing, Nothing)
            mEventService.AddEvent(ApplicationEventType.Information, SOURCE_INVARIANT_NAME, "DriveWorks Integration Example", String.Format("Setting loaded ({0}:{1})", "Connection String", mSettings.ConnectionString), Nothing, Nothing, Nothing)
            mEventService.AddEvent(ApplicationEventType.Information, SOURCE_INVARIANT_NAME, "DriveWorks Integration Example", String.Format("Setting loaded ({0}:{1})", "Respond to Generation Events", mSettings.RespondToGenerationEvents), Nothing, Nothing, Nothing)
            mEventService.AddEvent(ApplicationEventType.Information, SOURCE_INVARIANT_NAME, "DriveWorks Integration Example", String.Format("Setting loaded ({0}:{1})", "Respond to Specification Events", mSettings.RespondToSpecificationEvents), Nothing, Nothing, Nothing)
        End If
    End Sub

#End Region

    Public Function HandleException(ex As Exception) As Boolean Implements IExceptionHandler.HandleException
        Return HandleException(ex, Nothing)
    End Function

    Public Function HandleException(ex As Exception, source As String) As Boolean Implements IExceptionHandler.HandleException
        Debug.Fail(ex.Message, ex.ToString())
        Return False
    End Function

End Class
