using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C840", Offset = "0x75C840")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C840", Offset = "0x75C840")]
	[Token(Token = "0x200031F")]
	public class SetFlareStrength : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40019FD")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat flareStrength;

		[Token(Token = "0x40019FE")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FAB")]
		[Address(RVA = "0x990798", Offset = "0x990798", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.2f);\n\tthis.flareStrength = v13;\n\tthis.everyFrame = 0;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0.2f;
			flareStrength = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000FAC")]
		[Address(RVA = "0x9907CC", Offset = "0x9907CC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFlareStrength::DoSetFlareStrength(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetFlareStrength();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FAD")]
		[Address(RVA = "0x990830", Offset = "0x990830", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFlareStrength::DoSetFlareStrength(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetFlareStrength();
		}

		[Token(Token = "0x6000FAE")]
		[Address(RVA = "0x990808", Offset = "0x990808", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmFloat::get_Value(this.flareStrength);\n\tUnityEngine.RenderSettings::set_flareStrength(v10);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetFlareStrength()
		{
			float value = flareStrength.Value;
			RenderSettings.flareStrength = value;
		}

		[Token(Token = "0x6000FAF")]
		[Address(RVA = "0x990834", Offset = "0x990834", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetFlareStrength()
		{
		}
	}
}
