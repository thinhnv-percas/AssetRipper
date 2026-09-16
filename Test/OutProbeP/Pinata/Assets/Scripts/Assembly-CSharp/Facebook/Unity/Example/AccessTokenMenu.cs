using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x2000059")]
	internal class AccessTokenMenu : MenuBase
	{
		[Token(Token = "0x6000284")]
		[Address(RVA = "0xA05E3C", Offset = "0xA05E3C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAA7D8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C93]) = v38;\nL_0017:\n\tv43 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Refresh Access Token\");\n\tv45 = v43 == 0;\n\tif (v45) goto L_0036;\n\tv49 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAccessTokenRefreshResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IAccessTokenRefreshResult>::.ctor(v49, this, Il2CppMethodInfo);\n\tFacebook.Unity.FB+Mobile::RefreshCurrentAccessToken(v49);\n\treturn;\nL_0036:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void GetGui()
		{
			if (Button("Refresh Access Token"))
			{
				FacebookDelegate<IAccessTokenRefreshResult> callback = base.HandleResult;
				FB.Mobile.RefreshCurrentAccessToken(callback);
			}
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0xA06068", Offset = "0xA06068", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n")]
		public AccessTokenMenu()
		{
		}
	}
}
