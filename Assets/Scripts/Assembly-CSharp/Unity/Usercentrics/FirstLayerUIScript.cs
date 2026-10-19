using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unity.Usercentrics
{
	[Token(Token = "0x200005E")]
	public class FirstLayerUIScript : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x20")]
		private Text Title;

		[SerializeField]
		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x28")]
		private Text Description;

		[SerializeField]
		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x30")]
		private Text FirstLayerNoteResurface;

		[SerializeField]
		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x38")]
		private Button AcceptAllButton;

		[SerializeField]
		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x40")]
		private Button DenyAllButton;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x48")]
		public UnityAction OnFinishCallback;

		[Token(Token = "0x600014B")]
		[Address(RVA = "0x3C6CAB8", Offset = "0x3C6CAB8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002E:\n\tUnityEngine.Debug::Log(\"[USERCENTRICS][DEBUG] start 1st layer script\");\n\tUnity.Usercentrics.FirstLayerUIScript::SetContent(this);\n\tv69 = this.AcceptAllButton;\n\tv79 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v79, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v69.onClick, v79);\n\tv104 = this.DenyAllButton;\n\tv96 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v96, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v104.onClick, v96);\n\treturn;\nL_002A:\n\tgoto L_002E;\n")]
		private void Start()
		{
			Debug.Log("[USERCENTRICS][DEBUG] start 1st layer script");
			SetContent();
			Button acceptAllButton = AcceptAllButton;
			UnityAction call = delegate
			{
				AcceptAll();
			};
			acceptAllButton.onClick.AddListener(call);
			Button denyAllButton = DenyAllButton;
			UnityAction call2 = delegate
			{
				DenyAll();
			};
			denyAllButton.onClick.AddListener(call2);
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0x3C6CBF8", Offset = "0x3C6CBF8", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB2B8000 + 0xA60;\n\tgoto L_0017;\nL_0017:\n\tv70 = Unity.Usercentrics.Singleton`1::get_Instance /* +1 sharing this address */(*([v51 @ X21_v8 (System.Int32)]));\n\tv63 = v70 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0031;\n\tgoto L_0054;\nL_0031:\n\tv76 = Unity.Usercentrics.Usercentrics::GetFirstLayerSettings(v70);\n\tv126 = UnityEngine.UI.Text::set_text(this.Title, v76.title);\n\tv127 = UnityEngine.UI.Text::set_text(this.Description, v76.description);\n\tv90 = UnityEngine.UI.Text::set_text(v90, v76.resurfaceNote);\n\treturn;\nL_0054:\n\tthrow System.NullReferenceException;\n")]
		public void SetContent()
		{
			int num = 187400192 + 2656;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @626D310 (Unity.Usercentrics.Singleton`1::get_Instance, and 1 more at this address)");
			Usercentrics usercentrics = default(Usercentrics);
			if ((object)usercentrics != null)
			{
				FirstLayerSettings firstLayerSettings = usercentrics.GetFirstLayerSettings();
				Title.text = firstLayerSettings.title;
				Description.text = firstLayerSettings.description;
				Text text = default(Text);
				text.text = firstLayerSettings.resurfaceNote;
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0x3C6CCFC", Offset = "0x3C6CCFC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB2B8000 + 0xA60;\n\tgoto L_0017;\nL_0017:\n\tv69 = Unity.Usercentrics.Singleton`1::get_Instance /* +1 sharing this address */(*([v51 @ X21_v10 (System.Int32)]));\n\tUnity.Usercentrics.Usercentrics::AcceptAll(v69);\n\tv82 = this.OnFinishCallback == 0;\n\tif (v82) goto L_0047;\n\tUnityEngine.Events.UnityAction::Invoke(this.OnFinishCallback);\n\treturn;\nL_0047:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AcceptAll()
		{
			int num = 187400192 + 2656;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @626D310 (Unity.Usercentrics.Singleton`1::get_Instance, and 1 more at this address)");
			Usercentrics usercentrics = default(Usercentrics);
			usercentrics.AcceptAll();
			if (OnFinishCallback != null)
			{
				OnFinishCallback();
			}
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0x3C6CDC8", Offset = "0x3C6CDC8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB2B8000 + 0xA60;\n\tgoto L_0017;\nL_0017:\n\tv69 = Unity.Usercentrics.Singleton`1::get_Instance /* +1 sharing this address */(*([v51 @ X21_v10 (System.Int32)]));\n\tUnity.Usercentrics.Usercentrics::DenyAll(v69, 0);\n\tv83 = this.OnFinishCallback == 0;\n\tif (v83) goto L_0048;\n\tUnityEngine.Events.UnityAction::Invoke(this.OnFinishCallback);\n\treturn;\nL_0048:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DenyAll()
		{
			int num = 187400192 + 2656;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @626D310 (Unity.Usercentrics.Singleton`1::get_Instance, and 1 more at this address)");
			Usercentrics usercentrics = default(Usercentrics);
			usercentrics.DenyAll();
			if (OnFinishCallback != null)
			{
				OnFinishCallback();
			}
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0x3C6CE98", Offset = "0x3C6CE98", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public FirstLayerUIScript()
		{
		}
	}
}
