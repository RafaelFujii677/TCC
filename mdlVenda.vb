Imports MySql.Data.MySqlClient
Imports System.IO
Module mdlVenda
    Public vendaAtiva As Boolean = False
    Dim idVendedorVenda As Integer
    Dim idClienteVenda As Integer
    Public idProdVenda As Integer
    Public marcaProdVenda As String
    Public nomeProdVenda As String
    Public precoProdVenda As Double
    Public qntProdVenda As Integer
    Public estoqueAtual As Integer
    Public primeiroProdVenda As Boolean = True
    Public desconto As Double
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim subTotal As Double = 0
    Dim total As Double
    Public pontos As Integer
    Public idReceitaExistente As Integer
    Public valorReceitaExistente As Double
    Public valorDespesaExistente As Double
    Public idTotalContaReceitaExistente As Integer
    Public comissaoFuncVenda As Double
    Public idDespesaExistente As Integer
    Public idTotalContaDespesaExistente As Integer
    Public valorVendaAtualFunc As Double
    Sub buscarIdVendedorVenda()
        Try
            Dim apelidoPesquisa As String = FormMenu.LabelNomeFunc.Text
            fechar()
            abrir()

            sql = "SELECT id_Funcionario FROM Funcionarios WHERE apelido_Funcionario = '" & apelidoPesquisa & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idVendedorVenda = reader.GetString(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarClienteVenda()
        Try
            Dim cpfPesquisa As String = FormPesquisa.DGClientes.CurrentRow.Cells(0).Value.ToString
            fechar()
            abrir()

            sql = "SELECT id_Cliente, nome_Cliente, pontos_Fidelidade_Cliente FROM Clientes WHERE cpf_Cliente = '" & cpfPesquisa & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idClienteVenda = reader.GetString(0)
            FormMenu.TextBoxNomeCliVendas.Text = reader.GetString(1)
            FormMenu.TextBoxPontosVenda.Text = reader.GetString(2)
            FormMenu.MaskedTextBoxCpfOuRgCliVendas.Text = cpfPesquisa
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub isNotEditableVenda()
        FormMenu.Button2.Enabled = False
        FormMenu.TextBoxObsVenda.Enabled = False
        FormMenu.ComboBoxFormaPagamentoVenda.Enabled = False
        FormMenu.DataGridViewProdutosVenda.Enabled = False
        vendaAtiva = False
    End Sub

    Sub isEditableVenda()
        FormMenu.Button2.Enabled = True
        FormMenu.TextBoxObsVenda.Enabled = True
        FormMenu.DataGridViewProdutosVenda.Enabled = True
        vendaAtiva = True
    End Sub

    Sub addProdCarrinho()
        If primeiroProdVenda Then
            addColuna()
        Else
            dr = dt.NewRow()
        End If

        primeiroProdVenda = False

        idProdVenda = FormMenu.TextBoxIdProd.Text
        nomeProdVenda = FormMenu.TextBoxNomeProd.Text
        marcaProdVenda = FormMenu.TextBoxMarcaProd.Text
        precoProdVenda = FormMenu.TextBoxPrecoProd.Text
        qntProdVenda = quantidadeProdVenda.TextBox1.Text


        Try

            addLinha()

            FormMenu.DataGridViewProdutosVenda.DataSource = dt
            ajustarDGProdVenda()
        Catch ex As ArgumentOutOfRangeException

            MsgBox("Deu OutOfRange")
        Catch exGeral As Exception
            MsgBox(exGeral.ToString)
        End Try

    End Sub

    Sub addColuna()

        With dt
            .Columns.Add("X", GetType(String))
            .Columns.Add("Marca", GetType(String))
            .Columns.Add("Nome", GetType(String))
            .Columns.Add("Preço", GetType(Double))
            .Columns.Add("Quantidade", GetType(Integer))
        End With
        dr = dt.NewRow()
    End Sub

    Sub addLinha()
        With dr
            .Item("X") = "X"
            .Item("Marca") = marcaProdVenda
            .Item("Nome") = nomeProdVenda
            .Item("Preço") = precoProdVenda
            .Item("Quantidade") = qntProdVenda
        End With
        dt.Rows.Add(dr)
    End Sub

    Sub ajustarDGProdVenda()
        With FormMenu.DataGridViewProdutosVenda
            .RowHeadersVisible = False
            .Columns(0).Width = 30

        End With
    End Sub

    Sub calcularSubTotal()
        Dim valor As Double

        For Each col As DataGridViewRow In FormMenu.DataGridViewProdutosVenda.Rows
            valor = valor + col.Cells(3).Value * col.Cells(4).Value
        Next
        FormMenu.TextBoxSubTotalVendas.Text = valor
    End Sub

    Sub calcularDescontoVenda()
        Dim descontoPontosCliVendas As Integer = 0

        If FormMenu.LabelDescontoPontos.Visible = True Then
            descontoPontosCliVendas = FormMenu.TextBoxPontosVenda.Text
        End If
        buscarDescontoFormaPagamento()
        subTotal = FormMenu.TextBoxSubTotalVendas.Text

        desconto = subTotal * (descontoFormaPagamento / 100)
        desconto += subTotal * (descontoPontosCliVendas / 100)
        total = subTotal - desconto
        FormMenu.TextBoxDescontoVenda.Text = desconto
        FormMenu.TextBoxTotalVendas.Text = total
    End Sub

    Sub salvarRProdutoVenda()
        buscarEstoqueAtual()
        qntProdVenda = quantidadeProdVenda.TextBox1.Text
        If estoqueAtual < quantidadeProdVenda.TextBox1.Text Then
            MsgBox("Estoque insuficiente.")
        Else
            Try
                fechar()
                abrir()

                sql = "INSERT INTO RProduto_Venda (id_Venda, id_Produto, qnt_produto) VALUES (@idVenda, @idProduto, @qntProduto)"
                cmdUser = New MySqlCommand(sql, conexao)
                With cmdUser
                    .Parameters.AddWithValue("@idVenda", FormMenu.TextBoxIdVenda.Text)
                    .Parameters.AddWithValue("@idProduto", FormMenu.TextBoxIdProd.Text)
                    .Parameters.AddWithValue("@qntProduto", qntProdVenda)
                End With

                cmdUser.ExecuteNonQuery()

                addProdCarrinho()
                FormMenu.ComboBoxFormaPagamentoVenda.Enabled = True
                atualizarEstoque()
                MsgBox("Estoque atualizado")
                quantidadeProdVenda.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                fechar()
            End Try
        End If
    End Sub

    Sub buscarEstoqueAtual()
        Try
            fechar()
            abrir()

            sql = "SELECT estoque_Produto FROM Produtos WHERE id_Produto = " & FormMenu.TextBoxIdProd.Text
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            estoqueAtual = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub atualizarEstoque()
        Try
            fechar()
            abrir()

            sql = "UPDATE Produtos SET estoque_Produto = " & estoqueAtual - qntProdVenda & " WHERE id_Produto = " & FormMenu.TextBoxIdProd.Text
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub excluirRProdutoVenda()
        Try
            fechar()
            abrir()

            sql = "DELETE FROM RProduto_Venda WHERE id_Venda = " & FormMenu.TextBoxIdVenda.Text
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub buscarEstoqueVendaCAncelada(valor As String)
        Try
            fechar()
            abrir()

            sql = "SELECT estoque_Produto FROM Produtos WHERE nome_Produto = '" & valor & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            estoqueAtual = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub atualizarEstoqueVendasCancelada()
        Dim valor As String
        Dim qntProd As Integer

        For Each col As DataGridViewRow In FormMenu.DataGridViewProdutosVenda.Rows
            valor = col.Cells(2).Value.ToString
            qntProd = col.Cells(4).Value.ToString

            buscarEstoqueVendaCAncelada(valor)

            Try
                fechar()
                abrir()

                sql = "UPDATE Produtos SET estoque_Produto = " & estoqueAtual + qntProd & " WHERE nome_Produto = '" & valor & "'"
                cmdUser = New MySqlCommand(sql, conexao)
                cmdUser.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                fechar()
            End Try

        Next
    End Sub

    Sub atualizarEstoqueProdutoCancelado()
        Dim valor As String
        Dim qntProd As Integer

        valor = FormMenu.DataGridViewProdutosVenda.CurrentRow.Cells(2).Value.ToString
        qntProd = FormMenu.DataGridViewProdutosVenda.CurrentRow.Cells(4).Value.ToString

        buscarEstoqueVendaCAncelada(valor)

            Try
                fechar()
                abrir()

                sql = "UPDATE Produtos SET estoque_Produto = " & estoqueAtual + qntProd & " WHERE nome_Produto = '" & valor & "'"
                cmdUser = New MySqlCommand(sql, conexao)
                cmdUser.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                fechar()
            End Try


    End Sub

    Sub finalizarVenda()
        buscarIdVendedorVenda()
        Dim format As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo()
        format.NumberDecimalSeparator = "."
        Try
            fechar()
            abrir()

            sql = "INSERT INTO Vendas (id_Funcionario_Venda, id_Cliente_Venda,  sub_Total_Venda, forma_Pagamento_Venda, desconto_Venda, total_Venda, data_Venda, observacoes_Venda)" &
                              "VALUES (  @idFunc           ,      @idCli     ,     @subTotal   ,       @formaPGT      ,     @desconto ,   @total   ,  @data    ,     @obs         )   "
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@idFunc", idVendedorVenda)
                .Parameters.AddWithValue("@idCli", idClienteVenda)
                .Parameters.AddWithValue("@subTotal", subTotal.ToString(format))
                .Parameters.AddWithValue("@formaPGT", FormMenu.ComboBoxFormaPagamentoVenda.Text)
                .Parameters.AddWithValue("@desconto", desconto.ToString(format))
                .Parameters.AddWithValue("@total", total.ToString(format))
                .Parameters.AddWithValue("@data", DateTime.Now)
                .Parameters.AddWithValue("@obs", FormMenu.TextBoxObsVenda.Text)
            End With
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Venda efetuada com sucesso.")
            End If

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao finalizar a venda.")
        Finally
            fechar()
        End Try
    End Sub

    Sub limparVenda()
        FormMenu.TextBoxIdVenda.Clear()
        FormMenu.TextBoxNomeCliVendas.Clear()
        FormMenu.MaskedTextBoxCpfOuRgCliVendas.Clear()
        FormMenu.MaskedTextBoxCpfOuRgCliVendas.Clear()
        FormMenu.TextBoxIdVenda.Clear()
        FormMenu.TextBoxDescontoVenda.Clear()
        FormMenu.TextBoxObsVenda.Clear()

        For Each col As DataGridViewRow In FormMenu.DataGridViewProdutosVenda.Rows
            FormMenu.DataGridViewProdutosVenda.Rows.RemoveAt(FormMenu.DataGridViewProdutosVenda.CurrentRow.Index)
        Next

        FormMenu.TextBoxSubTotalVendas.Clear()
        FormMenu.TextBoxTotalVendas.Clear()
        FormMenu.TextBoxPontosVenda.Clear()
        FormMenu.ComboBoxFormaPagamentoVenda.SelectedItem = -1
        FormMenu.LabelDataVenda.Text = ""
    End Sub

    Sub buscarUltimoIdVenda()
        Try
            fechar()
            abrir()

            sql = "SELECT MAX(id_Venda) FROM Vendas"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.TextBoxIdVenda.Text = reader.GetString(0) + 1

        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub buscarDataVenda()
        Try
            fechar()
            abrir()

            sql = "SELECT data_Venda FROM Vendas WHERE id_Venda = " & FormMenu.TextBoxIdVenda.Text
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.LabelDataVenda.Text = reader.GetString(0)

        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub calcularPontos(total As Double)
        If total > 20000 Then
            pontos += 10
        ElseIf total > 15000 Then
            pontos += 7
        ElseIf total > 10000 Then
            pontos += 5
        ElseIf total > 5000 Then
            pontos += 3
        ElseIf total > 1000 Then
            pontos += 1
        Else
            pontos += 0
        End If

    End Sub

    Sub pesquisarVendasFunc()
        Try
            fechar()
            abrir()

            sql = "SELECT vendas_Funcionario FROM Funcionarios WHERE id_Funcionario= " & idVendedorVenda
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            valorVendaAtualFunc = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub addVendaFunc()
        pesquisarVendasFunc()
        Dim format As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo()
        format.NumberDecimalSeparator = "."
        Dim novoValorVenda As Double = valorVendaAtualFunc + FormMenu.TextBoxTotalVendas.Text
        Try
            fechar()
            abrir()

            sql = "UPDATE Funcionarios SET vendas_Funcionario = " & novoValorVenda.ToString(format) & " WHERE id_Funcionario = " & idVendedorVenda
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub verificarExistenciaDeReceitaVenda()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Receita, id_Total_Conta FROM Receitas WHERE Descricao = 'Vendas-" & mesSistema & "/" & anoSistema & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idReceitaExistente = reader.GetString(0)
            idTotalContaReceitaExistente = reader.GetString(1)

            buscarValorReceitaExistente()
        Catch exMysql As MySqlException
            Console.WriteLine(exMysql.Message)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarValorReceitaExistente()
        Try
            fechar()
            abrir()

            sql = "SELECT Valor FROM Receitas WHERE id_Receita = " & idReceitaExistente
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            valorReceitaExistente = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub addVendaReceita()
        verificarExistenciaDeReceitaVenda()

        If idReceitaExistente <> Nothing And idReceitaExistente <> 0 Then
            Try
                fechar()
                abrir()

                sql = "UPDATE Receitas SET Valor =  @valor WHERE id_Receita = " & idReceitaExistente
                cmdUser = New MySqlCommand(sql, conexao)
                With cmdUser
                    .Parameters.AddWithValue("@valor", valorReceitaExistente + FormMenu.TextBoxTotalVendas.Text)
                End With
                cmdUser.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                fechar()
            End Try
        Else
            TotalConta()

            Try
                fechar()
                abrir()

                sql = "INSERT INTO Receitas (Descricao, Valor, id_Total_Conta) VALUES (@desc, @valor, @TotalConta)"
                cmdUser = New MySqlCommand(sql, conexao)
                With cmdUser
                    .Parameters.AddWithValue("@desc", "Vendas-" & mesSistema & "/" & anoSistema)
                    .Parameters.AddWithValue("@valor", FormMenu.TextBoxTotalVendas.Text)
                    .Parameters.AddWithValue("@TotalConta", idContaTotal)
                End With
                cmdUser.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                fechar()
            End Try
        End If
    End Sub

    Sub buscarComissaoFuncionarioVenda()
        Dim porcentagemComissao As Double
        Try
            fechar()
            abrir()

            sql = "SELECT comissao_Funcionario FROM Funcionarios WHERE id_Funcionario =" & idVendedorVenda
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            porcentagemComissao = reader.GetString(0) / 100
            comissaoFuncVenda = FormMenu.TextBoxTotalVendas.Text * porcentagemComissao
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub verificarDespesaExisente()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Despesa, id_Total_Conta FROM Despesas WHERE Descricao = 'Comissão dos Funcionários-" & mesSistema & "/" & anoSistema & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idDespesaExistente = reader.GetString(0)
            idTotalContaDespesaExistente = reader.GetString(1)

            buscarValorDespesaExistente()
        Catch ex As MySqlException

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarValorDespesaExistente()
        Try
            fechar()
            abrir()

            sql = "SELECT Valor FROM Despesas WHERE id_Despesa = " & idDespesaExistente
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            valorDespesaExistente = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub addComissaoDespesas()
        verificarDespesaExisente()

        If idDespesaExistente <> Nothing And idDespesaExistente <> 0 Then
            Try
                fechar()
                abrir()

                sql = "UPDATE Despesas SET Valor =  @valor WHERE id_Despesa = " & idDespesaExistente
                cmdUser = New MySqlCommand(sql, conexao)
                With cmdUser
                    .Parameters.AddWithValue("@valor", valorDespesaExistente + comissaoFuncVenda)
                End With
                cmdUser.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                fechar()
            End Try

        Else
            TotalConta()

            Try
                fechar()
                abrir()

                sql = "INSERT INTO Despesas (Descricao, Valor, id_Total_Conta) VALUES (@desc, @valor, @TotalConta)"
                cmdUser = New MySqlCommand(sql, conexao)
                With cmdUser
                    .Parameters.AddWithValue("@desc", "Comissão dos Funcionários-" & mesSistema & "/" & anoSistema)
                    .Parameters.AddWithValue("@valor", comissaoFuncVenda)
                    .Parameters.AddWithValue("@TotalConta", idContaTotal)
                End With
                cmdUser.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                fechar()
            End Try

        End If


    End Sub

End Module