Public Class Form11

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
    End Sub

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
            Dim cmd = New OleDb.OleDbCommand("insert into login values('" & (TextBox1.Text) & "','" & (TextBox2.Text) & "' )", cnn)

            Dim ad = New OleDb.OleDbDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            MessageBox.Show(" New Account Created Sucssesful.... !", "Added New User", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = ""
            TextBox2.Text = ""
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class