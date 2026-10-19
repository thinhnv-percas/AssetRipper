using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.InputSystem
{
	[Token(Token = "0x200024A")]
	public class GameplayInputController : MonoBehaviour, IDisposable
	{
		[SerializeField]
		[Token(Token = "0x4000702")]
		[FieldOffset(Offset = "0x20")]
		private Camera m_camera;

		[SerializeField]
		[Token(Token = "0x4000703")]
		[FieldOffset(Offset = "0x28")]
		private LayerMask m_raycastMask;

		[SerializeField]
		[Token(Token = "0x4000704")]
		[FieldOffset(Offset = "0x2C")]
		private float m_raycastDistance;

		[Inject(false)]
		[Token(Token = "0x4000705")]
		[FieldOffset(Offset = "0x30")]
		private EntityManager _em;

		[Token(Token = "0x4000706")]
		[FieldOffset(Offset = "0x38")]
		private InputBlockService _blockService;

		[Token(Token = "0x4000707")]
		[FieldOffset(Offset = "0x40")]
		private bool _isConstructed;

		[Token(Token = "0x4000708")]
		private static readonly List<RaycastResult> s_raycastResults;

		[Inject(false)]
		[Token(Token = "0x60009F3")]
		[Address(RVA = "0x3E9DE20", Offset = "0x3E9DE20", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\t;\n\tv49 = Unco.ContainerSystem.Runtime.Instancer::TryResolve(instancer, &this._blockService (_game.CoreGameKit.BaseLayer.Services.InputBlockService));\n\tthis._isConstructed = 1;\n\treturn;\n")]
		public void Construct(Instancer instancer)
		{
			bool flag = instancer.TryResolve<InputBlockService>(out _blockService);
			_isConstructed = true;
		}

		[Token(Token = "0x60009F4")]
		[Address(RVA = "0x3E9DE90", Offset = "0x3E9DE90", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv51 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv64 = ~v51;\n\tif (v64) goto L_003C;\n\tv98 = this._blockService == 0;\n\tif (v98) goto L_0032;\n\tv60 = _game.CoreGameKit.BaseLayer.Services.InputBlockService::IsBlocked(this._blockService, 1);\n\tv106 = v60 == 0;\n\tv65 = ~v106;\n\tif (v65) goto L_003C;\nL_0032:\n\tgoto L_0033;\nL_0033:\n\tv59 = _game.CoreSystem.New.TopGridSystem.InputSystem.GameplayInputController::IsPointerOverInteractableUI();\n\tv63 = v59 == 0;\n\tif (v63) goto L_0044;\nL_003C:\n\treturn;\nL_0044:\n\tv81 = UnityEngine.Input::get_mousePosition();\n\t_game.CoreSystem.New.TopGridSystem.InputSystem.GameplayInputController::HandleClick(this, v81);\n\treturn;\nL_001C:\n\tv48 = this._isConstructed != 1;\n\tif (v48) goto L_003C;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (_isConstructed && Input.GetMouseButtonDown(0) && (_blockService == null || !_blockService.IsBlocked(InputChannel.CubeInteraction)) && !IsPointerOverInteractableUI())
			{
				Vector3 mousePosition = Input.mousePosition;
				HandleClick(mousePosition);
			}
		}

		[Token(Token = "0x60009F5")]
		[Address(RVA = "0x3E9E130", Offset = "0x3E9E130", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_003A:\n\tv70 = UnityEngine.Object::op_Inequality(this.m_camera, 0);\n\tv76 = v70 == 0;\n\tif (v76) goto L_004F;\n\tv140 = this.m_camera;\n\tgoto L_0058;\nL_004F:\n\tv99 = UnityEngine.Camera::get_main();\n\tv140 = v99;\n\tgoto L_0058;\nL_0058:\n\tv118 = UnityEngine.Object::op_Equality(v140, 0);\n\tv129 = v118 == 0;\n\tif (v129) goto L_006F;\n\tgoto L_00EF;\nL_006F:\n\tv270 = UnityEngine.Camera::ScreenPointToRay(v140, screenPos);\n\tv349 = UnityEngine.LayerMask::op_Implicit(this.m_raycastMask);\n\tgoto L_0084;\nL_0084:\n\tv178 = v270.origin;\n\tv223 = UnityEngine.Physics::Raycast(&v178 @ stack_-B0_v3 (UnityEngine.Vector3), &v58 @ stack_-80_v1 (UnityEngine.RaycastHit), this.m_raycastDistance, v349);\n\tv232 = ~v223;\n\tif (v232) goto L_00EF;\n\tv295 = UnityEngine.RaycastHit::get_collider(&v58 @ stack_-80_v1 (UnityEngine.RaycastHit));\n\tv364 = UnityEngine.Component::GetComponentInParent(v295);\n\tgoto L_00A0;\nL_00A0:\n\tv224 = UnityEngine.Object::op_Equality(v364, 0);\n\tv233 = v224 == 0;\n\tif (v233) goto L_00BA;\n\tgoto L_00EF;\nL_00BA:\n\tv145 = v364.IsBound != 1;\n\tif (v145) goto L_00EF;\n\tv227 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v364.Entity);\n\tv236 = ~v227;\n\tif (v236) goto L_00EF;\n\tv228 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v364.Entity);\n\tv237 = ~v228;\n\tif (v237) goto L_00EF;\n\tv229 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v364.Entity);\n\tv378 = v229 == 0;\n\tv238 = ~v378;\n\tif (v238) goto L_00EF;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v364.Entity, 0);\nL_00EF:\n\treturn;\nL_0030:\n\tv58 = 0;\n\tgoto L_003A;\n")]
		private unsafe void HandleClick(Vector3 screenPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayInputController::HandleClick");
		}

		[Token(Token = "0x60009F6")]
		[Address(RVA = "0x3E9DF40", Offset = "0x3E9DF40", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv49 = 0xB292000 + 0x5A0;\n\tgoto L_0016;\nL_0016:\n\tv52 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv62 = *([v49 @ X20_v12 (System.Int32)]);\n\tv64 = *([v62 @ X0_v55+E4]) == 0;\n\tv121 = v52;\n\tif (v64) goto L_0054;\n\tv82 = UnityEngine.Object::op_Equality(v121, 0);\n\tv94 = v82 == 0;\n\tif (v94) goto L_005C;\nL_002B:\n\treturn 0;\nL_0054:\n\tv98 = UnityEngine.Object::op_Equality(v52, 0);\n\tv129 = v98 == 0;\n\tv106 = ~v129;\n\tv121 = v52;\n\tif (v106) goto L_002B;\nL_005C:\n\tv127 = new UnityEngine.EventSystems.PointerEventData();\n\tUnityEngine.EventSystems.PointerEventData::.ctor(v127, v121);\n\tv184 = UnityEngine.Input::get_mousePosition();\n\tv127.<position>k__BackingField.x = v184;\n\tv127.<position>k__BackingField.y = v184.y;\n\tgoto L_0073;\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::Clear(v245);\n\tv228 = v245.Count < 1;\n\tif (v228) goto L_0093;\nL_0093:\n\tUnityEngine.EventSystems.EventSystem::RaycastAll(v121, v127, v257.s_raycastResults);\n\tgoto L_009C;\n\tv165 = v246.Count < 0;\n\tv161 = v246.Count == 0;\n\tv153 = v246.Count ^ v246.Count;\n\tv149 = v246.Count & v153;\n\tv145 = v149 < 0;\n\tv267 = v165 == v145;\n\tv135 = ~v161;\n\tv141 = v267 & v135;\n\treturn v141;\nL_0073:\n\tv245 = v249.s_raycastResults;\nL_009C:\n\tv246 = v265.s_raycastResults;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsPointerOverInteractableUI()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayInputController::IsPointerOverInteractableUI");
			return default;
		}

		[Token(Token = "0x60009F7")]
		[Address(RVA = "0x3E9E3E8", Offset = "0x3E9E3E8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB78E000;\n\tv18 = *([B78E723]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0026;\n\tv21 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v21;\n\tgoto L_001D;\nL_001D:\n\tUnityEngine.Object::Destroy(v53);\n\treturn;\nL_0026:\n\t*([v14 @ X20_v1+723]) = 1;\n\tv49 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v49;\n\tgoto L_001D;\n")]
		public void Dispose()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E723]");
			UnityEngine.Object obj2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				GameObject gameObject = base.gameObject;
				obj2 = gameObject;
			}
			else
			{
				_ = 1;
				GameObject gameObject2 = base.gameObject;
				obj2 = gameObject2;
			}
			UnityEngine.Object.Destroy(obj2);
		}

		[Token(Token = "0x60009F8")]
		[Address(RVA = "0x3E9E48C", Offset = "0x3E9E48C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.m_raycastMask = v14;\n\tthis.m_raycastDistance = 1000f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public GameplayInputController()
		{
			LayerMask raycastMask = -1;
			m_raycastMask = raycastMask;
			m_raycastDistance = 1000f;
		}

		[Token(Token = "0x60009F9")]
		[Address(RVA = "0x3E9E4C4", Offset = "0x3E9E4C4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>();\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::.ctor(v49);\n\tv58.s_raycastResults = v49;\n")]
		static GameplayInputController()
		{
			List<RaycastResult> list = new List<RaycastResult>();
			s_raycastResults = list;
		}
	}
}
