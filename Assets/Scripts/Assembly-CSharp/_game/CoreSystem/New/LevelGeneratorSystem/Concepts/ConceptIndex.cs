using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Concepts
{
	[Token(Token = "0x200039D")]
	public sealed class ConceptIndex
	{
		[CompilerGenerated]
		[Token(Token = "0x200039E")]
		private sealed class _003CListAll_003Ed__5 : IEnumerable<ConceptSummary>, IEnumerable, IEnumerator<ConceptSummary>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000B0C")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000B0D")]
			[FieldOffset(Offset = "0x18")]
			private ConceptSummary _003C_003E2__current;

			[Token(Token = "0x4000B0E")]
			[FieldOffset(Offset = "0x30")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000B0F")]
			[FieldOffset(Offset = "0x38")]
			public ConceptIndex _003C_003E4__this;

			[Token(Token = "0x4000B10")]
			[FieldOffset(Offset = "0x40")]
			private List<ConceptSO>.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x17000135")]
			ConceptSummary IEnumerator<ConceptSummary>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000F32")]
				[Address(RVA = "0x3C98EB4", Offset = "0x3C98EB4", Length = "0x14")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConceptIndex._003CListAll_003Ed__5::get_Current");
					return default;
				}
			}

			[Token(Token = "0x17000136")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000F34")]
				[Address(RVA = "0x3C98F08", Offset = "0x3C98F08", Length = "0x70")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConceptIndex._003CListAll_003Ed__5::get_Current");
					return default;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000F2E")]
			[Address(RVA = "0x3C98984", Offset = "0x3C98984", Length = "0x38")]
			public _003CListAll_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000F2F")]
			[Address(RVA = "0x3C98A4C", Offset = "0x3C98A4C", Length = "0x78")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConceptIndex._003CListAll_003Ed__5::Dispose");
			}

			[Token(Token = "0x6000F30")]
			[Address(RVA = "0x3C98AC4", Offset = "0x3C98AC4", Length = "0x2B0")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConceptIndex._003CListAll_003Ed__5::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000F31")]
			[Address(RVA = "0x3C98E58", Offset = "0x3C98E58", Length = "0x5C")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConceptIndex._003CListAll_003Ed__5::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000F33")]
			[Address(RVA = "0x3C98EC8", Offset = "0x3C98EC8", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000F35")]
			[Address(RVA = "0x3C98F78", Offset = "0x3C98F78", Length = "0xB4")]
			IEnumerator<ConceptSummary> IEnumerable<ConceptSummary>.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003CListAll_003Ed__5 _003CListAll_003Ed__6 = (_003CListAll_003Ed__5)FormatterServices.GetUninitializedObject(typeof(_003CListAll_003Ed__5));
				_003CListAll_003Ed__6._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CListAll_003Ed__6._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CListAll_003Ed__6._003C_003E4__this = _003C_003E4__this;
				return _003CListAll_003Ed__6;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000F36")]
			[Address(RVA = "0x3C9902C", Offset = "0x3C9902C", Length = "0x4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ConceptSummary>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x4000B0A")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<ConceptSO> _ordered;

		[Token(Token = "0x4000B0B")]
		[FieldOffset(Offset = "0x18")]
		private readonly Dictionary<string, ConceptSO> _byId;

		[Token(Token = "0x17000134")]
		public int Count
		{
			[Token(Token = "0x6000F2B")]
			[Address(RVA = "0x3C988B0", Offset = "0x3C988B0", Length = "0x4C")]
			get
			{
				List<ConceptSO> ordered = _ordered;
				return ordered.Count;
			}
		}

		[Token(Token = "0x6000F2A")]
		[Address(RVA = "0x3C983E8", Offset = "0x3C983E8", Length = "0x4C8")]
		public ConceptIndex(IEnumerable<ConceptSO> concepts)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConceptIndex::.ctor");
		}

		[IteratorStateMachine(typeof(_003CListAll_003Ed__5))]
		[Token(Token = "0x6000F2C")]
		[Address(RVA = "0x3C988FC", Offset = "0x3C988FC", Length = "0x88")]
		public IEnumerable<ConceptSummary> ListAll()
		{
			_003CListAll_003Ed__5 _003CListAll_003Ed__6 = new _003CListAll_003Ed__5(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CListAll_003Ed__6._003C_003El__initialThreadId = currentManagedThreadId;
			_003CListAll_003Ed__6._003C_003E4__this = this;
			return _003CListAll_003Ed__6;
		}

		[Token(Token = "0x6000F2D")]
		[Address(RVA = "0x3C989BC", Offset = "0x3C989BC", Length = "0x90")]
		public bool TryGet(string id, out ConceptSO concept)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConceptIndex::TryGet");
			concept = default;
			return default;
		}
	}
}
