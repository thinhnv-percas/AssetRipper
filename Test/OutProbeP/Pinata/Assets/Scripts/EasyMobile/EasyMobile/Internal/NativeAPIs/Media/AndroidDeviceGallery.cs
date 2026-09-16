using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Media
{
	[Token(Token = "0x20000F3")]
	internal class AndroidDeviceGallery : IDeviceGallery
	{
		[Token(Token = "0x4000450")]
		private const string NativeClassName = "com.sglib.easymobile.androidnative.media.DeviceGallery";

		[Token(Token = "0x4000451")]
		private const string NativeSaveImageName = "saveImage";

		[Token(Token = "0x4000452")]
		private const string NativePickName = "pick";

		[Token(Token = "0x4000453")]
		private const string NativeLoadImageContentUri = "loadImageFromContentUri";

		[Token(Token = "0x4000454")]
		private const string NativeLoadImageAbsoluteUri = "loadImageFromAbsoluteUri";

		[Token(Token = "0x4000455")]
		private const string NullNativeGalleryMessage = "Couldn't create Gallery native wrapper class.";

		[Token(Token = "0x4000456")]
		private const string NullImageMessage = "Can't save a null image.";

		[Token(Token = "0x4000457")]
		private const string NullCallbackMessage = "This method won't run because the callback is null.";

		[Token(Token = "0x4000458")]
		[FieldOffset(Offset = "0x10")]
		private AndroidJavaObject nativeGallery;

		[Token(Token = "0x60008BB")]
		[Address(RVA = "0xC00EBC", Offset = "0xC00EBC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EEBFA8]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F9B]) = v40;\nL_0016:\n\tSystem.Object::.ctor(this);\n\tv47 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv52 = v47;\n\tv53 = 0x8907BC(v52, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv57 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0045;\n\tv60 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv82 = v60;\n\tv83 = 0x8907BC(v82, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv84 = *([v60 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv70 = ~v84;\n\tif (v70) goto L_0045;\n\tgoto L_0045;\n\tv103 = v75;\n\tv104 = 0x8907BC(v103, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tgoto L_004D;\n\tv85 = v77;\n\tv86 = 0x8907BC(v85, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004D:\n\tv93 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v93, \"com.sglib.easymobile.androidnative.media.DeviceGallery\", v89.Value);\n\tthis.nativeGallery = v93;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidDeviceGallery()
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
			nativeGallery = new AndroidJavaObject("com.sglib.easymobile.androidnative.media.DeviceGallery");
		}

		[Token(Token = "0x60008BC")]
		[Address(RVA = "0xC00FCC", Offset = "0xC00FCC", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F0B8C8]);\n\tv25 = *([v24 @ X8_v33]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022F9C]) = v43;\nL_0016:\n\tv44 = callback == 0;\n\tif (v44) goto L_0069;\n\tv46 = this.nativeGallery == 0;\n\tif (v46) goto L_008B;\n\t// 31 NewArr v57 @ X0_v8 (System.Object[]), typeof(System.Object[]), 2\n\tv95 = 1;\n\t// 39 Box v96 @ X0_v10, typeof(System.Boolean), &v95 @ X8_v16 (System.Int32)\n\tv169 = v96 == 0;\n\tif (v169) goto L_0033;\n\t// 48 IsInst v190 @ X0_v28, typeof(System.Object), v96 @ X0_v10\nL_0033:\n\tv95 = v57.Length;\n\tv197 = v57.Length == 0;\n\tif (v197) goto L_008D;\n\tv57[0] = v96;\n\tv201 = new EasyMobile.Internal.NativeAPIs.Media.AndroidPickFromGalleryProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidPickFromGalleryProxy::.ctor(v201, callback);\n\tv234 = v201 == 0;\n\tif (v234) goto L_0047;\n\t// 67 IsInst v225 @ X0_v26, typeof(System.Object), v201 @ X0_v22 (EasyMobile.Internal.NativeAPIs.Media.AndroidPickFromGalleryProxy)\nL_0047:\n\tv237 = v57.Length < 1;\n\tv141 = ~v237;\n\tv137 = v57.Length - 1;\n\tv129 = v137 == 0;\n\tv238 = ~v141;\n\tv109 = v238 | v129;\n\tif (v109) goto L_008D;\n\tv57[1] = v201;\n\tUnityEngine.AndroidJavaObject::Call(this.nativeGallery, \"pick\", v57);\n\treturn;\nL_0069:\n\tgoto L_007A;\n\tv72 = *([v49 @ X0_v2+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_007A;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v49, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_007A:\n\tUnityEngine.Debug::LogError(\"This method won't run because the callback is null.\");\n\treturn;\nL_008B:\n\tSystem.Action`2<System.String, EasyMobile.MediaResult[]>::Invoke(callback, \"Couldn't create Gallery native wrapper class.\", 0);\n\treturn;\nL_008D:\n\tv220 = new System.IndexOutOfRangeException();\n\tgoto L_0092;\n\tv230 = new System.ArrayTypeMismatchException();\nL_0092:\n\tthrow v233;\n\tthrow System.NullReferenceException;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pick(Action<string, MediaResult[]> callback)
		{
			//IL_0125: Expected O, but got I4
			if (callback != null)
			{
				if (nativeGallery != null)
				{
					object[] array = new object[2];
					int num = 1;
					object obj = (byte)num != 0;
					if (obj != null)
					{
						object obj2 = obj as object;
					}
					num = array.Length;
					if (array.Length != 0)
					{
						array[0] = obj;
						AndroidPickFromGalleryProxy androidPickFromGalleryProxy = new AndroidPickFromGalleryProxy(callback);
						if (androidPickFromGalleryProxy != null)
						{
							object obj3 = androidPickFromGalleryProxy as object;
						}
						bool flag = array.Length < 1;
						bool flag2 = !flag;
						object obj4 = array.Length - 1;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							array[1] = androidPickFromGalleryProxy;
							nativeGallery.Call("pick", array);
							return;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				callback("Couldn't create Gallery native wrapper class.", null);
			}
			else
			{
				Debug.LogError("This method won't run because the callback is null.");
			}
		}

		[Token(Token = "0x60008BD")]
		[Address(RVA = "0xC0120C", Offset = "0xC0120C", Length = "0x2B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1F052B8]);\n\tv35 = *([v34 @ X8_v51]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, image, name, format, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022F9D]) = v50;\nL_001B:\n\tv51 = callback == 0;\n\tif (v51) goto L_0039;\n\tgoto L_002C;\n\tv64 = *([v54 @ X0_v6+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v54, image, name, format, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_002C:\n\tv74 = UnityEngine.Object::op_Equality(image, 0);\n\tv95 = v74 == 0;\n\tif (v95) goto L_004F;\n\tgoto L_00F8;\nL_0039:\n\tgoto L_004C;\n\tv75 = *([v60 @ X0_v2+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_004C;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v60, image, name, format, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004C:\n\tUnityEngine.Debug::LogError(\"This method won't run because the callback is null.\");\n\treturn;\nL_004F:\n\tv99 = this.nativeGallery == 0;\n\tif (v99) goto L_FFFFFFFF;\n\t// 85 NewArr v204 @ X0_v12 (System.Object[]), typeof(System.Object[]), 5\n\tv209 = EasyMobile.Internal.TextureUtilities::Encode(image, format);\n\tv211 = v209 == 0;\n\tif (v211) goto L_0066;\n\t// 99 IsInst v235 @ X0_v45, typeof(System.Object), v209 @ X0_v14 (System.String)\nL_0066:\n\tv305 = v204.Length;\n\tv242 = v204.Length == 0;\n\tif (v242) goto L_00FA;\n\tv204[0] = v209;\n\tv243 = name == 0;\n\tif (v243) goto L_0073;\n\t// 111 IsInst v324 @ X0_v43, typeof(System.Object), name @ X2 (System.String)\n\tv305 = v204.Length;\nL_0073:\n\tv343 = v305 < 1;\n\tv280 = ~v343;\n\tv276 = v305 - 1;\n\tv268 = v276 == 0;\n\tv344 = ~v280;\n\tv248 = v344 | v268;\n\tif (v248) goto L_00FA;\n\tv204[1] = name;\n\t// 133 Box v351 @ X0_v27, typeof(System.Int32), &format @ X3 (EasyMobile.ImageFormat)\n\tv352 = v351 == 0;\n\tif (v352) goto L_0090;\n\t// 140 IsInst v325 @ X0_v41, typeof(System.Object), v351 @ X0_v27\nL_0090:\n\tv355 = v204.Length < 2;\n\tv278 = ~v355;\n\tv274 = v204.Length - 2;\n\tv266 = v274 == 0;\n\tv356 = ~v278;\n\tv246 = v356 | v266;\n\tif (v246) goto L_00FA;\n\tv204[2] = v351;\n\tv360 = new EasyMobile.Internal.NativeAPIs.Media.AndroidSaveImageProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidSaveImageProxy::.ctor(v360, callback);\n\tv362 = v360 == 0;\n\tif (v362) goto L_00AD;\n\t// 169 IsInst v326 @ X0_v39, typeof(System.Object), v360 @ X0_v30 (EasyMobile.Internal.NativeAPIs.Media.AndroidSaveImageProxy)\nL_00AD:\n\tv365 = v204.Length < 3;\n\tv279 = ~v365;\n\tv275 = v204.Length - 3;\n\tv267 = v275 == 0;\n\tv366 = ~v279;\n\tv247 = v366 | v267;\n\tif (v247) goto L_00FA;\n\tv204[3] = v360;\n\tv107 = 0;\n\t// 191 Box v371 @ X0_v33, typeof(System.Boolean), &v107 @ stack_-48_v5\n\tv372 = v371 == 0;\n\tif (v372) goto L_00CA;\n\t// 198 IsInst v327 @ X0_v37, typeof(System.Object), v371 @ X0_v33\nL_00CA:\n\tv375 = v204.Length < 4;\n\tv143 = ~v375;\n\tv139 = v204.Length - 4;\n\tv131 = v139 == 0;\n\tv376 = ~v143;\n\tv111 = v376 | v131;\n\tif (v111) goto L_00FA;\n\tv204[4] = v371;\n\tUnityEngine.AndroidJavaObject::Call(this.nativeGallery, \"saveImage\", v204);\n\treturn;\nL_00F8:\n\tSystem.Action`1<System.String>::Invoke(callback, *([v188 @ X8_v14 (System.String)]));\n\treturn;\nL_00FA:\n\tv306 = new System.IndexOutOfRangeException();\n\tgoto L_00FF;\n\tv340 = new System.ArrayTypeMismatchException();\nL_00FF:\n\tthrow v346;\n\tthrow System.NullReferenceException;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveImage(Texture2D image, string name, ImageFormat format = ImageFormat.JPG, Action<string> callback = null)
		{
			//IL_00cf: Expected O, but got I4
			//IL_03f6: Expected O, but got I
			//IL_0139: Expected O, but got I4
			//IL_01b8: Expected O, but got I4
			//IL_026d: Expected O, but got I4
			//IL_02bd: Expected O, but got I4
			//IL_02c6: Expected I4, but got O
			//IL_0325: Expected O, but got I4
			if (callback != null)
			{
				string obj;
				if (image == null)
				{
					obj = "Can't save a null image.";
				}
				else
				{
					if (nativeGallery != null)
					{
						object[] array = new object[5];
						string text = TextureUtilities.Encode(image, format);
						if (text != null)
						{
							object obj2 = text as object;
						}
						object obj3 = array.Length;
						if (array.Length != 0)
						{
							array[0] = text;
							if (name != null)
							{
								object obj4 = name as object;
								obj3 = array.Length;
							}
							bool flag = (long)(IntPtr)obj3 < 1L;
							bool flag2 = !flag;
							object obj5 = (long)(IntPtr)obj3 - 1L;
							bool flag3 = obj5 == null;
							bool flag4 = !flag2;
							if (!(flag4 || flag3))
							{
								array[1] = name;
								object obj6 = (int)format;
								if (obj6 != null)
								{
									object obj7 = obj6 as object;
								}
								bool flag5 = array.Length < 2;
								bool flag6 = !flag5;
								object obj8 = array.Length - 2;
								bool flag7 = obj8 == null;
								bool flag8 = !flag6;
								if (!(flag8 || flag7))
								{
									array[2] = obj6;
									AndroidSaveImageProxy androidSaveImageProxy = new AndroidSaveImageProxy(callback);
									if (androidSaveImageProxy != null)
									{
										object obj9 = androidSaveImageProxy as object;
									}
									bool flag9 = array.Length < 3;
									bool flag10 = !flag9;
									object obj10 = array.Length - 3;
									bool flag11 = obj10 == null;
									bool flag12 = !flag10;
									if (!(flag12 || flag11))
									{
										array[3] = androidSaveImageProxy;
										object obj11 = 0;
										object obj12 = (byte)(int)obj11 != 0;
										if (obj12 != null)
										{
											object obj13 = obj12 as object;
										}
										bool flag13 = array.Length < 4;
										bool flag14 = !flag13;
										object obj14 = array.Length - 4;
										bool flag15 = obj14 == null;
										bool flag16 = !flag14;
										if (!(flag16 || flag15))
										{
											array[4] = obj12;
											nativeGallery.Call("saveImage", array);
											return;
										}
									}
								}
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
						throw ex2;
					}
					obj = "Couldn't create Gallery native wrapper class.";
				}
				callback(obj);
			}
			else
			{
				Debug.LogError("This method won't run because the callback is null.");
			}
		}

		[Token(Token = "0x60008BE")]
		[Address(RVA = "0xC01548", Offset = "0xC01548", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1F01678]);\n\tv31 = *([v30 @ X8_v37]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, media, callback, maxSize, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022F9E]) = v47;\nL_001C:\n\tv51 = new EasyMobile.Internal.NativeAPIs.Media.AndroidDeviceGallery+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v51);\n\tv51.callback = callback;\n\tv51.media = media;\n\tv51.<>4__this = this;\n\tv51.maxSize = maxSize;\n\tv55 = callback == 0;\n\tif (v55) goto L_0056;\n\tv98 = this.nativeGallery == 0;\n\tif (v98) goto L_FFFFFFFF;\n\tv105 = media == 0;\n\tif (v105) goto L_FFFFFFFF;\n\tv58 = media.<Type>k__BackingField != 1;\n\tif (v58) goto L_FFFFFFFF;\n\tv231 = EasyMobile.MediaResult::get_Uri(media);\n\tv87 = System.String::IsNullOrEmpty(v231);\n\tv233 = v87 == 0;\n\tif (v233) goto L_007F;\n\tgoto L_FFFFFFFF;\n\tv240 = *([v236 @ X0_v22+E0]);\n\tv241 = v240 == 0;\n\tv242 = ~v241;\n\tif (v242) goto L_FFFFFFFF;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v236, v84, callback, maxSize, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0068;\nL_0056:\n\tgoto L_FFFFFFFF;\n\tv108 = *([v101 @ X0_v9+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_FFFFFFFF;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v101, v52, callback, maxSize, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0068:\n\tUnityEngine.Debug::LogError(*([v196 @ X8_v6 (System.String)]));\n\treturn;\n\tgoto L_007D;\nL_007D:\n\tSystem.Action`2<System.String, UnityEngine.Texture2D>::Invoke(callback, *([v197 @ X8_v15 (System.String)]), 0);\n\treturn;\nL_007F:\n\tv93 = v51.media;\n\tv88 = System.String::IsNullOrEmpty(v93.absoluteUri);\n\tv94 = v51.media;\n\tv174 = v88 == 0;\n\tif (v174) goto L_009D;\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidDeviceGallery::LoadImageFromContentUri(this, v94.contentUri, v51.callback, v51.maxSize);\n\treturn;\nL_009D:\n\tv252 = new System.Action`2<System.String, UnityEngine.Texture2D>();\n\tSystem.Action`2<System.String, UnityEngine.Texture2D>::.ctor(v252, v51, Il2CppMethodInfo);\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidDeviceGallery::LoadImageFromAbsoluteUri(this, v94.absoluteUri, v252, v51.maxSize);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadImage(MediaResult media, Action<string, Texture2D> callback, int maxSize = -1)
		{
			Action<string, Texture2D> callback2 = callback;
			MediaResult media2 = media;
			string message;
			if (callback != null)
			{
				string arg;
				if (nativeGallery != null)
				{
					if (media != null && media.Type == MediaType.Image)
					{
						string uri = media.Uri;
						if (string.IsNullOrEmpty(uri))
						{
							message = "Couldn't find a valid uri.";
							goto IL_01ec;
						}
						MediaResult mediaResult = media2;
						bool flag = string.IsNullOrEmpty(mediaResult.absoluteUri);
						MediaResult mediaResult2 = media2;
						if (flag)
						{
							LoadImageFromContentUri(mediaResult2.contentUri, callback2, maxSize);
							return;
						}
						Action<string, Texture2D> callback3 = delegate
						{
							string text = default(string);
							Texture2D texture2D = default(Texture2D);
							Action<string, Texture2D> action;
							if (text == null && texture2D != null)
							{
								action = callback2;
							}
							else
							{
								MediaResult mediaResult3 = media2;
								if (!string.IsNullOrEmpty(mediaResult3.contentUri))
								{
									MediaResult mediaResult4 = media2;
									LoadImageFromContentUri(mediaResult4.contentUri, callback2, maxSize);
									return;
								}
								action = callback2;
							}
							action(null, null);
						};
						LoadImageFromAbsoluteUri(mediaResult2.absoluteUri, callback3, maxSize);
						return;
					}
					arg = "Unvalid MediaResult.";
				}
				else
				{
					arg = "Couldn't create Gallery native wrapper class.";
				}
				callback(arg, null);
				return;
			}
			message = "This method won't run because the callback is null.";
			goto IL_01ec;
			IL_01ec:
			Debug.LogError(message);
		}

		[Token(Token = "0x60008BF")]
		[Address(RVA = "0xC0196C", Offset = "0xC0196C", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv30 = *([1EBEB78]);\n\tv31 = *([v30 @ X8_v37]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, uri, callback, maxSize, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022F9F]) = v47;\nL_0027:\n\tv62 = maxSize < 1;\n\tif (v62) goto L_0087;\n\t// 42 NewArr v64 @ X0_v24 (System.Object[]), typeof(System.Object[]), 3\n\tv71 = uri == 0;\n\tif (v71) goto L_0037;\n\t// 51 IsInst v112 @ X0_v38, typeof(System.Object), uri @ X1 (System.String)\nL_0037:\n\tv119 = v64.Length == 0;\n\tif (v119) goto L_00C6;\n\tv64[0] = uri;\n\t// 63 Box v183 @ X0_v27, typeof(System.Int32), &maxSize @ X3 (System.Int32)\n\tv250 = v183 == 0;\n\tif (v250) goto L_004A;\n\t// 70 IsInst v236 @ X0_v36, typeof(System.Object), v183 @ X0_v27\nL_004A:\n\tv303 = v64.Length < 1;\n\tv201 = ~v303;\n\tv199 = v64.Length - 1;\n\tv195 = v199 == 0;\n\tv304 = ~v201;\n\tv185 = v304 | v195;\n\tif (v185) goto L_00C6;\n\tv64[1] = v183;\n\tv309 = new EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy::.ctor(v309, callback);\n\tv315 = v309 == 0;\n\tif (v315) goto L_0067;\n\t// 99 IsInst v237 @ X0_v34, typeof(System.Object), v309 @ X0_v30 (EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy)\nL_0067:\n\tv319 = v64.Length < 2;\n\tv146 = ~v319;\n\tv143 = v64.Length - 2;\n\tv137 = v143 == 0;\n\tv320 = ~v146;\n\tv122 = v320 | v137;\n\tif (v122) goto L_00C6;\n\tv64[2] = v309;\n\tUnityEngine.AndroidJavaObject::Call(this.nativeGallery, \"loadImageFromContentUri\", v64);\n\treturn;\nL_0087:\n\t// 135 NewArr v66 @ X0_v14 (System.Object[]), typeof(System.Object[]), 2\n\tv108 = uri == 0;\n\tif (v108) goto L_0094;\n\t// 144 IsInst v171 @ X0_v23, typeof(System.Object), uri @ X1 (System.String)\nL_0094:\n\tv178 = v66.Length == 0;\n\tif (v178) goto L_00C6;\n\tv66[0] = uri;\n\tv220 = new EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy::.ctor(v220, callback);\n\tv305 = v220 == 0;\n\tif (v305) goto L_00A7;\n\t// 163 IsInst v238 @ X0_v21, typeof(System.Object), v220 @ X0_v17 (EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy)\nL_00A7:\n\tv312 = v66.Length < 1;\n\tv147 = ~v312;\n\tv144 = v66.Length - 1;\n\tv138 = v144 == 0;\n\tv313 = ~v147;\n\tv123 = v313 | v138;\n\tif (v123) goto L_00C6;\n\tv66[1] = v220;\n\tUnityEngine.AndroidJavaObject::Call(this.nativeGallery, \"loadImageFromContentUri\", v66);\n\treturn;\nL_00C6:\n\tv216 = new System.IndexOutOfRangeException();\n\tgoto L_00CB;\n\tv249 = new System.ArrayTypeMismatchException();\nL_00CB:\n\tthrow v300;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void LoadImageFromContentUri(string uri, Action<string, Texture2D> callback, int maxSize = -1)
		{
			//IL_02d7: Expected O, but got I4
			//IL_00e0: Expected O, but got I4
			//IL_0195: Expected O, but got I4
			if (maxSize >= 1)
			{
				object[] array = new object[3];
				if (uri != null)
				{
					object obj = uri as object;
				}
				if (array.Length != 0)
				{
					array[0] = uri;
					object obj2 = maxSize;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
					}
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj4 = array.Length - 1;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = obj2;
						AndroidLoadImageProxy androidLoadImageProxy = new AndroidLoadImageProxy(callback);
						if (androidLoadImageProxy != null)
						{
							object obj5 = androidLoadImageProxy as object;
						}
						bool flag5 = array.Length < 2;
						bool flag6 = !flag5;
						object obj6 = array.Length - 2;
						bool flag7 = obj6 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							array[2] = androidLoadImageProxy;
							nativeGallery.Call("loadImageFromContentUri", array);
							return;
						}
					}
				}
			}
			else
			{
				object[] array2 = new object[2];
				if (uri != null)
				{
					object obj7 = uri as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = uri;
					AndroidLoadImageProxy androidLoadImageProxy2 = new AndroidLoadImageProxy(callback);
					if (androidLoadImageProxy2 != null)
					{
						object obj8 = androidLoadImageProxy2 as object;
					}
					bool flag9 = array2.Length < 1;
					bool flag10 = !flag9;
					object obj9 = array2.Length - 1;
					bool flag11 = obj9 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array2[1] = androidLoadImageProxy2;
						nativeGallery.Call("loadImageFromContentUri", array2);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008C0")]
		[Address(RVA = "0xC01750", Offset = "0xC01750", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv30 = *([1EF70B8]);\n\tv31 = *([v30 @ X8_v37]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, uri, callback, maxSize, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022FA0]) = v47;\nL_0027:\n\tv62 = maxSize < 1;\n\tif (v62) goto L_0087;\n\t// 42 NewArr v64 @ X0_v24 (System.Object[]), typeof(System.Object[]), 3\n\tv71 = uri == 0;\n\tif (v71) goto L_0037;\n\t// 51 IsInst v112 @ X0_v38, typeof(System.Object), uri @ X1 (System.String)\nL_0037:\n\tv119 = v64.Length == 0;\n\tif (v119) goto L_00C6;\n\tv64[0] = uri;\n\t// 63 Box v183 @ X0_v27, typeof(System.Int32), &maxSize @ X3 (System.Int32)\n\tv250 = v183 == 0;\n\tif (v250) goto L_004A;\n\t// 70 IsInst v236 @ X0_v36, typeof(System.Object), v183 @ X0_v27\nL_004A:\n\tv303 = v64.Length < 1;\n\tv201 = ~v303;\n\tv199 = v64.Length - 1;\n\tv195 = v199 == 0;\n\tv304 = ~v201;\n\tv185 = v304 | v195;\n\tif (v185) goto L_00C6;\n\tv64[1] = v183;\n\tv309 = new EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy::.ctor(v309, callback);\n\tv315 = v309 == 0;\n\tif (v315) goto L_0067;\n\t// 99 IsInst v237 @ X0_v34, typeof(System.Object), v309 @ X0_v30 (EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy)\nL_0067:\n\tv319 = v64.Length < 2;\n\tv146 = ~v319;\n\tv143 = v64.Length - 2;\n\tv137 = v143 == 0;\n\tv320 = ~v146;\n\tv122 = v320 | v137;\n\tif (v122) goto L_00C6;\n\tv64[2] = v309;\n\tUnityEngine.AndroidJavaObject::Call(this.nativeGallery, \"loadImageFromAbsoluteUri\", v64);\n\treturn;\nL_0087:\n\t// 135 NewArr v66 @ X0_v14 (System.Object[]), typeof(System.Object[]), 2\n\tv108 = uri == 0;\n\tif (v108) goto L_0094;\n\t// 144 IsInst v171 @ X0_v23, typeof(System.Object), uri @ X1 (System.String)\nL_0094:\n\tv178 = v66.Length == 0;\n\tif (v178) goto L_00C6;\n\tv66[0] = uri;\n\tv220 = new EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy();\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy::.ctor(v220, callback);\n\tv305 = v220 == 0;\n\tif (v305) goto L_00A7;\n\t// 163 IsInst v238 @ X0_v21, typeof(System.Object), v220 @ X0_v17 (EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy)\nL_00A7:\n\tv312 = v66.Length < 1;\n\tv147 = ~v312;\n\tv144 = v66.Length - 1;\n\tv138 = v144 == 0;\n\tv313 = ~v147;\n\tv123 = v313 | v138;\n\tif (v123) goto L_00C6;\n\tv66[1] = v220;\n\tUnityEngine.AndroidJavaObject::Call(this.nativeGallery, \"loadImageFromAbsoluteUri\", v66);\n\treturn;\nL_00C6:\n\tv216 = new System.IndexOutOfRangeException();\n\tgoto L_00CB;\n\tv249 = new System.ArrayTypeMismatchException();\nL_00CB:\n\tthrow v300;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void LoadImageFromAbsoluteUri(string uri, Action<string, Texture2D> callback, int maxSize = -1)
		{
			//IL_02d7: Expected O, but got I4
			//IL_00e0: Expected O, but got I4
			//IL_0195: Expected O, but got I4
			if (maxSize >= 1)
			{
				object[] array = new object[3];
				if (uri != null)
				{
					object obj = uri as object;
				}
				if (array.Length != 0)
				{
					array[0] = uri;
					object obj2 = maxSize;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
					}
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj4 = array.Length - 1;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = obj2;
						AndroidLoadImageProxy androidLoadImageProxy = new AndroidLoadImageProxy(callback);
						if (androidLoadImageProxy != null)
						{
							object obj5 = androidLoadImageProxy as object;
						}
						bool flag5 = array.Length < 2;
						bool flag6 = !flag5;
						object obj6 = array.Length - 2;
						bool flag7 = obj6 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							array[2] = androidLoadImageProxy;
							nativeGallery.Call("loadImageFromAbsoluteUri", array);
							return;
						}
					}
				}
			}
			else
			{
				object[] array2 = new object[2];
				if (uri != null)
				{
					object obj7 = uri as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = uri;
					AndroidLoadImageProxy androidLoadImageProxy2 = new AndroidLoadImageProxy(callback);
					if (androidLoadImageProxy2 != null)
					{
						object obj8 = androidLoadImageProxy2 as object;
					}
					bool flag9 = array2.Length < 1;
					bool flag10 = !flag9;
					object obj9 = array2.Length - 1;
					bool flag11 = obj9 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array2[1] = androidLoadImageProxy2;
						nativeGallery.Call("loadImageFromAbsoluteUri", array2);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
