using System.Collections;

namespace DevX.Cecil
{
	internal sealed class HashCodeProvider : IHashCodeProvider
	{
		public static readonly HashCodeProvider Instance = new HashCodeProvider();

		private HashCodeProvider()
		{
		}

		public int GetHashCode(object o)
		{
			return o.GetHashCode();
		}
	}
}
