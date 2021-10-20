Public Class frmReportes

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Abrir el formulario de reportes de salida
        frmFechaSalida.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Abrir el formulario de reportes de entrada
        frmFechaEntrada.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Abrir el formulario de reportes programados
        frmFechaProgramada.Show()
    End Sub
End Class