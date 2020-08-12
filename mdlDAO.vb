Imports MySql.Data.MySqlClient
Imports System.IO
Module mdlDAO
    Public conexao As New MySqlConnection("SERVER=31.170.162.19;user id=triplice_admin; password=admin;database=triplice_PegasusMusic;")
    Public comandao As New MySqlCommand
    Public adaptador As New MySqlDataAdapter
    Public cmdUser As New MySqlCommand
    Public reader As MySqlDataReader
    Public sql As String
    Public dados As New DataTable
    Public dadosDS As New DataSet
    Public editando As Boolean

    Sub abrir()
        If conexao.State = 0 Then
            conexao.Open()
        End If
    End Sub

    Sub fechar()
        If conexao.State = 1 Then
            conexao.Close()
        End If
    End Sub

    Sub isNotEditavel()
        FormMenu.TextBoxNomeFunc.Enabled = False
        FormMenu.TextBoxNomeFunc.Enabled = False
        FormMenu.TextBoxApelidoFunc.Enabled = False
        FormMenu.MaskedTextBoxCPFFunc.Enabled = False
        FormMenu.MaskedTextBoxRGFunc.Enabled = False
        FormMenu.MaskedTextBoxNascimentoFunc.Enabled = False
        FormMenu.MaskedTextBoxCEL1Func.Enabled = False
        FormMenu.MaskedTextBoxCEL2Func.Enabled = False
        FormMenu.MaskedTextBoxTEL1Func.Enabled = False
        FormMenu.MaskedTextBoxTEL2Func.Enabled = False
        FormMenu.TextBoxEMAILFunc.Enabled = False
        FormMenu.MaskedTextBoxCEPFunc.Enabled = False
        FormMenu.TextBoxLogradouroFunc.Enabled = False
        FormMenu.TextBoxUFFunc.Enabled = False
        FormMenu.TextBoxCidadeFunc.Enabled = False
        FormMenu.TextBoxNUmENDFunc.Enabled = False
        FormMenu.TextBoxBairroFunc.Enabled = False
        FormMenu.TextBoxCompleFunc.Enabled = False
        FormMenu.TextBoxSalarioFunc.Enabled = False
        FormMenu.TextBoxComissaoFunc.Enabled = False
        FormMenu.TextBoxLoginFunc.Enabled = False
        FormMenu.TextBoxSenhaFunc.Enabled = False
        FormMenu.ComboBoxCargoFunc.Enabled = False
        FormMenu.ComboBoxBancoFunc.Enabled = False
        FormMenu.TextBoxContaBancoFunc.Enabled = False
        FormMenu.TextBoxAgenciaFunc.Enabled = False
        FormMenu.TextBoxOperacaoBancoFunc.Enabled = False
        FormMenu.ButtonAddImagem.Enabled = False
        FormMenu.SalvarToolStripMenuItem.Enabled = False
        FormMenu.DesvincularToolStripMenuItem.Enabled = False
        editando = False
    End Sub

    Sub isEditavel()
        FormMenu.TextBoxNomeFunc.Enabled = True
        FormMenu.TextBoxNomeFunc.Enabled = True
        FormMenu.TextBoxApelidoFunc.Enabled = True
        FormMenu.MaskedTextBoxCPFFunc.Enabled = True
        FormMenu.MaskedTextBoxRGFunc.Enabled = True
        FormMenu.MaskedTextBoxNascimentoFunc.Enabled = True
        FormMenu.MaskedTextBoxCEL1Func.Enabled = True
        FormMenu.MaskedTextBoxCEL2Func.Enabled = True
        FormMenu.MaskedTextBoxTEL1Func.Enabled = True
        FormMenu.MaskedTextBoxTEL2Func.Enabled = True
        FormMenu.TextBoxEMAILFunc.Enabled = True
        FormMenu.MaskedTextBoxCEPFunc.Enabled = True
        FormMenu.TextBoxLogradouroFunc.Enabled = True
        FormMenu.TextBoxUFFunc.Enabled = True
        FormMenu.TextBoxCidadeFunc.Enabled = True
        FormMenu.TextBoxNUmENDFunc.Enabled = True
        FormMenu.TextBoxBairroFunc.Enabled = True
        FormMenu.TextBoxCompleFunc.Enabled = True
        FormMenu.TextBoxSalarioFunc.Enabled = True
        FormMenu.TextBoxComissaoFunc.Enabled = True
        FormMenu.TextBoxLoginFunc.Enabled = True
        FormMenu.TextBoxSenhaFunc.Enabled = True
        FormMenu.ComboBoxCargoFunc.Enabled = True
        FormMenu.ComboBoxBancoFunc.Enabled = True
        FormMenu.TextBoxContaBancoFunc.Enabled = True
        FormMenu.TextBoxAgenciaFunc.Enabled = True
        FormMenu.TextBoxOperacaoBancoFunc.Enabled = True
        FormMenu.ButtonAddImagem.Enabled = True
        FormMenu.SalvarToolStripMenuItem.Enabled = True
        FormMenu.DesvincularToolStripMenuItem.Enabled = True
        editando = True
    End Sub

    Sub isEditableCliente()
        FormMenu.TextBoxNomeCLI.Enabled = True
        FormMenu.MaskedTextBoxCPFCli.Enabled = True
        FormMenu.MaskedTextBoxRGCli.Enabled = True
        FormMenu.MaskedTextBoxNascimentoCli.Enabled = True
        FormMenu.MaskedTextBoxCEPCLI.Enabled = True
        FormMenu.TextBoxLogradouroCLI.Enabled = True
        FormMenu.TextBoxBairroCli.Enabled = True
        FormMenu.TextBoxUfCli.Enabled = True
        FormMenu.TextBoxCidadeCLi.Enabled = True
        FormMenu.TextBoxComplementoCli.Enabled = True
        FormMenu.TextBoxNumCli.Enabled = True
        FormMenu.MaskedTextBoxCEL1Cli.Enabled = True
        FormMenu.MaskedTextBoxCEL2Cli.Enabled = True
        FormMenu.MaskedTextBoxTEL1Cli.Enabled = True
        FormMenu.MaskedTextBoxTEL2Cli.Enabled = True
        FormMenu.TextBoxEMAILCLI.Enabled = True
        FormMenu.SalvarToolStripMenuItem1.Enabled = True
        editando = True
    End Sub

    Sub isNotEditableCliente()
        FormMenu.TextBoxNomeCLI.Enabled = False
        FormMenu.MaskedTextBoxCPFCli.Enabled = False
        FormMenu.MaskedTextBoxRGCli.Enabled = False
        FormMenu.MaskedTextBoxNascimentoCli.Enabled = False
        FormMenu.MaskedTextBoxCEPCLI.Enabled = False
        FormMenu.TextBoxLogradouroCLI.Enabled = False
        FormMenu.TextBoxBairroCli.Enabled = False
        FormMenu.TextBoxUfCli.Enabled = False
        FormMenu.TextBoxCidadeCLi.Enabled = False
        FormMenu.TextBoxComplementoCli.Enabled = False
        FormMenu.TextBoxNumCli.Enabled = False
        FormMenu.MaskedTextBoxCEL1Cli.Enabled = False
        FormMenu.MaskedTextBoxCEL2Cli.Enabled = False
        FormMenu.MaskedTextBoxTEL1Cli.Enabled = False
        FormMenu.MaskedTextBoxTEL2Cli.Enabled = False
        FormMenu.TextBoxEMAILCLI.Enabled = False
        FormMenu.SalvarToolStripMenuItem1.Enabled = False
        editando = False
    End Sub

End Module
