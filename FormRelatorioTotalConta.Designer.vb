<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRelatorioTotalConta
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.TotalContaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New PegasusMusic.DataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Total_ContaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Total_ContaTableAdapter = New PegasusMusic.DataSet1TableAdapters.Total_ContaTableAdapter()
        Me.DataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TotalContaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.TotalContaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Total_ContaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalContaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TotalContaBindingSource
        '
        Me.TotalContaBindingSource.DataMember = "Total_Conta"
        Me.TotalContaBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.TotalContaBindingSource1
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "PegasusMusic.ReportTotalConta.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(655, 593)
        Me.ReportViewer1.TabIndex = 0
        '
        'Total_ContaBindingSource
        '
        Me.Total_ContaBindingSource.DataMember = "Total_Conta"
        Me.Total_ContaBindingSource.DataSource = Me.DataSet1
        '
        'Total_ContaTableAdapter
        '
        Me.Total_ContaTableAdapter.ClearBeforeFill = True
        '
        'DataSet1BindingSource
        '
        Me.DataSet1BindingSource.DataSource = Me.DataSet1
        Me.DataSet1BindingSource.Position = 0
        '
        'TotalContaBindingSource1
        '
        Me.TotalContaBindingSource1.DataMember = "Total_Conta"
        Me.TotalContaBindingSource1.DataSource = Me.DataSet1
        '
        'FormRelatorioTotalConta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 593)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FormRelatorioTotalConta"
        Me.Text = "Relatório"
        CType(Me.TotalContaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Total_ContaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalContaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Total_ContaBindingSource As BindingSource
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents Total_ContaTableAdapter As DataSet1TableAdapters.Total_ContaTableAdapter
    Friend WithEvents TotalContaBindingSource As BindingSource
    Friend WithEvents TotalContaBindingSource1 As BindingSource
    Friend WithEvents DataSet1BindingSource As BindingSource
End Class
