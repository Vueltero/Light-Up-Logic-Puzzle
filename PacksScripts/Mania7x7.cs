using UnityEngine;
using UnityEngine.EventSystems;

public class Mania7x7 : MonoBehaviour
{
    string[] puzzles =
    {
        "7x7:aBb0hBBs13h0b1a", "7x7:a0c2hBeBaBc3a2eBh1cBa", "7x7:0c0aBg1s3gBa1cB", "7x7:bBaBi2bBb1bBB3bBbBb1iBaBb", "7x7:0e1bBa0d1a1k0a2d2aBb0eB", "7x7:l2c11a1b1cBb1a3Bc0l", "7x7:a1k1c2e2a3e1cBk2a", "7x7:a1b0mBa0a3Bh2fBg2a", "7x7:0iBc1c3b1aBi0a1j0b", "7x7:g1eBBa1a0a1g1a1a2aBBeBg", "7x7:a2cBBg0h0lBc3Bb0d", "7x7:g1a1h001kB103aBk", "7x7:h0cBd4e3aBe4d0c0h", "7x7:bBd2f1B1b1gBk2b1f", "7x7:1a1b0BfBd0hBd1hB0a1bBB", "7x7:d2c3Bb2aBd1i2d0aBbBBcBd", "7x7:d1d0dBdBf2a0d0c0hBb", "7x7:c1e1g1aBa1a2aBa0a3a2g0eBc", "7x7:c1k2cBc4aBc2c0k1c", "7x7:aB2aBBh1e1gBeBhBBaB2a", "7x7:aBa10b2gBq1g2b2Ba1a", "7x7:g2e1a3c1d2d2cBa0e2g", "7x7:g1BcBa01aBbBg2b0a00aBcBBg", "7x7:bBbBgBaBa3BBiBaBB2gBb0bBa", "7x7:b2aBc1a1h2d2b2eBbBaBeBa3b", "7x7:d3i1b2e3aBe3b0i0d", "7x7:a1Bb0k0j1b3cBaBa4i", "7x7:g0eBc2j1h2aBa2B0e", "7x7:dBaB2e0b1f00Bf2b0e0BaBd", "7x7:1eBd2iBc1b2a1b2lBb", "7x7:bBa0b0a0aBa3uBa1a0aBb0aBb", "7x7:BbBb2h3cBi1c0hBb0bB", "7x7:2bBf1a0bBgBa2cBh1a2aBbBc", "7x7:fBa00g0a2k1aBbB0j2", "7x7:l1aBg2c1BBBb0Be2b2aBd", "7x7:i1BaBg1b2a0bBgBa00i", "7x7:b12d1c0e1k1eBcBd00b", "7x7:aBcBbBhBb3j0bBa2f0c0a", "7x7:1e0gBd2i2dBg2eB", "7x7:aBdB1d3e2c02h1bBdBb1d1", "7x7:bBaBBfBc1o0c1f11a2b", "7x7:2bBb0cBBd1fBf1gB3bBbBbB", "7x7:b3eBdBj0b0h3d0b2d", "7x7:e1a3h2aBk2a1h0aBe", "7x7:aBn1j3cBa3a3cBe0bB", "7x7:BaBc1e10cBe2i0a2hB1aBa", "7x7:a0iBa2a2q2a2a0iBa", "7x7:a3bBiB10c2dBbBB1c2hBbBb", "7x7:aBb0a0k2eBbBc1iBb3d", "7x7:b3aBjBcBdBd0c0j1a2b", "7x7:bBaBc2cBbBcBiBc2bBc2c3aBb", "7x7:a1BeBc2Bf0c0c0fB1c0e11a", "7x7:b0Bh0cB0cBcBdB1h2c2Bc", "7x7:BeBd0c2q2cBd1e2", "7x7:h11aBBj0a2j00a0Bh", "7x7:b1a3g3a1b1g2aB1b1h0c1aBb", "7x7:iBb1bBBf3a3fB1b1b1i", "7x7:0c2hBd2cBc0c2dBhBc1", "7x7:Bc3g3b0BlB0i0a0cBb", "7x7:e2aBa2iBd2d0i2aBa2e", "7x7:k1a02iB0b2j2a0g", "7x7:hBa10BaBfBa3a3aBfBaB1BaBh", "7x7:e1a12cBw1c3BaBe", "7x7:a1bBeBa3c2m2g1aBb0bBb", "7x7:b0i4bBbBc2cBc3bBb3iBb", "7x7:b1a0i0aBaBaBg2aBa0a1i1a1b", "7x7:l0Bc0bBa4aBc2c2g3h", "7x7:c1b2BbBfBaBd1c2o2d", "7x7:Bf1b0cBaBo0a1c2bBfB", "7x7:h1a3a2jBa1j2a4aBh", "7x7:bBaBaB0k3i0k11a1a0b", "7x7:iBc111k010g2cBg", "7x7:bB0Bi0b3m2b1i1BBb", "7x7:b2kBd3Bc0c2BdBk0b", "7x7:f0a0c2oB1BgBb21f", "7x7:gBa0a2aBbBa1kBa0b2aBa1a1g", "7x7:aBfBb0d1aBkBa3c2b0c0e", "7x7:01fBa1a1iB1f2cBBkBB", "7x7:iBaBb0b0bBg0b3b1bBa2i", "7x7:bBaBb2b3bBuBb1b1b2a2b", "7x7:b0aBa0dBd2d1Bc20dBdBdBa0a0b", "7x7:2aBaBaBoBc4o1aBa1aB", "7x7:0a0c0m2g0m1c1aB", "7x7:hBBa2BbBc3cBa4c2cBb0Ba10h", "7x7:a1g012d1b3a0e2aBb0dB1BgBa", "7x7:1a1g1iBBe12i2gBaB", "7x7:aBBd1c1g0a10a1BhBBe2g", "7x7:c1b1f1Bi2c0a3m1cB", "7x7:aBa2b12bB2d0m1dBbBBc3aBbB", "7x7:b0a1i3eBbBa0bBeBi0a1b", "7x7:BBdBfBb1a4e3eBa2bBf0d00", "7x7:0fBd0b20fBa1c1Bd0d4aBf", "7x7:b2aBbBoBa0o0b2a1b", "7x7:aBb2h00b2eBa2e1b12hBb1a", "7x7:cBd01b0e2q2b2d2cB", "7x7:b0eBb1c1cB2i0b2lBb", "7x7:i4e2bBdBc0aBb2dBk", "7x7:1eBdBc01a1kBa31c0d1e0", "7x7:Be1j3eBBBe2j1e1", "7x7:aBcBhBa3a2a1gBa0a0a1h1cBa", "7x7:bBaBBh2c2i0c2kBa01a", "7x7:a2c2hBe1a3c2aBe1hBc2a", "7x7:h4b2dBdB3c1BdBdBb1h", "7x7:e0aBb3BoBg3bB1gBa", "7x7:a1fBc2bB2a1hBa00aBcBc3bBe", "7x7:1Bd1fBb1aBk0aBbBf1dB1", "7x7:h2bBeBa0c3c1j3dBbBb", "7x7:g1e2aB0a2BiB1a1BaBeBg", "7x7:a2c1a1dBa1e1eBc1bBa1d3cBd", "7x7:0aBBaB1c1iBgBiBcB2aB0a1", "7x7:h2d3BbBa2i3a2b2BdBh", "7x7:a1aBa1h1eBaBb1b1e2h1a2aBa", "7x7:B1a1bBgBcBbBf2c2iBBaBbB", "7x7:f2bBBk02aB1k11bBf", "7x7:bBbBa3lBgBl1aBb3b", "7x7:b3aBbBBc2BuB2cB0bBa1b", "7x7:b2aBj0cBc1aBcBcBj2a0b", "7x7:gBaBaBa2a0c3iBcBa1a1aBa2g", "7x7:h0bB2b0h0hBb3BbBh", "7x7:1c1aBa2eBs2e2a2aBc2", "7x7:hBb3g3BBa2aBa21BgBb0h", "7x7:1e11bBe1mBdBb4cBeB", "7x7:b3b1fBaBc2kBc1a1fBbBb", "7x7:cBaBa2a2b2aB1eBgBc2a2kBa", "7x7:c2a3gBhBBa01hBg2a0c", "7x7:b0Bd1b0a0nBeBBb1cBb0b0", "7x7:j2d2dBeBd2f100gB", "7x7:a2cBa1e2b2aBk0aBb1eBaBc3a", "7x7:aBcBaBa1c3eBi3eBcBaBa1cBa", "7x7:1e0B1b2dBcBBeBf1a2f1e", "7x7:d1cBd3g1eBg2d3cBd", "7x7:f0b3b1bBcBbBf1c3bBb2d1cB", "7x7:bBe1a1eBcBe3j2d1cBb", "7x7:bBaBb2e2b0aBk2aBb0e2bBaBb", "7x7:b1b3a1lBcBcBlBa0b0b", "7x7:BaBc0j4bBbBa3b3b2jBc1aB", "7x7:1j3b00aBc0dBeBaBb1d0e0", "7x7:aBBaBBh1aBa1aBgBa3aBaBhBBaB0a", "7x7:a1a2BhBh0c4eBa3b2k", "7x7:b0c0a1i0bBe1h3b0hB", "7x7:c3gBc2eBbBb2e3c2gBc", "7x7:1e1cBfBd2Ba31dBf2cBeB", "7x7:a0aBg3aBbBm2hBa2a2a2c", "7x7:bBaBi0a2aBa0g1aBaBa2i1aBb", "7x7:h2a3a0i0cBi1a0a2h", "7x7:a2c1iB0aB0iBBa0BiBc3a", "7x7:a2lBaBe22aB3e2aBlBa", "7x7:b1aBcBc3cBaBk2a2c4cBcBa1b", "7x7:BBc2Bb0BiBm2b10c1BcBB", "7x7:a2bBh3BsB3h1bBa"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 1;
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
        LightUpManager.currentPack = 1;
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