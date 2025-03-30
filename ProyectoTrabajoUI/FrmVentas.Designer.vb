<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridViewVentas = New System.Windows.Forms.DataGridView()
        Me.DataGridViewItems = New System.Windows.Forms.DataGridView()
        Me.btnCrear = New System.Windows.Forms.Button()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregarItem = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DataGridViewVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewVentas
        '
        Me.DataGridViewVentas.AllowUserToAddRows = False
        Me.DataGridViewVentas.AllowUserToDeleteRows = False
        Me.DataGridViewVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.IdCliente, Me.Fecha, Me.Total, Me.btnAgregarItem})
        Me.DataGridViewVentas.Location = New System.Drawing.Point(21, 112)
        Me.DataGridViewVentas.Name = "DataGridViewVentas"
        Me.DataGridViewVentas.ReadOnly = True
        Me.DataGridViewVentas.RowHeadersWidth = 62
        Me.DataGridViewVentas.RowTemplate.Height = 28
        Me.DataGridViewVentas.Size = New System.Drawing.Size(795, 428)
        Me.DataGridViewVentas.TabIndex = 0
        '
        'DataGridViewItems
        '
        Me.DataGridViewItems.AllowUserToAddRows = False
        Me.DataGridViewItems.AllowUserToDeleteRows = False
        Me.DataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewItems.Location = New System.Drawing.Point(853, 112)
        Me.DataGridViewItems.Name = "DataGridViewItems"
        Me.DataGridViewItems.ReadOnly = True
        Me.DataGridViewItems.RowHeadersWidth = 62
        Me.DataGridViewItems.RowTemplate.Height = 28
        Me.DataGridViewItems.Size = New System.Drawing.Size(675, 428)
        Me.DataGridViewItems.TabIndex = 1
        '
        'btnCrear
        '
        Me.btnCrear.Location = New System.Drawing.Point(687, 54)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(96, 52)
        Me.btnCrear.TabIndex = 2
        Me.btnCrear.Text = "Crear venta"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.MinimumWidth = 8
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 150
        '
        'IdCliente
        '
        Me.IdCliente.DataPropertyName = "IdCliente"
        Me.IdCliente.HeaderText = "IdCliente"
        Me.IdCliente.MinimumWidth = 8
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.ReadOnly = True
        Me.IdCliente.Width = 150
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.MinimumWidth = 8
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 150
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        Me.Total.HeaderText = "Total"
        Me.Total.MinimumWidth = 8
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 150
        '
        'btnAgregarItem
        '
        Me.btnAgregarItem.DataPropertyName = "btnAgregarItem"
        Me.btnAgregarItem.HeaderText = "AgregarItem"
        Me.btnAgregarItem.MinimumWidth = 8
        Me.btnAgregarItem.Name = "btnAgregarItem"
        Me.btnAgregarItem.ReadOnly = True
        Me.btnAgregarItem.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnAgregarItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnAgregarItem.Width = 150
        '
        'FrmVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1527, 595)
        Me.Controls.Add(Me.btnCrear)
        Me.Controls.Add(Me.DataGridViewItems)
        Me.Controls.Add(Me.DataGridViewVentas)
        Me.Name = "FrmVentas"
        Me.Text = "FrmVentas"
        CType(Me.DataGridViewVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridViewVentas As DataGridView
    Friend WithEvents DataGridViewItems As DataGridView
    Friend WithEvents btnCrear As Button
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents IdCliente As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents btnAgregarItem As DataGridViewButtonColumn
End Class
