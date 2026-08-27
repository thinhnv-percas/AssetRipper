using DSMCaps.Arm;
using DSMCaps.Arm64;
using DSMCaps.M68K;
using DSMCaps.Mips;
using DSMCaps.PowerPc;
using DSMCaps.X86;
using DSMCaps.XCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DSMCaps
{
	public abstract class CapstoneDisassembler : IDisposable
	{
		public static bool IsArm64Supported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryArm64Architecture);

		public static bool IsArmSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryArmArchitecture);

		public static bool IsDietModeEnabled => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryDietMode);

		internal static bool IsEvmSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryEvmArchitecture);

		internal static bool IsM680XSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryM680XArchitecture);

		public static bool IsM68KSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryM68KArchitecture);

		public static bool IsMipsSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryMipsArchitecture);

		public static bool IsPowerPcSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryPowerPcArchitecture);

		internal static bool IsSparcSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QuerySparcArchitecture);

		internal static bool IsSystemZSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QuerySystemZArchitecture);

		internal static bool IsTms320C64XSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryTms320C64XArchitecture);

		public static bool IsX86ReduceModeEnabled => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryX86ReduceMode);

		public static bool IsX86Supported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryX86Architecture);

		public static bool IsXCoreSupported => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(NativeQueryOption.QueryXCoreArchitecture);

		public static Version Version => _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020();

		public abstract DisassembleArchitecture DisassembleArchitecture
		{
			get;
		}

		public abstract bool EnableInstructionDetails
		{
			get;
			set;
		}

		public abstract bool EnableSkipDataMode
		{
			get;
			set;
		}

		internal abstract _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 Handle
		{
			get;
		}

		internal abstract NativeDisassembleMode NativeDisassembleMode
		{
			get;
		}

		public abstract string SkipDataInstructionMnemonic
		{
			get;
			set;
		}

		public static CapstoneArm64Disassembler CreateArm64Disassembler(Arm64DisassembleMode disassembleMode)
		{
			return new CapstoneArm64Disassembler(disassembleMode);
		}

		public static CapstoneArmDisassembler CreateArmDisassembler(ArmDisassembleMode disassembleMode)
		{
			return new CapstoneArmDisassembler(disassembleMode);
		}

		public static CapstoneM68KDisassembler CreateM68KDisassembler(M68KDisassembleMode disassembleMode)
		{
			return new CapstoneM68KDisassembler(disassembleMode);
		}

		public static CapstoneMipsDisassembler CreateMipsDisassembler(MipsDisassembleMode disassembleMode)
		{
			return new CapstoneMipsDisassembler(disassembleMode);
		}

		public static CapstonePowerPcDisassembler CreatePowerPcDisassembler(PowerPcDisassembleMode disassembleMode)
		{
			return new CapstonePowerPcDisassembler(disassembleMode);
		}

		public static CapstoneX86Disassembler CreateX86Disassembler(X86DisassembleMode disassembleMode)
		{
			return new CapstoneX86Disassembler(disassembleMode);
		}

		public static CapstoneXCoreDisassembler CreateXCoreDisassembler(XCoreDisassembleMode disassembleMode)
		{
			return new CapstoneXCoreDisassembler(disassembleMode);
		}

		internal static void ThrowIfDietModeIsEnabled()
		{
			if (IsDietModeEnabled)
			{
				throw new NotSupportedException("An operation is not supported when Diet Mode is enabled.");
			}
		}

		internal static void ThrowIfValueIsNullReference<T>(string name, T value) where T : class
		{
			if (value == null)
			{
				throw new ArgumentNullException(name, "A value cannot be a null reference.");
			}
		}

		public abstract void Dispose();
	}
	public abstract class CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup, TInstructionGroupId, TInstructionId, TRegister, TRegisterId> : CapstoneDisassembler where TDisassembleMode : Enum where TInstruction : Instruction<TInstruction, TInstructionDetail, TDisassembleMode, TInstructionGroup, TInstructionGroupId, TInstructionId, TRegister, TRegisterId> where TInstructionDetail : InstructionDetail<TInstructionDetail, TDisassembleMode, TInstructionGroup, TInstructionGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> where TInstructionGroup : InstructionGroup<TInstructionGroupId> where TInstructionGroupId : Enum where TInstructionId : Enum where TRegister : Register<TRegisterId> where TRegisterId : Enum
	{
		[CompilerGenerated]
		internal sealed class _003C_003Ec__DisplayClass42_0
		{
			public CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup, TInstructionGroupId, TInstructionId, TRegister, TRegisterId> _003C_003E4__this;

			public byte[] binaryCode;

			public int binaryCodeOffset;

			internal IntPtr _003CIterate_003Eg__OnNativeSkipDataCallback_007C0(IntPtr cPBinaryCode, IntPtr cBinaryCodeSize, IntPtr cDataOffset, IntPtr pState)
			{
				return new IntPtr(_003C_003E4__this.SkipDataCallback(binaryCode, binaryCodeOffset));
			}
		}

		[CompilerGenerated]
		internal sealed class _003CIterate_003Ed__42 : IEnumerable<TInstruction>, IEnumerable, IEnumerator<TInstruction>, IDisposable, IEnumerator
		{
			internal int _003C_003E1__state;

			internal TInstruction _003C_003E2__current;

			internal int _003C_003El__initialThreadId;

			public CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup, TInstructionGroupId, TInstructionId, TRegister, TRegisterId> _003C_003E4__this;

			internal byte[] binaryCode;

			public byte[] _003C_003E3__binaryCode;

			internal _003C_003Ec__DisplayClass42_0 _003C_003E8__1;

			internal long startingAddress;

			public long _003C_003E3__startingAddress;

			internal _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 _003Ccallback_003E5__2;

			internal _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _003ChInstruction_003E5__3;

			TInstruction IEnumerator<TInstruction>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CIterate_003Ed__42(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = _003C_003E1__state;
				if ((uint)(num - -4) <= 1u || num == 1)
				{
					try
					{
						if (num == -4 || num == 1)
						{
							try
							{
							}
							finally
							{
								_003C_003Em__Finally2();
							}
						}
					}
					finally
					{
						_003C_003Em__Finally1();
					}
				}
			}

			internal bool MoveNext()
			{
				try
				{
					int num = _003C_003E1__state;
					CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup, TInstructionGroupId, TInstructionId, TRegister, TRegisterId> capstoneDisassembler = _003C_003E4__this;
					switch (num)
					{
					default:
						return false;
					case 0:
						_003C_003E1__state = -1;
						_003C_003E8__1 = new _003C_003Ec__DisplayClass42_0();
						_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
						_003C_003E8__1.binaryCode = binaryCode;
						CapstoneDisassembler.ThrowIfValueIsNullReference("binaryCode", _003C_003E8__1.binaryCode);
						_003C_003E8__1.binaryCodeOffset = 0;
						_003Ccallback_003E5__2 = null;
						if (capstoneDisassembler.EnableSkipDataMode)
						{
							if (capstoneDisassembler._skipDataCallback != null)
							{
								_003Ccallback_003E5__2 = _003C_003E8__1._003CIterate_003Eg__OnNativeSkipDataCallback_007C0;
							}
							_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A = default(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
							_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.Callback = _003Ccallback_003E5__2;
							_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.InstructionMnemonic = capstoneDisassembler._skipDataInstructionMnemonic;
							_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.State = IntPtr.Zero;
							_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A(capstoneDisassembler._handle, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
						}
						_003C_003E1__state = -3;
						_003ChInstruction_003E5__3 = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020(capstoneDisassembler._handle);
						_003C_003E1__state = -4;
						break;
					case 1:
						_003C_003E1__state = -4;
						break;
					}
					if (_003C_003E8__1.binaryCodeOffset >= _003C_003E8__1.binaryCode.Length)
					{
						_003C_003Em__Finally2();
						_003ChInstruction_003E5__3 = null;
						_003C_003Em__Finally1();
						return false;
					}
					if (_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A(capstoneDisassembler._handle, _003C_003E8__1.binaryCode, ref _003C_003E8__1.binaryCodeOffset, ref startingAddress, _003ChInstruction_003E5__3))
					{
						TInstruction val = _003C_003E2__current = capstoneDisassembler.CreateInstruction(_003ChInstruction_003E5__3);
						_003C_003E1__state = 1;
						return true;
					}
					bool result = false;
					_003C_003Em__Finally2();
					_003C_003Em__Finally1();
					return result;
				}
				catch
				{
					//try-fault
					System_002EIDisposable_002EDispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			internal void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup, TInstructionGroupId, TInstructionId, TRegister, TRegisterId> capstoneDisassembler = _003C_003E4__this;
				if (_003Ccallback_003E5__2 != null)
				{
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A = default(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.Callback = null;
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.InstructionMnemonic = capstoneDisassembler._skipDataInstructionMnemonic;
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.State = IntPtr.Zero;
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A(capstoneDisassembler._handle, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
				}
			}

			internal void _003C_003Em__Finally2()
			{
				_003C_003E1__state = -3;
				if (_003ChInstruction_003E5__3 != null)
				{
					((IDisposable)_003ChInstruction_003E5__3).Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<TInstruction> IEnumerable<TInstruction>.GetEnumerator()
			{
				_003CIterate_003Ed__42 _003CIterate_003Ed__;
				if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Thread.CurrentThread.ManagedThreadId)
				{
					_003C_003E1__state = 0;
					_003CIterate_003Ed__ = this;
				}
				else
				{
					_003CIterate_003Ed__ = new _003CIterate_003Ed__42(0);
					_003CIterate_003Ed__._003C_003E4__this = _003C_003E4__this;
				}
				_003CIterate_003Ed__.binaryCode = _003C_003E3__binaryCode;
				_003CIterate_003Ed__.startingAddress = _003C_003E3__startingAddress;
				return _003CIterate_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return System_002ECollections_002EGeneric_002EIEnumerable_003CTInstruction_003E_002EGetEnumerator();
			}
		}

		internal readonly DisassembleArchitecture _disassembleArchitecture;

		internal TDisassembleMode _disassembleMode;

		internal DisassembleSyntax _disassembleSyntax;

		internal bool _enableInstructionDetails;

		internal bool _enableSkipDataMode;

		internal readonly _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 _handle;

		internal NativeDisassembleMode _nativeDisassembleMode;

		internal Func<byte[], long, long> _skipDataCallback;

		internal string _skipDataInstructionMnemonic;

		public override DisassembleArchitecture DisassembleArchitecture => _disassembleArchitecture;

		public TDisassembleMode DisassembleMode
		{
			get
			{
				return _disassembleMode;
			}
			set
			{
				NativeDisassembleMode nativeDisassembleMode = (NativeDisassembleMode)Convert.ToInt32(value);
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020(_handle, nativeDisassembleMode);
				_disassembleMode = value;
				_nativeDisassembleMode = nativeDisassembleMode;
			}
		}

		public DisassembleSyntax DisassembleSyntax
		{
			get
			{
				return _disassembleSyntax;
			}
			set
			{
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A(_handle, NativeDisassemblerOptionType.SetSyntax, (NativeDisassemblerOptionValue)value);
				_disassembleSyntax = value;
			}
		}

		public override bool EnableInstructionDetails
		{
			get
			{
				return _enableInstructionDetails;
			}
			set
			{
				NativeDisassemblerOptionValue _0020_0020 = value ? NativeDisassemblerOptionValue.Enable : NativeDisassemblerOptionValue.Disable;
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A(_handle, NativeDisassemblerOptionType.SetInstructionDetails, _0020_0020);
				_enableInstructionDetails = value;
			}
		}

		public override bool EnableSkipDataMode
		{
			get
			{
				return _enableSkipDataMode;
			}
			set
			{
				NativeDisassemblerOptionValue _0020_0020 = value ? NativeDisassemblerOptionValue.Enable : NativeDisassemblerOptionValue.Disable;
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A(_handle, NativeDisassemblerOptionType.SetSkipData, _0020_0020);
				_enableSkipDataMode = value;
			}
		}

		internal override _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 Handle => _handle;

		internal override NativeDisassembleMode NativeDisassembleMode => _nativeDisassembleMode;

		public Func<byte[], long, long> SkipDataCallback
		{
			get
			{
				return _skipDataCallback;
			}
			set
			{
				ThrowIfDisassemblerIsDisposed();
				_skipDataCallback = value;
			}
		}

		public override string SkipDataInstructionMnemonic
		{
			get
			{
				return _skipDataInstructionMnemonic;
			}
			set
			{
				ThrowIfDisassemblerIsDisposed();
				CapstoneDisassembler.ThrowIfValueIsNullReference("SkipDataInstructionMnemonic", value);
				_skipDataInstructionMnemonic = value;
			}
		}

		internal protected CapstoneDisassembler(DisassembleArchitecture disassembleArchitecture, TDisassembleMode disassembleMode)
		{
			_disassembleArchitecture = disassembleArchitecture;
			_disassembleMode = disassembleMode;
			_disassembleSyntax = DisassembleSyntax.Intel;
			_skipDataInstructionMnemonic = ".byte";
			_nativeDisassembleMode = _003C_002Ector_003Eg__CreateNativeDisassembleMode_007C33_0(this);
			_handle = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A(_disassembleArchitecture, _nativeDisassembleMode);
		}

		internal abstract TInstruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction);

		public TInstruction[] Disassemble(byte[] binaryCode)
		{
			return Disassemble(binaryCode, 4096L);
		}

		public TInstruction[] Disassemble(byte[] binaryCode, long startingAddress)
		{
			return Disassemble(binaryCode, startingAddress, 0);
		}

		public TInstruction[] Disassemble(byte[] binaryCode, long startingAddress, int count)
		{
			IEnumerable<TInstruction> source = Iterate(binaryCode, startingAddress);
			if (count != 0)
			{
				source = source.Skip(0).Take(count);
			}
			return source.ToArray();
		}

		public override void Dispose()
		{
			_handle.Dispose();
		}

		public string GetInstructionGroupName(TInstructionGroupId instructionGroupId)
		{
			ThrowIfDisassemblerIsDisposed();
			CapstoneDisassembler.ThrowIfDietModeIsEnabled();
			int _0020_000A = Convert.ToInt32(instructionGroupId);
			string text = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(_handle, _0020_000A);
			if (text == null)
			{
				throw new ArgumentException("An instruction group unique identifier is invalid.", "instructionGroupId");
			}
			return text;
		}

		public string GetRegisterName(TRegisterId registerId)
		{
			ThrowIfDisassemblerIsDisposed();
			CapstoneDisassembler.ThrowIfDietModeIsEnabled();
			int _0020_000A = Convert.ToInt32(registerId);
			string text = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(_handle, _0020_000A);
			if (text == null)
			{
				throw new ArgumentException("A register unique identifier is invalid.", "registerId");
			}
			return text;
		}

		public IEnumerable<TInstruction> Iterate(byte[] binaryCode)
		{
			return Iterate(binaryCode, 4096L);
		}

		public IEnumerable<TInstruction> Iterate(byte[] binaryCode, long startingAddress)
		{
			CapstoneDisassembler.ThrowIfValueIsNullReference("binaryCode", binaryCode);
			int binaryCodeOffset = 0;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 callback = null;
			if (EnableSkipDataMode)
			{
				if (_skipDataCallback != null)
				{
					_003C_003Ec__DisplayClass42_0 @object;
					callback = @object._003CIterate_003Eg__OnNativeSkipDataCallback_007C0;
				}
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A = default(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.Callback = callback;
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.InstructionMnemonic = _skipDataInstructionMnemonic;
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A.State = IntPtr.Zero;
				_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A(_handle, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
			}
			try
			{
				using (_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020(_handle))
				{
					while (binaryCodeOffset < binaryCode.Length)
					{
						if (!_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A(_handle, binaryCode, ref binaryCodeOffset, ref startingAddress, hInstruction))
						{
							yield break;
						}
						yield return CreateInstruction(hInstruction);
					}
				}
			}
			finally
			{
				if (callback != null)
				{
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A2 = default(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A2.Callback = null;
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A2.InstructionMnemonic = _skipDataInstructionMnemonic;
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A2.State = IntPtr.Zero;
					_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A(_handle, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A2);
				}
			}
		}

		public void ResetInstructionMnemonic(TInstructionId instructionId)
		{
			int instructionId2 = Convert.ToInt32(instructionId);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 = default(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020.InstructionId = instructionId2;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020.InstructionMnemonic = null;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_00202 = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020(_handle, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_00202);
		}

		public void SetInstructionMnemonic(TInstructionId instructionId, string instructionMnemonic)
		{
			CapstoneDisassembler.ThrowIfValueIsNullReference("instructionMnemonic", instructionMnemonic);
			int instructionId2 = Convert.ToInt32(instructionId);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 = default(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020.InstructionId = instructionId2;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020.InstructionMnemonic = instructionMnemonic;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_00202 = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020;
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020(_handle, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_00202);
		}

		internal void ThrowIfDisassemblerIsDisposed()
		{
			if (_handle.IsClosed)
			{
				throw new ObjectDisposedException("CapstoneDisassembler", "A disassembler is disposed.");
			}
		}

		[CompilerGenerated]
		internal static NativeDisassembleMode _003C_002Ector_003Eg__CreateNativeDisassembleMode_007C33_0(CapstoneDisassembler<TDisassembleMode, TInstruction, TInstructionDetail, TInstructionGroup, TInstructionGroupId, TInstructionId, TRegister, TRegisterId> @this)
		{
			return (NativeDisassembleMode)Convert.ToInt32(@this._disassembleMode);
		}
	}
}
