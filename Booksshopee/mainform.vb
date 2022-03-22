
Public Class mainform

    Private Sub mainform_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub mainform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoginForm1.Hide()
        LoginForm1.TextBox1.Clear()
        LoginForm1.TextBox2.Clear()
        customerinfo.MdiParent = Me
        changepass.MdiParent = Me
        custsales.MdiParent = Me
        custdetail.MdiParent = Me
        productinfo.MdiParent = Me
        productstk.MdiParent = Me

        supplierinfo.MdiParent = Me
        suppdetail.MdiParent = Me
        purchase.MdiParent = Me
        purchaseedit.MdiParent = Me
        purchasedetail.MdiParent = Me
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
            cnn.Open()
        Else
            cnn.Open()
        End If
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        If customerinfo.WindowState = FormWindowState.Minimized Then
            customerinfo.WindowState = FormWindowState.Normal
            customerinfo.Show()
        Else
            customerinfo.Show()
        End If

    End Sub

    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        supplierinfo.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = FormatDateTime(Now, DateFormat.LongDate) & " " & FormatDateTime(Now, DateFormat.LongTime)


    End Sub

    Private Sub ProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        productinfo.Show()

    End Sub

    Private Sub PurchesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchesToolStripMenuItem.Click
        Try
            purchase.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try


    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim ans As String
        ans = MsgBox("Do u Want to Exit", MsgBoxStyle.YesNo, "Warning")
        If ans = vbYes Then
            Application.Exit()
        End If


    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        Dim ans As String
        ans = MsgBox("Do u Want to LogOff System", MsgBoxStyle.YesNo, "Warning")
        If ans = vbYes Then
            Me.Hide()
            LoginForm1.Show()
        End If
    End Sub

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        purchaseedit.Show()
    End Sub

    Private Sub IncomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncomeToolStripMenuItem.Click
        custsales.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        changepass.Show()
    End Sub

    Private Sub BackUpDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackUpDataToolStripMenuItem.Click

    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem.Click
        aboutus.Show()
    End Sub

    Private Sub AddNewUserAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewUserAccountToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        custsalesedit.Show()
    End Sub

    Private Sub GstInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GstInfornationToolStripMenuItem.Click
        Gst.Show()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click
        custwise.Show()
    End Sub

    Private Sub TotalSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalSalesToolStripMenuItem.Click
        totalsalesrpt.Show()
    End Sub
    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click
        productrpt.Show()
    End Sub

    Private Sub ProductInformationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductInformationToolStripMenuItem1.Click
        salesrpt.Show()
    End Sub

    Private Sub SalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem1.Click
        purchaserpt.Show()
    End Sub

    Private Sub SupplierInformationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierInformationToolStripMenuItem1.Click
        supplierrpt.Show()
    End Sub

    Private Sub SupplierBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierBillToolStripMenuItem.Click
        supppayment.Show()
    End Sub

    Private Sub GstCollectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GstCollectionToolStripMenuItem.Click
        Gstcollection.Show()
    End Sub
End Class
