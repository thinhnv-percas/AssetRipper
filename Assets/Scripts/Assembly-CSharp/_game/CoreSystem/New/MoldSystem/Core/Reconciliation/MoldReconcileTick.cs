using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E2")]
	public class MoldReconcileTick : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x40008DC")]
		[FieldOffset(Offset = "0x20")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40008DD")]
		[FieldOffset(Offset = "0x28")]
		private MoldLinkedHandler _linkedHandler;

		[Inject(false)]
		[Token(Token = "0x40008DE")]
		[FieldOffset(Offset = "0x30")]
		private MoldGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x40008DF")]
		[FieldOffset(Offset = "0x38")]
		private MoldVisualStateInitSystem _initSystem;

		[Inject(false)]
		[Token(Token = "0x40008E0")]
		[FieldOffset(Offset = "0x40")]
		private MoldVisualCmdProcessor _cmdProcessor;

		[Token(Token = "0x40008E1")]
		[FieldOffset(Offset = "0x48")]
		private MoldReconcileCore _core;

		[Token(Token = "0x40008E2")]
		[FieldOffset(Offset = "0x50")]
		private bool _isConstructed;

		[Inject(false)]
		[Token(Token = "0x6000CAD")]
		[Address(RVA = "0x3EDEEFC", Offset = "0x3EDEEFC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis._isConstructed = 1;\n\treturn;\nL_001D:\n\tv53 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore();\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore::.ctor(v53, this._em, this._linkedHandler, this._gridHandler, this._cmdProcessor);\n\tthis._core = v53;\n")]
		private void Construct()
		{
			MoldReconcileCore core = new MoldReconcileCore(_em, _linkedHandler, _gridHandler, _cmdProcessor);
			_core = core;
			_isConstructed = true;
		}

		[Token(Token = "0x6000CAE")]
		[Address(RVA = "0x3EDEF94", Offset = "0x3EDEF94", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_deltaTime();\n\tv24 = this._isConstructed != 1;\n\tif (v24) goto L_0024;\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore::Tick(this._core, v13);\n\treturn;\nL_0024:\n\treturn;\n")]
		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (_isConstructed)
			{
				_core.Tick(deltaTime);
			}
		}

		[Token(Token = "0x6000CAF")]
		[Address(RVA = "0x3EDEFDC", Offset = "0x3EDEFDC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._isConstructed != 1;\n\tif (v11) goto L_0011;\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore::Tick(this._core, dt);\n\treturn;\nL_0011:\n\treturn;\n")]
		public void Tick(float dt)
		{
			if (_isConstructed)
			{
				_core.Tick(dt);
			}
		}

		[Token(Token = "0x6000CB0")]
		[Address(RVA = "0x3EDF004", Offset = "0x3EDF004", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldReconcileTick()
		{
		}
	}
}
