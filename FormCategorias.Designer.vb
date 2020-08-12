<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCategorias
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
        Me.SalvarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PesquisarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelCategoria = New System.Windows.Forms.Label()
        Me.GroupBoxCategoria = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComboBoxCategoria = New System.Windows.Forms.ComboBox()
        Me.LabelifCategoria = New System.Windows.Forms.Label()
        Me.LabelDescricao = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LabelMinEstoq = New System.Windows.Forms.Label()
        Me.TextBoxMinEstoq = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBoxCategoria.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel2.Size = New System.Drawing.Size(578, 38)
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
        Me.X.Location = New System.Drawing.Point(534, 0)
        Me.X.Margin = New System.Windows.Forms.Padding(0)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(44, 38)
        Me.X.TabIndex = 25
        Me.X.Text = "X"
        Me.X.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpçõesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(9, 9)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(67, 24)
        Me.MenuStrip1.TabIndex = 26
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpçõesToolStripMenuItem
        '
        Me.OpçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarToolStripMenuItem, Me.EditarToolStripMenuItem, Me.PesquisarTodosToolStripMenuItem})
        Me.OpçõesToolStripMenuItem.Name = "OpçõesToolStripMenuItem"
        Me.OpçõesToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.OpçõesToolStripMenuItem.Text = "Opções"
        '
        'SalvarToolStripMenuItem
        '
        Me.SalvarToolStripMenuItem.Enabled = False
        Me.SalvarToolStripMenuItem.Name = "SalvarToolStripMenuItem"
        Me.SalvarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SalvarToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SalvarToolStripMenuItem.Text = "Salvar"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Enabled = False
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'PesquisarTodosToolStripMenuItem
        '
        Me.PesquisarTodosToolStripMenuItem.Name = "PesquisarTodosToolStripMenuItem"
        Me.PesquisarTodosToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.PesquisarTodosToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.PesquisarTodosToolStripMenuItem.Text = "Pesquisar Todos"
        '
        'LabelCategoria
        '
        Me.LabelCategoria.AutoSize = True
        Me.LabelCategoria.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.LabelCategoria.Location = New System.Drawing.Point(13, 63)
        Me.LabelCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCategoria.Name = "LabelCategoria"
        Me.LabelCategoria.Size = New System.Drawing.Size(76, 25)
        Me.LabelCategoria.TabIndex = 5
        Me.LabelCategoria.Text = "Label1"
        '
        'GroupBoxCategoria
        '
        Me.GroupBoxCategoria.Controls.Add(Me.TextBoxMinEstoq)
        Me.GroupBoxCategoria.Controls.Add(Me.LabelMinEstoq)
        Me.GroupBoxCategoria.Controls.Add(Me.DataGridView1)
        Me.GroupBoxCategoria.Controls.Add(Me.ComboBoxCategoria)
        Me.GroupBoxCategoria.Controls.Add(Me.LabelifCategoria)
        Me.GroupBoxCategoria.Controls.Add(Me.LabelDescricao)
        Me.GroupBoxCategoria.Controls.Add(Me.TextBox1)
        Me.GroupBoxCategoria.Location = New System.Drawing.Point(12, 100)
        Me.GroupBoxCategoria.Name = "GroupBoxCategoria"
        Me.GroupBoxCategoria.Size = New System.Drawing.Size(549, 220)
        Me.GroupBoxCategoria.TabIndex = 6
        Me.GroupBoxCategoria.TabStop = False
        Me.GroupBoxCategoria.Text = "GroupBox1"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(263, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(264, 164)
        Me.DataGridView1.TabIndex = 4
        '
        'ComboBoxCategoria
        '
        Me.ComboBoxCategoria.FormattingEnabled = True
        Me.ComboBoxCategoria.Location = New System.Drawing.Point(41, 54)
        Me.ComboBoxCategoria.Name = "ComboBoxCategoria"
        Me.ComboBoxCategoria.Size = New System.Drawing.Size(174, 26)
        Me.ComboBoxCategoria.TabIndex = 3
        Me.ComboBoxCategoria.Visible = False
        '
        'LabelifCategoria
        '
        Me.LabelifCategoria.AutoSize = True
        Me.LabelifCategoria.Location = New System.Drawing.Point(38, 33)
        Me.LabelifCategoria.Name = "LabelifCategoria"
        Me.LabelifCategoria.Size = New System.Drawing.Size(78, 18)
        Me.LabelifCategoria.TabIndex = 2
        Me.LabelifCategoria.Text = "Categoria"
        Me.LabelifCategoria.Visible = False
        '
        'LabelDescricao
        '
        Me.LabelDescricao.AutoSize = True
        Me.LabelDescricao.Location = New System.Drawing.Point(38, 97)
        Me.LabelDescricao.Name = "LabelDescricao"
        Me.LabelDescricao.Size = New System.Drawing.Size(80, 18)
        Me.LabelDescricao.TabIndex = 1
        Me.LabelDescricao.Text = "Descrição"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(41, 118)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(174, 26)
        Me.TextBox1.TabIndex = 0
        '
        'LabelMinEstoq
        '
        Me.LabelMinEstoq.AutoSize = True
        Me.LabelMinEstoq.Location = New System.Drawing.Point(38, 157)
        Me.LabelMinEstoq.Name = "LabelMinEstoq"
        Me.LabelMinEstoq.Size = New System.Drawing.Size(142, 18)
        Me.LabelMinEstoq.TabIndex = 5
        Me.LabelMinEstoq.Text = "Mínimo de Estoque"
        '
        'TextBoxMinEstoq
        '
        Me.TextBoxMinEstoq.Location = New System.Drawing.Point(41, 178)
        Me.TextBoxMinEstoq.Name = "TextBoxMinEstoq"
        Me.TextBoxMinEstoq.Size = New System.Drawing.Size(75, 26)
        Me.TextBoxMinEstoq.TabIndex = 6
        '
        'FormCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 349)
        Me.Controls.Add(Me.GroupBoxCategoria)
        Me.Controls.Add(Me.LabelCategoria)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormCategorias"
        Me.Text = "FormCategorias"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBoxCategoria.ResumeLayout(False)
        Me.GroupBoxCategoria.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents X As Button
    Friend WithEvents LabelCategoria As Label
    Friend WithEvents GroupBoxCategoria As GroupBox
    Friend WithEvents ComboBoxCategoria As ComboBox
    Friend WithEvents LabelifCategoria As Label
    Friend WithEvents LabelDescricao As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalvarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PesquisarTodosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBoxMinEstoq As TextBox
    Friend WithEvents LabelMinEstoq As Label
End Class
