<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.AdministratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewUserAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GstInfornationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.IncomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalSalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductInformationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierInformationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierBillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GstCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackUpDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdministratorToolStripMenuItem
        '
        Me.AdministratorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.AddNewUserAccountToolStripMenuItem})
        Me.AdministratorToolStripMenuItem.Name = "AdministratorToolStripMenuItem"
        Me.AdministratorToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.AdministratorToolStripMenuItem.Text = "&Administrator"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "&Change Password"
        '
        'AddNewUserAccountToolStripMenuItem
        '
        Me.AddNewUserAccountToolStripMenuItem.Name = "AddNewUserAccountToolStripMenuItem"
        Me.AddNewUserAccountToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.AddNewUserAccountToolStripMenuItem.Text = "&Add New User Account"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.AdministratorToolStripMenuItem, Me.SystemToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1060, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterToolStripMenuItem
        '
        Me.MasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem, Me.SupplierToolStripMenuItem, Me.ProductToolStripMenuItem, Me.GstInfornationToolStripMenuItem})
        Me.MasterToolStripMenuItem.Name = "MasterToolStripMenuItem"
        Me.MasterToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.MasterToolStripMenuItem.Text = "&Master"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CustomerToolStripMenuItem.Text = "&Customer"
        '
        'SupplierToolStripMenuItem
        '
        Me.SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        Me.SupplierToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.SupplierToolStripMenuItem.Text = "&Supplier"
        '
        'ProductToolStripMenuItem
        '
        Me.ProductToolStripMenuItem.Name = "ProductToolStripMenuItem"
        Me.ProductToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ProductToolStripMenuItem.Text = "&Product"
        '
        'GstInfornationToolStripMenuItem
        '
        Me.GstInfornationToolStripMenuItem.Name = "GstInfornationToolStripMenuItem"
        Me.GstInfornationToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.GstInfornationToolStripMenuItem.Text = "Gst Infornation"
        Me.GstInfornationToolStripMenuItem.Visible = False
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchesToolStripMenuItem, Me.SalesToolStripMenuItem, Me.ToolStripSeparator1, Me.IncomeToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.TransactionToolStripMenuItem.Text = "&Transaction"
        '
        'PurchesToolStripMenuItem
        '
        Me.PurchesToolStripMenuItem.Name = "PurchesToolStripMenuItem"
        Me.PurchesToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PurchesToolStripMenuItem.Text = "&Purches Stock"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SalesToolStripMenuItem.Text = "&Purchase Stock Edit"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'IncomeToolStripMenuItem
        '
        Me.IncomeToolStripMenuItem.Name = "IncomeToolStripMenuItem"
        Me.IncomeToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.IncomeToolStripMenuItem.Text = "&Sales"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 22)
        Me.ToolStripMenuItem1.Text = "&Sales Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerToolStripMenuItem1, Me.TotalSalesToolStripMenuItem, Me.ProductInformationToolStripMenuItem, Me.SupplierInformationToolStripMenuItem, Me.GstCollectionToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ReportsToolStripMenuItem.Text = "&Report's"
        '
        'CustomerToolStripMenuItem1
        '
        Me.CustomerToolStripMenuItem1.Name = "CustomerToolStripMenuItem1"
        Me.CustomerToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.CustomerToolStripMenuItem1.Text = "&Customer"
        '
        'TotalSalesToolStripMenuItem
        '
        Me.TotalSalesToolStripMenuItem.Name = "TotalSalesToolStripMenuItem"
        Me.TotalSalesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TotalSalesToolStripMenuItem.Text = "&Total Sales"
        '
        'ProductInformationToolStripMenuItem
        '
        Me.ProductInformationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseToolStripMenuItem, Me.SalesToolStripMenuItem1, Me.ProductInformationToolStripMenuItem1})
        Me.ProductInformationToolStripMenuItem.Name = "ProductInformationToolStripMenuItem"
        Me.ProductInformationToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ProductInformationToolStripMenuItem.Text = "&Product "
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.PurchaseToolStripMenuItem.Text = "&Product Information"
        '
        'SalesToolStripMenuItem1
        '
        Me.SalesToolStripMenuItem1.Name = "SalesToolStripMenuItem1"
        Me.SalesToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.SalesToolStripMenuItem1.Text = "&Purchase"
        '
        'ProductInformationToolStripMenuItem1
        '
        Me.ProductInformationToolStripMenuItem1.Name = "ProductInformationToolStripMenuItem1"
        Me.ProductInformationToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.ProductInformationToolStripMenuItem1.Text = "&Sales"
        '
        'SupplierInformationToolStripMenuItem
        '
        Me.SupplierInformationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupplierInformationToolStripMenuItem1, Me.SupplierBillToolStripMenuItem})
        Me.SupplierInformationToolStripMenuItem.Name = "SupplierInformationToolStripMenuItem"
        Me.SupplierInformationToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SupplierInformationToolStripMenuItem.Text = "&Supplier"
        '
        'SupplierInformationToolStripMenuItem1
        '
        Me.SupplierInformationToolStripMenuItem1.Name = "SupplierInformationToolStripMenuItem1"
        Me.SupplierInformationToolStripMenuItem1.Size = New System.Drawing.Size(183, 22)
        Me.SupplierInformationToolStripMenuItem1.Text = "&Supplier Information"
        '
        'SupplierBillToolStripMenuItem
        '
        Me.SupplierBillToolStripMenuItem.Name = "SupplierBillToolStripMenuItem"
        Me.SupplierBillToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SupplierBillToolStripMenuItem.Text = "Supplier Bill"
        '
        'GstCollectionToolStripMenuItem
        '
        Me.GstCollectionToolStripMenuItem.Name = "GstCollectionToolStripMenuItem"
        Me.GstCollectionToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GstCollectionToolStripMenuItem.Text = "Gst Collection"
        Me.GstCollectionToolStripMenuItem.Visible = False
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOffToolStripMenuItem, Me.ExitToolStripMenuItem, Me.BackUpDataToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.SystemToolStripMenuItem.Text = "&System"
        '
        'LogOffToolStripMenuItem
        '
        Me.LogOffToolStripMenuItem.Name = "LogOffToolStripMenuItem"
        Me.LogOffToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LogOffToolStripMenuItem.Text = "&LogOff"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'BackUpDataToolStripMenuItem
        '
        Me.BackUpDataToolStripMenuItem.Name = "BackUpDataToolStripMenuItem"
        Me.BackUpDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BackUpDataToolStripMenuItem.Text = "BackUp Data"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutUsToolStripMenuItem.Text = "About Us"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(966, 18)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 388)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1060, 23)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(79, 18)
        Me.ToolStripStatusLabel2.Text = "Date & time"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Booksshopee.My.Resources.Resources.books_education_school_literature_51342
        Me.ClientSize = New System.Drawing.Size(1060, 411)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.IsMdiContainer = True
        Me.Name = "mainform"
        Me.Text = "mainform"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AdministratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewUserAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GstInfornationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IncomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TotalSalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductInformationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierInformationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierBillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GstCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackUpDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
