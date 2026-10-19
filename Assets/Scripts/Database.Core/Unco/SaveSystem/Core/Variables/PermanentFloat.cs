using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x2000011")]
	public sealed class PermanentFloat : PermanentVariable<float>
	{
		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3F3EA1C", Offset = "0x3F3EA1C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\nL_0036:\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<System.Single>::.ctor(this, v67, v65, v63, v61);\n\treturn;\n")]
		public PermanentFloat(string key, float initialValue = 0f, object remoteData = null, DateTime? remoteLastSavedTime = null)
			: base(key, initialValue, remoteData, remoteLastSavedTime)
		{
			string key2 = default(string);
			float initialValue2 = default(float);
			object remoteData2 = default(object);
			DateTime? commonRemoteDateTime = default(DateTime?);
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3F3EAB4", Offset = "0x3F3EAB4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\treturn pFloat.CurrentValue;\n")]
		public static implicit operator float(PermanentFloat pFloat)
		{
			return pFloat.CurrentValue;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x3F3EAFC", Offset = "0x3F3EAFC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = a.CurrentValue + value;\n\treturn returnVal1;\n")]
		public static float operator +(PermanentFloat a, float value)
		{
			return a.CurrentValue + value;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3F3EB54", Offset = "0x3F3EB54", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = a.CurrentValue - value;\n\treturn returnVal1;\n")]
		public static float operator -(PermanentFloat a, float value)
		{
			return a.CurrentValue - value;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3F3EBAC", Offset = "0x3F3EBAC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = a.CurrentValue / value;\n\treturn returnVal1;\n")]
		public static float operator /(PermanentFloat a, float value)
		{
			return a.CurrentValue / value;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x3F3EC04", Offset = "0x3F3EC04", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = a.CurrentValue * value;\n\treturn returnVal1;\n")]
		public static float operator *(PermanentFloat a, float value)
		{
			return a.CurrentValue * value;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x3F3EC5C", Offset = "0x3F3EC5C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv46 = a.CurrentValue == value;\n\treturn v46;\n")]
		public static bool operator ==(PermanentFloat a, float value)
		{
			return a.CurrentValue == value;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x3F3ECB8", Offset = "0x3F3ECB8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv46 = a.CurrentValue == value;\n\tv53 = ~v46;\n\treturn v53;\n")]
		public static bool operator !=(PermanentFloat a, float value)
		{
			bool flag = a.CurrentValue == value;
			return !flag;
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x3F3ED14", Offset = "0x3F3ED14", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = *([obj @ X1 (System.Object)]) == Unco.SaveSystem.Core.Variables.PermanentFloat;\n\tif (v56) goto L_0037;\nL_0031:\n\treturn 0;\nL_0037:\n\tgoto L_0045;\nL_0045:\n\tgoto L_004D;\nL_0017:\n\tv47 = obj == 0;\n\tif (v47) goto L_0031;\nL_004D:\n\tv111 = *([obj @ X1 (System.Object)+10]) == this.CurrentValue;\n\treturn v111;\n")]
		public override bool Equals(object obj)
		{
			if (obj == null || (object)obj.GetType() != typeof(PermanentFloat))
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
			return 0f == CurrentValue;
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x3F3EDF0", Offset = "0x3F3EDF0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\treturnVal1 = System.Single::Equals(&v44 @ stack_-34_v1 (System.Single), other.CurrentValue);\n\treturn returnVal1;\nL_0016:\n\tv44 = this.CurrentValue;\n")]
		private bool Equals(PermanentFloat other)
		{
			return CurrentValue.Equals(other.CurrentValue);
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x3F3EE60", Offset = "0x3F3EE60", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv39 = this.CurrentValue;\n\treturnVal1 = System.Single::GetHashCode(&v39 @ stack_-24_v1 (System.Single));\n\treturn returnVal1;\n")]
		public override int GetHashCode()
		{
			return CurrentValue.GetHashCode();
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x3F3EEB8", Offset = "0x3F3EEB8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B78EBD2]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_002E;\n\tv24 = *([B78EBD3]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_0039;\nL_0014:\n\tv50 = obj == 0;\n\tif (v50) goto L_003E;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv89 = System.Convert::ToSingle(obj);\n\tthis.CurrentValue = v89;\n\treturn;\nL_002E:\n\t*([B78EBD2]) = 1;\n\tv59 = *([B78EBD3]) & 1;\n\tv60 = v59 == 0;\n\tv45 = ~v60;\n\tif (v45) goto L_0014;\nL_0039:\n\t*([B78EBD3]) = 1;\n\tv84 = obj == 0;\n\tv63 = ~v84;\n\tif (v63) goto L_001C;\nL_003E:\n\tthis.CurrentValue = 0f;\n\treturn;\n")]
		public override void SetCurrentValue(object obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD2]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD3]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD3]");
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
			float num = Convert.ToSingle(obj);
			CurrentValue = num;
			return;
			IL_010a:
			CurrentValue = 0f;
			return;
			IL_0066:
			if (obj != null)
			{
				goto IL_0084;
			}
			goto IL_010a;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x3F3EF74", Offset = "0x3F3EF74", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tgoto L_0021;\nL_0021:\n\treturnVal2 = System.Convert::ToSingle(obj);\n\treturn returnVal2;\nL_0029:\n\treturn 0;\nL_0012:\n\tv38 = obj == 0;\n\tif (v38) goto L_0029;\n")]
		private float Cast(object obj)
		{
			if (obj != null)
			{
				return Convert.ToSingle(obj);
			}
			return 0f;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x3F3EFF8", Offset = "0x3F3EFF8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78E000;\n\tv18 = *([B78EBD4]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0031;\n\tv21 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Single>::GetRemoteDataInner(this);\n\tv46 = *([B78EBD3]) & 1;\n\tv47 = v46 == 0;\n\tv84 = v21;\n\tv70 = v21;\n\tif (v47) goto L_003F;\nL_0017:\n\tv63 = v84 == 0;\n\tif (v63) goto L_004B;\nL_001E:\n\tgoto L_0028;\nL_0028:\n\treturnVal2 = System.Convert::ToSingle(v84);\n\treturn returnVal2;\nL_0031:\n\t*([v14 @ X19_v1+BD4]) = 1;\n\tv51 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Single>::GetRemoteDataInner(this);\n\tv74 = *([B78EBD3]) & 1;\n\tv75 = v74 == 0;\n\tv56 = ~v75;\n\tv84 = v51;\n\tv70 = v51;\n\tif (v56) goto L_0017;\nL_003F:\n\t*([B78EBD3]) = 1;\n\tv104 = v70 == 0;\n\tv80 = ~v104;\n\tv84 = v70;\n\tif (v80) goto L_001E;\nL_004B:\n\treturn 0;\n")]
		public float GetRemoteData()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD4]");
			object obj2;
			object obj3;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				object remoteDataInner = GetRemoteDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD3]");
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
				object remoteDataInner2 = GetRemoteDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD3]");
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
			return Convert.ToSingle(obj2);
			IL_014e:
			return 0f;
			IL_0089:
			if (obj2 != null)
			{
				goto IL_00a7;
			}
			goto IL_014e;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x3F3F0E4", Offset = "0x3F3F0E4", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78E000;\n\tv18 = *([B78EBD5]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0031;\n\tv21 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Single>::GetLocalDataInner(this);\n\tv46 = *([B78EBD3]) & 1;\n\tv47 = v46 == 0;\n\tv84 = v21;\n\tv70 = v21;\n\tif (v47) goto L_003F;\nL_0017:\n\tv63 = v84 == 0;\n\tif (v63) goto L_004B;\nL_001E:\n\tgoto L_0028;\nL_0028:\n\treturnVal2 = System.Convert::ToSingle(v84);\n\treturn returnVal2;\nL_0031:\n\t*([v14 @ X19_v1+BD5]) = 1;\n\tv51 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Single>::GetLocalDataInner(this);\n\tv74 = *([B78EBD3]) & 1;\n\tv75 = v74 == 0;\n\tv56 = ~v75;\n\tv84 = v51;\n\tv70 = v51;\n\tif (v56) goto L_0017;\nL_003F:\n\t*([B78EBD3]) = 1;\n\tv104 = v70 == 0;\n\tv80 = ~v104;\n\tv84 = v70;\n\tif (v80) goto L_001E;\nL_004B:\n\treturn 0;\n")]
		public float GetLocalData()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD5]");
			object obj2;
			object obj3;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				object localDataInner = GetLocalDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD3]");
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
				object localDataInner2 = GetLocalDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD3]");
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
			return Convert.ToSingle(obj2);
			IL_014e:
			return 0f;
			IL_0089:
			if (obj2 != null)
			{
				goto IL_00a7;
			}
			goto IL_014e;
		}
	}
}
