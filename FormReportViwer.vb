Public Class FormReportViwer
    Private Sub FormReportViwer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta linha de código carrega dados na tabela 'DataSet1.DataTable1'. Você pode movê-la ou removê-la conforme necessário.
        Me.DataTable1TableAdapter.FillVenda(Me.DataSet1.DataTable1)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class