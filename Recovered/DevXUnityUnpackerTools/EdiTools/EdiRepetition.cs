using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EdiTools
{
	public class EdiRepetition : EdiValue
	{
		[CompilerGenerated]
		internal IList<EdiComponent> _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020;

		public IList<EdiComponent> Components
		{
			get;
			internal set;
		}

		public override string Value
		{
			get
			{
				return Components[0].Value;
			}
			set
			{
				Components.Clear();
				Components.Add(new EdiComponent(value));
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

		public EdiRepetition()
		{
			Components = new List<EdiComponent>();
		}

		public EdiRepetition(string value)
		{
			Components = new List<EdiComponent>
			{
				new EdiComponent(value)
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
			int num = _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A();
			for (int i = 0; i <= num; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append((options != null && options.ComponentSeparator.HasValue) ? options.ComponentSeparator.Value : EdiOptions.DefaultComponentSeparator);
				}
				if (Components[i] != null)
				{
					stringBuilder.Append(Components[i].ToString(options));
				}
			}
			return stringBuilder.ToString();
		}

		internal int _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A()
		{
			for (int num = Components.Count - 1; num >= 0; num--)
			{
				if (Components[num] != null)
				{
					return num;
				}
			}
			return -1;
		}
	}
}
