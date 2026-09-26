# Inlined `List<T>.Add` recovery

Sinh bởi `Test/Scripts/inline_list_add_report.py`. Đừng sửa tay.

| fixture | candidate | matched | rejected | status |
| --- | ---: | ---: | ---: | --- |
| RunFromZombies | 160 | 130 | 30 | OK |
| Impostor | 297 | 267 | 30 | OK |
| JellyBlastV2 | 1252 | 870 | 382 | OK |
| MergeRoom | 1346 | 820 | 526 | OK |
| **tổng** | **3055** | **2087** | **968** | |

## Sites được đề nghị nhưng bị từ chối

| số lượng | lý do |
| ---: | --- |
| 140 | `ListAdd:guard does not end in a conditional branch` |
| 133 | `ListAdd:CheckLess of field _size and ArrayLength of a local defined by Move field _items, neither the receiver's size; the receiver is an element address rather than a list - the fast path's own address in the receiver register` |
| 96 | `ListAdd:size compared against ArrayLength of a local with no single definition; the receiver is local defined by Newobj memory+0x0` |
| 91 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Newobj memory+0x0` |
| 72 | `ListAdd:slow path has 2 predecessors` |
| 40 | `ListAdd:nothing holds the receiver, which is memory+0x0` |
| 37 | `ListAdd:the branch condition is defined by CheckNotEqual; the receiver is local defined by Call local` |
| 35 | `ListAdd:fast path has 2 predecessors` |
| 29 | `ListAdd:the branch condition is defined by CheckNotEqual; the receiver is local defined by Newobj TypeAnalysisContext` |
| 26 | `ListAdd:CheckLess of field _size and ArrayLength of a local defined by Move field _items, neither the receiver's size; the receiver is Add of local and Immediate` |
| 25 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is a local with no single definition` |
| 24 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0x0` |
| 20 | `ListAdd:CheckLess of a local with no single definition and ArrayLength of a local with no single definition, neither the receiver's size; the receiver is local defined by Newobj GenericInstanceTypeAnalysisContext` |
| 18 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Newobj GenericInstanceTypeAnalysisContext` |
| 16 | `ListAdd:size compared against ArrayLength of a local with no single definition; the receiver is a local with no single definition` |
| 14 | `ListAdd:CheckLess of a local with no single definition and ArrayLength of a local with no single definition, neither the receiver's size; the receiver is a local with no single definition` |
| 10 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0x8` |
| 10 | `ListAdd:the branch condition is defined by CheckNotEqual; the receiver is a local with no single definition` |
| 8 | `ListAdd:fast path has 4 predecessors` |
| 8 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0x18` |
| 6 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Newobj RuntimeClassTypeAnalysisContext` |
| 6 | `ListAdd:fast path has 3 predecessors` |
| 6 | `ListAdd:slow path has 3 predecessors` |
| 4 | `ListAdd:the branch condition is defined by CheckEqual; the receiver is local defined by Newobj GenericInstanceTypeAnalysisContext` |
| 4 | `ListAdd:CheckLess of a local with no single definition and ArrayLength of a local defined by Move field _items, neither the receiver's size; the receiver is local defined by Newobj GenericInstanceTypeAnalysisContext` |
| 4 | `ListAdd:the receiver is field randomList, which the body also writes` |
| 4 | `ListAdd:CheckLess of a local with no single definition and ArrayLength of a local with no single definition, neither the receiver's size; the receiver is local defined by Newobj memory+0x0` |
| 4 | `ListAdd:the receiver is field _attributes, which the body also writes` |
| 4 | `ListAdd:the receiver is field _childNodes, which the body also writes` |
| 4 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0x88` |
| 4 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is an element address rather than a list - the fast path's own address in the receiver register` |
| 2 | `ListAdd:size compared against ArrayLength of a local with no single definition; the receiver is local defined by Newobj GenericInstanceTypeAnalysisContext` |
| 2 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0x20` |
| 2 | `ListAdd:the branch condition is defined by CheckEqual; the receiver is local defined by Move field AttachmentUVs` |
| 2 | `ListAdd:the branch condition is defined by CheckEqual; the receiver is local defined by Move field AttachmentVerts` |
| 2 | `ListAdd:the branch condition is defined by CheckEqual; the receiver is local defined by Newobj memory+0x0` |
| 2 | `ListAdd:the receiver is field positionList, which the body also writes` |
| 2 | `ListAdd:the branch condition is defined by CheckEqual; the receiver is a local with no single definition` |
| 2 | `ListAdd:the branch condition is defined by CheckEqual; the receiver is local defined by Move field frontPrior` |
| 2 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0x28` |
| 2 | `ListAdd:CheckLess of field _entries and ArrayLength of a local defined by Move field _buckets, neither the receiver's size; the receiver is local defined by Newobj memory+0x0` |
| 2 | `ListAdd:nothing holds the receiver, which is memory+0xFFFFFFFFFFFFFF60` |
| 2 | `ListAdd:CheckLess of a local with no single definition and ArrayLength of a local defined by Move field _items, neither the receiver's size; the receiver is local defined by Newobj memory+0x0` |
| 2 | `ListAdd:nothing holds the receiver, which is memory+0xA8` |
| 2 | `ListAdd:the receiver is field mFilters, which the body also writes` |
| 2 | `ListAdd:CheckLess of memory+0x18 and ArrayLength of a local with no single definition, neither the receiver's size; the receiver is a local with no single definition` |
| 2 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0x60` |
| 2 | `ListAdd:fast path has 5 predecessors` |
| 2 | `ListAdd:the branch condition is defined by Not; the receiver is Add of local and Immediate` |
| 2 | `ListAdd:CheckLess of a local with no single definition and ArrayLength of a local defined by Move field _items, neither the receiver's size; the receiver is a local with no single definition` |
| 2 | `ListAdd:CheckLess of memory+0x18 and memory+0x18, neither the receiver's size; the receiver is local defined by Move memory+0xFFFFFFFFFFFFFFF8` |
| 2 | `ListAdd:CheckLess of a local with no single definition and a local with no single definition, neither the receiver's size; the receiver is field m_normals` |
