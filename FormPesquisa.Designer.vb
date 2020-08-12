<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPesquisa
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.X = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PesquisarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.labelNomePesquisa = New System.Windows.Forms.Label()
        Me.GroupBoxFuncionarios = New System.Windows.Forms.GroupBox()
        Me.DGFuncionarios = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pesquisaNomeFuncionario = New System.Windows.Forms.TextBox()
        Me.pesquisaCPFfuncionario = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBoxClientes = New System.Windows.Forms.GroupBox()
        Me.pesquisaCpfCliente = New System.Windows.Forms.MaskedTextBox()
        Me.pesquisaNomeCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGClientes = New System.Windows.Forms.DataGridView()
        Me.GroupBoxPesquisaFornecedorAddProd = New System.Windows.Forms.GroupBox()
        Me.MaskedTextBoxcnpjFornPesquisa = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridViewFornPesquisa = New System.Windows.Forms.DataGridView()
        Me.LabelNomeFornPesquisa = New System.Windows.Forms.Label()
        Me.TextBoxNomeFornPesquisa = New System.Windows.Forms.TextBox()
        Me.GroupBoxProduto = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pesquisaFornProd = New System.Windows.Forms.TextBox()
        Me.pesquisaMarcaProd = New System.Windows.Forms.TextBox()
        Me.pesquisaNomeProd = New System.Windows.Forms.TextBox()
        Me.DataGridViewProduto = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBoxFuncionarios.SuspendLayout()
        CType(Me.DGFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxClientes.SuspendLayout()
        CType(Me.DGClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxPesquisaFornecedorAddProd.SuspendLayout()
        CType(Me.DataGridViewFornPesquisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxProduto.SuspendLayout()
        CType(Me.DataGridViewProduto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.X)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(834, 37)
        Me.Panel2.TabIndex = 4
        '
        'X
        '
        Me.X.Dock = System.Windows.Forms.DockStyle.Right
        Me.X.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.X.FlatAppearance.BorderSize = 0
        Me.X.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed
        Me.X.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.X.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.X.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.X.ForeColor = System.Drawing.Color.White
        Me.X.Location = New System.Drawing.Point(792, 0)
        Me.X.Margin = New System.Windows.Forms.Padding(0)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(42, 37)
        Me.X.TabIndex = 25
        Me.X.Text = "X"
        Me.X.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpõesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(7, 6)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(67, 24)
        Me.MenuStrip1.TabIndex = 26
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpõesToolStripMenuItem
        '
        Me.OpõesToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.OpõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PesquisarTodosToolStripMenuItem})
        Me.OpõesToolStripMenuItem.Name = "OpõesToolStripMenuItem"
        Me.OpõesToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.OpõesToolStripMenuItem.Text = "Opções"
        '
        'PesquisarTodosToolStripMenuItem
        '
        Me.PesquisarTodosToolStripMenuItem.Name = "PesquisarTodosToolStripMenuItem"
        Me.PesquisarTodosToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.PesquisarTodosToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.PesquisarTodosToolStripMenuItem.Text = "Pesquisar todos"
        '
        'labelNomePesquisa
        '
        Me.labelNomePesquisa.AutoSize = True
        Me.labelNomePesquisa.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelNomePesquisa.Location = New System.Drawing.Point(13, 51)
        Me.labelNomePesquisa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelNomePesquisa.Name = "labelNomePesquisa"
        Me.labelNomePesquisa.Size = New System.Drawing.Size(73, 24)
        Me.labelNomePesquisa.TabIndex = 5
        Me.labelNomePesquisa.Text = "Label1"
        '
        'GroupBoxFuncionarios
        '
        Me.GroupBoxFuncionarios.Controls.Add(Me.DGFuncionarios)
        Me.GroupBoxFuncionarios.Controls.Add(Me.Label2)
        Me.GroupBoxFuncionarios.Controls.Add(Me.Label1)
        Me.GroupBoxFuncionarios.Controls.Add(Me.pesquisaNomeFuncionario)
        Me.GroupBoxFuncionarios.Controls.Add(Me.pesquisaCPFfuncionario)
        Me.GroupBoxFuncionarios.Location = New System.Drawing.Point(17, 88)
        Me.GroupBoxFuncionarios.Name = "GroupBoxFuncionarios"
        Me.GroupBoxFuncionarios.Size = New System.Drawing.Size(802, 343)
        Me.GroupBoxFuncionarios.TabIndex = 6
        Me.GroupBoxFuncionarios.TabStop = False
        Me.GroupBoxFuncionarios.Text = "Funcionários"
        Me.GroupBoxFuncionarios.Visible = False
        '
        'DGFuncionarios
        '
        Me.DGFuncionarios.AllowUserToAddRows = False
        Me.DGFuncionarios.AllowUserToDeleteRows = False
        Me.DGFuncionarios.AllowUserToResizeColumns = False
        Me.DGFuncionarios.AllowUserToResizeRows = False
        Me.DGFuncionarios.BackgroundColor = System.Drawing.Color.White
        Me.DGFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGFuncionarios.Location = New System.Drawing.Point(253, 29)
        Me.DGFuncionarios.Name = "DGFuncionarios"
        Me.DGFuncionarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGFuncionarios.Size = New System.Drawing.Size(525, 298)
        Me.DGFuncionarios.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nome"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CPF"
        '
        'pesquisaNomeFuncionario
        '
        Me.pesquisaNomeFuncionario.Location = New System.Drawing.Point(22, 129)
        Me.pesquisaNomeFuncionario.Name = "pesquisaNomeFuncionario"
        Me.pesquisaNomeFuncionario.Size = New System.Drawing.Size(205, 26)
        Me.pesquisaNomeFuncionario.TabIndex = 1
        '
        'pesquisaCPFfuncionario
        '
        Me.pesquisaCPFfuncionario.Location = New System.Drawing.Point(21, 79)
        Me.pesquisaCPFfuncionario.Mask = "999,999,999-99"
        Me.pesquisaCPFfuncionario.Name = "pesquisaCPFfuncionario"
        Me.pesquisaCPFfuncionario.Size = New System.Drawing.Size(128, 26)
        Me.pesquisaCPFfuncionario.TabIndex = 0
        '
        'GroupBoxClientes
        '
        Me.GroupBoxClientes.Controls.Add(Me.pesquisaCpfCliente)
        Me.GroupBoxClientes.Controls.Add(Me.pesquisaNomeCliente)
        Me.GroupBoxClientes.Controls.Add(Me.Label4)
        Me.GroupBoxClientes.Controls.Add(Me.Label3)
        Me.GroupBoxClientes.Controls.Add(Me.DGClientes)
        Me.GroupBoxClientes.Location = New System.Drawing.Point(17, 88)
        Me.GroupBoxClientes.Name = "GroupBoxClientes"
        Me.GroupBoxClientes.Size = New System.Drawing.Size(802, 343)
        Me.GroupBoxClientes.TabIndex = 8
        Me.GroupBoxClientes.TabStop = False
        Me.GroupBoxClientes.Text = "Clientes"
        Me.GroupBoxClientes.Visible = False
        '
        'pesquisaCpfCliente
        '
        Me.pesquisaCpfCliente.Location = New System.Drawing.Point(22, 79)
        Me.pesquisaCpfCliente.Mask = "999,999,999-99"
        Me.pesquisaCpfCliente.Name = "pesquisaCpfCliente"
        Me.pesquisaCpfCliente.Size = New System.Drawing.Size(127, 26)
        Me.pesquisaCpfCliente.TabIndex = 4
        '
        'pesquisaNomeCliente
        '
        Me.pesquisaNomeCliente.Location = New System.Drawing.Point(24, 129)
        Me.pesquisaNomeCliente.Name = "pesquisaNomeCliente"
        Me.pesquisaNomeCliente.Size = New System.Drawing.Size(203, 26)
        Me.pesquisaNomeCliente.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "CPF"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nome"
        '
        'DGClientes
        '
        Me.DGClientes.AllowUserToAddRows = False
        Me.DGClientes.AllowUserToDeleteRows = False
        Me.DGClientes.AllowUserToResizeColumns = False
        Me.DGClientes.AllowUserToResizeRows = False
        Me.DGClientes.BackgroundColor = System.Drawing.Color.White
        Me.DGClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGClientes.Location = New System.Drawing.Point(253, 29)
        Me.DGClientes.Name = "DGClientes"
        Me.DGClientes.Size = New System.Drawing.Size(525, 298)
        Me.DGClientes.TabIndex = 0
        '
        'GroupBoxPesquisaFornecedorAddProd
        '
        Me.GroupBoxPesquisaFornecedorAddProd.Controls.Add(Me.MaskedTextBoxcnpjFornPesquisa)
        Me.GroupBoxPesquisaFornecedorAddProd.Controls.Add(Me.Label5)
        Me.GroupBoxPesquisaFornecedorAddProd.Controls.Add(Me.DataGridViewFornPesquisa)
        Me.GroupBoxPesquisaFornecedorAddProd.Controls.Add(Me.LabelNomeFornPesquisa)
        Me.GroupBoxPesquisaFornecedorAddProd.Controls.Add(Me.TextBoxNomeFornPesquisa)
        Me.GroupBoxPesquisaFornecedorAddProd.Location = New System.Drawing.Point(17, 88)
        Me.GroupBoxPesquisaFornecedorAddProd.Name = "GroupBoxPesquisaFornecedorAddProd"
        Me.GroupBoxPesquisaFornecedorAddProd.Size = New System.Drawing.Size(802, 343)
        Me.GroupBoxPesquisaFornecedorAddProd.TabIndex = 9
        Me.GroupBoxPesquisaFornecedorAddProd.TabStop = False
        Me.GroupBoxPesquisaFornecedorAddProd.Text = "Fornecedor"
        Me.GroupBoxPesquisaFornecedorAddProd.Visible = False
        '
        'MaskedTextBoxcnpjFornPesquisa
        '
        Me.MaskedTextBoxcnpjFornPesquisa.Location = New System.Drawing.Point(26, 104)
        Me.MaskedTextBoxcnpjFornPesquisa.Mask = "99,999,999/9999-99"
        Me.MaskedTextBoxcnpjFornPesquisa.Name = "MaskedTextBoxcnpjFornPesquisa"
        Me.MaskedTextBoxcnpjFornPesquisa.Size = New System.Drawing.Size(157, 26)
        Me.MaskedTextBoxcnpjFornPesquisa.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "CNPJ"
        '
        'DataGridViewFornPesquisa
        '
        Me.DataGridViewFornPesquisa.AllowUserToAddRows = False
        Me.DataGridViewFornPesquisa.AllowUserToDeleteRows = False
        Me.DataGridViewFornPesquisa.AllowUserToResizeColumns = False
        Me.DataGridViewFornPesquisa.AllowUserToResizeRows = False
        Me.DataGridViewFornPesquisa.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewFornPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewFornPesquisa.Location = New System.Drawing.Point(253, 29)
        Me.DataGridViewFornPesquisa.Name = "DataGridViewFornPesquisa"
        Me.DataGridViewFornPesquisa.Size = New System.Drawing.Size(525, 298)
        Me.DataGridViewFornPesquisa.TabIndex = 2
        '
        'LabelNomeFornPesquisa
        '
        Me.LabelNomeFornPesquisa.AutoSize = True
        Me.LabelNomeFornPesquisa.Location = New System.Drawing.Point(23, 33)
        Me.LabelNomeFornPesquisa.Name = "LabelNomeFornPesquisa"
        Me.LabelNomeFornPesquisa.Size = New System.Drawing.Size(50, 18)
        Me.LabelNomeFornPesquisa.TabIndex = 1
        Me.LabelNomeFornPesquisa.Text = "Nome"
        '
        'TextBoxNomeFornPesquisa
        '
        Me.TextBoxNomeFornPesquisa.Location = New System.Drawing.Point(26, 54)
        Me.TextBoxNomeFornPesquisa.Name = "TextBoxNomeFornPesquisa"
        Me.TextBoxNomeFornPesquisa.Size = New System.Drawing.Size(201, 26)
        Me.TextBoxNomeFornPesquisa.TabIndex = 0
        '
        'GroupBoxProduto
        '
        Me.GroupBoxProduto.Controls.Add(Me.Label8)
        Me.GroupBoxProduto.Controls.Add(Me.Label7)
        Me.GroupBoxProduto.Controls.Add(Me.Label6)
        Me.GroupBoxProduto.Controls.Add(Me.pesquisaFornProd)
        Me.GroupBoxProduto.Controls.Add(Me.pesquisaMarcaProd)
        Me.GroupBoxProduto.Controls.Add(Me.pesquisaNomeProd)
        Me.GroupBoxProduto.Controls.Add(Me.DataGridViewProduto)
        Me.GroupBoxProduto.Location = New System.Drawing.Point(17, 88)
        Me.GroupBoxProduto.Name = "GroupBoxProduto"
        Me.GroupBoxProduto.Size = New System.Drawing.Size(802, 343)
        Me.GroupBoxProduto.TabIndex = 6
        Me.GroupBoxProduto.TabStop = False
        Me.GroupBoxProduto.Text = "Produto"
        Me.GroupBoxProduto.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 18)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Fornecedor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 18)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Marca"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 18)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Nome"
        '
        'pesquisaFornProd
        '
        Me.pesquisaFornProd.Location = New System.Drawing.Point(27, 161)
        Me.pesquisaFornProd.Name = "pesquisaFornProd"
        Me.pesquisaFornProd.Size = New System.Drawing.Size(156, 26)
        Me.pesquisaFornProd.TabIndex = 3
        '
        'pesquisaMarcaProd
        '
        Me.pesquisaMarcaProd.Location = New System.Drawing.Point(27, 111)
        Me.pesquisaMarcaProd.Name = "pesquisaMarcaProd"
        Me.pesquisaMarcaProd.Size = New System.Drawing.Size(157, 26)
        Me.pesquisaMarcaProd.TabIndex = 2
        '
        'pesquisaNomeProd
        '
        Me.pesquisaNomeProd.Location = New System.Drawing.Point(27, 61)
        Me.pesquisaNomeProd.Name = "pesquisaNomeProd"
        Me.pesquisaNomeProd.Size = New System.Drawing.Size(156, 26)
        Me.pesquisaNomeProd.TabIndex = 1
        '
        'DataGridViewProduto
        '
        Me.DataGridViewProduto.AllowUserToAddRows = False
        Me.DataGridViewProduto.AllowUserToDeleteRows = False
        Me.DataGridViewProduto.AllowUserToResizeColumns = False
        Me.DataGridViewProduto.AllowUserToResizeRows = False
        Me.DataGridViewProduto.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProduto.Location = New System.Drawing.Point(253, 29)
        Me.DataGridViewProduto.Name = "DataGridViewProduto"
        Me.DataGridViewProduto.Size = New System.Drawing.Size(525, 298)
        Me.DataGridViewProduto.TabIndex = 0
        '
        'FormPesquisa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 446)
        Me.Controls.Add(Me.labelNomePesquisa)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBoxProduto)
        Me.Controls.Add(Me.GroupBoxPesquisaFornecedorAddProd)
        Me.Controls.Add(Me.GroupBoxClientes)
        Me.Controls.Add(Me.GroupBoxFuncionarios)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormPesquisa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormPesquisa"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBoxFuncionarios.ResumeLayout(False)
        Me.GroupBoxFuncionarios.PerformLayout()
        CType(Me.DGFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxClientes.ResumeLayout(False)
        Me.GroupBoxClientes.PerformLayout()
        CType(Me.DGClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxPesquisaFornecedorAddProd.ResumeLayout(False)
        Me.GroupBoxPesquisaFornecedorAddProd.PerformLayout()
        CType(Me.DataGridViewFornPesquisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxProduto.ResumeLayout(False)
        Me.GroupBoxProduto.PerformLayout()
        CType(Me.DataGridViewProduto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents X As Button
    Friend WithEvents labelNomePesquisa As Label
    Friend WithEvents GroupBoxFuncionarios As GroupBox
    Friend WithEvents pesquisaNomeFuncionario As TextBox
    Friend WithEvents pesquisaCPFfuncionario As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DGFuncionarios As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PesquisarTodosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBoxClientes As GroupBox
    Friend WithEvents pesquisaCpfCliente As MaskedTextBox
    Friend WithEvents pesquisaNomeCliente As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DGClientes As DataGridView
    Friend WithEvents GroupBoxPesquisaFornecedorAddProd As GroupBox
    Friend WithEvents MaskedTextBoxcnpjFornPesquisa As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridViewFornPesquisa As DataGridView
    Friend WithEvents LabelNomeFornPesquisa As Label
    Friend WithEvents TextBoxNomeFornPesquisa As TextBox
    Friend WithEvents GroupBoxProduto As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pesquisaFornProd As TextBox
    Friend WithEvents pesquisaMarcaProd As TextBox
    Friend WithEvents pesquisaNomeProd As TextBox
    Friend WithEvents DataGridViewProduto As DataGridView
End Class
