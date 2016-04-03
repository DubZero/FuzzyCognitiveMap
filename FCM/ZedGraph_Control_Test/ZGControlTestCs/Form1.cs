using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ZedGraph;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private ZedGraph.ZedGraphControl z1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.z1 = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedGraphControl1
			// 
			this.z1.Location = new System.Drawing.Point(0, 0);
			this.z1.Name = "zedGraphControl1";
			this.z1.Size = new System.Drawing.Size(680, 414);
			this.z1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 414);
			this.Controls.Add( this.z1 );
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.Load += new System.EventHandler( Form1_Load );

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run( new Form1() );
		}

		private void Form1_Load( object sender, System.EventArgs e )
		{
			z1.IsShowPointValues = true;
			z1.GraphPane.Title = "Test Case for C#";
			double[] x = new double[100];
			double[] y = new double[100];
			int	i;
			for ( i=0; i<100; i++ )
			{
				x[i] = (double) i / 100.0 * Math.PI * 2.0;
				y[i] = Math.Sin( x[i] );
			}
			z1.GraphPane.AddCurve( "Sine Wave", x, y, Color.Red, SymbolType.Square );
			z1.AxisChange();
			z1.Invalidate();
		}
	}
}
