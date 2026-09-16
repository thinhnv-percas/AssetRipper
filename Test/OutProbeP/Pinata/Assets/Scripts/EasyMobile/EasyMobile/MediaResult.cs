using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200006C")]
	public class MediaResult
	{
		[CompilerGenerated]
		[Token(Token = "0x4000283")]
		[FieldOffset(Offset = "0x10")]
		private MediaType _003CType_003Ek__BackingField;

		[Token(Token = "0x4000284")]
		[FieldOffset(Offset = "0x18")]
		internal string contentUri;

		[Token(Token = "0x4000285")]
		[FieldOffset(Offset = "0x20")]
		internal string absoluteUri;

		[Token(Token = "0x4000286")]
		[FieldOffset(Offset = "0x28")]
		private int loadedImageSize;

		[Token(Token = "0x4000287")]
		[FieldOffset(Offset = "0x30")]
		private Texture2D loadedImage;

		[Token(Token = "0x17000178")]
		public MediaType Type
		{
			[CompilerGenerated]
			[Token(Token = "0x6000516")]
			[Address(RVA = "0xFCBC98", Offset = "0xFCBC98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Type>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000517")]
			[Address(RVA = "0xFCBCA0", Offset = "0xFCBCA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Type>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CType_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000179")]
		public string Uri
		{
			[Token(Token = "0x6000518")]
			[Address(RVA = "0xFCBCA8", Offset = "0xFCBCA8", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = this + 0x20;\n\tv16 = System.String::IsNullOrEmpty(this.absoluteUri);\n\tv18 = v16 == 0;\n\tif (v18) goto L_001A;\n\tv19 = this + 0x18;\n\tv22 = System.String::IsNullOrEmpty(this.contentUri);\n\tv36 = v22 == 0;\n\tv27 = ~v36;\n\tif (v27) goto L_0020;\nL_001A:\n\treturnVal1 = this.absoluteUri;\nL_0020:\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000c: Expected O, but got I
				//IL_0044: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				string result;
				if (string.IsNullOrEmpty(absoluteUri))
				{
					object obj2 = (long)(IntPtr)this + 24L;
					bool flag = string.IsNullOrEmpty(contentUri);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = null;
					if (flag3)
					{
						goto IL_009a;
					}
					obj = obj2;
				}
				result = (string)obj;
				goto IL_009a;
				IL_009a:
				return result;
			}
		}

		[Token(Token = "0x6000519")]
		[Address(RVA = "0xFCBCF8", Offset = "0xFCBCF8", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Type>k__BackingField = type;\n\tthis.contentUri = contentUri;\n\tthis.absoluteUri = absoluteUri;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal MediaResult(MediaType type, string contentUri, string absoluteUri)
		{
			Type = type;
			this.contentUri = contentUri;
			this.absoluteUri = absoluteUri;
		}

		[Token(Token = "0x600051A")]
		[Address(RVA = "0xFCBD38", Offset = "0xFCBD38", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EEB790]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, maxSize, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025646]) = v44;\nL_001A:\n\tv48 = new EasyMobile.MediaResult+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v48);\n\tv48.<>4__this = this;\n\tv48.maxSize = maxSize;\n\tv48.callback = callback;\n\tv52 = callback == 0;\n\tif (v52) goto L_00A2;\n\tgoto L_0035;\n\tv129 = *([v57 @ X0_v7+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0035;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v57, v49, maxSize, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tv137 = UnityEngine.Object::op_Inequality(this.loadedImage, 0);\n\tv209 = v137 == 0;\n\tif (v209) goto L_0066;\n\tv220 = v48.maxSize < 1;\n\tif (v220) goto L_0061;\n\tv223 = v48.maxSize != this.loadedImageSize;\n\tif (v223) goto L_0066;\nL_0061:\n\tSystem.Action`2<System.String, UnityEngine.Texture2D>::Invoke(v48.callback, 0, this.loadedImage);\n\treturn;\nL_0066:\n\tv236 = new System.Action`2<System.String, UnityEngine.Texture2D>();\n\tSystem.Action`2<System.String, UnityEngine.Texture2D>::.ctor(v236, v48, Il2CppMethodInfo);\n\tv117 = EasyMobile.Media::get_Gallery();\n\tv242 = *([v117 @ X0_v13 (EasyMobile.IDeviceGallery)]);\n\tv243 = v48.maxSize;\n\tv189 = *([v242 @ X8_v15 (Il2CppClass<EasyMobile.IDeviceGallery>)+126]) == 0;\n\tif (v189) goto L_0099;\n\tv278 = *([v242 @ X8_v15 (Il2CppClass<EasyMobile.IDeviceGallery>)+B0]) + 8;\nL_0084:\n\tv293 = *([v278 @ X11_v5-8]) == EasyMobile.IDeviceGallery;\n\tif (v293) goto L_00A4;\n\tv279 = v279 + 1;\n\tv298 = v279 < *([v242 @ X8_v15 (Il2CppClass<EasyMobile.IDeviceGallery>)+126]);\n\tv273 = ~v298;\n\tv278 = v278 + 0x10;\n\tv257 = ~v273;\n\tif (v257) goto L_0084;\nL_0099:\n\tv305 = System.Action`2<System.String, UnityEngine.Texture2D>::.ctor(v117, EasyMobile.IDeviceGallery, 2);\n\tgoto L_00A8;\nL_00A2:\n\treturn;\nL_00A4:\n\tv300 = *([v278 @ X11_v5]) + 2;\n\tv301 = v300 << 4;\n\tv302 = v242 + v301;\n\tv305 = v302 + 0x130;\nL_00A8:\n\tv141 = *([v305 @ X0_v14 (System.Action`2<System.String, UnityEngine.Texture2D>)]);\n\tv139 = *([v305 @ X0_v14 (System.Action`2<System.String, UnityEngine.Texture2D>)+8]);\n\t// 181 IndirectJump v141 @ X5_v1 (Il2CppClass<System.Action`2<System.String, UnityEngine.Texture2D>>), v117 @ X0_v13 (EasyMobile.IDeviceGallery), v117 @ X0_v13 (EasyMobile.IDeviceGallery), this @ X0 (EasyMobile.MediaResult), v236 @ X0_v12 (System.Action`2<System.String, UnityEngine.Texture2D>), v243 @ X20_v4 (System.Int32), v139 @ X4_v1, v141 @ X5_v1 (Il2CppClass<System.Action`2<System.String, UnityEngine.Texture2D>>), v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadImage(Action<string, Texture2D> callback, int maxSize = -1)
		{
			//IL_0105: Expected I, but got O
			//IL_0238: Expected I, but got O
			//IL_0248: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Expected O, but got Unknown
			//IL_01e3: Expected O, but got I
			//IL_01f2: Expected O, but got I
			//IL_0199: Expected O, but got I
			Action<string, Texture2D> callback2 = callback;
			if (callback == null)
			{
				return;
			}
			if (loadedImage != null && (maxSize < 1 || maxSize == loadedImageSize))
			{
				callback2(null, loadedImage);
				return;
			}
			Action<string, Texture2D> action = delegate(string error, Texture2D image)
			{
				MediaResult mediaResult = this;
				mediaResult.loadedImageSize = maxSize;
				MediaResult mediaResult2 = this;
				mediaResult2.loadedImage = image;
				callback2(error, image);
			};
			IDeviceGallery gallery = Media.Gallery;
			IntPtr intPtr = (IntPtr)gallery;
			int num = maxSize;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ X8_v15 (Il2CppClass<EasyMobile.IDeviceGallery>)+126]");
			Action<string, Texture2D> action2 = default(Action<string, Texture2D>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ X8_v15 (Il2CppClass<EasyMobile.IDeviceGallery>)+B0]");
				object obj = 0L + 8L;
				int num2 = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IDeviceGallery))
					{
						num2++;
						int num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ X8_v15 (Il2CppClass<EasyMobile.IDeviceGallery>)+126]");
						bool flag = (long)num3 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 2;
					int num4 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num4;
					action2 = (Action<string, Texture2D>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			IntPtr intPtr2 = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X0_v14 (System.Action`2<System.String, UnityEngine.Texture2D>)+8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v141 @ X5_v1 (Il2CppClass<System.Action`2<System.String, UnityEngine.Texture2D>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600051B")]
		[Address(RVA = "0xFCBF0C", Offset = "0xFCBF0C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEEA78]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2025647]) = v38;\nL_0014:\n\tv40 = this.<Type>k__BackingField;\n\t// 25 Box v45 @ X0_v3 (System.Object), typeof(EasyMobile.MediaType), &v40 @ X8_v3 (EasyMobile.MediaType)\n\tv48 = EasyMobile.MediaResult::get_Uri(this);\n\tv66 = v48 != 0;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\treturnVal1 = System.String::Format(\"MediaResult[Type={0}, Uri={1}]\", v45, v69);\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			MediaType type = Type;
			object arg = type;
			string uri = Uri;
			string arg2 = ((uri != null) ? uri : "null");
			return $"MediaResult[Type={arg}, Uri={arg2}]";
		}
	}
}
