using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Systems.TimeSystems.Core;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Objects;
using UnityEngine;
using Utils;
using Debug = UnityEngine.Debug;

namespace Systems.ShopSystem.Scripts.Ui.ShopGroups
{
	[Token(Token = "0x200004F")]
	public class DailyShopGroupController : ShopGroupView
	{
		[CompilerGenerated]
		[Token(Token = "0x2000050")]
		private sealed class _003CUpdateTimer_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000B4")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000B5")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000B6")]
			[FieldOffset(Offset = "0x20")]
			public DailyShopGroupController _003C_003E4__this;

			[Token(Token = "0x17000030")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000F9")]
				[Address(RVA = "0x3C6872C", Offset = "0x3C6872C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000031")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000FB")]
				[Address(RVA = "0x3C68774", Offset = "0x3C68774", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000F6")]
			[Address(RVA = "0x3C685DC", Offset = "0x3C685DC", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CUpdateTimer_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000F7")]
			[Address(RVA = "0x3C68618", Offset = "0x3C68618", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000F8")]
			[Address(RVA = "0x3C6861C", Offset = "0x3C6861C", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv58 = v39.<>4__this;\n\tv39.<>1__state = -1;\n\tv100 = Systems.TimeSystems.Core.ServerTimeUtility::GetNetworkRemainedToNextDay();\n\tv66 = v100;\n\t// 51 Box v140 @ X0_v8 (System.Object), typeof(System.TimeSpan), &v66 @ stack_-38_v3 (System.TimeSpan)\n\tv107 = System.String::Format(\"Refresh in: {0:hh\\\\:mm\\\\:ss}\", v140);\n\tUnco.Objects.UncoTMP::SetText(v58.m_timer, v107);\n\tgoto L_004C;\nL_001B:\n\tv44 = v39.<>1__state < 1;\n\tv45 = ~v44;\n\tv46 = v39.<>1__state - 1;\n\tv48 = v46 == 0;\n\tv53 = ~v48;\n\tv54 = v45 & v53;\n\tif (v54) goto L_0051;\nL_004C:\n\tv39.<>2__current = v152._1second;\n\tv39.<>1__state = 1;\nL_0051:\n\tv80 = v39.<>1__state < 2;\n\tv81 = ~v80;\n\tv89 = ~v81;\n\treturn v89;\n")]
			private bool MoveNext()
			{
				bool flag = (uint)_003C_003E1__state < 1u;
				bool flag2 = !flag;
				int num = _003C_003E1__state - 1;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					DailyShopGroupController dailyShopGroupController = _003C_003E4__this;
					_003C_003E1__state = -1;
					TimeSpan networkRemainedToNextDay = ServerTimeUtility.GetNetworkRemainedToNextDay();
					TimeSpan timeSpan = networkRemainedToNextDay;
					object arg = timeSpan;
					string text = $"Refresh in: {arg:hh\\:mm\\:ss}";
					dailyShopGroupController.m_timer.SetText(text);
					_003C_003E2__current = CoroutineUtil._1second;
					_003C_003E1__state = 1;
				}
				bool flag5 = (uint)_003C_003E1__state < 2u;
				bool flag6 = !flag5;
				return !flag6;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x3C68734", Offset = "0x3C68734", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SerializeField]
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x70")]
		private Transform m_container;

		[SerializeField]
		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x78")]
		private UncoTMP m_timer;

		[SerializeField]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x80")]
		private Sprite m_itemBg;

		[SerializeField]
		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x88")]
		private bool m_initTimer;

		[SerializeField]
		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x90")]
		private string m_groupKey;

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x3C684D0", Offset = "0x3C684D0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F0000 + 0x358;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::LogWarning(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		protected override void InnerInit()
		{
			//IL_0022: Expected O, but got I4
			int num = 187629568 + 856;
			Debug.LogWarning(num);
		}

		[IteratorStateMachine(typeof(_003CUpdateTimer_003Ed__6))]
		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x3C68564", Offset = "0x3C68564", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new Systems.ShopSystem.Scripts.Ui.ShopGroups.DailyShopGroupController+<UpdateTimer>d__6();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator UpdateTimer()
		{
			_003CUpdateTimer_003Ed__6 _003CUpdateTimer_003Ed__7 = (_003CUpdateTimer_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CUpdateTimer_003Ed__6));
			_003CUpdateTimer_003Ed__7._003C_003E1__state = 0;
			_003CUpdateTimer_003Ed__7._003C_003E4__this = this;
			return _003CUpdateTimer_003Ed__7;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x3C68608", Offset = "0x3C68608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DailyShopGroupController()
		{
		}
	}
}
