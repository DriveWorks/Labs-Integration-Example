' Import main DriveWorks types
Imports DriveWorks

' Import the Specification namespace so we have access to Specification flow
Imports DriveWorks.Specification

<Task("Create a New Account in the 3rd Party System", "embedded://DriveWorks.Integration.Example.Puzzle-16x16.png")> _
Public Class ExampleCreateAccount
    Inherits Task

    ' This task is bringing in all of the data as sepearte strings.
    ' It would be just as appropriate to pass the data in as a single array or named pairs, or by using variable prefix's or suffix's

    ' Register properties so DriveWorks can see them and build rules for them
    Private mBillingCity As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Billing City", New FlowPropertyInfo("This is the billing city, as text", "Billing Address"))
    Private mBillingState As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Billing State", New FlowPropertyInfo("This is the Billing State, as text", "Billing Address"))
    Private mBillingStreet As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Billing Street", New FlowPropertyInfo("This is the Billing Street, as text", "Billing Address"))
    Private mBillingPostalCode As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Billing Postal Code", New FlowPropertyInfo("This is the Billing Postal Code, as text", "Billing Address"))
    Private mBillingcountry As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Billing country", New FlowPropertyInfo("This is the Billing Country, as text", "Billing Address"))
    Private mDescription As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Account Description", New FlowPropertyInfo("This is the Account Description", "Additional Information"))
    Private mFax As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Fax", New FlowPropertyInfo("This is the Account Fax number", "Account Information"))
    Private mIndustry As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Industry", New FlowPropertyInfo("This is the Account Industry", "Additional Information"))
    Private mMyName As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Account Name", New FlowPropertyInfo("This is the Account Name", "Account Information"))
    Private mAccountID As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Account Id", New FlowPropertyInfo("This is the Account ID", "Account Information"))
    Private mNumberOfEmployees As FlowProperty(Of Integer) = Me.Properties.RegisterInt32Property("Number Of Employees", New FlowPropertyInfo("This is the number of Employees at the Account", "Additional Information"))
    Private mPhone As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Phone", New FlowPropertyInfo("This is the Account's main Phone number", "Account Information"))
    Private mWebsite As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Website", New FlowPropertyInfo("This is the Account's website", "Account Information"))
    Private mType As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Type", New FlowPropertyInfo("This is the Account Type", "Additional Information"))
    Private mShippingCity As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Shipping City", New FlowPropertyInfo("This is the Shipping city, as text", "Shipping Address"))
    Private mShippingState As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Shipping State", New FlowPropertyInfo("This is the Shipping State, as text", "Shipping Address"))
    Private mShippingStreet As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Shipping Street", New FlowPropertyInfo("This is the Shipping Street, as text", "Shipping Address"))
    Private mShippingPostalCode As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Shipping Postal Code", New FlowPropertyInfo("This is the Shipping Postal Code, as text", "Shipping Address"))
    Private mShippingcountry As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Shipping country", New FlowPropertyInfo("This is the Shipping Country, as text", "Shipping Address"))
    Private mAnnualRevenue As FlowProperty(Of Integer) = Me.Properties.RegisterInt32Property("Annual Revenue", New FlowPropertyInfo("This is the estimated Annual Revenue of the Account", "Additional Information"))
    Private mCustomFields As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Custom data", New FlowPropertyInfo("Data for custom fields in the format CustField1=Custvalue1|CustField2=CustValue2. (Not Required)", "Additional Information"))

    Private mReturnConstant As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Return Constant", New FlowPropertyInfo("The name of the constant that the new Account ID will be posted to", "Reporting", {StandardRuleTypes.ConstantName}))

    Protected Overrides Sub Execute(ByVal ctx As SpecificationContext)

        Dim result As Object
        Dim returnConstantname As String = mReturnConstant.Value
        Dim connected As Boolean = False

        Dim connectionManager = Connections.Instance.GetConnection(ctx.Project)

        Try

            Dim valuePairs As New Dictionary(Of String, String)

            ' collect the data into a dictionary.
            ' It doesn't have to be this way, any storage method is appropriate and should be created with regard to the data sending method (Some systems require a dictionary, some txt or xml, and others objects.)
            valuePairs("BillingCity") = mBillingCity.Value
            valuePairs("BillingState") = mBillingState.Value
            valuePairs("BillingStreet") = mBillingStreet.Value
            valuePairs("BillingPostalCode") = mBillingPostalCode.Value
            valuePairs("Description") = mDescription.Value
            valuePairs("Fax") = mFax.Value
            valuePairs("Industry") = mIndustry.Value
            valuePairs("Name") = mMyName.Value

            valuePairs("NumberOfEmployees") = mNumberOfEmployees.Value.ToString
            valuePairs("Phone") = mPhone.Value
            valuePairs("Website") = mWebsite.Value

            valuePairs("Type") = mType.Value
            valuePairs("ShippingCity") = mShippingCity.Value
            valuePairs("ShippingState") = mShippingState.Value
            valuePairs("ShippingStreet") = mShippingStreet.Value
            valuePairs("ShippingPostalCode") = mShippingPostalCode.Value
            valuePairs("Shippingcountry") = mShippingcountry.Value
            valuePairs("AnnualRevenue") = mAnnualRevenue.Value.ToString

            ' in this example, we are also have the ability to pass in custom field data
            For Each CustomField As String In mCustomFields.Value.Split("|"c)

                If CustomField.Contains("=") Then

                    Dim fieldName = CustomField.Split("="c)(0)

                    Dim fieldValue As String = String.Empty

                    fieldValue = CustomField.Substring(fieldName.Length + 1)

                    valuePairs(fieldName) = fieldValue

                End If

            Next

            ' send the data to the third party system
            result = connectionManager.RunWithRetry(Function(connection)
                                                        Return connection.CreateAccount(valuePairs)
                                                    End Function)

            ' white to the returnConstant if it exists or has been set.
            Dim theConstant As ProjectConstant = Nothing
            Dim constantName As String = mReturnConstant.Value

            If constantName.StartsWith("DWConstant", StringComparison.OrdinalIgnoreCase) Then

                constantName = constantName.Substring("DWConstant".Length)
            End If

            ' If the constant exists, write to it, if it doesn't, write to the spec report
            If ctx.Project.Constants.TryGetConstant(constantName, theConstant) Then

                ' Set the constant value 
                theConstant.Value = result
            Else

                ' Report that we couldn't find the constant
                ctx.Report.WriteEntry(Reporting.ReportingLevel.Minimal, Reporting.ReportEntryType.Error, "Create an account", "Constant: " & constantName, "The constant didn't exist", Nothing)
            End If

        Catch ex As Exception
            ' Report that we had a major problem
            ctx.Report.WriteEntry(Reporting.ReportingLevel.Minimal, Reporting.ReportEntryType.Error, "Create an account", "Error: " & ex.ToString, "Error creating account", Nothing)

        End Try

    End Sub

End Class
