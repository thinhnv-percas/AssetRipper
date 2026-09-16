using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759898", Offset = "0x759898")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759898", Offset = "0x759898")]
	[Token(Token = "0x200028F")]
	public class SampleCurve : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40016E7")]
		[FieldOffset(Offset = "0x50")]
		public FsmAnimationCurve curve;

		[RequiredField]
		[Token(Token = "0x40016E8")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat sampleAt;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8C14", Offset = "0x7B8C14")]
		[Token(Token = "0x40016E9")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeValue;

		[Token(Token = "0x40016EA")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000CB5")]
		[Address(RVA = "0xB2511C", Offset = "0xB2511C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.sampleAt = 0;\n\tthis.storeValue = 0;\n\tthis.curve = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			sampleAt = null;
			storeValue = null;
			curve = null;
		}

		[Token(Token = "0x6000CB6")]
		[Address(RVA = "0xB2512C", Offset = "0xB2512C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SampleCurve::DoSampleCurve(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSampleCurve();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CB7")]
		[Address(RVA = "0xB251BC", Offset = "0xB251BC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SampleCurve::DoSampleCurve(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSampleCurve();
		}

		[Token(Token = "0x6000CB8")]
		[Address(RVA = "0xB25168", Offset = "0xB25168", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.curve;\n\tv12 = this.curve == 0;\n\tif (v12) goto L_001D;\n\tv14 = v10.curve == 0;\n\tif (v14) goto L_001D;\n\tv24 = this.storeValue;\n\tv28 = this.storeValue == 0;\n\tif (v28) goto L_001D;\n\tv44 = HutongGames.PlayMaker.FsmFloat::get_Value(this.sampleAt);\n\tv16 = UnityEngine.AnimationCurve::Evaluate(v10.curve, v44);\n\tv24.value = v16;\nL_001D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSampleCurve()
		{
			FsmAnimationCurve fsmAnimationCurve = curve;
			if (curve != null && fsmAnimationCurve.curve != null)
			{
				FsmFloat fsmFloat = storeValue;
				if (storeValue != null)
				{
					float value = sampleAt.Value;
					float value2 = fsmAnimationCurve.curve.Evaluate(value);
					fsmFloat.Value = value2;
				}
			}
		}

		[Token(Token = "0x6000CB9")]
		[Address(RVA = "0xB251C0", Offset = "0xB251C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SampleCurve()
		{
		}
	}
}
