using System.Collections.Generic;

namespace SpirV
{
	public class PairIdRefIdRef : OperandType
	{
		public override bool ReadValue(IList<uint> words, int index, out object value, out int wordsUsed)
		{
			ObjectReference variable = new ObjectReference(words[index]);
			ObjectReference parent = new ObjectReference(words[index + 1]);
			value = new _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A<ObjectReference, ObjectReference>(variable, parent);
			wordsUsed = 2;
			return true;
		}
	}
}
