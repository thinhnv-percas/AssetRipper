# Edits to MiniUnity's generated API stubs (Engine/Generated is ignored by its git)

Applied by hand on top of the generated files; re-apply after regenerating them.

- `Engine/Generated/UnityEngine.AudioModule.g.cs`: `public sealed unsafe partial class AudioClip : global::UnityEngine.Object`
  becomes `... : global::UnityEngine.Audio.AudioResource` (Unity 6: AudioClip derives from AudioResource, which
  `Engine/Core/Compat/AudioVideoTypes.cs` now declares).
- `Engine/Generated/UnityEngine.CoreModule.g.cs`: `UnityEngine.Screen.sleepTimeout` threw NotImplementedException;
  it is now `public static int sleepTimeout { get; set; } = -2; // SleepTimeout.SystemSetting`.
