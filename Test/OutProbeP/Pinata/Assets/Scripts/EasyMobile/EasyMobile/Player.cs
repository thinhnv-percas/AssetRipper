using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace EasyMobile
{
	[Token(Token = "0x200004C")]
	public class Player : IUserProfile, IComparable<Player>
	{
		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x10")]
		private string mPlayerName;

		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x18")]
		private string mPlayerId;

		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x20")]
		private bool mIsFriend;

		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x24")]
		private UserState mState;

		[Token(Token = "0x1700012F")]
		public string userName
		{
			[Token(Token = "0x6000405")]
			[Address(RVA = "0xFD237C", Offset = "0xFD237C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mPlayerName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return userName;
			}
		}

		[Token(Token = "0x17000130")]
		public string id
		{
			[Token(Token = "0x6000406")]
			[Address(RVA = "0xFD2384", Offset = "0xFD2384", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mPlayerId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return id;
			}
		}

		[Token(Token = "0x17000131")]
		public bool isFriend
		{
			[Token(Token = "0x6000407")]
			[Address(RVA = "0xFD238C", Offset = "0xFD238C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsFriend;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isFriend;
			}
		}

		[Token(Token = "0x17000132")]
		public UserState state
		{
			[Token(Token = "0x6000408")]
			[Address(RVA = "0xFD2394", Offset = "0xFD2394", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return state;
			}
		}

		[Token(Token = "0x17000133")]
		public Texture2D image
		{
			[Token(Token = "0x6000409")]
			[Address(RVA = "0xFD239C", Offset = "0xFD239C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600040A")]
		[Address(RVA = "0xFD23A4", Offset = "0xFD23A4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::CompareTo(this.mPlayerId, other.mPlayerId);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(Player other)
		{
			return id.CompareTo(other.id);
		}

		[Token(Token = "0x600040B")]
		[Address(RVA = "0xFD23D0", Offset = "0xFD23D0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = obj == 0;\n\tif (v0) goto L_000F;\n\tv7 = this == obj;\n\tif (v7) goto L_0011;\n\treturnVal3 = EasyMobile.Player::IsEqual(this, obj);\n\treturn returnVal3;\nL_000F:\n\treturn 0;\nL_0011:\n\treturn 1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(Player obj)
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

		[Token(Token = "0x600040C")]
		[Address(RVA = "0xFD241C", Offset = "0xFD241C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC6E50]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256A6]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv47 = this == obj;\n\tif (v47) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv85 = v85_asT != 0;\n\tif (v85) goto L_0052;\n\tgoto L_0049;\nL_0049:\n\treturn returnVal1;\nL_0052:\n\treturnVal2 = EasyMobile.Player::IsEqual(this, obj);\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			if (obj != null)
			{
				if (this == obj)
				{
					return true;
				}
				Player player = obj as Player;
				if (player != null)
				{
					return IsEqual((Player)obj);
				}
			}
			return false;
		}

		[Token(Token = "0x600040D")]
		[Address(RVA = "0xFD24CC", Offset = "0xFD24CC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.mPlayerId;\n\tv2 = this.mPlayerId == 0;\n\tif (v2) goto L_0007;\n\tv3 = returnVal1.m_value;\n\t// 6 IndirectJump [v3 @ X8_v1 (System.Int32)+150], this.mPlayerId (System.String), this.mPlayerId (System.String), [v3 @ X8_v1 (System.Int32)+158], [v3 @ X8_v1 (System.Int32)+150], v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\nL_0007:\n\treturn this.mPlayerId;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			//IL_000a: Expected I4, but got O
			//IL_0047: Expected I4, but got O
			int num = (int)id;
			if (id != null)
			{
				int value = ((int*)num)->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v3 @ X8_v1 (System.Int32)+150] (should have been resolved before IL gen)");
			}
			return (int)id;
		}

		[Token(Token = "0x600040E")]
		[Address(RVA = "0xFD24E4", Offset = "0xFD24E4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EEA8B8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256A7]) = v38;\nL_001E:\n\treturnVal1 = System.String::Format(\"[Player: '{0}' (id {1})]\", this.mPlayerName, this.mPlayerId);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return $"[Player: '{userName}' (id {id})]";
		}

		[Token(Token = "0x600040F")]
		[Address(RVA = "0xFD23F0", Offset = "0xFD23F0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::Equals(this.mPlayerId, other.mPlayerId);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool IsEqual(Player other)
		{
			return id.Equals(other.id);
		}

		[Token(Token = "0x6000410")]
		[Address(RVA = "0xFD2538", Offset = "0xFD2538", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EAE260]);\n\tv35 = *([v34 @ X8_v10]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, playerName, playerId, isFriend, state, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20256A8]) = v50;\nL_0022:\n\tthis.mPlayerName = v56.Empty;\n\tthis.mState = 3;\n\tthis.mPlayerId = v58.Empty;\n\tSystem.Object::.ctor(this);\n\tthis.mPlayerName = playerName;\n\tthis.mPlayerId = playerId;\n\tthis.mIsFriend = isFriend;\n\tthis.mState = state;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected Player(string playerName, string playerId, bool isFriend, UserState state)
		{
			mPlayerName = string.Empty;
			mState = UserState.Offline;
			mPlayerId = string.Empty;
			mPlayerName = playerName;
			mPlayerId = playerId;
			mIsFriend = isFriend;
			mState = state;
		}
	}
}
