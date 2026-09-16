using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759F18", Offset = "0x759F18")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759F18", Offset = "0x759F18")]
	[Token(Token = "0x20002A4")]
	public class GetTriggerInfo : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA450", Offset = "0x7BA450")]
		[Token(Token = "0x4001742")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA464", Offset = "0x7BA464")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA464", Offset = "0x7BA464")]
		[Token(Token = "0x4001743")]
		[FieldOffset(Offset = "0x58")]
		public FsmString physicsMaterialName;

		[Token(Token = "0x6000D27")]
		[Address(RVA = "0xA370D8", Offset = "0xA370D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObjectHit = 0;\n\tthis.physicsMaterialName = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObjectHit = null;
			physicsMaterialName = null;
		}

		[Token(Token = "0x6000D28")]
		[Address(RVA = "0xA370E0", Offset = "0xA370E0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F036D0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E1E]) = v38;\nL_0013:\n\tv39 = this.fsm;\n\tgoto L_0026;\n\tv75 = *([v44 @ X0_v6+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0026;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv58 = UnityEngine.Object::op_Equality(v39.<TriggerCollider>k__BackingField, 0);\n\tv100 = v58 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_004F;\n\tv70 = this.fsm;\n\tv59 = UnityEngine.Component::get_gameObject(v70.<TriggerCollider>k__BackingField);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v59);\n\tv71 = this.fsm;\n\tv68 = this.physicsMaterialName;\n\tv90 = UnityEngine.Collider::get_material(v71.<TriggerCollider>k__BackingField);\n\tv61 = UnityEngine.Object::get_name(v90);\n\tv68.value = v61;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreTriggerInfo()
		{
			Fsm fsm = Fsm;
			if (!(fsm.TriggerCollider == null))
			{
				Fsm fsm2 = Fsm;
				GameObject gameObject = fsm2.TriggerCollider.gameObject;
				gameObjectHit.Value = gameObject;
				Fsm fsm3 = Fsm;
				FsmString fsmString = physicsMaterialName;
				PhysicMaterial material = fsm3.TriggerCollider.material;
				string value = material.name;
				fsmString.Value = value;
			}
		}

		[Token(Token = "0x6000D29")]
		[Address(RVA = "0xA371C8", Offset = "0xA371C8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTriggerInfo::StoreTriggerInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreTriggerInfo();
			Finish();
		}

		[Token(Token = "0x6000D2A")]
		[Address(RVA = "0xA371F0", Offset = "0xA371F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetTriggerInfo()
		{
		}
	}
}
