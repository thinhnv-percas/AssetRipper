using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B5A0", Offset = "0x75B5A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B5A0", Offset = "0x75B5A0")]
	[Token(Token = "0x20002E9")]
	public class SetProceduralColor : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0E6C", Offset = "0x7C0E6C")]
		[Token(Token = "0x40018E6")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial substanceMaterial;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0EB8", Offset = "0x7C0EB8")]
		[Token(Token = "0x40018E7")]
		[FieldOffset(Offset = "0x58")]
		public FsmString colorProperty;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0F04", Offset = "0x7C0F04")]
		[Token(Token = "0x40018E8")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor colorValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0F50", Offset = "0x7C0F50")]
		[Token(Token = "0x40018E9")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000E87")]
		[Address(RVA = "0x9986E4", Offset = "0x9986E4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F071D0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021787]) = v38;\nL_0013:\n\tthis.substanceMaterial = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.colorProperty = v43;\n\tv45 = UnityEngine.Color::get_white();\n\tv51 = HutongGames.PlayMaker.FsmColor::op_Implicit(v45);\n\tthis.colorValue = v51;\n\tthis.everyFrame = 0;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			substanceMaterial = null;
			FsmString fsmString = "";
			colorProperty = fsmString;
			Color white = Color.white;
			FsmColor fsmColor = white;
			colorValue = fsmColor;
			everyFrame = false;
		}

		[Token(Token = "0x6000E88")]
		[Address(RVA = "0x998758", Offset = "0x998758", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.everyFrame;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E89")]
		[Address(RVA = "0x998770", Offset = "0x998770", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate()
		{
		}

		[Token(Token = "0x6000E8A")]
		[Address(RVA = "0x99876C", Offset = "0x99876C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoSetProceduralFloat()
		{
		}

		[Token(Token = "0x6000E8B")]
		[Address(RVA = "0x998774", Offset = "0x998774", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetProceduralColor()
		{
		}
	}
}
