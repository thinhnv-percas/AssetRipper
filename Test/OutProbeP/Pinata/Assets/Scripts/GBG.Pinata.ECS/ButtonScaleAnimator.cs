using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.EventSystems;

[Token(Token = "0x200002B")]
public sealed class ButtonScaleAnimator : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[SerializeField]
	[Token(Token = "0x400009A")]
	[FieldOffset(Offset = "0x18")]
	private float pressDuration;

	[SerializeField]
	[Token(Token = "0x400009B")]
	[FieldOffset(Offset = "0x1C")]
	private float releaseDuration;

	[SerializeField]
	[Token(Token = "0x400009C")]
	[FieldOffset(Offset = "0x20")]
	private Vector3 pressedScale;

	[SerializeField]
	[Token(Token = "0x400009D")]
	[FieldOffset(Offset = "0x2C")]
	private Vector3 initialScale;

	[SerializeField]
	[Token(Token = "0x400009E")]
	[FieldOffset(Offset = "0x38")]
	private TweenerEasingData pressEase;

	[SerializeField]
	[Token(Token = "0x400009F")]
	[FieldOffset(Offset = "0x50")]
	private TweenerEasingData releaseEase;

	[SerializeField]
	[Token(Token = "0x40000A0")]
	[FieldOffset(Offset = "0x68")]
	private Transform target;

	[Token(Token = "0x40000A1")]
	[FieldOffset(Offset = "0x70")]
	private TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;

	[Token(Token = "0x17000001")]
	private Transform Target
	{
		[Token(Token = "0x6000056")]
		[Address(RVA = "0xCBE748", Offset = "0xCBE748", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EADF28]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202370D]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Implicit(this.target);\n\tv57 = v55 == 0;\n\tif (v57) goto L_0034;\n\treturn this.target;\nL_0034:\n\treturnVal2 = UnityEngine.Component::get_transform(this);\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			if ((bool)target)
			{
				return target;
			}
			return base.transform;
		}
	}

	[Token(Token = "0x6000057")]
	[Address(RVA = "0xCBE7D4", Offset = "0xCBE7D4", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Complete(this.tweenerCore);\n\tv13 = ButtonScaleAnimator::get_Target(this);\n\t// 16 MakeStruct v19 @ AGGCBE808_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.pressedScale (UnityEngine.Vector3), this.pressedScale.y (System.Single), this.pressedScale.z (System.Single)\n\tv20 = DG.Tweening.ShortcutExtensions::DOScale(v13, v19, this.pressDuration);\n\tthis.tweenerCore = v20;\n\tv24 = this + 0x38;\n\tgoto L_0029;\nL_0029:\n\tgoto L_0031;\n\tv44 = *([1EE50D0]);\n\tv45 = *([v44 @ X8_v11]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, v25, methodInfo, v48, v49, v50, v51, v52, v14, v15, v16, v17, v53, v54, v55, v56);\n\tv58 = 0 | 1;\n\t*([2023798]) = v58;\nL_0031:\n\tv61 = *([v24 @ X0_v5]) == 0;\n\tif (v61) goto L_003F;\n\tv67 = DG.Tweening.TweenSettingsExtensions::SetEase(v20, *([v24 @ X0_v5+8]));\n\tgoto L_0046;\nL_003F:\n\tv73 = DG.Tweening.TweenSettingsExtensions::SetEase(v20, *([v24 @ X0_v5+10]));\nL_0046:\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnPointerDown(PointerEventData eventData)
	{
		//IL_0083: Expected O, but got I
		//IL_00a2: Expected O, but got I
		tweenerCore.Complete();
		Transform transform = Target;
		Vector3 endValue = default(Vector3);
		endValue.x = pressedScale.x;
		endValue.y = pressedScale.y;
		endValue.z = pressedScale.z;
		TweenerCore<Vector3, Vector3, VectorOptions> t = (tweenerCore = transform.DOScale(endValue, pressDuration));
		object obj = (long)(IntPtr)this + 56L;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X0_v5+8]");
			Tweener tweener = ((Tweener)t).SetEase((AnimationCurve)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X0_v5+10]");
			Tweener tweener2 = ((Tweener)t).SetEase(Ease.Unset);
		}
	}

	[Token(Token = "0x6000058")]
	[Address(RVA = "0xCBE8B0", Offset = "0xCBE8B0", Length = "0x54")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Complete(this.tweenerCore);\n\tv13 = ButtonScaleAnimator::get_Target(this);\n\t// 16 MakeStruct v19 @ AGGCBE8E4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.initialScale (UnityEngine.Vector3), this.initialScale.y (System.Single), this.initialScale.z (System.Single)\n\tv20 = DG.Tweening.ShortcutExtensions::DOScale(v13, v19, this.releaseDuration);\n\tthis.tweenerCore = v20;\n\tv24 = this + 0x50;\n\tv27 = 0xCBE828(v24, v20, methodInfo, v29, v30, v31, v32, v33, this.initialScale, this.initialScale.y, this.initialScale.z, this.releaseDuration, v34, v35, v36, v37);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnPointerUp(PointerEventData eventData)
	{
		//IL_0083: Expected O, but got I
		this.tweenerCore.Complete();
		Transform transform = Target;
		Vector3 endValue = default(Vector3);
		endValue.x = initialScale.x;
		endValue.y = initialScale.y;
		endValue.z = initialScale.z;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOScale(endValue, releaseDuration);
		this.tweenerCore = tweenerCore;
		object obj = (long)(IntPtr)this + 80L;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CBE828 (inside ButtonScaleAnimator::OnPointerDown +0x54)");
	}

	[Token(Token = "0x6000059")]
	[Address(RVA = "0xCBE904", Offset = "0xCBE904", Length = "0xAC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB2628]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202370E]) = v38;\nL_0017:\n\tthis.pressDuration = 0.08f;\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tv57 = UnityEngine.Vector3::get_one();\n\tv64 = UnityEngine.Vector3::op_Multiply(v57, 0.9f);\n\tthis.pressedScale = v64;\n\tthis.pressedScale.y = v64.y;\n\tthis.pressedScale.z = v64.z;\n\tv68 = UnityEngine.Vector3::get_one();\n\tthis.initialScale = v68;\n\tthis.initialScale.y = v68.y;\n\tthis.initialScale.z = v68.z;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ButtonScaleAnimator()
	{
		pressDuration = 0.08f;
		Vector3 one = Vector3.one;
		Vector3 vector = (pressedScale = one * 0.9f);
		pressedScale.y = vector.y;
		pressedScale.z = vector.z;
		Vector3 vector2 = (initialScale = Vector3.one);
		initialScale.y = vector2.y;
		initialScale.z = vector2.z;
	}
}
