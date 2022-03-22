Public Class custdetail

    Private Sub custdata1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles custdata1.CellContentClick

    End Sub

    Private Sub custdata1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles custdata1.CellContentDoubleClick
       
    End Sub
    Public Sub gridview()
        Me.custdata1.Refresh()
        cmd = New OleDb.OleDbCommand("select * from customer", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        ad.Fill(ds1)
        Me.custdata1.DataSource = ds1.Tables(0)
        Me.custdata1.Refresh()
    End Sub

    Private Sub custdetail_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Booksshopee.custsales.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub custdetail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Booksshopee.custsales.WindowState = FormWindowState.Normal
        Booksshopee.custsales.TextBox8.Focus()
    End Sub

    Private Sub custdetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        gridview()
        Me.CenterToScreen()
        If Me.Top <> 55 Then
            Me.Top = 55

        End If
        Me.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        gridview()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub custdata1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles custdata1.CellDoubleClick
        Try
            Booksshopee.custsales.TextBox3.Text = custdata1.SelectedRows(0).Cells("cid").Value
            Booksshopee.custsales.TextBox4.Text = custdata1.SelectedRows(0).Cells("cname").Value
            Booksshopee.custsales.TextBox5.Text = custdata1.SelectedRows(0).Cells("address").Value

            Booksshopee.custsales.TextBox8.Focus()
            Me.Close()
        Catch ex As Exception
            MsgBox("Please select Row", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
        If RadioButton1.Checked = True Then
            If Char.IsLetter(TextBox6.Text) = False Then
                MsgBox("Enter Only Character ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else

                cmd = New OleDb.OleDbCommand("select * from customer where cname LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.custdata1.DataSource = ds.Tables(0)
                Me.custdata1.Refresh()
            End If

        ElseIf RadioButton2.Checked = True Then
            If Char.IsNumber(TextBox6.Text) = False Then
                MsgBox("Enter Only Number ", MsgBoxStyle.Critical)

                Exit Sub
            ElseIf TextBox6.Text = "" Then

            Else
                'Me.custdata.Refresh()
                cmd = New OleDb.OleDbCommand("select * from customer where cid LIKE'%" & TextBox6.Text & "%'", cnn)
                cmd.CommandType = CommandType.Text
                ad = New OleDb.OleDbDataAdapter(cmd)
                ds.Clear()
                ad.Fill(ds)
                Me.custdata1.DataSource = ds.Tables(0)
                Me.custdata1.Refresh()
            End If
        Else
            MsgBox("Please Select Option", MsgBoxStyle.Critical)
            TextBox6.Clear()
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        
    End Sub
End Class