Imports System.Text.RegularExpressions
Public Class FormAlteracaoVenda
    Private Sub FormAlteracaoVenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregarFormaPagamento()
    End Sub

    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        Me.Close()
        carregarDescFormaPagamento()
    End Sub

    Private Sub SalvarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItem.Click
        If TextBoxDescontoFormaDePagamentoPesquisaVenda.Text <> "" And TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text <> "" Then
            salvarFormaPagamento()
            carregarFormaPagamento()
            limparFormaCarregamento()
        Else
            MsgBox("Todos os campos devem ser preenchidos.")
        End If
    End Sub

    Private Sub TextBoxDescricaoFormaDePagamentoPesquisaVenda_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDescricaoFormaDePagamentoPesquisaVenda.TextChanged
        Dim verificar As String = "^[0-9]"
        If (Regex.IsMatch(TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text, verificar)) Then
            TextBoxDescricaoFormaDePagamentoPesquisaVenda.Clear()
        End If
        If TextBoxDescontoFormaDePagamentoPesquisaVenda.Text <> "" And TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub TextBoxDescontoFormaDePagamentoPesquisaVenda_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDescontoFormaDePagamentoPesquisaVenda.TextChanged
        Dim verificar As String = "^[a-zA-Z]"
        If (Regex.IsMatch(TextBoxDescontoFormaDePagamentoPesquisaVenda.Text, verificar)) Then
            TextBoxDescontoFormaDePagamentoPesquisaVenda.Clear()
        End If
        If TextBoxDescontoFormaDePagamentoPesquisaVenda.Text <> "" And TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        If TextBoxDescontoFormaDePagamentoPesquisaVenda.Text <> "" And TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text <> "" Then
            updateFormaPagamento()
            carregarFormaPagamento()
            limparFormaCarregamento()
        End If

    End Sub

    Private Sub DataGridViewFormaPagamentoPesquisaVenda_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewFormaPagamentoPesquisaVenda.CellContentClick
        TextBoxDescontoFormaDePagamentoPesquisaVenda.Text = DataGridViewFormaPagamentoPesquisaVenda.CurrentRow.Cells(2).Value.ToString
        TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text = DataGridViewFormaPagamentoPesquisaVenda.CurrentRow.Cells(1).Value.ToString
        idFormaPagamento = DataGridViewFormaPagamentoPesquisaVenda.CurrentRow.Cells(0).Value.ToString
        EditarToolStripMenuItem.Enabled = True
        ExcluirToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ExcluirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirToolStripMenuItem.Click
        MessageBox.Show("Deseja mesmo excluir a forma de pagamento ?", "Confirmar exclusão", MessageBoxButtons.YesNo)
        If Windows.Forms.DialogResult.Yes Then
            excluirFormaPagamento()
            carregarFormaPagamento()
            limparFormaCarregamento()
        End If
    End Sub

    Private Sub TextBoxDescontoFormaDePagamentoPesquisaVenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDescontoFormaDePagamentoPesquisaVenda.KeyPress

    End Sub
End Class