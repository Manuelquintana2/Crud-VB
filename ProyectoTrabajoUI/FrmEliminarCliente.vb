Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades
Public Class FrmEliminarCliente

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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ClientesBussiness.EliminarCliente(cliente.Id)
        ' Mostrar un mensaje de éxito
        MessageBox.Show("Se elimino Correctamente")
        ' Cerrar el formulario
        Me.Close()
    End Sub

    Private Sub FrmEliminarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Mostrar los datos del cliente en los controles correspondientes
        Me.txtCliente.Text = Me.cliente.Cliente
        Me.txtTelefono.Text = Me.cliente.Telefono
        Me.txtCorreo.Text = Me.cliente.Correo
    End Sub
End Class