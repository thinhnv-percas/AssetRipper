using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x200000D")]
	public class DemoCamera : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private sealed class _003CSetCamAfterStart_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000036")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000037")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000038")]
			[FieldOffset(Offset = "0x20")]
			public DemoCamera _003C_003E4__this;

			[Token(Token = "0x17000008")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000039")]
				[Address(RVA = "0x3C1FBEC", Offset = "0x3C1FBEC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000009")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600003B")]
				[Address(RVA = "0x3C1FC34", Offset = "0x3C1FC34", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000036")]
			[Address(RVA = "0x3C1FAC4", Offset = "0x3C1FAC4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CSetCamAfterStart_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x3C1FAF8", Offset = "0x3C1FAF8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000038")]
			[Address(RVA = "0x3C1FAFC", Offset = "0x3C1FAFC", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.<>1__state == 0;\n\tif (v16) goto L_0052;\n\tv26 = this.<>1__state != 1;\n\tif (v26) goto L_0044;\n\tv46 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv110 = UnityEngine.Component::get_transform(this.<>4__this);\n\tv121 = UnityEngine.Transform::get_position(v46.targetedItem);\n\tv116 = v121.z + v46.offset.z;\n\tv119 = v121.y + v46.offset.y;\n\tv122 = v121 + v46.offset;\n\t// 48 MakeStruct v50 @ AGG3C1FB6C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v122 @ V0_v4 (System.Single), v119 @ V1_v4 (System.Single), v116 @ V2_v4 (System.Single)\n\tUnityEngine.Transform::set_position(v110, v50);\n\tv68 = UnityEngine.Component::get_transform(this.<>4__this);\n\tv61 = UnityEngine.Transform::get_position(v68);\n\tv46.target.x = v61;\n\tv46.target.y = v61.y;\n\tv46.target.z = v61.z;\n\tv46.canUpdate = 1;\nL_0052:\n\tv27 = this + 0x18;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = -1;\n\t*([v27 @ X0_v1-8]) = 1;\n\tv96 = this.<>1__state == 0;\n\treturn v96;\nL_0044:\n\tv79 = this.<>1__state == 0;\n\treturn v79;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DemoCamera._003CSetCamAfterStart_003Ed__8::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x3C1FBF4", Offset = "0x3C1FBF4", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x20")]
		private Transform targetedItem;

		[SerializeField]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x28")]
		private All1ShaderDemoController demoController;

		[SerializeField]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x30")]
		private float speed;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x34")]
		private Vector3 offset;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x40")]
		private Vector3 target;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x4C")]
		private bool canUpdate;

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x3C1F860", Offset = "0x3C1F860", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = UnityEngine.Component::get_transform(this);\n\tv28 = UnityEngine.Transform::get_position(v25);\n\tv58 = UnityEngine.Transform::get_position(this.targetedItem);\n\tv85 = v28 - v58;\n\tv83 = v28.y - v58.y;\n\tv81 = v28.z - v58.z;\n\tthis.offset.x = v85;\n\tthis.offset.y = v83;\n\tthis.offset.z = v81;\n\tgoto L_0033;\n\tv89 = UnityEngine.MonoBehaviour::StartCoroutine(this, v110);\n\treturn;\nL_0033:\n\tv110 = new AllIn1SpriteShader.DemoCamera+<SetCamAfterStart>d__8();\n\tSystem.Object::.ctor(v110);\n\tv110.<>1__state = 0;\n\tv110.<>4__this = this;\n")]
		private void Awake()
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 position2 = targetedItem.position;
			float x = position.x - position2.x;
			float y = position.y - position2.y;
			float z = position.z - position2.z;
			offset.x = x;
			offset.y = y;
			offset.z = z;
			_003CSetCamAfterStart_003Ed__8 _003CSetCamAfterStart_003Ed__9 = (_003CSetCamAfterStart_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CSetCamAfterStart_003Ed__8));
			_003CSetCamAfterStart_003Ed__9._003C_003E1__state = 0;
			_003CSetCamAfterStart_003Ed__9._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CSetCamAfterStart_003Ed__9);
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x3C1F9B0", Offset = "0x3C1F9B0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = this.canUpdate != 1;\n\tif (v37) goto L_0083;\n\tv39 = this.demoController;\n\tv56 = v39.expositorDistance * v39.currExpositor;\n\tthis.target.y = v56;\n\tv59 = UnityEngine.Component::get_transform(this);\n\tv84 = UnityEngine.Component::get_transform(this);\n\tv170 = UnityEngine.Transform::get_position(v84);\n\tv91 = UnityEngine.Time::get_deltaTime();\n\tv171 = this.target.z - v170.z;\n\tv172 = this.speed * v91;\n\tv174 = v172 < 1f;\n\tv175 = v172 == 1f;\n\tv178 = v172 == v172;\n\tv157 = 1f == 1f;\n\tv179 = v178 & v157;\n\tv180 = ~v179;\n\tv181 = v174 == v180;\n\tv120 = ~v175;\n\tv153 = v181 & v120;\n\tv182 = ~v153;\n\tif (v182) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv185 = 1f;\n\tgoto L_004F;\nL_FFFFFFFF:\n\tv185 = v172;\nL_FFFFFFFF:\n\tv190 = 0;\n\tgoto L_005C;\nL_FFFFFFFF:\n\tv190 = v185;\nL_0083:\n\treturn;\nL_004F:\n\tv161 = v172 < 0;\n\tv117 = ~v161;\n\tif (v117) goto L_FFFFFFFF;\nL_005C:\n\tv191 = v171 * v190;\n\tv137 = v170.z + v191;\n\tv192 = this.target.y - v170.y;\n\tv193 = v192 * v190;\n\tv145 = v170.y + v193;\n\tv111 = this.target - v170;\n\tv194 = v111 * v190;\n\tv147 = v170 + v194;\n\t// 115 MakeStruct v108 @ AGG3C1FAA0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v147 @ V0_v10 (System.Single), v145 @ V1_v9 (System.Single), v137 @ V2_v5 (System.Single)\n\tUnityEngine.Transform::set_position(v59, v108);\n\treturn;\n")]
		private void Update()
		{
			if (canUpdate)
			{
				All1ShaderDemoController all1ShaderDemoController = demoController;
				float y = all1ShaderDemoController.expositorDistance * (float)all1ShaderDemoController.currExpositor;
				target.y = y;
				Transform transform = base.transform;
				Transform transform2 = base.transform;
				Vector3 position = transform2.position;
				float deltaTime = Time.deltaTime;
				float num = target.z - position.z;
				float num2 = speed * deltaTime;
				bool flag = num2 < 1f;
				bool flag2 = num2 == 1f;
				bool flag3 = num2 == num2;
				bool flag4 = 1f == 1f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				float num3 = ((!(flag7 && flag8)) ? num2 : 1f);
				float num4 = ((!(num2 < 0f)) ? num3 : 0f);
				float num5 = num * num4;
				float z = position.z + num5;
				float num6 = target.y - position.y;
				float num7 = num6 * num4;
				float y2 = position.y + num7;
				float num8 = target.x - position.x;
				float num9 = num8 * num4;
				float x = position.x + num9;
				Vector3 position2 = default(Vector3);
				position2.x = x;
				position2.y = y2;
				position2.z = z;
				transform.position = position2;
			}
		}

		[IteratorStateMachine(typeof(_003CSetCamAfterStart_003Ed__8))]
		[Token(Token = "0x6000034")]
		[Address(RVA = "0x3C1F938", Offset = "0x3C1F938", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AllIn1SpriteShader.DemoCamera+<SetCamAfterStart>d__8();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator SetCamAfterStart()
		{
			_003CSetCamAfterStart_003Ed__8 _003CSetCamAfterStart_003Ed__9 = (_003CSetCamAfterStart_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CSetCamAfterStart_003Ed__8));
			_003CSetCamAfterStart_003Ed__9._003C_003E1__state = 0;
			_003CSetCamAfterStart_003Ed__9._003C_003E4__this = this;
			return _003CSetCamAfterStart_003Ed__9;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x3C1FAF0", Offset = "0x3C1FAF0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DemoCamera()
		{
		}
	}
}
