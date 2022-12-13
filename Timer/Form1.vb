
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Focus()
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        TextBox1.MaxLength = 2
        TextBox2.MaxLength = 2
        TextBox3.MaxLength = 2
        On Error Resume Next
        Dim objService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\CIMV2")
        Dim VideoController = objService.ExecQuery("SELECT * FROM Win32_VideoController")
        For Each objVideo In VideoController
            hrlrst = objVideo.CurrentHorizontalResolution
            vrtrsl = objVideo.CurrentVerticalResolution
        Next
        DoubleBuffered = True
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
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Try
            h = TextBox1.Text
            m = TextBox2.Text
            s = TextBox3.Text
            starttimerbtn()

        Catch ex As Exception

        End Try
    End Sub
    Sub starttimerbtn()
        If Label5.Text = "Пуск" And Form3.Label5.Text = "Пуск" Then
            Form3.Label5.Text = "Стоп"
            Label5.Text = "Стоп"
            If h = 0 And m = 0 And s = 0 Then
                h = 24
            End If
            Timer1.Enabled = True
            Timer4.Enabled = True
            Timer3.Enabled = True
            Label6.Visible = True
            Label7.Visible = True
            Label8.Visible = True
            Label3.Visible = False
            Label4.Visible = False
            TextBox3.Visible = False
            TextBox2.Visible = False
            TextBox1.Visible = False
            With Form3
                .Label6.Visible = True
                .Label7.Visible = True
                .Label8.Visible = True
                .Label3.Visible = False
                .Label4.Visible = False
                .TextBox3.Visible = False
                .TextBox2.Visible = False
                .TextBox1.Visible = False
                .Label11.Visible = True
                .Label12.Visible = True
            End With
        Else
            stoptimerbtn()
        End If
    End Sub
    Sub stoptimerbtn()
        Timer1.Enabled = False
        Label5.Text = "Пуск"
        Timer4.Enabled = False
        Timer3.Enabled = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label3.Visible = True
        Label4.Visible = True
        TextBox3.Visible = True
        TextBox2.Visible = True
        TextBox1.Visible = True
        With Form3
            .Label5.Text = "Пуск"
            .Label6.Visible = False
            .Label7.Visible = False
            .Label8.Visible = False
            .Label3.Visible = True
            .Label4.Visible = True
            .TextBox3.Visible = True
            .TextBox2.Visible = True
            .TextBox1.Visible = True
            .Label11.Visible = False
            .Label12.Visible = False
        End With
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If s >= 0 Then
            s = s - 1
        End If
        If s < 0 Then
            s = 59
            Call minute()
        End If
        If s = 0 And m = 0 And h = 0 Then
            stoptimer()
        End If
    End Sub
    Sub minute()
        If m >= 0 Then
            m = m - 1
        End If
        If m < 0 And h > 0 Then
            Call hours()
            m = 59
        End If
    End Sub
    Sub hours()
        If h > 0 Then
            h = h - 1
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress
        Dim ShCu$ = vbBack & ChrW(1) & ChrW(22) & ChrW(24) & ChrW(26) & ChrW(3)
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse ShCu.Contains(e.KeyChar), e.KeyChar, Nothing)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Label5_Click(Me, New EventArgs)
        End If
        If e.KeyCode = Keys.F1 Then
            Me.Hide()
            Form2.Show()
            Form2.Focus()
        End If
        If e.KeyCode = Keys.Escape Then
            Try
                ProgressBar1.Visible = True
                ProgressBar1.Value = ProgressBar1.Value + 4.5
                If ProgressBar1.Value = 100 Then
                    Application.Exit()
                End If
            Catch ex As Exception

            End Try
        End If
        If e.KeyCode = Keys.F11 Then
            сменарежима()
        End If
    End Sub
    Sub сменарежима()
        If Me.Height > 642 Then
            Me.Size = New Size(500, 642)
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
    Sub stoptimer()
        Me.KeyPreview = False
        Label9.Text = (Form2.TextBox1.Text)
        Label9.Visible = True
        Label9.BringToFront()
        Label10.Visible = True
        Label10.BringToFront()
        stoptimerbtn()
        Timer3.Enabled = False
        With Form3
            .KeyPreview = False
            .Label9.Text = (Form2.TextBox1.Text)
            .Label9.Visible = True
            .Label9.BringToFront()
            .Label10.Visible = True
            .Label10.BringToFront()
        End With
        AxWindowsMediaPlayer1.URL = Application.StartupPath & "\finish.mp3"
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If s < 10 Then
            Label8.Text = "0" & s
            Form3.Label8.Text = Label8.Text
        Else
            Label8.Text = s
            Form3.Label8.Text = Label8.Text
        End If
        If m < 10 Then
            Label7.Text = "0" & m
            Form3.Label7.Text = Label7.Text
        Else
            Label7.Text = m
            Form3.Label7.Text = Label7.Text
        End If
        If h < 10 Then
            Label6.Text = "0" & h
            Form3.Label6.Text = Label6.Text
        Else
            Label6.Text = h
            Form3.Label6.Text = Label6.Text
        End If
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
        Form3.Opacity = TrackBar1.Value / 100
        Form3.TrackBar1.Value = TrackBar1.Value
    End Sub
End Class
