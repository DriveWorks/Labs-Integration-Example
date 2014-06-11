Imports System.IO
Imports DriveWorks.Applications
Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks.Components

Partial Class GenerationServiceHandler

    ''' <summary>
    ''' Handles events for a model context 
    ''' </summary>
    ''' <remarks></remarks>
    Private Class ModelContextHandler
        Private mExceptionHandler As IExceptionHandler
        Private mIntegrationCore As IntegrationCore
        Private WithEvents mContext As IModelGenerationContext

        ' member variable for the 
        Private mMasterFileName As String
        Private mTargetFilename As String

#Region " .ctor "

        Friend Sub New(ByVal Integration As IntegrationCore, ByVal exceptionHandler As IExceptionHandler, ByVal context As IModelGenerationContext)
            mIntegrationCore = Integration
            mExceptionHandler = exceptionHandler
            mContext = context
        End Sub

#End Region

#Region " Current Model "

        Private Sub mContext_Preparing(ByVal sender As Object, ByVal e As System.EventArgs) Handles mContext.Preparing
            Try

                'This event is raised when DriveWorks is preparing the files to drive
                'for example, you could update a driven custom property value based on data in the third party system (ie an incrementing part number derived from your system
                mIntegrationCore.ActOnModelPreperation(mContext.Model)

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_Prepared(sender As Object, e As ModelPreparationResultEventArgs) Handles mContext.Prepared

            Try

                'This event is raised when DriveWorks has prepared a file to drive, but has not yet openend it

                ' To Get/Set the released model information if its a part
                If TypeOf mContext.Model Is ReleasedPart Then   ' its a solidworks part

                    Dim thisPart As ReleasedPart = DirectCast(mContext.Model, ReleasedPart)

                    ' You can now get hold of any of the released part information, for instance the Driven Custom Properties.

                End If

                ' To Get/Set the released model information if its an assembly
                If TypeOf mContext.Model Is ReleasedAssembly Then   ' its a solidworks assembly

                    Dim thisAssembly As ReleasedAssembly = DirectCast(mContext.Model, ReleasedAssembly)

                    ' You can now get hold of any of the released assembly information, for instance the Driven Assembly Structure.

                End If

                ' get the master path and target path from the model context
                mMasterFileName = mContext.Model.MasterPath

                mTargetFilename = mContext.Model.TargetPath


            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try

        End Sub

        Private Sub mContext_PreparationFailed(sender As Object, e As ExceptionEventArgs) Handles mContext.PreparationFailed
            Try

                'This event is raised if the model preperation fails for any reason

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_Generating(sender As Object, e As EventArgs) Handles mContext.Generating
            Try

                'This event is raised when DriveWorks starts generating a model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_Saving(sender As Object, e As EventArgs) Handles mContext.Saving
            Try

                'This event is raised just before DriveWorks saves the model
                'This would be a great time to traverse the assembly structure in the case of an assembly, so that a bill of materials can be derived from the assembly (Usually a Bill of Materials would be created from the Specification events or specification task to eliminate the need to gereate the models before the bill of materials is available.)
                ' You can find assembly traversal examples in the SolidWorks API documentation.

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_Saved(sender As Object, e As EventArgs) Handles mContext.Saved
            Try

                'This event is raised after the model has been saved

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_Finished(sender As Object, e As EventArgs) Handles mContext.Finished
            Try

                'This event is raised after driveWorks has finished with the model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_GenerationFailed(sender As Object, e As ExceptionEventArgs) Handles mContext.GenerationFailed
            Try

                'This event is raised if the model generation fails for the current model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_Generated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mContext.Generated
            Try

                'This event is raised when DriveWorks has generated a model
                ' the model will be closed at this point, so it would be a good time to register the file in the 3rd party system
                mIntegrationCore.RegisterDocument(mTargetFilename)

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

#End Region

#Region " Additional File Formats "

        Private Sub mContext_AdditionalFileFormatRequesting(ByVal sender As Object, ByVal e As FileFormatGenerationEventArgs) Handles mContext.AdditionalFileFormatPreparing
            Try

                'This event is raised when the first request is made for an additional file format (For example edrawing or PDF)

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_AdditionalFileFormatPrepared(sender As Object, e As FileFormatGenerationEventArgs) Handles mContext.AdditionalFileFormatPrepared
            Try

                'This event is raised once the additional file format has been prepared

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_AdditionalFileFormatGenerating(sender As Object, e As FileFormatGenerationEventArgs) Handles mContext.AdditionalFileFormatGenerating
            Try

                'This event is raised before DriveWorks generates the additional file format

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_AdditionalFileFormatGenerated(ByVal sender As Object, ByVal e As FileFormatGenerationEventArgs) Handles mContext.AdditionalFileFormatGenerated
            Try

                'This event is raised once the additional file format has been created

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mContext_AdditionalFileFormatGenerationFailed(sender As Object, e As FileFormatGenerationExceptionEventArgs) Handles mContext.AdditionalFileFormatGenerationFailed
            Try

                'This event is raised if the creation of the additional file format fails

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

#End Region

#Region " Drawings "

        Private Sub mContext_GeneratingDrawing(ByVal sender As Object, ByVal e As DrawingGenerationContextEventArgs) Handles mContext.DrawingGenerationContextCreated

            ' Create a new handler to handle drawing events
            ' NOTE: Do this on two lines to avoid compiler 
            '       warnings about us not using the variable
            Dim handler As DrawingContextHandler
            handler = New DrawingContextHandler(mIntegrationCore, mExceptionHandler, e.Context)
        End Sub

#End Region

    End Class
End Class

