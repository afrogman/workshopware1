'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmProveedores

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Boton de nueva opcion

        'Limpieza de controles
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        MaskedTextBox1.Clear()
        MaskedTextBox2.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Boton de guardado de proveedores

        'Variables para boton de guardado
        Dim codigopro, telofi, telcel As Integer
        Dim nombrepro, nombrerep, direccionpro, email As String

        Try
            'Codigo del proveedor
            codigopro = Val(TextBox1.Text)
            'Nombre comercial del proveedor
            nombrepro = TextBox2.Text
            'Nombre del representante o vendedor
            nombrerep = TextBox3.Text
            'Direccion del cliente
            direccionpro = TextBox4.Text
            'Telefono de su oficina
            telofi = MaskedTextBox1.Text
            'Telefono de celular
            telcel = MaskedTextBox2.Text
            'Correo electronico
            email = TextBox5.Text

            Try
                'Se llama al procedimiento que hace y abre la conexion
                Call ConectarDB()

                'Linea de codigo que va guardar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("INSERT INTO tblproveedor (idproveedor, nombre, nombreencargado, direccion, telefonooficina, telefonocelular, correoelectronico)" & Chr(13) &
                                            "VALUES(@codigo,@nombrepro,@nombrerep,@direccion,@telefonooficina,@telefonocelular,@email)", conexion)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@codigo", codigopro)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@nombrepro", nombrepro)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@nombrerep", nombrerep)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@direccion", direccionpro)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@telefonooficina", telofi)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@telefonocelular", telcel)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@email", email)

                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
                'Indico que se realizo exitosamente el guardado
                MsgBox("Los datos del proveedor fueron guardados exitosamente!")

                'Limpieza de controles
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
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

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        'Procedimiento de conexion de la base de datods
        Call ConectarDB()

        'Se guarda la consulta general mostrando nombres alternos para los campos
        sql = "SELECT idproveedor as 'Codigo', nombre as 'Nombre', nombreencargado as 'Encargado', direccion as 'Direccion', telefonooficina 'Telefono Oficina', telefonocelular as 'Telefono Celular', correoelectronico as 'Email' FROM tblproveedor"

        'Ejecuta la consulta SQL en la baes de datos con la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)

        datos = New DataSet

        'Va llenarse de los datos que tenga la tabla tbltecnico
        adaptador.Fill(datos, "tblproveedor")

        'Va recibir las tuplas de la tabla
        lista = datos.Tables("tblproveedor").Rows.Count

        'Condicional para ver si se recibe un dato en la lista
        If (lista <> 0) Then
            'Le indica al DataGridView que son datos que vienen de una base de datos
            DataGridView1.DataSource = datos
            'Le indica al DataGridView que muestre lo datos de la tabla indicada
            DataGridView1.DataMember = "tblproveedor"
            'Se cierra la conexion
            conexion.Close()
        Else
            MsgBox("No hay datos guardados aun")
            conexion.Close()
        End If
    End Sub
End Class