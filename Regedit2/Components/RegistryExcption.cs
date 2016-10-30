using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regedit2.Components {
	[Serializable]
	public class RegistryException : Exception {
		/// <summary>
		/// Initializes a new instance of the <see cref="RegistryException"/> class.
		/// </summary>
		public RegistryException ( ) { }
		/// <summary>
		/// Initializes a new instance of the <see cref="RegistryException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public RegistryException ( string message ) : base ( message ) { }
		/// <summary>
		/// Initializes a new instance of the <see cref="RegistryException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner.</param>
		public RegistryException ( string message, Exception inner ) : base ( message, inner ) { }
		protected RegistryException (
		System.Runtime.Serialization.SerializationInfo info,
		System.Runtime.Serialization.StreamingContext context )
			: base ( info, context ) { }
	}
}
