Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Module mdlClientes
    Dim nascimentoCli As Date
    Public isClienteVenda As Boolean = False
    Sub salvarCliente()
        Try
            fechar()
            abrir()

            nascimentoCli = FormMenu.MaskedTextBoxNascimentoCli.Text

            sql = "INSERT INTO Clientes (nome_Cliente, cpf_Cliente, rg_Cliente, celular1_Cliente, celular2_Cliente, telefone1_Cliente, telefone2_Cliente, email_Cliente, data_Cadastro_Cliente, Data_Nascimento_Cliente, cep_Cliente, logradouro_Cliente, cidade_Cliente, estado_Cliente, bairro_Cliente, numero_end_Cliente, complemento_Cliente, pontos_Fidelidade_Cliente)" &
                                "VALUES (   @nome    ,     @cpf   ,    @rg    ,      @cel1      ,      @cel2      ,      @tel1       ,       @tel2      ,      @email  ,       @cadastro      ,   @nascimento          ,     @cep   ,     @logradouro   ,    @cidade    ,     @estado   ,    @bairro    ,     @numero       ,      @complemento  ,     @pontos              )"

            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@nome", FormMenu.TextBoxNomeCLI.Text)
                .Parameters.AddWithValue("@cpf", FormMenu.MaskedTextBoxCPFCli.Text)
                .Parameters.AddWithValue("@rg", FormMenu.MaskedTextBoxRGCli.Text)
                .Parameters.AddWithValue("@cel1", FormMenu.MaskedTextBoxCEL1Cli.Text)
                .Parameters.AddWithValue("@cel2", FormMenu.MaskedTextBoxCEL2Cli.Text)
                .Parameters.AddWithValue("@tel1", FormMenu.MaskedTextBoxTEL1Cli.Text)
                .Parameters.AddWithValue("@tel2", FormMenu.MaskedTextBoxTEL2Cli.Text)
                .Parameters.AddWithValue("@email", FormMenu.TextBoxEMAILCLI.Text)
                .Parameters.AddWithValue("@cadastro", DateTime.Now)
                .Parameters.AddWithValue("@nascimento", nascimentoCli.ToString("yyyy-MM-dd"))
                .Parameters.AddWithValue("@cep", FormMenu.MaskedTextBoxCEPCLI.Text)
                .Parameters.AddWithValue("@logradouro", FormMenu.TextBoxLogradouroCLI.Text)
                .Parameters.AddWithValue("@cidade", FormMenu.TextBoxCidadeCLi.Text)
                .Parameters.AddWithValue("@estado", FormMenu.TextBoxUfCli.Text)
                .Parameters.AddWithValue("@bairro", FormMenu.TextBoxBairroCli.Text)
                .Parameters.AddWithValue("@numero", FormMenu.TextBoxNumCli.Text)
                .Parameters.AddWithValue("@complemento", FormMenu.TextBoxComplementoCli.Text)
                .Parameters.AddWithValue("@pontos", 0)
            End With

            If cmdUser.ExecuteNonQuery Then
                MsgBox("Cliente salvo com sucesso!")
            End If

        Catch ex As Exception
            MsgBox("Erro ao salvar o cliente.")
            MsgBox(ex.ToString())
        Finally
            fechar()
            isNotEditableCliente()
        End Try
    End Sub

    Sub validarCpfCli()
        Dim cpf As New Valida_CPF_CNPJ
        cpf.cpf = FormMenu.MaskedTextBoxCPFCli.Text

        If cpf.isCpfValido = False Then
            MsgBox("CPF inválido")
            FormMenu.MaskedTextBoxCPFCli.Text = ""
        End If
    End Sub

    Sub buscarCepCli()
        Try
            Dim WS = New WSCorreios.AtendeClienteClient
            Dim Resposta = WS.consultaCEP(FormMenu.MaskedTextBoxCEPCLI.Text)
            FormMenu.TextBoxLogradouroCLI.Text = Resposta.end
            FormMenu.TextBoxComplementoCli.Text = Resposta.complemento2
            FormMenu.TextBoxBairroCli.Text = Resposta.bairro
            FormMenu.TextBoxCidadeCLi.Text = Resposta.cidade
            FormMenu.TextBoxUfCli.Text = Resposta.uf
        Catch ex As Exception
            MessageBox.Show("Erro ao procurar CEP")
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub addPontosCli(cpfCliente As String, pontos As Integer)
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET pontos_Fidelidade_Cliente = @field1 WHERE cpf_Cliente = '" & cpfCliente & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.Parameters.AddWithValue("@field1", pontos)
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao adicionar pontos para o cliente.")
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub setUltimaCompraCLi(cpfCliente As String)
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET ultima_Compra_Cliente = @field1 WHERE cpf_Cliente = '" & cpfCliente & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.Parameters.AddWithValue("@field1", DateTime.Now)
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao alterar a data de última compra do cliente.")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarUltimoIdCli()
        Try
            fechar()
            abrir()

            sql = "SELECT MAX(id_Cliente) FROM Clientes"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            Dim maxId As String = reader.GetString(0)

            FormMenu.TextBoxIdCLI.Text = maxId + 1

        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarClientePorNome()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT cpf_Cliente, nome_Cliente FROM Clientes WHERE nome_Cliente LIKE '%" & FormPesquisa.pesquisaNomeCliente.Text & "%'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DGClientes.DataSource = dados

            ajustarDGClientes()
        Catch ex As Exception
            MsgBox("Erro ao buscar cliente.")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarClientePorCPF()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT cpf_Cliente, nome_Cliente FROM Clientes WHERE cpf_Cliente LIKE '%" & FormPesquisa.pesquisaCpfCliente.Text & "'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DGClientes.DataSource = dados

            ajustarDGClientes()
        Catch ex As Exception
            MsgBox("Erro ao buscar cliente.")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarTodosClientes()
        Try
            abrir()
            fechar()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT cpf_Cliente, nome_Cliente FROM Clientes"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DGClientes.DataSource = dados

            ajustarDGClientes()
        Catch ex As Exception
            MsgBox("Erro ao pesquisar todos os clientes.")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub ajustarDGClientes()
        With FormPesquisa.DGClientes
            .Sort(FormPesquisa.DGClientes.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "CPF"
            .Columns(0).Width = 150
            .Columns(1).HeaderText = "Nome"
            .Columns(1).Width = 370
        End With
    End Sub

    Sub limparCli()
        FormMenu.TextBoxIdCLI.Text = ""
        FormMenu.TextBoxNomeCLI.Text = ""
        FormMenu.MaskedTextBoxCPFCli.Text = ""
        FormMenu.MaskedTextBoxRGCli.Text = ""
        FormMenu.MaskedTextBoxNascimentoCli.Text = ""
        FormMenu.MaskedTextBoxCEL1Cli.Text = ""
        FormMenu.MaskedTextBoxCEL2Cli.Text = ""
        FormMenu.MaskedTextBoxTEL1Cli.Text = ""
        FormMenu.MaskedTextBoxTEL2Cli.Text = ""
        FormMenu.TextBoxEMAILCLI.Text = ""
        FormMenu.MaskedTextBoxCEPCLI.Text = ""
        FormMenu.TextBoxLogradouroCLI.Text = ""
        FormMenu.TextBoxCidadeCLi.Text = ""
        FormMenu.TextBoxUfCli.Text = ""
        FormMenu.TextBoxBairroCli.Text = ""
        FormMenu.TextBoxComplementoCli.Text = ""
        FormMenu.TextBoxNumCli.Text = ""
        FormMenu.LabelDataCadastroCli.Text = ""
        FormMenu.LabelUltimaCompraCli.Text = ""
        FormMenu.LabelPtsCLi.Text = ""
    End Sub

    ''' <summary>
    ''' 
    ''' 
    '''                                       Editar clientes
    '''                                                       
    ''' 
    ''' </summary>

    Sub editarCliente()
        editarnomeCli()
        editarcpfCli()
        editarRgCli()
        editarcel1Cli()
        editarcel2Cli()
        editartel1Cli()
        editartel2Cli()
        editaremailCli()
        editarNascimentoCli()
        editarCepCli()
        editarLogradouroCli()
        editarCidadeCli()
        editarEstadoCli()
        editarBairroCli()
        editarNumeroCli()
        editarComplementoCli()
        MsgBox("Cliente editado com sucesso.")
        isNotEditableCliente()
    End Sub

    Sub editarnomeCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET nome_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxNomeCLI.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o nome do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarcpfCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET cpf_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.MaskedTextBoxCPFCli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o cpf do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarRgCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET rg_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.MaskedTextBoxRGCli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o rg do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarcel1Cli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET celular1_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.MaskedTextBoxCEL1Cli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o celular 1 do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarcel2Cli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET celular2_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.MaskedTextBoxCEL2Cli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o celular 2 do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editartel1Cli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET telefone1_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.MaskedTextBoxTEL1Cli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o telefone 1 do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editartel2Cli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET telefone2_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.MaskedTextBoxTEL2Cli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o telefone 2 do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editaremailCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET email_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxEMAILCLI.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o email do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarNascimentoCli()
        Try
            fechar()
            abrir()

            nascimentoCli = FormMenu.MaskedTextBoxNascimentoCli.Text

            sql = "UPDATE Clientes SET Data_Nascimento_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", nascimentoCli.ToString("yyyy-MM-dd"))
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar a data de nascimento do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarCepCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET cep_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.MaskedTextBoxCEPCLI.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o cep do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarLogradouroCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET logradouro_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxLogradouroCLI.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o logradouro do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarCidadeCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET cidade_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxCidadeCLi.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar a cidade do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarEstadoCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET estado_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxUfCli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar a uf do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarBairroCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET bairro_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxBairroCli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o bairro do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarNumeroCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET numero_end_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxNumCli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o numero do endereço do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarComplementoCli()
        Try
            fechar()
            abrir()

            sql = "UPDATE Clientes SET complemento_Cliente = @field1 WHERE id_Cliente = " & FormMenu.TextBoxIdCLI.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxComplementoCli.Text)
            End With
            cmdUser.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar o complemento do endereço do cliente")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub


    Sub carregarClientes()
        Dim cpfPesquisa As String
        isNotEditableCliente()
        cpfPesquisa = FormPesquisa.DGClientes.CurrentRow.Cells(0).Value.ToString
        FormMenu.MaskedTextBoxCPFCli.Text = cpfPesquisa

        Try
            fechar()
            abrir()

            sql = "SELECT * FROM Clientes WHERE cpf_Cliente = '" & cpfPesquisa & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            FormMenu.TextBoxIdCLI.Text = reader.GetString(0)
            FormMenu.TextBoxNomeCLI.Text = reader.GetString(1)
            FormMenu.MaskedTextBoxRGCli.Text = reader.GetString(3)
            FormMenu.MaskedTextBoxCEL1Cli.Text = reader.GetString(4)
            FormMenu.MaskedTextBoxCEL2Cli.Text = reader.GetString(5)
            FormMenu.MaskedTextBoxTEL1Cli.Text = reader.GetString(6)
            FormMenu.MaskedTextBoxTEL2Cli.Text = reader.GetString(7)
            FormMenu.TextBoxEMAILCLI.Text = reader.GetString(8)
            FormMenu.LabelDataCadastroCli.Text = reader.GetString(9)
            FormMenu.MaskedTextBoxNascimentoCli.Text = reader.GetString(10)
            FormMenu.LabelUltimaCompraCli.Text = reader.GetString(11)
            FormMenu.LabelPtsCLi.Text = reader.GetString(12)
            FormMenu.MaskedTextBoxCEPCLI.Text = reader.GetString(13)
            FormMenu.TextBoxLogradouroCLI.Text = reader.GetString(14)
            FormMenu.TextBoxCidadeCLi.Text = reader.GetString(15)
            FormMenu.TextBoxUfCli.Text = reader.GetString(16)
            FormMenu.TextBoxBairroCli.Text = reader.GetString(17)
            FormMenu.TextBoxNumCli.Text = reader.GetString(18)
            FormMenu.TextBoxComplementoCli.Text = reader.GetString(19)

        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
        End Try


    End Sub

End Module