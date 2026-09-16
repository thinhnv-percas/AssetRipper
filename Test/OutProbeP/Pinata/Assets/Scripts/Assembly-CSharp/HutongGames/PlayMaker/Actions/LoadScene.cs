using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CED0", Offset = "0x75CED0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CED0", Offset = "0x75CED0")]
	[Token(Token = "0x2000335")]
	public class LoadScene : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C731C", Offset = "0x7C731C")]
		[Token(Token = "0x4001A5B")]
		[FieldOffset(Offset = "0x4C")]
		public GetSceneActionBase.SceneSimpleReferenceOptions sceneReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7354", Offset = "0x7C7354")]
		[Token(Token = "0x4001A5C")]
		[FieldOffset(Offset = "0x50")]
		public FsmString sceneByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C738C", Offset = "0x7C738C")]
		[Token(Token = "0x4001A5D")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt sceneAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C73C4", Offset = "0x7C73C4")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7C73C4", Offset = "0x7C73C4")]
		[Token(Token = "0x4001A5E")]
		[FieldOffset(Offset = "0x60")]
		public FsmEnum loadSceneMode;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C744C", Offset = "0x7C744C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C744C", Offset = "0x7C744C")]
		[Token(Token = "0x4001A5F")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool success;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C74AC", Offset = "0x7C74AC")]
		[Token(Token = "0x4001A60")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent successEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C74E4", Offset = "0x7C74E4")]
		[Token(Token = "0x4001A61")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent failureEvent;

		[Token(Token = "0x600100D")]
		[Address(RVA = "0xA3A560", Offset = "0xA3A560", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.LoadScene)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.LoadScene)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.LoadScene)+5C]) = 0;\n\tthis.sceneReference = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			_ = 0;
			_ = 0;
			_ = 0;
			sceneReference = default(GetSceneActionBase.SceneSimpleReferenceOptions);
		}

		[Token(Token = "0x600100E")]
		[Address(RVA = "0xA3A578", Offset = "0xA3A578", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.Actions.LoadScene::DoLoadScene(this);\n\tv19 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.success);\n\tv28 = v19 == 0;\n\tv29 = ~v28;\n\tif (v29) goto L_001A;\n\tv24 = this.success;\n\tv24.value = v12;\nL_001A:\n\tv59 = v12 == 0;\n\tif (v59) goto L_0022;\n\tv80 = this.successEvent;\n\tgoto L_0024;\nL_0022:\n\tv80 = this.failureEvent;\nL_0024:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v80);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool flag = DoLoadScene();
			if (!success.IsNone)
			{
				FsmBool fsmBool = success;
				fsmBool.value = flag;
			}
			FsmEvent fsmEvent = ((!flag) ? failureEvent : successEvent);
			Fsm.Event(fsmEvent);
			Finish();
		}

		[Token(Token = "0x600100F")]
		[Address(RVA = "0xA3A5F8", Offset = "0xA3A5F8", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EED100]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E43]) = v38;\nL_0015:\n\tv41 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv45 = this.sceneReference == 0;\n\tif (v45) goto L_0050;\n\tv46 = 0x10D454C(&v41 @ X0_v3 (UnityEngine.SceneManagement.Scene), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv56 = HutongGames.PlayMaker.FsmString::get_Value(this.sceneByName);\n\tv108 = System.String::op_Equality(v46, v56);\n\tv138 = v108 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_FFFFFFFF;\n\tv90 = HutongGames.PlayMaker.FsmString::get_Value(this.sceneByName);\n\tv124 = HutongGames.PlayMaker.FsmEnum::get_Value(this.loadSceneMode);\n\tv141 = v141_asT == 0;\n\tif (v141) goto L_0092;\n\tthis = \"il2cpp_vm_object_unbox\"(v124, UnityEngine.SceneManagement.LoadSceneMode, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v90, *([this @ X0 (HutongGames.PlayMaker.Actions.LoadScene)]));\n\tgoto L_FFFFFFFF;\nL_0050:\n\tv47 = 0x10D45CC(&v41 @ X0_v3 (UnityEngine.SceneManagement.Scene), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv105 = HutongGames.PlayMaker.FsmInt::get_Value(this.sceneAtIndex);\n\tv59 = v47 != v105;\n\tif (v59) goto L_0069;\n\tgoto L_008F;\nL_0069:\n\tv91 = HutongGames.PlayMaker.FsmInt::get_Value(this.sceneAtIndex);\n\tv126 = HutongGames.PlayMaker.FsmEnum::get_Value(this.loadSceneMode);\n\tv142 = v142_asT == 0;\n\tif (v142) goto L_0092;\n\tthis = \"il2cpp_vm_object_unbox\"(v126, UnityEngine.SceneManagement.LoadSceneMode, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v91, *([this @ X0 (HutongGames.PlayMaker.Actions.LoadScene)]));\nL_008F:\n\treturn returnVal2;\n\tv135 = new System.NullReferenceException();\nL_0092:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoLoadScene()
		{
			//IL_0160: Expected I4, but got O
			//IL_01b7: Expected I4, but got O
			//IL_0196: Expected I4, but got O
			//IL_009b: Expected I4, but got O
			//IL_00d1: Expected I4, but got O
			Scene activeScene = SceneManager.GetActiveScene();
			if (sceneReference != GetSceneActionBase.SceneSimpleReferenceOptions.SceneAtIndex)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				string value = sceneByName.Value;
				string text = default(string);
				if (text == value)
				{
					goto IL_011d;
				}
				string value2 = sceneByName.Value;
				Enum value3 = loadSceneMode.Value;
				if ((int)((value3 is LoadSceneMode) ? value3 : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					SceneManager.LoadScene(value2, (LoadSceneMode)this);
					goto IL_019b;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
				int value4 = sceneAtIndex.Value;
				int num = default(int);
				if (num == value4)
				{
					goto IL_011d;
				}
				int value5 = sceneAtIndex.Value;
				Enum value6 = loadSceneMode.Value;
				if ((int)((value6 is LoadSceneMode) ? value6 : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					SceneManager.LoadScene(value5, (LoadSceneMode)this);
					goto IL_019b;
				}
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
			IL_011d:
			return false;
			IL_019b:
			return true;
		}

		[Token(Token = "0x6001010")]
		[Address(RVA = "0xA3A78C", Offset = "0xA3A78C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LoadScene()
		{
		}
	}
}
