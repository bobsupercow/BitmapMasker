Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class BitmapMaskerMain

#Region "Variables and Properties"
    ''' <summary>
    ''' The source Image
    ''' </summary>
    Private _sourceImage As System.Drawing.Image

    ''' <summary>
    ''' Gets or sets the source image.
    ''' Additionally, sets the picture box image associated with the Source Image
    ''' </summary>
    ''' <value>
    ''' The source image.
    ''' </value>
    Public Property SourceImage() As System.Drawing.Image
        Get
            Return _sourceImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            _sourceImage = value
            Me.uiSourcePictureBox.Image = value
        End Set
    End Property

    ''' <summary>
    ''' The source image's filename as a string.
    ''' </summary>
    Private _sourceImageFileName As String = ""

    ''' <summary>
    ''' Gets or sets the sourceImageFileName variable.
    ''' Additionally, sets a label which displays this filename.
    ''' </summary>
    ''' <value>
    ''' The source image's filename.
    ''' </value>
    Public Property SourceImageFileName() As String
        Get
            Return _sourceImageFileName
        End Get
        Set(ByVal value As String)
            _sourceImageFileName = value
            'Essentially Bind this property to the Label on the form.
            Me.uiLabelBitSource.Text = value
        End Set
    End Property

    ''' <summary>
    ''' The source image as a bitmap, without transparencies.
    ''' </summary>
    Private _sourceAsBitmap As Bitmap

    ''' <summary>
    ''' Gets or sets the source as a bitmap.
    ''' Additionally, sets the picture box image associated with the SourceAsBitmap Image
    ''' </summary>
    ''' <value>
    ''' The source as a bitmap.
    ''' </value>
    Public Property SourceAsBitmap() As Bitmap
        Get
            Return _sourceAsBitmap
        End Get
        Set(ByVal value As Bitmap)
            _sourceAsBitmap = value
            Me.uiSourceAsBitmapPictureBox.Image = value
            'To make it easier for the user to see what is happening, we present a scaled version of the image as well, below. 
            Me.uiSourceOrigPictureBox.Image = value
        End Set
    End Property

    ''' <summary>
    ''' The black/white mask of the sourceAsBitmap
    ''' </summary>
    Private _bitmapMask As Bitmap

    ''' <summary>
    ''' Gets or sets the black/white mask of the sourceAsBitmap
    ''' </summary>
    ''' <value>
    ''' The black/white mask of the sourceAsBitmap
    ''' </value>
    Public Property BitmapMask() As Bitmap
        Get
            Return _bitmapMask
        End Get
        Set(ByVal value As Bitmap)
            _bitmapMask = value
            If _bitmapMask Is Nothing Then
                Me.uiBitmapMaskPictureBox.Image = Nothing
            Else
                Me.uiBitmapMaskPictureBox.Image = _bitmapMask
            End If
        End Set
    End Property

    ''' <summary>
    ''' Used for Async/Await update of progress to GUI
    ''' </summary>
    Dim myProgress As Progress(Of Integer)
    Dim myToken As CancellationTokenSource
#End Region

#Region "Opening File"

    ''' <summary>
    ''' Sets the source file.
    ''' This sets three properties.
    ''' The SourceImageFileName
    ''' The SourceImage
    ''' The SourceAsBitmap, which is created by scaling by a factor of 1.
    ''' </summary>
    ''' <param name="fileName">Name of the file.</param>
    Private Sub SetSourceFile(ByVal fileName As String)
        Me.BitmapMask = Nothing
        'First things first, we want to set the source image by opening the file.
        Try
            Me.SourceImage = System.Drawing.Image.FromFile(fileName)
        Catch ex As OutOfMemoryException
            MessageBox.Show("Either the file does not have a valid image format, or " &
                            "GDI+ does not support the pixel format of the file.")
            Exit Sub
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("The specified file does not exist:" & Environment.NewLine & fileName)
            Exit Sub
        Catch ex As ArgumentException
            MessageBox.Show("The specified filename is a URI (uniform resource identifier):" & Environment.NewLine & fileName)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("An unknown exception occured:" & Environment.NewLine & ex.Message)
            Exit Sub
        End Try

        'Set the filename
        Me.SourceImageFileName = fileName

        Dim tempBitMap = New Bitmap(fileName)
        'Create a proper bitmap by scaling the tempfile by a factor of 1. 
        'Essentially this just uses GDI+ to do work of removing alpha transparencies. 
        Me.uiToolStripStatusLabel.Text = "Creating Bitmap and Removing Transparencies"
        Try
            Me.SourceAsBitmap = ScaleBitmap(tempBitMap, 1, False)
        Catch ex As Exception
            MessageBox.Show("An error occured while converting the original image to a flattened bitmap:" & Environment.NewLine & ex.Message)
        End Try


        Me.uiToolStripStatusLabel.Text = "Status:"
    End Sub

    ''' <summary>
    ''' Handles the Click event of the uiButtonOpenFile control.
    ''' Opens a file via an OpenFileDialog
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub uiButtonOpenFile_Click(ByVal sender As Object,
                                       ByVal e As System.EventArgs) _
                                       Handles uiButtonOpenFile.Click
        Dim ofd As OpenFileDialog = Nothing
        Try
            ofd = New OpenFileDialog
            With ofd
                .CheckFileExists = True
                .CheckPathExists = True
                .Title = "Choose Source Image"
                .Multiselect = False
                'Filter by Supported Image Types
                'OR by Individual Image Types
                .Filter =
                    "Supported Image Types (*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff;)|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff;" &
                    "|BMP Images (*.bmp)|*.bmp" &
                    "|GIF Images (*.gif)|*.gif" &
                    "|JPG Images (*.jpeg;*.jpg)|*.jpeg;*.jpg;" &
                    "|PNG Images (*.png)|*.png" &
                    "|TIFF Images (*.tiff)|*.tiff"
            End With

            If (ofd.ShowDialog = Windows.Forms.DialogResult.OK) Then
                SetSourceFile(ofd.FileName)
            End If
        Finally
            If ofd IsNot Nothing Then
                ofd.Dispose()
                ofd = Nothing
            End If
        End Try
    End Sub

#Region "Drag & Drop Handling"

    ''' <summary>
    ''' Handles the DragDrop event of the BitmapMaskerMain control.
    ''' Sets the SourceFile = the file dropped into the form.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DragEventArgs" /> instance containing the event data.</param>
    Private Sub BitmapMaskerMain_DragDrop(ByVal sender As Object,
                                          ByVal e As System.Windows.Forms.DragEventArgs) _
                                          Handles Me.DragDrop
        Dim fileName As String = (CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString)
        SetSourceFile(fileName)
    End Sub

    ''' <summary>
    ''' Handles the DragEnter event of the BitmapMaskerMain control.
    ''' Only allows our supported image file types. If it is not a supported type... it is aborted.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.DragEventArgs" /> instance containing the event data.</param>
    Private Sub BitmapMaskerMain_DragEnter(ByVal sender As Object,
                                           ByVal e As System.Windows.Forms.DragEventArgs) _
                                           Handles Me.DragEnter
        Dim fileName As String = (CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString)
        Dim extension As String = System.IO.Path.GetExtension(fileName)
        Select Case extension
            Case ".bmp", ".gif", ".jpeg", ".jpg", ".png", ".tiff"
                e.Effect = DragDropEffects.Copy
            Case Else
                e.Effect = DragDropEffects.None
        End Select
    End Sub

#End Region

#End Region

#Region "Masking"

    ''' <summary>
    ''' Handles the Click event of the uiButtonCreateMask control.
    ''' Calls appropriate masking methods.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Async Sub UiButtonCreateMask_Click(ByVal sender As Object,
                                     ByVal e As System.EventArgs) _
                                     Handles uiButtonCreateMask.Click

        If SourceAsBitmap IsNot Nothing Then
            myToken = New CancellationTokenSource
            Await StartProgressBar(myToken)
        Else
            MessageBox.Show("No Source File Detected.")
        End If
    End Sub

    Private Async Function StartProgressBar(ct As CancellationTokenSource) As Tasks.Task
        Me.uiToolStripProgressBar.Value = 0
        'Create an event handler for the function used to report progress
        Dim progressTarget As Action(Of Integer)
        'Assign the handler to our function. 
        progressTarget = AddressOf UpdateProgress
        myProgress = New Progress(Of Integer)(progressTarget)
        Dim newMask As Bitmap = Await Tasks.Task(Of Bitmap).Run(Function() CreateMask(SourceAsBitmap, myProgress))
        UpdateProgress("Saving Files")
        SaveBitmapVersions()
    End Function

    Private Sub UpdateProgress(Value As Integer)
        Me.uiToolStripProgressBar.Value = Value
    End Sub
    Private Sub UpdateProgress(Value As Integer, Maximum As Integer)
        Me.uiToolStripProgressBar.Value = Value
        Me.uiToolStripProgressBar.Maximum = Maximum
    End Sub
    Private Sub UpdateProgress(Value As Integer, Maximum As Integer, Label As String)
        Me.uiToolStripProgressBar.Value = Value
        Me.uiToolStripProgressBar.Maximum = Maximum
        Me.uiToolStripStatusLabel.Text = Label
    End Sub
    Private Sub UpdateProgress(Label As String)
        Me.uiToolStripStatusLabel.Text = Label
    End Sub

    ''' <summary>
    ''' Creates the mask.
    ''' Iterivaly tests each pixel.
    ''' If it is black or transparent, it is changed to white.
    ''' If it is any other color, it is changed to black.
    ''' </summary>
    Private Function CreateMask(ByVal bitmapToMask As System.Drawing.Bitmap, progress As IProgress(Of Integer)) As Bitmap
        progress.Report((0 / bitmapToMask.Width) * 100)
        UpdateProgress("Cloning the Image")
        'We want to work on a copy of the bitmap, so the displayed version doesn't ever change. 
        Dim tempBitmapMask As Bitmap = bitmapToMask.Clone
        Me.BitmapMask = tempBitmapMask
        UpdateProgress("Creating the Mask")

        Dim blackAsArgb As Integer = Color.Black.ToArgb
        Dim transparentAsArgb As Integer = Color.Transparent.ToArgb
        tempBitmapMask.MakeTransparent()
        ' Loop through the images pixels to reset color.
        For x = 0 To tempBitmapMask.Width - 1
            For y = 0 To tempBitmapMask.Height - 1
                'Determine what the current color is.
                Select Case tempBitmapMask.GetPixel(x, y).ToArgb
                    Case blackAsArgb, transparentAsArgb
                        'If the color is black or transparent (used to mask transparent types... e.g. png files)
                        'Change color to white (used to mask using bitmasking)
                        tempBitmapMask.SetPixel(x, y, Color.White)
                    Case Else
                        'If the color is anything else, we want it displayed, so change it to black.
                        tempBitmapMask.SetPixel(x, y, Color.Black)
                End Select
            Next
            'Increment ProgressBar
            progress.Report((x / bitmapToMask.Width) * 100)
        Next
        'Reset the UI.
        progress.Report(0)


        'Set the property
        Me.BitmapMask = tempBitmapMask


        'Return it. 
        Return tempBitmapMask

    End Function

    ''' <summary>
    ''' Saves the bitmap versions of the image.
    ''' The bitmaps are saved in the same directory as the original image. 
    ''' </summary>
    Private Sub SaveBitmapVersions()
        'Save the new Bitmask
        Dim path As String = System.IO.Path.GetDirectoryName(SourceImageFileName)
        Dim maskFileName As String = System.IO.Path.GetFileNameWithoutExtension(SourceImageFileName) & "_Mask.bmp"
        Dim sourceFileName As String = System.IO.Path.GetFileNameWithoutExtension(SourceImageFileName) & "_Icon.bmp"
        Dim maskFullPath As String = System.IO.Path.Combine(path, maskFileName)
        Dim sourceFullPath As String = System.IO.Path.Combine(path, sourceFileName)

        If BitmapMask IsNot Nothing Then
            Try
                BitmapMask.Save(maskFullPath)
                UpdateProgress("Bitmap Saved")
            Catch ex As Exception
                MessageBox.Show("An error occured while saving the bitmap mask of the image:" & Environment.NewLine & ex.Message)
            End Try
        Else
            MessageBox.Show("The bitmap mask of the image could not be saved because it does not exist.")
        End If

        If SourceAsBitmap IsNot Nothing Then
            Try
                SourceAsBitmap.Save(sourceFullPath)
                UpdateProgress("Source As Bitmap Saved")
            Catch ex As Exception
                MessageBox.Show("An error occured while saving the bitmap version of the image:" & Environment.NewLine & ex.Message)
            End Try
        Else
            MessageBox.Show("The bitmap version of the image could not be saved because it does not exist.")
        End If
    End Sub

#End Region

    ''' <summary>
    ''' Scale a bitmap by a scale factor, growing or shrinking 
    ''' both axes, maintaining the aspect ratio.
    ''' This does not maintain transparencies, so scaling by factor 
    ''' of 1 effectively converts transparent pixels to black pixels.
    ''' </summary>
    ''' <param name="sourceBitmap">
    ''' Bitmap to scale
    ''' </param>
    ''' <param name="scale_factor">
    ''' Factor by which to scale
    ''' </param>
    ''' <returns>
    ''' New bitmap containing the original image, scaled by the 
    ''' scale factor
    ''' </returns>
    ''' <citation>
    ''' A Bitmap Manipulation Class With Support For Format 
    ''' Conversion, Bitmap Retrieval from a URL, Overlays, etc.,
    ''' Adam Nelson, The Code Project, September 2003.
    ''' </citation>
    Private Function ScaleBitmap(ByVal sourceBitmap As Bitmap,
                                 ByVal scale_factor As Single,
                                 ByVal maintainAlphaChannels As Boolean) _
                                 As Bitmap
        Dim g As Graphics = Nothing
        Dim new_bitmap As Bitmap = Nothing
        Dim rectangle As Rectangle

        Dim height As Integer = CInt(Math.Truncate(CSng(sourceBitmap.Size.Height) * scale_factor))
        Dim width As Integer = CInt(Math.Truncate(CSng(sourceBitmap.Size.Width) * scale_factor))
        'Using Format24bppRgb pixel format does not maintain alpha transparencies.
        If maintainAlphaChannels Then
            new_bitmap = New Bitmap(width, height, sourceBitmap.PixelFormat)
        Else
            new_bitmap = New Bitmap(width, height, Imaging.PixelFormat.Format24bppRgb)
        End If

        g = Graphics.FromImage(DirectCast(new_bitmap, Image))
        g.InterpolationMode = Drawing2D.InterpolationMode.High
        g.ScaleTransform(scale_factor, scale_factor)

        rectangle = New Rectangle(0, 0, sourceBitmap.Size.Width, sourceBitmap.Size.Height)
        g.DrawImage(sourceBitmap, rectangle, rectangle, GraphicsUnit.Pixel)
        g.Dispose()

        Return (new_bitmap)
    End Function

    ''' <summary>
    ''' Scales the image using GetThumnailImage.
    ''' </summary>
    ''' <param name="sourceImage">The source image.</param>
    ''' <param name="scale_factor">The scale_factor.</param>
    ''' <returns>The scaled image</returns>
    ''' <remarks>Unused</remarks>
    Private Function ScaleImage(ByVal sourceImage As System.Drawing.Image,
                                ByVal scale_factor As Single) _
                                As System.Drawing.Image
        Dim scaledImage As System.Drawing.Image
        Dim scaledHeight As Integer = CInt(Math.Truncate(CSng(sourceImage.Size.Height) * scale_factor))
        Dim scaledWidth As Integer = CInt(Math.Truncate(CSng(sourceImage.Size.Width) * scale_factor))
        scaledImage = sourceImage.GetThumbnailImage(scaledWidth, scaledHeight, Nothing, New IntPtr(0))
        Return scaledImage
    End Function

End Class


