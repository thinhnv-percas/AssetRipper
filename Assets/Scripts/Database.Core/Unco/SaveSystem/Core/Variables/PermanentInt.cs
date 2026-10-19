using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x2000013")]
	public sealed class PermanentInt : PermanentVariable<int>
	{
		[Token(Token = "0x6000071")]
		[Address(RVA = "0x3F3F1D0", Offset = "0x3F3F1D0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\nL_0032:\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<System.Int32>::.ctor(this, v63, v61, v59, v57);\n\treturn;\n")]
		public PermanentInt(string key, int initialValue = 0, object remoteData = null, DateTime? lastSavedRemoteTime = null)
			: base(key, initialValue, remoteData, lastSavedRemoteTime)
		{
			string key2 = default(string);
			int initialValue2 = default(int);
			object remoteData2 = default(object);
			DateTime? commonRemoteDateTime = default(DateTime?);
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x3F3F260", Offset = "0x3F3F260", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn pInt.CurrentValue;\nL_0021:\n\treturn 0;\nL_0012:\n\tv38 = pInt == 0;\n\tif (v38) goto L_0021;\n")]
		public static implicit operator int(PermanentInt pInt)
		{
			return pInt?.CurrentValue ?? 0;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x3F3F2B4", Offset = "0x3F3F2B4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = a.CurrentValue + value;\n\treturn returnVal1;\n")]
		public static int operator +(PermanentInt a, int value)
		{
			return a.CurrentValue + value;
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x3F3F30C", Offset = "0x3F3F30C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = a.CurrentValue - value;\n\treturn returnVal1;\n")]
		public static int operator -(PermanentInt a, int value)
		{
			return a.CurrentValue - value;
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x3F3F364", Offset = "0x3F3F364", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv46 = a.CurrentValue + 1;\n\ta.CurrentValue = v46;\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<System.Int32>::IncreaseCounter(a);\n\treturn a;\n")]
		public static PermanentInt operator ++(PermanentInt a)
		{
			int num = a.CurrentValue + 1;
			a.CurrentValue = num;
			a.IncreaseCounter();
			return a;
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x3F3F3E4", Offset = "0x3F3F3E4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv46 = a.CurrentValue - 1;\n\ta.CurrentValue = v46;\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<System.Int32>::IncreaseCounter(a);\n\treturn a;\n")]
		public static PermanentInt operator --(PermanentInt a)
		{
			int num = a.CurrentValue - 1;
			a.CurrentValue = num;
			a.IncreaseCounter();
			return a;
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x3F3F464", Offset = "0x3F3F464", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\treturnVal1 = value / a.CurrentValue;\n\treturn returnVal1;\nL_0022:\n\treturnVal2 = value / 0;\n\treturn returnVal2;\nL_0015:\n\tv43 = a == 0;\n\tif (v43) goto L_0022;\n")]
		public static int operator /(PermanentInt a, int value)
		{
			if (a != null)
			{
				return value / a.CurrentValue;
			}
			return value / 0;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x3F3F4D0", Offset = "0x3F3F4D0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\treturnVal1 = a.CurrentValue * value;\n\treturn returnVal1;\n")]
		public static int operator *(PermanentInt a, int value)
		{
			return a.CurrentValue * value;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x3F3F528", Offset = "0x3F3F528", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv47 = a.CurrentValue - value;\n\tv49 = v47 == 0;\n\treturn v49;\nL_0032:\n\treturn 0;\nL_0015:\n\tv43 = a == 0;\n\tif (v43) goto L_0032;\n")]
		public static bool operator ==(PermanentInt a, int value)
		{
			if (a != null)
			{
				int num = a.CurrentValue - value;
				return num == 0;
			}
			return false;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x3F3F594", Offset = "0x3F3F594", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv47 = a.CurrentValue - value;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\treturn v54;\nL_0033:\n\treturn 0;\nL_0015:\n\tv43 = a == 0;\n\tif (v43) goto L_0033;\n")]
		public static bool operator !=(PermanentInt a, int value)
		{
			if (a != null)
			{
				int num = a.CurrentValue - value;
				bool flag = num == 0;
				return !flag;
			}
			return false;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x3F3F600", Offset = "0x3F3F600", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv52 = *([obj @ X1 (System.Object)]) == Unco.SaveSystem.Core.Variables.PermanentInt;\n\tif (v52) goto L_0033;\nL_002D:\n\treturn 0;\nL_0033:\n\tgoto L_0039;\n\tv131 = this.CurrentValue;\nL_0015:\n\tv43 = obj == 0;\n\tif (v43) goto L_002D;\nL_0039:\n\tv129 = this == 0;\n\tv131 = this;\n\tif (v129) goto L_0041;\nL_004A:\n\tv105 = *([obj @ X1 (System.Object)+10]) - v131;\n\tv101 = v105 == 0;\n\treturn v101;\nL_0041:\n\tgoto L_004A;\n")]
		public override bool Equals(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentInt::Equals");
			return default;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x3F3F6CC", Offset = "0x3F3F6CC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\treturnVal1 = System.Int32::Equals(&v44 @ stack_-34_v1 (System.Int32), other.CurrentValue);\n\treturn returnVal1;\nL_0016:\n\tv44 = this.CurrentValue;\n")]
		private bool Equals(PermanentInt other)
		{
			return CurrentValue.Equals(other.CurrentValue);
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x3F3F73C", Offset = "0x3F3F73C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv39 = this.CurrentValue;\n\treturnVal1 = System.Int32::GetHashCode(&v39 @ stack_-24_v1 (System.Int32));\n\treturn returnVal1;\n")]
		public override int GetHashCode()
		{
			return CurrentValue.GetHashCode();
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x3F3F794", Offset = "0x3F3F794", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B78EBD9]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_002E;\n\tv24 = *([B78EBDA]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_0039;\nL_0014:\n\tv50 = obj == 0;\n\tif (v50) goto L_003E;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv89 = System.Convert::ToInt32(obj);\n\tthis.CurrentValue = v89;\n\treturn;\nL_002E:\n\t*([B78EBD9]) = 1;\n\tv59 = *([B78EBDA]) & 1;\n\tv60 = v59 == 0;\n\tv45 = ~v60;\n\tif (v45) goto L_0014;\nL_0039:\n\t*([B78EBDA]) = 1;\n\tv84 = obj == 0;\n\tv63 = ~v84;\n\tif (v63) goto L_001C;\nL_003E:\n\tthis.CurrentValue = 0;\n\treturn;\n")]
		public override void SetCurrentValue(object obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBD9]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDA]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDA]");
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
			int num = Convert.ToInt32(obj);
			CurrentValue = num;
			return;
			IL_010a:
			CurrentValue = 0;
			return;
			IL_0066:
			if (obj != null)
			{
				goto IL_0084;
			}
			goto IL_010a;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x3F3F850", Offset = "0x3F3F850", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tgoto L_0021;\nL_0021:\n\treturnVal2 = System.Convert::ToInt32(obj);\n\treturn returnVal2;\nL_0029:\n\treturn 0;\nL_0012:\n\tv38 = obj == 0;\n\tif (v38) goto L_0029;\n")]
		private int Cast(object obj)
		{
			if (obj != null)
			{
				return Convert.ToInt32(obj);
			}
			return 0;
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x3F3F8D4", Offset = "0x3F3F8D4", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78E000;\n\tv18 = *([B78EBDB]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0031;\n\tv21 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Int32>::GetRemoteDataInner(this);\n\tv46 = *([B78EBDA]) & 1;\n\tv47 = v46 == 0;\n\tv84 = v21;\n\tv70 = v21;\n\tif (v47) goto L_003F;\nL_0017:\n\tv63 = v84 == 0;\n\tif (v63) goto L_004B;\nL_001E:\n\tgoto L_0028;\nL_0028:\n\treturnVal2 = System.Convert::ToInt32(v84);\n\treturn returnVal2;\nL_0031:\n\t*([v14 @ X19_v1+BDB]) = 1;\n\tv51 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Int32>::GetRemoteDataInner(this);\n\tv74 = *([B78EBDA]) & 1;\n\tv75 = v74 == 0;\n\tv56 = ~v75;\n\tv84 = v51;\n\tv70 = v51;\n\tif (v56) goto L_0017;\nL_003F:\n\t*([B78EBDA]) = 1;\n\tv104 = v70 == 0;\n\tv80 = ~v104;\n\tv84 = v70;\n\tif (v80) goto L_001E;\nL_004B:\n\treturn 0;\n")]
		public int GetRemoteData()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDB]");
			object obj2;
			object obj3;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				object remoteDataInner = GetRemoteDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDA]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDA]");
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
			return Convert.ToInt32(obj2);
			IL_014e:
			return 0;
			IL_0089:
			if (obj2 != null)
			{
				goto IL_00a7;
			}
			goto IL_014e;
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x3F3F9C0", Offset = "0x3F3F9C0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78E000;\n\tv18 = *([B78EBDC]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0031;\n\tv21 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Int32>::GetLocalDataInner(this);\n\tv46 = *([B78EBDA]) & 1;\n\tv47 = v46 == 0;\n\tv84 = v21;\n\tv70 = v21;\n\tif (v47) goto L_003F;\nL_0017:\n\tv63 = v84 == 0;\n\tif (v63) goto L_004B;\nL_001E:\n\tgoto L_0028;\nL_0028:\n\treturnVal2 = System.Convert::ToInt32(v84);\n\treturn returnVal2;\nL_0031:\n\t*([v14 @ X19_v1+BDC]) = 1;\n\tv51 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Int32>::GetLocalDataInner(this);\n\tv74 = *([B78EBDA]) & 1;\n\tv75 = v74 == 0;\n\tv56 = ~v75;\n\tv84 = v51;\n\tv70 = v51;\n\tif (v56) goto L_0017;\nL_003F:\n\t*([B78EBDA]) = 1;\n\tv104 = v70 == 0;\n\tv80 = ~v104;\n\tv84 = v70;\n\tif (v80) goto L_001E;\nL_004B:\n\treturn 0;\n")]
		public int GetLocalData()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDC]");
			object obj2;
			object obj3;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				object localDataInner = GetLocalDataInner();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDA]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBDA]");
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
			return Convert.ToInt32(obj2);
			IL_014e:
			return 0;
			IL_0089:
			if (obj2 != null)
			{
				goto IL_00a7;
			}
			goto IL_014e;
		}
	}
}
