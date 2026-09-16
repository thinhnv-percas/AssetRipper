using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;

namespace Facebook.Unity
{
	[Token(Token = "0x200001E")]
	internal class MethodArguments
	{
		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x10")]
		private IDictionary<string, object> arguments;

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0xD1E7A4", Offset = "0xD1E7A4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE3138]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C51]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v42);\n\tFacebook.Unity.MethodArguments::.ctor(this, v42);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MethodArguments()
			: this(new Dictionary<string, object>())
		{
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0xD30854", Offset = "0xD30854", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.MethodArguments::.ctor(this, methodArgs.arguments);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MethodArguments(MethodArguments methodArgs)
			: this(methodArgs.arguments)
		{
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0xD307D0", Offset = "0xD307D0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC2DB8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, arguments, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C52]) = v41;\nL_0018:\n\tv45 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v45);\n\tthis.arguments = v45;\n\tSystem.Object::.ctor(this);\n\tthis.arguments = arguments;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private MethodArguments(IDictionary<string, object> arguments)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			this.arguments = dictionary;
			this.arguments = arguments;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0xBB3710", Offset = "0xBB3710", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = value & 1;\n\tgoto L_0019;\n\tv30 = *([1ED4688]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, argumentName, value, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022C55]) = v47;\nL_0019:\n\tv48 = this.arguments;\n\tgoto L_0026;\n\tv56 = v51;\n\tv57 = 0x8907BC(v56, argumentName, value, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0026:\n\t// 38 Box v61 @ X0_v4, typeof(Il2CppClass<T>), &v24 @ X22_v1 (System.Int32)\n\tv65 = *([v48 @ X20_v2 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv69 = *([v65 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v69) goto L_004E;\n\tv123 = *([v65 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_0039:\n\tv129 = *([v123 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v129) goto L_0051;\n\tv124 = v124 + 1;\n\tv190 = v124 < *([v65 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv103 = ~v190;\n\tv123 = v123 + 0x10;\n\tv79 = ~v103;\n\tif (v79) goto L_0039;\nL_004E:\n\tv197 = 0x8909C4(v48, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_005A;\nL_0051:\n\tv192 = *([v123 @ X11_v5]) + 1;\n\tv193 = v192 << 4;\n\tv194 = v65 + v193;\n\tv197 = v194 + 0x130;\nL_005A:\n\t*([v197 @ X0_v7])(v174, v48, argumentName, v61, *([v197 @ X0_v7+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddPrimative<T>(string argumentName, T value) where T : struct
		{
			//IL_002e: Expected I, but got O
			//IL_0069: Expected O, but got I
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_0108: Expected O, but got I
			//IL_0117: Expected O, but got I
			//IL_00b5: Expected O, but got I
			int num = (int)((long)(IntPtr)value & 1L);
			IDictionary<string, object> dictionary = arguments;
			object obj = (IntPtr)num;
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ce;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj2 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ce;
			}
			object obj3 = obj2 + 1;
			int num4 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr + (long)num4;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_0155;
			IL_00ce:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0155;
			IL_0155:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v197 @ X0_v7] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0xBB35E0", Offset = "0xBB35E0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv31 = *([1EF3598]);\n\tv32 = *([v31 @ X8_v14]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, argumentName, nullable, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022C54]) = v48;\nL_001A:\n\tv49 = nullable & 0xFF00000000;\n\tv50 = v49 == 0;\n\tif (v50) goto L_006B;\n\tv52 = this.arguments;\n\tthis = 0x115C1C4(&nullable @ X2 (System.Nullable`1<T>), Il2CppMethodInfo, nullable, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_002E;\n\tv160 = v124;\n\tv161 = 0x8907BC(v160, v54, nullable, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_002E:\n\t// 46 Box this @ X0 (Facebook.Unity.MethodArguments), typeof(Il2CppClass<T>), &this @ X0 (Facebook.Unity.MethodArguments)\n\tv166 = *([v52 @ X20_v4 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv110 = *([v166 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v110) goto L_0056;\n\tv211 = *([v166 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_0041:\n\tv217 = *([v211 @ X11_v6-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v217) goto L_0059;\n\tv212 = v212 + 1;\n\tv222 = v212 < *([v166 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv193 = ~v222;\n\tv211 = v211 + 0x10;\n\tv177 = ~v193;\n\tif (v177) goto L_0041;\nL_0056:\n\tthis = 0x8909C4(v52, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0062;\nL_0059:\n\tv224 = *([v211 @ X11_v6]) + 1;\n\tv225 = v224 << 4;\n\tv226 = v166 + v225;\n\tthis = v226 + 0x130;\nL_0062:\n\t*([this @ X0 (Facebook.Unity.MethodArguments)])(this, v52, argumentName, this, *([this @ X0 (Facebook.Unity.MethodArguments)+8]), v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_006B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddNullablePrimitive<T>(string argumentName, T? nullable) where T : struct
		{
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Expected I4, but got Unknown
			//IL_0024: Expected I, but got O
			//IL_0035: Expected I, but got O
			//IL_0070: Expected O, but got I
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_010f: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_00bc: Expected O, but got I
			if ((int)((_003F?)nullable & 0xFF00000000L) == 0)
			{
				return;
			}
			IDictionary<string, object> dictionary = arguments;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C1C4 (inside System.Nullable`1<System.Int32>::Unbox +0xC0)");
			MethodArguments methodArguments = (MethodArguments)(object)(IntPtr)this;
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00d5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00d5;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			methodArguments = (MethodArguments)((long)(IntPtr)obj3 + 304L);
			goto IL_017c;
			IL_017c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (Facebook.Unity.MethodArguments)] (should have been resolved before IL gen)");
			return;
			IL_00d5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_017c;
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0xD1E810", Offset = "0xD1E810", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EEB8D0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, argumentName, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C53]) = v44;\nL_0019:\n\tv47 = System.String::IsNullOrEmpty(value);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0025;\n\treturn;\nL_0025:\n\tv56 = this.arguments;\n\tv128 = *([v56 @ X21_v2 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv114 = *([v128 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v114) goto L_004C;\n\tv173 = *([v128 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_0037:\n\tv179 = *([v173 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v179) goto L_004F;\n\tv174 = v174 + 1;\n\tv184 = v174 < *([v128 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv155 = ~v184;\n\tv173 = v173 + 0x10;\n\tv139 = ~v155;\n\tif (v139) goto L_0037;\nL_004C:\n\tv191 = 0x8909C4(v56, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0053;\nL_004F:\n\tv186 = *([v173 @ X11_v5]) + 1;\n\tv187 = v186 << 4;\n\tv188 = v128 + v187;\n\tv191 = v188 + 0x130;\nL_0053:\n\tv61 = *([v191 @ X0_v6]);\n\tv59 = *([v191 @ X0_v6+8]);\n\t// 95 IndirectJump v61 @ X4_v1, v56 @ X21_v2 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), v56 @ X21_v2 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), argumentName @ X1 (System.String), value @ X2 (System.String), v59 @ X3_v1, v61 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddString(string argumentName, string value)
		{
			//IL_001d: Expected I, but got O
			//IL_0177: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			//IL_00f7: Expected O, but got I
			//IL_0106: Expected O, but got I
			//IL_00a4: Expected O, but got I
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			IDictionary<string, object> dictionary = arguments;
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bd;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bd;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_015f;
			IL_015f:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_00bd:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_015f;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0xD1F1D8", Offset = "0xD1F1D8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EADF20]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, argumentName, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C54]) = v44;\nL_0017:\n\tv45 = value == 0;\n\tif (v45) goto L_004C;\n\tv46 = this.arguments;\n\tv48 = Facebook.Unity.Utilities::ToCommaSeparateList(value);\n\tv127 = *([v46 @ X20_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv113 = *([v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v113) goto L_0043;\n\tv172 = *([v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_002E:\n\tv178 = *([v172 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v178) goto L_004E;\n\tv173 = v173 + 1;\n\tv183 = v173 < *([v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv154 = ~v183;\n\tv172 = v172 + 0x10;\n\tv138 = ~v154;\n\tif (v138) goto L_002E;\nL_0043:\n\tv190 = 0x8909C4(v46, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0052;\nL_004C:\n\treturn;\nL_004E:\n\tv185 = *([v172 @ X11_v5]) + 1;\n\tv186 = v185 << 4;\n\tv187 = v127 + v186;\n\tv190 = v187 + 0x130;\nL_0052:\n\tv60 = *([v190 @ X0_v6]);\n\tv58 = *([v190 @ X0_v6+8]);\n\t// 94 IndirectJump v60 @ X4_v1, v46 @ X20_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), v46 @ X20_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), argumentName @ X1 (System.String), v48 @ X0_v3 (System.String), v58 @ X3_v1, v60 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddCommaSeparatedList(string argumentName, IEnumerable<string> value)
		{
			//IL_0029: Expected I, but got O
			//IL_0177: Expected O, but got I
			//IL_0064: Expected O, but got I
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_0104: Expected O, but got I
			//IL_0113: Expected O, but got I
			//IL_00b0: Expected O, but got I
			if (value == null)
			{
				return;
			}
			IDictionary<string, object> dictionary = arguments;
			string text = value.ToCommaSeparateList();
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c9;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_015f;
			IL_015f:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_00c9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_015f;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xD30870", Offset = "0xD30870", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB64E8]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, argumentName, dict, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C55]) = v44;\nL_0017:\n\tv45 = dict == 0;\n\tif (v45) goto L_004C;\n\tv46 = this.arguments;\n\tv48 = Facebook.Unity.MethodArguments::ToStringDict(dict);\n\tv127 = *([v46 @ X20_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv113 = *([v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v113) goto L_0043;\n\tv172 = *([v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_002E:\n\tv178 = *([v172 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v178) goto L_004E;\n\tv173 = v173 + 1;\n\tv183 = v173 < *([v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv154 = ~v183;\n\tv172 = v172 + 0x10;\n\tv138 = ~v154;\n\tif (v138) goto L_002E;\nL_0043:\n\tv190 = 0x8909C4(v46, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0052;\nL_004C:\n\treturn;\nL_004E:\n\tv185 = *([v172 @ X11_v5]) + 1;\n\tv186 = v185 << 4;\n\tv187 = v127 + v186;\n\tv190 = v187 + 0x130;\nL_0052:\n\tv60 = *([v190 @ X0_v6]);\n\tv58 = *([v190 @ X0_v6+8]);\n\t// 94 IndirectJump v60 @ X4_v1, v46 @ X20_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), v46 @ X20_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), argumentName @ X1 (System.String), v48 @ X0_v3 (System.Collections.Generic.Dictionary`2<System.String, System.String>), v58 @ X3_v1, v60 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddDictionary(string argumentName, IDictionary<string, object> dict)
		{
			//IL_0029: Expected I, but got O
			//IL_0177: Expected O, but got I
			//IL_0064: Expected O, but got I
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_0104: Expected O, but got I
			//IL_0113: Expected O, but got I
			//IL_00b0: Expected O, but got I
			if (dict == null)
			{
				return;
			}
			IDictionary<string, object> dictionary = arguments;
			Dictionary<string, string> dictionary2 = ToStringDict(dict);
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c9;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_015f;
			IL_015f:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_00c9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_015f;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xBB33CC", Offset = "0xBB33CC", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EBD550]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, argumentName, list, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022C52]) = v44;\nL_0017:\n\tv45 = list == 0;\n\tif (v45) goto L_0049;\n\tv46 = this.arguments;\n\tv55 = *([v46 @ X21_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv59 = *([v55 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v59) goto L_0040;\n\tv169 = *([v55 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_002B:\n\tv175 = *([v169 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v175) goto L_004B;\n\tv170 = v170 + 1;\n\tv180 = v170 < *([v55 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv151 = ~v180;\n\tv169 = v169 + 0x10;\n\tv135 = ~v151;\n\tif (v135) goto L_002B;\nL_0040:\n\tv187 = 0x8909C4(v46, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_004F;\nL_0049:\n\treturn;\nL_004B:\n\tv182 = *([v169 @ X11_v5]) + 1;\n\tv183 = v182 << 4;\n\tv184 = v55 + v183;\n\tv187 = v184 + 0x130;\nL_004F:\n\tv65 = *([v187 @ X0_v4]);\n\tv63 = *([v187 @ X0_v4+8]);\n\t// 91 IndirectJump v65 @ X4_v1, v46 @ X21_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), v46 @ X21_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), argumentName @ X1 (System.String), list @ X2 (System.Collections.Generic.IEnumerable`1<T>), v63 @ X3_v1, v65 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddList<T>(string argumentName, IEnumerable<T> list)
		{
			//IL_001c: Expected I, but got O
			//IL_016a: Expected O, but got I
			//IL_0057: Expected O, but got I
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			//IL_00f7: Expected O, but got I
			//IL_0106: Expected O, but got I
			//IL_00a3: Expected O, but got I
			if (list == null)
			{
				return;
			}
			IDictionary<string, object> dictionary = arguments;
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v3 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bc;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0152;
			IL_0152:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v65 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_00bc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0152;
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0xD1F4C8", Offset = "0xD1F4C8", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC3020]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, argumentName, uri, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C56]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, argumentName, uri, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv61 = System.Uri::op_Inequality(uri, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_003B;\n\tv79 = System.Uri::get_AbsoluteUri(uri);\n\tv68 = System.String::IsNullOrEmpty(v79);\n\tv70 = v68 == 0;\n\tif (v70) goto L_003D;\nL_003B:\n\treturn;\nL_003D:\n\tv90 = this.arguments;\n\tv86 = System.Uri::ToString(uri);\n\tv167 = *([v90 @ X20_v4 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv151 = *([v167 @ X8_v9 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v151) goto L_0069;\n\tv211 = *([v167 @ X8_v9 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_0054:\n\tv217 = *([v211 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v217) goto L_006C;\n\tv212 = v212 + 1;\n\tv222 = v212 < *([v167 @ X8_v9 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv193 = ~v222;\n\tv211 = v211 + 0x10;\n\tv177 = ~v193;\n\tif (v177) goto L_0054;\nL_0069:\n\tv229 = 0x8909C4(v90, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0070;\nL_006C:\n\tv224 = *([v211 @ X11_v5]) + 1;\n\tv225 = v224 << 4;\n\tv226 = v167 + v225;\n\tv229 = v226 + 0x130;\nL_0070:\n\tv100 = *([v229 @ X0_v15]);\n\tv98 = *([v229 @ X0_v15+8]);\n\t// 124 IndirectJump v100 @ X4_v1, v90 @ X20_v4 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), v90 @ X20_v4 (System.Collections.Generic.IDictionary`2<System.String, System.Object>), argumentName @ X1 (System.String), v86 @ X0_v14 (System.String), v98 @ X3_v1, v100 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddUri(string argumentName, Uri uri)
		{
			//IL_0091: Expected I, but got O
			//IL_01c6: Expected O, but got I
			//IL_00cc: Expected O, but got I
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Expected O, but got Unknown
			//IL_016b: Expected O, but got I
			//IL_017a: Expected O, but got I
			//IL_0118: Expected O, but got I
			if (!(uri != null))
			{
				return;
			}
			string absoluteUri = uri.AbsoluteUri;
			if (string.IsNullOrEmpty(absoluteUri))
			{
				return;
			}
			IDictionary<string, object> dictionary = arguments;
			string text = uri.ToString();
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v9 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0131;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v9 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v9 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0131;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_01ae;
			IL_0131:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01ae;
			IL_01ae:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X0_v15+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v100 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0xD1E900", Offset = "0xD1E900", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EFD7C0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C57]) = v38;\nL_001A:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = Facebook.MiniJSON.Json+Serializer::Serialize(this.arguments);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ToJsonString()
		{
			return Json.Serializer.Serialize(arguments);
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xD30960", Offset = "0xD30960", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC60F8]);\n\tv27 = *([v26 @ X8_v34]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023C58]) = v46;\nL_0017:\n\tv47 = dict == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv51 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v51);\n\tgoto L_0051;\n\tv187 = *([v133 @ X8_v8+B0]);\n\tv188 = 0;\n\tv189 = v187 + 8;\n\tv191 = *([v227 @ X11_v30-8]);\n\tv233 = v191 == v136;\n\tif (v233) goto L_004A;\n\tv213 = v228 + 1;\n\tv238 = v213 < v135;\n\tv209 = ~v238;\n\tv211 = v227 + 0x10;\n\tv193 = ~v209;\n\tif (v193) goto L_FFFFFFFF;\n\tv214 = v20;\n\tv215 = 0;\n\tv216 = 0x8909C4(v214, v136, v215, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0051;\n\tgoto L_012C;\nL_004A:\n\tv239 = *([v227 @ X11_v30]);\n\tv240 = v239 << 4;\n\tv241 = v133 + v240;\n\tv242 = v241 + 0x130;\nL_0051:\n\tv263 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>>::GetEnumerator(dict);\nL_005F:\n\tgoto L_0086;\n\tv316 = *([v310 @ X8_v21+B0]);\n\tv317 = 0;\n\tv318 = v316 + 8;\n\tv320 = *([v384 @ X11_v25-8]);\n\tv390 = v320 == v311;\n\tif (v390) goto L_007F;\n\tv342 = v385 + 1;\n\tv419 = v342 < v312;\n\tv338 = ~v419;\n\tv340 = v384 + 0x10;\n\tv322 = ~v338;\n\tif (v322) goto L_FFFFFFFF;\n\tv343 = v119;\n\tv344 = 0;\n\tv345 = 0x8909C4(v343, v311, v344, v69, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0086;\nL_007F:\n\tv420 = *([v384 @ X11_v25]);\n\tv421 = v420 << 4;\n\tv422 = v310 + v421;\n\tv423 = v422 + 0x130;\nL_0086:\n\tv444 = System.Collections.IEnumerator::MoveNext(v263);\n\tv446 = v444 == 0;\n\tif (v446) goto L_00C9;\n\tgoto L_00B3;\n\tv465 = *([v447 @ X8_v24+B0]);\n\tv466 = 0;\n\tv467 = v465 + 8;\n\tv469 = *([v541 @ X11_v20-8]);\n\tv547 = v469 == v448;\n\tif (v547) goto L_00AE;\n\tv491 = v542 + 1;\n\tv606 = v491 < v449;\n\tv487 = ~v606;\n\tv489 = v541 + 0x10;\n\tv471 = ~v487;\n\tif (v471) goto L_FFFFFFFF;\n\tv492 = v119;\n\tv493 = 0;\n\tv494 = 0x8909C4(v492, v448, v493, v69, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00B3;\nL_00AE:\n\tv607 = *([v541 @ X11_v20]);\n\tv608 = v607 << 4;\n\tv609 = v447 + v608;\n\tv610 = v609 + 0x130;\nL_00B3:\n\tv365 = 0;\n\tv367 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>>::get_Current(v263);\n\tv636 = *([v365 @ X1_v17]);\n\t*([v636 @ X8_v27+160])(v414, 0, *([v636 @ X8_v27+168]), 0, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv306 = v51 == 0;\n\tif (v306) goto L_00D2;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v51, v367, v414);\n\tgoto L_005F;\nL_00C9:\n\tv453 = v263 == 0;\n\tv454 = ~v453;\n\tif (v454) goto L_00F0;\n\tgoto L_0118;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00D2:\n\tv418 = new System.NullReferenceException();\n\tgoto L_00E2;\n\tgoto L_00E2;\n\tgoto L_00E2;\n\tgoto L_00E2;\n\tgoto L_00E2;\n\tgoto L_00E2;\nL_00E2:\n\tv464 = v177 != 1;\n\tif (v464) goto L_0131;\n\tv526 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v418, v177, v151);\n\tv496 = *([v526 @ X0_v25 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]);\n\tv516 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v526, v177, v151);\n\tv518 = v263 == 0;\n\tif (v518) goto L_0118;\nL_00F0:\n\tgoto L_0117;\n\tv576 = *([v521 @ X8_v15+B0]);\n\tv577 = 0;\n\tv578 = v576 + 8;\n\tv580 = *([v625 @ X11_v11-8]);\n\tv631 = v580 == v524;\n\tif (v631) goto L_0110;\n\tv602 = v626 + 1;\n\tv639 = v602 < v523;\n\tv598 = ~v639;\n\tv600 = v625 + 0x10;\n\tv582 = ~v598;\n\tif (v582) goto L_FFFFFFFF;\n\tv603 = v119;\n\tv604 = 0;\n\tv605 = 0x8909C4(v603, v524, v604, v69, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0117;\nL_0110:\n\tv640 = *([v625 @ X11_v11]);\n\tv641 = v640 << 4;\n\tv642 = v521 + v641;\n\tv643 = v642 + 0x130;\nL_0117:\n\tSystem.IDisposable::Dispose(v263);\nL_0118:\n\tv117 = v67 + 1;\n\tv91 = v117 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_012C;\n\tv614 = v65 == 0;\n\tv116 = ~v614;\n\tif (v116) goto L_0130;\nL_012C:\n\treturn v122;\nL_0130:\n\tv530 = new System.TypeLoadException();\nL_0131:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v529, 0, 0);\n\treturn returnVal2;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Dictionary<string, string> ToStringDict(IDictionary<string, object> dict)
		{
			//IL_0091: Expected I, but got O
			//IL_00ad: Expected I, but got O
			//IL_0219: Expected O, but got I4
			//IL_010a: Expected I, but got O
			//IL_0140: Expected I, but got O
			Dictionary<string, string> result;
			if (dict != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				IEnumerator<KeyValuePair<string, object>> enumerator = dict.GetEnumerator();
				string value = default(string);
				string text = default(string);
				string value2 = default(string);
				Dictionary<string, string> dictionary3 = default(Dictionary<string, string>);
				Dictionary<string, string> result2 = default(Dictionary<string, string>);
				while (true)
				{
					IntPtr intPtr;
					int num;
					IntPtr intPtr2;
					int num2;
					Dictionary<string, string> dictionary2;
					if (!enumerator.MoveNext())
					{
						bool flag = enumerator == null;
						bool flag2 = !flag;
						intPtr = (IntPtr)null;
						num = 0;
						if (!flag2)
						{
							intPtr2 = (IntPtr)null;
							num2 = 0;
							goto IL_022b;
						}
					}
					else
					{
						object obj = 0;
						KeyValuePair<string, object> current = enumerator.Current;
						object obj2 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v636 @ X8_v27+160] (should have been resolved before IL gen)");
						if (dictionary != null)
						{
							dictionary.set_Item((string)current, value);
							continue;
						}
						NullReferenceException ex = new NullReferenceException();
						bool flag3 = (IntPtr)text != (IntPtr)1;
						dictionary2 = (Dictionary<string, string>)(object)ex;
						if (flag3)
						{
							goto IL_01a7;
						}
						((Dictionary<string, string>)(object)ex).set_Item(text, value2);
						intPtr = (IntPtr)dictionary3;
						dictionary3.set_Item(text, value2);
						bool flag4 = enumerator == null;
						num = -1;
						intPtr2 = (IntPtr)dictionary3;
						num2 = -1;
						if (flag4)
						{
							goto IL_022b;
						}
					}
					enumerator.Dispose();
					intPtr2 = intPtr;
					num2 = num;
					goto IL_022b;
					IL_022b:
					int num3 = num2 + 1;
					bool flag5 = num3 == 0;
					bool flag6 = !flag5;
					result = dictionary;
					if (flag6)
					{
						break;
					}
					bool flag7 = intPtr2 == (IntPtr)0;
					bool flag8 = !flag7;
					result = dictionary;
					if (!flag8)
					{
						break;
					}
					TypeLoadException ex2 = new TypeLoadException();
					dictionary2 = (Dictionary<string, string>)(object)ex2;
					goto IL_01a7;
					IL_01a7:
					dictionary2.set_Item((string)null, (string)null);
					return result2;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
