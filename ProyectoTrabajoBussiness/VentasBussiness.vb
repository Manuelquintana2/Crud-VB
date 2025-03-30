Imports ProyectoTrabajoEntidades
Imports ProyectoTrabajoBaseDeDatos
Public Class VentasBussiness
    Public Shared Function ObtenerVentas() As List(Of Ventas)
        Return VentasData.ObtenerVentas()
    End Function

    Public Shared Function ObtenerItemsDeVenta(idVenta As Integer) As List(Of VentasItems)
        Return VentasData.ObtenerItemsDeVenta(idVenta)
    End Function

    Public Shared Sub CrearVenta(venta As Ventas, items As List(Of VentasItems))
        VentasData.CrearVenta(venta, items)
    End Sub

    Public Shared Sub ActualizarVenta(venta As Ventas, items As List(Of VentasItems))
        VentasData.ModificarVenta(venta, items)
    End Sub

    Public Shared Sub EliminarVenta(idVenta As Integer)
        VentasData.EliminarVenta(idVenta)
    End Sub

    Public Shared Sub EliminarItemVenta(idItem As Integer)
        VentasData.EliminarItemVentaYActualizarTotal(idItem)
    End Sub

    Public Shared Sub AgregarItemVenta(idVenta As Integer, ItemVenta As VentasItems)
        VentasData.AgregarItemVenta(idVenta, ItemVenta)
    End Sub

End Class
