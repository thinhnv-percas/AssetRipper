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
	[Token(Token = "0x200000B")]
	public class Demo2AutoScroll : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200000C")]
		private sealed class _003CScrollElements_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400002C")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400002D")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400002E")]
			[FieldOffset(Offset = "0x20")]
			public Demo2AutoScroll _003C_003E4__this;

			[Token(Token = "0x400002F")]
			[FieldOffset(Offset = "0x28")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x17000006")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600002F")]
				[Address(RVA = "0x3C1F810", Offset = "0x3C1F810", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000007")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000031")]
				[Address(RVA = "0x3C1F858", Offset = "0x3C1F858", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x3C1F5BC", Offset = "0x3C1F5BC", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CScrollElements_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x3C1F5F0", Offset = "0x3C1F5F0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600002E")]
			[Address(RVA = "0x3C1F5F4", Offset = "0x3C1F5F4", Length = "0x21C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv64 = this.<>1__state == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_00DB;\n\tthis.<>1__state = -1;\n\tthis.<i>5__2 = 0;\n\tv70 = v52 == 0;\n\tv71 = ~v70;\n\tv186 = 0;\n\tif (v71) goto L_005B;\n\tgoto L_00DC;\nL_0033:\n\tthis.<>1__state = -1;\n\tv123 = this.<i>5__2 << 3;\n\tv210 = *([v52 @ X20_v2 (UnityEngine.Component)+20]) + v123;\n\tv192 = UnityEngine.Component::get_gameObject(*([v210 @ X8_v16+20]));\n\tUnityEngine.GameObject::SetActive(v192, 0);\n\tv211 = *([v52 @ X20_v2 (UnityEngine.Component)+20]);\n\tv333 = this.<i>5__2 + 1;\n\tv218 = v333 / *([v211 @ X8_v17+18]);\n\tv221 = v218 * *([v211 @ X8_v17+18]);\n\tv186 = v333 - v221;\n\tthis.<i>5__2 = v186;\n\tv285 = 0xB296000 + 0x6E0;\n\tv324 = UnityEngine.Component::get_gameObject(*([v212 @ X8_v7+20]));\n\tv327 = UnityEngine.Component::get_gameObject(v52);\n\tgoto L_0082;\nL_0082:\n\tv194 = UnityEngine.Object::op_Equality(v324, v327);\n\tv312 = *([v52 @ X20_v2 (UnityEngine.Component)+20]);\n\tv317 = ~v194;\n\tif (v317) goto L_00A9;\n\tv344 = this.<i>5__2 + 1;\n\tv281 = v344 / *([v312 @ X8_v13+18]);\n\tv311 = v281 * *([v312 @ X8_v13+18]);\n\tv186 = v344 - v311;\n\tthis.<i>5__2 = v186;\n\tv345 = v186 < *([v312 @ X8_v13+18]);\n\tv304 = ~v345;\n\tv279 = ~v304;\n\tv321 = *([v52 @ X20_v2 (UnityEngine.Component)+20]);\n\tif (v279) goto L_006D;\n\tv313 = new System.IndexOutOfRangeException();\nL_00A9:\n\tv126 = this.<i>5__2 << 3;\n\tv215 = *([v52 @ X20_v2 (UnityEngine.Component)+20]) + v126;\n\tv197 = UnityEngine.Component::get_gameObject(*([v215 @ X8_v12+20]));\n\tUnityEngine.GameObject::SetActive(v197, 1);\n\tv340 = new *([v285 @ X23_v6 (System.Int32)])();\n\tUnityEngine.WaitForSeconds::.ctor(v340, *([v52 @ X20_v2 (UnityEngine.Component)+28]));\n\tthis.<>2__current = v340;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_00DB:\n\treturn 0;\nL_00DC:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_001C:\n\tv52 = this.<>4__this;\n\tv57 = this.<>1__state == 1;\n\tif (v57) goto L_0033;\nL_005B:\n\tv321 = *([v52 @ X20_v2 (UnityEngine.Component)+20]);\nL_006D:\n\tv124 = v186 << 3;\n\tv212 = v321 + v124;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Demo2AutoScroll._003CScrollElements_003Ed__4::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x3C1F818", Offset = "0x3C1F818", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x20")]
		private Transform[] children;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x28")]
		public float totalTime;

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x30")]
		public GameObject sceneDescription;

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x3C1F2DC", Offset = "0x3C1F2DC", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tUnityEngine.GameObject::SetActive(this.sceneDescription, 0);\n\tv171 = UnityEngine.Camera::get_main();\n\tUnityEngine.Camera::set_fieldOfView(v171, 60f);\n\tv288 = UnityEngine.Component::GetComponentsInChildren(this);\n\tthis.children = v288;\n\tv306 = this.children;\n\tv152 = 0;\n\tgoto L_005A;\nL_004A:\n\t// 74 MakeStruct v347 @ AGG3C1F3C4_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v356.zero (UnityEngine.Vector3), v356.zero.y (System.Single), v356.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v196[v152 @ X24_v4 (System.Int32)], v347);\nL_004C:\n\tv152 = v152 + 1;\n\tv306 = this.children;\nL_005A:\n\tv78 = v152 >= v306.Length;\n\tif (v78) goto L_00B1;\n\tv316 = UnityEngine.Component::get_gameObject(v306[v152 @ X24_v4 (System.Int32)]);\n\tv326 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_006F;\nL_006F:\n\tv339 = UnityEngine.Object::op_Inequality(v316, v326);\n\tv342 = ~v339;\n\tif (v342) goto L_004C;\n\tgoto L_007A;\nL_007A:\n\tv194 = this.children;\n\tv178 = UnityEngine.Component::get_gameObject(v194[v152 @ X24_v4 (System.Int32)]);\n\tUnityEngine.GameObject::SetActive(v178, 0);\n\tv196 = this.children;\n\tgoto L_004A;\nL_00B1:\n\tv269 = this.totalTime / v306.Length;\n\tthis.totalTime = v269;\n\tgoto L_00C1;\n\tv275 = UnityEngine.MonoBehaviour::StartCoroutine(this, v323);\n\treturn;\nL_00C1:\n\tv323 = new AllIn1SpriteShader.Demo2AutoScroll+<ScrollElements>d__4();\n\tSystem.Object::.ctor(v323);\n\tv323.<>1__state = 0;\n\tv323.<>4__this = this;\n")]
		private void Start()
		{
			sceneDescription.SetActive(value: false);
			Camera main = Camera.main;
			main.fieldOfView = 60f;
			Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
			children = componentsInChildren;
			Transform[] array = children;
			int num = 0;
			Vector3 localPosition = default(Vector3);
			while (num < array.Length)
			{
				GameObject gameObject = array[num].gameObject;
				GameObject gameObject2 = base.gameObject;
				if (gameObject != gameObject2)
				{
					Transform[] array2 = children;
					GameObject gameObject3 = array2[num].gameObject;
					gameObject3.SetActive(value: false);
					Transform[] array3 = children;
					localPosition.x = Vector3.zero.x;
					localPosition.y = Vector3.zero.y;
					localPosition.z = Vector3.zero.z;
					array3[num].localPosition = localPosition;
				}
				num++;
				array = children;
			}
			float num2 = totalTime / (float)array.Length;
			totalTime = num2;
			_003CScrollElements_003Ed__4 _003CScrollElements_003Ed__5 = (_003CScrollElements_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CScrollElements_003Ed__4));
			_003CScrollElements_003Ed__5._003C_003E1__state = 0;
			_003CScrollElements_003Ed__5._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CScrollElements_003Ed__5);
		}

		[IteratorStateMachine(typeof(_003CScrollElements_003Ed__4))]
		[Token(Token = "0x600002A")]
		[Address(RVA = "0x3C1F544", Offset = "0x3C1F544", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AllIn1SpriteShader.Demo2AutoScroll+<ScrollElements>d__4();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator ScrollElements()
		{
			_003CScrollElements_003Ed__4 _003CScrollElements_003Ed__5 = (_003CScrollElements_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CScrollElements_003Ed__4));
			_003CScrollElements_003Ed__5._003C_003E1__state = 0;
			_003CScrollElements_003Ed__5._003C_003E4__this = this;
			return _003CScrollElements_003Ed__5;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x3C1F5E8", Offset = "0x3C1F5E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Demo2AutoScroll()
		{
		}
	}
}
