Public Class custreport

    Private Sub custreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CenterToScreen()
        Me.MdiParent = mainform
    End Sub

    Private Sub crystalReport111_InitReport(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crystalReport111.InitReport

    End Sub
End Class