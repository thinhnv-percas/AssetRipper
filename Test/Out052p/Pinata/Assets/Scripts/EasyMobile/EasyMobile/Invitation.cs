using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000041")]
	public class Invitation
	{
		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x10")]
		private MatchType mInvitationType;

		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x18")]
		private Participant mInviter;

		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x20")]
		private uint mVariant;

		[Token(Token = "0x17000117")]
		public MatchType InvitationType
		{
			[Token(Token = "0x60003AA")]
			[Address(RVA = "0xB53CC0", Offset = "0xB53CC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mInvitationType;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return InvitationType;
			}
		}

		[Token(Token = "0x17000118")]
		public Participant Inviter
		{
			[Token(Token = "0x60003AB")]
			[Address(RVA = "0xB53CC8", Offset = "0xB53CC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mInviter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Inviter;
			}
		}

		[Token(Token = "0x17000119")]
		public uint Variant
		{
			[Token(Token = "0x60003AC")]
			[Address(RVA = "0xB53CD0", Offset = "0xB53CD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mVariant;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Variant;
			}
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0xB53CD8", Offset = "0xB53CD8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EBC610]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20227B1]) = v40;\nL_0015:\n\tv42 = this.mInvitationType;\n\t// 26 Box v47 @ X0_v3 (System.Object), typeof(EasyMobile.MatchType), &v42 @ X8_v3 (EasyMobile.MatchType)\n\tv50 = this.mVariant;\n\t// 35 Box v56 @ X0_v5 (System.Object), typeof(System.UInt32), &v50 @ X8_v4 (System.UInt32)\n\treturnVal1 = System.String::Format(\"[Invitation: InvitationType={0}, Inviter={1}, Variant={2}]\", v47, this.mInviter, v56);\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			MatchType invitationType = InvitationType;
			object arg = invitationType;
			uint variant = Variant;
			object arg2 = variant;
			return $"[Invitation: InvitationType={arg}, Inviter={Inviter}, Variant={arg2}]";
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0xB53D84", Offset = "0xB53D84", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mInvitationType = invType;\n\tthis.mInviter = inviter;\n\tthis.mVariant = variant;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected Invitation(MatchType invType, Participant inviter, uint variant)
		{
			mInvitationType = invType;
			mInviter = inviter;
			mVariant = variant;
		}
	}
}
