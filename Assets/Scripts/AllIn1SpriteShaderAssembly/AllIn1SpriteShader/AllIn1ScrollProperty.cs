using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x200000A")]
	public class AllIn1ScrollProperty : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x20")]
		private string numericPropertyName;

		[SerializeField]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x28")]
		private float scrollSpeed;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x2C")]
		private bool applyModulo;

		[SerializeField]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x30")]
		private float modulo;

		[Space]
		[SerializeField]
		[Header("If missing will search object Sprite Renderer or UI Image")]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x38")]
		private Material mat;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x40")]
		private int propertyShaderID;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x44")]
		private float currValue;

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x3C1ED2C", Offset = "0x3C1ED2C", Length = "0x3FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv123 = this + 0x38;\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Equality(this.mat, 0);\n\tv73 = ~v63;\n\tv74 = ~v73;\n\tif (v74) goto L_0048;\n\tgoto L_008A;\nL_0048:\n\tv94 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0051;\nL_0051:\n\tv143 = UnityEngine.Object::op_Inequality(v94, 0);\n\tv153 = ~v143;\n\tif (v153) goto L_0066;\n\tv288 = UnityEngine.Renderer::get_material(v94);\n\tgoto L_0083;\nL_0066:\n\tv190 = UnityEngine.Component::GetComponent(this);\n\tgoto L_006F;\nL_006F:\n\tv111 = UnityEngine.Object::op_Inequality(v190, 0);\n\tv292 = ~v111;\n\tv118 = ~v292;\n\tif (v118) goto L_0081;\n\tgoto L_008A;\nL_0081:\n\tv288 = UnityEngine.UI.Image::get_material(v190);\nL_008A:\n\tgoto L_008E;\nL_008E:\n\tv138 = UnityEngine.Object::op_Equality(*([v123 @ X20_v3]), 0);\n\tv148 = ~v138;\n\tif (v148) goto L_00CA;\n\tv168 = UnityEngine.Component::get_gameObject(this);\n\tv232 = UnityEngine.Object::get_name(v168);\n\tv240 = System.String::Concat(v232, \" has no valid Material, deleting All1TextureOffsetOverTIme component\");\n\tgoto L_00A8;\nL_00A8:\n\tgoto L_00AB;\nL_00AB:\n\tUnityEngine.Debug::LogError(v240);\n\tgoto L_00BB;\nL_00BB:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_00CA:\n\tv195 = UnityEngine.Material::HasProperty(this.mat, this.numericPropertyName);\n\tv233 = ~v195;\n\tif (v233) goto L_00EE;\n\tv243 = UnityEngine.Shader::PropertyToID(this.numericPropertyName);\n\tthis.propertyShaderID = v243;\n\tgoto L_0117;\nL_00EE:\n\tv214 = UnityEngine.Component::get_gameObject(this);\n\tv321 = UnityEngine.Object::get_name(v214);\n\tv343 = System.String::Concat(v321, \"'s Material doesn't have a \", this.numericPropertyName, \" property\");\n\tgoto L_0107;\nL_0107:\n\tgoto L_010A;\nL_010A:\n\tUnityEngine.Debug::LogError(v343);\n\tgoto L_0111;\nL_0111:\n\tUnityEngine.Object::Destroy(this);\nL_0117:\n\tv246 = UnityEngine.Material::GetFloat(*([v123 @ X20_v3]), this.propertyShaderID);\n\tthis.currValue = v246;\n\treturn;\nL_0083:\n\t*([v123 @ X20_v3]) = v288;\n")]
		public void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1ScrollProperty::Start");
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x3C1F204", Offset = "0x3C1F204", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.Time::get_deltaTime();\n\tv20 = this.scrollSpeed * v19;\n\tv21 = this.currValue + v20;\n\tthis.currValue = v21;\n\tv32 = this.applyModulo != 1;\n\tif (v32) goto L_002B;\n\tv34 = 0x8BF6440(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v21, this.modulo, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis.currValue = v21;\nL_002B:\n\tUnityEngine.Material::SetFloat(this.mat, this.propertyShaderID, v21);\n\treturn;\n")]
		private void Update()
		{
			float deltaTime = Time.deltaTime;
			float num = scrollSpeed * deltaTime;
			float value = (currValue += num);
			if (applyModulo)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6440");
				currValue = value;
			}
			mat.SetFloat(propertyShaderID, value);
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x3C1F128", Offset = "0x3C1F128", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv52 = 0xB292000 + 0x5A0;\n\tgoto L_0019;\nL_0019:\n\tUnityEngine.Debug::LogError(logError);\n\tv64 = *([v52 @ X22_v9 (System.Int32)]);\n\tv66 = *([v64 @ X0_v19+E4]) == 0;\n\tif (v66) goto L_004B;\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_004B:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\n")]
		private void DestroyComponentAndLogError(string logError)
		{
			//IL_002a: Expected O, but got I4
			int num = 187244544 + 1440;
			Debug.LogError(logError);
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v19+E4]");
			if ((nint)0 != 0)
			{
				Object.Destroy(this);
			}
			else
			{
				Object.Destroy(this);
			}
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x3C1F270", Offset = "0x3C1F270", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.numericPropertyName = \"_RotateUvAmount\";\n\tthis.modulo = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1ScrollProperty()
		{
			numericPropertyName = "_RotateUvAmount";
			modulo = 1f;
		}
	}
}
