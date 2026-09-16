using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x744454", Offset = "0x744454")]
	[Token(Token = "0x2000032")]
	public class ObiNativeIntList : ObiNativeList<int>, ISerializationCallbackReceiver
	{
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x30")]
		public int[] serializedContents;

		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x38")]
		private unsafe int* m_Ptr;

		[Token(Token = "0x17000044")]
		public unsafe override int Item
		{
			[Token(Token = "0x600027F")]
			[Address(RVA = "0xE47E08", Offset = "0xE47E08", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_Ptr;\n\treturn *([v0 @ X8_v1 (System.Int32*)+index @ X1 (System.Int32)*4]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int* ptr = m_Ptr;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (System.Int32*)+index @ X1 (System.Int32)*4]");
				return 0;
			}
			[Token(Token = "0x6000280")]
			[Address(RVA = "0xE47E14", Offset = "0xE47E14", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_Ptr;\n\t*([v0 @ X8_v1 (System.Int32*)+index @ X1 (System.Int32)*4]) = value;\n\treturn;\n")]
			set
			{
				int* ptr = m_Ptr;
			}
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0xE3FFB8", Offset = "0xE3FFB8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF55C0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, capacity, alignment, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202476C]) = v44;\nL_001D:\n\tObi.ObiNativeList`1<System.Int32>::.ctor(this, capacity, alignment);\n\tv61 = capacity < 1;\n\tif (v61) goto L_0045;\nL_0031:\n\tv91 = Obi.ObiNativeIntList::set_Item(this, v125, 0);\n\tv125 = v125 + 1;\n\tv73 = capacity != v125;\n\tif (v73) goto L_0031;\nL_0045:\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNativeIntList(int capacity = 8, int alignment = 16)
			: base(capacity, alignment)
		{
			if (capacity >= 1)
			{
				int num = 0;
				int num2 = default(int);
				num = num2;
				do
				{
					this.set_Item(num, 0);
					num++;
				}
				while (capacity != num);
			}
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0xE47C44", Offset = "0xE47C44", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EB62E0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202476D]) = v40;\nL_0017:\n\tv44 = System.IntPtr::op_Inequality(this.m_AlignedPtr, 0);\n\tv46 = v44 == 0;\n\tif (v46) goto L_0066;\n\t// 31 NewArr v51 @ X0_v6 (System.Int32[]), typeof(System.Int32[]), this.m_Count (System.Int32)\n\tthis.serializedContents = v51;\n\tv69 = this.m_Count < 1;\n\tif (v69) goto L_0066;\n\tv116 = Obi.ObiNativeIntList::get_Item(this, 0);\nL_0039:\n\tv167 = v58 - 1;\n\tv198 = v167 < v127.Length;\n\tv159 = ~v198;\n\tif (v159) goto L_0067;\n\tv127[v167 @ X8_v10 (System.Int32)] = v116;\n\tv70 = v58 >= this.m_Count;\n\tif (v70) goto L_0066;\n\tv127 = this.serializedContents;\n\tv116 = Obi.ObiNativeIntList::get_Item(this, v58);\n\tv58 = v58 + 1;\n\tv203 = this.serializedContents == 0;\n\tv184 = ~v203;\n\tif (v184) goto L_0039;\n\tthrow System.NullReferenceException;\nL_0066:\n\treturn;\nL_0067:\n\tv201 = new System.IndexOutOfRangeException();\n\tthrow v201;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeforeSerialize()
		{
			if (!(m_AlignedPtr != (IntPtr)0))
			{
				return;
			}
			int[] array = (serializedContents = new int[count]);
			if (count < 1)
			{
				return;
			}
			int num = this.get_Item(0);
			int num2 = 1;
			int[] array2 = array;
			while (true)
			{
				int num3 = num2 - 1;
				if (num3 >= array2.Length)
				{
					break;
				}
				array2[num3] = num;
				if (num2 < count)
				{
					array2 = serializedContents;
					num = this.get_Item(num2);
					num2++;
					if (serializedContents == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0xE47D40", Offset = "0xE47D40", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE2888]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202476E]) = v38;\nL_0013:\n\tv39 = this.serializedContents;\n\tv40 = this.serializedContents == 0;\n\tif (v40) goto L_0042;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(this, v39.Length);\n\tv107 = this.serializedContents;\nL_0021:\n\tv163 = v110 < v107.Length;\n\tv80 = ~v163;\n\tv48 = v110 >= v107.Length;\n\tif (v48) goto L_0042;\n\tif (v80) goto L_0043;\n\tv148 = Obi.ObiNativeIntList::set_Item(this, v110, v107[v110 @ X20_v6 (System.Int32)]);\n\tv107 = this.serializedContents;\n\tv110 = v110 + 1;\n\tv167 = this.serializedContents == 0;\n\tv149 = ~v167;\n\tif (v149) goto L_0021;\n\tthrow System.NullReferenceException;\nL_0042:\n\treturn;\nL_0043:\n\tv168 = new System.IndexOutOfRangeException();\n\tthrow v168;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			int[] array = serializedContents;
			if (serializedContents == null)
			{
				return;
			}
			ResizeUninitialized(array.Length);
			int[] array2 = serializedContents;
			int num = 0;
			while (true)
			{
				bool flag = num < array2.Length;
				bool flag2 = !flag;
				if (num < array2.Length)
				{
					if (flag2)
					{
						break;
					}
					this.set_Item(num, array2[num]);
					array2 = serializedContents;
					num++;
					if (serializedContents == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0xE47DFC", Offset = "0xE47DFC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Ptr = this.m_AlignedPtr;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void CapacityChanged()
		{
			m_Ptr = (int*)m_AlignedPtr;
		}
	}
}
