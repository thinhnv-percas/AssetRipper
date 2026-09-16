using System;
using System.Buffers.Binary;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: recognises a compare-and-swap loop from its machine code, so that the runtime
/// function performing one can be named by what it does rather than by where it sits.
/// </summary>
/// <remarks>
/// <para>
/// One address on the test game takes 339 unresolved calls, every one of them from an
/// <c>add_</c>/<c>remove_</c> event accessor, and the code at it is a compare-and-swap loop. The
/// semantics are certain - that is what <c>Interlocked.CompareExchange</c> compiles to and what an
/// event accessor is written with - but no managed method sits there, and every thunk chain from
/// <c>System.Threading.Interlocked::CompareExchange</c> ends somewhere else, so the usual discovery
/// routes find nothing. Writing the address down would make the recovery correct on one build of one
/// game and silently wrong on the next, which is why iteration 050 recorded the evidence and changed
/// nothing.
/// </para>
/// <para>
/// This is the other half: a rule that reads the instructions. A64 has exactly one way to write a
/// compare-and-swap before <c>LSE</c> - an exclusive load, a comparison, a store-exclusive to the
/// <em>same</em> address, and a branch back when the store lost the reservation - and the encodings
/// of the two exclusive accesses are unambiguous. Nothing here is a heuristic about a particular
/// game: the pattern is the architecture's, and a function that does not have it does not match at
/// any address.
/// </para>
/// <para>
/// It reports; it does not rewrite. A wrong mapping would corrupt 339 event accessors in the quiet
/// way, so the recogniser has to be shown to separate the shape it claims before anything acts on
/// it - which is what the synthetic cases beside it are for, each assembled at a different address
/// so that no answer can come from one.
/// </para>
/// </remarks>
public static class AtomicIntrinsicRecognizer
{
    /// <summary>
    /// How many instructions from the entry are examined. A pre-LSE compare-and-swap is six to nine
    /// instructions including the retry branch; a window several times that admits a prologue
    /// without admitting an unrelated function's body.
    /// </summary>
    public const int WindowInstructions = 24;

    /// <summary>What the code at an address does, as far as this recogniser can tell.</summary>
    public enum Shape
    {
        /// <summary>Nothing here matches an atomic sequence.</summary>
        None,

        /// <summary>
        /// An exclusive load and an exclusive store to the same address with a comparison between
        /// them: <c>Interlocked.CompareExchange</c>.
        /// </summary>
        CompareExchange,

        /// <summary>
        /// An exclusive load and store to the same address with no comparison, which is
        /// <c>Interlocked.Exchange</c> or one of the arithmetic ones - distinguished from
        /// compare-and-swap, not from each other.
        /// </summary>
        ExchangeWithoutComparison,
    }

    /// <summary>
    /// What the words of A64 code in <paramref name="code"/> perform.
    /// </summary>
    /// <remarks>
    /// Given the bytes rather than the binary so the cases beside it need no game, and so the same
    /// rule can be applied to a veneer's target as to the veneer.
    /// </remarks>
    public static Shape Classify(ReadOnlySpan<byte> code)
    {
        int loadRegister = -1;
        int loadedInto = -1;
        bool compared = false;

        for (int index = 0; index < WindowInstructions && (index + 1) * 4 <= code.Length; index++)
        {
            uint word = BinaryPrimitives.ReadUInt32LittleEndian(code.Slice(index * 4, 4));

            if (IsLoadExclusive(word))
            {
                loadRegister = AddressRegister(word);
                loadedInto = TransferRegister(word);
                compared = false;
                continue;
            }

            if (loadRegister < 0)
            {
                // Everything before the exclusive load is prologue; a comparison there is not part of
                // the sequence and counting it would let an ordinary function match.
                continue;
            }

            // SUBS to the zero register is CMP, which is how a comparison is written; the operand
            // being the value just loaded is what makes it this sequence's comparison rather than a
            // test of something else.
            if (IsCompareWith(word, loadedInto))
            {
                compared = true;
                continue;
            }

            if (IsStoreExclusive(word))
            {
                // The same address, or the two accesses belong to different sequences and pairing
                // them would be reading a shape that is not there.
                if (AddressRegister(word) != loadRegister)
                {
                    return Shape.None;
                }

                return compared ? Shape.CompareExchange : Shape.ExchangeWithoutComparison;
            }
        }

        return Shape.None;
    }

    /// <summary>LDXR/LDAXR, 32- or 64-bit: the load half of an exclusive pair.</summary>
    /// <remarks>
    /// The load/store exclusive family is <c>size(2) 001000 o2 L o1 Rs o0 Rt2 Rn Rt</c>. A load has
    /// <c>L</c> set, <c>o1</c> clear, and both <c>Rs</c> and <c>Rt2</c> all ones. The size and the
    /// ordering bits are deliberately outside the mask: an <c>int</c> field and an object reference
    /// are both compare-and-swapped, and a compiler may write <c>LDXR</c> where the sequence is
    /// fenced some other way - refusing either would refuse a real compare-and-swap.
    /// </remarks>
    public static bool IsLoadExclusive(uint word)
        => (word & 0x3FFF7C00) == 0x085F7C00;

    /// <summary>STXR/STLXR, 32- or 64-bit: the store half.</summary>
    /// <remarks>
    /// The same family with <c>L</c> clear, so <c>Rs</c> is a real register - it receives whether the
    /// store kept its reservation - and is therefore outside the mask, leaving <c>Rt2</c> as the only
    /// fixed field. A load never matches this: its <c>L</c> bit is inside the mask and set.
    /// </remarks>
    public static bool IsStoreExclusive(uint word)
        => (word & 0x3FE07C00) == 0x08007C00;

    /// <summary>The base register an exclusive access addresses through.</summary>
    public static int AddressRegister(uint word) => (int)((word >> 5) & 0x1F);

    /// <summary>The register an exclusive access loads into or stores from.</summary>
    public static int TransferRegister(uint word) => (int)(word & 0x1F);

    /// <summary>
    /// Whether a word is a comparison one of whose operands is <paramref name="register"/>.
    /// </summary>
    /// <remarks>
    /// <c>CMP</c> is <c>SUBS</c> with the zero register as its destination, in either the
    /// shifted-register or the immediate form. Requiring the loaded value to be an operand is what
    /// separates a compare-and-swap from an exchange that happens to be followed by a test.
    /// </remarks>
    public static bool IsCompareWith(uint word, int register)
    {
        bool shiftedRegister = (word & 0x7F200000) == 0x6B000000;
        bool immediate = (word & 0x7F800000) == 0x71000000;

        if (!shiftedRegister && !immediate)
        {
            return false;
        }

        if ((word & 0x1F) != 0x1F)
        {
            // Not CMP: SUBS keeping its result is arithmetic, not a comparison.
            return false;
        }

        int first = (int)((word >> 5) & 0x1F);
        int second = (int)((word >> 16) & 0x1F);

        return first == register || (shiftedRegister && second == register);
    }
}
