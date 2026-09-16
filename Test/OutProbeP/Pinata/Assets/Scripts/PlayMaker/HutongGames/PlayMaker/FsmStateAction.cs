using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000072")]
	public abstract class FsmStateAction : IFsmStateAction
	{
		[Token(Token = "0x40002E4")]
		public static Color ActiveHighlightColor;

		[Token(Token = "0x40002E5")]
		public static bool Repaint;

		[Token(Token = "0x40002E6")]
		[FieldOffset(Offset = "0x10")]
		private string name;

		[Token(Token = "0x40002E7")]
		[FieldOffset(Offset = "0x18")]
		private bool enabled;

		[Token(Token = "0x40002E8")]
		[FieldOffset(Offset = "0x19")]
		private bool isOpen;

		[Token(Token = "0x40002E9")]
		[FieldOffset(Offset = "0x1A")]
		internal bool active;

		[Token(Token = "0x40002EA")]
		[FieldOffset(Offset = "0x1B")]
		internal bool finished;

		[Token(Token = "0x40002EB")]
		[FieldOffset(Offset = "0x1C")]
		private bool autoName;

		[Token(Token = "0x40002EC")]
		[FieldOffset(Offset = "0x20")]
		private GameObject owner;

		[NonSerialized]
		[Token(Token = "0x40002ED")]
		[FieldOffset(Offset = "0x28")]
		private FsmState fsmState;

		[NonSerialized]
		[Token(Token = "0x40002EE")]
		[FieldOffset(Offset = "0x30")]
		private Fsm fsm;

		[NonSerialized]
		[Token(Token = "0x40002EF")]
		[FieldOffset(Offset = "0x38")]
		private PlayMakerFSM fsmComponent;

		[CompilerGenerated]
		[Token(Token = "0x40002F1")]
		[FieldOffset(Offset = "0x48")]
		internal bool _003CEntered_003Ek__BackingField;

		[Token(Token = "0x170001A5")]
		public string Name
		{
			[Token(Token = "0x60005A3")]
			[Address(RVA = "0xCB5F00", Offset = "0xCB5F00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[Token(Token = "0x60005A4")]
			[Address(RVA = "0xCB5F08", Offset = "0xCB5F08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.name = value;\n\treturn;\n")]
			set
			{
				Name = value;
			}
		}

		[Token(Token = "0x170001A6")]
		public string DisplayName
		{
			[CompilerGenerated]
			[Token(Token = "0x60005A5")]
			[Address(RVA = "0xCB5F10", Offset = "0xCB5F10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<DisplayName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DisplayName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60005A6")]
			[Address(RVA = "0xCB5F18", Offset = "0xCB5F18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<DisplayName>k__BackingField = value;\n\treturn;\n")]
			set
			{
				DisplayName = value;
			}
		}

		[Token(Token = "0x170001A7")]
		public Fsm Fsm
		{
			[Token(Token = "0x60005A7")]
			[Address(RVA = "0xCB5F20", Offset = "0xCB5F20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fsm;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Fsm;
			}
			[Token(Token = "0x60005A8")]
			[Address(RVA = "0xCB5F28", Offset = "0xCB5F28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fsm = value;\n\treturn;\n")]
			set
			{
				Fsm = value;
			}
		}

		[Token(Token = "0x170001A8")]
		public GameObject Owner
		{
			[Token(Token = "0x60005A9")]
			[Address(RVA = "0xCB5F30", Offset = "0xCB5F30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.owner;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Owner;
			}
			[Token(Token = "0x60005AA")]
			[Address(RVA = "0xCB5F38", Offset = "0xCB5F38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.owner = value;\n\treturn;\n")]
			set
			{
				Owner = value;
			}
		}

		[Token(Token = "0x170001A9")]
		public FsmState State
		{
			[Token(Token = "0x60005AB")]
			[Address(RVA = "0xCB5F40", Offset = "0xCB5F40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fsmState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return State;
			}
			[Token(Token = "0x60005AC")]
			[Address(RVA = "0xCB5F48", Offset = "0xCB5F48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fsmState = value;\n\treturn;\n")]
			set
			{
				State = value;
			}
		}

		[Token(Token = "0x170001AA")]
		public bool Enabled
		{
			[Token(Token = "0x60005AD")]
			[Address(RVA = "0xCB5F50", Offset = "0xCB5F50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.enabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Enabled;
			}
			[Token(Token = "0x60005AE")]
			[Address(RVA = "0xCB5F58", Offset = "0xCB5F58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.enabled = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				enabled = value;
			}
		}

		[Token(Token = "0x170001AB")]
		public bool IsOpen
		{
			[Token(Token = "0x60005AF")]
			[Address(RVA = "0xCB5F64", Offset = "0xCB5F64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isOpen;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsOpen;
			}
			[Token(Token = "0x60005B0")]
			[Address(RVA = "0xCB5F6C", Offset = "0xCB5F6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isOpen = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				isOpen = value;
			}
		}

		[Token(Token = "0x170001AC")]
		public bool IsAutoNamed
		{
			[Token(Token = "0x60005B1")]
			[Address(RVA = "0xCB5F78", Offset = "0xCB5F78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.autoName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsAutoNamed;
			}
			[Token(Token = "0x60005B2")]
			[Address(RVA = "0xCB5F80", Offset = "0xCB5F80", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.autoName = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				autoName = value;
			}
		}

		[Token(Token = "0x170001AD")]
		public bool Entered
		{
			[CompilerGenerated]
			[Token(Token = "0x60005B3")]
			[Address(RVA = "0xCB5F8C", Offset = "0xCB5F8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Entered>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Entered;
			}
			[CompilerGenerated]
			[Token(Token = "0x60005B4")]
			[Address(RVA = "0xCB5F94", Offset = "0xCB5F94", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Entered>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CEntered_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x170001AE")]
		public bool Finished
		{
			[Token(Token = "0x60005B5")]
			[Address(RVA = "0xCB5FA0", Offset = "0xCB5FA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.finished;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Finished;
			}
			[Token(Token = "0x60005B6")]
			[Address(RVA = "0xCB3A34", Offset = "0xCB3A34", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = value == 0;\n\tif (v2) goto L_0005;\n\tthis.active = 0;\nL_0005:\n\tthis.finished = value;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value)
				{
					active = false;
				}
				finished = value;
			}
		}

		[Token(Token = "0x170001AF")]
		public bool Active
		{
			[Token(Token = "0x60005B7")]
			[Address(RVA = "0xCB5FA8", Offset = "0xCB5FA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.active;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Active;
			}
			[Token(Token = "0x60005B8")]
			[Address(RVA = "0xCB5FB0", Offset = "0xCB5FB0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.active = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				active = value;
			}
		}

		[Token(Token = "0x6000574")]
		[Address(RVA = "0xCB57FC", Offset = "0xCB57FC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fsmState = state;\n\tv13 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tthis.fsm = v13;\n\tv20 = HutongGames.PlayMaker.Fsm::get_GameObject(v13);\n\tthis.owner = v20;\n\tv50 = HutongGames.PlayMaker.Fsm::get_FsmComponent(this.fsm);\n\tthis.fsmComponent = v50;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Init(FsmState state)
		{
			State = state;
			Fsm fsm = (Fsm = state.Fsm);
			GameObject gameObject = fsm.GameObject;
			Owner = gameObject;
			PlayMakerFSM playMakerFSM = Fsm.FsmComponent;
			fsmComponent = playMakerFSM;
		}

		[Token(Token = "0x6000575")]
		[Address(RVA = "0xCB585C", Offset = "0xCB585C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void InitEditor(Fsm fsmOwner)
		{
		}

		[Token(Token = "0x6000576")]
		[Address(RVA = "0xCB5860", Offset = "0xCB5860", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Reset()
		{
		}

		[Token(Token = "0x6000577")]
		[Address(RVA = "0xCB5864", Offset = "0xCB5864", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnPreprocess()
		{
		}

		[Token(Token = "0x6000578")]
		[Address(RVA = "0xCB5868", Offset = "0xCB5868", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Awake()
		{
		}

		[Token(Token = "0x6000579")]
		[Address(RVA = "0xCB586C", Offset = "0xCB586C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool Event(FsmEvent fsmEvent)
		{
			return false;
		}

		[Token(Token = "0x600057A")]
		[Address(RVA = "0xCB5874", Offset = "0xCB5874", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = ~this.finished;\n\tif (v3) goto L_0007;\n\treturn;\nL_0007:\n\tthis.active = 0x100;\n\tHutongGames.PlayMaker.FsmState::FinishAction(this.fsmState, this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Finish()
		{
			if (!Finished)
			{
				active = false;
				finished = true;
				State.FinishAction(this);
			}
		}

		[Token(Token = "0x600057B")]
		[Address(RVA = "0xCB58A8", Offset = "0xCB58A8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv22 = *([1ED6370]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, routine, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023653]) = v41;\nL_0023:\n\treturnVal1 = UnityEngine.MonoBehaviour::StartCoroutine(this.fsmComponent, \"DoCoroutine\", routine);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Coroutine StartCoroutine(IEnumerator routine)
		{
			return fsmComponent.StartCoroutine("DoCoroutine", routine);
		}

		[Token(Token = "0x600057C")]
		[Address(RVA = "0xCB5914", Offset = "0xCB5914", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::StopCoroutine(this.fsmComponent, routine);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StopCoroutine(Coroutine routine)
		{
			fsmComponent.StopCoroutine(routine);
		}

		[Token(Token = "0x600057D")]
		[Address(RVA = "0xCB5930", Offset = "0xCB5930", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnEnter()
		{
		}

		[Token(Token = "0x600057E")]
		[Address(RVA = "0xCB5934", Offset = "0xCB5934", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnFixedUpdate()
		{
		}

		[Token(Token = "0x600057F")]
		[Address(RVA = "0xCB5938", Offset = "0xCB5938", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnUpdate()
		{
		}

		[Token(Token = "0x6000580")]
		[Address(RVA = "0xCB593C", Offset = "0xCB593C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnGUI()
		{
		}

		[Token(Token = "0x6000581")]
		[Address(RVA = "0xCB5940", Offset = "0xCB5940", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnLateUpdate()
		{
		}

		[Token(Token = "0x6000582")]
		[Address(RVA = "0xCB5944", Offset = "0xCB5944", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnExit()
		{
		}

		[Token(Token = "0x6000583")]
		[Address(RVA = "0xCB5948", Offset = "0xCB5948", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnDrawActionGizmos()
		{
		}

		[Token(Token = "0x6000584")]
		[Address(RVA = "0xCB594C", Offset = "0xCB594C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnDrawActionGizmosSelected()
		{
		}

		[Token(Token = "0x6000585")]
		[Address(RVA = "0xCB5950", Offset = "0xCB5950", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual string AutoName()
		{
			return null;
		}

		[Token(Token = "0x6000586")]
		[Address(RVA = "0xCB5958", Offset = "0xCB5958", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnActionTargetInvoked(object targetObject)
		{
		}

		[Token(Token = "0x6000587")]
		[Address(RVA = "0xCB595C", Offset = "0xCB595C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual float GetProgress()
		{
			return 0f;
		}

		[Token(Token = "0x6000588")]
		[Address(RVA = "0xCB5964", Offset = "0xCB5964", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoCollisionEnter(Collision collisionInfo)
		{
		}

		[Token(Token = "0x6000589")]
		[Address(RVA = "0xCB5968", Offset = "0xCB5968", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoCollisionStay(Collision collisionInfo)
		{
		}

		[Token(Token = "0x600058A")]
		[Address(RVA = "0xCB596C", Offset = "0xCB596C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoCollisionExit(Collision collisionInfo)
		{
		}

		[Token(Token = "0x600058B")]
		[Address(RVA = "0xCB5970", Offset = "0xCB5970", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoTriggerEnter(Collider other)
		{
		}

		[Token(Token = "0x600058C")]
		[Address(RVA = "0xCB5974", Offset = "0xCB5974", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoTriggerStay(Collider other)
		{
		}

		[Token(Token = "0x600058D")]
		[Address(RVA = "0xCB5978", Offset = "0xCB5978", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoTriggerExit(Collider other)
		{
		}

		[Token(Token = "0x600058E")]
		[Address(RVA = "0xCB597C", Offset = "0xCB597C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoParticleCollision(GameObject other)
		{
		}

		[Token(Token = "0x600058F")]
		[Address(RVA = "0xCB5980", Offset = "0xCB5980", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoCollisionEnter2D(Collision2D collisionInfo)
		{
		}

		[Token(Token = "0x6000590")]
		[Address(RVA = "0xCB5984", Offset = "0xCB5984", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoCollisionStay2D(Collision2D collisionInfo)
		{
		}

		[Token(Token = "0x6000591")]
		[Address(RVA = "0xCB5988", Offset = "0xCB5988", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoCollisionExit2D(Collision2D collisionInfo)
		{
		}

		[Token(Token = "0x6000592")]
		[Address(RVA = "0xCB598C", Offset = "0xCB598C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoTriggerEnter2D(Collider2D other)
		{
		}

		[Token(Token = "0x6000593")]
		[Address(RVA = "0xCB5990", Offset = "0xCB5990", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoTriggerStay2D(Collider2D other)
		{
		}

		[Token(Token = "0x6000594")]
		[Address(RVA = "0xCB5994", Offset = "0xCB5994", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoTriggerExit2D(Collider2D other)
		{
		}

		[Token(Token = "0x6000595")]
		[Address(RVA = "0xCB5998", Offset = "0xCB5998", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoControllerColliderHit(ControllerColliderHit collider)
		{
		}

		[Token(Token = "0x6000596")]
		[Address(RVA = "0xCB599C", Offset = "0xCB599C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoJointBreak(float force)
		{
		}

		[Token(Token = "0x6000597")]
		[Address(RVA = "0xCB59A0", Offset = "0xCB59A0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoJointBreak2D(Joint2D joint)
		{
		}

		[Token(Token = "0x6000598")]
		[Address(RVA = "0xCB59A4", Offset = "0xCB59A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoAnimatorMove()
		{
		}

		[Token(Token = "0x6000599")]
		[Address(RVA = "0xCB59A8", Offset = "0xCB59A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DoAnimatorIK(int layerIndex)
		{
		}

		[Token(Token = "0x600059A")]
		[Address(RVA = "0xCB59AC", Offset = "0xCB59AC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFED00]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023654]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tgoto L_0031;\n\tv62 = *([1ED3410]);\n\tv63 = *([v62 @ X8_v13]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = 0 | 1;\n\t*([2021AA1]) = v67;\nL_0031:\n\tgoto L_003A;\n\tv72 = *([v68 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003A;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v68, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv76 = HutongGames.PlayMaker.FsmLog;\nL_003A:\n\tv81 = ~v79.<LoggingEnabled>k__BackingField;\n\tif (v81) goto L_0056;\n\tv92 = HutongGames.PlayMaker.Fsm::get_MyLog(this.fsm);\n\tHutongGames.PlayMaker.FsmLog::LogAction(v92, 0, text, 0);\n\treturn;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Log(string text)
		{
			if (FsmLog.LoggingEnabled)
			{
				FsmLog myLog = Fsm.MyLog;
				myLog.LogAction(default(FsmLogType), text);
			}
		}

		[Token(Token = "0x600059B")]
		[Address(RVA = "0xCB5A98", Offset = "0xCB5A98", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EA3C80]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023655]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tgoto L_0031;\n\tv62 = *([1ED3410]);\n\tv63 = *([v62 @ X8_v13]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = 0 | 1;\n\t*([2021AA1]) = v67;\nL_0031:\n\tgoto L_003A;\n\tv72 = *([v68 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003A;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v68, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv76 = HutongGames.PlayMaker.FsmLog;\nL_003A:\n\tv81 = ~v79.<LoggingEnabled>k__BackingField;\n\tif (v81) goto L_0056;\n\tv92 = HutongGames.PlayMaker.Fsm::get_MyLog(this.fsm);\n\tHutongGames.PlayMaker.FsmLog::LogAction(v92, 1, text, 0);\n\treturn;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogWarning(string text)
		{
			if (FsmLog.LoggingEnabled)
			{
				FsmLog myLog = Fsm.MyLog;
				myLog.LogAction(FsmLogType.Warning, text);
			}
		}

		[Token(Token = "0x600059C")]
		[Address(RVA = "0xCB5B84", Offset = "0xCB5B84", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EE47F8]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023656]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tgoto L_0031;\n\tv62 = *([1ED3410]);\n\tv63 = *([v62 @ X8_v13]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = 0 | 1;\n\t*([2021AA1]) = v67;\nL_0031:\n\tgoto L_003A;\n\tv72 = *([v68 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003A;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v68, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv76 = HutongGames.PlayMaker.FsmLog;\nL_003A:\n\tv81 = ~v79.<LoggingEnabled>k__BackingField;\n\tif (v81) goto L_0056;\n\tv92 = HutongGames.PlayMaker.Fsm::get_MyLog(this.fsm);\n\tHutongGames.PlayMaker.FsmLog::LogAction(v92, 2, text, 0);\n\treturn;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogError(string text)
		{
			if (FsmLog.LoggingEnabled)
			{
				FsmLog myLog = Fsm.MyLog;
				myLog.LogAction(FsmLogType.Error, text);
			}
		}

		[Token(Token = "0x600059D")]
		[Address(RVA = "0xCB5C70", Offset = "0xCB5C70", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EE9488]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023657]) = v35;\nL_001A:\n\treturn v41.Empty;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual string ErrorCheck()
		{
			return string.Empty;
		}

		[Token(Token = "0x600059E")]
		[Address(RVA = "0xCB5CC0", Offset = "0xCB5CC0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(tag);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0017;\n\treturn 1;\nL_0017:\n\tv46 = UnityEngine.Component::get_gameObject(other);\n\tv49 = HutongGames.PlayMaker.FsmString::get_Value(tag);\n\treturnVal3 = UnityEngine.GameObject::CompareTag(v46, v49);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TagMatches(FsmString tag, Component other)
		{
			if (FsmString.IsNullOrEmpty(tag))
			{
				return true;
			}
			GameObject gameObject = other.gameObject;
			string value = tag.Value;
			return gameObject.CompareTag(value);
		}

		[Token(Token = "0x600059F")]
		[Address(RVA = "0xCB5D30", Offset = "0xCB5D30", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(tag);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0017;\n\treturn 1;\nL_0017:\n\tv46 = UnityEngine.Collision::get_collider(collisionInfo);\n\tv52 = UnityEngine.Component::get_gameObject(v46);\n\tv53 = HutongGames.PlayMaker.FsmString::get_Value(tag);\n\treturnVal3 = UnityEngine.GameObject::CompareTag(v52, v53);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TagMatches(FsmString tag, Collision collisionInfo)
		{
			if (FsmString.IsNullOrEmpty(tag))
			{
				return true;
			}
			Collider collider = collisionInfo.collider;
			GameObject gameObject = collider.gameObject;
			string value = tag.Value;
			return gameObject.CompareTag(value);
		}

		[Token(Token = "0x60005A0")]
		[Address(RVA = "0xCB5DAC", Offset = "0xCB5DAC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(tag);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0017;\n\treturn 1;\nL_0017:\n\tv46 = UnityEngine.Collision2D::get_collider(collisionInfo);\n\tv52 = UnityEngine.Component::get_gameObject(v46);\n\tv53 = HutongGames.PlayMaker.FsmString::get_Value(tag);\n\treturnVal3 = UnityEngine.GameObject::CompareTag(v52, v53);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TagMatches(FsmString tag, Collision2D collisionInfo)
		{
			if (FsmString.IsNullOrEmpty(tag))
			{
				return true;
			}
			Collider2D collider = collisionInfo.collider;
			GameObject gameObject = collider.gameObject;
			string value = tag.Value;
			return gameObject.CompareTag(value);
		}

		[Token(Token = "0x60005A1")]
		[Address(RVA = "0xCB5E28", Offset = "0xCB5E28", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(tag);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0017;\n\treturn 1;\nL_0017:\n\tv46 = UnityEngine.ControllerColliderHit::get_collider(collisionInfo);\n\tv52 = UnityEngine.Component::get_gameObject(v46);\n\tv53 = HutongGames.PlayMaker.FsmString::get_Value(tag);\n\treturnVal3 = UnityEngine.GameObject::CompareTag(v52, v53);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TagMatches(FsmString tag, ControllerColliderHit collisionInfo)
		{
			if (FsmString.IsNullOrEmpty(tag))
			{
				return true;
			}
			Collider collider = collisionInfo.collider;
			GameObject gameObject = collider.gameObject;
			string value = tag.Value;
			return gameObject.CompareTag(value);
		}

		[Token(Token = "0x60005A2")]
		[Address(RVA = "0xCB5EA4", Offset = "0xCB5EA4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(tag);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0016;\n\treturn 1;\nL_0016:\n\tv44 = HutongGames.PlayMaker.FsmString::get_Value(tag);\n\treturnVal3 = UnityEngine.GameObject::CompareTag(go, v44);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TagMatches(FsmString tag, GameObject go)
		{
			if (FsmString.IsNullOrEmpty(tag))
			{
				return true;
			}
			string value = tag.Value;
			return go.CompareTag(value);
		}

		[Token(Token = "0x60005B9")]
		[Address(RVA = "0xCB5FBC", Offset = "0xCB5FBC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.enabled = 0x101;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmStateAction()
		{
			enabled = true;
			isOpen = true;
		}
	}
}
