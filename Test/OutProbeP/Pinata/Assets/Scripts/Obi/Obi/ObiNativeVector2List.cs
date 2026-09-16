using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x744534", Offset = "0x744534")]
	[Token(Token = "0x2000036")]
	public class ObiNativeVector2List : ObiNativeList<Vector2>, ISerializationCallbackReceiver
	{
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x30")]
		public Vector2[] serializedContents;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x38")]
		private unsafe Vector2* m_Ptr;

		[Token(Token = "0x1700004A")]
		public unsafe override Vector2 Item
		{
			[Token(Token = "0x60002A6")]
			[Address(RVA = "0xE48378", Offset = "0xE48378", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = index << 3;\n\tv4 = this.m_Ptr + v2;\n\treturn *([v4 @ X8_v2]);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001e: Expected O, but got I
				int num = index << 3;
				return (Vector2)((byte*)m_Ptr + num);
			}
			[Token(Token = "0x60002A7")]
			[Address(RVA = "0xE48388", Offset = "0xE48388", Length = "0x1010")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = index << 3;\n\tv6 = this.m_Ptr + v4;\n\t*([v6 @ X8_v2]) = value;\n\t*([v6 @ X8_v2+4]) = value.y;\n\treturn;\n\tHutongGames.PlayMaker.FsmVarOverride::.ctor(X0, X1, X2);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xE3D008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX8 = *([X8+410]);\n\tX0 = 0xE41004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1021 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_001e: Expected O, but got I
				int num = index << 3;
				object obj = (object)((byte*)m_Ptr + num);
				obj = value;
				_ = value.y;
			}
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xE3DE24", Offset = "0xE3DE24", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EEA388]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, capacity, alignment, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024774]) = v44;\nL_001D:\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::.ctor(this, capacity, alignment);\n\tv61 = capacity < 1;\n\tif (v61) goto L_0053;\nL_0031:\n\tgoto L_0038;\n\tv131 = *([v127 @ X0_v5+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tgoto L_0038;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v111, v109, v50, v30, v31, v32, v33, v113, v112, v36, v37, v38, v39, v40, v41);\nL_0038:\n\tVector2_arg = UnityEngine.Vector2::get_zero();\n\tv95 = Obi.ObiNativeVector2List::set_Item(this, v125, Vector2_arg);\n\tv125 = v125 + 1;\n\tv77 = capacity != v125;\n\tif (v77) goto L_0031;\nL_0053:\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNativeVector2List(int capacity = 8, int alignment = 16)
			: base(capacity, alignment)
		{
			if (capacity >= 1)
			{
				int num = 0;
				do
				{
					this.set_Item(num, Vector2.zero);
					num++;
				}
				while (capacity != num);
			}
		}

		[Token(Token = "0x60002A3")]
		[Address(RVA = "0xE481A8", Offset = "0xE481A8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EE3038]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024775]) = v40;\nL_0017:\n\tv44 = System.IntPtr::op_Inequality(this.m_AlignedPtr, 0);\n\tv46 = v44 == 0;\n\tif (v46) goto L_0068;\n\t// 31 NewArr v51 @ X0_v6 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), this.m_Count (System.Int32)\n\tthis.serializedContents = v51;\n\tv69 = this.m_Count < 1;\n\tif (v69) goto L_0068;\n\tv175 = Obi.ObiNativeVector2List::get_Item(this, 0);\nL_0039:\n\tv167 = v58 - 1;\n\tv198 = v167 < v127.Length;\n\tv159 = ~v198;\n\tif (v159) goto L_0069;\n\tv55 = v167 << 3;\n\tv200 = v127 + v55;\n\t*([v200 @ X8_v12+20]) = v30;\n\tv127[v167 @ X8_v10 (System.Int32)].y = v31;\n\tv70 = v58 >= this.m_Count;\n\tif (v70) goto L_0068;\n\tv127 = this.serializedContents;\n\tv183 = Obi.ObiNativeVector2List::get_Item(this, v58);\n\tv58 = v58 + 1;\n\tv204 = this.serializedContents == 0;\n\tv184 = ~v204;\n\tif (v184) goto L_0039;\n\tthrow System.NullReferenceException;\nL_0068:\n\treturn;\nL_0069:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeforeSerialize()
		{
			//IL_0083: Expected O, but got I
			if (!(m_AlignedPtr != (IntPtr)0))
			{
				return;
			}
			Vector2[] array = (serializedContents = new Vector2[count]);
			if (count < 1)
			{
				return;
			}
			Vector2 vector = this.get_Item(0);
			int num = 1;
			Vector2[] array2 = array;
			float y = default(float);
			while (true)
			{
				int num2 = num - 1;
				if (num2 >= array2.Length)
				{
					break;
				}
				int num3 = num2 << 3;
				object obj = (long)(IntPtr)array2 + (long)num3;
				array2[num2].y = y;
				if (num < count)
				{
					array2 = serializedContents;
					Vector2 vector2 = this.get_Item(num);
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

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0xE482A8", Offset = "0xE482A8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F09588]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024776]) = v38;\nL_0013:\n\tv39 = this.serializedContents;\n\tv40 = this.serializedContents == 0;\n\tif (v40) goto L_004D;\n\tObi.ObiNativeList`1<UnityEngine.Vector2>::ResizeUninitialized(this, v39.Length);\n\tv114 = this.serializedContents;\nL_002A:\n\tv48 = v117 >= v114.Length;\n\tif (v48) goto L_004D;\n\tv183 = v117 < v114.Length;\n\tv146 = ~v183;\n\tif (v146) goto L_004E;\n\tv161 = v117 << 3;\n\tv184 = v114 + v161;\n\tv167 = Obi.ObiNativeVector2List::set_Item(this, v117, Vector2_arg);\n\tv114 = this.serializedContents;\n\tv117 = v117 + 1;\n\tv187 = this.serializedContents == 0;\n\tv168 = ~v187;\n\tif (v168) goto L_002A;\n\tthrow System.NullReferenceException;\nL_004D:\n\treturn;\nL_004E:\n\tv188 = new System.IndexOutOfRangeException();\n\tthrow v188;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			//IL_0073: Expected O, but got I
			//IL_0088: Expected F4, but got I
			Vector2[] array = serializedContents;
			if (serializedContents == null)
			{
				return;
			}
			ResizeUninitialized(array.Length);
			Vector2[] array2 = serializedContents;
			int num = 0;
			Vector2 value = default(Vector2);
			while (true)
			{
				if (num < array2.Length)
				{
					if (num >= array2.Length)
					{
						break;
					}
					int num2 = num << 3;
					object obj = (long)(IntPtr)array2 + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v10+20]");
					value.x = 0f;
					value.y = array2[num].y;
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

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0xE4836C", Offset = "0xE4836C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Ptr = this.m_AlignedPtr;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void CapacityChanged()
		{
			m_Ptr = (Vector2*)m_AlignedPtr;
		}
	}
}
