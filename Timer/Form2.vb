Public Class Form2
    Dim fontsize As String = "Маленький"
    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Select Case fontsize
                Case "Маленький"
                    Form1.Show()
                    Form1.Focus()
                    Me.Hide()
                Case "Большой"
                    Form3.Show()
                    Form3.Focus()
                    Me.Hide()
            End Select
        End If
        If e.KeyCode = Keys.F11 Then
            Form1.сменарежима()

        End If
    End Sub

    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Label3.MouseEnter
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label4.BorderStyle = BorderStyle.None
        Label5.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        Label3.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label4_MouseEnter(sender As Object, e As EventArgs) Handles Label4.MouseEnter
        Label3.BorderStyle = BorderStyle.None
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label5.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label4_MouseLeave(sender As Object, e As EventArgs) Handles Label4.MouseLeave
        Label4.BorderStyle = BorderStyle.None
    End Sub


    Private Sub Label5_MouseEnter(sender As Object, e As EventArgs) Handles Label5.MouseEnter
        Label3.BorderStyle = BorderStyle.None
        Label4.BorderStyle = BorderStyle.None
        Label5.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Label5.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click
        With Form1
            .Label3.Font = New Font("ProunX", 12)
            .Label4.Font = New Font("ProunX", 8)
            .Label5.Font = New Font("ProunX", 18)
            .Label6.Font = New Font("ProunX", 18)
            .Label7.Font = New Font("ProunX", 18)
            .Label8.Font = New Font("ProunX", 18)
            .Label9.Font = New Font("ProunX", 18)
            .Label12.Font = New Font("ProunX", 18)
            .Label13.Font = New Font("ProunX", 18)
            .TextBox1.Font = New Font("ProunX", 18)
            .TextBox2.Font = New Font("ProunX", 18)
            .TextBox3.Font = New Font("ProunX", 18)
            .TextBox1.Location = New Point(Form1.Label6.Location.X, Form1.Label6.Location.Y + 10)
            .TextBox2.Location = New Point(Form1.Label7.Location.X, Form1.Label7.Location.Y + 10)
            .TextBox3.Location = New Point(Form1.Label8.Location.X + 1, Form1.Label8.Location.Y + 10)
            .Label4.Text = "Час         Мин.       Сек."
        End With
        Me.Label1.Font = New Font("ProunX", 14)
        Me.Label2.Font = New Font("ProunX", 14)
        Me.TextBox1.Font = New Font("ProunX", 14)
        Me.Label6.Font = New Font("ProunX", 14)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        With Form1
            .Label3.Font = New Font("Arial Black", 12)
            .Label4.Font = New Font("Arial Black", 8)
            .Label5.Font = New Font("Arial Black", 18)
            .Label6.Font = New Font("Arial Black", 19)
            .Label7.Font = New Font("Arial Black", 19)
            .Label8.Font = New Font("Arial Black", 19)
            .Label9.Font = New Font("Arial Black", 19)
            .Label12.Font = New Font("Arial Black", 18)
            .Label13.Font = New Font("Arial Black", 18)
            .TextBox1.Font = New Font("Arial Black", 19.5)
            .TextBox2.Font = New Font("Arial Black", 19.5)
            .TextBox3.Font = New Font("Arial Black", 19.5)
            .TextBox1.Location = New Point(Form1.Label6.Location.X, Form1.Label6.Location.Y + 6)
            .TextBox2.Location = New Point(Form1.Label7.Location.X, Form1.Label7.Location.Y + 6)
            .TextBox3.Location = New Point(Form1.Label8.Location.X + 1, Form1.Label8.Location.Y + 6)
            .Label4.Text = "Час           Мин.         Сек."
        End With
        Me.Label1.Font = New Font("Arial Black", 14)
        Me.Label2.Font = New Font("Arial Black", 14)
        Me.TextBox1.Font = New Font("Arial Black", 14)
        Me.Label6.Font = New Font("Arial Black", 14)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        With Form1
            .Label3.Font = New Font("Impact", 16)
            .Label4.Font = New Font("Impact", 8)
            .Label5.Font = New Font("Impact", 18)
            .Label6.Font = New Font("Impact", 18)
            .Label7.Font = New Font("Impact", 18)
            .Label8.Font = New Font("Impact", 18)
            .Label9.Font = New Font("Impact", 18)
            .Label12.Font = New Font("Impact", 18)
            .Label13.Font = New Font("Impact", 18)
            .TextBox1.Font = New Font("Impact", 18)
            .TextBox2.Font = New Font("Impact", 18)
            .TextBox3.Font = New Font("Impact", 18)
            .Label4.Text = "Час                        Мин.                      Сек."
            .TextBox1.Location = New Point(Form1.Label6.Location.X, Form1.Label6.Location.Y + 10)
            .TextBox2.Location = New Point(Form1.Label7.Location.X, Form1.Label7.Location.Y + 10)
            .TextBox3.Location = New Point(Form1.Label8.Location.X + 1, Form1.Label8.Location.Y + 10)
        End With
        Me.Label1.Font = New Font("Impact", 14)
        Me.Label2.Font = New Font("Impact", 14)
        Me.TextBox1.Font = New Font("Impact", 14)
        Me.Label6.Font = New Font("Impact", 14)
    End Sub
    Sub changescreenstatus()
        If fontsize = "Большой" Then
            If Me.Height >= 720 Then
                Me.Size = Form3.Size
                Me.CenterToScreen()
            Else
                If Me.Height < 720 Then
                    Me.Size = Form3.Size
                    Me.CenterToScreen()
                End If
            End If
        Else
            If Me.Height >= 720 Then
                Me.Size = Form1.Size
                Me.CenterToScreen()
            Else
                If Me.Height < 720 Then
                    Me.Size = Form1.Size
                    Me.CenterToScreen()
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        Select Case ComboBox1.Text
            Case "Большой"
                fontsize = "Большой"
            Case "Маленький"
                fontsize = "Маленький"
        End Select
    End Sub
End Class