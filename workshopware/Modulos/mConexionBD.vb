'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Module mConexionBD

    'Funcion para conexion de la base de datos
    Public Sub ConectarDB()
        Try
            'Se guardan los datos de conexion: servidor, base de datos, usuario y el password
            conexion.ConnectionString = "server=localhost; database=basedatosipi; user= root; password=;"
            'Se abre la conexion a las base de datos
            conexion.Open()
        Catch ex As Exception
            'Muestra si hay algun error en la conexion
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
