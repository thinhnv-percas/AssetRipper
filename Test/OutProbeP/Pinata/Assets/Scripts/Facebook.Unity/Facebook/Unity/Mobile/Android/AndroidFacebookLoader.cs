using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Mobile.Android
{
	[Token(Token = "0x200006B")]
	internal class AndroidFacebookLoader : FB.CompiledFacebookLoader
	{
		[Token(Token = "0x1700008A")]
		protected override FacebookGameObject FBGameObject
		{
			[Token(Token = "0x60002A1")]
			[Address(RVA = "0xD320A0", Offset = "0xD320A0", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EDF740]);\n\tv17 = *([v16 @ X8_v11]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023C72]) = v37;\nL_0016:\n\tv42 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\tv46 = v42.<Facebook>k__BackingField == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_002B;\n\tv52 = new Facebook.Unity.Mobile.Android.AndroidFacebook();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook::.ctor(v52);\n\tv42.<Facebook>k__BackingField = v52;\nL_002B:\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				AndroidFacebookGameObject component = ComponentFactory.GetComponent<AndroidFacebookGameObject>();
				if (component.Facebook == null)
				{
					AndroidFacebook facebook = new AndroidFacebook();
					component.Facebook = facebook;
				}
				return component;
			}
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xD32124", Offset = "0xD32124", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidFacebookLoader()
		{
		}
	}
}
