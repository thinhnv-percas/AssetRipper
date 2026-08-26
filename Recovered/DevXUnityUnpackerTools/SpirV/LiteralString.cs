using System.Collections.Generic;
using System.Text;

namespace SpirV
{
	public class LiteralString : Literal
	{
		public override bool ReadValue(IList<uint> words, int index, out object value, out int wordsUsed)
		{
			wordsUsed = 1;
			int num = 0;
			byte[] array = new byte[(words.Count - index) * 4];
			for (int i = index; i < words.Count; i++)
			{
				uint num2 = words[i];
				byte b = (byte)(num2 & 0xFF);
				if (b == 0)
				{
					break;
				}
				array[num++] = b;
				byte b2 = (byte)((num2 >> 8) & 0xFF);
				if (b2 == 0)
				{
					break;
				}
				array[num++] = b2;
				byte b3 = (byte)((num2 >> 16) & 0xFF);
				if (b3 == 0)
				{
					break;
				}
				array[num++] = b3;
				byte b4 = (byte)(num2 >> 24);
				if (b4 == 0)
				{
					break;
				}
				array[num++] = b4;
				wordsUsed++;
			}
			value = Encoding.UTF8.GetString(array, 0, num);
			return true;
		}
	}
}
