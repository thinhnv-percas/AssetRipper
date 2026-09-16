using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200002D")]
public class RatingReviewManager : SingletonMonoDontDestroy<RatingReviewManager>
{
	[Serializable]
	[CompilerGenerated]
	[Token(Token = "0x200002E")]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x40000B7")]
		public static readonly _003C_003Ec _003C_003E9;

		[Token(Token = "0x40000B8")]
		public static Action _003C_003E9__7_0;

		[Token(Token = "0x6000139")]
		[Address(RVA = "0xC0239C", Offset = "0xC0239C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = RatingReviewManager+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35632]) = v34;\nL_0012:\n\tv36 = new RatingReviewManager+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static _003C_003Ec()
		{
			_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
			_003C_003E9 = _003C_003Ec2;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0xC023F8", Offset = "0xC023F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003C_003Ec()
		{
		}

		internal void _003CMoveToWinningCanvas_003Eb__7_0()
		{
			GUIManager instance = SingletonMonoDontDestroy<GUIManager>.Instance;
			instance.ActivatingWinningCanvas();
		}
	}

	[Token(Token = "0x40000B5")]
	[FieldOffset(Offset = "0x28")]
	public GameObject ratingReviewPanel;

	[Token(Token = "0x40000B6")]
	[FieldOffset(Offset = "0x30")]
	public GameObject sorryReviewPanel;

	[Token(Token = "0x6000131")]
	[Address(RVA = "0xC00F80", Offset = "0xC00F80", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.ratingReviewPanel, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void EnableRatingReviewPanel()
	{
		ratingReviewPanel.SetActive(value: true);
	}

	[Token(Token = "0x6000132")]
	[Address(RVA = "0xC02158", Offset = "0xC02158", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.ratingReviewPanel, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void UnableRatingReviewPanel()
	{
		ratingReviewPanel.SetActive(value: false);
	}

	[Token(Token = "0x6000133")]
	[Address(RVA = "0xC02178", Offset = "0xC02178", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.sorryReviewPanel, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void EnableSorryReviewPanel()
	{
		sorryReviewPanel.SetActive(value: true);
	}

	[Token(Token = "0x6000134")]
	[Address(RVA = "0xC02198", Offset = "0xC02198", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.sorryReviewPanel, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UnableSorryReviewPanel()
	{
		sorryReviewPanel.SetActive(value: false);
	}

	[Token(Token = "0x6000135")]
	[Address(RVA = "0xC021B8", Offset = "0xC021B8", Length = "0x18")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tRatingReviewManager::EnableSorryReviewPanel(this);\n\tRatingReviewManager::UnableRatingReviewPanel(this);\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DontRate()
	{
		EnableSorryReviewPanel();
		UnableRatingReviewPanel();
	}

	[Token(Token = "0x6000136")]
	[Address(RVA = "0xC021D0", Offset = "0xC021D0", Length = "0xEC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = RatingReviewManager+<>c;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A3562F]) = v40;\nL_001B:\n\tRatingReviewManager::UnableRatingReviewPanel(this);\n\tRatingReviewManager::UnableSorryReviewPanel(this);\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv54 = RatingReviewManager+<>c;\nL_0026:\n\tv78 = v55.<>9__7_0;\n\tv57 = v55.<>9__7_0 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0049;\n\tgoto L_0035;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv90 = RatingReviewManager+<>c;\nL_0035:\n\tv74 = new System.Action();\n\tSystem.Action::.ctor(v74, v92.<>9, Il2CppMethodInfo);\n\tv77.<>9__7_0 = v74;\nL_0049:\n\tExtensions::StartDelayMethod(this, 0f, v78);\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void MoveToWinningCanvas()
	{
		UnableRatingReviewPanel();
		UnableSorryReviewPanel();
		Action callback = _003C_003Ec._003C_003E9__7_0;
		if (_003C_003Ec._003C_003E9__7_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__7_0 = delegate
			{
				GUIManager instance = SingletonMonoDontDestroy<GUIManager>.Instance;
				instance.ActivatingWinningCanvas();
			});
		}
		this.StartDelayMethod(0f, callback);
	}

	[Token(Token = "0x6000137")]
	[Address(RVA = "0xC022BC", Offset = "0xC022BC", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = \"https://play.google.com/store/apps/details?id=com.Lucy.ImpostorSortPuzzle\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35630]) = v38;\nL_001C:\n\tgoto L_0020;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tUnityEngine.Application::OpenURL(\"https://play.google.com/store/apps/details?id=com.Lucy.ImpostorSortPuzzle\");\n\tRatingReviewManager::MoveToWinningCanvas(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void GoToRate()
	{
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.Lucy.ImpostorSortPuzzle");
		MoveToWinningCanvas();
	}

	[Token(Token = "0x6000138")]
	[Address(RVA = "0xC02330", Offset = "0xC02330", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = SingletonMonoDontDestroy`1<RatingReviewManager>;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35631]) = v38;\nL_001C:\n\tgoto L_0025;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tSingletonMonoDontDestroy`1<RatingReviewManager>::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public RatingReviewManager()
	{
	}
}
