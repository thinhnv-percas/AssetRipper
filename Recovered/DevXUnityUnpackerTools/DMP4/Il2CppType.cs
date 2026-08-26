using System.Runtime.CompilerServices;

namespace DMP4
{
	public class Il2CppType
	{
		public class Union
		{
			public ulong dummy;

			public long klassIndex => (long)dummy;

			public ulong typeHandle => dummy;

			public ulong type => dummy;

			public ulong array => dummy;

			public long genericParameterIndex => (long)dummy;

			public ulong genericParameterHandle => dummy;

			public ulong generic_class => dummy;
		}

		public ulong datapoint;

		public uint bits;

		[CompilerGenerated]
		internal Union _0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal Il2CppTypeEnum _0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020;

		public Union data
		{
			get;
			set;
		}

		public uint attrs
		{
			get;
			set;
		}

		public Il2CppTypeEnum type
		{
			get;
			set;
		}

		public uint num_mods
		{
			get;
			set;
		}

		public uint byref
		{
			get;
			set;
		}

		public uint pinned
		{
			get;
			set;
		}

		public void Init()
		{
			attrs = (bits & 0xFFFF);
			type = (Il2CppTypeEnum)((bits >> 16) & 0xFF);
			num_mods = ((bits >> 24) & 0x3F);
			byref = ((bits >> 30) & 1);
			pinned = bits >> 31;
			data = new Union
			{
				dummy = datapoint
			};
		}
	}
}
