using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;
using UnityEngine;

[Token(Token = "0x2000006")]
public class Events : MonoBehaviour
{
	[Token(Token = "0x400000C")]
	[FieldOffset(Offset = "0x18")]
	public GlobalEvent animationEventBegin;

	[Token(Token = "0x400000D")]
	[FieldOffset(Offset = "0x20")]
	public GlobalEvent animationEventEnd;

	[Token(Token = "0x400000E")]
	[FieldOffset(Offset = "0x28")]
	public GlobalEvent PinataIsKicked;

	[Token(Token = "0x400000F")]
	[FieldOffset(Offset = "0x30")]
	public GlobalEvent PinataIsDied;

	[Token(Token = "0x6000007")]
	[Address(RVA = "0xCBEF88", Offset = "0xCBEF88", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Events()
	{
	}
}
