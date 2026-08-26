namespace ICSharpCode.NRefactory.Utils
{
	public class FormatItem : FormatStringSegmentBase
	{
		public int Index
		{
			get;
			private set;
		}

		public int? Alignment
		{
			get;
			private set;
		}

		public string FormatString
		{
			get;
			private set;
		}

		public FormatItem(int index, int? alignment = default(int?), string formatString = null)
		{
			Index = index;
			Alignment = alignment;
			FormatString = formatString;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj.GetType() != typeof(FormatItem))
			{
				return false;
			}
			FormatItem other = (FormatItem)obj;
			return FieldsEquals(other);
		}

		public bool Equals(FormatItem other)
		{
			if (other == null)
			{
				return false;
			}
			return FieldsEquals(other);
		}

		private bool FieldsEquals(FormatItem other)
		{
			if (Index == other.Index && Alignment == other.Alignment && FormatString == other.FormatString && base.StartLocation == other.StartLocation)
			{
				return base.EndLocation == other.EndLocation;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((((23 * 37 + Index.GetHashCode()) * 37 + Alignment.GetHashCode()) * 37 + FormatString.GetHashCode()) * 37 + base.StartLocation.GetHashCode()) * 37 + base.EndLocation.GetHashCode();
		}

		public override string ToString()
		{
			return $"[FormatItem: Index={Index}, Alignment={Alignment}, FormatString={FormatString}, StartLocation={base.StartLocation}, EndLocation={base.EndLocation}]";
		}
	}
}
