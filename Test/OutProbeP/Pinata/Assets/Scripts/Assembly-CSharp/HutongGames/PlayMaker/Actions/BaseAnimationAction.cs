using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x2000120")]
	public abstract class BaseAnimationAction : ComponentAction<Animation>
	{
		[Token(Token = "0x6000693")]
		[Address(RVA = "0xA8B2BC", Offset = "0xA8B2BC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDCF10]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, targetObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20221C5]) = v41;\nL_0015:\n\tv42 = targetObject == 0;\n\tif (v42) goto L_0030;\n\tv56 = *([targetObject @ X1 (System.Object)]) != UnityEngine.AnimationClip;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\tgoto L_0039;\n\tv87 = *([v83 @ X0_v2+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0039;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v83, targetObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tv97 = UnityEngine.Object::op_Equality(v77, 0);\n\tv99 = v97 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0071;\n\tv125 = UnityEngine.GameObject::GetComponent(*([this @ X0 (HutongGames.PlayMaker.Actions.BaseAnimationAction)+20]));\n\tgoto L_0054;\n\tv164 = *([v116 @ X8_v10+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tif (v166) goto L_0054;\n\tv171 = v116;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v171, v124, v96, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0054:\n\tv110 = UnityEngine.Object::op_Inequality(v125, 0);\n\tv112 = v110 == 0;\n\tif (v112) goto L_0071;\n\tv161 = UnityEngine.Object::get_name(v77);\n\tUnityEngine.Animation::AddClip(v125, v77, v161);\n\treturn;\nL_0071:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnActionTargetInvoked(object targetObject)
		{
			//IL_008d: Expected O, but got I
			bool flag = targetObject == null;
			object obj = targetObject;
			if (!flag)
			{
				obj = (((object)targetObject.GetType() != typeof(AnimationClip)) ? null : targetObject);
			}
			if (!((Object)obj == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.BaseAnimationAction)+20]");
				Animation component = ((GameObject)0).GetComponent<Animation>();
				if (component != null)
				{
					string newName = ((Object)obj).name;
					component.AddClip((AnimationClip)obj, newName);
				}
			}
		}

		[Token(Token = "0x6000694")]
		[Address(RVA = "0xA87490", Offset = "0xA87490", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F07AB0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221C6]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Animation>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseAnimationAction()
		{
		}
	}
}
