Public Class purchase
    Public dt As New DataTable
    Public stk As Double
   

    Private Sub TextBox13_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox13.SelectAll()
    End Sub

    Private Sub TextBox12_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox12.SelectAll()
    End Sub

   

    Private Sub TextBox12_MouseClick_1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        TextBox12.SelectAll()
        TextBox14.Text = Val(TextBox12.Text * TextBox13.Text)
    End Sub

    Private Sub purchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.CenterToScreen()
        Me.Top = 40
        'dt.Columns.Add("Pur_Date")
        'dt.Columns.Add("Pur_ID")
        ' dt.Columns.Add("Pay_ID")
        ' dt.Columns.Add("Supp_ID")
        'dt.Columns.Add("Supp_Name")
        dt.Columns.Add("Pro_ID")
        dt.Columns.Add("bName")
        dt.Columns.Add("isbnNo")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Current Stock")
        dt.Columns.Add(" ")
        'Binding the rows to gridview
        purdata.DataSource = dt
        Me.Focus()
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
  
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Text = 0
        TextBox12.Text = 0
        TextBox13.Text = 0
        TextBox14.Text = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Text = 0
        TextBox12.Text = 0
        TextBox13.Text = 0
        TextBox14.Text = 0
        TextBox15.Text = 0
        TextBox16.Text = 0
        TextBox17.Text = 0
        TextBox8.Focus()
        TextBox7.Text = Now.Date
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        bs = New BindingSource
        cmd = New OleDb.OleDbCommand("select * from purchase", cnn)
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
        'bs = New BindingSource
        bs.ResetItem(True)
        cmd = New OleDb.OleDbCommand("select * from supp_bill", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        ds.Clear()
        ad.Fill(ds)
        bs.DataSource = ds.Tables(0)
        Dim pay As Integer = bs.Count
        If pay < 0 Then
            TextBox2.Text = 1
        Else
            TextBox2.Text = pay + 1
        End If
        TextBox3.Focus()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim r1 As Integer
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                cnn.Open()
            Else
                cnn.Open()
            End If
            r1 = dt.Rows.Count()
            If 0 <> dt.Rows.Count() Then
                'Insert Record into Databace
                Dim str As String
                Dim pid
                Dim pdate
                Dim pay
                Dim sid
                Dim sname
                Dim prid
                Dim bname
                Dim bno
                Dim price As Integer
                Dim qty As Integer
                Dim amt As Integer
                Dim tamt As Integer = TextBox15.Text
                Dim pamt As Integer = TextBox16.Text
                Dim bal As Integer = TextBox17.Text
                For r = 0 To r1 - 1
                    pid = TextBox1.Text
                    pdate = TextBox7.Text
                    pay = TextBox2.Text
                    sid = TextBox3.Text
                    sname = TextBox4.Text
                    prid = dt.Rows(r)(0)
                    bname = dt.Rows(r)(1)
                    bno = dt.Rows(r)(2)
                    price = dt.Rows(r)(3)
                    qty = Val(dt.Rows(r)(4))
                    amt = dt.Rows(r)(5)
                    stk = Val(dt.Rows(r)(6)) + qty
                    Try
                        str = ("insert into purchase values('" & (pid) & "','" & (pdate) & "','" & (sid) & "','" & (sname) & "','" & (prid) & "','" & (bname) & "','" & (bno) & "','" & (price) & "','" & (qty) & "','" & (amt) & "')")

                        cmd = New OleDb.OleDbCommand(str, cnn)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        'MessageBox.Show("Record Store in purchase table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                    Try

                        cmd = New OleDb.OleDbCommand("UPDATE product SET price=" & (price) & ",quantity=" & (stk) & " where pid=" & (prid) & "", cnn)

                        ad = New OleDb.OleDbDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        ' MessageBox.Show("Record UppDate in product table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                Next
                Try
                    str = ("insert into supp_bill values(" & (TextBox2.Text) & "," & (TextBox1.Text) & ",'" & (TextBox7.Text) & "'," & (TextBox3.Text) & ",'" & (TextBox4.Text) & "'," & (tamt) & "," & (pamt) & "," & (bal) & ")")

                    cmd = New OleDb.OleDbCommand(str, cnn)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    'MessageBox.Show("Record Store in Supp_Bill table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                MessageBox.Show("Record Store Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Text = 0
                TextBox12.Text = 0
                TextBox13.Text = 0
                TextBox14.Text = 0
                TextBox15.Text = 0
                TextBox16.Text = 0
                TextBox17.Text = 0

                TextBox7.Clear()
                Me.Close()
            Else
                MsgBox("Row is empty canot save Record", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            TextBox15.Text += Val(TextBox14.Text)
            If TextBox1.Text = "" Then
                MessageBox.Show("Enter the Purchase ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
            ElseIf TextBox2.Text = "" Then
                MessageBox.Show("Enter the Pay ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf TextBox3.Text = "" Then
                MessageBox.Show("Enter the Supplier ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf TextBox7.Text = "" Then
                MessageBox.Show("Enter the Purchase Date...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox7.Focus()
            ElseIf TextBox8.Text = "" Then
                MessageBox.Show("Enter the Product ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox8.Focus()
            ElseIf TextBox9.Text = "" Then
                MessageBox.Show("Enter the book Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox9.Focus()
            ElseIf TextBox10.Text = "" Then
                MessageBox.Show("Enter the book isbn No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox10.Focus()
            ElseIf TextBox12.Text = "0" Then
                MessageBox.Show("Enter the book Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox12.Focus()
                Exit Sub
            ElseIf TextBox13.Text = "0" Then
                MessageBox.Show("Enter the book Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox13.Focus()
                Exit Sub
            ElseIf TextBox14.Text = "0" Then
                MessageBox.Show("Enter the Total Amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox14.Focus()
                Exit Sub
            Else
                dt.Rows.Add(TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox11.Text)

                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Text = 0
                TextBox12.Text = 0
                TextBox13.Text = 0
                TextBox14.Text = 0
                TextBox8.Focus()
            End If

           

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Text = 0
        TextBox12.Text = 0
        TextBox13.Text = 0
        TextBox14.Text = 0
        TextBox8.Focus()
    End Sub

    Private Sub Button5_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Text = 0
        TextBox12.Text = 0
        TextBox13.Text = 0
        TextBox14.Text = 0
        TextBox15.Text = 0
        TextBox16.Text = 0
        TextBox17.Text = 0
        TextBox8.Focus()
        TextBox7.Clear()

        Dim rw As Integer = purdata.Rows.Count
        For objrow = 0 To rw - 1
            If purdata.Rows.Count <> 1 Then
                purdata.Rows.RemoveAt(0)

            End If
        Next
        purdata.Refresh()
       
    End Sub

    Private Sub TextBox3_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        If e.KeyCode = Keys.F1 Then
            Me.WindowState = FormWindowState.Minimized
            suppdetail.Show()

        ElseIf e.KeyCode <> Keys.F1 Then
            MsgBox("Press F1 Button for select Supplier ID", MsgBoxStyle.Critical)
            TextBox3.Clear()
            TextBox3.Focus()
        Else
            MsgBox("try agin")
            TextBox3.Clear()
            TextBox3.Focus()
        End If
    End Sub

   

    Private Sub TextBox8_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyUp
        If e.KeyCode = Keys.F1 Then
            Me.WindowState = FormWindowState.Minimized
            productstk.Show()
            TextBox12.Focus()
        ElseIf e.KeyCode <> Keys.F1 Then
            MsgBox("Press F1 Button for select Product ID", MsgBoxStyle.Critical)
            TextBox8.Clear()
            TextBox8.Focus()
        Else
            MsgBox("try agin")
            TextBox8.Clear()
            TextBox8.Focus()
        End If
    End Sub

   

    Private Sub TextBox15_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text = "" Then
            TextBox15.Text = 0
            TextBox17.Text = Val(TextBox15.Text) - Val(TextBox16.Text)
        Else
            TextBox17.Text = Val(TextBox15.Text) - Val(TextBox16.Text)
        End If
    End Sub

    Private Sub TextBox16_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox16.GotFocus
        TextBox16.SelectAll()

    End Sub

    Private Sub TextBox16_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox16.KeyUp
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Then
            TextBox17.Text = Val(TextBox15.Text) - Val(TextBox16.Text)
        Else
            ' MsgBox("Enter only Number ", MsgBoxStyle.Critical)
            TextBox16.SelectAll()
            TextBox16.Focus()

        End If

    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub TextBox12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.GotFocus
        TextBox12.SelectAll()

    End Sub

    Private Sub TextBox12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox12.KeyUp
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Then
            TextBox14.Text = Val(TextBox12.Text * TextBox13.Text)
        ElseIf e.KeyCode = 110 And e.KeyCode = 119 Then

        Else

            ' MsgBox("Enter only Number ", MsgBoxStyle.Critical)

            TextBox12.SelectAll()
            TextBox12.Focus()

        End If

    End Sub

    Private Sub TextBox12_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox12.MouseClick
        TextBox12.SelectAll()
        TextBox14.Text = Val(TextBox12.Text * TextBox13.Text)
    End Sub

    Private Sub TextBox13_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.GotFocus
        TextBox13.SelectAll()

    End Sub

    
    

    Private Sub TextBox13_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox13.KeyUp
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Then
            TextBox14.Text = Val(TextBox12.Text * TextBox13.Text)
        Else
            ' MsgBox("Enter only Number ", MsgBoxStyle.Critical)

            TextBox13.SelectAll()
            TextBox13.Focus()

        End If


    End Sub

    
    
    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text = "" Then
            TextBox13.Text = 0
            TextBox14.Text = Val(TextBox12.Text) * Val(TextBox13.Text)
            TextBox13.SelectAll()
        Else
            TextBox14.Text = Val(TextBox12.Text) * Val(TextBox13.Text)
        End If
    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        If TextBox12.Text = "" Then
            TextBox12.Text = 0
            TextBox14.Text = Val(TextBox12.Text * TextBox13.Text)
            TextBox12.SelectAll()
        Else
            TextBox14.Text = Val(TextBox12.Text) * Val(TextBox13.Text)
        End If

    End Sub

    Private Sub TextBox16_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox16.MouseClick
        TextBox16.SelectAll()
        TextBox16.Focus()
    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        If TextBox16.Text = "" Then
            TextBox16.Text = 0
            TextBox16.SelectAll()
            TextBox16.Focus()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub purdata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles purdata.CellContentClick

    End Sub
End Class