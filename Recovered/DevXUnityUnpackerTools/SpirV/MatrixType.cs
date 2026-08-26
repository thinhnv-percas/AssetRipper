using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class MatrixType : Type
	{
		[CompilerGenerated]
		internal readonly VectorType _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A;

		[CompilerGenerated]
		internal readonly int _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020;

		public VectorType ColumnType
		{
			get;
		}

		public int ColumnCount
		{
			get;
		}

		public int RowCount => ColumnType.ComponentCount;

		public MatrixType(VectorType vectorType, int columnCount)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A = vectorType;
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020 = columnCount;
		}

		public override string ToString()
		{
			return $"{ColumnType}x{ColumnCount}";
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			return sb.Append(ColumnType).Append('x').Append(ColumnCount);
		}
	}
}
