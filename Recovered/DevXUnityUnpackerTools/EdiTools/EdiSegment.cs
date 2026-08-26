using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EdiTools
{
	public class EdiSegment
	{
		[CompilerGenerated]
		private string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		private IList<EdiElement> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A;

		public string Id
		{
			get;
			set;
		}

		public IList<EdiElement> Elements
		{
			get;
			private set;
		}

		public string this[int position]
		{
			get
			{
				int num = position - 1;
				if (Elements.Count <= num || Elements[num] == null)
				{
					return null;
				}
				return Elements[num].Value;
			}
			set
			{
				int num = position - 1;
				if (!string.IsNullOrEmpty(value))
				{
					while (Elements.Count <= num)
					{
						Elements.Add(null);
					}
					Elements[num] = new EdiElement(value);
				}
				else if (Elements.Count > num)
				{
					Elements[num] = null;
				}
			}
		}

		public EdiSegment(string id = null)
		{
			Id = id;
			Elements = new List<EdiElement>();
		}

		public EdiElement Element(int position)
		{
			int num = position - 1;
			if (Elements.Count > num)
			{
				return Elements[num];
			}
			return null;
		}

		public void Element(int position, EdiElement element)
		{
			int num = position - 1;
			if (element != null)
			{
				while (Elements.Count <= num)
				{
					Elements.Add(null);
				}
				Elements[num] = element;
			}
			else if (Elements.Count > num)
			{
				Elements[num] = null;
			}
		}

		public override string ToString()
		{
			return ToString(null);
		}

		public string ToString(EdiOptions options)
		{
			StringBuilder stringBuilder = new StringBuilder(Id);
			if (Id.Equals("UNA", StringComparison.OrdinalIgnoreCase))
			{
				stringBuilder.Append((options != null && options.ComponentSeparator.HasValue) ? options.ComponentSeparator : new char?(EdiOptions.DefaultComponentSeparator)).Append((options != null && options.ElementSeparator.HasValue) ? options.ElementSeparator : new char?(EdiOptions.DefaultElementSeparator)).Append((options != null && options.DecimalIndicator.HasValue) ? options.DecimalIndicator : new char?('.'))
					.Append((options != null && options.ReleaseCharacter.HasValue) ? options.ReleaseCharacter : new char?(' '))
					.Append(' ');
			}
			else
			{
				int num = _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020();
				for (int i = 0; i <= num; i++)
				{
					stringBuilder.Append((options != null && options.ElementSeparator.HasValue) ? options.ElementSeparator : new char?(EdiOptions.DefaultElementSeparator));
					if (Elements[i] != null)
					{
						if (Id.Equals("ISA", StringComparison.OrdinalIgnoreCase) && Elements[i].Value.Length == 1 && ((i == 15 && Elements[i].Value[0] == ((options != null && options.ComponentSeparator.HasValue) ? options.ComponentSeparator.Value : EdiOptions.DefaultComponentSeparator)) || (i == 10 && options != null && Elements[i].Value[0] == options.RepetitionSeparator)) && Elements[i].Repetitions.Count == 1 && Elements[i].Components.Count == 1)
						{
							stringBuilder.Append(Elements[i].Value);
						}
						else
						{
							stringBuilder.Append(Elements[i].ToString(options));
						}
					}
				}
			}
			stringBuilder.Append((options != null && options.SegmentTerminator.HasValue) ? options.SegmentTerminator : new char?(EdiOptions.DefaultSegmentTerminator));
			return stringBuilder.ToString();
		}

		private int _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020()
		{
			for (int num = Elements.Count - 1; num >= 0; num--)
			{
				if (Elements[num] != null)
				{
					return num;
				}
			}
			return -1;
		}
	}
}
