<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprobante
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComprobante))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tblequipoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetComprobante = New workshopware.DataSetComprobante()
        Me.tblclienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tblservicioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbltecnicoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.tblequipoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblclienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblservicioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbltecnicoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "EquipoDataSet"
        ReportDataSource1.Value = Me.tblequipoBindingSource
        ReportDataSource2.Name = "ClienteDataSet"
        ReportDataSource2.Value = Me.tblclienteBindingSource
        ReportDataSource3.Name = "ServicioDataSet"
        ReportDataSource3.Value = Me.tblservicioBindingSource
        ReportDataSource4.Name = "TecnicoDataSet"
        ReportDataSource4.Value = Me.tbltecnicoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "workshopware.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(829, 361)
        Me.ReportViewer1.TabIndex = 0
        '
        'tblequipoBindingSource
        '
        Me.tblequipoBindingSource.DataMember = "tblequipo"
        Me.tblequipoBindingSource.DataSource = Me.DataSetComprobante
        '
        'DataSetComprobante
        '
        Me.DataSetComprobante.DataSetName = "DataSetComprobante"
        Me.DataSetComprobante.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tblclienteBindingSource
        '
        Me.tblclienteBindingSource.DataMember = "tblcliente"
        Me.tblclienteBindingSource.DataSource = Me.DataSetComprobante
        '
        'tblservicioBindingSource
        '
        Me.tblservicioBindingSource.DataMember = "tblservicio"
        Me.tblservicioBindingSource.DataSource = Me.DataSetComprobante
        '
        'tbltecnicoBindingSource
        '
        Me.tbltecnicoBindingSource.DataMember = "tbltecnico"
        Me.tbltecnicoBindingSource.DataSource = Me.DataSetComprobante
        '
        'frmComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 385)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1, 1)
        Me.Name = "frmComprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Workshopware - Comprobante de entrega"
        CType(Me.tblequipoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblclienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblservicioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbltecnicoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblequipoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetComprobante As workshopware.DataSetComprobante
    Friend WithEvents tblclienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tblservicioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tbltecnicoBindingSource As System.Windows.Forms.BindingSource
End Class
