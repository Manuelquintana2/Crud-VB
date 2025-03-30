Imports ProyectoTrabajoEntidades
Imports System.Data.SqlClient
Imports System.Configuration
Public Class VentasData
    Private Shared connectionString As String = My.Settings.MiConexion
    Public Shared Function ObtenerVentas() As List(Of Ventas)
        Dim ventas As New List(Of Ventas)()

        ' Consulta para obtener las ventas
        Dim queryVentas As String = "SELECT Id, IdCliente, Fecha, Total FROM Ventas"

        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryVentas, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Crear un objeto Ventas para cada registro
                        Dim venta As New Ventas() With {
                        .Id = Convert.ToInt32(reader("Id")),
                        .IdCliente = Convert.ToInt32(reader("IdCliente")),
                        .Fecha = Convert.ToDateTime(reader("Fecha")),
                        .Total = Convert.ToDouble(reader("Total"))
                    }

                        ' Agregar la venta a la lista
                        ventas.Add(venta)
                    End While
                End Using
            End Using
        End Using

        Return ventas
    End Function

    Public Shared Function ObtenerItemsDeVenta(idVenta As Integer) As List(Of VentasItems)
        Dim items As New List(Of VentasItems)()

        ' Consulta para obtener los ítems de la venta
        Dim queryItems As String = "SELECT Id, IdProducto, PrecioUnitario, Cantidad, PrecioTotal FROM VentasItems WHERE IdVenta = @IdVenta"

        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryItems, connection)
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Crear un objeto VentasItems para cada registro
                        Dim item As New VentasItems() With {
                        .Id = Convert.ToInt32(reader("Id")),
                        .IdVenta = idVenta,
                        .IdProducto = Convert.ToInt32(reader("IdProducto")),
                        .PrecioUnitario = Convert.ToDouble(reader("PrecioUnitario")),
                        .Cantidad = Convert.ToInt32(reader("Cantidad")),
                        .PrecioTotal = Convert.ToDouble(reader("PrecioTotal"))
                    }

                        ' Agregar el ítem a la lista
                        items.Add(item)
                    End While
                End Using
            End Using
        End Using

        Return items
    End Function


    Public Shared Sub CrearVenta(venta As Ventas, ventaItems As List(Of VentasItems))
        ' Insertar la venta en la tabla Ventas
        Dim queryVenta As String = "INSERT INTO Ventas (IdCliente, Fecha, Total) 
                                VALUES (@IdCliente, @Fecha, @Total);
                                SELECT SCOPE_IDENTITY();"

        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryVenta, connection)
                cmd.Parameters.AddWithValue("@IdCliente", venta.IdCliente)
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha)
                cmd.Parameters.AddWithValue("@Total", venta.Total)
                connection.Open()
                venta.Id = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using

        ' Insertar los ítems de la venta
        For Each item In ventaItems
            item.IdVenta = venta.Id
            item.PrecioTotal = item.PrecioUnitario * item.Cantidad ' Calcular el total del ítem
            Dim queryItem As String = "INSERT INTO VentasItems (IdVenta, IdProducto, PrecioUnitario, Cantidad, PrecioTotal) 
                                   VALUES (@IdVenta, @IdProducto, @PrecioUnitario, @Cantidad, @PrecioTotal)"
            Using connection As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(queryItem, connection)
                    cmd.Parameters.AddWithValue("@IdVenta", item.IdVenta)
                    cmd.Parameters.AddWithValue("@IdProducto", item.IdProducto)
                    cmd.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                    cmd.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                    cmd.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
                    connection.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Next
    End Sub

    Public Shared Sub ModificarVenta(venta As Ventas, ventaItems As List(Of VentasItems))
        ' Actualizar la venta
        Dim queryVenta As String = "UPDATE Ventas SET IdCliente = @IdCliente, Fecha = @Fecha, Total = @Total 
                                WHERE Id = @Id"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryVenta, connection)
                cmd.Parameters.AddWithValue("@IdCliente", venta.IdCliente)
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha)
                cmd.Parameters.AddWithValue("@Total", venta.Total)
                cmd.Parameters.AddWithValue("@Id", venta.Id)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Actualizar los ítems de la venta
        For Each item In ventaItems
            item.PrecioTotal = item.PrecioUnitario * item.Cantidad ' Calcular el total del ítem
            Dim queryItem As String = "UPDATE VentasItems SET IdProducto = @IdProducto, PrecioUnitario = @PrecioUnitario, 
                                   Cantidad = @Cantidad, PrecioTotal = @PrecioTotal WHERE Id = @Id"
            Using connection As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(queryItem, connection)
                    cmd.Parameters.AddWithValue("@IdProducto", item.IdProducto)
                    cmd.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                    cmd.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                    cmd.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
                    cmd.Parameters.AddWithValue("@Id", item.Id)
                    connection.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Next
    End Sub


    Public Shared Sub EliminarVenta(idVenta As Integer)
        ' Eliminar los ítems de la venta
        Dim queryItem As String = "DELETE FROM VentasItems WHERE IdVenta = @IdVenta"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryItem, connection)
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Eliminar la venta
        Dim queryVenta As String = "DELETE FROM Ventas WHERE Id = @IdVenta"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryVenta, connection)
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub EliminarItemVentaYActualizarTotal(idItem As Integer)
        ' Primero obtenemos el id de la venta a la que pertenece el ítem
        Dim idVenta As Integer = ObtenerIdVentaPorItem(idItem)

        ' Eliminar el ítem de la venta
        Dim queryEliminarItem As String = "DELETE FROM VentasItems WHERE Id = @IdItem"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryEliminarItem, connection)
                cmd.Parameters.AddWithValue("@IdItem", idItem)
                connection.Open()
                cmd.ExecuteNonQuery() ' Ejecutar la eliminación del ítem
            End Using
        End Using

        ' Recalcular el total de la venta después de eliminar el ítem
        Dim nuevoTotal As Decimal = RecalcularTotalVenta(idVenta)

        ' Actualizar el total de la venta en la tabla Ventas
        Dim queryActualizarVenta As String = "UPDATE Ventas SET Total = @NuevoTotal WHERE Id = @IdVenta"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryActualizarVenta, connection)
                cmd.Parameters.AddWithValue("@NuevoTotal", nuevoTotal)
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                connection.Open()
                cmd.ExecuteNonQuery() ' Ejecutar la actualización del total de la venta
            End Using
        End Using
    End Sub

    Private Shared Function ObtenerIdVentaPorItem(idItem As Integer) As Integer
        ' Consulta para obtener el Id de la venta a partir del Id del ítem
        Dim query As String = "SELECT IdVenta FROM VentasItems WHERE Id = @IdItem"

        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@IdItem", idItem)
                connection.Open()
                Dim result As Object = cmd.ExecuteScalar()

                ' Si se encuentra el IdVenta, se retorna el valor, de lo contrario, se retorna 0
                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    Return Convert.ToInt32(result)
                Else
                    Return 0
                End If
            End Using
        End Using
    End Function


    Private Shared Function RecalcularTotalVenta(idVenta As Integer) As Decimal
        Dim total As Decimal = 0

        ' Obtener todos los ítems de la venta
        Dim query As String = "SELECT PrecioTotal FROM VentasItems WHERE IdVenta = @IdVenta"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Sumar el PrecioTotal de cada ítem
                        total += Convert.ToDecimal(reader("PrecioTotal"))
                    End While
                End Using
            End Using
        End Using

        ' Retornar el nuevo total calculado
        Return total
    End Function

    Public Shared Sub AgregarItemVenta(idVenta As Integer, item As VentasItems)
        ' Verificar si el IdVenta está presente en el objeto
        If idVenta = 0 Then
            Throw New ArgumentException("El ítem debe estar asociado a una venta (IdVenta no puede ser 0).")
        End If

        ' Calcular el precio total del ítem (precio unitario * cantidad)
        item.PrecioTotal = item.PrecioUnitario * item.Cantidad

        ' Insertar el nuevo ítem en la tabla VentasItems
        Dim queryInsertItem As String = "INSERT INTO VentasItems (IdVenta, IdProducto, PrecioUnitario, Cantidad, PrecioTotal) 
                                     VALUES (@IdVenta, @IdProducto, @PrecioUnitario, @Cantidad, @PrecioTotal)"

        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryInsertItem, connection)
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                cmd.Parameters.AddWithValue("@IdProducto", item.IdProducto)
                cmd.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                cmd.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                cmd.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Luego, actualizamos el total de la venta
        Dim nuevoTotal = RecalcularTotalVenta(idVenta)
        ' Actualizar el total de la venta en la tabla Ventas
        Dim queryActualizarVenta As String = "UPDATE Ventas SET Total = @NuevoTotal WHERE Id = @IdVenta"
        Using connection As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(queryActualizarVenta, connection)
                cmd.Parameters.AddWithValue("@NuevoTotal", nuevoTotal)
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                connection.Open()
                cmd.ExecuteNonQuery() ' Ejecutar la actualización del total de la venta
            End Using
        End Using
    End Sub


End Class
