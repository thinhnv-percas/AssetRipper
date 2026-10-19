using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.SaveSystem.Runtime.DataSyncronization;

namespace Unco.SaveSystem.Core.DataSyncronization
{
	[Token(Token = "0x200001D")]
	public class LocalToRemoteSyncer : IDataSyncer
	{
		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x3F40994", Offset = "0x3F40994", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv50.key = key;\n\tv76 = new System.Action`1<System.Single>();\n\tSystem.Action`1<System.Single>::.ctor(v76, v50, Il2CppMethodInfo);\n\tgoto L_004F;\nL_004F:\n\tUnco.SaveSystem.Core.DataHandler::LoadFloat(v50.key, v76, 0f, 1);\n\treturn;\nL_0022:\n\tv50 = new Unco.SaveSystem.Core.DataSyncronization.LocalToRemoteSyncer+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v50);\n")]
		public void SyncFloat(string key)
		{
			Action<float> onComplete = saveToFirebase;
			DataHandler.LoadFloat(key, onComplete, 0f, isLocal: true);
			[Token(Token = "0x60000D2")]
			[Address(RVA = "0x3F40CC8", Offset = "0x3F40CC8", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_002D:\n\tUnco.SaveSystem.Core.DataHandler::SaveFloat(this.key, f, 0, 0);\n\treturn;\nL_001E:\n\tgoto L_002D;\n")]
			void saveToFirebase(float f)
			{
				DataHandler.SaveFloat(key, f);
			}
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x3F40A9C", Offset = "0x3F40A9C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv54.key = key;\n\tv85 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v85, v54, Il2CppMethodInfo);\n\tgoto L_0058;\nL_0058:\n\tUnco.SaveSystem.Core.DataHandler::LoadString(v54.key, v85, \"\", 1);\n\treturn;\nL_0027:\n\tv54 = new Unco.SaveSystem.Core.DataSyncronization.LocalToRemoteSyncer+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v54);\n")]
		public void SyncString(string key)
		{
			Action<string> onComplete = saveToFirebase;
			DataHandler.LoadString(key, onComplete, "", isLocal: true);
			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x3F40D44", Offset = "0x3F40D44", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_0029:\n\tUnco.SaveSystem.Core.DataHandler::SaveString(this.key, s, 0, 0);\n\treturn;\nL_001C:\n\tgoto L_0029;\n")]
			void saveToFirebase(string s)
			{
				DataHandler.SaveString(key, s);
			}
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x4A11ECC", Offset = "0x4A11ECC", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tgoto L_001F;\n\tgoto L_001F;\n\tv46 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_002E:\n\tv70 = new Il2CppClass<Unco.SaveSystem.Core.DataSyncronization.LocalToRemoteSyncer+<>c__DisplayClass2_0`1<T>>();\n\tv76 = Unco.SaveSystem.Core.DataSyncronization.LocalToRemoteSyncer+<>c__DisplayClass2_0`1<T>::.ctor(v70);\n\tv70.key = key;\n\tgoto L_0046;\nL_0046:\n\tv158 = new Il2CppClass<System.Action`1<T>>();\n\tv164 = System.Action`1<T>::.ctor(v158, v70, Il2CppMethodInfo);\n\tv167 = 0x8BF5F18(v59, *([v53 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_005A;\nL_005A:\n\tv215 = Il2CppClass<T>;\n\tv146 = *([v215 @ X8_v19 (Il2CppClass<T>)+30]);\n\tgoto L_0064;\n\treturn;\nL_008A:\n\tv155 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001F:\n\tv53 = Il2CppClass<T>;\n\tv57 = *([v53 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv58 = v57 & 0x1FFFFFFF0;\n\t// 36 StackAlloc v59 @ X20_v1 (System.Byte*), v58 @ X10_v2 (System.Int32)\n\tgoto L_002E;\nL_0064:\n\tv135 = 1;\n\tv132 = v70.key;\n\tv129 = v158;\n\tv126 = v59;\n\tv123 = &v135 @ stack_-69_v2 (System.Int32);\n\t*([v146 @ X1_v6 (Il2CppMethodInfo)+10])(v148, *([v146 @ X1_v6 (Il2CppMethodInfo)]), *([v215 @ X8_v19 (Il2CppClass<T>)+30]), 0, &v132 @ stack_-68_v2 (System.String), &v135 @ stack_-69_v2 (System.Int32), v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv225 = *([A4731E0]);\n\tv94 = *([v225 @ X9_v6]) != *([v23 @ X8_v2]);\n\tif (v94) goto L_008A;\n")]
		public unsafe void SyncJson<T>(string key)
		{
			//IL_0010: Expected O, but got I
			//IL_00c4: Expected O, but got I
			//IL_00d7: Expected I4, but got I8
			//IL_0115: Expected O, but got I4
			//IL_012f: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			Action<T> action = saveToFirebase;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5F18");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ X8_v19 (Il2CppClass<T>)+30]");
			nint num4 = 0;
			int num5 = 1;
			string text = key;
			Action<T> action2 = action;
			IntPtr intPtr = (nint)ptr;
			object obj3 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v146 @ X1_v6 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj4 = 0;
			if (obj4 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x5DBA814", Offset = "0x5DBA814", Length = "0x130")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = *([A4731E0]);\n\tv32 = v86;\n\tgoto L_0024;\n\tgoto L_0040;\n\tv108 = *([v67 @ X19_v2 (System.Byte*)]);\n\treturn;\nL_0079:\n\tv144 = 0x8BF5CF0(v119, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0024:\n\tv61 = Il2CppClass<T>;\n\tv65 = *([v61 @ X8_v7 (Il2CppClass<T>)+FC]) + 0xF;\n\tv66 = v65 & 0x1FFFFFFF0;\n\t// 41 StackAlloc v67 @ X19_v2 (System.Byte*), v66 @ X10_v2 (System.Int32)\n\tv74 = *([v61 @ X8_v7 (Il2CppClass<T>)+28]) < 0;\n\tv77 = *([v61 @ X8_v7 (Il2CppClass<T>)+28]) ^ *([v61 @ X8_v7 (Il2CppClass<T>)+28]);\n\tv78 = *([v61 @ X8_v7 (Il2CppClass<T>)+28]) & v77;\n\tv79 = v78 < 0;\n\tv81 = v74 == v79;\n\tv82 = ~v81;\n\tv83 = ~v82;\n\tif (v83) goto L_0040;\nL_0040:\n\tv88 = 0x8BF6A1C(v67, &v32 @ stack_-88_v1 (T), *([v61 @ X8_v7 (Il2CppClass<T>)+FC]), v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tgoto L_004B;\nL_004B:\n\tv101 = Il2CppMethodInfo;\n\tv103 = *([v61 @ X8_v7 (Il2CppClass<T>)+28]) & 0x80000000;\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tv108 = v67;\n\tif (v105) goto L_0052;\nL_0052:\n\tv109 = 0;\n\tv110 = this.key;\n\tv111 = v108;\n\tv113 = &v109 @ stack_-79_v1;\n\tv114 = 0;\n\t*([v101 @ X1_v2 (Il2CppMethodInfo)+10])(v119, *([v101 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, 0, &v110 @ stack_-78_v1 (System.String), 0, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv122 = *([A4731E0]);\n\tv133 = *([v122 @ X9_v3]) != *([v29 @ X8_v2]);\n\tif (v133) goto L_0079;\n")]
			unsafe void saveToFirebase(T t)
			{
				//IL_0010: Expected O, but got I
				//IL_005c: Expected O, but got I
				//IL_006f: Expected I4, but got I8
				//IL_0138: Expected I4, but got I8
				//IL_0171: Expected O, but got I4
				//IL_01ae: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj5 = 0;
				T val2 = default(T);
				T val = val2;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v7 (Il2CppClass<T>)+FC]");
				object obj6 = (nint)0 + (nint)15;
				int num7 = (int)((nint)obj6 & 0x1FFFFFFF0L);
				byte* ptr2 = stackalloc byte[(int)(uint)num7];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v7 (Il2CppClass<T>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v7 (Il2CppClass<T>)+28]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v7 (Il2CppClass<T>)+28]");
				int num9 = (int)(num8 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v7 (Il2CppClass<T>)+28]");
				int num10 = (int)((nint)0 & (nint)num9);
				bool flag2 = num10 < 0;
				if (flag != flag2)
				{
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v7 (Il2CppClass<T>)+28]");
				int num12 = 0;
				bool flag3 = num12 == 0;
				bool flag4 = !flag3;
				IntPtr intPtr2 = (nint)ptr2;
				if (!flag4)
				{
					intPtr2 = (nint)ptr2;
				}
				object obj7 = 0;
				string text2 = key;
				IntPtr intPtr3 = intPtr2;
				object obj8 = obj7;
				int num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v101 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj9 = 0;
				if (obj9 != obj5)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
				}
			}
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x3F40BC0", Offset = "0x3F40BC0", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv50.key = key;\n\tv76 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v76, v50, Il2CppMethodInfo);\n\tgoto L_004F;\nL_004F:\n\tUnco.SaveSystem.Core.DataHandler::LoadInt(v50.key, v76, 0, 1);\n\treturn;\nL_0022:\n\tv50 = new Unco.SaveSystem.Core.DataSyncronization.LocalToRemoteSyncer+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v50);\n")]
		public void SyncInt(string key)
		{
			Action<int> onComplete = saveToFirebase;
			DataHandler.LoadInt(key, onComplete, 0, isLocal: true);
			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x3F40DB8", Offset = "0x3F40DB8", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_0029:\n\tUnco.SaveSystem.Core.DataHandler::SaveInt(this.key, i, 0, 0);\n\treturn;\nL_001C:\n\tgoto L_0029;\n")]
			void saveToFirebase(int i)
			{
				DataHandler.SaveInt(key, i);
			}
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x3F40984", Offset = "0x3F40984", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LocalToRemoteSyncer()
		{
		}
	}
}
