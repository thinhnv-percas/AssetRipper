using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreSystem.UnityBindings.VisualRequests.LevelEnd
{
	[Token(Token = "0x200008A")]
	public class LoseRequest : VisualRequest
	{
		[Inject(false)]
		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x28")]
		private IBaseLayerFailService _failService;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x30")]
		private readonly float _delay;

		[Token(Token = "0x6000265")]
		[Address(RVA = "0x3C76BC0", Offset = "0x3C76BC0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._delay = delay;\n\treturn;\n")]
		public LoseRequest(float delay = 0.5f)
		{
			_delay = delay;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0x3C76BF4", Offset = "0x3C76BF4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tSystem.Action::.ctor(v64, this, Il2CppMethodInfo);\n\tv74 = PrimeTween.Sequence::ChainCallback(&v60 @ stack_-40_v2 (PrimeTween.Sequence), v64, 1);\n\treturn v60;\nL_0021:\n\tv53 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv62 = PrimeTween.Sequence::ChainDelay(&v60 @ stack_-40_v2 (PrimeTween.Sequence), this._delay);\n\tv64 = new System.Action();\n")]
		protected override Sequence CreateSequence()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoseRequest::CreateSequence");
			return default;
		}
	}
}
