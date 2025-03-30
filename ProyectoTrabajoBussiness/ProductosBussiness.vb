Imports ProyectoTrabajoBaseDeDatos
Imports ProyectoTrabajoEntidades
Public Class ProductosBussiness

    ' Método para Crear un Producto
    Public Shared Sub CrearProducto(producto As Productos)
        ProductosData.CrearProducto(producto)
    End Sub
    ' Método para Leer un Producto por ID
    Public Shared Function ObtenerProductoPorId(id As Integer) As Productos
        Return ProductosData.ObtenerProductoPorId(id)
    End Function

    Public Shared Function ObtenerProductos() As List(Of Productos)
        Return ProductosData.ObtenerProductos()
    End Function
    ' Método para Actualizar un Producto
    Public Shared Sub ActualizarProducto(producto As Productos)
        ProductosData.ActualizarProducto(producto)
    End Sub

    ' Método para Eliminar un Producto
    Public Shared Sub EliminarProducto(id As Integer)
        ProductosData.EliminarProducto(id)
    End Sub

End Class
