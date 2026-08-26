using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.M68K
{
	public sealed class M68KOperationSize
	{
		private readonly M68KCpuOperationSize _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020;

		private readonly M68KFpuOperationSize _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A;

		[CompilerGenerated]
		private readonly M68KOperationSizeType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public M68KCpuOperationSize CpuOperationSize
		{
			get
			{
				if (Type != M68KOperationSizeType.Cpu)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "CpuOperationSize", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020;
			}
		}

		public M68KFpuOperationSize FpuOperationSize
		{
			get
			{
				if (Type != M68KOperationSizeType.Fpu)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "FpuOperationSize", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A;
			}
		}

		public M68KOperationSizeType Type
		{
			get;
		}

		internal M68KOperationSize(ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020 nativeOperationSize)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperationSize.Type;
			switch (Type)
			{
			case M68KOperationSizeType.Cpu:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020 = nativeOperationSize.Value.CpuOperationSize;
				break;
			case M68KOperationSizeType.Fpu:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A = nativeOperationSize.Value.FpuOperationSize;
				break;
			}
		}
	}
}
