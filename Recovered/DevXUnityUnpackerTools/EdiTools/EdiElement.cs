using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EdiTools
{
	public class EdiElement : EdiValue
	{
		[CompilerGenerated]
		internal IList<EdiRepetition> _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A;

		public IList<EdiRepetition> Repetitions
		{
			get;
			internal set;
		}

		public override string Value
		{
			get
			{
				return Repetitions[0].Value;
			}
			set
			{
				Repetitions.Clear();
				Repetitions.Add(new EdiRepetition(value));
			}
		}

		public IList<EdiComponent> Components
		{
			get
			{
				if (Repetitions.Count == 0)
				{
					Repetitions.Add(new EdiRepetition());
				}
				return Repetitions[0].Components;
			}
		}

		public string this[int position]
		{
			get
			{
				int num = position - 1;
				if (Components.Count <= num || Components[num] == null)
				{
					return null;
				}
				return Components[num].Value;
			}
			set
			{
				int num = position - 1;
				if (!string.IsNullOrEmpty(value))
				{
					while (Components.Count <= num)
					{
						Components.Add(null);
					}
					Components[num] = new EdiComponent(value);
				}
				else if (Components.Count > num)
				{
					Components[num] = null;
				}
			}
		}

		public EdiElement()
		{
			Repetitions = new List<EdiRepetition>();
		}

		public EdiElement(string value)
		{
			Repetitions = new List<EdiRepetition>
			{
				new EdiRepetition(value)
			};
		}

		public EdiComponent Component(int position)
		{
			int num = position - 1;
			if (Components.Count > num)
			{
				return Components[num];
			}
			return null;
		}

		public override string ToString()
		{
			return ToString(null);
		}

		public string ToString(EdiOptions options)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Repetitions.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append((options != null && options.RepetitionSeparator.HasValue) ? options.RepetitionSeparator.Value : EdiOptions.DefaultRepetitionSeparator);
				}
				stringBuilder.Append(Repetitions[i].ToString(options));
			}
			return stringBuilder.ToString();
		}
	}
}
