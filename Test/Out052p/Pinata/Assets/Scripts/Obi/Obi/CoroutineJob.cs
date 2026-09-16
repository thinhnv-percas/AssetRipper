using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000050")]
	public class CoroutineJob
	{
		[Token(Token = "0x20000BA")]
		public class ProgressInfo
		{
			[Token(Token = "0x4000305")]
			[FieldOffset(Offset = "0x10")]
			public string userReadableInfo;

			[Token(Token = "0x4000306")]
			[FieldOffset(Offset = "0x18")]
			public float progress;

			[Token(Token = "0x600056E")]
			[Address(RVA = "0xE2EE24", Offset = "0xE2EE24", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.userReadableInfo = userReadableInfo;\n\tthis.progress = progress;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ProgressInfo(string userReadableInfo, float progress)
			{
				this.userReadableInfo = userReadableInfo;
				this.progress = progress;
			}
		}

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x10")]
		private object result;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x18")]
		private bool isDone;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x19")]
		private bool raisedException;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x1A")]
		private bool stop;

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x20")]
		private Exception e;

		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x28")]
		public int asyncThreshold;

		[Token(Token = "0x17000087")]
		public object Result
		{
			[Token(Token = "0x6000378")]
			[Address(RVA = "0xE2E768", Offset = "0xE2E768", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE81A8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024681]) = v38;\nL_0014:\n\tv40 = this.e == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0022;\n\treturn this.result;\nL_0022:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (e == null)
				{
					return result;
				}
				return new TypeLoadException();
			}
		}

		[Token(Token = "0x17000088")]
		public bool IsDone
		{
			[Token(Token = "0x6000379")]
			[Address(RVA = "0xE2E7C8", Offset = "0xE2E7C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isDone;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsDone;
			}
		}

		[Token(Token = "0x17000089")]
		public bool RaisedException
		{
			[Token(Token = "0x600037A")]
			[Address(RVA = "0xE2E7D0", Offset = "0xE2E7D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.raisedException;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RaisedException;
			}
		}

		[Token(Token = "0x600037B")]
		[Address(RVA = "0xE2E7D8", Offset = "0xE2E7D8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stop = 0;\n\tthis.isDone = 0;\n\tthis.result = 0;\n\treturn;\n")]
		private void Init()
		{
			stop = false;
			isDone = false;
			raisedException = false;
			result = null;
		}

		[Token(Token = "0x600037C")]
		[Address(RVA = "0xE2E7E8", Offset = "0xE2E7E8", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB3000]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2024682]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v46);\n\tv51 = coroutine == 0;\n\tif (v51) goto L_008F;\nL_0028:\n\tgoto L_004F;\n\tv200 = *([v155 @ X8_v9+B0]);\n\tv201 = 0;\n\tv202 = v200 + 8;\n\tv204 = *([v241 @ X11_v13-8]);\n\tv246 = v204 == v156;\n\tif (v246) goto L_0048;\n\tv224 = v240 + 1;\n\tv251 = v224 < v157;\n\tv222 = ~v251;\n\tv226 = v241 + 0x10;\n\tv206 = ~v222;\n\tif (v206) goto L_FFFFFFFF;\n\tv227 = v16;\n\tv228 = 0;\n\tv229 = 0x8909C4(v227, v156, v228, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_004F;\nL_0048:\n\tv252 = *([v241 @ X11_v13]);\n\tv253 = v252 << 4;\n\tv254 = v155 + v253;\n\tv255 = v254 + 0x130;\nL_004F:\n\tv105 = System.Collections.IEnumerator::MoveNext(coroutine);\n\tv107 = v105 == 0;\n\tif (v107) goto L_008F;\n\tv260 = coroutine->klass;\n\tv263 = *([v260 @ X8_v12 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v263) goto L_0075;\n\tv305 = *([v260 @ X8_v12 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0060:\n\tv310 = *([v305 @ X11_v8-8]) == System.Collections.IEnumerator;\n\tif (v310) goto L_0078;\n\tv304 = v304 + 1;\n\tv315 = v304 < *([v260 @ X8_v12 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv286 = ~v315;\n\tv305 = v305 + 0x10;\n\tv270 = ~v286;\n\tif (v270) goto L_0060;\nL_0075:\n\tv322 = 0x8909C4(coroutine, System.Collections.IEnumerator, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_007F;\nL_0078:\n\tv317 = *([v305 @ X11_v8]) + 1;\n\tv318 = v317 << 4;\n\tv319 = v260 + v318;\n\tv322 = v319 + 0x130;\nL_007F:\n\t*([v322 @ X0_v10])(v326, coroutine, *([v322 @ X0_v10+8]), v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv152 = v46 == 0;\n\tif (v152) goto L_0091;\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v46, v326);\n\tgoto L_0028;\nL_008F:\n\treturn v46;\nL_0091:\n\tv328 = new System.NullReferenceException();\n\tgoto L_009F;\n\tgoto L_009F;\n\tgoto L_009F;\nL_009F:\n\tv166 = v326 != 1;\n\tif (v166) goto L_00BF;\n\tv332 = 0x6D2BC0(v328, v326, v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv340 = *([v332 @ X0_v20]);\n\tv348 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v340 @ X20_v5]), v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv349 = v348 & 1;\n\tv337 = v349 == 0;\n\tif (v337) goto L_00B5;\n\tv350 = 0x6D2490(v348, *([v340 @ X20_v5]), v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tthrow System.TypeLoadException;\nL_00B5:\n\tv360 = 0x6D1E60(8, *([v340 @ X20_v5]), v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v360 @ X0_v25]) = *([v332 @ X0_v20]);\n\tv188 = 0x1E8A000 + 0x870;\n\tv364 = 0x6D2A00(v360, v188, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv336 = 0x6D2490(v364, v188, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00BF:\n\tv342 = 0x6D2380(v194, v188, v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturnVal2 = 0x846AA4(v342, v188, v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static object RunSynchronously(IEnumerator coroutine)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_00f0: Expected O, but got I
			//IL_00ff: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_01e7: Expected O, but got I4
			List<object> list = new List<object>();
			if (coroutine != null)
			{
				object obj5 = default(object);
				object obj8 = default(object);
				object obj9 = default(object);
				NullReferenceException ex3 = default(NullReferenceException);
				object obj11 = default(object);
				while (coroutine.MoveNext())
				{
					IntPtr intPtr = (IntPtr)coroutine;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X8_v12 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00ad;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X8_v12 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X11_v8-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X8_v12 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00ad;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					int num4 = 0;
					goto IL_02af;
					IL_00ad:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num4 = 1;
					goto IL_02af;
					IL_02af:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v322 @ X0_v10] (should have been resolved before IL gen)");
					if (list != null)
					{
						list.Add(obj5);
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					bool flag3 = (IntPtr)obj5 != (IntPtr)1;
					object obj6 = obj5;
					NullReferenceException ex2 = ex;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj7 = obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						if ((uint)((ulong)(long)(IntPtr)obj9 & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							num4 = 0;
							throw new TypeLoadException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj10 = obj8;
						obj6 = 32022528 + 2160;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						num4 = 0;
						ex2 = ex3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					return obj11;
				}
			}
			return list;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747418", Offset = "0x747418")]
		[Token(Token = "0x600037D")]
		[Address(RVA = "0xE2E9E4", Offset = "0xE2E9E4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDC2D8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, coroutine, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024683]) = v41;\nL_0018:\n\tv45 = new Obi.CoroutineJob+<Start>d__15();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n\tv45.coroutine = coroutine;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator Start(IEnumerator coroutine)
		{
			_003CStart_003Ed__15 _003CStart_003Ed__16 = null;
			_003CStart_003Ed__16._003C_003E1__state = 0;
			_003CStart_003Ed__16._003C_003E4__this = this;
			_003CStart_003Ed__16.coroutine = coroutine;
			return _003CStart_003Ed__16;
		}

		[Token(Token = "0x600037E")]
		[Address(RVA = "0xE2EA90", Offset = "0xE2EA90", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stop = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Stop()
		{
			stop = true;
		}

		[Token(Token = "0x600037F")]
		[Address(RVA = "0xE2EA9C", Offset = "0xE2EA9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CoroutineJob()
		{
		}
	}
}
