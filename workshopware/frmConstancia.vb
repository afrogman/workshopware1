'Importe de la libreria de referencia MYSQL
Imports MySql.Data.MySqlClient
'Importe de las opciones para que funcione el reporte
Imports Microsoft.Reporting.WinForms

Public Class frmConstancia

    Private Sub frmConstancia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            'Se recibe el codigo o id del servicio para generar el reporte impreso
            codServicio = frmServicio.MaskedTextBox1.Text
            'Refresca el reporte
            Me.ReportViewer1.RefreshReport()
            'Se asigna la consulta que se quiere visualizar
            sql = "SELECT tblservicio.idservicio, tblcliente.nombres, tblcliente.apellidos, tblequipo.marca, tblequipo.modelo, tblequipo.serie, tblequipo.accesorios, tblequipo.observaciones, tblservicio.falla, tblservicio.reparacion,  DATE_FORMAT(tblservicio.fechaentrada, '%y-%m-%d') as 'fechaentrada', DATE_FORMAT(tblservicio.fechasalida, '%y-%m-%d') as 'fechasalida', tblservicio.pago, tblservicio.saldo, tblservicio.total, tbltecnico.nombres as 'nombrest', tbltecnico.apellidos as 'apellidost' FROM tblcliente  INNER JOIN tblequipo ON tblcliente.idcliente = tblequipo.idcliente INNER JOIN tblservicio ON tblcliente.idcliente = tblservicio.idcliente INNER JOIN tbltecnico ON tblservicio.idtecnico = tbltecnico.idtecnico WHERE tblservicio.idservicio = '" & codServicio & "'"

            'Se hace la conexion a la base de datos
            Call ConectarDB()

            adaptador = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conexion)
            datos = New DataSet
            adaptador.Fill(datos)
            Dim report As New ReportDataSource("dsconstancia", datos.Tables(0))
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(report)
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class