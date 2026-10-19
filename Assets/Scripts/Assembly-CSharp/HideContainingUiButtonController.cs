using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

[Token(Token = "0x2000012")]
public class HideContainingUiButtonController : MonoBehaviour
{
	[SerializeField]
	[Token(Token = "0x4000019")]
	[FieldOffset(Offset = "0x20")]
	private UncoButton m_button;

	[Inject(false)]
	[Token(Token = "0x400001A")]
	[FieldOffset(Offset = "0x28")]
	private UiManager _uiManager;

	[Token(Token = "0x600003E")]
	[Address(RVA = "0x3C61C80", Offset = "0x3C61C80", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis.m_button = v46;\n\treturn;\n")]
	private void Reset()
	{
		UncoButton component = GetComponent<UncoButton>();
		m_button = component;
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0x3C61CE4", Offset = "0x3C61CE4", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tUnco.UncoButtonSystem.UncoButton::AddListener(this.m_button, v49, 1, 1);\n\treturn;\nL_001D:\n\tv49 = new System.Action();\n\tSystem.Action::.ctor(v49, this, Il2CppMethodInfo);\n")]
	private void OnEnable()
	{
		Action clickAction = delegate
		{
			UIController componentInParent = GetComponentInParent<UIController>();
			Type type = componentInParent.GetType();
			_uiManager.Hide(type);
		};
		m_button.AddListener(clickAction);
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x3C61D80", Offset = "0x3C61D80", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
	public HideContainingUiButtonController()
	{
	}
}
