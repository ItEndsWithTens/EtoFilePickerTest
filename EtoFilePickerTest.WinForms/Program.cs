﻿using System;
using Eto.Forms;

namespace EtoFilePickerTest.WinForms
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			new Application(Eto.Platforms.WinForms).Run(new MainForm());
		}
	}
}
