Public Class frmKeyboard
    Dim CapsFlag As Boolean
    Dim Section As String
    Dim Keyboard As New clsKeyboard

    Const KEY_ENTER = 28
    Const KEY_ESCAPE = 0

    Private Sub frmKeyboard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
                Text1.Text = Text1.Text & "%"
                Text1.Focus()
            Case 13
                If Len(Text1.Text) > 0 Then
                    Text1.Text = Mid(Text1.Text, 1, Len(Text1.Text) - 1)
                End If
                Text1.Focus()
            Case 14
                Text1.Text = Text1.Text & "\"
                Text1.Focus()
            Case 15
                Text1.Text = Text1.Text & "["
                Text1.Focus()
            Case 16
                Text1.Text = Text1.Text & Chr(Asc("p") + (32 * CapsFlag))
                Text1.Focus()
            Case 17
                Text1.Text = Text1.Text & Chr(Asc("o") + (32 * CapsFlag))
                Text1.Focus()
            Case 18
                Text1.Text = Text1.Text & Chr(Asc("i") + (32 * CapsFlag))
                Text1.Focus()
            Case 19
                Text1.Text = Text1.Text & Chr(Asc("u") + (32 * CapsFlag))
                Text1.Focus()
            Case 20
                Text1.Text = Text1.Text & Chr(Asc("y") + (32 * CapsFlag))
                Text1.Focus()
            Case 21
                Text1.Text = Text1.Text & Chr(Asc("t") + (32 * CapsFlag))
                Text1.Focus()
            Case 22
                Text1.Text = Text1.Text & Chr(Asc("r") + (32 * CapsFlag))
                Text1.Focus()
            Case 23
                Text1.Text = Text1.Text & Chr(Asc("e") + (32 * CapsFlag))
                Text1.Focus()
            Case 24
                Text1.Text = Text1.Text & Chr(Asc("w") + (32 * CapsFlag))
                Text1.Focus()
            Case 25
                Text1.Text = Text1.Text & Chr(Asc("q") + (32 * CapsFlag))
                Text1.Focus()
            Case 27
                'Change Caption on Cap Key and set flag
                If CapsFlag = True Then
                    CapsFlag = False
                    btn27.Text = "Caps"
                Else
                    CapsFlag = True
                    btn27.Text = "CAPS"
                End If
                Text1.Focus()
            Case KEY_ENTER
                'Save String To Reg
                Keyboard.Data = Text1.Text
                'Hide Form
                Me.Close()
            Case 29
                Text1.Text = Text1.Text & "'"
                Text1.Focus()
            Case 30
                Text1.Text = Text1.Text & ","
                Text1.Focus()
            Case 31
                Text1.Text = Text1.Text & Chr(Asc("l") + (32 * CapsFlag))
                Text1.Focus()
            Case 32
                Text1.Text = Text1.Text & Chr(Asc("k") + (32 * CapsFlag))
                Text1.Focus()
            Case 33
                Text1.Text = Text1.Text & Chr(Asc("j") + (32 * CapsFlag))
                Text1.Focus()
            Case 34
                Text1.Text = Text1.Text & Chr(Asc("h") + (32 * CapsFlag))
                Text1.Focus()
            Case 35
                Text1.Text = Text1.Text & Chr(Asc("g") + (32 * CapsFlag))
                Text1.Focus()
            Case 36
                Text1.Text = Text1.Text & Chr(Asc("f") + (32 * CapsFlag))
                Text1.Focus()
            Case 37
                Text1.Text = Text1.Text & Chr(Asc("d") + (32 * CapsFlag))
                Text1.Focus()
            Case 38
                Text1.Text = Text1.Text & Chr(Asc("s") + (32 * CapsFlag))
                Text1.Focus()
            Case 39
                Text1.Text = Text1.Text & Chr(Asc("a") + (32 * CapsFlag))
                Text1.Focus()
            Case 40
                Text1.Text = ""
                Text1.Focus()
            Case 41
                Text1.Text = Text1.Text & " "
                Text1.Focus()
            Case 42
                Text1.Text = Text1.Text & "/"
                Text1.Focus()
            Case 43
                Text1.Text = Text1.Text & "."
                Text1.Focus()
            Case 44
                Text1.Text = Text1.Text & ":"
                Text1.Focus()
            Case 45
                Text1.Text = Text1.Text & Chr(Asc("m") + (32 * CapsFlag))
                Text1.Focus()
            Case 46
                Text1.Text = Text1.Text & Chr(Asc("n") + (32 * CapsFlag))
                Text1.Focus()
            Case 47
                Text1.Text = Text1.Text & Chr(Asc("b") + (32 * CapsFlag))
                Text1.Focus()
            Case 48
                Text1.Text = Text1.Text & Chr(Asc("v") + (32 * CapsFlag))
                Text1.Focus()
            Case 49
                Text1.Text = Text1.Text & Chr(Asc("c") + (32 * CapsFlag))
                Text1.Focus()
            Case 50
                Text1.Text = Text1.Text & Chr(Asc("x") + (32 * CapsFlag))
                Text1.Focus()
            Case 51
                Text1.Text = Text1.Text & Chr(Asc("z") + (32 * CapsFlag))
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

    Private Sub btn16_Click(sender As System.Object, e As System.EventArgs) Handles btn16.Click
        ButtonPressed(16)
    End Sub

    Private Sub btn17_Click(sender As System.Object, e As System.EventArgs) Handles btn17.Click
        ButtonPressed(17)
    End Sub

    Private Sub btn18_Click(sender As System.Object, e As System.EventArgs) Handles btn18.Click
        ButtonPressed(18)
    End Sub

    Private Sub btn19_Click(sender As System.Object, e As System.EventArgs) Handles btn19.Click
        ButtonPressed(19)
    End Sub

    Private Sub btn20_Click(sender As System.Object, e As System.EventArgs) Handles btn20.Click
        ButtonPressed(20)
    End Sub

    Private Sub btn21_Click(sender As System.Object, e As System.EventArgs) Handles btn21.Click
        ButtonPressed(21)
    End Sub

    Private Sub btn22_Click(sender As System.Object, e As System.EventArgs) Handles btn22.Click
        ButtonPressed(22)
    End Sub

    Private Sub btn23_Click(sender As System.Object, e As System.EventArgs) Handles btn23.Click
        ButtonPressed(23)
    End Sub

    Private Sub btn24_Click(sender As System.Object, e As System.EventArgs) Handles btn24.Click
        ButtonPressed(24)
    End Sub

    Private Sub btn25_Click(sender As System.Object, e As System.EventArgs) Handles btn25.Click
        ButtonPressed(25)
    End Sub

    Private Sub btn27_Click(sender As System.Object, e As System.EventArgs) Handles btn27.Click
        ButtonPressed(27)
    End Sub

    Private Sub btn28_Click(sender As System.Object, e As System.EventArgs) Handles btn28.Click
        ButtonPressed(28)
    End Sub

    Private Sub btn29_Click(sender As System.Object, e As System.EventArgs) Handles btn29.Click
        ButtonPressed(29)
    End Sub

    Private Sub btn30_Click(sender As System.Object, e As System.EventArgs) Handles btn30.Click
        ButtonPressed(30)
    End Sub

    Private Sub btn31_Click(sender As System.Object, e As System.EventArgs) Handles btn31.Click
        ButtonPressed(31)
    End Sub

    Private Sub btn32_Click(sender As System.Object, e As System.EventArgs) Handles btn32.Click
        ButtonPressed(32)
    End Sub

    Private Sub btn33_Click(sender As System.Object, e As System.EventArgs) Handles btn33.Click
        ButtonPressed(33)
    End Sub

    Private Sub btn34_Click(sender As System.Object, e As System.EventArgs) Handles btn34.Click
        ButtonPressed(34)
    End Sub

    Private Sub btn35_Click(sender As System.Object, e As System.EventArgs) Handles btn35.Click
        ButtonPressed(35)
    End Sub

    Private Sub btn36_Click(sender As System.Object, e As System.EventArgs) Handles btn36.Click
        ButtonPressed(36)
    End Sub

    Private Sub btn37_Click(sender As System.Object, e As System.EventArgs) Handles btn37.Click
        ButtonPressed(37)
    End Sub

    Private Sub btn38_Click(sender As System.Object, e As System.EventArgs) Handles btn38.Click
        ButtonPressed(38)
    End Sub

    Private Sub btn39_Click(sender As System.Object, e As System.EventArgs) Handles btn39.Click
        ButtonPressed(39)
    End Sub

    Private Sub btn40_Click(sender As System.Object, e As System.EventArgs) Handles btn40.Click
        ButtonPressed(40)
    End Sub

    Private Sub btn41_Click(sender As System.Object, e As System.EventArgs) Handles btn41.Click
        ButtonPressed(41)
    End Sub

    Private Sub btn42_Click(sender As System.Object, e As System.EventArgs) Handles btn42.Click
        ButtonPressed(42)
    End Sub

    Private Sub btn43_Click(sender As System.Object, e As System.EventArgs) Handles btn43.Click
        ButtonPressed(43)
    End Sub

    Private Sub btn44_Click(sender As System.Object, e As System.EventArgs) Handles btn44.Click
        ButtonPressed(44)
    End Sub

    Private Sub btn45_Click(sender As System.Object, e As System.EventArgs) Handles btn45.Click
        ButtonPressed(45)
    End Sub

    Private Sub btn46_Click(sender As System.Object, e As System.EventArgs) Handles btn46.Click
        ButtonPressed(46)
    End Sub

    Private Sub btn47_Click(sender As System.Object, e As System.EventArgs) Handles btn47.Click
        ButtonPressed(47)
    End Sub

    Private Sub btn48_Click(sender As System.Object, e As System.EventArgs) Handles btn48.Click
        ButtonPressed(48)
    End Sub

    Private Sub btn49_Click(sender As System.Object, e As System.EventArgs) Handles btn49.Click
        ButtonPressed(49)
    End Sub

    Private Sub btn50_Click(sender As System.Object, e As System.EventArgs) Handles btn50.Click
        ButtonPressed(50)
    End Sub

    Private Sub btn51_Click(sender As System.Object, e As System.EventArgs) Handles btn51.Click
        ButtonPressed(51)
    End Sub

End Class