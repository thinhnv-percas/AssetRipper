using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Unco.OverridableSystem.Runtime.OverridableSystem
{
	[Token(Token = "0x200079D")]
	public class OverridableValue<T> where T : struct
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200079E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400193B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400193C")]
			public static Func<(IOverride<T> overrider, int priority), int> _003C_003E9__15_0;

			[Token(Token = "0x6002023")]
			[Address(RVA = "0x4F98B08", Offset = "0x4F98B08", Length = "0x15C")]
			static _003C_003Ec()
			{
				//IL_01af: Expected O, but got I
				//IL_01b7: Expected I, but got O
				//IL_0247: Expected O, but got I
				//IL_0325: Expected O, but got I
				//IL_02b4: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X0_v1 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X0_v37 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1<T>+<>c<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					nint num4 = 0;
					nint num5 = 0;
					if (!flag)
					{
						goto IL_007e;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X0_v6+C0]");
					object obj = 0;
					nint num4 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X0_v34 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1<T>+<>c<T>>)+135]");
					int num6 = (int)((nint)0 & (nint)1);
					bool flag2 = num6 == 0;
					bool flag3 = !flag2;
					nint num5 = num4;
					if (flag3)
					{
						goto IL_007e;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				_003C_003Ec _003C_003Ec2 = null;
				_003C_003Ec _003C_003Ec3 = _003C_003Ec2;
				goto IL_0090;
				IL_0108:
				_003C_003E9 = _003C_003Ec3;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X0_v29 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1+<>c>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				nint num9 = 0;
				if (!flag4)
				{
					goto IL_0150;
				}
				goto IL_0306;
				IL_0306:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v16+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v14+10]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X0_v11 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1<T>+<>c<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0373;
				IL_0150:
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v27 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1<T>+<>c<T>>)+135]");
				int num12 = (int)((nint)0 & (nint)1);
				bool flag5 = num12 == 0;
				num10 = 0;
				if (!flag5)
				{
					return;
				}
				goto IL_0373;
				IL_007e:
				_003C_003Ec _003C_003Ec4 = null;
				_003C_003Ec3 = _003C_003Ec4;
				goto IL_0090;
				IL_0090:
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X0_v10 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v30 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1<T>+<>c<T>>)+135]");
					int num15 = (int)((nint)0 & (nint)1);
					bool flag6 = num15 == 0;
					nint num16 = 0;
					if (!flag6)
					{
						goto IL_0108;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v21+C0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X8_v21+10]");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X0_v18 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1<T>+<>c<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0108;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X0_v19+B8]");
				object obj4 = 0;
				obj4 = _003C_003Ec3;
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v20 (Il2CppClass<Unco.OverridableSystem.Runtime.OverridableSystem.OverridableValue`1+<>c>)+135]");
				int num18 = (int)((nint)0 & (nint)1);
				bool flag7 = num18 == 0;
				bool flag8 = !flag7;
				num9 = 0;
				if (flag8)
				{
					goto IL_0150;
				}
				goto IL_0306;
				IL_0373:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}

			[Token(Token = "0x6002024")]
			[Address(RVA = "0x4F98C64", Offset = "0x4F98C64", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal int _003CRebuild_003Eb__15_0((IOverride<T> overrider, int priority) tuple)
			{
				int result = default(int);
				return result;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200079F")]
		private sealed class _003C_003Ec__DisplayClass14_0
		{
			[Token(Token = "0x400193D")]
			[FieldOffset(Offset = "0x0")]
			public IOverride<T> o;

			[Token(Token = "0x6002026")]
			[Address(RVA = "0x5DB59C8", Offset = "0x5DB59C8", Length = "0x8")]
			public _003C_003Ec__DisplayClass14_0()
			{
			}

			internal bool _003CRemoveOverride_003Eb__0((IOverride<T> overrider, int priority) x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue._003C_003Ec__DisplayClass14_0::_003CRemoveOverride_003Eb__0");
				return default;
			}
		}

		[Token(Token = "0x4001937")]
		[FieldOffset(Offset = "0x0")]
		private T _value;

		[CompilerGenerated]
		[Token(Token = "0x4001939")]
		[FieldOffset(Offset = "0x0")]
		private Action<T> OnValueChanged;

		[Token(Token = "0x400193A")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<(IOverride<T> overrider, int priority)> _overrides;

		[Token(Token = "0x17000315")]
		public T Value
		{
			[Token(Token = "0x6002018")]
			[Address(RVA = "0x5E9F494", Offset = "0x5E9F494", Length = "0x8")]
			get
			{
				return this;
			}
			[Token(Token = "0x6002019")]
			[Address(RVA = "0x5E9F49C", Offset = "0x5E9F49C", Length = "0x8")]
			private set
			{
				T value2 = default(T);
				_value = value2;
			}
		}

		[Token(Token = "0x17000316")]
		public T BaseValue
		{
			[CompilerGenerated]
			[Token(Token = "0x600201A")]
			[Address(RVA = "0x5E9F4A4", Offset = "0x5E9F4A4", Length = "0x8")]
			get
			{
				return this;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x600201B")]
		[Address(RVA = "0x5E9F4AC", Offset = "0x5E9F4AC", Length = "0xB4")]
		public void add_OnValueChanged(Action<T> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue::add_OnValueChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x600201C")]
		[Address(RVA = "0x5E9F560", Offset = "0x5E9F560", Length = "0xB4")]
		public void remove_OnValueChanged(Action<T> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue::remove_OnValueChanged");
		}

		[Token(Token = "0x600201D")]
		[Address(RVA = "0x5E9F614", Offset = "0x5E9F614", Length = "0x7C")]
		public OverridableValue(T value)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X1 (T)+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X8_v1+C0]");
			object obj2 = 0;
			T value2 = default(T);
			_value = value2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X8_v2+28]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X0_v2+135]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			List<(object, int)> onValueChanged = new List<(object, int)>();
			OnValueChanged = (Action<T>)(object)onValueChanged;
		}

		[Token(Token = "0x600201E")]
		[Address(RVA = "0x5E9F690", Offset = "0x5E9F690", Length = "0x3C")]
		public static implicit operator T(OverridableValue<T> overridableValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue::operator T");
			return default;
		}

		[Token(Token = "0x600201F")]
		[Address(RVA = "0x5E9F6CC", Offset = "0x5E9F6CC", Length = "0x104")]
		public static implicit operator OverridableValue<T>(T value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue::operator OverridableValue<T>");
			return default;
		}

		[Token(Token = "0x6002020")]
		[Address(RVA = "0x5E9F7D0", Offset = "0x5E9F7D0", Length = "0xD4")]
		public void AddOverride(IOverride<T> o, int priority)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue::AddOverride");
		}

		[Token(Token = "0x6002021")]
		[Address(RVA = "0x5E9F8A4", Offset = "0x5E9F8A4", Length = "0xEC")]
		public void RemoveOverride(IOverride<T> o)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue::RemoveOverride");
		}

		[Token(Token = "0x6002022")]
		[Address(RVA = "0x5E9F990", Offset = "0x5E9F990", Length = "0x58C")]
		private void Rebuild()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OverridableValue::Rebuild");
		}
	}
}
