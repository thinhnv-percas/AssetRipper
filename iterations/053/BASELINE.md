# Iteration 053 — baseline và ma trận fixture mới

Commit vào: `2e3d46f1`. Release, `--script-level 3 --reconstruct-bodies --struct-db StructDb`.
Mọi con số đọc sau khi tiến trình rip thoát.

## Impostor — tái lập baseline 052 đúng tới từng chữ số

| | 052 | 053 |
|---|---|---|
| `EXACT` | 2860 | 2860 |
| `HIGH_CONFIDENCE` | 163 | 163 |
| `PARTIAL` | 1142 | 1142 |
| `FALLBACK` | 1317 | 1317 |
| placeholder | 4297 | 4297 |
| phục hồi không đồ thế chỗ | 3023 / 5482 | 3023 / 5482 |
| field layout | 1394 / **0** | 1394 / **0** |
| `.cs` / `generatorFailures` | 830 / 0 | 830 / 0 |

## RunFromZombies — fixture chính mới, có source đối chiếu

```
.cs                       796
method có địa chỉ native  3928
EXACT                    2285  (58,2%)
HIGH_CONFIDENCE           164  ( 4,2%)
PARTIAL                  1074  (27,3%)
FALLBACK                  405  (10,3%)
MISSING                     0
phục hồi không đồ thế chỗ 2449 / 3928  (62,3%)
placeholder              5964
field layout             2165 exact / 0 disagreed
generatorFailures           0
```

## JellyBlast v2 — thay hẳn v1

```
.cs                      1501
method có địa chỉ native 7485      (v1: 0)
EXACT                    2200  (29,4%)
PARTIAL                  4668  (62,4%)
phục hồi không đồ thế chỗ 2448 / 7485  (32,7%)
placeholder             49487
field layout             2654 exact / 0 disagreed   (v1: không đo được gì)
generatorFailures           0
```

`reports/JELLYBLAST_V2.md` có bản fingerprint đầy đủ. Trạng thái `IOS_DECRYPTED`.

## Pinata

Rời ma trận mặc định theo §1. Số liệu cuối cùng còn ghi lại của nó nằm ở
`reports/regression-matrix.md` mục 052, và không còn ảnh hưởng acceptance.
