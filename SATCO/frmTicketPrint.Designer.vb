<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTicketPrint
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdPrintBTCoA50 = New System.Windows.Forms.Button()
        Me.cmdPrintBTCoA25 = New System.Windows.Forms.Button()
        Me.cmdPrintMO = New System.Windows.Forms.Button()
        Me.cmdPrintHazmat = New System.Windows.Forms.Button()
        Me.cmdPrintUC = New System.Windows.Forms.Button()
        Me.cmdPrintNSF = New System.Windows.Forms.Button()
        Me.cmdPrintSA = New System.Windows.Forms.Button()
        Me.cmdPrintLast = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdPrintBTCoA50)
        Me.GroupBox1.Controls.Add(Me.cmdPrintBTCoA25)
        Me.GroupBox1.Controls.Add(Me.cmdPrintMO)
        Me.GroupBox1.Controls.Add(Me.cmdPrintHazmat)
        Me.GroupBox1.Controls.Add(Me.cmdPrintUC)
        Me.GroupBox1.Controls.Add(Me.cmdPrintNSF)
        Me.GroupBox1.Controls.Add(Me.cmdPrintSA)
        Me.GroupBox1.Controls.Add(Me.cmdPrintLast)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(17, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 448)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Control"
        '
        'cmdPrintBTCoA50
        '
        Me.cmdPrintBTCoA50.Location = New System.Drawing.Point(267, 356)
        Me.cmdPrintBTCoA50.Name = "cmdPrintBTCoA50"
        Me.cmdPrintBTCoA50.Size = New System.Drawing.Size(120, 61)
        Me.cmdPrintBTCoA50.TabIndex = 13
        Me.cmdPrintBTCoA50.Text = "Print BT CoA 50"
        Me.cmdPrintBTCoA50.UseVisualStyleBackColor = True
        '
        'cmdPrintBTCoA25
        '
        Me.cmdPrintBTCoA25.Location = New System.Drawing.Point(49, 356)
        Me.cmdPrintBTCoA25.Name = "cmdPrintBTCoA25"
        Me.cmdPrintBTCoA25.Size = New System.Drawing.Size(120, 61)
        Me.cmdPrintBTCoA25.TabIndex = 11
        Me.cmdPrintBTCoA25.Text = "Print BT CoA 25"
        Me.cmdPrintBTCoA25.UseVisualStyleBackColor = True
        '
        'cmdPrintMO
        '
        Me.cmdPrintMO.Location = New System.Drawing.Point(49, 256)
        Me.cmdPrintMO.Name = "cmdPrintMO"
        Me.cmdPrintMO.Size = New System.Drawing.Size(338, 61)
        Me.cmdPrintMO.TabIndex = 6
        Me.cmdPrintMO.Text = "Print Blank MO BOL"
        Me.cmdPrintMO.UseVisualStyleBackColor = True
        '
        'cmdPrintHazmat
        '
        Me.cmdPrintHazmat.Location = New System.Drawing.Point(242, 177)
        Me.cmdPrintHazmat.Name = "cmdPrintHazmat"
        Me.cmdPrintHazmat.Size = New System.Drawing.Size(145, 61)
        Me.cmdPrintHazmat.TabIndex = 4
        Me.cmdPrintHazmat.Text = "Print Hazmat Sheet"
        Me.cmdPrintHazmat.UseVisualStyleBackColor = True
        '
        'cmdPrintUC
        '
        Me.cmdPrintUC.Location = New System.Drawing.Point(49, 177)
        Me.cmdPrintUC.Name = "cmdPrintUC"
        Me.cmdPrintUC.Size = New System.Drawing.Size(145, 61)
        Me.cmdPrintUC.TabIndex = 3
        Me.cmdPrintUC.Text = "Print Blank UC BOL"
        Me.cmdPrintUC.UseVisualStyleBackColor = True
        '
        'cmdPrintNSF
        '
        Me.cmdPrintNSF.Location = New System.Drawing.Point(242, 100)
        Me.cmdPrintNSF.Name = "cmdPrintNSF"
        Me.cmdPrintNSF.Size = New System.Drawing.Size(145, 61)
        Me.cmdPrintNSF.TabIndex = 2
        Me.cmdPrintNSF.Text = "Print Blank SA-NSF BOL"
        Me.cmdPrintNSF.UseVisualStyleBackColor = True
        '
        'cmdPrintSA
        '
        Me.cmdPrintSA.Location = New System.Drawing.Point(49, 100)
        Me.cmdPrintSA.Name = "cmdPrintSA"
        Me.cmdPrintSA.Size = New System.Drawing.Size(145, 61)
        Me.cmdPrintSA.TabIndex = 1
        Me.cmdPrintSA.Text = "Print Blank SA BOL"
        Me.cmdPrintSA.UseVisualStyleBackColor = True
        '
        'cmdPrintLast
        '
        Me.cmdPrintLast.Location = New System.Drawing.Point(49, 26)
        Me.cmdPrintLast.Name = "cmdPrintLast"
        Me.cmdPrintLast.Size = New System.Drawing.Size(338, 58)
        Me.cmdPrintLast.TabIndex = 0
        Me.cmdPrintLast.Text = "Reprint Last Ticket"
        Me.cmdPrintLast.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(199, 499)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(96, 47)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(159, 356)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 61)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Print BT CoA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmTicketPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 579)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTicketPrint"
        Me.Text = "Print Form"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrintBTCoA25 As System.Windows.Forms.Button
    Friend WithEvents cmdPrintMO As System.Windows.Forms.Button
    Friend WithEvents cmdPrintHazmat As System.Windows.Forms.Button
    Friend WithEvents cmdPrintUC As System.Windows.Forms.Button
    Friend WithEvents cmdPrintNSF As System.Windows.Forms.Button
    Friend WithEvents cmdPrintSA As System.Windows.Forms.Button
    Friend WithEvents cmdPrintLast As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrintBTCoA50 As Button
    Friend WithEvents Button1 As Button
End Class
