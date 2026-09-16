using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteAlways]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonAnimation-Component")]
	[AddComponentMenu("Spine/SkeletonAnimation")]
	[Token(Token = "0x200007D")]
	public class SkeletonAnimation : SkeletonRenderer, ISkeletonAnimation, IAnimationStateComponent
	{
		[Token(Token = "0x4000313")]
		[FieldOffset(Offset = "0xE8")]
		public AnimationState state;

		[Token(Token = "0x4000314")]
		[FieldOffset(Offset = "0xF0")]
		private bool wasUpdatedAfterInit = true;

		[CompilerGenerated]
		[Token(Token = "0x4000315")]
		[FieldOffset(Offset = "0xF8")]
		private UpdateBonesDelegate m__BeforeApply;

		[CompilerGenerated]
		[Token(Token = "0x4000316")]
		[FieldOffset(Offset = "0x100")]
		private UpdateBonesDelegate m__UpdateLocal;

		[CompilerGenerated]
		[Token(Token = "0x4000317")]
		[FieldOffset(Offset = "0x108")]
		private UpdateBonesDelegate m__UpdateWorld;

		[CompilerGenerated]
		[Token(Token = "0x4000318")]
		[FieldOffset(Offset = "0x110")]
		private UpdateBonesDelegate m__UpdateComplete;

		[SerializeField]
		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x4000319")]
		[FieldOffset(Offset = "0x118")]
		private string _animationName;

		[Token(Token = "0x400031A")]
		[FieldOffset(Offset = "0x120")]
		public bool loop;

		[Token(Token = "0x400031B")]
		[FieldOffset(Offset = "0x124")]
		public float timeScale = 1f;

		[Token(Token = "0x17000191")]
		public AnimationState AnimationState
		{
			[Token(Token = "0x6000523")]
			[Address(RVA = "0x1559F08", Offset = "0x1559F08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.state;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return state;
			}
		}

		[Token(Token = "0x17000192")]
		public string AnimationName
		{
			[Token(Token = "0x6000534")]
			[Address(RVA = "0x155A428", Offset = "0x155A428", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.valid;\n\tif (v4) goto L_0012;\n\tv10 = Spine.AnimationState::GetCurrent(this.state, 0);\n\tv41 = v10 == 0;\n\tif (v41) goto L_0016;\n\tv38 = v10.animation + 0x10;\n\tgoto L_0013;\nL_0012:\n\tv38 = this + 0x118;\nL_0013:\n\treturnVal2 = this._animationName;\nL_0016:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0079: Expected O, but got I
				//IL_0068: Expected O, but got I
				string result;
				object obj;
				if (valid)
				{
					TrackEntry current = state.GetCurrent(0);
					bool flag = current == null;
					result = (string)(object)current;
					if (flag)
					{
						goto IL_007e;
					}
					obj = (nint)current.Animation + 16;
				}
				else
				{
					obj = (nint)this + 280;
				}
				result = (string)obj;
				goto IL_007e;
				IL_007e:
				return result;
			}
			[Token(Token = "0x6000535")]
			[Address(RVA = "0x155A470", Offset = "0x155A470", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = System.String::op_Equality(this._animationName, value);\n\tv14 = v12 == 0;\n\tif (v14) goto L_0022;\n\tv54 = Spine.AnimationState::GetCurrent(this.state, 0);\n\tv50 = v54 == 0;\n\tif (v50) goto L_0022;\n\tv30 = v54.loop == this.loop;\n\tif (v30) goto L_004F;\nL_0022:\n\tthis._animationName = value;\n\tv57 = System.String::IsNullOrEmpty(value);\n\tv98 = v57 == 0;\n\tif (v98) goto L_0036;\n\tSpine.AnimationState::ClearTrack(this.state, 0);\n\treturn;\nL_0036:\n\tv81 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 0);\n\tv150 = Spine.SkeletonData::FindAnimation(v81, value);\n\tv148 = v150 == 0;\n\tif (v148) goto L_004F;\n\tv142 = Spine.AnimationState::SetAnimation(this.state, 0, v150, this.loop);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (_animationName == value)
				{
					TrackEntry current = state.GetCurrent(0);
					if (current != null && current.Loop == loop)
					{
						return;
					}
				}
				_animationName = value;
				if (string.IsNullOrEmpty(value))
				{
					state.ClearTrack(0);
					return;
				}
				SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: false);
				Animation animation = skeletonData.FindAnimation(value);
				if (animation != null)
				{
					TrackEntry trackEntry = state.SetAnimation(0, animation, loop);
				}
			}
		}

		[Token(Token = "0x1400000E")]
		protected event UpdateBonesDelegate _BeforeApply
		{
			[CompilerGenerated]
			[Token(Token = "0x6000524")]
			[Address(RVA = "0x1559F10", Offset = "0x1559F10", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C13]) = v38;\nL_0014:\n\tv40 = this + 0xF8;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 248;
				Delegate obj2 = this.m__BeforeApply;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x6000525")]
			[Address(RVA = "0x1559FAC", Offset = "0x1559FAC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C14]) = v38;\nL_0014:\n\tv40 = this + 0xF8;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 248;
				Delegate obj2 = this.m__BeforeApply;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x1400000F")]
		protected event UpdateBonesDelegate _UpdateLocal
		{
			[CompilerGenerated]
			[Token(Token = "0x6000526")]
			[Address(RVA = "0x155A048", Offset = "0x155A048", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C15]) = v38;\nL_0016:\n\tv42 = this + 0x100;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 256;
				Delegate obj2 = this.m__UpdateLocal;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x6000527")]
			[Address(RVA = "0x155A0E8", Offset = "0x155A0E8", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C16]) = v38;\nL_0016:\n\tv42 = this + 0x100;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 256;
				Delegate obj2 = this.m__UpdateLocal;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x14000010")]
		protected event UpdateBonesDelegate _UpdateWorld
		{
			[CompilerGenerated]
			[Token(Token = "0x6000528")]
			[Address(RVA = "0x155A188", Offset = "0x155A188", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C17]) = v38;\nL_0016:\n\tv42 = this + 0x108;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 264;
				Delegate obj2 = this.m__UpdateWorld;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x6000529")]
			[Address(RVA = "0x155A228", Offset = "0x155A228", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C18]) = v38;\nL_0016:\n\tv42 = this + 0x108;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 264;
				Delegate obj2 = this.m__UpdateWorld;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x14000011")]
		protected event UpdateBonesDelegate _UpdateComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x600052A")]
			[Address(RVA = "0x155A2C8", Offset = "0x155A2C8", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C19]) = v38;\nL_0016:\n\tv42 = this + 0x110;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 272;
				Delegate obj2 = this.m__UpdateComplete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x600052B")]
			[Address(RVA = "0x155A368", Offset = "0x155A368", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C1A]) = v38;\nL_0016:\n\tv42 = this + 0x110;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 272;
				Delegate obj2 = this.m__UpdateComplete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x14000012")]
		public event UpdateBonesDelegate BeforeApply
		{
			[Token(Token = "0x600052C")]
			[Address(RVA = "0x155A408", Offset = "0x155A408", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::add__BeforeApply(this, value);\n\treturn;\n")]
			add
			{
				_BeforeApply += value;
			}
			[Token(Token = "0x600052D")]
			[Address(RVA = "0x155A40C", Offset = "0x155A40C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::remove__BeforeApply(this, value);\n\treturn;\n")]
			remove
			{
				_BeforeApply -= value;
			}
		}

		[Token(Token = "0x14000013")]
		public event UpdateBonesDelegate UpdateLocal
		{
			[Token(Token = "0x600052E")]
			[Address(RVA = "0x155A410", Offset = "0x155A410", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::add__UpdateLocal(this, value);\n\treturn;\n")]
			add
			{
				_UpdateLocal += value;
			}
			[Token(Token = "0x600052F")]
			[Address(RVA = "0x155A414", Offset = "0x155A414", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::remove__UpdateLocal(this, value);\n\treturn;\n")]
			remove
			{
				_UpdateLocal -= value;
			}
		}

		[Token(Token = "0x14000014")]
		public event UpdateBonesDelegate UpdateWorld
		{
			[Token(Token = "0x6000530")]
			[Address(RVA = "0x155A418", Offset = "0x155A418", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::add__UpdateWorld(this, value);\n\treturn;\n")]
			add
			{
				_UpdateWorld += value;
			}
			[Token(Token = "0x6000531")]
			[Address(RVA = "0x155A41C", Offset = "0x155A41C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::remove__UpdateWorld(this, value);\n\treturn;\n")]
			remove
			{
				_UpdateWorld -= value;
			}
		}

		[Token(Token = "0x14000015")]
		public event UpdateBonesDelegate UpdateComplete
		{
			[Token(Token = "0x6000532")]
			[Address(RVA = "0x155A420", Offset = "0x155A420", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::add__UpdateComplete(this, value);\n\treturn;\n")]
			add
			{
				_UpdateComplete += value;
			}
			[Token(Token = "0x6000533")]
			[Address(RVA = "0x155A424", Offset = "0x155A424", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimation::remove__UpdateComplete(this, value);\n\treturn;\n")]
			remove
			{
				_UpdateComplete -= value;
			}
		}

		[Token(Token = "0x6000536")]
		[Address(RVA = "0x155A540", Offset = "0x155A540", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonDataAsset, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = Spine.Unity.SkeletonRenderer;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, skeletonDataAsset, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37C1B]) = v41;\nL_001E:\n\tgoto L_0029;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, skeletonDataAsset, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0029:\n\treturnVal1 = Spine.Unity.SkeletonRenderer::AddSpineComponent(gameObject, skeletonDataAsset);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonAnimation AddToGameObject(GameObject gameObject, SkeletonDataAsset skeletonDataAsset)
		{
			return SkeletonRenderer.AddSpineComponent<SkeletonAnimation>(gameObject, skeletonDataAsset);
		}

		[Token(Token = "0x6000537")]
		[Address(RVA = "0x155A5BC", Offset = "0x155A5BC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = Spine.Unity.SkeletonRenderer;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C1C]) = v38;\nL_001C:\n\tgoto L_0025;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\treturnVal1 = Spine.Unity.SkeletonRenderer::NewSpineGameObject(skeletonDataAsset);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonAnimation NewSkeletonAnimationGameObject(SkeletonDataAsset skeletonDataAsset)
		{
			return SkeletonRenderer.NewSpineGameObject<SkeletonAnimation>(skeletonDataAsset);
		}

		[Token(Token = "0x6000538")]
		[Address(RVA = "0x155A628", Offset = "0x155A628", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonRenderer::ClearState(this);\n\tv8 = this.state == 0;\n\tif (v8) goto L_0011;\n\tSpine.AnimationState::ClearTracks(this.state);\n\treturn;\nL_0011:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ClearState()
		{
			base.ClearState();
			if (state != null)
			{
				state.ClearTracks();
			}
		}

		[Token(Token = "0x6000539")]
		[Address(RVA = "0x155A728", Offset = "0x155A728", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = Spine.AnimationState;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, overwrite, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37C1D]) = v36;\nL_0013:\n\tv38 = ~this.valid;\n\tif (v38) goto L_001A;\n\tv40 = overwrite == 0;\n\tif (v40) goto L_0059;\nL_001A:\n\tSpine.Unity.SkeletonRenderer::Initialize(this, overwrite);\n\tv54 = ~this.valid;\n\tif (v54) goto L_0059;\n\tv96 = this.skeletonDataAsset;\n\tv58 = v96.stateData;\n\tv99 = v96.stateData == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002C;\n\tv110 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(v96, 0);\n\tv58 = v96.stateData;\nL_002C:\n\tv116 = new Spine.AnimationState();\n\tSpine.AnimationState::.ctor(v116, v58);\n\tthis.state = v116;\n\tthis.wasUpdatedAfterInit = 0;\n\tv51 = System.String::IsNullOrEmpty(this._animationName);\n\tv120 = v51 == 0;\n\tv55 = ~v120;\n\tif (v55) goto L_0059;\n\tv104 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 0);\n\tv52 = Spine.SkeletonData::FindAnimation(v104, this._animationName);\n\tv56 = v52 == 0;\n\tif (v56) goto L_0059;\n\tv81 = Spine.AnimationState::SetAnimation(this.state, 0, v52, this.loop);\n\treturn;\nL_0059:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Initialize(bool overwrite)
		{
			if (valid && !overwrite)
			{
				return;
			}
			base.Initialize(overwrite);
			if (!valid)
			{
				return;
			}
			SkeletonDataAsset skeletonDataAsset = base.skeletonDataAsset;
			AnimationStateData stateData = skeletonDataAsset.stateData;
			if (skeletonDataAsset.stateData == null)
			{
				SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: false);
				stateData = skeletonDataAsset.stateData;
			}
			AnimationState animationState = new AnimationState(stateData);
			state = animationState;
			wasUpdatedAfterInit = false;
			if (!string.IsNullOrEmpty(_animationName))
			{
				SkeletonData skeletonData2 = base.skeletonDataAsset.GetSkeletonData(quiet: false);
				Animation animation = skeletonData2.FindAnimation(_animationName);
				if (animation != null)
				{
					TrackEntry trackEntry = state.SetAnimation(0, animation, loop);
				}
			}
		}

		[Token(Token = "0x600053A")]
		[Address(RVA = "0x155AB34", Offset = "0x155AB34", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Time::get_deltaTime();\n\tSpine.Unity.SkeletonAnimation::Update(this, v7);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			float deltaTime = Time.deltaTime;
			Update(deltaTime);
		}

		[Token(Token = "0x600053B")]
		[Address(RVA = "0x155AB50", Offset = "0x155AB50", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = ~this.valid;\n\tif (v6) goto L_002A;\n\tv9 = this.state == 0;\n\tif (v9) goto L_002A;\n\tthis.wasUpdatedAfterInit = 1;\n\tv15 = this.updateMode < 1;\n\tif (v15) goto L_002A;\n\tSpine.Unity.SkeletonAnimation::UpdateAnimationStatus(this, deltaTime);\n\tv13 = this.updateMode != 1;\n\tif (v13) goto L_002F;\nL_002A:\n\treturn;\nL_002F:\n\tSpine.Unity.SkeletonAnimation::ApplyAnimation(this);\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update(float deltaTime)
		{
			if (!valid || state == null)
			{
				return;
			}
			wasUpdatedAfterInit = true;
			if (UpdateMode >= UpdateMode.OnlyAnimationStatus)
			{
				Update(deltaTime);
				if (UpdateMode != UpdateMode.OnlyAnimationStatus)
				{
					ApplyAnimation();
				}
			}
		}

		[Token(Token = "0x600053C")]
		[Address(RVA = "0x155ABA4", Offset = "0x155ABA4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.timeScale * deltaTime;\n\tSpine.Skeleton::Update(this.skeleton, v12);\n\tSpine.AnimationState::Update(this.state, v12);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void UpdateAnimationStatus(float deltaTime)
		{
			float delta = timeScale * deltaTime;
			skeleton.Update(delta);
			state.Update(delta);
		}

		[Token(Token = "0x600053D")]
		[Address(RVA = "0x155ABEC", Offset = "0x155ABEC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this._BeforeApply == 0;\n\tif (v7) goto L_001A;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._BeforeApply, this);\nL_001A:\n\tv46 = this.updateMode != 4;\n\tif (v46) goto L_0020;\n\tv85 = Spine.AnimationState::ApplyEventTimelinesOnly(this.state, this.skeleton);\n\tgoto L_0021;\nL_0020:\n\tv87 = Spine.AnimationState::Apply(this.state, this.skeleton);\nL_0021:\n\t;\n\tv90 = this._UpdateLocal == 0;\n\tif (v90) goto L_002D;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._UpdateLocal, this);\nL_002D:\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\n\tv130 = this._UpdateWorld == 0;\n\tif (v130) goto L_003B;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._UpdateWorld, this);\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\nL_003B:\n\t;\n\tv117 = this._UpdateComplete == 0;\n\tif (v117) goto L_0049;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this._UpdateComplete, this);\nL_0049:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ApplyAnimation()
		{
			if (this._BeforeApply != null)
			{
				this._BeforeApply(this);
			}
			if (UpdateMode == UpdateMode.OnlyEventTimelines)
			{
				bool flag = state.ApplyEventTimelinesOnly(skeleton);
			}
			else
			{
				bool flag2 = state.Apply(skeleton);
			}
			if (this._UpdateLocal != null)
			{
				this._UpdateLocal(this);
			}
			skeleton.UpdateWorldTransform();
			if (this._UpdateWorld != null)
			{
				this._UpdateWorld(this);
				skeleton.UpdateWorldTransform();
			}
			if (this._UpdateComplete != null)
			{
				this._UpdateComplete(this);
			}
		}

		[Token(Token = "0x600053E")]
		[Address(RVA = "0x155ACC0", Offset = "0x155ACC0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = ~this.wasUpdatedAfterInit;\n\tv8 = ~v7;\n\tif (v8) goto L_000F;\n\tSpine.Unity.SkeletonAnimation::Update(this, 0f);\nL_000F:\n\tSpine.Unity.SkeletonRenderer::LateUpdate(this);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LateUpdate()
		{
			if (!wasUpdatedAfterInit)
			{
				Update(0f);
			}
			base.LateUpdate();
		}

		[Token(Token = "0x600053F")]
		[Address(RVA = "0x155B2DC", Offset = "0x155B2DC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.Unity.SkeletonRenderer;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C1E]) = v37;\nL_0015:\n\tthis.wasUpdatedAfterInit = 1;\n\tthis.timeScale = 1f;\n\tgoto L_0023;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tSpine.Unity.SkeletonRenderer::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonAnimation()
		{
		}
	}
}
