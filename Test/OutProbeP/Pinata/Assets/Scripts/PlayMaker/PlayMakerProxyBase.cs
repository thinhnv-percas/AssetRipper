using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000015")]
public abstract class PlayMakerProxyBase : MonoBehaviour
{
	[Token(Token = "0x200008C")]
	public delegate void TriggerEvent(Collider other);

	[Token(Token = "0x200008D")]
	public delegate void CollisionEvent(Collision collisionInfo);

	[Token(Token = "0x200008E")]
	public delegate void Trigger2DEvent(Collider2D other);

	[Token(Token = "0x200008F")]
	public delegate void Collision2DEvent(Collision2D collisionInfo);

	[Token(Token = "0x2000090")]
	public delegate void ParticleCollisionEvent(GameObject gameObject);

	[Token(Token = "0x2000091")]
	public delegate void ControllerCollisionEvent(ControllerColliderHit hitCollider);

	[Token(Token = "0x400003D")]
	[FieldOffset(Offset = "0x18")]
	public List<PlayMakerFSM> TargetFSMs;

	[CompilerGenerated]
	[Token(Token = "0x400003E")]
	[FieldOffset(Offset = "0x20")]
	internal TriggerEvent TriggerEventCallback;

	[CompilerGenerated]
	[Token(Token = "0x400003F")]
	[FieldOffset(Offset = "0x28")]
	internal CollisionEvent CollisionEventCallback;

	[CompilerGenerated]
	[Token(Token = "0x4000040")]
	[FieldOffset(Offset = "0x30")]
	private ParticleCollisionEvent m_ParticleCollisionEventCallback;

	[CompilerGenerated]
	[Token(Token = "0x4000041")]
	[FieldOffset(Offset = "0x38")]
	internal ControllerCollisionEvent ControllerCollisionEventCallback;

	[CompilerGenerated]
	[Token(Token = "0x4000042")]
	[FieldOffset(Offset = "0x40")]
	internal Trigger2DEvent Trigger2DEventCallback;

	[CompilerGenerated]
	[Token(Token = "0x4000043")]
	[FieldOffset(Offset = "0x48")]
	internal Collision2DEvent Collision2DEventCallback;

	[Token(Token = "0x1700002E")]
	protected PlayMakerFSM[] playMakerFSMs
	{
		[Token(Token = "0x60000AD")]
		[Address(RVA = "0xE5DA10", Offset = "0xE5DA10", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EC5000]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202484A]) = v38;\nL_001E:\n\treturnVal1 = System.Collections.Generic.List`1<PlayMakerFSM>::ToArray(this.TargetFSMs);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return TargetFSMs.ToArray();
		}
	}

	[Token(Token = "0x14000001")]
	private event TriggerEvent TriggerEventCallback
	{
		[CompilerGenerated]
		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xE5DA68", Offset = "0xE5DA68", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ECF5F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202484B]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+TriggerEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 32L;
			Delegate obj2 = this.TriggerEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(TriggerEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000AF")]
		[Address(RVA = "0xE5DB0C", Offset = "0xE5DB0C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED38E0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202484C]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+TriggerEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 32L;
			Delegate obj2 = this.TriggerEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(TriggerEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000002")]
	private event CollisionEvent CollisionEventCallback
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B0")]
		[Address(RVA = "0xE5DBB0", Offset = "0xE5DBB0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDC478]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202484D]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+CollisionEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 40L;
			Delegate obj2 = this.CollisionEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(CollisionEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B1")]
		[Address(RVA = "0xE5DC54", Offset = "0xE5DC54", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB5D00]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202484E]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+CollisionEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 40L;
			Delegate obj2 = this.CollisionEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(CollisionEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000003")]
	private event ParticleCollisionEvent ParticleCollisionEventCallback
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B2")]
		[Address(RVA = "0xE5DCF8", Offset = "0xE5DCF8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBBBF0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202484F]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+ParticleCollisionEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 48L;
			Delegate obj2 = this.m_ParticleCollisionEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(ParticleCollisionEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B3")]
		[Address(RVA = "0xE5DD9C", Offset = "0xE5DD9C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB1790]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024850]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+ParticleCollisionEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 48L;
			Delegate obj2 = this.m_ParticleCollisionEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(ParticleCollisionEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000004")]
	private event ControllerCollisionEvent ControllerCollisionEventCallback
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B4")]
		[Address(RVA = "0xE5DE40", Offset = "0xE5DE40", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB2AB0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024851]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+ControllerCollisionEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 56L;
			Delegate obj2 = this.ControllerCollisionEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(ControllerCollisionEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B5")]
		[Address(RVA = "0xE5DEE4", Offset = "0xE5DEE4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F09A40]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024852]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+ControllerCollisionEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 56L;
			Delegate obj2 = this.ControllerCollisionEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(ControllerCollisionEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
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
	private event Trigger2DEvent Trigger2DEventCallback
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B6")]
		[Address(RVA = "0xE5DF88", Offset = "0xE5DF88", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F0EA78]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024853]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+Trigger2DEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 64L;
			Delegate obj2 = this.Trigger2DEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(Trigger2DEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B7")]
		[Address(RVA = "0xE5E02C", Offset = "0xE5E02C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE05E0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024854]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+Trigger2DEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 64L;
			Delegate obj2 = this.Trigger2DEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(Trigger2DEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
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
	private event Collision2DEvent Collision2DEventCallback
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B8")]
		[Address(RVA = "0xE5E0D0", Offset = "0xE5E0D0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBA910]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024855]) = v43;\nL_0017:\n\tv45 = this + 0x48;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+Collision2DEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 72L;
			Delegate obj2 = this.Collision2DEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(Collision2DEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B9")]
		[Address(RVA = "0xE5E174", Offset = "0xE5E174", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA7560]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024856]) = v43;\nL_0017:\n\tv45 = this + 0x48;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != PlayMakerProxyBase+Collision2DEvent;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 72L;
			Delegate obj2 = this.Collision2DEventCallback;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(Collision2DEvent))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x60000BA")]
	[Address(RVA = "0xE5E218", Offset = "0xE5E218", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EBF2B0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fsmTarget, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024857]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.List`1<PlayMakerFSM>::Contains(this.TargetFSMs, fsmTarget);\n\tv58 = v48 == 0;\n\tif (v58) goto L_0034;\n\treturn;\nL_0034:\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::Add(this.TargetFSMs, fsmTarget);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddTarget(PlayMakerFSM fsmTarget)
	{
		if (!TargetFSMs.Contains(fsmTarget))
		{
			TargetFSMs.Add(fsmTarget);
		}
	}

	[Token(Token = "0x60000BB")]
	[Address(RVA = "0xE5E2B0", Offset = "0xE5E2B0", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.TriggerEventCallback == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool HasTriggerEventDelegates()
	{
		bool flag = this.TriggerEventCallback == null;
		return !flag;
	}

	[Token(Token = "0x60000BC")]
	[Address(RVA = "0xE5E2C0", Offset = "0xE5E2C0", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::add_TriggerEventCallback(this, triggerEvent);\n\treturn;\n")]
	public void AddTriggerEventCallback(TriggerEvent triggerEvent)
	{
		TriggerEventCallback += triggerEvent;
	}

	[Token(Token = "0x60000BD")]
	[Address(RVA = "0xE5E2C4", Offset = "0xE5E2C4", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::remove_TriggerEventCallback(this, triggerEvent);\n\treturn;\n")]
	public void RemoveTriggerEventCallback(TriggerEvent triggerEvent)
	{
		TriggerEventCallback -= triggerEvent;
	}

	[Token(Token = "0x60000BE")]
	[Address(RVA = "0xE5E2C8", Offset = "0xE5E2C8", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.TriggerEventCallback == 0;\n\tif (v2) goto L_0005;\n\tPlayMakerProxyBase+TriggerEvent::Invoke(this.TriggerEventCallback, other);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DoTriggerEventCallback(Collider other)
	{
		if (this.TriggerEventCallback != null)
		{
			this.TriggerEventCallback(other);
		}
	}

	[Token(Token = "0x60000BF")]
	[Address(RVA = "0xE5E68C", Offset = "0xE5E68C", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.Trigger2DEventCallback == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool HasTrigger2DEventDelegates()
	{
		bool flag = this.Trigger2DEventCallback == null;
		return !flag;
	}

	[Token(Token = "0x60000C0")]
	[Address(RVA = "0xE5E69C", Offset = "0xE5E69C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::add_Trigger2DEventCallback(this, triggerEvent);\n\treturn;\n")]
	public void AddTrigger2DEventCallback(Trigger2DEvent triggerEvent)
	{
		Trigger2DEventCallback += triggerEvent;
	}

	[Token(Token = "0x60000C1")]
	[Address(RVA = "0xE5E6A0", Offset = "0xE5E6A0", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::remove_Trigger2DEventCallback(this, triggerEvent);\n\treturn;\n")]
	public void RemoveTrigger2DEventCallback(Trigger2DEvent triggerEvent)
	{
		Trigger2DEventCallback -= triggerEvent;
	}

	[Token(Token = "0x60000C2")]
	[Address(RVA = "0xE5E6A4", Offset = "0xE5E6A4", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Trigger2DEventCallback == 0;\n\tif (v2) goto L_0005;\n\tPlayMakerProxyBase+Trigger2DEvent::Invoke(this.Trigger2DEventCallback, other);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DoTrigger2DEventCallback(Collider2D other)
	{
		if (this.Trigger2DEventCallback != null)
		{
			this.Trigger2DEventCallback(other);
		}
	}

	[Token(Token = "0x60000C3")]
	[Address(RVA = "0xE5EA68", Offset = "0xE5EA68", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.CollisionEventCallback == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool HasCollisionEventDelegates()
	{
		bool flag = this.CollisionEventCallback == null;
		return !flag;
	}

	[Token(Token = "0x60000C4")]
	[Address(RVA = "0xE5EA78", Offset = "0xE5EA78", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::add_CollisionEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void AddCollisionEventCallback(CollisionEvent collisionEvent)
	{
		CollisionEventCallback += collisionEvent;
	}

	[Token(Token = "0x60000C5")]
	[Address(RVA = "0xE5EA7C", Offset = "0xE5EA7C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::remove_CollisionEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void RemoveCollisionEventCallback(CollisionEvent collisionEvent)
	{
		CollisionEventCallback -= collisionEvent;
	}

	[Token(Token = "0x60000C6")]
	[Address(RVA = "0xE546E0", Offset = "0xE546E0", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.CollisionEventCallback == 0;\n\tif (v2) goto L_0005;\n\tPlayMakerProxyBase+CollisionEvent::Invoke(this.CollisionEventCallback, collisionInfo);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DoCollisionEventCallback(Collision collisionInfo)
	{
		if (this.CollisionEventCallback != null)
		{
			this.CollisionEventCallback(collisionInfo);
		}
	}

	[Token(Token = "0x60000C7")]
	[Address(RVA = "0xE5EE34", Offset = "0xE5EE34", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.Collision2DEventCallback == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool HasCollision2DEventDelegates()
	{
		bool flag = this.Collision2DEventCallback == null;
		return !flag;
	}

	[Token(Token = "0x60000C8")]
	[Address(RVA = "0xE5EE44", Offset = "0xE5EE44", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::add_Collision2DEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void AddCollision2DEventCallback(Collision2DEvent collisionEvent)
	{
		Collision2DEventCallback += collisionEvent;
	}

	[Token(Token = "0x60000C9")]
	[Address(RVA = "0xE5EE48", Offset = "0xE5EE48", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::remove_Collision2DEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void RemoveCollision2DEventCallback(Collision2DEvent collisionEvent)
	{
		Collision2DEventCallback -= collisionEvent;
	}

	[Token(Token = "0x60000CA")]
	[Address(RVA = "0xE5483C", Offset = "0xE5483C", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Collision2DEventCallback == 0;\n\tif (v2) goto L_0005;\n\tPlayMakerProxyBase+Collision2DEvent::Invoke(this.Collision2DEventCallback, collisionInfo);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DoCollision2DEventCallback(Collision2D collisionInfo)
	{
		if (this.Collision2DEventCallback != null)
		{
			this.Collision2DEventCallback(collisionInfo);
		}
	}

	[Token(Token = "0x60000CB")]
	[Address(RVA = "0xE5F200", Offset = "0xE5F200", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.ParticleCollisionEventCallback == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool HasParticleCollisionEventDelegates()
	{
		bool flag = this.ParticleCollisionEventCallback == null;
		return !flag;
	}

	[Token(Token = "0x60000CC")]
	[Address(RVA = "0xE5F210", Offset = "0xE5F210", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::add_ParticleCollisionEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void AddParticleCollisionEventCallback(ParticleCollisionEvent collisionEvent)
	{
		ParticleCollisionEventCallback += collisionEvent;
	}

	[Token(Token = "0x60000CD")]
	[Address(RVA = "0xE5F214", Offset = "0xE5F214", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::remove_ParticleCollisionEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void RemoveParticleCollisionEventCallback(ParticleCollisionEvent collisionEvent)
	{
		ParticleCollisionEventCallback -= collisionEvent;
	}

	[Token(Token = "0x60000CE")]
	[Address(RVA = "0xE5F218", Offset = "0xE5F218", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.ParticleCollisionEventCallback == 0;\n\tif (v2) goto L_0005;\n\tPlayMakerProxyBase+ParticleCollisionEvent::Invoke(this.ParticleCollisionEventCallback, go);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DoParticleCollisionEventCallback(GameObject go)
	{
		if (this.ParticleCollisionEventCallback != null)
		{
			this.ParticleCollisionEventCallback(go);
		}
	}

	[Token(Token = "0x60000CF")]
	[Address(RVA = "0xE5F5DC", Offset = "0xE5F5DC", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.ControllerCollisionEventCallback == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool HasControllerCollisionEventDelegates()
	{
		bool flag = this.ControllerCollisionEventCallback == null;
		return !flag;
	}

	[Token(Token = "0x60000D0")]
	[Address(RVA = "0xE5F5EC", Offset = "0xE5F5EC", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::add_ControllerCollisionEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void AddControllerCollisionEventCallback(ControllerCollisionEvent collisionEvent)
	{
		ControllerCollisionEventCallback += collisionEvent;
	}

	[Token(Token = "0x60000D1")]
	[Address(RVA = "0xE5F5F0", Offset = "0xE5F5F0", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::remove_ControllerCollisionEventCallback(this, collisionEvent);\n\treturn;\n")]
	public void RemoveControllerCollisionEventCallback(ControllerCollisionEvent collisionEvent)
	{
		ControllerCollisionEventCallback -= collisionEvent;
	}

	[Token(Token = "0x60000D2")]
	[Address(RVA = "0xE54EC8", Offset = "0xE54EC8", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.ControllerCollisionEventCallback == 0;\n\tif (v2) goto L_0005;\n\tPlayMakerProxyBase+ControllerCollisionEvent::Invoke(this.ControllerCollisionEventCallback, hitCollider);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DoControllerCollisionEventCallback(ControllerColliderHit hitCollider)
	{
		if (this.ControllerCollisionEventCallback != null)
		{
			this.ControllerCollisionEventCallback(hitCollider);
		}
	}

	[Token(Token = "0x60000D3")]
	[Address(RVA = "0xE54100", Offset = "0xE54100", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0B1A8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024858]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v42);\n\tthis.TargetFSMs = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected internal PlayMakerProxyBase()
	{
		List<PlayMakerFSM> targetFSMs = new List<PlayMakerFSM>();
		TargetFSMs = targetFSMs;
	}
}
