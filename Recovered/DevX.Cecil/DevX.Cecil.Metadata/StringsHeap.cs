using System.Collections;
using System.Text;

namespace DevX.Cecil.Metadata
{
	public class StringsHeap : MetadataHeap
	{
		private IDictionary m_strings;

		public string this[uint index]
		{
			get
			{
				string text = m_strings[index] as string;
				if (text == null)
				{
					text = ReadStringAt(index);
					m_strings[index] = text;
				}
				return text;
			}
			set
			{
				m_strings[index] = value;
			}
		}

		internal StringsHeap(MetadataStream stream)
			: base(stream, "#Strings")
		{
			m_strings = new Hashtable();
		}

		private string ReadStringAt(uint index)
		{
			byte[] data = base.Data;
			int num = data.Length;
			if (index > num - 1)
			{
				return string.Empty;
			}
			int num2 = 0;
			for (int i = (int)index; i < num && data[i] != 0; i++)
			{
				num2++;
			}
			return Encoding.UTF8.GetString(data, (int)index, num2);
		}

		public override void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitStringsHeap(this);
		}
	}
}
