<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeal
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSeal1 = New System.Windows.Forms.TextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSeal2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSeal4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSeal3 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 37)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Seal 1:"
        '
        'txtSeal1
        '
        Me.txtSeal1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeal1.Location = New System.Drawing.Point(220, 97)
        Me.txtSeal1.MaxLength = 12
        Me.txtSeal1.Name = "txtSeal1"
        Me.txtSeal1.Size = New System.Drawing.Size(254, 44)
        Me.txtSeal1.TabIndex = 22
        Me.txtSeal1.Tag = "Seal 1"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(80, 25)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(327, 37)
        Me.lblMsg.TabIndex = 21
        Me.lblMsg.Text = "Enter Seal Number(s)"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(383, 390)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(120, 54)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(220, 390)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(120, 54)
        Me.cmdNext.TabIndex = 19
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(50, 390)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(120, 54)
        Me.cmdBack.TabIndex = 18
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(69, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 37)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Seal 2:"
        '
        'txtSeal2
        '
        Me.txtSeal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeal2.Location = New System.Drawing.Point(220, 164)
        Me.txtSeal2.MaxLength = 12
        Me.txtSeal2.Name = "txtSeal2"
        Me.txtSeal2.Size = New System.Drawing.Size(254, 44)
        Me.txtSeal2.TabIndex = 24
        Me.txtSeal2.Tag = "Seal 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(69, 302)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 37)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Seal 4:"
        '
        'txtSeal4
        '
        Me.txtSeal4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeal4.Location = New System.Drawing.Point(220, 299)
        Me.txtSeal4.MaxLength = 12
        Me.txtSeal4.Name = "txtSeal4"
        Me.txtSeal4.Size = New System.Drawing.Size(254, 44)
        Me.txtSeal4.TabIndex = 28
        Me.txtSeal4.Tag = "Seal 4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(69, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 37)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Seal 3:"
        '
        'txtSeal3
        '
        Me.txtSeal3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeal3.Location = New System.Drawing.Point(220, 232)
        Me.txtSeal3.MaxLength = 12
        Me.txtSeal3.Name = "txtSeal3"
        Me.txtSeal3.Size = New System.Drawing.Size(254, 44)
        Me.txtSeal3.TabIndex = 26
        Me.txtSeal3.Tag = "Seal 3"
        '
        'frmSeal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 470)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSeal4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSeal3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSeal2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSeal1)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdBack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSeal"
        Me.Text = "frmSeal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSeal1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSeal2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSeal4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSeal3 As System.Windows.Forms.TextBox
End Class
