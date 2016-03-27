#pragma once


namespace graphtest
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace ZedGraph;

	/// <summary> 
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the 
	///          'Resource File Name' property for the managed resource compiler tool 
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public __gc class Form1 : public System::Windows::Forms::Form
	{	
	public:
		Form1(void)
		{
			InitializeComponent();
		}
  
	protected:
		void Dispose(Boolean disposing)
		{
			if (disposing && components)
			{
				components->Dispose();
			}
			__super::Dispose(disposing);
		}

	private: ZedGraph::ZedGraphControl *  z1;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container * components;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->z1 = new ZedGraph::ZedGraphControl();
			this->SuspendLayout();
			// 
			// z1
			// 
			this->z1->Location = System::Drawing::Point(16, 32);
			this->z1->Name = S"z1";
			this->z1->Size = System::Drawing::Size(416, 240);
			this->z1->TabIndex = 2;
			// 
			// Form1
			// 
			this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
			this->ClientSize = System::Drawing::Size(456, 329);
			this->Controls->Add(this->z1);
			this->Name = S"Form1";
			this->Text = S"Form1";
			this->Load += new System::EventHandler(this, Form1_Load);
			this->ResumeLayout(false);

		}	

	private:
		System::Void Form1_Load(System::Object *  sender, System::EventArgs *  e)
		{
			z1->IsShowPointValues = true;
			z1->GraphPane->Title = "Test C++ Case";

			Double x[] = __gc new Double[100];
			Double y[] = __gc new Double[100];
			int		i;

			for ( i=0; i<100; i++ )
			{
				x[i] = (double) i / 100.0 * Math::PI * 2.0;
				y[i] = Math::Sin( x[i] );
			}

			z1->GraphPane->AddCurve( "Sine Wave", x, y, Color::Blue,
							ZedGraph::SymbolType::Diamond );
			z1->AxisChange();
			z1->Invalidate();
		}
	};
}


