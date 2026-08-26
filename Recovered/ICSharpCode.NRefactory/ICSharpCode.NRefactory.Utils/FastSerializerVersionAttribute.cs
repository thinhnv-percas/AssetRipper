using System;

namespace ICSharpCode.NRefactory.Utils
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
	public class FastSerializerVersionAttribute : Attribute
	{
		private readonly int versionNumber;

		public int VersionNumber => versionNumber;

		public FastSerializerVersionAttribute(int versionNumber)
		{
			this.versionNumber = versionNumber;
		}

		internal static int GetVersionNumber(Type type)
		{
			object[] customAttributes = type.GetCustomAttributes(typeof(FastSerializerVersionAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				return 0;
			}
			return ((FastSerializerVersionAttribute)customAttributes[0]).VersionNumber;
		}
	}
}
