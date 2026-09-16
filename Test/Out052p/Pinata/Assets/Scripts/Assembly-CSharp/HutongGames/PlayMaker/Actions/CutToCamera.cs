using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7546B0", Offset = "0x7546B0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7546B0", Offset = "0x7546B0")]
	[Token(Token = "0x2000193")]
	public class CutToCamera : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB94C", Offset = "0x7AB94C")]
		[Token(Token = "0x40012CE")]
		[FieldOffset(Offset = "0x50")]
		public Camera camera;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB998", Offset = "0x7AB998")]
		[Token(Token = "0x40012CF")]
		[FieldOffset(Offset = "0x58")]
		public bool makeMainCamera;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB9D0", Offset = "0x7AB9D0")]
		[Token(Token = "0x40012D0")]
		[FieldOffset(Offset = "0x59")]
		public bool cutBackOnExit;

		[Token(Token = "0x40012D1")]
		[FieldOffset(Offset = "0x60")]
		private Camera oldCamera;

		[Token(Token = "0x600089E")]
		[Address(RVA = "0xA96724", Offset = "0xA96724", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.camera = 0;\n\tthis.makeMainCamera = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			camera = null;
			makeMainCamera = true;
			cutBackOnExit = false;
		}

		[Token(Token = "0x600089F")]
		[Address(RVA = "0xA96734", Offset = "0xA96734", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC9388]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022213]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.camera, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0034;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing camera!\");\n\treturn;\nL_0034:\n\tv69 = UnityEngine.Camera::get_main();\n\tthis.oldCamera = v69;\n\tv71 = UnityEngine.Camera::get_main();\n\tHutongGames.PlayMaker.Actions.CutToCamera::SwitchCamera(v71, this.camera);\n\tv94 = ~this.makeMainCamera;\n\tif (v94) goto L_004C;\n\tUnityEngine.Component::set_tag(this.camera, \"MainCamera\");\nL_004C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (camera == null)
			{
				LogError("Missing camera!");
				return;
			}
			Camera main = Camera.main;
			oldCamera = main;
			Camera main2 = Camera.main;
			SwitchCamera(main2, camera);
			if (makeMainCamera)
			{
				camera.tag = "MainCamera";
			}
			Finish();
		}

		[Token(Token = "0x60008A0")]
		[Address(RVA = "0xA96900", Offset = "0xA96900", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.cutBackOnExit;\n\tif (v2) goto L_0008;\n\tHutongGames.PlayMaker.Actions.CutToCamera::SwitchCamera(this.camera, this.oldCamera);\n\treturn;\nL_0008:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (cutBackOnExit)
			{
				SwitchCamera(camera, oldCamera);
			}
		}

		[Token(Token = "0x60008A1")]
		[Address(RVA = "0xA96818", Offset = "0xA96818", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBB330]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, camera2, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022214]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, camera2, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(camera1, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0032;\n\tUnityEngine.Behaviour::set_enabled(camera1, 0);\nL_0032:\n\tgoto L_003B;\n\tv85 = *([v69 @ X0_v10+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_003B;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v69, v64, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003B:\n\tv78 = UnityEngine.Object::op_Inequality(camera2, 0);\n\tv93 = v78 == 0;\n\tif (v93) goto L_0052;\n\tUnityEngine.Behaviour::set_enabled(camera2, 1);\n\treturn;\nL_0052:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SwitchCamera(Camera camera1, Camera camera2)
		{
			if (camera1 != null)
			{
				camera1.enabled = false;
			}
			if (camera2 != null)
			{
				camera2.enabled = true;
			}
		}

		[Token(Token = "0x60008A2")]
		[Address(RVA = "0xA9691C", Offset = "0xA9691C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CutToCamera()
		{
		}
	}
}
