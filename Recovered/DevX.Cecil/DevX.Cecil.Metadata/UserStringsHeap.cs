using System.Collections;

namespace DevX.Cecil.Metadata
{
	public class UserStringsHeap : MetadataHeap
	{
		private readonly IDictionary m_strings;

		public string this[uint offset]
		{
			get
			{
				string text = m_strings[offset] as string;
				if (text != null)
				{
					return text;
				}
				text = ReadStringAt((int)offset);
				if (text != null && text.Length != 0)
				{
					m_strings[offset] = text;
				}
				return text;
			}
			set
			{
				m_strings[offset] = value;
			}
		}

		internal UserStringsHeap(MetadataStream stream)
			: base(stream, "#US")
		{
			m_strings = new Hashtable();
		}

		private string ReadStringAt(int offset)
		{
			int num = Utilities.ReadCompressedInteger(base.Data, offset, out offset) - 1;
			if (num < 1)
			{
				return string.Empty;
			}
			char[] array = new char[num / 2];
			int i = offset;
			int num2 = 0;
			for (; i < offset + num; i += 2)
			{
				array[num2++] = (char)(base.Data[i] | (base.Data[i + 1] << 8));
			}
			return new string(array);
		}

		public override void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitUserStringsHeap(this);
		}
	}
}
