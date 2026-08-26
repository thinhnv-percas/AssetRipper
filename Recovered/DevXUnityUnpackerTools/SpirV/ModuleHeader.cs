using System;
using System.Runtime.CompilerServices;

namespace SpirV
{
	public struct ModuleHeader
	{
		[CompilerGenerated]
		internal Version _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A;

		[CompilerGenerated]
		internal string _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal string _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A;

		[CompilerGenerated]
		internal int _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020;

		[CompilerGenerated]
		internal uint _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A;

		[CompilerGenerated]
		internal uint _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020;

		public Version Version
		{
			get;
			set;
		}

		public string GeneratorVendor
		{
			get;
			set;
		}

		public string GeneratorName
		{
			get;
			set;
		}

		public int GeneratorVersion
		{
			get;
			set;
		}

		public uint Bound
		{
			get;
			set;
		}

		public uint Reserved
		{
			get;
			set;
		}
	}
}
