using System;

namespace Cpp2ILInjected
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public sealed class AttributeAttribute : Attribute
	{
		public Type Type;

		public string RVA;

		public string Offset;
	}
}
