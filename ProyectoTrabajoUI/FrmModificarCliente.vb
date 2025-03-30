Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class FrmModificarCliente

    Private cliente As Clientes

    ' Constructor por defecto
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor que recibe un cliente
    Public Sub New(cliente As Clientes)
        Me.New() ' Llamada al constructor por defecto
        Me.cliente = cliente
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Me.cliente.Cliente = txtCliente.Text
        Me.cliente.Telefono = txtTelefono.Text
        Me.cliente.Correo = txtCorreo.Text

        ' Llamar al método de la clase ClienteBussiness para guardar los cambios
        ClientesBussiness.ActualizarCliente(Me.cliente)

        ' Mostrar un mensaje de éxito
        MessageBox.Show("Se modifico Correctamente")

        ' Cerrar el formulario
        Me.Close()
    End Sub

    Private Sub FrmModificarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtCliente.Text = Me.cliente.Cliente
        Me.txtTelefono.Text = Me.cliente.Telefono
        Me.txtCorreo.Text = Me.cliente.Correo
    End Sub
End Class