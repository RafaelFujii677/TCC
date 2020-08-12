Imports MySql.Data.MySqlClient
Imports System.IO
Module mdlFuncionarios
    Dim byteArray As Byte()
    Public fotoFuncionario As Bitmap = FormMenu.PictureBoxFunc.Image

    Sub pegarFotoDoPC()
        Try
            Using OFD As New OpenFileDialog With {.Filter = "Image File (*.jpg;*.bmp;|*.jpg;*.bmp"}
                If OFD.ShowDialog = DialogResult.OK Then
                    FormMenu.ImagemFunc = Image.FromFile(OFD.FileName)
                    FormMenu.PictureBoxFunc.Image = FormMenu.ImagemFunc
                End If
            End Using
            FormMenu.temFoto = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub limparFuncionario()
        FormMenu.TextBoxIdFunc.Text = ""
        FormMenu.TextBoxNomeFunc.Text = ""
        FormMenu.TextBoxApelidoFunc.Text = ""
        FormMenu.MaskedTextBoxCPFFunc.Text = ""
        FormMenu.MaskedTextBoxRGFunc.Text = ""
        FormMenu.MaskedTextBoxNascimentoFunc.Text = ""
        FormMenu.MaskedTextBoxCEL1Func.Text = ""
        FormMenu.MaskedTextBoxCEL2Func.Text = ""
        FormMenu.MaskedTextBoxTEL1Func.Text = ""
        FormMenu.MaskedTextBoxTEL2Func.Text = ""
        FormMenu.TextBoxEMAILFunc.Text = ""
        FormMenu.MaskedTextBoxCEPFunc.Text = ""
        FormMenu.TextBoxLogradouroFunc.Text = ""
        FormMenu.TextBoxUFFunc.Text = ""
        FormMenu.TextBoxCidadeFunc.Text = ""
        FormMenu.TextBoxNUmENDFunc.Text = ""
        FormMenu.TextBoxBairroFunc.Text = ""
        FormMenu.TextBoxCompleFunc.Text = ""
        FormMenu.TextBoxSalarioFunc.Text = ""
        FormMenu.TextBoxComissaoFunc.Text = ""
        FormMenu.TextBoxVendasFunc.Text = ""
        FormMenu.TextBoxLoginFunc.Text = ""
        FormMenu.TextBoxSenhaFunc.Text = ""
        FormMenu.ComboBoxCargoFunc.Text = ""
        FormMenu.ComboBoxBancoFunc.Text = ""
        FormMenu.TextBoxContaBancoFunc.Text = ""
        FormMenu.TextBoxAgenciaFunc.Text = ""
        FormMenu.TextBoxOperacaoBancoFunc.Text = ""
        FormMenu.LabelvinculoFuncionario.Text = ""
        FormMenu.PictureBoxFunc.Image = Nothing
    End Sub

    Sub preSalvarFoto()
        Try
            Dim ms As New IO.MemoryStream
            FormMenu.ImagemFunc.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            byteArray = ms.ToArray
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Sub buscarUltimoID()
        Try
            fechar()
            abrir()

            Dim maxId As Integer

            sql = "SELECT MAX(id_Funcionario) FROM Funcionarios"
            cmdUser = New MySqlCommand(sql, conexao)
            reader = cmdUser.ExecuteReader
            reader.Read()

            maxId = reader.GetString(0)

            FormMenu.TextBoxIdFunc.Text = maxId + 1
        Catch ex As Exception
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub salvarFuncionario()
        Dim format As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo()
        format.NumberDecimalSeparator = "."
        Try
            fechar()
            abrir()

            Dim nascimentoFunc As Date = FormMenu.MaskedTextBoxNascimentoFunc.Text
            preSalvarFoto()

            sql = "INSERT INTO Funcionarios (nome_Funcionario, apelido_Funcionario, cpf_Funcionario, rg_Funcionario, login_Funcionario, senha_Funcionario, cargo_Funcionario, data_Nascimento_Funcionario, foto_Funcionario, banco_Funcionario, conta_Banco_Funcionario, agencia_Funcionario, celular1_Funcionario, celular2_Funcionario, telefone1_Funcionario, telefone2_Funcionario, vendas_Funcionario, email_Funcionario, cep_Funcionario, logradouro_Funcionario, estado_Funcionario, cidade_Funcionario, bairro_Funcionario, numero_end_Funcionario, complemento_Funcionario, salario_Funcionario, comissao_Funcionario, operacao_Banco_Funcionario, vinculo_Funcionario)" &
                                    "VALUES (    @field1     ,      @field2       ,     @field3    ,     @field4   ,      @field5     ,       @field6    ,       @field7    ,          @field8           ,       @field9   ,      @nomeBanco  ,        @contaBanco     ,       @agencia     ,        @cel1        ,         @cel2       ,        @tel1         ,         @tel2        ,        @vendas    ,        @email    ,       @cep     ,        @logradouro    ,      @estado      ,       @cidade     ,        @bairro    ,        @numero        ,         @complemento   ,        @salario    ,      @comissao      ,          @operacao        ,         @vinculo        )"
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@field1", FormMenu.TextBoxNomeFunc.Text)
                .Parameters.AddWithValue("@field2", FormMenu.TextBoxApelidoFunc.Text)
                .Parameters.AddWithValue("@field3", FormMenu.MaskedTextBoxCPFFunc.Text)
                .Parameters.AddWithValue("@field4", FormMenu.MaskedTextBoxRGFunc.Text)
                .Parameters.AddWithValue("@field5", FormMenu.TextBoxLoginFunc.Text)
                .Parameters.AddWithValue("@field6", FormMenu.TextBoxSenhaFunc.Text)
                .Parameters.AddWithValue("@field7", FormMenu.ComboBoxCargoFunc.Text)
                .Parameters.AddWithValue("@field8", nascimentoFunc.ToString("yyyy-MM-dd"))
                .Parameters.AddWithValue("@field9", byteArray)
                .Parameters.AddWithValue("@nomeBanco", FormMenu.ComboBoxBancoFunc.Text)
                .Parameters.AddWithValue("@contaBanco", FormMenu.TextBoxContaBancoFunc.Text)
                .Parameters.AddWithValue("@agencia", FormMenu.TextBoxAgenciaFunc.Text)
                .Parameters.AddWithValue("@cel1", FormMenu.MaskedTextBoxCEL1Func.Text)
                .Parameters.AddWithValue("@cel2", FormMenu.MaskedTextBoxCEL2Func.Text)
                .Parameters.AddWithValue("@tel1", FormMenu.MaskedTextBoxTEL1Func.Text)
                .Parameters.AddWithValue("@tel2", FormMenu.MaskedTextBoxTEL2Func.Text)
                .Parameters.AddWithValue("@vendas", FormMenu.TextBoxVendasFunc.Text)
                .Parameters.AddWithValue("@email", FormMenu.TextBoxEMAILFunc.Text)
                .Parameters.AddWithValue("@cep", FormMenu.MaskedTextBoxCEPFunc.Text)
                .Parameters.AddWithValue("@logradouro", FormMenu.TextBoxLogradouroFunc.Text)
                .Parameters.AddWithValue("@cidade", FormMenu.TextBoxCidadeFunc.Text)
                .Parameters.AddWithValue("@estado", FormMenu.TextBoxUFFunc.Text)
                .Parameters.AddWithValue("@bairro", FormMenu.TextBoxBairroFunc.Text)
                .Parameters.AddWithValue("@numero", FormMenu.TextBoxNUmENDFunc.Text)
                .Parameters.AddWithValue("@complemento", FormMenu.TextBoxCompleFunc.Text)
                .Parameters.AddWithValue("@salario", FormMenu.TextBoxSalarioFunc.Text.ToString(format))
                .Parameters.AddWithValue("@comissao", FormMenu.TextBoxComissaoFunc.Text.ToString(format))
                .Parameters.AddWithValue("@operacao", FormMenu.TextBoxOperacaoBancoFunc.Text)
                .Parameters.AddWithValue("@vinculo", True)
            End With

            If cmdUser.ExecuteNonQuery() Then
                registrarEntrada()
                MsgBox("Funcionario salvo!")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            fechar()
            editando = False
        End Try

    End Sub

    Sub editarFuncionario()
        Try
            fechar()
            abrir()

            Dim nascimentoFunc As Date = FormMenu.MaskedTextBoxNascimentoFunc.Text

            sql = "UPDATE Funcionarios SET nome_Funcionario = @nome, apelido_Funcionario = @apelido, rg_Funcionario = @rg, data_Nascimento_Funcionario = @nascimento," &
                " celular1_Funcionario = @cel1, celular2_Funcionario = @cel2, telefone1_Funcionario = @tel1, telefone2_Funcionario = @tel2, email_Funcionario = @email," &
                " cep_Funcionario = @cep, logradouro_Funcionario = @logradouro, estado_Funcionario = @estado, cidade_Funcionario = @cidade, bairro_Funcionario = @bairro," &
                " numero_end_Funcionario = @numEnd, complemento_Funcionario = @complemento, salario_Funcionario = @salario, comissao_Funcionario = @comissao, login_Funcionario = @login," &
                " senha_Funcionario = @senha, cargo_Funcionario = @cargo, banco_Funcionario = @banco, conta_Banco_Funcionario = @conta, agencia_Funcionario = @agencia," &
                " operacao_Banco_Funcionario = @operacao" &
                " WHERE id_Funcionario = " & FormMenu.TextBoxIdFunc.Text

            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@nome", FormMenu.TextBoxNomeFunc.Text)
                .Parameters.AddWithValue("@apelido", FormMenu.TextBoxApelidoFunc.Text)
                .Parameters.AddWithValue("@rg", FormMenu.MaskedTextBoxRGFunc.Text)
                .Parameters.AddWithValue("@nascimento", (nascimentoFunc).ToString("yyyy-MM-dd"))
                .Parameters.AddWithValue("@cel1", FormMenu.MaskedTextBoxCEL1Func.Text)
                .Parameters.AddWithValue("@cel2", FormMenu.MaskedTextBoxCEL2Func.Text)
                .Parameters.AddWithValue("@tel1", FormMenu.MaskedTextBoxTEL1Func.Text)
                .Parameters.AddWithValue("@tel2", FormMenu.MaskedTextBoxTEL2Func.Text)
                .Parameters.AddWithValue("@email", FormMenu.TextBoxEMAILFunc.Text)
                .Parameters.AddWithValue("@cep", FormMenu.MaskedTextBoxCEPFunc.Text)
                .Parameters.AddWithValue("@logradouro", FormMenu.TextBoxLogradouroFunc.Text)
                .Parameters.AddWithValue("@estado", FormMenu.TextBoxUFFunc.Text)
                .Parameters.AddWithValue("@cidade", FormMenu.TextBoxCidadeFunc.Text)
                .Parameters.AddWithValue("@bairro", FormMenu.TextBoxBairroFunc.Text)
                .Parameters.AddWithValue("@numEnd", FormMenu.TextBoxNUmENDFunc.Text)
                .Parameters.AddWithValue("@complemento", FormMenu.TextBoxCompleFunc.Text)
                .Parameters.AddWithValue("@salario", FormMenu.TextBoxSalarioFunc.Text)
                .Parameters.AddWithValue("@comissao", FormMenu.TextBoxComissaoFunc.Text)
                .Parameters.AddWithValue("@login", FormMenu.TextBoxLoginFunc.Text)
                .Parameters.AddWithValue("@senha", FormMenu.TextBoxSenhaFunc.Text)
                .Parameters.AddWithValue("@cargo", FormMenu.ComboBoxCargoFunc.Text)
                .Parameters.AddWithValue("@banco", FormMenu.ComboBoxBancoFunc.Text)
                .Parameters.AddWithValue("@conta", FormMenu.TextBoxContaBancoFunc.Text)
                .Parameters.AddWithValue("@agencia", FormMenu.TextBoxAgenciaFunc.Text)
                .Parameters.AddWithValue("@operacao", FormMenu.TextBoxOperacaoBancoFunc.Text)
            End With
            If cmdUser.ExecuteNonQuery() Then
                MsgBox("Funcionário editado com sucesso!")
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro inesperado ao tentar editar o funcionário.")
            ex.ToString()
        Finally
            fechar()
        End Try
    End Sub

    Sub editarFoto()
        Try
            fechar()
            abrir()

            Dim ms As New IO.MemoryStream

            If FormMenu.temFoto = True Then
                FormMenu.ImagemFunc.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                byteArray = ms.ToArray

                sql = "UPDATE Funcionarios SET foto_Funcionario = @field1 WHERE id_Funcionario = " & FormMenu.TextBoxIdFunc.Text
                cmdUser = New MySqlCommand(sql, conexao)
                cmdUser.Parameters.AddWithValue("@field1", byteArray)

                cmdUser.ExecuteNonQuery()
            Else
                FormMenu.temFoto = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            fechar()
        End Try
    End Sub

    Sub desvincular()
        Try
            fechar()
            abrir()
            sql = "UPDATE Funcionarios SET vinculo_Funcionario = @field1 WHERE id_Funcionario = " & FormMenu.TextBoxIdFunc.Text
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.Parameters.AddWithValue("@field1", False)
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub vincular()
        Try
            fechar()
            abrir()
            sql = "UPDATE Funcionarios SET vinculo_Funcionario = @field1 WHERE id_Funcionario = " & FormMenu.TextBoxIdFunc.Text
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.Parameters.AddWithValue("@field1", True)
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub registrarEntrada()
        Try
            fechar()
            abrir()
            sql = "INSERT INTO RFuncionario (id_Funcionario, data_Entrada) VALUES (@id, @data)"
            cmdUser = New MySqlCommand(sql, conexao)
            With cmdUser
                .Parameters.AddWithValue("@id", FormMenu.TextBoxIdFunc.Text)
                .Parameters.AddWithValue("@data", New Date.Now)
            End With
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

    Sub registrarSaida()
        Try
            fechar()
            abrir()
            sql = "UPDATE RFuncionario SET data_Saida = @saida WHERE id_Funcionario = " & FormMenu.TextBoxIdFunc.Text
            cmdUser = New MySqlCommand(sql, conexao)
            cmdUser.Parameters.AddWithValue("@saida", New Date.Now)
            cmdUser.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
            MsgBox(ex.ToString)
        Finally
            fechar()
        End Try
    End Sub

End Module
