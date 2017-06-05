Imports DriveWorks.Components.Tasks
Imports DriveWorks.Specification

Namespace SolidWorks

    <ComponentTaskCondition("Fun Condition",
                            "Description goes here",
                            Nothing,
                            "Amazing")>
    Public Class FunComponentSpecificationCondition
        Inherits ComponentTaskReleaseCondition

        Private ReadOnly mValueProperty As FlowProperty(Of String) =
            Me.Properties.RegisterStringProperty(
                "Value",
                New FlowPropertyInfo(
                    "A value to check",
                    "Test"))

        Protected Overrides Function Evaluate(specificationContext As SpecificationContext) As Boolean

            ' If the tasks 'Value' property is driven to 'fun' then this condition passes
            Return String.Equals(mValueProperty.Value, "fun", StringComparison.OrdinalIgnoreCase)
        End Function
    End Class
End Namespace