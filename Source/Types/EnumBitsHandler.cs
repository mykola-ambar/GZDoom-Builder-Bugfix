
#region ================== Copyright (c) 2007 Pascal vd Heiden

/*
 * Copyright (c) 2007 Pascal vd Heiden, www.codeimp.com
 * This program is released under GNU General Public License
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 */

#endregion

#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CodeImp.DoomBuilder.IO;
using CodeImp.DoomBuilder.Data;
using System.IO;
using System.Diagnostics;
using CodeImp.DoomBuilder.Config;
using System.Windows.Forms;
using CodeImp.DoomBuilder.Windows;

#endregion

namespace CodeImp.DoomBuilder.Types
{
	[TypeHandler(12)]
	internal class EnumBitsHandler : TypeHandler
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private EnumList list;
		private int value;

		#endregion

		#region ================== Properties

		public override bool IsBrowseable { get { return true; } }
		
		#endregion

		#region ================== Constructor

		// When set up for an argument
		public override void SetupArgument(ArgumentInfo arginfo)
		{
			base.SetupArgument(arginfo);

			// Keep enum list reference
			list = arginfo.Enum;
		}

		#endregion
		
		#region ================== Methods

		public override void Browse(IWin32Window parent)
		{
			value = BitFlagsForm.ShowDialog(parent, list, value);
		}

		public override void SetValue(object value)
		{
			int result;

			// Already an int?
			if(value is int)
			{
				// Set directly
				this.value = (int)value;
			}
			else
			{
				// Try parsing as string
				if(int.TryParse(value.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out result))
				{
					this.value = result;
				}
				else
				{
					this.value = 0;
				}
			}
		}

		public override object GetValue()
		{
			return this.value;
		}

		public override int GetIntValue()
		{
			return this.value;
		}

		public override string GetStringValue()
		{
			return this.value.ToString();
		}

		#endregion
	}
}
