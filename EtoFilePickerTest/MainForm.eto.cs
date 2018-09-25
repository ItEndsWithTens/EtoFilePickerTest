using System;
using Eto.Forms;
using Eto.Drawing;

namespace EtoFilePickerTest
{
	partial class MainForm : Form
	{
		void InitializeComponent()
		{
			Padding = 10;

			// The most complex nesting, pulled from an as-yet-unreleased project.
			var cmdSpawnTestDialog = new Command { ToolBarText = "Spawn TestDialog" };
			var btnSpawnTestDialog = new Button { Text = cmdSpawnTestDialog.ToolBarText };
			btnSpawnTestDialog.Click += (sender, e) => new TestDialog().ShowModal(this);

			// Controls held directly in a container.
			var cmdFilePickerDirectlyInDialog = new Command { ToolBarText = "FilePicker directly in Dialog" };
			var btnFilePickerDirectlyInDialog = new Button { Text = cmdFilePickerDirectlyInDialog.ToolBarText };
			btnFilePickerDirectlyInDialog.Click += (sender, e) => new Dialog { Content = new FilePicker(), Size = new Size(300, 300) }.ShowModal(this);

			var cmdExpanderDirectlyInDialog = new Command { ToolBarText = "Expander directly in Dialog" };
			var btnExpanderDirectlyInDialog = new Button { Text = cmdExpanderDirectlyInDialog.ToolBarText };
			btnExpanderDirectlyInDialog.Click += (sender, e) => new Dialog { Content = new Expander { Content = new Button { Text = "Button!" } }, Size = new Size(300, 300) }.ShowModal(this);

			var cmdDocumentControlDirectlyInDialog = new Command { ToolBarText = "DocumentControl directly in Dialog" };
			var btnDocumentControlDirectlyInDialog = new Button { Text = cmdDocumentControlDirectlyInDialog.ToolBarText };
			btnDocumentControlDirectlyInDialog.Click += (sender, e) => new Dialog { Content = new DocumentControl { Pages = { new DocumentPage() } }, Size = new Size(300, 300) }.ShowModal(this);

			var lblDirect = new Label { ID = "directSpacer" };

			var cmdFilePickerDirectlyInForm = new Command { ToolBarText = "FilePicker directly in Form" };
			var btnFilePickerDirectlyInForm = new Button { Text = cmdFilePickerDirectlyInForm.ToolBarText };
			btnFilePickerDirectlyInForm.Click += (sender, e) => new Form { Content = new FilePicker(), Size = new Size(300, 300) }.Show();

			var cmdExpanderDirectlyInForm = new Command { ToolBarText = "Expander directly in Form" };
			var btnExpanderDirectlyInForm = new Button { Text = cmdExpanderDirectlyInForm.ToolBarText };
			btnExpanderDirectlyInForm.Click += (sender, e) => new Form { Content = new Expander { Content = new Button { Text = "Button!" } }, Size = new Size(300, 300) }.Show();

			var cmdDocumentControlDirectlyInForm = new Command { ToolBarText = "DocumentControl directly in Form" };
			var btnDocumentControlDirectlyInForm = new Button { Text = cmdDocumentControlDirectlyInForm.ToolBarText };
			btnDocumentControlDirectlyInForm.Click += (sender, e) => new Form { Content = new DocumentControl { Pages = { new DocumentPage() } }, Size = new Size(300, 300) }.Show();

			// Controls nested inside a TabPage, which is inside a TabControl.
			var cmdFilePickerNestedInDialog = new Command { ToolBarText = "FilePicker inside TabPage, within TabControl, in Dialog" };
			var btnFilePickerNestedInDialog = new Button { Text = cmdFilePickerNestedInDialog.ToolBarText };
			btnFilePickerNestedInDialog.Click += (sender, e) => new Dialog { Content = new TabControl { Pages = { new TabPage { Text = "FilePicker", Content = new FilePicker() } }, Size = new Size(300, 300) } }.ShowModal(this);

			var cmdExpanderNestedInDialog = new Command { ToolBarText = "Expander inside TabPage, within TabControl, in Dialog" };
			var btnExpanderNestedInDialog = new Button { Text = cmdExpanderNestedInDialog.ToolBarText };
			btnExpanderNestedInDialog.Click += (sender, e) => new Dialog { Content = new TabControl { Pages = { new TabPage { Text = "Expander", Content = new Expander { Content = new Button { Text = "Button!" } } } }, Size = new Size(300, 300) } }.ShowModal(this);

			var lblNested = new Label { ID = "nestedSpacer" };

			var cmdFilePickerNestedInForm = new Command { ToolBarText = "FilePicker inside TabPage, within TabControl, in Form" };
			var btnFilePickerNestedInForm = new Button { Text = cmdFilePickerNestedInForm.ToolBarText };
			btnFilePickerNestedInForm.Click += (sender, e) => new Form { Content = new TabControl { Pages = { new TabPage { Text = "FilePicker", Content = new FilePicker() } }, Size = new Size(300, 300) } }.Show();

			var cmdExpanderNestedInForm = new Command { ToolBarText = "Expander inside TabPage, within TabControl, in Form" };
			var btnExpanderNestedInForm = new Button { Text = cmdExpanderNestedInForm.ToolBarText };
			btnExpanderNestedInForm.Click += (sender, e) => new Form { Content = new TabControl { Pages = { new TabPage { Text = "Expander", Content = new Expander { Content = new Button { Text = "Button!" } } } }, Size = new Size(300, 300) } }.Show();

			var stkDirect = new StackLayout
			{
				Orientation = Orientation.Vertical,
				Spacing = 10,
				Items =
				{
					btnFilePickerDirectlyInDialog,
					btnExpanderDirectlyInDialog,
					btnDocumentControlDirectlyInDialog,
					lblDirect,
					btnFilePickerDirectlyInForm,
					btnExpanderDirectlyInForm,
					btnDocumentControlDirectlyInForm
				}
			};

			var stkNested = new StackLayout
			{
				Orientation = Orientation.Vertical,
				Spacing = 10,
				Items =
				{
					btnFilePickerNestedInDialog,
					btnExpanderNestedInDialog,
					lblNested,
					btnFilePickerNestedInForm,
					btnExpanderNestedInForm
				}
			};

			var stkTopLevel = new StackLayout
			{
				Orientation = Orientation.Horizontal,
				Spacing = 50,
				Items =
				{
					btnSpawnTestDialog,
					stkDirect,
					stkNested
				}
			};

			Content = stkTopLevel;

			var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
			quitCommand.Executed += (sender, e) => Application.Instance.Quit();

			Menu = new MenuBar
			{
				Items =
				{
					new ButtonMenuItem { Text = "&File" }
				},
				QuitItem = quitCommand
			};
		}
	}
}
