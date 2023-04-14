<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWeighIn
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
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTons = New System.Windows.Forms.TextBox()
        Me.txtNet = New System.Windows.Forms.TextBox()
        Me.txtTare = New System.Windows.Forms.TextBox()
        Me.txtGross = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.txtVehicle = New System.Windows.Forms.TextBox()
        Me.txtTrailer = New System.Windows.Forms.TextBox()
        Me.cmdRead = New System.Windows.Forms.Button()
        Me.cmdZero = New System.Windows.Forms.Button()
        Me.Comm1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Scale1Check = New System.Windows.Forms.Timer(Me.components)
        Me.Scale1Box = New System.Windows.Forms.TextBox()
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(133, 22)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(329, 37)
        Me.lblMsg.TabIndex = 16
        Me.lblMsg.Text = "Certified Weight Form"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 29)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Vehicle ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 29)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Trailer ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTons)
        Me.GroupBox1.Controls.Add(Me.txtNet)
        Me.GroupBox1.Controls.Add(Me.txtTare)
        Me.GroupBox1.Controls.Add(Me.txtGross)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(400, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 226)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scale Reading"
        '
        'txtTons
        '
        Me.txtTons.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTons.Location = New System.Drawing.Point(79, 172)
        Me.txtTons.Name = "txtTons"
        Me.txtTons.Size = New System.Drawing.Size(101, 29)
        Me.txtTons.TabIndex = 26
        Me.txtTons.Tag = "Tons"
        '
        'txtNet
        '
        Me.txtNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNet.Location = New System.Drawing.Point(79, 124)
        Me.txtNet.Name = "txtNet"
        Me.txtNet.Size = New System.Drawing.Size(101, 29)
        Me.txtNet.TabIndex = 25
        Me.txtNet.Tag = "Net Weight"
        '
        'txtTare
        '
        Me.txtTare.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTare.Location = New System.Drawing.Point(79, 78)
        Me.txtTare.Name = "txtTare"
        Me.txtTare.Size = New System.Drawing.Size(101, 29)
        Me.txtTare.TabIndex = 24
        Me.txtTare.Tag = "Tare Weight"
        '
        'txtGross
        '
        Me.txtGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGross.Location = New System.Drawing.Point(79, 32)
        Me.txtGross.Name = "txtGross"
        Me.txtGross.Size = New System.Drawing.Size(101, 29)
        Me.txtGross.TabIndex = 23
        Me.txtGross.Tag = "Gross Weight"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 24)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Tons:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 24)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Net:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 24)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Tare:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 24)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Gross:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(174, 354)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(87, 48)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(400, 354)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(87, 48)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtVehicle
        '
        Me.txtVehicle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicle.Location = New System.Drawing.Point(174, 102)
        Me.txtVehicle.MaxLength = 15
        Me.txtVehicle.Name = "txtVehicle"
        Me.txtVehicle.Size = New System.Drawing.Size(191, 35)
        Me.txtVehicle.TabIndex = 22
        Me.txtVehicle.Tag = "Vehicle ID"
        '
        'txtTrailer
        '
        Me.txtTrailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrailer.Location = New System.Drawing.Point(174, 152)
        Me.txtTrailer.MaxLength = 15
        Me.txtTrailer.Name = "txtTrailer"
        Me.txtTrailer.Size = New System.Drawing.Size(191, 35)
        Me.txtTrailer.TabIndex = 23
        Me.txtTrailer.Tag = "Trailer ID"
        '
        'cmdRead
        '
        Me.cmdRead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRead.Location = New System.Drawing.Point(98, 241)
        Me.cmdRead.Name = "cmdRead"
        Me.cmdRead.Size = New System.Drawing.Size(117, 48)
        Me.cmdRead.TabIndex = 24
        Me.cmdRead.Text = "Read Scale"
        Me.cmdRead.UseVisualStyleBackColor = True
        '
        'cmdZero
        '
        Me.cmdZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZero.Location = New System.Drawing.Point(238, 241)
        Me.cmdZero.Name = "cmdZero"
        Me.cmdZero.Size = New System.Drawing.Size(113, 48)
        Me.cmdZero.TabIndex = 25
        Me.cmdZero.Text = "Zero Scale"
        Me.cmdZero.UseVisualStyleBackColor = True
        Me.cmdZero.Visible = False
        '
        'Comm1
        '
        '
        'Scale1Check
        '
        '
        'Scale1Box
        '
        Me.Scale1Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Scale1Box.Location = New System.Drawing.Point(105, 304)
        Me.Scale1Box.Name = "Scale1Box"
        Me.Scale1Box.Size = New System.Drawing.Size(109, 29)
        Me.Scale1Box.TabIndex = 26
        Me.Scale1Box.Visible = False
        '
        'LoadTimer
        '
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(105, 426)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(443, 20)
        Me.txtStatus.TabIndex = 27
        '
        'frmWeighIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 464)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Scale1Box)
        Me.Controls.Add(Me.cmdZero)
        Me.Controls.Add(Me.cmdRead)
        Me.Controls.Add(Me.txtTrailer)
        Me.Controls.Add(Me.txtVehicle)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMsg)
        Me.Name = "frmWeighIn"
        Me.Text = "frmWeighIn"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTons As System.Windows.Forms.TextBox
    Friend WithEvents txtNet As System.Windows.Forms.TextBox
    Friend WithEvents txtTare As System.Windows.Forms.TextBox
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtVehicle As System.Windows.Forms.TextBox
    Friend WithEvents txtTrailer As System.Windows.Forms.TextBox
    Friend WithEvents cmdRead As System.Windows.Forms.Button
    Friend WithEvents cmdZero As System.Windows.Forms.Button
    Friend WithEvents Comm1 As System.IO.Ports.SerialPort
    Friend WithEvents Scale1Check As System.Windows.Forms.Timer
    Friend WithEvents Scale1Box As System.Windows.Forms.TextBox
    Friend WithEvents LoadTimer As System.Windows.Forms.Timer
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
End Class
