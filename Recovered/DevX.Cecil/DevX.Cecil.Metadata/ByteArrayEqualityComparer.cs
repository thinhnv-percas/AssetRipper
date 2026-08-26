using System.Collections;

namespace DevX.Cecil.Metadata
{
	internal class ByteArrayEqualityComparer : IHashCodeProvider, IComparer
	{
		public static readonly ByteArrayEqualityComparer Instance = new ByteArrayEqualityComparer();

		public int GetHashCode(object obj)
		{
			byte[] array = (byte[])obj;
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				num = ((num * 37) ^ array[i]);
			}
			return num;
		}

		public int Compare(object a, object b)
		{
			byte[] array = (byte[])a;
			byte[] array2 = (byte[])b;
			if (array == null || array2 == null)
			{
				return (array != array2) ? 1 : 0;
			}
			if (array.Length != array2.Length)
			{
				return 1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != array2[i])
				{
					return 1;
				}
			}
			return 0;
		}
	}
}
