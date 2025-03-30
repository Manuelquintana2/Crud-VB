Imports ProyectoTrabajoBaseDeDatos
Imports ProyectoTrabajoEntidades
Public Class ClientesBussiness

    ' Método para Crear un Cliente
    Public Shared Sub CrearCliente(cliente As Clientes)
        ClientesData.CrearCliente(cliente)
    End Sub
    ' Método para Leer todos los Clientes
    Public Shared Function ObtenerClientes() As List(Of Clientes)
        Return ClientesData.ObtenerClientes()
    End Function
    ' Método para Leer un Cliente por ID
    Public Shared Function ObtenerClientePorId(id As Integer) As Clientes
        Return ClientesData.ObtenerClientePorId(id)
    End Function
    ' Método para Actualizar un Cliente
    Public Shared Sub ActualizarCliente(cliente As Clientes)
        ClientesData.ActualizarCliente(cliente)
    End Sub
    ' Método para Eliminar un Cliente
    Public Shared Sub EliminarCliente(id As Integer)
        ClientesData.EliminarCliente(id)
    End Sub

End Class
