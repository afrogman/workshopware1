'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmFechaProgramada

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Boton para mostrar el rango de fechas de salida

        'Variables locales para las fechas
        Dim fechaI, fechaF As String
        'Se extrae la fecha de inicio de rango
        fechaI = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        'Se extrae la fecha de limite de rango
        fechaF = DateTimePicker2.Value.ToString("yyyy/MM/dd")
        'Procedimiento de conexion de la base de datods
        Call ConectarDB()
        'Se guarda la consulta general mostrando nombres alternos para los campos
        sql = "SELECT tblservicio.fechaprogramada as 'Fecha programada', tblcliente.nombres as 'Nombre cliente', tblcliente.apellidos as 'Apellidos cliente', tblequipo.marca as 'Marca equipo', tblequipo.modelo as 'Modelo equipo', tblequipo.serie as 'Serie equipo', tblservicio.saldo as 'Saldo del servicio', tblservicio.estado as 'Estado del servicio' FROM tblservicio INNER JOIN tblcliente ON tblservicio.idcliente = tblcliente.idcliente INNER JOIN tblequipo ON tblservicio.idequipo = tblequipo.idequipo WHERE tblservicio.fechaprogramada > '" & fechaI & "' AND tblservicio.fechaprogramada < '" & fechaF & "'"
        'Ejecuta la consulta SQL en la baes de datos con la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        'Guarda la data que va mostrar el DataGriedView
        datos = New DataSet
        'Va llenarse de los datos que tenga la tabla tblservicio
        adaptador.Fill(datos, "tblservicio")
        'Va recibir las tuplas de la tabla
        lista = datos.Tables("tblservicio").Rows.Count
        'Condicional para ver si se recibe un dato en la lista
        If (lista <> 0) Then
            'Le indica al DataGridView que son datos que vienen de una base de datos
            DataGridView1.DataSource = datos
            'Le indica al DataGridView que muestre lo datos de la tabla indicada
            DataGridView1.DataMember = "tblservicio"
            'Se cierra la conexion
            conexion.Close()
        Else
            MsgBox("No hay datos guardados en ese rango de fechas")
            conexion.Close()
        End If
    End Sub
End Class