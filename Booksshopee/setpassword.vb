Public Class setpassword

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox4.Text = "" Then
            MsgBox("Enter the User Name and Password", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        ElseIf TextBox1.Text = "" Then
            MsgBox("Enter the User Name", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        ElseIf TextBox4.Text = "" Then
            MsgBox("Enter the Password", MsgBoxStyle.Critical)
            TextBox4.Focus()
            Exit Sub
        Else
            cmd = New OleDb.OleDbCommand("select * from login where user='" & (TextBox1.Text) & "'", cnn)
            cmd.CommandType = CommandType.Text
            ' dr = cmd.ExecuteReader
            dr = cmd.ExecuteReader

            If dr.Read = True Then

                cmd = New OleDb.OleDbCommand("Update login set pass='" & (TextBox4.Text) & "' where user='" & (TextBox1.Text) & "'", cnn)
                'SET pass='" & (TextBox4.Text) & "'
                ad = New OleDb.OleDbDataAdapter(cmd)
                'cmd = New OleDb.OleDbCommand
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                '  MsgBox(i)
                ' bs.EndEdit()
                MessageBox.Show(" Current Record updated.... !", "update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Text = ""
                'TextBox2.Text = ""
                'TextBox3.Text = ""
                TextBox4.Text = ""
                'TextBox1.Focus()
                ' cnn.Close()
                Me.Close()

            Else
                MsgBox("Old Username And Password not match", MsgBoxStyle.Critical)
                TextBox1.Text = ""
                'TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox1.Focus()
            End If

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class