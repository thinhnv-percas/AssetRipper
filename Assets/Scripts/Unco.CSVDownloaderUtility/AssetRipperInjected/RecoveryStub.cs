// Written by Test/Tools/RecoveryStubber. A member whose recovered body did not compile was given a stub that calls
// Missing() and returns the default; the list of them, with the errors that caused each, is the repair worklist.
namespace AssetRipperInjected
{
    internal static class RecoveryStub
    {
        private static readonly global::System.Collections.Generic.HashSet<string> reported = new global::System.Collections.Generic.HashSet<string>();

        public static void Missing(string member)
        {
            lock (reported)
            {
                if (!reported.Add(member)) return;
            }
            global::UnityEngine.Debug.LogWarning("[Recovery] body not recovered yet: " + member);
        }
    }
}
