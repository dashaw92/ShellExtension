using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using SharpShell;
using SharpShell.Attributes;

namespace ShellExtension
{
	[ComVisible(true)]
	[COMServerAssociation(AssociationType.Directory)]
	public class ShellExtension : SharpShell.SharpContextMenu.SharpContextMenu
	{
		protected override bool CanShowMenu()
		{
			return SelectedItemPaths.Count() < 2;
		}

		protected override ContextMenuStrip CreateMenu()
		{
			var menu = new ContextMenuStrip();

			var jumpToFolder = new ToolStripMenuItem
			{
				Text = "Jump to non-empty"
			};

			jumpToFolder.Click += (sender, args) => enumerateFolders();

			menu.Items.Add(jumpToFolder);

			return menu;
		}

		private void enumerateFolders()
		{
			string selected = SelectedItemPaths.ElementAt(0);
			while (true)
			{
				if (Directory.GetFiles(selected).Length > 0 || Directory.GetDirectories(selected).Length > 1 || (Directory.GetDirectories(selected).Length < 1 && Directory.GetFiles(selected).Length < 1))
				{
					break;
				}
				else
				{
					selected = Directory.GetDirectories(selected)[0];
				}
			}
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.FileName = "explorer.exe";
			startInfo.Arguments = selected;
			process.StartInfo = startInfo;
			process.Start();
		}
	}
}