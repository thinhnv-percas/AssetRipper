using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Editor
{
	[Token(Token = "0x2000056")]
	internal class EditorFacebookLoader : FB.CompiledFacebookLoader
	{
		[Token(Token = "0x17000073")]
		protected override FacebookGameObject FBGameObject
		{
			[Token(Token = "0x6000208")]
			[Address(RVA = "0xD280FC", Offset = "0xD280FC", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ED0D70]);\n\tv17 = *([v16 @ X8_v9]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023BD1]) = v37;\nL_0016:\n\tv42 = Facebook.Unity.ComponentFactory::GetComponent(0);\n\tv48 = new Facebook.Unity.Editor.EditorFacebook();\n\tFacebook.Unity.Editor.EditorFacebook::.ctor(v48);\n\tv42.<Facebook>k__BackingField = v48;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EditorFacebookGameObject component = ComponentFactory.GetComponent<EditorFacebookGameObject>();
				EditorFacebook facebook = new EditorFacebook();
				component.Facebook = facebook;
				return component;
			}
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0xD28180", Offset = "0xD28180", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorFacebookLoader()
		{
		}
	}
}
