using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[ExecuteInEditMode]
[Attribute(Type = typeof(RequireComponent), RVA = "0x74C74C", Offset = "0x74C74C")]
[Token(Token = "0x2000012")]
public class TCP2_CameraDepth : MonoBehaviour
{
	[Token(Token = "0x40000A6")]
	[FieldOffset(Offset = "0x18")]
	public bool RenderDepth;

	[Token(Token = "0x6000086")]
	[Address(RVA = "0xB0318C", Offset = "0xB0318C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTCP2_CameraDepth::SetCameraDepth(this);\n\treturn;\n")]
	private void OnEnable()
	{
		SetCameraDepth();
	}

	[Token(Token = "0x6000087")]
	[Address(RVA = "0xB03218", Offset = "0xB03218", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTCP2_CameraDepth::SetCameraDepth(this);\n\treturn;\n")]
	private void OnValidate()
	{
		SetCameraDepth();
	}

	[Token(Token = "0x6000088")]
	[Address(RVA = "0xB03190", Offset = "0xB03190", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA3C38]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224CC]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tv49 = UnityEngine.Camera::get_depthTextureMode(v43);\n\tv51 = ~this.RenderDepth;\n\tif (v51) goto L_0023;\n\tv52 = v49 | 1;\n\tgoto L_002B;\nL_0023:\n\tv53 = v49 & 0xFFFFFFFE;\nL_002B:\n\tUnityEngine.Camera::set_depthTextureMode(v43, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SetCameraDepth()
	{
		//IL_005a: Expected I4, but got I8
		Camera component = GetComponent<Camera>();
		DepthTextureMode depthTextureMode = component.depthTextureMode;
		DepthTextureMode depthTextureMode2;
		if (RenderDepth)
		{
			int num = (int)(depthTextureMode | DepthTextureMode.Depth);
			depthTextureMode2 = (DepthTextureMode)num;
		}
		else
		{
			int num2 = (int)((long)depthTextureMode & 0xFFFFFFFEL);
			depthTextureMode2 = (DepthTextureMode)num2;
		}
		component.depthTextureMode = depthTextureMode2;
	}

	[Token(Token = "0x6000089")]
	[Address(RVA = "0xB0321C", Offset = "0xB0321C", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.RenderDepth = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_CameraDepth()
	{
		RenderDepth = true;
	}
}
