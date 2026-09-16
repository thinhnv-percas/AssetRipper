using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000053")]
	public sealed class AnimatedClip : IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x10")]
		private int _003CWidth_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x14")]
		private int _003CHeight_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x18")]
		private int _003CFramePerSecond_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x1C")]
		private float _003CLength_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x20")]
		private Texture[] _003CFrames_003Ek__BackingField;

		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x28")]
		internal bool isDisposed;

		[Token(Token = "0x17000141")]
		public int Width
		{
			[CompilerGenerated]
			[Token(Token = "0x600042C")]
			[Address(RVA = "0xA4D9F8", Offset = "0xA4D9F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Width>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Width;
			}
			[CompilerGenerated]
			[Token(Token = "0x600042D")]
			[Address(RVA = "0xA4DA00", Offset = "0xA4DA00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Width>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CWidth_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000142")]
		public int Height
		{
			[CompilerGenerated]
			[Token(Token = "0x600042E")]
			[Address(RVA = "0xA4DA08", Offset = "0xA4DA08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Height>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Height;
			}
			[CompilerGenerated]
			[Token(Token = "0x600042F")]
			[Address(RVA = "0xA4DA10", Offset = "0xA4DA10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Height>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CHeight_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000143")]
		public int FramePerSecond
		{
			[CompilerGenerated]
			[Token(Token = "0x6000430")]
			[Address(RVA = "0xA4DA18", Offset = "0xA4DA18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<FramePerSecond>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FramePerSecond;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000431")]
			[Address(RVA = "0xA4DA20", Offset = "0xA4DA20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<FramePerSecond>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CFramePerSecond_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000144")]
		public float Length
		{
			[CompilerGenerated]
			[Token(Token = "0x6000432")]
			[Address(RVA = "0xA4DA28", Offset = "0xA4DA28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Length>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Length;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000433")]
			[Address(RVA = "0xA4DA30", Offset = "0xA4DA30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Length>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLength_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000145")]
		public Texture[] Frames
		{
			[CompilerGenerated]
			[Token(Token = "0x6000434")]
			[Address(RVA = "0xA4DA38", Offset = "0xA4DA38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Frames>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000435")]
			[Address(RVA = "0xA4DA40", Offset = "0xA4DA40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Frames>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CFrames_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000436")]
		[Address(RVA = "0xA4DA48", Offset = "0xA4DA48", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Width>k__BackingField = width;\n\tthis.<Height>k__BackingField = height;\n\tthis.<FramePerSecond>k__BackingField = fps;\n\tthis.<Frames>k__BackingField = frames;\n\tv31 = frames.Length / fps;\n\tthis.<Length>k__BackingField = v31;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatedClip(int width, int height, int fps, Texture[] frames)
		{
			Width = width;
			Height = height;
			FramePerSecond = fps;
			Frames = frames;
			int num = frames.Length / fps;
			Length = num;
		}

		[Token(Token = "0x6000437")]
		[Address(RVA = "0xA4DAB8", Offset = "0xA4DAB8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.<Frames>k__BackingField;\n\tv138 = v12.Length;\n\tv28 = v12.Length < 1;\n\tif (v28) goto L_003F;\nL_0019:\n\tv140 = v40 < v138;\n\tv66 = ~v140;\n\tif (v66) goto L_0040;\n\tUnityEngine.Texture::set_filterMode(v12[v40 @ X21_v5 (System.Int32)], filterMode);\n\tv138 = v12.Length;\n\tv40 = v40 + 1;\n\tv100 = v40 < v12.Length;\n\tif (v100) goto L_0019;\nL_003F:\n\treturn;\nL_0040:\n\tv162 = new System.IndexOutOfRangeException();\n\tthrow v162;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFilterMode(FilterMode filterMode)
		{
			Texture[] frames = Frames;
			int num = frames.Length;
			if (frames.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				frames[num2].filterMode = filterMode;
				num = frames.Length;
				num2++;
				if (num2 >= frames.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000438")]
		[Address(RVA = "0xA4DB40", Offset = "0xA4DB40", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECCBF8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F30]) = v38;\nL_0016:\n\tv42 = new System.Action();\n\tSystem.Action::.ctor(v42, this, Il2CppMethodInfo);\n\tgoto L_002D;\n\tv56 = *([v52 @ X0_v5+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_002D;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, v48, v46, v49, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v42);\n\tSystem.Object::Finalize(this);\n\treturn;\n\tgoto L_0038;\nL_0038:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0052;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0053;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 80 ShiftStack 32\n\treturn;\nL_0052:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0053:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~AnimatedClip()
		{
			Action action = delegate
			{
				Cleanup(Frames);
			};
			RuntimeHelper.RunOnMainThread(action);
			base.Finalize();
		}

		[Token(Token = "0x6000439")]
		[Address(RVA = "0xA4DC2C", Offset = "0xA4DC2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isDisposed;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsDisposed()
		{
			return isDisposed;
		}

		[Token(Token = "0x600043A")]
		[Address(RVA = "0xA4DC34", Offset = "0xA4DC34", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB6BB8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F31]) = v38;\nL_0014:\n\tv40 = ~v36.isDisposed;\n\tv41 = ~v40;\n\tif (v41) goto L_002F;\n\tEasyMobile.AnimatedClip::Cleanup(v36, v36.<Frames>k__BackingField);\n\tgoto L_0027;\n\tv61 = *([v57 @ X0_v3+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0027;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tSystem.GC::SuppressFinalize(v36);\n\tv36.isDisposed = 1;\nL_002F:\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (!isDisposed)
			{
				Cleanup(Frames);
				GC.SuppressFinalize(this);
				isDisposed = true;
			}
		}

		[Token(Token = "0x600043B")]
		[Address(RVA = "0xA4DCB8", Offset = "0xA4DCB8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EEE0E0]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, frames, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021F32]) = v44;\nL_0016:\n\tv45 = frames == 0;\n\tif (v45) goto L_008E;\n\tv166 = frames.Length;\n\tv57 = frames.Length < 1;\n\tif (v57) goto L_008E;\nL_002A:\n\tv181 = v139 < v166;\n\tv159 = ~v181;\n\tif (v159) goto L_008F;\n\tgoto L_0044;\n\tv189 = *([v182 @ X0_v6+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0044;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v182, v171, v170, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0044:\n\tv198 = UnityEngine.Object::op_Inequality(frames[v139 @ X21_v4 (System.Int32)], 0);\n\tv200 = v198 == 0;\n\tif (v200) goto L_0078;\n\tv201 = frames[v139 @ X21_v4 (System.Int32)] == 0;\n\tif (v201) goto L_006F;\n\tgoto L_FFFFFFFF;\n\tv249 = v249_asT == 0;\n\tif (v249) goto L_006F;\n\tUnityEngine.RenderTexture::Release(frames[v139 @ X21_v4 (System.Int32)]);\nL_006F:\n\tgoto L_0077;\n\tv268 = *([v261 @ X0_v12+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0077;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v261, v245, v65, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0077:\n\tUnityEngine.Object::Destroy(frames[v139 @ X21_v4 (System.Int32)]);\nL_0078:\n\tv166 = frames.Length;\n\tv139 = v139 + 1;\n\tv81 = v139 < frames.Length;\n\tif (v81) goto L_002A;\nL_008E:\n\treturn;\nL_008F:\n\tv188 = new System.IndexOutOfRangeException();\n\tthrow v188;\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Cleanup(Texture[] frames)
		{
			if (frames == null)
			{
				return;
			}
			int num = frames.Length;
			if (frames.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				if (frames[num2] != null)
				{
					if ((object)frames[num2] != null)
					{
						RenderTexture renderTexture = frames[num2] as RenderTexture;
						if ((object)renderTexture != null)
						{
							((RenderTexture)frames[num2]).Release();
						}
					}
					UnityEngine.Object.Destroy(frames[num2]);
				}
				num = frames.Length;
				num2++;
				if (num2 >= frames.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
