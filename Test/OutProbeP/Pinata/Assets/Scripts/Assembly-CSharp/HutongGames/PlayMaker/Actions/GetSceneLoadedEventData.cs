using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CCA0", Offset = "0x75CCA0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CCA0", Offset = "0x75CCA0")]
	[Token(Token = "0x200032D")]
	public class GetSceneLoadedEventData : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C64D4", Offset = "0x7C64D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C64D4", Offset = "0x7C64D4")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7C64D4", Offset = "0x7C64D4")]
		[Token(Token = "0x4001A2E")]
		[FieldOffset(Offset = "0x50")]
		public FsmEnum loadedMode;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6570", Offset = "0x7C6570")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6570", Offset = "0x7C6570")]
		[Token(Token = "0x4001A2F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString name;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C65C0", Offset = "0x7C65C0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C65C0", Offset = "0x7C65C0")]
		[Token(Token = "0x4001A30")]
		[FieldOffset(Offset = "0x60")]
		public FsmString path;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6610", Offset = "0x7C6610")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6610", Offset = "0x7C6610")]
		[Token(Token = "0x4001A31")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isValid;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6660", Offset = "0x7C6660")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6660", Offset = "0x7C6660")]
		[Token(Token = "0x4001A32")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt buildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C66B0", Offset = "0x7C66B0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C66B0", Offset = "0x7C66B0")]
		[Token(Token = "0x4001A33")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool isLoaded;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6700", Offset = "0x7C6700")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6700", Offset = "0x7C6700")]
		[Token(Token = "0x4001A34")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool isDirty;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6750", Offset = "0x7C6750")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6750", Offset = "0x7C6750")]
		[Token(Token = "0x4001A35")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt rootCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C67A0", Offset = "0x7C67A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C67A0", Offset = "0x7C67A0")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7C67A0", Offset = "0x7C67A0")]
		[Token(Token = "0x4001A36")]
		[FieldOffset(Offset = "0x90")]
		public FsmArray rootGameObjects;

		[Token(Token = "0x4001A37")]
		[FieldOffset(Offset = "0x98")]
		private Scene _scene;

		[Token(Token = "0x6000FEB")]
		[Address(RVA = "0xA34D9C", Offset = "0xA34D9C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this + 0x50;\n\tv10 = 0x6D26F0(v6, 0, 0x48, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 80L;
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x6000FEC")]
		[Address(RVA = "0xA34DBC", Offset = "0xA34DBC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneLoadedEventData::DoGetSceneProperties(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetSceneProperties();
			Finish();
		}

		[Token(Token = "0x6000FED")]
		[Address(RVA = "0xA34DE4", Offset = "0xA34DE4", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFFB48]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E0B]) = v38;\nL_0019:\n\tthis._scene = v43.lastLoadedScene;\n\tv47 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.name);\n\tv99 = v47 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0036;\n\tv142 = v43.lastLoadedMode;\n\t// 43 Box v118 @ X0_v55 (System.Enum), typeof(UnityEngine.SceneManagement.LoadSceneMode), &v142 @ X8_v17 (UnityEngine.SceneManagement.LoadSceneMode)\n\tHutongGames.PlayMaker.FsmEnum::set_Value(this.loadedMode, v118);\nL_0036:\n\tv165 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.name);\n\tv186 = v165 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_0046;\n\tv145 = this.name;\n\tv188 = this + 0x98;\n\tv119 = 0x10D454C(v188, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv145.value = v119;\nL_0046:\n\tv192 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.buildIndex);\n\tv194 = v192 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_0056;\n\tv146 = this.buildIndex;\n\tv196 = this + 0x98;\n\tv120 = 0x10D45CC(v196, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv146.value = v120;\nL_0056:\n\tv200 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.path);\n\tv202 = v200 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0066;\n\tv147 = this.path;\n\tv204 = this + 0x98;\n\tv121 = 0x10D450C(v204, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv147.value = v121;\nL_0066:\n\tv208 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isValid);\n\tv210 = v208 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0077;\n\tv148 = this.isValid;\n\tv212 = this + 0x98;\n\tv122 = 0x10D44CC(v212, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv215 = v122 & 1;\n\tv148.value = v215;\nL_0077:\n\tv217 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isDirty);\n\tv219 = v217 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_0088;\n\tv149 = this.isDirty;\n\tv221 = this + 0x98;\n\tv123 = 0x10D460C(v221, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv224 = v123 & 1;\n\tv149.value = v224;\nL_0088:\n\tv226 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isLoaded);\n\tv228 = v226 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0099;\n\tv150 = this.isLoaded;\n\tv230 = this + 0x98;\n\tv124 = 0x10D458C(v230, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv233 = v124 & 1;\n\tv150.value = v233;\nL_0099:\n\tv235 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootCount);\n\tv237 = v235 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_00A9;\n\tv151 = this.rootCount;\n\tv239 = this + 0x98;\n\tv125 = 0x10D464C(v239, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151.value = v125;\nL_00A9:\n\tv243 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootGameObjects);\n\tv245 = v243 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_00CB;\n\tv152 = this + 0x98;\n\tv127 = 0x10D44CC(v152, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv255 = v127 & 1;\n\tv256 = v255 == 0;\n\tif (v256) goto L_00C5;\n\tv126 = 0x10D468C(v152, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.rootGameObjects, v126);\n\tgoto L_00CB;\nL_00C5:\n\tHutongGames.PlayMaker.FsmArray::Resize(this.rootGameObjects, 0);\nL_00CB:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneProperties()
		{
			//IL_00b8: Expected O, but got I
			//IL_012b: Expected O, but got I
			//IL_019e: Expected O, but got I
			//IL_0211: Expected O, but got I
			//IL_0293: Expected O, but got I
			//IL_0315: Expected O, but got I
			//IL_0397: Expected O, but got I
			//IL_0400: Expected O, but got I
			_scene = SendSceneLoadedEvent.lastLoadedScene;
			if (!name.IsNone)
			{
				LoadSceneMode lastLoadedMode = SendSceneLoadedEvent.lastLoadedMode;
				Enum value = lastLoadedMode;
				loadedMode.Value = value;
			}
			if (!name.IsNone)
			{
				FsmString fsmString = name;
				object obj = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				string value2 = default(string);
				fsmString.Value = value2;
			}
			if (!buildIndex.IsNone)
			{
				FsmInt fsmInt = buildIndex;
				object obj2 = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
				int value3 = default(int);
				fsmInt.Value = value3;
			}
			if (!path.IsNone)
			{
				FsmString fsmString2 = path;
				object obj3 = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D450C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x98)");
				string value4 = default(string);
				fsmString2.Value = value4;
			}
			if (!isValid.IsNone)
			{
				FsmBool fsmBool = isValid;
				object obj4 = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj5 = default(object);
				int value5 = (int)((long)(IntPtr)obj5 & 1L);
				fsmBool.value = (byte)value5 != 0;
			}
			if (!isDirty.IsNone)
			{
				FsmBool fsmBool2 = isDirty;
				object obj6 = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D460C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x198)");
				object obj7 = default(object);
				int value6 = (int)((long)(IntPtr)obj7 & 1L);
				fsmBool2.value = (byte)value6 != 0;
			}
			if (!isLoaded.IsNone)
			{
				FsmBool fsmBool3 = isLoaded;
				object obj8 = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D458C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x118)");
				object obj9 = default(object);
				int value7 = (int)((long)(IntPtr)obj9 & 1L);
				fsmBool3.value = (byte)value7 != 0;
			}
			if (!rootCount.IsNone)
			{
				FsmInt fsmInt2 = rootCount;
				object obj10 = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D464C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x1D8)");
				int value8 = default(int);
				fsmInt2.Value = value8;
			}
			if (!rootGameObjects.IsNone)
			{
				object obj11 = (long)(IntPtr)this + 152L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj12 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj12 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D468C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x218)");
					object[] values = default(object[]);
					rootGameObjects.Values = values;
				}
				else
				{
					rootGameObjects.Resize(0);
				}
			}
		}

		[Token(Token = "0x6000FEE")]
		[Address(RVA = "0xA35044", Offset = "0xA35044", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneLoadedEventData()
		{
		}
	}
}
