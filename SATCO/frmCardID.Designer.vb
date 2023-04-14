<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardID
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
        Me.components = New System.ComponentModel.Container()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtCardID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CardCom = New System.IO.Ports.SerialPort(Me.components)
        Me.TankInfoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CardReadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblCardStatus = New System.Windows.Forms.Label()
        Me.cboCardID = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(90, 220)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(120, 54)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(260, 220)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(120, 54)
        Me.cmdNext.TabIndex = 1
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(423, 220)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(120, 54)
        Me.cmdPrint.TabIndex = 2
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(138, 29)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(296, 37)
        Me.lblMsg.TabIndex = 3
        Me.lblMsg.Text = "Enter Card Number"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCardID
        '
        Me.txtCardID.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardID.Location = New System.Drawing.Point(298, 106)
        Me.txtCardID.MaxLength = 8
        Me.txtCardID.Name = "txtCardID"
        Me.txtCardID.Size = New System.Drawing.Size(215, 44)
        Me.txtCardID.TabIndex = 1
        Me.txtCardID.Tag = "Card ID"
        Me.txtCardID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Card #:"
        '
        'CardCom
        '
        Me.CardCom.PortName = "COM2"
        '
        'TankInfoTimer
        '
        Me.TankInfoTimer.Enabled = True
        Me.TankInfoTimer.Interval = 5000
        '
        'CardReadTimer
        '
        Me.CardReadTimer.Interval = 500
        '
        'lblCardStatus
        '
        Me.lblCardStatus.AutoSize = True
        Me.lblCardStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardStatus.Location = New System.Drawing.Point(246, 302)
        Me.lblCardStatus.Name = "lblCardStatus"
        Me.lblCardStatus.Size = New System.Drawing.Size(146, 16)
        Me.lblCardStatus.TabIndex = 6
        Me.lblCardStatus.Text = "Card Reader not Active"
        '
        'cboCardID
        '
        Me.cboCardID.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCardID.FormattingEnabled = True
        Me.cboCardID.Location = New System.Drawing.Point(215, 109)
        Me.cboCardID.Name = "cboCardID"
        Me.cboCardID.Size = New System.Drawing.Size(368, 45)
        Me.cboCardID.TabIndex = 19
        '
        'frmCardID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 338)
        Me.Controls.Add(Me.cboCardID)
        Me.Controls.Add(Me.lblCardStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCardID)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCardID"
        Me.Text = "frmCardID"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents txtCardID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CardCom As System.IO.Ports.SerialPort
    Friend WithEvents TankInfoTimer As System.Windows.Forms.Timer
    Friend WithEvents CardReadTimer As System.Windows.Forms.Timer
    Friend WithEvents lblCardStatus As System.Windows.Forms.Label
    Friend WithEvents cboCardID As ComboBox
End Class
