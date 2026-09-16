using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

[Token(Token = "0x200000D")]
public class ETFXSceneManager : MonoBehaviour
{
	[Token(Token = "0x4000044")]
	[FieldOffset(Offset = "0x18")]
	public bool GUIHide;

	[Token(Token = "0x4000045")]
	[FieldOffset(Offset = "0x19")]
	public bool GUIHide2;

	[Token(Token = "0x4000046")]
	[FieldOffset(Offset = "0x1A")]
	public bool GUIHide3;

	[Token(Token = "0x6000046")]
	[Address(RVA = "0xA03F78", Offset = "0xA03F78", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EBF240]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C73]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_explosions\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene1()
	{
		SceneManager.LoadScene("etfx_explosions");
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0xA03FC4", Offset = "0xA03FC4", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EDA128]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C74]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_explosions2\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene2()
	{
		SceneManager.LoadScene("etfx_explosions2");
	}

	[Token(Token = "0x6000048")]
	[Address(RVA = "0xA04010", Offset = "0xA04010", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1ECBB80]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C75]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_portals\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene3()
	{
		SceneManager.LoadScene("etfx_portals");
	}

	[Token(Token = "0x6000049")]
	[Address(RVA = "0xA0405C", Offset = "0xA0405C", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EEC648]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C76]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_magic\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene4()
	{
		SceneManager.LoadScene("etfx_magic");
	}

	[Token(Token = "0x600004A")]
	[Address(RVA = "0xA040A8", Offset = "0xA040A8", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EF3538]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C77]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_emojis\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene5()
	{
		SceneManager.LoadScene("etfx_emojis");
	}

	[Token(Token = "0x600004B")]
	[Address(RVA = "0xA040F4", Offset = "0xA040F4", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EA8620]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C78]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_sparkles\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene6()
	{
		SceneManager.LoadScene("etfx_sparkles");
	}

	[Token(Token = "0x600004C")]
	[Address(RVA = "0xA04140", Offset = "0xA04140", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EF1CE0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C79]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_fireworks\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene7()
	{
		SceneManager.LoadScene("etfx_fireworks");
	}

	[Token(Token = "0x600004D")]
	[Address(RVA = "0xA0418C", Offset = "0xA0418C", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1F01568]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C7A]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_powerups\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene8()
	{
		SceneManager.LoadScene("etfx_powerups");
	}

	[Token(Token = "0x600004E")]
	[Address(RVA = "0xA041D8", Offset = "0xA041D8", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1F024C8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C7B]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_swordcombat\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene9()
	{
		SceneManager.LoadScene("etfx_swordcombat");
	}

	[Token(Token = "0x600004F")]
	[Address(RVA = "0xA04224", Offset = "0xA04224", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EF7868]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C7C]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_maindemo\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene10()
	{
		SceneManager.LoadScene("etfx_maindemo");
	}

	[Token(Token = "0x6000050")]
	[Address(RVA = "0xA04270", Offset = "0xA04270", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EFA7A0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C7D]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_combat\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene11()
	{
		SceneManager.LoadScene("etfx_combat");
	}

	[Token(Token = "0x6000051")]
	[Address(RVA = "0xA042BC", Offset = "0xA042BC", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EE5940]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C7E]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_2ddemo\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene12()
	{
		SceneManager.LoadScene("etfx_2ddemo");
	}

	[Token(Token = "0x6000052")]
	[Address(RVA = "0xA04308", Offset = "0xA04308", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EED4E0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C7F]) = v35;\nL_0019:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(\"etfx_missiles\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadScene13()
	{
		SceneManager.LoadScene("etfx_missiles");
	}

	[Token(Token = "0x6000053")]
	[Address(RVA = "0xA04354", Offset = "0xA04354", Length = "0x16C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC0AE8]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C80]) = v38;\nL_0015:\n\tv41 = UnityEngine.Input::GetKeyDown(0x6C);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0032;\n\tv46 = this.GUIHide ^ 1;\n\tthis.GUIHide = v46;\n\tv50 = UnityEngine.GameObject::Find(\"CanvasSceneSelect\");\n\tv56 = UnityEngine.GameObject::GetComponent(v50);\n\tv58 = ~this.GUIHide;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_002F;\nL_002F:\n\tUnityEngine.Behaviour::set_enabled(v56, v54);\nL_0032:\n\tv64 = UnityEngine.Input::GetKeyDown(0x6A);\n\tv67 = v64 == 0;\n\tif (v67) goto L_004F;\n\tv97 = this.GUIHide2 ^ 1;\n\tthis.GUIHide2 = v97;\n\tv78 = UnityEngine.GameObject::Find(\"Canvas\");\n\tv79 = UnityEngine.GameObject::GetComponent(v78);\n\tv105 = ~this.GUIHide2;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_004C;\nL_004C:\n\tUnityEngine.Behaviour::set_enabled(v79, v102);\nL_004F:\n\tv110 = UnityEngine.Input::GetKeyDown(0x68);\n\tv112 = v110 == 0;\n\tif (v112) goto L_006C;\n\tv134 = this.GUIHide3 ^ 1;\n\tthis.GUIHide3 = v134;\n\tv80 = UnityEngine.GameObject::Find(\"ParticleSysDisplayCanvas\");\n\tv81 = UnityEngine.GameObject::GetComponent(v80);\n\tv122 = ~this.GUIHide3;\n\tif (v122) goto L_FFFFFFFF;\n\tgoto L_0074;\nL_006C:\n\treturn;\nL_0074:\n\tUnityEngine.Behaviour::set_enabled(v81, v119);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			int gUIHide = (GUIHide ? 1 : 0) ^ 1;
			GUIHide = (byte)gUIHide != 0;
			GameObject gameObject = GameObject.Find("CanvasSceneSelect");
			Canvas component = gameObject.GetComponent<Canvas>();
			bool flag = (GUIHide ? true : false);
			component.enabled = flag;
		}
		if (Input.GetKeyDown(KeyCode.J))
		{
			int gUIHide2 = (GUIHide2 ? 1 : 0) ^ 1;
			GUIHide2 = (byte)gUIHide2 != 0;
			GameObject gameObject2 = GameObject.Find("Canvas");
			Canvas component2 = gameObject2.GetComponent<Canvas>();
			bool flag2 = (GUIHide2 ? true : false);
			component2.enabled = flag2;
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			int gUIHide3 = (GUIHide3 ? 1 : 0) ^ 1;
			GUIHide3 = (byte)gUIHide3 != 0;
			GameObject gameObject3 = GameObject.Find("ParticleSysDisplayCanvas");
			Canvas component3 = gameObject3.GetComponent<Canvas>();
			bool flag3 = (GUIHide3 ? true : false);
			component3.enabled = flag3;
		}
	}

	[Token(Token = "0x6000054")]
	[Address(RVA = "0xA044C0", Offset = "0xA044C0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ETFXSceneManager()
	{
	}
}
