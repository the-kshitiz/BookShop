Module Module1
    Public cnn As New OleDb.OleDbConnection("provider=microsoft.ACE.OLEDB.12.0; Data source=X:\project book store\Booksshopee\Booksshopee\books.accdb")
    Public ad As New OleDb.OleDbDataAdapter
    Public cmd As New OleDb.OleDbCommand
    Public ds As New DataSet
    Public dr As OleDb.OleDbDataReader
    Public bs As New BindingSource
    Public str As String
End Module
