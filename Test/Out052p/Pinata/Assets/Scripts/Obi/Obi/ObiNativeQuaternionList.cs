using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x7444FC", Offset = "0x7444FC")]
	[Token(Token = "0x2000035")]
	public class ObiNativeQuaternionList : ObiNativeList<Quaternion>, ISerializationCallbackReceiver
	{
		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x30")]
		public Quaternion[] serializedContents;

		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x38")]
		private unsafe Quaternion* m_Ptr;

		[Token(Token = "0x17000049")]
		public unsafe override Quaternion Item
		{
			[Token(Token = "0x60002A0")]
			[Address(RVA = "0xE48180", Offset = "0xE48180", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = index << 4;\n\tv4 = this.m_Ptr + v2;\n\treturn *([v4 @ X8_v2]);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001e: Expected O, but got I
				int num = index << 4;
				return (Quaternion)((byte*)m_Ptr + num);
			}
			[Token(Token = "0x60002A1")]
			[Address(RVA = "0xE48194", Offset = "0xE48194", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = index << 4;\n\tv8 = this.m_Ptr + v6;\n\t*([v8 @ X8_v2]) = value;\n\t*([v8 @ X8_v2+4]) = value.y;\n\t*([v8 @ X8_v2+8]) = value.z;\n\t*([v8 @ X8_v2+C]) = value.w;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_001e: Expected O, but got I
				int num = index << 4;
				object obj = (object)((byte*)m_Ptr + num);
				obj = value;
				_ = value.y;
				_ = value.z;
				_ = value.w;
			}
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0xE3E798", Offset = "0xE3E798", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB9A38]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, capacity, alignment, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024770]) = v44;\nL_001D:\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::.ctor(this, capacity, alignment);\n\tv61 = capacity < 1;\n\tif (v61) goto L_0055;\nL_0031:\n\tgoto L_0038;\n\tv137 = *([v133 @ X0_v5+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tgoto L_0038;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v115, v113, v50, v30, v31, v32, v33, v119, v118, v117, v116, v38, v39, v40, v41);\nL_0038:\n\tQuaternion_arg = UnityEngine.Quaternion::get_identity();\n\tv99 = Obi.ObiNativeQuaternionList::set_Item(this, v131, Quaternion_arg);\n\tv131 = v131 + 1;\n\tv81 = capacity != v131;\n\tif (v81) goto L_0031;\nL_0055:\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNativeQuaternionList(int capacity = 8, int alignment = 16)
			: base(capacity, alignment)
		{
			if (capacity >= 1)
			{
				int num = 0;
				do
				{
					this.set_Item(num, Quaternion.identity);
					num++;
				}
				while (capacity != num);
			}
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0xE47EE0", Offset = "0xE47EE0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv42 = *([1EB1AA8]);\n\tv43 = *([v42 @ X8_v9]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, capacity, alignment, methodInfo, v46, v47, v48, v49, defaultValue, v0, v2, v3, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2024771]) = v56;\nL_0028:\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::.ctor(this, capacity, alignment);\n\tv73 = capacity < 1;\n\tif (v73) goto L_0057;\nL_003F:\n\tv103 = Obi.ObiNativeQuaternionList::set_Item(this, v147, Quaternion_arg);\n\tv147 = v147 + 1;\n\tv85 = capacity != v147;\n\tif (v85) goto L_003F;\nL_0057:\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNativeQuaternionList(int capacity, int alignment, Quaternion defaultValue)
			: base(capacity, alignment)
		{
			if (capacity >= 1)
			{
				int num = 0;
				int num2 = default(int);
				num = num2;
				Quaternion value = default(Quaternion);
				do
				{
					this.set_Item(num, value);
					num++;
				}
				while (capacity != num);
			}
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0xE47FA8", Offset = "0xE47FA8", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EBCAF8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024772]) = v40;\nL_0017:\n\tv44 = System.IntPtr::op_Inequality(this.m_AlignedPtr, 0);\n\tv46 = v44 == 0;\n\tif (v46) goto L_006A;\n\t// 31 NewArr v51 @ X0_v6 (UnityEngine.Quaternion[]), typeof(UnityEngine.Quaternion[]), this.m_Count (System.Int32)\n\tthis.serializedContents = v51;\n\tv69 = this.m_Count < 1;\n\tif (v69) goto L_006A;\n\tv175 = Obi.ObiNativeQuaternionList::get_Item(this, 0);\nL_0039:\n\tv167 = v58 - 1;\n\tv198 = v167 < v127.Length;\n\tv159 = ~v198;\n\tif (v159) goto L_006B;\n\tv55 = v167 << 4;\n\tv200 = v127 + v55;\n\t*([v200 @ X8_v12+20]) = v30;\n\tv127[v167 @ X8_v10 (System.Int32)].y = v31;\n\tv127[v167 @ X8_v10 (System.Int32)].z = v32;\n\tv127[v167 @ X8_v10 (System.Int32)].w = v33;\n\tv70 = v58 >= this.m_Count;\n\tif (v70) goto L_006A;\n\tv127 = this.serializedContents;\n\tv183 = Obi.ObiNativeQuaternionList::get_Item(this, v58);\n\tv58 = v58 + 1;\n\tv204 = this.serializedContents == 0;\n\tv184 = ~v204;\n\tif (v184) goto L_0039;\n\tthrow System.NullReferenceException;\nL_006A:\n\treturn;\nL_006B:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeforeSerialize()
		{
			//IL_0083: Expected O, but got I
			if (!(m_AlignedPtr != (IntPtr)0))
			{
				return;
			}
			Quaternion[] array = (serializedContents = new Quaternion[count]);
			if (count < 1)
			{
				return;
			}
			Quaternion quaternion = this.get_Item(0);
			int num = 1;
			Quaternion[] array2 = array;
			float y = default(float);
			float z = default(float);
			float w = default(float);
			while (true)
			{
				int num2 = num - 1;
				if (num2 >= array2.Length)
				{
					break;
				}
				int num3 = num2 << 4;
				object obj = (long)(IntPtr)array2 + (long)num3;
				array2[num2].y = y;
				array2[num2].z = z;
				array2[num2].w = w;
				if (num < count)
				{
					array2 = serializedContents;
					Quaternion quaternion2 = this.get_Item(num);
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

		[Token(Token = "0x600029E")]
		[Address(RVA = "0xE480AC", Offset = "0xE480AC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB2BD8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024773]) = v38;\nL_0013:\n\tv39 = this.serializedContents;\n\tv40 = this.serializedContents == 0;\n\tif (v40) goto L_004F;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeUninitialized(this, v39.Length);\n\tv120 = this.serializedContents;\nL_002A:\n\tv48 = v123 >= v120.Length;\n\tif (v48) goto L_004F;\n\tv193 = v123 < v120.Length;\n\tv154 = ~v193;\n\tif (v154) goto L_0050;\n\tv171 = v123 << 4;\n\tv194 = v120 + v171;\n\tv177 = Obi.ObiNativeQuaternionList::set_Item(this, v123, Quaternion_arg);\n\tv120 = this.serializedContents;\n\tv123 = v123 + 1;\n\tv197 = this.serializedContents == 0;\n\tv178 = ~v197;\n\tif (v178) goto L_002A;\n\tthrow System.NullReferenceException;\nL_004F:\n\treturn;\nL_0050:\n\tv198 = new System.IndexOutOfRangeException();\n\tthrow v198;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			//IL_0073: Expected O, but got I
			//IL_0088: Expected F4, but got I
			Quaternion[] array = serializedContents;
			if (serializedContents == null)
			{
				return;
			}
			ResizeUninitialized(array.Length);
			Quaternion[] array2 = serializedContents;
			int num = 0;
			Quaternion value = default(Quaternion);
			while (true)
			{
				if (num < array2.Length)
				{
					if (num >= array2.Length)
					{
						break;
					}
					int num2 = num << 4;
					object obj = (long)(IntPtr)array2 + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ X8_v10+20]");
					value.x = 0f;
					value.y = array2[num].y;
					value.z = array2[num].z;
					value.w = array2[num].w;
					this.set_Item(num, value);
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

		[Token(Token = "0x600029F")]
		[Address(RVA = "0xE48174", Offset = "0xE48174", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Ptr = this.m_AlignedPtr;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void CapacityChanged()
		{
			m_Ptr = (Quaternion*)m_AlignedPtr;
		}
	}
}
