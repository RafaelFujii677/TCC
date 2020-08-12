Public Class FormRelatorioTotalConta
    Private Sub FormRelatorioTotalConta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta linha de código carrega dados na tabela 'DataSet1.Total_Conta'. Você pode movê-la ou removê-la conforme necessário.
        Me.Total_ContaTableAdapter.FillTotalConta(Me.DataSet1.Total_Conta)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class