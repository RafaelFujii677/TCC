Imports MySql.Data.MySqlClient

Public Class FormBanco
    Dim editandoBanco As Boolean = False
    Dim idBanco As Integer
    Private Sub X_Click(sender As Object, e As EventArgs) Handles X.Click
        Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            SalvarToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub FormBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carregarBancosDatagrid()
    End Sub

    Sub carregarBancosDatagrid()
        Try
            fechar()
            abrir()

            Dim dados As New DataTable
            Dim adaptador As MySqlDataAdapter
            Dim sql As String

            sql = "SELECT id_Banco, nome_Banco FROM Bancos"
            adaptador = New MySqlDataAdapter(sql, conexao)
            adaptador.Fill(dados)
            DataGridView1.DataSource = dados
            ajustarDgBanco()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            fechar()
        End Try
    End Sub

    Private Sub SalvarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItem.Click
        If editandoBanco Then
            Try
                fechar()
                abrir()

                sql = "UPDATE Bancos SET nome_Banco = '" & TextBox1.Text & "' WHERE id_Banco = " & idBanco
                cmdUser = New MySqlCommand(sql, conexao)
                If cmdUser.ExecuteNonQuery() Then
                    MsgBox("Banco atualizado com sucesso.")
                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            Finally
                fechar()
                TextBox1.Clear()
            End Try
        Else
            Try
                fechar()
                abrir()

                sql = "INSERT INTO Bancos (nome_Banco) VALUES ('" & TextBox1.Text & "')"
                cmdUser = New MySqlCommand(sql, conexao)

                If cmdUser.ExecuteNonQuery Then
                    MsgBox("Banco salvo com sucesso.")
                End If
            Catch MySqlEx As MySqlException
                MsgBox("Banco já cadastrado.")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            Finally
                fechar()
                TextBox1.Clear()
            End Try
        End If
        editandoBanco = False
        carregarBancosDatagrid()
    End Sub

    Sub ajustarDgBanco()
        With DataGridView1
            .Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .RowHeadersVisible = False
            .Columns(0).HeaderText = "Id"
            .Columns(0).Width = 30
            .Columns(1).HeaderText = "Nome"
            .Columns(1).Width = 220
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        idBanco = DataGridView1.CurrentRow.Cells(0).Value.ToString
        editandoBanco = True
    End Sub
End Class