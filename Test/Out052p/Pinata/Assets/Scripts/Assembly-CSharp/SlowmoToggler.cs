using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000023")]
public class SlowmoToggler : MonoBehaviour
{
	[Token(Token = "0x60000C7")]
	[Address(RVA = "0xB02D4C", Offset = "0xB02D4C", Length = "0x18")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = slowmo == 0;\n\tv8 = ~v3;\n\tv9 = ~v8;\n\tif (v9) goto L_FFFFFFFF;\n\tgoto L_000F;\nL_000F:\n\tUnityEngine.Time::set_timeScale(v12);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Slowmo(bool slowmo)
	{
		float timeScale = ((!slowmo) ? 1f : 0.25f);
		Time.timeScale = timeScale;
	}

	[Token(Token = "0x60000C8")]
	[Address(RVA = "0xB02D64", Offset = "0xB02D64", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SlowmoToggler()
	{
	}
}
