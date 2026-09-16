using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74BA08", Offset = "0x74BA08")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74BA08", Offset = "0x74BA08")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74BA08", Offset = "0x74BA08")]
	[Token(Token = "0x2000007")]
	public class SendProgressionEvent : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C1A4", Offset = "0x74C1A4")]
		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x50")]
		public FsmString ProgressionStatusAsString;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C1DC", Offset = "0x74C1DC")]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x58")]
		public GAProgressionStatus ProgressionStatus;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C214", Offset = "0x74C214")]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x60")]
		public FsmString Progression01;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C260", Offset = "0x74C260")]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x68")]
		public FsmString Progression02;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C298", Offset = "0x74C298")]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x70")]
		public FsmString Progression03;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74C2D0", Offset = "0x74C2D0")]
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt Score;

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x167AFB8", Offset = "0x167AFB8", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv19 = *([1EE1868]);\n\tv20 = *([v19 @ X8_v5]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([202B50E]) = v39;\nL_0015:\n\tv37.ProgressionStatus = 1;\n\tv43 = 0x167B854(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturn;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1);\n\tif (TEMP) goto L_0046;\n\t*([X20+10]) = 0;\n\t*([X19+60]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1);\n\tif (TEMP) goto L_0046;\n\t*([X20+10]) = 0;\n\t*([X19+68]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1);\n\tif (TEMP) goto L_0046;\n\t*([X20+10]) = 0;\n\t*([X19+70]) = X20;\n\tX8 = *([1ECE5A0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmInt::.ctor(X0, X1);\n\tif (TEMP) goto L_0046;\n\t*([X20+10]) = 0;\n\t*([X19+78]) = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 68 ShiftStack 48\n\treturn;\nL_0046:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			ProgressionStatus = GAProgressionStatus.Start;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @167B854 (inside HutongGames.PlayMaker.Actions.SetGender::.ctor +0xC)");
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x167B0A0", Offset = "0x167B0A0", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Score);\n\tv131 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Progression03);\n\tv133 = v21 == 0;\n\tif (v133) goto L_003D;\n\tv167 = v131 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0029;\n\tv175 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Progression02);\n\tv173 = v175 == 0;\n\tif (v173) goto L_008A;\nL_0029:\n\tv120 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Progression02);\n\tv183 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression01);\n\tv187 = v120 == 0;\n\tif (v187) goto L_0069;\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(this.ProgressionStatus, v183, 0);\n\tgoto L_00CE;\nL_003D:\n\tv170 = v131 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_004C;\n\tv179 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Progression02);\n\tv177 = v179 == 0;\n\tif (v177) goto L_00A6;\nL_004C:\n\tv121 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Progression02);\n\tv185 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression01);\n\tv189 = v121 == 0;\n\tif (v189) goto L_0075;\n\tv199 = HutongGames.PlayMaker.FsmInt::get_Value(this.Score);\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(this.ProgressionStatus, v185, v199, 0);\n\tgoto L_00CE;\nL_0069:\n\tv196 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression02);\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(this.ProgressionStatus, v183, v196, 0);\n\tgoto L_00CE;\nL_0075:\n\tv122 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression02);\n\tv241 = HutongGames.PlayMaker.FsmInt::get_Value(this.Score);\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(this.ProgressionStatus, v185, v122, v241, 0);\n\tgoto L_00CE;\nL_008A:\n\tv123 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression01);\n\tv124 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression02);\n\tv237 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression03);\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(this.ProgressionStatus, v123, v124, v237, 0);\n\tgoto L_00CE;\nL_00A6:\n\tv125 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression01);\n\tv126 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression02);\n\tv127 = HutongGames.PlayMaker.FsmString::get_Value(this.Progression03);\n\tv244 = HutongGames.PlayMaker.FsmInt::get_Value(this.Score);\n\tGameAnalyticsSDK.Events.GA_Progression::NewEvent(this.ProgressionStatus, v125, v126, v127, v244, 0);\nL_00CE:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool isNone = Score.IsNone;
			bool isNone2 = Progression03.IsNone;
			if (isNone)
			{
				if (isNone2 || Progression02.IsNone)
				{
					bool isNone3 = Progression02.IsNone;
					string value = Progression01.Value;
					if (isNone3)
					{
						GA_Progression.NewEvent(ProgressionStatus, value, null);
					}
					else
					{
						string value2 = Progression02.Value;
						GA_Progression.NewEvent(ProgressionStatus, value, value2, null);
					}
				}
				else
				{
					string value3 = Progression01.Value;
					string value4 = Progression02.Value;
					string value5 = Progression03.Value;
					GA_Progression.NewEvent(ProgressionStatus, value3, value4, value5, null);
				}
			}
			else if (isNone2 || Progression02.IsNone)
			{
				bool isNone4 = Progression02.IsNone;
				string value6 = Progression01.Value;
				if (isNone4)
				{
					int value7 = Score.Value;
					GA_Progression.NewEvent(ProgressionStatus, value6, value7, null);
				}
				else
				{
					string value8 = Progression02.Value;
					int value9 = Score.Value;
					GA_Progression.NewEvent(ProgressionStatus, value6, value8, value9, null);
				}
			}
			else
			{
				string value10 = Progression01.Value;
				string value11 = Progression02.Value;
				string value12 = Progression03.Value;
				int value13 = Score.Value;
				GA_Progression.NewEvent(ProgressionStatus, value10, value11, value12, value13, null);
			}
			Finish();
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x167B33C", Offset = "0x167B33C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendProgressionEvent()
		{
		}
	}
}
