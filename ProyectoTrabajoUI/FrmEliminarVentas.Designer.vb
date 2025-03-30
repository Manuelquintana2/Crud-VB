<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEliminarVentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnEliminarVenta = New System.Windows.Forms.Button()
        Me.lblPrecioTotal = New System.Windows.Forms.Label()
        Me.txtPrecioTotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEliminarVenta
        '
        Me.btnEliminarVenta.Location = New System.Drawing.Point(313, 357)
        Me.btnEliminarVenta.Name = "btnEliminarVenta"
        Me.btnEliminarVenta.Size = New System.Drawing.Size(109, 54)
        Me.btnEliminarVenta.TabIndex = 32
        Me.btnEliminarVenta.Text = "Eliminar"
        Me.btnEliminarVenta.UseVisualStyleBackColor = True
        '
        'lblPrecioTotal
        '
        Me.lblPrecioTotal.AutoSize = True
        Me.lblPrecioTotal.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPrecioTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioTotal.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblPrecioTotal.Location = New System.Drawing.Point(508, 230)
        Me.lblPrecioTotal.Name = "lblPrecioTotal"
        Me.lblPrecioTotal.Size = New System.Drawing.Size(144, 29)
        Me.lblPrecioTotal.TabIndex = 31
        Me.lblPrecioTotal.Text = "Precio Total"
        '
        'txtPrecioTotal
        '
        Me.txtPrecioTotal.Enabled = False
        Me.txtPrecioTotal.Location = New System.Drawing.Point(539, 275)
        Me.txtPrecioTotal.Name = "txtPrecioTotal"
        Me.txtPrecioTotal.ReadOnly = True
        Me.txtPrecioTotal.Size = New System.Drawing.Size(100, 26)
        Me.txtPrecioTotal.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(508, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 29)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Precio Unitario"
        '
        'txtPrecio
        '
        Me.txtPrecio.Enabled = False
        Me.txtPrecio.Location = New System.Drawing.Point(539, 184)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.Size = New System.Drawing.Size(100, 26)
        Me.txtPrecio.TabIndex = 28
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCantidad.Location = New System.Drawing.Point(313, 230)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(109, 29)
        Me.lblCantidad.TabIndex = 27
        Me.lblCantidad.Text = "Cantidad"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Enabled = False
        Me.NumericUpDown1.Location = New System.Drawing.Point(303, 276)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.ReadOnly = True
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 26)
        Me.NumericUpDown1.TabIndex = 26
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblProducto.Location = New System.Drawing.Point(313, 133)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(110, 29)
        Me.lblProducto.TabIndex = 25
        Me.lblProducto.Text = "Producto"
        '
        'cmbProducto
        '
        Me.cmbProducto.Enabled = False
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(302, 184)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(121, 28)
        Me.cmbProducto.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(319, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 29)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Cliente"
        '
        'cmbCliente
        '
        Me.cmbCliente.Enabled = False
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(302, 82)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(121, 28)
        Me.cmbCliente.TabIndex = 22
        '
        'FrmEliminarVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnEliminarVenta)
        Me.Controls.Add(Me.lblPrecioTotal)
        Me.Controls.Add(Me.txtPrecioTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCliente)
        Me.Name = "FrmEliminarVentas"
        Me.Text = "FrmEliminarVentas"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEliminarVenta As Button
    Friend WithEvents lblPrecioTotal As Label
    Friend WithEvents txtPrecioTotal As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents lblCantidad As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents lblProducto As Label
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCliente As ComboBox
End Class
