'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmServicio

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Abre el formulario de clientes
        frmClientes.Show()
    End Sub

    Private Sub frmServicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        'Se llena el ComboBox1 del cliente (nit)
        Call LlenarDatosCliente()
        'Se llena el Combobox del equipo (idequipo)
        Call LlenarDatosEquipo()
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
                'Limpiar los controles
                TextBox6.Clear()
                TextBox5.Clear()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
            End If
            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then
                'Recibir el ID del cliente seleccionado
                IdCliente = datos.Tables("tblcliente").Rows(0).Item("idcliente")
                'Si encuentra algo, entonces muestra los datos en los controles correspondientes
                TextBox6.Text = datos.Tables("tblcliente").Rows(0).Item("nombres")
                TextBox5.Text = datos.Tables("tblcliente").Rows(0).Item("apellidos")
                TextBox1.Text = datos.Tables("tblcliente").Rows(0).Item("direccion")
                TextBox2.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocasa")
                TextBox3.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocelular")
                TextBox4.Text = datos.Tables("tblcliente").Rows(0).Item("correoelectronico")
                'Se cierra la conexion
                conexion.Close()
            Else
                'Si se escribe o selecciona el nit del cliente que no existe se le notifica al cliente
                MsgBox("No se encontro ningun cliente con ese nit")
                'Limpiar los controles
                TextBox6.Clear()
                TextBox5.Clear()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                'Se cierra la conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Indica si hubo algo error o problema durante la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    'Procedimiento que llena el Combobox1 para los datos del cliente
    Sub LlenarDatosCliente()
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

    'Procedimiento que llena los datos para el equipo del combobox3
    Sub LlenarDatosEquipo()
        'Se realiza la conexion a la base de datos
        Call ConectarDB()
        'Se guarda la cadena SQL que se quiere consultar
        sql = "SELECT * FROM tblequipo"
        'Se envia la consulta y la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        datos = New DataSet
        'Se selecciona la tabla que es va mostrar
        datos.Tables.Add("tblequipo")
        'Se indica que se va llenar con el resultado de la consulta
        adaptador.Fill(datos.Tables("tblequipo"))
        'Se le indica al combobox de que tabla se va alimentar
        ComboBox3.DataSource = datos.Tables("tblequipo")
        'Se indica el campo que va aparecer
        ComboBox3.DisplayMember = "idequipo"
        'se cierra la conexion
        conexion.Close()
    End Sub

    'Llena los datos para el Combobox2 que tiene los datos del tecnico
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
                'Limpieza de controles
                TextBox14.Clear()
                TextBox15.Clear()
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
                'Se le indica al usuario que no se encontro ningun tecnico con el nombre o codigo escrito
                MsgBox("No se encontro ningun tecnico con ese nombre")
                'Limpieza de controles
                TextBox14.Clear()
                TextBox15.Clear()
                'Se cierra el conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Se indica que hay error en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Variables para procedimiento de guardado de servicio
        Dim idservicio, idequipo As Integer
        Dim falla, repa As String
        Dim fechaentrada, fechasalida, fechaprograma As Date
        Dim pago, saldo, total As Double
        Dim est As String
        Try
            'Codigo del servicio
            idservicio = MaskedTextBox1.Text
            'Guarda el codigo del servicio para aplicarlo en la tabla de asignacion de productos
            codServicio = idservicio
            'Se extrae el codigo del equipo que se selecciono en el combobox
            idequipo = CodEquipo
            'se guarda la Falla del equipo
            falla = RichTextBox2.Text
            'se guarda la Reparacion que se le hara al equipo
            repa = RichTextBox3.Text
            'se guarda la Fecha de entrada del equipo
            fechaentrada = Format(DateTimePicker1.Value, "Short Date")
            'se guarda la Fecha de salida o entrega del equipo
            fechasalida = Format(DateTimePicker2.Value, "Short Date")
            'se guarda la Fecha de mantenimiento programado
            fechaprograma = Format(DateTimePicker3.Value, "Short Date")
            'se guarda el Pago por el servicio
            pago = TextBox11.Text
            'se guarda el Saldo pendiente de pago del servicio
            saldo = TextBox12.Text
            'se guarda el Total a pagar del servicio
            total = TextBox7.Text
            'Se hace una Asignacion temporal para est
            est = ""
            'Estado del servicio, dependiendo de la seleccion de los RadioButtons
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
                comandos.Parameters.AddWithValue("@idequipo", idequipo)
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
                MsgBox("Los datos del servicio fueron guardados exitosamente!")
                'Habilitar el boton de agregar productos
                Button7.Enabled = True
                'Inhabilitar el boton de generacion de comprobante impreso
                Button11.Enabled = True
                'Se cierra la conexion
                conexion.Close()
            Catch ex As Exception
                'Mensaje para indicar que no se tuvo exito con la conexion
                MsgBox(ex.Message)
                'Se cierra la conexion
                conexion.Close()
            End Try
        Catch ex As Exception
            'Indica si hubo algun error en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Variables para el calculo de pago, saldo y total
        Dim pago, saldo, total As Double

        'Se extrae el valor del pago total del servicio
        total = TextBox7.Text
        'Se extrae el valor del pago que deja por adelantado
        pago = TextBox11.Text

        'Evalua que el anticipo o pago no sea mayor al valor total del servicio
        If (pago > total) Then
            'Indica en pantalla que no es posible
            MsgBox("No es posible realizar la transaccion, el valor del pago u abono es mayor al valor del servicio")
            'Posiciona el cursor en el anticipo para que lo arregle
            TextBox11.Focus()
        Else
            'Se actualiza la operacion del abono si hay
            saldo = total - pago
            'Se muestra en pantalla
            TextBox12.Text = saldo
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Inhabilitar el boton de agregar productos
        Button7.Enabled = False

        'Inhabilitar el boton de modificar
        Button10.Enabled = False

        'Habilitar el boton de guardado
        Button3.Enabled = True

        'Inhabilitar el boton de guardado
        Button11.Enabled = False

        'Limpiar los controles
        MaskedTextBox1.Clear()
        TextBox6.Clear()
        TextBox5.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        RichTextBox1.Clear()
        RichTextBox4.Clear()
        RichTextBox2.Clear()
        RichTextBox3.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox7.Clear()
        RadioButton1.Checked = True
        MaskedTextBox1.Focus()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        'Asignar el codigo del servicio al formulario de productos
        frmAsignacionProductos.TextBox1.Text = codServicio
        'Abrir el formulario de los productos de servicio
        frmAsignacionProductos.Show()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        'Variable para obtener el dato seleccionado del MaskedTextbox1
        Dim NoServicio As String

        Try
            'Se captura el valor del numero de servicio del MasketTextbox1
            NoServicio = Val(MaskedTextBox1.Text)

            'Procedimiento de conexion de la baes de datos
            ConectarDB()

            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nit
            If (NoServicio <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblservicio WHERE idservicio = '" & NoServicio & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblservicio")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblservicio").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de ningun servicio")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Recibir el ID del cliente que tiene el servicio
                IdCliente = datos.Tables("tblservicio").Rows(0).Item("idcliente")
                'Recibir el ID del equipo que tiene el servicio
                CodEquipo = datos.Tables("tblservicio").Rows(0).Item("idequipo")
                'Recibir el ID del tecnico que esta viendo el equipo
                IdTecnico = datos.Tables("tblservicio").Rows(0).Item("idtecnico")
                'Recibir el Codigo del servicio
                codServicio = datos.Tables("tblservicio").Rows(0).Item("idservicio")

                ComboBox3.Text = datos.Tables("tblservicio").Rows(0).Item("idequipo")

                RichTextBox2.Text = datos.Tables("tblservicio").Rows(0).Item("falla")
                RichTextBox3.Text = datos.Tables("tblservicio").Rows(0).Item("reparacion")
                DateTimePicker1.Text = datos.Tables("tblservicio").Rows(0).Item("fechaentrada")
                DateTimePicker2.Text = datos.Tables("tblservicio").Rows(0).Item("fechasalida")
                DateTimePicker3.Text = datos.Tables("tblservicio").Rows(0).Item("fechaprogramada")

                Dim estado = datos.Tables("tblservicio").Rows(0).Item("estado")
                If (estado = "Pendiente") Then
                    RadioButton1.Checked = True
                    RadioButton2.Checked = False
                ElseIf (estado = "Entregado") Then
                    RadioButton1.Checked = False
                    RadioButton2.Checked = True
                End If

                TextBox11.Text = datos.Tables("tblservicio").Rows(0).Item("pago")
                TextBox12.Text = datos.Tables("tblservicio").Rows(0).Item("saldo")
                TextBox7.Text = datos.Tables("tblservicio").Rows(0).Item("total")

                'Llena los datos del cliente
                Call ComboCliente2()
                'Llena los datos del equipo
                Call DatosEquipo()
                'Llena los datos del tecnico
                Call TecnicoDatos()

                'Se habilita la opcion de detallar los productos para el servicio
                Button7.Enabled = True
                'Se habilita la opcion de modificar el servicio
                Button10.Enabled = True
                'Se habilita la opcion de imprimir comprobante
                Button11.Enabled = True
                'Se inhabilita la opcion de guardar productos
                Button3.Enabled = False
                'Se cierra la conexion
                conexion.Close()
            Else
                MsgBox("No se encontro ningun servicio con ese numero")
                conexion.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Procedimiento que llena el Combobox del Cliente para modificar
    Sub ComboCliente2()

        Try
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nit
            If (IdCliente <> 0) Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblcliente WHERE idcliente = '" & IdCliente & "'"
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

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox6.Text = datos.Tables("tblcliente").Rows(0).Item("nombres")
                TextBox5.Text = datos.Tables("tblcliente").Rows(0).Item("apellidos")
                TextBox1.Text = datos.Tables("tblcliente").Rows(0).Item("direccion")
                TextBox2.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocasa")
                TextBox3.Text = datos.Tables("tblcliente").Rows(0).Item("telefonocelular")
                TextBox4.Text = datos.Tables("tblcliente").Rows(0).Item("correoelectronico")
            Else
                MsgBox("No se encontro ningun cliente con ese nit")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Procedimiento para cargar los datos del equipo
    Sub DatosEquipo()
        Try
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nit
            If (CodEquipo <> 0) Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblequipo WHERE idequipo = '" & CodEquipo & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblequipo")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblequipo").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de equipo")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                ComboBox3.Text = datos.Tables("tblequipo").Rows(0).Item("idequipo")
                TextBox8.Text = datos.Tables("tblequipo").Rows(0).Item("marca")
                TextBox9.Text = datos.Tables("tblequipo").Rows(0).Item("modelo")
                TextBox10.Text = datos.Tables("tblequipo").Rows(0).Item("serie")
                RichTextBox4.Text = datos.Tables("tblequipo").Rows(0).Item("accesorios")
                RichTextBox1.Text = datos.Tables("tblequipo").Rows(0).Item("observaciones")
            Else
                MsgBox("No se encontro ningun equipo con ese codigo")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    
    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        'Variable para obtener el dato seleccionado del Combobox
        Dim idEquipo As String
        Try
            'Se captura el valor del NIT del cliente que tiene seleccionado el combobox1
            idEquipo = ComboBox3.Text
            'Procedimiento de conexion de la baes de datos
            ConectarDB()
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del idequipo
            If (idEquipo <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblequipo WHERE idequipo = '" & idEquipo & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblequipo")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblequipo").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de equipo")
                'Se limpian los controles
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                RichTextBox4.Clear()
                RichTextBox1.Clear()
            End If
            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then
                'Recibir el ID del equipo seleccionado para la variable publica
                CodEquipo = datos.Tables("tblequipo").Rows(0).Item("idequipo")
                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox8.Text = datos.Tables("tblequipo").Rows(0).Item("marca")
                TextBox9.Text = datos.Tables("tblequipo").Rows(0).Item("modelo")
                TextBox10.Text = datos.Tables("tblequipo").Rows(0).Item("serie")
                RichTextBox4.Text = datos.Tables("tblequipo").Rows(0).Item("accesorios")
                RichTextBox1.Text = datos.Tables("tblequipo").Rows(0).Item("observaciones")
                'Se cierra la conexion
                conexion.Close()
            Else
                'Se le indica al usuario que el equipo no se encuentra disponible
                MsgBox("No se encontro ningun equipo con ese codigo")
                'Se limpian los controles
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                RichTextBox4.Clear()
                RichTextBox1.Clear()
                'Se cierra la conexion
                conexion.Close()
            End If
        Catch ex As Exception
            'Se indica si hubo algun problema en la ejecusion
            MsgBox(ex.Message)
        End Try
    End Sub

    'Procedmiento para llenar los datos del tecnico
    Sub TecnicoDatos()
        Try
            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nit
            If (IdTecnico <> 0) Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tbltecnico WHERE idtecnico = '" & IdTecnico & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tbltecnico")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tbltecnico").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de tecnico")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox14.Text = datos.Tables("tbltecnico").Rows(0).Item("nombres")
                TextBox15.Text = datos.Tables("tbltecnico").Rows(0).Item("apellidos")

            Else
                MsgBox("No se encontro ningun tecnico con ese codigo")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        'Boton de actualizar servicios

        'Variables locales para la actualizacion del servicio
        Dim idservicio As Integer
        Dim falla, repa As String
        Dim fechaentrada, fechasalida, fechaprograma As String
        Dim pago, saldo, total As Double
        Dim est As String

        Try
            'Extrae el id del servicio
            idservicio = MaskedTextBox1.Text
            'Extrae la nueva falla
            falla = RichTextBox2.Text
            'Extrae la nueva reparacion
            repa = RichTextBox3.Text
            'Extrae la nueva fecha de entrada del equipo
            fechaentrada = DateTimePicker1.Value.ToString("yyyy/MM/dd")
            'Extrae la nueva fecha de salida o entrega del equipo
            fechasalida = DateTimePicker2.Value.ToString("yyyy/MM/dd")
            'Extraer la nueva fecha de mantenimiento programado
            fechaprograma = DateTimePicker3.Value.ToString("yyyy/MM/dd")
            'Nueva Asignacion temporal para estado
            est = ""

            'Nuevo estado del servicio
            If (RadioButton1.Checked = True) And (RadioButton2.Checked = False) Then
                est = "Pendiente"
            ElseIf (RadioButton2.Checked = True) And (RadioButton1.Checked = False) Then
                est = "Entregado"
            End If

            'Pago por el servicio
            pago = TextBox11.Text
            'Saldo pendiente de pago del servicio
            saldo = TextBox12.Text
            'Total a pagar del servicio
            total = TextBox7.Text

            'Hacer la conexion con la base de datos
            ConectarDB()

            'Variable local para confirmar (Si/No) va modificar el dato
            Dim sino As Byte
            'Se pregunta si se quiere o no modificar el dato de la base de datos
            sino = MsgBox("¿Esta seguro que desea cambiar el los datos del servicio?", vbYesNo, "Confirmacion de Actualizacion")

            'Se evalua si es si, para acutalizarlo
            If (sino = 6) Then
                'Guardamos el SQL del UPDATE que se correra en la base de datos
                sql = "UPDATE tblservicio SET idcliente = '" & IdCliente & "', idequipo = '" & CodEquipo & "', falla = '" & falla & "', reparacion = '" & repa & "', fechaentrada = '" & fechaentrada & "', fechasalida = '" & fechasalida & "', fechaprogramada = '" & fechaprograma & "', idtecnico = '" & IdTecnico & "', pago = '" & pago & "', saldo = '" & saldo & "', total = '" & total & "', estado = '" & est & "' WHERE idservicio = '" & idservicio & "'"
                'Se envia el SQL con la conexion para que se ejecute en la base de datos
                comandos = New MySqlCommand(sql, conexion)
                'No espero resultados
                comandos.ExecuteNonQuery()
                'Se le indica al usuario que ya fue realizada la actualizacion
                MsgBox("Los datos del servicio fueron actualizados")
                'Se cierra la conexion
                conexion.Close()
            End If

        Catch ex As Exception
            'Muestra el mensaje de error
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        'Abrir el formulario de la constancia
        frmConstancia.Show()
    End Sub

    Private Sub MaskedTextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MaskedTextBox1.Validating
        'Validacion para el numero de orden para el servicio
        If (DirectCast(sender, MaskedTextBox).Text.Length > 0) Then
            'Si se dejaron con datos el MaskedTextbox1 no muestra nada
            Me.ErrorProvider1.SetError(sender, "")
        Else
            'Si en caso no se ingreso numero de orden en el MaskedTextbox1 se muestra el error en el errorprovider1
            Me.ErrorProvider1.SetError(sender, "Debe de ingresar un numero de servicio")
            'Deja listo en MaskedTextbox1 para que escriba el codigo nuevamente
            MaskedTextBox1.Focus()
        End If
    End Sub
End Class