using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759438", Offset = "0x759438")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759438", Offset = "0x759438")]
	[Token(Token = "0x2000281")]
	public class FloatAdd : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B7FAC", Offset = "0x7B7FAC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7FAC", Offset = "0x7B7FAC")]
		[Token(Token = "0x40016AD")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B800C", Offset = "0x7B800C")]
		[Token(Token = "0x40016AE")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat add;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8058", Offset = "0x7B8058")]
		[Token(Token = "0x40016AF")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8090", Offset = "0x7B8090")]
		[Token(Token = "0x40016B0")]
		[FieldOffset(Offset = "0x61")]
		public bool perSecond;

		[Token(Token = "0x6000C78")]
		[Address(RVA = "0xB75CE4", Offset = "0xB75CE4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.floatVariable = 0;\n\tthis.add = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			perSecond = false;
			floatVariable = null;
			add = null;
		}

		[Token(Token = "0x6000C79")]
		[Address(RVA = "0xB75CF0", Offset = "0xB75CF0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatAdd::DoFloatAdd(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFloatAdd();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C7A")]
		[Address(RVA = "0xB75DA8", Offset = "0xB75DA8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatAdd::DoFloatAdd(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFloatAdd();
		}

		[Token(Token = "0x6000C7B")]
		[Address(RVA = "0xB75D2C", Offset = "0xB75D2C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.floatVariable;\n\tv23 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv51 = HutongGames.PlayMaker.FsmFloat::get_Value(this.add);\n\tv53 = ~this.perSecond;\n\tif (v53) goto L_001D;\n\tv75 = UnityEngine.Time::get_deltaTime();\n\tv76 = v51 * v75;\nL_001D:\n\tv61 = v23 + v76;\n\tv18.value = v61;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFloatAdd()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = add.Value;
			bool flag = !perSecond;
			float num = value2;
			if (!flag)
			{
				float deltaTime = Time.deltaTime;
				num = value2 * deltaTime;
			}
			float value3 = value + num;
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x6000C7C")]
		[Address(RVA = "0xB75DAC", Offset = "0xB75DAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatAdd()
		{
		}
	}
}
