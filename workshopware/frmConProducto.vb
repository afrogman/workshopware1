'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmConProducto

    Private Sub frmConProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Procedimiento de conexion de la base de datods
        Call ConectarDB()

        'Se guarda la consulta general mostrando nombres alternos para los campos
        sql = "SELECT tblproducto.idproducto as 'Codigo', tblproducto.nombre as 'Nombre', tblproducto.descripcion as 'Descripcion', tblproducto.marca as 'Marca', tblproducto.modelo as 'Modelo', tblproducto.serie as 'Serie', tblproducto.cantidad as 'Cantidad', tblproducto.pcosto as 'Precio Costo', tblproducto.pventa as 'Precio Venta', tblproveedor.nombre as 'Proveedor' FROM(tblproducto) INNER JOIN tblproveedor ON tblproducto.idproveedor = tblproveedor.idproveedor"

        'Ejecuta la consulta SQL en la baes de datos con la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)

        datos = New DataSet

        'Va llenarse de los datos que tenga la tabla tbltecnico
        adaptador.Fill(datos, "tblproducto")

        'Va recibir las tuplas de la tabla
        lista = datos.Tables("tblproducto").Rows.Count

        'Condicional para ver si se recibe un dato en la lista
        If (lista <> 0) Then
            'Le indica al DataGridView que son datos que vienen de una base de datos
            DataGridView1.DataSource = datos
            'Le indica al DataGridView que muestre lo datos de la tabla indicada
            DataGridView1.DataMember = "tblproducto"
            'Se cierra la conexion
            conexion.Close()
        Else
            MsgBox("No hay datos guardados aun")
            conexion.Close()
        End If
    End Sub
End Class