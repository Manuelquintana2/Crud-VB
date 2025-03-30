Imports ProyectoTrabajoEntidades
Imports System.Data.SqlClient
Imports System.Configuration

Public Class ClientesData

    Private Shared connectionString As String = My.Settings.MiConexion

    Public Shared Sub CrearCliente(cliente As Clientes)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO dbo.clientes (Cliente, Telefono, Correo) VALUES (@Cliente, @Telefono, @Correo)"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Cliente", cliente.Cliente)
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Método para Leer todos los Clientes
    Public Shared Function ObtenerClientes() As List(Of Clientes)
        Dim clientes As New List(Of Clientes)()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM dbo.clientes"
            Using cmd As New SqlCommand(query, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim cliente As New Clientes() With {
                            .Id = reader.GetInt32(0),
                            .Cliente = reader.GetString(1),
                            .Telefono = reader.GetString(2),
                            .Correo = reader.GetString(3)
                        }
                        clientes.Add(cliente)
                    End While
                End Using
            End Using
        End Using
        Return clientes
    End Function

    ' Método para Obtener un Cliente por su ID
    Public Shared Function ObtenerClientePorId(id As Integer) As Clientes
        Dim cliente As New Clientes()
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM dbo.clientes WHERE Id = @Id"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Id", id)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        cliente.Id = reader.GetInt32(0)
                        cliente.Cliente = reader.GetString(1)
                        cliente.Telefono = reader.GetString(2)
                        cliente.Correo = reader.GetString(3)
                    End If
                End Using
            End Using
        End Using
        Return cliente
    End Function

    ' Método para Actualizar un Cliente
    Public Shared Sub ActualizarCliente(cliente As Clientes)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "UPDATE dbo.clientes SET Cliente = @Cliente, Telefono = @Telefono, Correo = @Correo WHERE Id = @Id"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Id", cliente.Id)
                cmd.Parameters.AddWithValue("@Cliente", cliente.Cliente)
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Método para Eliminar un Cliente
    Public Shared Sub EliminarCliente(id As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM dbo.clientes WHERE Id = @Id"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Id", id)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


End Class
