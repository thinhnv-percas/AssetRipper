using System;

namespace EdiTools
{
	public class EdiComponent : EdiValue
	{
		private string _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A;

		public override string Value
		{
			get
			{
				return _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A;
			}
			set
			{
				_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A = value;
			}
		}

		public EdiComponent(string value)
		{
			_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A = value;
		}

		public override string ToString()
		{
			return ToString(null);
		}

		public string ToString(EdiOptions options)
		{
			char value = (options != null && options.SegmentTerminator.HasValue) ? options.SegmentTerminator.Value : EdiOptions.DefaultSegmentTerminator;
			char value2 = (options != null && options.ElementSeparator.HasValue) ? options.ElementSeparator.Value : EdiOptions.DefaultElementSeparator;
			char value3 = (options != null && options.ComponentSeparator.HasValue) ? options.ComponentSeparator.Value : EdiOptions.DefaultComponentSeparator;
			if (options != null && options.ReleaseCharacter.HasValue)
			{
				return _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.Replace(options.ReleaseCharacter.ToString(), options.ReleaseCharacter.ToString() + options.ReleaseCharacter.ToString()).Replace(value.ToString(), options.ReleaseCharacter.ToString() + value.ToString()).Replace(value2.ToString(), options.ReleaseCharacter.ToString() + value2.ToString())
					.Replace(value3.ToString(), options.ReleaseCharacter.ToString() + value3.ToString());
			}
			if (_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.IndexOf(value) != -1)
			{
				throw new FormatException($"'{_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A}' contains the segment terminator.");
			}
			if (_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.IndexOf(value2) != -1)
			{
				throw new FormatException($"'{_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A}' contains the element separator.");
			}
			if (options != null && options.RepetitionSeparator.HasValue && _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.IndexOf(options.RepetitionSeparator.Value) != -1)
			{
				throw new FormatException($"'{_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A}' contains the repetition separator.");
			}
			if (_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.IndexOf(value3) != -1)
			{
				throw new FormatException($"'{_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A}' contains the component separator.");
			}
			return _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A;
		}
	}
}
