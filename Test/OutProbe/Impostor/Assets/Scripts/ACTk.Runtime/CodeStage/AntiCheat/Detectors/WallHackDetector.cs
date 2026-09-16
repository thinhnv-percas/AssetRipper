using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace CodeStage.AntiCheat.Detectors
{
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/WallHack Detector")]
	[DisallowMultipleComponent]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_wall_hack_detector.html")]
	[Token(Token = "0x200004A")]
	public class WallHackDetector : ACTkDetectorBase<WallHackDetector>
	{
		[CompilerGenerated]
		[Token(Token = "0x200004B")]
		private sealed class _003CCaptureFrame_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000181")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000182")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000183")]
			[FieldOffset(Offset = "0x20")]
			public WallHackDetector _003C_003E4__this;

			[Token(Token = "0x4000184")]
			[FieldOffset(Offset = "0x28")]
			private RenderTexture _003CpreviousActive_003E5__2;

			[Token(Token = "0x17000040")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000446")]
				[Address(RVA = "0xBF3C68", Offset = "0xBF3C68", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000041")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000448")]
				[Address(RVA = "0xBF3CA8", Offset = "0xBF3CA8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000443")]
			[Address(RVA = "0xBF355C", Offset = "0xBF355C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CCaptureFrame_003Ed__76(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000444")]
			[Address(RVA = "0xBF37F4", Offset = "0xBF37F4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000445")]
			[Address(RVA = "0xBF37F8", Offset = "0xBF37F8", Length = "0x470")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv44 = UnityEngine.Object;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 1;\n\t*([1A3559A]) = v63;\nL_001F:\n\tv64 = v61.<>1__state;\n\tv65 = v61.<>1__state < 3;\n\tv66 = ~v65;\n\tv67 = v61.<>1__state - 3;\n\tv69 = v67 == 0;\n\tv74 = ~v69;\n\tv75 = v66 & v74;\n\tif (v75) goto L_009C;\n\tv78 = 0x424000 + 0x80;\n\tv81 = *([v78 @ X9_v2 (System.Int32)+v64 @ X8_v3 (System.Int32)]) << 2;\n\tv82 = 0xBF786C + v81;\n\t// 51 IndirectJump v82 @ X10_v2 (System.Int32), v61 @ X0_v1 (CodeStage.AntiCheat.Detectors.WallHackDetector+<CaptureFrame>d__76), v61 @ X0_v1 (CodeStage.AntiCheat.Detectors.WallHackDetector+<CaptureFrame>d__76), methodInfo @ X1 (Il2CppMethodInfo), v47 @ X2, v48 @ X3, v49 @ X4, v50 @ X5, v51 @ X6, v52 @ X7, v53 @ V0, v54 @ V1, v55 @ V2, v56 @ V3, v57 @ V4, v58 @ V5, v59 @ V6, v60 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_01C0;\n\tX0 = *([X20+98]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 1;\n\tX2 = 0;\n\tX21 = 1;\n\tUnityEngine.Behaviour::set_enabled(X0, X1, X2);\n\tX8 = *([X20+58]);\n\t*([X19+10]) = X21;\n\tgoto L_00A5;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_01C0;\n\tX0 = *([X20+A0]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 1;\n\tX2 = 0;\n\tUnityEngine.Renderer::set_enabled(X0, X1, X2);\n\tX0 = *([X20+A8]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 1;\n\tX2 = 0;\n\tUnityEngine.Renderer::set_enabled(X0, X1, X2);\n\tX0 = 0;\n\tX0 = UnityEngine.RenderTexture::get_active(X0);\n\t*([X19+28]) = X0;\n\tX0 = *([X20+F0]);\n\tX1 = 0;\n\tUnityEngine.RenderTexture::set_active(X0, X1);\n\tX0 = *([X20+98]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 0;\n\tUnityEngine.Camera::Render(X0, X1);\n\tX0 = *([X20+A0]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 0;\n\tX2 = 0;\n\tUnityEngine.Renderer::set_enabled(X0, X1, X2);\n\tX0 = *([X20+A8]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 0;\n\tX2 = 0;\n\tUnityEngine.Renderer::set_enabled(X0, X1, X2);\n\tgoto L_006E;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_01C0;\nL_006E:\n\tX0 = *([X20+F0]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 0;\n\tX0 = UnityEngine.RenderTexture::IsCreated(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00A1;\n\tX0 = *([X20+E8]);\n\tif (TEMP) goto L_01C0;\n\tV0 = 0;\n\tV1 = 0;\n\tV2 = 4f;\n\tV3 = 4f;\n\tX1 = 0;\n\tX2 = 0;\n\tX3 = 0;\n\tX4 = 0;\n\t// 129 MakeStruct AGGBF796C_1, typeof(UnityEngine.Rect), V0, V1, V2, V3\n\tUnityEngine.Texture2D::ReadPixels(X0, AGGBF796C_1, X1, X2, X3, X4);\n\tX0 = *([X20+E8]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 0;\n\tUnityEngine.Texture2D::Apply(X0, X1);\n\tX0 = *([X19+28]);\n\tX1 = 0;\n\tUnityEngine.RenderTexture::set_active(X0, X1);\n\tX8 = *([1935328]);\n\tX21 = *([X20+98]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0094;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0094:\n\tX0 = X21;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BB;\nL_009C:\n\tgoto L_00BA;\n\tX21 = 0;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tgoto L_00BA;\nL_00A1:\n\tX8 = *([X20+58]);\n\tX9 = 2;\n\t*([X19+10]) = X9;\n\tX21 = 1;\nL_00A5:\n\t*([X19+18]) = X8;\nL_00BA:\n\treturn 0;\nL_00BB:\n\tX0 = *([X20+98]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 0;\n\tX2 = 0;\n\tUnityEngine.Behaviour::set_enabled(X0, X1, X2);\n\tX0 = *([X20+E8]);\n\tif (TEMP) goto L_01C0;\n\tX2 = 3;\n\tX1 = 0;\n\tX3 = 0;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = *([X20+E8]);\n\tif (TEMP) goto L_01C0;\n\tX2 = 1;\n\tX1 = 0;\n\tX3 = 0;\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tV11 = V3;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = *([X20+E8]);\n\tif (TEMP) goto L_01C0;\n\tX1 = 3;\n\tX2 = 3;\n\tX3 = 0;\n\tV12 = V0;\n\tV13 = V1;\n\tV14 = V2;\n\tV15 = V3;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = *([X20+E8]);\n\tstack[58] = V1;\n\tstack[5C] = V0;\n\tstack[50] = V3;\n\tstack[54] = V2;\n\tif (TEMP) goto L_01C0;\n\tX1 = 3;\n\tX2 = 1;\n\tX3 = 0;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = *([X20+E8]);\n\tstack[48] = V1;\n\tstack[4C] = V0;\n\tstack[40] = V3;\n\tstack[44] = V2;\n\tif (TEMP) goto L_01C0;\n\tX1 = 1;\n\tX2 = 3;\n\tX3 = 0;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = *([X20+E8]);\n\tstack[38] = V1;\n\tstack[3C] = V0;\n\tstack[30] = V3;\n\tstack[34] = V2;\n\tif (TEMP) goto L_01C0;\n\tX1 = 2;\n\tX2 = 3;\n\tX3 = 0;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = *([X20+E8]);\n\tstack[28] = V1;\n\tstack[2C] = V0;\n\tstack[20] = V3;\n\tstack[24] = V2;\n\tif (TEMP) goto L_01C0;\n\tX1 = 1;\n\tX2 = 1;\n\tX3 = 0;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = *([X20+E8]);\n\tstack[18] = V1;\n\tstack[1C] = V0;\n\tstack[10] = V3;\n\tstack[14] = V2;\n\tif (TEMP) goto L_01C0;\n\tX1 = 2;\n\tX2 = 1;\n\tX3 = 0;\n\tV0 = UnityEngine.Texture2D::GetPixel(X0, X1, X2, X3);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = *([X20+B0]);\n\tV5 = *([X20+B4]);\n\tV6 = *([X20+B8]);\n\tV7 = *([X20+BC]);\n\tstack[8] = V1;\n\tstack[C] = V0;\n\tstack[0] = V3;\n\tstack[4] = V2;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tV3 = V11;\n\t// 313 MakeStruct AGGBF7B54_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 314 MakeStruct AGGBF7B54_2, typeof(UnityEngine.Color), V4, V5, V6, V7\n\tX0 = CodeStage.AntiCheat.Detectors.WallHackDetector::ColorsDiffer(X0, AGGBF7B54_1, AGGBF7B54_2, X1);\n\tV4 = *([X20+C0]);\n\tV5 = *([X20+C4]);\n\tV6 = *([X20+C8]);\n\tV7 = *([X20+CC]);\n\tV0 = V12;\n\tV1 = V13;\n\tV2 = V14;\n\tV3 = V15;\n\tX21 = X0;\n\t// 325 MakeStruct AGGBF7B74_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 326 MakeStruct AGGBF7B74_2, typeof(UnityEngine.Color), V4, V5, V6, V7\n\tX0 = CodeStage.AntiCheat.Detectors.WallHackDetector::ColorsDiffer(X0, AGGBF7B74_1, AGGBF7B74_2, X1);\n\tV4 = *([X20+B0]);\n\tV5 = *([X20+B4]);\n\tV6 = *([X20+B8]);\n\tV7 = *([X20+BC]);\n\tV1 = stack[58];\n\tV0 = stack[5C];\n\tV3 = stack[50];\n\tV2 = stack[54];\n\tX22 = X0;\n\t// 337 MakeStruct AGGBF7B8C_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 338 MakeStruct AGGBF7B8C_2, typeof(UnityEngine.Color), V4, V5, V6, V7\n\tX0 = CodeStage.AntiCheat.Detectors.WallHackDetector::ColorsDiffer(X0, AGGBF7B8C_1, AGGBF7B8C_2, X1);\n\tV4 = *([X20+C0]);\n\tV5 = *([X20+C4]);\n\tV6 = *([X20+C8]);\n\tV7 = *([X20+CC]);\n\tV1 = stack[48];\n\tV0 = stack[4C];\n\tV3 = stack[40];\n\tV2 = stack[44];\n\tX23 = X0;\n\t// 349 MakeStruct AGGBF7BA4_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 350 MakeStruct AGGBF7BA4_2, typeof(UnityEngine.Color), V4, V5, V6, V7\n\tX0 = CodeStage.AntiCheat.Detectors.WallHackDetector::ColorsDiffer(X0, AGGBF7BA4_1, AGGBF7BA4_2, X1);\n\tV4 = *([X20+B0]);\n\tV5 = *([X20+B4]);\n\tV6 = *([X20+B8]);\n\tV7 = *([X20+BC]);\n\tV1 = stack[38];\n\tV0 = stack[3C];\n\tV3 = stack[30];\n\tV2 = stack[34];\n\tX24 = X0;\n\t// 361 MakeStruct AGGBF7BBC_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 362 MakeStruct AGGBF7BBC_2, typeof(UnityEngine.Color), V4, V5, V6, V7\n\tX0 = CodeStage.AntiCheat.Detectors.WallHackDetector::ColorsDiffer(X0, AGGBF7BBC_1, AGGBF7BBC_2, X1);\n\tV4 = *([X20+B0]);\n\tV5 = *([X20+B4]);\n\tV6 = *([X20+B8]);\n\tV7 = *([X20+BC]);\n\tV1 = stack[28];\n\tV0 = stack[2C];\n\tV3 = stack[20];\n\tV2 = stack[24];\n\tX25 = X0;\n\t// 373 MakeStruct AGGBF7BD4_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 374 MakeStruct AGGBF7BD4_2, typeof(UnityEngine.Color), V4, V5, V6, V7\n\tX0 = CodeStage.AntiCheat.Detectors.WallHackDetector::ColorsDiffer(X0, AGGBF7BD4_1, AGGBF7BD4_2, X1);\n\tV4 = *([X20+C0]);\n\tV5 = *([X20+C4]);\n\tV6 = *([X20+C8]);\n\tV7 = *([X20+CC]);\n\tV1 = stack[18];\n\tV0 = stack[1C];\n\tV3 = stack[10];\n\tV2 = stack[14];\n\tX26 = X0;\n\t// 385 MakeStruct AGGBF7BEC_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 386 MakeStruct AGGBF7BEC_2, typeof(UnityEngine.Color), V4, V5, V6, V7\n\tX0 = CodeStage.AntiCheat.Detectors.WallHackDetector::ColorsDiffer(X0, AGGBF7BEC_1, AGGBF7BEC_2, X1);\n\tV4 = *([X20+C0]);\n\tV5 = *([X20+C4]);\n\tV6 = *([X20+C8]);\n\tV7 = *([X20+CC]);\n\tV1 = stack[8];\n\tV0 = stack[C];\n\tV3 = stack[0];\n\tV2 = stack[4];\n\tX27 = X0;\n\t// 397 MakeStruct AGGBF7C04_1, typeof(UnityEngine.Color), V0, V1, V2, V3\n\t// 398 MakeStruct AGGBF7C04_2, typeof(UnityEngine.Color), V4, V5, V6,\n// ... truncated")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 3;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 3;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 4341760 + 128;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X9_v2 (System.Int32)+v64 @ X8_v3 (System.Int32)]");
					int num4 = (int)((nint)0 << 2);
					int num5 = 12548204 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000447")]
			[Address(RVA = "0xBF3C70", Offset = "0xBF3C70", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200004C")]
		private sealed class _003CInitDetector_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000185")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000186")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000187")]
			[FieldOffset(Offset = "0x20")]
			public WallHackDetector _003C_003E4__this;

			[Token(Token = "0x17000042")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600044C")]
				[Address(RVA = "0xBF3D54", Offset = "0xBF3D54", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000043")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600044E")]
				[Address(RVA = "0xBF3D94", Offset = "0xBF3D94", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000449")]
			[Address(RVA = "0xBF30A4", Offset = "0xBF30A4", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CInitDetector_003Ed__71(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600044A")]
			[Address(RVA = "0xBF3CB0", Offset = "0xBF3CB0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600044B")]
			[Address(RVA = "0xBF3CB4", Offset = "0xBF3CB4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<>4__this;\n\tv11 = this.<>1__state == 1;\n\tif (v11) goto L_001C;\n\tv16 = this.<>1__state == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tthis.<>1__state = 1;\n\tthis.<>2__current = v6.waitForEndOfFrame;\n\tgoto L_003A;\nL_001C:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this.<>4__this);\n\tv60 = ~v6.checkRigidbody;\n\tif (v60) goto L_0027;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartRigidModule(this.<>4__this);\nL_0027:\n\tv70 = ~v6.checkController;\n\tif (v70) goto L_002C;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartControllerModule(this.<>4__this);\nL_002C:\n\tv74 = ~v6.checkWireframe;\n\tif (v74) goto L_0031;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartWireframeModule(this.<>4__this);\nL_0031:\n\tv25 = ~v6.checkRaycast;\n\tif (v25) goto L_003A;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartRaycastModule(this.<>4__this);\nL_003A:\n\treturn v55;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				WallHackDetector wallHackDetector = _003C_003E4__this;
				int result;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state != 0)
					{
						goto IL_016b;
					}
					_003C_003E1__state = -1;
					_003C_003E1__state = 1;
					_003C_003E2__current = wallHackDetector.waitForEndOfFrame;
					result = 1;
				}
				else
				{
					_003C_003E1__state = -1;
					_003C_003E4__this.UpdateServiceContainer();
					if (wallHackDetector.CheckRigidbody)
					{
						_003C_003E4__this.StartRigidModule();
					}
					if (wallHackDetector.CheckController)
					{
						_003C_003E4__this.StartControllerModule();
					}
					if (wallHackDetector.CheckWireframe)
					{
						_003C_003E4__this.StartWireframeModule();
					}
					bool flag = !wallHackDetector.CheckRaycast;
					result = (wallHackDetector.CheckRaycast ? 1 : 0);
					if (!flag)
					{
						_003C_003E4__this.StartRaycastModule();
						goto IL_016b;
					}
				}
				goto IL_0179;
				IL_0179:
				return (byte)result != 0;
				IL_016b:
				result = 0;
				goto IL_0179;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600044D")]
			[Address(RVA = "0xBF3D5C", Offset = "0xBF3D5C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000158")]
		public const string ComponentName = "WallHack Detector";

		[Token(Token = "0x4000159")]
		internal const string FinalLogPrefix = "[ACTk] WallHack Detector: ";

		[Token(Token = "0x400015A")]
		internal const string WireframeShaderName = "Hidden/ACTk/WallHackTexture";

		[Token(Token = "0x400015B")]
		private const string ServiceContainerName = "[WH Detector Service]";

		[Token(Token = "0x400015C")]
		private const int ShaderTextureSize = 4;

		[Token(Token = "0x400015D")]
		private const int RenderTextureSize = 4;

		[Token(Token = "0x400015E")]
		private const int ColorsDifferenceThreshold = 5;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x4C")]
		private readonly Vector3 rigidPlayerVelocity;

		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x58")]
		private readonly WaitForEndOfFrame waitForEndOfFrame;

		[SerializeField]
		[Tooltip("Check for the \"walk through the walls\" kind of cheats made via Rigidbody hacks?")]
		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x60")]
		private bool checkRigidbody;

		[Tooltip("Check for the \"walk through the walls\" kind of cheats made via Character Controller hacks?")]
		[SerializeField]
		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x61")]
		private bool checkController;

		[Tooltip("Check for the \"see through the walls\" kind of cheats made via shader or driver hacks (wireframe, color alpha, etc.)?")]
		[SerializeField]
		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x62")]
		private bool checkWireframe;

		[Tooltip("Check for the \"shoot through the walls\" kind of cheats made via Raycast hacks?")]
		[SerializeField]
		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x63")]
		private bool checkRaycast;

		[Range(1f, 60f)]
		[Tooltip("Delay between Wireframe module checks, from 1 up to 60 secs.")]
		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x64")]
		public int wireframeDelay;

		[Range(1f, 60f)]
		[Tooltip("Delay between Raycast module checks, from 1 up to 60 secs.")]
		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x68")]
		public int raycastDelay;

		[Tooltip("World position of the container for service objects within 3x3x3 cube (drawn as red wire cube in scene).")]
		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x6C")]
		public Vector3 spawnPosition;

		[Tooltip("Maximum false positives in a row for each detection module before registering a wall hack.")]
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x78")]
		public byte maxFalsePositives;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x80")]
		private GameObject serviceContainer;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x88")]
		private GameObject solidWall;

		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x90")]
		private GameObject thinWall;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x98")]
		private Camera wfCamera;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0xA0")]
		private MeshRenderer foregroundRenderer;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0xA8")]
		private MeshRenderer backgroundRenderer;

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0xB0")]
		private Color wfColor1;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0xC0")]
		private Color wfColor2;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0xD0")]
		private Shader wfShader;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0xD8")]
		private Material wfMaterial;

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0xE0")]
		private Texture2D shaderTexture;

		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0xE8")]
		private Texture2D targetTexture;

		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0xF0")]
		private RenderTexture renderTexture;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0xF8")]
		private int whLayer;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0xFC")]
		private int raycastMask;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x100")]
		private Rigidbody rigidPlayer;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x108")]
		private CharacterController charControllerPlayer;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x110")]
		private float charControllerVelocity;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x114")]
		private byte rigidbodyDetections;

		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x115")]
		private byte controllerDetections;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x116")]
		private byte wireframeDetections;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x117")]
		private byte raycastDetections;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x118")]
		private bool wireframeDetected;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x120")]
		private readonly RaycastHit[] rayHits;

		[Token(Token = "0x1700003C")]
		public bool CheckRigidbody
		{
			[Token(Token = "0x6000415")]
			[Address(RVA = "0xBF07BC", Offset = "0xBF07BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.checkRigidbody;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CheckRigidbody;
			}
			[Token(Token = "0x6000416")]
			[Address(RVA = "0xBF07C4", Offset = "0xBF07C4", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35573]) = v36;\nL_0017:\n\tv42 = this.checkRigidbody == value;\n\tif (v42) goto L_0050;\n\tgoto L_0026;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v49, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv57 = UnityEngine.Application::get_isPlaying();\n\tv61 = v57 == 0;\n\tif (v61) goto L_0050;\n\tv58 = UnityEngine.Behaviour::get_enabled(this);\n\tv62 = v58 == 0;\n\tif (v62) goto L_0050;\n\tv101 = UnityEngine.Component::get_gameObject(this);\n\tv59 = UnityEngine.GameObject::get_activeSelf(v101);\n\tv63 = v59 == 0;\n\tif (v63) goto L_0050;\n\tthis.checkRigidbody = value;\n\tv64 = ~this.started;\n\tif (v64) goto L_0050;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\tv84 = ~this.checkRigidbody;\n\tif (v84) goto L_0057;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartRigidModule(this);\n\treturn;\nL_0050:\n\treturn;\nL_0057:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopRigidModule(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (CheckRigidbody == value || !Application.isPlaying || !base.enabled)
				{
					return;
				}
				GameObject gameObject = base.gameObject;
				if (!gameObject.activeSelf)
				{
					return;
				}
				checkRigidbody = value;
				if (IsStarted)
				{
					UpdateServiceContainer();
					if (CheckRigidbody)
					{
						StartRigidModule();
					}
					else
					{
						StopRigidModule();
					}
				}
			}
		}

		[Token(Token = "0x1700003D")]
		public bool CheckController
		{
			[Token(Token = "0x6000417")]
			[Address(RVA = "0xBF1BBC", Offset = "0xBF1BBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.checkController;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CheckController;
			}
			[Token(Token = "0x6000418")]
			[Address(RVA = "0xBF1BC4", Offset = "0xBF1BC4", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35574]) = v36;\nL_0017:\n\tv42 = this.checkController == value;\n\tif (v42) goto L_0050;\n\tgoto L_0026;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v49, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv57 = UnityEngine.Application::get_isPlaying();\n\tv61 = v57 == 0;\n\tif (v61) goto L_0050;\n\tv58 = UnityEngine.Behaviour::get_enabled(this);\n\tv62 = v58 == 0;\n\tif (v62) goto L_0050;\n\tv101 = UnityEngine.Component::get_gameObject(this);\n\tv59 = UnityEngine.GameObject::get_activeSelf(v101);\n\tv63 = v59 == 0;\n\tif (v63) goto L_0050;\n\tthis.checkController = value;\n\tv64 = ~this.started;\n\tif (v64) goto L_0050;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\tv84 = ~this.checkController;\n\tif (v84) goto L_0057;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartControllerModule(this);\n\treturn;\nL_0050:\n\treturn;\nL_0057:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopControllerModule(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (CheckController == value || !Application.isPlaying || !base.enabled)
				{
					return;
				}
				GameObject gameObject = base.gameObject;
				if (!gameObject.activeSelf)
				{
					return;
				}
				checkController = value;
				if (IsStarted)
				{
					UpdateServiceContainer();
					if (CheckController)
					{
						StartControllerModule();
					}
					else
					{
						StopControllerModule();
					}
				}
			}
		}

		[Token(Token = "0x1700003E")]
		public bool CheckWireframe
		{
			[Token(Token = "0x6000419")]
			[Address(RVA = "0xBF1E48", Offset = "0xBF1E48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.checkWireframe;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CheckWireframe;
			}
			[Token(Token = "0x600041A")]
			[Address(RVA = "0xBF1E50", Offset = "0xBF1E50", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35575]) = v36;\nL_0017:\n\tv42 = this.checkWireframe == value;\n\tif (v42) goto L_0050;\n\tgoto L_0026;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v49, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv57 = UnityEngine.Application::get_isPlaying();\n\tv61 = v57 == 0;\n\tif (v61) goto L_0050;\n\tv58 = UnityEngine.Behaviour::get_enabled(this);\n\tv62 = v58 == 0;\n\tif (v62) goto L_0050;\n\tv101 = UnityEngine.Component::get_gameObject(this);\n\tv59 = UnityEngine.GameObject::get_activeSelf(v101);\n\tv63 = v59 == 0;\n\tif (v63) goto L_0050;\n\tthis.checkWireframe = value;\n\tv64 = ~this.started;\n\tif (v64) goto L_0050;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\tv84 = ~this.checkWireframe;\n\tif (v84) goto L_0057;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartWireframeModule(this);\n\treturn;\nL_0050:\n\treturn;\nL_0057:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopWireframeModule(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (CheckWireframe == value || !Application.isPlaying || !base.enabled)
				{
					return;
				}
				GameObject gameObject = base.gameObject;
				if (!gameObject.activeSelf)
				{
					return;
				}
				checkWireframe = value;
				if (IsStarted)
				{
					UpdateServiceContainer();
					if (CheckWireframe)
					{
						StartWireframeModule();
					}
					else
					{
						StopWireframeModule();
					}
				}
			}
		}

		[Token(Token = "0x1700003F")]
		public bool CheckRaycast
		{
			[Token(Token = "0x600041B")]
			[Address(RVA = "0xBF1FFC", Offset = "0xBF1FFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.checkRaycast;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CheckRaycast;
			}
			[Token(Token = "0x600041C")]
			[Address(RVA = "0xBF2004", Offset = "0xBF2004", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35576]) = v36;\nL_0017:\n\tv42 = this.checkRaycast == value;\n\tif (v42) goto L_0050;\n\tgoto L_0026;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v49, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv57 = UnityEngine.Application::get_isPlaying();\n\tv61 = v57 == 0;\n\tif (v61) goto L_0050;\n\tv58 = UnityEngine.Behaviour::get_enabled(this);\n\tv62 = v58 == 0;\n\tif (v62) goto L_0050;\n\tv101 = UnityEngine.Component::get_gameObject(this);\n\tv59 = UnityEngine.GameObject::get_activeSelf(v101);\n\tv63 = v59 == 0;\n\tif (v63) goto L_0050;\n\tthis.checkRaycast = value;\n\tv64 = ~this.started;\n\tif (v64) goto L_0050;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\tv84 = ~this.checkRaycast;\n\tif (v84) goto L_0057;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartRaycastModule(this);\n\treturn;\nL_0050:\n\treturn;\nL_0057:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopRaycastModule(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (CheckRaycast == value || !Application.isPlaying || !base.enabled)
				{
					return;
				}
				GameObject gameObject = base.gameObject;
				if (!gameObject.activeSelf)
				{
					return;
				}
				checkRaycast = value;
				if (IsStarted)
				{
					UpdateServiceContainer();
					if (CheckRaycast)
					{
						StartRaycastModule();
					}
					else
					{
						StopRaycastModule();
					}
				}
			}
		}

		[Token(Token = "0x600041D")]
		[Address(RVA = "0xBF219C", Offset = "0xBF219C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35577]) = v34;\nL_0016:\n\treturnVal1 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::get_GetOrCreateInstance();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static WallHackDetector AddToSceneOrGetExisting()
		{
			return KeepAliveBehaviour<WallHackDetector>.GetOrCreateInstance;
		}

		[Token(Token = "0x600041E")]
		[Address(RVA = "0xBF21DC", Offset = "0xBF21DC", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv20 = UnityEngine.Debug;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv62 = UnityEngine.Object;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv73 = \"[ACTk] WallHack Detector: can't be started since it doesn't exists in scene or not yet initialized!\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A35578]) = v41;\nL_0023:\n\tgoto L_002D;\n\tv51 = 0xB348B0(v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002D:\n\tgoto L_0035;\n\tv64 = 0xB348B0(v55, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0035:\n\tgoto L_003B;\n\tv74 = v66;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v74, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003B:\n\tv80 = UnityEngine.Object::op_Inequality(v67.<Instance>k__BackingField, 0);\n\tv82 = v80 == 0;\n\tif (v82) goto L_0091;\n\tgoto L_004D;\n\tv97 = 0xB348B0(v84, v78, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_004D:\n\tgoto L_0052;\n\tv109 = 0xB348B0(v100, v78, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0052:\n\tv159 = v112.<Instance>k__BackingField;\n\tgoto L_0061;\n\tv120 = v113;\n\tv121 = 0xB348B0(v120, v78, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv124 = v121;\nL_0061:\n\tgoto L_0064;\n\tv167 = 0xB348B0(v126, v78, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0064:\n\tv170 = v169.<Instance>k__BackingField;\n\tgoto L_0078;\n\tv204 = 0xB348B0(v197, v78, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0078:\n\tgoto L_007B;\n\tv212 = 0xB348B0(v207, v78, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_007B:\n\tv158 = v213.<Instance>k__BackingField;\n\t// 134 MakeStruct v133 @ AGGBF635C_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v170.spawnPosition (UnityEngine.Vector3), v170.spawnPosition.y (System.Single), v170.spawnPosition.z (System.Single)\n\tv154 = CodeStage.AntiCheat.Detectors.WallHackDetector::StartDetectionInternal(v112.<Instance>k__BackingField, 0, v133, v158.maxFalsePositives);\n\tgoto L_009F;\nL_0091:\n\tgoto L_0095;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v92, v78, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0095:\n\tUnityEngine.Debug::LogError(\"[ACTk] WallHack Detector: can't be started since it doesn't exists in scene or not yet initialized!\");\nL_009F:\n\treturn v159;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static WallHackDetector StartDetection()
		{
			WallHackDetector result;
			if (KeepAliveBehaviour<WallHackDetector>.Instance != null)
			{
				result = KeepAliveBehaviour<WallHackDetector>.Instance;
				WallHackDetector wallHackDetector = KeepAliveBehaviour<WallHackDetector>.Instance;
				WallHackDetector wallHackDetector2 = KeepAliveBehaviour<WallHackDetector>.Instance;
				Vector3 servicePosition = default(Vector3);
				servicePosition.x = wallHackDetector.spawnPosition.x;
				servicePosition.y = wallHackDetector.spawnPosition.y;
				servicePosition.z = wallHackDetector.spawnPosition.z;
				WallHackDetector wallHackDetector3 = KeepAliveBehaviour<WallHackDetector>.Instance.StartDetectionInternal(null, servicePosition, wallHackDetector2.maxFalsePositives);
			}
			else
			{
				Debug.LogError("[ACTk] WallHack Detector: can't be started since it doesn't exists in scene or not yet initialized!");
				result = null;
			}
			return result;
		}

		[Token(Token = "0x600041F")]
		[Address(RVA = "0xBF2580", Offset = "0xBF2580", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35579]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::get_GetOrCreateInstance();\n\t// 32 MakeStruct v49 @ AGGBF65D4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v39.spawnPosition (UnityEngine.Vector3), v39.spawnPosition.y (System.Single), v39.spawnPosition.z (System.Single)\n\treturnVal1 = CodeStage.AntiCheat.Detectors.WallHackDetector::StartDetection(callback, v49);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static WallHackDetector StartDetection(Action callback)
		{
			WallHackDetector getOrCreateInstance = KeepAliveBehaviour<WallHackDetector>.GetOrCreateInstance;
			Vector3 vector = default(Vector3);
			vector.x = getOrCreateInstance.spawnPosition.x;
			vector.y = getOrCreateInstance.spawnPosition.y;
			vector.z = getOrCreateInstance.spawnPosition.z;
			return StartDetection(callback, vector);
		}

		[Token(Token = "0x6000420")]
		[Address(RVA = "0xBF25DC", Offset = "0xBF25DC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, spawnPosition, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A3557A]) = v46;\nL_001C:\n\tv48 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.WallHackDetector::StartDetection(callback, spawnPosition, v48.maxFalsePositives);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static WallHackDetector StartDetection(Action callback, Vector3 spawnPosition)
		{
			WallHackDetector getOrCreateInstance = KeepAliveBehaviour<WallHackDetector>.GetOrCreateInstance;
			return StartDetection(callback, spawnPosition, getOrCreateInstance.maxFalsePositives);
		}

		[Token(Token = "0x6000421")]
		[Address(RVA = "0xBF265C", Offset = "0xBF265C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, maxFalsePositives, methodInfo, v37, v38, v39, v40, v41, spawnPosition, v0, v2, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A3557B]) = v49;\nL_001E:\n\tv51 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.WallHackDetector::StartDetectionInternal(v51, callback, spawnPosition, maxFalsePositives);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static WallHackDetector StartDetection(Action callback, Vector3 spawnPosition, byte maxFalsePositives)
		{
			WallHackDetector getOrCreateInstance = KeepAliveBehaviour<WallHackDetector>.GetOrCreateInstance;
			return getOrCreateInstance.StartDetectionInternal(callback, spawnPosition, maxFalsePositives);
		}

		[Token(Token = "0x6000422")]
		[Address(RVA = "0xBF26E8", Offset = "0xBF26E8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3557C]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.WallHackDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+208]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+210]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.WallHackDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.WallHackDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StopDetection()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<WallHackDetector>.Instance != null)
			{
				WallHackDetector wallHackDetector = KeepAliveBehaviour<WallHackDetector>.Instance;
				nint num = (nint)wallHackDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+208]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+210]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000423")]
		[Address(RVA = "0xBF27E0", Offset = "0xBF27E0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3557D]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.WallHackDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+1C8]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+1D0]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.WallHackDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.WallHackDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Dispose()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<WallHackDetector>.Instance != null)
			{
				WallHackDetector wallHackDetector = KeepAliveBehaviour<WallHackDetector>.Instance;
				nint num = (nint)wallHackDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+1C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.WallHackDetector>)+1D0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000424")]
		[Address(RVA = "0xBF28D4", Offset = "0xBF28D4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = UnityEngine.RaycastHit[];\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = UnityEngine.WaitForEndOfFrame;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A3557E]) = v46;\nL_0020:\n\tthis.rigidPlayerVelocity = 0;\n\tthis.rigidPlayerVelocity.y = 0f;\n\tthis.rigidPlayerVelocity.z = 1f;\n\tv49 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v49);\n\tthis.waitForEndOfFrame = v49;\n\tthis.raycastDelay = 0xA;\n\tthis.maxFalsePositives = 3;\n\tthis.checkRigidbody = 2.1228279462E-313d;\n\tthis.wfColor1 = *([407FF0]);\n\tthis.wfColor2 = *([407FF0]);\n\tthis.whLayer = -1;\n\t// 56 NewArr v66 @ X0_v5 (UnityEngine.RaycastHit[]), typeof(UnityEngine.RaycastHit[]), 10\n\tthis.rayHits = v66;\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::.ctor(this);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private WallHackDetector()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Invalid comparison between Unknown and I4
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Invalid comparison between Unknown and I4
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Invalid comparison between Unknown and I4
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Invalid comparison between Unknown and I4
			//IL_00fb: Expected I4, but got F8
			//IL_010d: Expected O, but got I
			//IL_011f: Expected O, but got I
			base._002Ector();
			rigidPlayerVelocity = default(Vector3);
			rigidPlayerVelocity.y = 0f;
			rigidPlayerVelocity.z = 1f;
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			this.waitForEndOfFrame = waitForEndOfFrame;
			raycastDelay = 10;
			maxFalsePositives = 3;
			checkRigidbody = (2.1228279462E-313 & 0xFF) > 0;
			checkController = ((2.1228279462E-313 >> 8) & 0xFF) > 0;
			checkWireframe = ((2.1228279462E-313 >> 16) & 0xFF) > 0;
			checkRaycast = ((2.1228279462E-313 >> 24) & 0xFF) > 0;
			wireframeDelay = 2.1228279462E-313 >> 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407FF0]");
			wfColor1 = (Color)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407FF0]");
			wfColor2 = (Color)0;
			whLayer = -1;
			raycastMask = -1;
			RaycastHit[] array = new RaycastHit[10];
			rayHits = array;
		}

		[Token(Token = "0x6000425")]
		[Address(RVA = "0xBF29B0", Offset = "0xBF29B0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = UnityEngine.Object;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3557F]) = v42;\nL_001B:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::OnDestroy(this);\n\tUnityEngine.MonoBehaviour::StopAllCoroutines(this);\n\tgoto L_0029;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v49, v48, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tv59 = UnityEngine.Object::op_Inequality(this.serviceContainer, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003C;\n\tgoto L_0036;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v62, v57, v58, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0036:\n\tUnityEngine.Object::Destroy(this.serviceContainer);\nL_003C:\n\tgoto L_0041;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v74, v67, v58, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0041:\n\tv86 = UnityEngine.Object::op_Inequality(this.wfMaterial, 0);\n\tv88 = v86 == 0;\n\tif (v88) goto L_0062;\n\tUnityEngine.Material::set_mainTexture(this.wfMaterial, 0);\n\tUnityEngine.Material::set_shader(this.wfMaterial, 0);\n\tthis.wfShader = 0;\n\tthis.shaderTexture = 0;\n\tUnityEngine.RenderTexture::DiscardContents(this.renderTexture);\n\tUnityEngine.RenderTexture::Release(this.renderTexture);\n\tthis.renderTexture = 0;\nL_0062:\n\tv104 = *([this @ X0 (CodeStage.AntiCheat.Detectors.WallHackDetector)+24]) - 1;\n\t*([this @ X0 (CodeStage.AntiCheat.Detectors.WallHackDetector)+24]) = v104;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnDestroy()
		{
			//IL_00f7: Expected O, but got I
			base.OnDestroy();
			StopAllCoroutines();
			if (serviceContainer != null)
			{
				UnityEngine.Object.Destroy(serviceContainer);
			}
			if (wfMaterial != null)
			{
				wfMaterial.mainTexture = null;
				wfMaterial.shader = null;
				wfShader = null;
				shaderTexture = null;
				renderTexture.DiscardContents();
				renderTexture.Release();
				renderTexture = null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (CodeStage.AntiCheat.Detectors.WallHackDetector)+24]");
			object obj = -1;
		}

		[Token(Token = "0x6000426")]
		[Address(RVA = "0xBF2AF8", Offset = "0xBF2AF8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = UnityEngine.Object;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35580]) = v33;\nL_0011:\n\tv35 = ~this.isRunning;\n\tif (v35) goto L_004C;\n\tv37 = ~this.checkRigidbody;\n\tif (v37) goto L_004C;\n\tgoto L_0022;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tv78 = UnityEngine.Object::op_Equality(this.rigidPlayer, 0);\n\tv128 = v78 == 0;\n\tv82 = ~v128;\n\tif (v82) goto L_004C;\n\tv79 = UnityEngine.Component::get_transform(this.rigidPlayer);\n\tv133 = UnityEngine.Transform::get_localPosition(v79);\n\tv39 = v133.z <= 1f;\n\tif (v39) goto L_004C;\n\tv85 = this.rigidbodyDetections + 1;\n\tthis.rigidbodyDetections = v85;\n\tv77 = CodeStage.AntiCheat.Detectors.WallHackDetector::Detect(this);\n\tv81 = v77 == 0;\n\tif (v81) goto L_004E;\nL_004C:\n\treturn;\nL_004E:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopRigidModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartRigidModule(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			if (!IsRunning || !CheckRigidbody || rigidPlayer == null)
			{
				return;
			}
			Transform transform = rigidPlayer.transform;
			if (transform.localPosition.z > 1f)
			{
				int num = rigidbodyDetections + 1;
				rigidbodyDetections = (byte)num;
				if (!Detect())
				{
					StopRigidModule();
					StartRigidModule();
				}
			}
		}

		[Token(Token = "0x6000427")]
		[Address(RVA = "0xBF2C24", Offset = "0xBF2C24", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = UnityEngine.Object;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35581]) = v33;\nL_0011:\n\tv35 = ~this.isRunning;\n\tif (v35) goto L_0069;\n\tv37 = ~this.checkController;\n\tif (v37) goto L_0069;\n\tgoto L_0022;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v112, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tv94 = UnityEngine.Object::op_Equality(this.charControllerPlayer, 0);\n\tv152 = v94 == 0;\n\tv98 = ~v152;\n\tif (v98) goto L_0069;\n\tv51 = this.charControllerVelocity <= 0;\n\tif (v51) goto L_0069;\n\tv134 = UnityEngine.Random::Range(-0.002f, 0.002f);\n\t// 66 MakeStruct v39 @ AGGBF6CCC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v134 @ V0_v4 (System.Single), 0, this.charControllerVelocity (System.Single)\n\tv164 = UnityEngine.CharacterController::Move(this.charControllerPlayer, v39);\n\tv95 = UnityEngine.Component::get_transform(this.charControllerPlayer);\n\tv169 = UnityEngine.Transform::get_localPosition(v95);\n\tv49 = v169.z <= 1f;\n\tif (v49) goto L_0069;\n\tv101 = this.controllerDetections + 1;\n\tthis.controllerDetections = v101;\n\tv93 = CodeStage.AntiCheat.Detectors.WallHackDetector::Detect(this);\n\tv97 = v93 == 0;\n\tif (v97) goto L_006B;\nL_0069:\n\treturn;\nL_006B:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopControllerModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartControllerModule(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (!IsRunning || !CheckController || charControllerPlayer == null || !(charControllerVelocity > 0f))
			{
				return;
			}
			float x = UnityEngine.Random.Range(-0.002f, 0.002f);
			Vector3 motion = default(Vector3);
			motion.x = x;
			motion.y = 0f;
			motion.z = charControllerVelocity;
			CollisionFlags collisionFlags = charControllerPlayer.Move(motion);
			Transform transform = charControllerPlayer.transform;
			if (transform.localPosition.z > 1f)
			{
				int num = controllerDetections + 1;
				controllerDetections = (byte)num;
				if (!Detect())
				{
					StopControllerModule();
					StartControllerModule();
				}
			}
		}

		[Token(Token = "0x6000428")]
		[Address(RVA = "0xBF23B0", Offset = "0xBF23B0", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, callback, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\n\tv55 = UnityEngine.Debug;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, callback, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\n\tv67 = \"[ACTk] WallHack Detector: already running!\";\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, callback, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\n\tv75 = \"[ACTk] WallHack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.\";\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, callback, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\n\tv93 = \"[ACTk] WallHack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?\";\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, callback, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\n\tv126 = \"[ACTk] WallHack Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, callback, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A35582]) = v49;\nL_002E:\n\tv53 = ~this.isRunning;\n\tif (v53) goto L_003C;\n\tgoto L_FFFFFFFF;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v57, callback, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\n\tgoto L_005D;\nL_003C:\n\tv65 = UnityEngine.Behaviour::get_enabled(this);\n\tv73 = v65 == 0;\n\tif (v73) goto L_0056;\n\tv88 = callback == 0;\n\tif (v88) goto L_0069;\n\tv120 = ~this.detectionEventHasListener;\n\tif (v120) goto L_0070;\n\tgoto L_0050;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v127, v64, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\nL_0050:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] WallHack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?\", this);\n\tgoto L_0070;\nL_0056:\n\tgoto L_FFFFFFFF;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v89, v64, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\nL_005D:\n\tUnityEngine.Debug::LogWarning(v78, this);\nL_0068:\n\treturn this;\nL_0069:\n\tv121 = ~this.detectionEventHasListener;\n\tif (v121) goto L_0083;\nL_0070:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::add_CheatDetected(this, callback);\n\tthis.spawnPosition = servicePosition;\n\tthis.spawnPosition.y = servicePosition.y;\n\tthis.spawnPosition.z = servicePosition.z;\n\tthis.maxFalsePositives = falsePositivesInRow;\n\tthis.rigidbodyDetections = 0;\n\tv151 = CodeStage.AntiCheat.Detectors.WallHackDetector::InitDetector(this);\n\tv102 = UnityEngine.MonoBehaviour::StartCoroutine(this, v151);\n\tthis.started = 0x101;\n\tgoto L_0068;\nL_0083:\n\tgoto L_008A;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v144, v64, falsePositivesInRow, methodInfo, v37, v38, v39, v40, servicePosition, v0, v2, v41, v42, v43, v44, v45);\nL_008A:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] WallHack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.\", this);\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\tgoto L_0068;\n\treturn X0;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private WallHackDetector StartDetectionInternal(Action callback, Vector3 servicePosition, byte falsePositivesInRow)
		{
			string message;
			if (IsRunning)
			{
				message = "[ACTk] WallHack Detector: already running!";
			}
			else
			{
				if (base.enabled)
				{
					if (callback != null)
					{
						if (detectionEventHasListener)
						{
							Debug.LogWarning("[ACTk] WallHack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
						}
					}
					else if (!detectionEventHasListener)
					{
						Debug.LogWarning("[ACTk] WallHack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
						base.enabled = false;
						goto IL_009f;
					}
					base.CheatDetected += callback;
					spawnPosition = servicePosition;
					spawnPosition.y = servicePosition.y;
					spawnPosition.z = servicePosition.z;
					maxFalsePositives = falsePositivesInRow;
					rigidbodyDetections = 0;
					controllerDetections = 0;
					wireframeDetections = 0;
					raycastDetections = 0;
					IEnumerator routine = InitDetector();
					Coroutine coroutine = StartCoroutine(routine);
					started = true;
					goto IL_009f;
				}
				message = "[ACTk] WallHack Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!";
			}
			Debug.LogWarning(message, this);
			goto IL_009f;
			IL_009f:
			return this;
		}

		[Token(Token = "0x6000429")]
		[Address(RVA = "0xBF2D98", Offset = "0xBF2D98", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 5 MakeStruct v6 @ AGGBF6DA8_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.spawnPosition (UnityEngine.Vector3), this.spawnPosition.y (System.Single), this.spawnPosition.z (System.Single)\n\tv7 = CodeStage.AntiCheat.Detectors.WallHackDetector::StartDetectionInternal(this, 0, v6, this.maxFalsePositives);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void StartDetectionAutomatically()
		{
			Vector3 servicePosition = default(Vector3);
			servicePosition.x = spawnPosition.x;
			servicePosition.y = spawnPosition.y;
			servicePosition.z = spawnPosition.z;
			WallHackDetector wallHackDetector = StartDetectionInternal(null, servicePosition, maxFalsePositives);
		}

		[Token(Token = "0x600042A")]
		[Address(RVA = "0xBF2DAC", Offset = "0xBF2DAC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35583]) = v33;\nL_0011:\n\tv35 = ~this.isRunning;\n\tif (v35) goto L_0029;\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::PauseDetector(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopRigidModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopControllerModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopWireframeModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopRaycastModule(this);\n\treturn;\nL_0029:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void PauseDetector()
		{
			if (IsRunning)
			{
				base.PauseDetector();
				StopRigidModule();
				StopControllerModule();
				StopWireframeModule();
				StopRaycastModule();
			}
		}

		[Token(Token = "0x600042B")]
		[Address(RVA = "0xBF2E28", Offset = "0xBF2E28", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35584]) = v37;\nL_0015:\n\tv40 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::ResumeDetector(this);\n\tv43 = v40 == 0;\n\tif (v43) goto L_0034;\n\tv45 = ~this.checkRigidbody;\n\tif (v45) goto L_0020;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartRigidModule(this);\nL_0020:\n\tv61 = ~this.checkController;\n\tif (v61) goto L_0025;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartControllerModule(this);\nL_0025:\n\tv65 = ~this.checkWireframe;\n\tif (v65) goto L_002A;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartWireframeModule(this);\nL_002A:\n\tv50 = ~this.checkRaycast;\n\tif (v50) goto L_0034;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StartRaycastModule(this);\nL_0034:\n\treturn v40;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool ResumeDetector()
		{
			bool flag = base.ResumeDetector();
			if (flag)
			{
				if (CheckRigidbody)
				{
					StartRigidModule();
				}
				if (CheckController)
				{
					StartControllerModule();
				}
				if (CheckWireframe)
				{
					StartWireframeModule();
				}
				if (CheckRaycast)
				{
					StartRaycastModule();
				}
			}
			return flag;
		}

		[Token(Token = "0x600042C")]
		[Address(RVA = "0xBF2EC0", Offset = "0xBF2EC0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35585]) = v33;\nL_0013:\n\tv37 = ~this.started;\n\tif (v37) goto L_0020;\n\tv42 = CodeStage.AntiCheat.Detectors.WallHackDetector::PauseDetector(this);\nL_0020:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::StopDetectionInternal(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void StopDetectionInternal()
		{
			if (IsStarted)
			{
				PauseDetector();
			}
			base.StopDetectionInternal();
		}

		[Token(Token = "0x600042D")]
		[Address(RVA = "0xBF2F24", Offset = "0xBF2F24", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"WallHack Detector\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35586]) = v34;\nL_0016:\n\treturn \"WallHack Detector\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string GetComponentName()
		{
			return "WallHack Detector";
		}

		[Token(Token = "0x600042E")]
		[Address(RVA = "0xBF089C", Offset = "0xBF089C", Length = "0x1084")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005E;\n\tv18 = UnityEngine.Color[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Debug;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv692 = Il2CppMethodInfo;\n\tv693 = \"il2cpp_codegen_initialize_runtime_metadata\"(v692, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv827 = Il2CppMethodInfo;\n\tv828 = \"il2cpp_codegen_initialize_runtime_metadata\"(v827, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv989 = Il2CppMethodInfo;\n\tv990 = \"il2cpp_codegen_initialize_runtime_metadata\"(v989, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1005 = Il2CppMethodInfo;\n\tv1006 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1005, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1029 = UnityEngine.GameObject;\n\tv1030 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1029, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1038 = UnityEngine.Material;\n\tv1039 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1038, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1043 = UnityEngine.Object;\n\tv1044 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1043, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1069 = UnityEngine.RenderTexture;\n\tv1070 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1069, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1082 = System.String[];\n\tv1083 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1082, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1102 = UnityEngine.Texture2D;\n\tv1103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1102, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1137 = \"Hidden/ACTk/WallHackTexture\";\n\tv1138 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1137, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1166 = \"Ignore Raycast\";\n\tv1167 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1166, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1178 = \"WireframeBack\";\n\tv1179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1178, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1187 = \"WireframeCamera\";\n\tv1188 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1187, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1219 = \"[WH Detector Service]\";\n\tv1220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1219, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1244 = \"WireframeFore\";\n\tv1245 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1244, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1259 = \"[ACTk] WallHack Detector: can't find 'Hidden/ACTk/WallHackTexture' shader!\\nPlease make sure you have it included at the Anti-Cheat Toolkit Settings.\";\n\tv1260 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1259, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1275 = \"[ACTk] WallHack Detector: can't detect wireframe cheats on this platform due to lack of needed shader support!\";\n\tv1276 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1275, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1287 = \"SolidWall\";\n\tv1288 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1287, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv1296 = \"ThinWall\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1296, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35587]) = v38;\nL_005E:\n\tv43 = UnityEngine.Behaviour::get_enabled(this);\n\tv48 = v43 == 0;\n\tif (v48) goto L_0138;\n\tv54 = UnityEngine.Component::get_gameObject(this);\n\tv58 = UnityEngine.GameObject::get_activeSelf(v54);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0138;\n\tv830 = this.whLayer + 1;\n\tv832 = v830 == 0;\n\tv835 = ~v832;\n\tif (v835) goto L_007B;\n\tv995 = UnityEngine.LayerMask::NameToLayer(\"Ignore Raycast\");\n\tthis.whLayer = v995;\nL_007B:\n\tv1000 = this.raycastMask + 1;\n\tv379 = v1000 == 0;\n\tv355 = ~v379;\n\tif (v355) goto L_0098;\n\t// 134 NewArr v472 @ X0_v295 (System.String[]), typeof(System.String[]), 1\n\tv472[0] = \"Ignore Raycast\";\n\tv1012 = UnityEngine.LayerMask::GetMask(v472);\n\tthis.raycastMask = v1012;\nL_0098:\n\tgoto L_009D;\n\tv1031 = \"il2cpp_codegen_runtime_class_init\"(v1016, v1009, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_009D:\n\tv1036 = UnityEngine.Object::op_Equality(this.serviceContainer, 0);\n\tv1041 = v1036 == 0;\n\tif (v1041) goto L_00CA;\n\tv473 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v473, \"[WH Detector Service]\");\n\tthis.serviceContainer = v473;\n\tUnityEngine.GameObject::set_layer(v473, this.whLayer);\n\tv475 = UnityEngine.GameObject::get_transform(this.serviceContainer);\n\t// 189 MakeStruct v1050 @ AGGBF4B18_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.spawnPosition (UnityEngine.Vector3), this.spawnPosition.y (System.Single), this.spawnPosition.z (System.Single)\n\tUnityEngine.Transform::set_position(v475, v1050);\n\tgoto L_00C8;\n\tv1246 = \"il2cpp_codegen_runtime_class_init\"(v1221, v1189, v311, v22, v23, v24, v25, v26, v1051, v1053, v1052, v30, v31, v32, v33, v34);\nL_00C8:\n\tUnityEngine.Object::DontDestroyOnLoad(this.serviceContainer);\nL_00CA:\n\tv1066 = ~this.checkRigidbody;\n\tv1067 = ~v1066;\n\tif (v1067) goto L_00D5;\n\tv1073 = ~this.checkController;\n\tif (v1073) goto L_0157;\nL_00D5:\n\tgoto L_00DA;\n\tv1098 = \"il2cpp_codegen_runtime_class_init\"(v1076, v1055, v1054, v22, v23, v24, v25, v26, v255, v294, v278, v30, v31, v32, v33, v34);\nL_00DA:\n\tv1089 = UnityEngine.Object::op_Equality(this.solidWall, 0);\n\tv1135 = v1089 == 0;\n\tif (v1135) goto L_0153;\n\tv476 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v476, \"SolidWall\");\n\tthis.solidWall = v476;\n\tv1217 = UnityEngine.GameObject::AddComponent(v476);\n\tUnityEngine.GameObject::set_layer(this.solidWall, this.whLayer);\n\tv479 = UnityEngine.GameObject::get_transform(this.solidWall);\n\tv480 = UnityEngine.GameObject::get_transform(this.serviceContainer);\n\tUnityEngine.Transform::set_parent(v479, v480);\n\tv482 = UnityEngine.GameObject::get_transform(this.solidWall);\n\t// 275 MakeStruct v249 @ AGGBF4C2C_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 3f, 3f, 0.5f\n\tUnityEngine.Transform::set_localScale(v482, v249);\n\tv1447 = UnityEngine.GameObject::get_transform(this.solidWall);\n\tgoto L_0131;\n\tv1463 = UnityEngine.Vector3;\n\tv1464 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1463, v470, v314, v22, v23, v24, v25, v26, v256, v295, v279, v30, v31, v32, v33, v34);\n\tv1465 = 1;\n\t*([1A35519]) = v1465;\nL_0131:\n\tUnityEngine.Transform::set_localPosition(v1447, v1129.zeroVector);\n\tgoto L_0173;\nL_0138:\n\tgoto L_013D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v61, v55, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_013D:\n\tv75 = UnityEngine.Object::op_Inequality(this.serviceContainer, 0);\n\tv690 = v75 == 0;\n\tif (v690) goto L_0534;\n\tv879 = this.serviceContainer;\nL_0146:\n\tgoto L_FFFFFFFF;\n\tv1001 = \"il2cpp_codegen_runtime_class_init\"(v876, v875, v869, v844, v843, v842, v841, v26, v866, v868, v867, v859, v860, v8\n// ... truncated")]
		private void UpdateServiceContainer()
		{
			//IL_05f0: Expected O, but got I
			//IL_06ff: Expected O, but got F4
			//IL_136e: Expected O, but got F4
			//IL_0732: Expected I4, but got I8
			//IL_0745: Expected O, but got I8
			//IL_0757: Expected O, but got I4
			//IL_0843: Expected O, but got I
			//IL_0852: Expected O, but got I
			if (base.enabled)
			{
				GameObject gameObject = base.gameObject;
				if (gameObject.activeSelf)
				{
					if (whLayer + 1 == 0)
					{
						int num = LayerMask.NameToLayer("Ignore Raycast");
						whLayer = num;
					}
					if (raycastMask + 1 == 0)
					{
						int mask = LayerMask.GetMask("Ignore Raycast");
						raycastMask = mask;
					}
					if (serviceContainer == null)
					{
						(serviceContainer = new GameObject("[WH Detector Service]")).layer = whLayer;
						Transform transform = serviceContainer.transform;
						Vector3 position = default(Vector3);
						position.x = spawnPosition.x;
						position.y = spawnPosition.y;
						position.z = spawnPosition.z;
						transform.position = position;
						UnityEngine.Object.DontDestroyOnLoad(serviceContainer);
					}
					if (!CheckRigidbody && !CheckController)
					{
						goto IL_038e;
					}
					if (solidWall == null)
					{
						BoxCollider boxCollider = (solidWall = new GameObject("SolidWall")).AddComponent<BoxCollider>();
						solidWall.layer = whLayer;
						Transform transform2 = solidWall.transform;
						Transform parent = serviceContainer.transform;
						transform2.parent = parent;
						Transform transform3 = solidWall.transform;
						Vector3 localScale = default(Vector3);
						localScale.x = 3f;
						localScale.y = 3f;
						localScale.z = 0.5f;
						transform3.localScale = localScale;
						Transform transform4 = solidWall.transform;
						transform4.localPosition = Vector3.zero;
					}
					else if (!CheckRigidbody)
					{
						goto IL_038e;
					}
					goto IL_03fb;
				}
			}
			GameObject gameObject2;
			if (serviceContainer != null)
			{
				gameObject2 = serviceContainer;
				goto IL_035b;
			}
			return;
			IL_04ca:
			if (wfCamera != null)
			{
				GameObject obj = foregroundRenderer.gameObject;
				UnityEngine.Object.Destroy(obj);
				GameObject obj2 = backgroundRenderer.gameObject;
				UnityEngine.Object.Destroy(obj2);
				wfCamera.targetTexture = null;
				GameObject obj3 = wfCamera.gameObject;
				UnityEngine.Object.Destroy(obj3);
			}
			goto IL_131d;
			IL_131d:
			UnityEngine.Object obj4;
			if (CheckRaycast)
			{
				if (thinWall == null)
				{
					(thinWall = GameObject.CreatePrimitive(PrimitiveType.Plane)).name = "ThinWall";
					thinWall.layer = whLayer;
					Transform transform5 = thinWall.transform;
					Transform parent2 = serviceContainer.transform;
					transform5.parent = parent2;
					Transform transform6 = thinWall.transform;
					Vector3 localScale2 = default(Vector3);
					localScale2.x = 0.2f;
					localScale2.y = 1f;
					localScale2.z = 0.2f;
					transform6.localScale = localScale2;
					Transform transform7 = thinWall.transform;
					Vector3 vector = default(Vector3);
					vector.x = 4.712389f;
					vector.y = 0f;
					vector.z = 0f;
					Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
					transform7.localRotation = localRotation;
					Transform transform8 = thinWall.transform;
					Vector3 localPosition = default(Vector3);
					localPosition.x = 0f;
					localPosition.y = 0f;
					localPosition.z = 1.4f;
					transform8.localPosition = localPosition;
					Renderer component = thinWall.GetComponent<Renderer>();
					UnityEngine.Object.Destroy(component);
					MeshFilter component2 = thinWall.GetComponent<MeshFilter>();
					obj4 = component2;
					goto IL_13ff;
				}
				if (CheckRaycast)
				{
					return;
				}
			}
			if (thinWall != null)
			{
				gameObject2 = thinWall;
				goto IL_035b;
			}
			return;
			IL_035b:
			obj4 = gameObject2;
			goto IL_13ff;
			IL_13ff:
			UnityEngine.Object.Destroy(obj4);
			return;
			IL_03fb:
			if (CheckWireframe)
			{
				if (wfCamera == null)
				{
					Shader shader = ((!(wfShader == null)) ? wfShader : (wfShader = Shader.Find("Hidden/ACTk/WallHackTexture")));
					if (shader == null)
					{
						Debug.LogError("[ACTk] WallHack Detector: can't find 'Hidden/ACTk/WallHackTexture' shader!\nPlease make sure you have it included at the Anti-Cheat Toolkit Settings.", this);
					}
					else
					{
						if (wfShader.isSupported)
						{
							object obj5 = (nint)this + 176;
							float num2 = wfColor1.r * wfColor1.r;
							float num3 = wfColor1.a + -1f;
							float num4 = wfColor1.g * wfColor1.g;
							float num5 = wfColor1.b * wfColor1.b;
							float num6 = num2 + num4;
							float num7 = num5 + num6;
							float num8 = num3 * num3;
							float num9 = num7 + num8;
							if (num9 < 9.9999994E-11f)
							{
								Color32 color = GenerateColor();
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
								float num10 = 3.46E-43f / num8;
								wfColor1 = (Color)num10;
								float num11 = num5;
								int num12 = 0;
								Color32 color2 = default(Color32);
								object obj6 = default(object);
								object obj7 = default(object);
								bool flag3;
								do
								{
									Color32 color3 = GenerateColor();
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
									num5 = num11 / num8;
									wfColor2 = (Color)num5;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BF7EB8 (inside CodeStage.AntiCheat.Common.ContainerHolder::.ctor +0x8)");
									num4 = wfColor2.a;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BF7EB8 (inside CodeStage.AntiCheat.Common.ContainerHolder::.ctor +0x8)");
									int num13 = (int)((nint)obj6 & 0xFFFFFFFFL);
									color2 = (Color32)((nint)obj7 & 0xFFFFFFFFL);
									bool flag = ColorsSimilar((Color32)num13, color2, 10);
									bool flag2 = !flag;
									flag3 = !flag2;
									num9 = wfColor2.r;
									num11 = num5;
									num12 = 10;
								}
								while (flag3);
							}
							if (shaderTexture == null)
							{
								(shaderTexture = new Texture2D(4, 4, TextureFormat.RGB24, mipChain: false, linear: false)).filterMode = default(FilterMode);
								Color[] array = new Color[16];
								object obj8 = (nint)this + 192;
								object obj9 = (nint)array + 32;
								int num14 = 0;
								do
								{
									bool flag4 = num14 < 7;
									bool flag5 = !flag4;
									int num15 = num14 - 7;
									bool flag6 = num15 == 0;
									bool flag7 = !flag5;
									if (!(flag7 || flag6))
									{
										bool flag8 = num14 < array.Length;
										bool flag9 = !flag8;
										bool flag10 = !flag9;
										object obj10 = obj8;
										if (!flag10)
										{
											throw new IndexOutOfRangeException();
										}
									}
									else
									{
										object obj10 = obj5;
									}
									num14++;
								}
								while (num14 != 16);
								shaderTexture.SetPixels(array, 0);
								shaderTexture.Apply();
							}
							if (renderTexture == null)
							{
								(renderTexture = new RenderTexture(4, 4, 24, default(RenderTextureFormat), RenderTextureReadWrite.sRGB)).autoGenerateMips = false;
								renderTexture.filterMode = default(FilterMode);
								bool flag11 = renderTexture.Create();
							}
							if (targetTexture == null)
							{
								(targetTexture = new Texture2D(4, 4, TextureFormat.RGB24, mipChain: false, linear: false)).filterMode = default(FilterMode);
							}
							if (wfMaterial == null)
							{
								(wfMaterial = new Material(wfShader)).mainTexture = shaderTexture;
							}
							if (foregroundRenderer == null)
							{
								GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
								BoxCollider component3 = gameObject3.GetComponent<BoxCollider>();
								UnityEngine.Object.Destroy(component3);
								gameObject3.name = "WireframeFore";
								gameObject3.layer = whLayer;
								Transform transform9 = gameObject3.transform;
								Transform parent3 = serviceContainer.transform;
								transform9.parent = parent3;
								Transform transform10 = gameObject3.transform;
								Vector3 localPosition2 = default(Vector3);
								localPosition2.x = 0f;
								localPosition2.y = 0f;
								localPosition2.z = 0f;
								transform10.localPosition = localPosition2;
								(foregroundRenderer = gameObject3.GetComponent<MeshRenderer>()).sharedMaterial = wfMaterial;
								foregroundRenderer.shadowCastingMode = default(ShadowCastingMode);
								foregroundRenderer.receiveShadows = false;
								foregroundRenderer.enabled = false;
							}
							if (backgroundRenderer == null)
							{
								GameObject gameObject4 = GameObject.CreatePrimitive(PrimitiveType.Quad);
								MeshCollider component4 = gameObject4.GetComponent<MeshCollider>();
								UnityEngine.Object.Destroy(component4);
								gameObject4.name = "WireframeBack";
								gameObject4.layer = whLayer;
								Transform transform11 = gameObject4.transform;
								Transform parent4 = serviceContainer.transform;
								transform11.parent = parent4;
								Transform transform12 = gameObject4.transform;
								Vector3 localPosition3 = default(Vector3);
								localPosition3.x = 0f;
								localPosition3.y = 0f;
								localPosition3.z = 1f;
								transform12.localPosition = localPosition3;
								Transform transform13 = gameObject4.transform;
								Vector3 localScale3 = default(Vector3);
								localScale3.x = 0.7f;
								localScale3.y = 0.7f;
								localScale3.z = 0.7f;
								transform13.localScale = localScale3;
								(backgroundRenderer = gameObject4.GetComponent<MeshRenderer>()).sharedMaterial = wfMaterial;
								backgroundRenderer.shadowCastingMode = default(ShadowCastingMode);
								backgroundRenderer.receiveShadows = false;
								backgroundRenderer.enabled = false;
							}
							GameObject gameObject5 = new GameObject("WireframeCamera");
							(wfCamera = gameObject5.AddComponent<Camera>()).cameraType = CameraType.Preview;
							GameObject gameObject6 = wfCamera.gameObject;
							gameObject6.layer = whLayer;
							Transform transform14 = wfCamera.transform;
							Transform parent5 = serviceContainer.transform;
							transform14.parent = parent5;
							Transform transform15 = wfCamera.transform;
							Vector3 localPosition4 = default(Vector3);
							localPosition4.x = 0f;
							localPosition4.y = 0f;
							localPosition4.z = -1f;
							transform15.localPosition = localPosition4;
							wfCamera.clearFlags = CameraClearFlags.Color;
							Color backgroundColor = default(Color);
							backgroundColor.r = 0f;
							backgroundColor.g = 0f;
							backgroundColor.b = 0f;
							backgroundColor.a = 1f;
							wfCamera.backgroundColor = backgroundColor;
							wfCamera.orthographic = true;
							wfCamera.orthographicSize = 0.5f;
							wfCamera.nearClipPlane = 0.01f;
							wfCamera.farClipPlane = 2.1f;
							wfCamera.depth = 0f;
							wfCamera.renderingPath = RenderingPath.Forward;
							wfCamera.useOcclusionCulling = false;
							wfCamera.allowHDR = false;
							wfCamera.allowMSAA = false;
							wfCamera.targetTexture = renderTexture;
							wfCamera.enabled = false;
							goto IL_131d;
						}
						Debug.LogWarning("[ACTk] WallHack Detector: can't detect wireframe cheats on this platform due to lack of needed shader support!", this);
					}
					checkWireframe = false;
				}
				else if (!CheckWireframe)
				{
					goto IL_04ca;
				}
				goto IL_131d;
			}
			goto IL_04ca;
			IL_038e:
			if (!CheckController && solidWall != null)
			{
				UnityEngine.Object.Destroy(solidWall);
			}
			goto IL_03fb;
		}

		[IteratorStateMachine(typeof(_003CInitDetector_003Ed__71))]
		[Token(Token = "0x600042F")]
		[Address(RVA = "0xBF2D38", Offset = "0xBF2D38", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Detectors.WallHackDetector+<InitDetector>d__71;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35588]) = v37;\nL_0014:\n\tv39 = new CodeStage.AntiCheat.Detectors.WallHackDetector+<InitDetector>d__71();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator InitDetector()
		{
			_003CInitDetector_003Ed__71 _003CInitDetector_003Ed__72 = null;
			_003CInitDetector_003Ed__72._003C_003E1__state = 0;
			_003CInitDetector_003Ed__72._003C_003E4__this = this;
			return _003CInitDetector_003Ed__72;
		}

		[Token(Token = "0x6000430")]
		[Address(RVA = "0xBF1920", Offset = "0xBF1920", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = UnityEngine.Object;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = \"StartRigidModule\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A35589]) = v36;\nL_0015:\n\tv38 = ~this.checkRigidbody;\n\tif (v38) goto L_009A;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0022:\n\tv53 = UnityEngine.Object::op_Implicit(this.rigidPlayer);\n\tv56 = v53 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_002D;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::InitRigidModule(this);\nL_002D:\n\tv68 = UnityEngine.Component::get_transform(this.rigidPlayer);\n\tv190 = UnityEngine.Transform::get_localPosition(v68);\n\tv191 = v190.z < 1f;\n\tv109 = ~v191;\n\tv106 = v190.z - 1f;\n\tv100 = v106 == 0;\n\tv192 = ~v100;\n\tv85 = v109 & v192;\n\tif (v85) goto L_004A;\n\tv194 = this.rigidbodyDetections == 0;\n\tif (v194) goto L_004A;\n\tthis.rigidbodyDetections = 0;\nL_004A:\n\tgoto L_005D;\n\tv201 = UnityEngine.Quaternion;\n\tv202 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, v126, v19, v20, v21, v22, v23, v24, v121, v116, v111, v28, v29, v30, v31, v32);\n\tv203 = 1;\n\t*([1A3551A]) = v203;\nL_005D:\n\tUnityEngine.Rigidbody::set_rotation(this.rigidPlayer, v208.identityQuaternion);\n\tgoto L_0075;\n\tv213 = UnityEngine.Vector3;\n\tv214 = \"il2cpp_codegen_initialize_runtime_metadata\"(v213, v130, v19, v20, v21, v22, v23, v24, v124, v119, v114, v82, v29, v30, v31, v32);\n\tv215 = 1;\n\t*([1A35519]) = v215;\nL_0075:\n\tUnityEngine.Rigidbody::set_angularVelocity(this.rigidPlayer, v146.zeroVector);\n\tv134 = UnityEngine.Component::get_transform(this.rigidPlayer);\n\t// 129 MakeStruct v71 @ AGGBF5A84_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0.75f, 0, -1f\n\tUnityEngine.Transform::set_localPosition(v134, v71);\n\t// 140 MakeStruct v157 @ AGGBF5AA4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rigidPlayerVelocity (UnityEngine.Vector3), this.rigidPlayerVelocity.y (System.Single), this.rigidPlayerVelocity.z (System.Single)\n\tUnityEngine.Rigidbody::set_velocity(this.rigidPlayer, v157);\n\tUnityEngine.MonoBehaviour::Invoke(this, \"StartRigidModule\", 4f);\n\treturn;\nL_009A:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopRigidModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UninitRigidModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StartRigidModule()
		{
			if (CheckRigidbody)
			{
				if (!rigidPlayer)
				{
					InitRigidModule();
				}
				Transform transform = rigidPlayer.transform;
				Vector3 localPosition = transform.localPosition;
				bool flag = localPosition.z < 1f;
				bool flag2 = !flag;
				float num = localPosition.z - 1f;
				bool flag3 = num == 0f;
				bool flag4 = !flag3;
				if (!(flag2 && flag4) && rigidbodyDetections != 0)
				{
					rigidbodyDetections = 0;
				}
				rigidPlayer.rotation = Quaternion.identity;
				rigidPlayer.angularVelocity = Vector3.zero;
				Transform transform2 = rigidPlayer.transform;
				Vector3 localPosition2 = default(Vector3);
				localPosition2.x = 0.75f;
				localPosition2.y = 0f;
				localPosition2.z = -1f;
				transform2.localPosition = localPosition2;
				Vector3 velocity = default(Vector3);
				velocity.x = rigidPlayerVelocity.x;
				velocity.y = rigidPlayerVelocity.y;
				velocity.z = rigidPlayerVelocity.z;
				rigidPlayer.velocity = velocity;
				Invoke("StartRigidModule", 4f);
			}
			else
			{
				StopRigidModule();
				UninitRigidModule();
				UpdateServiceContainer();
			}
		}

		[Token(Token = "0x6000431")]
		[Address(RVA = "0xBF1C9C", Offset = "0xBF1C9C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = UnityEngine.Object;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = \"StartControllerModule\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3558A]) = v34;\nL_0014:\n\tv36 = ~this.checkController;\n\tif (v36) goto L_0061;\n\tgoto L_0021;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv51 = UnityEngine.Object::op_Implicit(this.charControllerPlayer);\n\tv54 = v51 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002C;\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::InitControllerModule(this);\nL_002C:\n\tv65 = UnityEngine.Component::get_transform(this.charControllerPlayer);\n\tv145 = UnityEngine.Transform::get_localPosition(v65);\n\tv146 = v145.z < 1f;\n\tv92 = ~v146;\n\tv89 = v145.z - 1f;\n\tv83 = v89 == 0;\n\tv147 = ~v83;\n\tv68 = v92 & v147;\n\tif (v68) goto L_0048;\n\tv149 = this.controllerDetections == 0;\n\tif (v149) goto L_0048;\n\tthis.controllerDetections = 0;\nL_0048:\n\tv103 = UnityEngine.Component::get_transform(this.charControllerPlayer);\n\t// 81 MakeStruct v117 @ AGGBF5D70_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), -0.75f, 0, -1f\n\tUnityEngine.Transform::set_localPosition(v103, v117);\n\tthis.charControllerVelocity = 0.01f;\n\tUnityEngine.MonoBehaviour::Invoke(this, \"StartControllerModule\", 4f);\n\treturn;\nL_0061:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopControllerModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UninitControllerModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StartControllerModule()
		{
			if (CheckController)
			{
				if (!charControllerPlayer)
				{
					InitControllerModule();
				}
				Transform transform = charControllerPlayer.transform;
				Vector3 localPosition = transform.localPosition;
				bool flag = localPosition.z < 1f;
				bool flag2 = !flag;
				float num = localPosition.z - 1f;
				bool flag3 = num == 0f;
				bool flag4 = !flag3;
				if (!(flag2 && flag4) && controllerDetections != 0)
				{
					controllerDetections = 0;
				}
				Transform transform2 = charControllerPlayer.transform;
				Vector3 localPosition2 = default(Vector3);
				localPosition2.x = -0.75f;
				localPosition2.y = 0f;
				localPosition2.z = -1f;
				transform2.localPosition = localPosition2;
				charControllerVelocity = 0.01f;
				Invoke("StartControllerModule", 4f);
			}
			else
			{
				StopControllerModule();
				UninitControllerModule();
				UpdateServiceContainer();
			}
		}

		[Token(Token = "0x6000432")]
		[Address(RVA = "0xBF1F28", Offset = "0xBF1F28", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = \"ShootWireframeModule\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3558B]) = v33;\nL_0011:\n\tv35 = ~this.checkWireframe;\n\tif (v35) goto L_001C;\n\tv37 = ~this.wireframeDetected;\n\tif (v37) goto L_002F;\n\treturn;\nL_001C:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopWireframeModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\treturn;\nL_002F:\n\tUnityEngine.MonoBehaviour::Invoke(this, \"ShootWireframeModule\", this.wireframeDelay);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StartWireframeModule()
		{
			//IL_0044: Expected F4, but got I4
			if (CheckWireframe)
			{
				if (!wireframeDetected)
				{
					Invoke("ShootWireframeModule", wireframeDelay);
				}
			}
			else
			{
				StopWireframeModule();
				UpdateServiceContainer();
			}
		}

		[Token(Token = "0x6000433")]
		[Address(RVA = "0xBF3490", Offset = "0xBF3490", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = \"ShootWireframeModule\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3558C]) = v37;\nL_0014:\n\tv39 = CodeStage.AntiCheat.Detectors.WallHackDetector::CaptureFrame(this);\n\tv43 = UnityEngine.MonoBehaviour::StartCoroutine(this, v39);\n\tUnityEngine.MonoBehaviour::Invoke(this, \"ShootWireframeModule\", this.wireframeDelay);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ShootWireframeModule()
		{
			//IL_002f: Expected F4, but got I4
			IEnumerator routine = CaptureFrame();
			Coroutine coroutine = StartCoroutine(routine);
			Invoke("ShootWireframeModule", wireframeDelay);
		}

		[IteratorStateMachine(typeof(_003CCaptureFrame_003Ed__76))]
		[Token(Token = "0x6000434")]
		[Address(RVA = "0xBF34FC", Offset = "0xBF34FC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Detectors.WallHackDetector+<CaptureFrame>d__76;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3558D]) = v37;\nL_0014:\n\tv39 = new CodeStage.AntiCheat.Detectors.WallHackDetector+<CaptureFrame>d__76();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CaptureFrame()
		{
			_003CCaptureFrame_003Ed__76 _003CCaptureFrame_003Ed__77 = null;
			_003CCaptureFrame_003Ed__77._003C_003E1__state = 0;
			_003CCaptureFrame_003Ed__77._003C_003E4__this = this;
			return _003CCaptureFrame_003Ed__77;
		}

		[Token(Token = "0x6000435")]
		[Address(RVA = "0xBF3584", Offset = "0xBF3584", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv40 = System.Math;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v43, v44, v45, v46, v47, v48, a, v0, v2, v3, b, v4, v6, v7);\n\tv52 = 1;\n\t*([1A3558E]) = v52;\nL_0027:\n\tgoto L_0029;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v43, v44, v45, v46, v47, v48, a, v0, v2, v3, b, v4, v6, v7);\nL_0029:\n\t// 41 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv71 = a > 5f;\n\tif (v71) goto L_FFFFFFFF;\n\tgoto L_003E;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v43, v44, v45, v46, v47, v48, a, v59, v2, v3, b, v4, v6, v7);\nL_003E:\n\t// 62 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv77 = a <= 5f;\n\tif (v77) goto L_0053;\n\tgoto L_006E;\nL_0053:\n\tgoto L_0055;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v142, methodInfo, v43, v44, v45, v46, v47, v48, a, v99, v2, v3, b, v4, v6, v7);\nL_0055:\n\t// 85 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv122 = a - 5f;\n\tv120 = v122 < 0;\n\tv118 = v122 == 0;\n\tv116 = a ^ 5f;\n\tv114 = a ^ v122;\n\tv112 = v116 & v114;\n\tv110 = v112 < 0;\n\tv147 = v120 == v110;\n\tv106 = ~v118;\n\tv108 = v147 & v106;\nL_006E:\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool ColorsDiffer(Color a, Color b)
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			Color color = default(Color);
			if (!(color.r > 5f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				if (!(color.r > 5f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					float num = color.r - 5f;
					bool flag = num < 0f;
					bool flag2 = num == 0f;
					object obj = a ^ 5f;
					object obj2 = a ^ num;
					int num2 = (int)((nint)obj & (nint)obj2);
					bool flag3 = num2 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					return flag4 && flag5;
				}
			}
			return true;
		}

		[Token(Token = "0x6000436")]
		[Address(RVA = "0xBF20DC", Offset = "0xBF20DC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = \"ShootRaycastModule\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3558F]) = v33;\nL_0011:\n\tv35 = ~this.checkRaycast;\n\tif (v35) goto L_0021;\n\tUnityEngine.MonoBehaviour::Invoke(this, \"ShootRaycastModule\", this.raycastDelay);\n\treturn;\nL_0021:\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::StopRaycastModule(this);\n\tCodeStage.AntiCheat.Detectors.WallHackDetector::UpdateServiceContainer(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StartRaycastModule()
		{
			//IL_0016: Expected F4, but got I4
			if (CheckRaycast)
			{
				Invoke("ShootRaycastModule", raycastDelay);
				return;
			}
			StopRaycastModule();
			UpdateServiceContainer();
		}

		[Token(Token = "0x6000437")]
		[Address(RVA = "0xBF3658", Offset = "0xBF3658", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = UnityEngine.Physics;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = \"ShootRaycastModule\";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A35590]) = v48;\nL_001E:\n\tv54 = UnityEngine.GameObject::get_transform(this.serviceContainer);\n\tv68 = UnityEngine.Transform::get_position(v54);\n\tv180 = UnityEngine.GameObject::get_transform(this.serviceContainer);\n\tgoto L_0046;\n\tv185 = UnityEngine.Vector3;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, v71, v31, v32, v33, v34, v35, v36, v68, v66, v64, v40, v41, v42, v43, v44);\n\tv187 = 1;\n\t*([1A3559C]) = v187;\nL_0046:\n\tv199 = UnityEngine.Transform::TransformDirection(v180, v194.forwardVector);\n\tgoto L_0060;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v202, v192, v31, v32, v33, v34, v35, v36, v199, v200, v201, v40, v41, v42, v43, v44);\nL_0060:\n\tv214 = UnityEngine.Physics::RaycastNonAlloc(v68, v199, this.rayHits, 1.5f, this.raycastMask);\n\tv88 = v214 < 1;\n\tif (v88) goto L_0072;\n\tv218 = this.raycastDetections == 0;\n\tif (v218) goto L_0097;\n\tthis.raycastDetections = 0;\n\tgoto L_0097;\nL_0072:\n\tv175 = this.raycastDetections + 1;\n\tthis.raycastDetections = v175;\n\tv166 = CodeStage.AntiCheat.Detectors.WallHackDetector::Detect(this);\n\tv169 = v166 == 0;\n\tif (v169) goto L_0097;\n\treturn;\nL_0097:\n\tUnityEngine.MonoBehaviour::Invoke(this, \"ShootRaycastModule\", this.raycastDelay);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ShootRaycastModule()
		{
			//IL_0117: Expected F4, but got I4
			Transform transform = serviceContainer.transform;
			Vector3 position = transform.position;
			Transform transform2 = serviceContainer.transform;
			Vector3 direction = transform2.TransformDirection(Vector3.forward);
			int num = Physics.RaycastNonAlloc(position, direction, rayHits, 1.5f, raycastMask);
			if (num >= 1)
			{
				if (raycastDetections != 0)
				{
					raycastDetections = 0;
				}
			}
			else
			{
				int num2 = raycastDetections + 1;
				raycastDetections = (byte)num2;
				if (Detect())
				{
					return;
				}
			}
			Invoke("ShootRaycastModule", raycastDelay);
		}

		[Token(Token = "0x6000438")]
		[Address(RVA = "0xBF1AE8", Offset = "0xBF1AE8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"StartRigidModule\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35591]) = v38;\nL_001B:\n\tgoto L_001F;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = UnityEngine.Object::op_Implicit(this.rigidPlayer);\n\tv52 = v50 == 0;\n\tif (v52) goto L_0045;\n\tgoto L_003A;\n\tv87 = UnityEngine.Vector3;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, v49, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv91 = 1;\n\t*([1A35519]) = v91;\nL_003A:\n\tUnityEngine.Rigidbody::set_velocity(this.rigidPlayer, v74.zeroVector);\nL_0045:\n\tUnityEngine.MonoBehaviour::CancelInvoke(this, \"StartRigidModule\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopRigidModule()
		{
			if ((bool)rigidPlayer)
			{
				rigidPlayer.velocity = Vector3.zero;
			}
			CancelInvoke("StartRigidModule");
		}

		[Token(Token = "0x6000439")]
		[Address(RVA = "0xBF1DC0", Offset = "0xBF1DC0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"StartControllerModule\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35592]) = v38;\nL_001B:\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0021:\n\tv52 = UnityEngine.Object::op_Implicit(this.charControllerPlayer);\n\tv54 = v52 == 0;\n\tif (v54) goto L_002E;\n\tthis.charControllerVelocity = 0f;\nL_002E:\n\tUnityEngine.MonoBehaviour::CancelInvoke(this, \"StartControllerModule\");\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopControllerModule()
		{
			if ((bool)charControllerPlayer)
			{
				charControllerVelocity = 0f;
			}
			CancelInvoke("StartControllerModule");
		}

		[Token(Token = "0x600043A")]
		[Address(RVA = "0xBF1FB0", Offset = "0xBF1FB0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = \"ShootWireframeModule\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35593]) = v37;\nL_001B:\n\tUnityEngine.MonoBehaviour::CancelInvoke(this, \"ShootWireframeModule\");\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopWireframeModule()
		{
			CancelInvoke("ShootWireframeModule");
		}

		[Token(Token = "0x600043B")]
		[Address(RVA = "0xBF2150", Offset = "0xBF2150", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = \"ShootRaycastModule\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35594]) = v37;\nL_001B:\n\tUnityEngine.MonoBehaviour::CancelInvoke(this, \"ShootRaycastModule\");\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopRaycastModule()
		{
			CancelInvoke("ShootRaycastModule");
		}

		[Token(Token = "0x600043C")]
		[Address(RVA = "0xBF316C", Offset = "0xBF316C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = UnityEngine.GameObject;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = \"RigidPlayer\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35595]) = v42;\nL_0020:\n\tv44 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v44, \"RigidPlayer\");\n\tv61 = UnityEngine.GameObject::AddComponent(v44);\n\tUnityEngine.CapsuleCollider::set_height(v61, 2f);\n\tUnityEngine.GameObject::set_layer(v44, this.whLayer);\n\tv81 = UnityEngine.GameObject::get_transform(v44);\n\tv82 = UnityEngine.GameObject::get_transform(this.serviceContainer);\n\tUnityEngine.Transform::set_parent(v81, v82);\n\tv83 = UnityEngine.GameObject::get_transform(v44);\n\t// 80 MakeStruct v64 @ AGGBF7280_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0.75f, 0, -1f\n\tUnityEngine.Transform::set_localPosition(v83, v64);\n\tv84 = UnityEngine.GameObject::AddComponent(v44);\n\tthis.rigidPlayer = v84;\n\tUnityEngine.Rigidbody::set_useGravity(v84, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitRigidModule()
		{
			GameObject gameObject = new GameObject("RigidPlayer");
			CapsuleCollider capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
			capsuleCollider.height = 2f;
			gameObject.layer = whLayer;
			Transform transform = gameObject.transform;
			Transform parent = serviceContainer.transform;
			transform.parent = parent;
			Transform transform2 = gameObject.transform;
			Vector3 localPosition = default(Vector3);
			localPosition.x = 0.75f;
			localPosition.y = 0f;
			localPosition.z = -1f;
			transform2.localPosition = localPosition;
			(rigidPlayer = gameObject.AddComponent<Rigidbody>()).useGravity = false;
		}

		[Token(Token = "0x600043D")]
		[Address(RVA = "0xBF3354", Offset = "0xBF3354", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = UnityEngine.GameObject;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = \"ControlledPlayer\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35596]) = v42;\nL_0020:\n\tv44 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v44, \"ControlledPlayer\");\n\tv61 = UnityEngine.GameObject::AddComponent(v44);\n\tUnityEngine.CapsuleCollider::set_height(v61, 2f);\n\tUnityEngine.GameObject::set_layer(v44, this.whLayer);\n\tv72 = UnityEngine.GameObject::get_transform(v44);\n\tv73 = UnityEngine.GameObject::get_transform(this.serviceContainer);\n\tUnityEngine.Transform::set_parent(v72, v73);\n\tv74 = UnityEngine.GameObject::get_transform(v44);\n\t// 80 MakeStruct v89 @ AGGBF7468_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), -0.75f, 0, -1f\n\tUnityEngine.Transform::set_localPosition(v74, v89);\n\tv101 = UnityEngine.GameObject::AddComponent(v44);\n\tthis.charControllerPlayer = v101;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitControllerModule()
		{
			GameObject gameObject = new GameObject("ControlledPlayer");
			CapsuleCollider capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
			capsuleCollider.height = 2f;
			gameObject.layer = whLayer;
			Transform transform = gameObject.transform;
			Transform parent = serviceContainer.transform;
			transform.parent = parent;
			Transform transform2 = gameObject.transform;
			Vector3 localPosition = default(Vector3);
			localPosition.x = -0.75f;
			localPosition.y = 0f;
			localPosition.z = -1f;
			transform2.localPosition = localPosition;
			CharacterController characterController = gameObject.AddComponent<CharacterController>();
			charControllerPlayer = characterController;
		}

		[Token(Token = "0x600043E")]
		[Address(RVA = "0xBF30CC", Offset = "0xBF30CC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35597]) = v37;\nL_0018:\n\tgoto L_001C;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001C:\n\tv47 = UnityEngine.Object::op_Implicit(this.rigidPlayer);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0036;\n\tv70 = UnityEngine.Component::get_gameObject(this.rigidPlayer);\n\tgoto L_002F;\n\tv82 = v62;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v82, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\tUnityEngine.Object::Destroy(v70);\n\tthis.rigidPlayer = 0;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UninitRigidModule()
		{
			if ((bool)rigidPlayer)
			{
				GameObject obj = rigidPlayer.gameObject;
				UnityEngine.Object.Destroy(obj);
				rigidPlayer = null;
			}
		}

		[Token(Token = "0x600043F")]
		[Address(RVA = "0xBF32B4", Offset = "0xBF32B4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35598]) = v37;\nL_0018:\n\tgoto L_001C;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001C:\n\tv47 = UnityEngine.Object::op_Implicit(this.charControllerPlayer);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0036;\n\tv70 = UnityEngine.Component::get_gameObject(this.charControllerPlayer);\n\tgoto L_002F;\n\tv82 = v62;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v82, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\tUnityEngine.Object::Destroy(v70);\n\tthis.charControllerPlayer = 0;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UninitControllerModule()
		{
			if ((bool)charControllerPlayer)
			{
				GameObject obj = charControllerPlayer.gameObject;
				UnityEngine.Object.Destroy(obj);
				charControllerPlayer = null;
			}
		}

		[Token(Token = "0x6000440")]
		[Address(RVA = "0xBF2BCC", Offset = "0xBF2BCC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.controllerDetections < this.maxFalsePositives;\n\tv6 = ~v5;\n\tv7 = this.controllerDetections - this.maxFalsePositives;\n\tv9 = v7 == 0;\n\tv14 = ~v9;\n\tv15 = v6 & v14;\n\tif (v15) goto L_003A;\n\tv17 = this.rigidbodyDetections < this.maxFalsePositives;\n\tv18 = ~v17;\n\tv19 = this.rigidbodyDetections - this.maxFalsePositives;\n\tv21 = v19 == 0;\n\tv26 = ~v21;\n\tv27 = v18 & v26;\n\tif (v27) goto L_003A;\n\tv77 = this.wireframeDetections < this.maxFalsePositives;\n\tv54 = ~v77;\n\tv51 = this.wireframeDetections - this.maxFalsePositives;\n\tv45 = v51 == 0;\n\tv78 = ~v45;\n\tv30 = v54 & v78;\n\tif (v30) goto L_003A;\n\tv95 = this.raycastDetections < this.maxFalsePositives;\n\tv53 = ~v95;\n\tv50 = this.raycastDetections - this.maxFalsePositives;\n\tv44 = v50 == 0;\n\tv96 = ~v53;\n\tv29 = v96 | v44;\n\tif (v29) goto L_FFFFFFFF;\nL_003A:\n\tv61 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.WallHackDetector>::OnCheatingDetected(this);\nL_003E:\n\treturn returnVal1;\n\tgoto L_003E;\n\treturn X0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool Detect()
		{
			bool flag = controllerDetections < maxFalsePositives;
			bool flag2 = !flag;
			int num = controllerDetections - maxFalsePositives;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				bool flag5 = rigidbodyDetections < maxFalsePositives;
				bool flag6 = !flag5;
				int num2 = rigidbodyDetections - maxFalsePositives;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					bool flag9 = wireframeDetections < maxFalsePositives;
					bool flag10 = !flag9;
					int num3 = wireframeDetections - maxFalsePositives;
					bool flag11 = num3 == 0;
					bool flag12 = !flag11;
					if (!(flag10 && flag12))
					{
						bool flag13 = raycastDetections < maxFalsePositives;
						bool flag14 = !flag13;
						int num4 = raycastDetections - maxFalsePositives;
						bool flag15 = num4 == 0;
						bool flag16 = !flag14;
						if (flag16 || flag15)
						{
							return false;
						}
					}
				}
			}
			base.OnCheatingDetected();
			return true;
		}

		[Token(Token = "0x6000441")]
		[Address(RVA = "0xBF2F64", Offset = "0xBF2F64", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.Random::Range(0, 0x100);\n\tv14 = UnityEngine.Random::Range(0, 0x100);\n\tv19 = UnityEngine.Random::Range(0, 0x100);\n\tv20 = v14 & 0xFF;\n\tv21 = v20 << 8;\n\tv22 = v9 & 0xFFFFFFFFFFFF00FF;\n\tv23 = v22 | v21;\n\tv24 = v19 & 0xFFFF;\n\tv25 = v24 << 0x10;\n\tv26 = v23 & 0xFFFF;\n\tv27 = v26 | v25;\n\treturnVal1 = v27 | 0xFF000000;\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Color32 GenerateColor()
		{
			//IL_00be: Expected O, but got I8
			int num = UnityEngine.Random.Range(0, 256);
			int num2 = UnityEngine.Random.Range(0, 256);
			int num3 = UnityEngine.Random.Range(0, 256);
			int num4 = num2 & 0xFF;
			int num5 = num4 << 8;
			int num6 = num & -65281;
			int num7 = num6 | num5;
			int num8 = num3 & 0xFFFF;
			int num9 = num8 << 16;
			int num10 = num7 & 0xFFFF;
			int num11 = num10 | num9;
			return (Color32)(num11 | 0xFF000000L);
		}

		[Token(Token = "0x6000442")]
		[Address(RVA = "0xBF2FBC", Offset = "0xBF2FBC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = System.Math;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, c2, tolerance, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A35599]) = v45;\nL_001C:\n\tgoto L_001E;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v46, c2, tolerance, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_001E:\n\tv52 = c1 & 0xFF;\n\tv66 = v52 - c2;\n\tv63 = v66 >= 0;\n\tif (v63) goto L_0038;\n\tv66 = -v66;\n\tgoto L_0038;\nL_0038:\n\tv76 = v66 >= tolerance;\n\tif (v76) goto L_FFFFFFFF;\n\tv78 = c1 >> 8;\n\tv79 = c2 >> 8;\n\tgoto L_0042;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v77, c2, tolerance, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0042:\n\tv112 = v78 & 0xFF;\n\tv108 = v112 - v79;\n\tv87 = v108 >= 0;\n\tif (v87) goto L_005C;\n\tv108 = -v108;\n\tgoto L_005C;\nL_005C:\n\tv84 = v108 >= tolerance;\n\tif (v84) goto L_FFFFFFFF;\n\tv149 = c1 >> 0x10;\n\tv151 = c2 >> 0x10;\n\tgoto L_0066;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v165, c2, tolerance, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0066:\n\tv170 = v149 & 0xFF;\n\tv153 = v170 - v151;\n\tv127 = v153 >= 0;\n\tif (v127) goto L_0079;\n\tv153 = -v153;\n\tgoto L_0079;\nL_0079:\n\tv141 = v153 - tolerance;\n\tv139 = v141 < 0;\n\tv135 = v153 ^ tolerance;\n\tv133 = v153 ^ v141;\n\tv131 = v135 & v133;\n\tv129 = v131 < 0;\n\tv184 = v139 == v129;\n\tv124 = ~v184;\n\tgoto L_008D;\nL_008D:\n\treturn returnVal1;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool ColorsSimilar(Color32 c1, Color32 c2, int tolerance)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected I4, but got Unknown
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected I4, but got Unknown
			//IL_005c: Expected I4, but got O
			//IL_006a: Expected I4, but got O
			//IL_00c6: Expected I4, but got O
			//IL_00d4: Expected I4, but got O
			int num = c1 & 0xFF;
			int num2 = num - c2;
			if (num2 < 0)
			{
				num2 = -num2;
			}
			if (num2 < tolerance)
			{
				int num3 = (object)c1 >> 8;
				int num4 = (object)c2 >> 8;
				int num5 = num3 & 0xFF;
				int num6 = num5 - num4;
				if (num6 < 0)
				{
					num6 = -num6;
				}
				if (num6 < tolerance)
				{
					int num7 = (object)c1 >> 16;
					int num8 = (object)c2 >> 16;
					int num9 = num7 & 0xFF;
					int num10 = num9 - num8;
					if (num10 < 0)
					{
						num10 = -num10;
					}
					int num11 = num10 - tolerance;
					bool flag = num11 < 0;
					int num12 = num10 ^ tolerance;
					int num13 = num10 ^ num11;
					int num14 = num12 & num13;
					bool flag2 = num14 < 0;
					bool flag3 = flag == flag2;
					return !flag3;
				}
			}
			return false;
		}
	}
}
