'Importe de la libreria de referencia MYSQL
Imports MySql.Data.MySqlClient
'Importe de las opciones para que funcione el reporte
Imports Microsoft.Reporting.WinForms

Public Class frmFechaSalidaReporte
    'Variables locales para las fechas
    Dim fechaI, fechaF As String

    Private Sub frmFechaSalidaReporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            'Se extrae la fecha de inicio de rango
            fechaI = frmFechaSalida.DateTimePicker1.Value.ToString("yyyy/MM/dd")
            'Se extrae la fecha de limite de rango
            fechaF = frmFechaSalida.DateTimePicker2.Value.ToString("yyyy/MM/dd")

            'Refresca el reporte
            Me.ReportViewer1.RefreshReport()
            'Se asigna la consulta que se quiere visualizar
            sql = "SELECT DATE_FORMAT(tblservicio.fechasalida, '%d-%m-%y') as 'fechasalida', tblcliente.nombres, tblcliente.apellidos, tblequipo.marca, tblequipo.modelo, tblequipo.serie, tblservicio.total, tblservicio.estado FROM tblservicio INNER JOIN tblcliente ON tblservicio.idcliente = tblcliente.idcliente INNER JOIN tblequipo ON tblservicio.idequipo = tblequipo.idequipo WHERE tblservicio.fechasalida > '" & fechaI & "' AND tblservicio.fechasalida < '" & fechaF & "'"

            'Se hace la conexion a la base de datos
            Call ConectarDB()

            adaptador = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conexion)
            datos = New DataSet
            adaptador.Fill(datos)
            Dim report As New ReportDataSource("DataSetFechaSalida", datos.Tables(0))
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(report)
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class