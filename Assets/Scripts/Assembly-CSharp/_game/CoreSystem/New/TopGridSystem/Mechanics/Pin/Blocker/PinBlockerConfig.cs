using AssetRipperInjected;
using Cpp2ILInjected;
using HighlightPlus;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker
{
	[Token(Token = "0x20001B9")]
	public class PinBlockerConfig : ScriptableObject
	{
		[Header("Prefabs (placeholder)")]
		[Tooltip("Spawned at the two endpoints of the path. Authored facing +X (outward).")]
		[Token(Token = "0x4000557")]
		[FieldOffset(Offset = "0x18")]
		public GameObject endpointPrefab;

		[Tooltip("Spawned at straight (non-corner, non-endpoint) cells. Authored facing +X.")]
		[Token(Token = "0x4000558")]
		[FieldOffset(Offset = "0x20")]
		public GameObject straightPrefab;

		[Tooltip("Spawned where the path bends. Authored as an L-piece with its open arms pointing toward +X and +Y (the classifier subtracts 45 degrees so the bisector lands correctly).")]
		[Token(Token = "0x4000559")]
		[FieldOffset(Offset = "0x28")]
		public GameObject cornerPrefab;

		[Tooltip("Spawned at the marker cell instead of any path-shape prefab. The marker is the trigger: breaking the sand cube under it dissolves the whole pin. Authored facing +X like every other segment — rotation follows the cell's topology (endpoint / straight / corner) so the marker aligns with the path.")]
		[Token(Token = "0x400055A")]
		[FieldOffset(Offset = "0x30")]
		public GameObject markerPrefab;

		[Tooltip("Spawned one cell beyond each endpoint — head of the first piece and tail of the last. Authored facing +X (outward); rotation follows the adjacent endpoint piece. Leave null to skip terminal decoration.")]
		[Token(Token = "0x400055B")]
		[FieldOffset(Offset = "0x38")]
		public GameObject terminalPrefab;

		[Header("Placement")]
		[Tooltip("Distance from the cell along the camera-depth axis (-Z in world space). Positive moves the visual in front of the grid layer.")]
		[Token(Token = "0x400055C")]
		[FieldOffset(Offset = "0x40")]
		public float verticalOffset;

		[Tooltip("Local scale applied to straight / corner / endpoint prefabs. Since prefabs are authored facing +X, the X component is the long axis.")]
		[Token(Token = "0x400055D")]
		[FieldOffset(Offset = "0x44")]
		public Vector3 pieceScale;

		[Tooltip("Local scale applied to the marker prefab. Authored +X is the long axis (same convention as the path pieces), so the marker's rotation can follow the cell's segment topology.")]
		[Token(Token = "0x400055E")]
		[FieldOffset(Offset = "0x50")]
		public Vector3 markerScale;

		[Header("Highlight")]
		[Tooltip("Profile applied to the HighlightEffect added on each PinBlocker_{pinId} root. effectGroup = Children so every spawned piece under the root inherits the highlight. Leave null to skip adding the component.")]
		[Token(Token = "0x400055F")]
		[FieldOffset(Offset = "0x60")]
		public HighlightProfile highlightProfile;

		[Header("Timing")]
		[Tooltip("Seconds before Resp_PinDisappeared fires (the gameplay-side gate). Scattered pieces keep flying after this — only the data-side unblock waits this long.")]
		[Token(Token = "0x4000560")]
		[FieldOffset(Offset = "0x68")]
		public float disappearSeconds;

		[Header("Disappear FX")]
		[Tooltip("Radial impulse magnitude applied to each piece, directed marker → piece. The marker itself gets a random in-plane direction.")]
		[Token(Token = "0x4000561")]
		[FieldOffset(Offset = "0x6C")]
		public float explosionForce;

		[Tooltip("Extra +Y impulse added on top of the radial force so pieces pop up before falling under gravity.")]
		[Token(Token = "0x4000562")]
		[FieldOffset(Offset = "0x70")]
		public float upwardBias;

		[Tooltip("Random in-plane spin impulse range (±this, around Z). Pieces' X/Y rotations are frozen to keep the spin readable on the screen plane.")]
		[Token(Token = "0x4000563")]
		[FieldOffset(Offset = "0x74")]
		public float explosionTorque;

		[Tooltip("Seconds a scattered piece lives before being destroyed.")]
		[Token(Token = "0x4000564")]
		[FieldOffset(Offset = "0x78")]
		public float pieceLifetime;

		[Token(Token = "0x60007EF")]
		[Address(RVA = "0x3E71900", Offset = "0x3E71900", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.verticalOffset = 0.5f;\n\tgoto L_001E;\nL_001E:\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerConfig)+44]) = v49.one;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerConfig)+4C]) = v49.one.z;\n\t// 34 NotImplemented \"Instruction DUP not yet implemented.\"\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerConfig)+50]) = v49.one.z;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerConfig)+58]) = 0x3F19999A;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerConfig)+68]) = *([93094E0]);\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerConfig)+78]) = 0x40400000;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public PinBlockerConfig()
		{
			verticalOffset = 0.5f;
			_ = Vector3.one;
			_ = Vector3.one.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			_ = Vector3.one.z;
			_ = 1058642330;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [93094E0]");
			_ = 0;
			_ = 1077936128;
		}
	}
}
