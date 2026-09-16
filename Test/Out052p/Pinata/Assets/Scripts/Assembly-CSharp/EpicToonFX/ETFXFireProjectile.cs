using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EpicToonFX
{
	[Token(Token = "0x2000062")]
	public class ETFXFireProjectile : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000292")]
		[FieldOffset(Offset = "0x18")]
		public GameObject[] projectiles;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x764CA0", Offset = "0x764CA0")]
		[Token(Token = "0x4000293")]
		[FieldOffset(Offset = "0x20")]
		public Transform spawnPosition;

		[HideInInspector]
		[Token(Token = "0x4000294")]
		[FieldOffset(Offset = "0x28")]
		public int currentProjectile;

		[Token(Token = "0x4000295")]
		[FieldOffset(Offset = "0x2C")]
		public float speed;

		[Token(Token = "0x4000296")]
		[FieldOffset(Offset = "0x30")]
		private ETFXButtonScript selectedProjectileButton;

		[Token(Token = "0x4000297")]
		[FieldOffset(Offset = "0x38")]
		private RaycastHit hit;

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0xA04788", Offset = "0xA04788", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC4D70]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C83]) = v38;\nL_0017:\n\tv43 = UnityEngine.GameObject::Find(\"Button\");\n\tv48 = UnityEngine.GameObject::GetComponent(v43);\n\tthis.selectedProjectileButton = v48;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			GameObject gameObject = GameObject.Find("Button");
			ETFXButtonScript component = gameObject.GetComponent<ETFXButtonScript>();
			selectedProjectileButton = component;
		}

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0xA047F8", Offset = "0xA047F8", Length = "0x458")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv38 = *([1EDCB88]);\n\tv39 = *([v38 @ X8_v53]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2021C84]) = v58;\nL_0022:\n\tv64 = UnityEngine.Input::GetKeyDown(0x113);\n\tv66 = v64 == 0;\n\tif (v66) goto L_002A;\n\tEpicToonFX.ETFXFireProjectile::nextEffect(this);\nL_002A:\n\tv71 = UnityEngine.Input::GetKeyDown(0x64);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0032;\n\tEpicToonFX.ETFXFireProjectile::nextEffect(this);\nL_0032:\n\tv78 = UnityEngine.Input::GetKeyDown(0x61);\n\tv80 = v78 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_003E;\n\tv84 = UnityEngine.Input::GetKeyDown(0x114);\n\tv88 = v84 == 0;\n\tif (v88) goto L_0041;\nL_003E:\n\tEpicToonFX.ETFXFireProjectile::previousEffect(this);\nL_0041:\n\tv96 = UnityEngine.Input::GetKeyDown(0x143);\n\tv98 = v96 == 0;\n\tif (v98) goto L_0107;\n\tgoto L_0052;\n\tv238 = *([v101 @ X0_v45+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_0052;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v101, v95, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0052:\n\tv245 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv223 = UnityEngine.EventSystems.EventSystem::IsPointerOverGameObject(v245);\n\tv413 = v223 == 0;\n\tv227 = ~v413;\n\tif (v227) goto L_0107;\n\tv470 = UnityEngine.Camera::get_main();\n\tv394 = UnityEngine.Input::get_mousePosition();\n\tv607 = UnityEngine.Camera::ScreenPointToRay(v470, v394);\n\tv204 = v607.m_Origin;\n\tv235 = this + 0x38;\n\tv224 = UnityEngine.Physics::Raycast(&v204 @ stack_-A8 (UnityEngine.Vector3), v235, 100f);\n\tv228 = v224 == 0;\n\tif (v228) goto L_0107;\n\tv370 = this.projectiles;\n\tv177 = this.currentProjectile;\n\tv644 = this.currentProjectile < v370.Length;\n\tv171 = ~v644;\n\tif (v171) goto L_0194;\n\tv668 = UnityEngine.Transform::get_position(this.spawnPosition);\n\tgoto L_00A6;\n\tv682 = *([v678 @ X0_v58+E0]);\n\tv683 = v682 == 0;\n\tv684 = ~v683;\n\tif (v684) goto L_00A6;\n\tv686 = \"il2cpp_codegen_runtime_class_init\"(v678, v667, v180, v43, v44, v45, v46, v47, v668, v674, v675, v51, v52, v53, v54, v55);\nL_00A6:\n\tv690 = UnityEngine.Quaternion::get_identity();\n\tgoto L_00C7;\n\tv700 = *([v696 @ X0_v61+E0]);\n\tv701 = v700 == 0;\n\tv702 = ~v701;\n\tif (v702) goto L_00C7;\n\tv704 = \"il2cpp_codegen_runtime_class_init\"(v696, v667, v180, v43, v44, v45, v46, v47, v690, v691, v692, v693, v52, v53, v54, v55);\nL_00C7:\n\tv359 = UnityEngine.Object::Instantiate(v370[v177 @ X9_v5 (System.Int32)], v668, v690);\n\tv711 = UnityEngine.GameObject::get_transform(v359);\n\tv401 = 0x164C878(v235, 0, 0, v43, v44, v45, v46, v47, v668, v668.y, v668.z, v690, v690.y, v690.z, v690.w, v55);\n\tUnityEngine.Transform::LookAt(v711, v668);\n\tv718 = UnityEngine.GameObject::GetComponent(v359);\n\tv360 = UnityEngine.GameObject::get_transform(v359);\n\tv720 = UnityEngine.Transform::get_forward(v360);\n\tgoto L_00FD;\n\tv729 = *([v725 @ X0_v74+E0]);\n\tv730 = v729 == 0;\n\tv731 = ~v730;\n\tif (v731) goto L_00FD;\n\tv733 = \"il2cpp_codegen_runtime_class_init\"(v725, v397, v180, v43, v44, v45, v46, v47, v720, v721, v722, v289, v127, v125, v123, v55);\nL_00FD:\n\tv215 = UnityEngine.Vector3::op_Multiply(v720, this.speed);\n\tUnityEngine.Rigidbody::AddForce(v718, v215);\nL_0107:\n\tv237 = UnityEngine.Camera::get_main();\n\tv248 = UnityEngine.Input::get_mousePosition();\n\tv376 = &v204 @ stack_-A8 (UnityEngine.Vector3);\n\tv380 = UnityEngine.Camera::ScreenPointToRay(v237, v248);\n\tv204 = *([v376 @ X8_v7]);\n\tv468 = 0x10C8B24(&v204 @ stack_-A8 (UnityEngine.Vector3), 0, v179, v43, v44, v45, v46, v47, *([v376 @ X8_v7]), v248.y, v248.z, this.speed, v690.y, v690.z, v690.w, v55);\n\tv475 = UnityEngine.Camera::get_main();\n\tv395 = UnityEngine.Input::get_mousePosition();\n\tv612 = UnityEngine.Camera::ScreenPointToRay(v475, v395);\n\tv517 = v612.m_Origin;\n\tv619 = 0x10C8B18(&v517 @ stack_-D8_v1 (UnityEngine.Vector3), 0, v179, v43, v44, v45, v46, v47, v612.m_Origin, v395.y, v395.z, this.speed, v690.y, v690.z, v690.w, v55);\n\tgoto L_0157;\n\tv630 = *([v626 @ X0_v36+E0]);\n\tv631 = v630 == 0;\n\tv632 = ~v631;\n\tif (v632) goto L_0157;\n\tv634 = \"il2cpp_codegen_runtime_class_init\"(v626, v591, v179, v43, v44, v45, v46, v47, v617, v393, v392, v136, v126, v124, v122, v55);\nL_0157:\n\t// 343 MakeStruct v499 @ AGGA04BA4_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v612.m_Origin (UnityEngine.Vector3), v395.y (System.Single), v395.z (System.Single)\n\tv643 = UnityEngine.Vector3::op_Multiply(v499, 100f);\n\tv651 = UnityEngine.Color::get_yellow();\n\tgoto L_017E;\n\tv669 = *([v660 @ X0_v40+E0]);\n\tv670 = v669 == 0;\n\tv671 = ~v670;\n\tif (v671) goto L_017E;\n\tv673 = \"il2cpp_codegen_runtime_class_init\"(v660, v591, v179, v43, v44, v45, v46, v47, v651, v652, v653, v654, v126, v124, v122, v55);\nL_017E:\n\t// 382 MakeStruct v482 @ AGGA04C0C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v376 @ X8_v7], v248.y (System.Single), v248.z (System.Single)\n\tUnityEngine.Debug::DrawRay(v482, v643, v651);\n\treturn;\n\tv357 = new System.NullReferenceException();\n\tv375 = new System.NullReferenceException();\nL_0194:\n\tv465 = new System.IndexOutOfRangeException();\n\tthrow v465;\n\treturn;\n// 297 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Update()
		{
			//IL_017a: Expected O, but got Ref
			//IL_03c1: Expected F4, but got O
			//IL_019b: Expected O, but got I4
			//IL_02bf: Expected O, but got I4
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				nextEffect();
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				nextEffect();
			}
			if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				previousEffect();
			}
			Vector3 vector = default(Vector3);
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				EventSystem current = EventSystem.current;
				if (!current.IsPointerOverGameObject())
				{
					Camera main = Camera.main;
					Vector3 mousePosition = Input.mousePosition;
					vector = main.ScreenPointToRay(mousePosition).m_Origin;
					bool flag = Physics.Raycast((Ray)(&vector), out *(RaycastHit*)((long)(IntPtr)this + 56L), 100f);
					bool flag2 = !flag;
					object obj = 0;
					if (!flag2)
					{
						GameObject[] array = projectiles;
						int num = currentProjectile;
						if (currentProjectile >= array.Length)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						Vector3 position = spawnPosition.position;
						Quaternion identity = Quaternion.identity;
						GameObject gameObject = UnityEngine.Object.Instantiate(array[num], position, identity);
						Transform transform = gameObject.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
						transform.LookAt(position);
						Rigidbody component = gameObject.GetComponent<Rigidbody>();
						Transform transform2 = gameObject.transform;
						Vector3 forward = transform2.forward;
						Vector3 force = forward * speed;
						component.AddForce(force);
						obj = 0;
					}
				}
			}
			Camera main2 = Camera.main;
			Vector3 mousePosition2 = Input.mousePosition;
			object obj2 = vector;
			Ray ray = main2.ScreenPointToRay(mousePosition2);
			vector = (Vector3)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C8B24 (inside UnityEngine.Object::.cctor +0x3F4)");
			Camera main3 = Camera.main;
			Vector3 mousePosition3 = Input.mousePosition;
			Ray ray2 = main3.ScreenPointToRay(mousePosition3);
			Vector3 origin = ray2.m_Origin;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C8B18 (inside UnityEngine.Object::.cctor +0x3E8)");
			Vector3 vector2 = default(Vector3);
			vector2.x = ray2.m_Origin.x;
			vector2.y = mousePosition3.y;
			vector2.z = mousePosition3.z;
			Vector3 dir = vector2 * 100f;
			Color yellow = Color.yellow;
			Vector3 start = default(Vector3);
			start.x = (float)obj2;
			start.y = mousePosition2.y;
			start.z = mousePosition2.z;
			Debug.DrawRay(start, dir, yellow);
		}

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0xA04C50", Offset = "0xA04C50", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.projectiles;\n\tv12 = v6.Length - 1;\n\tv23 = this.currentProjectile < v12;\n\tif (v23) goto L_0019;\n\tgoto L_001B;\nL_0019:\n\tv48 = this.currentProjectile + 1;\nL_001B:\n\tthis.currentProjectile = v48;\n\tEpicToonFX.ETFXButtonScript::getProjectileNames(this.selectedProjectileButton);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void nextEffect()
		{
			GameObject[] array = projectiles;
			int num = array.Length - 1;
			int num2 = ((currentProjectile < num) ? (currentProjectile + 1) : 0);
			currentProjectile = num2;
			selectedProjectileButton.getProjectileNames();
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0xA04C94", Offset = "0xA04C94", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = this.currentProjectile;\n\tv19 = this.currentProjectile > 0;\n\tif (v19) goto L_0017;\n\tv20 = this.projectiles;\n\tv26 = v20.Length;\nL_0017:\n\tv29 = v26 - 1;\n\tthis.currentProjectile = v29;\n\tEpicToonFX.ETFXButtonScript::getProjectileNames(this.selectedProjectileButton);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void previousEffect()
		{
			int num = currentProjectile;
			if (currentProjectile <= 0)
			{
				GameObject[] array = projectiles;
				num = array.Length;
			}
			int num2 = num - 1;
			currentProjectile = num2;
			selectedProjectileButton.getProjectileNames();
		}

		[Token(Token = "0x60002A8")]
		[Address(RVA = "0xA04CD8", Offset = "0xA04CD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.speed = newSpeed;\n\treturn;\n")]
		public void AdjustSpeed(float newSpeed)
		{
			speed = newSpeed;
		}

		[Token(Token = "0x60002A9")]
		[Address(RVA = "0xA04CE0", Offset = "0xA04CE0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.speed = 500f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ETFXFireProjectile()
		{
			speed = 500f;
		}
	}
}
