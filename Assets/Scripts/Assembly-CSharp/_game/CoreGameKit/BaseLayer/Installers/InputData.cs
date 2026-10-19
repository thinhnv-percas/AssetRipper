using Cpp2ILInjected;
using Unity.Mathematics;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x2000689")]
	public readonly struct InputData
	{
		[Token(Token = "0x400165F")]
		[FieldOffset(Offset = "0x0")]
		public readonly float2 InputPosition;

		[Token(Token = "0x4001660")]
		[FieldOffset(Offset = "0x8")]
		public readonly float2 MoveDelta;

		[Token(Token = "0x4001661")]
		[FieldOffset(Offset = "0x10")]
		public readonly float ZoomDelta;

		[Token(Token = "0x4001662")]
		[FieldOffset(Offset = "0x14")]
		public readonly InputState SingleInputState;

		[Token(Token = "0x4001663")]
		[FieldOffset(Offset = "0x17")]
		public readonly InputState DualInputState;

		[Token(Token = "0x6001BC7")]
		[Address(RVA = "0x3D64F94", Offset = "0x3D64F94", Length = "0x28")]
		public InputData(float2 inputPosition, float2 moveDelta, float zoomDelta, InputState singleInputState, InputState dualInputState)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InputData::.ctor");
			this = default;
		}
	}
}
