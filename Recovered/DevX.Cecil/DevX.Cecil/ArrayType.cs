using DevX.Cecil.Signatures;
using System.Text;

namespace DevX.Cecil
{
	public sealed class ArrayType : TypeSpecification
	{
		private ArrayDimensionCollection m_dimensions;

		public ArrayDimensionCollection Dimensions => m_dimensions;

		public int Rank => m_dimensions.Count;

		public bool IsSizedArray
		{
			get
			{
				if (Rank != 1)
				{
					return false;
				}
				ArrayDimension arrayDimension = m_dimensions[0];
				return arrayDimension.UpperBound == 0;
			}
		}

		public override string Name => base.Name + Suffix();

		public override string FullName => base.FullName + Suffix();

		internal ArrayType(TypeReference elementType, ArrayShape shape)
			: base(elementType)
		{
			m_dimensions = new ArrayDimensionCollection(this);
			for (int i = 0; i < shape.Rank; i++)
			{
				int lb = 0;
				int ub = 0;
				if (i < shape.NumSizes)
				{
					if (i < shape.NumLoBounds)
					{
						lb = shape.LoBounds[i];
						ub = shape.LoBounds[i] + shape.Sizes[i] - 1;
					}
					else
					{
						ub = shape.Sizes[i] - 1;
					}
				}
				m_dimensions.Add(new ArrayDimension(lb, ub));
			}
		}

		public ArrayType(TypeReference elementType, int rank)
			: base(elementType)
		{
			m_dimensions = new ArrayDimensionCollection(this);
			for (int i = 0; i < rank; i++)
			{
				m_dimensions.Add(new ArrayDimension(0, 0));
			}
		}

		public ArrayType(TypeReference elementType)
			: this(elementType, 1)
		{
		}

		private string Suffix()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			for (int i = 0; i < m_dimensions.Count; i++)
			{
				ArrayDimension arrayDimension = m_dimensions[i];
				string text = arrayDimension.ToString();
				if (i < m_dimensions.Count - 1)
				{
					stringBuilder.Append(",");
				}
				if (text.Length > 0)
				{
					stringBuilder.Append(" ");
					stringBuilder.Append(text);
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
