using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74BC9C", Offset = "0x74BC9C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74BC9C", Offset = "0x74BC9C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74BC9C", Offset = "0x74BC9C")]
	[Token(Token = "0x200000D")]
	public class SetGender : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74C5D8", Offset = "0x74C5D8")]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x50")]
		public FsmString GenderAsString;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74C610", Offset = "0x74C610")]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x58")]
		public GAGender Gender;

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x167B770", Offset = "0x167B770", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Gender = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			Gender = GAGender.male;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x167B77C", Offset = "0x167B77C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAF6E8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B513]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmString::get_Value(this.GenderAsString);\n\tv61 = System.String::Equals(v42, \"male\", 3);\n\tv83 = v61 == 0;\n\tif (v83) goto L_0029;\n\tgoto L_0036;\nL_0029:\n\tv52 = HutongGames.PlayMaker.FsmString::get_Value(this.GenderAsString);\n\tv102 = System.String::Equals(v52, \"female\", 3);\n\tv94 = v102 == 0;\n\tif (v94) goto L_0038;\nL_0036:\n\tthis.Gender = v91;\n\tgoto L_003A;\nL_0038:\n\tv98 = this.Gender;\nL_003A:\n\tGameAnalyticsSDK.Events.GA_Setup::SetGender(v98);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = GenderAsString.Value;
			int num;
			GAGender gender;
			if (value.Equals("male", StringComparison.InvariantCultureIgnoreCase))
			{
				num = 1;
			}
			else
			{
				string value2 = GenderAsString.Value;
				if (!value2.Equals("female", StringComparison.InvariantCultureIgnoreCase))
				{
					gender = Gender;
					goto IL_00d7;
				}
				num = 2;
			}
			Gender = (GAGender)num;
			gender = (GAGender)num;
			goto IL_00d7;
			IL_00d7:
			GA_Setup.SetGender(gender);
			Finish();
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x167B848", Offset = "0x167B848", Length = "0x1008")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n\tUnityEngine.WWW::.ctor(X0, X1, X2);\n\treturn;\n\tX0 = *([X21]);\n\tX0 = 0x167B004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1022 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGender()
		{
		}
	}
}
