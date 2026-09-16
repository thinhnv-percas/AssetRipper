using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CE80", Offset = "0x75CE80")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CE80", Offset = "0x75CE80")]
	[Token(Token = "0x2000333")]
	public class GetSceneUnloadedEventData : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6DE8", Offset = "0x7C6DE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6DE8", Offset = "0x7C6DE8")]
		[Token(Token = "0x4001A47")]
		[FieldOffset(Offset = "0x50")]
		public FsmString name;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6E38", Offset = "0x7C6E38")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6E38", Offset = "0x7C6E38")]
		[Token(Token = "0x4001A48")]
		[FieldOffset(Offset = "0x58")]
		public FsmString path;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6E88", Offset = "0x7C6E88")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6E88", Offset = "0x7C6E88")]
		[Token(Token = "0x4001A49")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt buildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6ED8", Offset = "0x7C6ED8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6ED8", Offset = "0x7C6ED8")]
		[Token(Token = "0x4001A4A")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isValid;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6F28", Offset = "0x7C6F28")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6F28", Offset = "0x7C6F28")]
		[Token(Token = "0x4001A4B")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool isLoaded;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6F78", Offset = "0x7C6F78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6F78", Offset = "0x7C6F78")]
		[Token(Token = "0x4001A4C")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool isDirty;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6FC8", Offset = "0x7C6FC8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6FC8", Offset = "0x7C6FC8")]
		[Token(Token = "0x4001A4D")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt rootCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7018", Offset = "0x7C7018")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C7018", Offset = "0x7C7018")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7C7018", Offset = "0x7C7018")]
		[Token(Token = "0x4001A4E")]
		[FieldOffset(Offset = "0x88")]
		public FsmArray rootGameObjects;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C709C", Offset = "0x7C709C")]
		[Token(Token = "0x4001A4F")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x4001A50")]
		[FieldOffset(Offset = "0x94")]
		private Scene _scene;

		[Token(Token = "0x6001005")]
		[Address(RVA = "0xA356E4", Offset = "0xA356E4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.buildIndex = 0;\n\tthis.name = 0;\n\tthis.isLoaded = 0;\n\tthis.rootCount = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			buildIndex = null;
			name = null;
			isLoaded = null;
			rootCount = null;
			everyFrame = false;
		}

		[Token(Token = "0x6001006")]
		[Address(RVA = "0xA356FC", Offset = "0xA356FC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneUnloadedEventData::DoGetSceneProperties(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetSceneProperties();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001007")]
		[Address(RVA = "0xA3594C", Offset = "0xA3594C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneUnloadedEventData::DoGetSceneProperties(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSceneProperties();
		}

		[Token(Token = "0x6001008")]
		[Address(RVA = "0xA35738", Offset = "0xA35738", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB8820]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E0C]) = v38;\nL_0019:\n\tthis._scene = v43.lastUnLoadedScene;\n\tv47 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.name);\n\tv86 = v47 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_002D;\n\tv122 = this.name;\n\tv132 = this + 0x94;\n\tv99 = 0x10D454C(v132, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv122.value = v99;\nL_002D:\n\tv136 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.buildIndex);\n\tv167 = v136 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_003D;\n\tv123 = this.buildIndex;\n\tv169 = this + 0x94;\n\tv100 = 0x10D45CC(v169, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv123.value = v100;\nL_003D:\n\tv173 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.path);\n\tv175 = v173 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_004D;\n\tv124 = this.path;\n\tv177 = this + 0x94;\n\tv101 = 0x10D450C(v177, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv124.value = v101;\nL_004D:\n\tv181 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isValid);\n\tv183 = v181 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_005E;\n\tv125 = this.isValid;\n\tv185 = this + 0x94;\n\tv102 = 0x10D44CC(v185, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv188 = v102 & 1;\n\tv125.value = v188;\nL_005E:\n\tv190 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isDirty);\n\tv192 = v190 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_006F;\n\tv126 = this.isDirty;\n\tv194 = this + 0x94;\n\tv103 = 0x10D460C(v194, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv197 = v103 & 1;\n\tv126.value = v197;\nL_006F:\n\tv199 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isLoaded);\n\tv201 = v199 == 0;\n\tv202 = ~v201;\n\tif (v202) goto L_0080;\n\tv127 = this.isLoaded;\n\tv203 = this + 0x94;\n\tv104 = 0x10D458C(v203, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv206 = v104 & 1;\n\tv127.value = v206;\nL_0080:\n\tv208 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootCount);\n\tv210 = v208 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0090;\n\tv128 = this.rootCount;\n\tv212 = this + 0x94;\n\tv105 = 0x10D464C(v212, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv128.value = v105;\nL_0090:\n\tv148 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootGameObjects);\n\tv152 = v148 == 0;\n\tif (v152) goto L_009A;\n\treturn;\nL_009A:\n\tv129 = this + 0x94;\n\tv107 = 0x10D44CC(v129, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv217 = v107 & 1;\n\tv218 = v217 == 0;\n\tif (v218) goto L_00BB;\n\tv106 = 0x10D468C(v129, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.rootGameObjects, v106);\n\treturn;\nL_00BB:\n\tHutongGames.PlayMaker.FsmArray::Resize(this.rootGameObjects, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneProperties()
		{
			//IL_0052: Expected O, but got I
			//IL_00c0: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_019c: Expected O, but got I
			//IL_0219: Expected O, but got I
			//IL_0296: Expected O, but got I
			//IL_036d: Expected O, but got I
			//IL_0313: Expected O, but got I
			_scene = SendSceneUnloadedEvent.lastUnLoadedScene;
			if (!name.IsNone)
			{
				FsmString fsmString = name;
				object obj = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				string value = default(string);
				fsmString.Value = value;
			}
			if (!buildIndex.IsNone)
			{
				FsmInt fsmInt = buildIndex;
				object obj2 = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
				int value2 = default(int);
				fsmInt.Value = value2;
			}
			if (!path.IsNone)
			{
				FsmString fsmString2 = path;
				object obj3 = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D450C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x98)");
				string value3 = default(string);
				fsmString2.Value = value3;
			}
			if (!isValid.IsNone)
			{
				FsmBool fsmBool = isValid;
				object obj4 = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj5 = default(object);
				int value4 = (int)((long)(IntPtr)obj5 & 1L);
				fsmBool.value = (byte)value4 != 0;
			}
			if (!isDirty.IsNone)
			{
				FsmBool fsmBool2 = isDirty;
				object obj6 = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D460C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x198)");
				object obj7 = default(object);
				int value5 = (int)((long)(IntPtr)obj7 & 1L);
				fsmBool2.value = (byte)value5 != 0;
			}
			if (!isLoaded.IsNone)
			{
				FsmBool fsmBool3 = isLoaded;
				object obj8 = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D458C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x118)");
				object obj9 = default(object);
				int value6 = (int)((long)(IntPtr)obj9 & 1L);
				fsmBool3.value = (byte)value6 != 0;
			}
			if (!rootCount.IsNone)
			{
				FsmInt fsmInt2 = rootCount;
				object obj10 = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D464C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x1D8)");
				int value7 = default(int);
				fsmInt2.Value = value7;
			}
			if (!rootGameObjects.IsNone)
			{
				object obj11 = (long)(IntPtr)this + 148L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj12 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj12 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D468C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x218)");
					object[] values = default(object[]);
					rootGameObjects.Values = values;
				}
				else
				{
					rootGameObjects.Resize(0);
				}
			}
		}

		[Token(Token = "0x6001009")]
		[Address(RVA = "0xA35950", Offset = "0xA35950", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneUnloadedEventData()
		{
		}
	}
}
