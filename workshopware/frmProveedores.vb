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

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'Variable para el codigo del Proveedor y asi buscarlo
        Dim codProveedor As String

        Try
            'Se captura el codigo del proveedor del Textbox1
            codProveedor = TextBox1.Text

            'Procedimiento de conexion de la baes de datos
            ConectarDB()

            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nombre
            If (codProveedor <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblproveedor WHERE idproveedor = '" & codProveedor & "'"
                'Ejecuta la consulta SQL en la base de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblproveedor")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblproveedor").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No se ingreso ningun codigo de busqueda para el proveedor")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox1.Text = datos.Tables("tblproveedor").Rows(0).Item("idproveedor")
                TextBox2.Text = datos.Tables("tblproveedor").Rows(0).Item("nombre")
                TextBox3.Text = datos.Tables("tblproveedor").Rows(0).Item("nombreencargado")
                TextBox4.Text = datos.Tables("tblproveedor").Rows(0).Item("direccion")
                MaskedTextBox1.Text = datos.Tables("tblproveedor").Rows(0).Item("telefonooficina")
                MaskedTextBox2.Text = datos.Tables("tblproveedor").Rows(0).Item("telefonocelular")
                TextBox5.Text = datos.Tables("tblproveedor").Rows(0).Item("correoelectronico")

                'Se cierra la conexion
                conexion.Close()
            Else
                MsgBox("No se encontro ningun proveedor con ese codigo")
                conexion.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Boton de actualizar proveedores

        Try
            'Variables locales para la actualizacion del cliente
            Dim id, nombre, encargado, direccion, correo As String
            Dim tel1, tel2 As Integer

            'Extrae el id del proveedor
            id = TextBox1.Text
            'Extrae los nuevos nombres del proveedor
            nombre = TextBox2.Text
            'Extrae los nuevos nombres de proveedor 
            encargado = TextBox3.Text
            'Extrae la nueva direccion del cliente
            direccion = TextBox4.Text
            'Extrael el nuevo telefono de casa del cliente
            tel1 = MaskedTextBox1.Text
            'Extrae el nuevo telefono de celular del cliente
            tel2 = MaskedTextBox2.Text
            'Extrae el nuevo correo electronico del cliente
            correo = TextBox5.Text

            'Hacer la conexion con la base de datos
            ConectarDB()

            'Variable local para confirmar (Si/No) va modificar el dato
            Dim sino As Byte
            'Se pregunta si se quiere o no modificar el dato de la base de datos
            sino = MsgBox("¿Esta seguro que desea cambiar el los datos del proveedor?", vbYesNo, "Confirmacion de Actualizacion")

            'Se evalua si es si, para acutalizarlo
            If (sino = 6) Then
                'Guardamos el SQL del UPDATE que se correra en la base de datos
                sql = "UPDATE tblproveedor SET nombre = '" & nombre & "', nombreencargado = '" & encargado & "', direccion = '" & direccion & "', telefonooficina= '" & tel1 & "', telefonocelular = '" & tel2 & "', correoelectronico = '" & correo & "' WHERE idproveedor = '" & id & "'"
                'Se envia el SQL con la conexion para que se ejecute en la base de datos
                comandos = New MySqlCommand(sql, conexion)
                'No espero resultados
                comandos.ExecuteNonQuery()
                'Se le indica al usuario que ya fue realizada la actualizacion
                MsgBox("Los datos del proveedor fueron actualizados")
                'Se cierra la conexion
                conexion.Close()
            End If

        Catch ex As Exception
            'Muestra el mensaje de error
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Boton de eliminacion de proveedores

        'Varible para guardar el id del proveedor y asi borrarlo
        Dim id As String

        'Conecta con la base de datos
        ConectarDB()

        Try

            'Variable local para confirmar (Si/No) va eliminar el dato
            Dim sino As Byte

            'Extrae el id del cliente
            id = TextBox1.Text

            'Se pregunta si se quiere o no borrar el dato de la base de datos
            sino = MsgBox("¿Esta seguro que desea eliminar a este proveedor?", vbYesNo, "Confirmacion de Eliminacion")
            'Se evalua si es si, para eliminarlo

            If (sino = 6) Then
                'Se guarda el SQL de la eliminacion
                sql = "DELETE FROM tblproveedor WHERE idproveedor = '" & id & "'"
                'Se envia el SQL a la base de datos con el parametro de la conexion
                comandos = New MySqlCommand(sql, conexion)
                'Se indica que no se espera un dato de vuelta
                comandos.BeginExecuteNonQuery()
                'Se le indica al usuario que ya se borro la tupla
                MsgBox("Informacion del proveedor eliminada")

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
            End If

        Catch ex As Exception
            'Muestra el error de la rutina
            MsgBox(ex.Message)
        End Try
    End Sub
End Class