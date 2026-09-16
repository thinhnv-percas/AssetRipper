using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200000B")]
public class UICanvasManager : MonoBehaviour
{
	[Token(Token = "0x400003A")]
	public static UICanvasManager GlobalAccess;

	[Token(Token = "0x400003B")]
	[FieldOffset(Offset = "0x18")]
	public bool MouseOverButton;

	[Token(Token = "0x400003C")]
	[FieldOffset(Offset = "0x20")]
	public Text PENameText;

	[Token(Token = "0x400003D")]
	[FieldOffset(Offset = "0x28")]
	public Text ToolTipText;

	[Token(Token = "0x400003E")]
	[FieldOffset(Offset = "0x30")]
	private RaycastHit rayHit;

	[Token(Token = "0x6000039")]
	[Address(RVA = "0x16448C8", Offset = "0x16448C8", Length = "0x54")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF4F98]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB22]) = v38;\nL_0017:\n\tv42.GlobalAccess = this;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		GlobalAccess = this;
	}

	[Token(Token = "0x600003A")]
	[Address(RVA = "0x164491C", Offset = "0x164491C", Length = "0xCC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F07A40]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB23]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.PENameText, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0043;\n\tv69 = this.PENameText;\n\tv71 = ParticleEffectsLibrary::GetCurrentPENameString(v62.GlobalAccess);\n\tv92 = *([v69 @ X19_v4 (UnityEngine.UI.Text)]);\n\tv74 = *([v92 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv78 = *([v92 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 61 IndirectJump v74 @ X3_v1, v69 @ X19_v4 (UnityEngine.UI.Text), v69 @ X19_v4 (UnityEngine.UI.Text), v71 @ X0_v11 (System.String), v78 @ X2_v2, v74 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		//IL_0057: Expected I, but got O
		//IL_0067: Expected O, but got I
		//IL_0077: Expected O, but got I
		if (PENameText != null)
		{
			Text pENameText = PENameText;
			string currentPENameString = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
			IntPtr intPtr = (IntPtr)pENameText;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ X3_v1 (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x600003B")]
	[Address(RVA = "0x16449E8", Offset = "0x16449E8", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this.MouseOverButton;\n\tv12 = ~v11;\n\tif (v12) goto L_0014;\n\tv15 = UnityEngine.Input::GetMouseButtonUp(0);\n\tv21 = v15 == 0;\n\tif (v21) goto L_0014;\n\tUICanvasManager::SpawnCurrentParticleEffect(this);\nL_0014:\n\tv24 = UnityEngine.Input::GetKeyUp(0x61);\n\tv27 = v24 == 0;\n\tif (v27) goto L_001C;\n\tUICanvasManager::SelectPreviousPE(this);\nL_001C:\n\tv32 = UnityEngine.Input::GetKeyUp(0x64);\n\tv34 = v32 == 0;\n\tif (v34) goto L_002B;\n\tUICanvasManager::SelectNextPE(this);\n\treturn;\nL_002B:\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (!MouseOverButton && Input.GetMouseButtonUp(0))
		{
			SpawnCurrentParticleEffect();
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			SelectPreviousPE();
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			SelectNextPE();
		}
	}

	[Token(Token = "0x600003C")]
	[Address(RVA = "0x1644D0C", Offset = "0x1644D0C", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EC0D88]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, toolTipType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AB24]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, toolTipType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.ToolTipText, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_004B;\n\tv66 = toolTipType == 2;\n\tif (v66) goto L_004C;\n\tv73 = toolTipType != 1;\n\tif (v73) goto L_004B;\n\tv145 = this.ToolTipText;\n\tv155 = *([v145 @ X0_v6 (UnityEngine.UI.Text)]);\n\tgoto L_0052;\nL_004B:\n\treturn;\nL_004C:\n\tv145 = this.ToolTipText;\n\tv155 = *([v145 @ X0_v6 (UnityEngine.UI.Text)]);\nL_0052:\n\tv143 = *([v112 @ X9_v1 (System.String)]);\n\tv107 = *([v155 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv141 = *([v155 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 91 IndirectJump v107 @ X3_v1, v145 @ X0_v6 (UnityEngine.UI.Text), v145 @ X0_v6 (UnityEngine.UI.Text), v143 @ X1_v2 (Il2CppClass<System.String>), v141 @ X2_v2, v107 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void UpdateToolTip(ButtonTypes toolTipType)
	{
		//IL_00ac: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_0086: Expected I, but got O
		if (ToolTipText != null)
		{
			string text;
			switch (toolTipType)
			{
			case ButtonTypes.Previous:
			{
				Text toolTipText = ToolTipText;
				IntPtr intPtr = (IntPtr)toolTipText;
				text = "Select Previous Particle Effect";
				break;
			}
			default:
				return;
			case ButtonTypes.Next:
			{
				Text toolTipText = ToolTipText;
				IntPtr intPtr = (IntPtr)toolTipText;
				text = "Select Next Particle Effect";
				break;
			}
			}
			IntPtr intPtr2 = (IntPtr)text;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v107 @ X3_v1 (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0x1644DEC", Offset = "0x1644DEC", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC0EA0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB25]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.ToolTipText, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003B;\n\tv59 = this.ToolTipText;\n\tv66 = *([v59 @ X0_v6 (UnityEngine.UI.Text)]);\n\tv70 = *([v66 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv72 = *([v66 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 53 IndirectJump v70 @ X3_v1, v59 @ X0_v6 (UnityEngine.UI.Text), v59 @ X0_v6 (UnityEngine.UI.Text), \"\", v72 @ X2_v2, v70 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ClearToolTip()
	{
		//IL_0049: Expected I, but got O
		//IL_0059: Expected O, but got I
		//IL_0069: Expected O, but got I
		if (ToolTipText != null)
		{
			Text toolTipText = ToolTipText;
			IntPtr intPtr = (IntPtr)toolTipText;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v7 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v70 @ X3_v1 (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0x1644B2C", Offset = "0x1644B2C", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1EE61D0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AB26]) = v40;\nL_001C:\n\tParticleEffectsLibrary::PreviousParticleEffect(v44.GlobalAccess);\n\tgoto L_002D;\n\tv80 = *([v63 @ X0_v8+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002D;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v63, v47, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002D:\n\tv88 = UnityEngine.Object::op_Inequality(this.PENameText, 0);\n\tv90 = v88 == 0;\n\tif (v90) goto L_004D;\n\tv75 = this.PENameText;\n\tv71 = ParticleEffectsLibrary::GetCurrentPENameString(v57.GlobalAccess);\n\tv109 = *([v75 @ X19_v4 (UnityEngine.UI.Text)]);\n\tv95 = *([v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv100 = *([v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 70 IndirectJump v95 @ X3_v1, v75 @ X19_v4 (UnityEngine.UI.Text), v75 @ X19_v4 (UnityEngine.UI.Text), v71 @ X0_v13 (System.String), v100 @ X2_v4, v95 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SelectPreviousPE()
	{
		//IL_0066: Expected I, but got O
		//IL_0076: Expected O, but got I
		//IL_0086: Expected O, but got I
		ParticleEffectsLibrary.GlobalAccess.PreviousParticleEffect();
		if (PENameText != null)
		{
			Text pENameText = PENameText;
			string currentPENameString = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
			IntPtr intPtr = (IntPtr)pENameText;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v95 @ X3_v1 (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0x1644C1C", Offset = "0x1644C1C", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1EBEF98]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AB27]) = v40;\nL_001C:\n\tParticleEffectsLibrary::NextParticleEffect(v44.GlobalAccess);\n\tgoto L_002D;\n\tv80 = *([v63 @ X0_v8+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002D;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v63, v47, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002D:\n\tv88 = UnityEngine.Object::op_Inequality(this.PENameText, 0);\n\tv90 = v88 == 0;\n\tif (v90) goto L_004D;\n\tv75 = this.PENameText;\n\tv71 = ParticleEffectsLibrary::GetCurrentPENameString(v57.GlobalAccess);\n\tv109 = *([v75 @ X19_v4 (UnityEngine.UI.Text)]);\n\tv95 = *([v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv100 = *([v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 70 IndirectJump v95 @ X3_v1, v75 @ X19_v4 (UnityEngine.UI.Text), v75 @ X19_v4 (UnityEngine.UI.Text), v71 @ X0_v13 (System.String), v100 @ X2_v4, v95 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SelectNextPE()
	{
		//IL_0066: Expected I, but got O
		//IL_0076: Expected O, but got I
		//IL_0086: Expected O, but got I
		ParticleEffectsLibrary.GlobalAccess.NextParticleEffect();
		if (PENameText != null)
		{
			Text pENameText = PENameText;
			string currentPENameString = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
			IntPtr intPtr = (IntPtr)pENameText;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v95 @ X3_v1 (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x1644A5C", Offset = "0x1644A5C", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED6BD8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB28]) = v38;\nL_0014:\n\tv40 = UnityEngine.Camera::get_main();\n\tv43 = UnityEngine.Input::get_mousePosition();\n\tv52 = UnityEngine.Camera::ScreenPointToRay(v40, v43);\n\tv77 = v52.m_Origin;\n\tv89 = this + 0x30;\n\tv99 = UnityEngine.Physics::Raycast(&v77 @ stack_-38_v2 (UnityEngine.Vector3), v89);\n\tv101 = v99 == 0;\n\tif (v101) goto L_0046;\n\tv85 = 0x164C878(v89, 0, 0, v23, v24, v25, v26, v27, v77, v43.y, v43.z, v31, v32, v33, v34, v35);\n\t// 63 MakeStruct v136 @ AGG1644B10_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v77 @ stack_-38_v2 (UnityEngine.Vector3), v43.y (System.Single), v43.z (System.Single)\n\tParticleEffectsLibrary::SpawnParticleEffect(v91.GlobalAccess, v136);\nL_0046:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void SpawnCurrentParticleEffect()
	{
		//IL_003c: Expected O, but got Ref
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 origin = main.ScreenPointToRay(mousePosition).m_Origin;
		if (Physics.Raycast((Ray)(&origin), out *(RaycastHit*)((long)(IntPtr)this + 48L)))
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
			Vector3 positionInWorldToSpawn = default(Vector3);
			positionInWorldToSpawn.x = origin.x;
			positionInWorldToSpawn.y = mousePosition.y;
			positionInWorldToSpawn.z = mousePosition.z;
			ParticleEffectsLibrary.GlobalAccess.SpawnParticleEffect(positionInWorldToSpawn);
		}
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0x1644E94", Offset = "0x1644E94", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = buttonTypeClicked == 2;\n\tif (v5) goto L_0017;\n\tv19 = buttonTypeClicked != 1;\n\tif (v19) goto L_0019;\n\tUICanvasManager::SelectPreviousPE(this);\n\treturn;\nL_0017:\n\tUICanvasManager::SelectNextPE(this);\n\treturn;\nL_0019:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void UIButtonClick(ButtonTypes buttonTypeClicked)
	{
		switch (buttonTypeClicked)
		{
		case ButtonTypes.Previous:
			SelectPreviousPE();
			break;
		case ButtonTypes.Next:
			SelectNextPE();
			break;
		}
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0x1644EB0", Offset = "0x1644EB0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UICanvasManager()
	{
	}
}
