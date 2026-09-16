using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C980", Offset = "0x75C980")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C980", Offset = "0x75C980")]
	[Token(Token = "0x2000323")]
	public class SetSkybox : FsmStateAction
	{
		[Token(Token = "0x4001A05")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial skybox;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C583C", Offset = "0x7C583C")]
		[Token(Token = "0x4001A06")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FBF")]
		[Address(RVA = "0x999AA8", Offset = "0x999AA8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skybox = 0;\n\treturn;\n")]
		public override void Reset()
		{
			skybox = null;
		}

		[Token(Token = "0x6000FC0")]
		[Address(RVA = "0x999AB0", Offset = "0x999AB0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.skybox);\n\tUnityEngine.RenderSettings::set_skybox(v13);\n\tv32 = ~this.everyFrame;\n\tif (v32) goto L_001B;\n\treturn;\nL_001B:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Material value = skybox.Value;
			RenderSettings.skybox = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FC1")]
		[Address(RVA = "0x999B04", Offset = "0x999B04", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.skybox);\n\tUnityEngine.RenderSettings::set_skybox(v10);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			Material value = skybox.Value;
			RenderSettings.skybox = value;
		}

		[Token(Token = "0x6000FC2")]
		[Address(RVA = "0x999B2C", Offset = "0x999B2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetSkybox()
		{
		}
	}
}
