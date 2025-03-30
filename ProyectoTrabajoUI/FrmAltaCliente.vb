Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class FrmAltaCliente

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        ' Crear una nueva instancia de Cliente
        Dim cliente As New Clientes()

        ' Asignar los valores de los controles a las propiedades del cliente
        cliente.Cliente = txtCliente.Text
        cliente.Telefono = txtTelefono.Text
        cliente.Correo = txtCorreo.Text

        ' Llamar al método de la clase ClienteBussiness para crear el cliente
        ClientesBussiness.CrearCliente(cliente)

        ' Mostrar un mensaje de éxito
        MessageBox.Show("Se creo Correctamente")
        Me.Close()

    End Sub

    Private Sub FrmAltaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class