Imports ProyectoTrabajoEntidades
Imports ProyectoTrabajoBussiness

Public Class FrmVentas

    Private Sub FrmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarVentas()
        AgregarColumnasBotones()
    End Sub

    Private Sub CargarVentas()
        ' Obtener la lista de ventas desde la base de datos
        Dim ventas As List(Of Ventas) = VentasBussiness.ObtenerVentas()

        ' Asignar las ventas al DataGridView
        DataGridViewVentas.AutoGenerateColumns = False ' No generar columnas automáticamente
        DataGridViewVentas.DataSource = ventas
    End Sub

    Private Sub DataGridViewVentas_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewVentas.SelectionChanged

        If DataGridViewVentas.SelectedRows.Count > 0 Then
            ' Obtener el Id de la venta seleccionada
            Dim idVenta As Integer = Convert.ToInt32(DataGridViewVentas.SelectedRows(0).Cells("Id").Value)

            ' Obtener los ítems de la venta seleccionada
            Dim items As List(Of VentasItems) = VentasBussiness.ObtenerItemsDeVenta(idVenta)

            ' Asignar los ítems al DataGridView de ítems
            DataGridViewItems.DataSource = items
        End If
    End Sub

    Private Sub AgregarColumnasBotones()
        Dim btnEditar As New DataGridViewButtonColumn()
        btnEditar.Name = "btnEditar"
        btnEditar.HeaderText = "Editar"
        btnEditar.UseColumnTextForButtonValue = True

        ' Añadir la columna de botón al DataGridView
        DataGridViewItems.Columns.Add(btnEditar)

        ' Crear otra columna de tipo botón para eliminar
        Dim btnEliminar As New DataGridViewButtonColumn()
        btnEliminar.Name = "btnEliminar"
        btnEliminar.HeaderText = "Eliminar"
        btnEliminar.UseColumnTextForButtonValue = True

        ' Añadir la columna de botón para eliminar al DataGridView
        DataGridViewItems.Columns.Add(btnEliminar)
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim frmAltaVenta As New FrmAltaVenta()
        AddHandler frmAltaVenta.FormClosed, AddressOf FrmVentas_FormClosed
        frmAltaVenta.ShowDialog()
    End Sub

    Private Sub FrmVentas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        CargarVentas()
    End Sub

    Private Sub DataGridViewItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewItems.CellContentClick
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Return

        ' Obtener el ID del ítem de venta, no de la venta completa
        Dim idItem As Integer = Convert.ToInt32(Me.DataGridViewItems.Rows(e.RowIndex).Cells("Id").Value)

        ' Obtener la venta completa y los ítems de esa venta
        Dim idVenta As Integer = Convert.ToInt32(DataGridViewVentas.SelectedRows(0).Cells("Id").Value)
        Dim venta As Ventas = VentasBussiness.ObtenerVentas().Where(Function(x) x.Id = idVenta).FirstOrDefault()

        ' Obtener los ítems de la venta
        Dim ventaItems As List(Of VentasItems) = VentasBussiness.ObtenerItemsDeVenta(venta.Id)

        ' Buscar el ítem específico dentro de la venta
        Dim itemToEdit As VentasItems = ventaItems.FirstOrDefault(Function(x) x.Id = idItem)

        ' Verificar si la celda clickeada es la de "Editar" o "Eliminar"
        If Me.DataGridViewItems.Columns(e.ColumnIndex).Name = "btnEditar" Then
            If itemToEdit IsNot Nothing Then
                ' Ahora pasamos tanto la venta como el ítem seleccionado al formulario de modificación
                Dim frmModificarVenta As New FrmModificarVenta(venta, itemToEdit)
                AddHandler frmModificarVenta.FormClosed, AddressOf FrmVentas_FormClosed
                frmModificarVenta.ShowDialog()
            End If
        ElseIf Me.DataGridViewItems.Columns(e.ColumnIndex).Name = "btnEliminar" Then
            ' Mostrar un formulario de confirmación de eliminación
            Dim frmEliminarItem As New FrmEliminarVentas(venta, itemToEdit)
            AddHandler frmEliminarItem.FormClosed, AddressOf FrmVentas_FormClosed
            frmEliminarItem.ShowDialog()
        End If
    End Sub

    Private Sub DataGridViewVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewVentas.CellContentClick
        ' Verificar si la fila clickeada es válida
        If e.RowIndex < 0 Then Return ' Si no hay fila seleccionada, no hacer nada

        ' Asegurarse de que la columna clickeada sea la de "btnAgregarItem"
        If Me.DataGridViewVentas.Columns(e.ColumnIndex).Name = "btnAgregarItem" Then
            ' Verificar si hay una fila seleccionada
            If DataGridViewVentas.CurrentRow IsNot Nothing Then
                ' Obtener el ID de la venta desde la fila seleccionada
                Dim idVenta As Integer = Convert.ToInt32(DataGridViewVentas.CurrentRow.Cells("Id").Value)

                ' Abrir el formulario de agregar ítem, pasando el idVenta
                Dim agregar As New AgregarItemVenta(idVenta)
                AddHandler agregar.FormClosed, AddressOf FrmVentas_FormClosed
                agregar.ShowDialog()
            End If
        End If
    End Sub


End Class