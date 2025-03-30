Imports ProyectoTrabajoEntidades
Imports ProyectoTrabajoBussiness
Public Class FrmClientes

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFiltro.Items.Add("Cliente")
        cmbFiltro.Items.Add("Telefono")
        cmbFiltro.Items.Add("Correo")
        cmbFiltro.SelectedItem = "Cliente"
        CargarCliente()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Return

        ' Obtener el Id del cliente seleccionado
        Dim Id As Integer = Convert.ToInt32(Me.DataGridView1.Rows(e.RowIndex).Cells("Id").Value)
        ' Obtener el cliente utilizando el Id
        Dim cliente As Clientes = ClientesBussiness.ObtenerClientes().Where(Function(x) x.Id = Id).FirstOrDefault()

        ' Verificar si la columna clickeada es "btnEditar" para modificar el cliente
        If Me.DataGridView1.Columns(e.ColumnIndex).Name = "btnEditar" Then
            Dim modificar As New FrmModificarCliente(cliente)
            AddHandler modificar.FormClosed, AddressOf FrmClientes_FormClosed
            modificar.ShowDialog()
            ' Verificar si la columna clickeada es "btnEliminar" para eliminar el cliente
        ElseIf Me.DataGridView1.Columns(e.ColumnIndex).Name = "btnEliminar" Then
            Dim eliminar As New FrmEliminarCliente(cliente)
            AddHandler eliminar.FormClosed, AddressOf FrmClientes_FormClosed
            eliminar.ShowDialog()
        End If
    End Sub

    Private Sub FrmClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        CargarCliente()
    End Sub

    Private Sub CargarCliente()
        ' Obtener la lista de clientes
        Dim lista As List(Of Clientes) = ClientesBussiness.ObtenerClientes()
        ' Deshabilitar la generación automática de columnas
        DataGridView1.AutoGenerateColumns = False
        ' Asignar la lista de clientes al DataGridView
        DataGridView1.DataSource = lista
    End Sub

    Private Sub CargarClientes(filtro As String, busqueda As String)
        ' Obtener lista de todos los clientes
        Dim clientes As List(Of Clientes) = ClientesBussiness.ObtenerClientes()

        ' Usar LINQ para filtrar la lista según el filtro seleccionado
        Dim resultados = From cliente In clientes
                         Where (filtro = "Nombre" AndAlso cliente.Cliente.Contains(busqueda)) OrElse
                               (filtro = "Telefono" AndAlso cliente.Telefono.Contains(busqueda)) OrElse
                               (filtro = "Correo" AndAlso cliente.Correo.Contains(busqueda))
                         Select cliente

        ' Mostrar los resultados en el DataGridView
        DataGridView1.DataSource = resultados.ToList()
    End Sub
    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim cliente As New FrmAltaCliente()
        ' Cuando se cierre, recargar la lista de clientes
        AddHandler cliente.FormClosed, AddressOf FrmClientes_FormClosed
        ' Mostrar el formulario de creación de cliente
        cliente.ShowDialog()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim busqueda As String = txtBuscar.Text
        Dim filtro As String = cmbFiltro.SelectedItem.ToString()

        ' Cargar los clientes con los filtros aplicados
        CargarClientes(filtro, busqueda)
    End Sub
End Class