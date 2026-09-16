using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CF70", Offset = "0x75CF70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CF70", Offset = "0x75CF70")]
	[Token(Token = "0x2000337")]
	public class MergeScenes : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C78C8", Offset = "0x7C78C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C78C8", Offset = "0x7C78C8")]
		[Token(Token = "0x4001A74")]
		[FieldOffset(Offset = "0x4C")]
		public GetSceneActionBase.SceneAllReferenceOptions sourceReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7928", Offset = "0x7C7928")]
		[Token(Token = "0x4001A75")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt sourceAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7960", Offset = "0x7C7960")]
		[Token(Token = "0x4001A76")]
		[FieldOffset(Offset = "0x58")]
		public FsmString sourceByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7998", Offset = "0x7C7998")]
		[Token(Token = "0x4001A77")]
		[FieldOffset(Offset = "0x60")]
		public FsmString sourceByPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C79D0", Offset = "0x7C79D0")]
		[Token(Token = "0x4001A78")]
		[FieldOffset(Offset = "0x68")]
		public FsmOwnerDefault sourceByGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C7A08", Offset = "0x7C7A08")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7A08", Offset = "0x7C7A08")]
		[Token(Token = "0x4001A79")]
		[FieldOffset(Offset = "0x70")]
		public GetSceneActionBase.SceneAllReferenceOptions destinationReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7A68", Offset = "0x7C7A68")]
		[Token(Token = "0x4001A7A")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt destinationAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7AA0", Offset = "0x7C7AA0")]
		[Token(Token = "0x4001A7B")]
		[FieldOffset(Offset = "0x80")]
		public FsmString destinationByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7AD8", Offset = "0x7C7AD8")]
		[Token(Token = "0x4001A7C")]
		[FieldOffset(Offset = "0x88")]
		public FsmString destinationByPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7B10", Offset = "0x7C7B10")]
		[Token(Token = "0x4001A7D")]
		[FieldOffset(Offset = "0x90")]
		public FsmOwnerDefault destinationByGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C7B48", Offset = "0x7C7B48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7B48", Offset = "0x7C7B48")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C7B48", Offset = "0x7C7B48")]
		[Token(Token = "0x4001A7E")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool success;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7BBC", Offset = "0x7C7BBC")]
		[Token(Token = "0x4001A7F")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent successEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7BF4", Offset = "0x7C7BF4")]
		[Token(Token = "0x4001A80")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent failureEvent;

		[Token(Token = "0x4001A81")]
		[FieldOffset(Offset = "0xB0")]
		private Scene _sourceScene;

		[Token(Token = "0x4001A82")]
		[FieldOffset(Offset = "0xB4")]
		private bool _sourceFound;

		[Token(Token = "0x4001A83")]
		[FieldOffset(Offset = "0xB8")]
		private Scene _destinationScene;

		[Token(Token = "0x4001A84")]
		[FieldOffset(Offset = "0xBC")]
		private bool _destinationFound;

		[Token(Token = "0x6001018")]
		[Address(RVA = "0xA3BA84", Offset = "0xA3BA84", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.destinationReference = 0;\n\tthis.failureEvent = 0;\n\tthis.sourceReference = 1;\n\tthis.sourceAtIndex = 0;\n\tthis.sourceByPath = 0;\n\tthis.success = 0;\n\tthis.destinationAtIndex = 0;\n\tthis.destinationByPath = 0;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			destinationReference = default(GetSceneActionBase.SceneAllReferenceOptions);
			failureEvent = null;
			sourceReference = GetSceneActionBase.SceneAllReferenceOptions.SceneAtIndex;
			sourceAtIndex = null;
			sourceByPath = null;
			success = null;
			destinationAtIndex = null;
			destinationByPath = null;
		}

		[Token(Token = "0x6001019")]
		[Address(RVA = "0xA3BAAC", Offset = "0xA3BAAC", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF5FA0]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E4D]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.MergeScenes::GetSourceScene(this);\n\tHutongGames.PlayMaker.Actions.MergeScenes::GetDestinationScene(this);\n\tv42 = ~this._destinationFound;\n\tif (v42) goto L_0033;\n\tv44 = ~this._sourceFound;\n\tif (v44) goto L_0033;\n\tv50 = this._sourceScene;\n\tv54 = this + 0xB8;\n\t// 36 Box v56 @ X0_v12, typeof(UnityEngine.SceneManagement.Scene), &v50 @ X8_v10 (UnityEngine.SceneManagement.Scene)\n\tv78 = 0x10D49A0(v54, v56, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv92 = v78 & 1;\n\tv93 = v92 == 0;\n\tif (v93) goto L_003F;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Source and Destination scenes can not be the same\");\n\tgoto L_0040;\nL_0033:\n\tv47 = this.success;\n\tv47.value = 0;\n\tv99 = this.fsm;\n\tv96 = this.failureEvent;\n\tgoto L_004A;\nL_003F:\n\tUnityEngine.SceneManagement.SceneManager::MergeScenes(this._sourceScene, this._destinationScene);\nL_0040:\n\tv72 = this.success;\n\tv72.value = 1;\n\tv99 = this.fsm;\n\tv96 = this.successEvent;\nL_004A:\n\tHutongGames.PlayMaker.Fsm::Event(v99, v96);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0036: Expected O, but got I
			GetSourceScene();
			GetDestinationScene();
			Fsm fsm;
			FsmEvent fsmEvent;
			if (_destinationFound && _sourceFound)
			{
				Scene sourceScene = _sourceScene;
				object obj = (long)(IntPtr)this + 184L;
				object obj2 = sourceScene;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D49A0 (inside UnityEngine.SceneManagement.Scene::op_Equality +0x14)");
				object obj3 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
				{
					LogError("Source and Destination scenes can not be the same");
				}
				else
				{
					SceneManager.MergeScenes(_sourceScene, _destinationScene);
				}
				FsmBool fsmBool = success;
				fsmBool.value = true;
				fsm = Fsm;
				fsmEvent = successEvent;
			}
			else
			{
				FsmBool fsmBool2 = success;
				fsmBool2.value = false;
				fsm = Fsm;
				fsmEvent = failureEvent;
			}
			fsm.Event(fsmEvent);
			Finish();
		}

		[Token(Token = "0x600101A")]
		[Address(RVA = "0xA3BBC8", Offset = "0xA3BBC8", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F0A360]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E4E]) = v40;\nL_0014:\n\tv41 = v38.sourceReference;\n\tv42 = v38.sourceReference < 3;\n\tv43 = ~v42;\n\tv44 = v38.sourceReference - 3;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0044;\n\tv54 = 0x1818000 + 0x890;\n\tv56 = *([v54 @ X9_v2 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.GetSceneActionBase+SceneAllReferenceOptions)*4]) + v54;\n\t// 37 IndirectJump v56 @ X8_v7, v38 @ X0_v1 (HutongGames.PlayMaker.Actions.MergeScenes), v38 @ X0_v1 (HutongGames.PlayMaker.Actions.MergeScenes), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetActiveScene(X0);\n\tgoto L_0040;\n\tX0 = *([X19+58]);\n\tif (TEMP) goto L_0050;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByName(X0, X1);\n\tgoto L_0040;\n\tX0 = *([X19+60]);\n\tif (TEMP) goto L_0051;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByPath(X0, X1);\n\tgoto L_0040;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0052;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneAt(X0, X1);\nL_0040:\n\t*([X19+B0]) = X0;\nL_0044:\n\tv60 = UnityEngine.SceneManagement.Scene::op_Equality(v38._sourceScene, 0);\n\tv71 = ~v60;\n\tv38._sourceFound = v71;\n\treturn;\nL_0050:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0051:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0052:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\nL_0059:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_008A;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_007E;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0086;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tX0 = X19;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(X0, X1, X2);\n\tgoto L_0044;\nL_007E:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0086:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008A:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetSourceScene()
		{
			//IL_0029: Expected O, but got I
			while (true)
			{
				GetSceneActionBase.SceneAllReferenceOptions sceneAllReferenceOptions = sourceReference;
				bool flag = sourceReference < GetSceneActionBase.SceneAllReferenceOptions.SceneByPath;
				bool flag2 = !flag;
				int num = (int)(sourceReference - 3);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25264128 + 2192;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X9_v2 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.GetSceneActionBase+SceneAllReferenceOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v7 (should have been resolved before IL gen)");
			}
			bool flag5 = _sourceScene == default(Scene);
			bool sourceFound = !flag5;
			_sourceFound = sourceFound;
		}

		[Token(Token = "0x600101B")]
		[Address(RVA = "0xA3BD6C", Offset = "0xA3BD6C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF07C0]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E4F]) = v40;\nL_0014:\n\tv41 = v38.sourceReference;\n\tv42 = v38.sourceReference < 3;\n\tv43 = ~v42;\n\tv44 = v38.sourceReference - 3;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0044;\n\tv54 = 0x1818000 + 0x8A0;\n\tv56 = *([v54 @ X9_v2 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.GetSceneActionBase+SceneAllReferenceOptions)*4]) + v54;\n\t// 37 IndirectJump v56 @ X8_v7, v38 @ X0_v1 (HutongGames.PlayMaker.Actions.MergeScenes), v38 @ X0_v1 (HutongGames.PlayMaker.Actions.MergeScenes), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetActiveScene(X0);\n\tgoto L_0040;\n\tX0 = *([X19+80]);\n\tif (TEMP) goto L_0050;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByName(X0, X1);\n\tgoto L_0040;\n\tX0 = *([X19+88]);\n\tif (TEMP) goto L_0051;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByPath(X0, X1);\n\tgoto L_0040;\n\tX0 = *([X19+78]);\n\tif (TEMP) goto L_0052;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneAt(X0, X1);\nL_0040:\n\t*([X19+B8]) = X0;\nL_0044:\n\tv60 = UnityEngine.SceneManagement.Scene::op_Equality(v38._destinationScene, 0);\n\tv71 = ~v60;\n\tv38._destinationFound = v71;\n\treturn;\nL_0050:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0051:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0052:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\n\tgoto L_0059;\nL_0059:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_008A;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_007E;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0086;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tX0 = X19;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(X0, X1, X2);\n\tgoto L_0044;\nL_007E:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0086:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008A:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetDestinationScene()
		{
			//IL_0029: Expected O, but got I
			while (true)
			{
				GetSceneActionBase.SceneAllReferenceOptions sceneAllReferenceOptions = sourceReference;
				bool flag = sourceReference < GetSceneActionBase.SceneAllReferenceOptions.SceneByPath;
				bool flag2 = !flag;
				int num = (int)(sourceReference - 3);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25264128 + 2208;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X9_v2 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.GetSceneActionBase+SceneAllReferenceOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v7 (should have been resolved before IL gen)");
			}
			bool flag5 = _destinationScene == default(Scene);
			bool destinationFound = !flag5;
			_destinationFound = destinationFound;
		}

		[Token(Token = "0x600101C")]
		[Address(RVA = "0xA3BF10", Offset = "0xA3BF10", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB1F20]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E50]) = v38;\nL_0014:\n\tv40 = this.sourceReference == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_001D;\n\tv43 = this.destinationReference == 0;\n\tif (v43) goto L_FFFFFFFF;\nL_001D:\n\tv49 = v48.Empty;\nL_0024:\n\treturn *([v49 @ X8_v9 (System.String)]);\n\tgoto L_0024;\n\treturn X0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			if (sourceReference != GetSceneActionBase.SceneAllReferenceOptions.ActiveScene || destinationReference != GetSceneActionBase.SceneAllReferenceOptions.ActiveScene)
			{
				return string.Empty;
			}
			return "Source and Destination scenes can not be the same";
		}

		[Token(Token = "0x600101D")]
		[Address(RVA = "0xA3BF80", Offset = "0xA3BF80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MergeScenes()
		{
		}
	}
}
