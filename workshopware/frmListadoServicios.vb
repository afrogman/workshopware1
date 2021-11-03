'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmListadoServicios

    Private Sub frmListadoServicios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Procedimiento de conexion de la base de datods
        Call ConectarDB()

        'Se guarda la consulta general mostrando nombres alternos para los campos
        sql = "SELECT idservicio as 'Codigo servicio', falla as 'Falla equipo', reparacion as 'Reparacion equipo', fechaentrada as 'Fecha entrada', fechasalida as 'Fecha salida', pago as 'Pago', saldo as 'Saldo', total as 'Total', estado as 'Estado' FROM tblservicio"

        'Ejecuta la consulta SQL en la baes de datos con la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)

        datos = New DataSet

        'Va llenarse de los datos que tenga la tabla tbltecnico
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
            'Indica si no hay guardado algun dato guardado
            MsgBox("No hay datos guardados aun")
            'Cierra la conexion
            conexion.Close()
        End If
    End Sub
End Class