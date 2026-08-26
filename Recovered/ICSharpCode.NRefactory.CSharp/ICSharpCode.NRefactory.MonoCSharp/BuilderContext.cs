using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class BuilderContext
	{
		[Flags]
		public enum Options
		{
			CheckedScope = 0x1,
			AccurateDebugInfo = 0x2,
			OmitDebugInfo = 0x4,
			ConstructorScope = 0x8,
			AsyncBody = 0x10
		}

		public struct FlagsHandle : IDisposable
		{
			private readonly BuilderContext ec;

			private readonly Options invmask;

			private readonly Options oldval;

			public FlagsHandle(BuilderContext ec, Options flagsToSet)
			{
				this = new FlagsHandle(ec, flagsToSet, flagsToSet);
			}

			internal FlagsHandle(BuilderContext ec, Options mask, Options val)
			{
				this.ec = ec;
				invmask = ~mask;
				oldval = (ec.flags & mask);
				ec.flags = ((ec.flags & invmask) | (val & mask));
			}

			public void Dispose()
			{
				ec.flags = ((ec.flags & invmask) | oldval);
			}
		}

		protected Options flags;

		public bool HasSet(Options options)
		{
			return (flags & options) == options;
		}

		public FlagsHandle With(Options options, bool enable)
		{
			return new FlagsHandle(this, options, enable ? options : ((Options)0));
		}
	}
}
