Imports MySql.Data.MySqlClient
Imports System.IO
Module mdlRelatorio
    Public idFuncMaxVendas As Integer
    Public fotoFuncRelatorio As Image
    Public anoSistema As String = Date.Now.ToString("yyyy")
    Public mesSistema As String = Date.Now.ToString("MM")
    Public idContaTotal As Integer
    Dim totalReceita As Integer
    Dim totalDespesa As Integer
    Dim lucroOuPrejuizo As Integer
    Public situacaoMesPassadoConta As String
    Public valorMesPassadoConta As Double
    Public somaSalarioFuncionario As Double
    Public idDespesa As Integer
    Public idReceita As Integer

    Sub buscarIdMelhorVendedor()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Funcionario FROM Funcionarios WHERE vendas_Funcionario = (SELECT MAX(vendas_Funcionario) FROM Funcionarios)"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idFuncMaxVendas = reader.GetString(0)

        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub buscarMelhorVendedor()
        buscarIdMelhorVendedor()
        carregarFotoMelhorFunc()

        Try
            fechar()
            abrir()

            sql = "SELECT nome_Funcionario, vendas_Funcionario FROM Funcionarios WHERE id_Funcionario = " & idFuncMaxVendas
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            FormMenu.LabelMelhorFuncRelatorio.Text = reader.GetString(0)
            FormMenu.LabelVendasFuncRelatorio.Text = reader.GetString(1)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub carregarFotoMelhorFunc()

        Try
            fechar()
            abrir()

            sql = "SELECT foto_Funcionario FROM Funcionarios WHERE id_Funcionario = " & idFuncMaxVendas
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            Dim blob As Byte() = DirectCast(reader.Item("foto_Funcionario"), Byte())
            Using ms = New MemoryStream(blob)
                fotoFuncRelatorio = New Bitmap(ms)
            End Using

            FormMenu.PictureBox1.Image = fotoFuncRelatorio

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try

    End Sub

    Sub carregarDespesas()
        TotalConta()
        Try
            fechar()
            abrir()


            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT Descricao, Valor FROM Despesas WHERE id_Total_Conta = " & idContaTotal
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormMenu.DataGridViewDespesas.DataSource = dados

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
            ajustarDGDespesas()
            somarTotalDespesas()
        End Try

    End Sub

    Sub ajustarDGDespesas()
        With FormMenu.DataGridViewDespesas
            .Sort(FormMenu.DataGridViewDespesas.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "Descrição"
            .Columns(0).Width = 200
            .Columns(1).HeaderText = "Valor"
            .Columns(1).Width = 100
        End With
    End Sub

    Sub ajustarDGReceitas()
        With FormMenu.DataGridViewReceitas
            .Sort(FormMenu.DataGridViewReceitas.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "Descrição"
            .Columns(0).Width = 200
            .Columns(1).HeaderText = "Valor"
            .Columns(1).Width = 100
        End With
    End Sub

    Sub carregarReceitas()
        TotalConta()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT Descricao, Valor FROM Receitas WHERE id_Total_Conta = " & idContaTotal
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormMenu.DataGridViewReceitas.DataSource = dados

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
            ajustarDGReceitas()
            somarTotalReceitas()
        End Try
    End Sub

    Sub somarTotalDespesas()
        Dim valor As Double

        For Each col As DataGridViewRow In FormMenu.DataGridViewDespesas.Rows
            valor = valor + col.Cells(1).Value
        Next
        FormMenu.LabelDespesas.Text = valor
        totalDespesa = valor
    End Sub

    Sub somarTotalReceitas()
        Dim valor As Double

        For Each col As DataGridViewRow In FormMenu.DataGridViewReceitas.Rows
            valor = valor + col.Cells(1).Value
        Next
        FormMenu.LabelReceitas.Text = valor
        totalReceita = valor
    End Sub

    Sub calcularReceitaDespesa()
        lucroOuPrejuizo = totalReceita - totalDespesa
        If lucroOuPrejuizo < 0 Then
            FormMenu.GroupBoxLucroOuPrejuizoRelatorio.Text = "Prejuízo"
            FormMenu.LabelValorLucroOuPrejuízo.Text = lucroOuPrejuizo
            FormMenu.LabelValorLucroOuPrejuízo.ForeColor = Color.Red
        Else
            FormMenu.GroupBoxLucroOuPrejuizoRelatorio.Text = "Lucro"
            FormMenu.LabelValorLucroOuPrejuízo.Text = lucroOuPrejuizo
            FormMenu.LabelValorLucroOuPrejuízo.ForeColor = Color.Green
        End If

    End Sub

    Sub TotalConta()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Total FROM Total_Conta WHERE mes_Total = " & mesSistema & " AND ano_Total = " & anoSistema
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idContaTotal = reader.GetString(0)

        Catch ex As MySqlException
            buscarMesAnoAnterior()
        Catch exGeral As Exception
            MsgBox(exGeral.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarMesAnoAnterior()
        mesSistema -= 1
        If mesSistema = 0 Then
            mesSistema = 12
            anoSistema -= 1
        End If

        Try
            fechar()
            abrir()

            sql = "SELECT id_Total FROM Total_Conta WHERE mes_Total = " & mesSistema & " AND ano_Total = " & anoSistema
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idContaTotal = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            carregarDespesas()
            carregarReceitas()
            calcularReceitaDespesa()
            fecharMesAnoAnterior()
            anoSistema = Date.Now.ToString("yyyy")
            mesSistema = Date.Now.ToString("MM")
            criarContaMesEAnoAtual()
            addSalarioDespesa()
        End Try

    End Sub

    Sub fecharMesAnoAnterior()
        Try
            fechar()
            abrir()

            If lucroOuPrejuizo < 0 Then
                sql = "UPDATE Total_Conta SET situacao_Total = 'Prejuízo', valor_Lucro_Prejuizo =" & lucroOuPrejuizo & " WHERE id_Total = " & idContaTotal
            Else
                sql = "UPDATE Total_Conta SET situacao_Total = 'Lucro', valor_Lucro_Prejuizo =" & lucroOuPrejuizo & " WHERE id_Total = " & idContaTotal
            End If
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.ExecuteNonQuery()

            MsgBox("Mês fechado com sucesso.")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub criarContaMesEAnoAtual()
        Try
            fechar()
            abrir()

            sql = "INSERT INTO Total_Conta (mes_Total, ano_Total) VALUES (" & mesSistema & ", " & anoSistema & ")"
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.ExecuteNonQuery()

            MsgBox("Novo mês aberto.")

            zerarVendasFunc()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub zerarVendasFunc()
        Try
            fechar()
            abrir()

            sql = "UPDATE Funcionarios SET vendas_Funcionario = " & 0
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub salvarDespesas()
        Try
            fechar()
            abrir()

            sql = "INSERT INTO Despesas (Descricao, valor, id_Total_Conta) VALUES ('" & FormDespezaReceita.TextBoxDescDespesa.Text &
                "-" & mesSistema & "/" & anoSistema & "','" & FormDespezaReceita.TextBoxTextBoxValorDespesa.Text & "','" & idContaTotal & "')"
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery() Then
                MsgBox("Despesa salva com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub salvarReceitas()
        Try
            fechar()
            abrir()

            sql = "INSERT INTO Receitas (Descricao, valor, id_Total_Conta) VALUES ('" & FormDespezaReceita.TextBoxDescReceita.Text &
                "-" & mesSistema & "/" & anoSistema & "','" & FormDespezaReceita.TextBoxValorReceita.Text & "','" & idContaTotal & "')"
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery() Then
                MsgBox("Receita salva com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub calcularRelacaoMesAnterior()
        TotalConta()

        Try
            fechar()
            abrir()

            sql = "SELECT situacao_Total, valor_Lucro_Prejuizo FROM Total_Conta WHERE id_Total = " & idContaTotal - 1
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            situacaoMesPassadoConta = reader.GetString(0)
            valorMesPassadoConta = reader.GetString(1)
        Catch ex As Exception
            Console.Write(ex.ToString)
            Console.Write(ex.Message)
        Finally
            fechar()
            calcularMesPassado()
        End Try
    End Sub

    Sub calcularMesPassado()
        If situacaoMesPassadoConta = "Lucro" Then
            If FormMenu.GroupBoxLucroOuPrejuizoRelatorio.Text = "Lucro" Then
                FormMenu.LabelRelacaoMesRelatorio.Text = FormMenu.LabelValorLucroOuPrejuízo.Text - valorMesPassadoConta
            Else
                FormMenu.LabelRelacaoMesRelatorio.Text = FormMenu.LabelValorLucroOuPrejuízo.Text + valorMesPassadoConta
            End If
        Else
            If FormMenu.GroupBoxLucroOuPrejuizoRelatorio.Text = "Lucro" Then
                FormMenu.LabelRelacaoMesRelatorio.Text = FormMenu.LabelValorLucroOuPrejuízo.Text - valorMesPassadoConta
            Else
                FormMenu.LabelRelacaoMesRelatorio.Text = FormMenu.LabelValorLucroOuPrejuízo.Text + valorMesPassadoConta
            End If
        End If
    End Sub

    Sub calcularDespesaComSalarios()
        Try
            fechar()
            abrir()

            sql = "SELECT SUM(salario_Funcionario) FROM Funcionarios WHERE vinculo_Funcionario = 1"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            somaSalarioFuncionario = reader.GetString(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub addSalarioDespesa()
        calcularDespesaComSalarios()
        TotalConta()

        Try
            fechar()
            abrir()

            sql = "INSERT INTO Despesas (Descricao, Valor, id_Total_Conta) VALUES (@desc, @valor, @idTotalConta)"
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@desc", "Salário dos Funcionários-" & mesSistema & "/" & anoSistema)
                .Parameters.AddWithValue("@valor", somaSalarioFuncionario)
                .Parameters.AddWithValue("@idTotalConta", idContaTotal)
            End With
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub buscarIdDespesa()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Despesa FROM Despesas WHERE Descricao = '" & FormDespezaReceita.TextBoxDescDespesa.Text & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            idDespesa = reader.GetString(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarIdReceita()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Receita FROM Receitas WHERE Descricao = '" & FormDespezaReceita.TextBoxDescReceita.Text & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            idReceita = reader.GetString(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub atualizarDespesas()
        Try
            fechar()
            abrir()

            sql = "UPDATE Despesas SET Descricao = '" & FormDespezaReceita.TextBoxDescDespesa.Text & "-" & mesSistema & "/" & anoSistema &"', Valor = " & FormDespezaReceita.TextBoxTextBoxValorDespesa.Text &
                " WHERE id_Despesa = " & idDespesa
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Despesa atualizada com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub atualizarReceitas()
        Try
            fechar()
            abrir()

            sql = "UPDATE Receitas SET Descricao = '" & FormDespezaReceita.TextBoxDescReceita.Text & "-" & mesSistema & "/" & anoSistema & "', Valor = " & FormDespezaReceita.TextBoxValorReceita.Text &
                " WHERE id_Receita = " & idReceita
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Receita atualizada com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub
End Module