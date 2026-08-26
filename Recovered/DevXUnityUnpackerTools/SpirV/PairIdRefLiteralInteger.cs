using System.Collections.Generic;

namespace SpirV
{
	public class PairIdRefLiteralInteger : OperandType
	{
		public override bool ReadValue(IList<uint> words, int index, out object value, out int wordsUsed)
		{
			ObjectReference type = new ObjectReference(words[index]);
			uint member = words[index + 1];
			value = new _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020<ObjectReference, uint>(type, member);
			wordsUsed = 2;
			return true;
		}
	}
}
