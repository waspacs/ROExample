<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form, bileşen listesini temizlemeyi bırakmayı geçersiz kılar.
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

    'Windows Form Tasarımcısı tarafından gerektirilir
    Private components As System.ComponentModel.IContainer

    'NOT: Aşağıdaki yordam Windows Form Tasarımcısı için gereklidir
    'Windows Form Tasarımcısı kullanılarak değiştirilebilir.  
    'Kod düzenleyicisini kullanarak değiştirmeyin.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.readCb = New System.Windows.Forms.CheckBox()
        Me.hplabel = New System.Windows.Forms.Label()
        Me.alwaysOnTop = New System.Windows.Forms.CheckBox()
        Me.readTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'readCb
        '
        Me.readCb.AutoSize = True
        Me.readCb.Location = New System.Drawing.Point(12, 35)
        Me.readCb.Name = "readCb"
        Me.readCb.Size = New System.Drawing.Size(78, 17)
        Me.readCb.TabIndex = 0
        Me.readCb.Text = "Read Data"
        Me.readCb.UseVisualStyleBackColor = True
        '
        'hplabel
        '
        Me.hplabel.AutoSize = True
        Me.hplabel.Location = New System.Drawing.Point(9, 55)
        Me.hplabel.Name = "hplabel"
        Me.hplabel.Size = New System.Drawing.Size(28, 13)
        Me.hplabel.TabIndex = 1
        Me.hplabel.Text = "HP: "
        '
        'alwaysOnTop
        '
        Me.alwaysOnTop.AutoSize = True
        Me.alwaysOnTop.Location = New System.Drawing.Point(12, 12)
        Me.alwaysOnTop.Name = "alwaysOnTop"
        Me.alwaysOnTop.Size = New System.Drawing.Size(98, 17)
        Me.alwaysOnTop.TabIndex = 2
        Me.alwaysOnTop.Text = "Always On Top"
        Me.alwaysOnTop.UseVisualStyleBackColor = True
        '
        'readTimer
        '
        Me.readTimer.Interval = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(120, 77)
        Me.Controls.Add(Me.alwaysOnTop)
        Me.Controls.Add(Me.hplabel)
        Me.Controls.Add(Me.readCb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "ROExample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents readCb As CheckBox
    Friend WithEvents hplabel As Label
    Friend WithEvents alwaysOnTop As CheckBox
    Friend WithEvents readTimer As Timer
End Class
