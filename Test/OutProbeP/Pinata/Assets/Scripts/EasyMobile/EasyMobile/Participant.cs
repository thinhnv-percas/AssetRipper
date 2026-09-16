using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200004A")]
	public class Participant : IComparable<Participant>
	{
		[Token(Token = "0x2000121")]
		public enum ParticipantStatus
		{
			[Token(Token = "0x40004D8")]
			Unknown = 0,
			[Token(Token = "0x40004D9")]
			NotInvitedYet = 1,
			[Token(Token = "0x40004DA")]
			Matching = 2,
			[Token(Token = "0x40004DB")]
			Invited = 3,
			[Token(Token = "0x40004DC")]
			Declined = 4,
			[Token(Token = "0x40004DD")]
			Joined = 5,
			[Token(Token = "0x40004DE")]
			Unresponsive = 6,
			[Token(Token = "0x40004DF")]
			Left = 7,
			[Token(Token = "0x40004E0")]
			Done = 8
		}

		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x10")]
		private string mDisplayName;

		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x18")]
		private string mParticipantId;

		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x20")]
		private ParticipantStatus mStatus;

		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x28")]
		private Player mPlayer;

		[Token(Token = "0x40001DE")]
		[FieldOffset(Offset = "0x30")]
		private bool mIsConnectedToRoom;

		[Token(Token = "0x1700011F")]
		public string DisplayName
		{
			[Token(Token = "0x60003EB")]
			[Address(RVA = "0xFD1F64", Offset = "0xFD1F64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDisplayName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DisplayName;
			}
		}

		[Token(Token = "0x17000120")]
		public string ParticipantId
		{
			[Token(Token = "0x60003EC")]
			[Address(RVA = "0xFD1F6C", Offset = "0xFD1F6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mParticipantId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ParticipantId;
			}
		}

		[Token(Token = "0x17000121")]
		public ParticipantStatus Status
		{
			[Token(Token = "0x60003ED")]
			[Address(RVA = "0xFD1F74", Offset = "0xFD1F74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mStatus;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Status;
			}
		}

		[Token(Token = "0x17000122")]
		public Player Player
		{
			[Token(Token = "0x60003EE")]
			[Address(RVA = "0xFD1F7C", Offset = "0xFD1F7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mPlayer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Player;
			}
		}

		[Token(Token = "0x17000123")]
		public bool IsConnectedToRoom
		{
			[Token(Token = "0x60003EF")]
			[Address(RVA = "0xFD1F84", Offset = "0xFD1F84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsConnectedToRoom;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsConnectedToRoom;
			}
		}

		[Token(Token = "0x60003F0")]
		[Address(RVA = "0xFD1F8C", Offset = "0xFD1F8C", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EA7458]);\n\tv25 = *([v24 @ X8_v37]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20256A3]) = v44;\nL_001A:\n\t// 26 NewArr v49 @ X0_v3 (System.Object[]), typeof(System.Object[]), 5\n\tv53 = this.mDisplayName == 0;\n\tif (v53) goto L_0027;\n\t// 36 IsInst v125 @ X0_v39, typeof(System.Object), this.mDisplayName (System.String)\nL_0027:\n\tv290 = v49.Length;\n\tv132 = v49.Length == 0;\n\tif (v132) goto L_00BE;\n\tv49[0] = this.mDisplayName;\n\tv133 = this.mParticipantId == 0;\n\tif (v133) goto L_0035;\n\t// 49 IsInst v260 @ X0_v37, typeof(System.Object), this.mParticipantId (System.String)\n\tv290 = v49.Length;\nL_0035:\n\tv278 = v290 < 1;\n\tv94 = ~v278;\n\tv90 = v290 - 1;\n\tv82 = v90 == 0;\n\tv279 = ~v94;\n\tv62 = v279 | v82;\n\tif (v62) goto L_00BE;\n\tv49[1] = this.mParticipantId;\n\tv103 = this + 0x20;\n\t// 71 Box v112 @ X0_v15, typeof(EasyMobile.Participant+ParticipantStatus), v103 @ X22_v5\n\tv290 = *([v112 @ X0_v15]);\n\t*([v290 @ X8_v15 (EasyMobile.Participant+ParticipantStatus)+160])(v287, v112, *([v290 @ X8_v15 (EasyMobile.Participant+ParticipantStatus)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv289 = \"il2cpp_vm_object_unbox\"(v112, *([v290 @ X8_v15 (EasyMobile.Participant+ParticipantStatus)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv290 = *([v289 @ X0_v19]);\n\tthis.mStatus = *([v289 @ X0_v19]);\n\tv291 = v287 == 0;\n\tif (v291) goto L_005D;\n\t// 90 IsInst v261 @ X0_v35, typeof(System.Object), v287 @ X0_v17\nL_005D:\n\tv290 = v49.Length;\n\tv294 = v49.Length < 2;\n\tv169 = ~v294;\n\tv165 = v49.Length - 2;\n\tv157 = v165 == 0;\n\tv295 = ~v169;\n\tv137 = v295 | v157;\n\tif (v137) goto L_00BE;\n\tv49[2] = v287;\n\tv299 = this.mPlayer == 0;\n\tif (v299) goto L_007D;\n\tv303 = EasyMobile.Player::ToString(this.mPlayer);\n\tv305 = v303 == 0;\n\tv306 = ~v305;\n\tif (v306) goto L_0082;\n\tgoto L_0085;\nL_007D:\n\tv310 = \"NULL\" == 0;\n\tif (v310) goto L_0085;\nL_0082:\n\t// 130 IsInst v262 @ X0_v32, typeof(System.Object), v252 @ X22_v8 (System.String)\nL_0085:\n\tv290 = v49.Length;\n\tv317 = v49.Length < 3;\n\tv170 = ~v317;\n\tv166 = v49.Length - 3;\n\tv158 = v166 == 0;\n\tv318 = ~v170;\n\tv138 = v318 | v158;\n\tif (v138) goto L_00BE;\n\tv49[3] = v178;\n\tv320 = this.mIsConnectedToRoom;\n\t// 153 Box v323 @ X0_v24, typeof(System.Boolean), &v320 @ X8_v22 (System.Boolean)\n\tv324 = v323 == 0;\n\tif (v324) goto L_00A4;\n\t// 160 IsInst v263 @ X0_v29, typeof(System.Object), v323 @ X0_v24\nL_00A4:\n\tv327 = v49.Length < 4;\n\tv171 = ~v327;\n\tv167 = v49.Length - 4;\n\tv159 = v167 == 0;\n\tv328 = ~v171;\n\tv139 = v328 | v159;\n\tif (v139) goto L_00BE;\n\tv49[4] = v323;\n\treturnVal2 = System.String::Format(\"[Participant: '{0}' (id {1}), status={2}, player={3}, connected={4}]\", v49);\n\treturn returnVal2;\nL_00BE:\n\tv204 = new System.IndexOutOfRangeException();\n\tgoto L_00C3;\n\tv275 = new System.ArrayTypeMismatchException();\nL_00C3:\n\tthrow v281;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0418: Expected O, but got I4
			//IL_00d7: Expected O, but got I
			//IL_00e0: Expected I4, but got O
			//IL_00f1: Expected I4, but got O
			//IL_0112: Expected I4, but got O
			//IL_011c: Expected I4, but got O
			//IL_0181: Expected O, but got I4
			//IL_02b3: Expected O, but got I4
			//IL_036c: Expected O, but got I4
			object[] array = new object[5];
			if (DisplayName != null)
			{
				object obj = DisplayName as object;
			}
			ParticipantStatus participantStatus = (ParticipantStatus)array.Length;
			string text2;
			string text3;
			if (array.Length != 0)
			{
				array[0] = DisplayName;
				if (ParticipantId != null)
				{
					object obj2 = ParticipantId as object;
					participantStatus = (ParticipantStatus)array.Length;
				}
				bool flag = participantStatus < ParticipantStatus.NotInvitedYet;
				bool flag2 = !flag;
				object obj3 = participantStatus - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = ParticipantId;
					object obj4 = (long)(IntPtr)this + 32L;
					object obj5 = (ParticipantStatus)obj4;
					participantStatus = (ParticipantStatus)obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v290 @ X8_v15 (EasyMobile.Participant+ParticipantStatus)+160] (should have been resolved before IL gen)");
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj6 = default(object);
					participantStatus = (ParticipantStatus)obj6;
					mStatus = (ParticipantStatus)obj6;
					object obj7 = default(object);
					if (obj7 != null)
					{
						object obj8 = obj7 as object;
					}
					participantStatus = (ParticipantStatus)array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj9 = array.Length - 2;
					bool flag7 = obj9 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = obj7;
						if (Player != null)
						{
							string text = Player.ToString();
							bool flag9 = text == null;
							bool flag10 = !flag9;
							text2 = text;
							if (flag10)
							{
								goto IL_0263;
							}
							text3 = text;
						}
						else
						{
							bool flag11 = "NULL" == null;
							text2 = "NULL";
							text3 = "NULL";
							if (!flag11)
							{
								goto IL_0263;
							}
						}
						goto IL_027d;
					}
				}
			}
			goto IL_03ca;
			IL_03ca:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_027d:
			participantStatus = (ParticipantStatus)array.Length;
			bool flag12 = array.Length < 3;
			bool flag13 = !flag12;
			object obj10 = array.Length - 3;
			bool flag14 = obj10 == null;
			bool flag15 = !flag13;
			if (!(flag15 || flag14))
			{
				array[3] = text3;
				bool isConnectedToRoom = IsConnectedToRoom;
				object obj11 = isConnectedToRoom;
				if (obj11 != null)
				{
					object obj12 = obj11 as object;
				}
				bool flag16 = array.Length < 4;
				bool flag17 = !flag16;
				object obj13 = array.Length - 4;
				bool flag18 = obj13 == null;
				bool flag19 = !flag17;
				if (!(flag19 || flag18))
				{
					array[4] = obj11;
					return string.Format("[Participant: '{0}' (id {1}), status={2}, player={3}, connected={4}]", array);
				}
			}
			goto IL_03ca;
			IL_0263:
			object obj14 = text2 as object;
			text3 = text2;
			goto IL_027d;
		}

		[Token(Token = "0x60003F1")]
		[Address(RVA = "0xFD218C", Offset = "0xFD218C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::CompareTo(this.mParticipantId, other.mParticipantId);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(Participant other)
		{
			return ParticipantId.CompareTo(other.ParticipantId);
		}

		[Token(Token = "0x60003F2")]
		[Address(RVA = "0xFD21B8", Offset = "0xFD21B8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = obj == 0;\n\tif (v0) goto L_000F;\n\tv7 = this == obj;\n\tif (v7) goto L_0011;\n\treturnVal3 = EasyMobile.Participant::IsEqual(this, obj);\n\treturn returnVal3;\nL_000F:\n\treturn 0;\nL_0011:\n\treturn 1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(Participant obj)
		{
			if (obj != null)
			{
				if (this != obj)
				{
					return IsEqual(obj);
				}
				return true;
			}
			return false;
		}

		[Token(Token = "0x60003F3")]
		[Address(RVA = "0xFD2204", Offset = "0xFD2204", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE1F90]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256A4]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv47 = this == obj;\n\tif (v47) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv85 = v85_asT != 0;\n\tif (v85) goto L_0052;\n\tgoto L_0049;\nL_0049:\n\treturn returnVal1;\nL_0052:\n\treturnVal2 = EasyMobile.Participant::IsEqual(this, obj);\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			if (obj != null)
			{
				if (this == obj)
				{
					return true;
				}
				Participant participant = obj as Participant;
				if (participant != null)
				{
					return IsEqual((Participant)obj);
				}
			}
			return false;
		}

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0xFD22B4", Offset = "0xFD22B4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.mParticipantId;\n\tv2 = this.mParticipantId == 0;\n\tif (v2) goto L_0007;\n\tv3 = returnVal1.m_value;\n\t// 6 IndirectJump [v3 @ X8_v1 (System.Int32)+150], this.mParticipantId (System.String), this.mParticipantId (System.String), [v3 @ X8_v1 (System.Int32)+158], [v3 @ X8_v1 (System.Int32)+150], v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\nL_0007:\n\treturn this.mParticipantId;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			//IL_000a: Expected I4, but got O
			//IL_0047: Expected I4, but got O
			int num = (int)ParticipantId;
			if (ParticipantId != null)
			{
				int value = ((int*)num)->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v3 @ X8_v1 (System.Int32)+150] (should have been resolved before IL gen)");
			}
			return (int)ParticipantId;
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0xFD21D8", Offset = "0xFD21D8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::Equals(this.mParticipantId, other.mParticipantId);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool IsEqual(Participant other)
		{
			return ParticipantId.Equals(other.ParticipantId);
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0xFD22CC", Offset = "0xFD22CC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv38 = *([1F02470]);\n\tv39 = *([v38 @ X8_v10]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, displayName, participantId, status, player, connectedToRoom, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20256A5]) = v53;\nL_0024:\n\tthis.mDisplayName = v59.Empty;\n\tthis.mParticipantId = v61.Empty;\n\tSystem.Object::.ctor(this);\n\tthis.mDisplayName = displayName;\n\tthis.mParticipantId = participantId;\n\tthis.mStatus = status;\n\tthis.mPlayer = player;\n\tthis.mIsConnectedToRoom = connectedToRoom;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected Participant(string displayName, string participantId, ParticipantStatus status, Player player, bool connectedToRoom)
		{
			mDisplayName = string.Empty;
			mParticipantId = string.Empty;
			mDisplayName = displayName;
			mParticipantId = participantId;
			mStatus = status;
			mPlayer = player;
			mIsConnectedToRoom = connectedToRoom;
		}
	}
}
