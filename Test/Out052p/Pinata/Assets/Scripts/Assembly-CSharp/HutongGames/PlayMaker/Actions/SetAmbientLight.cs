using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C7F0", Offset = "0x75C7F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C7F0", Offset = "0x75C7F0")]
	[Token(Token = "0x200031E")]
	public class SetAmbientLight : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40019FB")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor ambientColor;

		[Token(Token = "0x40019FC")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FA6")]
		[Address(RVA = "0xB28808", Offset = "0xB28808", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_gray();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.ambientColor = v17;\n\tthis.everyFrame = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			Color gray = Color.gray;
			FsmColor fsmColor = gray;
			ambientColor = fsmColor;
			everyFrame = false;
		}

		[Token(Token = "0x6000FA7")]
		[Address(RVA = "0xB2883C", Offset = "0xB2883C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAmbientLight::DoSetAmbientColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetAmbientColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FA8")]
		[Address(RVA = "0xB288A0", Offset = "0xB288A0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAmbientLight::DoSetAmbientColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetAmbientColor();
		}

		[Token(Token = "0x6000FA9")]
		[Address(RVA = "0xB28878", Offset = "0xB28878", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.ambientColor;\n\t// 8 MakeStruct v8 @ AGGB2888C_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v0.value (UnityEngine.Color), v0.value.g (System.Single), v0.value.b (System.Single), v0.value.a (System.Single)\n\tUnityEngine.RenderSettings::set_ambientLight(v8);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetAmbientColor()
		{
			FsmColor fsmColor = ambientColor;
			Color ambientLight = default(Color);
			ambientLight.r = fsmColor.value.r;
			ambientLight.g = fsmColor.value.g;
			ambientLight.b = fsmColor.value.b;
			ambientLight.a = fsmColor.value.a;
			RenderSettings.ambientLight = ambientLight;
		}

		[Token(Token = "0x6000FAA")]
		[Address(RVA = "0xB288A4", Offset = "0xB288A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAmbientLight()
		{
		}
	}
}
