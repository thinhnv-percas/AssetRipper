using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.MoldSystem.Visual.EditMode
{
	[Token(Token = "0x20002B3")]
	public class MoldVisualCreator_Editor : MoldVisualCreator
	{
		[Inject(false)]
		[Token(Token = "0x4000856")]
		[FieldOffset(Offset = "0x60")]
		private EditorHistory _history;

		[Inject(false)]
		[Token(Token = "0x4000857")]
		[FieldOffset(Offset = "0x68")]
		private MoldLinkVisualController _linkVisual;

		[Token(Token = "0x6000C11")]
		[Address(RVA = "0x3ECF62C", Offset = "0x3ECF62C", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv60 = UnityEngine.GameObject::AddComponent(go);\n\tgoto L_0037;\n\tv72 = UnityEngine.GameObject::AddComponent(go);\n\tgoto L_0057;\n\tv72._linkVisual = this._linkVisual;\n\treturn;\nL_0037:\n\tv60._entity = entity;\n\tv123 = UnityEngine.Component::GetComponent(v60);\n\tv60._entityMono = v123;\n\tv60._history = this._history;\nL_0057:\n\tv72._entity = entity;\n\tv145 = UnityEngine.Component::GetComponent(v72);\n\tv72._entityMono = v145;\n\tv72._history = this._history;\n")]
		protected override void OnMoldSpawned(GameObject go, Entity entity)
		{
			MoldEntityActions moldEntityActions = go.AddComponent<MoldEntityActions>();
			moldEntityActions._entity = entity;
			EntityMono component = moldEntityActions.GetComponent<EntityMono>();
			moldEntityActions._entityMono = component;
			moldEntityActions._history = _history;
			LinkedMoldEntityActions linkedMoldEntityActions = go.AddComponent<LinkedMoldEntityActions>();
			linkedMoldEntityActions._entity = entity;
			EntityMono component2 = linkedMoldEntityActions.GetComponent<EntityMono>();
			linkedMoldEntityActions._entityMono = component2;
			linkedMoldEntityActions._history = _history;
			linkedMoldEntityActions._linkVisual = _linkVisual;
		}

		[Token(Token = "0x6000C12")]
		[Address(RVA = "0x3ECF78C", Offset = "0x3ECF78C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv51 = UnityEngine.Object::op_Inequality(go, 0);\n\tv58 = ~v51;\n\tif (v58) goto L_0042;\n\tgoto L_0027;\nL_0027:\n\tUnityEngine.Object::DestroyImmediate(go);\n\treturn;\nL_0042:\n\treturn;\n")]
		protected override void DestroyMoldGo(GameObject go)
		{
			if (go != null)
			{
				Object.DestroyImmediate(go);
			}
		}

		[Token(Token = "0x6000C13")]
		[Address(RVA = "0x3ECF85C", Offset = "0x3ECF85C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldVisualCreator_Editor()
		{
		}
	}
}
