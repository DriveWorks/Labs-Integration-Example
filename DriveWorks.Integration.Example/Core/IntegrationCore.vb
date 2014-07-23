Imports DriveWorks.Applications
Imports DriveWorks.SolidWorks.Components

Public Class IntegrationCore

    Private mUserName As String
    Private mPassword As String
    Private mConnectionString As String
    Private mLoggingService As IApplicationEventService

    Private mRespondToGenerationEvents As Boolean
    Private mRespondToSpecificationEvents As Boolean

    Private mProject As DriveWorks.Project

    Private mConnected As Boolean = False

#Region "    ctor    "

    Public Sub New()


    End Sub

    Public Sub New(project As DriveWorks.Project)

        mProject = project

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Log As IApplicationEventService
        Get
            Return mLoggingService
        End Get
        Set(value As IApplicationEventService)
            mLoggingService = value
        End Set
    End Property

    ''' <summary>
    ''' Loads/reloads settings.
    ''' </summary>
    ''' <param name="settings">The settings object.</param>
    ''' <remarks></remarks>
    Friend Sub LoadSettings(ByVal settings As PluginSettings)

        ' Store the settings
        mUserName = settings.UserName
        mPassword = settings.Password
        mConnectionString = settings.ConnectionString

        mRespondToGenerationEvents = settings.RespondToGenerationEvents
        mRespondToSpecificationEvents = settings.RespondToSpecificationEvents

        '
        ' Clear settings-related state
        '

        '
        ' Create the 3rd party connection
        '

    End Sub

    Public Function Connect() As Boolean

        Return Connect(mUserName, mPassword, mConnectionString)

    End Function

    Public Function Disconnect() As Boolean

        ' Add your own disconnection code here
        mConnected = False

        Return True
    End Function

    Public Function Connect(username As String, password As String, connectionString As String) As Boolean

        ' Add validation code here to check that the connection is possible
        mConnected = True

        Return True

    End Function

    Public ReadOnly Property Connected() As Boolean
        Get
            ' Maybe use a private member variable value that you set at the point of connection
            Return mConnected
        End Get

    End property

    Public ReadOnly Property Status As String
        Get
            ' Status as a string could give more information regarding the connection
            If mConnected Then
                Return "Currently Connected"
            Else
                Return "Not Connected"
            End If
        End Get
    End Property

    Public ReadOnly Property ConnectionString() As String
        Get
            Return mConnectionString
        End Get
    End Property

    Public ReadOnly Property UserName() As String
        Get
            Return mUserName
        End Get
    End Property


#End Region

#Region " Model Generation Actions"

    Public Function ActOnModelPreperation(model As ReleasedModel) As Boolean

        ' To Get/Set the released model information if its a part
        If TypeOf model Is ReleasedPart Then   ' its a solidworks part

            Dim thisPart As ReleasedPart = DirectCast(model, ReleasedPart)

            ' You can now get hold of any of the released part information, for instance the Driven Custom Properties.

            For Each customProperty In thisPart.CustomProperties

                ' set one of the custom properties here

            Next

        End If

        ' To Get/Set the released model information if its an assembly
        If TypeOf model Is ReleasedAssembly Then   ' its a solidworks assembly

            Dim thisAssembly As ReleasedAssembly = DirectCast(model, ReleasedAssembly)

            ' You can now get hold of any of the released assembly information, for instance the Driven Assembly Structure.

            For Each child In thisAssembly.Instances

                ' get the instance information here
                ' you could then for example work out is a model being replaced exists

            Next

        End If

        Return True

    End Function

    Public Function ActOnModelPrepared(model As ReleasedModel) As Boolean

        ' To Get/Set the released model information if its a part
        If TypeOf model Is ReleasedPart Then   ' its a solidworks part

            Dim thisPart As ReleasedPart = DirectCast(model, ReleasedPart)

            ' You can now get hold of any of the released part information, for instance the Driven dimensions.

            For Each dimension In thisPart.Dimensions

                ' You could get a dimension value here, and based on  material cost per length, work out the part price and write it to a custom property.

            Next

        End If

        ' To Get/Set the released model information if its an assembly
        If TypeOf model Is ReleasedAssembly Then   ' its a solidworks assembly

            Dim thisAssembly As ReleasedAssembly = DirectCast(model, ReleasedAssembly)

            ' You can now get hold of any of the released assembly information, for instance the Driven Assembly Structure.

            For Each child In thisAssembly.Instances

                ' get the instance information here

            Next

        End If

        Return True

    End Function

    Public Sub BeginBatch()

        ' Are we enabled?
        If Not IsEnabled() Then

            Return
        End If

        SyncLock Me

            ' enter your begin batch code here

        End SyncLock
    End Sub

    Public Sub EndBatch()

        ' Are we enabled?
        If Not IsEnabled() Then

            Return
        End If

        SyncLock Me
            ' enter your end batch code here

        End SyncLock
    End Sub

#End Region

#Region " Accounts and Contacts "

    Public Function GetAccounts(filtertext As String) As String(,)

        ' Insert Code here that will get the account details for all accounts that match the filter criteria

        ' This example has dummy data.  replace this with your code for getting accounts.
        ' This example does not make use of the filtertext parameter
        Dim returnText(4, 3) As String

        returnText(0, 0) = "ID"
        returnText(0, 1) = "Company Name"
        returnText(0, 2) = "City"
        returnText(0, 3) = "Country"

        returnText(1, 0) = "001"
        returnText(1, 1) = "Acme Inc"
        returnText(1, 2) = "New York"
        returnText(1, 3) = "USA"

        returnText(2, 0) = "002"
        returnText(2, 1) = "Bobby Bobs"
        returnText(2, 2) = "York"
        returnText(2, 3) = "UK"

        returnText(3, 0) = "003"
        returnText(3, 1) = "Craigs Tools"
        returnText(3, 2) = "Quite New York"
        returnText(3, 3) = "South Africa"

        returnText(4, 0) = "004"
        returnText(4, 1) = "Danny Dykes Bykes"
        returnText(4, 2) = "Old York"
        returnText(4, 3) = "Austrailia"

        Return returnText

    End Function

    Public Function GetContacts(accountID As String) As String(,)

        ' Insert Code here that will get the contact details for the listed account accounts that match the filter criteria
        ' This example has dummy data.  replace this with your code for getting accounts.
        Dim rowCount As Integer
        Dim currentRow As Integer

        If String.IsNullOrEmpty(accountID) Then

            rowCount = 8
        Else
            rowCount = 3
        End If

        Dim returnText(rowCount, 3) As String

        returnText(currentRow, 0) = "ID"
        returnText(currentRow, 1) = "Contact Name"
        returnText(currentRow, 2) = "EmailAddress"
        returnText(currentRow, 3) = "Company ID"

        currentRow = currentRow + 1

        ' In this example the return values will depend on the account name, which is based on the accounts retreived through the GetAccounts function

        If accountID = "001" Or accountID = "" Then
            returnText(currentRow, 0) = "00001"
            returnText(currentRow, 1) = "Bobby Acme"
            returnText(currentRow, 2) = "bobby.acme@acme.com"
            returnText(currentRow, 3) = "001"
            currentRow = currentRow + 1
            returnText(currentRow, 0) = "00002"
            returnText(currentRow, 1) = "Bobbetta Acme"
            returnText(currentRow, 2) = "bobbetta.acme@acme.com"
            returnText(currentRow, 3) = "001"
            currentRow = currentRow + 1
        End If
        If accountID = "002" Or accountID = "" Then
            returnText(currentRow, 0) = "00003"
            returnText(currentRow, 1) = "Robert Bob"
            returnText(currentRow, 2) = "bobby.acme@bb.co.uk"
            returnText(currentRow, 3) = "002"
            currentRow = currentRow + 1
            returnText(currentRow, 0) = "00004"
            returnText(currentRow, 1) = "Roberta Bob"
            returnText(currentRow, 2) = "roberta.bob@bb.co.uk"
            returnText(currentRow, 3) = "002"
            currentRow = currentRow + 1
        End If
        If accountID = "003" Or accountID = "" Then
            returnText(currentRow, 0) = "00005"
            returnText(currentRow, 1) = "Craig McFly"
            returnText(currentRow, 2) = "cmcfly@ctw.sa"
            returnText(currentRow, 3) = "003"
            currentRow = currentRow + 1
            returnText(currentRow, 0) = "00006"
            returnText(currentRow, 1) = "Karen McFly"
            returnText(currentRow, 2) = "kmcfly@ctw.sa"
            returnText(currentRow, 3) = "003"
            currentRow = currentRow + 1
        End If
        If accountID = "004" Or accountID = "" Then
            returnText(currentRow, 0) = "00007"
            returnText(currentRow, 1) = "Bobby Acme"
            returnText(currentRow, 2) = "dannydykes@bykes.com.au"
            returnText(currentRow, 3) = "004"
            currentRow = currentRow + 1
            returnText(currentRow, 0) = "00008"
            returnText(currentRow, 1) = "tonycaroni"
            returnText(currentRow, 2) = "tonicaroni.acme@bykes.com.au"
            returnText(currentRow, 3) = "004"

        End If

        Return returnText

    End Function

    Public Function CreateAccount(accountParameters As Dictionary(Of String, String)) As Object

        ' place your create account code here
        Return "Account Created"

    End Function

    Public Function CreateContact(contactParameters As Dictionary(Of String, String)) As Object

        ' place your create contact code here
        Return "Contact Created"

    End Function
#End Region

#Region " Document Handling "

    Public Sub RegisterDocument(filePath As String)

        Try
            ' add your code here for registering a generated document in the 3rd Party System


            ' then report on it being added
            LogMessage(ApplicationEventType.Success, "EXAMPLEIntegration", String.Format("The file '{0}' has been successfully registered", filePath), "Document Registered", Nothing)
        Catch ex As Exception

            ' It went wrong, log it
            LogMessage(ApplicationEventType.Error, "EXAMPLEIntegration", String.Format("The file '{0}' could not be registered", filePath), "Exception", ex)
        End Try

    End Sub


#End Region

#Region " Items and BOMS "

    Public Function GetItems(filtertext As String) As String(,)

        ' Insert Code here that will get the details for all Items that match the filter criteria

        ' This example has dummy data.  replace this with your code for getting items.
        ' This example does not make use of the filtertext parameter
        Dim returnText(6, 3) As String

        returnText(0, 0) = "ID"
        returnText(0, 1) = "Part Number"
        returnText(0, 2) = "Description"
        returnText(0, 3) = "Revision"

        returnText(1, 0) = "PRT001"
        returnText(1, 1) = "ABC123"
        returnText(1, 2) = "An ABC style component with a 123 size"
        returnText(1, 3) = "1"

        returnText(2, 0) = "PRT002"
        returnText(2, 1) = "XYZ543"
        returnText(2, 2) = "An XYZ component module that is 543 big"
        returnText(2, 3) = "2"

        returnText(3, 0) = "PRT003"
        returnText(3, 1) = "112233"
        returnText(3, 2) = "A nice 1122 with a 33 option"
        returnText(3, 3) = "1"

        returnText(4, 0) = "PRT004"
        returnText(4, 1) = "BEER1"
        returnText(4, 2) = "The first pint of beer on a winters night"
        returnText(4, 3) = "23"

        returnText(5, 0) = "ASM001"
        returnText(5, 1) = "EVERYTHING001"
        returnText(5, 2) = "The main assembly with everything in"
        returnText(5, 3) = "2"

        returnText(6, 0) = "ASM002"
        returnText(6, 1) = "NOTEVERYTHING002"
        returnText(6, 2) = "A small assembly with 2 things in"
        returnText(6, 3) = "0"

        Return returnText

    End Function

    Public Function GetBOMItems(BomID As String) As String(,)

        ' Insert Code here that will get the details for all Items in a specific bill of materials

        ' This example has dummy data.  replace this with your code for getting items.
        Dim rowCount As Integer

        If String.IsNullOrEmpty(BomID) Then

            rowCount = 0
        Else
            If BomID = "ASM001" Then
                rowCount = 5
            End If
            If BomID = "ASM002" Then
                rowCount = 2
            End If

        End If

        Dim returnText(rowCount, 3) As String

        returnText(0, 0) = "ID"
        returnText(0, 1) = "Parent"
        returnText(0, 2) = "Child"
        returnText(0, 3) = "Quantity"

        If BomID = "ASM001" Then

            returnText(1, 0) = "BOM001"
            returnText(1, 1) = "ASM001"
            returnText(1, 2) = "ABC123"
            returnText(1, 3) = "1"

            returnText(2, 0) = "BOM002"
            returnText(2, 1) = "ASM001"
            returnText(2, 2) = "XYZ543"
            returnText(2, 3) = "2"

            returnText(3, 0) = "BOM003"
            returnText(3, 1) = "ASM001"
            returnText(3, 2) = "112233"
            returnText(3, 3) = "6"

            returnText(4, 0) = "BOM004"
            returnText(4, 1) = "ASM001"
            returnText(4, 2) = "BEER1"
            returnText(4, 3) = "6"

            returnText(5, 0) = "BOM005"
            returnText(5, 1) = "ASM001"
            returnText(5, 2) = "NOTEVERYTHING002"
            returnText(5, 3) = "10"

        End If
        If BomID = "ASM002" Then
            returnText(1, 0) = "BOM006"
            returnText(1, 1) = "ASM002"
            returnText(1, 2) = "XYZ543"
            returnText(1, 3) = "345"

            returnText(2, 0) = "BOM007"
            returnText(2, 1) = "ASM002"
            returnText(2, 2) = "BEER1"
            returnText(2, 3) = "12"
        End If

        Return returnText

    End Function
#End Region

    Private Sub LogMessage(ByVal eventType As ApplicationEventType, ByVal target As String, ByVal description As String, ByVal task As String, ByVal ex As Exception)

        If mLoggingService Is Nothing Then
            Trace.WriteLine(String.Format("DriveWorks Integration Example ({0}) {1}: {2}", eventType, task, description))
        Else
            mLoggingService.AddEvent(eventType, "DriveWorks.Integration.Example", "DriveWorks Integration Example", description, Nothing, target, Nothing)
        End If

    End Sub

    Private Function IsEnabled() As Boolean
        Return Not String.IsNullOrEmpty(mConnectionString)
    End Function

End Class
