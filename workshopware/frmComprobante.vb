'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient
'Importa las opciones para que funcion el Reporte
Imports Microsoft.Reporting.WinForms

Public Class frmComprobante

    Private Sub frmComprobante_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            'Se recibe el codigo o id del sercicio para generar el reporte impreso
            codServicio = frmServicio.MaskedTextBox1.Text

            'Refresca el reporte y lo carga con los nuevos datos
            Me.ReportViewer1.RefreshReport()
            'Se asigna la consulta que queremos ver en el reporte
            sql = "SELECT tblservicio.idservicio, tblcliente.nombres, tblcliente.apellidos, tblequipo.marca, tblequipo.modelo, tblequipo.serie, tblequipo.accesorios, tblequipo.observaciones, tblservicio.falla, tblservicio.reparacion, tblservicio.fechaentrada, tblservicio.fechasalida, tblservicio.pago, tblservicio.saldo, tblservicio.total, tbltecnico.nombres, tbltecnico.apellidos FROM tblcliente INNER JOIN tblequipo ON tblcliente.idcliente = tblequipo.idcliente INNER JOIN tblservicio ON tblcliente.idcliente = tblservicio.idcliente INNER JOIN tbltecnico ON tblservicio.idtecnico = tbltecnico.idtecnico WHERE tblservicio.idservicio = '" & codServicio & "'"


            'Realiza la conexion a la base de datos
            Call ConectarDB()

            adaptador = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conexion)
            datos = New DataSet
            adaptador.Fill(datos)
            'Intercambia el DataSet que se hizo, por el que tiene el resultado de la consulta SQL
            Dim Report As New ReportDataSource("DataSetComprobante", datos.Tables(0))
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(Report)
            Me.ReportViewer1.RefreshReport()
            conexion.Close()
        Catch ex As Exception
            'Muestra si hay algun error en la conexion
            MsgBox(ex.Message)
        End Try
    End Sub
End Class