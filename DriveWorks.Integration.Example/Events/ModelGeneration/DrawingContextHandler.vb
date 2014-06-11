Imports System.IO
Imports DriveWorks.Applications
Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks.Components

Partial Class GenerationServiceHandler

    ''' <summary>
    ''' Handles events for a drawing context 
    ''' </summary>
    ''' <remarks></remarks>
    Private Class DrawingContextHandler
        Private mExceptionHandler As IExceptionHandler
        Private mIntegrationCore As IntegrationCore
        Private WithEvents mDrawingContext As IDrawingGenerationContext

#Region " .ctor "

        Friend Sub New(ByVal integration As IntegrationCore, ByVal exceptionHandler As IExceptionHandler, ByVal context As IDrawingGenerationContext)
            mIntegrationCore = integration
            mExceptionHandler = exceptionHandler
            mDrawingContext = context
        End Sub

#End Region

#Region " Current Model "

        

        Private Sub mDrawingContext_Preparing(ByVal sender As Object, ByVal e As System.EventArgs) Handles mDrawingContext.Preparing
            Try

                'This event is raised when DriveWorks is preparing the files to drive

                ' Get/Set released drawing properties by getting the released drawing
                Dim thisDrawing = mDrawingContext.Drawing


                ' The underlying Model on the drawing is also available
                ' To Get/Set the released model information if its a part
                If TypeOf mDrawingContext.Model Is ReleasedPart Then   ' its a solidworks part

                    Dim thisPart As ReleasedPart = DirectCast(mDrawingContext.Model, ReleasedPart)

                    ' You can now get hold of any of the released part information, for instance the Driven Custom Properties.

                End If

                ' To Get/Set the released model information if its an assembly
                If TypeOf mDrawingContext.Model Is ReleasedAssembly Then   ' its a solidworks assembly

                    Dim thisAssembly As ReleasedAssembly = DirectCast(mDrawingContext.Model, ReleasedAssembly)

                    ' You can now get hold of any of the released assembly information, for instance the Driven Assembly Structure.

                End If

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_Prepared(sender As Object, e As EventArgs) Handles mDrawingContext.Prepared

            Try

                'This event is raised when DriveWorks is preparing the files to drive

                ' Get/Set released drawing properties by getting the released drawing
                Dim thisDrawing = mDrawingContext.Drawing


                ' The underlying Model on the drawing is also available
                ' To Get/Set the released model information if its a part
                If TypeOf mDrawingContext.Model Is ReleasedPart Then   ' its a solidworks part

                    Dim thisPart As ReleasedPart = DirectCast(mDrawingContext.Model, ReleasedPart)

                    ' You can now get hold of any of the released part information, for instance the Driven Custom Properties.

                End If

                ' To Get/Set the released model information if its an assembly
                If TypeOf mDrawingContext.Model Is ReleasedAssembly Then   ' its a solidworks assembly

                    Dim thisAssembly As ReleasedAssembly = DirectCast(mDrawingContext.Model, ReleasedAssembly)

                    ' You can now get hold of any of the released assembly information, for instance the Driven Assembly Structure.

                End If

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try

        End Sub

        Private Sub mDrawingContext_PreparationFailed(sender As Object, e As ExceptionEventArgs) Handles mDrawingContext.PreparationFailed
            Try

                'This event is raised if the model preperation fails for any reason

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_Generating(sender As Object, e As EventArgs) Handles mDrawingContext.Generating
            Try

                'This event is raised when DriveWorks starts generating a model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_Saving(sender As Object, e As EventArgs) Handles mDrawingContext.Saving
            Try

                'This event is raised just before DriveWorks saves the model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_Saved(sender As Object, e As EventArgs) Handles mDrawingContext.Saved
            Try

                'This event is raised after the model has been saved

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_Finished(sender As Object, e As EventArgs) Handles mDrawingContext.Finished
            Try

                'This event is raised after driveWorks has finished with the model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_GenerationFailed(sender As Object, e As ExceptionEventArgs) Handles mDrawingContext.GenerationFailed
            Try

                'This event is raised if the model generation fails for the current model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_Generated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mDrawingContext.Generated
            Try

                'This event is raised when DriveWorks has generated a model

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

#End Region

#Region " Additional File Formats "

        Private Sub mDrawingContext_AdditionalFileFormatRequesting(ByVal sender As Object, ByVal e As FileFormatGenerationEventArgs) Handles mDrawingContext.AdditionalFileFormatPreparing
            Try

                'This event is raised when the first request is made for an additional file format (For example edrawing or PDF)

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_AdditionalFileFormatPrepared(sender As Object, e As FileFormatGenerationEventArgs) Handles mDrawingContext.AdditionalFileFormatPrepared
            Try

                'This event is raised once the additional file format has been prepared

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_AdditionalFileFormatGenerating(sender As Object, e As FileFormatGenerationEventArgs) Handles mDrawingContext.AdditionalFileFormatGenerating
            Try

                'This event is raised before DriveWorks generates the additional file format

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_AdditionalFileFormatGenerated(ByVal sender As Object, ByVal e As FileFormatGenerationEventArgs) Handles mDrawingContext.AdditionalFileFormatGenerated
            Try

                'This event is raised once the additional file format has been created

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

        Private Sub mDrawingContext_AdditionalFileFormatGenerationFailed(sender As Object, e As FileFormatGenerationExceptionEventArgs) Handles mDrawingContext.AdditionalFileFormatGenerationFailed
            Try

                'This event is raised if the creation of the additional file format fails

            Catch ex As Exception

                ' Make sure we don't crash DriveWorks
                mExceptionHandler.HandleException(ex)
            End Try
        End Sub

#End Region
    End Class
End Class
