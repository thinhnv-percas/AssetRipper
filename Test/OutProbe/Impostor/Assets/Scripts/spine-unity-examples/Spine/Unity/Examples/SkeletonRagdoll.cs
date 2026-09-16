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
	[RequireComponent(typeof(SkeletonRenderer))]
	[Token(Token = "0x200005A")]
	public class SkeletonRagdoll : MonoBehaviour
	{
		[Token(Token = "0x200005B")]
		public class LayerFieldAttribute : PropertyAttribute
		{
			[Token(Token = "0x600018D")]
			[Address(RVA = "0x151B2B8", Offset = "0x151B2B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public LayerFieldAttribute()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200005C")]
		private sealed class _003CSmoothMixCoroutine_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001EA")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001EB")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001EC")]
			[FieldOffset(Offset = "0x20")]
			public SkeletonRagdoll _003C_003E4__this;

			[Token(Token = "0x40001ED")]
			[FieldOffset(Offset = "0x28")]
			public float target;

			[Token(Token = "0x40001EE")]
			[FieldOffset(Offset = "0x2C")]
			public float duration;

			[Token(Token = "0x40001EF")]
			[FieldOffset(Offset = "0x30")]
			private float _003CstartTime_003E5__2;

			[Token(Token = "0x40001F0")]
			[FieldOffset(Offset = "0x34")]
			private float _003CstartMix_003E5__3;

			[Token(Token = "0x1700002A")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000191")]
				[Address(RVA = "0x151B3BC", Offset = "0x151B3BC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700002B")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000193")]
				[Address(RVA = "0x151B3FC", Offset = "0x151B3FC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600018E")]
			[Address(RVA = "0x151A048", Offset = "0x151A048", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CSmoothMixCoroutine_003Ed__41(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600018F")]
			[Address(RVA = "0x151B2C0", Offset = "0x151B2C0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000190")]
			[Address(RVA = "0x151B2C4", Offset = "0x151B2C4", Length = "0xF8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.<>4__this;\n\tv18 = this.<>1__state == 1;\n\tif (v18) goto L_0021;\n\tv23 = this.<>1__state == 0;\n\tv24 = ~v23;\n\tif (v24) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv29 = UnityEngine.Time::get_time();\n\tthis.<startTime>5__2 = v29;\n\tthis.<startMix>5__3 = v12.mix;\n\tgoto L_0030;\nL_0021:\n\tthis.<>1__state = 0xFFFFFFFF;\nL_0030:\n\tv32 = v12.mix <= 0;\n\tif (v32) goto L_FFFFFFFF;\n\tSpine.Skeleton::SetBonesToSetupPose(v12.skeleton);\n\tv163 = UnityEngine.Time::get_time();\n\tv166 = v163 - this.<startTime>5__2;\n\tv167 = v166 / this.duration;\n\tv128 = v167 < 0;\n\tv173 = UnityEngine.Mathf::Min(v167, 1f);\n\tv111 = ~v128;\n\tv97 = ~v111;\n\tif (v97) goto L_FFFFFFFF;\n\tgoto L_0054;\nL_0054:\n\tv175 = v173 + v173;\n\tv176 = v173 * 3f;\n\tv177 = v173 * v175;\n\tv103 = v173 * v176;\n\tv178 = v173 * v177;\n\tv179 = v103 - v178;\n\tv101 = this.target * v179;\n\tv180 = 1f - v179;\n\tv181 = this.<startMix>5__3 * v180;\n\tv113 = v101 + v181;\n\tv12.mix = v113;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\tgoto L_0069;\nL_0069:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				SkeletonRagdoll skeletonRagdoll = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state != 0)
					{
						goto IL_0159;
					}
					_003C_003E1__state = -1;
					float time = Time.time;
					_003CstartTime_003E5__2 = time;
					_003CstartMix_003E5__3 = skeletonRagdoll.mix;
				}
				else
				{
					_003C_003E1__state = -1;
				}
				if (skeletonRagdoll.mix > 0f)
				{
					skeletonRagdoll.skeleton.SetBonesToSetupPose();
					float time2 = Time.time;
					float num = time2 - _003CstartTime_003E5__2;
					float num2 = num / duration;
					bool flag = num2 < 0f;
					float num3 = Mathf.Min(num2, 1f);
					if (flag)
					{
						num3 = 0f;
					}
					float num4 = num3 + num3;
					float num5 = num3 * 3f;
					float num6 = num3 * num4;
					float num7 = num3 * num5;
					float num8 = num3 * num6;
					float num9 = num7 - num8;
					float num10 = target * num9;
					float num11 = 1f - num9;
					float num12 = _003CstartMix_003E5__3 * num11;
					float mix = num10 + num12;
					skeletonRagdoll.mix = mix;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0159;
				IL_0159:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000192")]
			[Address(RVA = "0x151B3C4", Offset = "0x151B3C4", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200005D")]
		private sealed class _003CStart_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001F1")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001F2")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001F3")]
			[FieldOffset(Offset = "0x20")]
			public SkeletonRagdoll _003C_003E4__this;

			[Token(Token = "0x1700002C")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000197")]
				[Address(RVA = "0x151B668", Offset = "0x151B668", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700002D")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000199")]
				[Address(RVA = "0x151B6A8", Offset = "0x151B6A8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000194")]
			[Address(RVA = "0x1518C4C", Offset = "0x1518C4C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__34(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000195")]
			[Address(RVA = "0x151B404", Offset = "0x151B404", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000196")]
			[Address(RVA = "0x151B408", Offset = "0x151B408", Length = "0x260")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = UnityEngine.Debug;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = UnityEngine.GameObject;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv150 = Spine.Unity.ISkeletonAnimation;\n\tv151 = \"il2cpp_codegen_initialize_runtime_metadata\"(v150, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv185 = UnityEngine.Object;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv213 = Spine.Unity.Examples.SkeletonRagdoll;\n\tv214 = \"il2cpp_codegen_initialize_runtime_metadata\"(v213, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv222 = \"Attached Spine component does not implement ISkeletonAnimation. This script is not compatible.\";\n\tv223 = \"il2cpp_codegen_initialize_runtime_metadata\"(v222, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv231 = \"Parent Space Helper\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v231, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A91]) = v38;\nL_0028:\n\tv40 = this.<>4__this;\n\tv45 = this.<>1__state == 1;\n\tif (v45) goto L_00AE;\n\tv53 = this.<>1__state == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_0048;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0048:\n\tv157 = UnityEngine.Object::op_Equality(v66.parentSpaceHelper, 0);\n\tv188 = v157 == 0;\n\tif (v188) goto L_006C;\n\tv134 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v134, \"Parent Space Helper\");\n\tv237 = UnityEngine.GameObject::get_transform(v134);\n\tv242.parentSpaceHelper = v237;\n\tUnityEngine.Object::set_hideFlags(v145.parentSpaceHelper, 1);\nL_006C:\n\tv229 = UnityEngine.Component::GetComponent(this.<>4__this);\n\t// 113 IsInst v235 @ X0_v15 (Spine.Unity.ISkeletonAnimation), typeof(Spine.Unity.ISkeletonAnimation), v229 @ X0_v14 (Spine.Unity.SkeletonRenderer)\n\tv40.targetSkeletonComponent = v235;\n\t// 117 IsInst v240 @ X0_v17, typeof(Spine.Unity.ISkeletonAnimation), v229 @ X0_v14 (Spine.Unity.SkeletonRenderer)\n\tv105 = v40.targetSkeletonComponent;\n\tv245 = v40.targetSkeletonComponent == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_008E;\n\tgoto L_0086;\n\tv261 = \"il2cpp_codegen_runtime_class_init\"(v249, v238, v121, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0086:\n\tUnityEngine.Debug::LogError(\"Attached Spine component does not implement ISkeletonAnimation. This script is not compatible.\");\n\tv105 = v40.targetSkeletonComponent;\nL_008E:\n\tgoto L_00BC;\n\tv264 = *([v257 @ X8_v15+B0]);\n\tv265 = v264 + 8;\n\tv267 = *([v303 @ X10_v7-8]);\n\tv309 = v267 == v258;\n\tif (v309) goto L_00B4;\n\tv289 = v304 - 1;\n\tv287 = v303 + 0x10;\n\tv269 = v304 != 1;\n\tif (v269) goto L_FFFFFFFF;\n\tv290 = 6;\n\tv291 = v105;\n\tv292 = 0xB349B4(v291, v258, v290, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_00BC;\nL_00AE:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tSpine.Unity.Examples.SkeletonRagdoll::Apply(this.<>4__this);\n\tgoto L_FFFFFFFF;\nL_00B4:\n\tv315 = *([v303 @ X10_v7]);\n\tv316 = v315 + 6;\n\tv317 = v316 << 4;\n\tv318 = v257 + v317;\n\tv319 = v318 + 0x138;\nL_00BC:\n\tv113 = Spine.Unity.ISkeletonAnimation::get_Skeleton(v105);\n\tv40.skeleton = v113;\n\tv115 = ~v40.applyOnStart;\n\tif (v115) goto L_FFFFFFFF;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\tgoto L_00CC;\nL_00CC:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				SkeletonRagdoll skeletonRagdoll = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						if (parentSpaceHelper == null)
						{
							GameObject gameObject = new GameObject("Parent Space Helper");
							Transform transform = gameObject.transform;
							parentSpaceHelper = transform;
							parentSpaceHelper.hideFlags = HideFlags.HideInHierarchy;
						}
						SkeletonRenderer component = _003C_003E4__this.GetComponent<SkeletonRenderer>();
						ISkeletonAnimation targetSkeletonComponent = component as ISkeletonAnimation;
						skeletonRagdoll.targetSkeletonComponent = targetSkeletonComponent;
						object obj = component as ISkeletonAnimation;
						ISkeletonAnimation targetSkeletonComponent2 = skeletonRagdoll.targetSkeletonComponent;
						if (skeletonRagdoll.targetSkeletonComponent == null)
						{
							Debug.LogError("Attached Spine component does not implement ISkeletonAnimation. This script is not compatible.");
							targetSkeletonComponent2 = skeletonRagdoll.targetSkeletonComponent;
						}
						Skeleton skeleton = targetSkeletonComponent2.Skeleton;
						skeletonRagdoll.skeleton = skeleton;
						if (skeletonRagdoll.applyOnStart)
						{
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					_003C_003E4__this.Apply();
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000198")]
			[Address(RVA = "0x151B670", Offset = "0x151B670", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40001D2")]
		private static Transform parentSpaceHelper;

		[Header("Hierarchy")]
		[SpineBone(null, null, true, false)]
		[Token(Token = "0x40001D3")]
		[FieldOffset(Offset = "0x20")]
		public string startingBoneName;

		[SpineBone(null, null, true, false)]
		[Token(Token = "0x40001D4")]
		[FieldOffset(Offset = "0x28")]
		public List<string> stopBoneNames;

		[Header("Parameters")]
		[Token(Token = "0x40001D5")]
		[FieldOffset(Offset = "0x30")]
		public bool applyOnStart;

		[Tooltip("Warning! You will have to re-enable and tune mix values manually if attempting to remove the ragdoll system.")]
		[Token(Token = "0x40001D6")]
		[FieldOffset(Offset = "0x31")]
		public bool disableIK;

		[Token(Token = "0x40001D7")]
		[FieldOffset(Offset = "0x32")]
		public bool disableOtherConstraints;

		[Tooltip("Set RootRigidbody IsKinematic to true when Apply is called.")]
		[Space(18f)]
		[Token(Token = "0x40001D8")]
		[FieldOffset(Offset = "0x33")]
		public bool pinStartBone;

		[Tooltip("Enable Collision between adjacent ragdoll elements (IE: Neck and Head)")]
		[Token(Token = "0x40001D9")]
		[FieldOffset(Offset = "0x34")]
		public bool enableJointCollision;

		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x35")]
		public bool useGravity;

		[Tooltip("If no BoundingBox Attachment is attached to a bone, this becomes the default Width or Radius of a Bone's ragdoll Rigidbody")]
		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x38")]
		public float thickness;

		[Tooltip("Default rotational limit value. Min is negative this value, Max is this value.")]
		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x3C")]
		public float rotationLimit;

		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x40")]
		public float rootMass;

		[Tooltip("If your ragdoll seems unstable or uneffected by limits, try lowering this value.")]
		[Range(0.01f, 1f)]
		[Token(Token = "0x40001DE")]
		[FieldOffset(Offset = "0x44")]
		public float massFalloffFactor;

		[Tooltip("The layer assigned to all of the rigidbody parts.")]
		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0x48")]
		public int colliderLayer;

		[Range(0f, 1f)]
		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x4C")]
		public float mix;

		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x50")]
		public bool oldRagdollBehaviour;

		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x58")]
		private ISkeletonAnimation targetSkeletonComponent;

		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x60")]
		private Skeleton skeleton;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x68")]
		private Dictionary<Bone, Transform> boneTable;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x70")]
		private Transform ragdollRoot;

		[CompilerGenerated]
		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x78")]
		private Rigidbody _003CRootRigidbody_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x80")]
		private Bone _003CStartingBone_003Ek__BackingField;

		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x88")]
		private Vector3 rootOffset;

		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x94")]
		private bool isActive;

		[Token(Token = "0x17000024")]
		public Rigidbody RootRigidbody
		{
			[CompilerGenerated]
			[Token(Token = "0x6000179")]
			[Address(RVA = "0x1518BB8", Offset = "0x1518BB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RootRigidbody>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RootRigidbody;
			}
			[CompilerGenerated]
			[Token(Token = "0x600017A")]
			[Address(RVA = "0x1518BC0", Offset = "0x1518BC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RootRigidbody>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CRootRigidbody_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000025")]
		public Bone StartingBone
		{
			[CompilerGenerated]
			[Token(Token = "0x600017B")]
			[Address(RVA = "0x1518BC8", Offset = "0x1518BC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StartingBone>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StartingBone;
			}
			[CompilerGenerated]
			[Token(Token = "0x600017C")]
			[Address(RVA = "0x1518BD0", Offset = "0x1518BD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StartingBone>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CStartingBone_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000026")]
		public Vector3 RootOffset
		{
			[Token(Token = "0x600017D")]
			[Address(RVA = "0x1518BD8", Offset = "0x1518BD8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rootOffset;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return rootOffset;
			}
		}

		[Token(Token = "0x17000027")]
		public bool IsActive
		{
			[Token(Token = "0x600017E")]
			[Address(RVA = "0x1518BE4", Offset = "0x1518BE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isActive;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsActive;
			}
		}

		[Token(Token = "0x17000028")]
		public unsafe Rigidbody[] RigidbodyArray
		{
			[Token(Token = "0x6000180")]
			[Address(RVA = "0x1518C74", Offset = "0x1518C74", Length = "0x264")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv134 = Il2CppMethodInfo;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv201 = Il2CppMethodInfo;\n\tv202 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv236 = Il2CppMethodInfo;\n\tv237 = \"il2cpp_codegen_initialize_runtime_metadata\"(v236, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv249 = UnityEngine.Rigidbody[];\n\tv250 = \"il2cpp_codegen_initialize_runtime_metadata\"(v249, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv255 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v255, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A87]) = v42;\nL_002F:\n\tv49 = ~this.isActive;\n\tif (v49) goto L_0083;\n\tv54 = this.boneTable == 0;\n\tif (v54) goto L_0095;\n\tv64 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Count(this.boneTable);\n\t// 59 NewArr v118 @ X0_v25 (UnityEngine.Rigidbody[]), typeof(UnityEngine.Rigidbody[]), v64 @ X0_v23 (System.Int32)\n\tv122 = this.boneTable == 0;\n\tif (v122) goto L_0095;\n\tv119 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Values(this.boneTable);\n\tv123 = v119 == 0;\n\tif (v123) goto L_0095;\n\tv263 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>::GetEnumerator(v119);\nL_0059:\n\tv294 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v101 @ stack_-78_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv183 = v294 == 0;\n\tif (v183) goto L_007F;\n\tv300 = UnityEngine.Component::GetComponent(v267);\n\tv332 = v300 == 0;\n\tif (v332) goto L_0078;\n\tv338 = *([v118 @ X0_v25 (UnityEngine.Rigidbody[])]);\n\tv336 = \"il2cpp_codegen_object_is_inst\"(v300, *([v338 @ X8_v26 (Il2CppClass<Spine.Unity.Examples.SkeletonRagdoll>)+40]), v25, v26, v27, v28, v29, v30, v101, v32, v33, v34, v35, v36, v37, v38);\n\tv337 = v336 == 0;\n\tif (v337) goto L_0092;\nL_0078:\n\t;\n\tv97 = v97 + 1;\n\tv118[v97 @ X24_v5 (System.Int32)] = v300;\n\tgoto L_0059;\nL_007F:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v101 @ stack_-78_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_008E;\nL_0083:\n\t// 131 NewArr v57 @ X0_v5 (UnityEngine.Rigidbody[]), typeof(UnityEngine.Rigidbody[]), 0\nL_008E:\n\treturn v185;\n\tv311 = new System.IndexOutOfRangeException();\n\tv316 = new System.NullReferenceException();\n\tv331 = new System.NullReferenceException();\nL_0092:\n\tv339 = new System.ArrayTypeMismatchException();\n\tthrow v339;\nL_0095:\n\tv131 = new System.NullReferenceException();\n\tgoto L_00A3;\n\tgoto L_00A3;\n\tgoto L_00A3;\nL_00A3:\n\tv140 = methodInfo != 1;\n\tif (v140) goto L_00B3;\n\tv241 = 0x1854E70(v131, methodInfo, v25, v26, v27, v28, v29, v30, v98, v32, v33, v34, v35, v36, v37, v38);\n\tv251 = 0x1854E80(v241, methodInfo, v25, v26, v27, v28, v29, v30, v98, v32, v33, v34, v35, v36, v37, v38);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v94 @ stack_-60_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv184 = *([v241 @ X0_v18]) == 0;\n\tif (v184) goto L_008E;\n\tthrow System.OutOfMemoryException;\nL_00B3:\n\tgoto L_00B9;\n\tX20 = X0;\nL_00B9:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v94 @ stack_-60_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_00C0;\n\tv270 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v131);\nL_00C0:\n\tv273 = new System.OutOfMemoryException();\n\treturnVal2 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v273);\n\treturn returnVal2;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0120: Expected I, but got O
				//IL_01b1: Expected I, but got O
				SkeletonRagdoll result;
				if (IsActive)
				{
					bool flag = boneTable == null;
					Dictionary<object, object>.ValueCollection.Enumerator enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
					result = this;
					nint num = default(nint);
					if (!flag)
					{
						int count = boneTable.Count;
						Rigidbody[] array = new Rigidbody[count];
						bool flag2 = boneTable == null;
						enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
						num = count;
						result = this;
						if (!flag2)
						{
							Dictionary<Bone, Transform>.ValueCollection values = boneTable.Values;
							bool flag3 = values == null;
							enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
							num = 0;
							result = (SkeletonRagdoll)(object)array;
							if (!flag3)
							{
								Dictionary<Bone, Transform>.ValueCollection.Enumerator enumerator2 = values.GetEnumerator();
								int num2 = 0;
								Dictionary<object, object>.ValueCollection.Enumerator enumerator3 = default(Dictionary<object, object>.ValueCollection.Enumerator);
								Component component2 = default(Component);
								object obj = default(object);
								while (enumerator3.MoveNext())
								{
									Rigidbody component = component2.GetComponent<Rigidbody>();
									if ((object)component != null)
									{
										nint num3 = (nint)array;
										Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
										if (obj == null)
										{
											ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
											num = unchecked((nint)null);
											throw ex;
										}
									}
									num2++;
									array[num2] = component;
								}
								enumerator3.Dispose();
								result = (SkeletonRagdoll)(object)array;
								goto IL_02a7;
							}
						}
					}
					NullReferenceException ex2 = new NullReferenceException();
					if (num != 1)
					{
						enumerator.Dispose();
						OutOfMemoryException ex3 = new OutOfMemoryException();
						((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)ex3)->Dispose();
						Rigidbody[] result2 = default(Rigidbody[]);
						return result2;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					enumerator.Dispose();
					object obj2 = default(object);
					if (obj2 != null)
					{
						throw new OutOfMemoryException();
					}
				}
				else
				{
					Rigidbody[] array2 = new Rigidbody[0];
					result = (SkeletonRagdoll)(object)array2;
				}
				goto IL_02a7;
				IL_02a7:
				return (Rigidbody[])(object)result;
			}
		}

		[Token(Token = "0x17000029")]
		public Vector3 EstimatedSkeletonPosition
		{
			[Token(Token = "0x6000181")]
			[Address(RVA = "0x1518ED8", Offset = "0x1518ED8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.Rigidbody::get_position(this.<RootRigidbody>k__BackingField);\n\treturnVal1 = v9 - this.rootOffset;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Vector3 position = RootRigidbody.position;
				return position - rootOffset;
			}
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__34))]
		[Token(Token = "0x600017F")]
		[Address(RVA = "0x1518BEC", Offset = "0x1518BEC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SkeletonRagdoll+<Start>d__34;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A86]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SkeletonRagdoll+<Start>d__34();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__34 _003CStart_003Ed__35 = null;
			_003CStart_003Ed__35._003C_003E1__state = 0;
			_003CStart_003Ed__35._003C_003E4__this = this;
			return _003CStart_003Ed__35;
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x1518F10", Offset = "0x1518F10", Length = "0xCC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0081;\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv492 = Il2CppMethodInfo;\n\tv493 = \"il2cpp_codegen_initialize_runtime_metadata\"(v492, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv566 = UnityEngine.Debug;\n\tv567 = \"il2cpp_codegen_initialize_runtime_metadata\"(v566, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv681 = Il2CppMethodInfo;\n\tv682 = \"il2cpp_codegen_initialize_runtime_metadata\"(v681, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv751 = Il2CppMethodInfo;\n\tv752 = \"il2cpp_codegen_initialize_runtime_metadata\"(v751, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv815 = Il2CppMethodInfo;\n\tv816 = \"il2cpp_codegen_initialize_runtime_metadata\"(v815, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv926 = Il2CppMethodInfo;\n\tv927 = \"il2cpp_codegen_initialize_runtime_metadata\"(v926, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv992 = Il2CppMethodInfo;\n\tv993 = \"il2cpp_codegen_initialize_runtime_metadata\"(v992, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1056 = Il2CppMethodInfo;\n\tv1057 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1056, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1153 = UnityEngine.GameObject;\n\tv1154 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1153, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1222 = Spine.Unity.ISkeletonAnimation;\n\tv1223 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1222, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1296 = Il2CppMethodInfo;\n\tv1297 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1296, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1362 = Il2CppMethodInfo;\n\tv1363 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1362, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1429 = Il2CppMethodInfo;\n\tv1430 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1429, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1506 = Il2CppMethodInfo;\n\tv1507 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1506, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1576 = Il2CppMethodInfo;\n\tv1577 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1576, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1661 = Il2CppMethodInfo;\n\tv1662 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1661, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1729 = Il2CppMethodInfo;\n\tv1730 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1729, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1803 = Il2CppMethodInfo;\n\tv1804 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1803, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv1929 = Il2CppMethodInfo;\n\tv1930 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1929, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2012 = Il2CppMethodInfo;\n\tv2013 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2012, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2102 = System.Collections.Generic.List`1<UnityEngine.Collider>;\n\tv2103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2102, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2214 = System.Collections.Generic.List`1<System.String>;\n\tv2215 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2214, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2316 = UnityEngine.Object;\n\tv2317 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2316, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2402 = UnityEngine.Physics;\n\tv2403 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2402, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2439 = Il2CppMethodInfo;\n\tv2440 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2439, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2475 = Spine.Unity.UpdateBonesDelegate;\n\tv2476 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2475, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2516 = \"Destroyed Utility Bones: \";\n\tv2517 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2516, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2544 = \",\";\n\tv2545 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2544, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv2584 = \"RagdollRoot\";\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2584, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 1;\n\t*([1A37A88]) = v60;\nL_0081:\n\tthis.isActive = 1;\n\tthis.mix = 1f;\n\tv78 = Spine.Skeleton::FindBone(this.skeleton, this.startingBoneName);\n\tthis.<StartingBone>k__BackingField = v78;\n\tSpine.Unity.Examples.SkeletonRagdoll::RecursivelyCreateBoneProxies(this, v78);\n\tv435 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, this.<StartingBone>k__BackingField);\n\tv436 = UnityEngine.Component::GetComponent(v435);\n\tthis.<RootRigidbody>k__BackingField = v436;\n\tUnityEngine.Rigidbody::set_isKinematic(v436, this.pinStartBone);\n\tUnityEngine.Rigidbody::set_mass(this.<RootRigidbody>k__BackingField, this.rootMass);\n\tv1225 = new System.Collections.Generic.List`1<UnityEngine.Collider>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider>::.ctor(v1225);\n\tv1439 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::GetEnumerator(this.boneTable);\nL_00CA:\n\tv743 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v656 @ stack_-F8_v26 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv1664 = v743 == 0;\n\tif (v1664) goto L_0223;\n\tv673 = UnityEngine.Component::GetComponent(v1731);\n\tv677 = v1225._items;\n\tv638 = v1225._version + 1;\n\tv1225._version = v638;\n\tv886 = v1225._size;\n\tv2104 = v1225._size < v677.Length;\n\tv2105 = ~v2104;\n\tif (v2105) goto L_00F7;\n\tv2216 = v1225._size + 1;\n\tv1225._size = v2216;\n\tv677[v886 @ X10_v51 (System.Int32)] = v673;\n\tgoto L_00FD;\nL_00F7:\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider>::AddWithResize(v1225, v673);\nL_00FD:\n\tv872 = this.<StartingBone>k__BackingField == v1510;\n\tif (v872) goto L_0115;\n\tv915 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, *([v1510 @ stack_-E8 (System.Single)+20]));\n\tv2518 = v915 == 0;\n\tv918 = ~v2518;\n\tif (v918) goto L_01A9;\n\tgoto L_043D;\nL_0115:\n\tv1654 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v1654, \"RagdollRoot\");\n\tv1656 = v1654 == 0;\n\tif (v1656) goto L_0447;\n\tv2521 = UnityEngine.GameObject::get_transform(v1654);\n\tthis.ragdollRoot = v2521;\n\tv1498 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v2521, v1498, 0);\n\tv2789 = Spine.Skeleton::get_RootBone(this.skeleton);\n\tv873 = v2789 == v1510;\n\tif (v873) goto L_0169;\n\tv1725 = *([v1510 @ stack_-E8 (System.Single)+20]);\n\t// 329 MakeStruct v1759 @ AGG151D344_1_v29 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1725 @ X8_v128+74], [v1725 @ X8_v128+80], 0\n\tUnityEngine.Transform::set_localPosition(this.ragdollRoot, v1759);\n\tv1782 = *([v1510 @ stack_-E8 (System.Single)+20\n// ... truncated")]
		public unsafe void Apply()
		{
			//IL_01c6: Expected O, but got I
			//IL_02aa: Expected O, but got I
			//IL_0476: Expected F4, but got I
			//IL_048b: Expected F4, but got I
			//IL_04b8: Expected O, but got I
			//IL_04c8: Expected O, but got I
			//IL_04ef: Expected O, but got I
			//IL_02c6: Expected F4, but got I
			//IL_02db: Expected F4, but got I
			//IL_0308: Expected O, but got I
			//IL_031d: Expected O, but got I
			//IL_032d: Expected O, but got I
			//IL_0354: Expected O, but got I
			//IL_050e: Expected O, but got I
			//IL_0524: Expected O, but got I
			//IL_0ef4: Expected I, but got O
			//IL_0efd: Expected I, but got O
			//IL_0f0d: Expected F4, but got I
			//IL_0373: Expected O, but got I
			//IL_0389: Expected O, but got I
			//IL_0648: Expected O, but got F4
			//IL_0678: Expected O, but got F4
			//IL_078e: Expected O, but got Ref
			isActive = true;
			mix = 1f;
			RecursivelyCreateBoneProxies(StartingBone = this.skeleton.FindBone(startingBoneName));
			Component component = boneTable[StartingBone];
			(RootRigidbody = component.GetComponent<Rigidbody>()).isKinematic = pinStartBone;
			RootRigidbody.mass = rootMass;
			List<Collider> list = new List<Collider>();
			Dictionary<Bone, Transform>.Enumerator enumerator = boneTable.GetEnumerator();
			float num2 = default(float);
			float num = num2;
			Dictionary<object, object>.Enumerator enumerator3 = default(Dictionary<object, object>.Enumerator);
			Dictionary<object, object>.Enumerator enumerator2 = enumerator3;
			Component component3 = default(Component);
			GameObject gameObject = default(GameObject);
			Vector3 localPosition = default(Vector3);
			Vector3 vector = default(Vector3);
			Dictionary<object, object>.Enumerator enumerator4;
			object obj6 = default(object);
			Vector3 localPosition2 = default(Vector3);
			Vector3 vector2 = default(Vector3);
			JointLimits jointLimits = default(JointLimits);
			float num8 = default(float);
			while (true)
			{
				Component component4;
				List<Collider> list2;
				if (enumerator3.MoveNext())
				{
					Collider component2 = component3.GetComponent<Collider>();
					Collider[] items = list._items;
					int version = list._version + 1;
					list._version = version;
					int count = list.Count;
					if (list.Count < items.Length)
					{
						int size = list.Count + 1;
						list._size = size;
						items[count] = component2;
					}
					else
					{
						list.Add(component2);
					}
					if ((float)StartingBone != num2)
					{
						Dictionary<Bone, Transform> dictionary = boneTable;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+20]");
						Transform transform = dictionary[(Bone)0];
						bool flag = (object)transform == null;
						bool flag2 = !flag;
						component4 = transform;
						if (flag2)
						{
							goto IL_067d;
						}
						NullReferenceException ex = new NullReferenceException();
						NullReferenceException ex2 = new NullReferenceException();
						NullReferenceException ex3 = new NullReferenceException();
						NullReferenceException ex4 = new NullReferenceException();
						NullReferenceException ex5 = new NullReferenceException();
						NullReferenceException ex6 = new NullReferenceException();
						NullReferenceException ex7 = new NullReferenceException();
						NullReferenceException ex8 = new NullReferenceException();
						NullReferenceException ex9 = new NullReferenceException();
						NullReferenceException ex10 = new NullReferenceException();
					}
					else
					{
						gameObject = new GameObject("RagdollRoot");
						if ((object)gameObject != null)
						{
							Transform transform2 = (ragdollRoot = gameObject.transform);
							Transform parent = base.transform;
							transform2.SetParent(parent, worldPositionStays: false);
							Bone rootBone = this.skeleton.RootBone;
							if ((float)rootBone != num2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+20]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1725 @ X8_v128+74]");
								localPosition.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1725 @ X8_v128+80]");
								localPosition.y = 0f;
								localPosition.z = 0f;
								ragdollRoot.localPosition = localPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+20]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ X9_v65+20]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ X9_v65+54]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ X9_v65+20]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ X9_v65+54]");
								object obj5 = 0;
								if (!flag3)
								{
									bool flag5;
									do
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2949 @ X8_v131+20]");
										obj3 = 0;
										nint num3 = (nint)obj4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2949 @ X8_v131+54]");
										obj4 = num3 + 0;
										bool flag4 = obj3 == null;
										flag5 = !flag4;
										obj5 = obj4;
									}
									while (flag5);
								}
								float z = (float)obj5 * ((float)Math.PI / 180f);
								vector.x = 0f;
								vector.y = 0f;
								vector.z = z;
								Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
								float w = localRotation.w;
								ragdollRoot.localRotation = localRotation;
							}
							else
							{
								bool flag6 = num2 == 0f;
								enumerator4 = enumerator3;
								list2 = list;
								if (flag6)
								{
									NullReferenceException ex11 = new NullReferenceException();
									if (0 == 1)
									{
										Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
										Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
										enumerator4.Dispose();
										if (obj6 != null)
										{
											throw new OutOfMemoryException();
										}
										goto IL_07e1;
									}
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+74]");
								localPosition2.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+80]");
								localPosition2.y = 0f;
								localPosition2.z = 0f;
								ragdollRoot.localPosition = localPosition2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+20]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+54]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+20]");
								bool flag7 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ stack_-E8 (System.Single)+54]");
								object obj9 = 0;
								if (!flag7)
								{
									bool flag9;
									do
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2916 @ X8_v126+20]");
										obj7 = 0;
										nint num4 = (nint)obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2916 @ X8_v126+54]");
										obj8 = num4 + 0;
										bool flag8 = obj7 == null;
										flag9 = !flag8;
										obj9 = obj8;
									}
									while (flag9);
								}
								float z2 = (float)obj9 * ((float)Math.PI / 180f);
								vector2.x = 0f;
								vector2.y = 0f;
								vector2.z = z2;
								Quaternion localRotation2 = Quaternion.Euler(vector2 * 57.29578f);
								float w = localRotation2.w;
								ragdollRoot.localRotation = localRotation2;
							}
							Vector3 position = ((Transform)component3).position;
							Transform transform3 = base.transform;
							Vector3 position2 = transform3.position;
							float num5 = position.x - position2.x;
							num = position.y - position2.y;
							float z3 = position.z - position2.z;
							rootOffset = (Vector3)num5;
							rootOffset.y = num;
							rootOffset.z = z3;
							component4 = ragdollRoot;
							enumerator2 = (Dictionary<object, object>.Enumerator)num5;
							goto IL_067d;
						}
					}
					throw gameObject;
				}
				enumerator3.Dispose();
				list2 = list;
				goto IL_07e1;
				IL_067d:
				Rigidbody component5 = component4.GetComponent<Rigidbody>();
				if (component5 != null)
				{
					GameObject gameObject2 = component3.gameObject;
					HingeJoint hingeJoint = gameObject2.AddComponent<HingeJoint>();
					hingeJoint.connectedBody = component5;
					Vector3 position3 = ((Transform)component3).position;
					Vector3 connectedAnchor = ((Transform)component4).InverseTransformPoint(position3);
					hingeJoint.connectedAnchor = connectedAnchor;
					nint num6 = (nint)typeof(Vector3);
					nint num7 = (nint)Vector3.zero;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1149 @ X8_v116 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
					float z3 = 0f;
					hingeJoint.axis = Vector3.forward;
					Rigidbody component6 = hingeJoint.GetComponent<Rigidbody>();
					Rigidbody connectedBody = hingeJoint.connectedBody;
					float mass = connectedBody.mass;
					float mass2 = mass * massFalloffFactor;
					component6.mass = mass2;
					float min = 0f - rotationLimit;
					jointLimits.min = min;
					jointLimits.max = rotationLimit;
					hingeJoint.limits = (JointLimits)(&jointLimits);
					hingeJoint.useLimits = true;
					hingeJoint.enableCollision = enableJointCollision;
					num = num8;
					enumerator2 = (Dictionary<object, object>.Enumerator)jointLimits;
				}
				continue;
				IL_07e1:
				int num9 = list2.Count;
				if (list2.Count >= 1)
				{
					int num10 = 0;
					do
					{
						if (num9 >= 1)
						{
							int num11 = 0;
							int num12 = num9;
							bool flag10;
							do
							{
								if (num10 != num11)
								{
									Collider collider = list2[num10];
									Collider collider2 = list2[num11];
									Physics.IgnoreCollision(collider, collider2);
									num12 = list2.Count;
								}
								num11++;
								flag10 = num11 < num12;
								num9 = num12;
							}
							while (flag10);
						}
						num10++;
					}
					while (num10 < num9);
				}
				SkeletonUtilityBone[] componentsInChildren = GetComponentsInChildren<SkeletonUtilityBone>();
				if (componentsInChildren.Length != 0)
				{
					List<string> list3 = new List<string>();
					int num13 = componentsInChildren.Length;
					if (componentsInChildren.Length >= 1)
					{
						int num14 = 0;
						do
						{
							Component component7 = componentsInChildren[num14];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ X22_v39 (UnityEngine.Component)+30]");
							if ((nint)0 == 1)
							{
								GameObject gameObject3 = componentsInChildren[num14].gameObject;
								string text = gameObject3.name;
								string[] items2 = list3._items;
								int version2 = list3._version + 1;
								list3._version = version2;
								int count2 = list3.Count;
								if (list3.Count < items2.Length)
								{
									int size2 = list3.Count + 1;
									list3._size = size2;
									items2[count2] = text;
								}
								else
								{
									list3.Add(text);
								}
								GameObject obj10 = componentsInChildren[num14].gameObject;
								UnityEngine.Object.Destroy(obj10);
								num13 = componentsInChildren.Length;
							}
							num14++;
						}
						while (num14 < num13);
					}
					if (list3.Count >= 1)
					{
						string text2 = "Destroyed Utility Bones: ";
						int num15 = 0;
						int count3;
						do
						{
							string text3 = list3[num15];
							string text4 = text2 + text3;
							count3 = list3.Count;
							int num16 = list3.Count - 1;
							bool flag11 = num15 == num16;
							text2 = text4;
							if (!flag11)
							{
								string text5 = text4 + ",";
								count3 = list3.Count;
								text2 = text5;
							}
							num15++;
						}
						while (num15 < count3);
						Debug.LogWarning(text2);
					}
				}
				if (disableIK)
				{
					Skeleton skeleton = this.skeleton;
					ExposedList<IkConstraint> ikConstraints = skeleton.IkConstraints;
					if (ikConstraints.Count >= 1)
					{
						IkConstraint[] items3 = ikConstraints.Items;
						int num17 = 0;
						do
						{
							IkConstraint ikConstraint = items3[num17];
							num17++;
							ikConstraint.Mix = 0f;
						}
						while (ikConstraints.Count != num17);
					}
				}
				if (disableOtherConstraints)
				{
					Skeleton skeleton2 = this.skeleton;
					ExposedList<TransformConstraint> transformConstraints = skeleton2.TransformConstraints;
					if (transformConstraints.Count >= 1)
					{
						TransformConstraint[] items4 = transformConstraints.Items;
						int num18 = 0;
						do
						{
							TransformConstraint transformConstraint = items4[num18];
							num18++;
							transformConstraint.RotateMix = 0f;
							transformConstraint.ScaleMix = 0f;
						}
						while (transformConstraints.Count != num18);
					}
					ExposedList<PathConstraint> pathConstraints = skeleton2.PathConstraints;
					if (pathConstraints.Count >= 1)
					{
						PathConstraint[] items5 = pathConstraints.Items;
						int num19 = 0;
						do
						{
							PathConstraint pathConstraint = items5[num19];
							num19++;
							pathConstraint.RotateMix = 0f;
						}
						while (pathConstraints.Count != num19);
					}
				}
				UpdateBonesDelegate value = UpdateSpineSkeleton;
				targetSkeletonComponent.UpdateWorld += value;
				return;
			}
			enumerator4.Dispose();
			OutOfMemoryException ex12 = new OutOfMemoryException();
			((Dictionary<Bone, Transform>.Enumerator*)ex12)->Dispose();
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x1519FB4", Offset = "0x1519FB4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Spine.Unity.Examples.SkeletonRagdoll::SmoothMixCoroutine(this, target, duration);\n\treturnVal1 = UnityEngine.MonoBehaviour::StartCoroutine(this, v6);\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Coroutine SmoothMix(float target, float duration)
		{
			IEnumerator routine = SmoothMixCoroutine(target, duration);
			return StartCoroutine(routine);
		}

		[IteratorStateMachine(typeof(_003CSmoothMixCoroutine_003Ed__41))]
		[Token(Token = "0x6000184")]
		[Address(RVA = "0x1519FD4", Offset = "0x1519FD4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = Spine.Unity.Examples.SkeletonRagdoll+<SmoothMixCoroutine>d__41;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, target, duration, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37A89]) = v43;\nL_0018:\n\tv45 = new Spine.Unity.Examples.SkeletonRagdoll+<SmoothMixCoroutine>d__41();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n\tv45.target = target;\n\tv45.duration = duration;\n\treturn v45;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator SmoothMixCoroutine(float target, float duration)
		{
			_003CSmoothMixCoroutine_003Ed__41 _003CSmoothMixCoroutine_003Ed__42 = null;
			_003CSmoothMixCoroutine_003Ed__42._003C_003E1__state = 0;
			_003CSmoothMixCoroutine_003Ed__42._003C_003E4__this = this;
			_003CSmoothMixCoroutine_003Ed__42.target = target;
			_003CSmoothMixCoroutine_003Ed__42.duration = duration;
			return _003CSmoothMixCoroutine_003Ed__42;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x151A070", Offset = "0x151A070", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = UnityEngine.Debug;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv225 = Il2CppMethodInfo;\n\tv226 = \"il2cpp_codegen_initialize_runtime_metadata\"(v225, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv273 = Il2CppMethodInfo;\n\tv274 = \"il2cpp_codegen_initialize_runtime_metadata\"(v273, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv277 = \"Can't call SetSkeletonPosition while Ragdoll is not active!\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v277, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37A8A]) = v53;\nL_002F:\n\tv54 = 0;\n\tv58 = ~this.isActive;\n\tif (v58) goto L_0088;\n\tv64 = UnityEngine.Component::get_transform(this);\n\tv74 = v64 == 0;\n\tif (v74) goto L_009D;\n\tv85 = UnityEngine.Transform::get_position(v64);\n\tv148 = UnityEngine.Component::get_transform(this);\n\tv154 = v148 == 0;\n\tif (v154) goto L_009D;\n\tUnityEngine.Transform::set_position(v148, worldPosition);\n\tv155 = this.boneTable == 0;\n\tif (v155) goto L_009D;\n\tv150 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Values(this.boneTable);\n\tv156 = v150 == 0;\n\tif (v156) goto L_009D;\n\tv159 = worldPosition - v85;\n\tv162 = worldPosition.y - v85.y;\n\tv165 = worldPosition.z - v85.z;\n\tv307 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>::GetEnumerator(v150);\nL_0063:\n\tv326 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv313 = v326 == 0;\n\tif (v313) goto L_0079;\n\tv330 = UnityEngine.Transform::get_position(0);\n\tv317 = v330 - v159;\n\tv179 = v330.y - v162;\n\tv174 = v330.z - v165;\n\t// 116 MakeStruct v316 @ AGG151E1E0_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v317 @ V0_v8 (System.Single), v179 @ V1_v3 (System.Single), v174 @ V2_v3 (System.Single)\n\tUnityEngine.Transform::set_position(0, v316);\n\tgoto L_0063;\nL_0079:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_007B:\n\tSpine.Unity.Examples.SkeletonRagdoll::UpdateSpineSkeleton(this, v145);\n\tv157 = this.skeleton == 0;\n\tif (v157) goto L_009D;\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\n\tgoto L_009B;\nL_0088:\n\tgoto L_008E;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\nL_008E:\n\tUnityEngine.Debug::LogWarning(\"Can't call SetSkeletonPosition while Ragdoll is not active!\");\nL_009B:\n\treturn;\n\tv147 = new System.NullReferenceException();\nL_009D:\n\tv184 = new System.NullReferenceException();\n\tgoto L_00AB;\n\tgoto L_00AB;\n\tgoto L_00AB;\nL_00AB:\n\tv229 = v140 != 1;\n\tif (v229) goto L_00BB;\n\tv279 = 0x1854E70(v184, v140, v39, v40, v41, v42, v43, v44, v136, v179, v174, v45, v46, v47, v48, v49);\n\tv290 = 0x1854E80(v279, v140, v39, v40, v41, v42, v43, v44, v136, v179, v174, v45, v46, v47, v48, v49);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv287 = *([v279 @ X0_v20]) == 0;\n\tif (v287) goto L_007B;\n\tthrow System.OutOfMemoryException;\nL_00BB:\n\tgoto L_00C1;\n\tX20 = X0;\nL_00C1:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_00C8;\n\tv298 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v184);\nL_00C8:\n\tv301 = new System.OutOfMemoryException();\n\tv259 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v301);\n\treturn;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetSkeletonPosition(Vector3 worldPosition)
		{
			//IL_0024: Expected O, but got I
			//IL_006e: Expected O, but got I4
			//IL_0370: Expected O, but got I
			//IL_00c5: Expected O, but got I4
			//IL_02b3: Expected O, but got I
			//IL_011c: Expected O, but got I4
			//IL_0285: Expected O, but got I
			//IL_0271: Expected O, but got F4
			Dictionary<object, object>.ValueCollection.Enumerator enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
			object obj;
			ISkeletonAnimation skeletonRenderer;
			Vector3 vector;
			float z;
			float y;
			if (IsActive)
			{
				Transform transform = base.transform;
				bool flag = (object)transform == null;
				obj = 0;
				if (!flag)
				{
					Vector3 position = transform.position;
					Transform transform2 = base.transform;
					bool flag2 = (object)transform2 == null;
					vector = worldPosition;
					obj = 0;
					z = worldPosition.z;
					y = worldPosition.y;
					if (!flag2)
					{
						transform2.position = worldPosition;
						bool flag3 = boneTable == null;
						vector = position;
						obj = 0;
						z = position.z;
						y = position.y;
						if (!flag3)
						{
							Dictionary<Bone, Transform>.ValueCollection values = boneTable.Values;
							bool flag4 = values == null;
							vector = worldPosition;
							obj = 0;
							z = worldPosition.z;
							y = worldPosition.y;
							if (!flag4)
							{
								Vector3 vector2 = default(Vector3);
								float num = vector2.x - position.x;
								float num2 = worldPosition.y - position.y;
								float num3 = worldPosition.z - position.z;
								Dictionary<Bone, Transform>.ValueCollection.Enumerator enumerator2 = values.GetEnumerator();
								vector = worldPosition;
								z = worldPosition.z;
								y = worldPosition.y;
								Vector3 position3 = default(Vector3);
								while (enumerator.MoveNext())
								{
									Vector3 position2 = ((Transform)null).position;
									float num4 = position2.x - num;
									y = position2.y - num2;
									z = position2.z - num3;
									position3.x = num4;
									position3.y = y;
									position3.z = z;
									((Transform)null).position = position3;
									vector = (Vector3)num4;
								}
								enumerator.Dispose();
								skeletonRenderer = (ISkeletonAnimation)0;
								goto IL_028a;
							}
						}
					}
				}
				goto IL_0300;
			}
			Debug.LogWarning("Can't call SetSkeletonPosition while Ragdoll is not active!");
			return;
			IL_0300:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)obj == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj2 = default(object);
				bool flag5 = obj2 == null;
				skeletonRenderer = (ISkeletonAnimation)0;
				if (!flag5)
				{
					throw new OutOfMemoryException();
				}
				goto IL_028a;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)ex2)->Dispose();
			return;
			IL_028a:
			UpdateSpineSkeleton(skeletonRenderer);
			bool flag6 = skeleton == null;
			vector = worldPosition;
			obj = 0;
			z = worldPosition.z;
			y = worldPosition.y;
			if (!flag6)
			{
				skeleton.UpdateWorldTransform();
				return;
			}
			goto IL_0300;
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x151A860", Offset = "0x151A860", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv160 = Il2CppMethodInfo;\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv163 = Il2CppMethodInfo;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv189 = Il2CppMethodInfo;\n\tv190 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv205 = Spine.Unity.ISkeletonAnimation;\n\tv206 = \"il2cpp_codegen_initialize_runtime_metadata\"(v205, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv221 = UnityEngine.Object;\n\tv222 = \"il2cpp_codegen_initialize_runtime_metadata\"(v221, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv229 = Il2CppMethodInfo;\n\tv230 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv240 = Spine.Unity.UpdateBonesDelegate;\n\tv241 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv249 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v249, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37A8B]) = v48;\nL_0036:\n\tthis.isActive = 0;\n\tv53 = this.boneTable == 0;\n\tif (v53) goto L_00C8;\n\tv60 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Values(this.boneTable);\n\tv145 = v60 == 0;\n\tif (v145) goto L_00C8;\n\tv176 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>::GetEnumerator(v60);\nL_0058:\n\tv216 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v108 @ stack_-88_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv224 = v216 == 0;\n\tif (v224) goto L_006E;\n\tv243 = UnityEngine.Component::get_gameObject(v192);\n\tgoto L_006A;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v250, v242, v31, v32, v33, v34, v35, v36, v105, v38, v39, v40, v41, v42, v43, v44);\nL_006A:\n\tUnityEngine.Object::Destroy(v243);\n\tgoto L_0058;\nL_006E:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v108 @ stack_-88_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_0070:\n\tv146 = this.ragdollRoot == 0;\n\tif (v146) goto L_00C8;\n\tv253 = UnityEngine.Component::get_gameObject(this.ragdollRoot);\n\tgoto L_007E;\n\tv322 = v152;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v322, v252, v92, v89, v33, v34, v35, v36, v106, v38, v39, v40, v41, v42, v43, v44);\nL_007E:\n\tUnityEngine.Object::Destroy(v253);\n\tv147 = this.boneTable == 0;\n\tif (v147) goto L_00C8;\n\tSystem.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Clear(this.boneTable);\n\tv157 = this.targetSkeletonComponent;\n\tv142 = new *([v122 @ X24_v2 (Il2CppClass<Spine.Unity.UpdateBonesDelegate>)])();\n\tv91 = *([v119 @ X23_v2 (Il2CppMethodInfo)]);\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v142, this, *([v119 @ X23_v2 (Il2CppMethodInfo)]));\n\tv148 = this.targetSkeletonComponent == 0;\n\tif (v148) goto L_00C8;\n\tv328 = *([v157 @ X20_v6 (Spine.Unity.ISkeletonAnimation)]);\n\tv371 = *([v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]);\n\tv315 = *([v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]) == 0;\n\tif (v315) goto L_00AF;\n\tv370 = *([v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+B0]) + 8;\nL_009A:\n\tv376 = *([v370 @ X10_v5-8]) == *([v116 @ X22_v2 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)]);\n\tif (v376) goto L_00B2;\n\tv356 = v371 - 1;\n\tv370 = v370 + 0x10;\n\tv336 = v371 != 1;\n\tif (v336) goto L_009A;\nL_00AF:\n\t;\n\tgoto L_00BA;\nL_00B2:\n\t;\nL_00BA:\n\tv313 = Spine.Unity.ISkeletonAnimation::remove_UpdateWorld(this.targetSkeletonComponent, v142);\n\treturn;\n\tv139 = new System.NullReferenceException();\nL_00C8:\n\tv158 = new System.NullReferenceException();\n\tgoto L_00D5;\n\tgoto L_00D5;\nL_00D5:\n\tv187 = v133 != 1;\n\tif (v187) goto L_00E3;\n\tv194 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::MoveNext(v158);\n\tv217 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::MoveNext(v194);\n\tv135 = *([v111 @ X27_v1 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v103 @ stack_-70_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv202 = ~v194.m_value;\n\tif (v202) goto L_0070;\n\tthrow System.OutOfMemoryException;\nL_00E3:\n\tgoto L_00E7;\n\tX20 = X0;\nL_00E7:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v103 @ stack_-70_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_00EE;\n\tv235 = 0xBD3CD0(v158, *([v111 @ X27_v1 (Il2CppMethodInfo)]), v91, v88, v33, v34, v35, v36, v104, v38, v39, v40, v41, v42, v43, v44);\nL_00EE:\n\tv238 = new System.OutOfMemoryException();\n\tv247 = 0x9DACB4(v238, *([v111 @ X27_v1 (Il2CppMethodInfo)]), v91, v88, v33, v34, v35, v36, v104, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Remove()
		{
			//IL_0448: Expected O, but got I4
			//IL_0476: Expected I, but got O
			//IL_0057: Expected I, but got O
			//IL_006b: Expected I, but got O
			//IL_00ef: Expected I, but got O
			//IL_0103: Expected I, but got O
			//IL_0276: Expected I, but got O
			//IL_028c: Expected I, but got O
			//IL_029c: Expected O, but got I
			//IL_02d7: Expected O, but got I
			//IL_02eb: Expected O, but got I
			//IL_02fa: Expected O, but got I
			isActive = false;
			bool flag = boneTable == null;
			object obj = 0;
			Dictionary<object, object>.ValueCollection.Enumerator enumerator2 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			Dictionary<object, object>.ValueCollection.Enumerator enumerator = enumerator2;
			nint num2 = default(nint);
			nint num = num2;
			nint num4 = default(nint);
			nint num3 = num4;
			nint num6 = default(nint);
			nint num5 = num6;
			nint num8 = default(nint);
			nint num7 = num8;
			nint num9 = (nint)this;
			object obj2 = default(object);
			IntPtr intPtr2 = default(IntPtr);
			object obj4;
			IntPtr intPtr3;
			Dictionary<object, object>.ValueCollection.Enumerator enumerator3 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			nint num10;
			IntPtr intPtr = default(IntPtr);
			if (!flag)
			{
				Dictionary<Bone, Transform>.ValueCollection values = boneTable.Values;
				bool flag2 = values == null;
				obj = obj2;
				intPtr = intPtr2;
				Dictionary<object, object>.ValueCollection.Enumerator enumerator4 = default(Dictionary<object, object>.ValueCollection.Enumerator);
				enumerator3 = enumerator4;
				enumerator = enumerator4;
				num = 0;
				num3 = (nint)typeof(ISkeletonAnimation);
				num5 = 0;
				num7 = (nint)typeof(UpdateBonesDelegate);
				num9 = 0;
				if (!flag2)
				{
					Dictionary<Bone, Transform>.ValueCollection.Enumerator enumerator5 = values.GetEnumerator();
					Component component = default(Component);
					while (enumerator4.MoveNext())
					{
						GameObject obj3 = component.gameObject;
						UnityEngine.Object.Destroy(obj3);
					}
					enumerator4.Dispose();
					obj4 = obj2;
					intPtr3 = intPtr2;
					enumerator3 = enumerator4;
					enumerator2 = enumerator4;
					num2 = 0;
					num4 = (nint)typeof(ISkeletonAnimation);
					num6 = 0;
					num8 = (nint)typeof(UpdateBonesDelegate);
					num10 = 0;
					goto IL_010f;
				}
			}
			goto IL_0331;
			IL_010f:
			bool flag3 = (object)ragdollRoot == null;
			obj = obj2;
			intPtr = intPtr2;
			enumerator3 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			Dictionary<object, object>.ValueCollection.Enumerator enumerator6 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			enumerator = enumerator6;
			IntPtr intPtr4 = default(IntPtr);
			num = intPtr4;
			IntPtr intPtr5 = default(IntPtr);
			num3 = intPtr5;
			IntPtr intPtr6 = default(IntPtr);
			num5 = intPtr6;
			IntPtr intPtr7 = default(IntPtr);
			num7 = intPtr7;
			num9 = 0;
			if (!flag3)
			{
				GameObject obj5 = ragdollRoot.gameObject;
				UnityEngine.Object.Destroy(obj5);
				bool flag4 = boneTable == null;
				obj = obj4;
				intPtr = intPtr3;
				enumerator = enumerator2;
				num = num2;
				num3 = num4;
				num5 = num6;
				num7 = num8;
				num9 = num10;
				if (!flag4)
				{
					boneTable.Clear();
					ISkeletonAnimation skeletonAnimation = targetSkeletonComponent;
					UpdateBonesDelegate value = new UpdateBonesDelegate(this, num6);
					intPtr = num6;
					bool flag5 = targetSkeletonComponent == null;
					obj = obj4;
					intPtr = intPtr3;
					enumerator = enumerator2;
					num = num2;
					num3 = num4;
					num5 = num6;
					num7 = num8;
					num9 = unchecked((nint)null);
					if (!flag5)
					{
						nint num11 = (nint)skeletonAnimation;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+B0]");
							object obj7 = (nint)0 + (nint)8;
							bool flag6;
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ X10_v5-8]");
								if (0 != num4)
								{
									object obj8 = (nint)obj6 - 1;
									obj7 = (nint)obj7 + 16;
									flag6 = (nint)obj6 != 1;
									obj6 = obj8;
									continue;
								}
								break;
							}
							while (flag6);
						}
						targetSkeletonComponent.UpdateWorld -= value;
						return;
					}
				}
			}
			goto IL_0331;
			IL_0331:
			NullReferenceException ex = new NullReferenceException();
			if (num9 == 1)
			{
				bool flag7 = ((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)ex)->MoveNext();
				bool flag8 = (flag7 ? ((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)1) : ((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)null))->MoveNext();
				num10 = num;
				enumerator3.Dispose();
				bool flag9 = !((bool*)(flag7 ? 1 : 0))->m_value;
				obj4 = obj;
				intPtr3 = intPtr;
				enumerator2 = enumerator;
				num2 = num;
				num4 = num3;
				num6 = num5;
				num8 = num7;
				if (!flag9)
				{
					throw new OutOfMemoryException();
				}
				goto IL_010f;
			}
			enumerator3.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x151AB34", Offset = "0x151AB34", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, boneName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, boneName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, boneName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37A8C]) = v37;\nL_001D:\n\tv45 = Spine.Skeleton::FindBone(this.skeleton, boneName);\n\tv68 = v45 == 0;\n\tif (v68) goto L_0046;\n\tv72 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::ContainsKey(this.boneTable, v45);\n\tv74 = v72 == 0;\n\tif (v74) goto L_0046;\n\tv55 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, v45);\n\treturnVal3 = UnityEngine.Component::GetComponent(v55);\n\treturn returnVal3;\nL_0046:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Rigidbody GetRigidbody(string boneName)
		{
			Bone bone = skeleton.FindBone(boneName);
			if (bone != null && boneTable.ContainsKey(bone))
			{
				Component component = boneTable[bone];
				return component.GetComponent<Rigidbody>();
			}
			return null;
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0x1519BD0", Offset = "0x1519BD0", Length = "0x3B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv178 = Il2CppMethodInfo;\n\tv179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v178, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv181 = Il2CppMethodInfo;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv199 = Il2CppMethodInfo;\n\tv200 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv218 = Il2CppMethodInfo;\n\tv219 = \"il2cpp_codegen_initialize_runtime_metadata\"(v218, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv271 = Il2CppMethodInfo;\n\tv272 = \"il2cpp_codegen_initialize_runtime_metadata\"(v271, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv310 = Il2CppMethodInfo;\n\tv311 = \"il2cpp_codegen_initialize_runtime_metadata\"(v310, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv318 = UnityEngine.GameObject;\n\tv319 = \"il2cpp_codegen_initialize_runtime_metadata\"(v318, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv324 = Il2CppMethodInfo;\n\tv325 = \"il2cpp_codegen_initialize_runtime_metadata\"(v324, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv328 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v328, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37A8D]) = v41;\nL_0032:\n\tv42 = 0;\n\tv45 = b == 0;\n\tif (v45) goto L_00FB;\n\tv49 = b.data;\n\tv50 = b.data == 0;\n\tif (v50) goto L_00FB;\n\tv156 = this.stopBoneNames == 0;\n\tif (v156) goto L_00FB;\n\tv186 = System.Collections.Generic.List`1<System.String>::Contains(this.stopBoneNames, v49.name);\n\tv202 = v186 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_00FA;\n\tv147 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v147, v49.name);\n\tv157 = v147 == 0;\n\tif (v157) goto L_00FB;\n\tUnityEngine.GameObject::set_layer(v147, this.colliderLayer);\n\tv148 = UnityEngine.GameObject::get_transform(v147);\n\tv158 = this.boneTable == 0;\n\tif (v158) goto L_00FB;\n\tSystem.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Add(this.boneTable, b, v148);\n\tv149 = UnityEngine.Component::get_transform(this);\n\tv159 = v148 == 0;\n\tif (v159) goto L_00FB;\n\tUnityEngine.Transform::set_parent(v148, v149);\n\t// 113 MakeStruct v110 @ AGG151DD58_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), b.worldX (System.Single), b.worldY (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(v148, v110);\n\tv342 = Spine.Bone::get_WorldRotationX(b);\n\tv346 = v342 - b.shearX;\n\tv348 = v346 * 0.017453292f;\n\t// 126 MakeStruct v107 @ AGG151DD88_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v348 @ V2_v5 (System.Single)\n\tv350 = UnityEngine.Quaternion::Internal_FromEulerRad(v107);\n\tUnityEngine.Transform::set_localRotation(v148, v350);\n\tv357 = Spine.Bone::get_WorldScaleX(b);\n\tv360 = Spine.Bone::get_WorldScaleY(b);\n\t// 147 MakeStruct v95 @ AGG151DDC8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v357 @ V0_v8 (System.Single), v360 @ V0_v9 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v148, v95);\n\tv150 = Spine.Unity.Examples.SkeletonRagdoll::AttachBoundingBoxRagdollColliders(this, b);\n\tv160 = v150 == 0;\n\tif (v160) goto L_00FB;\n\tv365 = v150._size == 0;\n\tv366 = ~v365;\n\tif (v366) goto L_00D4;\n\tv170 = b.data;\n\tv161 = b.data == 0;\n\tif (v161) goto L_00FB;\n\tv59 = v170.length != 0;\n\tif (v59) goto L_00BE;\n\tv151 = UnityEngine.GameObject::AddComponent(v147);\n\tv162 = v151 == 0;\n\tif (v162) goto L_00FB;\n\tv373 = this.thickness * 0.5f;\n\tUnityEngine.SphereCollider::set_radius(v151, v373);\n\tgoto L_00D4;\nL_00BE:\n\tv152 = UnityEngine.GameObject::AddComponent(v147);\n\tv163 = v152 == 0;\n\tif (v163) goto L_00FB;\n\t// 198 MakeStruct v368 @ AGG151DE54_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v170.length (System.Single), this.thickness (System.Single), this.thickness (System.Single)\n\tUnityEngine.BoxCollider::set_size(v152, v368);\n\tv372 = v170.length * 0.5f;\n\t// 206 MakeStruct v367 @ AGG151DE70_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v372 @ V0_v14 (System.Single), 0, 0\n\tUnityEngine.BoxCollider::set_center(v152, v367);\nL_00D4:\n\tv153 = UnityEngine.GameObject::AddComponent(v147);\n\tv164 = v153 == 0;\n\tif (v164) goto L_00FB;\n\tUnityEngine.Rigidbody::set_constraints(v153, 8);\n\tv165 = b.children == 0;\n\tif (v165) goto L_00FB;\n\tv398 = Spine.ExposedList`1<Spine.Bone>::GetEnumerator(b.children);\nL_00E6:\n\tv408 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv252 = v408 == 0;\n\tif (v252) goto L_00F2;\n\tSpine.Unity.Examples.SkeletonRagdoll::RecursivelyCreateBoneProxies(this, 0);\n\tgoto L_00E6;\nL_00F2:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00FA:\n\treturn;\nL_00FB:\n\tv176 = new System.NullReferenceException();\n\tgoto L_0107;\nL_0107:\n\tv197 = v122 != 1;\n\tif (v197) goto L_0117;\n\tv205 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Add(v176, v122, v131);\n\tv265 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Add(v205, v122, v131);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv211 = *([v205 @ X0_v13 (System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>)]) == 0;\n\tif (v211) goto L_00FA;\n\tthrow System.OutOfMemoryException;\nL_0117:\n\tgoto L_011D;\n\tX20 = X0;\nL_011D:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0124;\n\tv313 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v176);\nL_0124:\n\tv316 = new System.OutOfMemoryException();\n\tv300 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v316);\n\treturn;\n// 176 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RecursivelyCreateBoneProxies(Bone b)
		{
			//IL_057b: Expected O, but got I
			//IL_058c: Expected O, but got I
			//IL_00dc: Expected I, but got O
			//IL_0126: Expected I, but got O
			//IL_0173: Expected I, but got O
			//IL_02d9: Expected I, but got O
			//IL_04b8: Expected O, but got I
			//IL_04bd: Expected I, but got O
			//IL_0343: Expected I, but got O
			//IL_04f7: Expected O, but got I4
			//IL_04fc: Expected I, but got O
			//IL_03f5: Expected O, but got I
			//IL_03fa: Expected I, but got O
			//IL_039b: Expected O, but got I
			//IL_03a0: Expected I, but got O
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			bool flag = b == null;
			Bone bone = b;
			GameObject gameObject;
			nint num = default(nint);
			if (!flag)
			{
				BoneData data = b.Data;
				bool flag2 = b.Data == null;
				bone = b;
				if (!flag2)
				{
					bool flag3 = stopBoneNames == null;
					bone = b;
					if (!flag3)
					{
						if (stopBoneNames.Contains(data.Name))
						{
							return;
						}
						gameObject = new GameObject(data.Name);
						bool flag4 = (object)gameObject == null;
						bone = (Bone)(object)data.Name;
						num = unchecked((nint)null);
						if (!flag4)
						{
							gameObject.layer = colliderLayer;
							Transform transform = gameObject.transform;
							bool flag5 = boneTable == null;
							bone = null;
							num = unchecked((nint)null);
							if (!flag5)
							{
								boneTable.Add(b, transform);
								Transform parent = base.transform;
								bool flag6 = (object)transform == null;
								bone = null;
								num = (nint)transform;
								if (!flag6)
								{
									transform.parent = parent;
									Vector3 localPosition = default(Vector3);
									localPosition.x = b.WorldX;
									localPosition.y = b.WorldY;
									localPosition.z = 0f;
									transform.localPosition = localPosition;
									float worldRotationX = b.WorldRotationX;
									float num2 = worldRotationX - b.ShearX;
									float z = num2 * ((float)Math.PI / 180f);
									Vector3 vector = default(Vector3);
									vector.x = 0f;
									vector.y = 0f;
									vector.z = z;
									Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
									transform.localRotation = localRotation;
									float worldScaleX = b.WorldScaleX;
									float worldScaleY = b.WorldScaleY;
									Vector3 localScale = default(Vector3);
									localScale.x = worldScaleX;
									localScale.y = worldScaleY;
									localScale.z = 1f;
									transform.localScale = localScale;
									List<Collider> list = AttachBoundingBoxRagdollColliders(b);
									bool flag7 = list == null;
									bone = b;
									num = unchecked((nint)null);
									if (!flag7)
									{
										if (list.Count != 0)
										{
											goto IL_0495;
										}
										BoneData data2 = b.Data;
										bool flag8 = b.Data == null;
										bone = b;
										num = unchecked((nint)null);
										if (!flag8)
										{
											if (data2.Length == 0f)
											{
												SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
												bool flag9 = (object)sphereCollider == null;
												bone = (Bone)0;
												num = unchecked((nint)null);
												if (!flag9)
												{
													float radius = thickness * 0.5f;
													sphereCollider.radius = radius;
													goto IL_0495;
												}
											}
											else
											{
												BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
												bool flag10 = (object)boxCollider == null;
												bone = (Bone)0;
												num = unchecked((nint)null);
												if (!flag10)
												{
													Vector3 size = default(Vector3);
													size.x = data2.Length;
													size.y = thickness;
													size.z = thickness;
													boxCollider.size = size;
													float x = data2.Length * 0.5f;
													Vector3 center = default(Vector3);
													center.x = x;
													center.y = 0f;
													center.z = 0f;
													boxCollider.center = center;
													goto IL_0495;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_053c;
			IL_0495:
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			bool flag11 = (object)rigidbody == null;
			bone = (Bone)0;
			num = unchecked((nint)null);
			if (!flag11)
			{
				rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
				bool flag12 = b.Children == null;
				bone = (Bone)8;
				num = unchecked((nint)null);
				if (!flag12)
				{
					ExposedList<Bone>.Enumerator enumerator2 = b.Children.GetEnumerator();
					while (enumerator.MoveNext())
					{
						RecursivelyCreateBoneProxies(null);
					}
					enumerator.Dispose();
					return;
				}
			}
			goto IL_053c;
			IL_053c:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)bone == 1)
			{
				((Dictionary<Bone, Transform>)(object)ex).Add(bone, (Transform)num);
				Dictionary<Bone, Transform> dictionary = default(Dictionary<Bone, Transform>);
				dictionary.Add(bone, (Transform)num);
				enumerator.Dispose();
				if (dictionary != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((ExposedList<Bone>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x151A2E4", Offset = "0x151A2E4", Length = "0x57C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv244 = Il2CppMethodInfo;\n\tv245 = \"il2cpp_codegen_initialize_runtime_metadata\"(v244, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv248 = Il2CppMethodInfo;\n\tv249 = \"il2cpp_codegen_initialize_runtime_metadata\"(v248, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv270 = Il2CppMethodInfo;\n\tv271 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv293 = Il2CppMethodInfo;\n\tv294 = \"il2cpp_codegen_initialize_runtime_metadata\"(v293, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv385 = Il2CppMethodInfo;\n\tv386 = \"il2cpp_codegen_initialize_runtime_metadata\"(v385, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv394 = Spine.Unity.Examples.SkeletonRagdoll;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v394, skeletonRenderer, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv68 = 1;\n\t*([1A37A8E]) = v68;\nL_003A:\n\tv73 = this.skeleton;\n\tv74 = this.skeleton == 0;\n\tif (v74) goto L_01D9;\n\tv83 = v73.scaleX < 0;\n\tv91 = Spine.Skeleton::get_ScaleY(this.skeleton);\n\tv217 = v91 < 0;\n\tv236 = this.boneTable == 0;\n\tif (v236) goto L_01D9;\n\tv180 = v83 ^ v217;\n\tv178 = v83 | v217;\n\tv257 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::GetEnumerator(this.boneTable);\nL_0073:\n\tv378 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v175 @ stack_-F8_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv388 = v378 == 0;\n\tif (v388) goto L_01B2;\n\tv400 = this.<StartingBone>k__BackingField == v274;\n\tif (v400) goto L_008E;\n\tv580 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, *([v274 @ stack_-E8+20]));\n\tgoto L_0092;\nL_008E:\n\tv574 = this.ragdollRoot;\nL_0092:\n\tv585 = this.<StartingBone>k__BackingField - v274;\n\tv587 = v585 == 0;\n\tv593 = ~this.oldRagdollBehaviour;\n\tv594 = v587 & v593;\n\tv596 = v594 == 0;\n\tif (v596) goto L_00E0;\n\tv773 = Spine.Skeleton::get_RootBone(this.skeleton);\n\tv762 = v773 == v274;\n\tif (v762) goto L_00E0;\n\tv777 = *([v274 @ stack_-E8+20]);\n\t// 188 MakeStruct v787 @ AGG151E4B8_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v777 @ X8_v37+74], [v777 @ X8_v37+80], 0\n\tUnityEngine.Transform::set_localPosition(this.ragdollRoot, v787);\n\tv792 = *([v274 @ stack_-E8+20]);\n\tv1158 = *([v792 @ X9_v9+20]);\n\tv1154 = *([v792 @ X9_v9+54]);\n\tv1151 = *([v792 @ X9_v9+20]) == 0;\n\tif (v1151) goto L_00CD;\nL_00C5:\n\t;\n\tv1158 = *([v1158 @ X8_v40+20]);\n\tv1154 = v1154 + *([v1158 @ X8_v40+54]);\n\tv1160 = v1158 == 0;\n\tv1157 = ~v1160;\n\tif (v1157) goto L_00C5;\nL_00CD:\n\tv1165 = v1162 * 0.017453292f;\n\t// 209 MakeStruct v784 @ AGG151E4F8_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v1165 @ V2_v29 (System.Single)\n\tv804 = UnityEngine.Quaternion::Internal_FromEulerRad(v784);\n\tUnityEngine.Transform::set_localRotation(this.ragdollRoot, v804);\nL_00E0:\n\tv854 = UnityEngine.Transform::get_position(v574);\n\tv938 = UnityEngine.Transform::get_rotation(v574);\n\tUnityEngine.Transform::set_position(v962.parentSpaceHelper, v854);\n\tUnityEngine.Transform::set_rotation(v1088.parentSpaceHelper, v938);\n\tv1139 = UnityEngine.Transform::get_localScale(v574);\n\tUnityEngine.Transform::set_localScale(v1143.parentSpaceHelper, v1139);\n\tv1170 = UnityEngine.Transform::get_position(v395);\n\tv1027 = UnityEngine.Transform::get_right(v395);\n\tv1123 = UnityEngine.Transform::InverseTransformDirection(v1033.parentSpaceHelper, v1027);\n\tv1179 = UnityEngine.Transform::InverseTransformPoint(v1129.parentSpaceHelper, v1170);\n\tv370 = 0x1854F00(v1129.parentSpaceHelper, 0, Il2CppMethodInfo, v52, v53, v54, v55, v56, v1123.y, v1123, v1179.z, v938.w, *([v274 @ stack_-E8+38]), v100, v96, 0);\n\tv1216 = v1123.y * 57.29578f;\n\tv1188 = v178 == 0;\n\tif (v1188) goto L_018B;\n\tv1193 = this.<StartingBone>k__BackingField == v274;\n\tif (v1193) goto L_0157;\n\tv1218 = ~v180;\n\tif (v1218) goto L_018B;\n\tv1216 = -v1216;\n\tv318 = -v1179.y;\n\tgoto L_018B;\nL_0157:\n\tv1221 = -v1179.y;\n\tv1231 = v91 >= 0;\n\tif (v1231) goto L_FFFFFFFF;\n\tgoto L_0168;\nL_0168:\n\tv1203 = -v1216;\n\tv1246 = v180 == 0;\n\tv1251 = ~v1246;\n\tv1199 = ~v1251;\n\tif (v1199) goto L_0182;\n\tgoto L_0182;\nL_0182:\n\tv1198 = v73.scaleX >= 0;\n\tif (v1198) goto L_018B;\n\tv320 = -v1179;\n\tv1216 = v1216 + 0x43340000;\nL_018B:\n\t;\n\tv102 = *([v274 @ stack_-E8+38]);\n\tv360 = this.mix < 0;\n\tv1256 = UnityEngine.Mathf::Min(this.mix, 1f);\n\tv1239 = v320 - *([v274 @ stack_-E8+30]);\n\tv1240 = v318 - *([v274 @ stack_-E8+34]);\n\tv1241 = v1216 - *([v274 @ stack_-E8+38]);\n\tv296 = ~v360;\n\tv302 = ~v296;\n\tif (v302) goto L_FFFFFFFF;\n\tgoto L_01A4;\nL_01A4:\n\tv100 = v1239 * v1256;\n\tv96 = v1240 * v1256;\n\tv1257 = v1256 * v1241;\n\tv346 = *([v274 @ stack_-E8+30]) + v100;\n\tv344 = *([v274 @ stack_-E8+34]) + v96;\n\tv368 = *([v274 @ stack_-E8+38]) + v1257;\n\t*([v274 @ stack_-E8+30]) = v346;\n\t*([v274 @ stack_-E8+34]) = v344;\n\t*([v274 @ stack_-E8+38]) = v368;\n\tgoto L_0073;\nL_01B2:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v175 @ stack_-F8_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_01C8:\n\treturn;\n\tv1135 = new System.NullReferenceException();\n\tv883 = new System.NullReferenceException();\n\tv888 = new System.NullReferenceException();\n\tv963 = new System.NullReferenceException();\n\tv1034 = new System.NullReferenceException();\n\tv1086 = new System.NullReferenceException();\n\tv1130 = new System.NullReferenceException();\n\tv723 = new System.NullReferenceException();\n\tv728 = new System.NullReferenceException();\n\tv568 = new System.NullReferenceException();\n\tv573 = new System.NullReferenceException();\n\tv778 = new System.NullReferenceException();\n\tv851 = new System.NullReferenceException();\n\tv932 = new System.NullReferenceException();\n\tv1002 = new System.NullReferenceException();\n\tv232 = new System.NullReferenceException();\nL_01D9:\n\tv242 = new System.NullReferenceException();\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\nL_0203:\n\tv268 = v227 != 1;\n\tif (v268) goto L_0213;\n\tv280 = 0x1854E70(v242, v227, v150, v52, v53, v54, v55, v56, v229, v170, v168, v139, v101, v99, v95, v97);\n\tv379 = 0x1854E80(v280, v227, v150, v52, v53, v54, v55, v56, v229, v170, v168, v139, v101, v99, v95, v97);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v163 @ stack_-D0_v2 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv286 = *([v280 @ X0_v14]) == 0;\n\tif (v286) goto L_01C8;\n\tthrow System.OutOfMemoryException;\nL_0213:\n\tgoto L_0219;\n\tX19 = X0;\nL_0219:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v163 @ stack_-D0_v2 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_0220;\n\tv410 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.\n// ... truncated")]
		private unsafe void UpdateSpineSkeleton(ISkeletonAnimation skeletonRenderer)
		{
			//IL_06ad: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_0159: Expected O, but got I
			//IL_0175: Expected F4, but got I
			//IL_018a: Expected F4, but got I
			//IL_01b7: Expected O, but got I
			//IL_01cc: Expected O, but got I
			//IL_01dc: Expected O, but got I
			//IL_0203: Expected O, but got I
			//IL_0222: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_04d5: Expected O, but got I
			//IL_04a9: Unsupported input type for neg.
			//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ae: Expected O, but got Unknown
			Skeleton skeleton = this.skeleton;
			bool flag = this.skeleton == null;
			float num2 = default(float);
			float num = num2;
			float num4 = default(float);
			float num3 = num4;
			float num6 = default(float);
			float num5 = num6;
			object obj2 = default(object);
			object obj = obj2;
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr = intPtr2;
			Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
			ISkeletonAnimation skeletonAnimation = null;
			float num8 = default(float);
			float num7 = num8;
			if (!flag)
			{
				bool flag2 = skeleton.ScaleX < 0f;
				num8 = this.skeleton.ScaleY;
				bool flag3 = num8 < 0f;
				bool flag4 = boneTable == null;
				num = num2;
				num3 = num4;
				num5 = num6;
				obj = obj2;
				IntPtr intPtr3 = default(IntPtr);
				intPtr = intPtr3;
				Dictionary<object, object>.Enumerator enumerator2 = default(Dictionary<object, object>.Enumerator);
				enumerator = enumerator2;
				ISkeletonAnimation skeletonAnimation2 = default(ISkeletonAnimation);
				skeletonAnimation = skeletonAnimation2;
				float num9 = default(float);
				num7 = num9;
				if (!flag4)
				{
					bool flag5 = flag2 ^ flag3;
					bool flag6 = flag2 || flag3;
					Dictionary<Bone, Transform>.Enumerator enumerator3 = boneTable.GetEnumerator();
					object obj3 = default(object);
					Vector3 localPosition = default(Vector3);
					Vector3 vector = default(Vector3);
					Transform transform3 = default(Transform);
					while (enumerator2.MoveNext())
					{
						Transform transform2;
						if (StartingBone != obj3)
						{
							Dictionary<Bone, Transform> dictionary = boneTable;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+20]");
							Transform transform = dictionary[(Bone)0];
							transform2 = transform;
						}
						else
						{
							transform2 = ragdollRoot;
						}
						object obj4 = (nint)StartingBone - (nint)obj3;
						bool flag7 = obj4 == null;
						int num10 = ((!oldRagdollBehaviour) ? 1 : 0);
						if (((flag7 ? 1u : 0u) & (uint)num10) != 0)
						{
							Bone rootBone = this.skeleton.RootBone;
							if (rootBone != obj3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+20]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ X8_v37+74]");
								localPosition.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ X8_v37+80]");
								localPosition.y = 0f;
								localPosition.z = 0f;
								ragdollRoot.localPosition = localPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+20]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X9_v9+20]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X9_v9+54]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X9_v9+20]");
								bool flag8 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X9_v9+54]");
								object obj9 = 0;
								if (!flag8)
								{
									bool flag10;
									do
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v40+20]");
										obj7 = 0;
										nint num11 = (nint)obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v40+54]");
										obj8 = num11 + 0;
										bool flag9 = obj7 == null;
										flag10 = !flag9;
										obj9 = obj8;
									}
									while (flag10);
								}
								float z = (float)obj9 * ((float)Math.PI / 180f);
								vector.x = 0f;
								vector.y = 0f;
								vector.z = z;
								Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
								ragdollRoot.localRotation = localRotation;
							}
						}
						Vector3 position = transform2.position;
						Quaternion rotation = transform2.rotation;
						parentSpaceHelper.position = position;
						parentSpaceHelper.rotation = rotation;
						Vector3 localScale = transform2.localScale;
						parentSpaceHelper.localScale = localScale;
						Vector3 position2 = transform3.position;
						Vector3 right = transform3.right;
						Vector3 vector2 = parentSpaceHelper.InverseTransformDirection(right);
						Vector3 vector3 = parentSpaceHelper.InverseTransformPoint(position2);
						Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @1854F00 (native atan2f)");
						float num12 = vector2.y * 57.29578f;
						bool flag11 = !flag6;
						float num13 = vector3.y;
						Vector3 vector4 = vector3;
						if (!flag11)
						{
							if (StartingBone != obj3)
							{
								bool flag12 = !flag5;
								num13 = vector3.y;
								vector4 = vector3;
								if (!flag12)
								{
									num12 = 0f - num12;
									num13 = 0f - vector3.y;
									vector4 = vector3;
								}
							}
							else
							{
								float num14 = 0f - vector3.y;
								num13 = ((!(num8 < 0f)) ? vector3.y : num14);
								float num15 = 0f - num12;
								if (flag5)
								{
									num12 = num15;
								}
								bool flag13 = !(skeleton.ScaleX < 0f);
								vector4 = vector3;
								if (!flag13)
								{
									vector4 = 0 - vector3;
									num12 += 180f;
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+38]");
						obj2 = 0;
						bool flag14 = mix < 0f;
						float num16 = Mathf.Min(mix, 1f);
						float num17 = vector4.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+30]");
						float num18 = num17 - 0f;
						float num19 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+34]");
						float num20 = num19 - 0f;
						float num21 = num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+38]");
						float num22 = num21 - 0f;
						if (flag14)
						{
							num16 = 0f;
						}
						num6 = num18 * num16;
						num2 = num20 * num16;
						float num23 = num16 * num22;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+30]");
						float num24 = 0f + num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+34]");
						float num25 = 0f + num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+38]");
						float num26 = 0f + num23;
					}
					enumerator2.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if ((nint)skeletonAnimation == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj10 = default(object);
				if (obj10 != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((Dictionary<Bone, Transform>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0x151AC04", Offset = "0x151AC04", Length = "0x5B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005C;\n\tv44 = Spine.BoundingBoxAttachment;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv227 = Il2CppMethodInfo;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv358 = Il2CppMethodInfo;\n\tv359 = \"il2cpp_codegen_initialize_runtime_metadata\"(v358, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv453 = Il2CppMethodInfo;\n\tv454 = \"il2cpp_codegen_initialize_runtime_metadata\"(v453, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv459 = Il2CppMethodInfo;\n\tv460 = \"il2cpp_codegen_initialize_runtime_metadata\"(v459, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv476 = Il2CppMethodInfo;\n\tv477 = \"il2cpp_codegen_initialize_runtime_metadata\"(v476, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv569 = Il2CppMethodInfo;\n\tv570 = \"il2cpp_codegen_initialize_runtime_metadata\"(v569, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv641 = Il2CppMethodInfo;\n\tv642 = \"il2cpp_codegen_initialize_runtime_metadata\"(v641, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv700 = Il2CppMethodInfo;\n\tv701 = \"il2cpp_codegen_initialize_runtime_metadata\"(v700, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv760 = Il2CppMethodInfo;\n\tv761 = \"il2cpp_codegen_initialize_runtime_metadata\"(v760, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv879 = Il2CppMethodInfo;\n\tv880 = \"il2cpp_codegen_initialize_runtime_metadata\"(v879, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv934 = Il2CppMethodInfo;\n\tv935 = \"il2cpp_codegen_initialize_runtime_metadata\"(v934, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv954 = System.Collections.Generic.List`1<UnityEngine.Collider>;\n\tv955 = \"il2cpp_codegen_initialize_runtime_metadata\"(v954, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv959 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>;\n\tv960 = \"il2cpp_codegen_initialize_runtime_metadata\"(v959, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv966 = \"ragdoll\";\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v966, b, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv63 = 1;\n\t*([1A37A8F]) = v63;\nL_005C:\n\tv72 = new System.Collections.Generic.List`1<UnityEngine.Collider>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider>::.ctor(v72);\n\tv90 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, b);\n\tv199 = UnityEngine.Component::get_gameObject(v90);\n\tv215 = this.skeleton;\n\tv224 = v215.skin;\n\tv461 = v215.skin == 0;\n\tv462 = ~v461;\n\tif (v462) goto L_007D;\n\tv216 = v215.data;\n\tv224 = v216.defaultSkin;\nL_007D:\n\tv200 = new System.Collections.Generic.List`1<Spine.Skin+SkinEntry>();\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>::.ctor(v200);\n\tv217 = this.skeleton;\n\tv770 = Spine.ExposedList`1<Spine.Slot>::GetEnumerator(v217.slots);\nL_009A:\n\tv686 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v769 @ stack_-100_v10 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv957 = v686 == 0;\n\tif (v957) goto L_018E;\n\tv439 = v108 == 0;\n\tif (v439) goto L_01A1;\n\tv594 = v108.bone != b;\n\tif (v594) goto L_009A;\n\tv674 = this.skeleton;\n\tv626 = Spine.ExposedList`1<Spine.Slot>::IndexOf(v674.slots, v108);\n\tSpine.Skin::GetAttachments(v224, v626, v200);\n\tv976 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>::GetEnumerator(v200);\nL_00CF:\n\tv1008 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::MoveNext(&v974 @ stack_-100_v13 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv1020 = v1008 == 0;\n\tif (v1020) goto L_0151;\n\tv1013 = v980 == 0;\n\tif (v1013) goto L_00CF;\n\tgoto L_FFFFFFFF;\n\tv286 = v286_asT == 0;\n\tif (v286) goto L_00CF;\n\tv341 = v1028 == 0;\n\tif (v341) goto L_0162;\n\tv1030 = System.String::ToLower(v1028);\n\tv342 = v1030 == 0;\n\tif (v342) goto L_0164;\n\tv1009 = System.String::Contains(v1030, \"ragdoll\");\n\tv1014 = v1009 == 0;\n\tif (v1014) goto L_00CF;\n\tv343 = v199 == 0;\n\tif (v343) goto L_0166;\n\tv1036 = UnityEngine.GameObject::AddComponent(v199);\n\tv1038 = Spine.Unity.SkeletonUtility::GetBoundingBoxBounds(v980, this.thickness);\n\tv345 = v1036 == 0;\n\tif (v345) goto L_016A;\n\tUnityEngine.BoxCollider::set_center(v1036, v1038.m_Center);\n\tv312 = v1038.m_Extents + v1038.m_Extents;\n\tv282 = *([v1038 @ X0_v69 (UnityEngine.Bounds)+10]) + *([v1038 @ X0_v69 (UnityEngine.Bounds)+10]);\n\tv279 = *([v1038 @ X0_v69 (UnityEngine.Bounds)+14]) + *([v1038 @ X0_v69 (UnityEngine.Bounds)+14]);\n\t// 293 MakeStruct v231 @ AGG151EF68_1_v13 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v312 @ V0_v18 (System.Single), v282 @ V1_v15 (Spine.Slot), v279 @ V2_v15 (Spine.BoundingBoxAttachment)\n\tUnityEngine.BoxCollider::set_size(v1036, v231);\n\tv346 = v72 == 0;\n\tif (v346) goto L_016C;\n\tv351 = v72._items;\n\tv266 = v72._version + 1;\n\tv72._version = v266;\n\tv344 = v72._items == 0;\n\tif (v344) goto L_0168;\n\tv982 = v72._size;\n\tv1047 = v72._size < v351.Length;\n\tv1001 = ~v1047;\n\tif (v1001) goto L_0149;\n\tv1003 = v72._size + 1;\n\tv72._size = v1003;\n\tv351[v982 @ X10_v16 (System.Int32)] = v1036;\n\tgoto L_00CF;\nL_0149:\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider>::AddWithResize(v72, v1036);\n\tgoto L_00CF;\nL_0151:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v974 @ stack_-100_v13 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tgoto L_01B1;\n\tgoto L_009A;\n\tgoto L_0161;\nL_0161:\n\tgoto L_018E;\nL_0162:\n\tv333 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_0164:\n\tv333 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_0166:\n\tv333 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_0168:\n\tv333 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_016A:\n\tv333 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_016C:\n\tv333 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\n\tgoto L_017A;\nL_017A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01A2;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX25 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX26 = 0;\n\tgoto L_0151;\nL_018E:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v769 @ stack_-100_v10 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_01A0:\n\treturn v72;\nL_01A1:\n\tv437 = new System.NullReferenceException();\nL_01A2:\n\t;\nL_01A9:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v395 @ stack_-D0_v11 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv457 = v118 == 0;\n\tif (v457) goto L_01CD;\n\tthrow System.OutOfMemoryException;\nL_01B1:\n\tv554 = new System.OutOfMemoryException();\n\tv634 = new System.NullReferenceException();\n\tv694 = \n// ... truncated")]
		private unsafe List<Collider> AttachBoundingBoxRagdollColliders(Bone b)
		{
			//IL_0614: Expected O, but got I
			//IL_0625: Expected O, but got I
			//IL_0483: Expected I, but got O
			//IL_04ab: Expected I, but got O
			//IL_0503: Expected I, but got O
			//IL_02c1: Expected O, but got I
			//IL_02de: Expected O, but got I
			//IL_02f8: Expected F4, but got O
			//IL_0305: Expected F4, but got O
			//IL_052f: Expected I, but got O
			//IL_04d7: Expected I, but got O
			List<Collider> list = new List<Collider>();
			Component component = boneTable[b];
			GameObject gameObject = component.gameObject;
			Skeleton skeleton = this.skeleton;
			Skin skin = skeleton.Skin;
			if (skeleton.Skin == null)
			{
				SkeletonData data = skeleton.Data;
				skin = data.DefaultSkin;
			}
			List<Skin.SkinEntry> list2 = new List<Skin.SkinEntry>();
			Skeleton skeleton2 = this.skeleton;
			ExposedList<Slot>.Enumerator enumerator = skeleton2.Slots.GetEnumerator();
			List<Skin.SkinEntry>.Enumerator enumerator2 = default(List<Skin.SkinEntry>.Enumerator);
			ExposedList<object>.Enumerator enumerator3 = default(ExposedList<object>.Enumerator);
			Slot slot = default(Slot);
			List<Skin.SkinEntry>.Enumerator enumerator5 = default(List<Skin.SkinEntry>.Enumerator);
			BoundingBoxAttachment boundingBoxAttachment = default(BoundingBoxAttachment);
			string text = default(string);
			ExposedList<object>.Enumerator enumerator6;
			BoxCollider boxCollider2 = default(BoxCollider);
			Vector3 size = default(Vector3);
			while (true)
			{
				if (enumerator3.MoveNext())
				{
					NullReferenceException ex7;
					nint num4;
					if (slot != null)
					{
						if (slot.Bone != b)
						{
							continue;
						}
						Skeleton skeleton3 = this.skeleton;
						int slotIndex = skeleton3.Slots.IndexOf(slot);
						skin.GetAttachments(slotIndex, list2);
						List<Skin.SkinEntry>.Enumerator enumerator4 = list2.GetEnumerator();
						NullReferenceException ex;
						nint num;
						while (true)
						{
							if (enumerator5.MoveNext())
							{
								if (boundingBoxAttachment == null)
								{
									continue;
								}
								BoundingBoxAttachment boundingBoxAttachment2 = boundingBoxAttachment as BoundingBoxAttachment;
								if (boundingBoxAttachment2 == null)
								{
									continue;
								}
								if (text != null)
								{
									string text2 = text.ToLower();
									if (text2 != null)
									{
										if (text2.Contains("ragdoll"))
										{
											if ((object)gameObject == null)
											{
												ex = new NullReferenceException();
												enumerator2 = enumerator5;
												enumerator6 = enumerator3;
												num = unchecked((nint)"ragdoll");
												break;
											}
											BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
											Bounds boundingBoxBounds = SkeletonUtility.GetBoundingBoxBounds(boundingBoxAttachment, thickness);
											if ((object)boxCollider == null)
											{
												ex = new NullReferenceException();
												boxCollider2 = boxCollider;
												enumerator2 = enumerator5;
												enumerator6 = enumerator3;
												num = unchecked((nint)null);
												break;
											}
											boxCollider.center = boundingBoxBounds.m_Center;
											float x = boundingBoxBounds.m_Extents.x + boundingBoxBounds.m_Extents.x;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ X0_v69 (UnityEngine.Bounds)+10]");
											nint num2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ X0_v69 (UnityEngine.Bounds)+10]");
											Slot slot2 = (Slot)(num2 + 0);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ X0_v69 (UnityEngine.Bounds)+14]");
											nint num3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ X0_v69 (UnityEngine.Bounds)+14]");
											BoundingBoxAttachment boundingBoxAttachment3 = (BoundingBoxAttachment)(num3 + 0);
											size.x = x;
											size.y = (float)slot2;
											size.z = (float)boundingBoxAttachment3;
											boxCollider.size = size;
											if (list == null)
											{
												ex = new NullReferenceException();
												boxCollider2 = boxCollider;
												enumerator2 = enumerator5;
												enumerator6 = enumerator3;
												num = unchecked((nint)null);
												break;
											}
											Collider[] items = list._items;
											int version = list._version + 1;
											list._version = version;
											if (list._items == null)
											{
												ex = new NullReferenceException();
												boxCollider2 = boxCollider;
												enumerator2 = enumerator5;
												enumerator6 = enumerator3;
												num = unchecked((nint)null);
												break;
											}
											int count = list.Count;
											if (list.Count < items.Length)
											{
												int size2 = list.Count + 1;
												list._size = size2;
												items[count] = boxCollider;
												boxCollider2 = boxCollider;
											}
											else
											{
												list.Add(boxCollider);
												boxCollider2 = boxCollider;
											}
										}
										continue;
									}
									ex = new NullReferenceException();
									enumerator2 = enumerator5;
									enumerator6 = enumerator3;
									num = unchecked((nint)null);
									break;
								}
								ex = new NullReferenceException();
								enumerator2 = enumerator5;
								enumerator6 = enumerator3;
								num = 0;
								break;
							}
							enumerator5.Dispose();
							boxCollider2 = null;
							enumerator2 = enumerator5;
							enumerator6 = enumerator3;
							num = 0;
							OutOfMemoryException ex2 = new OutOfMemoryException();
							NullReferenceException ex3 = new NullReferenceException();
							NullReferenceException ex4 = new NullReferenceException();
							NullReferenceException ex5 = new NullReferenceException();
							NullReferenceException ex6 = new NullReferenceException();
							ex = new NullReferenceException();
							break;
						}
						ex7 = ex;
						num4 = num;
					}
					else
					{
						NullReferenceException ex8 = new NullReferenceException();
						boxCollider2 = null;
						enumerator6 = enumerator3;
						ex7 = ex8;
						num4 = 0;
					}
					enumerator2.Dispose();
					if ((object)boxCollider2 != null)
					{
						throw new OutOfMemoryException();
					}
					bool flag = num4 != 1;
					ExposedList<Slot>.Enumerator enumerator7 = (ExposedList<Slot>.Enumerator)ex7;
					if (flag)
					{
						break;
					}
					Transform transform = ((Dictionary<Bone, Transform>)(object)ex7)[(Bone)num4];
					Transform transform2 = ((Dictionary<Bone, Transform>)(object)transform)[(Bone)num4];
					enumerator6.Dispose();
					if ((object)transform != null)
					{
						OutOfMemoryException ex9 = new OutOfMemoryException();
						enumerator7 = (ExposedList<Slot>.Enumerator)ex9;
						break;
					}
				}
				else
				{
					enumerator3.Dispose();
				}
				return list;
			}
			enumerator6.Dispose();
			OutOfMemoryException ex10 = new OutOfMemoryException();
			((ExposedList<Slot>.Enumerator*)ex10)->Dispose();
			List<Collider> result = default(List<Collider>);
			return result;
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x1519F84", Offset = "0x1519F84", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = b.parent;\n\tv25 = b.arotation;\n\tv6 = b.parent == 0;\n\tif (v6) goto L_0010;\nL_0009:\n\tv27 = v27.parent;\n\tv25 = v25 + v27.arotation;\n\tv31 = v27 == 0;\n\tv30 = ~v31;\n\tif (v30) goto L_0009;\nL_0010:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float GetPropagatedRotation(Bone b)
		{
			Bone parent = b.Parent;
			float num = b.AppliedRotation;
			bool flag = b.Parent == null;
			float result = b.AppliedRotation;
			if (!flag)
			{
				bool flag3;
				do
				{
					parent = parent.Parent;
					num += parent.AppliedRotation;
					bool flag2 = parent == null;
					flag3 = !flag2;
					result = num;
				}
				while (flag3);
			}
			return result;
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0x151B1B4", Offset = "0x151B1B4", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv59 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv73 = System.Collections.Generic.List`1<System.String>;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv78 = \"\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37A90]) = v54;\nL_002C:\n\tthis.startingBoneName = \"\";\n\tv57 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v57);\n\tthis.stopBoneNames = v57;\n\tthis.disableIK = 1;\n\tthis.useGravity = 1;\n\tthis.mix = 1f;\n\tthis.thickness = *([407B70]);\n\tthis.oldRagdollBehaviour = 1;\n\tv71 = new System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::.ctor(v71);\n\tthis.boneTable = v71;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonRagdoll()
		{
			//IL_006d: Expected F4, but got I
			base._002Ector();
			startingBoneName = "";
			List<string> list = new List<string>();
			stopBoneNames = list;
			disableIK = true;
			useGravity = true;
			mix = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B70]");
			thickness = 0f;
			oldRagdollBehaviour = true;
			Dictionary<Bone, Transform> dictionary = new Dictionary<Bone, Transform>();
			boneTable = dictionary;
		}
	}
}
