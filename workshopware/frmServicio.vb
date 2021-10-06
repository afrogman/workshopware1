'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmServicio

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Abre el formulario de clientes
        frmClientes.Show()
    End Sub

    Private Sub frmServicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
End Class