'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmServicio

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Abre el formulario de clientes
        frmClientes.Show()
    End Sub

    Private Sub frmServicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Se llena el ComboBox del cliente (nit)
        Call DatosCliente()
        'Se llena el ComboBox del tecnico (nombre)
        Call DatosTecnico()
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

    Sub DatosCliente()
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

    Sub DatosTecnico()
        'Se realiza la conexion a la base de datos
        Call ConectarDB()

        'Se guarda la cadena SQL que se quiere consultar
        sql = "SELECT * FROM tbltecnico"

        'Se envia la consulta y la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        datos = New DataSet
        'Se selecciona la tabla que es va mostrar
        datos.Tables.Add("tbltecnico")
        'Se indica que se va llenar con el resultado de la consulta
        adaptador.Fill(datos.Tables("tbltecnico"))

        'Se le indica al combobox de que tabla se va alimentar
        ComboBox2.DataSource = datos.Tables("tbltecnico")
        'Se indica el campo que va aparecer
        ComboBox2.DisplayMember = "nombres"
        'se cierra la conexion
        conexion.Close()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'Variable para obtener el dato seleccionado del Combobox
        Dim NombreTecnico As String

        Try
            'Se captura el Nombre del tecnico que tiene seleccionado el combobox2
            NombreTecnico = ComboBox2.Text

            'Procedimiento de conexion de la baes de datos
            ConectarDB()

            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nombre
            If (NombreTecnico <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tbltecnico WHERE nombres = '" & NombreTecnico & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tbltecnico
                adaptador.Fill(datos, "tbltecnico")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tbltecnico").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de tecnico")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Recibir el ID del tecnico seleccionado
                IdTecnico = datos.Tables("tbltecnico").Rows(0).Item("idtecnico")

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox14.Text = datos.Tables("tbltecnico").Rows(0).Item("nombres")
                TextBox15.Text = datos.Tables("tbltecnico").Rows(0).Item("apellidos")
                

                'Se cierra la conexion
                conexion.Close()
            Else
                MsgBox("No se encontro ningun tecnico con ese nombre")
                conexion.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Llama al procedimiento los datos del equipo
        Call GuardarEquipo()
    End Sub

    'Procedimiento para guardar el equipo
    Sub GuardarEquipo()

        'Variables para procedimiento de guardado de equipo
        Dim idequipo As Integer
        Dim marca, modelo, serie, accesorios, observaciones As String

        Try
            'Codigo del equipo
            idequipo = Val(TextBox7.Text)

            'Se guarda en la variable temporal para la llave foranea
            CodEquipo = idequipo

            'Marca del equipo
            marca = TextBox8.Text
            'Modelo del equipo
            modelo = TextBox9.Text
            'Serie del equipo
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
                                            "VALUES(@idequipo,@marca,@modelo,@serie,@accesorios,@observaciones,@idcliente)", conexion)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@idequipo", idequipo)
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

                'Se cierra la conexion
                conexion.Close()

                'Llama al procedimiento del servicio
                Call GuardarServicio()

                'Habilitar el boton de agregar productos
                Button7.Enabled = True

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

    'Procedimiento para guardar la orden de servicio
    Sub GuardarServicio()

        'Variables para procedimiento de guardado de servicio
        Dim idservicio As Integer
        Dim falla, repa As String
        Dim fechaentrada, fechasalida, fechaprograma As Date
        Dim pago, saldo, total As Double
        Dim est As String

        Try
            'Codigo del servicio
            idservicio = MaskedTextBox1.Text

            'Guarda el codigo del servicio para aplicarlo en la tabla de asignacion de productos
            codServicio = idservicio

            'Falla del equipo
            falla = RichTextBox2.Text
            'Reparacion que se le hara al equipo
            repa = RichTextBox3.Text
            'Fecha de entrada del equipo
            fechaentrada = Format(DateTimePicker1.Value, "Short Date")
            'Fecha de salida o entrega del equipo
            fechasalida = Format(DateTimePicker2.Value, "Short Date")
            'Fecha de mantenimiento programado
            fechaprograma = Format(DateTimePicker3.Value, "Short Date")
            'Pago por el servicio
            pago = MaskedTextBox2.Text
            'Saldo pendiente de pago del servicio
            saldo = TextBox11.Text
            'Total a pagar del servicio
            total = MaskedTextBox4.Text

            'Estado del servicio
            If (RadioButton1.Checked = True) And (RadioButton2.Checked = False) Then
                est = "Pendiente"
            ElseIf (RadioButton2.Checked = True) And (RadioButton1.Checked = False) Then
                est = "Entregado"
            End If

            Try
                'Se llama al procedimiento que hace y abre la conexion
                Call ConectarDB()

                'Linea de codigo que va guardar la insercion en la tabla, pero con referencias
                comandos = New MySqlCommand("INSERT INTO tblservicio (idservicio, idcliente, idequipo, falla, reparacion, fechaentrada, fechasalida, fechaprogramada, idtecnico, pago, saldo, total, estado)" & Chr(13) &
                                            "VALUES(@idservicio,@idcliente,@idequipo,@falla,@reparacion,@fechaentrada,@fechasalida,@fechaprogramada,@idtecnico,@pago,@saldo,@total,@estado)", conexion)
                'Referencia al codigo ingresado en el formulario
                comandos.Parameters.AddWithValue("@idservicio", idservicio)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@idcliente", IdCliente)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@idequipo", CodEquipo)
                'Referencia al nombre ingresado en el formulario
                comandos.Parameters.AddWithValue("@falla", falla)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@reparacion", repa)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@fechaentrada", fechaentrada)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@fechasalida", fechasalida)
                'Referencia al precio ingresado en el formulario
                comandos.Parameters.AddWithValue("@fechaprogramada", fechaprograma)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@idtecnico", IdTecnico)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@pago", pago)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@saldo", saldo)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@total", total)
                'Referencia al estado ingresado en el formulario
                comandos.Parameters.AddWithValue("@estado", est)

                'Se coloca porque no espero ningun resultado de la consulta
                comandos.ExecuteNonQuery()
                'Indico que se realizo exitosamente el guardado
                MsgBox("Los datos del servicio y del equipo fueron guardados exitosamente!")

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
    
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Variables para el calculo de pago, saldo y total
        Dim pago, saldo, total As Double

        'Se extrae el valor del pago que deja por adelantado
        pago = MaskedTextBox2.Text
        'Se extrae el valor del pago total del servicio
        total = MaskedTextBox4.Text
        'Se actualiza la operacion del abono si hay
        saldo = total - pago
        'Se muestra en pantalla
        TextBox11.Text = saldo
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Inhabilitar el boton de agregar productos
        Button7.Enabled = False

        'Limpiar los controles
        MaskedTextBox1.Clear()
        TextBox6.Clear()
        TextBox5.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        RichTextBox1.Clear()
        RichTextBox4.Clear()
        RichTextBox2.Clear()
        RichTextBox3.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        MaskedTextBox2.Clear()
        TextBox11.Clear()
        MaskedTextBox4.Clear()
        RadioButton1.Checked = True
        MaskedTextBox1.Focus()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        'Asignar el codigo del servicio al formulario de productos
        frmAsignacionProductos.TextBox1.Text = codServicio
        'Abrir el formulario de los productos de servicio
        frmAsignacionProductos.Show()
    End Sub
End Class