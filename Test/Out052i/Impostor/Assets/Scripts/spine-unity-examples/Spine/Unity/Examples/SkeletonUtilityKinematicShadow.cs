using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000063")]
	public class SkeletonUtilityKinematicShadow : MonoBehaviour
	{
		[Token(Token = "0x2000064")]
		private struct TransformPair
		{
			[Token(Token = "0x400022E")]
			[FieldOffset(Offset = "0x0")]
			public Transform dest;

			[Token(Token = "0x400022F")]
			[FieldOffset(Offset = "0x8")]
			public Transform src;
		}

		[Token(Token = "0x2000065")]
		public enum PhysicsSystem
		{
			[Token(Token = "0x4000231")]
			Physics2D = 0,
			[Token(Token = "0x4000232")]
			Physics3D = 1
		}

		[Tooltip("If checked, the hinge chain can inherit your root transform's velocity or position/rotation changes.")]
		[Token(Token = "0x4000228")]
		[FieldOffset(Offset = "0x20")]
		public bool detachedShadow;

		[Token(Token = "0x4000229")]
		[FieldOffset(Offset = "0x28")]
		public Transform parent;

		[Token(Token = "0x400022A")]
		[FieldOffset(Offset = "0x30")]
		public bool hideShadow;

		[Token(Token = "0x400022B")]
		[FieldOffset(Offset = "0x34")]
		public PhysicsSystem physicsSystem;

		[Token(Token = "0x400022C")]
		[FieldOffset(Offset = "0x38")]
		private GameObject shadowRoot;

		[Token(Token = "0x400022D")]
		[FieldOffset(Offset = "0x40")]
		private readonly List<TransformPair> shadowTable;

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0x151DC14", Offset = "0x151DC14", Length = "0x640")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0049;\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv94 = Il2CppMethodInfo;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv344 = Il2CppMethodInfo;\n\tv345 = \"il2cpp_codegen_initialize_runtime_metadata\"(v344, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv403 = Il2CppMethodInfo;\n\tv404 = \"il2cpp_codegen_initialize_runtime_metadata\"(v403, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv406 = Il2CppMethodInfo;\n\tv407 = \"il2cpp_codegen_initialize_runtime_metadata\"(v406, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv494 = Il2CppMethodInfo;\n\tv495 = \"il2cpp_codegen_initialize_runtime_metadata\"(v494, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv498 = UnityEngine.Object;\n\tv499 = \"il2cpp_codegen_initialize_runtime_metadata\"(v498, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv501 = UnityEngine.Rigidbody2D;\n\tv502 = \"il2cpp_codegen_initialize_runtime_metadata\"(v501, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv504 = UnityEngine.Rigidbody;\n\tv505 = \"il2cpp_codegen_initialize_runtime_metadata\"(v504, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv507 = System.Type;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v507, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = 1;\n\t*([1A37AA3]) = v66;\nL_0049:\n\tv71 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0054;\n\tv83 = v75;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v83, v70, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\nL_0054:\n\tv88 = UnityEngine.Object::Instantiate(v71);\n\tthis.shadowRoot = v88;\n\tv99 = UnityEngine.GameObject::GetComponent(v88);\n\tUnityEngine.Object::Destroy(v99);\n\tv409 = UnityEngine.GameObject::get_transform(this.shadowRoot);\n\tv291 = UnityEngine.Component::get_transform(this);\n\tv258 = UnityEngine.Transform::get_position(v291);\n\tUnityEngine.Transform::set_position(v409, v258);\n\tv292 = UnityEngine.Component::get_transform(this);\n\tv263 = UnityEngine.Transform::get_rotation(v292);\n\tUnityEngine.Transform::set_rotation(v409, v263);\n\tv515 = UnityEngine.Component::get_transform(this);\n\tgoto L_009B;\n\tv520 = UnityEngine.Vector3;\n\tv521 = \"il2cpp_codegen_initialize_runtime_metadata\"(v520, v281, v49, v50, v51, v52, v53, v54, v263, v256, v249, v239, v59, v60, v61, v62);\n\tv522 = 1;\n\t*([1A37AC6]) = v522;\nL_009B:\n\tv259 = UnityEngine.Transform::TransformPoint(v515, v326.rightVector);\n\tv293 = UnityEngine.Component::get_transform(this);\n\tv532 = UnityEngine.Transform::get_position(v293);\n\tgoto L_00BD;\n\tv540 = System.Math;\n\tv541 = \"il2cpp_codegen_initialize_runtime_metadata\"(v540, v531, v49, v50, v51, v52, v53, v54, v532, v533, v534, v239, v59, v60, v61, v62);\n\tv544 = 1;\n\t*([1A357E4]) = v544;\nL_00BD:\n\tgoto L_00C3;\n\tv551 = \"il2cpp_codegen_runtime_class_init\"(v547, v531, v49, v50, v51, v52, v53, v54, v532, v533, v534, v239, v59, v60, v61, v62);\nL_00C3:\n\tgoto L_00D1;\n\tv558 = UnityEngine.Vector3;\n\tv559 = \"il2cpp_codegen_initialize_runtime_metadata\"(v558, v531, v49, v50, v51, v52, v53, v54, v532, v533, v534, v239, v59, v60, v61, v62);\n\tv562 = 1;\n\t*([1A35658]) = v562;\nL_00D1:\n\tUnityEngine.Transform::set_localScale(v409, v566.oneVector);\n\tv568 = ~this.detachedShadow;\n\tv569 = ~v568;\n\tif (v569) goto L_00F2;\n\tgoto L_00E0;\n\tv581 = \"il2cpp_codegen_runtime_class_init\"(v570, v565, v49, v50, v51, v52, v53, v54, v260, v253, v246, v239, v59, v60, v61, v62);\nL_00E0:\n\tv585 = UnityEngine.Object::op_Equality(this.parent, 0);\n\tv591 = v585 == 0;\n\tif (v591) goto L_00ED;\n\tv294 = UnityEngine.Component::get_transform(this);\n\tv597 = UnityEngine.Transform::get_root(v294);\n\tgoto L_00F0;\nL_00ED:\n\tv574 = this.parent;\nL_00F0:\n\tUnityEngine.Transform::set_parent(v409, v574);\nL_00F2:\n\tv580 = ~this.hideShadow;\n\tif (v580) goto L_0100;\n\tUnityEngine.Object::set_hideFlags(this.shadowRoot, 1);\nL_0100:\n\tv297 = UnityEngine.GameObject::GetComponentsInChildren(this.shadowRoot);\n\tv609 = v297.Length < 1;\n\tif (v609) goto L_0148;\n\tv611 = v532 - v259;\n\tv612 = v532.y - v259.y;\n\tv613 = v532.z - v259.z;\n\tv614 = v611 * v611;\n\tv615 = v612 * v612;\n\tv616 = v614 + v615;\n\tv617 = v613 * v613;\n\tv618 = v617 + v616;\n\tv216 = UnityEngine.Mathf::Sqrt(v618);\nL_012C:\n\tv657 = UnityEngine.Joint::get_connectedAnchor(v297[v230 @ X22_v16 (System.Int32)]);\n\tv633 = v216 * v657;\n\tv632 = v216 * v657.y;\n\tv631 = v216 * v657.z;\n\t// 308 MakeStruct v620 @ AGG1521FAC_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v633 @ V0_v16 (System.Single), v632 @ V1_v15 (System.Single), v631 @ V2_v13 (System.Single)\n\tUnityEngine.Joint::set_connectedAnchor(v297[v230 @ X22_v16 (System.Int32)], v620);\n\tv230 = v230 + 1;\n\tv621 = v230 < v297.Length;\n\tif (v621) goto L_012C;\nL_0148:\n\tv299 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv300 = UnityEngine.GameObject::GetComponentsInChildren(this.shadowRoot);\n\tv671 = v299.Length < 1;\n\tif (v671) goto L_022B;\nL_0171:\n\tv232 = v299[v129 @ X27_v6 (System.Int32)];\n\tv731 = UnityEngine.Component::get_gameObject(v299[v129 @ X27_v6 (System.Int32)]);\n\tv738 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0186;\n\tv744 = v739;\n\tv745 = \"il2cpp_codegen_runtime_class_init\"(v744, v737, v200, v104, v51, v52, v53, v54, v262, v255, v248, v239, v59, v60, v61, v62);\nL_0186:\n\tv749 = UnityEngine.Object::op_Equality(v731, v738);\n\tv751 = v749 == 0;\n\tv752 = ~v751;\n\tif (v752) goto L_0216;\n\tv754 = this.physicsSystem == 0;\n\tif (v754) goto L_FFFFFFFF;\n\tgoto L_0197;\nL_0197:\n\t;\n\tgoto L_019E;\n\tv821 = \"il2cpp_codegen_runtime_class_init\"(v818, v748, v201, v104, v51, v52, v53, v54, v262, v255, v248, v239, v59, v60, v61, v62);\nL_019E:\n\tv302 = System.Type::GetTypeFromHandle(*([v285 @ X9_v10]));\n\tv761 = v300.Length < 1;\n\tif (v761) goto L_0216;\nL_01BC:\n\tv122 = v300[v118 @ X28_v8 (System.Int32)];\n\tv839 = UnityEngine.Component::GetComponent(v300[v118 @ X28_v8 (System.Int32)], v302);\n\tgoto L_01CE;\n\tv842 = v335;\n\tv843 = \"il2cpp_codegen_runtime_class_init\"(v842, v837, v838, v104, v51, v52, v53, v54, v262, v255, v248, v239, v59, v60, v61, v62);\nL_01CE:\n\tv848 = UnityEngine.Object::op_Inequality(v839, 0);\n\tv850 = v848 == 0;\n\tif (v850) goto L_01DA;\n\tv853 = System.String::op_Equality(*([v122 @ X24_v9 (UnityEngine.Component)+20]), *([v232 @ X22_v12 (UnityEngine.Component)+20]));\n\tv858 = v853 == 0;\n\tv854 = ~v858;\n\tif (v854) goto L_01E9;\nL_01DA:\n\t;\n\tv118 = v118 + 1;\n\tv762 = v118 < v300.Length;\n\tif (v762) goto L_01BC;\n\tgoto L_0216;\nL_01E9:\n\tv127 = this.shadowTable;\n\tv861 = UnityEngine.Component::get_transform(v299[v129 @ X27_v6 (System.Int32)]);\n\tv304 = UnityEngine.Component::get_transform(v300[v118 @ X28_v8 (System.Int32)]);\n\tv336 = v127._items;\n\tv111 = v127._version + 1;\n\tv127._version = v111;\n\tv866 = v127._size < v336.Length;\n\tv792 = ~v866;\n\tif (v792) goto L_0215;\n\tv799 = v127._size + 1;\n\tv759 = v127._size << 4;\n\tv807 = v336 + v759;\n\tv127._size = v799;\n\t*([v807 @ X8_v48+20]) = v861;\n\tv336[v757 @ X10_v8 (System.Int32)].src = v304;\n\tgoto L_0216;\nL_0215:\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonUtilityKinematicShadow+TransformPair>::AddWithResize(v127, v861);\nL_0216:\n\t;\n\tv129 = v129 + 1;\n\tv691 = v129 < v299.Length;\n\tif (v691) goto L_0171;\nL_022B:\n\tSpine.Unity.Examples.SkeletonUtilityKinematicShadow::DestroyComponents(v300);\n\tv728 = UnityEngine.Component::GetC\n// ... truncated")]
		private void Start()
		{
			//IL_04fe: Expected O, but got I
			//IL_04fe: Expected O, but got I
			//IL_062d: Expected O, but got I
			GameObject original = base.gameObject;
			SkeletonUtilityKinematicShadow component = (shadowRoot = UnityEngine.Object.Instantiate(original)).GetComponent<SkeletonUtilityKinematicShadow>();
			UnityEngine.Object.Destroy(component);
			Transform transform = shadowRoot.transform;
			Transform transform2 = base.transform;
			Vector3 position = transform2.position;
			transform.position = position;
			Transform transform3 = base.transform;
			Quaternion rotation = transform3.rotation;
			transform.rotation = rotation;
			Transform transform4 = base.transform;
			Vector3 vector = transform4.TransformPoint(Vector3.right);
			Transform transform5 = base.transform;
			Vector3 position2 = transform5.position;
			transform.localScale = Vector3.one;
			if (!detachedShadow)
			{
				Transform transform7;
				if (parent == null)
				{
					Transform transform6 = base.transform;
					Transform root = transform6.root;
					transform7 = root;
				}
				else
				{
					transform7 = parent;
				}
				transform.parent = transform7;
			}
			if (hideShadow)
			{
				shadowRoot.hideFlags = HideFlags.HideInHierarchy;
			}
			Joint[] componentsInChildren = shadowRoot.GetComponentsInChildren<Joint>();
			if (componentsInChildren.Length >= 1)
			{
				float num = position2.x - vector.x;
				float num2 = position2.y - vector.y;
				float num3 = position2.z - vector.z;
				float num4 = num * num;
				float num5 = num2 * num2;
				float num6 = num4 + num5;
				float num7 = num3 * num3;
				float f = num7 + num6;
				float num8 = Mathf.Sqrt(f);
				int num9 = 0;
				Vector3 connectedAnchor2 = default(Vector3);
				do
				{
					Vector3 connectedAnchor = componentsInChildren[num9].connectedAnchor;
					float x = num8 * connectedAnchor.x;
					float y = num8 * connectedAnchor.y;
					float z = num8 * connectedAnchor.z;
					connectedAnchor2.x = x;
					connectedAnchor2.y = y;
					connectedAnchor2.z = z;
					componentsInChildren[num9].connectedAnchor = connectedAnchor2;
					num9++;
				}
				while (num9 < componentsInChildren.Length);
			}
			SkeletonUtilityBone[] componentsInChildren2 = GetComponentsInChildren<SkeletonUtilityBone>();
			SkeletonUtilityBone[] componentsInChildren3 = shadowRoot.GetComponentsInChildren<SkeletonUtilityBone>();
			if (componentsInChildren2.Length >= 1)
			{
				int num10 = 0;
				int num14 = default(int);
				do
				{
					Component component2 = componentsInChildren2[num10];
					GameObject gameObject = componentsInChildren2[num10].gameObject;
					GameObject gameObject2 = base.gameObject;
					if (!(gameObject == gameObject2))
					{
						object handle = ((physicsSystem == PhysicsSystem.Physics2D) ? typeof(Rigidbody2D) : typeof(Rigidbody));
						Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)handle);
						if (componentsInChildren3.Length >= 1)
						{
							int num11 = 0;
							do
							{
								Component component3 = componentsInChildren3[num11];
								Component component4 = componentsInChildren3[num11].GetComponent(typeFromHandle);
								if (component4 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X24_v9 (UnityEngine.Component)+20]");
									nint num12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X22_v12 (UnityEngine.Component)+20]");
									if ((string)num12 == (string)0)
									{
										List<TransformPair> list = shadowTable;
										Transform item = componentsInChildren2[num10].transform;
										Transform src = componentsInChildren3[num11].transform;
										TransformPair[] items = list._items;
										int version = list._version + 1;
										list._version = version;
										if (list.Count < items.Length)
										{
											int size = list.Count + 1;
											int num13 = list.Count << 4;
											object obj = (nint)items + num13;
											list._size = size;
											items[num14].src = src;
										}
										else
										{
											list.Add((TransformPair)item);
										}
										break;
									}
								}
								num11++;
							}
							while (num11 < componentsInChildren3.Length);
						}
					}
					num10++;
				}
				while (num10 < componentsInChildren2.Length);
			}
			DestroyComponents(componentsInChildren3);
			Joint[] componentsInChildren4 = GetComponentsInChildren<Joint>();
			DestroyComponents(componentsInChildren4);
			Rigidbody[] componentsInChildren5 = GetComponentsInChildren<Rigidbody>();
			DestroyComponents(componentsInChildren5);
			Collider[] componentsInChildren6 = GetComponentsInChildren<Collider>();
			DestroyComponents(componentsInChildren6);
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0x151E254", Offset = "0x151E254", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A37AA4]) = v41;\nL_0021:\n\tv54 = components.Length < 1;\n\tif (v54) goto L_0055;\n\tv56 = components.Length & 0xFFFFFFFF;\n\tv66 = v56 - 1;\nL_0030:\n\tgoto L_0034;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v175, v162, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0034:\n\tUnityEngine.Object::Destroy(components[v69 @ X21_v5 (System.Int32)]);\n\tv90 = v66 == v69;\n\tif (v90) goto L_0055;\n\tv69 = v69 + 1;\n\tv180 = v69 < components.Length;\n\tv130 = ~v180;\n\tv122 = ~v130;\n\tif (v122) goto L_0030;\n\tthrow System.IndexOutOfRangeException;\nL_0055:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DestroyComponents(Component[] components)
		{
			//IL_0038: Expected I4, but got I8
			if (components.Length < 1)
			{
				return;
			}
			int num = (int)(components.Length & 0xFFFFFFFFL);
			int num2 = num - 1;
			int num3 = 0;
			while (true)
			{
				UnityEngine.Object.Destroy(components[num3]);
				if (num2 != num3)
				{
					num3++;
					if (num3 >= components.Length)
					{
						throw new IndexOutOfRangeException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0x151E308", Offset = "0x151E308", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv190 = Il2CppMethodInfo;\n\tv191 = \"il2cpp_codegen_initialize_runtime_metadata\"(v190, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv245 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v245, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37AA5]) = v42;\nL_0021:\n\tv49 = this.physicsSystem == 0;\n\tif (v49) goto L_0049;\n\tv194 = UnityEngine.GameObject::GetComponent(this.shadowRoot);\n\tv160 = UnityEngine.Component::get_transform(this);\n\tv142 = UnityEngine.Transform::get_position(v160);\n\tUnityEngine.Rigidbody::MovePosition(v194, v142);\n\tv161 = UnityEngine.Component::get_transform(this);\n\tv255 = UnityEngine.Transform::get_rotation(v161);\n\tUnityEngine.Rigidbody::MoveRotation(v194, v255);\n\tgoto L_0077;\nL_0049:\n\tv197 = UnityEngine.GameObject::GetComponent(this.shadowRoot);\n\tv162 = UnityEngine.Component::get_transform(this);\n\tv143 = UnityEngine.Transform::get_position(v162);\n\t// 88 MakeStruct v114 @ AGG152240C_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v143 @ V0_v7 (UnityEngine.Vector3), v143.y (System.Single)\n\tUnityEngine.Rigidbody2D::MovePosition(v197, v114);\n\tv163 = UnityEngine.Component::get_transform(this);\n\tv257 = UnityEngine.Transform::get_rotation(v163);\n\tv269 = UnityEngine.Quaternion::Internal_ToEulerRad(v257);\n\tv275 = v269 * 57.29578f;\n\tv276 = v269.y * 57.29578f;\n\tv277 = v269.z * 57.29578f;\n\t// 111 MakeStruct v278 @ AGG1522448_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v275 @ V0_v10 (System.Single), v276 @ V1_v10 (System.Single), v277 @ V2_v10 (System.Single)\n\tv279 = UnityEngine.Quaternion::Internal_MakePositive(v278);\n\tUnityEngine.Rigidbody2D::MoveRotation(v197, v279.z);\nL_0077:\n\tv293 = this.shadowTable;\n\tv69 = v293._size < 1;\n\tif (v69) goto L_00BE;\nL_008C:\n\tv165 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonUtilityKinematicShadow+TransformPair>::get_Item(v293, v187);\n\tv146 = UnityEngine.Transform::get_localPosition(v187);\n\tUnityEngine.Transform::set_localPosition(v165, v146);\n\tv141 = UnityEngine.Transform::get_localRotation(v187);\n\tUnityEngine.Transform::set_localRotation(v165, v141);\n\tv187 = v187 + 1;\n\tv88 = v293._size == v187;\n\tif (v88) goto L_00BE;\n\tv293 = this.shadowTable;\n\tv300 = this.shadowTable == 0;\n\tv168 = ~v300;\n\tif (v168) goto L_008C;\n\tthrow System.NullReferenceException;\nL_00BE:\n\treturn;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			//IL_01f5: Expected O, but got I4
			//IL_0214: Expected O, but got I4
			if (physicsSystem != PhysicsSystem.Physics2D)
			{
				Rigidbody component = shadowRoot.GetComponent<Rigidbody>();
				Transform transform = base.transform;
				Vector3 position = transform.position;
				component.MovePosition(position);
				Transform transform2 = base.transform;
				Quaternion rotation = transform2.rotation;
				component.MoveRotation(rotation);
			}
			else
			{
				Rigidbody2D component2 = shadowRoot.GetComponent<Rigidbody2D>();
				Transform transform3 = base.transform;
				Vector3 position2 = transform3.position;
				Vector2 position3 = default(Vector2);
				position3.x = position2.x;
				position3.y = position2.y;
				component2.MovePosition(position3);
				Transform transform4 = base.transform;
				Quaternion rotation2 = transform4.rotation;
				Vector3 vector = Quaternion.Internal_ToEulerRad(rotation2);
				float x = vector.x * 57.29578f;
				float y = vector.y * 57.29578f;
				float z = vector.z * 57.29578f;
				Vector3 euler = default(Vector3);
				euler.x = x;
				euler.y = y;
				euler.z = z;
				component2.MoveRotation(Quaternion.Internal_MakePositive(euler).z);
			}
			List<TransformPair> list = shadowTable;
			if (list.Count < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				TransformPair transformPair = list[num];
				Vector3 localPosition = ((Transform)num).localPosition;
				((Transform)transformPair).localPosition = localPosition;
				Quaternion localRotation = ((Transform)num).localRotation;
				((Transform)transformPair).localRotation = localRotation;
				num++;
				if (list.Count != num)
				{
					list = shadowTable;
					if (shadowTable == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0x151E4F4", Offset = "0x151E4F4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonUtilityKinematicShadow+TransformPair>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37AA6]) = v42;\nL_001A:\n\tthis.hideShadow = 1;\n\tthis.physicsSystem = 1;\n\tv45 = new System.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonUtilityKinematicShadow+TransformPair>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.SkeletonUtilityKinematicShadow+TransformPair>::.ctor(v45);\n\tthis.shadowTable = v45;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonUtilityKinematicShadow()
		{
			hideShadow = true;
			physicsSystem = PhysicsSystem.Physics3D;
			List<TransformPair> list = new List<TransformPair>();
			shadowTable = list;
		}
	}
}
