using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C7A0", Offset = "0x75C7A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C7A0", Offset = "0x75C7A0")]
	[Token(Token = "0x200031D")]
	public class EnableFog : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C577C", Offset = "0x7C577C")]
		[Token(Token = "0x40019F9")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool enableFog;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C57B4", Offset = "0x7C57B4")]
		[Token(Token = "0x40019FA")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FA2")]
		[Address(RVA = "0xB746B4", Offset = "0xB746B4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.enableFog = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = true;
			enableFog = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x6000FA3")]
		[Address(RVA = "0xB746E4", Offset = "0xB746E4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmBool::get_Value(this.enableFog);\n\tUnityEngine.RenderSettings::set_fog(v13);\n\tv33 = ~this.everyFrame;\n\tif (v33) goto L_001C;\n\treturn;\nL_001C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool value = enableFog.Value;
			RenderSettings.fog = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FA4")]
		[Address(RVA = "0xB7473C", Offset = "0xB7473C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmBool::get_Value(this.enableFog);\n\tUnityEngine.RenderSettings::set_fog(v10);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			bool value = enableFog.Value;
			RenderSettings.fog = value;
		}

		[Token(Token = "0x6000FA5")]
		[Address(RVA = "0xB74768", Offset = "0xB74768", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnableFog()
		{
		}
	}
}
