Public Class frmMenu

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Abrir el formulario de clientes
        frmClientes.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Abrir el formulario de tecnicos
        frmTecnicos.Show()
    End Sub
End Class
