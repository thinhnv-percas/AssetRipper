using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.AdSystem;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.HoveringTextSystem;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace Systems.UISystem
{
	[RequireComponent(typeof(UncoButton))]
	[Token(Token = "0x2000026")]
	public class RewardedButton : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000027")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000052")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000053")]
			public static Action _003C_003E9__10_0;

			[Token(Token = "0x6000092")]
			[Address(RVA = "0x3C66B68", Offset = "0x3C66B68", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Systems.UISystem.RewardedButton+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000093")]
			[Address(RVA = "0x3C66BCC", Offset = "0x3C66BCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003COnClicked_003Eb__10_0()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_button;

		[SerializeField]
		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x28")]
		private RewardedAdCategory m_category;

		[SerializeField]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x30")]
		private string m_notReadyText;

		[Inject(false)]
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x38")]
		private IAdManager m_adManager;

		[Inject(false)]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x40")]
		private ILevelProgressService m_levelProgressService;

		[Inject(true)]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x48")]
		private HoveringTextController m_hoveringTextController;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x50")]
		private Action _onAdSuccess;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x58")]
		private Action _onAdFailed;

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x3C66500", Offset = "0x3C66500", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis.m_button = v46;\n\treturn;\n")]
		private void Reset()
		{
			UncoButton component = GetComponent<UncoButton>();
			m_button = component;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x3C66564", Offset = "0x3C66564", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tthis._onAdSuccess = v41;\n\tthis._onAdFailed = onAdFailed;\n\tv82 = new System.Action();\n\tSystem.Action::.ctor(v82, this, Il2CppMethodInfo);\n\tUnco.UncoButtonSystem.UncoButton::AddListener(this.m_button, v82, 1, 0);\n\treturn;\nL_0045:\n\tv69 = 0xB28B000 + 0x600;\n\tv86 = new v69();\n\tv93 = 0xB30E000 + 0x440;\n\tSystem.ArgumentNullException::.ctor(v86, v93);\n\tthrow v86;\nL_001A:\n\tv48 = v41 == 0;\n\tif (v48) goto L_0045;\n")]
		public void Init(Action onAdSuccess, Action onAdFailed = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardedButton::Init");
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x3C66678", Offset = "0x3C66678", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\nL_0036:\n\tUnco.UncoButtonSystem.UncoButton::SetInteractable(this.m_button, 0);\n\tv210 = this.m_adManager;\n\tgoto L_0049;\n\tgoto L_0056;\nL_0065:\n\tv321 = new System.Action();\n\tSystem.Action::.ctor(v321, this, Il2CppMethodInfo);\n\tv342 = new System.Action();\n\tSystem.Action::.ctor(v342, this, Il2CppMethodInfo);\n\tv351 = new System.Action();\n\tSystem.Action::.ctor(v351, this, Il2CppMethodInfo);\n\tv143 = new System.Action();\n\tSystem.Action::.ctor(v143, this, Il2CppMethodInfo);\n\tv156 = this.m_levelProgressService;\n\tv359 = *([v156 @ X22_v6 (_game.CoreGameKit.CoreSerivces.LevelProgresService.Interface.ILevelProgressService)]);\n\tv386 = *([v359 @ X8_v13 (Il2CppClass<_game.CoreGameKit.CoreSerivces.LevelProgresService.Interface.ILevelProgressService>)+12E]);\n\tv361 = *([v359 @ X8_v13 (Il2CppClass<_game.CoreGameKit.CoreSerivces.LevelProgresService.Interface.ILevelProgressService>)+12E]) == 0;\n\tif (v361) goto L_00AA;\n\tv112 = *([v359 @ X8_v13 (Il2CppClass<_game.CoreGameKit.CoreSerivces.LevelProgresService.Interface.ILevelProgressService>)+B0]) + 8;\n\tv112 = v112 + 0x10;\n\tv374 = v386 - 1;\n\tv364 = v386 != 1;\nL_FFFFFFFF:\n\tv386 = v374;\n\tif (v364) goto L_0091;\nL_00AA:\n\tv205 = _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface.ILevelProgressService::get_CurrentLevelIndex(v156);\nL_00B1:\n\tv209 = *([v210 @ X19_v4 (Unco.AdSystem.IAdManager)]);\n\tv197 = *([v209 @ X8_v17 (Il2CppClass<Unco.AdSystem.IAdManager>)+12E]);\n\tv207 = *([v209 @ X8_v17 (Il2CppClass<Unco.AdSystem.IAdManager>)+12E]) == 0;\n\tif (v207) goto L_FFFFFFFF;\n\tv190 = *([v209 @ X8_v17 (Il2CppClass<Unco.AdSystem.IAdManager>)+B0]) + 8;\n\tv190 = v190 + 0x10;\n\tv424 = v197 - 1;\n\tv414 = v197 != 1;\nL_FFFFFFFF:\n\tv197 = v424;\n\tif (v414) goto L_00BC;\nL_FFFFFFFF:\n\tv259 = v143;\nL_FFFFFFFF:\n\tv260 = v351;\nL_FFFFFFFF:\n\tv261 = v321;\nL_FFFFFFFF:\n\tv270 = v342;\nL_FFFFFFFF:\n\tv276 = v205;\n\tgoto L_00EF;\nL_00D4:\n\tv73 = *([v112 @ X10_v13]) << 4;\n\tv390 = v359 + v73;\n\tv391 = v390 + 0x138;\n\t*([v391 @ X0_v28])(v205, v156, *([v391 @ X0_v28+8]), Il2CppMethodInfo, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv393 = v210 == 0;\n\tv146 = ~v393;\nL_FFFFFFFF:\n\tv259 = v143;\nL_FFFFFFFF:\n\tv260 = v351;\nL_FFFFFFFF:\n\tv261 = v321;\nL_FFFFFFFF:\n\tv270 = v342;\nL_FFFFFFFF:\n\tv276 = v156;\n\tif (v146) goto L_00B1;\n\tthrow System.NullReferenceException;\nL_0049:\n\tv195 = v230.<>9__10_0;\n\tv232 = v230.<>9__10_0 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0065;\nL_0056:\n\tv330 = new System.Action();\n\tSystem.Action::.ctor(v330, v327.<>9, Il2CppMethodInfo);\n\tv345.<>9__10_0 = v330;\nL_FFFFFFFF:\n\tv195 = v330;\nL_0091:\n\tv96 = *([v112 @ X10_v13-8]) == _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface.ILevelProgressService;\n\tif (v96) goto L_00D4;\nL_00BC:\n\tv182 = *([v190 @ X10_v8-8]) == Unco.AdSystem.IAdManager;\nL_FFFFFFFF:\n\tv259 = v143;\nL_FFFFFFFF:\n\tv260 = v351;\nL_FFFFFFFF:\n\tv261 = v321;\nL_FFFFFFFF:\n\tv270 = v342;\nL_FFFFFFFF:\n\tv276 = v205;\n\tif (v182) goto L_00EF;\nL_00EF:\n\tv288 = Unco.AdSystem.IAdManager::DisplayRewarded(v210, this.m_category, v195, v261, v270, v260, v259, v276);\n\treturn;\n")]
		private void OnClicked()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardedButton::OnClicked");
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x3C66958", Offset = "0x3C66958", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.m_hoveringTextController, 0);\n\tv64 = ~v55;\n\tv65 = ~v64;\n\tif (v65) goto L_003A;\n\tgoto L_0040;\nL_003A:\n\t_game.CoreGameKit.CoreSerivces.HoveringTextSystem.HoveringTextController::Display(this.m_hoveringTextController, this.m_notReadyText, \"default\");\nL_0040:\n\tUnco.UncoButtonSystem.UncoButton::SetInteractable(this.m_button, 1);\n\tv106 = this._onAdFailed == 0;\n\tif (v106) goto L_0056;\n\tSystem.Action::Invoke(this._onAdFailed);\n\treturn;\nL_0056:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnAdNotReady()
		{
			if (m_hoveringTextController != null)
			{
				m_hoveringTextController.Display(m_notReadyText);
			}
			m_button.SetInteractable(isInteractable: true);
			if (_onAdFailed != null)
			{
				_onAdFailed();
			}
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x3C66A5C", Offset = "0x3C66A5C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.UncoButtonSystem.UncoButton::SetInteractable(this.m_button, 1);\n\tv33 = this._onAdFailed == 0;\n\tif (v33) goto L_001E;\n\tSystem.Action::Invoke(this._onAdFailed);\n\treturn;\nL_001E:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnAdFailed()
		{
			m_button.SetInteractable(isInteractable: true);
			if (_onAdFailed != null)
			{
				_onAdFailed();
			}
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x3C66AB0", Offset = "0x3C66AB0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.UncoButtonSystem.UncoButton::SetInteractable(this.m_button, 1);\n\tv33 = this._onAdSuccess == 0;\n\tif (v33) goto L_001E;\n\tSystem.Action::Invoke(this._onAdSuccess);\n\treturn;\nL_001E:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnAdSuccess()
		{
			m_button.SetInteractable(isInteractable: true);
			if (_onAdSuccess != null)
			{
				_onAdSuccess();
			}
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x3C66B04", Offset = "0x3C66B04", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.m_notReadyText = \"Ad is not ready\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RewardedButton()
		{
			m_notReadyText = "Ad is not ready";
		}
	}
}
