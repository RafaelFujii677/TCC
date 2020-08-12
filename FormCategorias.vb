Imports MySql.Data.MySqlClient
Imports System.IO
Public Class FormCategorias
    Dim idCategoria As Integer
    Dim idSubCategoria As Integer
    Dim editando As Boolean = False
    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        Me.Close()
    End Sub

    Private Sub FormCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LabelCategoria.Text = "Subcategoria" Then
            LabelifCategoria.Visible = True
            ComboBoxCategoria.Visible = True
            LabelMinEstoq.Visible = False
            TextBoxMinEstoq.Visible = False
            GroupBoxCategoria.Text = "Subcategorias"
        Else
            LabelifCategoria.Visible = False
            ComboBoxCategoria.Visible = False
            LabelMinEstoq.Visible = True
            TextBoxMinEstoq.Visible = True
            GroupBoxCategoria.Text = "Categorias"
        End If

        With ComboBoxCategoria
            .DataSource = FormMenu.ComboBoxCategoriaProd.DataSource
            .ValueMember = FormMenu.ComboBoxCategoriaProd.ValueMember
            .DisplayMember = FormMenu.ComboBoxCategoriaProd.DisplayMember
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        EditarToolStripMenuItem.Enabled = True
        If LabelCategoria.Text = "Subcategoria" Then
            pegarIdDataGridSubCategoria()
        Else
            pegarIdDataGridCategoria()
        End If

    End Sub

    Sub pegarIdDataGridSubCategoria()
        buscarIdCategoria()

        Try
            fechar()
            abrir()

            sql = "SELECT id_Subcategoria FROM SubCategoria WHERE descricao_SubCategoria = '" & DataGridView1.CurrentCell.Value & "' and id_Categoria_Subcategoria = " & idCategoria
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idSubCategoria = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Sub pegarIdDataGridCategoria()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Categoria FROM Categoria WHERE descricao_Categoria = '" & DataGridView1.CurrentCell.Value & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idCategoria = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If LabelCategoria.Text = "Subcategoria" And ComboBoxCategoria.Text = "" Then
            ComboBoxCategoria.Focus()
            TextBox1.Text = ""
        Else

        End If

        If TextBox1.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        Else
            SalvarToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub SalvarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItem.Click
        If LabelCategoria.Text = "Subcategoria" Then
            If editando Then
                atualizarSubCategoria()
            Else
                salvarSubCategoria()
            End If
        Else
            If editando Then
                atualizarCategoria()
            Else
                salvarCategoria()
            End If
        End If
    End Sub

    Sub salvarCategoria()
        Try
            fechar()
            abrir()

            sql = "INSERT INTO Categoria (descricao_Categoria, min_Estoque_Categoria) VALUES ('" & TextBox1.Text & "'," & TextBoxMinEstoq.Text & ")"
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery() Then
                MsgBox("Categoria salvar com sucesso.")
            End If

        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
            pesquisarCategorias()
            TextBox1.Clear()
            TextBoxMinEstoq.Clear()
            editando = False
            EditarToolStripMenuItem.Enabled = False
            SalvarToolStripMenuItem.Enabled = False
        End Try
    End Sub

    Sub salvarSubCategoria()
        buscarIdCategoria()

        Try
            fechar()
            abrir()

            sql = "INSERT INTO SubCategoria (descricao_Subcategoria, id_Categoria_Subcategoria) VALUES ('" & TextBox1.Text & "'," & idCategoria & ")"
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery() Then
                MsgBox("Subcategoria salvar com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
            pesquisarSubCategorias()
            TextBox1.Clear()
            editando = False
            EditarToolStripMenuItem.Enabled = False
            SalvarToolStripMenuItem.Enabled = False
        End Try
    End Sub

    Sub atualizarCategoria()
        Try
            fechar()
            abrir()

            sql = "UPDATE Categoria SET descricao_Categoria = '" & TextBox1.Text & "', min_Estoque_Categoria = " & TextBoxMinEstoq.Text & " WHERE id_Categoria = " & idCategoria
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery() Then
                MsgBox("Categoria editada com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
            pesquisarCategorias()
            TextBox1.Clear()
            TextBoxMinEstoq.Clear()
            editando = False
            EditarToolStripMenuItem.Enabled = False
            SalvarToolStripMenuItem.Enabled = False
        End Try
    End Sub

    Sub atualizarSubCategoria()
        buscarIdSubCategoria()

        Try
            fechar()
            abrir()

            sql = "UPDATE SubCategoria SET descricao_Subcategoria = '" & TextBox1.Text & "' WHERE id_Subcategoria = " & idSubCategoria
            cmdUser = New MySqlCommand(sql, conexao)
            If cmdUser.ExecuteNonQuery() Then
                MsgBox("Subcategoria editada com sucesso.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
            pesquisarSubCategorias()
            TextBox1.Clear()
            editando = False
            EditarToolStripMenuItem.Enabled = False
            SalvarToolStripMenuItem.Enabled = False
        End Try
    End Sub

    Sub buscarIdCategoria()
        Try
            fechar()
            abrir()

            sql = "SELECT id_Categoria FROM Categoria WHERE descricao_Categoria = '" & ComboBoxCategoria.Text & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idCategoria = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub buscarIdSubCategoria()
        buscarIdCategoria()

        Try
            fechar()
            abrir()

            sql = "SELECT id_Subcategoria FROM SubCategoria WHERE id_Categoria_Subcategoria = '" & idCategoria & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idSubCategoria = reader.GetString(0)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Sub pesquisarCategorias()
        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT descricao_Categoria, min_Estoque_Categoria FROM Categoria"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            DataGridView1.DataSource = dados
            ajustarDataGid()

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub pesquisarSubCategorias()
        buscarIdCategoria()

        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT descricao_Subcategoria FROM SubCategoria WHERE id_Categoria_Subcategoria = '" & idCategoria & "'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            DataGridView1.DataSource = dados
            ajustarDataGid()

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub ajustarDataGid()
        With DataGridView1
            .Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "Descrição"
            .Columns(0).Width = 200
            .Columns(1).HeaderText = "Min Estq"
            .Columns(1).Width = 60
        End With
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        editando = True
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBoxMinEstoq.Text = DataGridView1.CurrentRow.Cells(1).Value
    End Sub

    Private Sub PesquisarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesquisarTodosToolStripMenuItem.Click
        If LabelCategoria.Text = "Subcategoria" Then
            If ComboBoxCategoria.Text = "" Then
                MsgBox("Não é possível pesquisar uma subcategoria sem uma categoria inical.")
                ComboBoxCategoria.Focus()
            Else
                pesquisarSubCategorias()
            End If
        Else
            pesquisarCategorias()
        End If
    End Sub
End Class