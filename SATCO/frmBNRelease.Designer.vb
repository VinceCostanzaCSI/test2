<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBNRelease
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
        Me.lblOrder = New System.Windows.Forms.Label()
        Me.txtTargetWt = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblConsignee = New System.Windows.Forms.Label()
        Me.lblAltPO = New System.Windows.Forms.Label()
        Me.lblDest2 = New System.Windows.Forms.Label()
        Me.lblDest1 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRelease = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtRelease = New System.Windows.Forms.TextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblOrder
        '
        Me.lblOrder.AutoSize = True
        Me.lblOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrder.Location = New System.Drawing.Point(83, 70)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(313, 37)
        Me.lblOrder.TabIndex = 0
        Me.lblOrder.Text = "BGM Order Number:"
        '
        'txtTargetWt
        '
        Me.txtTargetWt.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTargetWt.Location = New System.Drawing.Point(402, 67)
        Me.txtTargetWt.MaxLength = 8
        Me.txtTargetWt.Name = "txtTargetWt"
        Me.txtTargetWt.Size = New System.Drawing.Size(293, 44)
        Me.txtTargetWt.TabIndex = 1
        Me.txtTargetWt.Tag = "Target Weight"
        Me.txtTargetWt.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblPercent)
        Me.GroupBox1.Controls.Add(Me.lblConsignee)
        Me.GroupBox1.Controls.Add(Me.lblAltPO)
        Me.GroupBox1.Controls.Add(Me.lblDest2)
        Me.GroupBox1.Controls.Add(Me.lblDest1)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.lblPO)
        Me.GroupBox1.Controls.Add(Me.lblProduct)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblRelease)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(33, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(738, 300)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Brenntag Confirmation"
        Me.GroupBox1.Visible = False
        '
        'lblConsignee
        '
        Me.lblConsignee.AutoSize = True
        Me.lblConsignee.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsignee.Location = New System.Drawing.Point(598, 67)
        Me.lblConsignee.Name = "lblConsignee"
        Me.lblConsignee.Size = New System.Drawing.Size(112, 31)
        Me.lblConsignee.TabIndex = 13
        Me.lblConsignee.Text = "BN0001"
        '
        'lblAltPO
        '
        Me.lblAltPO.AutoSize = True
        Me.lblAltPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltPO.Location = New System.Drawing.Point(244, 250)
        Me.lblAltPO.Name = "lblAltPO"
        Me.lblAltPO.Size = New System.Drawing.Size(114, 31)
        Me.lblAltPO.TabIndex = 12
        Me.lblAltPO.Text = "Alt PO #"
        '
        'lblDest2
        '
        Me.lblDest2.AutoSize = True
        Me.lblDest2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDest2.Location = New System.Drawing.Point(244, 201)
        Me.lblDest2.Name = "lblDest2"
        Me.lblDest2.Size = New System.Drawing.Size(93, 31)
        Me.lblDest2.TabIndex = 11
        Me.lblDest2.Text = "Dest 2"
        '
        'lblDest1
        '
        Me.lblDest1.AutoSize = True
        Me.lblDest1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDest1.Location = New System.Drawing.Point(244, 170)
        Me.lblDest1.Name = "lblDest1"
        Me.lblDest1.Size = New System.Drawing.Size(93, 31)
        Me.lblDest1.TabIndex = 10
        Me.lblDest1.Text = "Dest 1"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(244, 139)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(86, 31)
        Me.lblName.TabIndex = 9
        Me.lblName.Text = "Name"
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPO.Location = New System.Drawing.Point(244, 105)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(75, 31)
        Me.lblPO.TabIndex = 8
        Me.lblPO.Text = "PO #"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(241, 67)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(85, 31)
        Me.lblProduct.TabIndex = 7
        Me.lblProduct.Text = "Na2O"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(36, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 31)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Alt PO #:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(36, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 31)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Destination:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(36, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 31)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 31)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "PO #:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(36, 67)
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
        Me.Label2.Size = New System.Drawing.Size(356, 31)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "BGM Order Number is Valid:"
        '
        'cmdBack
        '
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(113, 468)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(111, 55)
        Me.cmdBack.TabIndex = 3
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(331, 468)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(111, 55)
        Me.cmdNext.TabIndex = 4
        Me.cmdNext.Text = "Validate"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(535, 468)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(111, 55)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtRelease
        '
        Me.txtRelease.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRelease.Location = New System.Drawing.Point(413, 67)
        Me.txtRelease.Name = "txtRelease"
        Me.txtRelease.Size = New System.Drawing.Size(293, 44)
        Me.txtRelease.TabIndex = 6
        Me.txtRelease.Tag = "Release Number"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(224, 9)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(270, 37)
        Me.lblMsg.TabIndex = 7
        Me.lblMsg.Text = "BN Release Form"
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = True
        Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercent.Location = New System.Drawing.Point(349, 67)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(44, 31)
        Me.lblPercent.TabIndex = 14
        Me.lblPercent.Text = "50"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(387, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 31)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "% Caustic"
        '
        'frmBNRelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 559)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.txtRelease)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtTargetWt)
        Me.Controls.Add(Me.lblOrder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBNRelease"
        Me.Text = "frmBNRelease"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOrder As System.Windows.Forms.Label
    Friend WithEvents txtTargetWt As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblConsignee As System.Windows.Forms.Label
    Friend WithEvents lblAltPO As System.Windows.Forms.Label
    Friend WithEvents lblDest2 As System.Windows.Forms.Label
    Friend WithEvents lblDest1 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRelease As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtRelease As System.Windows.Forms.TextBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPercent As Label
End Class
