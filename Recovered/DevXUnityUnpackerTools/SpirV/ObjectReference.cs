using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class ObjectReference
	{
		[CompilerGenerated]
		private readonly uint _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		private ParsedInstruction _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020;

		public uint Id
		{
			get;
		}

		public ParsedInstruction Reference
		{
			get;
			private set;
		}

		public ObjectReference(uint id)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A = id;
		}

		public void Resolve(IDictionary<uint, ParsedInstruction> objects)
		{
			Reference = objects[Id];
		}

		public override string ToString()
		{
			return $"%{Id}";
		}

		public StringBuilder ToString(StringBuilder sb)
		{
			return sb.Append('%').Append(Id);
		}
	}
}
