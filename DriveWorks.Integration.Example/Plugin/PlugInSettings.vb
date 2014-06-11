Imports DriveWorks.Applications
Imports System.Security.Cryptography

''' <summary>
''' Provides access to the plugins settings.
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class PluginSettings
    Private Const SETTING_BASE As String = "Common\Examples\Integration\"
    Private Const SETTING_USER_NAME As String = SETTING_BASE & "UserName"
    Private Const SETTING_PASSWORD As String = SETTING_BASE & "Password"
    Private Const SETTING_CONNECTION_STRING As String = SETTING_BASE & "ConnectionString"

    Private Const SETTING_RESPOND_TO_MODEL_GENERATION_EVENTS As String = SETTING_BASE & "RespondToGenerationEvents"
    Private Const SETTING_RESPOND_TO_SPECIFICATION_EVENTS As String = SETTING_BASE & "RespondToSpecificationEvents"

    Private mSettingsManager As ISettingsManager

#Region " .ctor "

    ''' <summary>
    ''' Initializes a new instance of the <see cref="PluginSettings" /> class.Glen Smith
    ''' </summary>
    ''' <param name="settingsManager">The settings manager to wrap.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal settingsManager As ISettingsManager)
        mSettingsManager = settingsManager
    End Sub

#End Region

#Region " Properties "

    ''' <summary>
    ''' Gets/sets the User name used to connect to the 3rd party system.
    ''' </summary>
    ''' <remarks></remarks>
    Public Property UserName() As String
        Get
            Return mSettingsManager.GetSettingAsString(SettingLevel.User, SETTING_USER_NAME, False)
        End Get
        Set(ByVal value As String)
            mSettingsManager.SetSetting(SettingLevel.User, SETTING_USER_NAME, value, False)
        End Set
    End Property

    ''' <summary>
    ''' Gets/sets the password to use to connect to the 3rd party system.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Password() As String
        Get
            Return WeakDecrypt(mSettingsManager.GetSettingAsString(SettingLevel.User, SETTING_PASSWORD, False))
        End Get
        Set(ByVal value As String)
            mSettingsManager.SetSetting(SettingLevel.User, SETTING_PASSWORD, WeakEncrypt(value), False)
        End Set
    End Property

    ''' <summary>
    ''' Gets/sets the connection string used to connect to the 3rd party system.
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ConnectionString() As String
        Get
            Return mSettingsManager.GetSettingAsString(SettingLevel.User, SETTING_CONNECTION_STRING, False)
        End Get
        Set(ByVal value As String)
            mSettingsManager.SetSetting(SettingLevel.User, SETTING_CONNECTION_STRING, value, False)
        End Set
    End Property

    ''' <summary>
    ''' Gets/sets whether to respond to model generation events.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RespondToGenerationEvents() As Boolean
        Get
            Dim value As Boolean

            If mSettingsManager.TryGetSettingAsBoolean(SettingLevel.User, SETTING_RESPOND_TO_MODEL_GENERATION_EVENTS, False, value) Then
                Return value
            Else
                Return True
            End If
        End Get
        Set(ByVal value As Boolean)
            mSettingsManager.SetSetting(SettingLevel.User, SETTING_RESPOND_TO_MODEL_GENERATION_EVENTS, value, False)
        End Set
    End Property

    ''' <summary>
    ''' Gets/sets whether to respond to specification events.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RespondToSpecificationEvents() As Boolean
        Get
            Dim value As Boolean

            If mSettingsManager.TryGetSettingAsBoolean(SettingLevel.User, SETTING_RESPOND_TO_SPECIFICATION_EVENTS, False, value) Then
                Return value
            Else
                Return True
            End If
        End Get
        Set(ByVal value As Boolean)
            mSettingsManager.SetSetting(SettingLevel.User, SETTING_RESPOND_TO_SPECIFICATION_EVENTS, value, False)
        End Set
    End Property

#End Region

#Region " Weak Encryption/Decryption "

    ''' <summary>
    ''' Encrypts a string by using the Windows Data Protection API scoped to the current user.
    ''' </summary>
    ''' <param name="uncryptedString">The string to encrypt.</param>
    ''' <returns>The encrypted string.</returns>
    ''' <remarks></remarks>
    Private Shared Function WeakEncrypt(ByVal uncryptedString As String) As String

        ' Nothing to do if there's nothing to work with
        If uncryptedString Is Nothing Then
            Return Nothing
        End If

        ' Encryption function works with bytes, so get a byte representation of the string
        Dim bytes = System.Text.Encoding.UTF8.GetBytes(uncryptedString)

        ' Use the data protection API built into Windows to perform the actual encryption
        ' such that only the current user can decrypt
        Dim encrypted = ProtectedData.Protect(bytes, Nothing, DataProtectionScope.CurrentUser)

        ' Convert back to a string that we're able to use with DriveWorks' settings API
        Dim encryptedString = Convert.ToBase64String(encrypted)

        ' All done
        Return encryptedString
    End Function

    ''' <summary>
    ''' Decrypts a string by using the Windows Data Protection API scoped to the current user.
    ''' </summary>
    ''' <param name="encryptedString">The string to decrypt.</param>
    ''' <returns>The decrypted string.</returns>
    ''' <remarks></remarks>
    Private Shared Function WeakDecrypt(ByVal encryptedString As String) As String

        ' Nothing to do if there's nothing to work with
        If encryptedString Is Nothing Then
            Return Nothing
        End If

        ' We store the encrypted data in the registry as a string, so convert back to the bytes
        ' that the decryption API is expecting
        Dim encryptedBytes = Convert.FromBase64String(encryptedString)

        ' Use the data protection API built into Windows to perform the actual decryption
        ' - the parameters here must match the ones we used for encryption
        Dim decryptedBytes = ProtectedData.Unprotect(encryptedBytes, Nothing, DataProtectionScope.CurrentUser)

        ' The encrypted byes are the UTF8 bytes representing the string, so decode them now
        Dim decryptedString = System.Text.Encoding.UTF8.GetString(decryptedBytes)

        ' All done
        Return decryptedString
    End Function

#End Region

End Class

