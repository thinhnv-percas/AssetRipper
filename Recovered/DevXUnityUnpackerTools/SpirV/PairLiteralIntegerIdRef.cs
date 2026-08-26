using System.Collections.Generic;

namespace SpirV
{
	public class PairLiteralIntegerIdRef : OperandType
	{
		public override bool ReadValue(IList<uint> words, int index, out object value, out int wordsUsed)
		{
			uint selector = words[index];
			ObjectReference label = new ObjectReference(words[index + 1]);
			value = new _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A<uint, ObjectReference>(selector, label);
			wordsUsed = 2;
			return true;
		}
	}
}
