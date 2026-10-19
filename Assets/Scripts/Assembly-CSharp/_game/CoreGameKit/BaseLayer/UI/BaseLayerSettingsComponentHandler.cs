using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.Utils;
using UnityEngine;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000632")]
	public class BaseLayerSettingsComponentHandler : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400155D")]
		[FieldOffset(Offset = "0x20")]
		private ComponentStateHandler _componentStateHandler;

		[Token(Token = "0x400155E")]
		[FieldOffset(Offset = "0x28")]
		private BaseLayerSessionController _sessionController;

		[Token(Token = "0x400155F")]
		[FieldOffset(Offset = "0x30")]
		private bool _hasStarted;

		[Inject(false)]
		[Token(Token = "0x6001A83")]
		[Address(RVA = "0x3D5421C", Offset = "0x3D5421C", Length = "0xBC")]
		private void Construct(BaseLayerSessionController sessionController)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerSettingsComponentHandler::Construct");
		}

		[Token(Token = "0x6001A84")]
		[Address(RVA = "0x3D54488", Offset = "0x3D54488", Length = "0x94")]
		private void OnDestroy()
		{
			Action value = RefreshState;
			_sessionController.remove_OnSessionStart(value);
		}

		[Token(Token = "0x6001A85")]
		[Address(RVA = "0x3D542D8", Offset = "0x3D542D8", Length = "0x1B0")]
		private void RefreshState()
		{
			BaseLayerSettingsState flag = default(BaseLayerSettingsState);
			BaseLayerSessionController sessionController = _sessionController;
			BaseLayerSettingsState baseLayerSettingsState = (sessionController.HasStarted ? BaseLayerSettingsState.HasStarted : BaseLayerSettingsState.None);
			int num;
			if (sessionController.HasStarted)
			{
				flag = baseLayerSettingsState;
				if (!sessionController.HomeBlocked)
				{
					goto IL_00d9;
				}
				num = (int)baseLayerSettingsState;
			}
			else
			{
				bool flag2 = !sessionController.HomeBlocked;
				bool flag3 = !flag2;
				baseLayerSettingsState = default(BaseLayerSettingsState);
				num = 0;
				if (!flag3)
				{
					goto IL_00d9;
				}
			}
			goto IL_0213;
			IL_0213:
			ComponentStateHandler componentStateHandler;
			if (sessionController.WinRewardedBlocked)
			{
				componentStateHandler = _componentStateHandler;
				if (_componentStateHandler == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				int num2 = num | 4;
				flag = (BaseLayerSettingsState)num2;
				componentStateHandler = _componentStateHandler;
			}
			IEnumerable<BaseLayerSettingsComponentState> source = componentStateHandler.AllStatesOfType<BaseLayerSettingsComponentState>();
			Func<BaseLayerSettingsComponentState, bool> predicate = delegate(BaseLayerSettingsComponentState x)
			{
				int num3 = (int)(~flag);
				int num4 = (int)x.SettingsFlag & num3;
				return num4 == 0;
			};
			object obj = source.FirstOrDefault((Func<object, bool>)predicate);
			bool flag4 = obj == null;
			bool flag5 = !flag4;
			ComponentState componentState = (ComponentState)obj;
			if (!flag5)
			{
				IEnumerable<ComponentState> source2 = _componentStateHandler.AllStatesOfType<ComponentState>();
				object obj2 = ((IEnumerable<object>)source2).First();
				componentState = (ComponentState)obj2;
			}
			_componentStateHandler.ActivateState(componentState);
			return;
			IL_00d9:
			num = (int)(flag = baseLayerSettingsState | BaseLayerSettingsState.HomeAvailable);
			goto IL_0213;
		}

		[Token(Token = "0x6001A86")]
		[Address(RVA = "0x3D54524", Offset = "0x3D54524", Length = "0x8")]
		public BaseLayerSettingsComponentHandler()
		{
		}
	}
}
