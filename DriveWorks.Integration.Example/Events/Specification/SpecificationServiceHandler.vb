Imports DriveWorks.Applications
Imports DriveWorks.Specification


''' <summary>
''' Handles the interaction between the specification process and a 3rd party system.
''' </summary>
''' <remarks></remarks>
Public Class SpecificationServiceHandler

    ' Required services
    Private mApplication As IApplication
    Private mExceptionHandler As IExceptionHandler
    Private mIntegrationCore As IntegrationCore
    Private mEnabled As Boolean

    ' The specification service used to find out when DriveWorks is about to create a specification
    Private WithEvents mSpecificationService As ISpecificationService

#Region " .ctor "

    ''' <summary>
    ''' Initializes a new instance of the <see cref="SpecificationServiceHandler" /> class.
    ''' </summary>
    ''' <param name="application">The hosting application.</param>
    ''' <param name="integration">The 3rd Party integration system.</param>
    ''' <param name="exceptionHandler">The exception handler.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal application As IApplication, ByVal integration As IntegrationCore, ByVal exceptionHandler As IExceptionHandler)
        If application Is Nothing Then Throw New ArgumentNullException("application")
        If integration Is Nothing Then Throw New ArgumentNullException("integration")
        If exceptionHandler Is Nothing Then Throw New ArgumentNullException("exceptionHandler")

        ' Store required services
        mApplication = application
        mIntegrationCore = integration
        mExceptionHandler = exceptionHandler

        ' Get hold of the specification service - if the application doesn't have one, Nothing is returned
        mSpecificationService = application.ServiceManager.GetService(Of ISpecificationService)()
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

#Region " Specification Service Events "

    Private Sub mSpecificationService_SpecificationContextCreated(ByVal sender As Object, ByVal e As SpecificationContextEventArgs) Handles mSpecificationService.SpecificationContextCreated
        If mEnabled Then

            ' Create a new object to handle the specification context's events
            Dim handler As SpecificationContextHandler
            handler = New SpecificationContextHandler(mIntegrationCore, mExceptionHandler, e.Context)
        End If
    End Sub

#End Region

End Class

