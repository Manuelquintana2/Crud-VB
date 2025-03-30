Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades
Public Class FrmEliminarVentas

    Private _venta As Ventas
    Private _ventaItem As VentasItems

    Public Sub New(venta As Ventas, ventaItem As VentasItems)
        InitializeComponent()
        _venta = venta
        _ventaItem = ventaItem
    End Sub

    Private Sub btnEliminarVenta_Click(sender As Object, e As EventArgs) Handles btnEliminarVenta.Click
        VentasBussiness.EliminarItemVenta(_ventaItem.Id)
        MessageBox.Show("Venta actualizada exitosamente", "ItemVenta eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub FrmEliminarVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llenamos los datos del cliente
        Dim clientes = ClientesBussiness.ObtenerClientes()
        cmbCliente.DataSource = clientes
        cmbCliente.DisplayMember = "Cliente"
        cmbCliente.ValueMember = "Id"
        cmbCliente.SelectedValue = _venta.IdCliente

        ' Llenamos el ComboBox de productos
        Dim productos = ProductosBussiness.ObtenerProductos()
        cmbProducto.DataSource = productos
        cmbProducto.DisplayMember = "Nombre"
        cmbProducto.ValueMember = "Id"
        cmbProducto.SelectedValue = _ventaItem.IdProducto

        ' Cargamos los datos de cantidad y precios del ítem
        NumericUpDown1.Value = _ventaItem.Cantidad
        txtPrecio.Text = _ventaItem.PrecioUnitario.ToString("F2")
        txtPrecioTotal.Text = _ventaItem.PrecioTotal.ToString("F2")
    End Sub
End Class