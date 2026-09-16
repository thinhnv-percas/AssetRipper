using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C890", Offset = "0x75C890")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C890", Offset = "0x75C890")]
	[Token(Token = "0x2000320")]
	public class SetFogColor : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40019FF")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor fogColor;

		[Token(Token = "0x4001A00")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FB0")]
		[Address(RVA = "0x9908F4", Offset = "0x9908F4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_white();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.fogColor = v17;\n\tthis.everyFrame = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			Color white = Color.white;
			FsmColor fsmColor = white;
			fogColor = fsmColor;
			everyFrame = false;
		}

		[Token(Token = "0x6000FB1")]
		[Address(RVA = "0x990928", Offset = "0x990928", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFogColor::DoSetFogColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetFogColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FB2")]
		[Address(RVA = "0x99098C", Offset = "0x99098C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFogColor::DoSetFogColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetFogColor();
		}

		[Token(Token = "0x6000FB3")]
		[Address(RVA = "0x990964", Offset = "0x990964", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fogColor;\n\t// 8 MakeStruct v8 @ AGG990978_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v0.value (UnityEngine.Color), v0.value.g (System.Single), v0.value.b (System.Single), v0.value.a (System.Single)\n\tUnityEngine.RenderSettings::set_fogColor(v8);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetFogColor()
		{
			FsmColor fsmColor = fogColor;
			Color color = default(Color);
			color.r = fsmColor.value.r;
			color.g = fsmColor.value.g;
			color.b = fsmColor.value.b;
			color.a = fsmColor.value.a;
			RenderSettings.fogColor = color;
		}

		[Token(Token = "0x6000FB4")]
		[Address(RVA = "0x990990", Offset = "0x990990", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetFogColor()
		{
		}
	}
}
