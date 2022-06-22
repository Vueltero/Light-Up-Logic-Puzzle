using UnityEngine;
using UnityEngine.EventSystems;

public class KidsPack : MonoBehaviour
{
    string[] puzzles =
    {
        "4x4:eB2b00e", "4x4:e0Bg3a", "4x4:1f1c2Bc", "4x4:bBa3fBa0b", "4x4:b0j3b", "4x4:e1c3f", "4x4:e21b0Be", "4x4:a0BjB2a", "4x4:a2a0c1h", "4x4:b2b4j", "4x4:i30e", "4x4:e31i", "4x4:a0BjB2a", "4x4:f4b2f", "4x4:eB2b2Be", "4x4:e4d4e", "4x4:e2BbB2e", "4x4:e0d2e", "4x4:e1c3f", "4x4:f3c1e", "4x4:dBb2Bb1d", "4x4:aBBj12a", "4x4:f3c1e", "4x4:eB0b12e", "4x4:eB1b02e", "4x4:e4d4e", "4x4:dBb02bBd", "4x4:d3e2aBc", "4x4:e02b0Be", "4x4:e4d2e", "4x4:e3c0f", "4x4:e0c3f", "4x4:a3aBiBaB", "4x4:bBa0f3aBb", "4x4:eB0b21e", "4x4:d3f0d", "4x4:2bBhBb2", "4x4:e4d2e", "4x4:e1c3f", "4x4:b1a3k", "4x4:b1j3b", "4x4:eB0b12e", "4x4:b0aBfBa0b", "4x4:e3c1f", "4x4:b0aBfBa3b", "4x4:aBe31eBa", "4x4:h3e0a", "4x4:bBg4e", "4x4:e21b1Be", "4x4:f1c3e", "4x4:a12jBBa", "4x4:e4d2e", "4x4:b3aBfBa1b", "4x4:e2BbB2e", "4x4:f2b0f", "4x4:f4hB", "4x4:2a2l1", "4x4:e4d2e", "4x4:c0h2c", "4x4:1f1c00c", "5x5:k2a0b2h", "5x5:g4b0fBg", "5x5:g4i2g", "5x5:a011q0B1a", "5x5:bBg1cBg3b", "5x5:dBf2d2fB1", "5x5:Bf2i2b2d", "5x5:g3cBa2c4g", "5x5:fBa4g2aBf", "5x5:b0gBaBa3g0b", "5x5:bBb3cBiBb2b", "5x5:b1fBa0gBb3b", "5x5:2eBk2e0", "5x5:f3a0g3aBf", "5x5:g3c1BBc2g", "5x5:aBBk3aBc2d", "5x5:bBBb3iBe21a", "5x5:g2i4g", "5x5:2cBoBc2", "5x5:gBc4a3c2g", "5x5:d2f2c1i", "5x5:0bBe2iBBb3a", "5x5:a1gBe3gBa", "5x5:aBa1aBc2eBcBa1a1a", "5x5:cBa3m0a0c", "5x5:dBb0a0e0a2g", "5x5:g0f3b2g", "5x5:b3b0b3gBbBb2b", "5x5:e3cBeBc2e", "5x5:f3a3gBa0f", "5x5:Ba3cBb1f0h", "5x5:c1a2i0gBa", "5x5:1a0d1i0d1aB", "5x5:f3aBg0a3f", "5x5:a1gBe3gBa", "5x5:a3fBi3f", "5x5:fBb2bBc2b3e", "5x5:a2u3a", "5x5:a1a2aBcBe3cBaBaBa", "5x5:g4cBa3c1g", "5x5:bBe1e01h1", "5x5:g01h22f", "5x5:g0Bg30g", "5x5:e2c1e3cBe", "5x5:fBa4g0a2f", "5x5:dBc0d1d0c1b", "5x5:b3f0iBbBb", "5x5:iBa02Ba1i", "5x5:2cBoBc2", "5x5:f4aBc2cBaBf", "5x5:2aBdBj3dBa", "5x5:b1cBbBfBb1b0b", "5x5:0b1q0b2", "5x5:2cBoBc2", "5x5:Bc2o2cB", "5x5:f1e2g2d", "5x5:a3bBdBi2aBbB", "5x5:hBb1a1b3h", "5x5:a2aBqBa3a", "5x5:c0a0m3aBc"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 24;
        LightUpManager.currentLevel = int.Parse(splitLevelName[1]) - 1;
        if (int.Parse(splitLevelName[1]) - 1 == 0)
            LightUpManager.previousLevelID = "empty";
        else
            LightUpManager.previousLevelID = puzzles[int.Parse(splitLevelName[1]) - 2];
        if (int.Parse(splitLevelName[1]) - 1 == 119)
            LightUpManager.nextLevelID = "empty";
        else
            LightUpManager.nextLevelID = puzzles[int.Parse(splitLevelName[1])];
        LightUpManager.LoadGameID(puzzles[int.Parse(splitLevelName[1]) - 1]);
    }

    public void SelectPuzzleByID(int id)
    {
        LightUpManager.currentPack = 24;
        LightUpManager.currentLevel = id;
        if (id == 0)
            LightUpManager.previousLevelID = "empty";
        else
            LightUpManager.previousLevelID = puzzles[id - 1];
        if (id == 119)
            LightUpManager.nextLevelID = "empty";
        else
            LightUpManager.nextLevelID = puzzles[id + 1];
        LightUpManager.LoadGameID(puzzles[id]);
    }
}