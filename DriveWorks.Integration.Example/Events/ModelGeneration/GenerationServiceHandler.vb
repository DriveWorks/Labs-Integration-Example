Imports DriveWorks.Applications
Imports DriveWorks.SolidWorks.Generation

''' <summary>
''' Handles the interaction between the model generation process and the 3rd party system.
''' </summary>
''' <remarks></remarks>
Public Class GenerationServiceHandler

    ' Required services
    Private mApplication As IApplication
    Private mExceptionHandler As IExceptionHandler
    Private mIntegrationCore As IntegrationCore
    Private mEnabled As Boolean

    ' The generation service used to find out  when DriveWorks is about to generate a model
    Private WithEvents mGenerationService As IGenerationService

#Region " .ctor "

    ''' <summary>
    ''' Initializes a new instance of the <see cref="GenerationServiceHandler" /> class.
    ''' </summary>
    ''' <param name="application">The hosting application.</param>
    ''' <param name="Integration">The Integration system.</param>
    ''' <param name="exceptionHandler">The exception handler.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal application As IApplication, ByVal Integration As IntegrationCore, ByVal exceptionHandler As IExceptionHandler)
        If application Is Nothing Then Throw New ArgumentNullException("application")
        If Integration Is Nothing Then Throw New ArgumentNullException("IntegrationCore")
        If exceptionHandler Is Nothing Then Throw New ArgumentNullException("exceptionHandler")

        ' Store required services
        mApplication = application
        mIntegrationCore = Integration
        mExceptionHandler = exceptionHandler

        ' Get hold of the generation service - if the application doesn't have one, Nothing is returned
        mGenerationService = application.ServiceManager.GetService(Of IGenerationService)()
    End Sub

#End Region

#Region " Public Properties "

    ''' <summary>
    ''' Gets/sets whether the generation service is enabled/disabled.
    ''' </summary>
    Public Property Enabled() As Boolean
        Get
            Return mEnabled
        End Get
        Set(ByVal value As Boolean)
            mEnabled = value
        End Set
    End Property

#End Region

#Region " Generation Service Events "

    Private Sub mGenerationService_BatchStarted(ByVal sender As Object, ByVal e As System.EventArgs) Handles mGenerationService.BatchStarted
        mIntegrationCore.BeginBatch()
    End Sub

    Private Sub mGenerationService_BatchFinished(ByVal sender As Object, ByVal e As System.EventArgs) Handles mGenerationService.BatchFinished
        mIntegrationCore.EndBatch()
    End Sub

    Private Sub mGenerationService_GeneratingModel(ByVal sender As Object, ByVal e As ModelGenerationContextEventArgs) Handles mGenerationService.ModelGenerationContextCreated
        If mEnabled Then

            ' Create a new handler to handle the generation of the specified model
            Dim handler As ModelContextHandler
            handler = New ModelContextHandler(mIntegrationCore, mExceptionHandler, e.Context)
        End If
    End Sub

#End Region

End Class
