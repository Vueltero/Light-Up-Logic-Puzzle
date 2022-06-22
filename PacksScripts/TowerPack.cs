using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPack : MonoBehaviour
{
    string[] puzzles =
    {
        "5x6:cBg11d00g2c", "5x6:1cBf1aBbBa1f2cB", "5x6:e1b0c0f11f0b", "5x6:l20i3f", "5x6:fB10l121f", "5x7:fBa2f2cBfBa4f", "5x7:a0b1fBa2gBaBgBb2", "5x7:d2Bi21aBBiB1d", "5x7:a2cBdBpBa2a3bB", "5x7:aBh2l2e1cBa", "5x8:k1a2aBl1Bf3c", "5x8:e0cBbBc0a1b2a3c2b2cBe", "5x8:eBc2e0aBdBa0e0c2e", "5x8:aBa1e2f1kBf2d", "5x8:e0BcBc3j1c1B2h", "5x9:b1e0b0bB1mBbB0i2a", "5x9:cBe1a0aBgBaBg2a0aBe1c", "5x9:g1g0c0b4bBc1g0g", "5x9:hBg2i4k0f", "5x9:10g0dBh1cBd0aBc2f", "5x10:kBa1aBc0B2aBBBBaBBBcBa3a1k", "5x10:Bc1e11cB1h0iBa1iBb", "5x10:a2e1b0c1e2h1eBc1bBe1a", "5x10:bBbBe3bBbBaBaBbB1f4i2bBd", "5x10:dBaBgBa2f2dBbBg3aBgB", "5x11:e0a0aBb1h2a0gBa1h0b2a3a1e", "5x11:a2BbBb2h3c1d0aBf0cBe1a0d1b", "5x11:0nBb1dBe22BkBBBBc0c0", "5x11:gBa3g2e10b2b01e2gBa2g", "5x11:i11e13e3c2eBb21b2h1e", "6x7:g00fBa11b1a00h0cBd", "6x7:m0a3j1a2m", "6x7:j1j31b1cBb0eBb2", "6x7:g1b1cB0cBbBc3Bc2b1g", "6x7:1d2cBf01aBh11cBb0d1", "6x8:g3dBf4hBf2d4g", "6x8:g1eB1e1b1hBa3BkB", "6x8:BaBc2j1q2BeBa1c", "6x8:bB2i1b2nBbBi2Bb", "6x8:h0bBdB1a0e3a2d2g2g", "6x9:bBbBcBd3d20j1Be2fBd2b1", "6x9:c21cBdBf0c3aBBi2aBn", "6x9:b2Bj2BbBd1f0d2b1BjB1b", "6x9:cBe0Ba1d2bBiB1cBa1c1a2i0", "6x9:a2d1eBa00b0pBb10aBe2dBa", "6x10:2c0Ba2f1aBhBB2lBaBg3i", "6x10:cBa2h2eB10nB20e1hBa2c", "6x10:a3b0mB0b01l2BbBBmBb2a", "6x10:BaBi2aB0a2cBBb2cBh2bBgBcBdBa", "6x10:b2jBbBd2cB0dB2f2cBb2i1c", "6x11:a2bBi0Bc1bBaBd2f2d1a4b2c3BiBbBa", "6x11:e2fBeBb2f0m2b2BbBbBd2b0bBb", "6x11:g12f3kBBd0aBg3a2b1a3k0a1a", "6x11:cBcBBb20BcBb3cBkBgBc20c1aBBbBc0b", "6x11:B2lBcBb3bBe0a0BaBeBb2b0cBl0B", "6x12:bBcB1a2h10h020j2B1h0Bh2a0BcBb", "6x12:mBa3cBb2bB1b1a3aBa2bBcBgBcB1c00cBg", "6x12:cBd21cBa0BBn02d0BoBa2BBb21e0b", "6x12:BdBh1Bj0Bb2d11d1b0Bj1BhBd1", "6x12:00a0fBh1e0h1dBaB0b0k2g1e1", "7x8:Bd3c1c3m11mBc2cBd0", "7x8:d1a0d1b1cBc1cBe2b2b0aBjBaB1a", "7x8:a2cBoBa1aBa2Ba0a1aBo1c0a", "7x8:c0a1dBaBb11kBaB10cBcBaBj3b", "7x8:d1a0d1b1cBc1cBe2b2b0aBjBaB1a", "7x9:BeBaBBa3Bh0bBbBg0b1b0hB0aBBa2eB", "7x9:dBa20j1Be2b2jBfBBa2jBaB", "7x9:b2a0aBh0g1BmBbBaB0a2aB2h0cB", "7x9:1b2a2lBf2BaBe0a2BfBl0aBb1", "7x9:0cBa2n12hBg3BiBdB2c1b", "7x10:cBe3aBg0cBb0e1dBeBb1c0g1a2eBc", "7x10:B0dBBb2eBe4a3rBaBeBdBb2cB0dB", "7x10:aBaBjBd1b1c10gBa2Ba2p2bBd3d", "7x10:aBc1cBa2b3eBgBeBBe2gBeBbBa1c1c0a", "7x10:Bj1e0g1Bi3g2b2oB1e", "7x11:c1g2b1o1d1a1a2l1c2BbBa2e2BaBe", "7x11:a2b2aBe1bBBg2BaBBm1iBBa0a20i3b1b1aB", "7x11:1a1fBa0a1f1dBa1bBBcBf0b00e1eBc0Bh0d", "7x11:hB0aBBb2c2dBdBcBc3a2c1cBd1dBcBbBBa0Bh", "7x11:bBd1c1g0cBbBb0f0c2fBb2b1cBg0cBd2b", "7x12:1cBaBb1b3kBcBhBa01b11a0hBcBkBb2b2a2cB", "7x12:a3a1hBaBc1c21nBk1b1BbBeBb2e3a3i", "7x12:B2aBsB1c10d1d1BaBBbBBcB2c2b0hBd0d1a0B0B", "7x12:BBc0Bh0c1jBa3b2bBbB1b2b0bBaBj1c0hB0c10", "7x12:aBdBBgBfBc3b1cBbBBeBBe1c1bBc1bBe2g1dB", "7x13:eBg3b1d1k1h1e1l0a0hBj1e2a", "7x13:d1aBg1cBa3BbBk3bBk1cBbB1aBaBh2cBBc0aBBcBb", "7x13:aBbBc1b0b0c2Bl21b0fBaBaBfBbB1l00cBbBbBcBb0a", "7x13:gB11aBBBa2BaB0pBcBaBaBa2a1a2c1p2BaB1aBBBa1BBg", "7x13:BbBaBBd3e2BBd0b1a1aBn0aBb0Bd1c0Bc4aBcBb0aB1bBgBa", "8x9:kBBcBe1f2f1h0b3e1d11k", "8x9:1bBdBd3aB11gBd3lBbBa2dBo0b", "8x9:a3eBg1BgBaBc1d01d2cBa1gBBgBe2a", "8x9:b2bBcBd4iBfBb0b0bBfBiBd0c1b1b", "8x9:Bf2hBdB1b0g1j1bB1e0a2cBjB", "8x10:aBb1jBd0BcB1d3qB1dBd2Bi2a3bBc", "8x10:c2cBeBaBh1e1d21d1BkBa2e1a1aBlB", "8x10:i1d2BaBcBaBc0e2l2e0c2a2cBa12dBi", "8x10:00a0h2a1BaBeBeBcBb11b2cBBa0e1j0bBg1d", "8x10:2f1aBdBc2b1c3dBrBd1cBb2c2dBa0f0", "8x11:c1cBe2h0B1a1c11aB1jBhBaBd0a1a1aBg1c1dBbB", "8x11:h2c1a2pB0dBaBc1Bc1a3d2Bp2a1c1h", "8x11:d1bBr1aB3b2bBBa2aBh3c1iBf1bBi2bBa", "8x11:cBBd2aBBaBj0d4dBBcBf1c2BdBdBj4aBBaBdBBc", "8x11:1dBkBb4bBb1dBg0aBmBbBdBa3bBb1hBd2b", "8x12:aBf2b2zbBf1a3k1cB0q1Bc2Bc2a", "8x12:Ba1c2cBc1j2aBa2aBaBbBcBn0a2a0bBfBc0aBaBfBBB2h", "8x12:b3b0bBfBi2aBBa0aBfBa1d2b1dBaBf1a2aB0aBiBf2bBb0b", "8x12:a0j21i1c12Bj1bBdBbBoB11iBdB1c1f", "8x12:fBa3c1d3c11aBeBe02b3bBhBbBbBBe0eBa11cBdBc1aBf", "8x13:2bBb2g0a2k0fBB0aBBd02aBBaBgBBBBB0BcB0iB2gBBj2Ba", "8x13:bBc1a1Bc2jBaBdBl2hBa3d2kBa1dBhB1c2d0c2a", "8x13:BbBBb1BcBd1fB1dBcBkBf2hBe2B2cBBaBe2gBcBa2BbBb", "8x13:aBd0dBb0dBaBk2aB0bBBBa2e2dBeBa12BbBBaBkBaBdBb1d2d1a", "8x13:cB0v2Bd2d2c0BBBlB0B0c3d0dB1v11c", "8x14:i2d3a2a1b2a3aBd2b1dBcBb0bBf1BfBb2bBc0d2bBdBaBaBbBaBa1dBi", "8x14:d0bBf11a1aBd11aBcBaBa1aBd0dBe3aBa0eB10l2dBBBe0cBb1gBB2aBB", "8x14:b0BaBb1h11c2eBi0Ba0g1bBe1aBaBa0e1aBd0d22aBfBaBfBd0c1a", "8x14:1iBb20BgBe0hBBBbBBfBcBc0c13bB1iB1eBiBb2bBB1Bg", "8x14:a1b0cBhBa3b2bBcBcBaBaBgBcBc1d1cBc1gBaBa2c1cBb1b1aBh2cBb1a", "9x10:i1cBcBc0a3e1cBb1g10gBbBc0e3a0c1cBc0i", "9x10:dBe1aBa0e11l1b20b1aBbBp0Ba0gBd2iB", "9x10:iB2jBb13b3aBe1gB1gBaBa2hBbB0a1Bp", "9x10:g1b0b3eBaBbBbB2dBeBaBfBaBeBd1Bb0b4a1eBb0b1g", "9x10:a2qBaBa0d0a0e11c0j2fBb2BBa2cBc3b2aBbBbBa1b", "9x11:jBaBaBa3a0g2b2a1aBc1Bc0BkBBcB1c1a1a2bBg1aBa3aBa1j", "9x11:BlBb2b2f2f0Be1eBe0e0eB1fBf1b4b1lB", "9x11:d1bBBcBjBb1Bb2a1bBB2oBB2g1b0a1b1eBbBcBi1b11", "9x11:d1B0aBt2BaBB0f2fBe0a0b2cBe2aBb0aBdBbBgBBa2c", "9x11:aB1e0cBb3bBdBa1d0eBb1a0hBk21aBb2d0BaBc2kBBd1", "9x12:a2s2c3cBbBlBb0bBdBbBbBl2bBc4cBs2a", "9x12:bBm1aBb1aBg2bB1e4bBaBaBb3cBa1bBgBbBdBb2B2b2aBj1cBf", "9x12:BBg1dBa201o1iBa12dB1BaBBaBBdB1hBg2fBb3eBd11b", "9x12:cBaBB0b2cBdBc02Bc0dBBbBdBd0a20aB2Bp2rBa3BaBc0g", "9x12:aBbBbBc0c2wBa3c2aBcBaBBaBcBaBc4a2wBcBc2b1b1a", "9x13:b2cBbBbBa1b3aBBc1BeBg3a0lBBaBa0aBBl1a0gBeBBcB1a2b2a4b1bBc2b", "9x13:d1g1aBi3c0j3eBaBBb1m3bBBa1eBj2c1i1aBgBd", "9x13:b1fBc2a2aBd1d2eBaBaBa0iBb0Bb1j0bB0aBa2eBeBaBdBd3cBa3a0bBf", "9x13:j2b0aBaBbBc0a1bBBBBBh0bBa0aBaBBc1eBbBdBd1B0a2aBa0f1aBa2iBBg1Bb", "9x13:fBaBaBBb1d3a1d1n1BcBc0nB2aB1hBBa1BaBkB2BbBaB1e1cBb", "9x14:Ba0i2cBe2bBBa2d2aBBaBe0B1jBBb0b1b11jBB0eBaBBaBd4aBBb0eBc1iBaB", "9x14:aBe0j2a1c0aBb0a1aBc1e2c1a2a1v0a1a1cBe0c1aBaBbBa0c3a1jBeBa", "9x14:bBdBd1a3a1B0c2bBaBa3iBf2c1b1d0dBbBBa1c21uBdBgBb1aBbBb11cB", "9x14:1d0bBhBa1aBdBbBb2Bf2B2b1d1bBfBaBfBaB1dBb0d2BBd0bBBc2aBdBhBBd1bB", "9x15:B2b1j2b1BiBcB0cBb2a0c1BeBBh1bBb0b1h0c02e1b11cBgBfBc1Bb2cBf", "9x15:1j0BBb4d2bBc2b2aBaBBb2lBBa0b0k3b2bBkBB1b2fBb2a2a2c2b1d001b1aBh", "9x15:gBbBB10aBaBa0aBd0c2e0dBb2c2kBBk11k0c1b0dBeBc0dBa0aBa1aBB10b2g", "9x15:Ba3bBd3c0d1Bc1eBpB2eB11a1a12fBeBaB00c0gBgBaB21hBf2Bd0hBa", "9x14:f2aB2cBjBBcBa3aB2i2k02gBeBaBBaBaBcBBBBcBaBaBaBb1p2c0Be", "9x15:1B1cBBBr0bBa1b1i1g0Bb2a3bBb2aBa3bBb2a1bBBgBiBb1aBb2r1B1cBBB"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 15;
        LightUpManager.currentLevel = int.Parse(splitLevelName[1]) - 1;
        if (int.Parse(splitLevelName[1]) - 1 == 0)
            LightUpManager.previousLevelID = "empty";
        else
            LightUpManager.previousLevelID = puzzles[int.Parse(splitLevelName[1]) - 2];
        if (int.Parse(splitLevelName[1]) - 1 == 149)
            LightUpManager.nextLevelID = "empty";
        else
            LightUpManager.nextLevelID = puzzles[int.Parse(splitLevelName[1])];
        LightUpManager.LoadGameID(puzzles[int.Parse(splitLevelName[1]) - 1]);
    }

    public void SelectPuzzleByID(int id)
    {
        LightUpManager.currentPack = 15;
        LightUpManager.currentLevel = id;
        if (id == 0)
            LightUpManager.previousLevelID = "empty";
        else
            LightUpManager.previousLevelID = puzzles[id - 1];
        if (id == 149)
            LightUpManager.nextLevelID = "empty";
        else
            LightUpManager.nextLevelID = puzzles[id + 1];
        LightUpManager.LoadGameID(puzzles[id]);
    }
}