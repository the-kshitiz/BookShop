Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Enterprise
Imports CrystalDecisions.ReportAppServer
Imports CrystalDecisions.Windows
Imports System.Data.OleDb
Public Class custbill
    Public crv As New CrystalReport10
    Private Sub custbill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.MdiParent = mainform
        Dim myparams As New ParameterFields
        Dim myparam As New ParameterField
        Dim mydiscvalue As New ParameterDiscreteValue
    
        myparam = New ParameterField()
        mydiscvalue = New ParameterDiscreteValue()
        myparam.ParameterFieldName = "sid"
        mydiscvalue.Value = custsalesedit.TextBox1.Text
        myparam.CurrentValues.Add(mydiscvalue)
        myparams.Add(myparam)


        CrystalReportViewer1.ParameterFieldInfo = myparams
        CrystalReportViewer1.ReportSource = crv

        CrystalReportViewer1.Refresh()
        CrystalReportViewer1.Visible = True
      

    End Sub
End Class