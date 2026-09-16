using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Mobile
{
	[Token(Token = "0x2000061")]
	internal abstract class MobileFacebook : FacebookBase, IMobileFacebookImplementation, IMobileFacebook, IFacebook, IMobileFacebookResultHandler, IFacebookResultHandler
	{
		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x28")]
		private ShareDialogMode shareDialogMode;

		[Token(Token = "0x1700007D")]
		public ShareDialogMode ShareDialogMode
		{
			[Token(Token = "0x600023F")]
			[Address(RVA = "0xD33928", Offset = "0xD33928", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tthis.shareDialogMode = value;\n\tv3 = this->klass->vtable[58];\n\tv4 = this->klass->vtable[58];\n\t// 4 IndirectJump v3 @ X3_v1, this @ X0 (Facebook.Unity.Mobile.MobileFacebook), this @ X0 (Facebook.Unity.Mobile.MobileFacebook), value @ X1 (Facebook.Unity.ShareDialogMode), v4 @ X2_v1, v3 @ X3_v1, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
			set
			{
				//IL_0005: Expected I, but got O
				//IL_001f: Expected O, but got I
				//IL_002f: Expected O, but got I
				IntPtr intPtr = (IntPtr)this;
				shareDialogMode = value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Facebook.Unity.Mobile.MobileFacebook>)+4D0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Facebook.Unity.Mobile.MobileFacebook>)+4D8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0xD30DEC", Offset = "0xD30DEC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<CallbackManager>k__BackingField = callbackManager;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected MobileFacebook(CallbackManager callbackManager)
		{
			CallbackManager = callbackManager;
		}

		[Token(Token = "0x6000240")]
		public abstract void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback);

		[Token(Token = "0x6000241")]
		public abstract void RefreshCurrentAccessToken(FacebookDelegate<IAccessTokenRefreshResult> callback);

		[Token(Token = "0x6000242")]
		public abstract bool IsImplicitPurchaseLoggingEnabled();

		[Token(Token = "0x6000243")]
		[Address(RVA = "0xD3393C", Offset = "0xD3393C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED7C58]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C88]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.LoginResult();\n\tFacebook.Unity.LoginResult::.ctor(v45, resultContainer);\n\tv48 = this->klass;\n\tv54 = this->klass->vtable[48];\n\tv55 = this->klass->vtable[48];\n\t// 39 IndirectJump v54 @ X3_v1, this @ X0 (Facebook.Unity.Mobile.MobileFacebook), this @ X0 (Facebook.Unity.Mobile.MobileFacebook), v45 @ X0_v3 (Facebook.Unity.LoginResult), v55 @ X2_v1, v54 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLoginComplete(ResultContainer resultContainer)
		{
			//IL_0018: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			LoginResult loginResult = new LoginResult(resultContainer);
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.MobileFacebook>)+430]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Mobile.MobileFacebook>)+438]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0xD339B8", Offset = "0xD339B8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE2E00]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C89]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AppLinkResult();\n\tFacebook.Unity.AppLinkResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGetAppLinkComplete(ResultContainer resultContainer)
		{
			AppLinkResult result = new AppLinkResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0xD33A30", Offset = "0xD33A30", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB6920]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C8A]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AppRequestResult();\n\tFacebook.Unity.AppRequestResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAppRequestsComplete(ResultContainer resultContainer)
		{
			AppRequestResult result = new AppRequestResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0xD33AA8", Offset = "0xD33AA8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EFE450]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C8B]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.AppLinkResult();\n\tFacebook.Unity.AppLinkResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFetchDeferredAppLinkComplete(ResultContainer resultContainer)
		{
			AppLinkResult result = new AppLinkResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0xD33B20", Offset = "0xD33B20", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA9EB8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C8C]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.ShareResult();\n\tFacebook.Unity.ShareResult::.ctor(v45, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnShareLinkComplete(ResultContainer resultContainer)
		{
			ShareResult result = new ShareResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0xD33B98", Offset = "0xD33B98", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EBBF68]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, resultContainer, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023C8D]) = v43;\nL_0019:\n\tv47 = new Facebook.Unity.AccessTokenRefreshResult();\n\tFacebook.Unity.AccessTokenRefreshResult::.ctor(v47, resultContainer);\n\tv52 = v47.<AccessToken>k__BackingField == 0;\n\tif (v52) goto L_003D;\n\tgoto L_0031;\n\tv73 = *([1ED9370]);\n\tv74 = *([v73 @ X8_v14]);\n\tv75 = \"il2cpp_codegen_initialize_method\"(v74, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv77 = 0 | 1;\n\t*([2023CAB]) = v77;\nL_0031:\n\tv63.<CurrentAccessToken>k__BackingField = v47.<AccessToken>k__BackingField;\nL_003D:\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v47);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnRefreshCurrentAccessTokenComplete(ResultContainer resultContainer)
		{
			AccessTokenRefreshResult accessTokenRefreshResult = new AccessTokenRefreshResult(resultContainer);
			if (accessTokenRefreshResult.AccessToken != null)
			{
				AccessToken.CurrentAccessToken = accessTokenRefreshResult.AccessToken;
			}
			CallbackManager.OnFacebookResponse(accessTokenRefreshResult);
		}

		[Token(Token = "0x6000249")]
		protected abstract void SetShareDialogMode(ShareDialogMode mode);
	}
}
