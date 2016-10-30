using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Regedit2.Components {
	public enum RegistryKeyValueDataType {
		String = 0,
		Word = 1,
		Binary = 2,
		Unknown = 3
	}

	public class RegistryKeyValue {
		public RegistryKeyValue ( ) {

		}
		public String Name { get; set; }
		public RegistryKeyValueDataType Type {
			get {
				switch ( TypeName ) {
					case RegistryValueKind.Binary:
						return RegistryKeyValueDataType.Binary;
					case RegistryValueKind.DWord:
					case RegistryValueKind.QWord:
						return RegistryKeyValueDataType.Word;
					case RegistryValueKind.ExpandString:
					case RegistryValueKind.MultiString:
					case RegistryValueKind.String:
						return RegistryKeyValueDataType.String;
					case RegistryValueKind.None:
					case RegistryValueKind.Unknown:
					default:
						return RegistryKeyValueDataType.Unknown;
				}
			}
		}
		public RegistryValueKind TypeName { get; set; }
		public object Data { get; set; }
		public String DataString {
			get {
				if ( Data == null ) {
					return Program.Settings.NullValue;
				}

				switch ( Type ) {
					case RegistryKeyValueDataType.Binary:
						return ( (byte[])Data ).ToHex ( );
					case RegistryKeyValueDataType.Word:
						return string.Format ( "0x{0:X8} ({0})", Data ).ToLower();
					case RegistryKeyValueDataType.String:
					case RegistryKeyValueDataType.Unknown:
					default:
						return Data.ToString ( );
				}
			}
		}
	}
}
