using System;

namespace Cpp2ILInjected
{
	public sealed class AddressAttribute : Attribute
	{
		public string RVA;

		public string Offset;

		public string Length;
	}
}
