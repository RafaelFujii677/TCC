Public Class FormDespezaReceita
    Public editandoDespesa As Boolean = False
    Public editandoReceita As Boolean = False
    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        Close()
    End Sub

    Private Sub SalvarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItem.Click
        TotalConta()
        If editandoDespesa Then

            If TextBoxDescDespesa.Text <> "" And TextBoxTextBoxValorDespesa.Text <> "" Then
                atualizarDespesas()
                editandoDespesa = False
                carregarDespesas()
                Me.Close()
            Else
                MsgBox("Os campos de despeza não podem estar vazios para a edição.")
            End If
        ElseIf editandoReceita Then
            If TextBoxDescReceita.Text <> "" And TextBoxValorReceita.Text <> "" Then
                atualizarReceitas()
                editandoReceita = False
                carregarReceitas()
                Me.Close()
            Else
                MsgBox("Os campos de receita não podem estar vazios para a edição.")
            End If

        Else

            If TextBoxDescDespesa.Text <> "" And TextBoxTextBoxValorDespesa.Text <> "" Then
                salvarDespesas()
                carregarDespesas()
                Me.Close()
            ElseIf TextBoxDescReceita.Text <> "" And TextBoxValorReceita.Text <> "" Then
                salvarReceitas()
                carregarReceitas()
                Me.Close()
            Else
                MsgBox("Algum campo necessário não foi preenchido.")
            End If

        End If

    End Sub

    Private Sub TextBoxDescDespesa_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDescDespesa.TextChanged
        If TextBoxDescDespesa.Text <> "" And TextBoxTextBoxValorDespesa.Text <> "" Or TextBoxDescReceita.Text <> "" And TextBoxValorReceita.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub TextBoxTextBoxValorDespesa_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTextBoxValorDespesa.TextChanged
        If TextBoxDescDespesa.Text <> "" And TextBoxTextBoxValorDespesa.Text <> "" Or TextBoxDescReceita.Text <> "" And TextBoxValorReceita.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub TextBoxDescReceita_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDescReceita.TextChanged
        If TextBoxDescDespesa.Text <> "" And TextBoxTextBoxValorDespesa.Text <> "" Or TextBoxDescReceita.Text <> "" And TextBoxValorReceita.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub TextBoxValorReceita_TextChanged(sender As Object, e As EventArgs) Handles TextBoxValorReceita.TextChanged
        If TextBoxDescDespesa.Text <> "" And TextBoxTextBoxValorDespesa.Text <> "" Or TextBoxDescReceita.Text <> "" And TextBoxValorReceita.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub FormDespezaReceita_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MsgBox("Para dados mais exatos do relatório, por favor, faça login novamente.")
    End Sub
End Class