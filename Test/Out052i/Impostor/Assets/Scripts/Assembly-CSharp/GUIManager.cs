using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Storage;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000029")]
public class GUIManager : SingletonMonoDontDestroy<GUIManager>
{
	[Serializable]
	[CompilerGenerated]
	[Token(Token = "0x200002A")]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x40000AC")]
		public static readonly _003C_003Ec _003C_003E9;

		[Token(Token = "0x40000AD")]
		public static Action _003C_003E9__30_0;

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xC01DF4", Offset = "0xC01DF4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GUIManager+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35628]) = v34;\nL_0012:\n\tv36 = new GUIManager+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static _003C_003Ec()
		{
			_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
			_003C_003E9 = _003C_003Ec2;
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0xC01E50", Offset = "0xC01E50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003C_003Ec()
		{
		}

		internal void _003CVibrating_003Eb__30_0()
		{
			Handheld.Vibrate();
		}
	}

	[Token(Token = "0x400009C")]
	[FieldOffset(Offset = "0x28")]
	public GameObject gamePlayPanel;

	[Token(Token = "0x400009D")]
	[FieldOffset(Offset = "0x30")]
	public GameObject menuPanel;

	[Token(Token = "0x400009E")]
	[FieldOffset(Offset = "0x38")]
	public GameObject winningCanvasPanel;

	[Token(Token = "0x400009F")]
	[FieldOffset(Offset = "0x40")]
	public GameObject videoGO;

	[Token(Token = "0x40000A0")]
	[FieldOffset(Offset = "0x48")]
	public GameObject priceGO;

	[Token(Token = "0x40000A1")]
	[FieldOffset(Offset = "0x50")]
	public Text levelText;

	[Token(Token = "0x40000A2")]
	[FieldOffset(Offset = "0x58")]
	public Text rewindText;

	[Token(Token = "0x40000A3")]
	[FieldOffset(Offset = "0x60")]
	public AudioSource sound;

	[Token(Token = "0x40000A4")]
	[FieldOffset(Offset = "0x68")]
	public AudioClip[] soundList;

	[Token(Token = "0x40000A5")]
	[FieldOffset(Offset = "0x70")]
	public List<AudioSource> allSound;

	[Token(Token = "0x40000A6")]
	[FieldOffset(Offset = "0x78")]
	public Image soundImg;

	[Token(Token = "0x40000A7")]
	[FieldOffset(Offset = "0x80")]
	public Sprite[] soundImgSprite;

	[Token(Token = "0x40000A8")]
	[FieldOffset(Offset = "0x88")]
	public Image vibrateImg;

	[Token(Token = "0x40000A9")]
	[FieldOffset(Offset = "0x90")]
	public Sprite[] vibrateImgSprite;

	[Token(Token = "0x40000AA")]
	[FieldOffset(Offset = "0x98")]
	public bool isSoundTurnOn = true;

	[Token(Token = "0x40000AB")]
	[FieldOffset(Offset = "0x99")]
	public bool canVibrate = true;

	[Token(Token = "0x6000107")]
	[Address(RVA = "0xBF99F4", Offset = "0xBF99F4", Length = "0x3BC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv253 = Il2CppMethodInfo;\n\tv254 = \"il2cpp_codegen_initialize_runtime_metadata\"(v253, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv287 = SingletonMonoDontDestroy`1<GameManager>;\n\tv288 = \"il2cpp_codegen_initialize_runtime_metadata\"(v287, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv335 = \"Level \";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v335, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A3561A]) = v48;\nL_0034:\n\tgoto L_0037;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0037:\n\tv65 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv73 = v65.currentLevel;\n\tv73 = v73 + 1;\n\tv80 = System.Int32::ToString(&v73 @ X8_v17 (System.Int32));\n\tv212 = System.String::Concat(\"Level \", v80);\n\tthis = UnityEngine.UI.Text::set_text(this.levelText, v212);\n\tv213 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv342 = GameManager::get_numberRewinds(v213);\n\tv214 = System.Int32::ToString(&v342 @ X0_v48 (System.Int32));\n\tthis = UnityEngine.UI.Text::set_text(this.rewindText, v214);\n\tv446 = ~this.isSoundTurnOn;\n\tif (v446) goto L_00B0;\n\tv243 = this.soundImgSprite;\n\tUnityEngine.UI.Image::set_sprite(this.soundImg, v243[1]);\n\tv561 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(this.allSound);\nL_008C:\n\tv577 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v297 @ stack_-88_v12 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv589 = v577 == 0;\n\tif (v589) goto L_00D5;\n\tv328 = v568 == 0;\n\tif (v328) goto L_0097;\n\tUnityEngine.AudioSource::set_volume(v568, 1f);\n\tgoto L_008C;\nL_0097:\n\tv326 = new System.NullReferenceException();\n\tgoto L_00A4;\n\tgoto L_00A4;\nL_00A4:\n\tv299 = Il2CppMethodInfo != 1;\n\tif (v299) goto L_0115;\n\tv605 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::MoveNext(v326);\n\tv607 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::MoveNext(v605);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v297 @ stack_-88_v12 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv609 = ~v605.m_value;\n\tv483 = ~v609;\n\tif (v483) goto L_0136;\nL_00B0:\n\tv244 = this.soundImgSprite;\n\tUnityEngine.UI.Image::set_sprite(this.soundImg, v244[0]);\n\tv564 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(this.allSound);\nL_00C8:\n\tv585 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v297 @ stack_-88_v12 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv591 = v585 == 0;\n\tif (v591) goto L_00D5;\n\tUnityEngine.AudioSource::set_volume(v568, 0f);\n\tgoto L_00C8;\nL_00D5:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v537 @ stack_-70_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00DC:\n\tv281 = ~this.canVibrate;\n\tif (v281) goto L_00F2;\n\tv73 = this.vibrateImgSprite + 0x28;\n\tgoto L_00F5;\nL_00F2:\n\tv73 = this.vibrateImgSprite + 0x20;\nL_00F5:\n\tUnityEngine.UI.Image::set_sprite(this.vibrateImg, *([v73 @ X8_v17 (System.Int32)]));\n\tgoto L_00FD;\n\tv599 = \"il2cpp_codegen_runtime_class_init\"(v596, v206, v191, v32, v33, v34, v35, v36, v96, v38, v39, v40, v41, v42, v43, v44);\nL_00FD:\n\tv223 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv603 = GameManager::get_numberRewinds(v223);\n\tv606 = v603 == 0;\n\tv520 = ~v606;\n\tif (v520) goto L_0110;\n\tGUIManager::EnableWatchingVideo(this);\nL_0110:\n\treturn;\n\tv211 = new System.NullReferenceException();\n\tv251 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0115:\n\tgoto L_0117;\n\tX20 = X0;\nL_0117:\n\tv385 = *([v374 @ X24_v3 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v537 @ stack_-70_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0141;\n\tv344 = new System.OutOfMemoryException();\n\tgoto L_012A;\n\tgoto L_012A;\nL_012A:\n\tv438 = *([v374 @ X24_v3 (Il2CppMethodInfo)]) != 1;\n\tif (v438) goto L_0138;\n\tthis = 0x1854E70(v344, v385, v382, v32, v33, v34, v35, v36, v351, v38, v39, v40, v41, v42, v43, v44);\n\tthis = 0x1854E80(this, v385, v382, v32, v33, v34, v35, v36, v351, v38, v39, v40, v41, v42, v43, v44);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v537 @ stack_-70_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv533 = *([this @ X0 (GUIManager)]) == 0;\n\tif (v533) goto L_00DC;\nL_0136:\n\tthrow System.OutOfMemoryException;\nL_0138:\n\tgoto L_013A;\n\tX20 = X0;\nL_013A:\n\tv385 = *([v374 @ X24_v3 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v537 @ stack_-70_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0143;\nL_0141:\n\tthis = 0xBD3CD0(v344, v385, v382, v32, v33, v34, v35, v36, v351, v38, v39, v40, v41, v42, v43, v44);\nL_0143:\n\tv427 = new System.OutOfMemoryException();\n\tthis = 0x9DACB4(v427, v420, v418, v32, v33, v34, v35, v36, v403, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n// 222 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe void SetDefaultGUI()
	{
		//IL_0400: Expected O, but got I4
		//IL_0135: Expected O, but got F4
		//IL_040d: Expected O, but got I
		//IL_01c0: Expected O, but got I4
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		int currentLevel = instance.currentLevel;
		string text = (currentLevel + 1).ToString();
		string text2 = "Level " + text;
		levelText.text = text2;
		GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
		string text3 = instance2.numberRewinds.ToString();
		rewindText.text = text3;
		if (!isSoundTurnOn)
		{
			goto IL_01ce;
		}
		Sprite[] array = soundImgSprite;
		soundImg.sprite = array[1];
		List<AudioSource>.Enumerator enumerator = allSound.GetEnumerator();
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		object obj = enumerator2;
		AudioSource audioSource = default(AudioSource);
		List<object>.Enumerator enumerator3;
		while (true)
		{
			bool flag = enumerator2.MoveNext();
			bool flag2 = !flag;
			enumerator3 = enumerator2;
			if (flag2)
			{
				break;
			}
			if ((object)audioSource != null)
			{
				audioSource.volume = 1f;
				obj = 1f;
				continue;
			}
			goto IL_013a;
		}
		goto IL_0222;
		IL_013a:
		NullReferenceException ex = new NullReferenceException();
		nint num = default(nint);
		object obj2 = default(object);
		if ((nint)0 == 1)
		{
			bool flag3 = ((List<AudioSource>.Enumerator*)ex)->MoveNext();
			bool flag4 = (flag3 ? ((List<AudioSource>.Enumerator*)1) : ((List<AudioSource>.Enumerator*)null))->MoveNext();
			enumerator2.Dispose();
			bool flag5 = !((bool*)(flag3 ? 1 : 0))->m_value;
			bool flag6 = !flag5;
			enumerator3 = enumerator2;
			num = 0;
			obj2 = 0;
			if (!flag6)
			{
				goto IL_01ce;
			}
			throw new OutOfMemoryException();
		}
		object obj3 = num;
		enumerator3.Dispose();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
		object obj4 = default(object);
		obj = obj4;
		object obj5 = obj2;
		object obj6 = obj3;
		OutOfMemoryException ex2 = new OutOfMemoryException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
		return;
		IL_01ce:
		Sprite[] array2 = soundImgSprite;
		soundImg.sprite = array2[0];
		List<AudioSource>.Enumerator enumerator4 = allSound.GetEnumerator();
		while (true)
		{
			bool flag7 = enumerator2.MoveNext();
			bool flag8 = !flag7;
			enumerator3 = enumerator2;
			if (flag8)
			{
				break;
			}
			audioSource.volume = 0f;
		}
		goto IL_0222;
		IL_0222:
		enumerator3.Dispose();
		currentLevel = (int)((!canVibrate) ? ((nint)vibrateImgSprite + 32) : ((nint)vibrateImgSprite + 40));
		vibrateImg.sprite = (Sprite)currentLevel;
		GameManager instance3 = SingletonMonoDontDestroy<GameManager>.Instance;
		if (instance3.numberRewinds == 0)
		{
			EnableWatchingVideo();
		}
	}

	[Token(Token = "0x6000108")]
	[Address(RVA = "0xC01450", Offset = "0xC01450", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGUIManager::PlayClickBoxSound(this);\n\tUnityEngine.GameObject::SetActive(this.menuPanel, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ActivatingMenu()
	{
		PlayClickBoxSound();
		menuPanel.SetActive(value: true);
	}

	[Token(Token = "0x6000109")]
	[Address(RVA = "0xC01478", Offset = "0xC01478", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.menuPanel, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void HideMenu()
	{
		menuPanel.SetActive(value: false);
	}

	[Token(Token = "0x600010A")]
	[Address(RVA = "0xC01430", Offset = "0xC01430", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.videoGO, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void EnableWatchingVideo()
	{
		videoGO.SetActive(value: true);
	}

	[Token(Token = "0x600010B")]
	[Address(RVA = "0xC00A80", Offset = "0xC00A80", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv14 = AdManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = SingletonMonoDontDestroy`1<GameManager>;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3561B]) = v35;\nL_001D:\n\tgoto L_0020;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv48 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv53 = ~v48.isRemoveAds;\n\tif (v53) goto L_0036;\n\treturn;\nL_0036:\n\tAdManager::ShowInterstitialAd(v59.Instance);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void WatchVideo1()
	{
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		if (!instance.isRemoveAds)
		{
			AdManager.Instance.ShowInterstitialAd();
		}
	}

	[Token(Token = "0x600010C")]
	[Address(RVA = "0xC01498", Offset = "0xC01498", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv26 = System.Action;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = AdManager;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv60 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A3561C]) = v46;\nL_0022:\n\tv50 = v49.Instance;\n\tv51 = new System.Action();\n\tSystem.Action::.ctor(v51, this, Il2CppMethodInfo);\n\tv50.RewardAction = v51;\n\tAdManager::ShowRewardAd(v63.Instance);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void WatchVideo2()
	{
		AdManager instance = AdManager.Instance;
		Action rewardAction = delegate
		{
			GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
			instance2.numberRewinds = 5;
			SetDefaultGUI();
			videoGO.SetActive(value: false);
		};
		instance.RewardAction = rewardAction;
		AdManager.Instance.ShowRewardAd();
	}

	[Token(Token = "0x600010D")]
	[Address(RVA = "0xC0154C", Offset = "0xC0154C", Length = "0x118")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = AdManager;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv63 = SingletonMonoDontDestroy`1<GameManager>;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A3561D]) = v40;\nL_0023:\n\tGUIManager::PlayClickBoxSound(this);\n\tgoto L_002B;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002B:\n\tv57 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv65 = ~v57.isAddBox;\n\tif (v65) goto L_003E;\n\treturn;\nL_003E:\n\tv76 = v99.Instance;\n\tv78 = new System.Action();\n\tSystem.Action::.ctor(v78, this, Il2CppMethodInfo);\n\tv76.RewardAction = v78;\n\tAdManager::ShowRewardAd(v85.Instance);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void WatchVideo3()
	{
		PlayClickBoxSound();
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		if (!instance.isAddBox)
		{
			AdManager instance2 = AdManager.Instance;
			Action rewardAction = delegate
			{
				AddOneBox();
			};
			instance2.RewardAction = rewardAction;
			AdManager.Instance.ShowRewardAd();
		}
	}

	[Token(Token = "0x600010E")]
	[Address(RVA = "0xC01664", Offset = "0xC01664", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = GameController;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3561E]) = v33;\nL_0011:\n\tGUIManager::PlayClickBoxSound(this);\n\tUnityEngine.GameObject::SetActive(this.videoGO, 0);\n\tv50 = v53.Ins;\n\tGamePlayController::Replay(v50.gamePlayController);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Replay()
	{
		PlayClickBoxSound();
		videoGO.SetActive(value: false);
		GameController ins = GameController.Ins;
		ins.gamePlayController.Replay();
	}

	[Token(Token = "0x600010F")]
	[Address(RVA = "0xC016DC", Offset = "0xC016DC", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = SingletonMonoDontDestroy`1<GameManager>;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3561F]) = v35;\nL_001A:\n\tgoto L_001D;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001D:\n\tv47 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv49 = GameManager::get_numberRewinds(v47);\n\tv56 = v49 < 0;\n\tv57 = v49 == 0;\n\tv59 = v49 ^ v49;\n\tv60 = v49 & v59;\n\tv61 = v60 < 0;\n\tv62 = v56 == v61;\n\tv63 = ~v57;\n\tv64 = v62 & v63;\n\treturn v64;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private bool isEnbleToRewind()
	{
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		int numberRewinds = instance.numberRewinds;
		bool flag = numberRewinds < 0;
		bool flag2 = numberRewinds == 0;
		int num = numberRewinds ^ numberRewinds;
		int num2 = numberRewinds & num;
		bool flag3 = num2 < 0;
		bool flag4 = flag == flag3;
		bool flag5 = !flag2;
		return flag4 && flag5;
	}

	[Token(Token = "0x6000110")]
	[Address(RVA = "0xC01758", Offset = "0xC01758", Length = "0xFC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = GameController;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv37 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = SingletonMonoDontDestroy`1<GameManager>;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv46 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35620]) = v34;\nL_001A:\n\tGUIManager::PlayClickBoxSound(this);\n\tv39 = GUIManager::isEnbleToRewind(this);\n\tv44 = v39 == 0;\n\tif (v44) goto L_0047;\n\tv51 = v50.Ins;\n\tv61 = v51.gamePlayController;\n\tv69 = v61.movementSaveStack;\n\tv86 = v69._size < 1;\n\tif (v86) goto L_0054;\n\tGamePlayController::RewindPlay(v61);\n\treturn;\nL_0047:\n\tgoto L_004A;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tv64 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv134 = GameManager::get_numberRewinds(v64);\n\tv123 = v134 == 0;\n\tif (v123) goto L_0056;\nL_0054:\n\treturn;\nL_0056:\n\tGUIManager::EnableWatchingVideo(this);\n\tGUIManager::WatchVideo2(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Rewind()
	{
		PlayClickBoxSound();
		if (isEnbleToRewind())
		{
			GameController ins = GameController.Ins;
			GamePlayController gamePlayController = ins.gamePlayController;
			Stack<Movement> movementSaveStack = gamePlayController.movementSaveStack;
			if (movementSaveStack.Count >= 1)
			{
				gamePlayController.RewindPlay();
			}
		}
		else
		{
			GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
			if (instance.numberRewinds == 0)
			{
				EnableWatchingVideo();
				WatchVideo2();
			}
		}
	}

	[Token(Token = "0x6000111")]
	[Address(RVA = "0xC01854", Offset = "0xC01854", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = GameController;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35621]) = v34;\nL_0013:\n\tv37 = v36.Ins;\n\tGamePlayController::AddOneBox(v37.gamePlayController);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddOneBox()
	{
		GameController ins = GameController.Ins;
		ins.gamePlayController.AddOneBox();
	}

	[Token(Token = "0x6000112")]
	[Address(RVA = "0xC018AC", Offset = "0xC018AC", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGUIManager::PlayClickBoxSound(this);\n\treturn;\n")]
	public void Shopping()
	{
		PlayClickBoxSound();
	}

	[Token(Token = "0x6000113")]
	[Address(RVA = "0xC018B0", Offset = "0xC018B0", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGUIManager::PlayClickBoxSound(this);\n\treturn;\n")]
	public void RemoveAds()
	{
		PlayClickBoxSound();
	}

	[Token(Token = "0x6000114")]
	[Address(RVA = "0xC018B4", Offset = "0xC018B4", Length = "0x2C0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv119 = Il2CppMethodInfo;\n\tv120 = \"il2cpp_codegen_initialize_runtime_metadata\"(v119, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv176 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv177 = \"il2cpp_codegen_initialize_runtime_metadata\"(v176, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv201 = \"isSoundOn\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35622]) = v42;\nL_002D:\n\tGUIManager::PlayClickBoxSound(this);\n\tv57 = ~this.isSoundTurnOn;\n\tif (v57) goto L_006D;\n\tv61 = this.soundImgSprite;\n\tUnityEngine.UI.Image::set_sprite(this.soundImg, v61[0]);\n\tv231 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(this.allSound);\nL_0049:\n\tv292 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v99 @ stack_-78_v12 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv325 = v292 == 0;\n\tif (v325) goto L_009C;\n\tv223 = v237 == 0;\n\tif (v223) goto L_0054;\n\tUnityEngine.AudioSource::set_volume(v237, 0f);\n\tgoto L_0049;\nL_0054:\n\tv221 = new System.NullReferenceException();\n\tgoto L_0061;\n\tgoto L_0061;\nL_0061:\n\tv66 = Il2CppMethodInfo != 1;\n\tif (v66) goto L_00C4;\n\tv476 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::MoveNext(v221);\n\tv479 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::MoveNext(v476);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v99 @ stack_-78_v12 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv480 = ~v476.m_value;\n\tv111 = ~v480;\n\tif (v111) goto L_00E5;\nL_006D:\n\tv116 = this.soundImgSprite;\n\tUnityEngine.UI.Image::set_sprite(this.soundImg, v116[1]);\n\tv235 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(this.allSound);\nL_008F:\n\tv323 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v99 @ stack_-78_v12 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv339 = v323 == 0;\n\tif (v339) goto L_009C;\n\tUnityEngine.AudioSource::set_volume(v237, 1f);\n\tgoto L_008F;\nL_009C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v351 @ stack_-60_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00A0:\n\tv418 = this.isSoundTurnOn ^ 1;\n\tthis.isSoundTurnOn = v418;\n\tgoto L_00AF;\n\tv470 = \"il2cpp_codegen_runtime_class_init\"(v419, v406, v405, v26, v27, v28, v29, v30, v403, v32, v33, v34, v35, v36, v37, v38);\nL_00AF:\n\tv446 = this.isSoundTurnOn == 0;\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetBool(\"isSoundOn\", v446);\n\treturn;\n\tv158 = new System.NullReferenceException();\n\tv172 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_00C4:\n\tgoto L_00C8;\n\tX20 = X0;\nL_00C8:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v351 @ stack_-60_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00F0;\n\tv239 = new System.OutOfMemoryException();\n\tgoto L_00D9;\n\tgoto L_00D9;\nL_00D9:\n\tv336 = Il2CppMethodInfo != 1;\n\tif (v336) goto L_00E7;\n\tv364 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::Dispose(v239);\n\tv425 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::Dispose(v364);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v351 @ stack_-60_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv412 = *([v364 @ X0_v20 (System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>)]) == 0;\n\tif (v412) goto L_00A0;\nL_00E5:\n\tthrow System.OutOfMemoryException;\nL_00E7:\n\tgoto L_00EB;\n\tX20 = X0;\nL_00EB:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v351 @ stack_-60_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00F2;\nL_00F0:\n\tv283 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::Dispose(v239);\nL_00F2:\n\tv315 = new System.OutOfMemoryException();\n\tv337 = System.Collections.Generic.List`1<UnityEngine.AudioSource>+Enumerator<UnityEngine.AudioSource>::Dispose(v315);\n\treturn;\n// 164 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe void TurnOnOffSound()
	{
		PlayClickBoxSound();
		if (!isSoundTurnOn)
		{
			goto IL_00fb;
		}
		Sprite[] array = soundImgSprite;
		soundImg.sprite = array[0];
		List<AudioSource>.Enumerator enumerator = allSound.GetEnumerator();
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		AudioSource audioSource = default(AudioSource);
		List<object>.Enumerator enumerator3;
		while (true)
		{
			bool flag = enumerator2.MoveNext();
			bool flag2 = !flag;
			enumerator3 = enumerator2;
			if (flag2)
			{
				break;
			}
			if ((object)audioSource != null)
			{
				audioSource.volume = 0f;
				continue;
			}
			goto IL_0076;
		}
		goto IL_014f;
		IL_0076:
		NullReferenceException ex = new NullReferenceException();
		if ((nint)0 == 1)
		{
			bool flag3 = ((List<AudioSource>.Enumerator*)ex)->MoveNext();
			bool flag4 = (flag3 ? ((List<AudioSource>.Enumerator*)1) : ((List<AudioSource>.Enumerator*)null))->MoveNext();
			enumerator2.Dispose();
			bool flag5 = !((bool*)(flag3 ? 1 : 0))->m_value;
			bool flag6 = !flag5;
			enumerator3 = enumerator2;
			if (!flag6)
			{
				goto IL_00fb;
			}
			throw new OutOfMemoryException();
		}
		enumerator3.Dispose();
		OutOfMemoryException ex2 = default(OutOfMemoryException);
		((List<AudioSource>.Enumerator*)ex2)->Dispose();
		OutOfMemoryException ex3 = new OutOfMemoryException();
		((List<AudioSource>.Enumerator*)ex3)->Dispose();
		return;
		IL_00fb:
		Sprite[] array2 = soundImgSprite;
		soundImg.sprite = array2[1];
		List<AudioSource>.Enumerator enumerator4 = allSound.GetEnumerator();
		while (true)
		{
			bool flag7 = enumerator2.MoveNext();
			bool flag8 = !flag7;
			enumerator3 = enumerator2;
			if (flag8)
			{
				break;
			}
			audioSource.volume = 1f;
		}
		goto IL_014f;
		IL_014f:
		enumerator3.Dispose();
		int num = (isSoundTurnOn ? 1 : 0) ^ 1;
		isSoundTurnOn = (byte)num != 0;
		bool value = !isSoundTurnOn;
		ObscuredPrefs.SetBool("isSoundOn", value);
	}

	[Token(Token = "0x6000115")]
	[Address(RVA = "0xBFCF18", Offset = "0xBFCF18", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = System.Action;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv56 = GUIManager+<>c;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35623]) = v38;\nL_0019:\n\tv40 = ~this.canVibrate;\n\tif (v40) goto L_0050;\n\tgoto L_0025;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = GUIManager+<>c;\nL_0025:\n\tv104 = v60.<>9__30_0;\n\tv62 = v60.<>9__30_0 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0048;\n\tgoto L_0034;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv108 = GUIManager+<>c;\nL_0034:\n\tv102 = new System.Action();\n\tSystem.Action::.ctor(v102, v110.<>9, Il2CppMethodInfo);\n\tv103.<>9__30_0 = v102;\nL_0048:\n\tExtensions::StartDelayMethod(this, 0.5f, v104);\n\treturn;\nL_0050:\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Vibrating()
	{
		if (!canVibrate)
		{
			return;
		}
		Action callback = _003C_003Ec._003C_003E9__30_0;
		if (_003C_003Ec._003C_003E9__30_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__30_0 = delegate
			{
				Handheld.Vibrate();
			});
		}
		this.StartDelayMethod(0.5f, callback);
	}

	[Token(Token = "0x6000116")]
	[Address(RVA = "0xC01B74", Offset = "0xC01B74", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv41 = \"canVibrate\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35624]) = v38;\nL_0016:\n\tGUIManager::PlayClickBoxSound(this);\n\tv47 = ~this.canVibrate;\n\tif (v47) goto L_0033;\n\tv152 = this.vibrateImgSprite + 0x20;\n\tgoto L_003A;\nL_0033:\n\tv152 = this.vibrateImgSprite + 0x28;\nL_003A:\n\tUnityEngine.UI.Image::set_sprite(this.vibrateImg, *([v152 @ X8_v4]));\n\tv160 = this.canVibrate ^ 1;\n\tthis.canVibrate = v160;\n\tgoto L_0049;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v161, v153, v158, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0049:\n\tv124 = this.canVibrate == 0;\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetBool(\"canVibrate\", v124);\n\treturn;\n\tv83 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void TurnOnOffVibrate()
	{
		//IL_0047: Expected O, but got I
		//IL_0031: Expected O, but got I
		PlayClickBoxSound();
		object sprite = ((!canVibrate) ? ((object)((nint)vibrateImgSprite + 40)) : ((object)((nint)vibrateImgSprite + 32)));
		vibrateImg.sprite = (Sprite)sprite;
		int num = (canVibrate ? 1 : 0) ^ 1;
		canVibrate = (byte)num != 0;
		bool value = !canVibrate;
		ObscuredPrefs.SetBool("canVibrate", value);
	}

	[Token(Token = "0x6000117")]
	[Address(RVA = "0xC01C50", Offset = "0xC01C50", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGUIManager::PlayClickBoxSound(this);\n\treturn;\n")]
	public void GivenGift()
	{
		PlayClickBoxSound();
	}

	[Token(Token = "0x6000118")]
	[Address(RVA = "0xBFC074", Offset = "0xBFC074", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.soundList;\n\tUnityEngine.AudioSource::PlayOneShot(this.sound, v2[1]);\n\treturn;\n\tv41 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PlayClickBoxSound()
	{
		AudioClip[] array = soundList;
		sound.PlayOneShot(array[1]);
	}

	[Token(Token = "0x6000119")]
	[Address(RVA = "0xBFC568", Offset = "0xBFC568", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.soundList;\n\tUnityEngine.AudioSource::PlayOneShot(this.sound, v2[2]);\n\treturn;\n\tv41 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PlayFallingSound()
	{
		AudioClip[] array = soundList;
		sound.PlayOneShot(array[2]);
	}

	[Token(Token = "0x600011A")]
	[Address(RVA = "0xBFD00C", Offset = "0xBFD00C", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.soundList;\n\tUnityEngine.AudioSource::PlayOneShot(this.sound, v2[3]);\n\treturn;\n\tv41 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PlaySolveSound()
	{
		AudioClip[] array = soundList;
		sound.PlayOneShot(array[3]);
	}

	[Token(Token = "0x600011B")]
	[Address(RVA = "0xC008B4", Offset = "0xC008B4", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.soundList;\n\tUnityEngine.AudioSource::PlayOneShot(this.sound, v2[4]);\n\treturn;\n\tv41 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PlayWinningSound()
	{
		AudioClip[] array = soundList;
		sound.PlayOneShot(array[4]);
	}

	[Token(Token = "0x600011C")]
	[Address(RVA = "0xBFCB9C", Offset = "0xBFCB9C", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.soundList;\n\tUnityEngine.AudioSource::PlayOneShot(this.sound, v2[5]);\n\treturn;\n\tv41 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PlayWrongPick()
	{
		AudioClip[] array = soundList;
		sound.PlayOneShot(array[5]);
	}

	[Token(Token = "0x600011D")]
	[Address(RVA = "0xC01010", Offset = "0xC01010", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.winningCanvasPanel, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ActivatingWinningCanvas()
	{
		winningCanvasPanel.SetActive(value: true);
	}

	[Token(Token = "0x600011E")]
	[Address(RVA = "0xC01C54", Offset = "0xC01C54", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.winningCanvasPanel, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void EndWinningCanvas()
	{
		winningCanvasPanel.SetActive(value: false);
	}

	[Token(Token = "0x600011F")]
	[Address(RVA = "0xC01C74", Offset = "0xC01C74", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = GameController;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35625]) = v37;\nL_0014:\n\tGUIManager::PlayClickBoxSound(this);\n\tGUIManager::SetDefaultGUI(this);\n\tGUIManager::EndWinningCanvas(this);\n\tv43 = v42.Ins;\n\tGamePlayController::NextLevel(v43.gamePlayController);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void NextLevel()
	{
		PlayClickBoxSound();
		SetDefaultGUI();
		EndWinningCanvas();
		GameController ins = GameController.Ins;
		ins.gamePlayController.NextLevel();
	}

	[Token(Token = "0x6000120")]
	[Address(RVA = "0xC01CE8", Offset = "0xC01CE8", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35626]) = v38;\nL_0017:\n\tthis.isSoundTurnOn = 0x101;\n\tgoto L_0027;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tSingletonMonoDontDestroy`1<GUIManager>::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GUIManager()
	{
	}
}
