using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C8E0", Offset = "0x75C8E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C8E0", Offset = "0x75C8E0")]
	[Token(Token = "0x2000321")]
	public class SetFogDensity : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001A01")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat fogDensity;

		[Token(Token = "0x4001A02")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FB5")]
		[Address(RVA = "0x990998", Offset = "0x990998", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.fogDensity = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0.5f;
			fogDensity = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000FB6")]
		[Address(RVA = "0x9909C8", Offset = "0x9909C8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFogDensity::DoSetFogDensity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetFogDensity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FB7")]
		[Address(RVA = "0x990A2C", Offset = "0x990A2C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFogDensity::DoSetFogDensity(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetFogDensity();
		}

		[Token(Token = "0x6000FB8")]
		[Address(RVA = "0x990A04", Offset = "0x990A04", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fogDensity);\n\tUnityEngine.RenderSettings::set_fogDensity(v10);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetFogDensity()
		{
			float value = fogDensity.Value;
			RenderSettings.fogDensity = value;
		}

		[Token(Token = "0x6000FB9")]
		[Address(RVA = "0x990A30", Offset = "0x990A30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetFogDensity()
		{
		}
	}
}
