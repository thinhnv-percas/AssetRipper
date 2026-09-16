using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CA70", Offset = "0x75CA70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CA70", Offset = "0x75CA70")]
	[Token(Token = "0x2000326")]
	public class GetSceneActivateChangedEventData : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C5A8C", Offset = "0x7C5A8C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5A8C", Offset = "0x7C5A8C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5A8C", Offset = "0x7C5A8C")]
		[Token(Token = "0x4001A0E")]
		[FieldOffset(Offset = "0x50")]
		public FsmString newName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5B00", Offset = "0x7C5B00")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5B00", Offset = "0x7C5B00")]
		[Token(Token = "0x4001A0F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString newPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5B50", Offset = "0x7C5B50")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5B50", Offset = "0x7C5B50")]
		[Token(Token = "0x4001A10")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool newIsValid;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5BA0", Offset = "0x7C5BA0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5BA0", Offset = "0x7C5BA0")]
		[Token(Token = "0x4001A11")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt newBuildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5BF0", Offset = "0x7C5BF0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5BF0", Offset = "0x7C5BF0")]
		[Token(Token = "0x4001A12")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool newIsLoaded;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5C40", Offset = "0x7C5C40")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5C40", Offset = "0x7C5C40")]
		[Token(Token = "0x4001A13")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool newIsDirty;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5C90", Offset = "0x7C5C90")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5C90", Offset = "0x7C5C90")]
		[Token(Token = "0x4001A14")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt newRootCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5CE0", Offset = "0x7C5CE0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5CE0", Offset = "0x7C5CE0")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7C5CE0", Offset = "0x7C5CE0")]
		[Token(Token = "0x4001A15")]
		[FieldOffset(Offset = "0x88")]
		public FsmArray newRootGameObjects;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C5D64", Offset = "0x7C5D64")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5D64", Offset = "0x7C5D64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5D64", Offset = "0x7C5D64")]
		[Token(Token = "0x4001A16")]
		[FieldOffset(Offset = "0x90")]
		public FsmString previousName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5DD8", Offset = "0x7C5DD8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5DD8", Offset = "0x7C5DD8")]
		[Token(Token = "0x4001A17")]
		[FieldOffset(Offset = "0x98")]
		public FsmString previousPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5E28", Offset = "0x7C5E28")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5E28", Offset = "0x7C5E28")]
		[Token(Token = "0x4001A18")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool previousIsValid;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5E78", Offset = "0x7C5E78")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5E78", Offset = "0x7C5E78")]
		[Token(Token = "0x4001A19")]
		[FieldOffset(Offset = "0xA8")]
		public FsmInt previousBuildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5EC8", Offset = "0x7C5EC8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5EC8", Offset = "0x7C5EC8")]
		[Token(Token = "0x4001A1A")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool previousIsLoaded;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5F18", Offset = "0x7C5F18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5F18", Offset = "0x7C5F18")]
		[Token(Token = "0x4001A1B")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool previousIsDirty;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5F68", Offset = "0x7C5F68")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5F68", Offset = "0x7C5F68")]
		[Token(Token = "0x4001A1C")]
		[FieldOffset(Offset = "0xC0")]
		public FsmInt previousRootCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C5FB8", Offset = "0x7C5FB8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C5FB8", Offset = "0x7C5FB8")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7C5FB8", Offset = "0x7C5FB8")]
		[Token(Token = "0x4001A1D")]
		[FieldOffset(Offset = "0xC8")]
		public FsmArray previousRootGameObjects;

		[Token(Token = "0x4001A1E")]
		[FieldOffset(Offset = "0xD0")]
		private Scene _scene;

		[Token(Token = "0x6000FCB")]
		[Address(RVA = "0xA3442C", Offset = "0xA3442C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this + 0x50;\n\tv10 = 0x6D26F0(v6, 0, 0x80, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 80L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x6000FCC")]
		[Address(RVA = "0xA3444C", Offset = "0xA3444C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActivateChangedEventData::DoGetSceneProperties(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetSceneProperties();
			Finish();
		}

		[Token(Token = "0x6000FCD")]
		[Address(RVA = "0xA3484C", Offset = "0xA3484C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActivateChangedEventData::DoGetSceneProperties(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSceneProperties();
		}

		[Token(Token = "0x6000FCE")]
		[Address(RVA = "0xA34474", Offset = "0xA34474", Length = "0x3D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC3BF8]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E0A]) = v42;\nL_001B:\n\tthis._scene = v47.lastPreviousActiveScene;\n\tv51 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousName);\n\tv130 = v51 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_002F;\n\tv196 = this.previousName;\n\tv214 = this + 0xD0;\n\tv155 = 0x10D454C(v214, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv196.value = v155;\nL_002F:\n\tv218 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousBuildIndex);\n\tv257 = v218 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_003F;\n\tv197 = this.previousBuildIndex;\n\tv259 = this + 0xD0;\n\tv156 = 0x10D45CC(v259, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv197.value = v156;\nL_003F:\n\tv263 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousPath);\n\tv265 = v263 == 0;\n\tv266 = ~v265;\n\tif (v266) goto L_004F;\n\tv198 = this.previousPath;\n\tv267 = this + 0xD0;\n\tv157 = 0x10D450C(v267, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv198.value = v157;\nL_004F:\n\tv271 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousIsValid);\n\tv273 = v271 == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_0060;\n\tv199 = this.previousIsValid;\n\tv275 = this + 0xD0;\n\tv158 = 0x10D44CC(v275, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv278 = v158 & 1;\n\tv199.value = v278;\nL_0060:\n\tv280 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousIsDirty);\n\tv282 = v280 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_0071;\n\tv200 = this.previousIsDirty;\n\tv284 = this + 0xD0;\n\tv159 = 0x10D460C(v284, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv287 = v159 & 1;\n\tv200.value = v287;\nL_0071:\n\tv289 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousIsLoaded);\n\tv291 = v289 == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_0082;\n\tv201 = this.previousIsLoaded;\n\tv293 = this + 0xD0;\n\tv160 = 0x10D458C(v293, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv296 = v160 & 1;\n\tv201.value = v296;\nL_0082:\n\tv298 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousRootCount);\n\tv300 = v298 == 0;\n\tv301 = ~v300;\n\tif (v301) goto L_0092;\n\tv202 = this.previousRootCount;\n\tv302 = this + 0xD0;\n\tv161 = 0x10D464C(v302, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv202.value = v161;\nL_0092:\n\tv306 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.previousRootGameObjects);\n\tv308 = v306 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_00B3;\n\tv134 = this + 0xD0;\n\tv163 = 0x10D44CC(v134, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv320 = v163 & 1;\n\tv321 = v320 == 0;\n\tif (v321) goto L_00AE;\n\tv162 = 0x10D468C(v134, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.previousRootGameObjects, v162);\n\tgoto L_00B3;\nL_00AE:\n\tHutongGames.PlayMaker.FsmArray::Resize(this.previousRootGameObjects, 0);\nL_00B3:\n\tthis._scene = v319.lastNewActiveScene;\n\tv323 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newName);\n\tv327 = v323 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_00C7;\n\tv204 = this.newName;\n\tv329 = this + 0xD0;\n\tv164 = 0x10D454C(v329, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv204.value = v164;\nL_00C7:\n\tv333 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newBuildIndex);\n\tv335 = v333 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_00D7;\n\tv205 = this.newBuildIndex;\n\tv337 = this + 0xD0;\n\tv165 = 0x10D45CC(v337, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv205.value = v165;\nL_00D7:\n\tv341 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newPath);\n\tv343 = v341 == 0;\n\tv344 = ~v343;\n\tif (v344) goto L_00E7;\n\tv206 = this.newPath;\n\tv345 = this + 0xD0;\n\tv166 = 0x10D450C(v345, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv206.value = v166;\nL_00E7:\n\tv349 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newIsValid);\n\tv351 = v349 == 0;\n\tv352 = ~v351;\n\tif (v352) goto L_00F8;\n\tv207 = this.newIsValid;\n\tv353 = this + 0xD0;\n\tv167 = 0x10D44CC(v353, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv356 = v167 & 1;\n\tv207.value = v356;\nL_00F8:\n\tv358 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newIsDirty);\n\tv360 = v358 == 0;\n\tv361 = ~v360;\n\tif (v361) goto L_0109;\n\tv208 = this.newIsDirty;\n\tv362 = this + 0xD0;\n\tv168 = 0x10D460C(v362, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv365 = v168 & 1;\n\tv208.value = v365;\nL_0109:\n\tv367 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newIsLoaded);\n\tv369 = v367 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_011A;\n\tv209 = this.newIsLoaded;\n\tv371 = this + 0xD0;\n\tv169 = 0x10D458C(v371, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv374 = v169 & 1;\n\tv209.value = v374;\nL_011A:\n\tv376 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newRootCount);\n\tv378 = v376 == 0;\n\tv379 = ~v378;\n\tif (v379) goto L_012A;\n\tv210 = this.newRootCount;\n\tv380 = this + 0xD0;\n\tv170 = 0x10D464C(v380, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv210.value = v170;\nL_012A:\n\tv238 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.newRootGameObjects);\n\tv242 = v238 == 0;\n\tif (v242) goto L_0136;\n\treturn;\nL_0136:\n\tv211 = this + 0xD0;\n\tv172 = 0x10D44CC(v211, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv385 = v172 & 1;\n\tv386 = v385 == 0;\n\tif (v386) goto L_015B;\n\tv171 = 0x10D468C(v211, 0, v53, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.newRootGameObjects, v171);\n\treturn;\nL_015B:\n\tHutongGames.PlayMaker.FsmArray::Resize(this.newRootGameObjects, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 197 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneProperties()
		{
			//IL_0052: Expected O, but got I
			//IL_00c0: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_019c: Expected O, but got I
			//IL_0219: Expected O, but got I
			//IL_0296: Expected O, but got I
			//IL_0313: Expected O, but got I
			//IL_0377: Expected O, but got I
			//IL_03f2: Expected O, but got I4
			//IL_0454: Expected O, but got I
			//IL_04c2: Expected O, but got I
			//IL_03d4: Expected O, but got I4
			//IL_0530: Expected O, but got I
			//IL_059e: Expected O, but got I
			//IL_061b: Expected O, but got I
			//IL_0698: Expected O, but got I
			//IL_076f: Expected O, but got I
			//IL_0715: Expected O, but got I
			_scene = SendActiveSceneChangedEvent.lastPreviousActiveScene;
			if (!previousName.IsNone)
			{
				FsmString fsmString = previousName;
				object obj = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				string value = default(string);
				fsmString.Value = value;
			}
			if (!previousBuildIndex.IsNone)
			{
				FsmInt fsmInt = previousBuildIndex;
				object obj2 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
				int value2 = default(int);
				fsmInt.Value = value2;
			}
			if (!previousPath.IsNone)
			{
				FsmString fsmString2 = previousPath;
				object obj3 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D450C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x98)");
				string value3 = default(string);
				fsmString2.Value = value3;
			}
			if (!previousIsValid.IsNone)
			{
				FsmBool fsmBool = previousIsValid;
				object obj4 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj5 = default(object);
				int value4 = (int)((long)(IntPtr)obj5 & 1L);
				fsmBool.value = (byte)value4 != 0;
			}
			if (!previousIsDirty.IsNone)
			{
				FsmBool fsmBool2 = previousIsDirty;
				object obj6 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D460C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x198)");
				object obj7 = default(object);
				int value5 = (int)((long)(IntPtr)obj7 & 1L);
				fsmBool2.value = (byte)value5 != 0;
			}
			if (!previousIsLoaded.IsNone)
			{
				FsmBool fsmBool3 = previousIsLoaded;
				object obj8 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D458C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x118)");
				object obj9 = default(object);
				int value6 = (int)((long)(IntPtr)obj9 & 1L);
				fsmBool3.value = (byte)value6 != 0;
			}
			if (!previousRootCount.IsNone)
			{
				FsmInt fsmInt2 = previousRootCount;
				object obj10 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D464C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x1D8)");
				int value7 = default(int);
				fsmInt2.Value = value7;
			}
			if (!previousRootGameObjects.IsNone)
			{
				object obj11 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj12 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj12 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D468C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x218)");
					object[] values = default(object[]);
					previousRootGameObjects.Values = values;
					object obj13 = 0;
				}
				else
				{
					previousRootGameObjects.Resize(0);
					object obj13 = 0;
				}
			}
			_scene = SendActiveSceneChangedEvent.lastNewActiveScene;
			if (!newName.IsNone)
			{
				FsmString fsmString3 = newName;
				object obj14 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				string value8 = default(string);
				fsmString3.Value = value8;
			}
			if (!newBuildIndex.IsNone)
			{
				FsmInt fsmInt3 = newBuildIndex;
				object obj15 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
				int value9 = default(int);
				fsmInt3.Value = value9;
			}
			if (!newPath.IsNone)
			{
				FsmString fsmString4 = newPath;
				object obj16 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D450C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x98)");
				string value10 = default(string);
				fsmString4.Value = value10;
			}
			if (!newIsValid.IsNone)
			{
				FsmBool fsmBool4 = newIsValid;
				object obj17 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj18 = default(object);
				int value11 = (int)((long)(IntPtr)obj18 & 1L);
				fsmBool4.value = (byte)value11 != 0;
			}
			if (!newIsDirty.IsNone)
			{
				FsmBool fsmBool5 = newIsDirty;
				object obj19 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D460C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x198)");
				object obj20 = default(object);
				int value12 = (int)((long)(IntPtr)obj20 & 1L);
				fsmBool5.value = (byte)value12 != 0;
			}
			if (!newIsLoaded.IsNone)
			{
				FsmBool fsmBool6 = newIsLoaded;
				object obj21 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D458C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x118)");
				object obj22 = default(object);
				int value13 = (int)((long)(IntPtr)obj22 & 1L);
				fsmBool6.value = (byte)value13 != 0;
			}
			if (!newRootCount.IsNone)
			{
				FsmInt fsmInt4 = newRootCount;
				object obj23 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D464C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x1D8)");
				int value14 = default(int);
				fsmInt4.Value = value14;
			}
			if (!newRootGameObjects.IsNone)
			{
				object obj24 = (long)(IntPtr)this + 208L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj25 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj25 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D468C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x218)");
					object[] values2 = default(object[]);
					newRootGameObjects.Values = values2;
				}
				else
				{
					newRootGameObjects.Resize(0);
				}
			}
		}

		[Token(Token = "0x6000FCF")]
		[Address(RVA = "0xA34850", Offset = "0xA34850", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneActivateChangedEventData()
		{
		}
	}
}
