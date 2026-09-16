using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CD90", Offset = "0x75CD90")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CD90", Offset = "0x75CD90")]
	[Token(Token = "0x2000330")]
	public class GetSceneProperties : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C692C", Offset = "0x7C692C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C692C", Offset = "0x7C692C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C692C", Offset = "0x7C692C")]
		[Token(Token = "0x4001A3A")]
		[FieldOffset(Offset = "0x90")]
		public FsmString name;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C69A0", Offset = "0x7C69A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C69A0", Offset = "0x7C69A0")]
		[Token(Token = "0x4001A3B")]
		[FieldOffset(Offset = "0x98")]
		public FsmString path;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C69F0", Offset = "0x7C69F0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C69F0", Offset = "0x7C69F0")]
		[Token(Token = "0x4001A3C")]
		[FieldOffset(Offset = "0xA0")]
		public FsmInt buildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6A40", Offset = "0x7C6A40")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6A40", Offset = "0x7C6A40")]
		[Token(Token = "0x4001A3D")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool isValid;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6A90", Offset = "0x7C6A90")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6A90", Offset = "0x7C6A90")]
		[Token(Token = "0x4001A3E")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool isLoaded;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6AE0", Offset = "0x7C6AE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6AE0", Offset = "0x7C6AE0")]
		[Token(Token = "0x4001A3F")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool isDirty;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6B30", Offset = "0x7C6B30")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6B30", Offset = "0x7C6B30")]
		[Token(Token = "0x4001A40")]
		[FieldOffset(Offset = "0xC0")]
		public FsmInt rootCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6B80", Offset = "0x7C6B80")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6B80", Offset = "0x7C6B80")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7C6B80", Offset = "0x7C6B80")]
		[Token(Token = "0x4001A41")]
		[FieldOffset(Offset = "0xC8")]
		public FsmArray rootGameObjects;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6C04", Offset = "0x7C6C04")]
		[Token(Token = "0x4001A42")]
		[FieldOffset(Offset = "0xD0")]
		public bool everyFrame;

		[Token(Token = "0x6000FF7")]
		[Address(RVA = "0xA3522C", Offset = "0xA3522C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv12 = this + 0x90;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneProperties)+84]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneProperties)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneProperties)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneProperties)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tv15 = 0x6D26F0(v12, 0, 0x41, v16, v17, v18, v19, v20, 0, v21, v22, v23, v24, v25, v26, v27);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0012: Expected O, but got I
			((FsmStateAction)this).Reset();
			object obj = (long)(IntPtr)this + 144L;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x6000FF8")]
		[Address(RVA = "0xA35278", Offset = "0xA35278", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneProperties::DoGetSceneProperties(this);\n\tv13 = ~this.everyFrame;\n\tif (v13) goto L_0017;\n\treturn;\nL_0017:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneProperties();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FF9")]
		[Address(RVA = "0xA352BC", Offset = "0xA352BC", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = ~this._sceneFound;\n\tif (v15) goto L_009F;\n\tv24 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.name);\n\tv110 = v24 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_001F;\n\tv113 = this.name;\n\tv150 = this + 0x88;\n\tv131 = 0x10D454C(v150, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv113.value = v131;\nL_001F:\n\tv154 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.buildIndex);\n\tv156 = v154 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_002F;\n\tv114 = this.buildIndex;\n\tv158 = this + 0x88;\n\tv132 = 0x10D45CC(v158, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv114.value = v132;\nL_002F:\n\tv162 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.path);\n\tv164 = v162 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_003F;\n\tv115 = this.path;\n\tv166 = this + 0x88;\n\tv133 = 0x10D450C(v166, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv115.value = v133;\nL_003F:\n\tv170 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isValid);\n\tv172 = v170 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0050;\n\tv116 = this.isValid;\n\tv174 = this + 0x88;\n\tv134 = 0x10D44CC(v174, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv177 = v134 & 1;\n\tv116.value = v177;\nL_0050:\n\tv179 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isDirty);\n\tv181 = v179 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0061;\n\tv117 = this.isDirty;\n\tv183 = this + 0x88;\n\tv135 = 0x10D460C(v183, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv186 = v135 & 1;\n\tv117.value = v186;\nL_0061:\n\tv188 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isLoaded);\n\tv190 = v188 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0072;\n\tv118 = this.isLoaded;\n\tv192 = this + 0x88;\n\tv136 = 0x10D458C(v192, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv195 = v136 & 1;\n\tv118.value = v195;\nL_0072:\n\tv197 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootCount);\n\tv199 = v197 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_0082;\n\tv119 = this.rootCount;\n\tv201 = this + 0x88;\n\tv137 = 0x10D464C(v201, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv119.value = v137;\nL_0082:\n\tv205 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootGameObjects);\n\tv207 = v205 == 0;\n\tv208 = ~v207;\n\tif (v208) goto L_00B1;\n\tv112 = this + 0x88;\n\tv139 = 0x10D44CC(v112, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tv217 = v139 & 1;\n\tv218 = v217 == 0;\n\tif (v218) goto L_00A5;\n\tv138 = 0x10D468C(v112, 0, v26, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.rootGameObjects, v138);\n\tgoto L_00B1;\nL_009F:\n\treturn;\nL_00A5:\n\tHutongGames.PlayMaker.FsmArray::Resize(this.rootGameObjects, 0);\nL_00B1:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneProperties()
		{
			//IL_0068: Expected O, but got I
			//IL_00db: Expected O, but got I
			//IL_014e: Expected O, but got I
			//IL_01c1: Expected O, but got I
			//IL_0243: Expected O, but got I
			//IL_02c5: Expected O, but got I
			//IL_0347: Expected O, but got I
			//IL_03b0: Expected O, but got I
			if (!_sceneFound)
			{
				return;
			}
			if (!name.IsNone)
			{
				FsmString fsmString = name;
				object obj = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				string value = default(string);
				fsmString.Value = value;
			}
			if (!buildIndex.IsNone)
			{
				FsmInt fsmInt = buildIndex;
				object obj2 = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
				int value2 = default(int);
				fsmInt.Value = value2;
			}
			if (!path.IsNone)
			{
				FsmString fsmString2 = path;
				object obj3 = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D450C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x98)");
				string value3 = default(string);
				fsmString2.Value = value3;
			}
			if (!isValid.IsNone)
			{
				FsmBool fsmBool = isValid;
				object obj4 = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj5 = default(object);
				int value4 = (int)((long)(IntPtr)obj5 & 1L);
				fsmBool.value = (byte)value4 != 0;
			}
			if (!isDirty.IsNone)
			{
				FsmBool fsmBool2 = isDirty;
				object obj6 = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D460C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x198)");
				object obj7 = default(object);
				int value5 = (int)((long)(IntPtr)obj7 & 1L);
				fsmBool2.value = (byte)value5 != 0;
			}
			if (!isLoaded.IsNone)
			{
				FsmBool fsmBool3 = isLoaded;
				object obj8 = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D458C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x118)");
				object obj9 = default(object);
				int value6 = (int)((long)(IntPtr)obj9 & 1L);
				fsmBool3.value = (byte)value6 != 0;
			}
			if (!rootCount.IsNone)
			{
				FsmInt fsmInt2 = rootCount;
				object obj10 = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D464C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x1D8)");
				int value7 = default(int);
				fsmInt2.Value = value7;
			}
			if (!rootGameObjects.IsNone)
			{
				object obj11 = (long)(IntPtr)this + 136L;
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
			Fsm.Event(sceneFoundEvent);
		}

		[Token(Token = "0x6000FFA")]
		[Address(RVA = "0xA354B8", Offset = "0xA354B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneProperties()
		{
		}
	}
}
