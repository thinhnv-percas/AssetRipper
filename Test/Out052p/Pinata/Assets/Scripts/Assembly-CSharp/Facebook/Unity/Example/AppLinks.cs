using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x200005B")]
	internal class AppLinks : MenuBase
	{
		[Token(Token = "0x6000288")]
		[Address(RVA = "0xA063CC", Offset = "0xA063CC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB78F8]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C95]) = v38;\nL_0017:\n\tv43 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Get App Link\");\n\tv45 = v43 == 0;\n\tif (v45) goto L_0038;\n\tv49 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppLinkResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppLinkResult>::.ctor(v49, this, Il2CppMethodInfo);\n\tgoto L_0036;\n\tv95 = *([v77 @ X0_v16+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0036;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v77, v72, v53, v51, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0036:\n\tFacebook.Unity.FB::GetAppLink(v49);\nL_0038:\n\tv68 = Facebook.Unity.Constants::get_IsMobile();\n\tv74 = v68 == 0;\n\tif (v74) goto L_005F;\n\tv85 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Fetch Deferred App Link\");\n\tv89 = v85 == 0;\n\tif (v89) goto L_005F;\n\tv125 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppLinkResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppLinkResult>::.ctor(v125, this, Il2CppMethodInfo);\n\tFacebook.Unity.FB+Mobile::FetchDeferredAppLinkData(v125);\n\treturn;\nL_005F:\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void GetGui()
		{
			if (Button("Get App Link"))
			{
				FacebookDelegate<IAppLinkResult> callback = base.HandleResult;
				FB.GetAppLink(callback);
			}
			if (Constants.IsMobile && Button("Fetch Deferred App Link"))
			{
				FacebookDelegate<IAppLinkResult> callback2 = base.HandleResult;
				FB.Mobile.FetchDeferredAppLinkData(callback2);
			}
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xA064F0", Offset = "0xA064F0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n")]
		public AppLinks()
		{
		}
	}
}
