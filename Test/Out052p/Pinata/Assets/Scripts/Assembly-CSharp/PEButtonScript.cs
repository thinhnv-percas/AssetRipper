using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Token(Token = "0x2000009")]
public class PEButtonScript : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	[Token(Token = "0x4000038")]
	[FieldOffset(Offset = "0x18")]
	private Button myButton;

	[Token(Token = "0x4000039")]
	[FieldOffset(Offset = "0x20")]
	public ButtonTypes ButtonType;

	[Token(Token = "0x6000031")]
	[Address(RVA = "0x98F5A4", Offset = "0x98F5A4", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDC730]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202170D]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tv46 = UnityEngine.GameObject::GetComponent(v41);\n\tthis.myButton = v46;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		GameObject gameObject = base.gameObject;
		Button component = gameObject.GetComponent<Button>();
		myButton = component;
	}

	[Token(Token = "0x6000032")]
	[Address(RVA = "0x98F60C", Offset = "0x98F60C", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F04F58]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, eventData, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202170E]) = v38;\nL_0017:\n\tv43 = v42.GlobalAccess;\n\tv43.MouseOverButton = 1;\n\tUICanvasManager::UpdateToolTip(v46.GlobalAccess, this.ButtonType);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnPointerEnter(PointerEventData eventData)
	{
		UICanvasManager globalAccess = UICanvasManager.GlobalAccess;
		globalAccess.MouseOverButton = true;
		UICanvasManager.GlobalAccess.UpdateToolTip(ButtonType);
	}

	[Token(Token = "0x6000033")]
	[Address(RVA = "0x98F688", Offset = "0x98F688", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1F06248]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, eventData, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202170F]) = v35;\nL_0015:\n\tv40 = v39.GlobalAccess;\n\tv40.MouseOverButton = 0;\n\tUICanvasManager::ClearToolTip(v42.GlobalAccess);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnPointerExit(PointerEventData eventData)
	{
		UICanvasManager globalAccess = UICanvasManager.GlobalAccess;
		globalAccess.MouseOverButton = false;
		UICanvasManager.GlobalAccess.ClearToolTip();
	}

	[Token(Token = "0x6000034")]
	[Address(RVA = "0x98F6F8", Offset = "0x98F6F8", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = *([1F0A458]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021710]) = v38;\nL_0021:\n\tUICanvasManager::UIButtonClick(v42.GlobalAccess, this.ButtonType);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnButtonClicked()
	{
		UICanvasManager.GlobalAccess.UIButtonClick(ButtonType);
	}

	[Token(Token = "0x6000035")]
	[Address(RVA = "0x98F75C", Offset = "0x98F75C", Length = "0x1008")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\tHutongGames.PlayMaker.Actions.SetEventTarget::Reset(X0, X1);\n\treturn;\n\tX8 = *([X8]);\n\tX0 = 0x98B008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x982008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x984008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X9]);\n\tX0 = 0x98D008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1016 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PEButtonScript()
	{
	}
}
