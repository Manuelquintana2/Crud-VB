Imports ProyectoTrabajoEntidades
Imports System.Data.SqlClient
Imports System.Configuration

Public Class ProductosData

    Private Shared connectionString As String = My.Settings.MiConexion


    ' Método para Crear un Producto
    Public Shared Sub CrearProducto(producto As Productos)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO dbo.productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre)
                cmd.Parameters.AddWithValue("@Precio", producto.Precio)
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Método para Leer un Producto por ID
    Public Shared Function ObtenerProductoPorId(id As Integer) As Productos
        Dim producto As New Productos()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM dbo.productos WHERE Id = @Id"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Id", id)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            producto.Id = reader.GetInt32(0)
                            producto.Nombre = reader.GetString(1)
                            producto.Precio = reader.GetDecimal(2)
                            producto.Categoria = reader.GetString(3)
                        End While
                    End If
                End Using
            End Using
        End Using
        Return producto
    End Function

    ' Método para Actualizar un Producto
    Public Shared Sub ActualizarProducto(producto As Productos)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "UPDATE dbo.productos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria WHERE Id = @Id"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Id", producto.Id)
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre)
                cmd.Parameters.AddWithValue("@Precio", producto.Precio)
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Método para Eliminar un Producto
    Public Shared Sub EliminarProducto(id As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM dbo.productos WHERE Id = @Id"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Id", id)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Método para obtener todos los productos
    Public Shared Function ObtenerProductos() As List(Of Productos)
        Dim lista As New List(Of Productos)()
        ' Importante: Para que funcione
        ' Modifica el parametro Server por el de tu Servidor

        Dim query As String = "SELECT * FROM dbo.productos"

        Try
            Using conexion As New SqlConnection(connectionString)
                conexion.Open()

                Using comando As New SqlCommand(query, conexion)
                    Using dr As SqlDataReader = comando.ExecuteReader()
                        If dr.HasRows Then
                            While dr.Read()
                                Dim producto As New Productos()
                                producto.Id = Convert.ToInt32(dr("Id"))
                                producto.Nombre = dr("Nombre").ToString()
                                producto.Precio = Convert.ToDecimal(dr("Precio"))
                                producto.Categoria = dr("Categoria").ToString()
                                lista.Add(producto)
                            End While
                        End If
                    End Using
                End Using

                ' Opcional: No es necesario cerrar la conexión explícitamente
                ' La conexión se cierra automáticamente al salir del bloque Using
            End Using
            Return lista
        Catch ex As Exception
            ' Si ocurre algún error, retorna Nothing o puedes lanzar un log o manejar el error de alguna forma
            Return Nothing
        End Try
    End Function


End Class
