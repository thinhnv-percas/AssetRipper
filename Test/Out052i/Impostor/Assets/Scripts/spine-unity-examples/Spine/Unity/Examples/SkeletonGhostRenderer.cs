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
	[Token(Token = "0x200004C")]
	public class SkeletonGhostRenderer : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200004D")]
		private sealed class _003CFade_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400019C")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400019D")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400019E")]
			[FieldOffset(Offset = "0x20")]
			public SkeletonGhostRenderer _003C_003E4__this;

			[Token(Token = "0x400019F")]
			[FieldOffset(Offset = "0x28")]
			private Color32 _003Cblack_003E5__2;

			[Token(Token = "0x40001A0")]
			[FieldOffset(Offset = "0x2C")]
			private float _003Ct_003E5__3;

			[Token(Token = "0x40001A1")]
			[FieldOffset(Offset = "0x30")]
			private float _003ChardTimeLimit_003E5__4;

			[Token(Token = "0x17000020")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000145")]
				[Address(RVA = "0x1516A30", Offset = "0x1516A30", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000021")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000147")]
				[Address(RVA = "0x1516A70", Offset = "0x1516A70", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000142")]
			[Address(RVA = "0x15166E0", Offset = "0x15166E0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CFade_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000143")]
			[Address(RVA = "0x1516788", Offset = "0x1516788", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000144")]
			[Address(RVA = "0x151678C", Offset = "0x151678C", Length = "0x2A4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = Spine.Unity.Examples.SkeletonGhostRenderer;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A6D]) = v38;\nL_0016:\n\tv40 = this.<>4__this;\n\tv45 = this.<>1__state == 1;\n\tif (v45) goto L_003B;\n\tv52 = this.<>1__state == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_0035;\n\tv279 = \"il2cpp_codegen_runtime_class_init\"(v141, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv281 = Spine.Unity.Examples.SkeletonGhostRenderer;\nL_0035:\n\tthis.<t>5__3 = 2048.0004844665527d;\n\tthis.<black>5__2 = v282.TransparentBlack;\n\tgoto L_0051;\nL_003B:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv57 = UnityEngine.Time::get_deltaTime();\n\tv126 = this.<hardTimeLimit>5__4 - v57;\n\tthis.<hardTimeLimit>5__4 = v126;\n\tv138 = v126 <= 0;\n\tif (v138) goto L_00F4;\nL_0051:\n\tv177 = UnityEngine.Mathf::Min(this.<t>5__3, 1f);\n\tv197 = this.<t>5__3 < 0;\n\tv179 = ~v197;\n\tv174 = ~v179;\n\tif (v174) goto L_FFFFFFFF;\n\tgoto L_006B;\nL_006B:\n\t// 107 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv167 = *([v40 @ X19_v2 (UnityEngine.Component)+24]) >> 0x18;\n\tv355 = *([v40 @ X19_v2 (UnityEngine.Component)+24]) & 0xFF;\n\t// 110 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv356 = this.<black>5__2 >> 0x18;\n\tv161 = this.<black>5__2 & 0xFF;\n\t// 113 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv357 = v355 - this.<black>5__2;\n\t// 115 NotImplemented \"Instruction USHL not yet implemented.\"\n\tv360 = v167 - v356;\n\tv361 = v206 * v357;\n\t// 120 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv362 = v361 + v161;\n\t// 123 NotImplemented \"Instruction USHL not yet implemented.\"\n\tv365 = v206 * v360;\n\tv366 = v365 + v356;\n\t// 128 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv367 = 3.39519326594E-313d & 0xFF000000FF;\n\tv368 = *([407C70]) & 0xFF000000FF;\n\tv379 = v367 - v368;\n\tv381 = v366 >= 0;\n\tif (v381) goto L_FFFFFFFF;\n\tgoto L_0095;\nL_0095:\n\t// 149 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 150 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 162 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv387 = v379 * v388;\n\tv389 = v385 & 0xFF;\n\tv390 = v387 + v368;\n\tv155 = v389 / 0x437F0000;\n\t// 168 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 169 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 170 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv173 = v362 >= 0;\n\tif (v173) goto L_FFFFFFFF;\n\tgoto L_00B2;\nL_00B2:\n\tv394 = v390 & 0xFF000000FF;\n\tv223 = v169 & 0xFF;\n\t// 180 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv176 = v394 / v33;\n\tv205 = v223 / 0x437F0000;\n\t// 186 MakeStruct v146 @ AGG151A954_2_v5 (UnityEngine.Color), typeof(UnityEngine.Color), v205 @ V0_v12 (System.Int32), v176 @ V1_v10 (System.Int32), v396 @ V1.S1, v155 @ V3_v7 (System.Int32)\n\tUnityEngine.MaterialPropertyBlock::SetColor(*([v40 @ X19_v2 (UnityEngine.Component)+38]), *([v40 @ X19_v2 (UnityEngine.Component)+40]), v146);\n\tUnityEngine.Renderer::SetPropertyBlock(*([v40 @ X19_v2 (UnityEngine.Component)+30]), *([v40 @ X19_v2 (UnityEngine.Component)+38]));\n\tv397 = UnityEngine.Time::get_deltaTime();\n\tv399 = v397 * *([v40 @ X19_v2 (UnityEngine.Component)+20]);\n\tv400 = UnityEngine.Mathf::Min(v399, 1f);\n\tv404 = v399 < 0;\n\tv410 = ~v404;\n\tv243 = ~v410;\n\tif (v243) goto L_FFFFFFFF;\n\tgoto L_00DA;\nL_00DA:\n\tv245 = 0 - this.<t>5__3;\n\tv414 = v245 * v413;\n\tv265 = this.<t>5__3 + v414;\n\tv415 = v265 < 0;\n\tv263 = ~v415;\n\tv257 = v265 == 0;\n\tthis.<t>5__3 = v265;\n\tv416 = ~v263;\n\tv247 = v416 | v257;\n\tif (v247) goto L_00F4;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\tgoto L_0111;\nL_00F4:\n\tv337 = UnityEngine.MeshFilter::get_sharedMesh(*([v40 @ X19_v2 (UnityEngine.Component)+28]));\n\tgoto L_0101;\n\tv344 = v124;\n\tv345 = \"il2cpp_codegen_runtime_class_init\"(v344, v336, v149, v22, v23, v24, v25, v26, v112, v91, v80, v68, v72, v70, v33, v34);\nL_0101:\n\tUnityEngine.Object::Destroy(v337);\n\tv118 = UnityEngine.Component::get_gameObject(v40);\n\tUnityEngine.GameObject::SetActive(v118, 0);\nL_0111:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0352: Expected O, but got I
				//IL_014b: Expected I4, but got O
				//IL_0156: Unknown result type (might be due to invalid IL or missing references)
				//IL_015b: Expected I4, but got Unknown
				//IL_016f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0174: Expected O, but got Unknown
				//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ff: Expected O, but got Unknown
				//IL_0219: Expected I4, but got I8
				//IL_0227: Expected O, but got I
				//IL_0413: Expected O, but got I
				//IL_041c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0421: Expected O, but got Unknown
				//IL_042f: Expected O, but got I
				//IL_0491: Expected I4, but got I8
				//IL_049a: Unknown result type (might be due to invalid IL or missing references)
				//IL_049f: Expected O, but got Unknown
				//IL_04ef: Expected F4, but got O
				//IL_051e: Expected O, but got I
				//IL_029a: Expected O, but got I
				//IL_029a: Expected O, but got I
				Component component = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state != 0)
					{
						goto IL_0389;
					}
					_003C_003E1__state = -1;
					_003Ct_003E5__3 = 1f;
					_003ChardTimeLimit_003E5__4 = 5f;
					_003Cblack_003E5__2 = TransparentBlack;
				}
				else
				{
					_003C_003E1__state = -1;
					float deltaTime = Time.deltaTime;
					if (!((_003ChardTimeLimit_003E5__4 -= deltaTime) > 0f))
					{
						goto IL_0341;
					}
				}
				float num = Mathf.Min(_003Ct_003E5__3, 1f);
				float num2 = ((_003Ct_003E5__3 < 0f) ? 0f : num);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+24]");
				int num3 = (int)((nint)0 >> 24);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+24]");
				int num4 = (int)((nint)0 & (nint)0xFF);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				int num5 = (object)_003Cblack_003E5__2 >> 24;
				int num6 = _003Cblack_003E5__2 & 0xFF;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj = num4 - _003Cblack_003E5__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
				int num7 = num3 - num5;
				float num8 = num2 * (float)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				float num9 = num8 + (float)num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
				float num10 = num2 * (float)num7;
				float num11 = num10 + (float)num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj2 = 3.39519326594E-313 & 0xFF000000FFL;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407C70]");
				int num12 = 0;
				object obj3 = (nint)obj2 - num12;
				float num13 = ((!(num11 < 0f)) ? num11 : num11);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj5 = default(object);
				object obj4 = (nint)obj3 * (nint)obj5;
				object obj6 = num13 & 0xFF;
				object obj7 = (nint)obj4 + num12;
				int num14 = (int)((nint)obj6 / 1132396544);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
				float num15 = ((!(num9 < 0f)) ? num9 : num9);
				int num16 = (int)((nint)obj7 & 0xFF000000FFL);
				object obj8 = num15 & 0xFF;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj9 = default(object);
				int num17 = (int)(num16 / (nint)obj9);
				int num18 = (int)((nint)obj8 / 1132396544);
				Color value = default(Color);
				value.r = num18;
				value.g = num17;
				object obj10 = default(object);
				value.b = (float)obj10;
				value.a = num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+38]");
				nint num19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+40]");
				((MaterialPropertyBlock)num19).SetColor(0, value);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+30]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+38]");
				((Renderer)num20).SetPropertyBlock((MaterialPropertyBlock)0);
				float deltaTime2 = Time.deltaTime;
				float num21 = deltaTime2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+20]");
				float num22 = num21 * 0f;
				float num23 = Mathf.Min(num22, 1f);
				float num24 = ((num22 < 0f) ? 0f : num23);
				float num25 = 0f - _003Ct_003E5__3;
				float num26 = num25 * num24;
				float num27 = _003Ct_003E5__3 + num26;
				bool flag = num27 < 0f;
				bool flag2 = !flag;
				bool flag3 = num27 == 0f;
				_003Ct_003E5__3 = num27;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0341;
				IL_0341:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+28]");
				Mesh sharedMesh = ((MeshFilter)0).sharedMesh;
				UnityEngine.Object.Destroy(sharedMesh);
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				goto IL_0389;
				IL_0389:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000146")]
			[Address(RVA = "0x1516A38", Offset = "0x1516A38", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200004E")]
		private sealed class _003CFadeAdditive_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001A2")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001A3")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001A4")]
			[FieldOffset(Offset = "0x20")]
			public SkeletonGhostRenderer _003C_003E4__this;

			[Token(Token = "0x40001A5")]
			[FieldOffset(Offset = "0x28")]
			private Color32 _003Cblack_003E5__2;

			[Token(Token = "0x40001A6")]
			[FieldOffset(Offset = "0x2C")]
			private float _003Ct_003E5__3;

			[Token(Token = "0x40001A7")]
			[FieldOffset(Offset = "0x30")]
			private float _003ChardTimeLimit_003E5__4;

			[Token(Token = "0x17000022")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600014B")]
				[Address(RVA = "0x1516D20", Offset = "0x1516D20", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000023")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600014D")]
				[Address(RVA = "0x1516D60", Offset = "0x1516D60", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000148")]
			[Address(RVA = "0x1516708", Offset = "0x1516708", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CFadeAdditive_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000149")]
			[Address(RVA = "0x1516A78", Offset = "0x1516A78", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600014A")]
			[Address(RVA = "0x1516A7C", Offset = "0x1516A7C", Length = "0x2A4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = Spine.Unity.Examples.SkeletonGhostRenderer;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A6E]) = v38;\nL_0016:\n\tv40 = this.<>4__this;\n\tv45 = this.<>1__state == 1;\n\tif (v45) goto L_003B;\n\tv52 = this.<>1__state == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_0035;\n\tv279 = \"il2cpp_codegen_runtime_class_init\"(v141, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv281 = Spine.Unity.Examples.SkeletonGhostRenderer;\nL_0035:\n\tthis.<t>5__3 = 2048.0004844665527d;\n\tthis.<black>5__2 = v282.TransparentBlack;\n\tgoto L_0051;\nL_003B:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv57 = UnityEngine.Time::get_deltaTime();\n\tv126 = this.<hardTimeLimit>5__4 - v57;\n\tthis.<hardTimeLimit>5__4 = v126;\n\tv138 = v126 <= 0;\n\tif (v138) goto L_00F4;\nL_0051:\n\tv177 = UnityEngine.Mathf::Min(this.<t>5__3, 1f);\n\tv197 = this.<t>5__3 < 0;\n\tv179 = ~v197;\n\tv174 = ~v179;\n\tif (v174) goto L_FFFFFFFF;\n\tgoto L_006B;\nL_006B:\n\t// 107 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv167 = *([v40 @ X19_v2 (UnityEngine.Component)+24]) >> 0x18;\n\tv355 = *([v40 @ X19_v2 (UnityEngine.Component)+24]) & 0xFF;\n\t// 110 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv356 = this.<black>5__2 >> 0x18;\n\tv161 = this.<black>5__2 & 0xFF;\n\t// 113 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv357 = v355 - this.<black>5__2;\n\t// 115 NotImplemented \"Instruction USHL not yet implemented.\"\n\tv360 = v167 - v356;\n\tv361 = v206 * v357;\n\t// 120 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv362 = v361 + v161;\n\t// 123 NotImplemented \"Instruction USHL not yet implemented.\"\n\tv365 = v206 * v360;\n\tv366 = v365 + v356;\n\t// 128 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv367 = 3.39519326594E-313d & 0xFF000000FF;\n\tv368 = *([407C70]) & 0xFF000000FF;\n\tv379 = v367 - v368;\n\tv381 = v366 >= 0;\n\tif (v381) goto L_FFFFFFFF;\n\tgoto L_0095;\nL_0095:\n\t// 149 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 150 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 162 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv387 = v379 * v388;\n\tv389 = v385 & 0xFF;\n\tv390 = v387 + v368;\n\tv155 = v389 / 0x437F0000;\n\t// 168 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 169 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 170 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv173 = v362 >= 0;\n\tif (v173) goto L_FFFFFFFF;\n\tgoto L_00B2;\nL_00B2:\n\tv394 = v390 & 0xFF000000FF;\n\tv223 = v169 & 0xFF;\n\t// 180 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv176 = v394 / v33;\n\tv205 = v223 / 0x437F0000;\n\t// 186 MakeStruct v146 @ AGG151AC44_2_v5 (UnityEngine.Color), typeof(UnityEngine.Color), v205 @ V0_v12 (System.Int32), v176 @ V1_v10 (System.Int32), v396 @ V1.S1, v155 @ V3_v7 (System.Int32)\n\tUnityEngine.MaterialPropertyBlock::SetColor(*([v40 @ X19_v2 (UnityEngine.Component)+38]), *([v40 @ X19_v2 (UnityEngine.Component)+40]), v146);\n\tUnityEngine.Renderer::SetPropertyBlock(*([v40 @ X19_v2 (UnityEngine.Component)+30]), *([v40 @ X19_v2 (UnityEngine.Component)+38]));\n\tv397 = UnityEngine.Time::get_deltaTime();\n\tv399 = v397 * *([v40 @ X19_v2 (UnityEngine.Component)+20]);\n\tv400 = UnityEngine.Mathf::Min(v399, 1f);\n\tv404 = v399 < 0;\n\tv410 = ~v404;\n\tv243 = ~v410;\n\tif (v243) goto L_FFFFFFFF;\n\tgoto L_00DA;\nL_00DA:\n\tv245 = 0 - this.<t>5__3;\n\tv414 = v245 * v413;\n\tv265 = this.<t>5__3 + v414;\n\tv415 = v265 < 0;\n\tv263 = ~v415;\n\tv257 = v265 == 0;\n\tthis.<t>5__3 = v265;\n\tv416 = ~v263;\n\tv247 = v416 | v257;\n\tif (v247) goto L_00F4;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\tgoto L_0111;\nL_00F4:\n\tv337 = UnityEngine.MeshFilter::get_sharedMesh(*([v40 @ X19_v2 (UnityEngine.Component)+28]));\n\tgoto L_0101;\n\tv344 = v124;\n\tv345 = \"il2cpp_codegen_runtime_class_init\"(v344, v336, v149, v22, v23, v24, v25, v26, v112, v91, v80, v68, v72, v70, v33, v34);\nL_0101:\n\tUnityEngine.Object::Destroy(v337);\n\tv118 = UnityEngine.Component::get_gameObject(v40);\n\tUnityEngine.GameObject::SetActive(v118, 0);\nL_0111:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0352: Expected O, but got I
				//IL_014b: Expected I4, but got O
				//IL_0156: Unknown result type (might be due to invalid IL or missing references)
				//IL_015b: Expected I4, but got Unknown
				//IL_016f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0174: Expected O, but got Unknown
				//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ff: Expected O, but got Unknown
				//IL_0219: Expected I4, but got I8
				//IL_0227: Expected O, but got I
				//IL_0413: Expected O, but got I
				//IL_041c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0421: Expected O, but got Unknown
				//IL_042f: Expected O, but got I
				//IL_0491: Expected I4, but got I8
				//IL_049a: Unknown result type (might be due to invalid IL or missing references)
				//IL_049f: Expected O, but got Unknown
				//IL_04ef: Expected F4, but got O
				//IL_051e: Expected O, but got I
				//IL_029a: Expected O, but got I
				//IL_029a: Expected O, but got I
				Component component = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state != 0)
					{
						goto IL_0389;
					}
					_003C_003E1__state = -1;
					_003Ct_003E5__3 = 1f;
					_003ChardTimeLimit_003E5__4 = 5f;
					_003Cblack_003E5__2 = TransparentBlack;
				}
				else
				{
					_003C_003E1__state = -1;
					float deltaTime = Time.deltaTime;
					if (!((_003ChardTimeLimit_003E5__4 -= deltaTime) > 0f))
					{
						goto IL_0341;
					}
				}
				float num = Mathf.Min(_003Ct_003E5__3, 1f);
				float num2 = ((_003Ct_003E5__3 < 0f) ? 0f : num);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+24]");
				int num3 = (int)((nint)0 >> 24);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+24]");
				int num4 = (int)((nint)0 & (nint)0xFF);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				int num5 = (object)_003Cblack_003E5__2 >> 24;
				int num6 = _003Cblack_003E5__2 & 0xFF;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj = num4 - _003Cblack_003E5__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
				int num7 = num3 - num5;
				float num8 = num2 * (float)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				float num9 = num8 + (float)num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
				float num10 = num2 * (float)num7;
				float num11 = num10 + (float)num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj2 = 3.39519326594E-313 & 0xFF000000FFL;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407C70]");
				int num12 = 0;
				object obj3 = (nint)obj2 - num12;
				float num13 = ((!(num11 < 0f)) ? num11 : num11);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj5 = default(object);
				object obj4 = (nint)obj3 * (nint)obj5;
				object obj6 = num13 & 0xFF;
				object obj7 = (nint)obj4 + num12;
				int num14 = (int)((nint)obj6 / 1132396544);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
				float num15 = ((!(num9 < 0f)) ? num9 : num9);
				int num16 = (int)((nint)obj7 & 0xFF000000FFL);
				object obj8 = num15 & 0xFF;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj9 = default(object);
				int num17 = (int)(num16 / (nint)obj9);
				int num18 = (int)((nint)obj8 / 1132396544);
				Color value = default(Color);
				value.r = num18;
				value.g = num17;
				object obj10 = default(object);
				value.b = (float)obj10;
				value.a = num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+38]");
				nint num19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+40]");
				((MaterialPropertyBlock)num19).SetColor(0, value);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+30]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+38]");
				((Renderer)num20).SetPropertyBlock((MaterialPropertyBlock)0);
				float deltaTime2 = Time.deltaTime;
				float num21 = deltaTime2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+20]");
				float num22 = num21 * 0f;
				float num23 = Mathf.Min(num22, 1f);
				float num24 = ((num22 < 0f) ? 0f : num23);
				float num25 = 0f - _003Ct_003E5__3;
				float num26 = num25 * num24;
				float num27 = _003Ct_003E5__3 + num26;
				bool flag = num27 < 0f;
				bool flag2 = !flag;
				bool flag3 = num27 == 0f;
				_003Ct_003E5__3 = num27;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0341;
				IL_0341:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X19_v2 (UnityEngine.Component)+28]");
				Mesh sharedMesh = ((MeshFilter)0).sharedMesh;
				UnityEngine.Object.Destroy(sharedMesh);
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				goto IL_0389;
				IL_0389:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600014C")]
			[Address(RVA = "0x1516D28", Offset = "0x1516D28", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000194")]
		private static readonly Color32 TransparentBlack = default(Color32);

		[Token(Token = "0x4000195")]
		private const string colorPropertyName = "_Color";

		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x20")]
		private float fadeSpeed;

		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x24")]
		private Color32 startColor;

		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x28")]
		private MeshFilter meshFilter;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x30")]
		private MeshRenderer meshRenderer;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x38")]
		private MaterialPropertyBlock mpb;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x40")]
		private int colorId;

		[Token(Token = "0x600013B")]
		[Address(RVA = "0x1516540", Offset = "0x1516540", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv45 = UnityEngine.MaterialPropertyBlock;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv60 = \"_Color\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37A67]) = v36;\nL_001C:\n\tv39 = UnityEngine.Component::get_gameObject(this);\n\tv50 = UnityEngine.GameObject::AddComponent(v39);\n\tthis.meshRenderer = v50;\n\tv54 = UnityEngine.Component::get_gameObject(this);\n\tv83 = UnityEngine.GameObject::AddComponent(v54);\n\tthis.meshFilter = v83;\n\tv86 = UnityEngine.Shader::PropertyToID(\"_Color\");\n\tthis.colorId = v86;\n\tv69 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v69);\n\tthis.mpb = v69;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			GameObject gameObject = base.gameObject;
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			this.meshRenderer = meshRenderer;
			GameObject gameObject2 = base.gameObject;
			MeshFilter meshFilter = gameObject2.AddComponent<MeshFilter>();
			this.meshFilter = meshFilter;
			int num = Shader.PropertyToID("_Color");
			colorId = num;
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			mpb = materialPropertyBlock;
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0x1515FC4", Offset = "0x1515FC4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, mesh, materials, color, additive, sortingLayerID, sortingOrder, methodInfo, speed, v45, v46, v47, v48, v49, v50, v51);\n\tv59 = UnityEngine.Object;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, mesh, materials, color, additive, sortingLayerID, sortingOrder, methodInfo, speed, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37A68]) = v55;\nL_0023:\n\tUnityEngine.MonoBehaviour::StopAllCoroutines(this);\n\tv62 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v62, 1);\n\tUnityEngine.Renderer::set_sharedMaterials(this.meshRenderer, materials);\n\tUnityEngine.Renderer::set_sortingLayerID(this.meshRenderer, sortingLayerID);\n\tUnityEngine.Renderer::set_sortingOrder(this.meshRenderer, sortingOrder);\n\tgoto L_004B;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v172, v171, v96, color, additive, sortingLayerID, sortingOrder, methodInfo, speed, v45, v46, v47, v48, v49, v50, v51);\nL_004B:\n\tv109 = UnityEngine.Object::Instantiate(mesh);\n\tUnityEngine.MeshFilter::set_sharedMesh(this.meshFilter, v109);\n\tthis.startColor = color;\n\tv179 = color >> 0x18;\n\tv127 = v179 & 0xFF;\n\tv180 = color >> 0x10;\n\tv89 = v180 & 0xFF;\n\tv181 = color >> 8;\n\tv86 = v181 & 0xFF;\n\tv83 = color & 0xFF;\n\tv72 = v127 / 0x437F0000;\n\tv70 = v89 / 0x437F0000;\n\tv76 = v86 / 0x437F0000;\n\tv80 = v83 / 0x437F0000;\n\t// 105 MakeStruct v68 @ AGG151A11C_2_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v80 @ V0_v4 (System.Int32), v76 @ V1_v3 (System.Int32), v70 @ V2_v2 (System.Int32), v72 @ V3_v2 (System.Int32)\n\tUnityEngine.MaterialPropertyBlock::SetColor(this.mpb, this.colorId, v68);\n\tUnityEngine.Renderer::SetPropertyBlock(this.meshRenderer, this.mpb);\n\tthis.fadeSpeed = speed;\n\tv149 = additive == 0;\n\tif (v149) goto L_0078;\n\tv191 = Spine.Unity.Examples.SkeletonGhostRenderer::FadeAdditive(this);\n\tgoto L_0087;\nL_0078:\n\tv191 = Spine.Unity.Examples.SkeletonGhostRenderer::Fade(this);\nL_0087:\n\tv147 = UnityEngine.MonoBehaviour::StartCoroutine(this, v191);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(Mesh mesh, Material[] materials, Color32 color, bool additive, float speed, int sortingLayerID, int sortingOrder)
		{
			//IL_0092: Expected I4, but got O
			//IL_00ae: Expected I4, but got O
			//IL_00ca: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected I4, but got Unknown
			StopAllCoroutines();
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: true);
			meshRenderer.sharedMaterials = materials;
			meshRenderer.sortingLayerID = sortingLayerID;
			meshRenderer.sortingOrder = sortingOrder;
			Mesh sharedMesh = UnityEngine.Object.Instantiate(mesh);
			meshFilter.sharedMesh = sharedMesh;
			startColor = color;
			int num = (object)color >> 24;
			int num2 = num & 0xFF;
			int num3 = (object)color >> 16;
			int num4 = num3 & 0xFF;
			int num5 = (object)color >> 8;
			int num6 = num5 & 0xFF;
			int num7 = color & 0xFF;
			int num8 = num2 / 1132396544;
			int num9 = num4 / 1132396544;
			int num10 = num6 / 1132396544;
			int num11 = num7 / 1132396544;
			Color value = default(Color);
			value.r = num11;
			value.g = num10;
			value.b = num9;
			value.a = num8;
			mpb.SetColor(colorId, value);
			meshRenderer.SetPropertyBlock(mpb);
			fadeSpeed = speed;
			IEnumerator routine = ((!additive) ? Fade() : FadeAdditive());
			Coroutine coroutine = StartCoroutine(routine);
		}

		[IteratorStateMachine(typeof(_003CFade_003Ed__10))]
		[Token(Token = "0x600013D")]
		[Address(RVA = "0x1516680", Offset = "0x1516680", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SkeletonGhostRenderer+<Fade>d__10;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A69]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SkeletonGhostRenderer+<Fade>d__10();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Fade()
		{
			_003CFade_003Ed__10 _003CFade_003Ed__11 = null;
			_003CFade_003Ed__11._003C_003E1__state = 0;
			_003CFade_003Ed__11._003C_003E4__this = this;
			return _003CFade_003Ed__11;
		}

		[IteratorStateMachine(typeof(_003CFadeAdditive_003Ed__11))]
		[Token(Token = "0x600013E")]
		[Address(RVA = "0x1516620", Offset = "0x1516620", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SkeletonGhostRenderer+<FadeAdditive>d__11;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A6A]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SkeletonGhostRenderer+<FadeAdditive>d__11();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator FadeAdditive()
		{
			_003CFadeAdditive_003Ed__11 _003CFadeAdditive_003Ed__12 = null;
			_003CFadeAdditive_003Ed__12._003C_003E1__state = 0;
			_003CFadeAdditive_003Ed__12._003C_003E4__this = this;
			return _003CFadeAdditive_003Ed__12;
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x1516388", Offset = "0x1516388", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A6B]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.meshFilter, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_0047;\n\tv78 = UnityEngine.MeshFilter::get_sharedMesh(this.meshFilter);\n\tgoto L_0031;\n\tv105 = v70;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v105, v77, v47, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tv64 = UnityEngine.Object::op_Inequality(v78, 0);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0047;\n\tv121 = UnityEngine.MeshFilter::get_sharedMesh(this.meshFilter);\n\tgoto L_0044;\n\tv123 = v69;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v123, v120, v58, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0044:\n\tUnityEngine.Object::Destroy(v121);\nL_0047:\n\tv76 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0057;\n\tv96 = v89;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v96, v75, v57, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0057:\n\tUnityEngine.Object::Destroy(v76);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Cleanup()
		{
			if (meshFilter != null)
			{
				Mesh sharedMesh = meshFilter.sharedMesh;
				if (sharedMesh != null)
				{
					Mesh sharedMesh2 = meshFilter.sharedMesh;
					UnityEngine.Object.Destroy(sharedMesh2);
				}
			}
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x1516730", Offset = "0x1516730", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fadeSpeed = 10f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonGhostRenderer()
		{
			fadeSpeed = 10f;
		}
	}
}
