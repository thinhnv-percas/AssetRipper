using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.Events;

[Token(Token = "0x2000023")]
public class WeaponButtonProvider : MonoProvider<WeaponButtonComponent>
{
	[Token(Token = "0x400007B")]
	[FieldOffset(Offset = "0xA0")]
	private GlobalEvent onSelectWeaponClick;

	[Token(Token = "0x400007C")]
	[FieldOffset(Offset = "0xA8")]
	private GlobalEvent onAmmoUpgradeClick;

	[Token(Token = "0x400007D")]
	[FieldOffset(Offset = "0xB0")]
	private GlobalEvent onPowerUpgradeClick;

	[Token(Token = "0x400007E")]
	[FieldOffset(Offset = "0xB8")]
	private GlobalEvent onBuyWeaponClick;

	[Token(Token = "0x6000035")]
	[Address(RVA = "0xCCC70C", Offset = "0xCCC70C", Length = "0x1E4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1F044B0]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20237A2]) = v46;\nL_001B:\n\tv50 = 0;\n\tv53 = Morpeh.MonoProvider`1<WeaponButtonComponent>::GetData(this, &v50 @ stack_-44_v1 (System.Boolean));\n\tv59 = UnityEngine.ScriptableObject::CreateInstance();\n\tthis.onSelectWeaponClick = v59;\n\tv60 = *([v53 @ X0_v3 (WeaponButtonComponent&)+30]);\n\t*([v53 @ X0_v3 (WeaponButtonComponent&)]) = v59;\n\tv66 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v66, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v60 @ X8_v6+E8]), v66);\n\tv98 = UnityEngine.ScriptableObject::CreateInstance();\n\tthis.onAmmoUpgradeClick = v98;\n\tv114 = *([v53 @ X0_v3 (WeaponButtonComponent&)+38]);\n\t*([v53 @ X0_v3 (WeaponButtonComponent&)+8]) = v98;\n\tv99 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v99, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v114 @ X8_v10+E8]), v99);\n\tv100 = UnityEngine.ScriptableObject::CreateInstance();\n\tthis.onPowerUpgradeClick = v100;\n\tv116 = *([v53 @ X0_v3 (WeaponButtonComponent&)+40]);\n\t*([v53 @ X0_v3 (WeaponButtonComponent&)+10]) = v100;\n\tv101 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v101, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v116 @ X8_v13+E8]), v101);\n\tv102 = UnityEngine.ScriptableObject::CreateInstance();\n\tthis.onBuyWeaponClick = v102;\n\tv118 = *([v53 @ X0_v3 (WeaponButtonComponent&)+48]);\n\t*([v53 @ X0_v3 (WeaponButtonComponent&)+18]) = v102;\n\tv103 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v103, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v118 @ X8_v16+E8]), v103);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected unsafe override void Initialize()
	{
		//IL_0182: Expected O, but got I
		//IL_0030: Expected O, but got I
		//IL_0058: Expected O, but got I
		//IL_008d: Expected O, but got I
		//IL_00b5: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_0147: Expected O, but got I
		bool existOnEntity = false;
		ref WeaponButtonComponent data = ref GetData(out existOnEntity);
		GlobalEvent globalEvent = (onSelectWeaponClick = ScriptableObject.CreateInstance<GlobalEvent>());
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v3 (WeaponButtonComponent&)+30]");
		object obj = 0;
		data = ref *(WeaponButtonComponent*)globalEvent;
		UnityAction call = delegate
		{
			bool existOnEntity2 = false;
			((GlobalEvent)GetData(out existOnEntity2)).Publish();
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v6+E8]");
		((UnityEvent)0).AddListener(call);
		GlobalEvent globalEvent2 = ScriptableObject.CreateInstance<GlobalEvent>();
		onAmmoUpgradeClick = globalEvent2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v3 (WeaponButtonComponent&)+38]");
		object obj2 = 0;
		UnityAction call2 = delegate
		{
			//IL_0016: Expected O, but got I
			bool existOnEntity2 = false;
			ref WeaponButtonComponent data2 = ref GetData(out existOnEntity2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v3 (WeaponButtonComponent&)+8]");
			((GlobalEvent)0).Publish();
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v10+E8]");
		((UnityEvent)0).AddListener(call2);
		GlobalEvent globalEvent3 = ScriptableObject.CreateInstance<GlobalEvent>();
		onPowerUpgradeClick = globalEvent3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v3 (WeaponButtonComponent&)+40]");
		object obj3 = 0;
		UnityAction call3 = delegate
		{
			//IL_0016: Expected O, but got I
			bool existOnEntity2 = false;
			ref WeaponButtonComponent data2 = ref GetData(out existOnEntity2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v3 (WeaponButtonComponent&)+10]");
			((GlobalEvent)0).Publish();
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v13+E8]");
		((UnityEvent)0).AddListener(call3);
		GlobalEvent globalEvent4 = ScriptableObject.CreateInstance<GlobalEvent>();
		onBuyWeaponClick = globalEvent4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v3 (WeaponButtonComponent&)+48]");
		object obj4 = 0;
		UnityAction call4 = delegate
		{
			//IL_0016: Expected O, but got I
			bool existOnEntity2 = false;
			ref WeaponButtonComponent data2 = ref GetData(out existOnEntity2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v3 (WeaponButtonComponent&)+18]");
			((GlobalEvent)0).Publish();
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v16+E8]");
		((UnityEvent)0).AddListener(call4);
	}

	[Token(Token = "0x6000036")]
	[Address(RVA = "0xCCC8F0", Offset = "0xCCC8F0", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB11B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20237A3]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tUnityEngine.Object::Destroy(this.onSelectWeaponClick);\n\tUnityEngine.Object::Destroy(this.onAmmoUpgradeClick);\n\tUnityEngine.Object::Destroy(this.onPowerUpgradeClick);\n\tUnityEngine.Object::Destroy(this.onBuyWeaponClick);\n\tMorpeh.EntityProvider::OnDestroy(this);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected override void OnDestroy()
	{
		Object.Destroy(onSelectWeaponClick);
		Object.Destroy(onAmmoUpgradeClick);
		Object.Destroy(onPowerUpgradeClick);
		Object.Destroy(onBuyWeaponClick);
		base.OnDestroy();
	}

	[Token(Token = "0x6000037")]
	[Address(RVA = "0xCCC98C", Offset = "0xCCC98C", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EAE360]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20237A4]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<WeaponButtonComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public WeaponButtonProvider()
	{
	}
}
