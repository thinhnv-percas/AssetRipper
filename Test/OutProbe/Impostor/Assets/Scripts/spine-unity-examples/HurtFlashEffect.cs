using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000002")]
public class HurtFlashEffect : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x2000003")]
	private sealed class _003CFlashRoutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x10")]
		internal int _003C_003E1__state;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x18")]
		private object _003C_003E2__current;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x20")]
		public HurtFlashEffect _003C_003E4__this;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x28")]
		private int _003CfillPhase_003E5__2;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x2C")]
		private int _003CfillColor_003E5__3;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x30")]
		private WaitForSeconds _003Cwait_003E5__4;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x38")]
		private int _003Ci_003E5__5;

		[Token(Token = "0x17000001")]
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x1508658", Offset = "0x1508658", Length = "0x8")]
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
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x1508698", Offset = "0x1508698", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		[Token(Token = "0x6000004")]
		[Address(RVA = "0x15083EC", Offset = "0x15083EC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003CFlashRoutine_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15084A0", Offset = "0x15084A0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void IDisposable.Dispose()
		{
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x15084A4", Offset = "0x15084A4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv20 = UnityEngine.WaitForSeconds;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A379DB]) = v39;\nL_0013:\n\tv40 = this.<>1__state;\n\tv42 = this.<>1__state < 3;\n\tv43 = ~v42;\n\tv44 = this.<>1__state - 3;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0097;\n\tv55 = 0x44C000 + 0xCC6;\n\tv58 = *([v55 @ X9_v2 (System.Int32)+v40 @ X8_v3 (System.Int32)]) << 2;\n\tv59 = 0x150C508 + v58;\n\t// 41 IndirectJump v59 @ X10_v2 (System.Int32), 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v23 @ X2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0098;\n\tX8 = *([X21+20]);\n\tTEMP = X8 & 0x80000000;\n\tif (TEMP) goto L_0034;\n\tX8 = 3;\n\t*([X21+20]) = X8;\nL_0034:\n\tX0 = *([X21+38]);\n\tX1 = 0;\n\tX0 = UnityEngine.Shader::PropertyToID(X0, X1);\n\t*([X19+28]) = X0;\n\tX0 = *([X21+40]);\n\tX1 = 0;\n\tX0 = UnityEngine.Shader::PropertyToID(X0, X1);\n\t*([X19+2C]) = X0;\n\tX8 = *([19359A0]);\n\tV8 = *([X21+34]);\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V8;\n\tX1 = 0;\n\tX20 = X0;\n\tUnityEngine.WaitForSeconds::.ctor(X0, V0, X1);\n\tX8 = 0;\n\t*([X19+30]) = X20;\n\t*([X19+38]) = 0;\n\tgoto L_0062;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0098;\n\tX20 = X21;\n\tX20 = X20 + 0x48;\n\tX0 = *([X20]);\n\tif (TEMP) goto L_0098;\n\tX1 = *([X19+28]);\n\tV0 = 0;\n\tX2 = 0;\n\tUnityEngine.MaterialPropertyBlock::SetFloat(X0, X1, V0, X2);\n\tX0 = *([X21+50]);\n\tif (TEMP) goto L_0098;\n\tX22 = 2;\n\tgoto L_0086;\n\tX8 = *([X19+38]);\n\tX9 = 0xFFFFFFFF;\n\t*([X19+10]) = X9;\n\tX8 = X8 + 1;\n\t*([X19+38]) = X8;\n\tif (TEMP) goto L_0098;\nL_0062:\n\tX9 = *([X21+20]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_008B;\n\tX20 = X21;\n\tX20 = X20 + 0x48;\n\tX0 = *([X20]);\n\tif (TEMP) goto L_0098;\n\tV2 = *([X21+2C]);\n\tV3 = *([X21+30]);\n\tV0 = *([X21+24]);\n\tV1 = *([X21+28]);\n\tX1 = *([X19+2C]);\n\tX2 = 0;\n\t// 121 MakeStruct AGG150C5F0_2, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tUnityEngine.MaterialPropertyBlock::SetColor(X0, X1, AGG150C5F0_2, X2);\n\tX0 = *([X21+48]);\n\tif (TEMP) goto L_0098;\n\tX1 = *([X19+28]);\n\tV0 = 1f;\n\tX2 = 0;\n\tUnityEngine.MaterialPropertyBlock::SetFloat(X0, X1, V0, X2);\n\tX0 = *([X21+50]);\n\tif (TEMP) goto L_0098;\n\tX22 = 1;\nL_0086:\n\tX1 = *([X20]);\n\tX2 = 0;\n\tUnityEngine.Renderer::SetPropertyBlock(X0, X1, X2);\n\tX8 = *([X19+30]);\n\tgoto L_008D;\nL_008B:\n\tX8 = 0;\n\tX22 = 3;\nL_008D:\n\tX0 = 1;\n\t*([X19+18]) = X8;\n\t*([X19+10]) = X22;\nL_0097:\n\treturn 0;\nL_0098:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool MoveNext()
		{
			while (true)
			{
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 3;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 3;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num3 = 4505600 + 3270;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X9_v2 (System.Int32)+v40 @ X8_v3 (System.Int32)]");
				int num4 = (int)((nint)0 << 2);
				int num5 = 22070536 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v59 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		[Token(Token = "0x6000008")]
		[Address(RVA = "0x1508660", Offset = "0x1508660", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	[Token(Token = "0x4000001")]
	private const int DefaultFlashCount = 3;

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x20")]
	public int flashCount;

	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x24")]
	public Color flashColor;

	[Range(1f / 120f, 1f / 15f)]
	[Token(Token = "0x4000004")]
	[FieldOffset(Offset = "0x34")]
	public float interval;

	[Token(Token = "0x4000005")]
	[FieldOffset(Offset = "0x38")]
	public string fillPhaseProperty;

	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x40")]
	public string fillColorProperty;

	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x48")]
	private MaterialPropertyBlock mpb;

	[Token(Token = "0x4000008")]
	[FieldOffset(Offset = "0x50")]
	private MeshRenderer meshRenderer;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x150829C", Offset = "0x150829C", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv43 = UnityEngine.MaterialPropertyBlock;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv61 = UnityEngine.Object;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A379D8]) = v36;\nL_001A:\n\tv40 = this.mpb == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002A;\n\tv48 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v48);\n\tthis.mpb = v48;\nL_002A:\n\tgoto L_002F;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v55, v49, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002F:\n\tv67 = UnityEngine.Object::op_Equality(this.meshRenderer, 0);\n\tv69 = v67 == 0;\n\tif (v69) goto L_FFFFFFFF;\n\tv74 = UnityEngine.Component::GetComponent(this);\n\tthis.meshRenderer = v74;\n\tgoto L_003F;\nL_003F:\n\tUnityEngine.Renderer::GetPropertyBlock(v77, this.mpb);\n\tv84 = HurtFlashEffect::FlashRoutine(this);\n\tv92 = UnityEngine.MonoBehaviour::StartCoroutine(this, v84);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Flash()
	{
		if (mpb == null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			mpb = materialPropertyBlock;
		}
		Renderer renderer = ((!(meshRenderer == null)) ? meshRenderer : (meshRenderer = GetComponent<MeshRenderer>()));
		renderer.GetPropertyBlock(mpb);
		IEnumerator routine = FlashRoutine();
		Coroutine coroutine = StartCoroutine(routine);
	}

	[IteratorStateMachine(typeof(_003CFlashRoutine_003Ed__9))]
	[Token(Token = "0x6000002")]
	[Address(RVA = "0x150838C", Offset = "0x150838C", Length = "0x60")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = HurtFlashEffect+<FlashRoutine>d__9;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379D9]) = v37;\nL_0014:\n\tv39 = new HurtFlashEffect+<FlashRoutine>d__9();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IEnumerator FlashRoutine()
	{
		_003CFlashRoutine_003Ed__9 _003CFlashRoutine_003Ed__10 = null;
		_003CFlashRoutine_003Ed__10._003C_003E1__state = 0;
		_003CFlashRoutine_003Ed__10._003C_003E4__this = this;
		return _003CFlashRoutine_003Ed__10;
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x1508414", Offset = "0x1508414", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = \"_FillPhase\";\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv57 = \"_FillColor\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A379DA]) = v42;\nL_001D:\n\tthis.flashCount = 3;\n\tthis.flashColor = 0;\n\tthis.interval = 0.016666668f;\n\tthis.fillPhaseProperty = \"_FillPhase\";\n\tthis.fillColorProperty = \"_FillColor\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public HurtFlashEffect()
	{
		flashCount = 3;
		flashColor = default(Color);
		interval = 1f / 60f;
		fillPhaseProperty = "_FillPhase";
		fillColorProperty = "_FillColor";
	}
}
