using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7556E0", Offset = "0x7556E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7556E0", Offset = "0x7556E0")]
	[Token(Token = "0x20001C7")]
	public class DeviceVibrate : FsmStateAction
	{
		[Token(Token = "0x600097F")]
		[Address(RVA = "0xB70654", Offset = "0xB70654", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000980")]
		[Address(RVA = "0xB70658", Offset = "0xB70658", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Handheld::Vibrate();\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Handheld.Vibrate();
			Finish();
		}

		[Token(Token = "0x6000981")]
		[Address(RVA = "0xB70684", Offset = "0xB70684", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DeviceVibrate()
		{
		}
	}
}
