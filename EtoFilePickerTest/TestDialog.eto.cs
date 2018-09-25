using System;
using Eto.Forms;
using Eto.Drawing;

namespace EtoFilePickerTest
{
	partial class TestDialog : Dialog
	{
		int MasterPadding = 10;

		void InitializeComponent()
		{
			Title = "Preferences";
			Padding = MasterPadding;
			Resizable = true;

			// Uncommenting this line will cause the spawned TestDialog to be blank.
			//Size = new Size(300, 550);

			var lbxFgd = new ListBox() { AllowDrop = true };
			lbxFgd.Items.Add("test/quake4ericwTools.fgd");
			lbxFgd.Items.Add("test/func_instance.fgd");

			var btnAddFgd = new Button { Text = "Add..." };
			var btnRemoveFgd = new Button { Text = "Remove" };

			var btnFgdCombineStack = new RadioButton { Text = "Stack", Checked = true };
			var btnFgdCombineBlend = new RadioButton(btnFgdCombineStack) { Text = "Blend" };

			var layoutFgdAddRemove = new TableLayout(2, 1)
			{
				Spacing = new Size(MasterPadding, 0)
			};

			layoutFgdAddRemove.Add(btnAddFgd, 0, 0);
			layoutFgdAddRemove.Add(btnRemoveFgd, 1, 0);

			var tblFgdCombine = new TableLayout(2, 1)
			{
				Spacing = new Size(MasterPadding, 0)
			};

			tblFgdCombine.Add(btnFgdCombineStack, 0, 0);
			tblFgdCombine.Add(btnFgdCombineBlend, 1, 0);

			var stkFgd = new StackLayout
			{
				Spacing = MasterPadding,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				Items =
				{
					layoutFgdAddRemove,
					tblFgdCombine
				}
			};

			var tblFgd = new TableLayout(1, 2) { Spacing = new Size(0, MasterPadding) };

			tblFgd.Add(lbxFgd, 0, 0);
			tblFgd.Add(stkFgd, 0, 1);

			tblFgd.SetRowScale(0, true);
			tblFgd.SetRowScale(1, false);

			var gbxFgd = new GroupBox
			{
				Padding = new Padding(MasterPadding, MasterPadding, MasterPadding, 0),
				Text = "Entity definition files",
				Content = tblFgd,
				ID = "gbxFgd"
			};

			var lbxWad = new ListBox() { AllowDrop = true };
			lbxWad.Items.Add("test/quake.wad");
			lbxWad.Items.Add("test/jam6_tens.wad");

			var btnAddWad = new Button { Text = "Add..." };
			var btnRemoveWad = new Button { Text = "Remove" };

			var tblWadAddRemove = new TableLayout(2, 1)
			{
				Spacing = new Size(MasterPadding, 0)
			};

			tblWadAddRemove.Add(btnAddWad, 0, 0);
			tblWadAddRemove.Add(btnRemoveWad, 1, 0);

			var stkWad = new StackLayout
			{
				Spacing = MasterPadding,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				Items =
				{
					tblWadAddRemove
				}
			};

			var tblPalette = new TableLayout(2, 1)
			{
				Spacing = new Size(MasterPadding, 0)
			};

			tblPalette.Add(new Label { Text = "Palette:", VerticalAlignment = VerticalAlignment.Center }, 0, 0);
			tblPalette.Add(new FilePicker() { FileAction = Eto.FileAction.OpenFile }, 1, 0);

			var tblWad = new TableLayout(1, 3) { Spacing = new Size(0, MasterPadding) };

			tblWad.Add(lbxWad, 0, 0);
			tblWad.Add(stkWad, 0, 1);
			tblWad.Add(tblPalette, 0, 2);

			tblWad.SetRowScale(0, true);
			tblWad.SetRowScale(1, false);
			tblWad.SetRowScale(2, false);

			var gbxWad = new GroupBox
			{
				Padding = new Padding(MasterPadding, MasterPadding, MasterPadding, 0),
				Text = "Texture collections",
				Content = tblWad,
				ID = "gbxWad"
			};

			var tblMaster = new TableLayout(1, 2);

			tblMaster.Add(gbxFgd, 0, 0);
			tblMaster.Add(gbxWad, 0, 1);

			tblMaster.SetRowScale(0, true);
			tblMaster.SetRowScale(1, true);

			Content = new TabControl
			{
				BackgroundColor = SystemColors.ControlBackground,
				Pages =
				{
					new TabPage { Padding = MasterPadding, Text = "Resources", Content = tblMaster },
					new TabPage { Text = "Controls" }
				}
			};

			var cmdOK = new Command();
			cmdOK.Executed += (sender, e) => Close();

			var cmdCancel = new Command();
			cmdCancel.Executed += (sender, e) => Close();

			PositiveButtons.Add(new Button { Text = "OK", Command = cmdOK });
			NegativeButtons.Add(new Button { Text = "Cancel", Command = cmdCancel });
		}
	}
}
