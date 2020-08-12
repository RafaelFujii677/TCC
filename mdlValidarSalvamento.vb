Module mdlValidarSalvamento
    Public Function validarSalvamento() As Boolean
        If FormMenu.TextBoxNomeFunc.Text = "" Then
            FormMenu.TextBoxNomeFunc.Focus()
            MsgBox("O campo 'Nome' não pode estar vazio!")
            Return False
        ElseIf FormMenu.MaskedTextBoxCPFFunc.Text = "   .   .   -" Then
            FormMenu.MaskedTextBoxCPFFunc.Focus()
            MsgBox("O campo 'CPF' não pode estar vazio!")
            Return False
        ElseIf FormMenu.TextBoxApelidoFunc.Text = "" Then
            FormMenu.TextBoxApelidoFunc.Focus()
            MsgBox("O campo 'Apelido' não pode estar vazio!")
            Return False
        ElseIf FormMenu.MaskedTextBoxRGFunc.Text = "  .   .   -" Then
            FormMenu.MaskedTextBoxRGFunc.Focus()
            MsgBox("O campo 'RG' não pode estar vazio!")
            Return False
        ElseIf FormMenu.MaskedTextBoxNascimentoFunc.Text = "  /  /" Then
            FormMenu.MaskedTextBoxNascimentoFunc.Focus()
            MsgBox("O campo 'Data de Nascimento' não pode estar vazio!")
            Return False
        ElseIf FormMenu.temFoto = False Then
            FormMenu.ButtonAddImagem.Focus()
            MsgBox("O campo 'Foto' não pode estar vazio!")
            Return False
        ElseIf FormMenu.TextBoxLoginFunc.Text = "" Then
            FormMenu.TextBoxLoginFunc.Focus()
            MsgBox("O campo 'Usuário' não pode estar vazio!")
            Return False
        ElseIf FormMenu.TextBoxSenhaFunc.Text = "" Then
            FormMenu.TextBoxSenhaFunc.Focus()
            MsgBox("O campo 'Senha' não pode estar vazio!")
            Return False
        ElseIf FormMenu.ComboBoxCargoFunc.Text = "" Then
            FormMenu.ComboBoxCargoFunc.Focus()
            MsgBox("O campo 'Cargo' não pode estar vazio!")
            Return False
        Else
            Return True
        End If

    End Function
End Module
