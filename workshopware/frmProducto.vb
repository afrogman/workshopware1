'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmProducto

    Private Sub frmProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Se realiza la conexion a la base de datos
        Call ConectarDB()
        'Se guarda la cadena SQL que se quiere consultar
        sql = "SELECT * FROM tblproveedor"
        'Se envia la consulta y la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        datos = New DataSet
        'Se selecciona la tabla que es va mostrar
        datos.Tables.Add("tblproveedor")
        'Se indica que se va llenar con el resultado de la consulta
        adaptador.Fill(datos.Tables("tblproveedor"))
        ComboBox1.DataSource = datos.Tables("tblproveedor")
        'Se indica el campo que va aparecer
        ComboBox1.DisplayMember = "nombre"
        'se cierra la conexion
        conexion.Close()
    End Sub
    
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Variable para obtener el dato seleccionado del Combobox
        Dim nomProv As String
        Try
            'Se captura el nombre del proveedor que tiene seleccionado el combobox1
            nomProv = ComboBox1.Text
            'Procedimiento de conexion de la baes de datos
            ConectarDB()
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nombre
            If (nomProv <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblproveedor WHERE nombre = '" & nomProv & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblproveedor")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblproveedor").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de proveedor")
            End If
            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then
                'Recibir el ID del proveedor seleccionado
                codProv = datos.Tables("tblproveedor").Rows(0).Item("idproveedor")
                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox1.Text = datos.Tables("tblproveedor").Rows(0).Item("idproveedor")
                TextBox2.Text = datos.Tables("tblproveedor").Rows(0).Item("nombreencargado")
                'Hace enfoque para que se llenen los datos del producto
                TextBox3.Focus()
                'Se cierra la conexion
                conexion.Close()
            Else
                'Se indica si no se encontro ningun proveedor
                MsgBox("No se encontro ningun proveedor con ese nombre")
                'Se cierra la conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Indica si hay algun error en la ejecusion.
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Boton de limpieza de controles

        'Se habilita el Textbox3
        TextBox3.Enabled = True
        'Se inhabilita el boton de modificacion
        Button6.Enabled = False
        'Se inhabilita el boton de eliminar
        Button7.Enabled = False
        'Se habilita el boton de guardar
        Button3.Enabled = True
        'Limpieza de controles
        TextBox3.Clear()
        TextBox4.Clear()
        RichTextBox1.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox3.Focus()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Boton de guardado de productos

        'Variables para boton de guardado
        Dim nombreprod, descrip, marca, modelo, serie As String
        Dim idprod, cantidad, idprov As Integer
        Dim pcosto, pventa As Double
        Try
            'Codigo del producto
            idprod = TextBox3.Text
            'Nombre del producto
            nombreprod = TextBox4.Text
            'Descripcion del producto
            descrip = RichTextBox1.Text
            'Marca del producto
            marca = TextBox5.Text
            'Modelo del producto
            modelo = TextBox6.Text
            'Serie del producto
            serie = TextBox7.Text
            'Cantidad o existencia del producto
            cantidad = TextBox8.Text
            'Precio de costo
            pcosto = Val(TextBox9.Text)
            'Precio de venta
            pventa = Val(TextBox10.Text)
            'Codigo del proveedor, obtenido de la llave foranea
            idprov = codProv
            Try
                'Se llama al procedimiento que hace y abre la conexion
                Call ConectarDB()
                'Linea de codigo que va guardar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("INSERT INTO tblproducto (idproducto, nombre, descripcion, marca, modelo, serie, cantidad, pcosto, pventa, idproveedor)" & Chr(13) &
                                            "VALUES(@codigo,@nombre,@descripcion,@dmarca,@modelo,@serie,@cantidad,@pcosto,@pventa,@idproveedor)", conexion)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@codigo", idprod)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@nombre", nombreprod)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@descripcion", descrip)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@dmarca", marca)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@modelo", modelo)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@serie", serie)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@cantidad", cantidad)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@pcosto", pcosto)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@pventa", pventa)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@idproveedor", idprov)
                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
                'Indico que se realizo exitosamente el guardado
                MsgBox("Los datos del producto fueron guardados exitosamente!")
                'Limpieza de controles
                TextBox3.Clear()
                TextBox4.Clear()
                RichTextBox1.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox3.Focus()
                'Se cierra la conexion
                conexion.Close()
            Catch ex As Exception
                'Mensaje para indicar que no se tuvo exito con la conexion
                MsgBox(ex.Message)
                'Se cierra la conexion
                conexion.Close()
            End Try
        Catch ex As Exception
            'Indica mensaje si hay algun error en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'Abrir el formulario de consulta de productos
        frmConProducto.Show()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        'Boton para calcular el precio de venta
        Dim pcosto, pventa, impuesto, ganancia As Double
        'Extraer el precio de costo
        pcosto = Val(TextBox9.Text)
        'Se calcula primero el impuesto del 5%
        impuesto = (pcosto * 0.05)
        'Se calcula la ganancia
        ganancia = (pcosto * 0.1)
        'Se suma el impuesto, la ganancia con el precio de costo para obtener el precio de venta
        pventa = impuesto + ganancia + pcosto
        'Se muestra el precio de venta en pantalla
        TextBox10.Text = pventa
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Inhabilitar el Textbox3, para que no cambian la clave por ser llave primaria.
        TextBox3.Enabled = False
        'procedimiento de busqueda de producto
        Call buscarProducto()
        'procedimiento de busqueda del proveedor
        Call buscarProveedor()
    End Sub

    'Procedimiento para buscar producto
    Sub buscarProducto()
        'Variable para el codigo del Proveedor y asi buscarlo
        Dim codProducto As String
        Try
            'Se captura el codigo del producto del Textbox3
            codProducto = TextBox3.Text
            'Procedimiento de conexion de la base de datos
            ConectarDB()
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del codigo del producto
            If (codProducto <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblproducto WHERE idproducto = '" & codProducto & "'"
                'Ejecuta la consulta SQL en la base de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblproducto")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblproducto").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No se ingreso ningun codigo de busqueda para el producto")
            End If
            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then
                'Guardar en variable publica el codigo del proveedor, para la consulta del proveedor en el combobox
                codProv = datos.Tables("tblproducto").Rows(0).Item("idproveedor")
                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox3.Text = datos.Tables("tblproducto").Rows(0).Item("idproducto")
                TextBox4.Text = datos.Tables("tblproducto").Rows(0).Item("nombre")
                RichTextBox1.Text = datos.Tables("tblproducto").Rows(0).Item("descripcion")
                TextBox5.Text = datos.Tables("tblproducto").Rows(0).Item("marca")
                TextBox6.Text = datos.Tables("tblproducto").Rows(0).Item("modelo")
                TextBox7.Text = datos.Tables("tblproducto").Rows(0).Item("serie")
                TextBox8.Text = datos.Tables("tblproducto").Rows(0).Item("cantidad")
                TextBox9.Text = datos.Tables("tblproducto").Rows(0).Item("pcosto")
                TextBox10.Text = datos.Tables("tblproducto").Rows(0).Item("pventa")
                'Se inhabilita el boton de busqueda
                Button3.Enabled = False
                'Se habilita el boton de modificar
                Button6.Enabled = True
                'Se habilita el boton de eliminar
                Button7.Enabled = True
                'Se cierra la conexion
                conexion.Close()
            Else
                'Se indica si hay o no hay algun producto existente
                MsgBox("No se encontro ningun producto con ese codigo")
                'Se cierra la conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Indica si hay algun error en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    'Procedimiento para llenar al proveedor en la busqueda
    Sub buscarProveedor()
        'Se define variable para el proveedor
        Dim codProveedor As String
        'Se asigna el valor que traemos del procedimiento buscarProducto
        codProveedor = codProv
        Try
            'Procedimiento de conexion de la baes de datos
            ConectarDB()
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nombre
            If (codProveedor <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblproveedor WHERE idproveedor = '" & codProveedor & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblproveedor")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblproveedor").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de proveedor")
            End If
            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then
                'Recibir el ID del proveedor seleccionado
                codProv = datos.Tables("tblproveedor").Rows(0).Item("idproveedor")
                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox1.Text = datos.Tables("tblproveedor").Rows(0).Item("idproveedor")
                TextBox2.Text = datos.Tables("tblproveedor").Rows(0).Item("nombreencargado")
                'Hace enfoque para que se llenen los datos del producto
                TextBox3.Focus()
                'Se cierra la conexion
                conexion.Close()
            Else
                'Indica si se encontro algun nombre de proveedor o no
                MsgBox("No se encontro ningun proveedor con ese nombre")
                'Cierre de conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Indica si hay algun error de ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Boton de actualizar productos        
        Try
            'Variables locales para la actualizacion de productos
            Dim id, nombre, descripcion, marca, modelo, serie As String
            Dim cantidad, idp As Integer
            Dim pventa, pcosto As Double
            'Id del producto
            id = Val(TextBox3.Text)
            'Extrae los nuevos nombres del producto
            nombre = TextBox4.Text
            'Extrae la nueva descripcion del producto
            descripcion = RichTextBox1.Text
            'Extrae la nueva marca del producto
            marca = TextBox5.Text
            'Extra el nuevo modelo del producto
            modelo = TextBox6.Text
            'Extrae el nuevo numero de serie
            serie = TextBox7.Text
            'Extrae la nueva cantidad o existencia de productos
            cantidad = Val(TextBox8.Text)
            'Extrae el nuevo precio de costo del producto
            pcosto = Val(TextBox9.Text)
            'Extrae el nuevo precio de venta del producto
            pventa = Val(TextBox10.Text)
            'Se guarda el nuevo codigo de proveedor de producto
            idp = codProv
            'Hacer la conexion con la base de datos
            ConectarDB()
            'Variable local para confirmar (Si/No) va modificar el dato
            Dim sino As Byte
            'Se pregunta si se quiere o no modificar el dato de la base de datos
            sino = MsgBox("¿Esta seguro que desea cambiar el los datos del producto?", vbYesNo, "Confirmacion de Actualizacion")
            'Se evalua si es si, para acutalizarlo
            If (sino = 6) Then
                'Guardamos el SQL del UPDATE que se correra en la base de datos
                sql = "UPDATE tblproducto SET nombre = '" & nombre & "', descripcion = '" & descripcion & "', marca = '" & marca & "', modelo = '" & modelo & "', serie = '" & serie & "', cantidad = '" & cantidad & "' , pcosto = '" & pcosto & "', pventa = '" & pventa & "', idproveedor = '" & idp & "' WHERE idproducto = '" & id & "'"
                'Se envia el SQL con la conexion para que se ejecute en la base de datos
                comandos = New MySqlCommand(sql, conexion)
                'No espero resultados
                comandos.ExecuteNonQuery()
                'Se le indica al usuario que ya fue realizada la actualizacion
                MsgBox("Los datos del producto fueron actualizados")
                'Se cierra la conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Muestra el mensaje de error
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        'Boton de eliminacion de productos

        'Varible para guardar el id del producto y asi borrarlo
        Dim id As String
        'Conecta con la base de datos
        ConectarDB()
        Try
            'Variable local para confirmar (Si/No) va eliminar el dato
            Dim sino As Byte
            'Extrae el id del producto
            id = TextBox3.Text
            'Se pregunta si se quiere o no borrar el dato de la base de datos
            sino = MsgBox("¿Esta seguro que desea eliminar a este producto?", vbYesNo, "Confirmacion de Eliminacion")
            'Se evalua si es si, para eliminarlo
            If (sino = 6) Then
                'Se guarda el SQL de la eliminacion
                sql = "DELETE FROM tblproducto WHERE idproducto = '" & id & "'"
                'Se envia el SQL a la base de datos con el parametro de la conexion
                comandos = New MySqlCommand(sql, conexion)
                'Se indica que no se espera un dato de vuelta
                comandos.BeginExecuteNonQuery()
                'Se le indica al usuario que ya se borro la tupla
                MsgBox("Informacion del producto eliminada")
                'Limpieza de controles
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                RichTextBox1.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox1.Focus()
                'Se cierra la conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Muestra el error de la rutina
            MsgBox(ex.Message)
        End Try
    End Sub
End Class