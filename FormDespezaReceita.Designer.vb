<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDespezaReceita
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
        Me.GroupBoxDespesa = New System.Windows.Forms.GroupBox()
        Me.TextBoxTextBoxValorDespesa = New System.Windows.Forms.TextBox()
        Me.TextBoxDescDespesa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxReceita = New System.Windows.Forms.GroupBox()
        Me.TextBoxValorReceita = New System.Windows.Forms.TextBox()
        Me.TextBoxDescReceita = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBoxDespesa.SuspendLayout()
        Me.GroupBoxReceita.SuspendLayout()
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
        Me.Panel2.Size = New System.Drawing.Size(571, 34)
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
        Me.X.Location = New System.Drawing.Point(531, 0)
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
        Me.MenuStrip1.Location = New System.Drawing.Point(6, 5)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(67, 24)
        Me.MenuStrip1.TabIndex = 26
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpçõesToolStripMenuItem
        '
        Me.OpçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarToolStripMenuItem})
        Me.OpçõesToolStripMenuItem.Name = "OpçõesToolStripMenuItem"
        Me.OpçõesToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.OpçõesToolStripMenuItem.Text = "Opções"
        '
        'SalvarToolStripMenuItem
        '
        Me.SalvarToolStripMenuItem.Name = "SalvarToolStripMenuItem"
        Me.SalvarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SalvarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SalvarToolStripMenuItem.Text = "Salvar"
        '
        'GroupBoxDespesa
        '
        Me.GroupBoxDespesa.Controls.Add(Me.TextBoxTextBoxValorDespesa)
        Me.GroupBoxDespesa.Controls.Add(Me.TextBoxDescDespesa)
        Me.GroupBoxDespesa.Controls.Add(Me.Label2)
        Me.GroupBoxDespesa.Controls.Add(Me.Label1)
        Me.GroupBoxDespesa.Location = New System.Drawing.Point(32, 72)
        Me.GroupBoxDespesa.Name = "GroupBoxDespesa"
        Me.GroupBoxDespesa.Size = New System.Drawing.Size(242, 161)
        Me.GroupBoxDespesa.TabIndex = 5
        Me.GroupBoxDespesa.TabStop = False
        Me.GroupBoxDespesa.Text = "Despesa"
        '
        'TextBoxTextBoxValorDespesa
        '
        Me.TextBoxTextBoxValorDespesa.Location = New System.Drawing.Point(9, 101)
        Me.TextBoxTextBoxValorDespesa.Name = "TextBoxTextBoxValorDespesa"
        Me.TextBoxTextBoxValorDespesa.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxTextBoxValorDespesa.TabIndex = 3
        '
        'TextBoxDescDespesa
        '
        Me.TextBoxDescDespesa.Location = New System.Drawing.Point(9, 52)
        Me.TextBoxDescDespesa.Name = "TextBoxDescDespesa"
        Me.TextBoxDescDespesa.Size = New System.Drawing.Size(227, 26)
        Me.TextBoxDescDespesa.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Valor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descrição"
        '
        'GroupBoxReceita
        '
        Me.GroupBoxReceita.Controls.Add(Me.TextBoxValorReceita)
        Me.GroupBoxReceita.Controls.Add(Me.TextBoxDescReceita)
        Me.GroupBoxReceita.Controls.Add(Me.Label4)
        Me.GroupBoxReceita.Controls.Add(Me.Label3)
        Me.GroupBoxReceita.Location = New System.Drawing.Point(303, 72)
        Me.GroupBoxReceita.Name = "GroupBoxReceita"
        Me.GroupBoxReceita.Size = New System.Drawing.Size(242, 161)
        Me.GroupBoxReceita.TabIndex = 6
        Me.GroupBoxReceita.TabStop = False
        Me.GroupBoxReceita.Text = "Receita"
        '
        'TextBoxValorReceita
        '
        Me.TextBoxValorReceita.Location = New System.Drawing.Point(9, 101)
        Me.TextBoxValorReceita.Name = "TextBoxValorReceita"
        Me.TextBoxValorReceita.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxValorReceita.TabIndex = 4
        '
        'TextBoxDescReceita
        '
        Me.TextBoxDescReceita.Location = New System.Drawing.Point(9, 52)
        Me.TextBoxDescReceita.Name = "TextBoxDescReceita"
        Me.TextBoxDescReceita.Size = New System.Drawing.Size(227, 26)
        Me.TextBoxDescReceita.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Valor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Descrição"
        '
        'FormDespezaReceita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 249)
        Me.Controls.Add(Me.GroupBoxReceita)
        Me.Controls.Add(Me.GroupBoxDespesa)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormDespezaReceita"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormDespezaReceita"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBoxDespesa.ResumeLayout(False)
        Me.GroupBoxDespesa.PerformLayout()
        Me.GroupBoxReceita.ResumeLayout(False)
        Me.GroupBoxReceita.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents X As Button
    Friend WithEvents GroupBoxDespesa As GroupBox
    Friend WithEvents TextBoxTextBoxValorDespesa As TextBox
    Friend WithEvents TextBoxDescDespesa As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBoxReceita As GroupBox
    Friend WithEvents TextBoxValorReceita As TextBox
    Friend WithEvents TextBoxDescReceita As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalvarToolStripMenuItem As ToolStripMenuItem
End Class
