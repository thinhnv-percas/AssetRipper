using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000045")]
	public class RaggedySpineboy : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000046")]
		private sealed class _003CRestore_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400016E")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400016F")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000170")]
			[FieldOffset(Offset = "0x20")]
			public RaggedySpineboy _003C_003E4__this;

			[Token(Token = "0x1700001C")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000123")]
				[Address(RVA = "0x1514C38", Offset = "0x1514C38", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001D")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000125")]
				[Address(RVA = "0x1514C78", Offset = "0x1514C78", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000120")]
			[Address(RVA = "0x15143B0", Offset = "0x15143B0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CRestore_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x151441C", Offset = "0x151441C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000122")]
			[Address(RVA = "0x1514420", Offset = "0x1514420", Length = "0x27C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = UnityEngine.Object;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv69 = UnityEngine.Physics2D;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37A5C]) = v52;\nL_0021:\n\tv58 = this.<>4__this;\n\tv63 = this.<>1__state == 1;\n\tif (v63) goto L_00C5;\n\tv71 = this.<>1__state == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_00DC;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv217 = Spine.Unity.Examples.SkeletonRagdoll2D::get_EstimatedSkeletonPosition(v58.ragdoll);\n\tv234 = v58.ragdoll;\n\tv279 = UnityEngine.Rigidbody2D::get_position(v234.<RootRigidbody>k__BackingField);\n\tgoto L_0054;\n\tv286 = System.Math;\n\tv287 = \"il2cpp_codegen_initialize_runtime_metadata\"(v286, v275, v35, v36, v37, v38, v39, v40, v279, v280, v210, v44, v45, v46, v47, v48);\n\tv290 = 1;\n\t*([1A357E4]) = v290;\nL_0054:\n\tv78 = v217 - v279;\n\tv80 = v217.y - v279.y;\n\tgoto L_005D;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v293, v275, v35, v36, v37, v38, v39, v40, v279, v280, v210, v44, v45, v46, v47, v48);\nL_005D:\n\tv300 = v78 * v78;\n\tv301 = v80 * v80;\n\tv302 = v300 + v301;\n\tv303 = v217.z * v217.z;\n\tv304 = v303 + v302;\n\tv133 = UnityEngine.Mathf::Sqrt(v304);\n\tv306 = UnityEngine.LayerMask::op_Implicit(v58.groundMask);\n\tgoto L_0078;\n\tv314 = v310;\n\tv315 = \"il2cpp_codegen_runtime_class_init\"(v314, v305, v35, v36, v37, v38, v39, v40, v304, v303, v210, v44, v45, v46, v47, v48);\nL_0078:\n\t// 120 MakeStruct v121 @ AGG1518578_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v78 @ V14_v4 (System.Single), v80 @ V13_v4 (System.Single)\n\tv322 = UnityEngine.Physics2D::Raycast(v279, v121, v133, v306);\n\tv118 = v322.m_Centroid;\n\tv328 = UnityEngine.RaycastHit2D::get_collider(&v118 @ stack_-B8_v3 (UnityEngine.Vector2));\n\tgoto L_0099;\n\tv334 = v331;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v334, v327, v35, v36, v37, v38, v39, v40, v323, v324, v211, v128, v126, v46, v47, v48);\nL_0099:\n\tv339 = UnityEngine.Object::op_Inequality(v328, 0);\n\tv341 = v339 == 0;\n\tif (v341) goto L_00A4;\n\tv344 = UnityEngine.RaycastHit2D::get_point(&v118 @ stack_-B8_v3 (UnityEngine.Vector2));\nL_00A4:\n\tv161 = v58.ragdoll;\n\tUnityEngine.Rigidbody2D::set_isKinematic(v161.<RootRigidbody>k__BackingField, 1);\n\t// 179 MakeStruct v83 @ AGG1518618_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v145 @ V8_v5, v143 @ V9_v5 (System.Single), v141 @ V10_v5 (System.Single)\n\tSpine.Unity.Examples.SkeletonRagdoll2D::SetSkeletonPosition(v58.ragdoll, v83);\n\tv350 = Spine.Unity.Examples.SkeletonRagdoll2D::SmoothMixCoroutine(v58.ragdoll, 0f, v58.restoreDuration);\n\tv352 = UnityEngine.MonoBehaviour::StartCoroutine(v58.ragdoll, v350);\n\tthis.<>2__current = v352;\n\tthis.<>1__state = 1;\n\tgoto L_00DC;\nL_00C5:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tSpine.Unity.Examples.SkeletonRagdoll2D::Remove(v58.ragdoll);\n\tSpine.Unity.Examples.RaggedySpineboy::AddRigidbody(v58);\nL_00DC:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				//IL_01fa: Expected F4, but got O
				RaggedySpineboy raggedySpineboy = _003C_003E4__this;
				bool result;
				if (_003C_003E1__state != 1)
				{
					bool flag = _003C_003E1__state == 0;
					bool flag2 = !flag;
					result = false;
					if (!flag2)
					{
						_003C_003E1__state = -1;
						Vector3 estimatedSkeletonPosition = raggedySpineboy.ragdoll.EstimatedSkeletonPosition;
						SkeletonRagdoll2D ragdoll = raggedySpineboy.ragdoll;
						Vector2 position = ragdoll.RootRigidbody.position;
						float num = estimatedSkeletonPosition.x - position.x;
						float num2 = estimatedSkeletonPosition.y - position.y;
						float num3 = num * num;
						float num4 = num2 * num2;
						float num5 = num3 + num4;
						float num6 = estimatedSkeletonPosition.z * estimatedSkeletonPosition.z;
						float f = num6 + num5;
						float distance = Mathf.Sqrt(f);
						int layerMask = raggedySpineboy.groundMask;
						Vector2 direction = default(Vector2);
						direction.x = num;
						direction.y = num2;
						Vector2 centroid = Physics2D.Raycast(position, direction, distance, layerMask).m_Centroid;
						Collider2D collider = ((RaycastHit2D*)(&centroid))->collider;
						bool flag3 = collider != null;
						bool flag4 = !flag3;
						float z = estimatedSkeletonPosition.z;
						float y = estimatedSkeletonPosition.y;
						object obj = estimatedSkeletonPosition;
						if (!flag4)
						{
							Vector2 point = ((RaycastHit2D*)(&centroid))->point;
							z = 0f;
							y = point.y;
							obj = point;
						}
						SkeletonRagdoll2D ragdoll2 = raggedySpineboy.ragdoll;
						ragdoll2.RootRigidbody.isKinematic = true;
						Vector3 skeletonPosition = default(Vector3);
						skeletonPosition.x = (float)obj;
						skeletonPosition.y = y;
						skeletonPosition.z = z;
						raggedySpineboy.ragdoll.SetSkeletonPosition(skeletonPosition);
						IEnumerator routine = raggedySpineboy.ragdoll.SmoothMixCoroutine(0f, raggedySpineboy.restoreDuration);
						Coroutine coroutine = raggedySpineboy.ragdoll.StartCoroutine(routine);
						_003C_003E2__current = coroutine;
						_003C_003E1__state = 1;
						result = true;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					raggedySpineboy.ragdoll.Remove();
					raggedySpineboy.AddRigidbody();
					result = false;
				}
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000124")]
			[Address(RVA = "0x1514C40", Offset = "0x1514C40", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000047")]
		private sealed class _003CWaitUntilStopped_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000171")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000172")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000173")]
			[FieldOffset(Offset = "0x20")]
			public RaggedySpineboy _003C_003E4__this;

			[Token(Token = "0x4000174")]
			[FieldOffset(Offset = "0x28")]
			private float _003Ct_003E5__2;

			[Token(Token = "0x1700001E")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000129")]
				[Address(RVA = "0x1514E08", Offset = "0x1514E08", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001F")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600012B")]
				[Address(RVA = "0x1514E48", Offset = "0x1514E48", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000126")]
			[Address(RVA = "0x15143D8", Offset = "0x15143D8", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CWaitUntilStopped_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000127")]
			[Address(RVA = "0x1514C80", Offset = "0x1514C80", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000128")]
			[Address(RVA = "0x1514C84", Offset = "0x1514C84", Length = "0x184")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = UnityEngine.WaitForSeconds;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A5D]) = v37;\nL_0013:\n\tv39 = this.<>4__this;\n\tv44 = this.<>1__state == 2;\n\tif (v44) goto L_003A;\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_003D;\n\tv59 = this.<>1__state == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv76 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v76, 0.5f);\n\tthis.<>2__current = v76;\n\tthis.<>1__state = 1;\n\tgoto L_0096;\nL_003A:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_004C;\nL_003D:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tthis.<t>5__2 = 0f;\nL_004C:\n\tv80 = this.<t>5__2 >= 0.5f;\n\tif (v80) goto L_008A;\n\tv127 = v39.ragdoll;\n\tv206 = UnityEngine.Rigidbody2D::get_velocity(v127.<RootRigidbody>k__BackingField);\n\tgoto L_0069;\n\tv213 = System.Math;\n\tv214 = \"il2cpp_codegen_initialize_runtime_metadata\"(v213, v147, v21, v22, v23, v24, v25, v26, v206, v207, v29, v30, v31, v32, v33, v34);\n\tv217 = 1;\n\t*([1A357E2]) = v217;\nL_0069:\n\tgoto L_006D;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v220, v147, v21, v22, v23, v24, v25, v26, v206, v207, v29, v30, v31, v32, v33, v34);\nL_006D:\n\tv226 = v206 * v206;\n\tv137 = v206.y * v206.y;\n\tv227 = v226 + v137;\n\tv228 = UnityEngine.Mathf::Sqrt(v227);\n\tv143 = v228 > 0.09f;\n\tif (v143) goto L_0084;\n\tv234 = UnityEngine.Time::get_deltaTime();\n\tv149 = this.<t>5__2 + v234;\nL_0084:\n\tthis.<t>5__2 = v149;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 2;\n\tgoto L_0096;\nL_008A:\n\tv181 = Spine.Unity.Examples.RaggedySpineboy::Restore(this.<>4__this);\n\tv105 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v181);\nL_0096:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				RaggedySpineboy raggedySpineboy = _003C_003E4__this;
				if (_003C_003E1__state != 2)
				{
					if (_003C_003E1__state != 1)
					{
						if (_003C_003E1__state == 0)
						{
							_003C_003E1__state = -1;
							WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);
							_003C_003E2__current = waitForSeconds;
							_003C_003E1__state = 1;
							return true;
						}
						goto IL_01c4;
					}
					_003C_003E1__state = -1;
					_003Ct_003E5__2 = 0f;
				}
				else
				{
					_003C_003E1__state = -1;
				}
				if (_003Ct_003E5__2 < 0.5f)
				{
					SkeletonRagdoll2D ragdoll = raggedySpineboy.ragdoll;
					Vector2 velocity = ragdoll.RootRigidbody.velocity;
					float num = velocity.x * velocity.x;
					float num2 = velocity.y * velocity.y;
					float f = num + num2;
					float num3 = Mathf.Sqrt(f);
					bool flag = num3 > 0.09f;
					float num4 = 0f;
					if (!flag)
					{
						float deltaTime = Time.deltaTime;
						num4 = _003Ct_003E5__2 + deltaTime;
					}
					_003Ct_003E5__2 = num4;
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				}
				IEnumerator routine = _003C_003E4__this.Restore();
				Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
				goto IL_01c4;
				IL_01c4:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600012A")]
			[Address(RVA = "0x1514E10", Offset = "0x1514E10", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x20")]
		public LayerMask groundMask;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x24")]
		public float restoreDuration;

		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x28")]
		public Vector2 launchVelocity;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x30")]
		private SkeletonRagdoll2D ragdoll;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x38")]
		private Collider2D naturalCollider;

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x15133F8", Offset = "0x15133F8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A57]) = v42;\nL_001B:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tthis.ragdoll = v45;\n\tv50 = UnityEngine.Component::GetComponent(this);\n\tthis.naturalCollider = v50;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			SkeletonRagdoll2D component = GetComponent<SkeletonRagdoll2D>();
			ragdoll = component;
			Collider2D component2 = GetComponent<Collider2D>();
			naturalCollider = component2;
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x1513474", Offset = "0x1513474", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37A58]) = v33;\nL_0012:\n\tv36 = UnityEngine.Component::get_gameObject(this);\n\tv41 = UnityEngine.GameObject::AddComponent(v36);\n\tUnityEngine.Rigidbody2D::set_freezeRotation(v41, 1);\n\tUnityEngine.Behaviour::set_enabled(this.naturalCollider, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddRigidbody()
		{
			GameObject gameObject = base.gameObject;
			Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
			rigidbody2D.freezeRotation = true;
			naturalCollider.enabled = true;
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x15134F0", Offset = "0x15134F0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = UnityEngine.Object;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A59]) = v42;\nL_001B:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0026;\n\tv53 = v48;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v53, v43, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.Object::Destroy(v45);\n\tUnityEngine.Behaviour::set_enabled(this.naturalCollider, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveRigidbody()
		{
			Rigidbody2D component = GetComponent<Rigidbody2D>();
			UnityEngine.Object.Destroy(component);
			naturalCollider.enabled = false;
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x1513590", Offset = "0x1513590", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.Behaviour::get_enabled(this.naturalCollider);\n\tv27 = v9 == 0;\n\tif (v27) goto L_0015;\n\tSpine.Unity.Examples.RaggedySpineboy::Launch(this);\n\treturn;\nL_0015:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnMouseUp()
		{
			if (naturalCollider.enabled)
			{
				Launch();
			}
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x15135C4", Offset = "0x15135C4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.RaggedySpineboy::RemoveRigidbody(this);\n\tSpine.Unity.Examples.SkeletonRagdoll2D::Apply(this.ragdoll);\n\tv21 = this.ragdoll;\n\tv40 = -this.launchVelocity;\n\tv13 = UnityEngine.Random::Range(v40, this.launchVelocity);\n\t// 23 MakeStruct v46 @ AGG151760C_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v13 @ V0_v3 (System.Single), this.launchVelocity.y (System.Single)\n\tUnityEngine.Rigidbody2D::set_velocity(v21.<RootRigidbody>k__BackingField, v46);\n\tv64 = Spine.Unity.Examples.RaggedySpineboy::WaitUntilStopped(this);\n\tv58 = UnityEngine.MonoBehaviour::StartCoroutine(this, v64);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Launch()
		{
			//IL_002b: Unsupported input type for neg.
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected F4, but got Unknown
			RemoveRigidbody();
			ragdoll.Apply();
			SkeletonRagdoll2D skeletonRagdoll2D = ragdoll;
			float minInclusive = (float)(0 - launchVelocity);
			float x = UnityEngine.Random.Range(minInclusive, launchVelocity.x);
			Vector2 velocity = default(Vector2);
			velocity.x = x;
			velocity.y = launchVelocity.y;
			skeletonRagdoll2D.RootRigidbody.velocity = velocity;
			IEnumerator routine = WaitUntilStopped();
			Coroutine coroutine = StartCoroutine(routine);
		}

		[IteratorStateMachine(typeof(_003CRestore_003Ed__10))]
		[Token(Token = "0x600011D")]
		[Address(RVA = "0x1514350", Offset = "0x1514350", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.RaggedySpineboy+<Restore>d__10;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A5A]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.RaggedySpineboy+<Restore>d__10();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Restore()
		{
			_003CRestore_003Ed__10 _003CRestore_003Ed__11 = null;
			_003CRestore_003Ed__11._003C_003E1__state = 0;
			_003CRestore_003Ed__11._003C_003E4__this = this;
			return _003CRestore_003Ed__11;
		}

		[IteratorStateMachine(typeof(_003CWaitUntilStopped_003Ed__11))]
		[Token(Token = "0x600011E")]
		[Address(RVA = "0x15142F0", Offset = "0x15142F0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.RaggedySpineboy+<WaitUntilStopped>d__11;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A5B]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.RaggedySpineboy+<WaitUntilStopped>d__11();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator WaitUntilStopped()
		{
			_003CWaitUntilStopped_003Ed__11 _003CWaitUntilStopped_003Ed__12 = null;
			_003CWaitUntilStopped_003Ed__12._003C_003E1__state = 0;
			_003CWaitUntilStopped_003Ed__12._003C_003E4__this = this;
			return _003CWaitUntilStopped_003Ed__12;
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0x1514400", Offset = "0x1514400", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.restoreDuration = 0.5f;\n\tthis.launchVelocity = 52776566820864d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RaggedySpineboy()
		{
			//IL_0020: Expected O, but got F8
			base._002Ector();
			restoreDuration = 0.5f;
			launchVelocity = (Vector2)52776566820864.0;
		}
	}
}
