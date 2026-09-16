using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Media
{
	[Token(Token = "0x20000F2")]
	internal class AndroidDeviceCamera : IDeviceCamera
	{
		[Token(Token = "0x4000449")]
		private const string NativeClassName = "com.sglib.easymobile.androidnative.media.DeviceCamera";

		[Token(Token = "0x400044A")]
		private const string NativeIsCameraAvailableName = "isCameraAvailable";

		[Token(Token = "0x400044B")]
		private const string NativeTakePicktureName = "takePicture";

		[Token(Token = "0x400044C")]
		private const string NativeRecordVideoName = "recordVideo";

		[Token(Token = "0x400044D")]
		private const string CantCreateNativeCameraMessage = "The native camera object coundn't be initialized.";

		[Token(Token = "0x400044E")]
		private const string CameraUnsupportedDeviceMessage = " camera is not supported on this device.";

		[Token(Token = "0x400044F")]
		[FieldOffset(Offset = "0x10")]
		private AndroidJavaObject NativeCamera;

		[Token(Token = "0x60008B7")]
		[Address(RVA = "0xC00838", Offset = "0xC00838", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EE9030]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F97]) = v40;\nL_0016:\n\tSystem.Object::.ctor(this);\n\tv47 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv52 = v47;\n\tv53 = 0x8907BC(v52, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv57 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0045;\n\tv60 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv82 = v60;\n\tv83 = 0x8907BC(v82, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv84 = *([v60 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv70 = ~v84;\n\tif (v70) goto L_0045;\n\tgoto L_0045;\n\tv103 = v75;\n\tv104 = 0x8907BC(v103, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tgoto L_004D;\n\tv85 = v77;\n\tv86 = 0x8907BC(v85, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004D:\n\tv93 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v93, \"com.sglib.easymobile.androidnative.media.DeviceCamera\", v89.Value);\n\tthis.NativeCamera = v93;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidDeviceCamera()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			NativeCamera = new AndroidJavaObject("com.sglib.easymobile.androidnative.media.DeviceCamera");
		}

		[Token(Token = "0x60008B8")]
		[Address(RVA = "0xC00948", Offset = "0xC00948", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EBB878]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, cameraType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022F98]) = v41;\nL_0016:\n\tv43 = this.NativeCamera == 0;\n\tif (v43) goto L_0043;\n\t// 28 NewArr v48 @ X0_v10 (System.Object[]), typeof(System.Object[]), 1\n\t// 35 Box v61 @ X0_v12, typeof(System.Int32), &cameraType @ X1 (EasyMobile.CameraType)\n\tv76 = v61 == 0;\n\tif (v76) goto L_0030;\n\t// 44 IsInst v107 @ X0_v23, typeof(System.Object), v61 @ X0_v12\nL_0030:\n\tv93 = v48.Length == 0;\n\tif (v93) goto L_0059;\n\tv48[0] = v61;\n\tv90 = UnityEngine.AndroidJavaObject::Call(this.NativeCamera, \"isCameraAvailable\", v48);\n\tgoto L_0056;\nL_0043:\n\tgoto L_004D;\n\tv62 = *([v51 @ X0_v4+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_004D;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v51, cameraType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004D:\n\tUnityEngine.Debug::LogError(\"The native camera object coundn't be initialized.\");\nL_0056:\n\treturn v90;\n\tv78 = new System.NullReferenceException();\nL_0059:\n\tv118 = new System.IndexOutOfRangeException();\n\tgoto L_005E;\n\tv140 = new System.ArrayTypeMismatchException();\nL_005E:\n\tthrow v142;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsCameraAvailable(CameraType cameraType)
		{
			if (NativeCamera != null)
			{
				object[] array = new object[1];
				object obj = (int)cameraType;
				if (obj != null)
				{
					object obj2 = obj as object;
				}
				if (array.Length != 0)
				{
					array[0] = obj;
					return NativeCamera.Call<bool>("isCameraAvailable", array);
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			Debug.LogError("The native camera object coundn't be initialized.");
			return false;
		}

		[Token(Token = "0x60008B9")]
		[Address(RVA = "0xC00A7C", Offset = "0xC00A7C", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EEC0F8]);\n\tv27 = *([v26 @ X8_v33]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, cameraType, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022F99]) = v44;\nL_0018:\n\tv46 = this.NativeCamera == 0;\n\tif (v46) goto L_0063;\n\tv49 = EasyMobile.Internal.NativeAPIs.Media.AndroidDeviceCamera::IsCameraAvailable(this, cameraType);\n\tv52 = v49 == 0;\n\tif (v52) goto L_0076;\n\t// 37 NewArr v134 @ X0_v11 (System.Object[]), typeof(System.Object[]), 2\n\t// 44 Box v179 @ X0_v13, typeof(System.Int32), &cameraType @ X1 (EasyMobile.CameraType)\n\tv192 = v179 == 0;\n\tif (v192) goto L_0039;\n\t// 53 IsInst v216 @ X0_v31, typeof(System.Object), v179 @ X0_v13\nL_0039:\n\tv223 = v134.Length == 0;\n\tif (v223) goto L_0092;\n\tv134[0] = v179;\n\tv246 = new EasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy::.ctor(v246, callback);\n\tv266 = v246 == 0;\n\tif (v266) goto L_004C;\n\t// 72 IsInst v236 @ X0_v29, typeof(System.Object), v246 @ X0_v25 (EasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy)\nL_004C:\n\tv269 = v134.Length < 1;\n\tv102 = ~v269;\n\tv99 = v134.Length - 1;\n\tv93 = v99 == 0;\n\tv270 = ~v102;\n\tv78 = v270 | v93;\n\tif (v78) goto L_0092;\n\tv134[1] = v246;\n\tUnityEngine.AndroidJavaObject::Call(this.NativeCamera, \"takePicture\", v134);\n\tgoto L_0091;\nL_0063:\n\tv50 = callback == 0;\n\tif (v50) goto L_0091;\n\tSystem.Action`2<System.String, EasyMobile.MediaResult>::Invoke(callback, \"The native camera object coundn't be initialized.\", 0);\n\treturn;\nL_0076:\n\tv113 = callback == 0;\n\tif (v113) goto L_0091;\n\t// 125 Box v184 @ X0_v7 (System.Object), typeof(EasyMobile.CameraType), &cameraType @ X1 (EasyMobile.CameraType)\n\tv191 = System.String::Concat(v184, \" camera is not supported on this device.\");\n\tSystem.Action`2<System.String, EasyMobile.MediaResult>::Invoke(callback, v191, 0);\nL_0091:\n\treturn;\nL_0092:\n\tv262 = new System.IndexOutOfRangeException();\n\tgoto L_0099;\n\tv211 = new System.NullReferenceException();\n\tv242 = new System.ArrayTypeMismatchException();\nL_0099:\n\tthrow v264;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TakePicture(CameraType cameraType, Action<string, MediaResult> callback)
		{
			//IL_011e: Expected O, but got I4
			if (NativeCamera != null)
			{
				if (IsCameraAvailable(cameraType))
				{
					object[] array = new object[2];
					object obj = (int)cameraType;
					if (obj != null)
					{
						object obj2 = obj as object;
					}
					if (array.Length != 0)
					{
						array[0] = obj;
						AndroidMediaCollectedProxy androidMediaCollectedProxy = new AndroidMediaCollectedProxy(callback);
						if (androidMediaCollectedProxy != null)
						{
							object obj3 = androidMediaCollectedProxy as object;
						}
						bool flag = array.Length < 1;
						bool flag2 = !flag;
						object obj4 = array.Length - 1;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							array[1] = androidMediaCollectedProxy;
							NativeCamera.Call("takePicture", array);
							return;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				if (callback != null)
				{
					object obj5 = cameraType;
					string arg = string.Concat(obj5, " camera is not supported on this device.");
					callback(arg, null);
				}
			}
			else
			{
				callback?.Invoke("The native camera object coundn't be initialized.", null);
			}
		}

		[Token(Token = "0x60008BA")]
		[Address(RVA = "0xC00CE0", Offset = "0xC00CE0", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EBAF38]);\n\tv27 = *([v26 @ X8_v33]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, cameraType, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022F9A]) = v44;\nL_0018:\n\tv46 = this.NativeCamera == 0;\n\tif (v46) goto L_0063;\n\tv49 = EasyMobile.Internal.NativeAPIs.Media.AndroidDeviceCamera::IsCameraAvailable(this, cameraType);\n\tv52 = v49 == 0;\n\tif (v52) goto L_0076;\n\t// 37 NewArr v134 @ X0_v11 (System.Object[]), typeof(System.Object[]), 2\n\t// 44 Box v179 @ X0_v13, typeof(System.Int32), &cameraType @ X1 (EasyMobile.CameraType)\n\tv192 = v179 == 0;\n\tif (v192) goto L_0039;\n\t// 53 IsInst v216 @ X0_v31, typeof(System.Object), v179 @ X0_v13\nL_0039:\n\tv223 = v134.Length == 0;\n\tif (v223) goto L_0092;\n\tv134[0] = v179;\n\tv246 = new EasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy::.ctor(v246, callback);\n\tv266 = v246 == 0;\n\tif (v266) goto L_004C;\n\t// 72 IsInst v236 @ X0_v29, typeof(System.Object), v246 @ X0_v25 (EasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy)\nL_004C:\n\tv269 = v134.Length < 1;\n\tv102 = ~v269;\n\tv99 = v134.Length - 1;\n\tv93 = v99 == 0;\n\tv270 = ~v102;\n\tv78 = v270 | v93;\n\tif (v78) goto L_0092;\n\tv134[1] = v246;\n\tUnityEngine.AndroidJavaObject::Call(this.NativeCamera, \"recordVideo\", v134);\n\tgoto L_0091;\nL_0063:\n\tv50 = callback == 0;\n\tif (v50) goto L_0091;\n\tSystem.Action`2<System.String, EasyMobile.MediaResult>::Invoke(callback, \"The native camera object coundn't be initialized.\", 0);\n\treturn;\nL_0076:\n\tv113 = callback == 0;\n\tif (v113) goto L_0091;\n\t// 125 Box v184 @ X0_v7 (System.Object), typeof(EasyMobile.CameraType), &cameraType @ X1 (EasyMobile.CameraType)\n\tv191 = System.String::Concat(v184, \" camera is not supported on this device.\");\n\tSystem.Action`2<System.String, EasyMobile.MediaResult>::Invoke(callback, v191, 0);\nL_0091:\n\treturn;\nL_0092:\n\tv262 = new System.IndexOutOfRangeException();\n\tgoto L_0099;\n\tv211 = new System.NullReferenceException();\n\tv242 = new System.ArrayTypeMismatchException();\nL_0099:\n\tthrow v264;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RecordVideo(CameraType cameraType, Action<string, MediaResult> callback)
		{
			//IL_011e: Expected O, but got I4
			if (NativeCamera != null)
			{
				if (IsCameraAvailable(cameraType))
				{
					object[] array = new object[2];
					object obj = (int)cameraType;
					if (obj != null)
					{
						object obj2 = obj as object;
					}
					if (array.Length != 0)
					{
						array[0] = obj;
						AndroidMediaCollectedProxy androidMediaCollectedProxy = new AndroidMediaCollectedProxy(callback);
						if (androidMediaCollectedProxy != null)
						{
							object obj3 = androidMediaCollectedProxy as object;
						}
						bool flag = array.Length < 1;
						bool flag2 = !flag;
						object obj4 = array.Length - 1;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							array[1] = androidMediaCollectedProxy;
							NativeCamera.Call("recordVideo", array);
							return;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				if (callback != null)
				{
					object obj5 = cameraType;
					string arg = string.Concat(obj5, " camera is not supported on this device.");
					callback(arg, null);
				}
			}
			else
			{
				callback?.Invoke("The native camera object coundn't be initialized.", null);
			}
		}
	}
}
