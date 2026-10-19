using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x2000016")]
	public sealed class PermanentString : PermanentVariable<string>
	{
		[Token(Token = "0x6000094")]
		[Address(RVA = "0x3F3FAAC", Offset = "0x3F3FAAC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\nL_0032:\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<System.Object>::.ctor(v70, v63, v61, v59, v57);\n\treturn;\n")]
		public PermanentString(string key, string initialValue, object remoteData = null, DateTime? lastSavedRemoteTime = null)
			: base(key, initialValue, remoteData, lastSavedRemoteTime)
		{
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x3F3FB3C", Offset = "0x3F3FB3C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\treturn pString.CurrentValue;\n")]
		public static implicit operator string(PermanentString pString)
		{
			return pString.CurrentValue;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x3F3FB84", Offset = "0x3F3FB84", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\treturnVal1 = System.String::op_Equality(a.CurrentValue, v40);\n\treturn returnVal1;\nL_002C:\n\treturnVal2 = System.String::op_Equality(0, v40);\n\treturn returnVal2;\nL_0016:\n\tv46 = a == 0;\n\tif (v46) goto L_002C;\n")]
		public static bool operator ==(PermanentString a, string value)
		{
			string text = default(string);
			if ((object)a != null)
			{
				return a.CurrentValue == text;
			}
			return null == text;
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x3F3FBF4", Offset = "0x3F3FBF4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\treturnVal1 = System.String::op_Inequality(a.CurrentValue, v40);\n\treturn returnVal1;\nL_002C:\n\treturnVal2 = System.String::op_Inequality(0, v40);\n\treturn returnVal2;\nL_0016:\n\tv46 = a == 0;\n\tif (v46) goto L_002C;\n")]
		public static bool operator !=(PermanentString a, string value)
		{
			string text = default(string);
			if ((object)a != null)
			{
				return a.CurrentValue != text;
			}
			return null != text;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x3F3FC64", Offset = "0x3F3FC64", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv52 = *([obj @ X1 (System.Object)]) == Unco.SaveSystem.Core.Variables.PermanentString;\n\tif (v52) goto L_0033;\nL_002D:\n\treturn 0;\nL_0033:\n\tgoto L_0041;\nL_0041:\n\tgoto L_0051;\nL_0015:\n\tv43 = obj == 0;\n\tif (v43) goto L_002D;\nL_0051:\n\treturnVal3 = System.String::op_Equality(*([obj @ X1 (System.Object)+10]), this.CurrentValue);\n\treturn returnVal3;\n")]
		public override bool Equals(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentString::Equals");
			return default;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x3F3FD34", Offset = "0x3F3FD34", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal2 = System.String::Equals(this.CurrentValue, other.CurrentValue);\n\treturn returnVal2;\n")]
		private bool Equals(PermanentString other)
		{
			return CurrentValue.Equals(other.CurrentValue);
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x3F3FD94", Offset = "0x3F3FD94", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv38 = System.String::GetHashCode(v38);\n\treturn v38;\nL_0012:\n\tv38 = this.CurrentValue;\n")]
		public override int GetHashCode()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentString::GetHashCode");
			return default;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x3F3FDE4", Offset = "0x3F3FDE4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B78EBE0]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0032;\n\tv24 = *([B78EBE1]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_0040;\nL_0014:\n\tv50 = obj == 0;\n\tif (v50) goto L_0048;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv96 = System.Convert::ToString(obj);\n\tthis.CurrentValue = v96;\n\treturn;\nL_0032:\n\t*([B78EBE0]) = 1;\n\tv59 = *([B78EBE1]) & 1;\n\tv60 = v59 == 0;\n\tv45 = ~v60;\n\tif (v45) goto L_0014;\nL_0040:\n\t*([B78EBE1]) = 1;\n\tv97 = obj == 0;\n\tv64 = ~v97;\n\tif (v64) goto L_001C;\nL_0048:\n\tthis.CurrentValue = \"\";\n\treturn;\n")]
		public override void SetCurrentValue(object obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE0]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE1]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE1]");
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
			goto IL_010f;
			IL_0084:
			string text = Convert.ToString(obj);
			CurrentValue = text;
			return;
			IL_010f:
			CurrentValue = "";
			return;
			IL_0066:
			if (obj != null)
			{
				goto IL_0084;
			}
			goto IL_010f;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x3F3FEC0", Offset = "0x3F3FEC0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tgoto L_0024;\nL_0024:\n\treturnVal2 = System.Convert::ToString(obj);\n\treturn returnVal2;\nL_002E:\n\treturn \"\";\nL_0015:\n\tv39 = obj == 0;\n\tif (v39) goto L_002E;\n")]
		protected string Cast(object obj)
		{
			if (obj != null)
			{
				return Convert.ToString(obj);
			}
			return "";
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x3F3FF58", Offset = "0x3F3FF58", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78E000;\n\tv18 = *([B78EBE2]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0031;\n\tv21 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Object>::GetRemoteDataInner(this);\n\tv46 = *([B78EBE1]) & 1;\n\tv47 = v46 == 0;\n\tv85 = v21;\n\tv70 = v21;\n\tif (v47) goto L_0042;\nL_0017:\n\tv63 = v85 == 0;\n\tif (v63) goto L_0050;\nL_001E:\n\tgoto L_0028;\nL_0028:\n\treturnVal2 = System.Convert::ToString(v85);\n\treturn returnVal2;\nL_0031:\n\t*([v14 @ X19_v1+BE2]) = 1;\n\tv51 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Object>::GetRemoteDataInner(this);\n\tv74 = *([B78EBE1]) & 1;\n\tv75 = v74 == 0;\n\tv56 = ~v75;\n\tv85 = v51;\n\tv70 = v51;\n\tif (v56) goto L_0017;\nL_0042:\n\t*([B78EBE1]) = 1;\n\tv137 = v70 == 0;\n\tv81 = ~v137;\n\tv85 = v70;\n\tif (v81) goto L_001E;\nL_0050:\n\treturn \"\";\n")]
		public string GetRemoteData()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE2]");
			object obj2;
			object obj3;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				object remoteDataInner = ((PermanentVariable<object>)(object)this).GetRemoteDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE1]");
				int num = (int)((nint)0 & (nint)1);
				bool flag = num == 0;
				obj2 = remoteDataInner;
				obj3 = remoteDataInner;
				if (!flag)
				{
					goto IL_0089;
				}
			}
			else
			{
				_ = 1;
				object remoteDataInner2 = ((PermanentVariable<object>)(object)this).GetRemoteDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE1]");
				int num2 = (int)((nint)0 & (nint)1);
				bool flag2 = num2 == 0;
				bool flag3 = !flag2;
				obj2 = remoteDataInner2;
				obj3 = remoteDataInner2;
				if (flag3)
				{
					goto IL_0089;
				}
			}
			_ = 1;
			bool flag4 = obj3 == null;
			bool flag5 = !flag4;
			obj2 = obj3;
			if (flag5)
			{
				goto IL_00a7;
			}
			goto IL_014e;
			IL_00a7:
			return Convert.ToString(obj2);
			IL_014e:
			return "";
			IL_0089:
			if (obj2 != null)
			{
				goto IL_00a7;
			}
			goto IL_014e;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x3F40058", Offset = "0x3F40058", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78E000;\n\tv18 = *([B78EBE3]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0031;\n\tv21 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Object>::GetLocalDataInner(this);\n\tv46 = *([B78EBE1]) & 1;\n\tv47 = v46 == 0;\n\tv85 = v21;\n\tv70 = v21;\n\tif (v47) goto L_0042;\nL_0017:\n\tv63 = v85 == 0;\n\tif (v63) goto L_0050;\nL_001E:\n\tgoto L_0028;\nL_0028:\n\treturnVal2 = System.Convert::ToString(v85);\n\treturn returnVal2;\nL_0031:\n\t*([v14 @ X19_v1+BE3]) = 1;\n\tv51 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Object>::GetLocalDataInner(this);\n\tv74 = *([B78EBE1]) & 1;\n\tv75 = v74 == 0;\n\tv56 = ~v75;\n\tv85 = v51;\n\tv70 = v51;\n\tif (v56) goto L_0017;\nL_0042:\n\t*([B78EBE1]) = 1;\n\tv137 = v70 == 0;\n\tv81 = ~v137;\n\tv85 = v70;\n\tif (v81) goto L_001E;\nL_0050:\n\treturn \"\";\n")]
		public string GetLocalData()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE3]");
			object obj2;
			object obj3;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				object localDataInner = ((PermanentVariable<object>)(object)this).GetLocalDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE1]");
				int num = (int)((nint)0 & (nint)1);
				bool flag = num == 0;
				obj2 = localDataInner;
				obj3 = localDataInner;
				if (!flag)
				{
					goto IL_0089;
				}
			}
			else
			{
				_ = 1;
				object localDataInner2 = ((PermanentVariable<object>)(object)this).GetLocalDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBE1]");
				int num2 = (int)((nint)0 & (nint)1);
				bool flag2 = num2 == 0;
				bool flag3 = !flag2;
				obj2 = localDataInner2;
				obj3 = localDataInner2;
				if (flag3)
				{
					goto IL_0089;
				}
			}
			_ = 1;
			bool flag4 = obj3 == null;
			bool flag5 = !flag4;
			obj2 = obj3;
			if (flag5)
			{
				goto IL_00a7;
			}
			goto IL_014e;
			IL_00a7:
			return Convert.ToString(obj2);
			IL_014e:
			return "";
			IL_0089:
			if (obj2 != null)
			{
				goto IL_00a7;
			}
			goto IL_014e;
		}
	}
}
