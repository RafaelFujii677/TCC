Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Module mdlProdutos
    Dim imageProd As Image
    Dim byteArray
    Public temFotoProd As Boolean = False
    Public editandoProd As Boolean
    Dim idPesquisa As Integer
    Dim idsProdutosBaixoEstoque As Integer
    Dim qntCategorias As Integer
    Dim minEstoque As Integer
    Dim A As Integer
    Dim descricao As String

    Sub pegarFotoDoPCProduto()
        Try
            Using OFD As New OpenFileDialog With {.Filter = "Image File (*.jpg;*.bmp;*.png|*.jpg;*.bmp;*.png"}
                If OFD.ShowDialog = DialogResult.OK Then
                    imageProd = Image.FromFile(OFD.FileName)
                    FormMenu.PictureBoxProduto.Image = imageProd
                End If
            End Using
            temFotoProd = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub preSalvarFotoProduto()
        Try
            Dim ms As New IO.MemoryStream
            imageProd.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            byteArray = ms.ToArray
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

    Sub isEditableProd()
        FormMenu.TextBoxNomeProd.Enabled = True
        FormMenu.TextBoxMarcaProd.Enabled = True
        FormMenu.TextBoxCorProd.Enabled = True
        FormMenu.ComboBoxCategoriaProd.Enabled = True
        FormMenu.ComboBoxSubCategoriaProd.Enabled = True
        FormMenu.TextBoxEstoqueProd.Enabled = True
        FormMenu.TextBoxPrecoProd.Enabled = True
        FormMenu.TextBoxDescricaoProd.Enabled = True
        FormMenu.ButtonAddImageProd.Enabled = True
        temFotoProd = True
        FormMenu.SalvarToolStripMenuItemProduto.Enabled = True
        FormMenu.TextBoxFornProd.Enabled = True
        FormMenu.ButtonAddFornProd.Enabled = True
    End Sub

    Sub isNotEditableProd()
        FormMenu.TextBoxNomeProd.Enabled = False
        FormMenu.TextBoxMarcaProd.Enabled = False
        FormMenu.TextBoxCorProd.Enabled = False
        FormMenu.ComboBoxCategoriaProd.Enabled = False
        FormMenu.ComboBoxSubCategoriaProd.Enabled = False
        FormMenu.TextBoxEstoqueProd.Enabled = False
        FormMenu.TextBoxPrecoProd.Enabled = False
        FormMenu.TextBoxDescricaoProd.Enabled = False
        FormMenu.ButtonAddImageProd.Enabled = False
        editandoProd = False
        temFotoProd = False
        FormMenu.SalvarToolStripMenuItemProduto.Enabled = False
        FormMenu.TextBoxFornProd.Enabled = False
        FormMenu.ButtonAddFornProd.Enabled = False
    End Sub

    Sub buscarUltimoIdProd()
        Try
            fechar()
            abrir()

            sql = "SELECT MAX(id_Produto) FROM Produtos"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.TextBoxIdProd.Text = reader.GetString(0) + 1

        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub salvarProduto()
        Dim format As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo()
        format.NumberDecimalSeparator = "."
        Try
            fechar()
            abrir()

            preSalvarFotoProduto()

            sql = "INSERT INTO Produtos (nome_Produto, marca_Produto, categoria_Produto, sub_Categoria_Produto, cor_Produto, estoque_Produto, preco_Produto, descricao_Produto, foto_Produto, fornecedor_Produto)" &
                                "VALUES (    @nome   ,   @marca     ,      @categoria  ,      @subcategoria   ,     @cor   ,     @estoque   ,     @preco   ,      @descricao  ,     @foto   ,   @fornecedor) "
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@nome", FormMenu.TextBoxNomeProd.Text)
                .Parameters.AddWithValue("@marca", FormMenu.TextBoxMarcaProd.Text)
                .Parameters.AddWithValue("@categoria", FormMenu.ComboBoxCategoriaProd.Text)
                .Parameters.AddWithValue("@subcategoria", FormMenu.ComboBoxSubCategoriaProd.Text)
                .Parameters.AddWithValue("@cor", FormMenu.TextBoxCorProd.Text)
                .Parameters.AddWithValue("@estoque", FormMenu.TextBoxEstoqueProd.Text)
                .Parameters.AddWithValue("@preco", FormMenu.TextBoxPrecoProd.Text.ToString(format))
                .Parameters.AddWithValue("@descricao", FormMenu.TextBoxDescricaoProd.Text)
                .Parameters.AddWithValue("@foto", byteArray)
                .Parameters.AddWithValue("@fornecedor", FormMenu.TextBoxFornProd.Text)
            End With
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Produto salvo com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarPorNomeProd()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT id_Produto, nome_Produto, marca_Produto, fornecedor_Produto FROM Produtos WHERE nome_Produto LIKE '%" & FormPesquisa.pesquisaNomeProd.Text & "%'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DataGridViewProduto.DataSource = dados

            ajeitarDGProd()
        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub buscarPorMarca()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT id_Produto, nome_Produto, marca_Produto, fornecedor_Produto FROM Produtos WHERE marca_Produto LIKE '%" & FormPesquisa.pesquisaMarcaProd.Text & "%'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DataGridViewProduto.DataSource = dados

            ajeitarDGProd()
        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub buscarPorFornecedor()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT id_Produto, nome_Produto, marca_Produto, fornecedor_Produto FROM Produtos WHERE fornecedor_Produto LIKE '%" & FormPesquisa.pesquisaFornProd.Text & "%'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DataGridViewProduto.DataSource = dados

            ajeitarDGProd()
        Catch ex As Exception

        Finally
            fechar()
        End Try
    End Sub

    Sub carregarProduto()
        idPesquisa = FormPesquisa.DataGridViewProduto.CurrentRow.Cells(0).Value.ToString
        Try
            fechar()
            abrir()

            sql = "SELECT * FROM Produtos WHERE id_Produto = " & idPesquisa
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.TextBoxIdProd.Text = idPesquisa
            FormMenu.TextBoxNomeProd.Text = reader.GetString(1)
            FormMenu.TextBoxMarcaProd.Text = reader.GetString(2)
            FormMenu.ComboBoxCategoriaProd.Text = reader.GetString(3)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub


    Sub carregarSubCategroia()
        idPesquisa = FormPesquisa.DataGridViewProduto.CurrentRow.Cells(0).Value.ToString
        Try
            fechar()
            abrir()

            sql = "SELECT sub_Categoria_Produto, cor_Produto, estoque_Produto, preco_Produto, descricao_Produto, fornecedor_Produto FROM Produtos WHERE id_Produto = " & idPesquisa
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            FormMenu.ComboBoxSubCategoriaProd.Text = reader.GetString(0)
            FormMenu.TextBoxCorProd.Text = reader.GetString(1)
            FormMenu.TextBoxEstoqueProd.Text = reader.GetString(2)
            FormMenu.TextBoxPrecoProd.Text = reader.GetString(3)
            FormMenu.TextBoxDescricaoProd.Text = reader.GetString(4)
            FormMenu.TextBoxFornProd.Text = reader.GetString(5)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub carregarFotoProd()
        idPesquisa = FormPesquisa.DataGridViewProduto.CurrentRow.Cells(0).Value.ToString
        Try
            fechar()
            abrir()
            sql = "SELECT foto_Produto FROM Produtos WHERE id_Produto = " & idPesquisa
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            Dim blob As Byte() = DirectCast(reader.Item("foto_Produto"), Byte())
            Using ms = New MemoryStream(blob)
                imageProd = New Bitmap(ms)
            End Using

            FormMenu.PictureBoxProduto.Image = imageProd

        Catch ex As MySqlException
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub ajeitarDGProd()
        With FormPesquisa.DataGridViewProduto
            .Sort(FormPesquisa.DataGridViewProduto.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "Id"
            .Columns(0).Width = 30
            .Columns(1).HeaderText = "Nome"
            .Columns(1).Width = 150
            .Columns(2).HeaderText = "Marca"
            .Columns(2).Width = 150
            .Columns(3).HeaderText = "Fornecedor"
            .Columns(3).Width = 200
        End With
    End Sub

    Sub limparProd()
        FormMenu.TextBoxIdProd.Text = ""
        FormMenu.TextBoxNomeProd.Text = ""
        FormMenu.TextBoxMarcaProd.Text = ""
        FormMenu.TextBoxCorProd.Text = ""
        FormMenu.ComboBoxCategoriaProd.SelectedItem = -1
        FormMenu.ComboBoxSubCategoriaProd.SelectedItem = -1
        FormMenu.TextBoxEstoqueProd.Text = ""
        FormMenu.TextBoxPrecoProd.Text = ""
        FormMenu.TextBoxDescricaoProd.Text = ""
        FormMenu.PictureBoxProduto.Image = Nothing
        FormMenu.TextBoxFornProd.Clear()
    End Sub

    Sub atualizarFotoProd()
        preSalvarFotoProduto()

        Try
            fechar()
            abrir()

            sql = "UPDATE Produtos SET foto_Produto = @foto WHERE id_Produto = " & FormMenu.TextBoxIdProd.Text
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.Parameters.AddWithValue("@foto", byteArray)
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception

        Finally
            fechar()
        End Try

    End Sub

    Sub atualizarProd()
        Try
            fechar()
            abrir()

            sql = "UPDATE Produtos SET nome_Produto = @nome, marca_Produto = @marca, categoria_Produto = @categoria, sub_Categoria_Produto = @subcategoria, cor_Produto = @cor, " &
                "estoque_Produto = @estoque, preco_Produto = @preco, descricao_Produto = @desc, fornecedor_Produto = @forn WHERE id_Produto = " & FormMenu.TextBoxIdProd.Text
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@nome", FormMenu.TextBoxNomeProd.Text)
                .Parameters.AddWithValue("@marca", FormMenu.TextBoxMarcaProd.Text)
                .Parameters.AddWithValue("@categoria", FormMenu.ComboBoxCategoriaProd.Text)
                .Parameters.AddWithValue("@subcategoria", FormMenu.ComboBoxSubCategoriaProd.Text)
                .Parameters.AddWithValue("@cor", FormMenu.TextBoxCorProd.Text)
                .Parameters.AddWithValue("@estoque", FormMenu.TextBoxEstoqueProd.Text)
                .Parameters.AddWithValue("@preco", FormMenu.TextBoxPrecoProd.Text)
                .Parameters.AddWithValue("@desc", FormMenu.TextBoxDescricaoProd.Text)
                .Parameters.AddWithValue("@forn", FormMenu.TextBoxFornProd.Text)
            End With
            If cmdUser.ExecuteNonQuery Then
                MsgBox("Produto editado com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarTodosProd()
        Try
            fechar()
            abrir()

            Dim adaptador As New MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT id_Produto, nome_Produto, marca_Produto, fornecedor_Produto FROM Produtos"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DataGridViewProduto.DataSource = dados
            ajeitarDGProd()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            fechar()
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' 
    ''' 
    '''                           estoque baixo
    ''' 
    ''' 
    ''' 
    ''' </summary>

    Sub contarCategorias()
        Try
            fechar()
            abrir()

            sql = "SELECT COUNT(id_Categoria) FROM Categoria"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            qntCategorias = reader.GetString(0)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            fechar()
        End Try
    End Sub

    Sub avisoDeBaixoEstoque()
        contarCategorias()

        For A = 1 To qntCategorias
            Try
                fechar()
                abrir()

                sql = "SELECT min_Estoque_Categoria FROM Categoria WHERE id_Categoria = " & A
                cmdUser = New MySqlCommand(sql, conexao)
                reader = cmdUser.ExecuteReader
                reader.Read()
                minEstoque = reader.GetString(0)

                contarQuantosProdutosTemEsqtoqueBaixo()

                If idsProdutosBaixoEstoque > 0 And idsProdutosBaixoEstoque <> Nothing Then
                    If MessageBox.Show("Existem " & idsProdutosBaixoEstoque & " produtos com baixo estoque no sistema. Gostaria de visualiza-los ?", "Aviso", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        listarProdutosComEstoqueBaixo()
                        FormPesquisa.labelNomePesquisa.Text = "Produto"
                        FormPesquisa.GroupBoxProduto.Visible = True
                        FormPesquisa.GroupBoxProduto.Enabled = False
                        FormPesquisa.Show()
                        ajeitarDGProd()
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next

    End Sub

    Sub listarProdutosComEstoqueBaixo()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT id_Produto, nome_Produto, marca_Produto, fornecedor_Produto FROM Produtos WHERE estoque_Produto < " & minEstoque & " AND categoria_Produto='" & descricao & "'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            FormPesquisa.DataGridViewProduto.DataSource = dados

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            fechar()
        End Try
    End Sub

    Sub contarQuantosProdutosTemEsqtoqueBaixo()
        buscarDescricaoCategoriaPorId()
        Try
            fechar()
            abrir()

            sql = "SELECT COUNT(id_Produto) FROM Produtos WHERE estoque_Produto < " & minEstoque & " AND categoria_Produto='" & descricao & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idsProdutosBaixoEstoque = reader.GetString(0)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarDescricaoCategoriaPorId()
        Try
            fechar()
            abrir()

            sql = " SELECT descricao_Categoria FROM Categoria WHERE id_Categoria=" & A
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            descricao = reader.GetString(0)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            fechar()
        End Try
    End Sub

End Module
