Public Class frmTicketPrint
    Private SQL As New SQLControl
    Dim PrintHazmat As Boolean

    Private Sub frmTicketPrint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        Me.Top = 80
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdPrintLast_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintLast.Click

        Try
            SQL.RunQuery("Select Top 1 * from Trans Order by TDate DESC,InTime DESC")
            If SQL.RecordCount <> 0 Then
                With SQL.SQLDataset.Tables(0).Rows(0)
                    NewPrinterCode = .Item("Code")
                    NewPrinterID = .Item("Id")
                End With
                'Stop
                PrintLastTicket()
            End If
        Catch ex As Exception
            frmMain.Status1Panel3.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdPrintSA_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintSA.Click
        PrintWordDoc("Q091 SA BOL.doc")
    End Sub

    Private Sub cmdPrintNSF_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintNSF.Click
        PrintWordDoc("Q095 SA BOL_NSF.doc")
    End Sub

    Private Sub cmdPrintUC_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintUC.Click
        PrintWordDoc("Q092 Nutrien Ag Solutions BOL.doc")
    End Sub

    Private Sub cmdPrintHazmat_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintHazmat.Click
        PrintExcel("Q074 Hazmat.xls")
    End Sub

    Private Sub cmdPrintMO_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintMO.Click
        PrintWordDoc("Q110 MO BOL.doc")
    End Sub

    Private Sub cmdPrintMO8Bulk_Click(sender As System.Object, e As System.EventArgs)
        PrintWordDoc("MO8_Bulk.doc")
    End Sub

    Private Sub cmdPrintMO9Bulk_Click(sender As System.Object, e As System.EventArgs)
        PrintWordDoc("MO9_Bulk.doc")
    End Sub

    Private Sub cmdPrintBTCoA50_Click(sender As Object, e As EventArgs) Handles cmdPrintBTCoA50.Click
        PrintBNCoA50("Brenntag CoA 50.doc")
    End Sub

    Private Sub cmdPrintBTCoA25_Click(sender As Object, e As EventArgs) Handles cmdPrintBTCoA25.Click
        PrintBNCoA25("Brenntag CoA 25.doc")
    End Sub
End Class