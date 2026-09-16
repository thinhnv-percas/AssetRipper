using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x74456C", Offset = "0x74456C")]
	[Token(Token = "0x2000037")]
	public class ObiNativeVector3List : ObiNativeList<Vector3>, ISerializationCallbackReceiver
	{
		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x30")]
		public Vector3[] serializedContents;

		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x38")]
		private unsafe Vector3* m_Ptr;

		[Token(Token = "0x1700004B")]
		public unsafe override Vector3 Item
		{
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0xC2701C", Offset = "0xC2701C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = index * 0xC;\n\tv5 = this.m_Ptr + v3;\n\treturn *([v5 @ X8_v2]);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001e: Expected O, but got I
				int num = index * 12;
				return (Vector3)((byte*)m_Ptr + num);
			}
			[Token(Token = "0x60002AD")]
			[Address(RVA = "0xC27034", Offset = "0xC27034", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = index * 0xC;\n\tv8 = this.m_Ptr + v6;\n\t*([v8 @ X8_v2]) = value;\n\t*([v8 @ X8_v2+4]) = value.y;\n\t*([v8 @ X8_v2+8]) = value.z;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_001e: Expected O, but got I
				int num = index * 12;
				object obj = (object)((byte*)m_Ptr + num);
				obj = value;
				_ = value.y;
				_ = value.z;
			}
		}

		[Token(Token = "0x60002A8")]
		[Address(RVA = "0xC26D74", Offset = "0xC26D74", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EAE938]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, capacity, alignment, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202312E]) = v44;\nL_001D:\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::.ctor(this, capacity, alignment);\n\tv61 = capacity < 1;\n\tif (v61) goto L_0054;\nL_0031:\n\tgoto L_0038;\n\tv134 = *([v130 @ X0_v5+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tgoto L_0038;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v130, v113, v111, v50, v30, v31, v32, v33, v116, v115, v114, v37, v38, v39, v40, v41);\nL_0038:\n\tVector3_arg = UnityEngine.Vector3::get_zero();\n\tv97 = Obi.ObiNativeVector3List::set_Item(this, v128, Vector3_arg);\n\tv128 = v128 + 1;\n\tv79 = capacity != v128;\n\tif (v79) goto L_0031;\nL_0054:\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNativeVector3List(int capacity = 8, int alignment = 16)
			: base(capacity, alignment)
		{
			if (capacity >= 1)
			{
				int num = 0;
				do
				{
					this.set_Item(num, Vector3.zero);
					num++;
				}
				while (capacity != num);
			}
		}

		[Token(Token = "0x60002A9")]
		[Address(RVA = "0xC26E34", Offset = "0xC26E34", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB03D8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202312F]) = v42;\nL_0018:\n\tv46 = System.IntPtr::op_Inequality(this.m_AlignedPtr, 0);\n\tv48 = v46 == 0;\n\tif (v48) goto L_006C;\n\t// 32 NewArr v53 @ X0_v6 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), this.m_Count (System.Int32)\n\tthis.serializedContents = v53;\n\tv70 = this.m_Count < 1;\n\tif (v70) goto L_006C;\n\tv177 = Obi.ObiNativeVector3List::get_Item(this, 0);\nL_003B:\n\tv169 = v59 - 1;\n\tv200 = v169 < v128.Length;\n\tv160 = ~v200;\n\tif (v160) goto L_006D;\n\tv120 = v169 * 0xC;\n\tv202 = v128 + v120;\n\t*([v202 @ X8_v12+20]) = v32;\n\tv128[v169 @ X8_v10 (System.Int32)].y = v33;\n\tv128[v169 @ X8_v10 (System.Int32)].z = v34;\n\tv71 = v59 >= this.m_Count;\n\tif (v71) goto L_006C;\n\tv128 = this.serializedContents;\n\tv185 = Obi.ObiNativeVector3List::get_Item(this, v59);\n\tv59 = v59 + 1;\n\tv206 = this.serializedContents == 0;\n\tv186 = ~v206;\n\tif (v186) goto L_003B;\n\tthrow System.NullReferenceException;\nL_006C:\n\treturn;\nL_006D:\n\tv204 = new System.IndexOutOfRangeException();\n\tthrow v204;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeforeSerialize()
		{
			//IL_0083: Expected O, but got I
			//IL_009e: Expected F4, but got O
			//IL_00b4: Expected F4, but got O
			if (!(m_AlignedPtr != (IntPtr)0))
			{
				return;
			}
			Vector3[] array = (serializedContents = new Vector3[count]);
			if (count < 1)
			{
				return;
			}
			Vector3 vector = this.get_Item(0);
			int num = 1;
			Vector3[] array2 = array;
			object obj2 = default(object);
			object obj3 = default(object);
			while (true)
			{
				int num2 = num - 1;
				if (num2 >= array2.Length)
				{
					break;
				}
				int num3 = num2 * 12;
				object obj = (long)(IntPtr)array2 + (long)num3;
				array2[num2].y = (float)obj2;
				array2[num2].z = (float)obj3;
				if (num < count)
				{
					array2 = serializedContents;
					Vector3 vector2 = this.get_Item(num);
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

		[Token(Token = "0x60002AA")]
		[Address(RVA = "0xC26F3C", Offset = "0xC26F3C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB6FE8]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023130]) = v40;\nL_0014:\n\tv41 = this.serializedContents;\n\tv42 = this.serializedContents == 0;\n\tif (v42) goto L_0051;\n\tObi.ObiNativeList`1<UnityEngine.Vector3>::ResizeUninitialized(this, v41.Length);\n\tv118 = this.serializedContents;\nL_002C:\n\tv50 = v121 >= v118.Length;\n\tif (v50) goto L_0051;\n\tv189 = v121 < v118.Length;\n\tv151 = ~v189;\n\tif (v151) goto L_0052;\n\tv190 = v121 * 0xC;\n\tv191 = v118 + v190;\n\tv173 = Obi.ObiNativeVector3List::set_Item(this, v121, Vector3_arg);\n\tv118 = this.serializedContents;\n\tv121 = v121 + 1;\n\tv194 = this.serializedContents == 0;\n\tv174 = ~v194;\n\tif (v174) goto L_002C;\n\tthrow System.NullReferenceException;\nL_0051:\n\treturn;\nL_0052:\n\tv195 = new System.IndexOutOfRangeException();\n\tthrow v195;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			//IL_0073: Expected O, but got I
			//IL_0088: Expected F4, but got I
			Vector3[] array = serializedContents;
			if (serializedContents == null)
			{
				return;
			}
			ResizeUninitialized(array.Length);
			Vector3[] array2 = serializedContents;
			int num = 0;
			Vector3 value = default(Vector3);
			while (true)
			{
				if (num < array2.Length)
				{
					if (num >= array2.Length)
					{
						break;
					}
					int num2 = num * 12;
					object obj = (long)(IntPtr)array2 + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v10+20]");
					value.x = 0f;
					value.y = array2[num].y;
					value.z = array2[num].z;
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

		[Token(Token = "0x60002AB")]
		[Address(RVA = "0xC27010", Offset = "0xC27010", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Ptr = this.m_AlignedPtr;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void CapacityChanged()
		{
			m_Ptr = (Vector3*)m_AlignedPtr;
		}
	}
}
