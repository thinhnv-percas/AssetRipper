"""Port of Source/AssetRipper.Numerics.Tests/BoneWeight4Tests.cs"""
from assetripper_numerics.bone_weight import BoneWeight4


def test_default_can_be_normalized():
    bone_weight = BoneWeight4().normalize_weights()
    assert bone_weight.weight0 == 0.25
    assert bone_weight.weight1 == 0.25
    assert bone_weight.weight2 == 0.25
    assert bone_weight.weight3 == 0.25
    assert bone_weight.normalized
