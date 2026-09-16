using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.Events;

[Token(Token = "0x2000021")]
public class TabProvider : MonoProvider<TabComponent>
{
	[Token(Token = "0x400007A")]
	[FieldOffset(Offset = "0x40")]
	private GlobalEvent onClick;

	[Token(Token = "0x6000030")]
	[Address(RVA = "0xCCB000", Offset = "0xCCB000", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE8948]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023793]) = v40;\nL_0018:\n\tv44 = 0;\n\tv47 = Morpeh.MonoProvider`1<TabComponent>::GetData(this, &v44 @ stack_-24_v1 (System.Boolean));\n\tv53 = UnityEngine.ScriptableObject::CreateInstance();\n\tthis.onClick = v53;\n\tv54 = *([v47 @ X0_v3 (TabComponent&)+10]);\n\t*([v47 @ X0_v3 (TabComponent&)]) = v53;\n\tv60 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v60, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v54 @ X8_v8+E8]), v60);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected unsafe override void Initialize()
	{
		//IL_006b: Expected O, but got I
		//IL_0030: Expected O, but got I
		bool existOnEntity = false;
		ref TabComponent data = ref GetData(out existOnEntity);
		GlobalEvent globalEvent = (onClick = ScriptableObject.CreateInstance<GlobalEvent>());
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v3 (TabComponent&)+10]");
		object obj = 0;
		data = ref *(TabComponent*)globalEvent;
		UnityAction call = delegate
		{
			bool existOnEntity2 = false;
			((GlobalEvent)GetData(out existOnEntity2)).Publish();
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v8+E8]");
		((UnityEvent)0).AddListener(call);
	}

	[Token(Token = "0x6000031")]
	[Address(RVA = "0xCCB0D8", Offset = "0xCCB0D8", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F0B690]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023794]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tUnityEngine.Object::Destroy(this.onClick);\n\tMorpeh.EntityProvider::OnDestroy(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected override void OnDestroy()
	{
		Object.Destroy(onClick);
		base.OnDestroy();
	}

	[Token(Token = "0x6000032")]
	[Address(RVA = "0xCCB150", Offset = "0xCCB150", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFDFD8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023795]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<TabComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TabProvider()
	{
	}
}
