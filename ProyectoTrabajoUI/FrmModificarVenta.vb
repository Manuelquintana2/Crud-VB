Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class FrmModificarVenta
    Private _venta As Ventas
    Private _ventaItem As VentasItems

    ' Constructor modificado para recibir tanto la venta como el ítem de la venta
    Public Sub New(venta As Ventas, ventaItem As VentasItems)
        InitializeComponent()
        _venta = venta
        _ventaItem = ventaItem
    End Sub

    Private Sub FrmModificarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnEditarVenta_Click(sender As Object, e As EventArgs) Handles btnEditarVenta.Click
        ' Actualizamos la venta
        _venta.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue)
        _venta.Fecha = DateTime.Now
        _venta.Total = Convert.ToDecimal(txtPrecioTotal.Text)

        ' Actualizamos el ítem de la venta
        _ventaItem.IdProducto = Convert.ToInt32(cmbProducto.SelectedValue)
        _ventaItem.Cantidad = Convert.ToInt32(NumericUpDown1.Value)
        _ventaItem.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text)
        _ventaItem.PrecioTotal = Convert.ToDecimal(txtPrecioTotal.Text)

        ' Guardar los cambios de la venta y los ítems
        VentasBussiness.ActualizarVenta(_venta, New List(Of VentasItems) From {_ventaItem})
        MessageBox.Show("Venta actualizada exitosamente", "Venta Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub CalcularTotal()
        ' Obtener el precio unitario del producto seleccionado
        Dim precioUnitario As Decimal = Convert.ToDecimal(txtPrecio.Text)

        ' Obtener la cantidad seleccionada
        Dim cantidad As Integer = Convert.ToInt32(NumericUpDown1.Value)

        ' Calcular el total
        Dim total As Decimal = precioUnitario * cantidad

        ' Mostrar el total calculado en el campo de Total
        txtPrecioTotal.Text = total.ToString("F2")
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        ' Cuando se cambie el producto, obtener el precio unitario del producto seleccionado
        Dim producto As Productos = CType(cmbProducto.SelectedItem, Productos)
        txtPrecio.Text = producto.Precio.ToString("F2")

        ' Calcular el total cuando cambie el producto
        CalcularTotal()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        ' Calcular el total cuando cambie la cantidad
        CalcularTotal()
    End Sub
End Class
