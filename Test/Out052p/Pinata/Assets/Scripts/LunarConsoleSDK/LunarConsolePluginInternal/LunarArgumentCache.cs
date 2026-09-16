using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Serializable]
	[Token(Token = "0x2000022")]
	internal class LunarArgumentCache : ISerializationCallbackReceiver
	{
		[SerializeField]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x10")]
		private UnityEngine.Object m_objectArgument;

		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x18")]
		private string m_objectArgumentAssemblyTypeName;

		[SerializeField]
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x20")]
		private int m_intArgument;

		[SerializeField]
		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x24")]
		private float m_floatArgument;

		[SerializeField]
		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x28")]
		private string m_stringArgument;

		[SerializeField]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x30")]
		private bool m_boolArgument;

		[Token(Token = "0x17000021")]
		public UnityEngine.Object unityObjectArgument
		{
			[Token(Token = "0x60000C3")]
			[Address(RVA = "0x13E063C", Offset = "0x13E063C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_objectArgument;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return unityObjectArgument;
			}
			[Token(Token = "0x60000C4")]
			[Address(RVA = "0x13E0644", Offset = "0x13E0644", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECB738]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AC8]) = v41;\nL_0015:\n\tthis.m_objectArgument = value;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv58 = UnityEngine.Object::op_Inequality(value, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0039;\n\tv69 = System.Object::GetType(value);\n\tv76 = System.Type::get_AssemblyQualifiedName(v69);\n\tgoto L_003A;\nL_0039:\n\tv76 = v65.Empty;\nL_003A:\n\tthis.m_objectArgumentAssemblyTypeName = v76;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_objectArgument = value;
				string objectArgumentAssemblyTypeName;
				if (value != null)
				{
					Type type = value.GetType();
					objectArgumentAssemblyTypeName = type.AssemblyQualifiedName;
				}
				else
				{
					objectArgumentAssemblyTypeName = string.Empty;
				}
				m_objectArgumentAssemblyTypeName = objectArgumentAssemblyTypeName;
			}
		}

		[Token(Token = "0x17000022")]
		public string unityObjectArgumentAssemblyTypeName
		{
			[Token(Token = "0x60000C5")]
			[Address(RVA = "0x13E0710", Offset = "0x13E0710", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_objectArgumentAssemblyTypeName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return unityObjectArgumentAssemblyTypeName;
			}
		}

		[Token(Token = "0x17000023")]
		public int intArgument
		{
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0x13E0718", Offset = "0x13E0718", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_intArgument;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return intArgument;
			}
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0x13E0720", Offset = "0x13E0720", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_intArgument = value;\n\treturn;\n")]
			set
			{
				intArgument = value;
			}
		}

		[Token(Token = "0x17000024")]
		public float floatArgument
		{
			[Token(Token = "0x60000C8")]
			[Address(RVA = "0x13E0728", Offset = "0x13E0728", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_floatArgument;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return floatArgument;
			}
			[Token(Token = "0x60000C9")]
			[Address(RVA = "0x13E0730", Offset = "0x13E0730", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_floatArgument = value;\n\treturn;\n")]
			set
			{
				floatArgument = value;
			}
		}

		[Token(Token = "0x17000025")]
		public string stringArgument
		{
			[Token(Token = "0x60000CA")]
			[Address(RVA = "0x13E0738", Offset = "0x13E0738", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_stringArgument;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return stringArgument;
			}
			[Token(Token = "0x60000CB")]
			[Address(RVA = "0x13E0740", Offset = "0x13E0740", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_stringArgument = value;\n\treturn;\n")]
			set
			{
				stringArgument = value;
			}
		}

		[Token(Token = "0x17000026")]
		public bool boolArgument
		{
			[Token(Token = "0x60000CC")]
			[Address(RVA = "0x13E0748", Offset = "0x13E0748", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_boolArgument;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return boolArgument;
			}
			[Token(Token = "0x60000CD")]
			[Address(RVA = "0x13E0750", Offset = "0x13E0750", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_boolArgument = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_boolArgument = value;
			}
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x13E075C", Offset = "0x13E075C", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EFA350]);\n\tv21 = *([v20 @ X8_v32]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028AC9]) = v40;\nL_0016:\n\tv43 = System.String::IsNullOrEmpty(this.m_objectArgumentAssemblyTypeName);\n\tv45 = v43 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0096;\n\tv102 = System.String::IndexOf(this.m_objectArgumentAssemblyTypeName, \", Version=\");\n\tv161 = v102 + 1;\n\tv116 = v161 == 0;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_0039;\n\tv169 = *([v164 @ X0_v28+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0039;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v164, v101, v100, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tv179 = System.Math::Min(v102, 0x7FFFFFFF);\n\tgoto L_0044;\nL_0044:\n\tv187 = System.String::IndexOf(this.m_objectArgumentAssemblyTypeName, \", Culture=\");\n\tv188 = v187 + 1;\n\tv117 = v188 == 0;\n\tif (v117) goto L_0064;\n\tgoto L_005B;\n\tv203 = *([v191 @ X0_v23+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tif (v205) goto L_005B;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v191, v186, v185, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005B:\n\tv198 = System.Math::Min(v187, v92);\nL_0064:\n\tv213 = System.String::IndexOf(this.m_objectArgumentAssemblyTypeName, \", PublicKeyToken=\");\n\tv214 = v213 + 1;\n\tv216 = v214 == 0;\n\tif (v216) goto L_0082;\n\tgoto L_007B;\n\tv233 = *([v221 @ X0_v18+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_007B;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v221, v212, v211, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007B:\n\tv227 = System.Math::Min(v213, v92);\nL_0082:\n\tv72 = v92 == 0x7FFFFFFF;\n\tif (v72) goto L_0096;\n\tv84 = System.String::Substring(this.m_objectArgumentAssemblyTypeName, 0, v92);\n\tthis.m_objectArgumentAssemblyTypeName = v84;\nL_0096:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TidyAssemblyTypeName()
		{
			if (!string.IsNullOrEmpty(unityObjectArgumentAssemblyTypeName))
			{
				int num = unityObjectArgumentAssemblyTypeName.IndexOf(", Version=");
				int num3;
				if (num + 1 != 0)
				{
					int num2 = Math.Min(num, int.MaxValue);
					num3 = num2;
				}
				else
				{
					num3 = int.MaxValue;
				}
				int num4 = unityObjectArgumentAssemblyTypeName.IndexOf(", Culture=");
				if (num4 + 1 != 0)
				{
					int num5 = Math.Min(num4, num3);
					num3 = num5;
				}
				int num6 = unityObjectArgumentAssemblyTypeName.IndexOf(", PublicKeyToken=");
				if (num6 + 1 != 0)
				{
					int num7 = Math.Min(num6, num3);
					num3 = num7;
				}
				if (num3 != int.MaxValue)
				{
					string objectArgumentAssemblyTypeName = unityObjectArgumentAssemblyTypeName.Substring(0, num3);
					m_objectArgumentAssemblyTypeName = objectArgumentAssemblyTypeName;
				}
			}
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x13E08FC", Offset = "0x13E08FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePluginInternal.LunarArgumentCache::TidyAssemblyTypeName(this);\n\treturn;\n")]
		public void OnBeforeSerialize()
		{
			TidyAssemblyTypeName();
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x13E0900", Offset = "0x13E0900", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePluginInternal.LunarArgumentCache::TidyAssemblyTypeName(this);\n\treturn;\n")]
		public void OnAfterDeserialize()
		{
			TidyAssemblyTypeName();
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x13E0904", Offset = "0x13E0904", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LunarArgumentCache()
		{
		}
	}
}
