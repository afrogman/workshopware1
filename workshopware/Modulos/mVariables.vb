'Importe de la libreria de referencia a MySQL
Imports MySql.Data.MySqlClient

Module mVariables
    'Variables publicas de proyecto workshopware

    'Variable para la cadena de conexion localhost, password, user y base de datos
    Public conexion As New MySqlConnection
    'Variable comando usada para insertar datos
    Public comandos As New MySqlCommand
    'Variable para el SQL que se envia a la base de datos
    Public sql As String
    'Variable que envia la cadena de conexion y la consulta SQL
    Public adaptador As MySqlDataAdapter
    'Variable que se encarga de representar los datos que se enviar y reciben de la DB
    Public datos As New DataSet
    'Variable que sirve para ver la cantidad de tuplas recibidas de una consulta
    Public lista As Byte
    'Variable para guardar un codigo de proveedor temporal
    Public codProv, IdCliente As Integer
    
End Module
