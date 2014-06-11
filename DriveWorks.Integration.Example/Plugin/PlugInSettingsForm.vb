Imports System.Windows.Forms

Public Class PlugInSettingsForm

    Private Sub TestButton_Click(sender As Object, e As EventArgs) Handles TestButton.Click

        ' Attempt a connection to the 3rd party system
        Dim mIntegration As New IntegrationCore

        Try

            ' Try connecting to the 3rd party system on
            If mIntegration.Connect(Me.UserName.Text, Me.Password.Text, Me.ConnectionString.Text) Then

                ' Let the user know the connection succeeded
                MessageBox.Show("Test Succeeded", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                ' Let the user know the connection failed
                MessageBox.Show("Test Failed", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

           

        Catch ex As Exception

            ' Let the user know
            MessageBox.Show(String.Format("test failed: {0}", ex.Message), "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class