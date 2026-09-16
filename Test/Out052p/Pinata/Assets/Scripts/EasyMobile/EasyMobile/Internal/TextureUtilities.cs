using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000CC")]
	internal static class TextureUtilities
	{
		[Token(Token = "0x20001B7")]
		public class ThreadData
		{
			[Token(Token = "0x40006A1")]
			[FieldOffset(Offset = "0x10")]
			public int start;

			[Token(Token = "0x40006A2")]
			[FieldOffset(Offset = "0x14")]
			public int end;

			[Token(Token = "0x6000CF4")]
			[Address(RVA = "0xB534D0", Offset = "0xB534D0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.start = s;\n\tthis.end = e;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ThreadData(int s, int e)
			{
				start = s;
				end = e;
			}
		}

		[Token(Token = "0x40003B3")]
		private static Color[] texColors;

		[Token(Token = "0x40003B4")]
		private static Color[] newColors;

		[Token(Token = "0x40003B5")]
		private static int oldWidth;

		[Token(Token = "0x40003B6")]
		private static float ratioX;

		[Token(Token = "0x40003B7")]
		private static float ratioY;

		[Token(Token = "0x40003B8")]
		private static int newWidth;

		[Token(Token = "0x40003B9")]
		private static int finishCount;

		[Token(Token = "0x40003BA")]
		private static Mutex mutex;

		[Token(Token = "0x600076B")]
		[Address(RVA = "0xB52E54", Offset = "0xB52E54", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC4798]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227A6]) = v38;\nL_0013:\n\tv39 = encodedImage == 0;\n\tif (v39) goto L_0031;\n\tgoto L_0023;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv60 = System.Convert::FromBase64String(encodedImage);\n\treturnVal2 = EasyMobile.Internal.TextureUtilities::Decode(v60);\n\treturn returnVal2;\nL_0031:\n\treturn 0;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Texture2D Decode(string encodedImage)
		{
			if (encodedImage != null)
			{
				byte[] bytes = Convert.FromBase64String(encodedImage);
				return Decode(bytes);
			}
			return null;
		}

		[Token(Token = "0x600076C")]
		[Address(RVA = "0xB52ED4", Offset = "0xB52ED4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBB640]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227A7]) = v38;\nL_0013:\n\tv39 = bytes == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv43 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v43, 1, 1, 3, 0);\n\tv71 = UnityEngine.ImageConversion::LoadImage(v43, bytes);\n\tUnityEngine.Texture2D::Apply(v43);\n\tgoto L_0031;\nL_0031:\n\treturn v63;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Texture2D Decode(byte[] bytes)
		{
			if (bytes != null)
			{
				Texture2D texture2D = new Texture2D(1, 1, TextureFormat.RGB24, mipChain: false);
				bool flag = texture2D.LoadImage(bytes);
				texture2D.Apply();
				return texture2D;
			}
			return null;
		}

		[Token(Token = "0x600076D")]
		[Address(RVA = "0xB52F78", Offset = "0xB52F78", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE9B98]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, format, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227A8]) = v41;\nL_0017:\n\treturnVal1 = EasyMobile.Internal.TextureUtilities::EncodeAsByteArray(texture, format);\n\tv46 = returnVal1 == 0;\n\tif (v46) goto L_0037;\n\tgoto L_002F;\n\tv58 = *([v49 @ X0_v4+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_002F;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v49, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\treturnVal2 = System.Convert::ToBase64String(returnVal1);\n\treturn returnVal2;\nL_0037:\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string Encode(Texture2D texture, ImageFormat format = ImageFormat.PNG)
		{
			string text = (string)(object)EncodeAsByteArray(texture, format);
			if (text != null)
			{
				return Convert.ToBase64String((byte[])(object)text);
			}
			return text;
		}

		[Token(Token = "0x600076E")]
		[Address(RVA = "0xB53010", Offset = "0xB53010", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB8678]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, format, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20227A9]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, format, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(texture, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0030;\n\treturn 0;\nL_0030:\n\tv67 = format == 0;\n\tif (v67) goto L_0044;\n\treturnVal2 = UnityEngine.ImageConversion::EncodeToPNG(texture);\n\treturn returnVal2;\nL_0044:\n\treturnVal3 = UnityEngine.ImageConversion::EncodeToJPG(texture);\n\treturn returnVal3;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte[] EncodeAsByteArray(Texture2D texture, ImageFormat format = ImageFormat.PNG)
		{
			if (texture == null)
			{
				return null;
			}
			if (format != ImageFormat.JPG)
			{
				return texture.EncodeToPNG();
			}
			return texture.EncodeToJPG();
		}

		[Token(Token = "0x600076F")]
		[Address(RVA = "0xB530C8", Offset = "0xB530C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.TextureUtilities::ThreadedScale(texture, newWidth, newHeight, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PointScale(this Texture2D texture, int newWidth, int newHeight)
		{
			ThreadedScale(texture, newWidth, newHeight, useBilinear: false);
		}

		[Token(Token = "0x6000770")]
		[Address(RVA = "0xB534C8", Offset = "0xB534C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.TextureUtilities::ThreadedScale(texture, newWidth, newHeight, 1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void BilinearScale(this Texture2D texture, int newWidth, int newHeight)
		{
			ThreadedScale(texture, newWidth, newHeight, useBilinear: true);
		}

		[Token(Token = "0x6000771")]
		[Address(RVA = "0xB530D0", Offset = "0xB530D0", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv42 = *([1EB2028]);\n\tv43 = *([v42 @ X8_v62]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, newWidth, newHeight, useBilinear, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([20227AA]) = v59;\nL_0023:\n\tv63 = UnityEngine.Texture2D::GetPixels(tex);\n\tv145 = newHeight * newWidth;\n\tv147.texColors = v63;\n\t// 45 NewArr v151 @ X0_v8 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), v145 @ X1_v3 (System.Int32)\n\tv153.newColors = v151;\n\tv158 = UnityEngine.Texture::get_width(tex);\n\tv163 = useBilinear == 0;\n\tif (v163) goto L_0050;\n\tv229 = v158 - 1;\n\tv233 = newWidth / v229;\n\tv234 = 1f / v233;\n\tv161.ratioX = v234;\n\tv239 = UnityEngine.Texture::get_height(tex);\n\tv240 = v239 - 1;\n\tv243 = newHeight / v240;\n\tv121 = 1f / v243;\n\tgoto L_005D;\nL_0050:\n\tv247 = v158 / newWidth;\n\tv161.ratioX = v247;\n\tv252 = UnityEngine.Texture::get_height(tex);\n\tv255 = v252 / newHeight;\nL_005D:\n\tv262.ratioY = v121;\n\tv266 = UnityEngine.Texture::get_width(tex);\n\tv268.oldWidth = v266;\n\tv269.newWidth = newWidth;\n\tv271 = UnityEngine.SystemInfo::get_processorCount();\n\tgoto L_007A;\n\tv279 = *([v275 @ X8_v21+E0]);\n\tv280 = v279 == 0;\n\tv281 = ~v280;\n\tgoto L_007A;\n\tv290 = v275;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v290, v265, newHeight, useBilinear, methodInfo, v46, v47, v48, v121, v119, v51, v52, v53, v54, v55, v56);\nL_007A:\n\tv289 = UnityEngine.Mathf::Min(v271, newHeight);\n\tv123.finishCount = 0;\n\tv294 = v292.mutex == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_0098;\n\tv299 = new System.Threading.Mutex();\n\tSystem.Threading.Mutex::.ctor(v299, 0);\n\tv308.mutex = v299;\nL_0098:\n\tv318 = v289 >= 2;\n\tif (v318) goto L_00AE;\n\tv322 = new EasyMobile.Internal.TextureUtilities+ThreadData();\n\tSystem.Object::.ctor(v322);\n\tv322.start = 0;\n\tv322.end = newHeight;\n\tv345 = useBilinear == 0;\n\tif (v345) goto L_010A;\n\tEasyMobile.Internal.TextureUtilities::BilinearScale(v322);\n\tgoto L_0129;\nL_00AE:\n\tv132 = v289 - 1;\n\tv326 = new EasyMobile.Internal.TextureUtilities+ThreadData();\n\tv342 = v132 < 1;\n\tif (v342) goto L_00FE;\n\tv140 = newHeight / v289;\nL_00C8:\n\tv402 = v140 + v79;\n\tSystem.Object::.ctor(v111);\n\tv111.start = v79;\n\tv111.end = v402;\n\tv408 = new System.Threading.ParameterizedThreadStart();\n\tv447 = useBilinear == 0;\n\tif (v447) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\tSystem.Threading.ParameterizedThreadStart::.ctor(v408, 0, *([v138 @ X8_v43 (Il2CppMethodInfo)]));\n\tv128 = new System.Threading.Thread();\n\tSystem.Threading.Thread::.ctor(v128, v408);\n\tv71 = v71 + 1;\n\tSystem.Threading.Thread::Start(v128, v111);\n\tv381 = new EasyMobile.Internal.TextureUtilities+ThreadData();\n\tv356 = v79 + v140;\n\tv355 = v71 < v132;\n\tif (v355) goto L_00C8;\nL_00FE:\n\tSystem.Object::.ctor(v374);\n\tv374.start = v356;\n\tv374.end = newHeight;\n\tv406 = useBilinear == 0;\n\tif (v406) goto L_010D;\n\tEasyMobile.Internal.TextureUtilities::BilinearScale(v374);\n\tgoto L_0112;\nL_010A:\n\tEasyMobile.Internal.TextureUtilities::PointScale(v322);\n\tgoto L_0129;\nL_010D:\n\tEasyMobile.Internal.TextureUtilities::PointScale(v374);\nL_0112:\n\tgoto L_0123;\nL_0115:\n\tSystem.Threading.Thread::Sleep(1);\nL_0123:\n\tv415 = v471.finishCount < v289;\n\tif (v415) goto L_0115;\nL_0129:\n\tv444 = UnityEngine.Texture2D::Resize(v432, v434, v436);\n\tUnityEngine.Texture2D::SetPixels(v432, v452.newColors);\n\tUnityEngine.Texture2D::Apply(v432);\n\tv478.texColors = 0;\n\tv224.newColors = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 230 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ThreadedScale(Texture2D tex, int newWidth, int newHeight, bool useBilinear)
		{
			Color[] pixels = tex.GetPixels();
			int num = newHeight * newWidth;
			texColors = pixels;
			Color[] array = new Color[num];
			newColors = array;
			int width = tex.width;
			float num7;
			if (useBilinear)
			{
				int num2 = width - 1;
				int num3 = newWidth / num2;
				float num4 = 1f / (float)num3;
				ratioX = num4;
				int height = tex.height;
				int num5 = height - 1;
				int num6 = newHeight / num5;
				num7 = 1f / (float)num6;
			}
			else
			{
				int num8 = width / newWidth;
				ratioX = num8;
				int height2 = tex.height;
				int num9 = height2 / newHeight;
				num7 = num9;
			}
			ratioY = num7;
			int width2 = tex.width;
			oldWidth = width2;
			TextureUtilities.newWidth = newWidth;
			int processorCount = SystemInfo.processorCount;
			int num10 = Mathf.Min(processorCount, newHeight);
			finishCount = 0;
			if (TextureUtilities.mutex == null)
			{
				Mutex mutex = new Mutex(initiallyOwned: false);
				TextureUtilities.mutex = mutex;
			}
			Texture2D texture2D;
			int width3;
			int height3;
			if (num10 < 2)
			{
				ThreadData threadData = null;
				threadData.start = 0;
				threadData.end = newHeight;
				if (useBilinear)
				{
					BilinearScale(threadData);
					texture2D = tex;
					width3 = newWidth;
					height3 = newHeight;
				}
				else
				{
					PointScale(threadData);
					texture2D = tex;
					width3 = newWidth;
					height3 = newHeight;
				}
			}
			else
			{
				int num11 = num10 - 1;
				ThreadData threadData2 = null;
				bool flag = num11 < 1;
				int num12 = 0;
				ThreadData threadData3 = threadData2;
				if (!flag)
				{
					int num13 = newHeight / num10;
					int num14 = 0;
					int num15 = 0;
					ThreadData threadData4 = threadData2;
					bool flag2;
					do
					{
						int end = num13 + num15;
						threadData4.start = num15;
						threadData4.end = end;
						Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: ParameterizedThreadStart");
						ParameterizedThreadStart start = null;
						if (useBilinear)
						{
							IntPtr intPtr = (IntPtr)0;
						}
						else
						{
							IntPtr intPtr = (IntPtr)0;
						}
						Thread thread = new Thread(start);
						num14++;
						thread.Start(threadData4);
						ThreadData threadData5 = null;
						num12 = num15 + num13;
						flag2 = num14 < num11;
						threadData3 = threadData5;
						num15 = num12;
						threadData4 = threadData5;
					}
					while (flag2);
				}
				threadData3.start = num12;
				threadData3.end = newHeight;
				if (useBilinear)
				{
					BilinearScale(threadData3);
				}
				else
				{
					PointScale(threadData3);
				}
				while (true)
				{
					bool flag3 = finishCount < num10;
					texture2D = tex;
					width3 = newWidth;
					height3 = newHeight;
					if (flag3)
					{
						Thread.Sleep(1);
						continue;
					}
					break;
				}
			}
			bool flag4 = texture2D.Resize(width3, height3);
			texture2D.SetPixels(newColors);
			texture2D.Apply();
			texColors = null;
			newColors = null;
		}

		[Token(Token = "0x6000772")]
		[Address(RVA = "0xB53508", Offset = "0xB53508", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv48 = *([1ECE080]);\n\tv49 = *([v48 @ X8_v39]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([20227AB]) = v68;\nL_0034:\n\tgoto L_FFFFFFFF;\n\tv330 = v330_asT == 0;\n\tif (v330) goto L_016B;\n\tv229 = *([obj @ X0 (System.Object)+10]);\n\tv510 = *([obj @ X0 (System.Object)+10]) >= *([obj @ X0 (System.Object)+14]);\n\tif (v510) goto L_0143;\nL_005C:\n\tgoto L_006F;\n\tv697 = *([v687 @ X0_v14+E0]);\n\tv698 = v697 == 0;\n\tv699 = ~v698;\n\tgoto L_006F;\n\tv702 = \"il2cpp_codegen_runtime_class_init\"(v687, v73, v52, v53, v54, v55, v56, v57, v669, v657, v656, v655, v654, v653, v652, v651);\n\tv705 = EasyMobile.Internal.TextureUtilities;\nL_006F:\n\tv718 = v706.newWidth < 1;\n\tif (v718) goto L_012F;\n\tv720 = v683.ratioY * v229;\n\tv207 = v720 + 1;\n\tv201 = v706.oldWidth * v720;\n\tv199 = v706.oldWidth * v207;\n\tv197 = v706.newWidth * v229;\nL_0080:\n\tgoto L_0088;\n\tv758 = *([v755 @ X0_v18 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv759 = v758 == 0;\n\tv760 = ~v759;\n\tgoto L_0088;\n\tv762 = \"il2cpp_codegen_runtime_class_init\"(v755, v73, v52, v53, v54, v55, v56, v57, v217, v178, v173, v168, v163, v158, v153, v148);\n\tv765 = EasyMobile.Internal.TextureUtilities;\nL_0088:\n\tv313 = v300.texColors;\n\tv767 = v751.ratioX * v205;\n\tv768 = v201 + v767;\n\tv769 = v768 < v313.Length;\n\tv770 = ~v769;\n\tif (v770) goto L_0164;\n\tv220 = v768 + 1;\n\tv779 = v220 < v313.Length;\n\tv283 = ~v779;\n\tif (v283) goto L_0164;\n\tv181 = v300.newColors;\n\tv803 = v313 + 0x20;\n\tv804 = v768 << 4;\n\tv289 = v803 + v804;\n\tv232 = v220 << 4;\n\tv805 = v803 + v232;\n\tv193 = v300.ratioX * v205;\n\tv142 = v193 - v767;\n\t// 186 MakeStruct v131 @ AGGB536A4_0_v9 (UnityEngine.Color), typeof(UnityEngine.Color), [v289 @ X10_v19], [v289 @ X10_v19+4], [v289 @ X10_v19+8], [v289 @ X10_v19+C]\n\t// 187 MakeStruct v126 @ AGGB536A4_1_v9 (UnityEngine.Color), typeof(UnityEngine.Color), [v805 @ X8_v23], [v805 @ X8_v23+4], [v805 @ X8_v23+8], [v805 @ X8_v23+C]\n\tv215 = EasyMobile.Internal.TextureUtilities::ColorLerpUnclamped(v131, v126, v142);\n\tv311 = v811.texColors;\n\tv797 = v199 + v767;\n\tv812 = v797 < v311.Length;\n\tv794 = ~v812;\n\tif (v794) goto L_0164;\n\tv796 = v797 + 1;\n\tv813 = v796 < v311.Length;\n\tv284 = ~v813;\n\tif (v284) goto L_0164;\n\tv814 = v311 + 0x20;\n\tv815 = v797 << 4;\n\tv298 = v814 + v815;\n\tv233 = v796 << 4;\n\tv816 = v814 + v233;\n\t// 240 MakeStruct v106 @ AGGB5370C_0_v9 (UnityEngine.Color), typeof(UnityEngine.Color), [v298 @ X9_v22], [v298 @ X9_v22+4], [v298 @ X9_v22+8], [v298 @ X9_v22+C]\n\t// 241 MakeStruct v101 @ AGGB5370C_1_v9 (UnityEngine.Color), typeof(UnityEngine.Color), [v816 @ X8_v28], [v816 @ X8_v28+4], [v816 @ X8_v28+8], [v816 @ X8_v28+C]\n\tv826 = EasyMobile.Internal.TextureUtilities::ColorLerpUnclamped(v106, v101, v142);\n\tv835 = v312.ratioY * v229;\n\tv836 = v835 - v720;\n\tv216 = EasyMobile.Internal.TextureUtilities::ColorLerpUnclamped(v215, v826, v836);\n\tv800 = v197 + v205;\n\tv838 = v800 < v181.Length;\n\tv795 = ~v838;\n\tif (v795) goto L_0164;\n\tv724 = v800 << 4;\n\tv840 = v181 + v724;\n\t*([v840 @ X8_v33+20]) = v216;\n\tv181[v800 @ X8_v31].g = v216.g;\n\tv181[v800 @ X8_v31].b = v216.b;\n\tv181[v800 @ X8_v31].a = v216.a;\n\tv205 = v205 + 1;\n\tv726 = v205 < v745.newWidth;\n\tif (v726) goto L_0080;\nL_012F:\n\t;\n\tv229 = v229 + 1;\n\tv547 = v229 < *([obj @ X0 (System.Object)+14]);\n\tif (v547) goto L_005C;\nL_0143:\n\tv694 = System.Threading.WaitHandle::WaitOne(v487.mutex);\n\tv485 = v488.finishCount + 1;\n\tv488.finishCount = v485;\n\tSystem.Threading.Mutex::ReleaseMutex(v495.mutex);\n\treturn;\nL_0164:\n\tv801 = new System.IndexOutOfRangeException();\n\tthrow v801;\n\tthrow System.NullReferenceException;\nL_016B:\n\tthrow System.InvalidCastException;\n// 265 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void BilinearScale(object obj)
		{
			//IL_0044: Expected O, but got I
			//IL_0513: Expected O, but got I
			//IL_00c2: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_017d: Expected I4, but got F4
			//IL_018b: Expected O, but got I
			//IL_0199: Expected I4, but got F4
			//IL_01a7: Expected O, but got I
			//IL_01dc: Expected F4, but got O
			//IL_01f1: Expected F4, but got I
			//IL_0206: Expected F4, but got I
			//IL_021b: Expected F4, but got I
			//IL_0228: Expected F4, but got O
			//IL_023d: Expected F4, but got I
			//IL_0252: Expected F4, but got I
			//IL_0267: Expected F4, but got I
			//IL_030f: Expected O, but got I
			//IL_031d: Expected I4, but got F4
			//IL_032b: Expected O, but got I
			//IL_0339: Expected I4, but got F4
			//IL_0347: Expected O, but got I
			//IL_0354: Expected F4, but got O
			//IL_0369: Expected F4, but got I
			//IL_037e: Expected F4, but got I
			//IL_0393: Expected F4, but got I
			//IL_03a0: Expected F4, but got O
			//IL_03b5: Expected F4, but got I
			//IL_03ca: Expected F4, but got I
			//IL_03df: Expected F4, but got I
			//IL_043c: Expected O, but got I
			//IL_0482: Expected O, but got I
			ThreadData threadData = obj as ThreadData;
			if (threadData != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X0 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X0 (System.Object)+10]");
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X0 (System.Object)+14]");
				if ((long)intPtr < 0L)
				{
					Color c = default(Color);
					Color c2 = default(Color);
					Color c4 = default(Color);
					Color c5 = default(Color);
					object obj12;
					do
					{
						if (newWidth >= 1)
						{
							float num = ratioY * (float)obj2;
							float num2 = num + float.Epsilon;
							float num3 = (float)oldWidth * num;
							float num4 = (float)oldWidth * num2;
							object obj3 = (long)newWidth * (long)(IntPtr)obj2;
							int num5 = 0;
							while (true)
							{
								Color[] array = texColors;
								float num6 = ratioX * (float)num5;
								float num7 = num3 + num6;
								if (num7 < (float)array.Length)
								{
									float num8 = num7 + float.Epsilon;
									if (num8 < (float)array.Length)
									{
										Color[] array2 = newColors;
										object obj4 = (long)(IntPtr)array + 32L;
										int num9 = num7 << 4;
										object obj5 = (long)(IntPtr)obj4 + (long)num9;
										int num10 = num8 << 4;
										object obj6 = (long)(IntPtr)obj4 + (long)num10;
										float num11 = ratioX * (float)num5;
										float value = num11 - num6;
										c.r = (float)obj5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X10_v19+4]");
										c.g = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X10_v19+8]");
										c.b = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X10_v19+C]");
										c.a = 0f;
										c2.r = (float)obj6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ X8_v23+4]");
										c2.g = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ X8_v23+8]");
										c2.b = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ X8_v23+C]");
										c2.a = 0f;
										Color c3 = ColorLerpUnclamped(c, c2, value);
										Color[] array3 = texColors;
										float num12 = num4 + num6;
										if (num12 < (float)array3.Length)
										{
											float num13 = num12 + float.Epsilon;
											if (num13 < (float)array3.Length)
											{
												object obj7 = (long)(IntPtr)array3 + 32L;
												int num14 = num12 << 4;
												object obj8 = (long)(IntPtr)obj7 + (long)num14;
												int num15 = num13 << 4;
												object obj9 = (long)(IntPtr)obj7 + (long)num15;
												c4.r = (float)obj8;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X9_v22+4]");
												c4.g = 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X9_v22+8]");
												c4.b = 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X9_v22+C]");
												c4.a = 0f;
												c5.r = (float)obj9;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ X8_v28+4]");
												c5.g = 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ X8_v28+8]");
												c5.b = 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ X8_v28+C]");
												c5.a = 0f;
												Color c6 = ColorLerpUnclamped(c4, c5, value);
												float num16 = ratioY * (float)obj2;
												float value2 = num16 - num;
												Color color = ColorLerpUnclamped(c3, c6, value2);
												object obj10 = (long)(IntPtr)obj3 + (long)num5;
												if ((long)(IntPtr)obj10 < (long)array2.Length)
												{
													int num17 = (int)((long)(IntPtr)obj10 << 4);
													object obj11 = (long)(IntPtr)array2 + (long)num17;
													array2[obj10].g = color.g;
													array2[obj10].b = color.b;
													array2[obj10].a = color.a;
													num5++;
													if (num5 >= newWidth)
													{
														break;
													}
													continue;
												}
											}
										}
									}
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
							}
						}
						obj2 = (long)(IntPtr)obj2 + 1L;
						obj12 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X0 (System.Object)+14]");
					}
					while ((long)(IntPtr)obj12 < 0L);
				}
				bool flag = mutex.WaitOne();
				int num18 = finishCount + 1;
				finishCount = num18;
				mutex.ReleaseMutex();
				return;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x6000773")]
		[Address(RVA = "0xB53820", Offset = "0xB53820", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv18 = *([1F0A298]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227AC]) = v38;\nL_0025:\n\tgoto L_FFFFFFFF;\n\tv148 = v148_asT == 0;\n\tif (v148) goto L_00BF;\n\tv131 = *([obj @ X0 (System.Object)+10]);\n\tv302 = *([obj @ X0 (System.Object)+14]);\n\tgoto L_009E;\nL_0047:\n\tv354 = v245.newWidth < 1;\n\tif (v354) goto L_0093;\n\tv364 = v245.ratioY * v131;\n\tv366 = v245.oldWidth * v364;\n\tv79 = v245.newWidth * v131;\nL_0052:\n\tv74 = v124.texColors;\n\tv387 = v124.ratioX * v120;\n\tv72 = v387 + v366;\n\tv388 = v72 < v74.Length;\n\tv117 = ~v388;\n\tif (v117) goto L_00BA;\n\tv125 = v124.newColors;\n\tv263 = v79 + v120;\n\tv389 = v263 < v125.Length;\n\tv271 = ~v389;\n\tif (v271) goto L_00BA;\n\tv392 = v72 << 4;\n\tv393 = v74 + v392;\n\tv371 = v263 << 4;\n\tv394 = v125 + v371;\n\tv120 = v120 + 1;\n\t*([v394 @ X9_v16+20]) = *([v393 @ X12_v11+20]);\n\tv125[v263 @ X14_v9].g = v74[v72 @ V1_v11 (System.Single)].g;\n\tv125[v263 @ X14_v9].b = v74[v72 @ V1_v11 (System.Single)].b;\n\tv125[v263 @ X14_v9].a = v74[v72 @ V1_v11 (System.Single)].a;\n\tv372 = v120 < v382.newWidth;\n\tif (v372) goto L_0052;\n\tv302 = *([obj @ X0 (System.Object)+14]);\nL_0093:\n\tv131 = v131 + 1;\nL_009E:\n\tv222 = v131 < v302;\n\tif (v222) goto L_0047;\n\tv357 = System.Threading.WaitHandle::WaitOne(v245.mutex);\n\tv241 = v246.finishCount + 1;\n\tv246.finishCount = v241;\n\tSystem.Threading.Mutex::ReleaseMutex(v254.mutex);\n\treturn;\n\tv256 = new System.NullReferenceException();\nL_00BA:\n\tv274 = new System.IndexOutOfRangeException();\n\tthrow v274;\nL_00BF:\n\tthrow System.InvalidCastException;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PointScale(object obj)
		{
			//IL_0044: Expected O, but got I
			//IL_0054: Expected O, but got I
			//IL_02ab: Expected O, but got I
			//IL_00a6: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_0152: Expected I4, but got F4
			//IL_0160: Expected O, but got I
			//IL_017d: Expected O, but got I
			//IL_0231: Expected O, but got I
			ThreadData threadData = obj as ThreadData;
			if (threadData != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X0 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X0 (System.Object)+14]");
				object obj3 = 0;
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					if (newWidth >= 1)
					{
						float num = ratioY * (float)obj2;
						float num2 = (float)oldWidth * num;
						object obj4 = (long)newWidth * (long)(IntPtr)obj2;
						int num3 = 0;
						while (true)
						{
							Color[] array = texColors;
							float num4 = ratioX * (float)num3;
							float num5 = num4 + num2;
							if (num5 < (float)array.Length)
							{
								Color[] array2 = newColors;
								object obj5 = (long)(IntPtr)obj4 + (long)num3;
								if ((long)(IntPtr)obj5 < (long)array2.Length)
								{
									int num6 = num5 << 4;
									object obj6 = (long)(IntPtr)array + (long)num6;
									int num7 = (int)((long)(IntPtr)obj5 << 4);
									object obj7 = (long)(IntPtr)array2 + (long)num7;
									num3++;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ X12_v11+20]");
									_ = 0;
									array2[obj5].g = array[num5].g;
									array2[obj5].b = array[num5].b;
									array2[obj5].a = array[num5].a;
									if (num3 >= newWidth)
									{
										break;
									}
									continue;
								}
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X0 (System.Object)+14]");
						obj3 = 0;
					}
					obj2 = (long)(IntPtr)obj2 + 1L;
				}
				bool flag = mutex.WaitOne();
				int num8 = finishCount + 1;
				finishCount = num8;
				mutex.ReleaseMutex();
				return;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x6000774")]
		[Address(RVA = "0xB539C0", Offset = "0xB539C0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tv15 = c2 - c1;\n\tv16 = c2.g - c1.g;\n\tv17 = c2.b - c1.b;\n\tv18 = c2.a - c1.a;\n\tv19 = v15 * *([v12 @ X29_v1+10]);\n\tv20 = v16 * *([v12 @ X29_v1+10]);\n\tv21 = v17 * *([v12 @ X29_v1+10]);\n\tv22 = v18 * *([v12 @ X29_v1+10]);\n\tv23 = c1 + v19;\n\tv24 = c1.g + v20;\n\tv25 = c1.b + v21;\n\tv26 = c1.a + v22;\n\tv28 = 0;\n\tv31 = 0x101059C(&v28 @ stack_-20_v1 (UnityEngine.Color), 0, v32, v33, v34, v35, v36, v37, v23, v24, v25, v26, v19, v20, v21, v22);\n\treturn 0;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Color ColorLerpUnclamped(Color c1, Color c2, float value)
		{
			object obj2 = default(object);
			object obj = obj2;
			Color color = default(Color);
			Color color2 = default(Color);
			float num = color.r - color2.r;
			float num2 = c2.g - c1.g;
			float num3 = c2.b - c1.b;
			float num4 = c2.a - c1.a;
			float num5 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			float num6 = num5 * 0f;
			float num7 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			float num8 = num7 * 0f;
			float num9 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			float num10 = num9 * 0f;
			float num11 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			float num12 = num11 * 0f;
			float num13 = color2.r + num6;
			float num14 = c1.g + num8;
			float num15 = c1.b + num10;
			float num16 = c1.a + num12;
			Color color3 = default(Color);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}
	}
}
