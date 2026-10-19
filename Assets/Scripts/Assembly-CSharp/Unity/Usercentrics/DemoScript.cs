using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unity.Usercentrics
{
	[Token(Token = "0x200005B")]
	public class DemoScript : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200005C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000E5")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000E6")]
			public static UnityAction<string> _003C_003E9__9_1;

			[Token(Token = "0x40000E7")]
			public static UnityAction<AuthorizationStatus> _003C_003E9__10_0;

			[Token(Token = "0x6000145")]
			[Address(RVA = "0x3C6CA34", Offset = "0x3C6CA34", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unity.Usercentrics.DemoScript+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000146")]
			[Address(RVA = "0x3C6CA98", Offset = "0x3C6CA98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CInitAndShowConsentManagerIfNeeded_003Eb__9_1(string errorMessage)
			{
			}

			internal void _003CShowAtt_003Eb__10_0(AuthorizationStatus status)
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x20")]
		private Button ShowFirstLayerButton;

		[SerializeField]
		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x28")]
		private Button ShowSecondLayerButton;

		[SerializeField]
		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x30")]
		private Button ShowAttButton;

		[SerializeField]
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x38")]
		private Button GetAttStatusButton;

		[SerializeField]
		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x40")]
		private Button ShowCustomizedFirstLayerButton;

		[SerializeField]
		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x48")]
		private Canvas FirstLayerUI;

		[SerializeField]
		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x50")]
		private Button ShowUnityUIButton;

		[Token(Token = "0x6000127")]
		[Address(RVA = "0x3C6AF8C", Offset = "0x3C6AF8C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnity.Usercentrics.DemoScript::InitAndShowConsentManagerIfNeeded(this);\n\treturn;\n")]
		private void Awake()
		{
			InitAndShowConsentManagerIfNeeded();
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x3C6B124", Offset = "0x3C6B124", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv58 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v58, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v47.onClick, v58);\n\tv139 = this.ShowSecondLayerButton;\n\tv113 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v113, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v139.onClick, v113);\n\tv140 = this.ShowAttButton;\n\tv115 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v115, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v140.onClick, v115);\n\tv141 = this.GetAttStatusButton;\n\tv117 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v117, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v141.onClick, v117);\n\tv142 = this.ShowCustomizedFirstLayerButton;\n\tv119 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v119, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v142.onClick, v119);\n\tv143 = this.ShowUnityUIButton;\n\tv121 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v121, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v143.onClick, v121);\n\tv211 = UnityEngine.Component::GetComponent(this.FirstLayerUI);\n\tv123 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v123, this, Il2CppMethodInfo);\n\tv211.OnFinishCallback = v123;\n\treturn;\nL_002E:\n\tv47 = this.ShowFirstLayerButton;\n")]
		private void Start()
		{
			Button showFirstLayerButton = ShowFirstLayerButton;
			UnityAction call = delegate
			{
				ShowFirstLayer();
			};
			showFirstLayerButton.onClick.AddListener(call);
			Button showSecondLayerButton = ShowSecondLayerButton;
			UnityAction call2 = delegate
			{
				ShowSecondLayer();
			};
			showSecondLayerButton.onClick.AddListener(call2);
			Button showAttButton = ShowAttButton;
			UnityAction call3 = delegate
			{
				ShowAtt();
			};
			showAttButton.onClick.AddListener(call3);
			Button getAttStatusButton = GetAttStatusButton;
			UnityAction call4 = delegate
			{
				GetAttStatus();
			};
			getAttStatusButton.onClick.AddListener(call4);
			Button showCustomizedFirstLayerButton = ShowCustomizedFirstLayerButton;
			UnityAction call5 = delegate
			{
				ShowCustomizedFirstLayer();
			};
			showCustomizedFirstLayerButton.onClick.AddListener(call5);
			Button showUnityUIButton = ShowUnityUIButton;
			UnityAction call6 = delegate
			{
				ShowCustomFirstLayer();
			};
			showUnityUIButton.onClick.AddListener(call6);
			FirstLayerUIScript component = FirstLayerUI.GetComponent<FirstLayerUIScript>();
			UnityAction onFinishCallback = delegate
			{
				HideCustomFirstLayer();
			};
			component.OnFinishCallback = onFinishCallback;
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0x3C6AF90", Offset = "0x3C6AF90", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\nL_0039:\n\tv67 = Unity.Usercentrics.Singleton`1<Unity.Usercentrics.Usercentrics>::get_Instance();\n\tv73 = new UnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsReadyStatus>();\n\tUnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsReadyStatus>::.ctor(v73, this, Il2CppMethodInfo);\n\tgoto L_0047;\nL_0047:\n\tv129 = v90.<>9__9_1;\n\tv92 = v90.<>9__9_1 == 0;\n\tif (v92) goto L_0065;\nL_0059:\n\tUnity.Usercentrics.Usercentrics::Initialize(v67, v73, v129);\n\treturn;\nL_0065:\n\tgoto L_006D;\n\tv182 = v67 == 0;\n\tv126 = ~v182;\n\tv129 = v160;\n\tif (v126) goto L_0059;\n\tthrow System.NullReferenceException;\nL_0036:\n\tgoto L_0039;\nL_006D:\n\tv160 = new UnityEngine.Events.UnityAction`1<System.String>();\n\tUnityEngine.Events.UnityAction`1<System.String>::.ctor(v160, v155.<>9, Il2CppMethodInfo);\n\tv180.<>9__9_1 = v160;\n")]
		private void InitAndShowConsentManagerIfNeeded()
		{
			Usercentrics instance = Singleton<Usercentrics>.Instance;
			UnityAction<UsercentricsReadyStatus> initializeCallback = delegate(UsercentricsReadyStatus status)
			{
				if (status.shouldCollectConsent)
				{
					ShowFirstLayer();
				}
				else
				{
					UpdateServices(status.consents);
				}
			};
			UnityAction<string> initializeErrorCallback = _003C_003Ec._003C_003E9__9_1;
			if (_003C_003Ec._003C_003E9__9_1 == null)
			{
				UnityAction<string> unityAction = (_003C_003Ec._003C_003E9__9_1 = delegate
				{
				});
				bool flag = (object)instance == null;
				bool flag2 = !flag;
				initializeErrorCallback = unityAction;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			instance.Initialize(initializeCallback, initializeErrorCallback);
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0x3C6B3C4", Offset = "0x3C6B3C4", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_002A:\n\tv55 = Unity.Usercentrics.Singleton`1<Unity.Usercentrics.AppTrackingTransparency>::get_Instance();\n\tv121 = v55;\n\tgoto L_0031;\nL_0031:\n\tv124 = v77.<>9__10_0;\n\tv79 = v77.<>9__10_0 == 0;\n\tif (v79) goto L_0055;\nL_0040:\n\tUnity.Usercentrics.AppTrackingTransparency::PromptForAppTrackingTransparency(v121, v124);\n\treturn;\nL_0055:\n\tgoto L_005D;\n\tv173 = v55 == 0;\n\tv120 = ~v173;\n\tv121 = v55;\n\tv124 = v153;\n\tif (v120) goto L_0040;\n\tthrow System.NullReferenceException;\nL_0028:\n\tgoto L_002A;\nL_005D:\n\tv153 = new UnityEngine.Events.UnityAction`1<Unity.Usercentrics.AuthorizationStatus>();\n\tUnityEngine.Events.UnityAction`1<Unity.Usercentrics.AuthorizationStatus>::.ctor(v153, v148.<>9, Il2CppMethodInfo);\n\tv171.<>9__10_0 = v153;\n")]
		private void ShowAtt()
		{
			AppTrackingTransparency instance = Singleton<AppTrackingTransparency>.Instance;
			AppTrackingTransparency appTrackingTransparency = instance;
			UnityAction<AuthorizationStatus> attCallback = _003C_003Ec._003C_003E9__10_0;
			if (_003C_003Ec._003C_003E9__10_0 == null)
			{
				UnityAction<AuthorizationStatus> unityAction = (_003C_003Ec._003C_003E9__10_0 = delegate
				{
				});
				bool flag = (object)instance == null;
				bool flag2 = !flag;
				appTrackingTransparency = instance;
				attCallback = unityAction;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			appTrackingTransparency.PromptForAppTrackingTransparency(attCallback);
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0x3C6B51C", Offset = "0x3C6B51C", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv49.attStatus = 2;\n\tgoto L_0044;\nL_0044:\n\tv100 = Unity.Usercentrics.Singleton`1<Unity.Usercentrics.AppTrackingTransparency>::get_Instance();\n\tv87 = new UnityEngine.Events.UnityAction`1<Unity.Usercentrics.AuthorizationStatus>();\n\tUnityEngine.Events.UnityAction`1<Unity.Usercentrics.AuthorizationStatus>::.ctor(v87, v49, Il2CppMethodInfo);\n\tUnity.Usercentrics.AppTrackingTransparency::GetAuthorizationStatus(v100, v87);\n\tv116 = Unity.Usercentrics.AuthorizationStatus;\n\tv162 = System.Enum::ToString(&v116 @ stack_-58_v1 (Il2CppClass<Unity.Usercentrics.AuthorizationStatus>));\n\tv132 = System.String::Concat(\"[USERCENTRICS][DEBUG] ATT status callback: \", v162);\n\tgoto L_0070;\nL_002D:\n\tv49 = new Unity.Usercentrics.DemoScript+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v49);\nL_0070:\n\tUnityEngine.Debug::Log(v132);\n\treturn;\n")]
		private void GetAttStatus()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoScript::GetAttStatus");
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x3C6B6CC", Offset = "0x3C6B6CC", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002E:\n\tv65 = Unity.Usercentrics.Singleton`1<Unity.Usercentrics.Usercentrics>::get_Instance();\n\tv71 = new UnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsConsentUserResponse>();\n\tUnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsConsentUserResponse>::.ctor(v71, this, Il2CppMethodInfo);\n\tv78 = v65 == 0;\n\tif (v78) goto L_0047;\n\tUnity.Usercentrics.Usercentrics::ShowFirstLayer(v65, v71);\n\treturn;\nL_0047:\n\tthrow v71;\nL_002B:\n\tgoto L_002E;\n")]
		private void ShowFirstLayer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoScript::ShowFirstLayer");
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0x3C6B7A8", Offset = "0x3C6B7A8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002E:\n\tv65 = Unity.Usercentrics.Singleton`1<Unity.Usercentrics.Usercentrics>::get_Instance();\n\tv71 = Unity.Usercentrics.DemoScript::GetBannerSettingsCustom(this);\n\tv76 = new UnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsConsentUserResponse>();\n\tUnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsConsentUserResponse>::.ctor(v76, this, Il2CppMethodInfo);\n\tv81 = v65 == 0;\n\tif (v81) goto L_004B;\n\tUnity.Usercentrics.Usercentrics::ShowFirstLayer(v65, v71, v76);\n\treturn;\nL_004B:\n\tthrow v76;\nL_002B:\n\tgoto L_002E;\n")]
		private void ShowCustomizedFirstLayer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoScript::ShowCustomizedFirstLayer");
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x3C6B95C", Offset = "0x3C6B95C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv97 = new Unity.Usercentrics.SecondLayerStyleSettings();\n\tUnity.Usercentrics.SecondLayerStyleSettings::.ctor(v97, 1);\n\tv102 = new Unity.Usercentrics.BannerSettings();\n\tUnity.Usercentrics.BannerSettings::.ctor(v102, v72, v94, v97, \"\");\n\treturn v102;\nL_002A:\n\tgoto L_0037;\nL_0037:\n\tv72 = new Unity.Usercentrics.GeneralStyleSettings();\n\tUnity.Usercentrics.GeneralStyleSettings::.ctor(v72, 1, \"#f51d7e\", 1, \"\", \"\", \"\", \"\", \"\", \"\", 0, \"\", 0);\n\tv94 = Unity.Usercentrics.DemoScript::GetFirstLayerStyleSettings(v72);\n")]
		private BannerSettings GetBannerSettings()
		{
			GeneralStyleSettings generalStyleSettings = new GeneralStyleSettings(androidDisableSystemBackButton: true, "#f51d7e");
			FirstLayerStyleSettings firstLayerStyleSettings = ((DemoScript)(object)generalStyleSettings).GetFirstLayerStyleSettings();
			SecondLayerStyleSettings secondLayerStyleSettings = new SecondLayerStyleSettings(showCloseButton: true);
			return new BannerSettings(generalStyleSettings, firstLayerStyleSettings, secondLayerStyleSettings);
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0x3C6B894", Offset = "0x3C6B894", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tUnity.Usercentrics.SecondLayerStyleSettings::.ctor(v62, 1);\n\tv67 = new Unity.Usercentrics.BannerSettings();\n\tUnity.Usercentrics.BannerSettings::.ctor(v67, v52, v57, v62, \"\");\n\treturn v67;\nL_0021:\n\tv52 = Unity.Usercentrics.DemoScript::GetGeneralStyleSettingsCustom(v47);\n\tv57 = Unity.Usercentrics.DemoScript::GetFirstLayerStyleSettings(v52);\n\tv62 = new Unity.Usercentrics.SecondLayerStyleSettings();\n")]
		private BannerSettings GetBannerSettingsCustom()
		{
			GeneralStyleSettings generalStyleSettingsCustom = GetGeneralStyleSettingsCustom();
			FirstLayerStyleSettings firstLayerStyleSettings = ((DemoScript)(object)generalStyleSettingsCustom).GetFirstLayerStyleSettings();
			SecondLayerStyleSettings secondLayerStyleSettings = new SecondLayerStyleSettings(showCloseButton: true);
			return new BannerSettings(generalStyleSettingsCustom, firstLayerStyleSettings, secondLayerStyleSettings);
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x3C6BAA8", Offset = "0x3C6BAA8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tv49 = new Unity.Usercentrics.GeneralStyleSettings();\n\tUnity.Usercentrics.GeneralStyleSettings::.ctor(v49, 1, \"#f51d7e\", 1, \"\", \"\", \"\", \"\", \"\", \"\", 0, \"\", 0);\n\treturn v49;\n")]
		private GeneralStyleSettings GetGeneralStyleSettings()
		{
			return new GeneralStyleSettings(androidDisableSystemBackButton: true, "#f51d7e");
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x3C6BE9C", Offset = "0x3C6BE9C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\nL_0038:\n\tv65 = new Unity.Usercentrics.GeneralStyleSettings();\n\tUnity.Usercentrics.GeneralStyleSettings::.ctor(v65, 1, \"#af7ac5\", 1, \"#ffffff\", \"#001d3b\", \"#1f5791\", \"#00d0fc\", \"#ffffff\", \"#ffffff\", 0, \"\", 0);\n\treturn v65;\n")]
		private GeneralStyleSettings GetGeneralStyleSettingsCustom()
		{
			return new GeneralStyleSettings(androidDisableSystemBackButton: true, "#af7ac5", androidWindowFullscreen: true, "#ffffff", "#001d3b", "#1f5791", "#00d0fc", "#ffffff", "#ffffff");
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0x3C6BB60", Offset = "0x3C6BB60", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004E;\n\tv87 = new Unity.Usercentrics.ButtonSettings();\n\tUnity.Usercentrics.ButtonSettings::.ctor(v87, 2, 10f, \"#001d3b\", \"#00d0fc\", 12f, 0);\n\tgoto L_0085;\nL_0085:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::Add(v77, v87);\n\tv164 = new Unity.Usercentrics.ButtonSettings();\n\tUnity.Usercentrics.ButtonSettings::.ctor(v164, 0, 10f, \"#001d3b\", \"#00d0fc\", 12f, 0);\n\tgoto L_00BE;\nL_00BE:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::Add(v77, v164);\n\tv312 = Unity.Usercentrics.ButtonLayout::Row(v77);\n\tv315 = new Unity.Usercentrics.TitleSettings();\n\tUnity.Usercentrics.TitleSettings::.ctor(v315, 2, 24f, \"#FFFFFF\");\n\tv322 = new Unity.Usercentrics.MessageSettings();\n\tUnity.Usercentrics.MessageSettings::.ctor(v322, 10f, 1, \"#e8daef\", \"#00d0fc\", 1);\n\tv331 = new Unity.Usercentrics.FirstLayerStyleSettings();\n\tUnity.Usercentrics.FirstLayerStyleSettings::.ctor(v331, 4, v71, v315, v322, v312, \"#001d3b\", 30f, \"#350aab\", 0.5f);\n\treturn v331;\nL_004E:\n\tv71 = Unity.Usercentrics.HeaderImageSettings::Custom(\"https://drive.google.com/uc?export=download&id=1Cd6o0FBqsGVb3zZW8KRSUOmFAcCAvZ9o\", 2, 100f);\n\tv77 = new System.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>();\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::.ctor(v77);\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FirstLayerStyleSettings GetFirstLayerStyleSettings()
		{
			HeaderImageSettings headerImage = HeaderImageSettings.Custom("https://drive.google.com/uc?export=download&id=1Cd6o0FBqsGVb3zZW8KRSUOmFAcCAvZ9o", SectionAlignment.Center, 100f);
			List<ButtonSettings> list = new List<ButtonSettings>();
			ButtonSettings item = new ButtonSettings(ButtonType.More, 10f, "#001d3b", "#00d0fc", 12f);
			list.Add(item);
			ButtonSettings item2 = new ButtonSettings(default(ButtonType), 10f, "#001d3b", "#00d0fc", 12f);
			list.Add(item2);
			ButtonLayout buttonLayout = ButtonLayout.Row(list);
			TitleSettings title = new TitleSettings(SectionAlignment.Center, 24f, "#FFFFFF");
			MessageSettings message = new MessageSettings(10f, SectionAlignment.Start, "#e8daef", "#00d0fc", underlineLink: true);
			return new FirstLayerStyleSettings(UsercentricsLayout.PopupCenter, headerImage, title, message, buttonLayout, "#001d3b", 30f, "#350aab", 0.5f);
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0x3C6BFB8", Offset = "0x3C6BFB8", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::.ctor(v79);\n\tv89 = new Unity.Usercentrics.ButtonSettings();\n\tUnity.Usercentrics.ButtonSettings::.ctor(v89, 0, 13f, \"#ffffff\", \"#350aab\", 12f, 1);\n\tgoto L_007C;\nL_007C:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::Add(v79, v89);\n\tv217 = new Unity.Usercentrics.ButtonSettings();\n\tUnity.Usercentrics.ButtonSettings::.ctor(v217, 3, 13f, \"#ffffff\", \"#350aab\", 12f, 1);\n\tgoto L_00AB;\nL_00AB:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::Add(v79, v217);\n\tv218 = new Unity.Usercentrics.ButtonSettingsRow();\n\tUnity.Usercentrics.ButtonSettingsRow::.ctor(v218, v79);\n\tgoto L_00D7;\nL_00D7:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettingsRow>::Add(v69, v218);\n\tv364 = new System.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>();\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::.ctor(v364);\n\tv219 = new Unity.Usercentrics.ButtonSettings();\n\tUnity.Usercentrics.ButtonSettings::.ctor(v219, 2, 13f, \"#ffffff\", \"#350aab\", 12f, 1);\n\tgoto L_010B;\nL_010B:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::Add(v364, v219);\n\tv220 = new Unity.Usercentrics.ButtonSettingsRow();\n\tUnity.Usercentrics.ButtonSettingsRow::.ctor(v220, v364);\n\tgoto L_0135;\nL_0135:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettingsRow>::Add(v69, v220);\n\treturnVal2 = Unity.Usercentrics.ButtonLayout::Grid(v69);\n\treturn returnVal2;\nL_0043:\n\tv69 = new System.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettingsRow>();\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettingsRow>::.ctor(v69);\n\tv79 = new System.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>();\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ButtonLayout GridButtonLayoutExample()
		{
			List<ButtonSettingsRow> list = new List<ButtonSettingsRow>();
			List<ButtonSettings> list2 = new List<ButtonSettings>();
			ButtonSettings item = new ButtonSettings(default(ButtonType), 13f, "#ffffff", "#350aab", 12f, isAllCaps: true);
			list2.Add(item);
			ButtonSettings item2 = new ButtonSettings(ButtonType.Save, 13f, "#ffffff", "#350aab", 12f, isAllCaps: true);
			list2.Add(item2);
			ButtonSettingsRow item3 = new ButtonSettingsRow(list2);
			list.Add(item3);
			List<ButtonSettings> list3 = new List<ButtonSettings>();
			ButtonSettings item4 = new ButtonSettings(ButtonType.More, 13f, "#ffffff", "#350aab", 12f, isAllCaps: true);
			list3.Add(item4);
			ButtonSettingsRow item5 = new ButtonSettingsRow(list3);
			list.Add(item5);
			return ButtonLayout.Grid(list);
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x3C6C3A8", Offset = "0x3C6C3A8", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tUnity.Usercentrics.ButtonSettings::.ctor(v67, 0, 13f, \"#ffffff\", \"#350aab\", 12f, 1);\n\tgoto L_0063;\nL_0063:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::Add(v57, v67);\n\tv143 = new Unity.Usercentrics.ButtonSettings();\n\tUnity.Usercentrics.ButtonSettings::.ctor(v143, 2, 13f, \"#ffffff\", \"#350aab\", 12f, 1);\n\tgoto L_0090;\nL_0090:\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::Add(v57, v143);\n\treturnVal2 = Unity.Usercentrics.ButtonLayout::Column(v57);\n\treturn returnVal2;\nL_002F:\n\tv57 = new System.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>();\n\tSystem.Collections.Generic.List`1<Unity.Usercentrics.ButtonSettings>::.ctor(v57);\n\tv67 = new Unity.Usercentrics.ButtonSettings();\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ButtonLayout ColumnButtonLayoutExample()
		{
			List<ButtonSettings> list = new List<ButtonSettings>();
			ButtonSettings item = new ButtonSettings(default(ButtonType), 13f, "#ffffff", "#350aab", 12f, isAllCaps: true);
			list.Add(item);
			ButtonSettings item2 = new ButtonSettings(ButtonType.More, 13f, "#ffffff", "#350aab", 12f, isAllCaps: true);
			list.Add(item2);
			return ButtonLayout.Column(list);
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x3C6C590", Offset = "0x3C6C590", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002E:\n\tv65 = Unity.Usercentrics.Singleton`1<Unity.Usercentrics.Usercentrics>::get_Instance();\n\tv71 = Unity.Usercentrics.DemoScript::GetBannerSettings(this);\n\tv76 = new UnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsConsentUserResponse>();\n\tUnityEngine.Events.UnityAction`1<Unity.Usercentrics.UsercentricsConsentUserResponse>::.ctor(v76, this, Il2CppMethodInfo);\n\tv81 = v65 == 0;\n\tif (v81) goto L_004B;\n\tUnity.Usercentrics.Usercentrics::ShowSecondLayer(v65, v71, v76);\n\treturn;\nL_004B:\n\tthrow v76;\nL_002B:\n\tgoto L_002E;\n")]
		private void ShowSecondLayer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoScript::ShowSecondLayer");
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x3C6C67C", Offset = "0x3C6C67C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv68 = System.Collections.Generic.List`1<Unity.Usercentrics.UsercentricsServiceConsent>::GetEnumerator(consents);\n\tv91 = v68._list;\n\tv81 = v68.Current;\n\tv120 = System.String::op_Equality(v81.templateId, \"XxxXXxXxX\");\n\tv215 = v120 == 0;\n\tv123 = ~v215;\n\tv69 = 0;\n\tif (v123) goto L_0043;\n\tv121 = System.String::op_Equality(v81.templateId, \"YYyyYyYYY\");\n\tv69 = 0;\n\tgoto L_0043;\nL_005A:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v91 @ stack_-58_v4 (System.Collections.Generic.List`1<Unity.Usercentrics.UsercentricsServiceConsent>));\nL_0064:\n\treturn;\nL_0075:\n\tv138 = Il2CppMethodInfo != 1;\n\tv154 = v107;\n\tif (v138) goto L_0085;\n\tv145 = 0x8BF5BC4(v107, Il2CppMethodInfo, v69, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv163 = 0x8BF5BF4(v145, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v91 @ stack_-58_v4 (System.Collections.Generic.List`1<Unity.Usercentrics.UsercentricsServiceConsent>));\n\tv153 = *([v145 @ X0_v11]) == 0;\n\tif (v153) goto L_0064;\n\tv151 = new System.OutOfMemoryException();\n\tv74 = *([v145 @ X0_v11]);\n\tv154 = v151;\n\treturn;\nL_0025:\n\tv91 = 0;\n\tv50 = consents == 0;\n\tv74 = 0;\n\tif (v50) goto L_0067;\nL_0043:\n\tv127 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v91 @ stack_-58_v4 (System.Collections.Generic.List`1<Unity.Usercentrics.UsercentricsServiceConsent>));\n\tv143 = v127 == 0;\n\tif (v143) goto L_005A;\nL_0085:\n\tv157 = 0x3179AB0(&v74 @ stack_-68_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv165 = 0x8BF0368(v154, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv213 = 0xA1B8(v165, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0067:\n\tv107 = new System.NullReferenceException();\n\tgoto L_0075;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void UpdateServices(List<UsercentricsServiceConsent> consents)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoScript::UpdateServices");
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x3C6C810", Offset = "0x3C6C810", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB304000 + 0xD8;\n\tgoto L_0018;\nL_0018:\n\tUnityEngine.Debug::Log(*([v51 @ X21_v8 (System.Int32)]));\n\tv64 = this.FirstLayerUI == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0035;\n\tgoto L_0043;\nL_0035:\n\tv79 = UnityEngine.Component::get_gameObject(this.FirstLayerUI);\n\tUnityEngine.GameObject::SetActive(v79, 1);\n\treturn;\nL_0043:\n\tthrow System.NullReferenceException;\n")]
		private void ShowCustomFirstLayer()
		{
			//IL_0022: Expected O, but got I4
			int num = 187711488 + 216;
			Debug.Log(num);
			if ((object)FirstLayerUI != null)
			{
				GameObject gameObject = FirstLayerUI.gameObject;
				gameObject.SetActive(value: true);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x3C6C8D8", Offset = "0x3C6C8D8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB304000 + 0xD0;\n\tgoto L_0018;\nL_0018:\n\tUnityEngine.Debug::Log(*([v51 @ X21_v8 (System.Int32)]));\n\tv64 = this.FirstLayerUI == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0035;\n\tgoto L_0043;\nL_0035:\n\tv79 = UnityEngine.Component::get_gameObject(this.FirstLayerUI);\n\tUnityEngine.GameObject::SetActive(v79, 0);\n\treturn;\nL_0043:\n\tthrow System.NullReferenceException;\n")]
		private void HideCustomFirstLayer()
		{
			//IL_0022: Expected O, but got I4
			int num = 187711488 + 208;
			Debug.Log(num);
			if ((object)FirstLayerUI != null)
			{
				GameObject gameObject = FirstLayerUI.gameObject;
				gameObject.SetActive(value: false);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x3C6C9A0", Offset = "0x3C6C9A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DemoScript()
		{
		}
	}
}
