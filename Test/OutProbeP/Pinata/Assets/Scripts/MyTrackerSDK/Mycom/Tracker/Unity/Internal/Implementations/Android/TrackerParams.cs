using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Mycom.Tracker.Unity.Internal.Interfaces;
using UnityEngine;

namespace Mycom.Tracker.Unity.Internal.Implementations.Android
{
	[Token(Token = "0x2000010")]
	internal sealed class TrackerParams : ITrackerParams, IDisposable
	{
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x10")]
		internal readonly AndroidJavaObject _trackerParamsObject;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x18")]
		internal bool _isDisposed;

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x161C50C", Offset = "0x161C50C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._trackerParamsObject = trackerParamsObject;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal TrackerParams(AndroidJavaObject trackerParamsObject)
		{
			_trackerParamsObject = trackerParamsObject;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x161F83C", Offset = "0x161F83C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._isDisposed;\n\tv14 = ~v13;\n\tif (v14) goto L_0019;\n\tthis._isDisposed = 1;\n\tv17 = this._trackerParamsObject == 0;\n\tif (v17) goto L_0019;\n\tUnityEngine.AndroidJavaObject::Dispose(this._trackerParamsObject);\nL_0019:\n\tSystem.Object::Finalize(this);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0035;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0036;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 51 ShiftStack 32\n\treturn;\nL_0035:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0036:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~TrackerParams()
		{
			if (!_isDisposed)
			{
				_isDisposed = true;
				if (_trackerParamsObject != null)
				{
					_trackerParamsObject.Dispose();
				}
			}
			base.Finalize();
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x161BD28", Offset = "0x161BD28", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this._isDisposed;\n\tif (v2) goto L_0006;\nL_0003:\n\treturn;\nL_0006:\n\tthis._isDisposed = 1;\n\tv7 = this._trackerParamsObject == 0;\n\tif (v7) goto L_0003;\n\tUnityEngine.AndroidJavaObject::Dispose(this._trackerParamsObject);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (!_isDisposed)
			{
				_isDisposed = true;
				if (_trackerParamsObject != null)
				{
					_trackerParamsObject.Dispose();
				}
			}
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x161F8C4", Offset = "0x161F8C4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EDDB40]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2E2]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getAge\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetAge()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.Call<int>("getAge", Array.Empty<object>());
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x161F9C4", Offset = "0x161F9C4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EBB518]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2E3]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getBufferingPeriod\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetBufferingPeriod()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.Call<int>("getBufferingPeriod", Array.Empty<object>());
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x161FAC4", Offset = "0x161FAC4", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB7A68]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2E4]) = v42;\nL_001A:\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0023;\n\tv53 = v48;\n\tv54 = UnityEngine.AndroidJavaObject::Call(v53, methodInfo, v26, v27);\n\tv57 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0023:\n\tv58 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0044;\n\tv61 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0030;\n\tv83 = v61;\n\tv84 = UnityEngine.AndroidJavaObject::Call(v83, methodInfo, v26, v27);\nL_0030:\n\tv85 = *([v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v85;\n\tif (v71) goto L_0044;\n\tgoto L_0044;\n\tv105 = v76;\n\tv106 = UnityEngine.AndroidJavaObject::Call(v105, methodInfo, v26, v27);\nL_0044:\n\tgoto L_0052;\n\tv86 = v78;\n\tv87 = UnityEngine.AndroidJavaObject::Call(v86, methodInfo, v26, v27);\nL_0052:\n\tv102 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getCustomUserIds\", v95.Value);\n\tv110 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateStringArray(v102);\n\tv180 = v102 == 0;\n\tif (v180) goto L_0088;\nL_0060:\n\tgoto L_0087;\n\tv253 = *([v221 @ X8_v14+B0]);\n\tv254 = 0;\n\tv255 = v253 + 8;\n\tv257 = *([v302 @ X11_v8-8]);\n\tv308 = v257 == v224;\n\tif (v308) goto L_0080;\n\tv279 = v303 + 1;\n\tv340 = v279 < v223;\n\tv275 = ~v340;\n\tv277 = v302 + 0x10;\n\tv259 = ~v275;\n\tif (v259) goto L_FFFFFFFF;\n\tv280 = v216;\n\tv281 = 0;\n\tv282 = 0x8909C4(v280, v224, v281, v207, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0087;\nL_0080:\n\tv341 = *([v302 @ X11_v8]);\n\tv342 = v341 << 4;\n\tv343 = v221 + v342;\n\tv344 = v343 + 0x130;\nL_0087:\n\tSystem.IDisposable::Dispose(v216);\nL_0088:\n\tv250 = v150 + 1;\n\tv134 = v250 == 0;\n\tv119 = ~v134;\n\tif (v119) goto L_009A;\n\tv283 = v148 == 0;\n\tv166 = ~v283;\n\tif (v166) goto L_00A0;\nL_009A:\n\treturn v172;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv176 = new System.TypeLoadException();\n\tgoto L_00B5;\n\tv251 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\tv203 = *([v251 @ X0_v11 (UnityEngine.AndroidJavaObject)]);\n\tv213 = UnityEngine.AndroidJavaObject::Call(v251, 0, 0);\n\tv339 = this._trackerParamsObject == 0;\n\tv215 = ~v339;\n\tif (v215) goto L_0060;\n\tgoto L_0088;\nL_00B5:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetCustomUserIds()
		{
			//IL_0089: Expected I, but got O
			//IL_00a8: Expected I, but got O
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = _trackerParamsObject.Call<AndroidJavaObject>("getCustomUserIds", Array.Empty<object>());
			string[] array = JavaHelper.CreateStringArray(androidJavaObject);
			bool flag = androidJavaObject == null;
			IntPtr intPtr3 = (IntPtr)null;
			int num = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			string[] array2 = array;
			IntPtr intPtr4 = (IntPtr)null;
			int num2 = 0;
			string[] result = array;
			if (!flag)
			{
				((IDisposable)androidJavaObject2).Dispose();
				intPtr4 = intPtr3;
				num2 = num;
				result = array2;
			}
			if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			return (string[])(object)((AndroidJavaObject)(object)ex).Call<AndroidJavaObject>((string)null, (object[])null);
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x161FC90", Offset = "0x161FC90", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ECD308]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2E5]) = v42;\nL_001A:\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0023;\n\tv53 = v48;\n\tv54 = UnityEngine.AndroidJavaObject::Call(v53, methodInfo, v26, v27);\n\tv57 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0023:\n\tv58 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0044;\n\tv61 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0030;\n\tv83 = v61;\n\tv84 = UnityEngine.AndroidJavaObject::Call(v83, methodInfo, v26, v27);\nL_0030:\n\tv85 = *([v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v85;\n\tif (v71) goto L_0044;\n\tgoto L_0044;\n\tv105 = v76;\n\tv106 = UnityEngine.AndroidJavaObject::Call(v105, methodInfo, v26, v27);\nL_0044:\n\tgoto L_0052;\n\tv86 = v78;\n\tv87 = UnityEngine.AndroidJavaObject::Call(v86, methodInfo, v26, v27);\nL_0052:\n\tv102 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getEmails\", v95.Value);\n\tv110 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateStringArray(v102);\n\tv180 = v102 == 0;\n\tif (v180) goto L_0088;\nL_0060:\n\tgoto L_0087;\n\tv253 = *([v221 @ X8_v14+B0]);\n\tv254 = 0;\n\tv255 = v253 + 8;\n\tv257 = *([v302 @ X11_v8-8]);\n\tv308 = v257 == v224;\n\tif (v308) goto L_0080;\n\tv279 = v303 + 1;\n\tv340 = v279 < v223;\n\tv275 = ~v340;\n\tv277 = v302 + 0x10;\n\tv259 = ~v275;\n\tif (v259) goto L_FFFFFFFF;\n\tv280 = v216;\n\tv281 = 0;\n\tv282 = 0x8909C4(v280, v224, v281, v207, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0087;\nL_0080:\n\tv341 = *([v302 @ X11_v8]);\n\tv342 = v341 << 4;\n\tv343 = v221 + v342;\n\tv344 = v343 + 0x130;\nL_0087:\n\tSystem.IDisposable::Dispose(v216);\nL_0088:\n\tv250 = v150 + 1;\n\tv134 = v250 == 0;\n\tv119 = ~v134;\n\tif (v119) goto L_009A;\n\tv283 = v148 == 0;\n\tv166 = ~v283;\n\tif (v166) goto L_00A0;\nL_009A:\n\treturn v172;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv176 = new System.TypeLoadException();\n\tgoto L_00B5;\n\tv251 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\tv203 = *([v251 @ X0_v11 (UnityEngine.AndroidJavaObject)]);\n\tv213 = UnityEngine.AndroidJavaObject::Call(v251, 0, 0);\n\tv339 = this._trackerParamsObject == 0;\n\tv215 = ~v339;\n\tif (v215) goto L_0060;\n\tgoto L_0088;\nL_00B5:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetEmails()
		{
			//IL_0089: Expected I, but got O
			//IL_00a8: Expected I, but got O
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = _trackerParamsObject.Call<AndroidJavaObject>("getEmails", Array.Empty<object>());
			string[] array = JavaHelper.CreateStringArray(androidJavaObject);
			bool flag = androidJavaObject == null;
			IntPtr intPtr3 = (IntPtr)null;
			int num = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			string[] array2 = array;
			IntPtr intPtr4 = (IntPtr)null;
			int num2 = 0;
			string[] result = array;
			if (!flag)
			{
				((IDisposable)androidJavaObject2).Dispose();
				intPtr4 = intPtr3;
				num2 = num;
				result = array2;
			}
			if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			return (string[])(object)((AndroidJavaObject)(object)ex).Call<AndroidJavaObject>((string)null, (object[])null);
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x161FE5C", Offset = "0x161FE5C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED31B0]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2E6]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getForcingPeriod\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetForcingPeriod()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.Call<int>("getForcingPeriod", Array.Empty<object>());
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x161FF5C", Offset = "0x161FF5C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA3E30]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2E7]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv103 = v74;\n\tv104 = 0x8907BC(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0051;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getGender\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GenderEnum GetGender()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return (GenderEnum)_trackerParamsObject.Call<int>("getGender", Array.Empty<object>());
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x1620060", Offset = "0x1620060", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBE858]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2E8]) = v42;\nL_001A:\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0023;\n\tv53 = v48;\n\tv54 = UnityEngine.AndroidJavaObject::Call(v53, methodInfo, v26, v27);\n\tv57 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0023:\n\tv58 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0044;\n\tv61 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0030;\n\tv83 = v61;\n\tv84 = UnityEngine.AndroidJavaObject::Call(v83, methodInfo, v26, v27);\nL_0030:\n\tv85 = *([v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v85;\n\tif (v71) goto L_0044;\n\tgoto L_0044;\n\tv105 = v76;\n\tv106 = UnityEngine.AndroidJavaObject::Call(v105, methodInfo, v26, v27);\nL_0044:\n\tgoto L_0052;\n\tv86 = v78;\n\tv87 = UnityEngine.AndroidJavaObject::Call(v86, methodInfo, v26, v27);\nL_0052:\n\tv102 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getIcqIds\", v95.Value);\n\tv110 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateStringArray(v102);\n\tv180 = v102 == 0;\n\tif (v180) goto L_0088;\nL_0060:\n\tgoto L_0087;\n\tv253 = *([v221 @ X8_v14+B0]);\n\tv254 = 0;\n\tv255 = v253 + 8;\n\tv257 = *([v302 @ X11_v8-8]);\n\tv308 = v257 == v224;\n\tif (v308) goto L_0080;\n\tv279 = v303 + 1;\n\tv340 = v279 < v223;\n\tv275 = ~v340;\n\tv277 = v302 + 0x10;\n\tv259 = ~v275;\n\tif (v259) goto L_FFFFFFFF;\n\tv280 = v216;\n\tv281 = 0;\n\tv282 = 0x8909C4(v280, v224, v281, v207, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0087;\nL_0080:\n\tv341 = *([v302 @ X11_v8]);\n\tv342 = v341 << 4;\n\tv343 = v221 + v342;\n\tv344 = v343 + 0x130;\nL_0087:\n\tSystem.IDisposable::Dispose(v216);\nL_0088:\n\tv250 = v150 + 1;\n\tv134 = v250 == 0;\n\tv119 = ~v134;\n\tif (v119) goto L_009A;\n\tv283 = v148 == 0;\n\tv166 = ~v283;\n\tif (v166) goto L_00A0;\nL_009A:\n\treturn v172;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv176 = new System.TypeLoadException();\n\tgoto L_00B5;\n\tv251 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\tv203 = *([v251 @ X0_v11 (UnityEngine.AndroidJavaObject)]);\n\tv213 = UnityEngine.AndroidJavaObject::Call(v251, 0, 0);\n\tv339 = this._trackerParamsObject == 0;\n\tv215 = ~v339;\n\tif (v215) goto L_0060;\n\tgoto L_0088;\nL_00B5:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetIcqIds()
		{
			//IL_0089: Expected I, but got O
			//IL_00a8: Expected I, but got O
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = _trackerParamsObject.Call<AndroidJavaObject>("getIcqIds", Array.Empty<object>());
			string[] array = JavaHelper.CreateStringArray(androidJavaObject);
			bool flag = androidJavaObject == null;
			IntPtr intPtr3 = (IntPtr)null;
			int num = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			string[] array2 = array;
			IntPtr intPtr4 = (IntPtr)null;
			int num2 = 0;
			string[] result = array;
			if (!flag)
			{
				((IDisposable)androidJavaObject2).Dispose();
				intPtr4 = intPtr3;
				num2 = num;
				result = array2;
			}
			if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			return (string[])(object)((AndroidJavaObject)(object)ex).Call<AndroidJavaObject>((string)null, (object[])null);
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x162022C", Offset = "0x162022C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED4C08]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2E9]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv102 = v74;\n\tv103 = 0x8907BC(v102, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0052;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\treturnVal1 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::GetString(this._trackerParamsObject, \"getId\", v88.Value);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetId()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.GetString("getId");
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x1620314", Offset = "0x1620314", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EBD868]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2EA]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv102 = v74;\n\tv103 = 0x8907BC(v102, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0052;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\treturnVal1 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::GetString(this._trackerParamsObject, \"getLang\", v88.Value);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetLang()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.GetString("getLang");
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x16203FC", Offset = "0x16203FC", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F064F8]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2EB]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getLaunchTimeout\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetLaunchTimeout()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.Call<int>("getLaunchTimeout", Array.Empty<object>());
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x16204FC", Offset = "0x16204FC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EDA1A0]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2EC]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv102 = v74;\n\tv103 = 0x8907BC(v102, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0052;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\treturnVal1 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::GetString(this._trackerParamsObject, \"getMrgsAppId\", v88.Value);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMrgsAppId()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.GetString("getMrgsAppId");
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x16205E4", Offset = "0x16205E4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED5FF8]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2ED]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv102 = v74;\n\tv103 = 0x8907BC(v102, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0052;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\treturnVal1 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::GetString(this._trackerParamsObject, \"getMrgsId\", v88.Value);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMrgsId()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.GetString("getMrgsId");
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x16206CC", Offset = "0x16206CC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED9118]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2EE]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv102 = v74;\n\tv103 = 0x8907BC(v102, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0052;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\treturnVal1 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::GetString(this._trackerParamsObject, \"getMrgsUserId\", v88.Value);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMrgsUserId()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.GetString("getMrgsUserId");
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x16207B4", Offset = "0x16207B4", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBDB40]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2EF]) = v42;\nL_001A:\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0023;\n\tv53 = v48;\n\tv54 = UnityEngine.AndroidJavaObject::Call(v53, methodInfo, v26, v27);\n\tv57 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0023:\n\tv58 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0044;\n\tv61 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0030;\n\tv83 = v61;\n\tv84 = UnityEngine.AndroidJavaObject::Call(v83, methodInfo, v26, v27);\nL_0030:\n\tv85 = *([v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v85;\n\tif (v71) goto L_0044;\n\tgoto L_0044;\n\tv105 = v76;\n\tv106 = UnityEngine.AndroidJavaObject::Call(v105, methodInfo, v26, v27);\nL_0044:\n\tgoto L_0052;\n\tv86 = v78;\n\tv87 = UnityEngine.AndroidJavaObject::Call(v86, methodInfo, v26, v27);\nL_0052:\n\tv102 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getOkIds\", v95.Value);\n\tv110 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateStringArray(v102);\n\tv180 = v102 == 0;\n\tif (v180) goto L_0088;\nL_0060:\n\tgoto L_0087;\n\tv253 = *([v221 @ X8_v14+B0]);\n\tv254 = 0;\n\tv255 = v253 + 8;\n\tv257 = *([v302 @ X11_v8-8]);\n\tv308 = v257 == v224;\n\tif (v308) goto L_0080;\n\tv279 = v303 + 1;\n\tv340 = v279 < v223;\n\tv275 = ~v340;\n\tv277 = v302 + 0x10;\n\tv259 = ~v275;\n\tif (v259) goto L_FFFFFFFF;\n\tv280 = v216;\n\tv281 = 0;\n\tv282 = 0x8909C4(v280, v224, v281, v207, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0087;\nL_0080:\n\tv341 = *([v302 @ X11_v8]);\n\tv342 = v341 << 4;\n\tv343 = v221 + v342;\n\tv344 = v343 + 0x130;\nL_0087:\n\tSystem.IDisposable::Dispose(v216);\nL_0088:\n\tv250 = v150 + 1;\n\tv134 = v250 == 0;\n\tv119 = ~v134;\n\tif (v119) goto L_009A;\n\tv283 = v148 == 0;\n\tv166 = ~v283;\n\tif (v166) goto L_00A0;\nL_009A:\n\treturn v172;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv176 = new System.TypeLoadException();\n\tgoto L_00B5;\n\tv251 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\tv203 = *([v251 @ X0_v11 (UnityEngine.AndroidJavaObject)]);\n\tv213 = UnityEngine.AndroidJavaObject::Call(v251, 0, 0);\n\tv339 = this._trackerParamsObject == 0;\n\tv215 = ~v339;\n\tif (v215) goto L_0060;\n\tgoto L_0088;\nL_00B5:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetOkIds()
		{
			//IL_0089: Expected I, but got O
			//IL_00a8: Expected I, but got O
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = _trackerParamsObject.Call<AndroidJavaObject>("getOkIds", Array.Empty<object>());
			string[] array = JavaHelper.CreateStringArray(androidJavaObject);
			bool flag = androidJavaObject == null;
			IntPtr intPtr3 = (IntPtr)null;
			int num = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			string[] array2 = array;
			IntPtr intPtr4 = (IntPtr)null;
			int num2 = 0;
			string[] result = array;
			if (!flag)
			{
				((IDisposable)androidJavaObject2).Dispose();
				intPtr4 = intPtr3;
				num2 = num;
				result = array2;
			}
			if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			return (string[])(object)((AndroidJavaObject)(object)ex).Call<AndroidJavaObject>((string)null, (object[])null);
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x1620980", Offset = "0x1620980", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB0928]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2F0]) = v42;\nL_001A:\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0023;\n\tv53 = v48;\n\tv54 = UnityEngine.AndroidJavaObject::Call(v53, methodInfo, v26, v27);\n\tv57 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0023:\n\tv58 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0044;\n\tv61 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0030;\n\tv83 = v61;\n\tv84 = UnityEngine.AndroidJavaObject::Call(v83, methodInfo, v26, v27);\nL_0030:\n\tv85 = *([v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v85;\n\tif (v71) goto L_0044;\n\tgoto L_0044;\n\tv105 = v76;\n\tv106 = UnityEngine.AndroidJavaObject::Call(v105, methodInfo, v26, v27);\nL_0044:\n\tgoto L_0052;\n\tv86 = v78;\n\tv87 = UnityEngine.AndroidJavaObject::Call(v86, methodInfo, v26, v27);\nL_0052:\n\tv102 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getPhones\", v95.Value);\n\tv110 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateStringArray(v102);\n\tv180 = v102 == 0;\n\tif (v180) goto L_0088;\nL_0060:\n\tgoto L_0087;\n\tv253 = *([v221 @ X8_v14+B0]);\n\tv254 = 0;\n\tv255 = v253 + 8;\n\tv257 = *([v302 @ X11_v8-8]);\n\tv308 = v257 == v224;\n\tif (v308) goto L_0080;\n\tv279 = v303 + 1;\n\tv340 = v279 < v223;\n\tv275 = ~v340;\n\tv277 = v302 + 0x10;\n\tv259 = ~v275;\n\tif (v259) goto L_FFFFFFFF;\n\tv280 = v216;\n\tv281 = 0;\n\tv282 = 0x8909C4(v280, v224, v281, v207, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0087;\nL_0080:\n\tv341 = *([v302 @ X11_v8]);\n\tv342 = v341 << 4;\n\tv343 = v221 + v342;\n\tv344 = v343 + 0x130;\nL_0087:\n\tSystem.IDisposable::Dispose(v216);\nL_0088:\n\tv250 = v150 + 1;\n\tv134 = v250 == 0;\n\tv119 = ~v134;\n\tif (v119) goto L_009A;\n\tv283 = v148 == 0;\n\tv166 = ~v283;\n\tif (v166) goto L_00A0;\nL_009A:\n\treturn v172;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv176 = new System.TypeLoadException();\n\tgoto L_00B5;\n\tv251 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\tv203 = *([v251 @ X0_v11 (UnityEngine.AndroidJavaObject)]);\n\tv213 = UnityEngine.AndroidJavaObject::Call(v251, 0, 0);\n\tv339 = this._trackerParamsObject == 0;\n\tv215 = ~v339;\n\tif (v215) goto L_0060;\n\tgoto L_0088;\nL_00B5:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetPhones()
		{
			//IL_0089: Expected I, but got O
			//IL_00a8: Expected I, but got O
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = _trackerParamsObject.Call<AndroidJavaObject>("getPhones", Array.Empty<object>());
			string[] array = JavaHelper.CreateStringArray(androidJavaObject);
			bool flag = androidJavaObject == null;
			IntPtr intPtr3 = (IntPtr)null;
			int num = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			string[] array2 = array;
			IntPtr intPtr4 = (IntPtr)null;
			int num2 = 0;
			string[] result = array;
			if (!flag)
			{
				((IDisposable)androidJavaObject2).Dispose();
				intPtr4 = intPtr3;
				num2 = num;
				result = array2;
			}
			if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			return (string[])(object)((AndroidJavaObject)(object)ex).Call<AndroidJavaObject>((string)null, (object[])null);
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x1620B4C", Offset = "0x1620B4C", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EAC9B8]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2F1]) = v42;\nL_001A:\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0023;\n\tv53 = v48;\n\tv54 = UnityEngine.AndroidJavaObject::Call(v53, methodInfo, v26, v27);\n\tv57 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0023:\n\tv58 = *([v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0044;\n\tv61 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0030;\n\tv83 = v61;\n\tv84 = UnityEngine.AndroidJavaObject::Call(v83, methodInfo, v26, v27);\nL_0030:\n\tv85 = *([v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv71 = ~v85;\n\tif (v71) goto L_0044;\n\tgoto L_0044;\n\tv105 = v76;\n\tv106 = UnityEngine.AndroidJavaObject::Call(v105, methodInfo, v26, v27);\nL_0044:\n\tgoto L_0052;\n\tv86 = v78;\n\tv87 = UnityEngine.AndroidJavaObject::Call(v86, methodInfo, v26, v27);\nL_0052:\n\tv102 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"getVKIds\", v95.Value);\n\tv110 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateStringArray(v102);\n\tv180 = v102 == 0;\n\tif (v180) goto L_0088;\nL_0060:\n\tgoto L_0087;\n\tv253 = *([v221 @ X8_v14+B0]);\n\tv254 = 0;\n\tv255 = v253 + 8;\n\tv257 = *([v302 @ X11_v8-8]);\n\tv308 = v257 == v224;\n\tif (v308) goto L_0080;\n\tv279 = v303 + 1;\n\tv340 = v279 < v223;\n\tv275 = ~v340;\n\tv277 = v302 + 0x10;\n\tv259 = ~v275;\n\tif (v259) goto L_FFFFFFFF;\n\tv280 = v216;\n\tv281 = 0;\n\tv282 = 0x8909C4(v280, v224, v281, v207, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0087;\nL_0080:\n\tv341 = *([v302 @ X11_v8]);\n\tv342 = v341 << 4;\n\tv343 = v221 + v342;\n\tv344 = v343 + 0x130;\nL_0087:\n\tSystem.IDisposable::Dispose(v216);\nL_0088:\n\tv250 = v150 + 1;\n\tv134 = v250 == 0;\n\tv119 = ~v134;\n\tif (v119) goto L_009A;\n\tv283 = v148 == 0;\n\tv166 = ~v283;\n\tif (v166) goto L_00A0;\nL_009A:\n\treturn v172;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv176 = new System.TypeLoadException();\n\tgoto L_00B5;\n\tv251 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\tv203 = *([v251 @ X0_v11 (UnityEngine.AndroidJavaObject)]);\n\tv213 = UnityEngine.AndroidJavaObject::Call(v251, 0, 0);\n\tv339 = this._trackerParamsObject == 0;\n\tv215 = ~v339;\n\tif (v215) goto L_0060;\n\tgoto L_0088;\nL_00B5:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v176, 0, 0);\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetVkIds()
		{
			//IL_0089: Expected I, but got O
			//IL_00a8: Expected I, but got O
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = _trackerParamsObject.Call<AndroidJavaObject>("getVKIds", Array.Empty<object>());
			string[] array = JavaHelper.CreateStringArray(androidJavaObject);
			bool flag = androidJavaObject == null;
			IntPtr intPtr3 = (IntPtr)null;
			int num = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			string[] array2 = array;
			IntPtr intPtr4 = (IntPtr)null;
			int num2 = 0;
			string[] result = array;
			if (!flag)
			{
				((IDisposable)androidJavaObject2).Dispose();
				intPtr4 = intPtr3;
				num2 = num;
				result = array2;
			}
			if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex = new TypeLoadException();
			return (string[])(object)((AndroidJavaObject)(object)ex).Call<AndroidJavaObject>((string)null, (object[])null);
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x1620D18", Offset = "0x1620D18", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED0BC0]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2F2]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"isTrackingEnvironmentEnabled\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsTrackingEnvironmentEnabled()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.Call<bool>("isTrackingEnvironmentEnabled", Array.Empty<object>());
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x1620E18", Offset = "0x1620E18", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC6CE0]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2F3]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"isTrackingLaunchEnabled\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsTrackingLaunchEnabled()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.Call<bool>("isTrackingLaunchEnabled", Array.Empty<object>());
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x1620F18", Offset = "0x1620F18", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA4A60]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A2F4]) = v40;\nL_0019:\n\tv46 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0022;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0022:\n\tv56 = *([v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0043;\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv81 = v59;\n\tv82 = 0x8907BC(v81, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv83 = *([v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv69 = ~v83;\n\tif (v69) goto L_0043;\n\tgoto L_0043;\n\tv108 = v74;\n\tv109 = 0x8907BC(v108, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tgoto L_0057;\n\tv84 = v76;\n\tv85 = 0x8907BC(v84, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"isTrackingLocationEnabled\", v93.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsTrackingLocationEnabled()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return _trackerParamsObject.Call<bool>("isTrackingLocationEnabled", Array.Empty<object>());
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x1621018", Offset = "0x1621018", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE6200]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2F5]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Int32), &value @ X1 (System.Int32)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setAge\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetAge(int value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setAge", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x1621104", Offset = "0x1621104", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB84E8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2F6]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Int32), &value @ X1 (System.Int32)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setBufferingPeriod\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetBufferingPeriod(int value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setBufferingPeriod", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x16211F0", Offset = "0x16211F0", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED5B38]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2F7]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringArray(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setCustomUserIds\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetCustomUserIds(string[] value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringArray(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setCustomUserIds", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x1621398", Offset = "0x1621398", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDCFC0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2F8]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringArray(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setEmails\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEmails(string[] value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringArray(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setEmails", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x1621540", Offset = "0x1621540", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F0AAD0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2F9]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Int32), &value @ X1 (System.Int32)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setForcingPeriod\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetForcingPeriod(int value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setForcingPeriod", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x162162C", Offset = "0x162162C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBCE00]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2FA]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 34 Box v55 @ X0_v5, typeof(System.Int32), &value @ X1 (Mycom.Tracker.Unity.GenderEnum)\n\tv58 = v55 == 0;\n\tif (v58) goto L_002F;\n\t// 43 IsInst v72 @ X0_v16, typeof(System.Object), v55 @ X0_v5\nL_002F:\n\tv76 = v47.Length == 0;\n\tif (v76) goto L_0044;\n\tv47[0] = v55;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setGender\", v47);\n\treturn;\n\tv68 = new System.NullReferenceException();\nL_0044:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_0049;\n\tv82 = new System.ArrayTypeMismatchException();\nL_0049:\n\tthrow v90;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetGender(GenderEnum value)
		{
			object[] array = new object[1];
			object obj = (int)value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setGender", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x162171C", Offset = "0x162171C", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F06F08]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2FB]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringArray(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setIcqIds\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetIcqIds(string[] value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringArray(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setIcqIds", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x16218C4", Offset = "0x16218C4", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB4ED8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2FC]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setLang\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetLang(string value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaString(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setLang", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x1621A6C", Offset = "0x1621A6C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EA48F0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2FD]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Int32), &value @ X1 (System.Int32)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setLaunchTimeout\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetLaunchTimeout(int value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setLaunchTimeout", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x1621B58", Offset = "0x1621B58", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDF578]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2FE]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setMrgsAppId\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMrgsAppId(string value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaString(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setMrgsAppId", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x1621D00", Offset = "0x1621D00", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB74C0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A2FF]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setMrgsId\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMrgsId(string value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaString(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setMrgsId", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x1621EA8", Offset = "0x1621EA8", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F0E4D0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A300]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setMrgsUserId\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMrgsUserId(string value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaString(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setMrgsUserId", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x1622050", Offset = "0x1622050", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EAB6F0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A301]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringArray(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setOkIds\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetOkIds(string[] value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringArray(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setOkIds", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x16221F8", Offset = "0x16221F8", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA81A8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A302]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringArray(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setPhones\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPhones(string[] value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringArray(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setPhones", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x16223A0", Offset = "0x16223A0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EDD7D0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A303]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setTrackingEnvironmentEnabled\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetTrackingEnvironmentEnabled(bool value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setTrackingEnvironmentEnabled", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x162248C", Offset = "0x162248C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB9A88]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A304]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setTrackingLaunchEnabled\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetTrackingLaunchEnabled(bool value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setTrackingLaunchEnabled", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x1622578", Offset = "0x1622578", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F04D58]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A305]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Boolean), &value @ X1 (System.Boolean)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setTrackingLocationEnabled\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetTrackingLocationEnabled(bool value)
		{
			object[] array = new object[1];
			object obj = value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setTrackingLocationEnabled", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x1622664", Offset = "0x1622664", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB55F8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A306]) = v41;\nL_0016:\n\tv43 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringArray(value);\n\t// 30 NewArr v51 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = v43 == 0;\n\tif (v54) goto L_002B;\n\t// 39 IsInst v60 @ X0_v34, typeof(System.Object), v43 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv64 = v60 == 0;\n\tif (v64) goto L_0086;\nL_002B:\n\tv67 = v51.Length == 0;\n\tif (v67) goto L_0080;\n\tv51[0] = v43;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setVKIds\", v51);\n\tv215 = v43 == 0;\n\tif (v215) goto L_0069;\nL_0041:\n\tgoto L_0068;\n\tv283 = *([v252 @ X8_v12+B0]);\n\tv284 = 0;\n\tv285 = v283 + 8;\n\tv287 = *([v332 @ X11_v11-8]);\n\tv338 = v287 == v255;\n\tif (v338) goto L_0061;\n\tv309 = v333 + 1;\n\tv368 = v309 < v254;\n\tv305 = ~v368;\n\tv307 = v332 + 0x10;\n\tv289 = ~v305;\n\tif (v289) goto L_FFFFFFFF;\n\tv310 = v47;\n\tv311 = 0;\n\tv312 = 0x8909C4(v310, v255, v311, v239, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0068;\nL_0061:\n\tv369 = *([v332 @ X11_v11]);\n\tv370 = v369 << 4;\n\tv371 = v252 + v370;\n\tv372 = v371 + 0x130;\nL_0068:\n\tSystem.IDisposable::Dispose(v43);\nL_0069:\n\tv281 = v125 + 1;\n\tv91 = v281 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0079;\n\tv313 = v121 == 0;\n\tv119 = ~v313;\n\tif (v119) goto L_007F;\nL_0079:\n\treturn;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv129 = new System.TypeLoadException();\nL_0080:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\tv189 = new System.NullReferenceException();\nL_0086:\n\tv198 = new System.ArrayTypeMismatchException();\n\tthrow v198;\n\tgoto L_0095;\nL_0095:\n\tif (1) goto L_009E;\n\tv320 = 0x6D2BC0(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v320 @ X0_v11]);\n\tv243 = 0x6D2490(v320, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv376 = v43 == 0;\n\tv245 = ~v376;\n\tif (v245) goto L_0041;\n\tgoto L_0069;\nL_009E:\n\tv321 = 0x6D2380(v212, 0, 0, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetVkIds(string[] value)
		{
			AndroidJavaObject androidJavaObject = JavaHelper.CreateJavaStringArray(value);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				_trackerParamsObject.Call("setVKIds", array);
				bool flag = androidJavaObject == null;
				int num = 0;
				int num2 = 0;
				if (!flag)
				{
					((IDisposable)androidJavaObject).Dispose();
					num = 0;
					num2 = 0;
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x162280C", Offset = "0x162280C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE9308]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A307]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = value == 0;\n\tif (v50) goto L_0027;\n\t// 35 IsInst v55 @ X0_v16, typeof(System.Object), value @ X1 (System.String)\nL_0027:\n\tv62 = v47.Length == 0;\n\tif (v62) goto L_003B;\n\tv47[0] = value;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setProxyHost\", v47);\n\treturn;\n\tv51 = new System.NullReferenceException();\nL_003B:\n\tv67 = new System.IndexOutOfRangeException();\n\tgoto L_0042;\n\tv71 = new System.NullReferenceException();\n\tv74 = new System.ArrayTypeMismatchException();\nL_0042:\n\tthrow v88;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetProxyHost(string value)
		{
			object[] array = new object[1];
			if (value != null)
			{
				object obj = value as object;
			}
			if (array.Length != 0)
			{
				array[0] = value;
				_trackerParamsObject.Call("setProxyHost", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x16228DC", Offset = "0x16228DC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EEC2A8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A308]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 33 Box v54 @ X0_v5, typeof(System.Int32), &value @ X1 (Mycom.Tracker.Unity.RegionEnum)\n\tv57 = v54 == 0;\n\tif (v57) goto L_002E;\n\t// 42 IsInst v71 @ X0_v16, typeof(System.Object), v54 @ X0_v5\nL_002E:\n\tv75 = v47.Length == 0;\n\tif (v75) goto L_0043;\n\tv47[0] = v54;\n\tUnityEngine.AndroidJavaObject::Call(this._trackerParamsObject, \"setRegion\", v47);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0043:\n\tv80 = new System.IndexOutOfRangeException();\n\tgoto L_0048;\n\tv81 = new System.ArrayTypeMismatchException();\nL_0048:\n\tthrow v89;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetRegion(RegionEnum value)
		{
			object[] array = new object[1];
			object obj = (int)value;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				_trackerParamsObject.Call("setRegion", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
