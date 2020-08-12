Imports MySql.Data.MySqlClient
Imports System.IO
Module mdlFormFormaPagamento
    Public idFormaPagamento As Integer
    Public descontoFormaPagamento As Double
    Sub carregarFormaPagamento()
        Try
            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            abrir()
            fechar()

            sql = "SELECT * FROM RForma_Pagamento_Vendas"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormAlteracaoVenda.DataGridViewFormaPagamentoPesquisaVenda.DataSource = dados

            ajustarDgFormaPagamento()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub updateFormaPagamento()
        Try
            fechar()
            abrir()

            sql = "UPDATE RForma_Pagamento_Vendas SET nome_Pagamento = '" & FormAlteracaoVenda.TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text &
                ", desconto_Pagamento = '" & FormAlteracaoVenda.TextBoxDescontoFormaDePagamentoPesquisaVenda.Text & "')"
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Forma de pagamento editada com sucesso.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub ajustarDgFormaPagamento()
        With FormAlteracaoVenda.DataGridViewFormaPagamentoPesquisaVenda
            .Sort(FormAlteracaoVenda.DataGridViewFormaPagamentoPesquisaVenda.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "id"
            .Columns(0).Width = 30
            .Columns(1).HeaderText = "Descrição"
            .Columns(1).Width = 190
            .Columns(2).HeaderText = "Desconto"
            .Columns(2).Width = 80
        End With
    End Sub

    Sub salvarFormaPagamento()
        Try
            fechar()
            abrir()

            sql = "INSERT INTO RForma_Pagamento_Vendas (nome_Pagamento, desconto_Pagamento) VALUES ('" & FormAlteracaoVenda.TextBoxDescricaoFormaDePagamentoPesquisaVenda.Text &
                "','" & FormAlteracaoVenda.TextBoxDescontoFormaDePagamentoPesquisaVenda.Text & "')"
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Forma de pagamento salva com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub excluirFormaPagamento()
        Try
            fechar()
            abrir()

            sql = "DELETE FROM RForma_Pagamento_Vendas WHERE id_Pagamento = " & idFormaPagamento
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Forma de pagamento excluida com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub limparFormaCarregamento()
        FormAlteracaoVenda.TextBoxDescontoFormaDePagamentoPesquisaVenda.Clear()
        FormAlteracaoVenda.TextBoxDescricaoFormaDePagamentoPesquisaVenda.Clear()
    End Sub

    Sub carregarDescFormaPagamento()
        Try
            fechar()
            abrir()

            sql = "SELECT nome_Pagamento FROM RForma_Pagamento_Vendas"
            adaptador = New MySqlDataAdapter(sql, conexao)
            Dim dado As New DataSet
            adaptador.Fill(dado, "RForma_Pagamento_Vendas")

            With FormMenu.ComboBoxFormaPagamentoVenda
                .DataSource = dado.Tables(0)
                .ValueMember = "nome_Pagamento"
                .DisplayMember = "nome_Pagamento"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarDescontoFormaPagamento()
        Try
            fechar()
            abrir()

            sql = "SELECT desconto_Pagamento FROM RForma_Pagamento_Vendas WHERE nome_Pagamento = '" & FormMenu.ComboBoxFormaPagamentoVenda.Text & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            descontoFormaPagamento = reader.GetString(0)

        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

End Module
