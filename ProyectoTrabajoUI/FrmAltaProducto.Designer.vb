<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAltaProducto
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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.numPrecio = New System.Windows.Forms.NumericUpDown()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.btnCrear = New System.Windows.Forms.Button()
        CType(Me.numPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(335, 27)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(122, 38)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(248, 85)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(306, 26)
        Me.txtNombre.TabIndex = 6
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPrecio.Location = New System.Drawing.Point(349, 141)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(102, 38)
        Me.lblPrecio.TabIndex = 7
        Me.lblPrecio.Text = "Precio"
        Me.lblPrecio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'numPrecio
        '
        Me.numPrecio.Location = New System.Drawing.Point(337, 207)
        Me.numPrecio.Name = "numPrecio"
        Me.numPrecio.Size = New System.Drawing.Size(120, 26)
        Me.numPrecio.TabIndex = 8
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCategoria.Location = New System.Drawing.Point(322, 264)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(145, 38)
        Me.lblCategoria.TabIndex = 9
        Me.lblCategoria.Text = "Categoria"
        '
        'txtCategoria
        '
        Me.txtCategoria.Location = New System.Drawing.Point(248, 322)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(306, 26)
        Me.txtCategoria.TabIndex = 10
        '
        'btnCrear
        '
        Me.btnCrear.Location = New System.Drawing.Point(335, 368)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(116, 53)
        Me.btnCrear.TabIndex = 11
        Me.btnCrear.Text = "Crear"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'FrmAltaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCrear)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.numPrecio)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblNombre)
        Me.Name = "FrmAltaProducto"
        Me.Text = "FrmAltaProducto"
        CType(Me.numPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblPrecio As Label
    Friend WithEvents numPrecio As NumericUpDown
    Friend WithEvents lblCategoria As Label
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents btnCrear As Button
End Class
