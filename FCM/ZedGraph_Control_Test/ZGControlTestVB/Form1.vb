Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ZedGraphControl2 As ZedGraph.ZedGraphControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ZedGraphControl2 = New ZedGraph.ZedGraphControl
        Me.SuspendLayout()
        '
        'ZedGraphControl2
        '
        Me.ZedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZedGraphControl2.Location = New System.Drawing.Point(0, 0)
        Me.ZedGraphControl2.Name = "ZedGraphControl2"
        Me.ZedGraphControl2.Size = New System.Drawing.Size(464, 390)
        Me.ZedGraphControl2.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(464, 390)
        Me.Controls.Add(Me.ZedGraphControl2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim junk As ZedGraph.ZedGraphControl
        junk = ZedGraphControl2
        junk.GraphPane.Title = "Test Case for VB"
        junk.IsShowPointValues = True
        Dim x(100) As Double
        Dim y(100) As Double
        Dim i As Integer
        Randomize()
        For i = 1 To 100
            x(i) = i / 100 * 6.3
            y(i) = Math.Sin(x(i))
        Next

        junk.GraphPane.AddCurve("Sine Wave", x, y, Color.Blue, ZedGraph.SymbolType.XCross)
        junk.GraphPane.AxisFill = New ZedGraph.Fill(Color.White, Color.LightGoldenrodYellow)
        junk.AxisChange()
    End Sub
End Class
