using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A5CC", Offset = "0x75A5CC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A5CC", Offset = "0x75A5CC")]
	[Token(Token = "0x20002B9")]
	public class GetCollision2dInfo : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBDA0", Offset = "0x7BBDA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBDA0", Offset = "0x7BBDA0")]
		[Token(Token = "0x40017B3")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBDF0", Offset = "0x7BBDF0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBDF0", Offset = "0x7BBDF0")]
		[Token(Token = "0x40017B4")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 relativeVelocity;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBE40", Offset = "0x7BBE40")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBE40", Offset = "0x7BBE40")]
		[Token(Token = "0x40017B5")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat relativeSpeed;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBE90", Offset = "0x7BBE90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBE90", Offset = "0x7BBE90")]
		[Token(Token = "0x40017B6")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 contactPoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBEE0", Offset = "0x7BBEE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBEE0", Offset = "0x7BBEE0")]
		[Token(Token = "0x40017B7")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 contactNormal;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBF30", Offset = "0x7BBF30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBF30", Offset = "0x7BBF30")]
		[Token(Token = "0x40017B8")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt shapeCount;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBF80", Offset = "0x7BBF80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBF80", Offset = "0x7BBF80")]
		[Token(Token = "0x40017B9")]
		[FieldOffset(Offset = "0x80")]
		public FsmString physics2dMaterialName;

		[Token(Token = "0x6000DA6")]
		[Address(RVA = "0xB84390", Offset = "0xB84390", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.physics2dMaterialName = 0;\n\tthis.relativeSpeed = 0;\n\tthis.contactNormal = 0;\n\tthis.gameObjectHit = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			physics2dMaterialName = null;
			relativeSpeed = null;
			contactNormal = null;
			gameObjectHit = null;
		}

		[Token(Token = "0x6000DA7")]
		[Address(RVA = "0xB843A4", Offset = "0xB843A4", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EB6560]);\n\tv27 = *([v26 @ X8_v34]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20229DC]) = v46;\nL_0018:\n\tv48 = this.fsm;\n\tv51 = v48.<Collision2DInfo>k__BackingField == 0;\n\tif (v51) goto L_010D;\n\tv109 = UnityEngine.Collision2D::get_gameObject(v48.<Collision2DInfo>k__BackingField);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v109);\n\tv143 = this.fsm;\n\tv158 = this.relativeSpeed;\n\tv89 = UnityEngine.Collision2D::get_relativeVelocity(v143.<Collision2DInfo>k__BackingField);\n\tv111 = 0x1588E30(&v89 @ V0_v5 (UnityEngine.Vector2), 0, 0, v31, v32, v33, v34, v35, v89, v89.y, v38, v39, v40, v41, v42, v43);\n\tv158.value = v89;\n\tv144 = this.fsm;\n\tv159 = this.relativeVelocity;\n\tv89 = UnityEngine.Collision2D::get_relativeVelocity(v144.<Collision2DInfo>k__BackingField);\n\tgoto L_0055;\n\tv312 = *([v308 @ X0_v17+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_0055;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v308, v99, v94, v31, v32, v33, v34, v35, v305, v306, v38, v39, v40, v41, v42, v43);\nL_0055:\n\tv90 = UnityEngine.Vector2::op_Implicit(v89);\n\tv159.value = v90;\n\tv159.value.y = v90.y;\n\tv159.value.z = v90.z;\n\tv146 = this.fsm;\n\tv62 = this.physics2dMaterialName;\n\tv221 = UnityEngine.Collision2D::get_collider(v146.<Collision2DInfo>k__BackingField);\n\tv321 = UnityEngine.Collider2D::get_sharedMaterial(v221);\n\tgoto L_007B;\n\tv328 = *([v324 @ X8_v15+E0]);\n\tv329 = v328 == 0;\n\tv330 = ~v329;\n\tif (v330) goto L_007B;\n\tv335 = v324;\n\tv332 = \"il2cpp_codegen_runtime_class_init\"(v335, v320, v94, v31, v32, v33, v34, v35, v90, v85, v64, v39, v40, v41, v42, v43);\nL_007B:\n\tv113 = UnityEngine.Object::op_Inequality(v321, 0);\n\tv337 = v113 == 0;\n\tif (v337) goto L_FFFFFFFF;\n\tv147 = this.fsm;\n\tv223 = UnityEngine.Collision2D::get_collider(v147.<Collision2DInfo>k__BackingField);\n\tv224 = UnityEngine.Collider2D::get_sharedMaterial(v223);\n\tv116 = UnityEngine.Object::get_name(v224);\n\tv341 = v62 == 0;\n\tv130 = ~v341;\n\tif (v130) goto L_0098;\n\tgoto L_010F;\nL_0098:\n\tv62.value = v116;\n\tv149 = this.fsm;\n\tv161 = this.shapeCount;\n\tv226 = UnityEngine.Collision2D::get_collider(v149.<Collision2DInfo>k__BackingField);\n\tv117 = UnityEngine.Collider2D::get_shapeCount(v226);\n\tv161.value = v117;\n\tv150 = this.fsm;\n\tv118 = UnityEngine.Collision2D::get_contacts(v150.<Collision2DInfo>k__BackingField);\n\tv182 = v118 == 0;\n\tif (v182) goto L_010D;\n\tv151 = this.fsm;\n\tv119 = UnityEngine.Collision2D::get_contacts(v151.<Collision2DInfo>k__BackingField);\n\tv183 = v119.Length == 0;\n\tif (v183) goto L_010D;\n\tv152 = this.fsm;\n\tv162 = this.contactPoint;\n\tv230 = UnityEngine.Collision2D::get_contacts(v152.<Collision2DInfo>k__BackingField);\n\tv299 = v230.Length == 0;\n\tif (v299) goto L_0110;\n\tv342 = v230 + 0x20;\n\tv343 = 0x163E178(v342, 0, 0, v31, v32, v33, v34, v35, v90, v90.y, v90.z, v39, v40, v41, v42, v43);\n\tgoto L_00E0;\n\tv348 = *([v344 @ X0_v38+E0]);\n\tv349 = v348 == 0;\n\tv350 = ~v349;\n\tif (v350) goto L_00E0;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v344, v106, v95, v31, v32, v33, v34, v35, v90, v85, v64, v39, v40, v41, v42, v43);\nL_00E0:\n\t// 224 MakeStruct v57 @ AGGB8462C_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v90 @ V0_v8 (UnityEngine.Vector3), v90.y (System.Single)\n\tv91 = UnityEngine.Vector2::op_Implicit(v57);\n\tv162.value = v91;\n\tv162.value.y = v91.y;\n\tv162.value.z = v91.z;\n\tv154 = this.fsm;\n\tv141 = this.contactNormal;\n\tv232 = UnityEngine.Collision2D::get_contacts(v154.<Collision2DInfo>k__BackingField);\n\tv300 = v232.Length == 0;\n\tif (v300) goto L_0110;\n\tv356 = v232 + 0x20;\n\tv357 = 0x163E180(v356, 0, 0, v31, v32, v33, v34, v35, v91, v91.y, v91.z, v39, v40, v41, v42, v43);\n\t// 251 MakeStruct v54 @ AGGB84674_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v91 @ V0_v10 (UnityEngine.Vector3), v91.y (System.Single)\n\tv92 = UnityEngine.Vector2::op_Implicit(v54);\n\tv141.value = v92;\n\tv141.value.y = v92.y;\n\tv141.value.z = v92.z;\nL_010D:\n\treturn;\nL_010F:\n\tv253 = new System.NullReferenceException();\nL_0110:\n\tv302 = new System.IndexOutOfRangeException();\n\tthrow v302;\n\treturn;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreCollisionInfo()
		{
			//IL_0340: Expected O, but got I
			//IL_041e: Expected O, but got I
			Fsm fsm = Fsm;
			if (fsm.Collision2DInfo == null)
			{
				return;
			}
			GameObject gameObject = fsm.Collision2DInfo.gameObject;
			gameObjectHit.Value = gameObject;
			Fsm fsm2 = Fsm;
			FsmFloat fsmFloat = relativeSpeed;
			Vector2 vector = fsm2.Collision2DInfo.relativeVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588E30 (inside UnityEngine.Vector2::Scale +0xC8)");
			fsmFloat.Value = vector.x;
			Fsm fsm3 = Fsm;
			FsmVector3 fsmVector = relativeVelocity;
			vector = fsm3.Collision2DInfo.relativeVelocity;
			Vector3 vector2 = (fsmVector.value = vector);
			fsmVector.value.y = vector2.y;
			fsmVector.value.z = vector2.z;
			Fsm fsm4 = Fsm;
			FsmString fsmString = physics2dMaterialName;
			Collider2D collider = fsm4.Collision2DInfo.collider;
			PhysicsMaterial2D sharedMaterial = collider.sharedMaterial;
			string value;
			if (sharedMaterial != null)
			{
				Fsm fsm5 = Fsm;
				Collider2D collider2 = fsm5.Collision2DInfo.collider;
				PhysicsMaterial2D sharedMaterial2 = collider2.sharedMaterial;
				value = sharedMaterial2.name;
				if (fsmString == null)
				{
					NullReferenceException ex = new NullReferenceException();
					goto IL_049e;
				}
			}
			else
			{
				value = "";
			}
			fsmString.Value = value;
			Fsm fsm6 = Fsm;
			FsmInt fsmInt = shapeCount;
			Collider2D collider3 = fsm6.Collision2DInfo.collider;
			int value2 = collider3.shapeCount;
			fsmInt.Value = value2;
			Fsm fsm7 = Fsm;
			ContactPoint2D[] contacts = fsm7.Collision2DInfo.contacts;
			if (contacts == null)
			{
				return;
			}
			Fsm fsm8 = Fsm;
			ContactPoint2D[] contacts2 = fsm8.Collision2DInfo.contacts;
			if (contacts2.Length == 0)
			{
				return;
			}
			Fsm fsm9 = Fsm;
			FsmVector3 fsmVector2 = contactPoint;
			ContactPoint2D[] contacts3 = fsm9.Collision2DInfo.contacts;
			if (contacts3.Length != 0)
			{
				object obj = (long)(IntPtr)contacts3 + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163E178 (inside UnityEngine.Physics2D::get_queriesHitTriggers +0x34)");
				Vector2 vector3 = default(Vector2);
				vector3.x = vector2.x;
				vector3.y = vector2.y;
				Vector3 vector4 = (fsmVector2.value = vector3);
				fsmVector2.value.y = vector4.y;
				fsmVector2.value.z = vector4.z;
				Fsm fsm10 = Fsm;
				FsmVector3 fsmVector3 = contactNormal;
				ContactPoint2D[] contacts4 = fsm10.Collision2DInfo.contacts;
				if (contacts4.Length != 0)
				{
					object obj2 = (long)(IntPtr)contacts4 + 32L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163E180 (inside UnityEngine.Physics2D::get_queriesHitTriggers +0x3C)");
					Vector2 vector5 = default(Vector2);
					vector5.x = vector4.x;
					vector5.y = vector4.y;
					Vector3 vector6 = (fsmVector3.value = vector5);
					fsmVector3.value.y = vector6.y;
					fsmVector3.value.z = vector6.z;
					return;
				}
			}
			goto IL_049e;
			IL_049e:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x6000DA8")]
		[Address(RVA = "0xB846B4", Offset = "0xB846B4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetCollision2dInfo::StoreCollisionInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreCollisionInfo();
			Finish();
		}

		[Token(Token = "0x6000DA9")]
		[Address(RVA = "0xB846DC", Offset = "0xB846DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetCollision2dInfo()
		{
		}
	}
}
