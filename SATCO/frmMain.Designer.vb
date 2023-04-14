<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.mnuLoadout = New System.Windows.Forms.ToolStripButton()
        Me.mnuPrintTicket = New System.Windows.Forms.ToolStripButton()
        Me.mnuCertifiedWeight = New System.Windows.Forms.ToolStripButton()
        Me.mnuSetup = New System.Windows.Forms.ToolStripButton()
        Me.mnuExit = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status1Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status1Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status1Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.Logo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status2Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status2Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip()
        Me.Status3Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status3Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status3Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status3Panel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status3Panel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CmdTempExit = New System.Windows.Forms.Button()
        Me.TimeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.StatusStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLoadout, Me.mnuPrintTicket, Me.mnuCertifiedWeight, Me.mnuSetup, Me.mnuExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(991, 154)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'mnuLoadout
        '
        Me.mnuLoadout.Image = CType(resources.GetObject("mnuLoadout.Image"), System.Drawing.Image)
        Me.mnuLoadout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuLoadout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuLoadout.Name = "mnuLoadout"
        Me.mnuLoadout.Size = New System.Drawing.Size(148, 151)
        Me.mnuLoadout.Tag = "Fill Vehicle"
        Me.mnuLoadout.Text = "Fill Vehicle"
        Me.mnuLoadout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuLoadout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuPrintTicket
        '
        Me.mnuPrintTicket.Image = CType(resources.GetObject("mnuPrintTicket.Image"), System.Drawing.Image)
        Me.mnuPrintTicket.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPrintTicket.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrintTicket.Name = "mnuPrintTicket"
        Me.mnuPrintTicket.Size = New System.Drawing.Size(152, 151)
        Me.mnuPrintTicket.Tag = "Print TIcket"
        Me.mnuPrintTicket.Text = "Print Ticket"
        Me.mnuPrintTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuPrintTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuCertifiedWeight
        '
        Me.mnuCertifiedWeight.Image = CType(resources.GetObject("mnuCertifiedWeight.Image"), System.Drawing.Image)
        Me.mnuCertifiedWeight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCertifiedWeight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCertifiedWeight.Name = "mnuCertifiedWeight"
        Me.mnuCertifiedWeight.Size = New System.Drawing.Size(215, 151)
        Me.mnuCertifiedWeight.Text = "Certified Weight"
        Me.mnuCertifiedWeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuCertifiedWeight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSetup
        '
        Me.mnuSetup.Image = CType(resources.GetObject("mnuSetup.Image"), System.Drawing.Image)
        Me.mnuSetup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSetup.Name = "mnuSetup"
        Me.mnuSetup.Size = New System.Drawing.Size(180, 151)
        Me.mnuSetup.Text = "System Setup"
        Me.mnuSetup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(114, 151)
        Me.mnuExit.Text = "Exit"
        Me.mnuExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status1Panel1, Me.Status1Panel2, Me.Status1Panel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 560)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(991, 37)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status1Panel1
        '
        Me.Status1Panel1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status1Panel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Status1Panel1.Name = "Status1Panel1"
        Me.Status1Panel1.Size = New System.Drawing.Size(325, 32)
        Me.Status1Panel1.Spring = True
        Me.Status1Panel1.Text = "Status1Panel1"
        Me.Status1Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Status1Panel2
        '
        Me.Status1Panel2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status1Panel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Status1Panel2.Name = "Status1Panel2"
        Me.Status1Panel2.Size = New System.Drawing.Size(325, 32)
        Me.Status1Panel2.Spring = True
        Me.Status1Panel2.Text = "Status1Panel2"
        '
        'Status1Panel3
        '
        Me.Status1Panel3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status1Panel3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Status1Panel3.Name = "Status1Panel3"
        Me.Status1Panel3.Size = New System.Drawing.Size(325, 32)
        Me.Status1Panel3.Spring = True
        Me.Status1Panel3.Text = "Status1Panel3"
        Me.Status1Panel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LoadTimer
        '
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Logo, Me.Status2Panel2, Me.Status2Panel3})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 154)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(991, 54)
        Me.StatusStrip2.TabIndex = 4
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'Logo
        '
        Me.Logo.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Logo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(325, 49)
        Me.Logo.Spring = True
        '
        'Status2Panel2
        '
        Me.Status2Panel2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status2Panel2.Name = "Status2Panel2"
        Me.Status2Panel2.Size = New System.Drawing.Size(325, 49)
        Me.Status2Panel2.Spring = True
        Me.Status2Panel2.Text = "Scale #"
        '
        'Status2Panel3
        '
        Me.Status2Panel3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status2Panel3.Name = "Status2Panel3"
        Me.Status2Panel3.Size = New System.Drawing.Size(325, 49)
        Me.Status2Panel3.Spring = True
        Me.Status2Panel3.Text = "Status2Panel3"
        Me.Status2Panel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusStrip3
        '
        Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status3Panel1, Me.Status3Panel2, Me.Status3Panel3, Me.Status3Panel4, Me.Status3Panel5})
        Me.StatusStrip3.Location = New System.Drawing.Point(0, 523)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.Size = New System.Drawing.Size(991, 37)
        Me.StatusStrip3.TabIndex = 5
        Me.StatusStrip3.Text = "StatusStrip3"
        '
        'Status3Panel1
        '
        Me.Status3Panel1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status3Panel1.Name = "Status3Panel1"
        Me.Status3Panel1.Size = New System.Drawing.Size(164, 32)
        Me.Status3Panel1.Text = "Status3Panel1"
        '
        'Status3Panel2
        '
        Me.Status3Panel2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status3Panel2.Name = "Status3Panel2"
        Me.Status3Panel2.Size = New System.Drawing.Size(164, 32)
        Me.Status3Panel2.Text = "Status3Panel2"
        '
        'Status3Panel3
        '
        Me.Status3Panel3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status3Panel3.Name = "Status3Panel3"
        Me.Status3Panel3.Size = New System.Drawing.Size(320, 32)
        Me.Status3Panel3.Spring = True
        Me.Status3Panel3.Text = "Status3Panel3"
        '
        'Status3Panel4
        '
        Me.Status3Panel4.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status3Panel4.Name = "Status3Panel4"
        Me.Status3Panel4.Size = New System.Drawing.Size(164, 32)
        Me.Status3Panel4.Text = "Status3Panel4"
        '
        'Status3Panel5
        '
        Me.Status3Panel5.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status3Panel5.Name = "Status3Panel5"
        Me.Status3Panel5.Size = New System.Drawing.Size(164, 32)
        Me.Status3Panel5.Text = "Status3Panel5"
        '
        'CmdTempExit
        '
        Me.CmdTempExit.Location = New System.Drawing.Point(10, 219)
        Me.CmdTempExit.Name = "CmdTempExit"
        Me.CmdTempExit.Size = New System.Drawing.Size(48, 23)
        Me.CmdTempExit.TabIndex = 7
        Me.CmdTempExit.Text = "Exit"
        Me.CmdTempExit.UseVisualStyleBackColor = True
        Me.CmdTempExit.Visible = False
        '
        'TimeTimer
        '
        Me.TimeTimer.Enabled = True
        Me.TimeTimer.Interval = 10000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 597)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdTempExit)
        Me.Controls.Add(Me.StatusStrip3)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "SATCO Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.StatusStrip3.ResumeLayout(False)
        Me.StatusStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuLoadout As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuPrintTicket As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuCertifiedWeight As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status1Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LoadTimer As System.Windows.Forms.Timer
    Friend WithEvents Status1Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip3 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status1Panel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status3Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Logo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status2Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status2Panel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status3Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status3Panel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status3Panel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status3Panel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CmdTempExit As System.Windows.Forms.Button
    Friend WithEvents TimeTimer As System.Windows.Forms.Timer

End Class
