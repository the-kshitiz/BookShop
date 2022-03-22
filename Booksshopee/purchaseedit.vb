Public Class purchaseedit
    Public amt As Integer = 0
    Public dt As New DataTable
    Private Sub purchaseedit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        Me.CenterToScreen()
        If Me.Top <> 55 Then
            Me.Top = 55

        End If
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        dt.Columns.Add("Pro_ID")
        dt.Columns.Add("bName")
        dt.Columns.Add("isbnNo")
        dt.Columns.Add("Rate")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Current Stock")
        dt.Columns.Add("Old Stock")
        dt.Columns.Add(" ")
        Me.puredit.DataSource = dt
        Me.puredit11.DataSource = Nothing
        Me.puredit11.Refresh()
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
      
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.F1 Then
            Me.WindowState = FormWindowState.Minimized
            purchasedetail.Show()
            Button3.Focus()

        ElseIf e.KeyCode <> Keys.F1 And e.KeyCode <> Keys.Enter Then
            MsgBox("Press F1 Button for select Purchase ID", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox1.Focus()
        ElseIf e.KeyCode = Keys.Enter Then

            
        Else
            MsgBox("try agin")
            TextBox1.Clear()
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        
    End Sub

    Private Sub TextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick
        TextBox1.SelectAll()
        TextBox1.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
       
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If TextBox1.Text = "" Then
            ' MsgBox("Please Select the Purchase ID", MsgBoxStyle.Critical)

            TextBox1.Clear()
            TextBox1.Focus()
            Me.WindowState = FormWindowState.Minimized
            purchasedetail.Show()
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


                    Dim cmd11 = New OleDb.OleDbCommand("select * from purchase where pur_ID =" & TextBox1.Text & "", cnn) 'pur_ID =" & TextBox1.Text & " AND
                    cmd11.CommandType = CommandType.Text
                    Dim ad = New OleDb.OleDbDataAdapter(cmd11)
                    ds.Clear()
                    Me.puredit11.DataSource = Nothing
                    Me.puredit11.Refresh()
                    ad.Fill(ds)
                    Me.puredit11.DataSource = ds.Tables(0)


                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Try


                Dim bs1 = New BindingSource
                cmd = New OleDb.OleDbCommand("select * from supplier where  sid=" & TextBox3.Text & "", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                Dim ds1 As New DataSet
                ds1.Clear()
                ad.Fill(ds1)
                bs1.DataSource = ds1.Tables(0)
                TextBox5.DataBindings.Clear()
                TextBox6.DataBindings.Clear()

                TextBox5.DataBindings.Add("Text", bs1, "address")
                TextBox6.DataBindings.Add("Text", bs1, "phone")

            Catch ex As Exception
                MsgBox(ex.ToString)
                MsgBox("Error in supplier ")
            End Try
            Try


                Dim bs2 = New BindingSource
                cmd = New OleDb.OleDbCommand("select * from supp_bill where  supp_ID=" & TextBox3.Text & "", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                Dim ds2 As New DataSet
                ds2.Clear()
                ad.Fill(ds2)
                bs2.DataSource = ds2.Tables(0)
                TextBox2.DataBindings.Clear()
                TextBox15.DataBindings.Clear()
                TextBox16.DataBindings.Clear()
                TextBox17.DataBindings.Clear()

                TextBox2.DataBindings.Add("Text", bs2, "pay_ID")
                TextBox15.DataBindings.Add("Text", bs2, "totalamt")
                TextBox16.DataBindings.Add("Text", bs2, "paidamt")
                TextBox17.DataBindings.Add("Text", bs2, "balance")

            Catch ex As Exception
                MsgBox(ex.ToString)
                MsgBox("Error in supplier Bill  ")
            End Try
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub puredit_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles puredit.CellContentClick

    End Sub

    Private Sub puredit_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles puredit.CellDoubleClick
        Try
            If TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = 0 Or TextBox13.Text = 0 Then
                TextBox8.Text = puredit.SelectedRows(0).Cells("Pro_ID").Value
                TextBox9.Text = puredit.SelectedRows(0).Cells("bName").Value
                TextBox10.Text = puredit.SelectedRows(0).Cells("isbnNo").Value
                TextBox12.Text = puredit.SelectedRows(0).Cells("Rate").Value
                TextBox11.Text = puredit.SelectedRows(0).Cells("Quantity").Value
                TextBox13.Text = puredit.SelectedRows(0).Cells("Quantity").Value
                amt = puredit.SelectedRows(0).Cells("Amount").Value
                TextBox15.Text -= amt

                puredit.Rows.RemoveAt(puredit.SelectedRows(0).Index)
            Else
                MsgBox("Please First Click ON Add Button", MsgBoxStyle.Critical)
                Button1.Focus()
            End If

        Catch ex As Exception
            MsgBox("Select Only Row", MsgBoxStyle.Critical)
        End Try


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

    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged
        TextBox17.Text = Val(TextBox15.Text) - Val(TextBox16.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                    cnn.Open()
                Else
                    cnn.Open()
                End If


                ' dt.Rows.Add(TextBox1.Text, TextBox7.Text, TextBox3.Text, TextBox4.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text)
                dt.Rows.Add(TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox11.Text, TextBox18.Text)
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Text = 0
                TextBox12.Text = 0
                TextBox13.Text = 0
                TextBox14.Text = 0
                TextBox18.Text = 0
                TextBox8.Focus()
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub puredit1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles puredit11.CellContentClick

    End Sub

    Private Sub puredit1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles puredit11.CellDoubleClick
        Try
            If TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = 0 Or TextBox13.Text = 0 Then
                TextBox8.Text = puredit11.SelectedRows(0).Cells("pro_ID").Value
                TextBox9.Text = puredit11.SelectedRows(0).Cells("bname").Value
                TextBox10.Text = puredit11.SelectedRows(0).Cells("isbnno").Value
                TextBox12.Text = puredit11.SelectedRows(0).Cells("price").Value
                TextBox11.Text = puredit11.SelectedRows(0).Cells("quantity").Value
                TextBox13.Text = puredit11.SelectedRows(0).Cells("quantity").Value
                amt = puredit11.SelectedRows(0).Cells("amount").Value
                TextBox15.Text -= amt

                puredit11.Rows.RemoveAt(puredit11.SelectedRows(0).Index)
            Else
                MsgBox("Please First Click ON Add Button", MsgBoxStyle.Critical)
                Button1.Focus()
            End If

        Catch ex As Exception
            MsgBox("Select Only Row", MsgBoxStyle.Critical)
        End Try
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
                Dim pid
                Dim pdate
                Dim pay
                Dim sid
                Dim sname
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
                    curstk = Val(dt.Rows(r)(6))
                    If curstk > qty Then
                        stk = curstk - qty
                        oldstk = Val(dt.Rows(r)(7)) - stk
                    Else
                        stk = qty - curstk
                        oldstk = Val(dt.Rows(r)(7)) + stk
                    End If
                    Try
                        str = ("update purchase set price=" & (price) & ",quantity=" & (qty) & ",amount=" & (amt) & " where pro_ID=" & (prid) & "")

                        cmd = New OleDb.OleDbCommand(str, cnn)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        ' MessageBox.Show("Record Updated in purchase table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                    'this code work in progresss*************************
                    Try



                        cmd = New OleDb.OleDbCommand("UPDATE product SET price=" & (price) & ",quantity=" & (oldstk) & " where pid=" & (prid) & "", cnn)
                        ad = New OleDb.OleDbDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        cmd.ExecuteNonQuery()
                        ' MessageBox.Show("Record UppDate in product table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                Next
                Try
                    str = ("update supp_bill set totalamt=" & (tamt) & ",paidamt=" & (pamt) & ",balance=" & (bal) & " where pay_ID=" & (TextBox2.Text) & "")

                    cmd = New OleDb.OleDbCommand(str, cnn)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    'MessageBox.Show("Record Update in Supp_Bill table  Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                MessageBox.Show("Record UpDated Successful", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clerall()
                Me.Close()
            Else
                MsgBox("Row is empty canot Update Record", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        clerall()
    End Sub
    Public Sub clerall()
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
        'puredit.DataSource = Nothing
        Dim rw As Integer = puredit.Rows.Count
        For objrow = 0 To rw - 1
            If puredit.Rows.Count <> 1 Then
                puredit.Rows.RemoveAt(0)

            End If
        Next
        puredit.Refresh()
        puredit11.DataSource = Nothing
        puredit11.Refresh()

    End Sub

    Private Sub TextBox16_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox16.KeyUp
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Then
            TextBox17.Text = Val(TextBox15.Text) - Val(TextBox16.Text)
        Else
            ' MsgBox("Enter only Number ", MsgBoxStyle.Critical)
            TextBox16.SelectAll()
            TextBox16.Focus()

        End If
    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub Button3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.GotFocus

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Text = 0
        TextBox12.Text = 0
        TextBox13.Text = 0
        TextBox14.Text = 0
        TextBox18.Clear()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "" Then
            TextBox8.Clear()
        Else
            Dim bs1 = New BindingSource
            Dim cmd1 = New OleDb.OleDbCommand("select * from product where pid=" & (TextBox8.Text) & "", cnn)
            cmd1.CommandType = CommandType.Text
            Dim ad1 = New OleDb.OleDbDataAdapter(cmd1)
            Dim ds1 As New DataSet
            ds1.Clear()
            ad1.Fill(ds1)
            bs1.DataSource = ds1.Tables(0)
            TextBox18.DataBindings.Clear()
            Dim q = TextBox18.DataBindings.Add("Text", bs1, "quantity")
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        suppbill.Show()
    End Sub
End Class