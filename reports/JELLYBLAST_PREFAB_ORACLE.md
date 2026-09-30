# JellyBlast prefab oracle — iteration 063

Nhãn: **PROVEN**, **MEASURED**. `Test/Scripts/prefab_oracle.py`; nguyên liệu
`iterations/063/serialized/jellyblast-prefabs.{json,txt}`.

## 1. Phép đo

Một prefab được rút về dạng chuẩn: tập các cặp (đường dẫn hierarchy, kiểu component). Kiểu của một
MonoBehaviour là tên class của script, phân giải qua GUID trong `.meta` của **từng phía** — nên một script
nằm trong package ở phía này và trong `Assets/Scripts` ở phía kia vẫn ghép được. Không so YAML thô, không
so fileID.

- `MATCH`, `SERIALIZED_RECOVERY_MISMATCH` (liệt kê phần chỉ có ở một phía), `MISSING_IN_RECOVERED`,
  `NOT_IN_BUILD` (prefab demo/tutorial/examples của vendor, không có trong build).
- Với `--root`, mỗi mismatch được quy nguồn: phần source có mà bản phục hồi thiếu, nếu derivation root
  cũng không có, là **SOURCE_EDIT**; nếu root có mà bản phục hồi mất, là **RECOVERY_DEFECT**.

## 2. Kết quả — MEASURED

| | Số |
|---|---:|
| Prefab source | 70 |
| Prefab phục hồi | 49 |
| `NOT_IN_BUILD` (RayFire Tutorial 16, PathCreator Examples 4, UIOverlayParticles Demo 1) | 21 |
| `MATCH` | 26 |
| `SERIALIZED_RECOVERY_MISMATCH` | 23 — **cả 23 là SOURCE_EDIT** |
| `RECOVERY_DEFECT` | **0** |
| `MISSING_IN_RECOVERED` | 0 |

23 mismatch đều là các prefab `levelN` và cùng một thay đổi: build đặt `ClosedPathCollider` +
`RoundedPathMeshCreator` (các type của `Assembly-CSharp-firstpass`) trên floor/curve; source thay bằng
`PathFillMeshCreator` + `PathPolygonCollider2D` viết tay. Hai script build dùng không có trong source
(provenance đã thấy chúng thiếu), và commit `878d647b` "Fix level floors drawn offset from their
colliders" là nơi thay. Bản phục hồi giữ đúng component của build.

`prefab_match_rate` thô 0.5306 (26/49) đo source chứ không đo bản phục hồi; trên các prefab source không
sửa, bản phục hồi khớp **26/26**.
