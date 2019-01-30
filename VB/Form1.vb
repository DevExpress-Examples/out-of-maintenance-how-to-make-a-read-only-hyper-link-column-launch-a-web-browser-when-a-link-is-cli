Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Diagnostics
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace WindowsApplication7
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colHyperlink As DevExpress.XtraGrid.Columns.GridColumn
		Private colTrademark As DevExpress.XtraGrid.Columns.GridColumn
		Private repositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colTrademark = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colHyperlink = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemHyperLinkEdit1})
			Me.gridControl1.Size = New System.Drawing.Size(696, 422)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colTrademark, Me.colHyperlink})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.gridView1_MouseDown);
			' 
			' colTrademark
			' 
			Me.colTrademark.Caption = "Trademark"
			Me.colTrademark.FieldName = "Trademark"
			Me.colTrademark.Name = "colTrademark"
			Me.colTrademark.Visible = True
			Me.colTrademark.VisibleIndex = 1
			' 
			' colHyperlink
			' 
			Me.colHyperlink.Caption = "Hyperlink"
			Me.colHyperlink.ColumnEdit = Me.repositoryItemHyperLinkEdit1
			Me.colHyperlink.FieldName = "Hyperlink"
			Me.colHyperlink.Name = "colHyperlink"
			Me.colHyperlink.OptionsColumn.AllowEdit = False
			Me.colHyperlink.Visible = True
			Me.colHyperlink.VisibleIndex = 0
			' 
			' repositoryItemHyperLinkEdit1
			' 
			Me.repositoryItemHyperLinkEdit1.AutoHeight = False
			Me.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1"
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(696, 422)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim list = New BindingList(Of Car)()
			list.Add(New Car() With {.Trademark = "Mercedes-Benz", .Hyperlink = "http://www.mercedes.com"})
			list.Add(New Car() With {.Trademark = "Jaguar", .Hyperlink = "http://www.jaguar.com"})
			list.Add(New Car() With {.Trademark = "Lexus", .Hyperlink = "http://www.lexus.com"})
			gridControl1.DataSource = list
		End Sub

		Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridView1.MouseDown
			Dim hi As GridHitInfo = (TryCast(sender, GridView)).CalcHitInfo(New Point(e.X, e.Y))
			If hi.InRowCell AndAlso TypeOf hi.Column.ColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit Then
				Dim process As New Process()
				Dim v As Object = (TryCast(sender, GridView)).GetRowCellValue(hi.RowHandle, hi.Column)
				process.StartInfo.FileName = (If(v Is Nothing, String.Empty, v.ToString()))
				process.StartInfo.Verb = "open"
				process.StartInfo.WindowStyle = ProcessWindowStyle.Normal
				Try
					process.Start()
				Catch
				End Try
			End If
		End Sub
	End Class
	Public Class Car
		Private privateTrademark As String
		Public Property Trademark() As String
			Get
				Return privateTrademark
			End Get
			Set(ByVal value As String)
				privateTrademark = value
			End Set
		End Property
		Private privateHyperlink As String
		Public Property Hyperlink() As String
			Get
				Return privateHyperlink
			End Get
			Set(ByVal value As String)
				privateHyperlink = value
			End Set
		End Property
	End Class
End Namespace
