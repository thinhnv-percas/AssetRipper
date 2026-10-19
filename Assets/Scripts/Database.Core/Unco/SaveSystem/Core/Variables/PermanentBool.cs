using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x2000010")]
	public class PermanentBool : PermanentVariable<bool>
	{
		[Token(Token = "0x6000047")]
		[Address(RVA = "0x3F3E7F0", Offset = "0x3F3E7F0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\nL_0032:\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<System.Boolean>::.ctor(this, v63, v61, v59, v57);\n\treturn;\n")]
		public PermanentBool(string key, bool initialValue, object remoteData = null, DateTime? lastSavedRemoteTime = null)
			: base(key, initialValue, remoteData, lastSavedRemoteTime)
		{
			string key2 = default(string);
			bool initialValue2 = default(bool);
			object remoteData2 = default(object);
			DateTime? commonRemoteDateTime = default(DateTime?);
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x3F3E880", Offset = "0x3F3E880", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B78EBCD]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_002E;\n\tv24 = *([B78EBCE]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_0039;\nL_0014:\n\tv50 = obj == 0;\n\tif (v50) goto L_003E;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv89 = System.Convert::ToBoolean(obj);\n\tthis.CurrentValue = v89;\n\treturn;\nL_002E:\n\t*([B78EBCD]) = 1;\n\tv59 = *([B78EBCE]) & 1;\n\tv60 = v59 == 0;\n\tv45 = ~v60;\n\tif (v45) goto L_0014;\nL_0039:\n\t*([B78EBCE]) = 1;\n\tv84 = obj == 0;\n\tv63 = ~v84;\n\tif (v63) goto L_001C;\nL_003E:\n\tthis.CurrentValue = 0;\n\treturn;\n")]
		public override void SetCurrentValue(object obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBCD]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBCE]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBCE]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			_ = 1;
			if (obj != null)
			{
				goto IL_0084;
			}
			goto IL_010a;
			IL_0084:
			bool flag = Convert.ToBoolean(obj);
			CurrentValue = flag;
			return;
			IL_010a:
			CurrentValue = false;
			return;
			IL_0066:
			if (obj != null)
			{
				goto IL_0084;
			}
			goto IL_010a;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3F3E93C", Offset = "0x3F3E93C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tgoto L_0021;\nL_0021:\n\treturnVal2 = System.Convert::ToBoolean(obj);\n\treturn returnVal2;\nL_0029:\n\treturn 0;\nL_0012:\n\tv38 = obj == 0;\n\tif (v38) goto L_0029;\n")]
		private bool Cast(object obj)
		{
			if (obj != null)
			{
				return Convert.ToBoolean(obj);
			}
			return false;
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3F3E9C0", Offset = "0x3F3E9C0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn permanentBool.CurrentValue;\nL_0023:\n\treturn 0;\nL_0012:\n\tv38 = permanentBool == 0;\n\tif (v38) goto L_0023;\n")]
		public static implicit operator bool(PermanentBool permanentBool)
		{
			return permanentBool?.CurrentValue ?? false;
		}
	}
}
