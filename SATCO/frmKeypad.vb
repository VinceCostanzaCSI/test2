Public Class frmKeypad
    Dim CapsFlag As Boolean
    Dim Section As String
    Dim Keyboard As New clsKeyboard

    Const KEY_ENTER = 12
    Const KEY_ESCAPE = 0

    Private Sub frmKeypad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        'Set CapsFlag to default
        CapsFlag = True

        'Get Text Label
        lblInputString.Text = Keyboard.Label
        'Get Max Length Of Input String
        Text1.MaxLength = Keyboard.Length
        'Get Tmp String From Reg
        Text1.Text = Keyboard.Data
        ' Get the password character
        Text1.PasswordChar = ""
        If HidePassword = True Then
            Text1.PasswordChar = "*"
            HidePassword = False
        End If

        Text1.SelectionStart = 0
        Text1.SelectionLength = Text1.Text.Length
    End Sub

    Private Sub Text1_GotFocus(sender As Object, e As System.EventArgs) Handles Text1.GotFocus
        'Place Cursor At End Of String
        Text1.SelectionStart = Len(Text1.Text) + 1
        Text1.Focus()
    End Sub

    Private Sub ButtonPressed(Index As Integer)

        Select Case Index
            Case 0
                Me.Close()
            Case 1
                Text1.Text = Text1.Text & "1"
                Text1.Focus()
            Case 2
                Text1.Text = Text1.Text & "2"
                Text1.Focus()
            Case 3
                Text1.Text = Text1.Text & "3"
                Text1.Focus()
            Case 4
                Text1.Text = Text1.Text & "4"
                Text1.Focus()
            Case 5
                Text1.Text = Text1.Text & "5"
                Text1.Focus()
            Case 6
                Text1.Text = Text1.Text & "6"
                Text1.Focus()
            Case 7
                Text1.Text = Text1.Text & "7"
                Text1.Focus()
            Case 8
                Text1.Text = Text1.Text & "8"
                Text1.Focus()
            Case 9
                Text1.Text = Text1.Text & "9"
                Text1.Focus()
            Case 10
                Text1.Text = Text1.Text & "0"
                Text1.Focus()
            Case 11
                Text1.Text = Text1.Text & "-"
                Text1.Focus()
            Case 12
                'Save String To Reg
                Keyboard.Data = Text1.Text
                'Hide Form
                Me.Close()
            Case 13
                If Len(Text1.Text) > 0 Then
                    Text1.Text = Mid(Text1.Text, 1, Len(Text1.Text) - 1)
                End If
                Text1.Focus()
            Case 14
                Text1.Text = ""
                Text1.Focus()
            Case 15
                Text1.Text = Text1.Text & " "
                Text1.Focus()
        End Select

    End Sub
    Private Sub btn0_Click(sender As System.Object, e As System.EventArgs) Handles btn0.Click
        ButtonPressed(0)
    End Sub

    Private Sub btn1_Click(sender As System.Object, e As System.EventArgs) Handles btn1.Click
        ButtonPressed(1)
    End Sub

    Private Sub btn2_Click(sender As System.Object, e As System.EventArgs) Handles btn2.Click
        ButtonPressed(2)
    End Sub

    Private Sub btn3_Click(sender As System.Object, e As System.EventArgs) Handles btn3.Click
        ButtonPressed(3)
    End Sub

    Private Sub btn4_Click(sender As System.Object, e As System.EventArgs) Handles btn4.Click
        ButtonPressed(4)
    End Sub

    Private Sub btn5_Click(sender As System.Object, e As System.EventArgs) Handles btn5.Click
        ButtonPressed(5)
    End Sub

    Private Sub btn6_Click(sender As System.Object, e As System.EventArgs) Handles btn6.Click
        ButtonPressed(6)
    End Sub

    Private Sub btn7_Click(sender As System.Object, e As System.EventArgs) Handles btn7.Click
        ButtonPressed(7)
    End Sub

    Private Sub btn8_Click(sender As System.Object, e As System.EventArgs) Handles btn8.Click
        ButtonPressed(8)
    End Sub

    Private Sub btn9_Click(sender As System.Object, e As System.EventArgs) Handles btn9.Click
        ButtonPressed(9)
    End Sub

    Private Sub btn10_Click(sender As System.Object, e As System.EventArgs) Handles btn10.Click
        ButtonPressed(10)
    End Sub

    Private Sub btn11_Click(sender As System.Object, e As System.EventArgs) Handles btn11.Click
        ButtonPressed(11)
    End Sub

    Private Sub btn12_Click(sender As System.Object, e As System.EventArgs) Handles btn12.Click
        ButtonPressed(12)
    End Sub

    Private Sub btn13_Click(sender As System.Object, e As System.EventArgs) Handles btn13.Click
        ButtonPressed(13)
    End Sub

    Private Sub btn14_Click(sender As System.Object, e As System.EventArgs) Handles btn14.Click
        ButtonPressed(14)
    End Sub

    Private Sub btn15_Click(sender As System.Object, e As System.EventArgs) Handles btn15.Click
        ButtonPressed(15)
    End Sub
End Class