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
	[SelectionBase]
	[Token(Token = "0x2000022")]
	public class SpineboyBeginnerModel : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000023")]
		private sealed class _003CJumpRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000BC")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000BD")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000BE")]
			[FieldOffset(Offset = "0x20")]
			public SpineboyBeginnerModel _003C_003E4__this;

			[Token(Token = "0x40000BF")]
			[FieldOffset(Offset = "0x28")]
			private Vector3 _003Cpos_003E5__2;

			[Token(Token = "0x40000C0")]
			[FieldOffset(Offset = "0x34")]
			private float _003Ct_003E5__3;

			[Token(Token = "0x17000012")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000088")]
				[Address(RVA = "0x150D294", Offset = "0x150D294", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000013")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600008A")]
				[Address(RVA = "0x150D2D4", Offset = "0x150D2D4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000085")]
			[Address(RVA = "0x150D004", Offset = "0x150D004", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CJumpRoutine_003Ed__19(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000086")]
			[Address(RVA = "0x150D040", Offset = "0x150D040", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000087")]
			[Address(RVA = "0x150D044", Offset = "0x150D044", Length = "0x250")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.<>4__this;\n\tv20 = this.<>1__state == 2;\n\tif (v20) goto L_0036;\n\tv29 = this.<>1__state == 1;\n\tif (v29) goto L_005B;\n\tv38 = this.<>1__state == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv59 = v14.state != 2;\n\tif (v59) goto L_00A2;\n\tgoto L_00DB;\nL_0036:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv37 = UnityEngine.Time::get_deltaTime();\n\tv95 = this.<t>5__3 + v37;\n\tthis.<t>5__3 = v95;\n\tv50 = v95 < 0.6f;\n\tif (v50) goto L_0078;\n\tv138 = UnityEngine.Component::get_transform(this.<>4__this);\n\t// 81 MakeStruct v200 @ AGG15110DC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.<pos>5__2 (UnityEngine.Vector3), this.<pos>5__2.y (System.Single), this.<pos>5__2.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v138, v200);\n\tthis.<pos>5__2.z = 0f;\n\tthis.<pos>5__2 = 0;\n\tv14.state = 0;\n\tgoto L_00DB;\nL_005B:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv43 = UnityEngine.Time::get_deltaTime();\n\tv83 = this.<t>5__3 + v43;\n\tthis.<t>5__3 = v83;\n\tv93 = v83 >= 0.6f;\n\tif (v93) goto L_0073;\n\tv274 = 0.6f - v83;\n\tv126 = v274 * 20f;\n\tgoto L_00B1;\nL_0073:\n\tthis.<t>5__3 = 0f;\nL_0078:\n\tv245 = UnityEngine.Component::get_transform(this.<>4__this);\n\tv132 = UnityEngine.Time::get_deltaTime();\n\tgoto L_008C;\n\tv296 = UnityEngine.Vector3;\n\tv297 = \"il2cpp_codegen_initialize_runtime_metadata\"(v296, v123, v174, v175, v176, v177, v178, v179, v132, v97, v117, v180, v181, v182, v183, v184);\n\tv298 = 1;\n\t*([1A37A9D]) = v298;\nL_008C:\n\tv305 = v95 * 20f;\n\tv306 = v305 * v132;\n\tv307 = UnityEngine.Vector3;\n\tv309 = *([v307 @ X8_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv204 = v306 * *([v309 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]);\n\tv213 = v306 * *([v309 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+28]);\n\tv217 = v306 * v309.downVector;\n\t// 152 MakeStruct v190 @ AGG15111B8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v217 @ V0_v6 (System.Single), v213 @ V1_v3 (System.Single), v204 @ V2_v1 (System.Single)\n\tUnityEngine.Transform::Translate(v245, v190);\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 2;\n\tgoto L_00DB;\nL_00A2:\n\tv14.state = 2;\n\tv139 = UnityEngine.Component::get_transform(this.<>4__this);\n\tv284 = UnityEngine.Transform::get_localPosition(v139);\n\tthis.<pos>5__2 = v284;\n\tthis.<pos>5__2.y = v284.y;\n\tthis.<pos>5__2.z = v284.z;\n\tthis.<t>5__3 = 0f;\nL_00B1:\n\tv290 = UnityEngine.Component::get_transform(this.<>4__this);\n\tv133 = UnityEngine.Time::get_deltaTime();\n\tgoto L_00C4;\n\tv312 = UnityEngine.Vector3;\n\tv313 = \"il2cpp_codegen_initialize_runtime_metadata\"(v312, v124, v174, v175, v176, v177, v178, v179, v133, v129, v118, v180, v181, v182, v183, v184);\n\tv314 = 1;\n\t*([1A3575B]) = v314;\nL_00C4:\n\tv192 = v126 * v133;\n\tv318 = UnityEngine.Vector3;\n\tv235 = *([v318 @ X8_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv202 = v192 * *([v235 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+20]);\n\tv211 = v192 * *([v235 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]);\n\tv215 = v192 * v235.upVector;\n\t// 207 MakeStruct v186 @ AGG1511270_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v215 @ V0_v14 (System.Single), v211 @ V1_v10 (System.Single), v202 @ V2_v6 (System.Single)\n\tUnityEngine.Transform::Translate(v290, v186);\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\nL_00DB:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0287: Expected I, but got O
				//IL_0290: Expected I, but got O
				//IL_03be: Expected I, but got O
				//IL_03c7: Expected I, but got O
				SpineboyBeginnerModel spineboyBeginnerModel = _003C_003E4__this;
				float num;
				float num4;
				if (_003C_003E1__state != 2)
				{
					if (_003C_003E1__state != 1)
					{
						if (_003C_003E1__state == 0)
						{
							_003C_003E1__state = -1;
							if (spineboyBeginnerModel.state != SpineBeginnerBodyState.Jumping)
							{
								spineboyBeginnerModel.state = SpineBeginnerBodyState.Jumping;
								Transform transform = _003C_003E4__this.transform;
								Vector3 vector = (_003Cpos_003E5__2 = transform.localPosition);
								_003Cpos_003E5__2.y = vector.y;
								_003Cpos_003E5__2.z = vector.z;
								_003Ct_003E5__3 = 0f;
								num = 12f;
								goto IL_0463;
							}
						}
						return false;
					}
					_003C_003E1__state = -1;
					float deltaTime = Time.deltaTime;
					float num2 = (_003Ct_003E5__3 += deltaTime);
					if (num2 < 0.6f)
					{
						float num3 = 0.6f - num2;
						num = num3 * 20f;
						goto IL_0463;
					}
					_003Ct_003E5__3 = 0f;
					num4 = 0f;
				}
				else
				{
					_003C_003E1__state = -1;
					float deltaTime2 = Time.deltaTime;
					num4 = (_003Ct_003E5__3 += deltaTime2);
					if (!(num4 < 0.6f))
					{
						Transform transform2 = _003C_003E4__this.transform;
						Vector3 localPosition = default(Vector3);
						localPosition.x = _003Cpos_003E5__2.x;
						localPosition.y = _003Cpos_003E5__2.y;
						localPosition.z = _003Cpos_003E5__2.z;
						transform2.localPosition = localPosition;
						_003Cpos_003E5__2.z = 0f;
						_003Cpos_003E5__2 = default(Vector3);
						spineboyBeginnerModel.state = default(SpineBeginnerBodyState);
						return false;
					}
				}
				Transform transform3 = _003C_003E4__this.transform;
				float deltaTime3 = Time.deltaTime;
				float num5 = num4 * 20f;
				float num6 = num5 * deltaTime3;
				nint num7 = (nint)typeof(Vector3);
				nint num8 = (nint)Vector3.zero;
				float num9 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
				float z = num9 * 0f;
				float num10 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
				float y = num10 * 0f;
				float x = num6 * Vector3.down.x;
				Vector3 translation = default(Vector3);
				translation.x = x;
				translation.y = y;
				translation.z = z;
				transform3.Translate(translation);
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
				IL_0463:
				Transform transform4 = _003C_003E4__this.transform;
				float deltaTime4 = Time.deltaTime;
				float num11 = num * deltaTime4;
				nint num12 = (nint)typeof(Vector3);
				nint num13 = (nint)Vector3.zero;
				float num14 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float z2 = num14 * 0f;
				float num15 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float y2 = num15 * 0f;
				float x2 = num11 * Vector3.upVector.x;
				Vector3 translation2 = default(Vector3);
				translation2.x = x2;
				translation2.y = y2;
				translation2.z = z2;
				transform4.Translate(translation2);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000089")]
			[Address(RVA = "0x150D29C", Offset = "0x150D29C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Header("Current State")]
		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x20")]
		public SpineBeginnerBodyState state;

		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x24")]
		public bool facingLeft;

		[Range(-1f, 1f)]
		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x28")]
		public float currentSpeed;

		[Header("Balance")]
		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x2C")]
		public float shootInterval;

		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x30")]
		private float lastShootTime;

		[CompilerGenerated]
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x38")]
		private Action m_ShootEvent;

		[CompilerGenerated]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x40")]
		internal Action StartAimEvent;

		[CompilerGenerated]
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x48")]
		internal Action StopAimEvent;

		[Token(Token = "0x14000004")]
		public event Action ShootEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000078")]
			[Address(RVA = "0x150CBFC", Offset = "0x150CBFC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37A0A]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_ShootEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000079")]
			[Address(RVA = "0x150CC98", Offset = "0x150CC98", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37A0B]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_ShootEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000005")]
		public event Action StartAimEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x150CD34", Offset = "0x150CD34", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37A0C]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.StartAimEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600007B")]
			[Address(RVA = "0x150CDD0", Offset = "0x150CDD0", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37A0D]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.StartAimEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000006")]
		public event Action StopAimEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x600007C")]
			[Address(RVA = "0x150CE6C", Offset = "0x150CE6C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37A0E]) = v38;\nL_0014:\n\tv40 = this + 0x48;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 72;
				Delegate obj2 = this.StopAimEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600007D")]
			[Address(RVA = "0x150CF08", Offset = "0x150CF08", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37A0F]) = v38;\nL_0014:\n\tv40 = this + 0x48;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 72;
				Delegate obj2 = this.StopAimEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x150CB30", Offset = "0x150CB30", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Spine.Unity.Examples.SpineboyBeginnerModel::JumpRoutine(this);\n\tv13 = UnityEngine.MonoBehaviour::StartCoroutine(this, v6);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TryJump()
		{
			IEnumerator routine = JumpRoutine();
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x150CAB0", Offset = "0x150CAB0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Time::get_time();\n\tv10 = v7 - this.lastShootTime;\n\tv22 = v10 <= this.shootInterval;\n\tif (v22) goto L_0024;\n\tthis.lastShootTime = v7;\n\tv24 = this.ShootEvent == 0;\n\tif (v24) goto L_0024;\n\tSystem.Action::Invoke(this.ShootEvent);\nL_0024:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TryShoot()
		{
			float time = Time.time;
			float num = time - lastShootTime;
			if (num > shootInterval)
			{
				lastShootTime = time;
				if (this.ShootEvent != null)
				{
					this.ShootEvent();
				}
			}
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x150CAF8", Offset = "0x150CAF8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.StartAimEvent == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.StartAimEvent);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StartAim()
		{
			if (this.StartAimEvent != null)
			{
				this.StartAimEvent();
			}
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x150CB14", Offset = "0x150CB14", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.StopAimEvent == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.StopAimEvent);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StopAim()
		{
			if (this.StopAimEvent != null)
			{
				this.StopAimEvent();
			}
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x150CA80", Offset = "0x150CA80", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = speed < 0;\n\tv5 = speed == 0;\n\tthis.currentSpeed = speed;\n\tif (v5) goto L_0012;\n\tthis.facingLeft = v4;\nL_0012:\n\tv19 = this.state == 2;\n\tif (v19) goto L_0024;\n\tv28 = speed == 0;\n\tv33 = ~v28;\n\tthis.state = v33;\nL_0024:\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TryMove(float speed)
		{
			bool flag = speed < 0f;
			bool flag2 = speed == 0f;
			currentSpeed = speed;
			if (!flag2)
			{
				facingLeft = flag;
			}
			if (state != SpineBeginnerBodyState.Jumping)
			{
				bool flag3 = speed == 0f;
				bool flag4 = !flag3;
				state = (flag4 ? SpineBeginnerBodyState.Running : SpineBeginnerBodyState.Idle);
			}
		}

		[IteratorStateMachine(typeof(_003CJumpRoutine_003Ed__19))]
		[Token(Token = "0x6000083")]
		[Address(RVA = "0x150CFA4", Offset = "0x150CFA4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SpineboyBeginnerModel+<JumpRoutine>d__19;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A10]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SpineboyBeginnerModel+<JumpRoutine>d__19();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator JumpRoutine()
		{
			_003CJumpRoutine_003Ed__19 _003CJumpRoutine_003Ed__20 = null;
			_003CJumpRoutine_003Ed__20._003C_003E1__state = 0;
			_003CJumpRoutine_003Ed__20._003C_003E4__this = this;
			return _003CJumpRoutine_003Ed__20;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x150D02C", Offset = "0x150D02C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shootInterval = 0.12f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyBeginnerModel()
		{
			shootInterval = 0.12f;
		}
	}
}
