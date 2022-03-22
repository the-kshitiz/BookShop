Public Class Gst
    Dim dt As New DataTable
    Dim amt As Double
    Private Sub vat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = mainform
        Me.CenterToScreen()
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
        gridview()
    End Sub
    Public Sub gridview()
        Me.vatdata.Refresh()
        cmd = New OleDb.OleDbCommand("select * from Gst", cnn)
        cmd.CommandType = CommandType.Text
        ad = New OleDb.OleDbDataAdapter(cmd)
        Dim ds1 As New DataSet
        ds1.Clear()
        ad.Fill(ds1)
        Me.vatdata.DataSource = ds1.Tables(0)

        Me.vatdata.Refresh()
        Dim rw As Integer = vatdata.Rows.Count

        For objrow = 0 To rw - 1
            amt += vatdata.Rows(objrow).Cells("Gstamt").Value
        Next
        Label1.Text = "Tatal Gst : - " & amt
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Gstcollection.show()
        Me.Close()
    End Sub
End Class