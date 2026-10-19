using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.TextViewSystem;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.CoreSerivces.FeatureUnlock
{
	[Token(Token = "0x200061B")]
	public class WinUiFeatureDataSetter : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200061C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001526")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001527")]
			public static Action<WinUiFeatureDataSetter, float> _003C_003E9__18_0;

			[Token(Token = "0x4001528")]
			public static Action<WinUiFeatureDataSetter> _003C_003E9__18_1;

			[Token(Token = "0x6001A29")]
			[Address(RVA = "0x3D51870", Offset = "0x3D51870", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001A2A")]
			[Address(RVA = "0x3D518D4", Offset = "0x3D518D4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CInject_003Eb__18_0(WinUiFeatureDataSetter t, float currentProgress)
			{
				if (!(t == null))
				{
					t.m_featureIconImage.fillAmount = currentProgress;
					float num = currentProgress * 100f;
					float num2 = ((num != 1f / 0f) ? num : -0f);
					float num3 = num2;
					int num4 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					string text = $"{arg}";
					t.m_featureProgressText.SetText(text);
				}
			}

			internal void _003CInject_003Eb__18_1(WinUiFeatureDataSetter t)
			{
				GameObject gameObject = t.m_featureProgressText.gameObject;
				gameObject.SetActive(value: false);
				TextView textView = default(TextView);
				textView.SetText("New Feature\n<size=120%>UNLOCKED!");
			}
		}

		[SerializeField]
		[Token(Token = "0x4001514")]
		[FieldOffset(Offset = "0x20")]
		private Image m_featureIconImage;

		[SerializeField]
		[Token(Token = "0x4001515")]
		[FieldOffset(Offset = "0x28")]
		private Image m_featureShadowImage;

		[SerializeField]
		[Token(Token = "0x4001516")]
		[FieldOffset(Offset = "0x30")]
		private Image m_featureUnlockedCompleteImage;

		[SerializeField]
		[Token(Token = "0x4001517")]
		[FieldOffset(Offset = "0x38")]
		private Image m_featureLockedCompleteImage;

		[SerializeField]
		[Token(Token = "0x4001518")]
		[FieldOffset(Offset = "0x40")]
		private GameObject m_hasFeatureGroup;

		[SerializeField]
		[Token(Token = "0x4001519")]
		[FieldOffset(Offset = "0x48")]
		private GameObject m_noFeatureIconGroup;

		[SerializeField]
		[Token(Token = "0x400151A")]
		[FieldOffset(Offset = "0x50")]
		private TextView m_unlockedText;

		[SerializeField]
		[Token(Token = "0x400151B")]
		[FieldOffset(Offset = "0x58")]
		private FormattedTextView m_featureProgressText;

		[SerializeField]
		[Token(Token = "0x400151C")]
		[FieldOffset(Offset = "0x60")]
		private TextView m_featureDescriptionText;

		[Header("Animation Settings")]
		[SerializeField]
		[Token(Token = "0x400151D")]
		[FieldOffset(Offset = "0x68")]
		private float m_fillAnimationDuration;

		[SerializeField]
		[Token(Token = "0x400151E")]
		[FieldOffset(Offset = "0x6C")]
		private Ease m_fillAnimationEase;

		[SerializeField]
		[Token(Token = "0x400151F")]
		[FieldOffset(Offset = "0x70")]
		private float m_shakeStrength;

		[SerializeField]
		[Token(Token = "0x4001520")]
		[FieldOffset(Offset = "0x74")]
		private float m_shakeDuration;

		[SerializeField]
		[Token(Token = "0x4001521")]
		[FieldOffset(Offset = "0x78")]
		private float m_scaleAmount;

		[SerializeField]
		[Token(Token = "0x4001522")]
		[FieldOffset(Offset = "0x7C")]
		private float m_scaleDuration;

		[SerializeField]
		[Token(Token = "0x4001523")]
		[FieldOffset(Offset = "0x80")]
		private Vector3 m_disabledLootScale;

		[SerializeField]
		[Token(Token = "0x4001524")]
		[FieldOffset(Offset = "0x8C")]
		private Vector3 m_disabledLootPos;

		[SerializeField]
		[Token(Token = "0x4001525")]
		[FieldOffset(Offset = "0x98")]
		private Transform m_featureGroup;

		[Inject(false)]
		[Token(Token = "0x6001A27")]
		[Address(RVA = "0x3D5120C", Offset = "0x3D5120C", Length = "0x644")]
		private void Inject(IFeatureUnlockService service, ILevelProgressService progressService)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinUiFeatureDataSetter::Inject");
		}

		[Token(Token = "0x6001A28")]
		[Address(RVA = "0x3D51850", Offset = "0x3D51850", Length = "0x20")]
		public WinUiFeatureDataSetter()
		{
			m_fillAnimationDuration = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [93080C0]");
			m_shakeStrength = 0f;
		}
	}
}
