using System;
using System.Runtime.CompilerServices;

namespace Wasm
{
	public struct SectionName : IEquatable<SectionName>
	{
		[CompilerGenerated]
		internal SectionCode _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A;

		[CompilerGenerated]
		internal string _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A;

		public SectionCode Code
		{
			get;
			internal set;
		}

		public bool IsCustom => Code == SectionCode.Custom;

		public string CustomName
		{
			get;
			internal set;
		}

		public SectionName(SectionCode code)
		{
			Code = code;
			CustomName = null;
		}

		public SectionName(string customName)
		{
			Code = SectionCode.Custom;
			CustomName = customName;
		}

		public bool Equals(SectionName other)
		{
			if (IsCustom)
			{
				if (other.IsCustom)
				{
					return CustomName == other.CustomName;
				}
				return false;
			}
			return Code == other.Code;
		}

		public override int GetHashCode()
		{
			if (IsCustom)
			{
				return CustomName.GetHashCode();
			}
			return (int)Code;
		}

		public override bool Equals(object other)
		{
			if (other is SectionName)
			{
				return Equals((SectionName)other);
			}
			return false;
		}

		public static bool operator ==(SectionName first, SectionName second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(SectionName first, SectionName second)
		{
			return !first.Equals(second);
		}

		public override string ToString()
		{
			if (IsCustom)
			{
				return "Custom section '" + CustomName + "'";
			}
			return Code.ToString();
		}
	}
}
