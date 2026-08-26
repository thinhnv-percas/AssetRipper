using System;
using System.Globalization;

namespace ICSharpCode.NRefactory.Utils
{
	[Serializable]
	[CLSCompliant(false)]
	public struct BitVector16 : IEquatable<BitVector16>
	{
		private ushort data;

		public bool this[ushort mask]
		{
			get
			{
				return (data & mask) != 0;
			}
			set
			{
				if (value)
				{
					data |= mask;
				}
				else
				{
					data &= (ushort)(~mask);
				}
			}
		}

		public ushort Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is BitVector16)
			{
				return Equals((BitVector16)obj);
			}
			return false;
		}

		public bool Equals(BitVector16 other)
		{
			return data == other.data;
		}

		public override int GetHashCode()
		{
			return data;
		}

		public static bool operator ==(BitVector16 left, BitVector16 right)
		{
			return left.data == right.data;
		}

		public static bool operator !=(BitVector16 left, BitVector16 right)
		{
			return left.data != right.data;
		}

		public override string ToString()
		{
			return data.ToString("x4", CultureInfo.InvariantCulture);
		}
	}
}
