﻿'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmEquipos

    Private Sub frmEquipos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Se realiza la conexion a la base de datos
        Call ConectarDB()

        'Se guarda la cadena SQL que se quiere consultar
        sql = "SELECT * FROM tblcliente"

        'Se envia la consulta y la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        datos = New DataSet
        'Se selecciona la tabla que es va mostrar
        datos.Tables.Add("tblcliente")
        'Se indica que se va llenar con el resultado de la consulta
        adaptador.Fill(datos.Tables("tblcliente"))

        'Se le indica al combobox de que tabla se va alimentar
        ComboBox1.DataSource = datos.Tables("tblcliente")
        'Se indica el campo que va aparecer
        ComboBox1.DisplayMember = "nit"
        'se cierra la conexion
        conexion.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Variable para obtener el dato seleccionado del Combobox
        Dim nitCli As String

        Try
            'Se captura el valor del NIT del cliente que tiene seleccionado el combobox1
            nitCli = ComboBox1.Text

            'Procedimiento de conexion de la baes de datos
            ConectarDB()

            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nit
            If (nitCli <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblcliente WHERE nit = '" & nitCli & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblcliente")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblcliente").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de cliente")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Recibir el ID del cliente seleccionado
                IdCliente = datos.Tables("tblcliente").Rows(0).Item("idcliente")

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox6.Text = datos.Tables("tblcliente").Rows(0).Item("nombres")
                TextBox5.Text = datos.Tables("tblcliente").Rows(0).Item("apellidos")
                TextBox1.Text = datos.Tables("tblcliente").Rows(0).Item("direccion")
                TextBox2.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocasa")
                TextBox3.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocelular")
                TextBox4.Text = datos.Tables("tblcliente").Rows(0).Item("correoelectronico")

                'Se enfoca al Textbox7 para ingresar los datos del equipo
                TextBox7.Focus()

                'Se cierra la conexion
                conexion.Close()
            Else
                MsgBox("No se encontro ningun cliente con ese nit")
                conexion.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Boton de limpieza para equipos

        'Limpieza de controles
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        RichTextBox1.Clear()
        RichTextBox4.Clear()
        TextBox7.Focus()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Boton de guardado de equipos

        'Variables para boton de guardado
        Dim codigoequipo As Integer
        Dim marca, modelo, serie, accesorios, observaciones As String

        Try
            'Codigo del equipo
            codigoequipo = Val(TextBox7.Text)
            'Marca del equipo
            marca = TextBox8.Text
            'Model del equipo
            modelo = TextBox9.Text
            'No. de serie del equipo
            serie = TextBox10.Text
            'Accesorios del equipo
            accesorios = RichTextBox4.Text
            'Observaciones del equipo
            observaciones = RichTextBox1.Text

            Try
                'Se llama al procedimiento que hace y abre la conexion
                Call ConectarDB()

                'Linea de codigo que va guardar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("INSERT INTO tblequipo (idequipo, marca, modelo, serie, accesorios, observaciones, idcliente)" & Chr(13) &
                                            "VALUES(@codigo,@marca,@modelo,@serie,@accesorios,@observaciones,@idcliente)", conexion)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@codigo", codigoequipo)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@marca", marca)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@modelo", modelo)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@serie", serie)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@accesorios", accesorios)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@observaciones", observaciones)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@idcliente", IdCliente)

                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
                'Indico que se realizo exitosamente el guardado
                MsgBox("Los datos del equipo fueron guardados exitosamente!")

                'Limpieza de controles
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                RichTextBox1.Clear()
                RichTextBox4.Clear()
                TextBox7.Focus()

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
End Class