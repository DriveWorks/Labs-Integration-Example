Imports System.Runtime.InteropServices
Imports DriveWorks.Components
Imports DriveWorks.Components.Tasks
Imports DriveWorks.Forms.DataModel
Imports DriveWorks.SolidWorks
Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks.Generation.Proxies
Imports SolidWorks.Interop.sldworks

Namespace SolidWorks

    <GenerationTaskCondition("Check the mass please",
                             "Great description",
                             Nothing,
                             "Amazing",
                              GenerationTaskScope.Assemblies Or GenerationTaskScope.Parts)>
    Public Class MassGenerationCondition
        Inherits GenerationTaskCondition

        Private Shared ReadOnly sValueProperty As New ComponentTaskParameterInfo(
            "Mass",
            "Mass Value",
            "Value to check for",
            "test",
            New ComponentTaskParameterMetaData(
                PropertyBehavior.StandardOptionDynamicManual,
                GetType(Double),
                0.0))

        Public Overrides ReadOnly Property Parameters As ComponentTaskParameterInfo()
            Get
                Return New ComponentTaskParameterInfo() {
                    sValueProperty
                }
            End Get
        End Property

        Protected Overrides Function Evaluate(model As SldWorksModelProxy,
                                              component As ReleasedComponent,
                                              generationSettings As GenerationSettings) As Boolean

            Dim comparisonValue As Double = -1

            If Not Me.Data.TryGetParameterValueAsDouble(sValueProperty.Name, comparisonValue) Then

                Me.EvaluationResultDetails =
                    String.Format(
                        "Could not convert the value '{0}' to a double for the value property.",
                        Me.Data.GetParameterValue(sValueProperty.Name))

                Return True
            End If

            Dim swValue = GetMassPropertyValue(model)

            Dim result = swValue = comparisonValue

            Me.EvaluationResultDetails =
                String.Format(
                    "Compared '{0}' with '{1}'",
                    swValue, comparisonValue)

            Return result
        End Function

        Private Shared Function GetMassPropertyValue(modelProxy As SldWorksModelProxy) As Double
            Dim swModel As IModelDoc2 = Nothing
            Dim modelExtension As ModelDocExtension = Nothing
            Dim massProperties As MassProperty = Nothing

            Try
                swModel = modelProxy.Model
                modelExtension = swModel.Extension
                massProperties = modelExtension.CreateMassProperty()

                Return massProperties.Mass
            Finally
                If massProperties IsNot Nothing Then
                    Marshal.ReleaseComObject(massProperties)
                    massProperties = Nothing
                End If

                If modelExtension IsNot Nothing Then
                    Marshal.ReleaseComObject(modelExtension)
                    modelExtension = Nothing
                End If

                If swModel IsNot Nothing Then
                    Marshal.ReleaseComObject(swModel)
                    swModel = Nothing
                End If
            End Try
        End Function

    End Class

    Friend Enum MassPropertyType
        Volume
        Density
        SurfaceArea
        Mass
    End Enum

End Namespace