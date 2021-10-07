'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Public Class frmAsignacionProductos

    Private Sub frmAsignacionProductos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Se realiza la conexion a la base de datos
        Call ConectarDB()

        'Se guarda la cadena SQL que se quiere consultar
        sql = "SELECT * FROM tblproducto"

        'Se envia la consulta y la conexion
        adaptador = New MySqlDataAdapter(sql, conexion)
        datos = New DataSet
        'Se selecciona la tabla que es va mostrar
        datos.Tables.Add("tblproducto")
        'Se indica que se va llenar con el resultado de la consulta
        adaptador.Fill(datos.Tables("tblproducto"))
        ComboBox1.DataSource = datos.Tables("tblproducto")
        'Se indica el campo que va aparecer
        ComboBox1.DisplayMember = "nombre"
        'se cierra la conexion
        conexion.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Variable para obtener el dato seleccionado del Combobox
        Dim nomProd As String

        Try
            'Se captura el nombre del producto que tiene seleccionado el combobox1
            nomProd = ComboBox1.Text

            'Procedimiento de conexion de la baes de datos
            ConectarDB()

            'Condicional que va verificar que no hayan dejado en blanco la solicitud del nombre
            If (nomProd <> "") Then
                'Se guarda la consulta que quiero hacer en la base de datos
                sql = "SELECT * FROM tblproducto WHERE nombre = '" & nomProd & "'"
                'Ejecuta la consulta SQL en la baes de datos con la conexion
                adaptador = New MySqlDataAdapter(sql, conexion)
                datos = New DataSet
                'Va llenarse de los datos que tenga la tabla tblproveedor
                adaptador.Fill(datos, "tblproducto")
                'Va recibir las tuplas de la tabla
                lista = datos.Tables("tblproducto").Rows.Count
            Else
                'Mensaje en caso se haya dejado en blanco la solicitud del codigo
                MessageBox.Show("No hizo seleccion de ningun producto")
            End If

            'Condicional para ver si se recibe un dato en la lista
            If (lista <> 0) Then

                'Recibir el ID del producto seleccionado
                codProv = datos.Tables("tblproducto").Rows(0).Item("idproducto")

                'Si encuentra algo, entonces va mostrar la primera posicion encontrada
                TextBox4.Text = datos.Tables("tblproducto").Rows(0).Item("nombre")
                RichTextBox1.Text = datos.Tables("tblproducto").Rows(0).Item("descripcion")
                TextBox5.Text = datos.Tables("tblproducto").Rows(0).Item("marca")
                TextBox6.Text = datos.Tables("tblproducto").Rows(0).Item("modelo")
                TextBox7.Text = datos.Tables("tblproducto").Rows(0).Item("serie")
                TextBox8.Text = datos.Tables("tblproducto").Rows(0).Item("cantidad")
                TextBox3.Text = datos.Tables("tblproducto").Rows(0).Item("pventa")

                'Se cierra la conexion
                conexion.Close()
            Else
                MsgBox("No se encontro ningun producto con ese nombre")
                conexion.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class