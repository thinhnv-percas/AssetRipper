using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200002B")]
	public class HeroEffectsHandlerExample : MonoBehaviour
	{
		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x20")]
		public BasicPlatformerController eventSource;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x28")]
		public UnityEvent OnJump;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x30")]
		public UnityEvent OnLand;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x38")]
		public UnityEvent OnHardLand;

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x150E4BC", Offset = "0x150E4BC", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = UnityEngine.Object;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = UnityEngine.Events.UnityAction;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37A1F]) = v44;\nL_0021:\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tv58 = UnityEngine.Object::op_Equality(this.eventSource, 0);\n\tv62 = v58 == 0;\n\tif (v62) goto L_003A;\n\treturn;\nL_003A:\n\tv123 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v123, this.OnLand, Il2CppMethodInfo);\n\tv115 = this.eventSource == 0;\n\tif (v115) goto L_006A;\n\tSpine.Unity.Examples.BasicPlatformerController::add_OnLand(this.eventSource, v123);\n\tv123 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v123, this.OnJump, Il2CppMethodInfo);\n\tv126 = this.eventSource == 0;\n\tif (v126) goto L_006A;\n\tSpine.Unity.Examples.BasicPlatformerController::add_OnJump(this.eventSource, v123);\n\tv123 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v123, this.OnHardLand, Il2CppMethodInfo);\n\tv100 = this.eventSource == 0;\n\tif (v100) goto L_006A;\n\tSpine.Unity.Examples.BasicPlatformerController::add_OnHardLand(this.eventSource, v123);\n\treturn;\nL_006A:\n\tthrow v123;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			if (eventSource == null)
			{
				return;
			}
			UnityAction unityAction = OnLand.Invoke;
			if ((object)eventSource != null)
			{
				eventSource.OnLand += unityAction;
				unityAction = OnJump.Invoke;
				if ((object)eventSource != null)
				{
					eventSource.OnJump += unityAction;
					unityAction = OnHardLand.Invoke;
					if ((object)eventSource != null)
					{
						eventSource.OnHardLand += unityAction;
						return;
					}
				}
			}
			throw unityAction;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x150E608", Offset = "0x150E608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HeroEffectsHandlerExample()
		{
		}
	}
}
