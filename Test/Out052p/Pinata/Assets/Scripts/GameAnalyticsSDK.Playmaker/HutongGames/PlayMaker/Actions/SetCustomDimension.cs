using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74BB94", Offset = "0x74BB94")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BB94", Offset = "0x74BB94")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74BB94", Offset = "0x74BB94")]
	[Token(Token = "0x200000B")]
	public class SetCustomDimension : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C4F4", Offset = "0x74C4F4")]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x4C")]
		public CustomDimensionNumber CustomDimension;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C540", Offset = "0x74C540")]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x50")]
		public FsmString CustomDimensionValue;

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x167B5A4", Offset = "0x167B5A4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F02818]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B511]) = v38;\nL_0014:\n\tthis.CustomDimension = 1;\n\tv43 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v43);\n\tv43.useVariable = 0;\n\tthis.CustomDimensionValue = v43;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			CustomDimension = CustomDimensionNumber.CustomDimension01;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			CustomDimensionValue = fsmString;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x167B61C", Offset = "0x167B61C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this.CustomDimension == 3;\n\tif (v15) goto L_0032;\n\tv24 = this.CustomDimension == 2;\n\tif (v24) goto L_003A;\n\tv40 = this.CustomDimension != 1;\n\tif (v40) goto L_0043;\n\tv83 = HutongGames.PlayMaker.FsmString::get_Value(this.CustomDimensionValue);\n\tGameAnalyticsSDK.Events.GA_Setup::SetCustomDimension01(v83);\n\tgoto L_0043;\nL_0032:\n\tv44 = HutongGames.PlayMaker.FsmString::get_Value(this.CustomDimensionValue);\n\tGameAnalyticsSDK.Events.GA_Setup::SetCustomDimension03(v44);\n\tgoto L_0043;\nL_003A:\n\tv82 = HutongGames.PlayMaker.FsmString::get_Value(this.CustomDimensionValue);\n\tGameAnalyticsSDK.Events.GA_Setup::SetCustomDimension02(v82);\nL_0043:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (CustomDimension != CustomDimensionNumber.CustomDimension03)
			{
				if (CustomDimension != CustomDimensionNumber.CustomDimension02)
				{
					if (CustomDimension == CustomDimensionNumber.CustomDimension01)
					{
						string value = CustomDimensionValue.Value;
						GA_Setup.SetCustomDimension01(value);
					}
				}
				else
				{
					string value2 = CustomDimensionValue.Value;
					GA_Setup.SetCustomDimension02(value2);
				}
			}
			else
			{
				string value3 = CustomDimensionValue.Value;
				GA_Setup.SetCustomDimension03(value3);
			}
			Finish();
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x167B6B0", Offset = "0x167B6B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetCustomDimension()
		{
		}
	}
}
