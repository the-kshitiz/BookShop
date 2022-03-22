Public Class suppdetail

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub gridview()
        Me.suppdata1.Refresh()
        cmd = New OleDb.OleDbCommand("select * from supplier", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        ad.Fill(ds1)
        Me.suppdata1.DataSource = ds1.Tables(0)
        Me.suppdata1.Refresh()
    End Sub

    Private Sub suppdetail_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Booksshopee.purchase.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub suppdetail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Booksshopee.purchase.WindowState = FormWindowState.Normal
        Booksshopee.purchase.TextBox8.Focus()
    End Sub
    Private Sub suppdetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub suppdata1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub suppdata1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub suppdata1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
       
    End Sub

    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gridview()
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
                Me.suppdata1.DataSource = ds.Tables(0)
                Me.suppdata1.Refresh()
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
                Me.suppdata1.DataSource = ds.Tables(0)
                Me.suppdata1.Refresh()
            End If
        Else
            MsgBox("Please Select Option", MsgBoxStyle.Critical)
            TextBox6.Clear()
            TextBox6.Focus()
        End If
    End Sub

   
    Private Sub TextBox6_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        gridview()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub suppdata1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles suppdata1.CellContentClick

    End Sub

    Private Sub suppdata1_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles suppdata1.CellDoubleClick
        Try
            Booksshopee.purchase.TextBox3.Text = suppdata1.SelectedRows(0).Cells("sid").Value
            Booksshopee.purchase.TextBox4.Text = suppdata1.SelectedRows(0).Cells("sname").Value
            Booksshopee.purchase.TextBox5.Text = suppdata1.SelectedRows(0).Cells("address").Value
            Booksshopee.purchase.TextBox6.Text = suppdata1.SelectedRows(0).Cells("phone").Value
            Booksshopee.purchase.TextBox8.Focus()
            Me.Close()
        Catch ex As Exception
            MsgBox("Please select Row", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class