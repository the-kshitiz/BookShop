Public Class custsales
    Public dt As New DataTable
    Dim stk As Double
    Public Sub addnew()
        Dim rw As Integer = salesdata.Rows.Count
        For objrow = 0 To rw - 1
            If salesdata.Rows.Count <> 1 Then
                salesdata.Rows.RemoveAt(0)

            End If
        Next
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

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
        TextBox19.Text = 0
        TextBox20.Text = 0
        CheckBox1.Checked = True
        TextBox8.Focus()
        TextBox7.Text = Now.Date
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        bs = New BindingSource
        cmd = New OleDb.OleDbCommand("select * from sales", cnn)
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
        cmd = New OleDb.OleDbCommand("select * from cust_bill", cnn)
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

    Private Sub custsales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        Me.MdiParent = mainform
        If Me.Top <> 55 Then
            Me.Top = 55

        End If
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
       
        dt.Columns.Add("Pro_ID")
        dt.Columns.Add("bName")
        dt.Columns.Add("isbnNo")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Current Stock")
        dt.Columns.Add(" ")
        'Binding the rows to gridview
        salesdata.DataSource = dt
        Me.Focus()
        addnew()
    End Sub

  

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        If e.KeyCode = Keys.F1 Then
            Me.WindowState = FormWindowState.Minimized
            custdetail.Show()

        ElseIf e.KeyCode <> Keys.F1 Then
            MsgBox("Press F1 Button for select Customer ID", MsgBoxStyle.Critical)
            TextBox3.Clear()
            TextBox3.Focus()
        Else
            MsgBox("try agin")
            TextBox3.Clear()
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox8_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyUp
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

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.GotFocus


        TextBox12.SelectAll()
        TextBox12.Focus()
    End Sub

    Private Sub TextBox12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox12.KeyUp
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Then
            TextBox14.Text = Val(TextBox12.Text * TextBox13.Text)
        Else
            ' MsgBox("Enter only Number ", MsgBoxStyle.Critical)
            TextBox12.SelectAll()
            TextBox12.Focus()

        End If
    End Sub

    Private Sub TextBox12_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox12.MouseClick
        TextBox12.SelectAll()
        TextBox12.Focus()
        TextBox14.Text = Val(TextBox12.Text * TextBox13.Text)
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

    Private Sub TextBox13_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.GotFocus
        TextBox13.SelectAll()
        TextBox13.Focus()
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

    Private Sub TextBox13_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox13.MouseClick
        TextBox13.SelectAll()
        TextBox13.Focus()
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text = "" Then
            TextBox13.Text = 0
            TextBox14.Text = Val(TextBox12.Text) * Val(TextBox13.Text)
            TextBox13.SelectAll()
        ElseIf Val(TextBox13.Text) > Val(TextBox11.Text) Then
            MessageBox.Show("Enter the Quantity Less Than :- " & TextBox11.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox13.Focus()

            TextBox13.Text = 0
            TextBox13.SelectAll()
        Else
            TextBox14.Text = Val(TextBox12.Text) * Val(TextBox13.Text)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            TextBox20.Text += Val(TextBox14.Text)
            If TextBox1.Text = "" Then
                MessageBox.Show("Enter the Sales ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
            ElseIf TextBox2.Text = "" Then
                MessageBox.Show("Enter the Pay ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf TextBox3.Text = "" Then
                MessageBox.Show("Enter the Customer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf TextBox7.Text = "" Then
                MessageBox.Show("Enter the Sales Date...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox7.Focus()
            ElseIf TextBox8.Text = "" Then
                MessageBox.Show("Enter the book ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ElseIf Val(TextBox13.Text) > Val(TextBox11.Text) Then
                MessageBox.Show("Enter the Quantity Less Than :- " & TextBox11.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox13.Focus()

                TextBox13.Text = 0
                TextBox13.SelectAll()
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Text = 0
        TextBox12.Text = 0
        TextBox13.Text = 0
        TextBox14.Text = 0
        TextBox8.Focus()
    End Sub

    Private Sub TextBox16_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox16.MouseClick
        TextBox16.Text = 0
        TextBox16.SelectAll()
        TextBox16.Focus()
    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        If TextBox16.Text = "" Then
            TextBox16.Text = 0
            TextBox16.SelectAll()
            TextBox16.Focus()
        Else
            TextBox17.Text = Val(TextBox15.Text) - Val(TextBox16.Text)
        End If
    End Sub

    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text = "" Then
            TextBox15.Text = 0

        Else
            TextBox17.Text = Val(TextBox15.Text) - Val(TextBox16.Text)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

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
        TextBox18.Text = 5
        TextBox19.Text = 0
        TextBox20.Text = 0
        TextBox8.Focus()
        TextBox7.Clear()
        Dim rw As Integer = salesdata.Rows.Count
        For objrow = 0 To rw - 1
            If salesdata.Rows.Count <> 1 Then
                salesdata.Rows.RemoveAt(0)

            End If
        Next

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
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
                Dim slid
                Dim sldate
                Dim pay
                Dim cid
                Dim cname
                Dim prid
                Dim bname
                Dim bno
                Dim price As Single
                Dim qty As Integer
                Dim amt As Single
                Dim tamt As Single = TextBox15.Text
                Dim pamt As Single = TextBox16.Text
                Dim bal As Single = TextBox17.Text
                For r = 0 To r1 - 1
                    slid = TextBox1.Text
                    sldate = TextBox7.Text
                    pay = TextBox2.Text
                    cid = TextBox3.Text
                    cname = TextBox4.Text
                    prid = dt.Rows(r)(0)
                    bname = dt.Rows(r)(1)
                    bno = dt.Rows(r)(2)
                    price = dt.Rows(r)(3)
                    qty = Val(dt.Rows(r)(4))
                    amt = dt.Rows(r)(5)
                    stk = Val(dt.Rows(r)(6)) - qty

                    Try
                        str = ("insert into sales values('" & (slid) & "','" & (sldate) & "','" & (cid) & "','" & (cname) & "','" & (prid) & "','" & (bname) & "','" & (bno) & "','" & (price) & "','" & (qty) & "','" & (amt) & "')")

                        cmd = New OleDb.OleDbCommand(str, cnn)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        'MessageBox.Show("Record Store in Sales table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                    Try

                        cmd = New OleDb.OleDbCommand("UPDATE product SET price=" & (price) & ",quantity=" & (stk) & " where pid=" & (prid) & "", cnn)

                        ad = New OleDb.OleDbDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        'MessageBox.Show("Record UppDate in product table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                Next
                Try
                    str = ("insert into cust_bill values(" & (TextBox2.Text) & "," & (TextBox1.Text) & ",'" & (TextBox7.Text) & "'," & (TextBox3.Text) & ",'" & (TextBox4.Text) & "'," & (TextBox20.Text) & "," & (tamt) & "," & (pamt) & "," & (bal) & ")")

                    cmd = New OleDb.OleDbCommand(str, cnn)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    ' MessageBox.Show("Record Store in cust_Bill table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                If CheckBox1.CheckState = True Then
                    Try
                        str = ("insert into Gst values(" & (TextBox2.Text) & "," & (TextBox1.Text) & ",'" & (TextBox7.Text) & "'," & (TextBox18.Text) & "," & (TextBox19.Text) & ")")

                        Dim cmd = New OleDb.OleDbCommand(str, cnn)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        ' MessageBox.Show("Record Store in vat table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If



                MessageBox.Show("Record Store Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'TextBox1.Clear()
                'TextBox2.Clear()
                'TextBox3.Clear()
                'TextBox4.Clear()
                'TextBox5.Clear()

                'TextBox8.Clear()
                'TextBox9.Clear()
                'TextBox10.Clear()
                'TextBox11.Text = 0
                'TextBox12.Text = 0
                'TextBox13.Text = 0
                'TextBox14.Text = 0
                'TextBox15.Text = 0
                'TextBox16.Text = 0
                'TextBox17.Text = 0
                'TextBox19.Text = 0
                'TextBox20.Text = 0

                'TextBox7.Clear()
                custbill.Show()
                Dim rw As Integer = salesdata.Rows.Count
                For objrow = 0 To rw - 1
                    If salesdata.Rows.Count <> 1 Then
                        salesdata.Rows.RemoveAt(0)

                    End If
                Next
            Else
                MsgBox("Row is empty canot save Record", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged
        Gst()
    End Sub
    Public Sub Gst()
        If CheckBox1.Checked = True Then
            TextBox19.Text = Val(TextBox20.Text) * Val(TextBox18.Text) / 100
            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)
        Else
            TextBox19.Text = 0
            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)

        End If
    End Sub

    Private Sub CheckBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CheckBox1.MouseClick
        Gst()
    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged

    End Sub

    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged
        Gst()
    End Sub



    Private Sub salesdata_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles salesdata.CellDoubleClick
        Try
            Dim amt As Integer
            If TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = 0 Or TextBox13.Text = 0 Then
                TextBox8.Text = salesdata.SelectedRows(0).Cells("Pro_ID").Value
                TextBox9.Text = salesdata.SelectedRows(0).Cells("bName").Value
                TextBox10.Text = salesdata.SelectedRows(0).Cells("isbnNo").Value
                TextBox12.Text = salesdata.SelectedRows(0).Cells("Rate").Value
                TextBox11.Text = salesdata.SelectedRows(0).Cells("Quantity").Value
                TextBox13.Text = salesdata.SelectedRows(0).Cells("Quantity").Value
                amt = salesdata.SelectedRows(0).Cells("Amount").Value
                If amt < Val(TextBox20.Text) Then
                    TextBox20.Text -= amt
                Else
                    TextBox15.Text = 0
                    TextBox20.Text = 0
                    TextBox19.Text = 0
                    TextBox17.Text = 0

                End If
                salesdata.Rows.RemoveAt(salesdata.SelectedRows(0).Index)
            Else
                MsgBox("Please First Click ON Add Button", MsgBoxStyle.Critical)
                Button1.Focus()
            End If

        Catch ex As Exception
            MsgBox("Select Only Row", MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        addnew()
    End Sub
End Class