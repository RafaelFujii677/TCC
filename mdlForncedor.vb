Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Module mdlForncedor
    Public isFornecedor As Boolean = False
    Dim cnpjPesquisa As String
    Public editandoForn As Boolean = False

    Sub isEditableForn()
        FormMenu.TextBoxNomeForne.Enabled = True
        FormMenu.MaskedTextBoxCNPJForne.Enabled = True
        FormMenu.MaskedTextBoxTEL1Forn.Enabled = True
        FormMenu.MaskedTextBoxTEL2Forn.Enabled = True
        FormMenu.MaskedTextBoxCEPForn.Enabled = True
        FormMenu.TextBoxLogradouroForn.Enabled = True
        FormMenu.TextBoxUfForn.Enabled = True
        FormMenu.TextBoxCidadeForn.Enabled = True
        FormMenu.TextBoxBairroForn.Enabled = True
        FormMenu.TextBoxNumForn.Enabled = True
        FormMenu.TextBoxCompleForn.Enabled = True
        FormMenu.ComboBoxBancoForn.Enabled = True
        FormMenu.TextBoxContaForn.Enabled = True
        FormMenu.TextBoxAgenciaForn.Enabled = True
        FormMenu.TextBoxOperacaoForn.Enabled = True
        FormMenu.TextBoxinformacaoForn.Enabled = True
        FormMenu.SalvarToolStripMenuItemFornecedor.Enabled = True
    End Sub

    Sub isNotEditableForn()
        FormMenu.TextBoxNomeForne.Enabled = False
        FormMenu.MaskedTextBoxCNPJForne.Enabled = False
        FormMenu.MaskedTextBoxTEL1Forn.Enabled = False
        FormMenu.MaskedTextBoxTEL2Forn.Enabled = False
        FormMenu.MaskedTextBoxCEPForn.Enabled = False
        FormMenu.TextBoxLogradouroForn.Enabled = False
        FormMenu.TextBoxUfForn.Enabled = False
        FormMenu.TextBoxCidadeForn.Enabled = False
        FormMenu.TextBoxBairroForn.Enabled = False
        FormMenu.TextBoxNumForn.Enabled = False
        FormMenu.TextBoxCompleForn.Enabled = False
        FormMenu.ComboBoxBancoForn.Enabled = False
        FormMenu.TextBoxContaForn.Enabled = False
        FormMenu.TextBoxAgenciaForn.Enabled = False
        FormMenu.TextBoxOperacaoForn.Enabled = False
        FormMenu.TextBoxinformacaoForn.Enabled = False
        FormMenu.SalvarToolStripMenuItemFornecedor.Enabled = False
        editandoForn = False
    End Sub

    Sub salvarForncedor()
        Try
            fechar()
            abrir()

            sql = "INSERT INTO Fornecedor (nome_Fornecedor, cnpj_Fornecedor, telefone1_Fornecedor, telefone2_Fornecedor, cep_Fornecedor, logradouro_Fornecedor, estado_Fornecedor, cidade_Fornecedor, bairro_Fornecedor,numero_end_Fornecedor , complemento_Fornecedor, banco_Fornecedor, conta_Fornecedor, agencia_Fornecedor, operacao_Fornecedor, informacoes_Adicionais_Fornecedor)" &
                                  "VALUES ( @nome         ,    @cnpj       ,      @tel1          ,       @tel2         ,     @cep      ,        @logradouro   ,      @uf         ,     @cidade      ,    @bairro       ,        @numero       ,    @complemento       ,         @banco  ,      @conta     ,      @agencia     ,     @operacao       ,    @informacao                   )"
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@nome", FormMenu.TextBoxNomeForne.Text)
                .Parameters.AddWithValue("@cnpj", FormMenu.MaskedTextBoxCNPJForne.Text)
                .Parameters.AddWithValue("@tel1", FormMenu.MaskedTextBoxTEL1Forn.Text)
                .Parameters.AddWithValue("@tel2", FormMenu.MaskedTextBoxTEL2Forn.Text)
                .Parameters.AddWithValue("@cep", FormMenu.MaskedTextBoxCEPForn.Text)
                .Parameters.AddWithValue("@logradouro", FormMenu.TextBoxLogradouroForn.Text)
                .Parameters.AddWithValue("@uf", FormMenu.TextBoxUfForn.Text)
                .Parameters.AddWithValue("@cidade", FormMenu.TextBoxCidadeForn.Text)
                .Parameters.AddWithValue("@bairro", FormMenu.TextBoxBairroForn.Text)
                .Parameters.AddWithValue("@numero", FormMenu.TextBoxNumForn.Text)
                .Parameters.AddWithValue("@complemento", FormMenu.TextBoxCompleForn.Text)
                .Parameters.AddWithValue("@banco", FormMenu.ComboBoxBancoForn.Text)
                .Parameters.AddWithValue("@conta", FormMenu.TextBoxContaForn.Text)
                .Parameters.AddWithValue("@agencia", FormMenu.TextBoxAgenciaForn.Text)
                .Parameters.AddWithValue("@operacao", FormMenu.TextBoxOperacaoForn.Text)
                .Parameters.AddWithValue("@informacao", FormMenu.TextBoxinformacaoForn.Text)
            End With
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Forncedor salvo com sucesso.")
            End If
        Catch ex As Exception
            ex.ToString()
            MsgBox("Ocorreu um erro ao tentar salvar o fornecedor.")
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarUltimoIdForn()
        Try
            fechar()
            abrir()

            sql = "SELECT MAX(id_Fornecedor) FROM Fornecedor"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.TextBoxIdForne.Text = reader.GetString(0) + 1
        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub limparForn()
        FormMenu.TextBoxIdForne.Clear()
        FormMenu.TextBoxNomeForne.Clear()
        FormMenu.MaskedTextBoxCNPJForne.Clear()
        FormMenu.MaskedTextBoxTEL1Forn.Clear()
        FormMenu.MaskedTextBoxTEL2Forn.Clear()
        FormMenu.MaskedTextBoxCEPForn.Clear()
        FormMenu.TextBoxLogradouroForn.Clear()
        FormMenu.TextBoxUfForn.Clear()
        FormMenu.TextBoxCidadeForn.Clear()
        FormMenu.TextBoxBairroForn.Clear()
        FormMenu.TextBoxNumForn.Clear()
        FormMenu.TextBoxCompleForn.Clear()
        FormMenu.ComboBoxBancoForn.SelectedItem = -1
        FormMenu.TextBoxContaForn.Clear()
        FormMenu.TextBoxAgenciaForn.Clear()
        FormMenu.TextBoxOperacaoForn.Clear()
        FormMenu.TextBoxinformacaoForn.Clear()
    End Sub

    Sub buscarFornPorNome()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT cnpj_Fornecedor, nome_Fornecedor From Fornecedor WHERE nome_Fornecedor LIKE '%" & FormPesquisa.TextBoxNomeFornPesquisa.Text & "%'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DataGridViewFornPesquisa.DataSource = dados
            ajeitarDGForn()
        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub buscarPorCNPJ()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT cnpj_Fornecedor, nome_Fornecedor From Fornecedor WHERE cnpj_Fornecedor LIKE '%" & FormPesquisa.MaskedTextBoxcnpjFornPesquisa.Text & "%'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DataGridViewFornPesquisa.DataSource = dados
            ajeitarDGForn()
        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub ajeitarDGForn()
        With FormPesquisa.DataGridViewFornPesquisa
            .Sort(FormPesquisa.DataGridViewFornPesquisa.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "CNPJ"
            .Columns(0).Width = 152
            .Columns(1).HeaderText = "Nome"
            .Columns(1).Width = 370
        End With
    End Sub

    Sub carregarFornecedor()
        cnpjPesquisa = FormPesquisa.DataGridViewFornPesquisa.CurrentRow.Cells(0).Value.ToString()

        Try
        fechar()
            abrir()

            FormMenu.MaskedTextBoxCNPJForne.Text = cnpjPesquisa

            sql = "SELECT * FROM Fornecedor WHERE cnpj_Fornecedor = '" & cnpjPesquisa & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            FormMenu.TextBoxIdForne.Text = reader.GetString(0)
            FormMenu.TextBoxNomeForne.Text = reader.GetString(1)
            FormMenu.MaskedTextBoxTEL1Forn.Text = reader.GetString(3)
            FormMenu.MaskedTextBoxTEL2Forn.Text = reader.GetString(4)
            FormMenu.MaskedTextBoxCEPForn.Text = reader.GetString(5)
            FormMenu.TextBoxLogradouroForn.Text = reader.GetString(6)
            FormMenu.TextBoxUfForn.Text = reader.GetString(7)
            FormMenu.TextBoxCidadeForn.Text = reader.GetString(8)
            FormMenu.TextBoxBairroForn.Text = reader.GetString(9)
            FormMenu.TextBoxNumForn.Text = reader.GetString(10)
            FormMenu.TextBoxCompleForn.Text = reader.GetString(11)
            FormMenu.ComboBoxBancoForn.Text = reader.GetString(12)
            FormMenu.TextBoxContaForn.Text = reader.GetString(13)
            FormMenu.TextBoxAgenciaForn.Text = reader.GetString(14)
            FormMenu.TextBoxOperacaoForn.Text = reader.GetString(15)
            FormMenu.TextBoxinformacaoForn.Text = reader.GetString(16)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub atualizarFornecedor()
        Try
            fechar()
            abrir()

            sql = "UPDATE Fornecedor SET nome_Fornecedor = @nome, cnpj_Fornecedor = @cnpj, telefone1_Fornecedor = @tel1, telefone2_Fornecedor = @tel2, cep_Fornecedor = @cep, " &
                "logradouro_Fornecedor = @logradouro, estado_Fornecedor = @uf, cidade_Fornecedor = @cidade, bairro_Fornecedor = @bairro, numero_end_Fornecedor = @num, complemento_Fornecedor = @complemento, " &
                "banco_Fornecedor = @banco, conta_Fornecedor= @conta, agencia_Fornecedor = @agencia, operacao_Fornecedor = @operacao, informacoes_Adicionais_Fornecedor = @info WHERE id_Fornecedor = " & FormMenu.TextBoxIdForne.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@nome", FormMenu.TextBoxNomeForne.Text)
                .Parameters.AddWithValue("@CNPJ", FormMenu.MaskedTextBoxCNPJForne.Text)
                .Parameters.AddWithValue("@tel1", FormMenu.MaskedTextBoxTEL1Forn.Text)
                .Parameters.AddWithValue("@tel2", FormMenu.MaskedTextBoxTEL2Forn.Text)
                .Parameters.AddWithValue("@cep", FormMenu.MaskedTextBoxCEPForn.Text)
                .Parameters.AddWithValue("@logradouro", FormMenu.TextBoxLogradouroForn.Text)
                .Parameters.AddWithValue("@uf", FormMenu.TextBoxUfForn.Text)
                .Parameters.AddWithValue("@cidade", FormMenu.TextBoxCidadeForn.Text)
                .Parameters.AddWithValue("@bairro", FormMenu.TextBoxBairroForn.Text)
                .Parameters.AddWithValue("@num", FormMenu.TextBoxNumForn.Text)
                .Parameters.AddWithValue("@complemento", FormMenu.TextBoxCompleForn.Text)
                .Parameters.AddWithValue("@banco", FormMenu.ComboBoxBancoForn.Text)
                .Parameters.AddWithValue("@conta", FormMenu.TextBoxContaForn.Text)
                .Parameters.AddWithValue("@agencia", FormMenu.TextBoxAgenciaForn.Text)
                .Parameters.AddWithValue("@operacao", FormMenu.TextBoxOperacaoForn.Text)
                .Parameters.AddWithValue("@info", FormMenu.TextBoxinformacaoForn.Text)
            End With

            If cmdUser.ExecuteNonQuery Then
                MsgBox("Fornecedor editado com sucesso.")
            End If

        Catch ex As Exception
            MsgBox("Erro ao editar o fornecedor.")
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarTodosForn()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT cnpj_Fornecedor, nome_Fornecedor FROM Fornecedor"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)

            FormPesquisa.DataGridViewFornPesquisa.DataSource = dados

            ajeitarDGForn()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            fechar()
        End Try
    End Sub

End Module
