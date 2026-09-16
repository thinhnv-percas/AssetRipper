using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x20001B5")]
	public abstract class BaseLogAction : FsmStateAction
	{
		[Token(Token = "0x4001371")]
		[FieldOffset(Offset = "0x49")]
		public bool sendToUnityLog;

		[Token(Token = "0x6000948")]
		[Address(RVA = "0xA8B83C", Offset = "0xA8B83C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sendToUnityLog = 0;\n\treturn;\n")]
		public override void Reset()
		{
			sendToUnityLog = false;
		}

		[Token(Token = "0x6000949")]
		[Address(RVA = "0xA8B844", Offset = "0xA8B844", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseLogAction()
		{
		}
	}
}
