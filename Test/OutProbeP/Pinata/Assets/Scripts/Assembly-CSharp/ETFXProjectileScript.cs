using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200000C")]
public class ETFXProjectileScript : MonoBehaviour
{
	[Token(Token = "0x400003F")]
	[FieldOffset(Offset = "0x18")]
	public GameObject impactParticle;

	[Token(Token = "0x4000040")]
	[FieldOffset(Offset = "0x20")]
	public GameObject projectileParticle;

	[Token(Token = "0x4000041")]
	[FieldOffset(Offset = "0x28")]
	public GameObject muzzleParticle;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x763DC0", Offset = "0x763DC0")]
	[Token(Token = "0x4000042")]
	[FieldOffset(Offset = "0x30")]
	public float colliderRadius;

	[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x763DF8", Offset = "0x763DF8")]
	[Token(Token = "0x4000043")]
	[FieldOffset(Offset = "0x34")]
	public float collideOffset;

	[Token(Token = "0x6000043")]
	[Address(RVA = "0xA03714", Offset = "0xA03714", Length = "0x214")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EA7E80]);\n\tv37 = *([v36 @ X8_v13]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021C71]) = v56;\nL_001F:\n\tv60 = UnityEngine.Component::get_transform(this);\n\tv63 = UnityEngine.Transform::get_position(v60);\n\tv118 = UnityEngine.Component::get_transform(this);\n\tv164 = UnityEngine.Transform::get_rotation(v118);\n\tgoto L_0050;\n\tv246 = *([v242 @ X0_v11+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_0050;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v242, v163, v40, v41, v42, v43, v44, v45, v164, v238, v239, v240, v50, v51, v52, v53);\nL_0050:\n\tv119 = UnityEngine.Object::Instantiate(this.projectileParticle, v63, v164);\n\tthis.projectileParticle = v119;\n\tv255 = UnityEngine.GameObject::get_transform(v119);\n\tv155 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::set_parent(v255, v155);\n\tv223 = UnityEngine.Object::op_Implicit(this.muzzleParticle);\n\tv226 = v223 == 0;\n\tif (v226) goto L_00B8;\n\tv120 = UnityEngine.Component::get_transform(this);\n\tv111 = UnityEngine.Transform::get_position(v120);\n\tv121 = UnityEngine.Component::get_transform(this);\n\tv265 = UnityEngine.Transform::get_rotation(v121);\n\tgoto L_0096;\n\tv277 = *([v269 @ X0_v25+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_0096;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v269, v264, v65, v41, v42, v43, v44, v45, v265, v266, v267, v268, v77, v75, v73, v53);\nL_0096:\n\tv222 = UnityEngine.Object::Instantiate(this.muzzleParticle, v111, v265);\n\tthis.muzzleParticle = v222;\n\tUnityEngine.Object::Destroy(v222, 1.5f);\n\treturn;\nL_00B8:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Quaternion rotation = transform2.rotation;
		Transform transform3 = (projectileParticle = UnityEngine.Object.Instantiate(projectileParticle, position, rotation)).transform;
		Transform parent = base.transform;
		transform3.parent = parent;
		if ((bool)muzzleParticle)
		{
			Transform transform4 = base.transform;
			Vector3 position2 = transform4.position;
			Transform transform5 = base.transform;
			Quaternion rotation2 = transform5.rotation;
			UnityEngine.Object.Destroy(muzzleParticle = UnityEngine.Object.Instantiate(muzzleParticle, position2, rotation2), 1.5f);
		}
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0xA03928", Offset = "0xA03928", Length = "0x638")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0027;\n\tv44 = *([1EEF9B0]);\n\tv45 = *([v44 @ X8_v49]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([2021C72]) = v64;\nL_0027:\n\tv72 = 0;\n\tv78 = UnityEngine.Component::GetComponent(this);\n\tv81 = UnityEngine.Rigidbody::get_velocity(v78);\n\tv350 = 0x158AD58(&v81 @ V0_v5 (UnityEngine.Vector3), 0, v48, v49, v50, v51, v52, v53, v81, v81.y, v81.z, v191, v143, v139, v60, v61);\n\tv234 = v81 == 0;\n\tif (v234) goto L_0071;\n\tv423 = UnityEngine.Component::get_transform(this);\n\tv301 = UnityEngine.Component::GetComponent(this);\n\tv81 = UnityEngine.Rigidbody::get_velocity(v301);\n\tgoto L_0065;\n\tv645 = *([v632 @ X0_v109+E0]);\n\tv646 = v645 == 0;\n\tv647 = ~v646;\n\tif (v647) goto L_0065;\n\tv649 = \"il2cpp_codegen_runtime_class_init\"(v632, v496, v48, v49, v50, v51, v52, v53, v623, v628, v629, v57, v58, v59, v60, v61);\nL_0065:\n\tv432 = UnityEngine.Quaternion::LookRotation(v81);\n\tv191 = v432.w;\n\tUnityEngine.Transform::set_rotation(v423, v432);\nL_0071:\n\tv302 = UnityEngine.Component::get_transform(this);\n\tv512 = UnityEngine.Component::GetComponent(v302);\n\tgoto L_0088;\n\tv636 = *([v336 @ X8_v7+E0]);\n\tv637 = v636 == 0;\n\tv638 = ~v637;\n\tif (v638) goto L_0088;\n\tv654 = v336;\n\tv640 = \"il2cpp_codegen_runtime_class_init\"(v654, v511, v48, v49, v50, v51, v52, v53, v275, v268, v260, v191, v58, v59, v60, v61);\nL_0088:\n\tv644 = UnityEngine.Object::op_Implicit(v512);\n\tv656 = v644 == 0;\n\tif (v656) goto L_0099;\n\tv303 = UnityEngine.Component::get_transform(this);\n\tv304 = UnityEngine.Component::GetComponent(v303);\n\tv660 = UnityEngine.SphereCollider::get_radius(v304);\n\tgoto L_009C;\nL_0099:\n\tv212 = this.colliderRadius;\nL_009C:\n\tv305 = UnityEngine.Component::get_transform(this);\n\tv306 = UnityEngine.Component::GetComponent(v305);\n\tv81 = UnityEngine.Rigidbody::get_velocity(v306);\n\tv270 = v81.y;\n\tv262 = v81.z;\n\tv307 = UnityEngine.Component::get_transform(this);\n\tv308 = UnityEngine.Component::GetComponent(v307);\n\tv669 = UnityEngine.Rigidbody::get_useGravity(v308);\n\tv671 = v669 == 0;\n\tif (v671) goto L_00EB;\n\tv81 = UnityEngine.Physics::get_gravity();\n\tv707 = UnityEngine.Time::get_deltaTime();\n\tgoto L_00D7;\n\tv715 = *([v711 @ X0_v95+E0]);\n\tv716 = v715 == 0;\n\tv717 = ~v716;\n\tif (v717) goto L_00D7;\n\tv719 = \"il2cpp_codegen_runtime_class_init\"(v711, v668, v48, v49, v50, v51, v52, v53, v707, v704, v705, v191, v58, v59, v60, v61);\nL_00D7:\n\tv81 = UnityEngine.Vector3::op_Multiply(v81, v707);\n\tv81 = UnityEngine.Vector3::op_Addition(v81, v81);\n\tv270 = v81.y;\n\tv262 = v81.z;\nL_00EB:\n\tv703 = 0x158A710(&v690 @ stack_-D0_v6 (UnityEngine.Vector3), 0, v48, v49, v50, v51, v52, v53, v81, v270, v262, v191, v81.y, v81.z, v60, v61);\n\tv309 = UnityEngine.Component::get_transform(this);\n\tv310 = UnityEngine.Component::GetComponent(v309);\n\tv81 = UnityEngine.Rigidbody::get_velocity(v310);\n\tv735 = 0x158AD58(&v81 @ V0_v5 (UnityEngine.Vector3), 0, v48, v49, v50, v51, v52, v53, v81, v81.y, v81.z, v191, v81.y, v81.z, v60, v61);\n\tv279 = UnityEngine.Time::get_deltaTime();\n\tv311 = UnityEngine.Component::get_transform(this);\n\tv739 = v81 * v279;\n\tv81 = UnityEngine.Transform::get_position(v311);\n\t// 280 MakeStruct v123 @ AGGA03C44_2_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v81 @ V0_v5 (UnityEngine.Vector3), v270 @ V1_v7 (System.Single), v262 @ V2_v7 (System.Single)\n\tv748 = UnityEngine.Physics::SphereCast(v81, v212, v123, &v72 @ stack_-C0_v1 (UnityEngine.RaycastHit), v739);\n\tv750 = v748 == 0;\n\tif (v750) goto L_022F;\n\tv753 = UnityEngine.Component::get_transform(this);\n\tv791 = 0x164C878(&v72 @ stack_-C0_v1 (UnityEngine.RaycastHit), 0, v48, v49, v50, v51, v52, v53, v81, v81.y, v81.z, v212, v81, v270, v262, v739);\n\tv793 = 0x164C884(&v72 @ stack_-C0_v1 (UnityEngine.RaycastHit), 0, v48, v49, v50, v51, v52, v53, v81, v81.y, v81.z, v212, v81, v270, v262, v739);\n\tgoto L_0140;\n\tv800 = *([v796 @ X0_v49+E0]);\n\tv801 = v800 == 0;\n\tv802 = ~v801;\n\tif (v802) goto L_0140;\n\tv804 = \"il2cpp_codegen_runtime_class_init\"(v796, v497, v48, v49, v50, v51, v52, v53, v740, v741, v742, v746, v743, v744, v130, v128);\nL_0140:\n\tv81 = UnityEngine.Vector3::op_Multiply(v81, this.collideOffset);\n\tv81 = UnityEngine.Vector3::op_Addition(v81, v81);\n\tUnityEngine.Transform::set_position(v753, v81);\n\tv312 = UnityEngine.Component::get_transform(this);\n\tv81 = UnityEngine.Transform::get_position(v312);\n\t*([v34 @ X29_v1-34]) = v81;\n\tv81 = UnityEngine.Vector3::get_up();\n\tv833 = 0x164C884(&v72 @ stack_-C0_v1 (UnityEngine.RaycastHit), 0, v48, v49, v50, v51, v52, v53, v81, v81.y, v81.z, v81, v81.y, v81.z, v262, v739);\n\tgoto L_0184;\n\tv841 = *([v837 @ X0_v59+E0]);\n\tv842 = v841 == 0;\n\tv843 = ~v842;\n\tif (v843) goto L_0184;\n\tv845 = \"il2cpp_codegen_runtime_class_init\"(v837, v829, v48, v49, v50, v51, v52, v53, v825, v826, v827, v193, v144, v140, v130, v128);\nL_0184:\n\tv855 = UnityEngine.Quaternion::FromToRotation(v81, v81);\n\tgoto L_0198;\n\tv863 = *([v859 @ X0_v62+E0]);\n\tv864 = v863 == 0;\n\tv865 = ~v864;\n\tif (v865) goto L_0198;\n\tv867 = \"il2cpp_codegen_runtime_class_init\"(v859, v829, v48, v49, v50, v51, v52, v53, v855, v856, v857, v858, v852, v853, v130, v128);\nL_0198:\n\tv81 = *([v34 @ X29_v1-34]);\n\t// 417 MakeStruct v102 @ AGGA03DE0_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v34 @ X29_v1-34], v81.y (System.Single), v81.z (System.Single)\n\tv874 = UnityEngine.Object::Instantiate(this.impactParticle, v102, v855);\n\tv313 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv414 = v313.Length;\n\tv888 = v313.Length < 2;\n\tif (v888) goto L_020A;\nL_01BE:\n\tv926 = v89 < v414;\n\tv247 = ~v926;\n\tif (v247) goto L_0231;\n\tv314 = UnityEngine.Component::get_gameObject(v313[v89 @ X24_v8 (System.Int32)]);\n\tv315 = UnityEngine.Object::get_name(v314);\n\tv941 = System.String::Contains(v315, \"Trail\");\n\tv943 = v941 == 0;\n\tif (v943) goto L_01F7;\n\tv316 = UnityEngine.Component::get_transform(v313[v89 @ X24_v8 (System.Int32)]);\n\tUnityEngine.Transform::SetParent(v316, 0);\n\tv959 = UnityEngine.Component::get_gameObject(v313[v89 @ X24_v8 (System.Int32)]);\n\tgoto L_01F6;\n\tv963 = *([v953 @ X8_v33+E0]);\n\tv964 = v963 == 0;\n\tv965 = ~v964;\n\tif (v965) goto L_01F6;\n\tv968 = v953;\n\tv967 = \"il2cpp_codegen_runtime_class_init\"(v968, v958, v945, v49, v50, v51, v52, v53, v282, v273, v265, v194, v145, v141, v131, v128);\nL_01F6:\n\tUnityEngine.Object::Destroy(v959, 2f);\nL_01F7:\n\tv414 = v313.Length;\n\tv89 = v89 + 1;\n\tv893 = v89 < v313.Length;\n\tif (v893) goto L_01BE;\nL_020A:\n\tgoto L_0213;\n\tv927 = *([v914 @ X0_v69+E0]);\n\tv928 = v927 == 0;\n\tv929 = ~v928;\n\tif (v929) goto L_0213;\n\tv931 = \"il2cpp_codegen_runtime_class_init\"(v914, v906, v754, v49, v50, v51, v52, v53, v904, v273, v265, v194, v145, v141, v131, v128);\nL_0213:\n\tUnityEngine.Object::Destroy(this.projectileParticle, 3f);\n\tUnityEngine.Object::Destroy(v874, 3.5f);\n\tv785 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.Object::Destroy(v785);\nL_022F:\n\treturn;\n\tv347 = new System.NullReferenceException();\nL_0231:\n\tv416 = new System.IndexOutOfRangeException();\n\tthrow v416;\n\tthrow System.NullReferenceException;\n// 416 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void FixedUpdate()
	{
		//IL_03ee: Expected O, but got I
		//IL_0403: Expected F4, but got I
		object obj2 = default(object);
		object obj = obj2;
		RaycastHit hitInfo = default(RaycastHit);
		Rigidbody component = GetComponent<Rigidbody>();
		Vector3 velocity = component.velocity;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
		if (velocity.x != 0f)
		{
			Transform transform = base.transform;
			Rigidbody component2 = GetComponent<Rigidbody>();
			velocity = component2.velocity;
			Quaternion rotation = Quaternion.LookRotation(velocity);
			float w = rotation.w;
			transform.rotation = rotation;
		}
		Transform transform2 = base.transform;
		SphereCollider component3 = transform2.GetComponent<SphereCollider>();
		float radius2;
		if ((bool)component3)
		{
			Transform transform3 = base.transform;
			SphereCollider component4 = transform3.GetComponent<SphereCollider>();
			float radius = component4.radius;
			radius2 = radius;
		}
		else
		{
			radius2 = colliderRadius;
		}
		Transform transform4 = base.transform;
		Rigidbody component5 = transform4.GetComponent<Rigidbody>();
		velocity = component5.velocity;
		float y = velocity.y;
		float z = velocity.z;
		Transform transform5 = base.transform;
		Rigidbody component6 = transform5.GetComponent<Rigidbody>();
		bool useGravity = component6.useGravity;
		bool flag = !useGravity;
		Vector3 vector = velocity;
		if (!flag)
		{
			velocity = Physics.gravity;
			float deltaTime = Time.deltaTime;
			velocity *= deltaTime;
			velocity += velocity;
			y = velocity.y;
			z = velocity.z;
			vector = velocity;
			float w = velocity.x;
		}
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
		Transform transform6 = base.transform;
		Rigidbody component7 = transform6.GetComponent<Rigidbody>();
		velocity = component7.velocity;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
		float deltaTime2 = Time.deltaTime;
		Transform transform7 = base.transform;
		float maxDistance = velocity.x * deltaTime2;
		velocity = transform7.position;
		Vector3 direction = default(Vector3);
		direction.x = velocity.x;
		direction.y = y;
		direction.z = z;
		if (!Physics.SphereCast(velocity, radius2, direction, out hitInfo, maxDistance))
		{
			return;
		}
		Transform transform8 = base.transform;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
		velocity *= collideOffset;
		velocity += velocity;
		transform8.position = velocity;
		Transform transform9 = base.transform;
		velocity = transform9.position;
		velocity = Vector3.up;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
		Quaternion rotation2 = Quaternion.FromToRotation(velocity, velocity);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
		velocity = (Vector3)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
		Vector3 position = default(Vector3);
		position.x = 0f;
		position.y = velocity.y;
		position.z = velocity.z;
		GameObject obj3 = UnityEngine.Object.Instantiate(impactParticle, position, rotation2);
		ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
		int num = componentsInChildren.Length;
		if (componentsInChildren.Length >= 2)
		{
			int num2 = 1;
			do
			{
				if (num2 < num)
				{
					GameObject gameObject = componentsInChildren[num2].gameObject;
					string text = gameObject.name;
					if (text.Contains("Trail"))
					{
						Transform transform10 = componentsInChildren[num2].transform;
						transform10.SetParent(null);
						GameObject obj4 = componentsInChildren[num2].gameObject;
						UnityEngine.Object.Destroy(obj4, 2f);
					}
					num = componentsInChildren.Length;
					num2++;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			while (num2 < componentsInChildren.Length);
		}
		UnityEngine.Object.Destroy(projectileParticle, 3f);
		UnityEngine.Object.Destroy(obj3, 3.5f);
		GameObject obj5 = base.gameObject;
		UnityEngine.Object.Destroy(obj5);
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0xA03F60", Offset = "0xA03F60", Length = "0x18")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.colliderRadius = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ETFXProjectileScript()
	{
		colliderRadius = 1f;
	}
}
