Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class FrmAltaProducto

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim producto As New Productos()

        ' Asignar los valores de los controles a las propiedades del producto
        producto.Nombre = txtNombre.Text
        producto.Categoria = txtCategoria.Text
        producto.Precio = numPrecio.Value
        ' Llamada al método para crear el producto
        ProductosBussiness.CrearProducto(producto)

        ' Mostrar mensaje de confirmación
        MessageBox.Show("Se creo correctamente")
        Me.Close()
    End Sub

    Private Sub FrmAltaProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class