Imports DriveWorks.Applications
Imports DriveWorks.Specification
Imports System.IO

Partial Class SpecificationServiceHandler

    ''' <summary>
    ''' Handles the events for a specification context
    ''' </summary>
    ''' <remarks></remarks>
    Private Class SpecificationContextHandler
        Private mExceptionHandler As IExceptionHandler
        Private mIntegrationCore As IntegrationCore
        Private WithEvents mContext As SpecificationContext

#Region " .ctor "

        Friend Sub New(ByVal integration As IntegrationCore, ByVal exceptionHandler As IExceptionHandler, ByVal context As SpecificationContext)
            mIntegrationCore = integration
            mExceptionHandler = exceptionHandler
            mContext = context
        End Sub

#End Region

#Region " Main Specification Context Events "

        Private Sub mContext_ChildContextCreated(ByVal sender As Object, ByVal e As Specification.SpecificationContextEventArgs) Handles mContext.ChildContextCreated

            ' Create a new handle for the child specification
            Dim childHandler As SpecificationContextHandler
            childHandler = New SpecificationContextHandler(mIntegrationCore, mExceptionHandler, e.Context)
        End Sub

        Private Sub mContext_AdditionalFoldersCreated(ByVal sender As Object, ByVal e As Specification.AdditionalFoldersCreatedEventArgs) Handles mContext.AdditionalFoldersCreated
            Try

                ' event raised by DriveWorks when an additional folder is created

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_DocumentRegistered(ByVal sender As Object, ByVal e As Specification.SpecificationDocumentEventArgs) Handles mContext.DocumentRegistered
            Try

                ' Event raised by DriveWorks when a new document is created (for example a Microsoft Word or Excel file)

                ' Get the new file name of the document in its normalized form
                Dim newFilePath As String = New FileInfo(e.DocumentDetails.Path).FullName

                mIntegrationCore.RegisterDocument(newFilePath)

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_StateChanging(ByVal sender As Object, ByVal e As Specification.StateChangeEventArgs) Handles mContext.StateChanging
            Try

                ' Event raised by DriveWorks before a state is changed

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_StateChanged(ByVal sender As Object, ByVal e As Specification.StateChangeEventArgs) Handles mContext.StateChanged
            Try

                ' Event raised by DriveWorks after state has been changed

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_OpenRequested(ByVal sender As Object, ByVal e As Specification.SpecificationDetailsEventArgs) Handles mContext.OpenRequested
            Try

                ' Event raised by DriveWorks when a specification open has been requested

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_TransitionInvoking(sender As Object, e As TransitionEventArgs) Handles mContext.TransitionInvoking
            Try

                ' Event raised by DriveWorks when a transition has been invoked

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_TransitionInvoked(sender As Object, e As TransitionEventArgs) Handles mContext.TransitionInvoked
            Try

                ' Event raised by DriveWorks after a specification has been invoked

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

#End Region

#Region " Additional Specification Context Events "

        Private Sub mContext_ActiveDialogChanged(sender As Object, e As EventArgs) Handles mContext.ActiveDialogChanged

        End Sub

        Private Sub mContext_ActiveDialogChanging(sender As Object, e As EventArgs) Handles mContext.ActiveDialogChanging

        End Sub

        Private Sub mContext_ActiveDialogOrFormChanged(sender As Object, e As EventArgs) Handles mContext.ActiveDialogOrFormChanged

        End Sub

        Private Sub mContext_ActiveDialogOrFormChanging(sender As Object, e As EventArgs) Handles mContext.ActiveDialogOrFormChanging

        End Sub

        Private Sub mContext_ActiveDialogOrFormUpdated(sender As Object, e As EventArgs) Handles mContext.ActiveDialogOrFormUpdated

        End Sub

        Private Sub mContext_ActiveFormChanged(sender As Object, e As EventArgs) Handles mContext.ActiveFormChanged

        End Sub

        Private Sub mContext_ActiveFormChanging(sender As Object, e As EventArgs) Handles mContext.ActiveFormChanging

        End Sub

        Private Sub mContext_Cancelled(sender As Object, e As EventArgs) Handles mContext.Cancelled

        End Sub

        Private Sub mContext_CopyRequested(sender As Object, e As SpecificationDetailsEventArgs) Handles mContext.CopyRequested

        End Sub

        Private Sub mContext_Deleted(sender As Object, e As EventArgs) Handles mContext.Deleted

        End Sub

        Private Sub mContext_DialogClosed(sender As Object, e As EventArgs) Handles mContext.DialogClosed

        End Sub

        Private Sub mContext_DialogClosing(sender As Object, e As EventArgs) Handles mContext.DialogClosing

        End Sub

        Private Sub mContext_DialogOpening(sender As Object, e As EventArgs) Handles mContext.DialogOpening

        End Sub

        Private Sub mContext_EventSequenceInvoked(sender As Object, e As EventSequenceEventArgs) Handles mContext.EventSequenceInvoked

        End Sub

        Private Sub mContext_EventSequenceInvoking(sender As Object, e As EventSequenceEventArgs) Handles mContext.EventSequenceInvoking

        End Sub

        Private Sub mContext_IsLoadedChanged(sender As Object, e As EventArgs) Handles mContext.IsLoadedChanged

        End Sub

        Private Sub mContext_IsRunningChanged(sender As Object, e As EventArgs) Handles mContext.IsRunningChanged

        End Sub

        Private Sub mContext_OperationInvoked(sender As Object, e As OperationEventArgs) Handles mContext.OperationInvoked

        End Sub

        Private Sub mContext_OperationInvoking(sender As Object, e As OperationEventArgs) Handles mContext.OperationInvoking

        End Sub

        Private Sub mContext_OperationSequenceInvoked(sender As Object, e As OperationEventArgs) Handles mContext.OperationSequenceInvoked

        End Sub

        Private Sub mContext_OperationSequenceInvoking(sender As Object, e As OperationEventArgs) Handles mContext.OperationSequenceInvoking

        End Sub

        Private Sub mContext_ReportCancelled(sender As Object, e As EventArgs) Handles mContext.ReportCancelled

        End Sub

        Private Sub mContext_ReportCreated(sender As Object, e As EventArgs) Handles mContext.ReportCreated

        End Sub

        Private Sub mContext_ReportFinished(sender As Object, e As EventArgs) Handles mContext.ReportFinished

        End Sub

        Private Sub mContext_StartRequested(sender As Object, e As ProjectDetailsEventArgs) Handles mContext.StartRequested

        End Sub

        Private Sub mContext_TaskListEntryAdded(sender As Object, e As SpecificationTaskListEntryEventArgs) Handles mContext.TaskListEntryAdded

        End Sub

        Private Sub mContext_TaskListEntryRemoved(sender As Object, e As SpecificationTaskListEntryEventArgs) Handles mContext.TaskListEntryRemoved

        End Sub

        Private Sub mContext_TaskListEntryUpdated(sender As Object, e As SpecificationTaskListEntryEventArgs) Handles mContext.TaskListEntryUpdated

        End Sub

        Private Sub mContext_TransitionSequenceInvoked(sender As Object, e As TransitionEventArgs) Handles mContext.TransitionSequenceInvoked

        End Sub

        Private Sub mContext_TransitionSequenceInvoking(sender As Object, e As TransitionEventArgs) Handles mContext.TransitionSequenceInvoking

        End Sub
#End Region

    End Class
End Class

