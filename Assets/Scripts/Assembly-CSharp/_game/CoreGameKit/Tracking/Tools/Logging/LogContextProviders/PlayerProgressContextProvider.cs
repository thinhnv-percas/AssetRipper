using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.Tracking.Tools.Logging.LogContextProviders
{
	[Token(Token = "0x2000596")]
	public class PlayerProgressContextProvider : ILogContextProvider
	{
		[Token(Token = "0x400133F")]
		[FieldOffset(Offset = "0x10")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x60017B2")]
		[Address(RVA = "0x3D301C0", Offset = "0x3D301C0", Length = "0x8")]
		private void Construct(ILevelProgressService levelProgressService = null)
		{
			_levelProgressService = levelProgressService;
		}

		[Token(Token = "0x60017B3")]
		[Address(RVA = "0x3D301C8", Offset = "0x3D301C8", Length = "0x1DC")]
		public string GetContext()
		{
			if (_levelProgressService == null)
			{
				return "{\"progress\": \"Not available\"}";
			}
			int currentLevelIndex = _levelProgressService.CurrentLevelIndex;
			int num = currentLevelIndex;
			int num2 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"{{\"currentLevelIndex\": {arg}}}";
		}

		[Token(Token = "0x60017B4")]
		[Address(RVA = "0x3D303A4", Offset = "0x3D303A4", Length = "0x8")]
		public PlayerProgressContextProvider()
		{
		}
	}
}
