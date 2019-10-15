<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BitmapMaskerMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BitmapMaskerMain))
        Me.uiButtonOpenFile = New System.Windows.Forms.Button
        Me.uiButtonCreateMask = New System.Windows.Forms.Button
        Me.uiLabelBitSource = New System.Windows.Forms.Label
        Me.uiBitmapMaskPictureBox = New System.Windows.Forms.PictureBox
        Me.uiSourceAsBitmapPictureBox = New System.Windows.Forms.PictureBox
        Me.uiSourceTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.uiSourceLabel = New System.Windows.Forms.Label
        Me.uiBitSourceLabel = New System.Windows.Forms.Label
        Me.uiMaskLabel = New System.Windows.Forms.Label
        Me.uiSourceOrigPictureBox = New System.Windows.Forms.PictureBox
        Me.uiSourcePictureBox = New System.Windows.Forms.PictureBox
        Me.uiStatusStrip = New System.Windows.Forms.StatusStrip
        Me.uiToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.uiToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.uiBitmapMaskPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uiSourceAsBitmapPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uiSourceTableLayoutPanel.SuspendLayout()
        CType(Me.uiSourceOrigPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uiSourcePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uiStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'uiButtonOpenFile
        '
        Me.uiButtonOpenFile.Dock = System.Windows.Forms.DockStyle.Top
        Me.uiButtonOpenFile.Location = New System.Drawing.Point(0, 0)
        Me.uiButtonOpenFile.Name = "uiButtonOpenFile"
        Me.uiButtonOpenFile.Size = New System.Drawing.Size(392, 23)
        Me.uiButtonOpenFile.TabIndex = 0
        Me.uiButtonOpenFile.Text = "Open Source Bitmap"
        Me.uiButtonOpenFile.UseVisualStyleBackColor = True
        '
        'uiButtonCreateMask
        '
        Me.uiButtonCreateMask.Dock = System.Windows.Forms.DockStyle.Top
        Me.uiButtonCreateMask.Location = New System.Drawing.Point(0, 23)
        Me.uiButtonCreateMask.Name = "uiButtonCreateMask"
        Me.uiButtonCreateMask.Size = New System.Drawing.Size(392, 23)
        Me.uiButtonCreateMask.TabIndex = 1
        Me.uiButtonCreateMask.Text = "Create Mask and Save"
        Me.uiButtonCreateMask.UseVisualStyleBackColor = True
        '
        'uiLabelBitSource
        '
        Me.uiLabelBitSource.AutoEllipsis = True
        Me.uiLabelBitSource.AutoSize = True
        Me.uiSourceTableLayoutPanel.SetColumnSpan(Me.uiLabelBitSource, 3)
        Me.uiLabelBitSource.Location = New System.Drawing.Point(3, 454)
        Me.uiLabelBitSource.Name = "uiLabelBitSource"
        Me.uiLabelBitSource.Size = New System.Drawing.Size(51, 13)
        Me.uiLabelBitSource.TabIndex = 2
        Me.uiLabelBitSource.Text = "FileName"
        '
        'uiBitmapMaskPictureBox
        '
        Me.uiBitmapMaskPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.uiBitmapMaskPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uiBitmapMaskPictureBox.Location = New System.Drawing.Point(263, 3)
        Me.uiBitmapMaskPictureBox.Name = "uiBitmapMaskPictureBox"
        Me.uiBitmapMaskPictureBox.Size = New System.Drawing.Size(126, 79)
        Me.uiBitmapMaskPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.uiBitmapMaskPictureBox.TabIndex = 3
        Me.uiBitmapMaskPictureBox.TabStop = False
        '
        'uiSourceAsBitmapPictureBox
        '
        Me.uiSourceAsBitmapPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.uiSourceAsBitmapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uiSourceAsBitmapPictureBox.Location = New System.Drawing.Point(133, 3)
        Me.uiSourceAsBitmapPictureBox.Name = "uiSourceAsBitmapPictureBox"
        Me.uiSourceAsBitmapPictureBox.Size = New System.Drawing.Size(124, 79)
        Me.uiSourceAsBitmapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.uiSourceAsBitmapPictureBox.TabIndex = 4
        Me.uiSourceAsBitmapPictureBox.TabStop = False
        '
        'uiSourceTableLayoutPanel
        '
        Me.uiSourceTableLayoutPanel.ColumnCount = 3
        Me.uiSourceTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.uiSourceTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.uiSourceTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiSourceLabel, 0, 2)
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiLabelBitSource, 0, 4)
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiBitSourceLabel, 0, 2)
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiMaskLabel, 0, 2)
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiSourceOrigPictureBox, 0, 3)
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiSourcePictureBox, 0, 0)
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiBitmapMaskPictureBox, 2, 0)
        Me.uiSourceTableLayoutPanel.Controls.Add(Me.uiSourceAsBitmapPictureBox, 1, 0)
        Me.uiSourceTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uiSourceTableLayoutPanel.Location = New System.Drawing.Point(0, 46)
        Me.uiSourceTableLayoutPanel.Name = "uiSourceTableLayoutPanel"
        Me.uiSourceTableLayoutPanel.RowCount = 4
        Me.uiSourceTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.uiSourceTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.uiSourceTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.uiSourceTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.uiSourceTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.uiSourceTableLayoutPanel.Size = New System.Drawing.Size(392, 520)
        Me.uiSourceTableLayoutPanel.TabIndex = 5
        '
        'uiSourceLabel
        '
        Me.uiSourceLabel.AutoEllipsis = True
        Me.uiSourceLabel.AutoSize = True
        Me.uiSourceLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.uiSourceLabel.Location = New System.Drawing.Point(3, 85)
        Me.uiSourceLabel.Name = "uiSourceLabel"
        Me.uiSourceLabel.Size = New System.Drawing.Size(124, 13)
        Me.uiSourceLabel.TabIndex = 9
        Me.uiSourceLabel.Text = "Source Image"
        '
        'uiBitSourceLabel
        '
        Me.uiBitSourceLabel.AutoEllipsis = True
        Me.uiBitSourceLabel.AutoSize = True
        Me.uiBitSourceLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.uiBitSourceLabel.Location = New System.Drawing.Point(133, 85)
        Me.uiBitSourceLabel.Name = "uiBitSourceLabel"
        Me.uiBitSourceLabel.Size = New System.Drawing.Size(124, 13)
        Me.uiBitSourceLabel.TabIndex = 8
        Me.uiBitSourceLabel.Text = "Source as Bitmap"
        '
        'uiMaskLabel
        '
        Me.uiMaskLabel.AutoEllipsis = True
        Me.uiMaskLabel.AutoSize = True
        Me.uiMaskLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.uiMaskLabel.Location = New System.Drawing.Point(263, 85)
        Me.uiMaskLabel.Name = "uiMaskLabel"
        Me.uiMaskLabel.Size = New System.Drawing.Size(126, 13)
        Me.uiMaskLabel.TabIndex = 7
        Me.uiMaskLabel.Text = "Mask"
        '
        'uiSourceOrigPictureBox
        '
        Me.uiSourceOrigPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.uiSourceTableLayoutPanel.SetColumnSpan(Me.uiSourceOrigPictureBox, 3)
        Me.uiSourceOrigPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uiSourceOrigPictureBox.Location = New System.Drawing.Point(3, 101)
        Me.uiSourceOrigPictureBox.Name = "uiSourceOrigPictureBox"
        Me.uiSourceOrigPictureBox.Size = New System.Drawing.Size(386, 350)
        Me.uiSourceOrigPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.uiSourceOrigPictureBox.TabIndex = 6
        Me.uiSourceOrigPictureBox.TabStop = False
        '
        'uiSourcePictureBox
        '
        Me.uiSourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.uiSourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uiSourcePictureBox.Location = New System.Drawing.Point(3, 3)
        Me.uiSourcePictureBox.Name = "uiSourcePictureBox"
        Me.uiSourcePictureBox.Size = New System.Drawing.Size(124, 79)
        Me.uiSourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.uiSourcePictureBox.TabIndex = 5
        Me.uiSourcePictureBox.TabStop = False
        '
        'uiStatusStrip
        '
        Me.uiStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.uiToolStripProgressBar, Me.uiToolStripStatusLabel})
        Me.uiStatusStrip.Location = New System.Drawing.Point(0, 544)
        Me.uiStatusStrip.Name = "uiStatusStrip"
        Me.uiStatusStrip.Size = New System.Drawing.Size(392, 22)
        Me.uiStatusStrip.TabIndex = 6
        Me.uiStatusStrip.Text = "StatusStrip1"
        '
        'uiToolStripProgressBar
        '
        Me.uiToolStripProgressBar.Name = "uiToolStripProgressBar"
        Me.uiToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'uiToolStripStatusLabel
        '
        Me.uiToolStripStatusLabel.Name = "uiToolStripStatusLabel"
        Me.uiToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.uiToolStripStatusLabel.Text = "Status:"
        '
        'BitmapMaskerMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 566)
        Me.Controls.Add(Me.uiStatusStrip)
        Me.Controls.Add(Me.uiSourceTableLayoutPanel)
        Me.Controls.Add(Me.uiButtonCreateMask)
        Me.Controls.Add(Me.uiButtonOpenFile)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(400, 600)
        Me.Name = "BitmapMaskerMain"
        Me.Text = "BitmapMasker"
        CType(Me.uiBitmapMaskPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uiSourceAsBitmapPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uiSourceTableLayoutPanel.ResumeLayout(False)
        Me.uiSourceTableLayoutPanel.PerformLayout()
        CType(Me.uiSourceOrigPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uiSourcePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uiStatusStrip.ResumeLayout(False)
        Me.uiStatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents uiButtonOpenFile As System.Windows.Forms.Button
    Friend WithEvents uiButtonCreateMask As System.Windows.Forms.Button
    Friend WithEvents uiLabelBitSource As System.Windows.Forms.Label
    Friend WithEvents uiBitmapMaskPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents uiSourceAsBitmapPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents uiSourceTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents uiSourcePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents uiSourceOrigPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents uiMaskLabel As System.Windows.Forms.Label
    Friend WithEvents uiSourceLabel As System.Windows.Forms.Label
    Friend WithEvents uiBitSourceLabel As System.Windows.Forms.Label
    Friend WithEvents uiStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents uiToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents uiToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel

End Class
