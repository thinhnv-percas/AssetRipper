using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class ExecutionPolicy
	{
		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		internal uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A;

		public bool EnforceAlignment
		{
			get;
			internal set;
		}

		public uint MaxCallStackDepth
		{
			get;
			internal set;
		}

		public uint MaxMemorySize
		{
			get;
			internal set;
		}

		public bool TranslateExceptions
		{
			get;
			internal set;
		}

		internal ExecutionPolicy()
		{
		}

		public static ExecutionPolicy Create(uint maxCallStackDepth = 256u, uint maxMemorySize = 0u, bool enforceAlignment = false, bool translateExceptions = true)
		{
			return new ExecutionPolicy
			{
				MaxCallStackDepth = maxCallStackDepth,
				EnforceAlignment = enforceAlignment,
				MaxMemorySize = maxMemorySize,
				TranslateExceptions = translateExceptions
			};
		}
	}
}
