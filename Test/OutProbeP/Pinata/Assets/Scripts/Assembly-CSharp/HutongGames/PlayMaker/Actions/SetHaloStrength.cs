using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C930", Offset = "0x75C930")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C930", Offset = "0x75C930")]
	[Token(Token = "0x2000322")]
	public class SetHaloStrength : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001A03")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat haloStrength;

		[Token(Token = "0x4001A04")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FBA")]
		[Address(RVA = "0x9952A0", Offset = "0x9952A0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.haloStrength = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0.5f;
			haloStrength = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000FBB")]
		[Address(RVA = "0x9952D0", Offset = "0x9952D0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetHaloStrength::DoSetHaloStrength(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetHaloStrength();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FBC")]
		[Address(RVA = "0x995334", Offset = "0x995334", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetHaloStrength::DoSetHaloStrength(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetHaloStrength();
		}

		[Token(Token = "0x6000FBD")]
		[Address(RVA = "0x99530C", Offset = "0x99530C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmFloat::get_Value(this.haloStrength);\n\tUnityEngine.RenderSettings::set_haloStrength(v10);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetHaloStrength()
		{
			float value = haloStrength.Value;
			RenderSettings.haloStrength = value;
		}

		[Token(Token = "0x6000FBE")]
		[Address(RVA = "0x995338", Offset = "0x995338", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetHaloStrength()
		{
		}
	}
}
