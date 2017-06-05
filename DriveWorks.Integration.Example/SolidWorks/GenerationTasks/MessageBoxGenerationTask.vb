Imports System.IO
Imports DriveWorks.Components
Imports DriveWorks.Components.Tasks
Imports DriveWorks.SolidWorks
Imports DriveWorks.SolidWorks.Components
Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks.Generation.Proxies

Namespace SolidWorks

    <GenerationTask("Annoying Message Box",
                    "Spot on description",
                    Nothing,
                    "Amazing",
                    GenerationTaskScope.All)>
    Public Class MessageBoxGenTask
        Inherits GenerationTask

        Private Shared ReadOnly sMessageProperty As New ComponentTaskParameterInfo(
            "Message",
            "Annoying Message",
            "Doesn't actually have to be annoying, the fact that dialog popped up will make it plenty annoying",
            "Test")

        Public Overrides ReadOnly Property Parameters As ComponentTaskParameterInfo()
            Get
                Return New ComponentTaskParameterInfo() {
                    sMessageProperty
                }
            End Get
        End Property

        Public Overrides Sub Execute(model As SldWorksModelProxy,
                                     component As ReleasedComponent,
                                     generationSettings As GenerationSettings)

            Dim messageValue As String = Nothing
            If Not Me.Data.TryGetParameterValue(sMessageProperty.Name, True, messageValue) Then

                Me.SetExecutionResult(
                    TaskExecutionResult.SuccessWithWarnings,
                    "No value specified for message")

                Return
            End If

            Dim asReleasedPart = TryCast(component, ReleasedPart)
            Dim asReleasedAssembly = TryCast(component, ReleasedAssembly)
            Dim asReleasedDrawing = TryCast(component, ReleasedDrawing)

            Dim filename = Path.GetFileNameWithoutExtension(model.Path)
            Dim componentType =
                If(asReleasedPart IsNot Nothing, "Part",
                    If(asReleasedAssembly IsNot Nothing, "Assembly",
                        If(asReleasedDrawing IsNot Nothing, "Drawing",
                            "Unknown Type")))

            Dim wrappingText = $"{filename} ({componentType}) says: {{0}}"

            Dim result =
                Windows.Forms.MessageBox.Show(
                    String.Format(wrappingText, messageValue),
                    "Annoying Message")

            Me.SetExecutionResult(
                TaskExecutionResult.Success,
                "Said the message")
        End Sub

    End Class

End Namespace