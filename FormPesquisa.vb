Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FormPesquisa
    Public cpfPesquisa As String
    Public fotoFuncionario As Bitmap

    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        If labelNomePesquisa.Text = "Funcionários" Then
            GroupBoxFuncionarios.Visible = False
        ElseIf labelNomePesquisa.Text = "Clientes" Then
            GroupBoxClientes.Visible = False
            isClienteVenda = False
        ElseIf labelNomePesquisa.Text = "Fornecedor" Then
            GroupBoxPesquisaFornecedorAddProd.Visible = False
            isFornecedor = False
        ElseIf labelNomePesquisa.Text = "Produto" Then
            GroupBoxProduto.Visible = False
        End If
        Me.Close()
    End Sub

    Sub ajustarDGFuncionario()
        With DGFuncionarios
            .Sort(DGFuncionarios.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "CPF"
            .Columns(0).Width = 150
            .Columns(1).HeaderText = "Nome"
            .Columns(1).Width = 370
        End With
    End Sub

    Private Sub DGFuncionarios_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGFuncionarios.CellMouseClick
        limparFuncionario()
        isNotEditavel()
        cpfPesquisa = DGFuncionarios.CurrentRow.Cells(0).Value.ToString()
        FormMenu.MaskedTextBoxCPFFunc.Text = cpfPesquisa

        carregarFuncionario()
        carregarVinculo()
        carregarFoto()

        Me.Close()
    End Sub

    Sub carregarFuncionario()
        Try
            fechar()
            abrir()

            sql = "SELECT * FROM Funcionarios WHERE cpf_Funcionario = '" & cpfPesquisa & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.TextBoxIdFunc.Text = reader.GetString(0)
            FormMenu.TextBoxNomeFunc.Text = reader.GetString(1)
            FormMenu.TextBoxApelidoFunc.Text = reader.GetString(2)
            FormMenu.MaskedTextBoxRGFunc.Text = reader.GetString(4)
            FormMenu.MaskedTextBoxNascimentoFunc.Text = reader.GetString(5)
            FormMenu.MaskedTextBoxCEL1Func.Text = reader.GetString(6)
            FormMenu.MaskedTextBoxCEL2Func.Text = reader.GetString(7)
            FormMenu.MaskedTextBoxTEL1Func.Text = reader.GetString(8)
            FormMenu.MaskedTextBoxTEL2Func.Text = reader.GetString(9)
            FormMenu.TextBoxVendasFunc.Text = reader.GetString(10)
            FormMenu.TextBoxEMAILFunc.Text = reader.GetString(12)
            FormMenu.TextBoxLoginFunc.Text = reader.GetString(13)
            FormMenu.TextBoxSenhaFunc.Text = reader.GetString(14)
            FormMenu.ComboBoxCargoFunc.Text = reader.GetString(15)
            FormMenu.MaskedTextBoxCEPFunc.Text = reader.GetString(16)
            FormMenu.TextBoxLogradouroFunc.Text = reader.GetString(17)
            FormMenu.TextBoxUFFunc.Text = reader.GetString(18)
            FormMenu.TextBoxCidadeFunc.Text = reader.GetString(19)
            FormMenu.TextBoxBairroFunc.Text = reader.GetString(20)
            FormMenu.TextBoxNUmENDFunc.Text = reader.GetString(21)
            FormMenu.TextBoxCompleFunc.Text = reader.GetString(22)
            FormMenu.TextBoxSalarioFunc.Text = reader.GetString(23)
            FormMenu.ComboBoxBancoFunc.Text = reader.GetString(24)
            FormMenu.TextBoxAgenciaFunc.Text = reader.GetString(25)
            FormMenu.TextBoxContaBancoFunc.Text = reader.GetString(26)
            FormMenu.TextBoxComissaoFunc.Text = reader.GetString(27)
            FormMenu.TextBoxOperacaoBancoFunc.Text = reader.GetString(28)

        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub carregarFoto()
        Try
            fechar()
            abrir()
            sql = "SELECT foto_Funcionario FROM Funcionarios WHERE cpf_Funcionario = '" & cpfPesquisa & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            Dim blob As Byte() = DirectCast(reader.Item("foto_Funcionario"), Byte())
            Using ms = New MemoryStream(blob)
                fotoFuncionario = New Bitmap(ms)
            End Using

            FormMenu.PictureBoxFunc.Image = fotoFuncionario

        Catch ex As MySqlException
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub carregarVinculo()
        Try
            fechar()
            abrir()

            sql = "SELECT vinculo_Funcionario FROM Funcionarios WHERE cpf_Funcionario = '" & cpfPesquisa & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            Dim vinculo As String = reader.GetString(0)

            If vinculo = "1" Then
                FormMenu.LabelvinculoFuncionario.Text = "Vinculado"
                FormMenu.LabelvinculoFuncionario.ForeColor = Color.Green
            Else
                FormMenu.LabelvinculoFuncionario.Text = "Desvinculado"
                FormMenu.LabelvinculoFuncionario.ForeColor = Color.Red
            End If

        Catch ex As Exception
            ex.ToString()
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub pesquisarTodos()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "Select cpf_Funcionario, nome_Funcionario FROM Funcionarios "
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            DGFuncionarios.DataSource = dados
            ajustarDGFuncionario()
        Catch ex As Exception
            ex.ToString()
            MsgBox("Ops, ocorreu um erro inesperado!")
        Finally
            fechar()
        End Try
    End Sub

    Private Sub PesquisarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesquisarTodosToolStripMenuItem.Click
        If labelNomePesquisa.Text = "Funcionários" Then
            pesquisarTodos()
        ElseIf LabelNomeFornPesquisa.Text = "Clientes" Then
            buscarTodosClientes()
        ElseIf labelNomePesquisa.Text = "Fornecedor" Then
            buscarTodosForn()
        Else
            buscarTodosProd()
        End If

    End Sub

    Private Sub PesquisaNomeFuncionario_TextChanged(sender As Object, e As EventArgs) Handles pesquisaNomeFuncionario.TextChanged
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String
            If pesquisaNomeFuncionario.Text <> "" Then
                sql = "SELECT cpf_Funcionario, nome_Funcionario FROM Funcionarios WHERE nome_Funcionario LIKE '%" & pesquisaNomeFuncionario.Text & "%'"
                adaptador = New MySqlDataAdapter(sql, conexao)
                adaptador.Fill(dados)
                DGFuncionarios.DataSource = dados

                ajustarDGFuncionario()
            Else

            End If

        Catch ex1 As Exception
            ex1.ToString()
            MsgBox("Ocorreu um erro inesperado durante a pesquisa de funcionários!
Por favor tente novamente, ou entre em contato com o suporte.")
        Finally
            fechar()
        End Try
    End Sub

    Private Sub PesquisaCPFfuncionario_TextChanged(sender As Object, e As EventArgs) Handles pesquisaCPFfuncionario.TextChanged
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            If pesquisaCPFfuncionario.Text <> "   .   .   -" Then
                sql = "Select cpf_Funcionario, nome_Funcionario FROM Funcionarios WHERE cpf_Funcionario LIKE '%" & pesquisaCPFfuncionario.Text & "'"
                adaptador = New MySqlDataAdapter(sql, conexao)
                adaptador.Fill(dados)
                DGFuncionarios.DataSource = dados

                ajustarDGFuncionario()
            End If

        Catch ex1 As Exception
            ex1.ToString()
            MsgBox("Ocorreu um erro inesperado durante a pesquisa de funcionários!
Por favor tente novamente, ou entre em contato com o suporte.")
        Finally
            fechar()
        End Try
    End Sub

    Private Sub PesquisaNomeCliente_TextChanged(sender As Object, e As EventArgs) Handles pesquisaNomeCliente.TextChanged
        If pesquisaNomeCliente.Text <> "" Then
            buscarClientePorNome()
        End If
    End Sub

    Private Sub PesquisaCpfCliente_TextChanged(sender As Object, e As EventArgs) Handles pesquisaCpfCliente.TextChanged
        If pesquisaCpfCliente.Text <> "   .   .   -" Then
            buscarClientePorCPF()
        End If
    End Sub

    Private Sub TextBoxNomeFornPesquisa_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNomeFornPesquisa.TextChanged
        If TextBoxNomeFornPesquisa.Text <> "" Then
            buscarFornPorNome()
        End If
    End Sub

    Private Sub DataGridViewFornPesquisa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewFornPesquisa.CellClick
        If isFornecedor Then
            carregarFornecedor()
        Else
            FormMenu.TextBoxFornProd.Text = DataGridViewFornPesquisa.CurrentRow.Cells(1).Value.ToString
            Me.Close()
        End If

    End Sub

    Private Sub PesquisaNomeProd_TextChanged(sender As Object, e As EventArgs) Handles pesquisaNomeProd.TextChanged
        If pesquisaNomeProd.Text <> "" Then
            buscarPorNomeProd()
        End If
    End Sub

    Private Sub PesquisaMarcaProd_TextChanged(sender As Object, e As EventArgs) Handles pesquisaMarcaProd.TextChanged
        If pesquisaMarcaProd.Text <> "" Then
            buscarPorMarca()
        End If
    End Sub

    Private Sub PesquisaFornProd_TextChanged(sender As Object, e As EventArgs) Handles pesquisaFornProd.TextChanged
        If pesquisaFornProd.Text <> "" Then
            buscarPorFornecedor()
        End If
    End Sub

    Private Sub DataGridViewProduto_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewProduto.CellMouseClick
        If vendaAtiva Then
            FormMenu.AdicionarNoCarrinhoToolStripMenuItem.Visible = True
            FormMenu.AdicionarNoCarrinhoToolStripMenuItem.Enabled = True

            carregarProduto()
            carregarFotoProd()
            carregarSubCategroia()

            FormMenu.EditarToolStripMenuItemFornecedor.Enabled = False
            Me.Close()
        Else
            FormMenu.AdicionarNoCarrinhoToolStripMenuItem.Visible = False
            FormMenu.AdicionarNoCarrinhoToolStripMenuItem.Enabled = False

            carregarProduto()
            carregarFotoProd()
            carregarSubCategroia()
            Me.Close()
        End If
    End Sub

    Private Sub DGClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGClientes.CellClick
        If isClienteVenda Then
            buscarClienteVenda()
        Else
            carregarClientes()
        End If
        Me.Close()
    End Sub

End Class