Public Class purchasedetail

    Private Sub purchasedetail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Booksshopee.purchaseedit.WindowState = FormWindowState.Normal

    End Sub

    Private Sub purchasedetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        Booksshopee.purchaseedit.WindowState = FormWindowState.Minimized
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
    Public Sub gridview()

        Me.purdata11.Refresh()
        cmd = New OleDb.OleDbCommand("select * from purchase", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        ad.Fill(ds1)
        Me.purdata11.DataSource = ds1.Tables(0)
        Me.purdata11.Refresh()
        ' Else
        ' Me.purdata11.Refresh()
        ' cmd = New OleDb.OleDbCommand("select * from purchase where pur_ID=" & (msm.purchaseedit.TextBox1.Text) & "", cnn)
        ' cmd.CommandType = CommandType.Text
        'ad = New OleDb.OleDbDataAdapter(cmd)
        'Dim ds1 As New DataSet
        'ds1.Clear()
        'ad.Fill(ds1)
        'Me.purdata11.DataSource = ds1.Tables(0)
        'Me.purdata11.Refresh()


    End Sub

    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
        If RadioButton1.Checked = True Then
            If Char.IsLetter(TextBox6.Text) = False Then
                MsgBox("Enter Only Character ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else

                cmd = New OleDb.OleDbCommand("select * from purchase where pname LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.purdata11.DataSource = ds.Tables(0)
                Me.purdata11.Refresh()
            End If

        ElseIf RadioButton2.Checked = True Then
            If Char.IsNumber(TextBox6.Text) = False Then
                MsgBox("Enter Only Number ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else
                'Me.custdata.Refresh()
                cmd = New OleDb.OleDbCommand("select * from purchase where pro_ID LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.purdata11.DataSource = ds.Tables(0)
                Me.purdata11.Refresh()
            End If
        ElseIf RadioButton3.Checked = True Then

            cmd = New OleDb.OleDbCommand("select * from purchase where pur_date LIKE'%" & TextBox6.Text & "%'", cnn)
            cmd.CommandType = CommandType.Text
            ad = New OleDb.OleDbDataAdapter(cmd)
            ds.Clear()
            ad.Fill(ds)
            Me.purdata11.DataSource = ds.Tables(0)
            Me.purdata11.Refresh()
        Else
            MsgBox("Please Select Option", MsgBoxStyle.Critical)
            TextBox6.Clear()
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub purdata1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles purdata11.CellContentClick

    End Sub

    Private Sub purdata1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles purdata11.CellDoubleClick
        Try
            If Booksshopee.purchaseedit.WindowState = FormWindowState.Minimized Then
                Booksshopee.purchaseedit.TextBox1.Text = purdata11.SelectedRows(0).Cells("pur_ID").Value
                Booksshopee.purchaseedit.TextBox7.Text = purdata11.SelectedRows(0).Cells("pur_date").Value
                Booksshopee.purchaseedit.TextBox3.Text = purdata11.SelectedRows(0).Cells("supp_ID").Value
                Booksshopee.purchaseedit.TextBox4.Text = purdata11.SelectedRows(0).Cells("supp_name").Value
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        gridview()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class