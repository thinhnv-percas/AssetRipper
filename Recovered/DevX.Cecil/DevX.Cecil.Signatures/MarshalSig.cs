namespace DevX.Cecil.Signatures
{
	internal sealed class MarshalSig
	{
		public interface IMarshalSigSpec
		{
		}

		public sealed class Array : IMarshalSigSpec
		{
			public NativeType ArrayElemType;

			public int ParamNum;

			public int ElemMult;

			public int NumElem;

			public Array()
			{
				ParamNum = 0;
				ElemMult = 0;
				NumElem = 0;
			}
		}

		public sealed class CustomMarshaler : IMarshalSigSpec
		{
			public string Guid;

			public string UnmanagedType;

			public string ManagedType;

			public string Cookie;
		}

		public sealed class FixedArray : IMarshalSigSpec
		{
			public int NumElem;

			public NativeType ArrayElemType;

			public FixedArray()
			{
				NumElem = 0;
				ArrayElemType = NativeType.NONE;
			}
		}

		public sealed class SafeArray : IMarshalSigSpec
		{
			public VariantType ArrayElemType;
		}

		public sealed class FixedSysString : IMarshalSigSpec
		{
			public int Size;
		}

		public NativeType NativeInstrinsic;

		public IMarshalSigSpec Spec;

		public MarshalSig(NativeType nt)
		{
			NativeInstrinsic = nt;
		}
	}
}
