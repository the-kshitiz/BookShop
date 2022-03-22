Public Class supplierinfo

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub
    Public Sub s_data()
        TextBox1.DataBindings.Add("Text", bs, "sid")
        TextBox2.DataBindings.Add("Text", bs, "sname")
        TextBox3.DataBindings.Add("Text", bs, "address")
        TextBox4.DataBindings.Add("Text", bs, "city")
        TextBox5.DataBindings.Add("Text", bs, "phone")

    End Sub
    Public Sub gridview()
        Me.suppdata.Refresh()
        cmd = New OleDb.OleDbCommand("select * from supplier", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        ad.Fill(ds1)
        Me.suppdata.DataSource = ds1.Tables(0)
        Me.suppdata.Refresh()
    End Sub
    Private Sub supplierinfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        'cnn = New OleDb.OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source =c:\msm data\msm.mdb")

        bs = New BindingSource
        cmd = New OleDb.OleDbCommand("select * from supplier", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        ds.Clear()
        ad.Fill(ds)
        bs.DataSource = ds.Tables(0)
        s_data()

        gridview()
        Me.CenterToScreen()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MoveFirst()
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

    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        
    End Sub

    Private Sub TextBox6_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        TextBox6.SelectAll()
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        bs = New BindingSource
        cmd = New OleDb.OleDbCommand("select * from supplier", cnn)
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
        TextBox2.Text = ""
        TextBox2.Focus()
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Button4.Enabled = False
        Button5.Enabled = False
        ' Button6.Enabled = False
        'Button7.Enabled = False
        'Button8.Enabled = False
        'Button9.Enabled = False
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            TextBox5.MaxLength = (10)
            Dim a As Integer
            a = TextBox5.TextLength
            If TextBox1.Text = "" Then
                MessageBox.Show("Enter the Supplier ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
            ElseIf TextBox2.Text = "" Then
                MessageBox.Show("Enter the name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf TextBox3.Text = "" Then
                MessageBox.Show("Enter the Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf TextBox4.Text = "" Then
                MessageBox.Show("Enter the City Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
            ElseIf TextBox5.Text = "" Then
                MessageBox.Show("Enter the Correct Phone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()

            ElseIf a <> 10 Then
                MessageBox.Show("Enter The Correct Mobile No..", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
            Else
                str = ("insert into supplier values(" & (TextBox1.Text) & ",'" & (TextBox2.Text) & "','" & (TextBox3.Text) & "','" & (TextBox4.Text) & "'," & (TextBox5.Text) & ")")
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

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try

            cmd = New OleDb.OleDbCommand("UPDATE supplier SET sname='" & (TextBox2.Text) & "',address='" & (TextBox3.Text) & "',city='" & (TextBox4.Text) & "',phone=" & (TextBox5.Text) & " where sid=" & (TextBox1.Text) & "", cnn)
            ad = New OleDb.OleDbDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            MessageBox.Show(" Current Record updated.... !", "update", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cmd = New OleDb.OleDbCommand("select * from supplier", cnn)
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

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim ans
            ans = MessageBox.Show("Do u want to delete current record ?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If ans = vbYes Then

                cmd = New OleDb.OleDbCommand("delete * from supplier where sid= " & (TextBox1.Text) & "", cnn)
                ad = New OleDb.OleDbDataAdapter(cmd)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Current Record Delete.....", "Delete Record ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmd = New OleDb.OleDbCommand("select * from supplier", cnn)
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

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MoveFirst()
    End Sub

    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MoveLast()
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MovePrevious()

    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bs.MoveNext()
    End Sub

    Private Sub TextBox6_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
        If RadioButton1.Checked = True Then
            If Char.IsLetter(TextBox6.Text) = False Then
                MsgBox("Enter Only Character ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else

                cmd = New OleDb.OleDbCommand("select * from supplier where sname LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.suppdata.DataSource = ds.Tables(0)
                Me.suppdata.Refresh()
            End If

        ElseIf RadioButton2.Checked = True Then
            If Char.IsNumber(TextBox6.Text) = False Then
                MsgBox("Enter Only Number ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else
                'Me.custdata.Refresh()
                cmd = New OleDb.OleDbCommand("select * from supplier where sid LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.suppdata.DataSource = ds.Tables(0)
                Me.suppdata.Refresh()
            End If
        Else
            MsgBox("Please Select Option", MsgBoxStyle.Critical)
            TextBox6.Clear()
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub
End Class