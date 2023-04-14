<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMORelease
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
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtRelease = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEvoqua = New System.Windows.Forms.Label()
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
        Me.lblCode = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(114, 22)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(340, 37)
        Me.lblMsg.TabIndex = 15
        Me.lblMsg.Text = "Enter Release Number"
        '
        'txtRelease
        '
        Me.txtRelease.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRelease.Location = New System.Drawing.Point(395, 85)
        Me.txtRelease.MaxLength = 15
        Me.txtRelease.Name = "txtRelease"
        Me.txtRelease.Size = New System.Drawing.Size(293, 44)
        Me.txtRelease.TabIndex = 14
        Me.txtRelease.Tag = "Release Number"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(503, 487)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(111, 55)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(299, 487)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(111, 55)
        Me.cmdNext.TabIndex = 12
        Me.cmdNext.Text = "Validate"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(81, 487)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(111, 55)
        Me.cmdBack.TabIndex = 11
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCode)
        Me.GroupBox1.Controls.Add(Me.lblEvoqua)
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
        Me.GroupBox1.Location = New System.Drawing.Point(52, 145)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(589, 300)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mosaic Confirmation"
        Me.GroupBox1.Visible = False
        '
        'lblEvoqua
        '
        Me.lblEvoqua.AutoSize = True
        Me.lblEvoqua.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvoqua.Location = New System.Drawing.Point(33, 249)
        Me.lblEvoqua.Name = "lblEvoqua"
        Me.lblEvoqua.Size = New System.Drawing.Size(248, 31)
        Me.lblEvoqua.TabIndex = 12
        Me.lblEvoqua.Text = "UAN-32 Consignee"
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
        Me.lblConsignee.Size = New System.Drawing.Size(136, 31)
        Me.lblConsignee.TabIndex = 9
        Me.lblConsignee.Text = "CustCode"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.Location = New System.Drawing.Point(241, 67)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(133, 31)
        Me.lblProduct.TabIndex = 7
        Me.lblProduct.Text = "UAN 32%"
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
        Me.txtTargetWt.Location = New System.Drawing.Point(384, 85)
        Me.txtTargetWt.MaxLength = 8
        Me.txtTargetWt.Name = "txtTargetWt"
        Me.txtTargetWt.Size = New System.Drawing.Size(293, 44)
        Me.txtTargetWt.TabIndex = 9
        Me.txtTargetWt.Tag = "Target Weight"
        Me.txtTargetWt.Visible = False
        '
        'lblOrder
        '
        Me.lblOrder.AutoSize = True
        Me.lblOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrder.Location = New System.Drawing.Point(65, 88)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(255, 37)
        Me.lblOrder.TabIndex = 8
        Me.lblOrder.Text = "Release Number"
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.Location = New System.Drawing.Point(313, 249)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(136, 31)
        Me.lblCode.TabIndex = 13
        Me.lblCode.Text = "CustCode"
        '
        'frmMORelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 568)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.txtRelease)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtTargetWt)
        Me.Controls.Add(Me.lblOrder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMORelease"
        Me.Text = "frmMORelease"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents txtRelease As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEvoqua As System.Windows.Forms.Label
    Friend WithEvents lblDest2 As System.Windows.Forms.Label
    Friend WithEvents lblDest1 As System.Windows.Forms.Label
    Friend WithEvents lblConsignee As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRelease As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTargetWt As System.Windows.Forms.TextBox
    Friend WithEvents lblOrder As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
End Class
