using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000B8")]
	public class SerializableDictionary<T, U> : SerializableDictionaryBase<T, U, U>
	{
		[Token(Token = "0x60006E8")]
		[Address(RVA = "0xD8F298", Offset = "0xD8F298", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X2_v1, this @ X0 (EasyMobile.Internal.SerializableDictionary`2<T, U>), this @ X0 (EasyMobile.Internal.SerializableDictionary`2<T, U>), methodof(EasyMobile.Internal.SerializableDictionaryBase`3<T, U, U>::.ctor), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableDictionary()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006E9")]
		[Address(RVA = "0xD8F2BC", Offset = "0xD8F2BC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X3_v1, this @ X0 (EasyMobile.Internal.SerializableDictionary`2<T, U>), this @ X0 (EasyMobile.Internal.SerializableDictionary`2<T, U>), dict @ X1 (System.Collections.Generic.IDictionary`2<T, U>), methodof(EasyMobile.Internal.SerializableDictionaryBase`3<T, U, U>::.ctor), v6 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableDictionary(IDictionary<T, U> dict)
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006EA")]
		[Address(RVA = "0xD8F2E0", Offset = "0xD8F2E0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = *([v3 @ X4+18]);\n\tv4 = *([v2 @ X8_v1+C0]);\n\tv5 = *([v4 @ X8_v2+20]);\n\tv6 = *([v5 @ X4_v1]);\n\t// 6 IndirectJump v6 @ X5_v1, this @ X0 (EasyMobile.Internal.SerializableDictionary`2<T, U>), this @ X0 (EasyMobile.Internal.SerializableDictionary`2<T, U>), info @ X1 (System.Runtime.Serialization.SerializationInfo), context @ X2 (System.Runtime.Serialization.StreamingContext), methodInfo @ X3 (Il2CppMethodInfo), v5 @ X4_v1, v6 @ X5_v1, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected SerializableDictionary(SerializationInfo info, StreamingContext context)
		{
			//IL_0010: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_0030: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X4+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X8_v2+20]");
			object obj3 = 0;
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006EB")]
		[Address(RVA = "0xD8F304", Offset = "0xD8F304", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = storage.Length < i;\n\tv11 = ~v9;\n\tv12 = storage.Length - i;\n\tv14 = v12 == 0;\n\tv19 = ~v11;\n\tv20 = v19 | v14;\n\tif (v20) goto L_001C;\n\treturn storage[i @ X2 (System.Int32)];\n\tv22 = new System.NullReferenceException();\nL_001C:\n\tv63 = new System.IndexOutOfRangeException();\n\tthrow v63;\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override U GetValue(U[] storage, int i)
		{
			bool flag = storage.Length < i;
			bool flag2 = !flag;
			int num = storage.Length - i;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				return storage[i];
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60006EC")]
		[Address(RVA = "0xD8F344", Offset = "0xD8F344", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = storage.Length < i;\n\tv11 = ~v9;\n\tv12 = storage.Length - i;\n\tv14 = v12 == 0;\n\tv19 = ~v11;\n\tv20 = v19 | v14;\n\tif (v20) goto L_001C;\n\tstorage[i @ X2 (System.Int32)] = value;\n\treturn;\n\tv22 = new System.NullReferenceException();\nL_001C:\n\tv62 = new System.IndexOutOfRangeException();\n\tthrow v62;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SetValue(U[] storage, int i, U value)
		{
			bool flag = storage.Length < i;
			bool flag2 = !flag;
			int num = storage.Length - i;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				storage[i] = value;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
	[Token(Token = "0x20000B9")]
	public static class SerializableDictionary
	{
		[Token(Token = "0x200019E")]
		public class Storage<T>
		{
			[Token(Token = "0x400066A")]
			[FieldOffset(Offset = "0x0")]
			public T data;

			[Token(Token = "0x6000CAE")]
			[Address(RVA = "0xD8E860", Offset = "0xD8E860", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Storage()
			{
			}
		}
	}
	[Token(Token = "0x20000BA")]
	public class SerializableDictionary<T, U, V> : SerializableDictionaryBase<T, U, V> where V : SerializableDictionary.Storage<U>, new()
	{
		[Token(Token = "0x60006ED")]
		[Address(RVA = "0xD8F384", Offset = "0xD8F384", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X2_v1, this @ X0 (EasyMobile.Internal.SerializableDictionary`3<T, U, V>), this @ X0 (EasyMobile.Internal.SerializableDictionary`3<T, U, V>), methodof(EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>::.ctor), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableDictionary()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006EE")]
		[Address(RVA = "0xD8F3A8", Offset = "0xD8F3A8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X3_v1, this @ X0 (EasyMobile.Internal.SerializableDictionary`3<T, U, V>), this @ X0 (EasyMobile.Internal.SerializableDictionary`3<T, U, V>), dict @ X1 (System.Collections.Generic.IDictionary`2<T, U>), methodof(EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>::.ctor), v6 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableDictionary(IDictionary<T, U> dict)
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006EF")]
		[Address(RVA = "0xD8F3CC", Offset = "0xD8F3CC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = *([v3 @ X4+18]);\n\tv4 = *([v2 @ X8_v1+C0]);\n\tv5 = *([v4 @ X8_v2+20]);\n\tv6 = *([v5 @ X4_v1]);\n\t// 6 IndirectJump v6 @ X5_v1, this @ X0 (EasyMobile.Internal.SerializableDictionary`3<T, U, V>), this @ X0 (EasyMobile.Internal.SerializableDictionary`3<T, U, V>), info @ X1 (System.Runtime.Serialization.SerializationInfo), context @ X2 (System.Runtime.Serialization.StreamingContext), methodInfo @ X3 (Il2CppMethodInfo), v5 @ X4_v1, v6 @ X5_v1, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected SerializableDictionary(SerializationInfo info, StreamingContext context)
		{
			//IL_0010: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_0030: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X4+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X8_v2+20]");
			object obj3 = 0;
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006F0")]
		[Address(RVA = "0xD8F3F0", Offset = "0xD8F3F0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = storage.Length < i;\n\tv11 = ~v9;\n\tv12 = storage.Length - i;\n\tv14 = v12 == 0;\n\tv19 = ~v11;\n\tv20 = v19 | v14;\n\tif (v20) goto L_001F;\n\tv44 = storage[i @ X2 (System.Int32)];\n\treturn *([v44 @ X8_v5 (V)+10]);\n\tv48 = new System.NullReferenceException();\nL_001F:\n\tv77 = new System.IndexOutOfRangeException();\n\tthrow v77;\n\treturn returnVal2;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override U GetValue(V[] storage, int i)
		{
			//IL_0082: Expected O, but got I
			bool flag = storage.Length < i;
			bool flag2 = !flag;
			int num = storage.Length - i;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				V val = storage[i];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (V)+10]");
				return (U)0;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60006F1")]
		[Address(RVA = "0xD8F438", Offset = "0xD8F438", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = System.Activator::CreateInstance();\n\t*([v23 @ X0_v2 (V)+10]) = value;\n\tv39 = storage.Length < i;\n\tv40 = ~v39;\n\tv41 = storage.Length - i;\n\tv43 = v41 == 0;\n\tv48 = ~v40;\n\tv49 = v48 | v43;\n\tif (v49) goto L_002E;\n\tstorage[i @ X2 (System.Int32)] = v23;\n\treturn;\n\tthrow System.NullReferenceException;\n\tv53 = new System.NullReferenceException();\nL_002E:\n\tv82 = new System.IndexOutOfRangeException();\n\tthrow v82;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SetValue(V[] storage, int i, U value)
		{
			V val = new V();
			bool flag = storage.Length < i;
			bool flag2 = !flag;
			int num = storage.Length - i;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				storage[i] = val;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
