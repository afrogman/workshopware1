'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmClientes

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Procedimiento de conexion de la base de datods
        Call ConectarDB()

        'Se guarda la consulta general mostrando nombres alternos para los campos
        sql = "SELECT idcliente as 'Codigo', nombres as 'Nombres', apellidos as 'Apellidos', direccion as 'Direccion', telefonocasa as 'Telefono Casa', telefonocelular as 'Telefono Celular', correoelectronico as 'Email', nit as 'NIT' FROM tblcliente"

        'Ejecuta la consulta SQL en la baes de datos con la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)

        datos = New DataSet

        'Va llenarse de los datos que tenga la tabla tbltecnico
        adaptador.Fill(datos, "tblcliente")

        'Va recibir las tuplas de la tabla
        lista = datos.Tables("tblcliente").Rows.Count

        'Condicional para ver si se recibe un dato en la lista
        If (lista <> 0) Then
            'Le indica al DataGridView que son datos que vienen de una base de datos
            DataGridView1.DataSource = datos
            'Le indica al DataGridView que muestre lo datos de la tabla indicada
            DataGridView1.DataMember = "tblcliente"
            'Se cierra la conexion
            conexion.Close()
        Else
            MsgBox("No hay datos guardados aun")
            conexion.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Boton de guardado de clientes

        'Variables para boton de guardado
        Dim codigocli, telcasa, telcel As Integer
        Dim nombrecli, apellidocli, direccioncli, email, nit As String

        Try
            'Codigo del cliente
            codigocli = Val(TextBox1.Text)
            'Nombre del cliente
            nombrecli = TextBox2.Text
            'Apellido del cliente
            apellidocli = TextBox3.Text
            'Direccion del cliente
            direccioncli = TextBox4.Text
            'Telefono de su casa
            telcasa = MaskedTextBox1.Text
            'Telefono de celular
            telcel = MaskedTextBox2.Text
            'Correo electronico
            email = TextBox5.Text
            'Numero de nit del cliente
            nit = TextBox6.Text

            Try
                'Se llama al procedimiento que hace y abre la conexion
                Call ConectarDB()

                'Linea de codigo que va guardar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("INSERT INTO tblcliente (idcliente, nombres, apellidos, direccion, telefonocasa, telefonocelular, correoelectronico, nit)" & Chr(13) &
                                            "VALUES(@codigo,@nombre,@apellido,@direccion,@telefonocasa,@telefonocelular,@email,@nit)", conexion)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@codigo", codigocli)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@nombre", nombrecli)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@apellido", apellidocli)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@direccion", direccioncli)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@telefonocasa", telcasa)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@telefonocelular", telcel)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@email", email)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@nit", nit)

                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
                'Indico que se realizo exitosamente el guardado
                MsgBox("Los datos del cliente fueron guardados exitosamente!")

                'Limpieza de controles
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                MaskedTextBox1.Clear()
                MaskedTextBox2.Clear()
                TextBox1.Focus()

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Boton de nueva opcion

        'Limpieza de controles
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        MaskedTextBox1.Clear()
        MaskedTextBox2.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'Variable para el codigo del cliente y asi buscarlo
        Dim codCliente As String

        Try
            'Se captura el codigo del cliente del Textbox1
            codCliente = TextBox1.Text

            'Procedimiento de conexion de la baes de datos
            ConectarDB()

            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nombre
            If (codCliente <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblcliente WHERE idcliente = '" & codCliente & "'"
                'Ejecuta la consulta SQL en la base de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblcliente")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblcliente").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No se ingreso ningun codigo de busqueda para el cliente")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox1.Text = datos.Tables("tblcliente").Rows(0).Item("idcliente")
                TextBox2.Text = datos.Tables("tblcliente").Rows(0).Item("nombres")
                TextBox3.Text = datos.Tables("tblcliente").Rows(0).Item("apellidos")
                TextBox4.Text = datos.Tables("tblcliente").Rows(0).Item("direccion")
                MaskedTextBox1.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocasa")
                MaskedTextBox2.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocelular")
                TextBox5.Text = datos.Tables("tblcliente").Rows(0).Item("correoelectronico")
                TextBox6.Text = datos.Tables("tblcliente").Rows(0).Item("nit")


                'Se cierra la conexion
                conexion.Close()
            Else
                MsgBox("No se encontro ningun cliente con ese codigo")
                conexion.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Boton de actualizar clientes

        Try
            'Variables locales para la actualizacion del cliente
            Dim id, nombres, apellidos, direccion, correo, nit As String
            Dim tel1, tel2 As Integer

            'Extrae el id del cliente
            id = TextBox1.Text
            'Extrae los nuevos nombres del cliente
            nombres = TextBox2.Text
            'Extrae los nuevos apellidos del cliente
            apellidos = TextBox3.Text
            'Extrae la nueva direccion del cliente
            direccion = TextBox4.Text
            'Extrael el nuevo telefono de casa del cliente
            tel1 = MaskedTextBox1.Text
            'Extrae el nuevo telefono de celular del cliente
            tel2 = MaskedTextBox2.Text
            'Extrae el nuevo correo electronico del cliente
            correo = TextBox5.Text
            'Extrae el nuevo numero de nit del cliente
            nit = TextBox6.Text

            'Hacer la conexion con la base de datos
            ConectarDB()

            'Variable local para confirmar (Si/No) va modificar el dato
            Dim sino As Byte
            'Se pregunta si se quiere o no modificar el dato de la base de datos
            sino = MsgBox("¿Esta seguro que desea cambiar el los datos del cliente?", vbYesNo, "Confirmacion de Actualizacion")

            'Se evalua si es si, para acutalizarlo
            If (sino = 6) Then
                'Guardamos el SQL del UPDATE que se correra en la base de datos
                sql = "UPDATE tblcliente SET nombres = '" & nombres & "', apellidos = '" & apellidos & "', direccion = '" & direccion & "', telefonocasa = '" & tel1 & "', telefonocelular = '" & tel2 & "', correoelectronico = '" & correo & "', nit = '" & nit & "'  WHERE idcliente = '" & id & "'"
                'Se envia el SQL con la conexion para que se ejecute en la base de datos
                comandos = New MySqlCommand(sql, conexion)
                'No espero resultados
                comandos.ExecuteNonQuery()
                'Se le indica al usuario que ya fue realizada la actualizacion
                MsgBox("Los datos del cliente fueron actualizados")
                'Se cierra la conexion
                conexion.Close()
            End If

        Catch ex As Exception
            'Muestra el mensaje de error
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Boton de eliminacion de cliente

        'Varible para guardar el id del cliente y asi borrarlo
        Dim id As String

        'Conecta con la base de datos
        ConectarDB()

        Try

            'Variable local para confirmar (Si/No) va eliminar el dato
            Dim sino As Byte

            'Extrae el id del cliente
            id = TextBox1.Text

            'Se pregunta si se quiere o no borrar el dato de la base de datos
            sino = MsgBox("¿Esta seguro que desea eliminar a este cliente?", vbYesNo, "Confirmacion de Eliminacion")
            'Se evalua si es si, para eliminarlo

            If (sino = 6) Then
                'Se guarda el SQL de la eliminacion
                sql = "DELETE FROM tblcliente WHERE idcliente = '" & id & "'"
                'Se envia el SQL a la base de datos con el parametro de la conexion
                comandos = New MySqlCommand(sql, conexion)
                'Se indica que no se espera un dato de vuelta
                comandos.BeginExecuteNonQuery()
                'Se le indica al usuario que ya se borro la tupla
                MsgBox("Informacion del cliente eliminada")

                'Limpieza de controles
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                MaskedTextBox1.Clear()
                MaskedTextBox2.Clear()
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