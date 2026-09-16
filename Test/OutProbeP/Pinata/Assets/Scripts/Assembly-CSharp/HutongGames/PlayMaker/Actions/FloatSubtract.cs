using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759668", Offset = "0x759668")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759668", Offset = "0x759668")]
	[Token(Token = "0x2000288")]
	public class FloatSubtract : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B87FC", Offset = "0x7B87FC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B87FC", Offset = "0x7B87FC")]
		[Token(Token = "0x40016CC")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B885C", Offset = "0x7B885C")]
		[Token(Token = "0x40016CD")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat subtract;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B88A8", Offset = "0x7B88A8")]
		[Token(Token = "0x40016CE")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B88E0", Offset = "0x7B88E0")]
		[Token(Token = "0x40016CF")]
		[FieldOffset(Offset = "0x61")]
		public bool perSecond;

		[Token(Token = "0x6000C98")]
		[Address(RVA = "0xB76B3C", Offset = "0xB76B3C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.floatVariable = 0;\n\tthis.subtract = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			perSecond = false;
			floatVariable = null;
			subtract = null;
		}

		[Token(Token = "0x6000C99")]
		[Address(RVA = "0xB76B48", Offset = "0xB76B48", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatSubtract::DoFloatSubtract(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFloatSubtract();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C9A")]
		[Address(RVA = "0xB76C00", Offset = "0xB76C00", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatSubtract::DoFloatSubtract(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFloatSubtract();
		}

		[Token(Token = "0x6000C9B")]
		[Address(RVA = "0xB76B84", Offset = "0xB76B84", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.floatVariable;\n\tv23 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv51 = HutongGames.PlayMaker.FsmFloat::get_Value(this.subtract);\n\tv53 = ~this.perSecond;\n\tif (v53) goto L_001D;\n\tv75 = UnityEngine.Time::get_deltaTime();\n\tv76 = v51 * v75;\nL_001D:\n\tv61 = v23 - v76;\n\tv18.value = v61;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFloatSubtract()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = subtract.Value;
			bool flag = !perSecond;
			float num = value2;
			if (!flag)
			{
				float deltaTime = Time.deltaTime;
				num = value2 * deltaTime;
			}
			float value3 = value - num;
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x6000C9C")]
		[Address(RVA = "0xB76C04", Offset = "0xB76C04", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatSubtract()
		{
		}
	}
}
