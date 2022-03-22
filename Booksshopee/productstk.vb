Public Class productstk

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Public Sub gridview()
        Me.prodata1.Refresh()
        cmd = New OleDb.OleDbCommand("select * from product", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        ad.Fill(ds1)
        Me.prodata1.DataSource = ds1.Tables(0)
        Me.prodata1.Refresh()
    End Sub

    Private Sub productstk_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub productstk_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If Booksshopee.purchase.WindowState = FormWindowState.Minimized Then
                Booksshopee.purchase.WindowState = FormWindowState.Normal
                Booksshopee.purchase.TextBox12.Focus()

            ElseIf Booksshopee.custsales.WindowState = FormWindowState.Minimized Then
                Booksshopee.custsales.WindowState = FormWindowState.Normal
                Booksshopee.custsales.TextBox12.Focus()

            End If
        Catch ex As Exception 

        End Try
    End Sub

  Private Sub productstk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        gridview()
        Me.CenterToScreen()
        Me.Focus()

    End Sub

    Private Sub TextBox6_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
        If RadioButton1.Checked = True Then
            If Char.IsLetter(TextBox6.Text) = False Then
                MsgBox("Enter Only Character ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else

                cmd = New OleDb.OleDbCommand("select * from product where mname LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.prodata1.DataSource = ds.Tables(0)
                Me.prodata1.Refresh()
            End If

        ElseIf RadioButton2.Checked = True Then
            If Char.IsNumber(TextBox6.Text) = False Then
                MsgBox("Enter Only Number ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else
                'Me.custdata.Refresh()
                cmd = New OleDb.OleDbCommand("select * from product where pid LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.prodata1.DataSource = ds.Tables(0)
                Me.prodata1.Refresh()
            End If
        Else
            MsgBox("Please Select Option", MsgBoxStyle.Critical)
            TextBox6.Clear()
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        gridview()
    End Sub

    Private Sub prodata1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles prodata1.CellContentClick
        
    End Sub

    Private Sub prodata1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles prodata1.CellDoubleClick
        Try
            If Booksshopee.purchase.WindowState = FormWindowState.Minimized Then
                Booksshopee.purchase.TextBox8.Text = prodata1.SelectedRows(0).Cells("pid").Value
                Booksshopee.purchase.TextBox9.Text = prodata1.SelectedRows(0).Cells("bname").Value
                Booksshopee.purchase.TextBox10.Text = prodata1.SelectedRows(0).Cells("isbnno").Value
                Booksshopee.purchase.TextBox12.Text = prodata1.SelectedRows(0).Cells("price").Value
                Booksshopee.purchase.TextBox11.Text = prodata1.SelectedRows(0).Cells("quantity").Value
                Booksshopee.purchase.TextBox12.Focus()
                Me.Close()
            ElseIf Booksshopee.custsales.WindowState = FormWindowState.Minimized Then

                Booksshopee.custsales.TextBox8.Text = prodata1.SelectedRows(0).Cells("pid").Value
                Booksshopee.custsales.TextBox9.Text = prodata1.SelectedRows(0).Cells("bname").Value
                Booksshopee.custsales.TextBox10.Text = prodata1.SelectedRows(0).Cells("isbnno").Value
                Booksshopee.custsales.TextBox12.Text = prodata1.SelectedRows(0).Cells("sales").Value
                Booksshopee.custsales.TextBox11.Text = prodata1.SelectedRows(0).Cells("quantity").Value
                Booksshopee.custsales.TextBox12.Focus()
                Me.Close()
            Else


            End If
        Catch ex As Exception
            MsgBox("Please select Row", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class