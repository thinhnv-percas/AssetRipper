using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.InAppPurchase.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.Events;

namespace GBG.Pinata.ECS.InAppPurchase.Providers
{
	[Token(Token = "0x2000053")]
	public class SetStateGameObjectProvider : MonoProvider<SetStateGameObjectComponent>
	{
		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x40")]
		private GlobalEvent onClick;

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0xCBF8B8", Offset = "0xCBF8B8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED39B8]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023729]) = v40;\nL_0018:\n\tv44 = 0;\n\tv47 = Morpeh.MonoProvider`1<GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectComponent>::GetData(this, &v44 @ stack_-24_v1 (System.Boolean));\n\tv53 = UnityEngine.ScriptableObject::CreateInstance();\n\tthis.onClick = v53;\n\tv54 = *([v47 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectComponent&)+8]);\n\t*([v47 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectComponent&)]) = v53;\n\tv60 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v60, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v54 @ X8_v8+E8]), v60);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void Initialize()
		{
			//IL_006b: Expected O, but got I
			//IL_0030: Expected O, but got I
			bool existOnEntity = false;
			ref SetStateGameObjectComponent data = ref GetData(out existOnEntity);
			GlobalEvent globalEvent = (onClick = ScriptableObject.CreateInstance<GlobalEvent>());
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectComponent&)+8]");
			object obj = 0;
			data = ref *(SetStateGameObjectComponent*)globalEvent;
			UnityAction call = delegate
			{
				bool existOnEntity2 = false;
				((GlobalEvent)GetData(out existOnEntity2)).Publish();
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v8+E8]");
			((UnityEvent)0).AddListener(call);
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0xCBF990", Offset = "0xCBF990", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EDCC30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202372A]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tUnityEngine.Object::Destroy(this.onClick);\n\tMorpeh.EntityProvider::OnDestroy(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnDestroy()
		{
			Object.Destroy(onClick);
			base.OnDestroy();
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0xCBFA08", Offset = "0xCBFA08", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDBB98]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202372B]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetStateGameObjectProvider()
		{
		}
	}
}
