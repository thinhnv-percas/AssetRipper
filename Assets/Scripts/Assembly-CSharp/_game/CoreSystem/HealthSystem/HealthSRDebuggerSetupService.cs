using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using SRDebugger;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.Systems.ElephantStorage;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004DC")]
	public class HealthSRDebuggerSetupService : SRDebuggerOptionServiceBase
	{
		[Token(Token = "0x400103E")]
		[FieldOffset(Offset = "0x18")]
		private HealthController _healthController;

		[Inject(false)]
		[Token(Token = "0x6001471")]
		[Address(RVA = "0x3CF5680", Offset = "0x3CF5680", Length = "0x28")]
		private void Inject(HealthController healthController)
		{
			_healthController = healthController;
			SetupSRDebuggerActions();
		}

		[Token(Token = "0x6001472")]
		[Address(RVA = "0x3CF56A8", Offset = "0x3CF56A8", Length = "0x234")]
		private void SetupSRDebuggerActions()
		{
			Action callback = delegate
			{
				HealthController healthController = _healthController;
				HealthStorageData healthData = healthController._healthData;
				HealthConfig config = healthController._config;
				int num = healthData.CurrentHealth + 1;
				int health = ((num < config.MaxHealth) ? (healthData.CurrentHealth + 1) : config.MaxHealth);
				healthController.SetHealth(health);
				healthController.EvaluateState();
			};
			OptionDefinition option = OptionDefinition.FromMethod("Add 1 Health", callback, "5. Health System");
			AddOption(option);
			Action callback2 = delegate
			{
				_healthController.RemoveHealth();
			};
			OptionDefinition option2 = OptionDefinition.FromMethod("Remove 1 Health", callback2, "5. Health System");
			AddOption(option2);
			Action callback3 = delegate
			{
				_healthController.GrantInfiniteHealth(10f);
			};
			OptionDefinition option3 = OptionDefinition.FromMethod("Add Infinite 10s", callback3, "5. Health System");
			AddOption(option3);
			Action callback4 = delegate
			{
				_healthController.GrantInfiniteHealth(600f);
			};
			OptionDefinition option4 = OptionDefinition.FromMethod("Add Infinite 10m", callback4, "5. Health System");
			AddOption(option4);
		}

		[Token(Token = "0x6001473")]
		[Address(RVA = "0x3CF55F8", Offset = "0x3CF55F8", Length = "0x88")]
		public HealthSRDebuggerSetupService()
		{
		}
	}
}
