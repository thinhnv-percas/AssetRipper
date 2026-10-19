using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x2000009")]
	public class All1TextureOffsetOverTime : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x20")]
		private string texturePropertyName;

		[SerializeField]
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x28")]
		private Vector2 offsetSpeed;

		[SerializeField]
		[Header("If missing will search object Sprite Renderer or UI Image")]
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x30")]
		private Material mat;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x38")]
		private int textureShaderId;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x3C")]
		private Vector2 currOffset;

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x3C1E7D8", Offset = "0x3C1E7D8", Length = "0x360")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv123 = this + 0x30;\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Equality(this.mat, 0);\n\tv73 = ~v63;\n\tv74 = ~v73;\n\tif (v74) goto L_0048;\n\tgoto L_008A;\nL_0048:\n\tv94 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0051;\nL_0051:\n\tv143 = UnityEngine.Object::op_Inequality(v94, 0);\n\tv153 = ~v143;\n\tif (v153) goto L_0066;\n\tv273 = UnityEngine.Renderer::get_material(v94);\n\tgoto L_0083;\nL_0066:\n\tv190 = UnityEngine.Component::GetComponent(this);\n\tgoto L_006F;\nL_006F:\n\tv111 = UnityEngine.Object::op_Inequality(v190, 0);\n\tv277 = ~v111;\n\tv118 = ~v277;\n\tif (v118) goto L_0081;\n\tgoto L_008A;\nL_0081:\n\tv273 = UnityEngine.UI.Image::get_material(v190);\nL_008A:\n\tgoto L_008E;\nL_008E:\n\tv138 = UnityEngine.Object::op_Equality(*([v123 @ X20_v3]), 0);\n\tv148 = ~v138;\n\tif (v148) goto L_00D7;\n\tv168 = UnityEngine.Component::get_gameObject(this);\n\tv218 = UnityEngine.Object::get_name(v168);\n\tv226 = System.String::Concat(v218, \" has no valid Material, deleting All1TextureOffsetOverTIme component\");\n\tgoto L_FFFFFFFF;\nL_00B6:\n\tUnityEngine.Debug::LogError(v331);\n\tgoto L_00C8;\nL_00C8:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_00D7:\n\tv195 = UnityEngine.Material::HasProperty(this.mat, this.texturePropertyName);\n\tv219 = ~v195;\n\tif (v219) goto L_00EA;\n\tv229 = UnityEngine.Shader::PropertyToID(this.texturePropertyName);\n\tthis.textureShaderId = v229;\n\treturn;\nL_00EA:\n\tv204 = UnityEngine.Component::get_gameObject(this);\n\tv300 = UnityEngine.Object::get_name(v204);\n\tv338 = System.String::Concat(v300, \"'s Material doesn't have a \", this.texturePropertyName, \" property\");\n\tgoto L_FFFFFFFF;\nL_0083:\n\t*([v123 @ X20_v3]) = v273;\nL_FFFFFFFF:\n\tv331 = v226;\n\tgoto L_00B6;\nL_FFFFFFFF:\n\tv331 = v338;\n\tgoto L_00B6;\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("All1TextureOffsetOverTime::Start");
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x3C1EC14", Offset = "0x3C1EC14", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.Time::get_deltaTime();\n\tv20 = this.offsetSpeed * v19;\n\tv21 = this.currOffset + v20;\n\tthis.currOffset.x = v21;\n\tv25 = UnityEngine.Time::get_deltaTime();\n\tv26 = this.offsetSpeed.y * v25;\n\tv27 = this.currOffset.y + v26;\n\tthis.currOffset.y = v27;\n\t// 36 MakeStruct v39 @ AGG3C1EC80_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.currOffset (UnityEngine.Vector2), v27 @ V1_v1 (System.Single)\n\tUnityEngine.Material::SetTextureOffset(this.mat, this.textureShaderId, v39);\n\treturn;\n")]
		public void Update()
		{
			float deltaTime = Time.deltaTime;
			float num = offsetSpeed.x * deltaTime;
			float x = currOffset.x + num;
			currOffset.x = x;
			float deltaTime2 = Time.deltaTime;
			float num2 = offsetSpeed.y * deltaTime2;
			float y = currOffset.y + num2;
			currOffset.y = y;
			Vector2 value = default(Vector2);
			value.x = currOffset.x;
			value.y = y;
			mat.SetTextureOffset(textureShaderId, value);
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x3C1EB38", Offset = "0x3C1EB38", Length = "0xDC")]
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

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x3C1EC88", Offset = "0x3C1EC88", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.texturePropertyName = \"_MainTex\";\n\tgoto L_002B;\nL_002B:\n\tthis.offsetSpeed = v62.zero;\n\tthis.currOffset = v62.zero;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public All1TextureOffsetOverTime()
		{
			texturePropertyName = "_MainTex";
			offsetSpeed = Vector2.zero;
			currOffset = Vector2.zero;
		}
	}
}
