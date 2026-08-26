using System.Collections.Generic;

namespace SpirV
{
	public class LiteralSpecConstantOpInteger : Literal
	{
		public override bool ReadValue(IList<uint> words, int index, out object value, out int wordsUsed)
		{
			List<ObjectReference> list = new List<ObjectReference>();
			for (int i = index; i < words.Count; i++)
			{
				ObjectReference item = new ObjectReference(words[i]);
				list.Add(item);
			}
			value = list;
			wordsUsed = words.Count - index;
			return true;
		}
	}
}
