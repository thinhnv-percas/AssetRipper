using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1VfxToolkit.Scripts
{
	[Token(Token = "0x2000019")]
	public class AllIn1GraphicMaterialDuplicate : MonoBehaviour
	{
		[Token(Token = "0x6000051")]
		[Address(RVA = "0x3C286B4", Offset = "0x3C286B4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv59 = UnityEngine.UI.Graphic::get_material(v48);\n\tv62 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v62, v59);\n\tv70 = UnityEngine.UI.Graphic::set_material(v70, v62);\n\treturn;\nL_001C:\n\tv48 = UnityEngine.Component::GetComponent(this);\n")]
		private void Awake()
		{
			Graphic component = GetComponent<Graphic>();
			Material material = component.material;
			Material material2 = new Material(material);
			Graphic graphic = default(Graphic);
			graphic.material = material2;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x3C28770", Offset = "0x3C28770", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1GraphicMaterialDuplicate()
		{
		}
	}
}
