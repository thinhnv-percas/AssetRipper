using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Conditions;
using _game.CoreSystem.New.Shared.Components;

namespace _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Core
{
	[Token(Token = "0x200043D")]
	public class MoldFillFromUnitsSystem_Headless
	{
		[Inject(false)]
		[Token(Token = "0x4000D48")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x4000D49")]
		[FieldOffset(Offset = "0x18")]
		private MoldClaimValidator _validator;

		[Inject(false)]
		[Token(Token = "0x60011A6")]
		[Address(RVA = "0x3CC2DFC", Offset = "0x3CC2DFC", Length = "0x264")]
		private void Construct()
		{
			List<IClaimCondition> list = new List<IClaimCondition>();
			ColorMatchCondition item = new ColorMatchCondition();
			list.Add(item);
			NotDataCompleteCondition item2 = new NotDataCompleteCondition();
			list.Add(item2);
			NotLinkBlockedCondition item3 = new NotLinkBlockedCondition(_em);
			list.Add(item3);
			MoldClaimValidator validator = new MoldClaimValidator(list);
			_validator = validator;
		}

		[Token(Token = "0x60011A7")]
		[Address(RVA = "0x3CBA94C", Offset = "0x3CBA94C", Length = "0x37C")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillFromUnitsSystem_Headless::Execute");
		}

		[Token(Token = "0x60011A8")]
		[Address(RVA = "0x3CC3060", Offset = "0x3CC3060", Length = "0x2AC")]
		private void AdmitToBelt(ref bool progress)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillFromUnitsSystem_Headless::AdmitToBelt");
		}

		[Token(Token = "0x60011A9")]
		[Address(RVA = "0x3CC330C", Offset = "0x3CC330C", Length = "0x20C")]
		private Entity FindBeltUnitOfColor(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillFromUnitsSystem_Headless::FindBeltUnitOfColor");
			return default;
		}

		[Token(Token = "0x60011AA")]
		[Address(RVA = "0x3CC3518", Offset = "0x3CC3518", Length = "0xA4")]
		private void FillCellComplete(Entity mold)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillFromUnitsSystem_Headless::FillCellComplete");
		}

		[Token(Token = "0x60011AB")]
		[Address(RVA = "0x3CC2D54", Offset = "0x3CC2D54", Length = "0x8")]
		public MoldFillFromUnitsSystem_Headless()
		{
		}
	}
}
