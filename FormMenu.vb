Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class FormMenu
    Dim HeightGroupBox, WidthGrupoBox, WidthForm, HeightForm As Integer
    Public ImagemFunc As Image
    Public editando As Boolean
    Public temFoto As Boolean = False

    Private Sub BTNcliente_Click(sender As Object, e As EventArgs) Handles BTNcliente.Click
        selectPanel(PanelClientes, GroupBoxClientes)

        PanelSelect.Location = New Point(0, 230)
        PanelSelect.Visible = True

        desabilitarMenus()
        habilitarMenuClientes()
    End Sub

    Private Sub BTNprodutos_Click(sender As Object, e As EventArgs) Handles BTNprodutos.Click
        selectPanel(PanelProdutos, GroupBoxProdutos)

        PanelSelect.Location = New Point(0, 289)
        PanelSelect.Visible = True

        desabilitarMenus()
        habilitarMenuProdutos()
    End Sub

    Private Sub BTNusuarios_Click(sender As Object, e As EventArgs) Handles BTNusuarios.Click
        selectPanel(PanelFuncionarios, GroupBoxFuncionarios)

        PanelSelect.Location = New Point(0, 348)
        PanelSelect.Visible = True

        desabilitarMenus()
        habilitarMenuFuncionarios()
    End Sub

    Private Sub BTNfornecedores_Click(sender As Object, e As EventArgs) Handles BTNfornecedores.Click
        selectPanel(PanelFornecedores, GroupBoxFornecedores)

        PanelSelect.Location = New Point(0, 407)
        PanelSelect.Visible = True

        desabilitarMenus()
        habilitarMenuFornecedores()
    End Sub

    Private Sub ButtonAddImagem_Click(sender As Object, e As EventArgs) Handles ButtonAddImagem.Click
        pegarFotoDoPC()
    End Sub

    Private Sub BTNrelatorios_Click(sender As Object, e As EventArgs) Handles BTNrelatorios.Click
        selectPanel(PanelRelatorio, GroupBoxRelatorios)

        PanelSelect.Location = New Point(0, 466)
        PanelSelect.Visible = True
    End Sub

    Private Sub BTNcarrinho_Click(sender As Object, e As EventArgs) Handles BTNcarrinho.Click
        selectPanel(PanelCarrinho, GroupBoxCarrinho)
        If FormLogin.carrinhoUp Then
            PanelSelect.Location = New Point(0, 348)
            PanelSelect.Visible = True
        Else
            PanelSelect.Location = New Point(0, 525)
            PanelSelect.Visible = True
        End If
    End Sub

    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        If MessageBox.Show("Deseja realmente sair?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.Yes Then
            Me.Close()
            FormLogin.Refresh()
            FormLogin.Visible = True
        End If
    End Sub

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tela As Screen = Screen.FromPoint(Me.Location)
        Me.Size = tela.WorkingArea.Size
        Me.Location = Point.Empty

        HeightForm = Me.Size.Height
        WidthForm = Me.Size.Width

        HeightGroupBox = HeightForm - 76
        WidthGrupoBox = WidthForm - 275
        FormLogin.Visible = False
        setFalseVisiblePanel()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        setFalseVisiblePanel()
        MenuStripFuncionarios.Visible = False
        MenuStripFuncionarios.Enabled = False
        desabilitarMenus()
    End Sub

    Private Sub NovoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovoToolStripMenuItem.Click
        limparFuncionario()
        buscarUltimoID()
        isEditavel()
    End Sub

    Private Sub SalvarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItem.Click
        Try

            If editando = False Then
                If validarSalvamento() = True Then
                    salvarFuncionario()
                Else
                    isEditavel()
                End If

            Else
                If validarSalvamento() = True Then
                    editarFuncionario()
                    editarFoto()
                Else
                    isEditavel()
                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao salvar o funcionário.")
            MsgBox(ex.ToString)
        End Try


        isNotEditavel()
    End Sub

    Private Sub MaskedTextBoxCPFFunc_Leave(sender As Object, e As EventArgs) Handles MaskedTextBoxCPFFunc.Leave
        Dim cpf As New Valida_CPF_CNPJ
        cpf.cpf = MaskedTextBoxCPFFunc.Text

        If cpf.isCpfValido = False Then
            MsgBox("CPF inválido")
            MaskedTextBoxCPFFunc.Text = ""
        End If
    End Sub

    Private Sub TextBoxSalarioFunc_leave(sender As Object, e As EventArgs) Handles TextBoxSalarioFunc.Leave
        Dim verificar As String = "^[a-zA-Z]"
        If (Regex.IsMatch(TextBoxSalarioFunc.Text, verificar)) Then
            TextBoxSalarioFunc.Text = ""
        End If
    End Sub

    Private Sub TextBoxVendasFunc_Leave(sender As Object, e As EventArgs) Handles TextBoxVendasFunc.Leave
        Dim verificar As String = "^[a-zA-Z]"
        If (Regex.IsMatch(TextBoxVendasFunc.Text, verificar)) Then
            TextBoxVendasFunc.Text = ""
        End If
    End Sub

    Private Sub TextBoxComissaoFunc_Leave(sender As Object, e As EventArgs) Handles TextBoxComissaoFunc.Leave
        Dim verificar As String = "^[a-zA-Z]"
        If (Regex.IsMatch(TextBoxComissaoFunc.Text, verificar)) Then
            TextBoxComissaoFunc.Text = ""
        End If
    End Sub

    Private Sub PorIdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorIdToolStripMenuItem.Click
        FormPesquisa.Show()
        FormPesquisa.labelNomePesquisa.Text = "Funcionários"
        FormPesquisa.GroupBoxFuncionarios.Visible = True
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        If TextBoxIdFunc.Text = "" Then
            MsgBox("Não há registro para editar")
        Else
            isEditavel()
            editando = True
            temFoto = True
        End If
    End Sub

    Private Sub DesvincularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesvincularToolStripMenuItem.Click
        If DesvincularToolStripMenuItem.Text = "Desvincular" Then
            desvincular()
            registrarSaida()
            MsgBox("Funcionário desvinculado com sucesso!")
        Else
            vincular()
            registrarEntrada()
            MsgBox("Funcionário vinculado!")
        End If

        FormPesquisa.cpfPesquisa = MaskedTextBoxCPFFunc.Text
        FormPesquisa.carregarVinculo()
    End Sub

    Private Sub PesquisarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesquisarToolStripMenuItem.Click
        If LabelvinculoFuncionario.Text = "Desvinculado" Then
            DesvincularToolStripMenuItem.Text = "Vincular"
        Else
            DesvincularToolStripMenuItem.Text = "Desvincular"
        End If
    End Sub

    Private Sub SalvarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItem1.Click
        If editando = False Then
            salvarCliente()
        Else
            editarCliente()
        End If

    End Sub

    Private Sub EditarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItemCli.Click
        If TextBoxIdCLI.Text = "" Then
            MsgBox("Não há registro para ser editado.")
        Else
            isEditableCliente()
            editando = True
        End If
    End Sub

    Private Sub MaskedTextBoxCPFCli_Leave(sender As Object, e As EventArgs) Handles MaskedTextBoxCPFCli.Leave
        validarCpfCli()
    End Sub

    Private Sub MaskedTextBoxCEPCLI_Leave(sender As Object, e As EventArgs) Handles MaskedTextBoxCEPCLI.Leave
        buscarCepCli()
    End Sub

    Private Sub NovoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NovoToolStripMenuItemCliente.Click
        limparCli()
        buscarUltimoIdCli()
        isEditableCliente()
        editando = False
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        FormPesquisa.labelNomePesquisa.Text = "Clientes"
        FormPesquisa.GroupBoxClientes.Visible = True
        FormPesquisa.Show()
        isClienteVenda = False
    End Sub

    Private Sub MaskedTextBoxCEPFunc_Leave(sender As Object, e As EventArgs) Handles MaskedTextBoxCEPFunc.Leave
        Try
            Dim WS = New WSCorreios.AtendeClienteClient
            Dim Resposta = WS.consultaCEP(MaskedTextBoxCEPFunc.Text)
            TextBoxLogradouroFunc.Text = Resposta.end
            TextBoxCompleFunc.Text = Resposta.complemento2
            TextBoxBairroFunc.Text = Resposta.bairro
            TextBoxCidadeFunc.Text = Resposta.cidade
            TextBoxUFFunc.Text = Resposta.uf
        Catch ex As Exception
            MessageBox.Show("Erro ao procurar CEP")
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        FormCategorias.LabelCategoria.Text = "Categoria"
        FormCategorias.Show()
    End Sub

    Private Sub SubcategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubcategoriasToolStripMenuItem.Click
        FormCategorias.LabelCategoria.Text = "Subcategoria"
        FormCategorias.Show()
    End Sub

    Private Sub ComboBoxCategoriaProd_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxCategoriaProd.TextChanged
        If ComboBoxCategoriaProd.Text <> "" Then
            pesquisarSubCategorias(ComboBoxCategoriaProd.Text)
        End If

    End Sub

    Private Sub ButtonAddImageProd_Click(sender As Object, e As EventArgs) Handles ButtonAddImageProd.Click
        pegarFotoDoPCProduto()
    End Sub

    Private Sub SalvarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItemProduto.Click
        If editandoProd Then
            atualizarProd()
            If temFotoProd Then

            Else
                atualizarFotoProd()
            End If
        Else
            salvarProduto()
        End If
        isNotEditableProd()
    End Sub

    Private Sub EdiitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EdiitarToolStripMenuItemProduto.Click
        If TextBoxIdProd.Text <> "" Then
            isEditableProd()
            editandoProd = True
        Else
            MsgBox("Não há dados para serem editados")
        End If
    End Sub

    Private Sub NovoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NovoToolStripMenuItemProduto.Click
        limparProd()
        isEditableProd()
        buscarUltimoIdProd()
        temFotoProd = False
    End Sub

    Private Sub SalvarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItemFornecedor.Click
        If editandoForn Then
            atualizarFornecedor()
        Else
            salvarForncedor()
        End If
        isNotEditableForn()
    End Sub

    Private Sub NovoToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles NovoToolStripMenuItemFornecedor.Click
        limparForn()
        buscarUltimoIdForn()
        isEditableForn()
    End Sub

    Private Sub EditarToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles EditarToolStripMenuItemFornecedor.Click
        If TextBoxIdForne.Text <> "" Then
            isEditableForn()
            editandoForn = True
        Else
            MsgBox("Não há dados para serem editados.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonAddFornProd.Click
        FormPesquisa.Show()
        FormPesquisa.labelNomePesquisa.Text = "Fornecedor"
        FormPesquisa.GroupBoxPesquisaFornecedorAddProd.Visible = True
    End Sub

    Private Sub PordutosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PordutosToolStripMenuItem.Click
        FormPesquisa.Show()
        FormPesquisa.labelNomePesquisa.Text = "Produto"
        FormPesquisa.GroupBoxProduto.Visible = True
    End Sub

    Private Sub FornecedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FornecedorToolStripMenuItem.Click
        isFornecedor = True
        FormPesquisa.Show()
        FormPesquisa.labelNomePesquisa.Text = "Fornecedor"
        FormPesquisa.GroupBoxPesquisaFornecedorAddProd.Visible = True
    End Sub

    Private Sub MaskedTextBoxCEPForn_Leave(sender As Object, e As EventArgs) Handles MaskedTextBoxCEPForn.Leave
        Try
            Dim WS = New WSCorreios.AtendeClienteClient
            Dim Resposta = WS.consultaCEP(MaskedTextBoxCEPForn.Text)
            TextBoxLogradouroForn.Text = Resposta.end
            TextBoxCompleForn.Text = Resposta.complemento2
            TextBoxBairroForn.Text = Resposta.bairro
            TextBoxCidadeForn.Text = Resposta.cidade
            TextBoxUfForn.Text = Resposta.uf
        Catch ex As Exception
            MessageBox.Show("Erro ao procurar CEP")
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub IniciarVendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IniciarVendaToolStripMenuItem.Click
        carregarDescFormaPagamento()
        isEditableVenda()
        buscarUltimoIdVenda()
        CancelarVendaToolStripMenuItem.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        isClienteVenda = True
        FormPesquisa.labelNomePesquisa.Text = "Clientes"
        FormPesquisa.GroupBoxClientes.Visible = True
        FormPesquisa.Show()
    End Sub

    Private Sub FormasDePagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormasDePagamentoToolStripMenuItem.Click
        FormAlteracaoVenda.Label1.Text = "Forma de Pagamento"
        FormAlteracaoVenda.Show()
    End Sub

    Private Sub CheckBoxPontosVendas_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPontosVendas.CheckedChanged
        If CheckBoxPontosVendas.Checked Then
            LabelDescontoPontos.Visible = True
            LabelDescontoPontos.Text = TextBoxPontosVenda.Text & " %"
            calcularDescontoVenda()
        Else
            LabelDescontoPontos.Visible = False
        End If
    End Sub

    Private Sub DataGridViewProdutosVenda_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewProdutosVenda.CellContentClick
        If DataGridViewProdutosVenda.CurrentCell.Value.ToString = "X" Then
            atualizarEstoqueProdutoCancelado()
            excluirRProdutoVenda()
            DataGridViewProdutosVenda.Rows.RemoveAt(DataGridViewProdutosVenda.CurrentRow.Index)
        End If
    End Sub

    Private Sub DataGridViewProdutosVenda_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewProdutosVenda.RowsAdded
        calcularSubTotal()
    End Sub

    Private Sub DataGridViewProdutosVenda_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridViewProdutosVenda.RowsRemoved
        calcularSubTotal()
    End Sub

    Private Sub ComboBoxFormaPagamentoVenda_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxFormaPagamentoVenda.SelectedValueChanged
        If TextBoxSubTotalVendas.Text <> "" Then
            calcularDescontoVenda()
        End If

    End Sub

    Private Sub CancelarVendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarVendaToolStripMenuItem.Click
        CancelarVendaToolStripMenuItem.Enabled = False
        atualizarEstoqueVendasCancelada()
        excluirRProdutoVenda()
        FinalizarVendaToolStripMenuItem.Enabled = False
        limparVenda()
        isNotEditableVenda()
        AdicionarNoCarrinhoToolStripMenuItem.Visible = False
        MsgBox("Venda cancelada")
    End Sub

    Private Sub FinalizarVendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalizarVendaToolStripMenuItem.Click
        If TextBoxNomeCliVendas.Text <> "" And TextBoxTotalVendas.Text <> "" Then
            finalizarVenda()
            FinalizarVendaToolStripMenuItem.Enabled = False
            CancelarVendaToolStripMenuItem.Enabled = False
            buscarComissaoFuncionarioVenda()
            addVendaFunc()
            addVendaReceita()
            addComissaoDespesas()
            buscarDataVenda()
            setUltimaCompraCLi(MaskedTextBoxCpfOuRgCliVendas.Text)
            pontos = TextBoxPontosVenda.Text
            If CheckBoxPontosVendas.Checked Then
                pontos = 0
                calcularPontos(TextBoxTotalVendas.Text)
                addPontosCli(MaskedTextBoxCpfOuRgCliVendas.Text, pontos)
                TextBoxPontosVenda.Text = pontos
            Else
                calcularPontos(TextBoxTotalVendas.Text)
                addPontosCli(MaskedTextBoxCpfOuRgCliVendas.Text, pontos)
                TextBoxPontosVenda.Text = pontos
            End If

            carregarDespesas()
            carregarReceitas()
            AdicionarNoCarrinhoToolStripMenuItem.Visible = False

            limparVenda()
            isNotEditableVenda()
        Else
            MsgBox("Faltam informações para a finalização da venda")
        End If

    End Sub

    Private Sub TextBoxTotalVendas_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTotalVendas.TextChanged
        If TextBoxTotalVendas.Text <> "" And TextBoxTotalVendas.Text <> "0" Then
            FinalizarVendaToolStripMenuItem.Enabled = True
            FormPesquisa.GroupBoxClientes.Visible = True
            CheckBoxPontosVendas.Enabled = True
        End If
    End Sub

    Private Sub DataGridViewDespesas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridViewDespesas.MouseDoubleClick
        FormDespezaReceita.TextBoxDescDespesa.Text = DataGridViewDespesas.CurrentRow.Cells(0).Value.ToString
        FormDespezaReceita.TextBoxTextBoxValorDespesa.Text = DataGridViewDespesas.CurrentRow.Cells(1).Value.ToString
        buscarIdDespesa()
        FormDespezaReceita.editandoDespesa = True
        FormDespezaReceita.Show()
    End Sub

    Private Sub AdicionarReceitaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdicionarReceitaToolStripMenuItem.Click
        FormDespezaReceita.Show()
    End Sub

    Private Sub DataGridViewReceitas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridViewReceitas.MouseDoubleClick
        FormDespezaReceita.TextBoxDescReceita.Text = DataGridViewReceitas.CurrentRow.Cells(0).Value.ToString
        FormDespezaReceita.TextBoxValorReceita.Text = DataGridViewReceitas.CurrentRow.Cells(1).Value.ToString
        buscarIdReceita()
        FormDespezaReceita.editandoReceita = True
        FormDespezaReceita.Show()
    End Sub

    Private Sub AdicionarNoCarrinhoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AdicionarNoCarrinhoToolStripMenuItem.Click
        quantidadeProdVenda.Show()
    End Sub

    ''' <summary>
    '''                      
    ''' 
    '''                               SUBS
    ''' 
    ''' 
    ''' 
    ''' </summary>

    Sub setFalseVisiblePanel()
        PanelSelect.Visible = False
        PanelClientes.Visible = False
        PanelProdutos.Visible = False
        PanelFuncionarios.Visible = False
        PanelFornecedores.Visible = False
        PanelRelatorio.Visible = False
        PanelCarrinho.Visible = False
    End Sub

    Sub setSizePanel0()
        PanelClientes.Size = New System.Drawing.Size(1037, 0)
        PanelProdutos.Size = New System.Drawing.Size(1037, 0)
        PanelFuncionarios.Size = New System.Drawing.Size(1037, 0)
        PanelFornecedores.Size = New System.Drawing.Size(1037, 0)
        PanelRelatorio.Size = New System.Drawing.Size(1037, 0)
        PanelCarrinho.Size = New System.Drawing.Size(1037, 0)
    End Sub

    Sub selectPanel(panel As Panel, groupBox As GroupBox)
        setSizePanel0()
        setFalseVisiblePanel()
        panel.Visible = True
        panel.Size = New System.Drawing.Size(1037, HeightForm)
        groupBox.Size = New System.Drawing.Size(WidthGrupoBox, HeightGroupBox)
    End Sub

    Sub desabilitarMenus()
        NovoToolStripMenuItemCliente.Enabled = False
        EditarToolStripMenuItemCli.Enabled = False
        NovoToolStripMenuItemProduto.Enabled = False
        EdiitarToolStripMenuItemProduto.Enabled = False
        NovoToolStripMenuItem.Enabled = False
        EditarToolStripMenuItem.Enabled = False
        NovoToolStripMenuItemFornecedor.Enabled = False
        EditarToolStripMenuItemFornecedor.Enabled = False
    End Sub

    Sub habilitarMenuClientes()
        NovoToolStripMenuItemCliente.Enabled = True
        EditarToolStripMenuItemCli.Enabled = True
    End Sub

    Private Sub CadastrarBancoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastrarBancoToolStripMenuItem.Click
        FormBanco.Show()
    End Sub

    Private Sub VendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendasToolStripMenuItem.Click
        FormReportViwer.Show()
    End Sub

    Private Sub ReceitasEDespesasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceitasEDespesasToolStripMenuItem.Click
        FormRelatorioTotalConta.Show()
    End Sub

    Sub habilitarMenuProdutos()
        NovoToolStripMenuItemProduto.Enabled = True
        EdiitarToolStripMenuItemProduto.Enabled = True
    End Sub

    Sub habilitarMenuFuncionarios()
        NovoToolStripMenuItem.Enabled = True
        EditarToolStripMenuItem.Enabled = True
    End Sub

    Sub habilitarMenuFornecedores()
        NovoToolStripMenuItemFornecedor.Enabled = True
        EditarToolStripMenuItemFornecedor.Enabled = True
    End Sub



End Class