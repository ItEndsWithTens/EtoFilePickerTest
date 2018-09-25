using System;
using Eto.Forms;
using Eto.Drawing;

namespace EtoFilePickerTest
{
	public partial class TestDialog : Dialog
	{
		public TestDialog()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
		
			Location = (Point)(Screen.PrimaryScreen.Bounds.Center - ((SizeF)Size / 2.0f));
		}
	}
}
