using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000009")]
public static class Extensions
{
	[CompilerGenerated]
	[Token(Token = "0x200000B")]
	private sealed class _003CDelay_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x10")]
		internal int _003C_003E1__state;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x18")]
		private object _003C_003E2__current;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x20")]
		public float time;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x28")]
		public Action callback;

		[Token(Token = "0x17000001")]
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			[Token(Token = "0x6000048")]
			[Address(RVA = "0xBF8980", Offset = "0xBF8980", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _003C_003E2__current;
			}
		}

		[Token(Token = "0x17000002")]
		object IEnumerator.Current
		{
			[DebuggerHidden]
			[Token(Token = "0x600004A")]
			[Address(RVA = "0xBF89C0", Offset = "0xBF89C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		[Token(Token = "0x6000045")]
		[Address(RVA = "0xBF87E0", Offset = "0xBF87E0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003CDelay_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		[Token(Token = "0x6000046")]
		[Address(RVA = "0xBF88CC", Offset = "0xBF88CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void IDisposable.Dispose()
		{
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0xBF88D0", Offset = "0xBF88D0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = UnityEngine.WaitForSeconds;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A355C4]) = v35;\nL_0016:\n\tv41 = this.<>1__state == 1;\n\tif (v41) goto L_002E;\n\tv46 = this.<>1__state == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv56 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v56, this.time);\n\tthis.<>2__current = v56;\n\tthis.<>1__state = 1;\n\tgoto L_003D;\nL_002E:\n\t;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv50 = this.callback == 0;\n\tif (v50) goto L_FFFFFFFF;\n\tSystem.Action::Invoke(this.callback);\nL_003D:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool MoveNext()
		{
			if (_003C_003E1__state != 1)
			{
				if (_003C_003E1__state == 0)
				{
					_003C_003E1__state = -1;
					WaitForSeconds waitForSeconds = new WaitForSeconds(time);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if (callback != null)
				{
					callback();
				}
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		[Token(Token = "0x6000049")]
		[Address(RVA = "0xBF8988", Offset = "0xBF8988", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	[CompilerGenerated]
	[Token(Token = "0x200000C")]
	private sealed class _003CDelayReal_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x10")]
		internal int _003C_003E1__state;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x18")]
		private object _003C_003E2__current;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x20")]
		public float time;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x28")]
		public Action callback;

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x30")]
		private float _003Cend_003E5__2;

		[Token(Token = "0x17000003")]
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			[Token(Token = "0x600004E")]
			[Address(RVA = "0xBF8A54", Offset = "0xBF8A54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _003C_003E2__current;
			}
		}

		[Token(Token = "0x17000004")]
		object IEnumerator.Current
		{
			[DebuggerHidden]
			[Token(Token = "0x6000050")]
			[Address(RVA = "0xBF8A94", Offset = "0xBF8A94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		[Token(Token = "0x600004B")]
		[Address(RVA = "0xBF88A4", Offset = "0xBF88A4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003CDelayReal_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		[Token(Token = "0x600004C")]
		[Address(RVA = "0xBF89C8", Offset = "0xBF89C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void IDisposable.Dispose()
		{
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0xBF89CC", Offset = "0xBF89CC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.<>1__state == 1;\n\tif (v11) goto L_001B;\n\tv16 = this.<>1__state == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv21 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv64 = v21 + this.time;\n\tthis.<end>5__2 = v64;\n\tgoto L_001D;\nL_001B:\n\tthis.<>1__state = 0xFFFFFFFF;\nL_001D:\n\tv35 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv29 = v35 >= this.<end>5__2;\n\tif (v29) goto L_002E;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\tgoto L_0039;\nL_002E:\n\t;\n\tv41 = this.callback == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tSystem.Action::Invoke(this.callback);\nL_0039:\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool MoveNext()
		{
			if (_003C_003E1__state != 1)
			{
				if (_003C_003E1__state != 0)
				{
					goto IL_00dd;
				}
				_003C_003E1__state = -1;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				float num = realtimeSinceStartup + time;
				_003Cend_003E5__2 = num;
			}
			else
			{
				_003C_003E1__state = -1;
			}
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			if (realtimeSinceStartup2 < _003Cend_003E5__2)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (callback != null)
			{
				callback();
			}
			goto IL_00dd;
			IL_00dd:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		[Token(Token = "0x600004F")]
		[Address(RVA = "0xBF8A5C", Offset = "0xBF8A5C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	[Token(Token = "0x600003C")]
	[Address(RVA = "0xC71E68", Offset = "0xC71E68", Length = "0x260")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = &v21 @ stack_-50_v2;\n\t*([v20 @ X29_v1-8]) = *([v23 @ SYSREG+28]);\n\t*([v20 @ X29_v1-30]) = newValue;\n\t*([v20 @ X29_v1-28]) = v84;\n\tgoto L_001D;\n\tv37 = 0xB3490C(v121, v84, newValue, v121, v119, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_001D:\n\tv53 = Il2CppClass<T>;\n\tv57 = *([v53 @ X8_v2 (Il2CppClass<T>)+FC]) + 0xF;\n\tv58 = v57 & 0x1FFFFFFF0;\n\tv329 = &v55 @ stack_-80_v1 - v58;\n\tv61 = source == 0;\n\tif (v61) goto L_00FD;\n\tv68 = *([v53 @ X8_v2 (Il2CppClass<T>)+28]) < 0;\n\tv71 = *([v53 @ X8_v2 (Il2CppClass<T>)+28]) ^ *([v53 @ X8_v2 (Il2CppClass<T>)+28]);\n\tv72 = *([v53 @ X8_v2 (Il2CppClass<T>)+28]) & v71;\n\tv73 = v72 < 0;\n\tv74 = &v21 @ stack_-50_v2 - 0x28;\n\tv75 = v68 == v73;\n\tv76 = ~v75;\n\tv77 = ~v76;\n\tif (v77) goto L_003B;\n\tgoto L_003B;\nL_003B:\n\tv85 = 0x1854F10(v329, v74, *([v53 @ X8_v2 (Il2CppClass<T>)+FC]), v121, v119, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_004C;\n\tv98 = v90;\n\tv99 = 0xB348B0(v98, v90, v64, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv104 = Il2CppMethodRgctx<Extensions::Replace>;\n\tv101 = v99;\nL_004C:\n\tgoto L_004E;\n\tv114 = *([v59 @ X20_v1]);\nL_004E:\n\tv116 = source->klass;\n\tv211 = source->klass->interface_offsets_count;\n\tv118 = *([v116 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v118) goto L_006E;\n\tv212 = *([v116 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0054:\n\t;\n\tv226 = *([v212 @ X10_v15-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v226) goto L_0071;\n\tv186 = v211 - 1;\n\tv212 = v212 + 0x10;\n\tv190 = v211 != 1;\n\tif (v190) goto L_0054;\nL_006E:\n\tv294 = 0xB349B4(source, Il2CppClass<System.Collections.Generic.IList`1<T>>, 2, v121, v119, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0075;\nL_0071:\n\tv276 = *([v212 @ X10_v15]) + 2;\n\tv277 = v276 << 4;\n\tv278 = v116 + v277;\n\tv294 = v278 + 0x138;\nL_0075:\n\t*([v20 @ X29_v1-20]) = v329;\n\tv135 = *([v294 @ X0_v17+8]);\n\tv121 = &v21 @ stack_-50_v2 - 0x20;\n\tv119 = &v21 @ stack_-50_v2 - 0xC;\n\t*([v135 @ X1_v1 (Il2CppMethodInfo)+10])(v169, *([v135 @ X1_v1 (Il2CppMethodInfo)+8]), *([v294 @ X0_v17+8]), source, v121, v119, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv303 = *([v20 @ X29_v1-C]) + 1;\n\tv305 = v303 == 0;\n\tif (v305) goto L_00EA;\n\tv311 = Il2CppClass<T>;\n\tv316 = *([v311 @ X8_v14 (Il2CppClass<T>)+28]) < 0;\n\tv319 = *([v311 @ X8_v14 (Il2CppClass<T>)+28]) ^ *([v311 @ X8_v14 (Il2CppClass<T>)+28]);\n\tv320 = *([v311 @ X8_v14 (Il2CppClass<T>)+28]) & v319;\n\tv321 = v320 < 0;\n\tv322 = &v21 @ stack_-50_v2 - 0x30;\n\tv323 = v316 == v321;\n\tv324 = ~v323;\n\tv325 = ~v324;\n\tif (v325) goto L_FFFFFFFF;\n\tgoto L_009B;\nL_009B:\n\tv368 = 0x1854F10(v329, v367, *([v53 @ X8_v2 (Il2CppClass<T>)+FC]), v121, v119, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00AB;\n\tv374 = v369;\n\tv375 = 0xB348B0(v374, v369, v310, v297, v298, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv379 = Il2CppMethodRgctx<Extensions::Replace>;\n\tv377 = v375;\nL_00AB:\n\tgoto L_00AD;\n\tv385 = *([v59 @ X20_v1]);\nL_00AD:\n\t*([v20 @ X29_v1-C]) = *([v20 @ X29_v1-C]);\n\tv386 = source->klass;\n\tv418 = source->klass->interface_offsets_count;\n\tv355 = *([v386 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v355) goto L_00CE;\n\tv419 = *([v386 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_00B4:\n\t;\n\tv433 = *([v419 @ X10_v10-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v433) goto L_00D1;\n\tv393 = v418 - 1;\n\tv419 = v419 + 0x10;\n\tv397 = v418 != 1;\n\tif (v397) goto L_00B4;\nL_00CE:\n\tv445 = 0xB349B4(source, Il2CppClass<System.Collections.Generic.IList`1<T>>, 1, v121, v119, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00D5;\nL_00D1:\n\tv440 = *([v419 @ X10_v10]) + 1;\n\tv441 = v440 << 4;\n\tv442 = v386 + v441;\n\tv445 = v442 + 0x138;\nL_00D5:\n\tv447 = &v21 @ stack_-50_v2 - 0xC;\n\t*([v20 @ X29_v1-20]) = v447;\n\t*([v20 @ X29_v1-18]) = v329;\n\tv135 = *([v445 @ X0_v25+8]);\n\tv121 = &v21 @ stack_-50_v2 - 0x20;\n\t*([v135 @ X1_v1 (Il2CppMethodInfo)+10])(v169, *([v135 @ X1_v1 (Il2CppMethodInfo)+8]), *([v445 @ X0_v25+8]), source, v121, v329, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00EA:\n\tv142 = *([v23 @ SYSREG+28]) != *([v20 @ X29_v1-8]);\n\tif (v142) goto L_0109;\n\treturn *([v20 @ X29_v1-C]);\nL_00FD:\n\tv83 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v83, \"source\");\n\tthrow v83;\nL_0109:\n\treturnVal1 = 0x1854EB0(v169, v135, v167, v121, v119, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn returnVal1;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int Replace<T>(this IList<T> source, T oldValue, T newValue)
	{
		//IL_0357: Expected O, but got I
		//IL_036a: Expected I4, but got I8
		//IL_0378: Expected O, but got I
		//IL_009f: Expected O, but got I
		//IL_04e4: Expected I, but got O
		//IL_04f4: Expected O, but got I
		//IL_0404: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0176: Expected O, but got I
		//IL_0185: Expected O, but got I
		//IL_0100: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_055d: Expected I, but got O
		//IL_056d: Expected O, but got I
		//IL_0494: Expected O, but got I
		//IL_0259: Expected O, but got I
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02e3: Expected O, but got I
		//IL_02f2: Expected O, but got I
		//IL_026d: Expected O, but got I
		//IL_027c: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ SYSREG+28]");
		_ = 0;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v2 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
		object obj5 = default(object);
		object obj4 = (nint)obj5 - num2;
		if (source != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v2 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v2 (Il2CppClass<T>)+28]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v2 (Il2CppClass<T>)+28]");
			int num4 = (int)(num3 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v2 (Il2CppClass<T>)+28]");
			int num5 = (int)((nint)0 & (nint)num4);
			bool flag2 = num5 < 0;
			T val = (T)((nint)obj2 - 40);
			if (flag != flag2)
			{
			}
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
			nint num6 = (nint)source;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 == 0)
			{
				goto IL_0137;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj7 = (nint)0 + (nint)8;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ X10_v15-8]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj8 = (nint)obj6 - 1;
				obj7 = (nint)obj7 + 16;
				bool flag3 = (nint)obj6 != 1;
				obj6 = obj8;
				if (flag3)
				{
					continue;
				}
				goto IL_0137;
			}
			object obj9 = obj7 + 2;
			int num7 = (int)((nint)obj9 << 4);
			object obj10 = num6 + num7;
			object obj11 = (nint)obj10 + 312;
			goto IL_03d1;
		}
		ArgumentNullException ex = new ArgumentNullException("source");
		IList<T> list = null;
		throw ex;
		IL_0519:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ SYSREG+28]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-8]");
		if (num8 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-C]");
			return 0;
		}
		Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
		int result = default(int);
		return result;
		IL_0485:
		object obj12 = (nint)obj2 - 12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ X0_v25+8]");
		nint num9 = 0;
		nint num10 = (nint)obj2 - 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		object obj13 = obj4;
		list = source;
		goto IL_0519;
		IL_0137:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B349B4");
		goto IL_03d1;
		IL_03d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X0_v17+8]");
		num9 = 0;
		num10 = (nint)obj2 - 32;
		obj13 = (nint)obj2 - 12;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-C]");
		int num11 = (int)((nint)0 + (nint)1);
		bool flag4 = num11 == 0;
		list = source;
		if (!flag4)
		{
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v14 (Il2CppClass<T>)+28]");
			bool flag5 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v14 (Il2CppClass<T>)+28]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v14 (Il2CppClass<T>)+28]");
			int num14 = (int)(num13 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v14 (Il2CppClass<T>)+28]");
			int num15 = (int)((nint)0 & (nint)num14);
			bool flag6 = num15 < 0;
			T val2 = (T)((nint)obj2 - 48);
			if (flag5 != flag6)
			{
				T val3 = newValue;
			}
			else
			{
				T val3 = val2;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-C]");
			_ = 0;
			nint num16 = (nint)source;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 == 0)
			{
				goto IL_02a4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj15 = (nint)0 + (nint)8;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X10_v10-8]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj16 = (nint)obj14 - 1;
				obj15 = (nint)obj15 + 16;
				bool flag7 = (nint)obj14 != 1;
				obj14 = obj16;
				if (flag7)
				{
					continue;
				}
				goto IL_02a4;
			}
			object obj17 = obj15 + 1;
			int num17 = (int)((nint)obj17 << 4);
			object obj18 = num16 + num17;
			object obj19 = (nint)obj18 + 312;
			goto IL_0485;
		}
		goto IL_0519;
		IL_02a4:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B349B4");
		goto IL_0485;
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0xC720C8", Offset = "0xC720C8", Length = "0x27C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-38]) = v27;\n\t*([v24 @ X29_v1-8]) = *([v27 @ SYSREG+28]);\n\t*([v24 @ X29_v1-30]) = newValue;\n\t*([v24 @ X29_v1-28]) = oldValue;\n\tgoto L_0020;\n\tv41 = 0xB3490C(v179, oldValue, newValue, v179, v177, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0020:\n\tv57 = Il2CppClass<T>;\n\tv61 = *([v57 @ X8_v3 (Il2CppClass<T>)+FC]) + 0xF;\n\tv62 = v61 & 0x1FFFFFFF0;\n\tv63 = &v59 @ stack_-A0_v1 - v62;\n\tv65 = source == 0;\n\tif (v65) goto L_0106;\n\tv66 = &v25 @ stack_-60_v2 - 0x28;\n\tv67 = &v25 @ stack_-60_v2 - 0x30;\nL_002B:\n\t;\n\tv135 = *([v127 @ X8_v5 (Il2CppClass<T>)+28]) < 0;\n\tv138 = *([v127 @ X8_v5 (Il2CppClass<T>)+28]) ^ *([v127 @ X8_v5 (Il2CppClass<T>)+28]);\n\tv139 = *([v127 @ X8_v5 (Il2CppClass<T>)+28]) & v138;\n\tv140 = v139 < 0;\n\tv141 = v135 == v140;\n\tv142 = ~v141;\n\tv143 = ~v142;\n\tif (v143) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\tv152 = 0x1854F10(v63, v151, *([v57 @ X8_v3 (Il2CppClass<T>)+FC]), v179, v177, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0050;\n\tv164 = v156;\n\tv165 = 0xB348B0(v164, v156, v131, v73, v71, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv170 = Il2CppMethodRgctx<Extensions::ReplaceAll>;\n\tv167 = v165;\nL_0050:\n\tgoto L_0052;\n\tv225 = *([v63 @ X24_v1]);\nL_0052:\n\tv226 = source->klass;\n\tv306 = source->klass->interface_offsets_count;\n\tv228 = *([v226 @ X8_v10 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v228) goto L_0072;\n\tv315 = *([v226 @ X8_v10 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0058:\n\t;\n\tv320 = *([v315 @ X10_v15-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v320) goto L_0074;\n\tv236 = v306 - 1;\n\tv315 = v315 + 0x10;\n\tv234 = v306 != 1;\n\tif (v234) goto L_0058;\nL_0072:\n\tv342 = 0xB349B4(source, Il2CppClass<System.Collections.Generic.IList`1<T>>, 2, v179, v177, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0079;\nL_0074:\n\t;\n\tv327 = *([v315 @ X10_v15]) + 2;\n\tv328 = v327 << 4;\n\tv329 = v226 + v328;\n\tv342 = v329 + 0x138;\nL_0079:\n\t*([v24 @ X29_v1-20]) = v63;\n\tv211 = *([v342 @ X0_v18+8]);\n\tv179 = &v25 @ stack_-60_v2 - 0x20;\n\tv177 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v211 @ X1_v1 (Il2CppMethodInfo)+10])(v215, *([v211 @ X1_v1 (Il2CppMethodInfo)+8]), v211, source, v179, v177, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv218 = *([v24 @ X29_v1-C]) + 1;\n\tv347 = v218 == 0;\n\tif (v347) goto L_00E6;\n\tv353 = Il2CppClass<T>;\n\tv358 = *([v353 @ X8_v15 (Il2CppClass<T>)+28]) < 0;\n\tv361 = *([v353 @ X8_v15 (Il2CppClass<T>)+28]) ^ *([v353 @ X8_v15 (Il2CppClass<T>)+28]);\n\tv362 = *([v353 @ X8_v15 (Il2CppClass<T>)+28]) & v361;\n\tv363 = v362 < 0;\n\tv364 = v358 == v363;\n\tv365 = ~v364;\n\tv82 = ~v365;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_009E;\nL_009E:\n\tv378 = 0x1854F10(v63, v377, *([v57 @ X8_v3 (Il2CppClass<T>)+FC]), v179, v177, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00AF;\n\tv384 = v379;\n\tv385 = 0xB348B0(v384, v379, v352, v180, v178, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv390 = Il2CppMethodRgctx<Extensions::ReplaceAll>;\n\tv387 = v385;\nL_00AF:\n\tgoto L_00B1;\n\tv397 = *([v63 @ X24_v1]);\nL_00B1:\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-C]);\n\tv399 = source->klass;\n\tv432 = source->klass->interface_offsets_count;\n\tv124 = *([v399 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v124) goto L_00D2;\n\tv441 = *([v399 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_00B8:\n\t;\n\tv446 = *([v441 @ X10_v10-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v446) goto L_00D4;\n\tv408 = v432 - 1;\n\tv441 = v441 + 0x10;\n\tv406 = v432 != 1;\n\tif (v406) goto L_00B8;\nL_00D2:\n\tv458 = 0xB349B4(source, Il2CppClass<System.Collections.Generic.IList`1<T>>, 1, v179, v177, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00D9;\nL_00D4:\n\t;\n\tv453 = *([v441 @ X10_v10]) + 1;\n\tv454 = v453 << 4;\n\tv455 = v399 + v454;\n\tv458 = v455 + 0x138;\nL_00D9:\n\tv460 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-20]) = v460;\n\t*([v24 @ X29_v1-18]) = v63;\n\tv120 = *([v458 @ X0_v24+8]);\n\tv179 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v120 @ X1_v12+10])(v122, *([v120 @ X1_v12+8]), v120, source, v179, v63, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_002B;\nL_00E6:\n\tv366 = *([v24 @ X29_v1-38]);\n\tv190 = *([v366 @ X8_v13+28]) != *([v24 @ X29_v1-8]);\n\tif (v190) goto L_0112;\n\treturn;\nL_0106:\n\tv144 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v144, \"source\");\n\tthrow v144;\nL_0112:\n\tv224 = 0x1854EB0(v215, v211, source, v179, v177, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void ReplaceAll<T>(this IList<T> source, T oldValue, T newValue)
	{
		//IL_0322: Expected O, but got I
		//IL_0335: Expected I4, but got I8
		//IL_0343: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_04aa: Expected I, but got O
		//IL_04ba: Expected O, but got I
		//IL_03cf: Expected O, but got I
		//IL_03f2: Expected O, but got I
		//IL_0097: Expected O, but got I
		//IL_02a7: Expected O, but got I
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0122: Expected O, but got I
		//IL_0131: Expected O, but got I
		//IL_00ab: Expected O, but got I
		//IL_00ba: Expected O, but got I
		//IL_04f4: Expected I, but got O
		//IL_0504: Expected O, but got I
		//IL_045a: Expected O, but got I
		//IL_0474: Expected O, but got I
		//IL_01f8: Expected O, but got I
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_0283: Expected O, but got I
		//IL_0292: Expected O, but got I
		//IL_020c: Expected O, but got I
		//IL_021b: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
		_ = 0;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v3 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
		object obj5 = default(object);
		object obj4 = (nint)obj5 - num2;
		if (source != null)
		{
			T val = (T)((nint)obj2 - 40);
			T val2 = (T)((nint)obj2 - 48);
			nint num3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v5 (Il2CppClass<T>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v5 (Il2CppClass<T>)+28]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v5 (Il2CppClass<T>)+28]");
				int num5 = (int)(num4 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v5 (Il2CppClass<T>)+28]");
				int num6 = (int)((nint)0 & (nint)num5);
				bool flag2 = num6 < 0;
				if (flag != flag2)
				{
					T val3 = oldValue;
				}
				else
				{
					T val3 = val;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				nint num7 = (nint)source;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X8_v10 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X8_v10 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_00e2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X8_v10 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj7 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X10_v15-8]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj8 = (nint)obj6 - 1;
					obj7 = (nint)obj7 + 16;
					bool flag3 = (nint)obj6 != 1;
					obj6 = obj8;
					if (flag3)
					{
						continue;
					}
					goto IL_00e2;
				}
				object obj9 = obj7 + 2;
				int num8 = (int)((nint)obj9 << 4);
				object obj10 = num7 + num8;
				object obj11 = (nint)obj10 + 312;
				goto IL_039c;
				IL_044b:
				object obj12 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ X0_v24+8]");
				object obj13 = 0;
				nint num9 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v120 @ X1_v12+10] (should have been resolved before IL gen)");
				object obj14 = obj4;
				num3 = 0;
				continue;
				IL_00e2:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B349B4");
				goto IL_039c;
				IL_0243:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B349B4");
				goto IL_044b;
				IL_039c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ X0_v18+8]");
				nint num10 = 0;
				num9 = (nint)obj2 - 32;
				obj14 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-C]");
				object obj15 = (nint)0 + (nint)1;
				if (obj15 == null)
				{
					break;
				}
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ X8_v15 (Il2CppClass<T>)+28]");
				bool flag4 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ X8_v15 (Il2CppClass<T>)+28]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ X8_v15 (Il2CppClass<T>)+28]");
				int num13 = (int)(num12 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ X8_v15 (Il2CppClass<T>)+28]");
				int num14 = (int)((nint)0 & (nint)num13);
				bool flag5 = num14 < 0;
				if (flag4 != flag5)
				{
					T val4 = newValue;
				}
				else
				{
					T val4 = val2;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-C]");
				_ = 0;
				nint num15 = (nint)source;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ X8_v20 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
					object obj17 = (nint)0 + (nint)8;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ X10_v10-8]");
						if ((nint)0 == 0)
						{
							break;
						}
						object obj18 = (nint)obj16 - 1;
						obj17 = (nint)obj17 + 16;
						bool flag6 = (nint)obj16 != 1;
						obj16 = obj18;
						if (flag6)
						{
							continue;
						}
						goto IL_0243;
					}
					object obj19 = obj17 + 1;
					int num16 = (int)((nint)obj19 << 4);
					object obj20 = num15 + num16;
					object obj21 = (nint)obj20 + 312;
					goto IL_044b;
				}
				goto IL_0243;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-38]");
			object obj22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ X8_v13+28]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
			if (num17 != 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			}
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("source");
		throw ex;
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0xC71C80", Offset = "0xC71C80", Length = "0x1E8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-8]) = *([v27 @ SYSREG+28]);\n\t*([v24 @ X29_v1-18]) = newValue;\n\t*([v24 @ X29_v1-10]) = v102;\n\tgoto L_001F;\n\tv41 = 0xB3490C(v130, v102, newValue, v130, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_001F:\n\tv57 = Il2CppClass<T>;\n\tv61 = *([v57 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv62 = v61 & 0x1FFFFFFF0;\n\tv63 = &v60 @ stack_-80_v1 - v62;\n\tv67 = &v60 @ stack_-80_v1 - v62;\n\tgoto L_0030;\n\tv74 = 0xB348B0(v69, oldValue, newValue, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0030:\n\tv76 = new Il2CppClass<Extensions+<>c__DisplayClass2_0`1<T>>();\n\tv81 = Extensions+<>c__DisplayClass2_0`1<T>::.ctor(v76);\n\tv85 = Il2CppClass<T>;\n\tv90 = *([v85 @ X8_v7 (Il2CppClass<T>)+28]) < 0;\n\tv93 = *([v85 @ X8_v7 (Il2CppClass<T>)+28]) ^ *([v85 @ X8_v7 (Il2CppClass<T>)+28]);\n\tv94 = *([v85 @ X8_v7 (Il2CppClass<T>)+28]) & v93;\n\tv95 = v94 < 0;\n\tv96 = &v25 @ stack_-60_v2 - 0x10;\n\tv97 = v90 == v95;\n\tv98 = ~v97;\n\tv99 = ~v98;\n\tif (v99) goto L_004D;\n\tgoto L_004D;\nL_004D:\n\tv103 = 0x1854F10(v63, v96, *([v57 @ X9_v1 (Il2CppClass<T>)+FC]), v130, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv105 = Il2CppClass<Extensions+<>c__DisplayClass2_0`1<T>>;\n\tv110 = 0xAD94C0(v76, *([v105 @ X8_v12 (Il2CppClass<Extensions+<>c__DisplayClass2_0`1<T>>)+80]), v63, *([v57 @ X9_v1 (Il2CppClass<T>)+FC]), v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv115 = Il2CppClass<T>;\n\tv120 = *([v115 @ X8_v13 (Il2CppClass<T>)+28]) < 0;\n\tv123 = *([v115 @ X8_v13 (Il2CppClass<T>)+28]) ^ *([v115 @ X8_v13 (Il2CppClass<T>)+28]);\n\tv124 = *([v115 @ X8_v13 (Il2CppClass<T>)+28]) & v123;\n\tv125 = v124 < 0;\n\tv126 = &v25 @ stack_-60_v2 - 0x18;\n\tv127 = v120 == v125;\n\tv128 = ~v127;\n\tv129 = ~v128;\n\tif (v129) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_006D:\n\tv160 = 0x1854F10(v67, v159, *([v57 @ X9_v1 (Il2CppClass<T>)+FC]), *([v57 @ X9_v1 (Il2CppClass<T>)+FC]), v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv165 = Il2CppClass<Extensions+<>c__DisplayClass2_0`1<T>>;\n\tv145 = *([v165 @ X8_v16 (Il2CppClass<Extensions+<>c__DisplayClass2_0`1<T>>)+80]) + 0x20;\n\tv147 = 0xAD94C0(v76, v145, v67, *([v57 @ X9_v1 (Il2CppClass<T>)+FC]), v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv149 = source == 0;\n\tif (v149) goto L_00AD;\n\tgoto L_007F;\n\tv216 = 0xB348B0(v174, v145, v143, v131, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_007F:\n\tv218 = new Il2CppClass<System.Func`2<T, T>>();\n\tv223 = System.Func`2<T, T>::.ctor(v218, v76, Il2CppMethodInfo);\n\tv206 = System.Linq.Enumerable::Select(source, v218);\n\tv185 = *([v27 @ SYSREG+28]) != *([v24 @ X29_v1-8]);\n\tif (v185) goto L_00B9;\n\treturn v206;\n\tthrow System.NullReferenceException;\nL_00AD:\n\tv158 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v158, \"source\");\n\tthrow v158;\nL_00B9:\n\treturnVal1 = 0x1854EB0(v206, v218, Il2CppMethodInfo, Il2CppMethodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal1;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, T oldValue, T newValue)
	{
		//IL_0261: Expected O, but got I
		//IL_0274: Expected I4, but got I8
		//IL_0282: Expected O, but got I
		//IL_0290: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_0168: Expected O, but got I
		//IL_02d4: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
		_ = 0;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X9_v1 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
		object obj5 = default(object);
		object obj4 = (nint)obj5 - num2;
		object obj6 = (nint)obj5 - num2;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v7 (Il2CppClass<T>)+28]");
		bool flag = (nint)0 < (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v7 (Il2CppClass<T>)+28]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v7 (Il2CppClass<T>)+28]");
		int num5 = (int)(num4 ^ 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v7 (Il2CppClass<T>)+28]");
		int num6 = (int)((nint)0 & (nint)num5);
		bool flag2 = num6 < 0;
		T val = (T)((nint)obj2 - 16);
		if (flag != flag2)
		{
		}
		Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
		nint num7 = 0;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94C0");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X8_v13 (Il2CppClass<T>)+28]");
		bool flag3 = (nint)0 < (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X8_v13 (Il2CppClass<T>)+28]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X8_v13 (Il2CppClass<T>)+28]");
		int num10 = (int)(num9 ^ 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X8_v13 (Il2CppClass<T>)+28]");
		int num11 = (int)((nint)0 & (nint)num10);
		bool flag4 = num11 < 0;
		T val2 = (T)((nint)obj2 - 24);
		if (flag3 != flag4)
		{
			T val3 = newValue;
		}
		else
		{
			T val3 = val2;
		}
		Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v16 (Il2CppClass<Extensions+<>c__DisplayClass2_0`1<T>>)+80]");
		object obj7 = (nint)0 + (nint)32;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94C0");
		if (source != null)
		{
			Func<T, T> selector = delegate
			{
				//IL_002a: Expected O, but got I
				//IL_003a: Expected O, but got I
				//IL_004a: Expected O, but got I
				//IL_0060: Expected O, but got I
				//IL_0073: Expected I4, but got I8
				//IL_0081: Expected O, but got I
				//IL_008f: Expected O, but got I
				//IL_00b1: Expected O, but got I
				//IL_00c1: Expected O, but got I
				//IL_00d1: Expected O, but got I
				//IL_0138: Expected O, but got I
				//IL_034d: Expected O, but got I
				//IL_035d: Expected O, but got I
				//IL_0194: Expected O, but got I
				//IL_01a4: Expected O, but got I
				//IL_01b4: Expected O, but got I
				//IL_01ce: Expected I4, but got I8
				//IL_03a1: Expected O, but got I
				//IL_03b0: Expected O, but got I
				//IL_03c0: Expected O, but got I
				//IL_03da: Expected O, but got I
				//IL_03ea: Expected O, but got I
				//IL_026a: Expected O, but got I
				//IL_02d1: Expected O, but got I
				//IL_0228: Expected O, but got I
				//IL_023e: Expected O, but got I
				object obj9 = default(object);
				object obj8 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X3_v1+20]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X8_v2+C0]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v3+18]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X9_v1+FC]");
				object obj13 = (nint)0 + (nint)15;
				int num14 = (int)((nint)obj13 & 0x1FFFFFFF0L);
				object obj15 = default(object);
				object obj14 = (nint)obj15 - num14;
				object obj16 = (nint)obj15 - num14;
				object obj17 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v51 @ X0_v1] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X3_v1+20]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X28_v1+C0]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v5+18]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v6+28]");
				bool flag5 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v6+28]");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v6+28]");
				int num16 = (int)(num15 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v6+28]");
				int num17 = (int)((nint)0 & (nint)num16);
				bool flag6 = num17 < 0;
				T val4 = (T)((nint)obj9 - 40);
				if (flag5 != flag6)
				{
					T val6 = default(T);
					T val5 = val6;
				}
				else
				{
					T val5 = val4;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X28_v1+C0]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v9+20]");
				object obj22 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94BC");
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X3_v1+20]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v12+C0]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X8_v13+18]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X8_v14+28]");
				if (0 == 0)
				{
					object obj26 = obj14;
					obj16 = obj16;
				}
				else
				{
					object obj26 = obj14;
				}
				object obj28 = default(object);
				object obj27 = obj28;
				object obj29 = (nint)obj9 - 32;
				object obj30 = (nint)obj9 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X9_v5+1C0]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v152 @ X1_v5+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X3_v1+20]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v18+C0]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-C]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X8_v19+20]");
					object obj34 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v25+80]");
					object obj35 = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94BC");
					T val7 = default(T);
					T val6 = val7;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X8_v19+18]");
					object obj36 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v22+28]");
					bool flag7 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v22+28]");
					nint num18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v22+28]");
					int num19 = (int)(num18 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v22+28]");
					int num20 = (int)((nint)0 & (nint)num19);
					bool flag8 = num20 < 0;
					T val8 = (T)((nint)obj9 - 40);
					if (flag7 == flag8)
					{
						T val6 = val8;
					}
				}
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
				nint num21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
				T result3 = default(T);
				if (num21 == 0)
				{
					return result3;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
				T result4 = default(T);
				return result4;
			};
			IEnumerable<T> result = source.Select(selector);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
			if (num13 == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			IEnumerable<T> result2 = default(IEnumerable<T>);
			return result2;
		}
		ArgumentNullException ex = new ArgumentNullException("source");
		throw ex;
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0xBF8744", Offset = "0xBF8744", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = Extensions::Delay(time, callback);\n\tv16 = UnityEngine.MonoBehaviour::StartCoroutine(mono, v8);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void StartDelayMethod(this MonoBehaviour mono, float time, Action callback)
	{
		IEnumerator routine = Delay(time, callback);
		Coroutine coroutine = mono.StartCoroutine(routine);
	}

	[IteratorStateMachine(typeof(_003CDelay_003Ed__4))]
	[Token(Token = "0x6000040")]
	[Address(RVA = "0xBF8770", Offset = "0xBF8770", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Extensions+<Delay>d__4;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, time, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A355C2]) = v40;\nL_0016:\n\tv42 = new Extensions+<Delay>d__4();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.time = time;\n\tv42.callback = callback;\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static IEnumerator Delay(float time, Action callback)
	{
		_003CDelay_003Ed__4 _003CDelay_003Ed__5 = null;
		_003CDelay_003Ed__5._003C_003E1__state = 0;
		_003CDelay_003Ed__5.time = time;
		_003CDelay_003Ed__5.callback = callback;
		return _003CDelay_003Ed__5;
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0xBF8808", Offset = "0xBF8808", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = Extensions::DelayReal(time, callback);\n\tv16 = UnityEngine.MonoBehaviour::StartCoroutine(mono, v8);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void StartDelayMethodRealTime(this MonoBehaviour mono, float time, Action callback)
	{
		IEnumerator routine = DelayReal(time, callback);
		Coroutine coroutine = mono.StartCoroutine(routine);
	}

	[IteratorStateMachine(typeof(_003CDelayReal_003Ed__6))]
	[Token(Token = "0x6000042")]
	[Address(RVA = "0xBF8834", Offset = "0xBF8834", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Extensions+<DelayReal>d__6;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, time, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A355C3]) = v40;\nL_0016:\n\tv42 = new Extensions+<DelayReal>d__6();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.time = time;\n\tv42.callback = callback;\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static IEnumerator DelayReal(float time, Action callback)
	{
		_003CDelayReal_003Ed__6 _003CDelayReal_003Ed__7 = null;
		_003CDelayReal_003Ed__7._003C_003E1__state = 0;
		_003CDelayReal_003Ed__7.time = time;
		_003CDelayReal_003Ed__7.callback = callback;
		return _003CDelayReal_003Ed__7;
	}
}
