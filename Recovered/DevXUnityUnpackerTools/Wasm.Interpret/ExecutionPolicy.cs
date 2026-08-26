using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class ExecutionPolicy
	{
		[CompilerGenerated]
		private bool _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020;

		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020;

		[CompilerGenerated]
		private bool _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A;

		public bool EnforceAlignment
		{
			get;
			private set;
		}

		public uint MaxCallStackDepth
		{
			get;
			private set;
		}

		public uint MaxMemorySize
		{
			get;
			private set;
		}

		public bool TranslateExceptions
		{
			get;
			private set;
		}

		private ExecutionPolicy()
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
