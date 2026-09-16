using System;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000046")]
	public class MatchOutcome
	{
		[Token(Token = "0x2000120")]
		public enum ParticipantResult
		{
			[Token(Token = "0x40004D2")]
			CustomPlacement = -1,
			[Token(Token = "0x40004D3")]
			None = 0,
			[Token(Token = "0x40004D4")]
			Won = 1,
			[Token(Token = "0x40004D5")]
			Lost = 2,
			[Token(Token = "0x40004D6")]
			Tied = 3
		}

		[Token(Token = "0x40001CC")]
		public const uint PlacementUnset = 0u;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x10")]
		private List<string> mParticipantIds;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<string, uint> mPlacements;

		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<string, ParticipantResult> mResults;

		[Token(Token = "0x1700011A")]
		public List<string> ParticipantIds
		{
			[Token(Token = "0x60003DD")]
			[Address(RVA = "0xFCB41C", Offset = "0xFCB41C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mParticipantIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ParticipantIds;
			}
		}

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0xFCB1D8", Offset = "0xFCB1D8", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFE650]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202563A]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v42);\n\tthis.mParticipantIds = v42;\n\tv50 = new System.Collections.Generic.Dictionary`2<System.String, System.UInt32>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.UInt32>::.ctor(v50);\n\tthis.mPlacements = v50;\n\tv58 = new System.Collections.Generic.Dictionary`2<System.String, EasyMobile.MatchOutcome+ParticipantResult>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.MatchOutcome+ParticipantResult>::.ctor(v58);\n\tthis.mResults = v58;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MatchOutcome()
		{
			List<string> list = new List<string>();
			mParticipantIds = list;
			Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
			mPlacements = dictionary;
			Dictionary<string, ParticipantResult> dictionary2 = new Dictionary<string, ParticipantResult>();
			mResults = dictionary2;
		}

		[Token(Token = "0x60003DA")]
		[Address(RVA = "0xFCB298", Offset = "0xFCB298", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED9BA0]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, participantId, result, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202563B]) = v44;\nL_0017:\n\tv45 = result + 1;\n\tv47 = v45 == 0;\n\tv50 = ~v47;\n\tif (v50) goto L_003A;\n\tgoto L_002E;\n\tv75 = *([v53 @ X0_v4+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_002E;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v53, participantId, result, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002E:\n\tUnityEngine.Debug::Log(\"Do not set ParticipantResult.CustomPlacement directly. Use SetParticipantPlacement method instead.\");\nL_003A:\n\tEasyMobile.MatchOutcome::SetParticipantResultAndPlacement(this, participantId, result, 0);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParticipantResult(string participantId, ParticipantResult result)
		{
			if (result + 1 == ParticipantResult.None)
			{
				Debug.Log("Do not set ParticipantResult.CustomPlacement directly. Use SetParticipantPlacement method instead.");
			}
			SetParticipantResultAndPlacement(participantId, result, 0u);
		}

		[Token(Token = "0x60003DB")]
		[Address(RVA = "0xFCB40C", Offset = "0xFCB40C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.MatchOutcome::SetParticipantResultAndPlacement(this, participantId, 0xFFFFFFFF, placement);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetParticipantPlacement(string participantId, uint placement)
		{
			//IL_0017: Expected I4, but got I8
			SetParticipantResultAndPlacement(participantId, ParticipantResult.CustomPlacement, placement);
		}

		[Token(Token = "0x60003DC")]
		[Address(RVA = "0xFCB334", Offset = "0xFCB334", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1ECE060]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, participantId, result, placement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202563C]) = v47;\nL_0020:\n\tv54 = System.Collections.Generic.List`1<System.String>::Contains(this.mParticipantIds, participantId);\n\tv76 = v54 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0035;\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.mParticipantIds, participantId);\nL_0035:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.UInt32>::set_Item(this.mPlacements, participantId, placement);\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.MatchOutcome+ParticipantResult>::set_Item(this.mResults, participantId, result);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetParticipantResultAndPlacement(string participantId, ParticipantResult result, uint placement)
		{
			if (!ParticipantIds.Contains(participantId))
			{
				ParticipantIds.Add(participantId);
			}
			mPlacements.set_Item(participantId, placement);
			mResults.set_Item(participantId, result);
		}

		[Token(Token = "0x60003DE")]
		[Address(RVA = "0xFCB424", Offset = "0xFCB424", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EE0350]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, participantId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202563D]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.MatchOutcome+ParticipantResult>::ContainsKey(this.mResults, participantId);\n\tv58 = v48 == 0;\n\tif (v58) goto L_0036;\n\treturnVal3 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.MatchOutcome+ParticipantResult>::get_Item(this.mResults, participantId);\n\treturn returnVal3;\nL_0036:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ParticipantResult GetParticipantResult(string participantId)
		{
			if (mResults.ContainsKey(participantId))
			{
				return mResults.get_Item(participantId);
			}
			return default(ParticipantResult);
		}

		[Token(Token = "0x60003DF")]
		[Address(RVA = "0xFCB4C0", Offset = "0xFCB4C0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EFEDA0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, participantId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202563E]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.Dictionary`2<System.String, System.UInt32>::ContainsKey(this.mPlacements, participantId);\n\tv58 = v48 == 0;\n\tif (v58) goto L_0036;\n\treturnVal3 = System.Collections.Generic.Dictionary`2<System.String, System.UInt32>::get_Item(this.mPlacements, participantId);\n\treturn returnVal3;\nL_0036:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public uint GetParticipantPlacement(string participantId)
		{
			if (mPlacements.ContainsKey(participantId))
			{
				return mPlacements.get_Item(participantId);
			}
			return 0u;
		}

		[Token(Token = "0x60003E0")]
		[Address(RVA = "0xFCB55C", Offset = "0xFCB55C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1ECBA70]);\n\tv31 = *([v30 @ X8_v21]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202563F]) = v50;\nL_001D:\n\tv55 = 0;\n\tv57 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v57);\n\tv60 = v57 == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tv57 = System.Text.StringBuilder::Append(v57, \"[MatchOutcome\");\n\tv69 = this.mParticipantIds == 0;\n\tif (v69) goto L_009A;\n\tv107 = System.Collections.Generic.List`1<System.String>::GetEnumerator(this.mParticipantIds);\nL_003D:\n\tv135 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::MoveNext(&v55 @ stack_-68_v1 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv130 = v135 == 0;\n\tif (v130) goto L_0062;\n\tv174 = EasyMobile.MatchOutcome::GetParticipantResult(this, 0);\n\t// 73 Box v183 @ X0_v25 (System.Object), typeof(EasyMobile.MatchOutcome+ParticipantResult), &v174 @ X0_v23 (EasyMobile.MatchOutcome+ParticipantResult)\n\tv186 = EasyMobile.MatchOutcome::GetParticipantPlacement(this, 0);\n\t// 82 Box v191 @ X0_v29 (System.Object), typeof(System.UInt32), &v186 @ X0_v27 (System.UInt32)\n\tv195 = System.String::Format(\" {0}->({1},{2})\", 0, v183, v191);\n\tv57 = System.Text.StringBuilder::Append(v57, v195);\n\tgoto L_003D;\nL_0062:\n\tv57 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v55 @ stack_-68_v1 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tgoto L_0087;\n\tgoto L_009A;\n\tgoto L_006C;\n\tgoto L_006C;\n\tgoto L_006C;\n\tgoto L_006C;\n\tgoto L_006C;\n\tgoto L_006C;\nL_006C:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_009B;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA6D58]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009F;\nL_0087:\n\tv57 = System.Text.StringBuilder::Append(v57, \"]\");\n\tv99 = v57 == 0;\n\tif (v99) goto L_009A;\n\treturnVal2 = System.Text.StringBuilder::ToString(v57);\n\treturn returnVal2;\nL_009A:\n\tv102 = new System.NullReferenceException();\nL_009B:\n\tv57 = 0x6D2380(v102, v94, v92, v191, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_009F:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0031: Expected O, but got I4
			//IL_010c: Expected O, but got I4
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			StringBuilder stringBuilder = new StringBuilder();
			if (stringBuilder != null)
			{
				stringBuilder = stringBuilder.Append("[MatchOutcome");
				bool flag = ParticipantIds == null;
				object obj = 0;
				string text = "[MatchOutcome";
				if (!flag)
				{
					List<string>.Enumerator enumerator2 = ParticipantIds.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ParticipantResult participantResult = GetParticipantResult(null);
						object arg = participantResult;
						uint participantPlacement = GetParticipantPlacement(null);
						object arg2 = participantPlacement;
						string value = $" {null}->({arg},{arg2})";
						stringBuilder = stringBuilder.Append(value);
					}
					enumerator.Dispose();
					stringBuilder = stringBuilder.Append("]");
					bool flag2 = stringBuilder == null;
					obj = 0;
					text = "]";
					if (!flag2)
					{
						return stringBuilder.ToString();
					}
				}
			}
			else
			{
				string text = null;
			}
			NullReferenceException ex = new NullReferenceException();
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			return (string)(object)new TypeLoadException();
		}
	}
}
