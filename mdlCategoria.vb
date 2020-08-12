Imports MySql.Data.MySqlClient
Imports System.IO
Module mdlCategoria
    Dim idCategoria As Integer
    Sub buscarIdCategoria(descricaoCategoria As String)
        Try
            fechar()
            abrir()

            sql = "SELECT id_Categoria FROM Categoria WHERE descricao_Categoria = '" & descricaoCategoria & "'"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()
            idCategoria = reader.GetString(0)

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Sub pesquisarSubCategorias(descricaoCategoria As String)
        buscarIdCategoria(descricaoCategoria)

        Try
            fechar()
            abrir()

            Dim adaptador As MySqlDataAdapter
            Dim dados As New DataTable
            Dim sql As String

            sql = "SELECT descricao_Subcategoria FROM SubCategoria WHERE id_Categoria_Subcategoria = '" & idCategoria & "'"
            adaptador = New MySqlDataAdapter(sql, conexao)
            Dim dado As New DataSet
            adaptador.Fill(dado, "SubCategoria")

            With FormMenu.ComboBoxSubCategoriaProd
                .DataSource = dado.Tables(0)
                .ValueMember = "descricao_Subcategoria"
                .DisplayMember = "descricao_Subcategoria"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

End Module
