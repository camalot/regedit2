using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regedit2.Components {
	public static class ByteArrayExtension {

		public static String ToHex ( this byte[] bytes, int max ) {
			int high = bytes.Length > max ? max : bytes.Length;
			StringBuilder sb = new StringBuilder ( );
			for ( int i = 0; i < high; i++ ) {
				sb.AppendFormat ( "{0:x2}{1}", bytes[i], i != high - 1 ? " " : string.Empty );
			}
			return sb.ToString ( );
		}

		public static String ToHex ( this byte[] bytes ) {
			return ToHex ( bytes, 30 );
		}
	}
}
