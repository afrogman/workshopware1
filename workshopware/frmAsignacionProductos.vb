'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmAsignacionProductos

    Private Sub frmAsignacionProductos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Se realiza la conexion a la base de datos
        Call ConectarDB()
        'Se guarda la cadena SQL que se quiere consultar
        sql = "SELECT * FROM tblproducto"
        'Se envia la consulta y la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        datos = New DataSet
        'Se selecciona la tabla que es va mostrar
        datos.Tables.Add("tblproducto")
        'Se indica que se va llenar con el resultado de la consulta
        adaptador.Fill(datos.Tables("tblproducto"))
        ComboBox1.DataSource = datos.Tables("tblproducto")
        'Se indica el campo que va aparecer
        ComboBox1.DisplayMember = "nombre"
        'se cierra la conexion
        conexion.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Variable para obtener el dato seleccionado del Combobox
        Dim nomProd As String
        Try
            'Se captura el nombre del producto que tiene seleccionado el combobox1
            nomProd = ComboBox1.Text
            'Procedimiento de conexion de la baes de datos
            ConectarDB()
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nombre
            If (nomProd <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblproducto WHERE nombre = '" & nomProd & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblproducto")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblproducto").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de ningun producto")
            End If
            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then
                'Recibir el ID del producto seleccionado
                codProducto = datos.Tables("tblproducto").Rows(0).Item("idproducto")
                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox4.Text = datos.Tables("tblproducto").Rows(0).Item("nombre")
                RichTextBox1.Text = datos.Tables("tblproducto").Rows(0).Item("descripcion")
                TextBox5.Text = datos.Tables("tblproducto").Rows(0).Item("marca")
                TextBox6.Text = datos.Tables("tblproducto").Rows(0).Item("modelo")
                TextBox7.Text = datos.Tables("tblproducto").Rows(0).Item("serie")
                TextBox8.Text = datos.Tables("tblproducto").Rows(0).Item("cantidad")
                TextBox3.Text = datos.Tables("tblproducto").Rows(0).Item("pventa")
                'Se cierra la conexion
                conexion.Close()
            Else
                'Indica si hay o no hay productos con el codigo que se inidca o nombre
                MsgBox("No se encontro ningun producto con ese nombre")
                'Se cierra la conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Indica si hubo algun problema en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Variables locales para la existencia que hay en la BD y la cantidad que quieren despachar
        Dim existencia, cantidad As Integer
        'Precio de venta y el total
        Dim precioventa, total As Double
        'Extraer la existencia disponible del productos
        existencia = Val(TextBox8.Text)
        'Extraer la cantidad que quieren despachar
        cantidad = Val(TextBox2.Text)
        'Extraer el precio de venta de la bd
        precioventa = Val(TextBox3.Text)
        'Evaluar si se tienen las existencias necesarias del producto
        If (cantidad > existencia) Then
            'Indicar que no se puede cubrir la existencia
            MsgBox("No se puede despachar la cantidad que se indica, no se cubren las existencias")
        Else
            'se calcula el total a pagar
            total = precioventa * cantidad
            'se muestra cuando se va pagar
            TextBox9.Text = total
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Variables locales para la existencia que hay en la BD y la cantidad que quieren despachar
        Dim existencia, cantidad As Integer
        'Extraer la existencia disponible del productos
        existencia = Val(TextBox8.Text)
        'Extraer la cantidad que quieren despachar
        cantidad = Val(TextBox2.Text)
        'Evaluar si se tienen las existencias necesarias del producto
        If (cantidad > existencia) Then
            'Indicar que no se puede cubrir la existencia
            MsgBox("No se puede despachar la cantidad que se indica, no se cubren las existencias")
        Else
            'Se guarda el producto en la tabla intermedia
            Call GuardarProducto()
            'Se muestran los productos asignados
            Call MostrarProductos()
            'Se muestra el total a pagar
            Call totalProducto()
            'Habilitar el boton de edicion
            frmServicio.Button10.Enabled = True
        End If
    End Sub

    'Procedimiento para guardar el producto
    Sub GuardarProducto()
        'Boton de guardado de productos en el servicio
        'Variables para boton de guardado
        Dim idproducto, idservicio, cantidad As Integer
        Dim precioventa, total As Double
        Dim nombreproducto As String
        Try
            'codigo del producto
            idproducto = codProducto
            'codigo del servicio
            idservicio = codServicio
            'precio de venta
            precioventa = Val(TextBox3.Text)
            'nombre del producto
            nombreproducto = TextBox4.Text
            'la cantidad que quiere el cliente
            cantidad = Val(TextBox2.Text)
            'total de la seleccion de este producto
            total = Val(TextBox9.Text)
            Try
                'Se llama al procedimiento que hace y abre la conexion
                Call ConectarDB()
                'Linea de codigo que va guardar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("INSERT INTO tblasignacionproducto (idasignacion, idproducto, nombreproducto, idservicio, precioventa, cantidad, total)" & Chr(13) &
                                            "VALUES(@idasignacion,@idproducto,@nombreproducto,@idservicio,@precioventa,@cantidad,@total)", conexion)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@idasignacion", 0)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@nombreproducto", nombreproducto)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@idproducto", idproducto)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@idservicio", idservicio)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@precioventa", precioventa)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@cantidad", cantidad)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@total", total)
                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
                'Indico que se realizo exitosamente el guardado
                MsgBox("Los datos del producto fueron guardados exitosamente!")
                'Procedimiento que actualiza la existencia de un producto
                Call ActualizarExistencia()
                'Procedimiento para actualizar los montos
                Call ActualizarMonto()
                'Limpieza de controles
                TextBox4.Clear()
                RichTextBox1.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox3.Clear()
                TextBox2.Clear()
                TextBox9.Clear()
                'Se cierra la conexion
                conexion.Close()
            Catch ex As Exception
                'Mensaje para indicar que no se tuvo exito con la conexion
                MsgBox(ex.Message)
                'Se cierra la conexion
                conexion.Close()
            End Try
        Catch ex As Exception
            'Indica si hubo algun error en la ejecusion del programa
            MsgBox(ex.Message)
        End Try
    End Sub

    'Procedimiento para mostrar el contenido de la tabla con los productos asignados
    Sub MostrarProductos()
        'Procedimiento de conexion de la base de datods
        Call ConectarDB()

        'Se guarda la consulta general mostrando nombres alternos para los campos
        sql = "SELECT idproducto as 'Codigo Producto', nombreproducto as 'Producto', precioventa as 'Precio Venta', cantidad as 'Cantidad', total as 'Total' FROM tblasignacionproducto WHERE idservicio =  '" & codServicio & "'"

        'Ejecuta la consulta SQL en la baes de datos con la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)

        datos = New DataSet

        'Va llenarse de los datos que tenga la tabla tbltecnico
        adaptador.Fill(datos, "tblasignacionproducto")

        'Va recibir las tuplas de la tabla
        lista = datos.Tables("tblasignacionproducto").Rows.Count

        'Condicional para ver si se recibe un dato en la lista
        If (lista <> 0) Then
            'Le indica al DataGridView que son datos que vienen de una base de datos
            DataGridView1.DataSource = datos
            'Le indica al DataGridView que muestre lo datos de la tabla indicada
            DataGridView1.DataMember = "tblasignacionproducto"
            'Se cierra la conexion
            conexion.Close()
        Else
            MsgBox("No hay datos guardados aun")
            conexion.Close()
        End If
    End Sub

    'Procedimiento ActualizarCantidad
    Sub ActualizarExistencia()
        'Actualizacion de la existencia de productos

        'Variables para boton de guardado
        Dim existencia, cantidad, diferencia As Integer
        Try
            'Se obtiene la cantidad que se va despachar de producto
            cantidad = Val(TextBox2.Text)
            existencia = Val(TextBox8.Text)
            'Se obtiene la existencia que queda
            diferencia = existencia - cantidad
            Try
                'Linea de codigo que va actualizar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("UPDATE tblproducto SET cantidad = '" & diferencia & "'" & Chr(13) &
                                            "WHERE idproducto = '" & codProducto & "'", conexion)
                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
            Catch ex As Exception
                'Mensaje para indicar que no se tuvo exito con la conexion
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            'Indica si hay algun error en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    'Procedimiento para calcular el total de producto a pagar
    Sub totalProducto()
        'Procedimiento de conexion de la base de datods
        Call ConectarDB()
        'Se guarda la consulta general mostrando nombres alternos para los campos
        sql = "SELECT sum(precioventa) as 'Total Productos' FROM tblasignacionproducto WHERE idservicio =  '" & codServicio & "'"
        'Ejecuta la consulta SQL en la baes de datos con la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        'Guarda los datos que se van a mostrar en el dataGridview2 oculto
        datos = New DataSet
        'Va llenarse de los datos que tenga la tabla tbltecnico
        adaptador.Fill(datos, "tblasignacionproducto")
        'Va recibir las tuplas de la tabla
        lista = datos.Tables("tblasignacionproducto").Rows.Count
        'Condicional para ver si se recibe un dato en la lista
        If (lista <> 0) Then
            'Le indica al DataGridView que son datos que vienen de una base de datos
            DataGridView2.DataSource = datos
            'Le indica al DataGridView que muestre lo datos de la tabla indicada
            DataGridView2.DataMember = "tblasignacionproducto"
            'Extraer el total del DataGridView
            totProd = DataGridView2.Rows(0).Cells(0).Value
            'Se cierra la conexion
            conexion.Close()
            'Se muestra el total en pantalla
            TextBox10.Text = totProd
        Else
            'Indica queno hay datos guardados
            MsgBox("No hay datos guardados aun")
            'Se cierra la conexion
            conexion.Close()
        End If
    End Sub

    'Procedimiento ActualizarCantidad
    Sub ActualizarMonto()
        'Actualizacion del monto a pagar
        'Variables para actualizar
        Dim saldo, subtotal, total As Double
        Try
            'Se obtiene el saldo del formulario de servicios
            saldo = Val(frmServicio.TextBox7.Text)
            'Se obtiene el dato del subtotal de los productos
            subtotal = Val(TextBox9.Text)
            'Se obtiene el dato actual del total para actualizar
            total = saldo + subtotal
            Try
                'Linea de codigo que va actualizar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("UPDATE tblservicio SET total = '" & total & "'" & Chr(13) &
                                            "WHERE idservicio = '" & codServicio & "'", conexion)
                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
                'Se actualiza el dato en el formulario de servicios
                frmServicio.TextBox7.Text = total
            Catch ex As Exception
                'Mensaje para indicar que no se tuvo exito con la conexion
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            'Indica si hubo algun error en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub
End Class