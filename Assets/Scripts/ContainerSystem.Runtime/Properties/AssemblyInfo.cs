using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("Reflex.Editor")]
[assembly: InternalsVisibleTo("Reflex.EditModeTests")]
[assembly: InternalsVisibleTo("Reflex.IL2CPP.Tests")]
[assembly: InternalsVisibleTo("Reflex.Weaving")]
[assembly: AlwaysLinkAssembly]
[assembly: Token(Token = "0x20000001")]
[assembly: AssemblyVersion("0.0.0.0")]
