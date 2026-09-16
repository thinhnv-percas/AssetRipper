using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x742AF0", Offset = "0x742AF0")]
	[Token(Token = "0x2000002")]
	public class DOTweenVisualManager : MonoBehaviour
	{
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x18")]
		public VisualManagerPreset preset;

		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x1C")]
		public OnEnableBehaviour onEnableBehaviour;

		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x20")]
		public OnDisableBehaviour onDisableBehaviour;

		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x24")]
		private bool _requiresRestartFromSpawnPoint;

		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x28")]
		private ABSAnimationComponent _animComponent;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x163CD00", Offset = "0x163CD00", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB1818]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A892]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis._animComponent = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ABSAnimationComponent component = GetComponent<ABSAnimationComponent>();
			_animComponent = component;
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x163CD58", Offset = "0x163CD58", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED47F8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A893]) = v38;\nL_0014:\n\tv40 = ~this._requiresRestartFromSpawnPoint;\n\tif (v40) goto L_002F;\n\tgoto L_0026;\n\tv63 = *([v44 @ X0_v3+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0026;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv53 = UnityEngine.Object::op_Equality(this._animComponent, 0);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0030;\nL_002F:\n\treturn;\nL_0030:\n\tv79 = this._animComponent;\n\tthis._requiresRestartFromSpawnPoint = 0;\n\tv86 = *([v79 @ X0_v7 (DG.Tweening.Core.ABSAnimationComponent)]);\n\tv71 = *([v86 @ X8_v9 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1E0]);\n\tv75 = *([v86 @ X8_v9 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1E8]);\n\t// 61 IndirectJump v71 @ X3_v1, v79 @ X0_v7 (DG.Tweening.Core.ABSAnimationComponent), v79 @ X0_v7 (DG.Tweening.Core.ABSAnimationComponent), 1, v75 @ X2_v3, v71 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_005a: Expected I, but got O
			//IL_006a: Expected O, but got I
			//IL_007a: Expected O, but got I
			while (_requiresRestartFromSpawnPoint && !(_animComponent == null))
			{
				ABSAnimationComponent animComponent = _animComponent;
				_requiresRestartFromSpawnPoint = false;
				IntPtr intPtr = (IntPtr)animComponent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v9 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v9 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1E8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v71 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x163CE00", Offset = "0x163CE00", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F04B40]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A894]) = v38;\nL_0018:\n\tv44 = this.onEnableBehaviour == 3;\n\tif (v44) goto L_006F;\n\tv53 = this.onEnableBehaviour == 2;\n\tif (v53) goto L_0055;\n\tv68 = this.onEnableBehaviour != 1;\n\tif (v68) goto L_0075;\n\tgoto L_0043;\n\tv171 = *([v109 @ X0_v12+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0043;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v109, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tv93 = UnityEngine.Object::op_Inequality(this._animComponent, 0);\n\tv96 = v93 == 0;\n\tif (v96) goto L_0075;\n\tv156 = this._animComponent;\n\tv188 = *([v156 @ X0_v3 (DG.Tweening.Core.ABSAnimationComponent)]);\n\tv123 = *([v188 @ X8_v18 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+170]);\n\tv126 = *([v188 @ X8_v18 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+178]);\n\tgoto L_006D;\nL_0055:\n\tgoto L_005E;\n\tv113 = *([v72 @ X0_v6+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_005E;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005E:\n\tv94 = UnityEngine.Object::op_Inequality(this._animComponent, 0);\n\tv97 = v94 == 0;\n\tif (v97) goto L_0075;\n\tv156 = this._animComponent;\n\tv184 = *([v156 @ X0_v3 (DG.Tweening.Core.ABSAnimationComponent)]);\n\tv123 = *([v184 @ X8_v12 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1D0]);\n\tv126 = *([v184 @ X8_v12 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1D8]);\nL_006D:\n\t// 109 IndirectJump v123 @ X2_v2, v156 @ X0_v3 (DG.Tweening.Core.ABSAnimationComponent), v156 @ X0_v3 (DG.Tweening.Core.ABSAnimationComponent), v126 @ X1_v2, v123 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_006F:\n\tthis._requiresRestartFromSpawnPoint = 1;\nL_0075:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			//IL_00fd: Expected I, but got O
			//IL_010d: Expected O, but got I
			//IL_011d: Expected O, but got I
			//IL_008f: Expected I, but got O
			//IL_009f: Expected O, but got I
			//IL_00af: Expected O, but got I
			if (onEnableBehaviour != OnEnableBehaviour.RestartFromSpawnPoint)
			{
				if (onEnableBehaviour != OnEnableBehaviour.Restart)
				{
					if (onEnableBehaviour != OnEnableBehaviour.Play || !(_animComponent != null))
					{
						return;
					}
					ABSAnimationComponent animComponent = _animComponent;
					IntPtr intPtr = (IntPtr)animComponent;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X8_v18 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+170]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X8_v18 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+178]");
					object obj2 = 0;
				}
				else
				{
					if (!(_animComponent != null))
					{
						return;
					}
					ABSAnimationComponent animComponent = _animComponent;
					IntPtr intPtr2 = (IntPtr)animComponent;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v12 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1D0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v12 (Il2CppClass<DG.Tweening.Core.ABSAnimationComponent>)+1D8]");
					object obj2 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X2_v2 (should have been resolved before IL gen)");
			}
			else
			{
				_requiresRestartFromSpawnPoint = true;
			}
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x163CF08", Offset = "0x163CF08", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ED8578]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A895]) = v40;\nL_0015:\n\tv38._requiresRestartFromSpawnPoint = 0;\n\tv42 = v38.onDisableBehaviour - 1;\n\tv43 = v42 < 4;\n\tv44 = ~v43;\n\tv45 = v42 - 4;\n\tv47 = v45 == 0;\n\tv52 = ~v47;\n\tv53 = v44 & v52;\n\tif (v53) goto L_00A2;\n\tv55 = 0x1853000 + 0x238;\n\tv57 = *([v55 @ X9_v2 (System.Int32)+v42 @ X8_v4 (System.Int32)*4]) + v55;\n\t// 39 IndirectJump v57 @ X8_v6, v38 @ X0_v1 (DG.Tweening.DOTweenVisualManager), v38 @ X0_v1 (DG.Tweening.DOTweenVisualManager), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+28]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0035;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0035;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0035:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00A2;\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_00D7;\n\tX8 = *([X0]);\n\tX2 = *([X8+1A0]);\n\tX1 = *([X8+1A8]);\n\tgoto L_0095;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+28]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0050;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0050;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0050:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00A2;\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_00D7;\n\tX8 = *([X0]);\n\tX2 = *([X8+1C0]);\n\tX1 = *([X8+1C8]);\n\tgoto L_0095;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+28]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006B;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006B;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006B:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008F;\n\tgoto L_00A2;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+28]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0081;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0081;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0081:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00A2;\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_00D7;\n\tX8 = *([X0]);\n\tX9 = *([X8+1F0]);\n\tX1 = *([X8+1F8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008F:\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_00D7;\n\tX8 = *([X0]);\n\tX2 = *([X8+200]);\n\tX1 = *([X8+208]);\nL_0095:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 154 ShiftStack 48\n\t// 155 IndirectJump X2, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\nL_00A2:\n\treturn;\n\tX21 = *([1EAB010]);\n\tX20 = *([X19+28]);\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00B0;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B0;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B0:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BE;\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_00D7;\n\tX8 = *([X0]);\n\tX9 = *([X8+200]);\n\tX1 = *([X8+208]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BE:\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tX8 = *([X21]);\n\tX19 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00CD;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00CD;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00CD:\n\tX0 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = 0;\n\tX21 = stack[0];\n\t// 212 ShiftStack 48\n\tUnityEngine.Object::Destroy(X0, X1);\n\treturn;\nL_00D7:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			//IL_0029: Expected O, but got I
			_requiresRestartFromSpawnPoint = false;
			int num = (int)(onDisableBehaviour - 1);
			bool flag = num < 4;
			bool flag2 = !flag;
			int num2 = num - 4;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25505792 + 568;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X9_v2 (System.Int32)+v42 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X8_v6 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x163D154", Offset = "0x163D154", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\t*([X0+10]) = 0;\n\t*([X0]) = 0;\n\t*([X0+8]) = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenVisualManager()
		{
		}
	}
}
