Public Class loginForm1

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("Enter the User Name and Password", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        ElseIf TextBox1.Text = "" Then
            MsgBox("Enter the User Name", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter the Password", MsgBoxStyle.Critical)
            TextBox2.Focus()
            Exit Sub
        Else
            cmd = New OleDb.OleDbCommand("select * from login where user='" & (TextBox1.Text) & "' AND pass='" & (TextBox2.Text) & "'", cnn)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.Read() Then

                mainform.Show()
                Me.Hide()

            Else
                MsgBox("Username And Password not match", MsgBoxStyle.Critical)
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
            End If

        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
        Me.Close()
    End Sub

    Private Sub LoginForm1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextBox1.Focus()
    End Sub



    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        cnn = New OleDb.OleDbConnection("provider=microsoft.ACE.OLEDB.12.0; Data source=X:\project book store\Booksshopee\Booksshopee\books.accdb")
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        bs = New BindingSource
        cmd = New OleDb.OleDbCommand("select * from login ", cnn)
        cmd.CommandType = CommandType.Text
        dr = cmd.ExecuteReader
        TextBox1.Focus()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
        Me.CenterToScreen()



    End Sub

    Private Sub register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles register.Click
        Form11.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        forget.Show()
    End Sub
End Class
