using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.Unity.Editor.Dialogs;

namespace Facebook.Unity.Editor
{
	[Token(Token = "0x2000058")]
	internal class EditorWrapper : IEditorWrapper
	{
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x10")]
		private IFacebookCallbackHandler callbackHandler;

		[Token(Token = "0x6000217")]
		[Address(RVA = "0xD26DB8", Offset = "0xD26DB8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.callbackHandler = callbackHandler;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorWrapper(IFacebookCallbackHandler callbackHandler)
		{
			this.callbackHandler = callbackHandler;
		}

		[Token(Token = "0x6000218")]
		[Address(RVA = "0xD28A50", Offset = "0xD28A50", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = *([1EE0E30]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BD7]) = v38;\nL_0021:\n\tgoto L_004E;\n\tv54 = *([v45 @ X8_v5+B0]);\n\tv55 = 0;\n\tv56 = v54 + 8;\n\tv58 = *([v105 @ X11_v7-8]);\n\tv110 = v58 == v50;\n\tif (v110) goto L_0041;\n\tv88 = v104 + 1;\n\tv166 = v88 < v48;\n\tv85 = ~v166;\n\tv90 = v105 + 0x10;\n\tv61 = ~v85;\n\tif (v61) goto L_FFFFFFFF;\n\tv91 = v39;\n\tv92 = 0;\n\tv93 = 0x8909C4(v91, v50, v92, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004E;\nL_0041:\n\tv167 = *([v105 @ X11_v7]);\n\tv168 = v167 << 4;\n\tv169 = v45 + v168;\n\tv170 = v169 + 0x130;\nL_004E:\n\tFacebook.Unity.IFacebookCallbackHandler::OnInitComplete(this.callbackHandler, v46.Empty);\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init()
		{
			callbackHandler.OnInitComplete(string.Empty);
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0xD28B1C", Offset = "0xD28B1C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF7360]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, callbackId, permsisions, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2023BD8]) = v41;\nL_0019:\n\tv46 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\tv46.<Callback>k__BackingField = callback;\n\tv46.<CallbackID>k__BackingField = callbackId;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowLoginMockDialog(Utilities.Callback<ResultContainer> callback, string callbackId, string permsisions)
		{
			MockLoginDialog component = ComponentFactory.GetComponent<MockLoginDialog>();
			component.Callback = callback;
			component.CallbackID = callbackId;
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0xD28B88", Offset = "0xD28B88", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EC5690]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, callbackId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2023BD9]) = v41;\nL_0020:\n\tFacebook.Unity.Editor.EditorWrapper::ShowEmptyMockDialog(v38, callback, callbackId, \"Mock App Request\");\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowAppRequestMockDialog(Utilities.Callback<ResultContainer> callback, string callbackId)
		{
			ShowEmptyMockDialog(callback, callbackId, "Mock App Request");
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0xD28C5C", Offset = "0xD28C5C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1F0C948]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, callbackId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2023BDA]) = v41;\nL_0020:\n\tFacebook.Unity.Editor.EditorWrapper::ShowEmptyMockDialog(v38, callback, callbackId, \"Mock Pay\");\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowPayMockDialog(Utilities.Callback<ResultContainer> callback, string callbackId)
		{
			ShowEmptyMockDialog(callback, callbackId, "Mock Pay");
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0xD28CBC", Offset = "0xD28CBC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EE7658]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, subTitle, callbackId, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2023BDB]) = v44;\nL_001B:\n\tv49 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\tv49.<CallbackID>k__BackingField = callbackId;\n\tv49.<SubTitle>k__BackingField = subTitle;\n\tv49.<Callback>k__BackingField = callback;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowMockShareDialog(Utilities.Callback<ResultContainer> callback, string subTitle, string callbackId)
		{
			MockShareDialog component = ComponentFactory.GetComponent<MockShareDialog>();
			component.CallbackID = callbackId;
			component.SubTitle = subTitle;
			component.Callback = callback;
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0xD28BE8", Offset = "0xD28BE8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EABFA0]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, callbackId, title, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2023BDC]) = v44;\nL_001B:\n\tv49 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\tv49.<Callback>k__BackingField = callback;\n\tv49.<CallbackID>k__BackingField = callbackId;\n\tv49.<EmptyDialogTitle>k__BackingField = title;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ShowEmptyMockDialog(Utilities.Callback<ResultContainer> callback, string callbackId, string title)
		{
			EmptyMockDialog component = ComponentFactory.GetComponent<EmptyMockDialog>();
			component.Callback = callback;
			component.CallbackID = callbackId;
			component.EmptyDialogTitle = title;
		}
	}
}
