using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using AOT;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Gif.Android
{
	[Token(Token = "0x2000101")]
	internal class AndroidNativeGif
	{
		[StructLayout((LayoutKind)0, Size = 32)]
		[Token(Token = "0x20001D2")]
		private struct GifDecodeTask
		{
			[Token(Token = "0x40006F7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int taskId;

			[Token(Token = "0x40006F8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public string filepath;

			[Token(Token = "0x40006F9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public int framesToRead;

			[Token(Token = "0x40006FA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
			public ThreadPriority threadPriority;

			[Token(Token = "0x40006FB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public DecodeCompleteCallback completeCallback;
		}

		[Token(Token = "0x20001D3")]
		private static class C
		{
			[Token(Token = "0x20001DB")]
			internal delegate void GifExportProgressDelegate(int taskId, float progress);

			[Token(Token = "0x20001DC")]
			internal delegate void GifExportCompletedDelegate(int taskId, string filepath);

			[Token(Token = "0x20001DD")]
			internal delegate void NativeGetFrameMetadataHolderDelegate(int taskId, int frameCount, IntPtr pointerHolder);

			[Token(Token = "0x20001DE")]
			internal delegate void NativeGetImageDataHolderDelegate(int taskId, int frameCount, int frameWidth, int frameHeight, IntPtr pointerHolder);

			[Token(Token = "0x20001DF")]
			internal delegate void NativeGifDecodingCompletedDelegate(int taskId);

			[PreserveSig]
			[Token(Token = "0x6000D41")]
			[Address(RVA = "0xBFDE04", Offset = "0xBFDE04", Length = "0x128")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv48 = *([2022F68]);\n\tv44 = *([2022F68]) == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0032;\n\tv48 = 0x1819000 + 0xEB8;\n\tv61 = 0x8D848C(&v48 @ X8_v6 (System.Int32), filepath, width, height, loop, fps, sampleFac, frameCount, v62, v63, v64, v65, v66, v67, v68, v69);\n\t*([2022F68]) = v61;\n\tv94 = v61 == 0;\n\tif (v94) goto L_0068;\nL_0032:\n\tv100 = 0x8D8464(filepath, filepath, width, height, loop, fps, sampleFac, frameCount, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv113 = *([v24 @ X29_v1+10]) != 0;\n\tif (v113) goto L_0045;\n\tgoto L_0045;\nL_0045:\n\tv123 = 0x8D8484(*([v24 @ X29_v1+18]), filepath, width, height, loop, fps, sampleFac, frameCount, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv126 = 0x8D8484(*([v24 @ X29_v1+20]), filepath, width, height, loop, fps, sampleFac, frameCount, v62, v63, v64, v65, v66, v67, v68, v69);\n\t*([2022F68])(v209, taskId, v100, width, height, loop, fps, sampleFac, frameCount, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv184 = 0x8D8480(v100, v100, width, height, loop, fps, sampleFac, frameCount, v62, v63, v64, v65, v66, v67, v68, v69);\n\treturn;\nL_0068:\n\tv116 = new System.NotSupportedException();\n\tthrow v116;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static extern void _ExportGif(int taskId, string filepath, int width, int height, int loop, int fps, int sampleFac, int frameCount, IntPtr[] imageData, GifExportProgressDelegate exportingCallback, GifExportCompletedDelegate exportCompletedCallback);

			[PreserveSig]
			[Token(Token = "0x6000D42")]
			[Address(RVA = "0xBFE32C", Offset = "0xBFE32C", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([2022F70]);\n\tv38 = *([2022F70]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_002C;\n\tv42 = 0x1819000 + 0xEB8;\n\tv55 = 0x8D848C(&v42 @ X8_v5 (System.Int32), filepath, framesToRead, gifMetadataBuff, getMetadataHolder, getImageDataHolder, completeCallback, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64);\n\t*([2022F70]) = v55;\n\tv89 = v55 == 0;\n\tif (v89) goto L_004F;\nL_002C:\n\tv92 = 0x8D8464(filepath, filepath, framesToRead, gifMetadataBuff, getMetadataHolder, getImageDataHolder, completeCallback, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv95 = 0x8D8484(getMetadataHolder, filepath, framesToRead, gifMetadataBuff, getMetadataHolder, getImageDataHolder, completeCallback, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv101 = 0x8D8484(getImageDataHolder, filepath, framesToRead, gifMetadataBuff, getMetadataHolder, getImageDataHolder, completeCallback, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv107 = 0x8D8484(completeCallback, filepath, framesToRead, gifMetadataBuff, getMetadataHolder, getImageDataHolder, completeCallback, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64);\n\t*([2022F70])(v116, taskId, v92, framesToRead, gifMetadataBuff, v95, v101, v107, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv118 = 0x8D8480(v92, v92, framesToRead, gifMetadataBuff, v95, v101, v107, methodInfo, v57, v58, v59, v60, v61, v62, v63, v64);\n\treturn;\nL_004F:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static extern void _DecodeGif(int taskId, string filepath, int framesToRead, [In][Out] IntPtr gifMetadataBuff, NativeGetFrameMetadataHolderDelegate getMetadataHolder, NativeGetImageDataHolderDelegate getImageDataHolder, NativeGifDecodingCompletedDelegate completeCallback);

			[PreserveSig]
			[Token(Token = "0x6000D43")]
			[Address(RVA = "0xBFE060", Offset = "0xBFE060", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2022F78]);\n\tv22 = *([2022F78]) == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0025;\n\tv26 = 0x1819000 + 0xEB8;\n\tv40 = 0x8D848C(&v26 @ X8_v4 (System.Int32), srcPtrArray, length, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2022F78]) = v40;\n\tv80 = v40 == 0;\n\tif (v80) goto L_0042;\nL_0025:\n\tv83 = srcPtrArray + 0x20;\n\tv93 = srcPtrArray != 0;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv26(v102, destPtrArray, v99, length, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\nL_0042:\n\tv98 = new System.NotSupportedException();\n\tthrow v98;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal static extern void _CopyPointerArray(IntPtr destPtrArray, IntPtr[] srcPtrArray, int length);
		}

		[CompilerGenerated]
		[Token(Token = "0x20001D4")]
		private sealed class _003C_003Ec__DisplayClass21_0
		{
			[Token(Token = "0x40006FC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public int taskId;

			[Token(Token = "0x40006FD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
			public GifMetadata gifMetadata;

			[Token(Token = "0x40006FE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public GifFrameMetadata[] gifFrameMetadata;

			[Token(Token = "0x40006FF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public Color32[][] imageData;

			[Token(Token = "0x6000D44")]
			[Address(RVA = "0xBFE118", Offset = "0xBFE118", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass21_0()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20001D5")]
		private sealed class _003C_003Ec__DisplayClass21_1
		{
			[Token(Token = "0x4000700")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public DecodeCompleteCallback callback;

			[Token(Token = "0x4000701")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

			[Token(Token = "0x6000D45")]
			[Address(RVA = "0xBFE120", Offset = "0xBFE120", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass21_1()
			{
			}

			internal void _003CGifDecodingCompleteCallback_003Eb__0()
			{
				//IL_0043: Expected O, but got I4
				_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_2 = CS_0024_003C_003E8__locals1;
				callback(_003C_003Ec__DisplayClass21_2.taskId, _003C_003Ec__DisplayClass21_2.gifMetadata, (GifFrameMetadata[])_003C_003Ec__DisplayClass21_2.gifMetadata.frameCount, (Color32[][])(object)_003C_003Ec__DisplayClass21_2.gifFrameMetadata);
			}
		}

		[Token(Token = "0x4000471")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private GifExportTask mExportTask;

		[CompilerGenerated]
		[Token(Token = "0x4000472")]
		private static Action<int, float> m_GifExportProgress;

		[CompilerGenerated]
		[Token(Token = "0x4000473")]
		private static Action<int, string> m_GifExportCompleted;

		[Token(Token = "0x4000474")]
		private static Dictionary<int, GCHandle[]> gcHandles;

		[Token(Token = "0x4000475")]
		private static Dictionary<int, GifDecodeResources> sDecodeTasks;

		[Token(Token = "0x4000476")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private GifDecodeTask mDecodeTask;

		[Token(Token = "0x1700024E")]
		private static Dictionary<int, GifDecodeResources> DecodeTasks
		{
			[Token(Token = "0x60008F4")]
			[Address(RVA = "0xBFDF60", Offset = "0xBFDF60", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ED87C0]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022F61]) = v37;\nL_0016:\n\treturnVal1 = v41.sDecodeTasks;\n\tv43 = v41.sDecodeTasks == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002D;\n\tv48 = new System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::.ctor(v48);\n\tv50.sDecodeTasks = v48;\n\treturnVal1 = v57.sDecodeTasks;\nL_002D:\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Dictionary<int, GifDecodeResources> result = sDecodeTasks;
				if (sDecodeTasks == null)
				{
					Dictionary<int, GifDecodeResources> dictionary = new Dictionary<int, GifDecodeResources>();
					sDecodeTasks = dictionary;
					result = sDecodeTasks;
				}
				return result;
			}
		}

		[Token(Token = "0x1400004D")]
		internal static event Action<int, float> GifExportProgress
		{
			[CompilerGenerated]
			[Token(Token = "0x60008EB")]
			[Address(RVA = "0xBF2B60", Offset = "0xBF2B60", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB3388]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022F59]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.Int32, System.Single>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.GifExportProgress, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				Delegate obj = AndroidNativeGif.m_GifExportProgress;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<int, float>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60008EC")]
			[Address(RVA = "0xBF2D7C", Offset = "0xBF2D7C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F0CFF0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022F5A]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.Int32, System.Single>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.GifExportProgress, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				Delegate obj = AndroidNativeGif.m_GifExportProgress;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<int, float>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400004E")]
		internal static event Action<int, string> GifExportCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x60008ED")]
			[Address(RVA = "0xBF2C14", Offset = "0xBF2C14", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ECC3C8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022F5B]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.Int32, System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119.GifExportProgress + 8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_003f: Expected O, but got I
				Delegate obj = AndroidNativeGif.m_GifExportCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<int, string>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)AndroidNativeGif.GifExportProgress + 8L;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60008EE")]
			[Address(RVA = "0xBF2E30", Offset = "0xBF2E30", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF3190]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022F5C]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.Int32, System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119.GifExportProgress + 8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_003f: Expected O, but got I
				Delegate obj = AndroidNativeGif.m_GifExportCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<int, string>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)AndroidNativeGif.GifExportProgress + 8L;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60008EA")]
		[Address(RVA = "0xBFDB4C", Offset = "0xBFDB4C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mExportTask = exportTask;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AndroidNativeGif(GifExportTask exportTask)
		{
			mExportTask = exportTask;
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x738814", Offset = "0x738814")]
		[Token(Token = "0x60008EF")]
		[Address(RVA = "0xBFCE88", Offset = "0xBFCE88", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EECA98]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, progress, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022F5D]) = v41;\nL_001A:\n\tv47 = v45.GifExportProgress == 0;\n\tif (v47) goto L_002F;\n\tSystem.Action`2<System.Int32, System.Single>::Invoke(v45.GifExportProgress, taskId, progress);\n\treturn;\nL_002F:\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void GifExportProgressCallback(int taskId, float progress)
		{
			if (AndroidNativeGif.GifExportProgress != null)
			{
				AndroidNativeGif.GifExportProgress(taskId, progress);
			}
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x738878", Offset = "0x738878")]
		[Token(Token = "0x60008F0")]
		[Address(RVA = "0xBFCF10", Offset = "0xBFCF10", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC61F0]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, filepath, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022F5E]) = v43;\nL_001C:\n\tv50 = v48.GifExportCompleted == 0;\n\tif (v50) goto L_002D;\n\tSystem.Action`2<System.Int32, System.String>::Invoke(v48.GifExportCompleted, taskId, filepath);\nL_002D:\n\tv68 = System.Collections.Generic.Dictionary`2<System.Int32, System.Runtime.InteropServices.GCHandle[]>::get_Item(v48.gcHandles, taskId);\n\tv129 = v68.Length;\n\tv143 = v68.Length < 1;\n\tif (v143) goto L_0067;\nL_003F:\n\tv205 = v77 < v129;\n\tv112 = ~v205;\n\tif (v112) goto L_0070;\n\tv178 = v77 << 2;\n\tv48 = v68 + v178;\n\tv48 = *([v48 @ X8_v4 (Il2CppStaticFields<EasyMobile.Internal.Gif.Android.AndroidNativeGif>)+20]);\n\tv191 = System.Collections.Generic.Dictionary`2<System.Int32, System.Runtime.InteropServices.GCHandle[]>::get_Item(&v48 @ X8_v4 (Il2CppStaticFields<EasyMobile.Internal.Gif.Android.AndroidNativeGif>), 0);\n\tv129 = v68.Length;\n\tv77 = v77 + 1;\n\tv180 = v77 < v68.Length;\n\tif (v180) goto L_003F;\nL_0067:\n\tv164 = System.Collections.Generic.Dictionary`2<System.Int32, System.Runtime.InteropServices.GCHandle[]>::Remove(v48.gcHandles, taskId);\n\treturn;\nL_0070:\n\tv210 = new System.IndexOutOfRangeException();\n\tthrow v210;\n\tthrow System.NullReferenceException;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void GifExportCompletedCallback(int taskId, string filepath)
		{
			//IL_00a4: Expected O, but got I
			if (AndroidNativeGif.GifExportCompleted != null)
			{
				AndroidNativeGif.GifExportCompleted(taskId, filepath);
			}
			GCHandle[] array = gcHandles.get_Item(taskId);
			int num = array.Length;
			if (array.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						int num3 = num2 << 2;
						IntPtr intPtr = (IntPtr)(void*)((long)(IntPtr)array + (long)num3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppStaticFields<EasyMobile.Internal.Gif.Android.AndroidNativeGif>)+20]");
						intPtr = (IntPtr)0;
						GCHandle[] array2 = ((Dictionary<int, GCHandle[]>)(long)intPtr).get_Item(0);
						num = array.Length;
						num2++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < array.Length);
			}
			bool flag = gcHandles.Remove(taskId);
		}

		[Token(Token = "0x60008F1")]
		[Address(RVA = "0xBF4054", Offset = "0xBF4054", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EB82F0]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F5F]) = v40;\nL_0017:\n\tv44 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif();\n\tSystem.Object::.ctor(v44);\n\tv44.mExportTask = exportTask;\n\tv50 = new System.Threading.ThreadStart();\n\tSystem.Threading.ThreadStart::.ctor(v50, v44, Il2CppMethodInfo);\n\tv60 = new System.Threading.Thread();\n\tSystem.Threading.Thread::.ctor(v60, v50);\n\tSystem.Threading.Thread::set_Priority(v60, exportTask.workerPriority);\n\tSystem.Threading.Thread::Start(v60);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ExportGif(GifExportTask exportTask)
		{
			AndroidNativeGif androidNativeGif = null;
			androidNativeGif.mExportTask = exportTask;
			ThreadStart start = androidNativeGif.DoExportGif;
			Thread thread = new Thread(start);
			thread.Priority = exportTask.workerPriority;
			thread.Start();
		}

		[Token(Token = "0x60008F2")]
		[Address(RVA = "0xBFDB78", Offset = "0xBFDB78", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1ED2F40]);\n\tv35 = *([v34 @ X8_v44]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022F60]) = v54;\nL_001B:\n\tv55 = this.mExportTask;\n\tv57 = v55.clip;\n\tv141 = v57.<Frames>k__BackingField;\n\tv165 = v55.imageData;\n\t// 53 NewArr v222 @ X0_v8 (System.Runtime.InteropServices.GCHandle[]), typeof(System.Runtime.InteropServices.GCHandle[]), v165.Length\n\t// 60 NewArr v297 @ X0_v10 (System.IntPtr[]), typeof(System.IntPtr[]), v165.Length\n\tv349 = v165.Length;\n\tv309 = v165.Length < 1;\n\tif (v309) goto L_009D;\nL_004C:\n\tv350 = v145 < v349;\n\tv111 = ~v350;\n\tif (v111) goto L_00E8;\n\tv150 = System.Runtime.InteropServices.GCHandle::Alloc(v165[v145 @ X9_v10 (System.Int32)], 3);\n\tv404 = v145 < v222.Length;\n\tv381 = ~v404;\n\tif (v381) goto L_00E8;\n\tv66 = v145 << 2;\n\tv163 = v222 + v66;\n\t*([v163 @ X8_v38+20]) = v150;\n\tv408 = v145 < v222.Length;\n\tv112 = ~v408;\n\tif (v112) goto L_00E8;\n\tv409 = v163 + 0x20;\n\tv151 = 0xF74EC4(v409, 0, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv410 = v145 < v297.Length;\n\tv382 = ~v410;\n\tif (v382) goto L_00E8;\n\tv297[v145 @ X9_v10 (System.Int32)] = v151;\n\tv349 = v165.Length;\n\tv145 = v145 + 1;\n\tv313 = v145 < v165.Length;\n\tif (v313) goto L_004C;\nL_009D:\n\tv357 = v331.gcHandles;\n\tv333 = v331.gcHandles == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_00B6;\n\tv354 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Runtime.InteropServices.GCHandle[]>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Runtime.InteropServices.GCHandle[]>::.ctor(v354);\n\tv206.gcHandles = v354;\n\tv357 = v213.gcHandles;\nL_00B6:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Runtime.InteropServices.GCHandle[]>::Add(v357, v55.taskId, v222);\n\tv393 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif+C+GifExportProgressDelegate();\n\tv398 = Il2CppMethodInfo;\n\tv393.m_target = 0;\n\tv393.method = Il2CppMethodInfo;\n\tv393.method_ptr = *([v398 @ X8_v22 (Il2CppMethodInfo)]);\n\tv403 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif+C+GifExportCompletedDelegate();\n\tv287 = Il2CppMethodInfo;\n\tv403.m_target = 0;\n\tv403.method = Il2CppMethodInfo;\n\tv403.method_ptr = *([v287 @ X8_v27 (Il2CppMethodInfo)]);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif+C::_ExportGif(v55.taskId, v55.filepath, v57.<Width>k__BackingField, v57.<Height>k__BackingField, v55.loop, v57.<FramePerSecond>k__BackingField, v55.sampleFac, v141.Length, v297, v393, v403);\n\treturn;\nL_00E8:\n\tv387 = new System.IndexOutOfRangeException();\n\tthrow v387;\n\tv167 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoExportGif()
		{
			//IL_00fa: Expected O, but got I
			//IL_0137: Expected O, but got I
			//IL_0185: Expected I, but got O
			GifExportTask gifExportTask = mExportTask;
			AnimatedClip clip = gifExportTask.clip;
			Texture[] frames = clip.Frames;
			Color32[][] imageData = gifExportTask.imageData;
			GCHandle[] array = new GCHandle[imageData.Length];
			IntPtr[] array2 = new IntPtr[imageData.Length];
			int num = imageData.Length;
			if (imageData.Length >= 1)
			{
				int num2 = 0;
				object obj3 = default(object);
				while (true)
				{
					if (num2 < num)
					{
						GCHandle gCHandle = GCHandle.Alloc(imageData[num2], GCHandleType.Pinned);
						if (num2 < array.Length)
						{
							int num3 = num2 << 2;
							object obj = (long)(IntPtr)array + (long)num3;
							if (num2 < array.Length)
							{
								object obj2 = (long)(IntPtr)obj + 32L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
								if (num2 < array2.Length)
								{
									array2[num2] = (IntPtr)obj3;
									num = imageData.Length;
									num2++;
									if (num2 >= imageData.Length)
									{
										break;
									}
									continue;
								}
							}
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			Dictionary<int, GCHandle[]> dictionary = gcHandles;
			if (gcHandles == null)
			{
				Dictionary<int, GCHandle[]> dictionary2 = new Dictionary<int, GCHandle[]>();
				gcHandles = dictionary2;
				dictionary = gcHandles;
			}
			dictionary.Add(gifExportTask.taskId, array);
			C.GifExportProgressDelegate gifExportProgressDelegate = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)gifExportProgressDelegate).m_target = null;
			((Delegate)gifExportProgressDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<int, float, void>*/)(&GifExportProgressCallback);
			((Delegate)gifExportProgressDelegate).method_ptr = method_ptr;
			C.GifExportCompletedDelegate gifExportCompletedDelegate = null;
			IntPtr method_ptr2 = (IntPtr)0;
			((Delegate)gifExportCompletedDelegate).m_target = null;
			((Delegate)gifExportCompletedDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<int, string, void>*/)(&GifExportCompletedCallback);
			((Delegate)gifExportCompletedDelegate).method_ptr = method_ptr2;
			C._ExportGif(gifExportTask.taskId, gifExportTask.filepath, clip.Width, clip.Height, gifExportTask.loop, clip.FramePerSecond, gifExportTask.sampleFac, frames.Length, array2, gifExportProgressDelegate, gifExportCompletedDelegate);
		}

		[Token(Token = "0x60008F3")]
		[Address(RVA = "0xBFDF2C", Offset = "0xBFDF2C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mDecodeTask.framesToRead = task.framesToRead;\n\tthis.mDecodeTask = task.taskId;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AndroidNativeGif(GifDecodeTask task)
		{
			//IL_0029: Expected O, but got I4
			base._002Ector();
			mDecodeTask.framesToRead = task.framesToRead;
			mDecodeTask = (GifDecodeTask)task.taskId;
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x7388DC", Offset = "0x7388DC")]
		[Token(Token = "0x60008F5")]
		[Address(RVA = "0xBFD03C", Offset = "0xBFD03C", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = *([1EDF048]);\n\tv39 = *([v38 @ X8_v26]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, frameCount, pointerHolder, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022F62]) = v56;\nL_0027:\n\tv67 = frameCount < 1;\n\tif (v67) goto L_0034;\n\tv69 = EasyMobile.Internal.PInvokeUtil::IsNull(pointerHolder);\n\tv72 = v69 == 0;\n\tif (v72) goto L_0051;\nL_0034:\n\tgoto L_004B;\n\tv80 = *([v75 @ X0_v3+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_004B;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v75, frameCount, pointerHolder, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_004B:\n\tUnityEngine.Debug::LogError(\"GetFrameMetadataHolderFunc Error: Invalid buffer pointers from native side.\");\n\treturn;\nL_0051:\n\t// 81 NewArr v107 @ X0_v10 (System.Runtime.InteropServices.GCHandle[]), typeof(System.Runtime.InteropServices.GCHandle[]), frameCount @ X1 (System.Int32)\n\t// 88 NewArr v114 @ X0_v12 (System.IntPtr[]), typeof(System.IntPtr[]), frameCount @ X1 (System.Int32)\n\tv209 = v107 + 0x20;\nL_0062:\n\tv117 = 0;\n\t// 99 Box v219 @ X0_v15 (System.Object), typeof(EasyMobile.Internal.Gif.GifFrameMetadata), &v117 @ stack_-68_v2\n\tv221 = System.Runtime.InteropServices.GCHandle::Alloc(v219, 3);\n\tv224 = v207 < v107.Length;\n\tv225 = ~v224;\n\tif (v225) goto L_00BC;\n\t*([v209 @ X24_v3]) = v221;\n\tv270 = v207 < v107.Length;\n\tv256 = ~v270;\n\tif (v256) goto L_00BC;\n\tv212 = 0xF74EC4(v209, 0, 0, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv288 = v207 < v114.Length;\n\tv278 = ~v288;\n\tif (v278) goto L_00BC;\n\tv114[v207 @ X25_v3 (System.Int32)] = v212;\n\tv207 = v207 + 1;\n\tv209 = v209 + 4;\n\tv119 = v207 < frameCount;\n\tif (v119) goto L_0062;\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif+C::_CopyPointerArray(pointerHolder, v114, frameCount);\n\tv285 = EasyMobile.Internal.Gif.Android.AndroidNativeGif::get_DecodeTasks();\n\tv172 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v285, taskId);\n\tv172.frameMetadataHandles = v107;\n\treturn;\nL_00BC:\n\tv281 = new System.IndexOutOfRangeException();\n\tthrow v281;\n\tv269 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void GetFrameMetadataHolderFunc(int taskId, int frameCount, IntPtr pointerHolder)
		{
			//IL_006d: Expected O, but got I
			//IL_01d3: Expected O, but got I4
			//IL_0123: Expected I, but got O
			//IL_0140: Expected O, but got I
			if (frameCount < 1 || PInvokeUtil.IsNull(pointerHolder))
			{
				Debug.LogError("GetFrameMetadataHolderFunc Error: Invalid buffer pointers from native side.");
				return;
			}
			GCHandle[] array = new GCHandle[frameCount];
			IntPtr[] array2 = new IntPtr[frameCount];
			object obj = (long)(IntPtr)array + 32L;
			int num = 0;
			object obj3 = default(object);
			while (true)
			{
				object obj2 = 0;
				object value = (GifFrameMetadata)obj2;
				GCHandle gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
				if (num >= array.Length)
				{
					break;
				}
				obj = gCHandle;
				if (num >= array.Length)
				{
					break;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
				if (num >= array2.Length)
				{
					break;
				}
				array2[num] = (IntPtr)obj3;
				num++;
				obj = (long)(IntPtr)obj + 4L;
				if (num >= frameCount)
				{
					C._CopyPointerArray(pointerHolder, array2, frameCount);
					Dictionary<int, GifDecodeResources> decodeTasks = DecodeTasks;
					GifDecodeResources gifDecodeResources = decodeTasks.get_Item(taskId);
					gifDecodeResources.frameMetadataHandles = array;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x738940", Offset = "0x738940")]
		[Token(Token = "0x60008F6")]
		[Address(RVA = "0xBFD218", Offset = "0xBFD218", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv42 = *([1ECEF88]);\n\tv43 = *([v42 @ X8_v39]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, frameCount, frameWidth, frameHeight, pointerHolder, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2022F63]) = v58;\nL_0029:\n\tv69 = frameCount < 1;\n\tif (v69) goto L_0036;\n\tv71 = EasyMobile.Internal.PInvokeUtil::IsNull(pointerHolder);\n\tv74 = v71 == 0;\n\tif (v74) goto L_0052;\nL_0036:\n\tgoto L_004D;\n\tv82 = *([v77 @ X0_v3+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_004D;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v77, frameCount, frameWidth, frameHeight, pointerHolder, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_004D:\n\tUnityEngine.Debug::LogError(\"GetImageDataHolderFunc Error: Invalid buffer pointers from native side.\");\n\treturn;\nL_0052:\n\tv108 = frameHeight * frameWidth;\n\t// 84 NewArr v110 @ X0_v10 (UnityEngine.Color32[][]), typeof(UnityEngine.Color32[][]), frameCount @ X1 (System.Int32)\nL_005D:\n\t// 93 NewArr v207 @ X0_v13 (UnityEngine.Color32[]), typeof(UnityEngine.Color32[]), v108 @ X23_v3 (System.Int32)\n\tv209 = v207 == 0;\n\tif (v209) goto L_0074;\n\tv282 = *([v110 @ X0_v10 (UnityEngine.Color32[][])]);\n\tv285 = \"il2cpp_codegen_object_is_inst\"(v207, *([v282 @ X8_v36+40]), frameWidth, frameHeight, pointerHolder, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv286 = v285 == 0;\n\tif (v286) goto L_010D;\nL_0074:\n\tv110[v195 @ X25_v3 (System.Int32)] = v207;\n\tv195 = v195 + 1;\n\tv176 = v195 < frameCount;\n\tif (v176) goto L_005D;\n\t// 134 NewArr v394 @ X0_v26 (System.Runtime.InteropServices.GCHandle[]), typeof(System.Runtime.InteropServices.GCHandle[]), frameCount @ X1 (System.Int32)\n\t// 141 NewArr v403 @ X0_v28 (System.IntPtr[]), typeof(System.IntPtr[]), frameCount @ X1 (System.Int32)\n\tv415 = v110.Length < 1;\n\tif (v415) goto L_00ED;\nL_00A8:\n\t;\n\tv265 = System.Runtime.InteropServices.GCHandle::Alloc(v110[v219 @ X9_v8 (System.Int32)], 3);\n\tv216 = v219 << 2;\n\tv277 = v394 + v216;\n\t*([v277 @ X8_v32+20]) = v265;\n\tv447 = v277 + 0x20;\n\tv266 = 0xF74EC4(v447, 0, 0, frameHeight, pointerHolder, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv403[v219 @ X9_v8 (System.Int32)] = v266;\n\tv219 = v219 + 1;\n\tv420 = v219 < v110.Length;\n\tif (v420) goto L_00A8;\nL_00ED:\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif+C::_CopyPointerArray(pointerHolder, v403, frameCount);\n\tv315 = EasyMobile.Internal.Gif.Android.AndroidNativeGif::get_DecodeTasks();\n\tv156 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v315, taskId);\n\tv156.imageDataHandles = v394;\n\treturn;\n\tv369 = new System.IndexOutOfRangeException();\nL_010A:\n\tthrow System.TypeLoadException;\n\tv322 = new System.NullReferenceException();\nL_010D:\n\tv389 = new System.ArrayTypeMismatchException();\n\tgoto L_010A;\n\treturn;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void GetImageDataHolderFunc(int taskId, int frameCount, int frameWidth, int frameHeight, IntPtr pointerHolder)
		{
			//IL_017e: Expected O, but got I
			//IL_0197: Expected O, but got I
			//IL_01bc: Expected I, but got O
			if (frameCount < 1 || PInvokeUtil.IsNull(pointerHolder))
			{
				Debug.LogError("GetImageDataHolderFunc Error: Invalid buffer pointers from native side.");
				return;
			}
			int num = frameHeight * frameWidth;
			Color32[][] array = new Color32[frameCount][];
			int num2 = 0;
			object obj2 = default(object);
			object obj5 = default(object);
			while (true)
			{
				Color32[] array2 = new Color32[num];
				if (array2 != null)
				{
					object obj = array;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					if (obj2 == null)
					{
						break;
					}
				}
				array[num2] = array2;
				num2++;
				if (num2 < frameCount)
				{
					continue;
				}
				GCHandle[] array3 = new GCHandle[frameCount];
				IntPtr[] array4 = new IntPtr[frameCount];
				if (array.Length >= 1)
				{
					int num3 = 0;
					do
					{
						GCHandle gCHandle = GCHandle.Alloc(array[num3], GCHandleType.Pinned);
						int num4 = num3 << 2;
						object obj3 = (long)(IntPtr)array3 + (long)num4;
						object obj4 = (long)(IntPtr)obj3 + 32L;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
						array4[num3] = (IntPtr)obj5;
						num3++;
					}
					while (num3 < array.Length);
				}
				C._CopyPointerArray(pointerHolder, array4, frameCount);
				Dictionary<int, GifDecodeResources> decodeTasks = DecodeTasks;
				GifDecodeResources gifDecodeResources = decodeTasks.get_Item(taskId);
				gifDecodeResources.imageDataHandles = array3;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw new TypeLoadException();
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x7389A4", Offset = "0x7389A4")]
		[Token(Token = "0x60008F7")]
		[Address(RVA = "0xBFD470", Offset = "0xBFD470", Length = "0x6DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EB1108]);\n\tv31 = *([v30 @ X8_v114]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022F64]) = v50;\nL_001E:\n\tv56 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif+<>c__DisplayClass21_0();\n\tSystem.Object::.ctor(v56);\n\tv56.taskId = taskId;\n\tv60 = EasyMobile.Internal.Gif.Android.AndroidNativeGif::get_DecodeTasks();\n\tv270 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::ContainsKey(v60, v56.taskId);\n\tv323 = v270 == 0;\n\tif (v323) goto L_006F;\n\tv253 = EasyMobile.Internal.Gif.Android.AndroidNativeGif::get_DecodeTasks();\n\tv347 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v253, v56.taskId);\n\tv350 = v347 == 0;\n\tif (v350) goto L_006F;\n\tv254 = EasyMobile.Internal.Gif.Android.AndroidNativeGif::get_DecodeTasks();\n\tv556 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v254, v56.taskId);\n\tv56.gifFrameMetadata = 0;\n\tv56.imageData = 0;\n\tv672 = v556 + 0x10;\n\tv674 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v672, 0);\n\tv331 = v331_asT == 0;\n\tif (v331) goto L_01A9;\n\tv829 = \"il2cpp_vm_object_unbox\"(v674, EasyMobile.Internal.Gif.GifMetadata, Il2CppMethodInfo, v67, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv56.gifMetadata = *([v829 @ X0_v83]);\n\tv56.gifMetadata.frameCount = *([v829 @ X0_v83+8]);\n\tv353 = v556.imageDataHandles;\n\tv889 = v556.frameMetadataHandles == 0;\n\tif (v889) goto L_00A5;\n\tv916 = v556.imageDataHandles == 0;\n\tv349 = ~v916;\n\tif (v349) goto L_00AB;\n\tthrow System.NullReferenceException;\nL_006F:\n\t// 111 NewArr v358 @ X0_v55 (System.Object[]), typeof(System.Object[]), 1\n\tv193 = v56.taskId;\n\t// 119 Box v178 @ X0_v57 (EasyMobile.Internal.Gif.Android.AndroidNativeGif+<>c__DisplayClass21_0), typeof(System.Int32), &v193 @ X8_v48 (System.Int32)\n\tv434 = v178 == 0;\n\tif (v434) goto L_0086;\n\t// 128 IsInst v445 @ X0_v64, typeof(System.Object), v178 @ X0_v57 (EasyMobile.Internal.Gif.Android.AndroidNativeGif+<>c__DisplayClass21_0)\n\tv449 = v445 == 0;\n\tif (v449) goto L_01A2;\nL_0086:\n\tv358[0] = v178;\n\tgoto L_0098;\n\tv605 = *([v479 @ X0_v59+E0]);\n\tv606 = v605 == 0;\n\tv607 = ~v606;\n\tif (v607) goto L_0098;\n\tv609 = \"il2cpp_codegen_runtime_class_init\"(v479, v446, v168, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0098:\n\tUnityEngine.Debug::LogErrorFormat(\"Complete decoding GIF image with invalid task ID {0}. Please check!\", v358);\nL_00A4:\n\treturn;\nL_00A5:\n\tv917 = v556.imageDataHandles == 0;\n\tif (v917) goto L_0155;\nL_00AB:\n\t// 171 NewArr v851 @ X0_v97 (UnityEngine.Color32[][]), typeof(UnityEngine.Color32[][]), v353.Length\n\tv56.imageData = v851;\n\tv855 = v556.frameMetadataHandles;\n\t// 180 NewArr v1006 @ X0_v99 (EasyMobile.Internal.Gif.GifFrameMetadata[]), typeof(EasyMobile.Internal.Gif.GifFrameMetadata[]), v855.Length\n\tv56.gifFrameMetadata = v1006;\n\tv1073 = v556.frameMetadataHandles;\nL_00C6:\n\tv1084 = v1059 >= v1073.Length;\n\tif (v1084) goto L_0103;\n\tv1110 = v1059 < v1073.Length;\n\tv1111 = ~v1110;\n\tif (v1111) goto L_0185;\n\tv1018 = v56.gifFrameMetadata;\n\tv1144 = v1059 << 2;\n\tv193 = v1073 + v1144;\n\tv1146 = v193 + 0x20;\n\tv1148 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v1146, 0);\n\tv1022 = v1022_asT == 0;\n\tif (v1022) goto L_018C;\n\tv1044 = \"il2cpp_vm_object_unbox\"(v1148, EasyMobile.Internal.Gif.GifFrameMetadata, Il2CppMethodInfo, v67, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv193 = v1018.Length;\n\tv1297 = v1059 < v1018.Length;\n\tv1038 = ~v1297;\n\tif (v1038) goto L_018D;\n\tv193 = *([v1044 @ X0_v149]);\n\tv1013 = v1059 << 3;\n\tv1040 = v1018 + v1013;\n\tv1059 = v1059 + 1;\n\t*([v1040 @ X9_v44+20]) = *([v1044 @ X0_v149]);\n\tv1073 = v556.frameMetadataHandles;\n\tv1333 = v556.frameMetadataHandles == 0;\n\tv1046 = ~v1333;\n\tif (v1046) goto L_00C6;\n\tv1050 = new System.NullReferenceException();\nL_0103:\n\tv977 = v556.imageDataHandles;\nL_0113:\n\tv688 = v682 >= v977.Length;\n\tif (v688) goto L_0155;\n\tv1170 = v682 < v977.Length;\n\tv704 = ~v1170;\n\tif (v704) goto L_0191;\n\tv678 = v56.imageData;\n\tv676 = v682 << 2;\n\tv193 = v977 + v676;\n\tv1183 = v193 + 0x20;\n\tv1185 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v1183, 0);\n\tv1271 = v1185 == 0;\n\tif (v1271) goto L_FFFFFFFF;\n\t// 302 IsInst v1305 @ X0_v125, typeof(UnityEngine.Color32[]), v1185 @ X0_v121 (EasyMobile.Internal.Gif.GifDecodeResources)\n\tv1334 = v1305 == 0;\n\tif (v1334) goto L_019D;\n\t// 307 IsInst v1343 @ X0_v126, typeof(UnityEngine.Color32[]), v1305 @ X0_v125\n\tv1371 = v1343 == 0;\n\tif (v1371) goto L_019E;\n\t// 313 IsInst v1134 @ X0_v122 (System.Int32), typeof(UnityEngine.Color32[]), v1185 @ X0_v121 (EasyMobile.Internal.Gif.GifDecodeResources)\n\tv1377 = v1134 == 0;\n\tv714 = ~v1377;\n\tif (v714) goto L_013F;\n\tgoto L_01A6;\nL_013F:\n\tv193 = v678.Length;\n\tv1338 = v682 < v678.Length;\n\tv1131 = ~v1338;\n\tif (v1131) goto L_0197;\n\tv678[v682 @ X23_v32 (System.Int32)] = v1134;\n\tv977 = v556.imageDataHandles;\n\tv682 = v682 + 1;\n\tv1370 = v556.imageDataHandles == 0;\n\tv1135 = ~v1370;\n\tif (v1135) goto L_0113;\n\tthrow System.NullReferenceException;\nL_0155:\n\tv979 = v556.completeCallback == 0;\n\tif (v979) goto L_0181;\n\tv988 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif+<>c__DisplayClass21_1();\n\tSystem.Object::.ctor(v988);\n\tv903 = v988 == 0;\n\tif (v903) goto L_01AD;\n\tv988.CS$<>8__locals1 = v56;\n\tv988.callback = v556.completeCallback;\n\tv1055 = new System.Action();\n\tSystem.Action::.ctor(v1055, v988, Il2CppMethodInfo);\n\tgoto L_017E;\n\tv1161 = *([v1140 @ X0_v92+E0]);\n\tv1162 = v1161 == 0;\n\tv1163 = ~v1162;\n\tif (v1163) goto L_017E;\n\tv1165 = \"il2cpp_codegen_runtime_class_init\"(v1140, v1109, v993, v989, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_017E:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v1055);\nL_0181:\n\tv999 = v556 == 0;\n\tv184 = ~v999;\n\tif (v184) goto L_01DD;\n\tgoto L_FFFFFFFF;\nL_0185:\n\tv1149 = new System.IndexOutOfRangeException();\n\tthrow v1149;\n\tv1181 = new System.NullReferenceException();\n\tv1247 = new System.NullReferenceException();\nL_018C:\n\tv1270 = new System.InvalidCastException();\nL_018D:\n\tv1301 = new System.IndexOutOfRangeException();\n\tthrow v1301;\nL_0191:\n\tv1226 = new System.IndexOutOfRangeException();\n\tthrow v1226;\n\tv1295 = new System.NullReferenceException();\nL_0197:\n\tv1331 = new System.IndexOutOfRangeException();\n\tthrow v1331;\nL_019D:\n\tv1368 = new System.InvalidCastException();\nL_019E:\n\tv1375 = new System.ArrayTypeMismatchException();\n\tthrow v1375;\nL_01A2:\n\tv604 = new System.ArrayTypeMismatchException();\n\tgoto L_FFFFFFFF;\nL_01A6:\n\tv712 = new System.InvalidCastException();\n\tv717 = new System.NullReferenceException();\n\tv760 = new System.NullReferenceException();\nL_01A9:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_01AD:\n\tv473 = new System.NullReferenceException();\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\n\tgoto L_01C5;\nL_01C5:\n\tv298 = 0 == 1;\n\tif (v298) goto L_0259;\nL_01D5:\n\tv106 = v409 != 1;\n\tif (v106) goto L_0281;\n\tv553 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v473, v409);\n\tv243 = *([v553 @ X0_v46 (EasyMobile.Internal.Gif.GifDecodeResources)]);\n\tv180 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::get_Item(v553, v409);\nL_01DD:\n\tv735 = v541 + 0x10;\n\tv884 = 0xF75014(v735, 0, v247, v207, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv495 = v541.frameMetadataHandles;\n\tv538 = v541.frameMetadataHandles == 0;\n\tif (v538) goto L_0210;\n\tv193 = v495.Length;\n\tv800 = v495.Length < 1;\n\tif (v800) goto L_0210;\nL_01FB:\n\tv803 = v498 << 2;\n\tv193 = v541.frameMetadataHan\n// ... truncated")]
		private static void GifDecodingCompleteCallback(int taskId)
		{
			//IL_0aeb: Expected I, but got O
			//IL_00e2: Expected O, but got I
			//IL_06e3: Expected I, but got O
			//IL_08a3: Expected O, but got I
			//IL_0709: Expected O, but got I4
			//IL_0653: Expected I, but got O
			//IL_0b21: Expected I, but got O
			//IL_06b0: Expected O, but got I4
			//IL_0c3a: Expected O, but got I4
			//IL_0347: Expected O, but got I4
			//IL_0c70: Expected I, but got O
			//IL_0bb0: Expected O, but got I
			//IL_0870: Expected I, but got O
			//IL_0beb: Expected I, but got O
			//IL_04c9: Expected O, but got I4
			//IL_03d2: Expected I4, but got O
			//IL_03ee: Expected O, but got I
			//IL_05aa: Expected O, but got I4
			//IL_055e: Expected I4, but got O
			_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_2 = new _003C_003Ec__DisplayClass21_0();
			_003C_003Ec__DisplayClass21_2.taskId = taskId;
			Dictionary<int, GifDecodeResources> decodeTasks = DecodeTasks;
			GifDecodeResources gifDecodeResources2;
			int num3;
			if (decodeTasks.ContainsKey(_003C_003Ec__DisplayClass21_2.taskId))
			{
				Dictionary<int, GifDecodeResources> decodeTasks2 = DecodeTasks;
				GifDecodeResources gifDecodeResources = decodeTasks2.get_Item(_003C_003Ec__DisplayClass21_2.taskId);
				if (gifDecodeResources != null)
				{
					Dictionary<int, GifDecodeResources> decodeTasks3 = DecodeTasks;
					gifDecodeResources2 = decodeTasks3.get_Item(_003C_003Ec__DisplayClass21_2.taskId);
					_003C_003Ec__DisplayClass21_2.gifFrameMetadata = null;
					_003C_003Ec__DisplayClass21_2.imageData = null;
					Dictionary<int, GifDecodeResources> dictionary = (Dictionary<int, GifDecodeResources>)((long)(IntPtr)gifDecodeResources2 + 16L);
					GifDecodeResources gifDecodeResources3 = dictionary.get_Item(0);
					GifMetadata gifMetadata = (GifMetadata)((gifDecodeResources3 is GifMetadata) ? gifDecodeResources3 : null);
					if ((object)gifMetadata != null)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object gifMetadata2 = default(object);
						_003C_003Ec__DisplayClass21_2.gifMetadata = (GifMetadata)gifMetadata2;
						ref GifMetadata reference = ref _003C_003Ec__DisplayClass21_2.gifMetadata;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ X0_v83+8]");
						reference.frameCount = 0;
						GCHandle[] imageDataHandles = gifDecodeResources2.imageDataHandles;
						if (gifDecodeResources2.frameMetadataHandles != null)
						{
							if (gifDecodeResources2.imageDataHandles == null)
							{
								throw new NullReferenceException();
							}
						}
						else if (gifDecodeResources2.imageDataHandles == null)
						{
							goto IL_05f8;
						}
						Color32[][] imageData = new Color32[imageDataHandles.Length][];
						_003C_003Ec__DisplayClass21_2.imageData = imageData;
						GCHandle[] frameMetadataHandles = gifDecodeResources2.frameMetadataHandles;
						GifFrameMetadata[] gifFrameMetadata = new GifFrameMetadata[frameMetadataHandles.Length];
						_003C_003Ec__DisplayClass21_2.gifFrameMetadata = gifFrameMetadata;
						GCHandle[] frameMetadataHandles2 = gifDecodeResources2.frameMetadataHandles;
						int num = 0;
						object obj = default(object);
						while (num < frameMetadataHandles2.Length)
						{
							if (num < frameMetadataHandles2.Length)
							{
								GifFrameMetadata[] array = _003C_003Ec__DisplayClass21_2.gifFrameMetadata;
								int num2 = num << 2;
								num3 = (int)((long)(IntPtr)frameMetadataHandles2 + (long)num2);
								Dictionary<int, GifDecodeResources> dictionary2 = (Dictionary<int, GifDecodeResources>)(num3 + 32);
								GifDecodeResources gifDecodeResources4 = dictionary2.get_Item(0);
								GifFrameMetadata gifFrameMetadata2 = (GifFrameMetadata)((gifDecodeResources4 is GifFrameMetadata) ? gifDecodeResources4 : null);
								if ((object)gifFrameMetadata2 != null)
								{
									Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									num3 = array.Length;
									if (num < array.Length)
									{
										num3 = (int)obj;
										int num4 = num << 3;
										object obj2 = (long)(IntPtr)array + (long)num4;
										num++;
										frameMetadataHandles2 = gifDecodeResources2.frameMetadataHandles;
										if (gifDecodeResources2.frameMetadataHandles == null)
										{
											NullReferenceException ex = new NullReferenceException();
											break;
										}
										continue;
									}
								}
								else
								{
									InvalidCastException ex2 = new InvalidCastException();
								}
								IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
								throw ex3;
							}
							IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
							throw ex4;
						}
						GCHandle[] imageDataHandles2 = gifDecodeResources2.imageDataHandles;
						int num5 = 0;
						while (num5 < imageDataHandles2.Length)
						{
							Color32[][] array2;
							int num7;
							if (num5 < imageDataHandles2.Length)
							{
								array2 = _003C_003Ec__DisplayClass21_2.imageData;
								int num6 = num5 << 2;
								num3 = (int)((long)(IntPtr)imageDataHandles2 + (long)num6);
								Dictionary<int, GifDecodeResources> dictionary3 = (Dictionary<int, GifDecodeResources>)(num3 + 32);
								GifDecodeResources gifDecodeResources5 = dictionary3.get_Item(0);
								if (gifDecodeResources5 != null)
								{
									object obj3 = gifDecodeResources5 as Color32[];
									if (obj3 != null)
									{
										object obj4 = obj3 as Color32[];
										if (obj4 != null)
										{
											num7 = (int)(gifDecodeResources5 as Color32[]);
											if (num7 == 0)
											{
												goto IL_0786;
											}
											goto IL_0cb3;
										}
									}
									else
									{
										InvalidCastException ex5 = new InvalidCastException();
									}
									ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
									throw ex6;
								}
								num7 = 0;
								goto IL_0cb3;
							}
							IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
							throw ex7;
							IL_0cb3:
							num3 = array2.Length;
							if (num5 < array2.Length)
							{
								array2[num5] = (Color32[])num7;
								imageDataHandles2 = gifDecodeResources2.imageDataHandles;
								num5++;
								if (gifDecodeResources2.imageDataHandles == null)
								{
									throw new NullReferenceException();
								}
								continue;
							}
							IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
							throw ex8;
						}
						goto IL_05f8;
					}
					goto IL_07b0;
				}
			}
			object[] array3 = new object[1];
			num3 = _003C_003Ec__DisplayClass21_2.taskId;
			_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_3 = (_003C_003Ec__DisplayClass21_0)(object)num3;
			if (_003C_003Ec__DisplayClass21_3 != null)
			{
				object obj5 = _003C_003Ec__DisplayClass21_3 as object;
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
					goto IL_0ae6;
				}
			}
			array3[0] = _003C_003Ec__DisplayClass21_3;
			Debug.LogErrorFormat("Complete decoding GIF image with invalid task ID {0}. Please check!", array3);
			return;
			IL_0ae6:
			IntPtr intPtr = (IntPtr)null;
			throw new TypeLoadException();
			IL_0786:
			InvalidCastException ex10 = new InvalidCastException();
			NullReferenceException ex11 = new NullReferenceException();
			NullReferenceException ex12 = new NullReferenceException();
			goto IL_07b0;
			IL_0b08:
			NullReferenceException ex13;
			int key;
			GifDecodeResources gifDecodeResources6 = ((Dictionary<int, GifDecodeResources>)(object)ex13).get_Item(key);
			IntPtr intPtr2 = (IntPtr)gifDecodeResources6;
			int key2 = (int)(long)intPtr2;
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
			Dictionary<int, GifDecodeResources> dictionary4 = default(Dictionary<int, GifDecodeResources>);
			int num8 = (int)((long)(IntPtr)dictionary4 & 1L);
			bool flag = num8 == 0;
			object obj7;
			object obj6 = obj7;
			GifDecodeResources gifDecodeResources7 = gifDecodeResources6;
			IntPtr intPtr3 = intPtr;
			GifDecodeResources gifDecodeResources9;
			GifDecodeResources gifDecodeResources8 = gifDecodeResources9;
			_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_5;
			_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_4 = _003C_003Ec__DisplayClass21_5;
			string text2;
			IntPtr intPtr4;
			NullReferenceException ex15;
			if (!flag)
			{
				GifDecodeResources gifDecodeResources10 = dictionary4.get_Item((int)(long)intPtr2);
				string text = "Error casting GCHandle back to decoding buffer:" + (long)intPtr2;
				Debug.LogError(text);
				TypeLoadException ex14 = new TypeLoadException();
				obj6 = obj7;
				text2 = text;
				intPtr3 = (IntPtr)0;
				intPtr4 = (IntPtr)null;
				ex15 = (NullReferenceException)(object)ex14;
				gifDecodeResources8 = gifDecodeResources9;
				_003C_003Ec__DisplayClass21_4 = _003C_003Ec__DisplayClass21_5;
				goto IL_0c08;
			}
			goto IL_0c2c;
			IL_05f8:
			bool flag2 = gifDecodeResources2.completeCallback == null;
			object obj8 = default(object);
			obj6 = obj8;
			intPtr3 = (IntPtr)0;
			if (!flag2)
			{
				_003C_003Ec__DisplayClass21_1 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass21_1();
				bool flag3 = CS_0024_003C_003E8__locals6 == null;
				gifDecodeResources7 = (GifDecodeResources)(object)CS_0024_003C_003E8__locals6;
				intPtr4 = (IntPtr)null;
				if (flag3)
				{
					ex15 = new NullReferenceException();
					bool flag4 = 0 == 1;
					obj6 = obj8;
					intPtr3 = (IntPtr)0;
					gifDecodeResources8 = gifDecodeResources2;
					_003C_003Ec__DisplayClass21_4 = _003C_003Ec__DisplayClass21_2;
					obj7 = obj8;
					intPtr = (IntPtr)0;
					key = 0;
					ex13 = ex15;
					gifDecodeResources9 = gifDecodeResources2;
					_003C_003Ec__DisplayClass21_5 = _003C_003Ec__DisplayClass21_2;
					if (!flag4)
					{
						goto IL_082f;
					}
					goto IL_0b08;
				}
				CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass21_2;
				CS_0024_003C_003E8__locals6.callback = gifDecodeResources2.completeCallback;
				Action action = delegate
				{
					//IL_0043: Expected O, but got I4
					_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_6 = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals1;
					CS_0024_003C_003E8__locals6.callback(_003C_003Ec__DisplayClass21_6.taskId, _003C_003Ec__DisplayClass21_6.gifMetadata, (GifFrameMetadata[])_003C_003Ec__DisplayClass21_6.gifMetadata.frameCount, (Color32[][])(object)_003C_003Ec__DisplayClass21_6.gifFrameMetadata);
				};
				RuntimeHelper.RunOnMainThread(action);
				obj6 = 0;
				intPtr3 = (IntPtr)0;
			}
			bool flag5 = gifDecodeResources2 == null;
			bool flag6 = !flag5;
			int num9 = 0;
			IntPtr intPtr5 = (IntPtr)null;
			gifDecodeResources8 = gifDecodeResources2;
			_003C_003Ec__DisplayClass21_4 = _003C_003Ec__DisplayClass21_2;
			if (flag6)
			{
				goto IL_0894;
			}
			gifDecodeResources9 = (GifDecodeResources)taskId;
			_003C_003Ec__DisplayClass21_5 = _003C_003Ec__DisplayClass21_2;
			obj7 = obj8;
			key = 0;
			ex13 = new NullReferenceException();
			goto IL_0b08;
			IL_0c2c:
			GifDecodeResources gifDecodeResources11 = ((Dictionary<int, GifDecodeResources>)8).get_Item(key2);
			gifDecodeResources11 = gifDecodeResources7;
			intPtr4 = (IntPtr)(32022528 + 2160);
			ex15 = (NullReferenceException)(object)((Dictionary<int, GifDecodeResources>)(object)gifDecodeResources11).get_Item((int)(long)intPtr4);
			intPtr3 = (IntPtr)null;
			goto IL_082f;
			IL_07b0:
			throw new InvalidCastException();
			IL_0894:
			object obj9 = (long)(IntPtr)gifDecodeResources8 + 16L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F75014 (inside System.Runtime.InteropServices.GCHandle::Alloc +0x28)");
			GCHandle[] frameMetadataHandles3 = gifDecodeResources8.frameMetadataHandles;
			if (gifDecodeResources8.frameMetadataHandles != null)
			{
				num3 = frameMetadataHandles3.Length;
				if (frameMetadataHandles3.Length >= 1)
				{
					int num10 = 0;
					do
					{
						int num11 = num10 << 2;
						num3 = (int)((long)(IntPtr)gifDecodeResources8.frameMetadataHandles + (long)num11);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X8_v48 (System.Int32)+20]");
						num3 = 0;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F75014 (inside System.Runtime.InteropServices.GCHandle::Alloc +0x28)");
						num3 = frameMetadataHandles3.Length;
						num10++;
					}
					while (num10 < frameMetadataHandles3.Length);
				}
			}
			GCHandle[] imageDataHandles3 = gifDecodeResources8.imageDataHandles;
			if (gifDecodeResources8.imageDataHandles != null)
			{
				num3 = imageDataHandles3.Length;
				if (imageDataHandles3.Length >= 1)
				{
					int num12 = 0;
					do
					{
						int num13 = num12 << 2;
						num3 = (int)((long)(IntPtr)gifDecodeResources8.imageDataHandles + (long)num13);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X8_v48 (System.Int32)+20]");
						num3 = 0;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F75014 (inside System.Runtime.InteropServices.GCHandle::Alloc +0x28)");
						num3 = imageDataHandles3.Length;
						num12++;
					}
					while (num12 < imageDataHandles3.Length);
				}
			}
			Dictionary<int, GifDecodeResources> decodeTasks4 = DecodeTasks;
			bool flag7 = decodeTasks4.Remove(_003C_003Ec__DisplayClass21_4.taskId);
			if (num9 + 1 != 0 || intPtr5 == (IntPtr)0)
			{
				return;
			}
			goto IL_0ae6;
			IL_0c08:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			gifDecodeResources7 = (GifDecodeResources)(object)text2;
			key2 = (int)(long)intPtr4;
			goto IL_0c2c;
			IL_082f:
			bool flag8 = intPtr4 != (IntPtr)1;
			text2 = (string)(object)gifDecodeResources7;
			if (!flag8)
			{
				GifDecodeResources gifDecodeResources12 = ((Dictionary<int, GifDecodeResources>)(object)ex15).get_Item((int)(long)intPtr4);
				intPtr5 = (IntPtr)gifDecodeResources12;
				GifDecodeResources gifDecodeResources13 = ((Dictionary<int, GifDecodeResources>)(object)gifDecodeResources12).get_Item((int)(long)intPtr4);
				num9 = -1;
				goto IL_0894;
			}
			goto IL_0c08;
		}

		[Token(Token = "0x60008F8")]
		[Address(RVA = "0xBFE128", Offset = "0xBFE128", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif::DecodeGif(taskId, filepath, 0xFFFFFFFF, workerPriority, completeCallback);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void DecodeGif(int taskId, string filepath, ThreadPriority workerPriority, DecodeCompleteCallback completeCallback)
		{
			DecodeGif(taskId, filepath, -1, workerPriority, completeCallback);
		}

		[Token(Token = "0x60008F9")]
		[Address(RVA = "0xBF2768", Offset = "0xBF2768", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EDAE58]);\n\tv35 = *([v34 @ X8_v12]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, filepath, framesToRead, workerPriority, completeCallback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022F65]) = v50;\nL_001E:\n\tv54 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif();\n\tSystem.Object::.ctor(v54);\n\tv54.mDecodeTask = taskId;\n\t*([v54 @ X0_v3 (EasyMobile.Internal.Gif.Android.AndroidNativeGif)+1C]) = 0;\n\tv54.mDecodeTask.filepath = filepath;\n\tv54.mDecodeTask.framesToRead = framesToRead;\n\tv54.mDecodeTask.threadPriority = workerPriority;\n\tv54.mDecodeTask.completeCallback = completeCallback;\n\tv60 = new System.Threading.ThreadStart();\n\tSystem.Threading.ThreadStart::.ctor(v60, v54, Il2CppMethodInfo);\n\tv70 = new System.Threading.Thread();\n\tSystem.Threading.Thread::.ctor(v70, v60);\n\tSystem.Threading.Thread::set_Priority(v70, workerPriority);\n\tSystem.Threading.Thread::Start(v70);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void DecodeGif(int taskId, string filepath, int framesToRead, ThreadPriority workerPriority, DecodeCompleteCallback completeCallback)
		{
			//IL_004b: Expected O, but got I4
			AndroidNativeGif androidNativeGif = null;
			androidNativeGif.mDecodeTask = (GifDecodeTask)taskId;
			_ = 0;
			androidNativeGif.mDecodeTask.filepath = filepath;
			androidNativeGif.mDecodeTask.framesToRead = framesToRead;
			androidNativeGif.mDecodeTask.threadPriority = workerPriority;
			androidNativeGif.mDecodeTask.completeCallback = completeCallback;
			ThreadStart start = androidNativeGif.DoDecodeGif;
			Thread thread = new Thread(start);
			thread.Priority = workerPriority;
			thread.Start();
		}

		[Token(Token = "0x60008FA")]
		[Address(RVA = "0xBFE140", Offset = "0xBFE140", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv28 = *([1EE5568]);\n\tv29 = *([v28 @ X8_v26]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022F66]) = v48;\nL_0020:\n\tv56 = 0;\n\t// 34 Box v59 @ X0_v3 (System.Object), typeof(EasyMobile.Internal.Gif.GifMetadata), &v56 @ stack_-60_v1\n\tv62 = System.Runtime.InteropServices.GCHandle::Alloc(v59, 3);\n\tv65 = EasyMobile.Internal.Gif.Android.AndroidNativeGif::get_DecodeTasks();\n\tv71 = new EasyMobile.Internal.Gif.GifDecodeResources();\n\tSystem.Object::.ctor(v71);\n\t*([v71 @ X0_v7 (System.Object)+10]) = v62;\n\t*([v71 @ X0_v7 (System.Object)+28]) = this.mDecodeTask.completeCallback;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::set_Item(v65, this.mDecodeTask, v71);\n\tv87 = System.Collections.Generic.Dictionary`2<System.Int32, EasyMobile.Internal.Gif.GifDecodeResources>::set_Item(&v62 @ X0_v4 (System.Runtime.InteropServices.GCHandle), 0, v71);\n\tv134 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif+C+NativeGetFrameMetadataHolderDelegate();\n\tv138 = Il2CppMethodInfo;\n\tv134.m_target = 0;\n\tv134.method = Il2CppMethodInfo;\n\tv134.method_ptr = *([v138 @ X8_v15 (Il2CppMethodInfo)]);\n\tv143 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif+C+NativeGetImageDataHolderDelegate();\n\tv147 = Il2CppMethodInfo;\n\tv143.m_target = 0;\n\tv143.method = Il2CppMethodInfo;\n\tv143.method_ptr = *([v147 @ X8_v20 (Il2CppMethodInfo)]);\n\tv152 = new EasyMobile.Internal.Gif.Android.AndroidNativeGif+C+NativeGifDecodingCompletedDelegate();\n\tv106 = Il2CppMethodInfo;\n\tv152.m_target = 0;\n\tv152.method = Il2CppMethodInfo;\n\tv152.method_ptr = *([v106 @ X9_v5 (Il2CppMethodInfo)]);\n\tEasyMobile.Internal.Gif.Android.AndroidNativeGif+C::_DecodeGif(this.mDecodeTask, this.mDecodeTask.filepath, this.mDecodeTask.framesToRead, v87, v134, v143, v152);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoDecodeGif()
		{
			//IL_012c: Expected O, but got I4
			//IL_003d: Expected I4, but got O
			//IL_011d: Expected I4, but got O
			object obj = 0;
			object value = (GifMetadata)obj;
			GCHandle gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
			Dictionary<int, GifDecodeResources> decodeTasks = DecodeTasks;
			object value2 = new GifDecodeResources();
			_ = mDecodeTask.completeCallback;
			decodeTasks.set_Item((int)mDecodeTask, (GifDecodeResources)value2);
			((Dictionary<int, GifDecodeResources>)gCHandle).set_Item(0, (GifDecodeResources)value2);
			C.NativeGetFrameMetadataHolderDelegate nativeGetFrameMetadataHolderDelegate = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)nativeGetFrameMetadataHolderDelegate).m_target = null;
			((Delegate)nativeGetFrameMetadataHolderDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<int, int, IntPtr, void>*/)(&GetFrameMetadataHolderFunc);
			((Delegate)nativeGetFrameMetadataHolderDelegate).method_ptr = method_ptr;
			C.NativeGetImageDataHolderDelegate nativeGetImageDataHolderDelegate = null;
			IntPtr method_ptr2 = (IntPtr)0;
			((Delegate)nativeGetImageDataHolderDelegate).m_target = null;
			((Delegate)nativeGetImageDataHolderDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<int, int, int, int, IntPtr, void>*/)(&GetImageDataHolderFunc);
			((Delegate)nativeGetImageDataHolderDelegate).method_ptr = method_ptr2;
			C.NativeGifDecodingCompletedDelegate nativeGifDecodingCompletedDelegate = null;
			IntPtr method_ptr3 = (IntPtr)0;
			((Delegate)nativeGifDecodingCompletedDelegate).m_target = null;
			((Delegate)nativeGifDecodingCompletedDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<int, void>*/)(&GifDecodingCompleteCallback);
			((Delegate)nativeGifDecodingCompletedDelegate).method_ptr = method_ptr3;
			IntPtr gifMetadataBuff = default(IntPtr);
			C._DecodeGif((int)mDecodeTask, mDecodeTask.filepath, mDecodeTask.framesToRead, gifMetadataBuff, nativeGetFrameMetadataHolderDelegate, nativeGetImageDataHolderDelegate, nativeGifDecodingCompletedDelegate);
		}
	}
}
