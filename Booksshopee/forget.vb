Public Class forget

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'cnn.Close()
        'cnn.Open()
        'cmd = New OleDb.OleDbCommand("SELECT * FROM [admin] WHERE [pin] = '" & TextBox2.Text & "' ", cnn)

        If TextBox1.Text = "jarvish" And TextBox2.Text = "1234" Then
            'MessageBox.Show("verified succefully")
            setpassword.Show()
        Else
            MessageBox.Show("username or pin is incorrect")
        End If
        ' dr = cmd.ExecuteReader
        'Dim pin As Boolean = False
        'While dr.Read
        'pin = True

        'End While
        'If pin = True Then
        'setpassword.Show()
        'Me.Hide()
        'cnn.Close()
        'Else
        'MsgBox("Sorry, PIN or Username is Incorrect", MsgBoxStyle.OkOnly, "Invalid Details")
        'cnn.Close()
        'End If
        'Try
        'cmd.ExecuteNonQuery()
        'cmd.Dispose()
        'myConn.Close()
        'TextBox1.Clear()
        'TextBox2.Clear()

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try




    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class