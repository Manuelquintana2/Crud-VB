Imports ProyectoTrabajoBussiness
Imports ProyectoTrabajoEntidades

Public Class AgregarItemVenta

    Public idVenta As Integer
    Public Sub New(idVenta As Integer)
        InitializeComponent()
        Me.idVenta = idVenta

    End Sub
    Private Sub AgregarItemVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnCrearVenta_Click(sender As Object, e As EventArgs) Handles btnCrearVenta.Click
        Dim item As New VentasItems()
        item.IdProducto = Convert.ToInt32(cmbProducto.SelectedValue)
        item.Cantidad = Convert.ToInt32(NumericUpDown1.Value)
        item.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text)
        item.PrecioTotal = Convert.ToDecimal(txtPrecioTotal.Text)
        VentasBussiness.AgregarItemVenta(idVenta, item)
        MessageBox.Show("Item creada exitosamente", "Item Creada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
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
End Class