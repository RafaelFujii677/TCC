Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Public Class FormLogin
    Dim cargo As String
    Dim login As String
    Dim senha As String
    Dim fotoFuncionario As Bitmap
    Dim tick As Boolean = False
    Public carrinhoUp As Boolean
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'Permite visualizar/esconder a senha
        If (CheckBox1.Checked) Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If (TextBox1.Text = "") Then
            TextBox1.Text = "Usuário"
        End If
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If (TextBox1.Text = "Usuário") Then
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If (TextBox2.Text = "") Then
            TextBox2.PasswordChar = ""
            TextBox2.Text = "Senha"
        End If
    End Sub

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        If (CheckBox1.Checked = False) Then
            TextBox2.PasswordChar = "*"
        End If

        If (TextBox2.Text = "Senha") Then
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        Application.Exit()
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox2.PasswordChar = ""
    End Sub

    Private Sub FormLogin_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        TextBox1.Text = "Usuário"
        TextBox2.Text = "Senha"
        TextBox2.PasswordChar = ""
    End Sub

    Sub carregando()
        PictureBox3.Visible = False
        PictureBox1.Visible = False
        PictureBox2.Visible = False

        TextBox1.Visible = False
        TextBox2.Visible = False

        Panel1.Visible = False
        Panel2.Visible = False

        CheckBox1.Visible = False
        Button1.Visible = False
        X.Visible = False

        LabelCarregando.Visible = True

        FormMenu.LabelvinculoFuncionario.Text = ""
        FormMenu.LabelDataCadastroCli.Text = ""
        FormMenu.LabelPtsCLi.Text = ""
        FormMenu.LabelUltimaCompraCli.Text = ""
        FormMenu.LabelDataVenda.Text = ""

        isNotEditavel()
        isNotEditableCliente()
        isNotEditableProd()
        isNotEditableForn()
        isNotEditableVenda()
    End Sub

    Sub posCarregamento()
        PictureBox1.Visible = True
        PictureBox2.Visible = True

        TextBox1.Visible = True
        TextBox2.Visible = True

        Panel1.Visible = True
        Panel2.Visible = True

        CheckBox1.Visible = True
        Button1.Visible = True
        X.Visible = True

        LabelCarregando.Visible = False

        BunifuCircleProgressbar1.Value = 0
        BunifuCircleProgressbar1.Refresh()

        PictureBox3.Visible = True

        FormMenu.desabilitarMenus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim canLogin As Integer
        carregando()

        login = TextBox1.Text()
        senha = TextBox2.Text()

        Try
            fechar()
            abrir()
            Dim charsToTrim As Char() = {"*", " ", "\", "'"}
            sql = "SELECT * FROM Funcionarios WHERE login_Funcionario = '" & login & "' AND senha_Funcionario = '" & senha & "'"
            senha.Trim(charsToTrim)

            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader

            BunifuCircleProgressbar1.Value += 10
            BunifuCircleProgressbar1.Refresh()

            If reader.Read Then

                fechar()
                abrir()
                sql = "SELECT vinculo_Funcionario FROM Funcionarios WHERE login_Funcionario = '" & login & "' AND senha_Funcionario = '" & senha & "'"
                cmdUser = New MySqlCommand(sql, conexao)
                reader = cmdUser.ExecuteReader
                reader.Read()
                canLogin = reader.GetString(0)

                If canLogin = 1 Then

                    fechar()
                    abrir()

                    sql = "SELECT cargo_Funcionario FROM Funcionarios WHERE login_Funcionario = '" & login & "' AND senha_Funcionario = '" & senha & "'"
                    cmdUser = New MySqlCommand(sql, conexao)
                    reader = cmdUser.ExecuteReader
                    reader.Read()
                    cargo = reader.GetString(0)

                    BunifuCircleProgressbar1.Value += 10
                    BunifuCircleProgressbar1.Refresh()

                    If cargo = "Gerente" Then

                        permissaoAdmin()


                    ElseIf cargo = "Vendedor" Then

                        permissaoVendedor()

                    Else
                        MsgBox("Você não tem permissão suficiente para logar no sistema")
                    End If


                    'carregar bancos cadastrados
                    Try
                        fechar()
                        abrir()

                        BunifuCircleProgressbar1.Value += 10
                        BunifuCircleProgressbar1.Refresh()

                        sql = "SELECT nome_Banco FROM Bancos"
                        adaptador = New MySqlDataAdapter(sql, conexao)

                        BunifuCircleProgressbar1.Value += 10
                        BunifuCircleProgressbar1.Refresh()

                        Dim dado As New DataSet
                        adaptador.Fill(dado, "Bancos")

                        BunifuCircleProgressbar1.Value += 10
                        BunifuCircleProgressbar1.Refresh()

                        With FormMenu.ComboBoxBancoFunc
                            .DataSource = dado.Tables(0)
                            .ValueMember = "nome_Banco"
                            .DisplayMember = "nome_Banco"
                            .SelectedIndex = -1
                        End With

                        With FormMenu.ComboBoxBancoForn
                            .DataSource = dado.Tables(0)
                            .ValueMember = "nome_Banco"
                            .DisplayMember = "nome_Banco"
                            .SelectedIndex = -1
                        End With

                    Catch ex As Exception
                        MsgBox("Erro ao carregar bancos cadastrados.")
                    Finally
                        fechar()
                    End Try
                    ' fim do carregamento

                    'carregar cargos
                    Try
                        fechar()
                        abrir()

                        sql = "SELECT nome_Cargo FROM Cargos"
                        adaptador = New MySqlDataAdapter(sql, conexao)

                        BunifuCircleProgressbar1.Value += 10
                        BunifuCircleProgressbar1.Refresh()

                        Dim dado As New DataSet
                        adaptador.Fill(dado, "Cargos")

                        BunifuCircleProgressbar1.Value += 10
                        BunifuCircleProgressbar1.Refresh()

                        With FormMenu.ComboBoxCargoFunc
                            .DataSource = dado.Tables(0)
                            .ValueMember = "nome_Cargo"
                            .DisplayMember = "nome_Cargo"
                            .SelectedIndex = -1
                        End With

                    Catch ex As Exception
                        MsgBox("Erro ao carregar cargos cadastrados.")
                    Finally
                        fechar()
                    End Try
                    ' fim do carregamento


                    'carregar categorias
                    Try
                        fechar()
                        abrir()

                        sql = "SELECT descricao_Categoria FROM Categoria"
                        adaptador = New MySqlDataAdapter(sql, conexao)
                        Dim dado As New DataSet
                        adaptador.Fill(dado, "Categoria")

                        BunifuCircleProgressbar1.Value += 10
                        BunifuCircleProgressbar1.Refresh()

                        With FormMenu.ComboBoxCategoriaProd
                            .DataSource = dado.Tables(0)
                            .ValueMember = "descricao_Categoria"
                            .DisplayMember = "descricao_Categoria"
                            .SelectedIndex = -1
                        End With

                    Catch ex As Exception
                        MsgBox("Erro ao carregar categorias.")
                        MsgBox(ex.ToString())
                    Finally
                        fechar()
                    End Try
                    'fim do carregamento

                    buscarMelhorVendedor()
                    BunifuCircleProgressbar1.Value += 10
                    BunifuCircleProgressbar1.Refresh()

                    TotalConta()

                    carregarDespesas()
                    BunifuCircleProgressbar1.Value += 10
                    BunifuCircleProgressbar1.Refresh()

                    carregarReceitas()

                    calcularReceitaDespesa()

                    calcularRelacaoMesAnterior()

                    BunifuCircleProgressbar1.Refresh()
                    System.Threading.Thread.Sleep(2000)
                    PictureBox3.Visible = True
                    Me.Visible = False
                    posCarregamento()
                    FormMenu.Show()

                    If cargo = "Gerente" Then
                        avisoDeBaixoEstoque()
                    End If

                Else
                    MsgBox("ThenSem permissão para logar!")
                    posCarregamento()
                End If
            Else
                MsgBox("Dados Incorretos!")
                posCarregamento()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
            posCarregamento()
        Finally
            fechar()
        End Try


    End Sub

    Sub permissaoAdmin()

        habilitarTodos()
        FormMenu.LabelCargo.Text = cargo

        carregarFoto()
        buscarApelido()

        descerBTNCarrinho()
        habilitarMenuOpcoes()
    End Sub

    Sub permissaoVendedor()

        desabilitarBTNUsuarios()
        desabilitarBTNFornecedores()
        desabilitarBTNRelatorios()
        FormMenu.LabelCargo.Text = cargo

        carregarFoto()
        buscarApelido()

        subirBTNCarrinho()
        desabilitarMenuOpcoes()
    End Sub

    ' BTN clientes
    Sub desabilitarBTNClientes()
        FormMenu.BTNcliente.Visible = False
        FormMenu.BTNcliente.Enabled = False
    End Sub
    Sub habilitarBTNClientes()
        FormMenu.BTNcliente.Visible = True
        FormMenu.BTNcliente.Enabled = True
    End Sub

    ' BTN produtos
    Sub desabilitarBTNProdutos()
        FormMenu.BTNprodutos.Visible = False
        FormMenu.BTNprodutos.Enabled = False
    End Sub
    Sub habilitarBTNProdutos()
        FormMenu.BTNprodutos.Visible = True
        FormMenu.BTNprodutos.Enabled = True
    End Sub

    'BTN Usuários
    Sub desabilitarBTNUsuarios()
        FormMenu.BTNusuarios.Visible = False
        FormMenu.BTNusuarios.Enabled = False
    End Sub
    Sub habilitarBTNUsusarios()
        FormMenu.BTNusuarios.Visible = True
        FormMenu.BTNusuarios.Enabled = True
    End Sub

    ' BTN fornecedores
    Sub desabilitarBTNFornecedores()
        FormMenu.BTNfornecedores.Visible = False
        FormMenu.BTNfornecedores.Enabled = False
    End Sub
    Sub habilitarBTNFornecedores()
        FormMenu.BTNfornecedores.Visible = True
        FormMenu.BTNfornecedores.Enabled = True
    End Sub

    'BTN relatórios
    Sub desabilitarBTNRelatorios()
        FormMenu.BTNrelatorios.Visible = False
        FormMenu.BTNrelatorios.Enabled = False
    End Sub
    Sub habilitarBTNRelatorios()
        FormMenu.BTNrelatorios.Visible = True
        FormMenu.BTNrelatorios.Enabled = True
    End Sub

    'BTN carrinho
    Sub desabilitarBTNCarrinho()
        FormMenu.BTNcarrinho.Visible = False
        FormMenu.BTNcarrinho.Enabled = False
    End Sub
    Sub habilitarBTNCarrinho()
        FormMenu.BTNcarrinho.Visible = True
        FormMenu.BTNcarrinho.Enabled = True
    End Sub

    Sub subirBTNCarrinho()
        FormMenu.BTNcarrinho.Location = New Point(27, 348)
        carrinhoUp = True
    End Sub

    Sub descerBTNCarrinho()
        FormMenu.BTNcarrinho.Location = New Point(27, 525)
        carrinhoUp = False
    End Sub

    Sub habilitarTodos()
        habilitarBTNClientes()
        habilitarBTNProdutos()
        habilitarBTNUsusarios()
        habilitarBTNFornecedores()
        habilitarBTNRelatorios()
        habilitarBTNCarrinho()
    End Sub
    Sub desabilitarTodos()
        desabilitarBTNClientes()
        desabilitarBTNProdutos()
        desabilitarBTNUsuarios()
        desabilitarBTNFornecedores()
        desabilitarBTNRelatorios()
        desabilitarBTNCarrinho()
    End Sub

    Sub buscarApelido()
        fechar()
        abrir()
        Try
            sql = "SELECT apelido_Funcionario FROM Funcionarios WHERE login_Funcionario = '" & login & "' AND  senha_Funcionario = '" & senha & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.LabelNomeFunc.Text = reader.GetString(0)
        Catch ex As MySqlException
            MsgBox(ex.ToString())
        End Try
        fechar()
    End Sub


    Sub carregarFoto()
        fechar()
        abrir()
        Try
            sql = "SELECT foto_Funcionario FROM Funcionarios WHERE login_Funcionario = '" & login & "' AND  senha_Funcionario = '" & senha & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader

            If reader.HasRows Then
                reader.Read()

                Dim blob As Byte() = DirectCast(reader.Item("foto_Funcionario"), Byte())
                Using ms = New MemoryStream(blob)
                    fotoFuncionario = New Bitmap(ms)
                End Using
                FormMenu.FotoFuncionarioPictureBox.BackgroundImage = fotoFuncionario
            Else

            End If
        Catch ex As MySqlException
            MsgBox(ex.ToString())

        Finally
            fechar()
        End Try
    End Sub

    Sub desabilitarMenuOpcoes()
        FormMenu.OpçõesToolStripMenuItem.Visible = False
        FormMenu.AlterarToolStripMenuItem.Visible = False
    End Sub

    Sub habilitarMenuOpcoes()
        FormMenu.OpçõesToolStripMenuItem.Visible = True
        FormMenu.AlterarToolStripMenuItem.Visible = True
    End Sub
End Class
