
Public Class Form1
    Dim strBufferOut As String
    Dim strBufferIn As String
    Dim iBufferIn1 As Integer
    Dim resultado As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnConectar.Enabled = False
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If spPuertos.BytesToRead <> 0 Then
            iBufferIn1 = spPuertos.ReadExisting
            spPuertos.DiscardInBuffer()
            resultado = iBufferIn1
            TextBox1.Text = resultado
            Label1.Text = TextBox1.Text

    End Sub

    Private Sub btnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConectar.Click
        If btnConectar.Text = ("Conectar") Then
            spPuertos.PortName = cboPuertos.Text
            btnConectar.Text = ("Desconectar")
            Timer1.Start()
            spPuertos.Open()


        ElseIf btnConectar.Text = ("Desconectar") Then
            btnConectar.Text = ("Conectar")
            Timer1.Stop()
            spPuertos.Close()

        End If
    End Sub

    Private Sub btnDeterminarConexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeterminarConexion.Click
        cboPuertos.Items.Clear()

        For Each PuertosDisponibles As String In My.Computer.Ports.SerialPortNames
            cboPuertos.Items.Add(PuertosDisponibles)
        Next

        If cboPuertos.Items.Count > 0 Then
            cboPuertos.Text = cboPuertos.Items(0)
            ' btnConectar.Enabled = True

            spPuertos.PortName = cboPuertos.Text
            btnConectar.Text = ("Desconectar")
            spPuertos.Open()
            Timer1.Start()


        Else
            MessageBox.Show("¡Ningun Puerto Encontrado!")
            btnConectar.Enabled = False
            cboPuertos.Items.Clear()
            cboPuertos.Text = ("                          ")

        End If
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim Intru As Object
        Dim Archivo As Object
        Intru = CreateObject("Scripting.FileSystemObject")
        Archivo = Intru.CreateTextFile("D:\flujo\flujo.txt", True)
        Archivo.WriteLine("flujo=")
        Archivo.WriteLine(resultado)
        Archivo.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class



