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

                'Se cierra la conexion
                conexion.Close()
            Else
                MsgBox("No se encontro ningun proveedor con ese nombre")
                conexion.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Limpieza de controles
        TextBox3.Clear()
        TextBox4.Clear()
        RichTextBox1.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        MaskedTextBox1.Clear()
        MaskedTextBox2.Clear()
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
            pcosto = MaskedTextBox1.Text
            'Precio de venta
            pventa = MaskedTextBox2.Text
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
                MaskedTextBox1.Clear()
                MaskedTextBox2.Clear()
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
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'Abrir el formulario de consulta de productos
        frmConProducto.Show()
    End Sub
End Class