using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unco.UncoButtonSystem
{
	[RequireComponent(typeof(Button))]
	[Token(Token = "0x2000008")]
	public class ButtonAnimator : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
	{
		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x20")]
		public bool CustomScale;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x21")]
		public bool IsActive;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x24")]
		private float _downScale;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x28")]
		private float _upScale;

		[Token(Token = "0x400003D")]
		private const float AnimDuration = 0.4f;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x30")]
		private Transform _buttonTransform;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x38")]
		private Button _button;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x40")]
		private Vector3 _buttonScale;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x4C")]
		private bool _activated;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x50")]
		private float _baseScale;

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81BEF0C", Offset = "0x81BEF0C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv55 = UnityEngine.Component::get_transform(this._button);\n\tthis._buttonTransform = v55;\n\tv88 = UnityEngine.Transform::get_localScale(this._buttonTransform);\n\tthis._buttonScale.x = v88;\n\tthis._buttonScale.y = v88.y;\n\tthis._buttonScale.z = v88.z;\n\tv58 = this.CustomScale != 1;\n\tif (v58) goto L_0052;\n\tv145 = UnityEngine.Transform::get_localScale(this._buttonTransform);\n\tthis._baseScale = v145;\n\tv143 = this._downScale * v147;\n\tthis._downScale = v143;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis._button = v46;\nL_0052:\n\treturn;\n")]
		private void Awake()
		{
			Button component = GetComponent<Button>();
			_button = component;
			Transform buttonTransform = _button.transform;
			_buttonTransform = buttonTransform;
			Vector3 localScale = _buttonTransform.localScale;
			_buttonScale.x = localScale.x;
			_buttonScale.y = localScale.y;
			_buttonScale.z = localScale.z;
			if (CustomScale)
			{
				_baseScale = _buttonTransform.localScale.x;
				object obj = default(object);
				float downScale = _downScale * (float)obj;
				_downScale = downScale;
			}
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81BEFE4", Offset = "0x81BEFE4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv115 = UnityEngine.Behaviour::get_enabled(this._button);\n\tv118 = ~v115;\n\tif (v118) goto L_0067;\n\tv133 = this._button;\n\tv167 = v133.interactable == 0;\n\tv117 = ~v167;\n\tif (v117) goto L_0041;\n\tv85 = this._activated != 1;\n\tif (v85) goto L_0067;\nL_0041:\n\tv80 = this._upScale * this._buttonScale;\n\tv78 = this._upScale * this._buttonScale.y;\n\tv82 = this._upScale * this._buttonScale.z;\n\t// 78 MakeStruct v61 @ AGG81BF0A4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v80 @ V0_v3 (System.Single), v78 @ V1_v3 (System.Single), v82 @ V2_v3 (System.Single)\n\tv180 = PrimeTween.Tween::Scale(this._buttonTransform, v61, 0.1f, 0xF, 1, 0, 0f, 0f, 0);\n\tv58 = v180;\n\tv180.tween = 0xF;\n\tv184 = new System.Action();\n\tSystem.Action::.ctor(v184, this, Il2CppMethodInfo);\n\tv114 = PrimeTween.Tween::OnComplete(&v58 @ stack_-30_v2 (PrimeTween.Tween), v184, 1);\nL_0067:\n\treturn;\nL_001F:\n\tv49 = this.IsActive != 1;\n\tif (v49) goto L_0067;\n")]
		public void OnPointerUp(PointerEventData eventData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ButtonAnimator::OnPointerUp");
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81BF100", Offset = "0x81BF100", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = PrimeTween.Tween::StopAll(this._buttonTransform);\n\treturn;\n")]
		private void OnDisable()
		{
			int num = Tween.StopAll(_buttonTransform);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81BF10C", Offset = "0x81BF10C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.IsActive != 1;\n\tif (v21) goto L_0048;\n\tv22 = this._button;\n\tv38 = v22.interactable != 1;\n\tif (v38) goto L_0048;\n\tv28 = UnityEngine.Behaviour::get_enabled(v22);\n\tv36 = ~v28;\n\tif (v36) goto L_0048;\n\tthis._activated = 1;\n\tv100 = this._downScale * this._buttonScale;\n\tv98 = this._downScale * this._buttonScale.y;\n\tv102 = this._downScale * this._buttonScale.z;\n\t// 64 MakeStruct v77 @ AGG81BF1A0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v100 @ V0_v2 (System.Single), v98 @ V1_v2 (System.Single), v102 @ V2_v2 (System.Single)\n\tv106 = PrimeTween.Tween::Scale(this._buttonTransform, v77, 0.2f, 0xE, 1, 0, 0f, 0f, 0);\n\treturn;\nL_0048:\n\treturn;\n")]
		public void OnPointerDown(PointerEventData eventData)
		{
			if (IsActive)
			{
				Button button = _button;
				if (button.interactable && button.enabled)
				{
					_activated = true;
					float x = _downScale * _buttonScale.x;
					float y = _downScale * _buttonScale.y;
					float z = _downScale * _buttonScale.z;
					Vector3 endValue = default(Vector3);
					endValue.x = x;
					endValue.y = y;
					endValue.z = z;
					Tween tween = Tween.Scale(_buttonTransform, endValue, 0.2f, Ease.InQuint);
				}
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x81BF1B4", Offset = "0x81BF1B4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._buttonScale.x = scale;\n\tthis._buttonScale.y = scale;\n\tthis._buttonScale.z = scale;\n\treturn;\n")]
		public void SetInitialScale(float scale)
		{
			_buttonScale.x = scale;
			_buttonScale.y = scale;
			_buttonScale.z = scale;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x81BF1C0", Offset = "0x81BF1C0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IsActive = 1;\n\tthis._downScale = 0.009062500654836185d;\n\tthis._baseScale = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ButtonAnimator()
		{
			IsActive = true;
			_downScale = 0.96f;
			_upScale = 1.02f;
			_baseScale = 1f;
		}
	}
}
