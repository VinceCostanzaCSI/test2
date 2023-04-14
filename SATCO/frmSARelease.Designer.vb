<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSARelease
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
        Me.txtRelease = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTank = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNSF = New System.Windows.Forms.Label()
        Me.lblStrength = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProductCode = New System.Windows.Forms.Label()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblDest2 = New System.Windows.Forms.Label()
        Me.lblDest1 = New System.Windows.Forms.Label()
        Me.lblConsignee = New System.Windows.Forms.Label()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRelease = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTargetWt = New System.Windows.Forms.TextBox()
        Me.lblOrder = New System.Windows.Forms.Label()
        Me.TankStatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(102, 31)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(340, 37)
        Me.lblMsg.TabIndex = 23
        Me.lblMsg.Text = "Enter Release Number"
        '
        'txtRelease
        '
        Me.txtRelease.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRelease.Location = New System.Drawing.Point(383, 94)
        Me.txtRelease.MaxLength = 15
        Me.txtRelease.Name = "txtRelease"
        Me.txtRelease.Size = New System.Drawing.Size(293, 44)
        Me.txtRelease.TabIndex = 22
        Me.txtRelease.Tag = "Release Number"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(491, 522)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(111, 55)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(287, 522)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(111, 55)
        Me.cmdNext.TabIndex = 20
        Me.cmdNext.Text = "Validate"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(69, 522)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(111, 55)
        Me.cmdBack.TabIndex = 19
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTank)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblPO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblNSF)
        Me.GroupBox1.Controls.Add(Me.lblStrength)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblProductCode)
        Me.GroupBox1.Controls.Add(Me.lblCode)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblDest2)
        Me.GroupBox1.Controls.Add(Me.lblDest1)
        Me.GroupBox1.Controls.Add(Me.lblConsignee)
        Me.GroupBox1.Controls.Add(Me.lblProduct)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblRelease)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(40, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(589, 352)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SA Confirmation"
        Me.GroupBox1.Visible = False
        '
        'lblTank
        '
        Me.lblTank.AutoSize = True
        Me.lblTank.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTank.Location = New System.Drawing.Point(241, 232)
        Me.lblTank.Name = "lblTank"
        Me.lblTank.Size = New System.Drawing.Size(75, 31)
        Me.lblTank.TabIndex = 21
        Me.lblTank.Text = "Tank"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 31)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Tank:"
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPO.Location = New System.Drawing.Point(241, 265)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(75, 31)
        Me.lblPO.TabIndex = 19
        Me.lblPO.Text = "PO #"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 31)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "PO:"
        '
        'lblNSF
        '
        Me.lblNSF.AutoSize = True
        Me.lblNSF.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNSF.Location = New System.Drawing.Point(514, 308)
        Me.lblNSF.Name = "lblNSF"
        Me.lblNSF.Size = New System.Drawing.Size(69, 31)
        Me.lblNSF.TabIndex = 17
        Me.lblNSF.Text = "NSF"
        Me.lblNSF.Visible = False
        '
        'lblStrength
        '
        Me.lblStrength.AutoSize = True
        Me.lblStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStrength.Location = New System.Drawing.Point(241, 197)
        Me.lblStrength.Name = "lblStrength"
        Me.lblStrength.Size = New System.Drawing.Size(93, 31)
        Me.lblStrength.TabIndex = 16
        Me.lblStrength.Text = "Dest 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 31)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Analysis:"
        '
        'lblProductCode
        '
        Me.lblProductCode.AutoSize = True
        Me.lblProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductCode.Location = New System.Drawing.Point(494, 67)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(50, 31)
        Me.lblProductCode.TabIndex = 14
        Me.lblProductCode.Text = "SA"
        Me.lblProductCode.Visible = False
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.Location = New System.Drawing.Point(315, 308)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(136, 31)
        Me.lblCode.TabIndex = 13
        Me.lblCode.Text = "CustCode"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(35, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 31)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Consignee"
        '
        'lblDest2
        '
        Me.lblDest2.AutoSize = True
        Me.lblDest2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDest2.Location = New System.Drawing.Point(241, 163)
        Me.lblDest2.Name = "lblDest2"
        Me.lblDest2.Size = New System.Drawing.Size(93, 31)
        Me.lblDest2.TabIndex = 11
        Me.lblDest2.Text = "Dest 2"
        '
        'lblDest1
        '
        Me.lblDest1.AutoSize = True
        Me.lblDest1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDest1.Location = New System.Drawing.Point(241, 132)
        Me.lblDest1.Name = "lblDest1"
        Me.lblDest1.Size = New System.Drawing.Size(93, 31)
        Me.lblDest1.TabIndex = 10
        Me.lblDest1.Text = "Dest 1"
        '
        'lblConsignee
        '
        Me.lblConsignee.AutoSize = True
        Me.lblConsignee.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsignee.Location = New System.Drawing.Point(241, 101)
        Me.lblConsignee.Name = "lblConsignee"
        Me.lblConsignee.Size = New System.Drawing.Size(143, 31)
        Me.lblConsignee.TabIndex = 9
        Me.lblConsignee.Text = "CustName"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(241, 67)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(187, 31)
        Me.lblProduct.TabIndex = 7
        Me.lblProduct.Text = "Sulphuric Acid"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 31)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Destination:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 31)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Consignee:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 31)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Product Type:"
        '
        'lblRelease
        '
        Me.lblRelease.AutoSize = True
        Me.lblRelease.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelease.Location = New System.Drawing.Point(408, 31)
        Me.lblRelease.Name = "lblRelease"
        Me.lblRelease.Size = New System.Drawing.Size(136, 31)
        Me.lblRelease.TabIndex = 1
        Me.lblRelease.Text = "Release #"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(319, 31)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Release Number is Valid:"
        '
        'txtTargetWt
        '
        Me.txtTargetWt.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTargetWt.Location = New System.Drawing.Point(372, 94)
        Me.txtTargetWt.MaxLength = 8
        Me.txtTargetWt.Name = "txtTargetWt"
        Me.txtTargetWt.Size = New System.Drawing.Size(293, 44)
        Me.txtTargetWt.TabIndex = 17
        Me.txtTargetWt.Tag = "Target Weight"
        Me.txtTargetWt.Visible = False
        '
        'lblOrder
        '
        Me.lblOrder.AutoSize = True
        Me.lblOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrder.Location = New System.Drawing.Point(53, 97)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(255, 37)
        Me.lblOrder.TabIndex = 16
        Me.lblOrder.Text = "Release Number"
        '
        'TankStatusTimer
        '
        Me.TankStatusTimer.Interval = 1000
        '
        'frmSARelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 589)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.txtRelease)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtTargetWt)
        Me.Controls.Add(Me.lblOrder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSARelease"
        Me.Text = "frmSARelease"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMsg As Label
    Friend WithEvents txtRelease As TextBox
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdNext As Button
    Friend WithEvents cmdBack As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblCode As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblDest2 As Label
    Friend WithEvents lblDest1 As Label
    Friend WithEvents lblConsignee As Label
    Friend WithEvents lblProduct As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblRelease As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTargetWt As TextBox
    Friend WithEvents lblOrder As Label
    Friend WithEvents lblProductCode As Label
    Friend WithEvents lblStrength As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNSF As Label
    Friend WithEvents lblPO As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTank As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TankStatusTimer As Timer
End Class
