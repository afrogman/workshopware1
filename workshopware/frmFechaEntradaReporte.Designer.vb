<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFechaEntradaReporte
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFechaEntradaReporte))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSetFechaEntrada = New workshopware.DataSetFechaEntrada()
        Me.TablaConsultaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSetFechaEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TablaConsultaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSetFechaEntrada"
        ReportDataSource1.Value = Me.TablaConsultaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "workshopware.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(13, 13)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(789, 485)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSetFechaEntrada
        '
        Me.DataSetFechaEntrada.DataSetName = "DataSetFechaEntrada"
        Me.DataSetFechaEntrada.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TablaConsultaBindingSource
        '
        Me.TablaConsultaBindingSource.DataMember = "TablaConsulta"
        Me.TablaConsultaBindingSource.DataSource = Me.DataSetFechaEntrada
        '
        'frmFechaEntradaReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(814, 517)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.Name = "frmFechaEntradaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Workshopware - Reporte impreso fecha entrada"
        CType(Me.DataSetFechaEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TablaConsultaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TablaConsultaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetFechaEntrada As workshopware.DataSetFechaEntrada
End Class
