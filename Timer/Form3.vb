Public Class Form3
    Private Sub Form3_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Label5_Click(Me, New EventArgs)
            Case Keys.F1
                Me.Hide()
                Form2.Show()
                Form2.Focus()
            Case Keys.Escape
                Try
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = ProgressBar1.Value + 4.5
                    If ProgressBar1.Value = 100 Then
                        Application.Exit()
                    End If
                Catch ex As Exception

                End Try
            Case Keys.F11
                сменарежима()
        End Select
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Show()
        Form1.Hide()
        Me.Focus()
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        TextBox1.MaxLength = 2
        TextBox2.MaxLength = 2
        TextBox3.MaxLength = 2
        DoubleBuffered = True
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Select Case Label5.Text
            Case "Пуск"
                Try
                    h = TextBox1.Text
                    m = TextBox2.Text
                    s = TextBox3.Text
                    Form1.starttimerbtn()
                Catch ex As Exception

                End Try
            Case "Стоп"
                Form1.stoptimerbtn()
        End Select
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.TextLength = 2 Then
            TextBox2.Focus()
        End If
        Try
            If TextBox1.Text >= 24 Then
                TextBox1.Text = 23
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength = 2 Then
            TextBox3.Focus()
        End If
        Try
            If TextBox2.Text >= 60 Then
                TextBox2.Text = 59
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.TextLength = 2 Then
            Label5.Focus()
        End If
        Try
            If TextBox3.Text >= 60 Then
                TextBox3.Text = 59
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Right Then
            If TextBox1.Focus Then TextBox2.Focus()
            TextBox2.SelectAll()
        End If
        If e.KeyCode = Keys.Left Then
            If TextBox1.Focus Then TextBox3.Focus()
            TextBox3.SelectAll()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Right Then
            If TextBox2.Focus Then TextBox3.Focus()
            TextBox3.SelectAll()
        End If
        If e.KeyCode = Keys.Left Then
            If TextBox2.Focus Then TextBox1.Focus()
            TextBox1.SelectAll()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Left Then
            If TextBox3.Focus Then TextBox2.Focus()
            TextBox2.SelectAll()
        End If
        If e.KeyCode = Keys.Right Then
            If TextBox3.Focus Then TextBox1.Focus()
            TextBox1.SelectAll()
        End If
    End Sub

    Private Sub Label5_MouseEnter(sender As Object, e As EventArgs) Handles Label5.MouseEnter
        Label5.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Label5.BorderStyle = BorderStyle.None
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress
        Dim ShCu$ = vbBack & ChrW(1) & ChrW(22) & ChrW(24) & ChrW(26) & ChrW(3)
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse ShCu.Contains(e.KeyChar), e.KeyChar, Nothing)
    End Sub
    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Label9.Visible = False
        Label10.Visible = False
        Me.KeyPreview = True
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            ProgressBar1.Value = 0
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Me.Opacity = TrackBar1.Value / 100
        Form2.Opacity = TrackBar1.Value / 100
        Form1.Opacity = TrackBar1.Value / 100
        Form1.TrackBar1.Value = TrackBar1.Value
    End Sub
    Sub сменарежима()
        If Me.Height > 702 Then
            Me.Size = New Size(1284, 701)
            Me.CenterToScreen()
            Call Form2.changescreenstatus()
        Else
            If Me.Height < vrtrsl Then
                Me.Size = New Size(hrlrst, vrtrsl)
                Me.CenterToScreen()
                Call Form2.changescreenstatus()
            End If
        End If
    End Sub
End Class