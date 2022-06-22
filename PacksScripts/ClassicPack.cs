using UnityEngine;
using UnityEngine.EventSystems;

public class ClassicPack : MonoBehaviour
{
    string[] puzzles =
    {
        "7x7:aBb0b1aBo0i1a3eBb1b", "7x7:iBa1bBaBa1aBg1a0aBa3b0a0i", "7x7:a0B1eBb0h1dB2b0g1BhB", "7x7:1b0hBbBb12c0aBcB1bBb2h1bB", "7x7:a2bBd11bBc1bBg0b1c1b12dBb3a", "7x7:d3cBcBa2sBa0c3cBd", "7x7:aBBe0dBf1g2f1d2eBBa", "7x7:g1Bb3c0cBiBc0aB1b1i", "7x7:cBbBBg2a3bBaBc1a2b2aBg10bBc", "7x7:bBaBc4cBc3a1kBaBcBc2c3aBb", "7x7:g1c1e1b21BdBb21l00a1a", "7x7:BcBdBd0l1b3dBc2dBd", "7x7:hBc2bB1aBBi12a2Bb1c0h", "7x7:a3eBbBhBdBh3a2b0dBe", "7x7:dB2a1f0i2iBfBa02d", "7x7:aBcBd3b2a1mBhBb2a0c1a", "7x7:a0k0c2e1BBe3c0k0a", "7x7:BBc3gBh2cBf2i2bBb", "7x7:e1Bg10cBi2c00gB2e", "7x7:1b0iBbBgBa3eBf1aB1a0aBb", "7x7:hBc4d0c1eBc2d2c1h", "7x7:aBgBc2b2aBBiB0a0b2c2gBa", "7x7:Bk1c3c00hBcBe3aBf", "7x7:a3aBa2hBeBgBe3hBaBaBa", "7x7:1dBe1BeBe2a4e3f1Ba1dBa", "7x7:e1a3b1kBcBk1bBa2e", "7x7:b02r0a1a2r11b", "7x7:g1a1a0aBBeBgBeB2a1a2aBg", "7x7:iBbB1j1d3b02b1cBh", "7x7:a0h0bBh3a0a1hBb0hBa", "8x8:e1dBe2c2a1c2j1c0a1cBe3d0e", "8x8:BBBbBB1j2b0t0b0j00Bb10B", "8x8:c3a1cBBcBe0aBbBg2jBa2bB0cBd1aBb", "8x8:B11hBcBb11e1l1e11b2cBhB1B", "8x8:a0m0b1c2BdBg2e2cBBg1a1f", "8x8:j3iBcBBcBa211c0aBd1e2m", "8x8:i2d0d20c00dBBB1d1Bc0BdBd1i", "8x8:e2c1s2a03aBsBc2e", "8x8:c3za03za1c", "8x8:b0a2mBbBa02n00a2b0m0a0b", "8x8:c21iBcBiBa2eBaBc2k2d10c", "8x8:BaBaB1Bv2c0aBBdBgBc20a1aBbBb", "8x8:h1dBb2aBc1fBd2fBc1a1bBd1h", "8x8:j2bBe22cBfB1fBc20e1b2j", "8x8:a1j00a2j0b1d1b0j0a10j1a", "8x8:aBdBf0c0fBB1j2b3aBn0dBa", "8x8:bBb0e20c1f0c01fBBc1f2cB1eBb0b", "8x8:b2a0d3bBhBmBc2a1eBd0BBi", "8x8:f0bBf1b1i12f1Ba3b0e3l0a", "8x8:2d1g1b2fBs0aBgBg1b", "8x8:2f1cBBeB1B0tBBB1eB2cBfB", "8x8:b2a3mBBa1aBBdBdBd2Ba2aBBmBaBb", "8x8:1eBBdBaBb3a2g1aB3dBdB1h1dBe0b", "8x8:0kBb3l2f4l1bBkB", "8x8:2k0bBgBd3bBBbBdBgBbBk2", "8x8:gBt1bB2cBh4fBbB0Bb1bB", "8x8:b2Bi2cBeBgB0g2e2c2iBBb", "8x8:f1a1eBa01aBe1b2aBbBbBaBaBBa2d2eBgBa", "8x8:d1m1a0BbBaBj3a2b10a0m1d", "8x8:Bb2BbB0f0cB1v11cBf01bB1b1", "9x9:2cB1b1c1bBcBgBf1aBgBa4fBg2c2b0cBbBBcB", "9x9:Bj2eBbBb2g3f0b3cBBbB1Be3d0eBaBBBb2e", "9x9:j2aBaBa3c2a0a3cBeBa1gBa2e2c3a3a3cBaBaBa2j", "9x9:2a2d1Bd1dBb2fBfBi0fBf2b0d1dBBd1a0", "9x9:Ba1bBbBaBe1i2Bc1g0BBg1cB1i3eBaBbBbBa1", "9x9:gBg4dBeBaBaBBbBcBcBcBBgBa1d3a1a2c3bBbBd", "9x9:bBa2d2Be1c1BkBa2oBa3bBBeB0e0c1a1d", "9x9:bBe1j2a2b0cBBaBd0iBBa0e1a2b1mBe1", "9x9:dBBa2c31h2f1bBa0bBe0c1b1aBeBg21iB0aBa", "9x9:g2a3bBBt1BlBdBaBa3a1aBbBe1eB1c", "9x9:BdBg01d3bBc22Bd0c1b1bBc1d001cBbBdB1gBdB", "9x9:b0c3dBf0bBcBBdBaBe4a3e2aBdBBc1bBfBd1c1b", "9x9:b0aBdBi0b2c0c2B2e2Bh0B0dBb0c02j1a2d", "9x9:h1BhBa2a0hBc1b1aBa0b2c1h0a2aBhBBh", "9x9:a0b1b3cBcBbBgBaBa0aBaBk2a1a2aBa0g2bBcBcBb0bBa", "9x9:cBbBaB2c2aBaBa1dBgBb2bBa2hBBcBa01Bd0bBa4bBcBe", "9x9:d1d1h0a1eBe1g0n1cBe2a2j3b", "9x9:1lBa2cBa3a3l0bBaBbBl3a0aBc2aBl1", "9x9:1aBc1aBBbBa0bBc2a0m1eBmBa1c1b1a2b1Ba0c2aB", "9x9:f1c1g1b3c0BeBa0a0aBc2gBaBaBb1cB0a0m1b", "9x9:hB2c1g01Bh2bB1g0BbBhBB0g0cBBh", "9x9:b1bBa0e2b0cBf1gBi1gBf1c2bBeBa3b2b", "9x9:Bb1d2cB1qBbB0a2aBa1a1a10b1qB0c0dBb1", "9x9:aB0dBaBb1dBhBg3k1gBhBd1b2a2dB1a", "9x9:bBc1b0g0d0dBaBc1aBi0aBc0aBd0dBgBb1c1b", "9x9:eBBb0b31fBnBa0a2e1dBbBfBe0b2jB", "9x9:bBa3aBb1bBa3b2bBc2m2cBmBcBb2bBaBbBb1aBa3b", "9x9:jBa0bBBbB1cBiBe0e1i1c22b21bBaBj", "9x9:c0a1c1g1j10cB2c1c2c1Bc1Bj0g0c1a1c", "9x9:a1iB1c01b0001nBa1oB01Be0Bc11a1g", "10x10:a1BbBBBeBa10eBf0bBjB1BiBa000e1gBiBdBc2Ba1d", "10x10:BjBBbBbB2g2f1b0a1b0i02cBpBBcBfB0aBa001a2cB", "10x10:m2b1c1b1b3b00aBa1Ba2a0tBa0aB2aBaB1bBbBb1cBbBm", "10x10:2sBb2c1d2a2cBgBa21B1aBg2c1aBd1c3bBsB", "10x10:bBc0aBBk2aBb1h3a1cBp0c0aBh1b2a1kB2aBc2b", "10x10:aBBe2a2c0d2eBcBl4e2b3eBlBcBeBd0cBaBe1Ba", "10x10:gBaBbBa2a1a3iB2bBi2nBi2b2BiBaBa2a1bBaBg", "10x10:a0Bd2BfBj2B1aBBB1zB100lBB1f0e2Bd0Ba", "10x10:a01cBb0bBi11f1h1fBa0Bf1a1B1h1bB2hBhBBc1bB", "10x10:a0aBbBa3dBbBc3hBaBf1c1d2d1dBcBf1aBhBcBb1d0aBb0a2a", "10x10:BBfBdBb0dBb2bBe2c1y2cBc3b3b1eBb0cB2fBa", "10x10:a2fBo2Bd1a0d4aBc1bBfBbBc2aBd1a2dB1oBf1a", "10x10:m2bBe2d3c1aB11BaBb0f1b0fBb2aB1BBa1c4dBe2bBm", "10x10:b1aBj3g0b4bBbBdBc1bBBcB0c0Bb4c3dBb0bBb2g2j1a0b", "10x10:c1BBa2bBoBb1a2bBa2pBaBd1c2g0dBa1a2BbB2a1cB0bBc", "10x10:bBeBa0c2a00c0g0a0b0k2aBbBa2k0bBa0g1cBBa1cBaBe1b", "10x10:b2bBa2a00bBeBb2aB1Bj0c0BaBj2aB0c1jBBBa3bBe2bB1aBa3bBb", "10x10:b1bBaBa0c0BBBlBa0k0dBa1d3e1BBdBgBaB2bB1d3b2h", "10x10:0c0Bc2m2b1c2cB0cBbBdBdBd1b2cB1c2cBb0mBc11cB", "10x10:aBdBc2d3a1a1c1bB1d2l1bBfBb0c1j1bBBb2d3aBa2a1d2c", "10x10:aBiBa12BaBBBa0p0bBf0bBf0b1p0aBB2aB1Ba0iBa", "10x10:cBc0l2bBBaBe2b3a2a0cBc1dBc3cBaBa1bBe2aB2b2l1c0c", "10x10:bBb1d2h2e1BaBi1BbBh0bBbBBc1b0b1bBa1a11lBaBdB1b", "10x10:c0b2e1BbB2mB0d0BcBdBdBdBc2Bd11mB1bB1eBb1c", "10x10:g0b1BcBcBf2aBa1a4dBBbBiBhBaBdB2g4aBa11cBcBg0b", "10x10:aBaBb0fB2aB2c3f3d0cBbBi1lBc2cBfBdB2aB2cBaBbBc", "10x10:h1aBc2aB0c0bBfBc0g1cB1bB0cBg1cBf0b2c12aBc2aBh", "10x10:1gBaBc2c0BBcB1i1BaBaBcBaBcBgBc1b0iBa4bBb2BmBa", "10x10:hBcB0aBcBBf2d10cBb0d1hBd2bBc0Bd0f32c1aBBc1h", "10x10:B2aBkBaBa3fBe1Bj2jBj02e1f2aBa1kBaBB", "11x11:dBfBa2vBb2b1a3b1iBa1l1b00eBbBB1Ba1i1bBa2eB2h", "11x11:e0c1a1c1BaBo0aBc2lBa01cBc11aBl2cBaBo3aB2cBa2cBe", "11x11:d1dBa2bBaBa0o2b1d4hBb3aBg2aBb1hBd1b1o3aBaBb1a0dBd", "11x11:BaBBb2eBf0aBh1eBg00aBBBaBb3k00aBB0a1bBcBo0cBf0a2BaB1bBd", "11x11:b1d01BaBb2aBe1aBc1aBaBBdBcBc2i2aBcBa2iBcBcBdBBa4a1cBaBe2aBbBaBBBd2b", "11x11:aBbBdBc1eBb0hBaBc1c2c0f0cBc3a2b1kBb2fBi1gBb1b2b1f", "11x11:aBdBbBbBfB2a1b0b0BBe3b2bBcBaBiBdBaBb3aBi1b1b2a2bBbBB2cBfB2b1d2bBa", "11x11:dBbBdBb1aB0c11c0c1b1o0e1o0eBi2Bc2c1bBbBa2BgBb1c", "11x11:fBe3eBa2B2BcBg1c2BaBaBaBa1gBg1g0aBaBa4aBBcBg2cB101a1eBe2f", "11x11:aBaBBaBBcBf1a3b4eB1eBBgBaBa1e0b1aBc0h0aBBdBd0d0Bg0cBaBBdBBBbBb0", "11x11:1dBb1BgBc1c11Bg0mBb1bBBBBc1BBBbBb3m2gB1Bc2c0g2BbBdB", "11x11:1bBd2dB2eBjB1aBj3aBb0aBb3cBa1cBb0a0b1a3jBa1BjBeB1d1d2bB", "11x11:bBe1d3eBbBcBa0cBbBa0aBaBb2BaBa1a2aBBkBBa3aBaBaBBbBaBa2aBbBc1aBcBbBe2d1eBb", "11x11:bBd1h1a10bBb1bBl1a0b0f1a2l00e2aBe0fBgB3aBbBBBBfBB0cB", "11x11:aBa2hBaBaBaB1BBaBgBb0dBgBb2BqBBbBg2d1bBg1a1BBBa1aBaBhBaBa", "11x11:BaBdBb0c0bBnBBb11b0a1b2e1q1e1bBa1b1BbBBn0b2c1b1dBaB", "11x11:cBk1a0cBaB3aBb2c0dBbBg0eBi2e1gBb1d2c2bBa1Ba0c1aBk0c", "11x11:a0bB0b0c0zaBaBa0BcBBs10cB1a0aBza2c2bBBbBa", "11x11:a1bBa1bBbBg1f0g0eBe1cBe3e3e2c2eBeBg1f1g1bBb1a2bBa", "11x11:d1bBbBdBeBaB1c2dBh4kBf0bBkB3hBb3BcBh1eBdBb0bB", "11x11:BbBaBcBc2bBB1a2f0c1b1hBa0f1lBa2f1cBhBe1cBcBbB02a2a0bBaBcBa", "11x11:d0B0p1b2a2b2cBbBb2c2gBbBc2cBbBg2cBb2b3c0b1a1b2pB0Bd", "11x11:aBBa0a1aB1nBbBb1eBcBfBc1d1c4cBd1cBfBcBe1bBbBn10aBa1aB1a", "11x11:hBc2cBb1BaB1cBtB2BeBBaBa2a22e1B1tBcBBa21bBc0cBh", "11x11:hB0aB1bB2bB0cBBb2dBc1Bd2gBeBd1c0d1aBc0rB0b1a4bBeBe2bB", "11x11:bBbBb0cBd2k0bBd2b0fB0BgBeBh0bBe0BeB2dB2BgBBdB0a2a2cBa", "11x11:m2BB2kBb2g2bBc10eBb0g1b1e1BcBb0g0b1k2BBBm", "11x11:b1a2dBfBhBaBaBd0l1c1cB2h1cBcBd1lBaBa1hBg2a2d3a", "11x11:b2e1nB01c111aBi12iBbBe2bBiB0iBa1BBc0B2n1eBb", "11x11:cBaBa3cBa2e4aBaBgBd1c1dBgBm0g2d1cBdBgBa3aBe1aBc0aBa0c"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 0;
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
        LightUpManager.currentPack = 0;
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