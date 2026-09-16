using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200004B")]
	public class TurnBasedMatch
	{
		[Token(Token = "0x2000122")]
		public enum MatchStatus
		{
			[Token(Token = "0x40004E2")]
			Unknown = 0,
			[Token(Token = "0x40004E3")]
			Active = 1,
			[Token(Token = "0x40004E4")]
			Ended = 2,
			[Token(Token = "0x40004E5")]
			Matching = 3,
			[Token(Token = "0x40004E6")]
			Cancelled = 4,
			[Token(Token = "0x40004E7")]
			Expired = 5,
			[Token(Token = "0x40004E8")]
			Deleted = 6
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000123")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40004E9")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40004EA")]
			public static Func<Participant, string> _003C_003E9__31_0;

			[Token(Token = "0x6000975")]
			[Address(RVA = "0xFD6B74", Offset = "0xFD6B74", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EE7D40]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20256E9]) = v37;\nL_0015:\n\tv41 = new EasyMobile.TurnBasedMatch+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000976")]
			[Address(RVA = "0xFD6BD8", Offset = "0xFD6BD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CToString_003Eb__31_0(Participant p)
			{
				//IL_0008: Expected I, but got O
				//IL_0018: Expected O, but got I
				//IL_0028: Expected O, but got I
				IntPtr intPtr = (IntPtr)p;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.Participant>)+160]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.Participant>)+168]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: X0)");
				return null;
			}
		}

		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0x10")]
		private string mMatchId;

		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x18")]
		private int mPlayerCount;

		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x20")]
		private byte[] mData;

		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x28")]
		private string mSelfParticipantId;

		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x30")]
		private Participant[] mParticipants;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x38")]
		private string mCurrentParticipantId;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x40")]
		private MatchStatus mMatchStatus;

		[Token(Token = "0x17000124")]
		public string MatchId
		{
			[Token(Token = "0x60003F7")]
			[Address(RVA = "0xFD6664", Offset = "0xFD6664", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMatchId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MatchId;
			}
		}

		[Token(Token = "0x17000125")]
		public int PlayerCount
		{
			[Token(Token = "0x60003F8")]
			[Address(RVA = "0xFD666C", Offset = "0xFD666C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mPlayerCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PlayerCount;
			}
		}

		[Token(Token = "0x17000126")]
		public bool HasVacantSlot
		{
			[Token(Token = "0x60003F9")]
			[Address(RVA = "0xFD6674", Offset = "0xFD6674", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.mParticipants;\n\tv7 = this.mPlayerCount - v0.Length;\n\tv8 = v7 < 0;\n\tv9 = v7 == 0;\n\tv10 = this.mPlayerCount ^ v0.Length;\n\tv11 = this.mPlayerCount ^ v7;\n\tv12 = v10 & v11;\n\tv13 = v12 < 0;\n\tv14 = v8 == v13;\n\tv15 = ~v9;\n\tv16 = v14 & v15;\n\treturn v16;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0020: Expected O, but got I4
				Participant[] participants = Participants;
				object obj = PlayerCount - participants.Length;
				bool flag = (long)(IntPtr)obj < 0L;
				bool flag2 = obj == null;
				int num = PlayerCount ^ participants.Length;
				int num2 = (int)((long)PlayerCount ^ (long)(IntPtr)obj);
				int num3 = num & num2;
				bool flag3 = num3 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Token(Token = "0x17000127")]
		public bool IsMyTurn
		{
			[Token(Token = "0x60003FA")]
			[Address(RVA = "0xFD66A0", Offset = "0xFD66A0", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::Equals(this.mSelfParticipantId, this.mCurrentParticipantId);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SelfParticipantId.Equals(CurrentParticipantId);
			}
		}

		[Token(Token = "0x17000128")]
		public byte[] Data
		{
			[Token(Token = "0x60003FB")]
			[Address(RVA = "0xFD66C4", Offset = "0xFD66C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mData;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x17000129")]
		public string SelfParticipantId
		{
			[Token(Token = "0x60003FC")]
			[Address(RVA = "0xFD66CC", Offset = "0xFD66CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mSelfParticipantId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SelfParticipantId;
			}
		}

		[Token(Token = "0x1700012A")]
		public Participant Self
		{
			[Token(Token = "0x60003FD")]
			[Address(RVA = "0xFD66D4", Offset = "0xFD66D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.TurnBasedMatch::GetParticipant(this, this.mSelfParticipantId);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GetParticipant(SelfParticipantId);
			}
		}

		[Token(Token = "0x1700012B")]
		public Participant[] Participants
		{
			[Token(Token = "0x60003FE")]
			[Address(RVA = "0xFD67E8", Offset = "0xFD67E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mParticipants;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Participants;
			}
		}

		[Token(Token = "0x1700012C")]
		public string CurrentParticipantId
		{
			[Token(Token = "0x60003FF")]
			[Address(RVA = "0xFD67F0", Offset = "0xFD67F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCurrentParticipantId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentParticipantId;
			}
		}

		[Token(Token = "0x1700012D")]
		public Participant CurrentParticipant
		{
			[Token(Token = "0x6000400")]
			[Address(RVA = "0xFD67F8", Offset = "0xFD67F8", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.mCurrentParticipantId == 0;\n\tif (v2) goto L_0006;\n\treturnVal2 = EasyMobile.TurnBasedMatch::GetParticipant(this, this.mCurrentParticipantId);\n\treturn returnVal2;\nL_0006:\n\treturn 0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (CurrentParticipantId != null)
				{
					return GetParticipant(CurrentParticipantId);
				}
				return null;
			}
		}

		[Token(Token = "0x1700012E")]
		public MatchStatus Status
		{
			[Token(Token = "0x6000401")]
			[Address(RVA = "0xFD680C", Offset = "0xFD680C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMatchStatus;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Status;
			}
		}

		[Token(Token = "0x6000402")]
		[Address(RVA = "0xFD66DC", Offset = "0xFD66DC", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1ECFDE0]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, participantId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20256E7]) = v43;\nL_0016:\n\tv44 = this.mParticipants;\n\tv107 = v44.Length;\n\tv57 = v44.Length < 1;\n\tif (v57) goto L_0053;\nL_0027:\n\tv177 = v69 < v107;\n\tv95 = ~v177;\n\tif (v95) goto L_006F;\n\tv105 = v44[v69 @ X22_v7 (System.Int32)];\n\tv137 = System.String::Equals(v105.mParticipantId, participantId);\n\tv247 = v137 == 0;\n\tv139 = ~v247;\n\tif (v139) goto L_006E;\n\tv107 = v44.Length;\n\tv69 = v69 + 1;\n\tv119 = v69 < v44.Length;\n\tif (v119) goto L_0027;\nL_0053:\n\tv148 = System.String::Concat(\"Participant not found in turn-based match: \", participantId);\n\tgoto L_0064;\n\tv186 = *([v181 @ X8_v12+E0]);\n\tv187 = v186 == 0;\n\tv188 = ~v187;\n\tif (v188) goto L_0064;\n\tv240 = v181;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v240, v145, v146, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0064:\n\tUnityEngine.Debug::LogWarning(v148);\nL_006E:\n\treturn v244;\nL_006F:\n\tv185 = new System.IndexOutOfRangeException();\n\tthrow v185;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Participant GetParticipant(string participantId)
		{
			Participant[] participants = Participants;
			int num = participants.Length;
			if (participants.Length < 1)
			{
				goto IL_00d7;
			}
			int num2 = 0;
			Participant result;
			while (true)
			{
				if (num2 < num)
				{
					Participant participant = participants[num2];
					bool flag = participant.ParticipantId.Equals(participantId);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = participants[num2];
					if (flag3)
					{
						break;
					}
					num = participants.Length;
					num2++;
					if (num2 < participants.Length)
					{
						continue;
					}
					goto IL_00d7;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_011e;
			IL_00d7:
			string message = "Participant not found in turn-based match: " + participantId;
			Debug.LogWarning(message);
			result = null;
			goto IL_011e;
			IL_011e:
			return result;
		}

		[Token(Token = "0x6000403")]
		[Address(RVA = "0xFD6814", Offset = "0xFD6814", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1ECEB20]);\n\tv31 = *([v30 @ X8_v52]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20256E8]) = v50;\nL_001D:\n\t// 29 NewArr v55 @ X0_v3 (System.Object[]), typeof(System.Object[]), 7\n\tv59 = this.mMatchId == 0;\n\tif (v59) goto L_002A;\n\t// 39 IsInst v126 @ X0_v52, typeof(System.Object), this.mMatchId (System.String)\nL_002A:\n\tv374 = v55.Length;\n\tv133 = v55.Length == 0;\n\tif (v133) goto L_0119;\n\tv55[0] = this.mMatchId;\n\tv135 = this.mData == 0;\n\tif (v135) goto L_0038;\n\t// 52 IsInst v326 @ X0_v50, typeof(System.Object), this.mData (System.Byte[])\n\tv374 = v55.Length;\nL_0038:\n\tv350 = v374 < 1;\n\tv204 = ~v350;\n\tv197 = v374 - 1;\n\tv183 = v197 == 0;\n\tv351 = ~v204;\n\tv148 = v351 | v183;\n\tif (v148) goto L_0119;\n\tv55[1] = this.mData;\n\tv355 = this.mSelfParticipantId == 0;\n\tif (v355) goto L_004F;\n\t// 75 IsInst v327 @ X0_v48, typeof(System.Object), this.mSelfParticipantId (System.String)\n\tv374 = v55.Length;\nL_004F:\n\tv358 = v374 < 2;\n\tv205 = ~v358;\n\tv198 = v374 - 2;\n\tv184 = v198 == 0;\n\tv359 = ~v205;\n\tv149 = v359 | v184;\n\tif (v149) goto L_0119;\n\tv55[2] = this.mSelfParticipantId;\n\tgoto L_006D;\n\tv366 = *([v362 @ X0_v15 (Il2CppClass<EasyMobile.TurnBasedMatch+<>c>)+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_006D;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v362, v228, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv370 = EasyMobile.TurnBasedMatch+<>c;\nL_006D:\n\tv212 = v374.<>9__31_0;\n\tv379 = v374.<>9__31_0 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_0096;\n\tgoto L_0084;\n\tv405 = *([v369 @ X0_v16 (Il2CppClass<EasyMobile.TurnBasedMatch+<>c>)+E0]);\n\tv406 = v405 == 0;\n\tv407 = ~v406;\n\tif (v407) goto L_0084;\n\tv410 = \"il2cpp_codegen_runtime_class_init\"(v369, v228, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv426 = EasyMobile.TurnBasedMatch+<>c;\n\tv412 = *([v426 @ X8_v42+B8]);\nL_0084:\n\tv394 = new System.Func`2<EasyMobile.Participant, System.String>();\n\tSystem.Func`2<EasyMobile.Participant, System.String>::.ctor(v394, v374.<>9, Il2CppMethodInfo);\n\tv374.<>9__31_0 = v394;\nL_0096:\n\tv404 = System.Linq.Enumerable::Select(this.mParticipants, v212);\n\tv419 = System.Linq.Enumerable::ToArray(v404);\n\tv425 = System.String::Join(\",\", v419);\n\tv428 = v425 == 0;\n\tif (v428) goto L_00A8;\n\t// 165 IsInst v328 @ X0_v40, typeof(System.Object), v425 @ X0_v22 (System.String)\nL_00A8:\n\tv374 = v55.Length;\n\tv431 = v55.Length < 3;\n\tv201 = ~v431;\n\tv194 = v55.Length - 3;\n\tv180 = v194 == 0;\n\tv432 = ~v201;\n\tv145 = v432 | v180;\n\tif (v145) goto L_0119;\n\tv55[3] = v425;\n\tv433 = this.mCurrentParticipantId == 0;\n\tif (v433) goto L_00C0;\n\t// 188 IsInst v329 @ X0_v38, typeof(System.Object), this.mCurrentParticipantId (System.String)\n\tv374 = v55.Length;\nL_00C0:\n\tv436 = v374 < 4;\n\tv206 = ~v436;\n\tv199 = v374 - 4;\n\tv185 = v199 == 0;\n\tv437 = ~v206;\n\tv150 = v437 | v185;\n\tif (v150) goto L_0119;\n\tv55[4] = this.mCurrentParticipantId;\n\tv439 = this.mMatchStatus;\n\t// 211 Box v442 @ X0_v26, typeof(EasyMobile.TurnBasedMatch+MatchStatus), &v439 @ X8_v24 (EasyMobile.TurnBasedMatch+MatchStatus)\n\tv443 = v442 == 0;\n\tif (v443) goto L_00DD;\n\t// 218 IsInst v330 @ X0_v36, typeof(System.Object), v442 @ X0_v26\nL_00DD:\n\tv374 = v55.Length;\n\tv446 = v55.Length < 5;\n\tv202 = ~v446;\n\tv195 = v55.Length - 5;\n\tv181 = v195 == 0;\n\tv447 = ~v202;\n\tv146 = v447 | v181;\n\tif (v146) goto L_0119;\n\tv55[5] = v442;\n\tv449 = this.mPlayerCount;\n\t// 241 Box v452 @ X0_v29, typeof(System.Int32), &v449 @ X8_v27 (System.Int32)\n\tv453 = v452 == 0;\n\tif (v453) goto L_00FC;\n\t// 248 IsInst v331 @ X0_v34, typeof(System.Object), v452 @ X0_v29\nL_00FC:\n\tv456 = v55.Length < 6;\n\tv203 = ~v456;\n\tv196 = v55.Length - 6;\n\tv182 = v196 == 0;\n\tv457 = ~v203;\n\tv147 = v457 | v182;\n\tif (v147) goto L_0119;\n\tv55[6] = v452;\n\treturnVal2 = System.String::Format(\"[TurnBasedMatch: mMatchId={0}, mData={1}, mSelfParticipantId={2}, mParticipants={3}, mCurrentParticipantId={4}, mMatchStatus={5}, mPlayerCount={6}]\", v55);\n\treturn returnVal2;\nL_0119:\n\tv256 = new System.IndexOutOfRangeException();\n\tgoto L_011E;\n\tv347 = new System.ArrayTypeMismatchException();\nL_011E:\n\tthrow v354;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 167 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_040f: Expected O, but got I
			//IL_046d: Expected O, but got I
			//IL_0190: Expected O, but got I4
			//IL_0528: Expected O, but got I
			//IL_02a9: Expected O, but got I4
			//IL_0362: Expected O, but got I4
			object[] array = new object[7];
			if (MatchId != null)
			{
				object obj = MatchId as object;
			}
			IntPtr intPtr = (IntPtr)array.Length;
			if (array.Length != 0)
			{
				array[0] = MatchId;
				if (Data != null)
				{
					object obj2 = Data as object;
					intPtr = (IntPtr)array.Length;
				}
				bool flag = (long)intPtr < 1L;
				bool flag2 = !flag;
				object obj3 = (long)intPtr - 1L;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = Data;
					if (SelfParticipantId != null)
					{
						object obj4 = SelfParticipantId as object;
						intPtr = (IntPtr)array.Length;
					}
					bool flag5 = (long)intPtr < 2L;
					bool flag6 = !flag5;
					object obj5 = (long)intPtr - 2L;
					bool flag7 = obj5 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = SelfParticipantId;
						Func<Participant, string> selector = _003C_003Ec._003C_003E9__31_0;
						if (_003C_003Ec._003C_003E9__31_0 == null)
						{
							selector = (_003C_003Ec._003C_003E9__31_0 = delegate(Participant p)
							{
								//IL_0008: Expected I, but got O
								//IL_0018: Expected O, but got I
								//IL_0028: Expected O, but got I
								IntPtr intPtr2 = (IntPtr)p;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.Participant>)+160]");
								object obj16 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.Participant>)+168]");
								object obj17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: X0)");
								return (string)null;
							});
						}
						IEnumerable<string> source = Participants.Select(selector);
						string[] value = source.ToArray();
						string text = string.Join(",", value);
						if (text != null)
						{
							object obj6 = text as object;
						}
						intPtr = (IntPtr)array.Length;
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj7 = array.Length - 3;
						bool flag11 = obj7 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = text;
							if (CurrentParticipantId != null)
							{
								object obj8 = CurrentParticipantId as object;
								intPtr = (IntPtr)array.Length;
							}
							bool flag13 = (long)intPtr < 4L;
							bool flag14 = !flag13;
							object obj9 = (long)intPtr - 4L;
							bool flag15 = obj9 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = CurrentParticipantId;
								MatchStatus status = Status;
								object obj10 = status;
								if (obj10 != null)
								{
									object obj11 = obj10 as object;
								}
								intPtr = (IntPtr)array.Length;
								bool flag17 = array.Length < 5;
								bool flag18 = !flag17;
								object obj12 = array.Length - 5;
								bool flag19 = obj12 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = obj10;
									int playerCount = PlayerCount;
									object obj13 = playerCount;
									if (obj13 != null)
									{
										object obj14 = obj13 as object;
									}
									bool flag21 = array.Length < 6;
									bool flag22 = !flag21;
									object obj15 = array.Length - 6;
									bool flag23 = obj15 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[6] = obj13;
										return string.Format("[TurnBasedMatch: mMatchId={0}, mData={1}, mSelfParticipantId={2}, mParticipants={3}, mCurrentParticipantId={4}, mMatchStatus={5}, mPlayerCount={6}]", array);
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000404")]
		[Address(RVA = "0xFD6B08", Offset = "0xFD6B08", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mMatchId = matchId;\n\tthis.mPlayerCount = playerCount;\n\tthis.mData = data;\n\tthis.mSelfParticipantId = selfParticipantId;\n\tthis.mParticipants = participants;\n\tthis.mCurrentParticipantId = currentParticipantId;\n\tthis.mMatchStatus = matchStatus;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected TurnBasedMatch(string matchId, int playerCount, byte[] data, string selfParticipantId, Participant[] participants, string currentParticipantId, MatchStatus matchStatus)
		{
			mMatchId = matchId;
			mPlayerCount = playerCount;
			mData = data;
			mSelfParticipantId = selfParticipantId;
			mParticipants = participants;
			mCurrentParticipantId = currentParticipantId;
			mMatchStatus = matchStatus;
		}
	}
}
