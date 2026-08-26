using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class StructType : Type
	{
		[CompilerGenerated]
		internal readonly IList<Type> _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A;

		internal List<string> _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020;

		public IList<Type> MemberTypes
		{
			get;
		}

		public IList<string> MemberNames => _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020;

		public StructType(IList<Type> memberTypes)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A = memberTypes;
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020 = new List<string>();
			for (int i = 0; i < memberTypes.Count; i++)
			{
				_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.Add(string.Empty);
			}
		}

		public void SetMemberName(uint member, string name)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020[(int)member] = name;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ToString(stringBuilder);
			return stringBuilder.ToString();
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			sb.Append("struct {");
			for (int i = 0; i < MemberTypes.Count; i++)
			{
				MemberTypes[i].ToString(sb);
				if (!string.IsNullOrEmpty(_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020[i]))
				{
					sb.Append(' ');
					sb.Append(MemberNames[i]);
				}
				sb.Append(';');
				if (i < MemberTypes.Count - 1)
				{
					sb.Append(' ');
				}
			}
			sb.Append('}');
			return sb;
		}
	}
}
