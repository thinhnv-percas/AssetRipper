using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000004")]
public class Countdown : MonoBehaviour
{
	[Token(Token = "0x4000004")]
	[FieldOffset(Offset = "0x20")]
	private float currentTime;

	[Token(Token = "0x4000005")]
	[FieldOffset(Offset = "0x24")]
	private float startingTime;

	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x28")]
	private Button closeButton;

	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x30")]
	private Text countdownText;

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x133C5F8", Offset = "0x133C5F8", Length = "0x120")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv54 = UnityEngine.Debug;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = \"Invalid Prefab\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A36724]) = v42;\nL_0021:\n\tv45 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv52 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv70 = v45.Length < 2;\n\tif (v70) goto L_0063;\n\tv73 = v52.Length <= 1;\n\tif (v73) goto L_0063;\n\tthis.closeButton = v52[1];\n\tthis.countdownText = v45[1];\n\tv102 = UnityEngine.Component::get_gameObject(v52[1]);\n\tUnityEngine.GameObject::SetActive(v102, 0);\n\tthis.currentTime = this.startingTime;\n\treturn;\nL_0063:\n\tgoto L_006D;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v125, v49, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tUnityEngine.Debug::Log(\"Invalid Prefab\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Start()
	{
		Text[] componentsInChildren = GetComponentsInChildren<Text>();
		Button[] componentsInChildren2 = GetComponentsInChildren<Button>();
		if (componentsInChildren.Length >= 2 && componentsInChildren2.Length > 1)
		{
			closeButton = componentsInChildren2[1];
			countdownText = componentsInChildren[1];
			GameObject gameObject = componentsInChildren2[1].gameObject;
			gameObject.SetActive(value: false);
			currentTime = startingTime;
		}
		else
		{
			Debug.Log("Invalid Prefab");
		}
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0x133C718", Offset = "0x133C718", Length = "0x1C8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = UnityEngine.Object;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv48 = \" second(s) remaining\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A36725]) = v40;\nL_001D:\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0022:\n\tv54 = UnityEngine.Object::op_Equality(this.countdownText, 0);\n\tv56 = v54 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_00BE;\n\tgoto L_0031;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v58, v52, v53, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0031:\n\tv137 = UnityEngine.Object::op_Equality(this.closeButton, 0);\n\tv200 = v137 == 0;\n\tv141 = ~v200;\n\tif (v141) goto L_00BE;\n\tv201 = this.currentTime < 0;\n\tv122 = ~v201;\n\tv107 = this.currentTime == 0;\n\tv202 = ~v122;\n\tv82 = v202 | v107;\n\tif (v82) goto L_00BE;\n\tv78 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv146 = this.countdownText;\n\tv125 = this.currentTime - v78;\n\tthis.currentTime = v125;\n\tv83 = v125 <= 0;\n\tif (v83) goto L_0077;\n\tv209 = 0x1854ED0(&v74 @ stack_-28_v3 (System.Single), 0, 0, v24, v25, v26, v27, v28, v125, v30, v31, v32, v33, v34, v35, v36);\n\tv220 = v125 >= 0;\n\tif (v220) goto L_008D;\n\tv242 = v125 != -0.5d;\n\tif (v242) goto L_00A1;\n\tgoto L_0093;\nL_0077:\n\tUnityEngine.Behaviour::set_enabled(this.countdownText, 0);\n\tv138 = UnityEngine.Component::get_gameObject(this.closeButton);\n\tUnityEngine.GameObject::SetActive(v138, 1);\n\tgoto L_00BE;\nL_008D:\n\tv253 = v125 != 0.5d;\n\tif (v253) goto L_00A5;\nL_0093:\n\tv277 = v78 + v264;\n\tv278 = v78 & 1;\n\tv280 = v278 == 0;\n\tv283 = ~v280;\n\tif (v283) goto L_FFFFFFFF;\n\tgoto L_009F;\nL_009F:\n\tgoto L_00AA;\nL_00A1:\n\tv78 = v125 + -0.5f;\n\tv78 = UnityEngine.Mathf::Ceil(v78);\n\tgoto L_00AA;\nL_00A5:\n\tv78 = v125 + 0.5f;\n\tv78 = UnityEngine.Mathf::Floor(v78);\nL_00AA:\n\tv289 = System.Single::ToString(&v78 @ V0_v2 (System.Single));\n\tv229 = System.String::Concat(v289, \" second(s) remaining\");\n\tv144 = *([v146 @ X20_v6 (UnityEngine.Behaviour)]);\n\t*([v144 @ X8_v11 (Il2CppClass<UnityEngine.Behaviour>)+5E8])(v136, this.countdownText, v229, *([v144 @ X8_v11 (Il2CppClass<UnityEngine.Behaviour>)+5F0]), v24, v25, v26, v27, v28, v78, v277, v31, v32, v33, v34, v35, v36);\nL_00BE:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Update()
	{
		//IL_02a2: Expected I, but got O
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected I4, but got Unknown
		if (countdownText == null || closeButton == null)
		{
			return;
		}
		bool flag = currentTime < 0f;
		bool flag2 = !flag;
		bool flag3 = currentTime == 0f;
		bool flag4 = !flag2;
		if (flag4 || flag3)
		{
			return;
		}
		float unscaledDeltaTime = Time.unscaledDeltaTime;
		Behaviour behaviour = countdownText;
		float num = (currentTime -= unscaledDeltaTime);
		if (num > 0f)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			float num3;
			float num4 = default(float);
			float num2;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					unscaledDeltaTime = num + -0.5f;
					unscaledDeltaTime = Mathf.Ceil(unscaledDeltaTime);
					num2 = -0.5f;
					goto IL_0276;
				}
				num3 = -1f;
				unscaledDeltaTime = num4;
			}
			else
			{
				if ((double)num != 0.5)
				{
					unscaledDeltaTime = num + 0.5f;
					unscaledDeltaTime = Mathf.Floor(unscaledDeltaTime);
					num2 = 0.5f;
					goto IL_0276;
				}
				num3 = 1f;
				unscaledDeltaTime = num4;
			}
			num2 = unscaledDeltaTime + num3;
			if ((unscaledDeltaTime & 1) != 0)
			{
				unscaledDeltaTime = num2;
			}
			goto IL_0276;
		}
		countdownText.enabled = false;
		GameObject gameObject = closeButton.gameObject;
		gameObject.SetActive(value: true);
		return;
		IL_0276:
		string text = unscaledDeltaTime.ToString();
		string text2 = text + " second(s) remaining";
		nint num5 = (nint)behaviour;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v144 @ X8_v11 (Il2CppClass<UnityEngine.Behaviour>)+5E8] (should have been resolved before IL gen)");
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0x133C8E0", Offset = "0x133C8E0", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.startingTime = 5f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Countdown()
	{
		startingTime = 5f;
	}
}
