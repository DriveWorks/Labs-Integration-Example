<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlugInSettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlugInSettingsForm))
        Me.HeaderLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.HeaderLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.FooterLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TestButton = New System.Windows.Forms.Button()
        Me.FinishButton = New System.Windows.Forms.Button()
        Me.DlgCancelButton = New System.Windows.Forms.Button()
        Me.BodyPanel = New System.Windows.Forms.Panel()
        Me.BodyLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.SpecificationEventsLabel = New System.Windows.Forms.Label()
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.ConnectionStringlabel = New System.Windows.Forms.Label()
        Me.ConnectionString = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.SpecificationEventsCheck = New System.Windows.Forms.CheckBox()
        Me.ModelEventsCheck = New System.Windows.Forms.CheckBox()
        Me.ModelEventsLabel = New System.Windows.Forms.Label()
        Me.HeaderLayoutPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FooterLayoutPanel.SuspendLayout()
        Me.BodyPanel.SuspendLayout()
        Me.BodyLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeaderLayoutPanel
        '
        Me.HeaderLayoutPanel.BackColor = System.Drawing.Color.White
        Me.HeaderLayoutPanel.ColumnCount = 2
        Me.HeaderLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.HeaderLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.HeaderLayoutPanel.Controls.Add(Me.DescriptionLabel, 0, 1)
        Me.HeaderLayoutPanel.Controls.Add(Me.HeaderLabel, 0, 0)
        Me.HeaderLayoutPanel.Controls.Add(Me.PictureBox1, 1, 0)
        Me.HeaderLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLayoutPanel.Name = "HeaderLayoutPanel"
        Me.HeaderLayoutPanel.RowCount = 2
        Me.HeaderLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.HeaderLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.HeaderLayoutPanel.Size = New System.Drawing.Size(517, 82)
        Me.HeaderLayoutPanel.TabIndex = 3
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Location = New System.Drawing.Point(3, 29)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Padding = New System.Windows.Forms.Padding(8)
        Me.DescriptionLabel.Size = New System.Drawing.Size(274, 29)
        Me.DescriptionLabel.TabIndex = 2
        Me.DescriptionLabel.Text = "Example DriveWorks Integration Plugin Settings Form"
        '
        'HeaderLabel
        '
        Me.HeaderLabel.AutoSize = True
        Me.HeaderLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLabel.Location = New System.Drawing.Point(3, 0)
        Me.HeaderLabel.Name = "HeaderLabel"
        Me.HeaderLabel.Padding = New System.Windows.Forms.Padding(8)
        Me.HeaderLabel.Size = New System.Drawing.Size(205, 29)
        Me.HeaderLabel.TabIndex = 1
        Me.HeaderLabel.Text = "DriveWorks Integration Example"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(443, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.HeaderLayoutPanel.SetRowSpan(Me.PictureBox1, 2)
        Me.PictureBox1.Size = New System.Drawing.Size(68, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'FooterLayoutPanel
        '
        Me.FooterLayoutPanel.ColumnCount = 4
        Me.FooterLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.FooterLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.FooterLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.FooterLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.FooterLayoutPanel.Controls.Add(Me.TestButton, 0, 0)
        Me.FooterLayoutPanel.Controls.Add(Me.FinishButton, 3, 0)
        Me.FooterLayoutPanel.Controls.Add(Me.DlgCancelButton, 2, 0)
        Me.FooterLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FooterLayoutPanel.Location = New System.Drawing.Point(0, 265)
        Me.FooterLayoutPanel.Name = "FooterLayoutPanel"
        Me.FooterLayoutPanel.RowCount = 1
        Me.FooterLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.FooterLayoutPanel.Size = New System.Drawing.Size(517, 31)
        Me.FooterLayoutPanel.TabIndex = 9
        '
        'TestButton
        '
        Me.TestButton.Location = New System.Drawing.Point(3, 3)
        Me.TestButton.Name = "TestButton"
        Me.TestButton.Size = New System.Drawing.Size(75, 25)
        Me.TestButton.TabIndex = 0
        Me.TestButton.Text = "&Test"
        Me.TestButton.UseVisualStyleBackColor = True
        '
        'FinishButton
        '
        Me.FinishButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.FinishButton.Location = New System.Drawing.Point(439, 3)
        Me.FinishButton.Name = "FinishButton"
        Me.FinishButton.Size = New System.Drawing.Size(75, 25)
        Me.FinishButton.TabIndex = 1
        Me.FinishButton.Text = "&Finish"
        Me.FinishButton.UseVisualStyleBackColor = True
        '
        'DlgCancelButton
        '
        Me.DlgCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DlgCancelButton.Location = New System.Drawing.Point(358, 3)
        Me.DlgCancelButton.Name = "DlgCancelButton"
        Me.DlgCancelButton.Size = New System.Drawing.Size(75, 25)
        Me.DlgCancelButton.TabIndex = 2
        Me.DlgCancelButton.Text = "&Cancel"
        Me.DlgCancelButton.UseVisualStyleBackColor = True
        '
        'BodyPanel
        '
        Me.BodyPanel.Controls.Add(Me.BodyLayoutPanel)
        Me.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BodyPanel.Location = New System.Drawing.Point(0, 82)
        Me.BodyPanel.Name = "BodyPanel"
        Me.BodyPanel.Padding = New System.Windows.Forms.Padding(8)
        Me.BodyPanel.Size = New System.Drawing.Size(517, 183)
        Me.BodyPanel.TabIndex = 10
        '
        'BodyLayoutPanel
        '
        Me.BodyLayoutPanel.ColumnCount = 2
        Me.BodyLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.BodyLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.BodyLayoutPanel.Controls.Add(Me.SpecificationEventsLabel, 0, 5)
        Me.BodyLayoutPanel.Controls.Add(Me.UserName, 1, 0)
        Me.BodyLayoutPanel.Controls.Add(Me.ConnectionStringlabel, 0, 2)
        Me.BodyLayoutPanel.Controls.Add(Me.ConnectionString, 1, 2)
        Me.BodyLayoutPanel.Controls.Add(Me.PasswordLabel, 0, 1)
        Me.BodyLayoutPanel.Controls.Add(Me.Password, 1, 1)
        Me.BodyLayoutPanel.Controls.Add(Me.UserNameLabel, 0, 0)
        Me.BodyLayoutPanel.Controls.Add(Me.SpecificationEventsCheck, 1, 5)
        Me.BodyLayoutPanel.Controls.Add(Me.ModelEventsCheck, 1, 4)
        Me.BodyLayoutPanel.Controls.Add(Me.ModelEventsLabel, 0, 4)
        Me.BodyLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BodyLayoutPanel.Location = New System.Drawing.Point(8, 8)
        Me.BodyLayoutPanel.Name = "BodyLayoutPanel"
        Me.BodyLayoutPanel.Padding = New System.Windows.Forms.Padding(2)
        Me.BodyLayoutPanel.RowCount = 7
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.BodyLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.BodyLayoutPanel.Size = New System.Drawing.Size(501, 167)
        Me.BodyLayoutPanel.TabIndex = 8
        '
        'SpecificationEventsLabel
        '
        Me.SpecificationEventsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.SpecificationEventsLabel.AutoSize = True
        Me.SpecificationEventsLabel.Location = New System.Drawing.Point(5, 115)
        Me.SpecificationEventsLabel.Name = "SpecificationEventsLabel"
        Me.SpecificationEventsLabel.Size = New System.Drawing.Size(166, 13)
        Me.SpecificationEventsLabel.TabIndex = 8
        Me.SpecificationEventsLabel.Text = "Respond To Specification Events"
        '
        'UserName
        '
        Me.UserName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UserName.Location = New System.Drawing.Point(200, 5)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(214, 20)
        Me.UserName.TabIndex = 0
        '
        'ConnectionStringlabel
        '
        Me.ConnectionStringlabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ConnectionStringlabel.AutoSize = True
        Me.ConnectionStringlabel.Location = New System.Drawing.Point(5, 60)
        Me.ConnectionStringlabel.Name = "ConnectionStringlabel"
        Me.ConnectionStringlabel.Size = New System.Drawing.Size(91, 13)
        Me.ConnectionStringlabel.TabIndex = 4
        Me.ConnectionStringlabel.Text = "Connection String"
        '
        'ConnectionString
        '
        Me.ConnectionString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConnectionString.Location = New System.Drawing.Point(200, 57)
        Me.ConnectionString.Name = "ConnectionString"
        Me.ConnectionString.Size = New System.Drawing.Size(297, 20)
        Me.ConnectionString.TabIndex = 2
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(5, 34)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(53, 13)
        Me.PasswordLabel.TabIndex = 3
        Me.PasswordLabel.Text = "Password"
        '
        'Password
        '
        Me.Password.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Password.Location = New System.Drawing.Point(200, 31)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(214, 20)
        Me.Password.TabIndex = 1
        Me.Password.UseSystemPasswordChar = True
        '
        'UserNameLabel
        '
        Me.UserNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UserNameLabel.AutoSize = True
        Me.UserNameLabel.Location = New System.Drawing.Point(5, 8)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New System.Drawing.Size(60, 13)
        Me.UserNameLabel.TabIndex = 2
        Me.UserNameLabel.Text = "User Name"
        '
        'SpecificationEventsCheck
        '
        Me.SpecificationEventsCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.SpecificationEventsCheck.AutoSize = True
        Me.SpecificationEventsCheck.Location = New System.Drawing.Point(200, 115)
        Me.SpecificationEventsCheck.Name = "SpecificationEventsCheck"
        Me.SpecificationEventsCheck.Size = New System.Drawing.Size(15, 14)
        Me.SpecificationEventsCheck.TabIndex = 3
        Me.SpecificationEventsCheck.UseVisualStyleBackColor = True
        '
        'ModelEventsCheck
        '
        Me.ModelEventsCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ModelEventsCheck.AutoSize = True
        Me.ModelEventsCheck.Location = New System.Drawing.Point(200, 95)
        Me.ModelEventsCheck.Name = "ModelEventsCheck"
        Me.ModelEventsCheck.Size = New System.Drawing.Size(15, 14)
        Me.ModelEventsCheck.TabIndex = 3
        Me.ModelEventsCheck.UseVisualStyleBackColor = True
        '
        'ModelEventsLabel
        '
        Me.ModelEventsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ModelEventsLabel.AutoSize = True
        Me.ModelEventsLabel.Location = New System.Drawing.Point(5, 95)
        Me.ModelEventsLabel.Name = "ModelEventsLabel"
        Me.ModelEventsLabel.Size = New System.Drawing.Size(189, 13)
        Me.ModelEventsLabel.TabIndex = 8
        Me.ModelEventsLabel.Text = "Respond To Model Generation Events"
        '
        'PlugInSettingsForm
        '
        Me.AcceptButton = Me.FinishButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.DlgCancelButton
        Me.ClientSize = New System.Drawing.Size(517, 296)
        Me.Controls.Add(Me.BodyPanel)
        Me.Controls.Add(Me.FooterLayoutPanel)
        Me.Controls.Add(Me.HeaderLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(533, 335)
        Me.Name = "PlugInSettingsForm"
        Me.Text = "DriveWorks Integration Example Settings"
        Me.HeaderLayoutPanel.ResumeLayout(False)
        Me.HeaderLayoutPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FooterLayoutPanel.ResumeLayout(False)
        Me.BodyPanel.ResumeLayout(False)
        Me.BodyLayoutPanel.ResumeLayout(False)
        Me.BodyLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HeaderLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents HeaderLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents FooterLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TestButton As System.Windows.Forms.Button
    Friend WithEvents FinishButton As System.Windows.Forms.Button
    Friend WithEvents DlgCancelButton As System.Windows.Forms.Button
    Friend WithEvents BodyPanel As System.Windows.Forms.Panel
    Friend WithEvents BodyLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SpecificationEventsLabel As System.Windows.Forms.Label
    Friend WithEvents UserName As System.Windows.Forms.TextBox
    Friend WithEvents ConnectionStringlabel As System.Windows.Forms.Label
    Friend WithEvents ConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents UserNameLabel As System.Windows.Forms.Label
    Friend WithEvents SpecificationEventsCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ModelEventsCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ModelEventsLabel As System.Windows.Forms.Label
End Class
