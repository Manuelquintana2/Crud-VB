Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class FrmModificarProducto

    Private _producto As Productos

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor con parámetro para inicializar el producto
    Public Sub New(producto As Productos)
        InitializeComponent()
        _producto = producto
    End Sub
    Private Sub FrmModificarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _producto.Nombre = txtNombre.Text
        _producto.Precio = numPrecio.Value
        _producto.Categoria = txtCategoria.Text
        ' Llamada al método de modificación del producto
        ProductosBussiness.ActualizarProducto(_producto)

        ' Mostrar mensaje de confirmación
        MessageBox.Show("Se modifico correctamente")

        Me.Close()
    End Sub
End Class