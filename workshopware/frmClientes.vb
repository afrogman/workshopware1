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
End Class