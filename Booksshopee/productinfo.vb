Public Class productinfo

    Private Sub productinfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        bs = New BindingSource
        cmd = New OleDb.OleDbCommand("select * from product", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        ds.Clear()
        ad.Fill(ds)
        bs.DataSource = ds.Tables(0)
        p_data()

        gridview()
        Me.CenterToScreen()
        'DateTimePicker1.Value = Now.Date.ToString
        DateTimePicker2.Value = Now.Date.ToString


        DateTimePicker2.Value = Date.Today.Date
    End Sub
    Public Sub gridview()
        Me.prodata.Refresh()
        cmd = New OleDb.OleDbCommand("select * from product", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        ad.Fill(ds1)
        Me.prodata.DataSource = ds1.Tables(0)
        Me.prodata.Refresh()
    End Sub
    Public Sub p_data()
        TextBox1.DataBindings.Add("Text", bs, "pid")
        TextBox2.DataBindings.Add("Text", bs, "bname")
        TextBox3.DataBindings.Add("Text", bs, "publisher")
        TextBox4.DataBindings.Add("Text", bs, "isbnno")
        ComboBox1.DataBindings.Add("Text", bs, "bdesc")
        DateTimePicker2.DataBindings.Add("text", bs, "datee")
        TextBox6.DataBindings.Add("Text", bs, "price")
        TextBox9.DataBindings.Add("Text", bs, "sales")
        TextBox7.DataBindings.Add("Text", bs, "quantity")
        TextBox5.DataBindings.Add("Text", bs, "author")
        'DateTimePicker1.DataBindings.Add("text", bs, "mfd")
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MoveLast()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MovePrevious()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MoveNext()
    End Sub

    Private Sub TextBox8_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub TextBox8_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        TextBox8.SelectAll()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            If TextBox1.Text = "" Then
                MessageBox.Show("Enter the Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
            ElseIf TextBox2.Text = "" Then
                MessageBox.Show("Enter the Book name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf TextBox3.Text = "" Then
                MessageBox.Show("Enter the publisher Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf TextBox4.Text = "" Then
                MessageBox.Show("Enter the isbn no...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
            ElseIf ComboBox1.Text = "" Then
                MessageBox.Show("Select the Book Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBox1.Focus()
            ElseIf TextBox6.Text = "" Then
                MessageBox.Show("Enter the Book Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
            ElseIf TextBox9.Text = "" Then
                MessageBox.Show("Enter the Book Sales Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox9.Focus()

            ElseIf TextBox7.Text = "" Then
                MessageBox.Show("Enter the Book Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox7.Focus()
            Else
                str = ("insert into product values(" & (TextBox1.Text) & ",'" & (TextBox2.Text) & "','" & (TextBox3.Text) & "','" & (TextBox4.Text) & "','" & (ComboBox1.Text) & "','" & (DateTimePicker2.Value) & "'," & (TextBox6.Text) & "," & (TextBox9.Text) & "," & (TextBox7.Text) & ",'" & (TextBox5.Text) & "')")
                cmd = New OleDb.OleDbCommand(str, cnn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record Store", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bs.MoveFirst()
                gridview()
                Button4.Enabled = True
                Button5.Enabled = True
                'Button6.Enabled = True
                'Button7.Enabled = True
                'Button8.Enabled = True
                'Button9.Enabled = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim ans
            ans = MessageBox.Show("Do u want to delete current record ?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If ans = vbYes Then

                cmd = New OleDb.OleDbCommand("delete * from product where pid= " & (TextBox1.Text) & "", cnn)
                ad = New OleDb.OleDbDataAdapter(cmd)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Current Record Delete.....", "Delete Record ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmd = New OleDb.OleDbCommand("select * from product", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                bs.DataSource = ds.Tables(0)
                gridview()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TextBox8_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyUp
        If RadioButton1.Checked = True Then
            If Char.IsLetter(TextBox8.Text) = False Then
                MsgBox("Enter Only Character ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox8.Text = "" Then

            Else

                cmd = New OleDb.OleDbCommand("select * from product where bname LIKE'%" & TextBox8.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.prodata.DataSource = ds.Tables(0)
                Me.prodata.Refresh()
            End If

        ElseIf RadioButton2.Checked = True Then
            If Char.IsNumber(TextBox8.Text) = False Then
                MsgBox("Enter Only Number ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox8.Text = "" Then

            Else
                'Me.custdata.Refresh()
                cmd = New OleDb.OleDbCommand("select * from product where pid LIKE'%" & TextBox8.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.prodata.DataSource = ds.Tables(0)
                Me.prodata.Refresh()
            End If
        Else
            MsgBox("Please Select Option", MsgBoxStyle.Critical)
            TextBox8.Clear()
            TextBox8.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try

            cmd = New OleDb.OleDbCommand("UPDATE product SET bname='" & (TextBox2.Text) & "',publisher='" & (TextBox3.Text) & "',isbnno= " & (TextBox4.Text) & ",bdesc='" & (ComboBox1.Text) & "', datee='" & (DateTimePicker2.Value) & "',price=" & (TextBox6.Text) & ",sales=" & (TextBox9.Text) & ",quantity=" & (TextBox7.Text) & ",author='" & (TextBox5.Text) & "' where pid=" & (TextBox1.Text) & "", cnn)
            ad = New OleDb.OleDbDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            MessageBox.Show(" Current Record updated.... !", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cmd = New OleDb.OleDbCommand("select * from product", cnn)
            cmd.CommandType = CommandType.Text
            ad = New OleDb.OleDbDataAdapter(cmd)
            ds.Clear()
            ad.Fill(ds)
            bs.DataSource = ds.Tables(0)
            gridview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        bs = New BindingSource
        cmd = New OleDb.OleDbCommand("select * from product", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        ds.Clear()
        ad.Fill(ds)
        bs.DataSource = ds.Tables(0)
        Dim cnt As Integer = bs.Count
        If cnt < 0 Then
            TextBox1.Text = 1

        Else
            TextBox1.Text = cnt + 1
        End If
        TextBox2.Focus()
        DateTimePicker2.Value = Now.Date.ToString
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Text = ""
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        Button4.Enabled = False
        Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = False
        'Button8.Enabled = False
        'Button9.Enabled = False
    End Sub
End Class