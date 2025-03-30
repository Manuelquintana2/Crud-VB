Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class FrmEliminarProducto

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Campo privado para almacenar el producto
    Private _producto As Productos

    ' Constructor con parámetro para inicializar el producto
    Public Sub New(producto As Productos)
        InitializeComponent()
        _producto = producto
    End Sub

    Private Sub FrmEliminarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtNombre.Text = _producto.Nombre
        Me.txtCategoria.Text = _producto.Categoria
        Me.numPrecio.Value = _producto.Precio.ToString()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ProductosBussiness.EliminarProducto(_producto.Id)
        ' Mostrar mensaje de confirmación
        MessageBox.Show("Se elimino correctamente")
        Me.Close()
    End Sub
End Class