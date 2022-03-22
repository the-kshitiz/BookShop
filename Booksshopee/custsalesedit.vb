Public Class custsalesedit
    Dim dt As New DataTable
    Private Sub custsalesedit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        Me.CenterToScreen()
        TextBox1.Focus()
        dt.Columns.Add("Pro_ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("isbnno")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Current Stock")
        dt.Columns.Add("Old Stock")
        dt.Columns.Add(" ")
        'Binding the rows to gridview
        salesdata.DataSource = dt
        CheckBox1.Checked = False
        Me.Focus()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.F1 Then
            Me.WindowState = FormWindowState.Minimized
            salesdetail.Show()
            Button3.Focus()

        ElseIf e.KeyCode <> Keys.F1 And e.KeyCode <> Keys.Enter Then
            MsgBox("Press F1 Button for select Sales ID", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox1.Focus()
        ElseIf e.KeyCode = Keys.Enter Then

        Else
            MsgBox("try agin")
            TextBox1.Clear()
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'clr()
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox7.Text = "" Then
            ' MsgBox("Please Select the Purchase ID", MsgBoxStyle.Critical)

            TextBox1.Clear()
            TextBox1.Focus()
            Me.WindowState = FormWindowState.Minimized
            salesdetail.Show()
            Button3.Focus()

        Else
            Try

                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                    cnn.Open()
                Else
                    cnn.Open()
                End If
                Try


                    Dim cmdsales = New OleDb.OleDbCommand("select pro_ID,bname,isbnno,price,quantity,amount from sales where sales_ID =" & Trim(TextBox1.Text) & " AND cust_ID =" & Trim(TextBox3.Text) & "", cnn) 'pur_ID =" & TextBox1.Text & " AND
                    cmdsales.CommandType = CommandType.Text
                    Dim ad1 = New OleDb.OleDbDataAdapter(cmdsales)
                    Dim ds1 As New DataSet
                    ds1.Clear()
                    Me.salesdata1.DataSource = Nothing
                    Me.salesdata1.Refresh()
                    ad1.Fill(ds1)
                    Me.salesdata1.DataSource = ds1.Tables(0)


                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
           
            Try


                Dim bs2 = New BindingSource
                Dim cmd = New OleDb.OleDbCommand("select c.cust_ID,c.pay_ID,c.sales_ID,c.sales_date,c.grossamt,c.totalamt,c.paidamt,c.balance from cust_bill c where c.sales_date=" & Trim(TextBox7.Text) & " AND c.sales_ID=" & Trim(TextBox1.Text) & " OR c.cust_ID=" & Trim(TextBox3.Text) & " AND c.sales_ID=" & Trim(TextBox1.Text) & "", cnn) '& TextBox3.Text & 
                cmd.CommandType = CommandType.Text
                Dim ad = New OleDb.OleDbDataAdapter(cmd)
                Dim ds2 As New DataSet
                ds2.Clear()
                ad.Fill(ds2)
                bs2.DataSource = ds2.Tables(0)
                TextBox2.DataBindings.Clear()
                TextBox20.DataBindings.Clear()
                TextBox15.DataBindings.Clear()
                TextBox16.DataBindings.Clear()
                TextBox17.DataBindings.Clear()
                TextBox2.DataBindings.Add("Text", bs2, "pay_ID")
                TextBox20.DataBindings.Add("Text", bs2, "grossamt")
                TextBox15.DataBindings.Add("Text", bs2, "totalamt")
                TextBox16.DataBindings.Add("Text", bs2, "paidamt")
                TextBox17.DataBindings.Add("Text", bs2, "balance")

            Catch ex As Exception
                MsgBox(ex.ToString)
                MsgBox("Error in Customer Bill  ")
            End Try

            Try
                Dim bs2 = New BindingSource
                Dim cmd = New OleDb.OleDbCommand("select * from Gst where  ID=" & TextBox2.Text & "", cnn)
                cmd.CommandType = CommandType.Text
                Dim ad = New OleDb.OleDbDataAdapter(cmd)
                Dim ds2 As New DataSet
                ds2.Clear()
                ad.Fill(ds2)
                bs2.DataSource = ds2.Tables(0)
                TextBox18.DataBindings.Clear()
                TextBox19.DataBindings.Clear()
                TextBox18.DataBindings.Add("Text", bs2, "Gstpersent")
                TextBox19.DataBindings.Add("Text", bs2, "Gstamt")
            Catch ex As Exception
                MsgBox(ex.ToString)
                MsgBox("Error in vat ")
            End Try
        End If
    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged
        If TextBox19.Text <> "0" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged
        If CheckBox1.Checked = True Then
            TextBox19.Text = Val(TextBox20.Text) * Val(TextBox18.Text) / 100
            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)
        Else
            TextBox19.Text = 0

            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)
        End If

    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        If CheckBox1.Checked = True Then
            TextBox19.Text = Val(TextBox20.Text) * Val(TextBox18.Text) / 100
            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)
        Else
            TextBox19.Text = 0

            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)
        End If
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

    Private Sub salesdata1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles salesdata1.CellContentClick

    End Sub

    Private Sub salesdata1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles salesdata1.CellDoubleClick
        Try
            Dim amt As Single
            If TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = 0 Or TextBox13.Text = 0 Then
                TextBox8.Text = salesdata1.SelectedRows(0).Cells("pro_ID").Value
                TextBox9.Text = salesdata1.SelectedRows(0).Cells("bname").Value
                TextBox10.Text = salesdata1.SelectedRows(0).Cells("isbnno").Value
                TextBox12.Text = salesdata1.SelectedRows(0).Cells("price").Value
                TextBox11.Text = salesdata1.SelectedRows(0).Cells("quantity").Value
                TextBox13.Text = salesdata1.SelectedRows(0).Cells("quantity").Value
                amt = salesdata1.SelectedRows(0).Cells("amount").Value
                TextBox20.Text -= Val(amt)

                salesdata1.Rows.RemoveAt(salesdata1.SelectedRows(0).Index)
            Else
                MsgBox("Please First Click ON Add Button", MsgBoxStyle.Critical)
                Button1.Focus()
            End If

        Catch ex As Exception
            MsgBox("Select Only Row", MsgBoxStyle.Critical)
        End Try
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

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text = "" Then
            TextBox13.Text = 0
            TextBox14.Text = Val(TextBox12.Text) * Val(TextBox13.Text)
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
                dt.Rows.Add(TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox11.Text, TextBox5.Text)

                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Text = 0
                TextBox12.Text = 0
                TextBox13.Text = 0
                TextBox14.Text = 0
                TextBox5.Text = 0
                TextBox8.Focus()
                If CheckBox1.Checked = True Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub CheckBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CheckBox1.MouseClick
        If CheckBox1.Checked = True Then
            TextBox19.Text = Val(TextBox20.Text) * Val(TextBox18.Text) / 100
            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)
        Else
            TextBox19.Text = 0
            TextBox15.Text = Val(TextBox20.Text) + Val(TextBox19.Text)

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Text = 0
        TextBox12.Text = 0
        TextBox13.Text = 0
        TextBox14.Text = 0
    End Sub
    Public Sub clr()
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
        TextBox1.Focus()
        TextBox7.Clear()
        Dim rw As Integer = salesdata.Rows.Count
        For objrow = 0 To rw - 1
            If salesdata.Rows.Count <> 1 Then
                salesdata.Rows.RemoveAt(0)

            End If
        Next
        Dim rw1 As Integer = salesdata1.Rows.Count
        For objrow1 = 0 To rw1 - 1
            If salesdata1.Rows.Count <> 1 Then
                salesdata1.Rows.RemoveAt(0)

            End If
        Next
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        clr()
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
                Dim stk As Integer
                Dim oldstk As Integer
                Dim curstk As Integer

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
                    
                    prid = dt.Rows(r)(0)
                    bname = dt.Rows(r)(1)
                    bno = dt.Rows(r)(2)
                    price = dt.Rows(r)(3)
                    qty = Val(dt.Rows(r)(4))
                    amt = dt.Rows(r)(5)
                    curstk = Val(dt.Rows(r)(6))
                    If curstk > qty Then
                        stk = curstk - qty
                        oldstk = Val(dt.Rows(r)(7)) + stk
                    Else
                        stk = qty - curstk
                        oldstk = Val(dt.Rows(r)(7)) - stk
                    End If
                    Try
                        str = ("update sales set price=" & (price) & ",quantity=" & (qty) & ",amount=" & (amt) & " where pro_ID=" & (prid) & "")

                        cmd = New OleDb.OleDbCommand(str, cnn)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        ' MessageBox.Show("Record Updated in sales table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                    'this code work in progresss*************************
                    Try



                        cmd = New OleDb.OleDbCommand("UPDATE product SET quantity=" & (oldstk) & " where pid=" & (prid) & "", cnn)
                        ad = New OleDb.OleDbDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        ' MessageBox.Show("Record UppDate in product table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                Next
                Try
                    str = ("update cust_bill set grossamt=" & Trim(TextBox20.Text) & " ,totalamt=" & (TextBox15.Text) & ",paidamt=" & (TextBox16.Text) & ",balance=" & (TextBox17.Text) & " where pay_ID=" & (TextBox2.Text) & "")

                    cmd = New OleDb.OleDbCommand(str, cnn)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    ' MessageBox.Show("Record Update in cust_Bill table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try


                If CheckBox1.CheckState = True Then
                    Try
                        Dim str1 As String
                        str1 = ("UPDATE Gst SET Gstpersent=" & Trim(TextBox18.Text) & ",Gstamt=" & Trim(TextBox19.Text) & " where sales_ID=" & Trim(TextBox1.Text) & "")

                        Dim cmd11 = New OleDb.OleDbCommand(str1, cnn)
                        cmd11.CommandType = CommandType.Text
                        cmd11.ExecuteNonQuery()
                        ' MessageBox.Show("Record Update in vat table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try


                End If
                MessageBox.Show("Record Store Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MsgBox("Row is empty canot Update Record", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub salesdata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles salesdata.CellContentClick

    End Sub

    Private Sub salesdata_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles salesdata.CellDoubleClick
        Try
            Dim amt As Single
            If TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = 0 Or TextBox13.Text = 0 Then
                TextBox8.Text = salesdata1.SelectedRows(0).Cells("pro_ID").Value
                TextBox9.Text = salesdata1.SelectedRows(0).Cells("bname").Value
                TextBox10.Text = salesdata1.SelectedRows(0).Cells("isbnno").Value
                TextBox12.Text = salesdata1.SelectedRows(0).Cells("price").Value
                TextBox11.Text = salesdata1.SelectedRows(0).Cells("quantity").Value
                TextBox13.Text = salesdata1.SelectedRows(0).Cells("quantity").Value
                amt = salesdata1.SelectedRows(0).Cells("amount").Value
                TextBox20.Text -= Val(amt)

                salesdata1.Rows.RemoveAt(salesdata1.SelectedRows(0).Index)
            Else
                MsgBox("Please First Click ON Add Button", MsgBoxStyle.Critical)
                Button1.Focus()
            End If

        Catch ex As Exception
            MsgBox("Select Only Row", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "" Then
            TextBox8.Clear()
        Else
            Dim bs1 = New BindingSource
            Dim cmd1 = New OleDb.OleDbCommand("select * from product where pid=" & Trim(TextBox8.Text) & "", cnn)
            cmd1.CommandType = CommandType.Text
            Dim ad1 = New OleDb.OleDbDataAdapter(cmd1)
            Dim ds1 As New DataSet
            ds1.Clear()
            ad1.Fill(ds1)
            bs1.DataSource = ds1.Tables(0)
            TextBox5.DataBindings.Clear()
            Dim q = TextBox5.DataBindings.Add("Text", bs1, "quantity")
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        custbill.Show()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class