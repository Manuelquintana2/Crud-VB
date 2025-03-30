Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades
Public Class frmProductos
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Return

        Dim Id As Integer = Convert.ToInt32(Me.DataGridView1.Rows(e.RowIndex).Cells("Id").Value)
        Dim producto As Productos = ProductosBussiness.ObtenerProductos().Where(Function(x) x.Id = Id).FirstOrDefault()

        If Me.DataGridView1.Columns(e.ColumnIndex).Name = "btnEditar" Then
            Dim modificar As New FrmModificarProducto(producto)
            AddHandler modificar.FormClosed, AddressOf frmProductos_FormClosed
            modificar.ShowDialog()
        ElseIf Me.DataGridView1.Columns(e.ColumnIndex).Name = "btnEliminar" Then
            Dim eliminar As New FrmEliminarProducto(producto)
            AddHandler eliminar.FormClosed, AddressOf frmProductos_FormClosed
            eliminar.ShowDialog()
        End If

    End Sub

    Private Sub CargarProductos()
        Dim lista As List(Of Productos) = ProductosBussiness.ObtenerProductos()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = lista
    End Sub

    Private Sub CargarProductos(filtro As String, busqueda As String)
        ' Obtener todos los productos desde la base de datos
        Dim lista As List(Of Productos) = ProductosBussiness.ObtenerProductos()

        ' Aplicar el filtro usando LINQ
        Dim resultados = From producto In lista
                         Where (filtro = "Nombre" AndAlso producto.Nombre.ToLower().Contains(busqueda.ToLower())) OrElse
                               (filtro = "Categoria" AndAlso producto.Categoria.ToLower().Contains(busqueda.ToLower())) OrElse
                               (filtro = "Precio" AndAlso producto.Precio.ToString().Contains(busqueda))
                         Select producto

        ' Mostrar los productos filtrados en el DataGridView
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = resultados.ToList()
    End Sub

    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFiltro.Items.Add("Nombre")
        cmbFiltro.Items.Add("Categoria")
        cmbFiltro.Items.Add("Precio")
        cmbFiltro.SelectedItem = "Nombre" ' Seleccionar "Nombre" por defecto
        CargarProductos()
    End Sub

    Private Sub frmProductos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        CargarProductos()
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim FrmAltaProducto As New FrmAltaProducto()
        AddHandler FrmAltaProducto.FormClosed, AddressOf frmProductos_FormClosed
        FrmAltaProducto.ShowDialog()
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim frmCliente As New FrmClientes()
        frmCliente.ShowDialog()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim busqueda As String = txtBuscar.Text
        Dim filtro As String = cmbFiltro.SelectedItem.ToString()

        ' Cargar los productos con los filtros aplicados
        CargarProductos(filtro, busqueda)
    End Sub

    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        Dim frmVentas As New FrmVentas()
        frmVentas.ShowDialog()
    End Sub
End Class
