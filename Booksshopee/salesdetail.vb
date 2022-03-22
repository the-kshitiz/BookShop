Public Class salesdetail

    Private Sub salesdetail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Booksshopee.custsalesedit.WindowState = FormWindowState.Normal
    End Sub

    Private Sub salesdetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        Me.CenterToScreen()
        Me.MdiParent = mainform
        Booksshopee.custsalesedit.WindowState = FormWindowState.Minimized
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        gridview()
    End Sub
    Public Sub gridview()
        If Booksshopee.purchaseedit.TextBox1.Text = "" Then
            Me.salesinfo.Refresh()
            cmd = New OleDb.OleDbCommand("select * from sales", cnn)
            cmd.CommandType = CommandType.Text
            ad = New OleDb.OleDbDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            ad.Fill(ds1)
            Me.salesinfo.DataSource = ds1.Tables(0)
            Me.salesinfo.Refresh()

        End If

    End Sub

    Private Sub salesinfo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles salesinfo.CellContentClick

    End Sub

    Private Sub salesinfo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles salesinfo.CellDoubleClick
        Try
            If Booksshopee.custsalesedit.WindowState = FormWindowState.Minimized Then
                Booksshopee.custsalesedit.TextBox1.Text = salesinfo.SelectedRows(0).Cells("sales_ID").Value
                Booksshopee.custsalesedit.TextBox7.Text = salesinfo.SelectedRows(0).Cells("sales_date").Value
                Booksshopee.custsalesedit.TextBox3.Text = salesinfo.SelectedRows(0).Cells("cust_ID").Value
                Booksshopee.custsalesedit.TextBox4.Text = salesinfo.SelectedRows(0).Cells("cust_name").Value
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        gridview()
    End Sub

    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
        If RadioButton1.Checked = True Then
            If Char.IsLetter(TextBox6.Text) = False Then
                MsgBox("Enter Only Character ", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else

                cmd = New OleDb.OleDbCommand("select * from sales where pname LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.salesinfo.DataSource = ds.Tables(0)
                Me.salesinfo.Refresh()
            End If

        ElseIf RadioButton2.Checked = True Then
            If Char.IsNumber(TextBox6.Text) = False Then
                MsgBox("Enter Only Number ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else
                'Me.custdata.Refresh()
                cmd = New OleDb.OleDbCommand("select * from sales where pro_ID LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.salesinfo.DataSource = ds.Tables(0)
                Me.salesinfo.Refresh()
            End If
        ElseIf RadioButton3.Checked = True Then

            cmd = New OleDb.OleDbCommand("select * from sales where pur_date LIKE'%" & TextBox6.Text & "%'", cnn)
            cmd.CommandType = CommandType.Text
            ad = New OleDb.OleDbDataAdapter(cmd)
            ds.Clear()
            ad.Fill(ds)
            Me.salesinfo.DataSource = ds.Tables(0)
            Me.salesinfo.Refresh()
        Else
            MsgBox("Please Select Option", MsgBoxStyle.Critical)
            TextBox6.Clear()
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class