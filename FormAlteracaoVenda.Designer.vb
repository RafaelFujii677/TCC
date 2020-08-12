<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAlteracaoVenda
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.X = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalvarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcluirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxFormasPgmt = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DataGridViewFormaPagamentoPesquisaVenda = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxDescricaoFormaDePagamentoPesquisaVenda = New System.Windows.Forms.TextBox()
        Me.TextBoxDescontoFormaDePagamentoPesquisaVenda = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBoxFormasPgmt.SuspendLayout()
        CType(Me.DataGridViewFormaPagamentoPesquisaVenda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.X)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(577, 34)
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
        Me.X.Location = New System.Drawing.Point(537, 0)
        Me.X.Margin = New System.Windows.Forms.Padding(0)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(40, 34)
        Me.X.TabIndex = 25
        Me.X.Text = "X"
        Me.X.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpçõesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(5, 5)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(67, 24)
        Me.MenuStrip1.TabIndex = 26
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpçõesToolStripMenuItem
        '
        Me.OpçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.SalvarToolStripMenuItem, Me.ExcluirToolStripMenuItem})
        Me.OpçõesToolStripMenuItem.Name = "OpçõesToolStripMenuItem"
        Me.OpçõesToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.OpçõesToolStripMenuItem.Text = "Opções"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Enabled = False
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.EditarToolStripMenuItem.Text = "Atualizar"
        '
        'SalvarToolStripMenuItem
        '
        Me.SalvarToolStripMenuItem.Enabled = False
        Me.SalvarToolStripMenuItem.Name = "SalvarToolStripMenuItem"
        Me.SalvarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SalvarToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SalvarToolStripMenuItem.Text = "Salvar"
        '
        'ExcluirToolStripMenuItem
        '
        Me.ExcluirToolStripMenuItem.Enabled = False
        Me.ExcluirToolStripMenuItem.Name = "ExcluirToolStripMenuItem"
        Me.ExcluirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ExcluirToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ExcluirToolStripMenuItem.Text = "Excluir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label1"
        '
        'GroupBoxFormasPgmt
        '
        Me.GroupBoxFormasPgmt.Controls.Add(Me.Label4)
        Me.GroupBoxFormasPgmt.Controls.Add(Me.DataGridViewFormaPagamentoPesquisaVenda)
        Me.GroupBoxFormasPgmt.Controls.Add(Me.Label3)
        Me.GroupBoxFormasPgmt.Controls.Add(Me.Label2)
        Me.GroupBoxFormasPgmt.Controls.Add(Me.TextBoxDescricaoFormaDePagamentoPesquisaVenda)
        Me.GroupBoxFormasPgmt.Controls.Add(Me.TextBoxDescontoFormaDePagamentoPesquisaVenda)
        Me.GroupBoxFormasPgmt.Location = New System.Drawing.Point(17, 98)
        Me.GroupBoxFormasPgmt.Name = "GroupBoxFormasPgmt"
        Me.GroupBoxFormasPgmt.Size = New System.Drawing.Size(548, 251)
        Me.GroupBoxFormasPgmt.TabIndex = 6
        Me.GroupBoxFormasPgmt.TabStop = False
        Me.GroupBoxFormasPgmt.Text = "Formas de Pagamento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(86, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "%"
        '
        'DataGridViewFormaPagamentoPesquisaVenda
        '
        Me.DataGridViewFormaPagamentoPesquisaVenda.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewFormaPagamentoPesquisaVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewFormaPagamentoPesquisaVenda.Location = New System.Drawing.Point(224, 30)
        Me.DataGridViewFormaPagamentoPesquisaVenda.Name = "DataGridViewFormaPagamentoPesquisaVenda"
        Me.DataGridViewFormaPagamentoPesquisaVenda.Size = New System.Drawing.Size(307, 194)
        Me.DataGridViewFormaPagamentoPesquisaVenda.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Descrição"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Desconto"
        '
        'TextBoxDescricaoFormaDePagamentoPesquisaVenda
        '
        Me.TextBoxDescricaoFormaDePagamentoPesquisaVenda.Location = New System.Drawing.Point(36, 121)
        Me.TextBoxDescricaoFormaDePagamentoPesquisaVenda.Name = "TextBoxDescricaoFormaDePagamentoPesquisaVenda"
        Me.TextBoxDescricaoFormaDePagamentoPesquisaVenda.Size = New System.Drawing.Size(154, 26)
        Me.TextBoxDescricaoFormaDePagamentoPesquisaVenda.TabIndex = 1
        '
        'TextBoxDescontoFormaDePagamentoPesquisaVenda
        '
        Me.TextBoxDescontoFormaDePagamentoPesquisaVenda.Location = New System.Drawing.Point(36, 65)
        Me.TextBoxDescontoFormaDePagamentoPesquisaVenda.Name = "TextBoxDescontoFormaDePagamentoPesquisaVenda"
        Me.TextBoxDescontoFormaDePagamentoPesquisaVenda.Size = New System.Drawing.Size(42, 26)
        Me.TextBoxDescontoFormaDePagamentoPesquisaVenda.TabIndex = 0
        '
        'FormAlteracaoVenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 361)
        Me.Controls.Add(Me.GroupBoxFormasPgmt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormAlteracaoVenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAlteracaoVenda"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBoxFormasPgmt.ResumeLayout(False)
        Me.GroupBoxFormasPgmt.PerformLayout()
        CType(Me.DataGridViewFormaPagamentoPesquisaVenda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents X As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBoxFormasPgmt As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxDescricaoFormaDePagamentoPesquisaVenda As TextBox
    Friend WithEvents TextBoxDescontoFormaDePagamentoPesquisaVenda As TextBox
    Friend WithEvents OpçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalvarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridViewFormaPagamentoPesquisaVenda As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents ExcluirToolStripMenuItem As ToolStripMenuItem
End Class
