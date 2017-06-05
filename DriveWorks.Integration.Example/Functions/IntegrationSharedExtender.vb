Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class IntegrationSharedExtender

    Inherits SharedProjectExtender

    Private Function GetConnectionManager() As ConnectionManager
        Static Dim connectionManager As ConnectionManager = Connections.Instance.GetConnection(Me.Project)
        Return connectionManager
    End Function

    <Udf()>
    <FunctionInfo("Returns a String value that describes the current status of the connection to the third party system")>
    Public Function EXAMPLEConnectionStatus(<ParamInfo("Trigger", "Change this value in order to re-evaluate the function")> trigger As Object) As String

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return connection.Status
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve Connection status: " & ex.Message
        End Try

    End Function

    <Udf()>
    <FunctionInfo("Returns a Boolean value representing if the connection to the 3rd party system is open")>
    Public Function EXAMPLEConnected(<ParamInfo("Trigger", "Change this value in order to re-evaluate the function")> trigger As Object) As Object

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return connection.Connected()
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve Connected status: " & ex.Message
        End Try

    End Function

    <Udf()>
    <FunctionInfo("Returns the 3rd Party connection string, based on the settings for this plugin")>
    Public Function EXAMPLEConnectionString() As String

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return connection.ConnectionString
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve Connection String: " & ex.Message
        End Try

    End Function

    <Udf()>
    <FunctionInfo("Returns the 3rd Party username, based on the settings for this plugin")>
    Public Function EXAMPLEUserName() As String

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return connection.UserName
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve user name: " & ex.Message
        End Try

    End Function


    <Udf()>
    <FunctionInfo("Returns a table array including headers of all of the account details for all accounts")>
    Public Function EXAMPLEGetAccounts(<ParamInfo("Filter Text", "Text to use for filtering the accounts")> filterText As String) As Object

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return New StandardArrayValue(connection.GetAccounts(filterText))
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve accounts: " & ex.Message
        End Try

    End Function

    <Udf()>
    <FunctionInfo("Returns a table array including headers of all of the contacts for a specific account")>
    Public Function EXAMPLEGetContacts(<ParamInfo("AccountID", "The accountID for who contacts will be retrieved (leave blank to get all contacts)")> accountID As String) As Object

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return New StandardArrayValue(connection.GetContacts(accountID))
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve accounts: " & ex.Message
        End Try

    End Function

    <Udf()>
    <FunctionInfo("Returns a table array including headers of all of the items")>
    Public Function EXAMPLEGetItems(<ParamInfo("Filter Text", "Text to use for filtering the items")> filterText As String) As Object

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return New StandardArrayValue(connection.GetItems(filterText))
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve items: " & ex.Message
        End Try

    End Function

    <Udf()>
    <FunctionInfo("Returns a table array including headers of all of the items in a specific BOM")>
    Public Function EXAMPLEGetBOMItems(<ParamInfo("BOMID", "The BOMID for which items will be retrieved.")> bomID As String) As Object

        Try
            Return GetConnectionManager().RunWithRetry(Function(connection)
                                                           Return New StandardArrayValue(connection.GetBOMItems(bomID))
                                                       End Function)
        Catch ex As Exception
            Return "#EXAMPLE! Unable to retrieve BOM items: " & ex.Message
        End Try

    End Function



End Class
