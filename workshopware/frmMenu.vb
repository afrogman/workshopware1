Public Class frmMenu

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Abrir el formulario de clientes
        frmClientes.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Abrir el formulario de tecnicos
        frmTecnicos.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Abrir el formulario de proveedores
        frmProveedores.Show()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'Abrir el formulario de los productos
        frmProducto.Show()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Abrir el formulario de servicios
        frmServicio.Show()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Abrir el formulario de equipos a reparar
        frmEquipos.Show()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        'Abrir el formulario que tiene los reportes
        frmReportes.Show()
    End Sub
End Class
