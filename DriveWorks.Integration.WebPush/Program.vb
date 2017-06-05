Module Program

    Public Sub Main()

        ' This will attempt to connect to a local autopilot service (http://localhost:8901/SpecificationAutomation)
        Using client As New DriveWorksSpecificationAutomation.HttpConnectorServiceClient()

            ' Create a specification based on the 'Test' project, run the save transition and get information about it
            ' Drive some values into the specification too (See: value:=new Dictionary...)
            Dim creationResult =
                client.CreateSpecification(
                    projectName:="Test",
                    transitionName:="Save",
                    values:=New Dictionary(Of String, String)() From {
                        {"ATextBoxValue", "Cool"},
                        {"ACheckBoxValue", "True"},
                        {"DWConstantAConstantValue", "Dude"}
                    })

            ' Make sure it worked
            If creationResult.Status <> DriveWorksSpecificationAutomation.SpecificationRequestResult.Succeeded Then

                ' This might happen if you don't have a project called test or doesn't have a transition called save etc
                Return
            End If

            ' Run the delete operation to remove the specification that we just created
            client.EditSpecification(
                projectName:=Nothing,
                transitionName:=Nothing,
                specificationName:=creationResult.SpecificationName,
                specificationId:=Nothing,
                operationName:="Delete",
                values:=New Dictionary(Of String, String)())
        End Using
    End Sub

End Module
