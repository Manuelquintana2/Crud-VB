Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class FrmAltaVenta
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnCrearVenta_Click(sender As Object, e As EventArgs) Handles btnCrearVenta.Click
        Dim venta As New Ventas()
        venta.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue)
        venta.Fecha = DateTime.Now
        venta.Total = Convert.ToDecimal(txtPrecioTotal.Text)
        Dim item As New VentasItems()
        item.IdProducto = Convert.ToInt32(cmbProducto.SelectedValue)
        item.Cantidad = Convert.ToInt32(NumericUpDown1.Value)
        item.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text)
        item.PrecioTotal = Convert.ToDecimal(txtPrecioTotal.Text)
        Dim items As New List(Of VentasItems)
        items.Add(item)
        VentasBussiness.CrearVenta(venta, items)
        MessageBox.Show("Venta creada exitosamente", "Venta Creada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Private Sub FrmAltaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clientes = ClientesBussiness.ObtenerClientes()
        cmbCliente.DataSource = clientes
        cmbCliente.DisplayMember = "Cliente" ' Lo que se muestra en el ComboBox
        cmbCliente.ValueMember = "Id" ' El valor que se utiliza para guardar (ID del cliente)

        ' Llenar ComboBox de Productos
        Dim productos = ProductosBussiness.ObtenerProductos()
        cmbProducto.DataSource = productos
        cmbProducto.DisplayMember = "Nombre" ' Lo que se muestra en el ComboBox
        cmbProducto.ValueMember = "Id" ' El valor que se utiliza para guardar (ID del producto)
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        Dim producto As Productos = CType(cmbProducto.SelectedItem, Productos)
        ' Mostrar el precio en un TextBox
        txtPrecio.Text = producto.Precio.ToString("F2")
        Dim cantidad As Integer = Convert.ToInt32(NumericUpDown1.Value)
        Dim precio As Decimal = Convert.ToDecimal(txtPrecio.Text)
        Dim total As Decimal = cantidad * precio
        txtPrecioTotal.Text = total.ToString("F2")
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Dim cantidad As Integer = Convert.ToInt32(NumericUpDown1.Value)
        Dim precio As Decimal = Convert.ToDecimal(txtPrecio.Text)
        Dim total As Decimal = cantidad * precio
        txtPrecioTotal.Text = total.ToString("F2")
    End Sub

    Private Sub lblPrecioTotal_Click(sender As Object, e As EventArgs) Handles lblPrecioTotal.Click

    End Sub

    Private Sub txtPrecioTotal_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioTotal.TextChanged

    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged

    End Sub

    Private Sub lblCantidad_Click(sender As Object, e As EventArgs) Handles lblCantidad.Click

    End Sub

    Private Sub lblProducto_Click(sender As Object, e As EventArgs) Handles lblProducto.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub
End Class