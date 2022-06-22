﻿using UnityEngine;
using UnityEngine.EventSystems;

public class JumboRectangle : MonoBehaviour
{
    string[] puzzles =
    {
        "14x16:dBa2Bc2cBb1gBBa1bBBa1BaBeBb2c2a0BgBf0n1BaB1g1g0a1c2bBeBaB0fBcBeB1e1aBBaBb1b0h0qBd1a2cBa0a1B0aBc1j1a2c", "14x16:bBa2a1aBcB1Be1jBiBb2BBb0eBbBaBd0a2bBa2aB0cBgBBBbB1a2eBc2aBbBg1bBaBBBd3BkBfBa3mBg1bBa3g0mBBBBd1c1Bi", "14x16:e1bBe0c10bB1cBn1b1BBb1B1bB1aBh1a2a1aBa0bBaBaBg11zn2BgBaBaBbBa1a1aBa0hBa11bBBBb111bBn1c0BbB0cBeBb1e", "14x16:bBhBc2aBbBcBB2aBaB1a1a1eBaBdBc20bBBdBa2bBa1bBvBa2e2BBaBeBd0bBa1aBb1cBbBaBaBcBf0f2a00aB0cBb2cBa1bBBBfBBbBb21dBe2BaB0Be1e", "14x16:hBcBj01Bb0aB3cBBcB0Bc2b1c1a1gBB0dB2a10aBn1Bf1BBeBa1Bb1B2eBaB0hBBe0BaBBa0nBBBd1c1b1c1aBBaB1cB2c0BiB1BjBc1a", "14x16:dBBaBa3e21BbBfBBa1b3bBB11aBBcBcBi1cBp1b2BBdBaBb2bB1d1dBbBBb0B1e1iBdBaB0cB0eB1bB01fBfBBo1bBd1BbBBdBa2BaBB1aBc2a", "14x16:BaB1a1a0dBBB1fBa3a1b1e1fBhBd1cBaBb2bB0BaBBeBBcB1d1hBd0fBa2B1cBBBa2f0aB1cBaBd21fBb0d2dB2e11aBeB0lBaBB0c0aBaBaBfBdBb", "14x16:BbBb00bBbBa10hB0rB1a0Ba1Bc0dBbBd2b2bBbBbBf1d1fBbB0BBbBdBb1B01b1fBdBfBbBb1b0b1d2bBdBc11a1Ba21r11h0Ba1b1b11b1b2", "14x16:2aB1aBBb1pBbBaBcBaB1eBcBe0BBc2hBb1hBBkBb1bB0c1cBdBc0c0Bb1b2kBBhBbBh1c0BBeBc4e1BaBc2aBb2pBbB0aBBaB", "14x16:bBa1aBf13aBa0b10a00c2aBhBBaBcBBBBc1aBBk1cBa1eBf2Bc2cBc3fBb12c2BeBBeBaB1dBd0Bc1Be2BbBd2fBeBa0bBbBe2eBaB1aB1g00fB0b0", "14x16:1bBBaBa1a2c1Bj0d1d00eBBcBdBe2BfBa30a3bB1BBa0iBc0b2bBcB0h1c1BlBc0bB0a2bBBB0aBfB0fBa2aB2cBdBeBd11dB1jBa1bBBa3aBa1c", "14x16:0hB0a0cBcBa1cBe3aBBbBbBeB2aBaB1c0hBBaBa0cBb1aBbBaB002cBBb3a1dBBb0cB0d2BbBcBaBBB2cB1bBb0cBb0aBbBaBhBBaBe1BaBaB1f3a1Bb0bBbBcBa3c2a0hBBaBa", "14x16:b1BbB0bBBeBfBeBhBb1l1b0BBdBB1f1a11aBd0b1fBb2a0bBaBBa1bBbBbBaB0a1b3a3b1fBbBdBaB1a2fBBBdB2Bb1l1bBhBe1fBeB1b1Bb11b", "14x16:b2c0h2h3h0b1bBb1f3g0d2aBiBa0a0a2c3bBBa0dBdBgBBqBf1aBcBc1bBBaBb2dB0eBcBa3aBbBa0bBBgBaBBb0aBd4bBbBbBbBBcBa1a", "14x16:aBcBcB2bBb2i0a2eBcBeBhBdBd1aBbB0b12BBaBgBd1e4aBaB1fBbBzBb2h0Ba0f0gBBd2fBB1a1cB2aBbBg3aBb4c0BdBBaBaB", "14x16:aBbBaBBa3bBaBlBaB1hB0e2Bb0Be2cBb0cBfBb0eBaBh3aBd1d2hBdBd1aBhBaBe2b1fBcBb0c3e11bBBe1BhBBa1lBaBb1aBBa2bBa", "14x16:nBaBb0bBb0aBbBaB0b0Ba0pBbBaB01BaBbB1l0dB1b10dBlBBl1d2Bb0BdBlBBb1a2BB2aBbBpBaBBbBBaBb0aBb3b1b1aBn", "14x16:bBBeBa1dBa2a2b2d2Be0dB0cB0Bc0aBs0b1dBBBBBBb1gBBgBaB1BaBgBa1B2aBB1bBgBc1b1dBBBqBB0cBa1bB3e0dBBbBa2a1b3fB1eBa0b", "14x16:B0bBBcBBhBbBa1c2aBbBeB1cB0dB2eBaBBdB3bBaB1BaBa4aBc0fBaBb1bBb000fBaBbBBBf0g1a2bBc1BBa1a2aBc0a3aB1dB1bBbBBd10dBa0bBeB1f0b2a2cB0bBBcBBc", "14x16:e2bBg0Be2d0fBn2aBpBe1aBd2bBdB0aB2d2b0dBBbBBeBa20a1c0cBf2cBaBb0h12Be1BaBjBaBBBBm1aBa4aBa0a0bBBbBbBeB", "14x16:iBd0bBBB2aBa2eBh0h3d1d0a1eBb0eBdBa0BfBe1b2bBBc012d3BBc2Bb2b2e2fBBa0dBe0b1e2aBd1dBh1h4e2aBa0002b0d1i", "14x16:Bg0e2b00Bb0b1aBa2d2aB1eBb1a1BfBgBBc2e1aBbBhBa0hBeBa3bBa3aBbBB1bBlB1BBBBb0cBl2fB0h1iB0b110B11BBBBaBdBeBaBBaBc1", "14x16:BlBBa2aBaBBa2aBaBB2jBBBlBBcBdBc1e0bBf1BaBd2aB0c1b1b1bBd1bBb1b2c1Ba1dBa01fBb2e0cBdBc0BlBBBjBB0aBaBa2Ba0aBaBBlB", "14x16:b2aBB2a1bB1bBeBc1BaBBaBaBcBcBb4fBlBb2d1Bd1BeBc0Bg1aBBaBb1e0aBBaBbBfBcB1i10dBBlBbBdBfBd2Ba4a2c2cBaBeBcB1cBaBBBaBbBBa", "14x16:a3aBBbB2a2fBbBbBBBaB1BgBBa3BbBb3dBcBaBaBBb0BaBjB2b0bBd2h2i1bBc1aBBaBbBbBcBg1e1f21aB2eBBd0BcBaBiBc1dBcBb0bBaB0Bc1eBa1c", "14x16:b0b3aBBbBBeBb2g00aBdBeBbB1e1bBeBB00cBB0c1BgBf0dBa1aB0cBl2cB2a2a1dBfBgB1cBB3c1BBBe1b1eB1bBe2d0aB2gBb1eB1b0BaBbBb", "14x16:BBdBcBcBa3gBa3eBBbBbBBBBaBeBa2bB1g1aBfBh3Bb12dBaBcBaBgBbBBbBgBa1c2a2dBBb1BhBfBaBgBBbBaBe2a1BB1bBb1BeBaBgBaBcBcBd1B", "14x16:0aBb1a3cBaBdBc2a1e0a2aBdBp1cBbBBbBa2cBBBa2h1BBr1aBd1a0r0B1h1aBB2cBa0b10bBcBpBd1a0aBeBa0cBdBa1c0aBbBa1", "14x16:Bg0d1b1gBg11a0Bc122aBf0h01a0f1BbBaBB1hBb1gBg10h2BgBgBbBhB1BaBb11f0a1Bh0fBaB0BcBBaBBgBg2b1d1gB", "14x16:bBaBBcBd0cBa1Be2eBa1aBaBBBc2iBaBBBkBh21aBgBc2c2d0aBcBg2a0Bg1a2dB11a1d0f01b01aBBBB0eBb1b2eBcBcBbBb1Bb0BBbBe0b0BbBc2b", "15x17:gBBa2dBBaB1b1aBd1kBbBBBb2e3cBh1b3l0BbBBBaBe1a1a0eBb1BBdBBa0bB2aBdBBdBbBBBd1B3a1eBa2aBkBBbB1h3b1cBBb0e1cBkBbBB1a01b1a1dBgBBa2d", "15x17:e1c1uBa2bBaBbBa2aBaBdBd3aBaBbBaBaBa1b3h2iBi1bB2e0e1BaBB2g00BaBBeBeBBb0iBi1hBbBaBa2a2b2a3aBd2dBaBa4aBb0aBb2a2uBcBe", "15x17:oBBkBBaBb1a1a2a2b2b3cBBaBBcBc2bBBaBBbBbBBb1e0b1BoBbBbBa1bBbBfBa2fBb2b0aBb1b1o0Bb1eBbBBbBb00aBBb1c2c1BaB2cBbBbBaBaBa2b1aBBkB2o", "15x17:d1c00aBaBc110g1f0Bc1aBiBe3aBaBe0cBaBa2b0b1bB0a2BB1BaBd1gBaBb0bBdBcB1e1BbBb2c1bBcBa1cBe3c3aBeBd0cBBB0b2bBf2cBd2aB1cBa1BBdBBg0i0d1cB0b1", "15x17:dBb0fBB0bBaBf0e1Bb1a0BcBaBBgBbBh2bBaBBB3aBaBcBa2eBBBBa2h10bBaBeBBaBc1bBc00aBbBa1BeBeBa2aBB1Ba0aB0aBaBf1lBBcBB11bBaBaBbBBbBBkBbBB2a11cBBBa1a2aBd0aB1b", "15x17:bBi0Bb3bBb2e1Bd3cBb2bBa1a3aBg2cBd0bB1bBBfBbBaBiBf0b2Bl1c0a0aBc1l01b1f1iBa1bBfBBb10bBd3c4g0a2a4aBb0b1cBdBBe2bBbBbBBiBb", "15x17:bBk1bBd1a0BaBBBa2aBe0aBd0c001f2Bb1aBaBk1fBbBb2eBeBcB0jBd0a1aBdBj02c1e1eBbBb1f2k2aBaBbB0fBB1c2d1a0e0a2aBBBa2Ba2dBbBkBb", "15x17:2cBc1a1cBb0j1BcBd0b2m2eBiBaBi2iBa2g2bBaBb0aBdBaBbBdBgBa1g1eBd3aBaBBBdBaBBa2c1cB2c1aBc1b2bBbBBBc0Ba1bBf1g0c3b1eBBcBf0a", "15x17:1f1eBBd0bBc001kBa0d2d0dBbBbBb2aBdBBa2f0c2a21BcBe0e11f0BaBbBBaB0aB01gBBfB2a1aB1c0eBd3fBcBaBBbBb2a1d1BbBd1d1lBaBf2b1c012aBf0eBB", "15x17:f1cBb2fBbBc2b0a2bBbBdBkB2aBdBa0b0bBb1a2c2fBfBBbBa1c3aBfBa1BhBa1aBh21a0f0a0c1a1b02fBfBcBaBb2bBb1aBd1aBBkBdBbBb2a2b1c1bBfBb1c0f", "15x17:fBaBh0b0aBa2bBbBa1d1d2aBB1kBBdBeBdBa2Bg2BaBbB0bBaBb1Bc0k0a10bBbBbBbBBaBk2cB0b0a2bBBb2aB0gBBa0d1eBdBBk1BBa2dBdBa1b1bBaBaBb1hBaBf", "15x17:BBiBaBBe1c0g0Bc0d1f1aBb02cBfBbBd1aB00d0Ba2bBa1aBBf1Bj1aBd0a1iBaBd2aBjB1f2BaBaBb0aBBdBB2aBd0bBfBcB1b0a1f2dBcBBgBc0e01aBi1B", "15x17:aBaBBaBBb0oBB3aBbBb1gB0hBaBdBbBBBBbBcBc0BjBc2c1g3cBb1a2b0BcB1aBaBaB1c1BbBa0b4c1gBcBc1jBBc1c1b0BBBb2d2a2h10gBb3bBaBB0oBbBBaBBaBa", "15x17:dBBa1c2BcBcBfBaBa3b1BhBBa2bBa1a0d2cB1lBbBcBaBfB2lBBaBb2dB1a1aB2a1bBeBcBa0bBg0dBBB1cBbBkBgB2b1c2Bc1eBBa1aB2cBaBaBa2bB1eBc4cBaBa0b2bBa2aB", "15x17:bBb1a1f0cBaBe2e3Bb3bBc0fBb1bBeBb1a0BbBaBbBBbBfBBbB1BnBc1aBaBa0BcBb1Ba1aBfBcBa0a2aBBa1B1l1BbBf11cBb0a10b1aBf1bBb1e3Bb2b2c2dBa1e1eBbBa1fB", "15x17:fBa2gB3bBcBbBBaBcBe3cBBaBb3cBbBaBcBBBcBBBf0aBaBa2a1f1gBc2aBcBaBc1a2bBc1aBcBbBa2c1a0cBa3c1gBfBa0aBa2a1f0B1cB2Bc0aBbBcBbBaBBc1e1cBa2BbBcBbB2gBaBf", "15x17:c10d0aBeBa0d1d0aBcBB1b3eBBb2aBfB1dBBB2aBb3c2h1f1BaBaBf2c1bB00bBaBa1k2aBcBb2BBbBa3c0Ba2aBhBhBc2d1BB0a1bBbB2bBaBf0aBc1B1bBf2aBd0dBcBBd2a2c", "15x17:b0pBc2a2a2e2a0d0dBa1d1aBc1g1b1eBa0a1eB0a2bBc2aBcBe1f1aBdBa21c1aBa21Bd11oBcBBc1dBaBb1oB1bBf2aB1g1a02BaBdBb2dBmBb2a1aBa", "15x17:hBd0Bb2BBBBBBb2a0B1Ba1bBfBaBaBBfBa1aBa3c01e0f1aBa0aBa1d1c2fBaBk2c11B0B0B0dBa2k1d1c0f0eBaBa3a0aBcBcB1eBbBa2Bf0aBaB1BaBbBf1c1010001b2a1BhBdBB", "15x17:cBBe0Bd20c3aBc00sBbBaBb1c0cB1cBBc0f0BBf1B2aBBc0Ba00BaBb0e2bBgBB0g2bBe2bBaB01a0BcBBaBB0f112f0cBBcBBcBc0b2aBb3s2BcBa0cB2dB0eBBc", "15x17:a0b3a2aBc1mBd0BcBaBb3a2Ba1a2e2BaBB1fBdBeBBaBaBc0e0f0cBa2e0k0iBaBbBf0b2aBg1pBBBaBBb2cBjBa1c3aBBdBeBaBc0a0g2h0bBBc3bB", "15x17:Ba2aB1fBcBf1dBaBkB2eBB2a0a1BBaB0BaBcB0bBaBh1k2BbBaB0hBe0a3c1BbBaBBaBfB2d1cBa2gBc2c1bBBcBhBBdBbBaBe4dBB2cBBfBBd3dBdBaBcBb1bB0bBBaB", "15x17:a3a2c0aBbBBBb3b1a2a2aBaBaB1fBBh2k1aBaBB1BBBBa0a1BgBbBe1eB2aBcBdBB2c2bB1Bc3bBBbBB1a1aBBdBbBdBaBdBa1eB2cBbBBbBcBbBeBBaBB3aBdBa2cBfBbBa3a12cBb3dBdBaBeBBBb", "15x17:b1b0BaBdBdBa0c0c0gBBcBaBdBg001b1bBa1bBc1h2bBcBa1BBBc2eBaBBc2bBc0e20a2bBg1BhBb0c2aBaBc1bBBa4cBa2B0bBb3aBb1BBcBBBaBf1aBbBaBBB2BbBBd2cBaB1bBBa2bBaBBcB2b1aB", "15x17:BmBeBc0h2c2c0cBa0aBb0bBaBa1BaBb1cBbBaBc2gBcBmBd3eBd0dBB002dBd1e1dBm0c0g3cBaBbBc0bBaBBaBa2bBbBa2a0c1c0c2h1c2e0m0", "15x17:d1BcBa2aBaBBBaBBB2e0j1e1BBbBa0Be1BBhBdBBf0aBaBfB1h1a2cB0aBBeBBbBB1bBa3a2b0c0cB2aBc1a1c1a1b0gBBmBfBBc13i2a0dB0b1BaBf1f1BaBj0BaBa", "15x17:b1bBp1eBcBc0e21Ba1e2bBBb1b11eBBbBb1oB2aBcBa1a0a0a1f1b1hBa0hBbBfBaBa3aBa1c1aBBo3bBbBBeB1b2bB2bBeBa1B1e0c3c2e0p0bBb", "15x17:g1bBe0gBbB2bBc4cBB0eBaBfBaBa1dBb2e1BiBBBa01aB1bBBBa2aBc1a1aBBkBdBbBj3aB1f1a2c2cBcBdBbBd1a2cBa2aBc1BfBb2a1a2bBeBcBBBBe3eB2aBaB1BdBdBB", "15x17:gBb0c02BBfBfBBBc2aBb1bB1fBaBcB0fBa2b3Bc2e2bBaBBaBfBc4aBiBe1bBcBBaBbBBiBf3f1c2aBb1eBb3aBBBfBaBb3BaBBfBaBcBaBB2cBa2b1bBB1fBl2bBc0", "15x17:a2b2a1BBB1g10d0Bb10BoBaBaB0B0fBBaB1aBbB1BBcBa0gBiB2bB1b0c1a0b2eBaBc1aB1a00aBB1BiB1bBaB0aBeBaBBaBaBc1bB12bBa4a1cBeBaBjB0B3aBa0f0dBb1Bb0cBBcBc1dBaBa", "16x18:Bb1cB2cBbBB2b1aBbBaBb1BBfB1fBB0lBBBaBbBa2BaBb1aBd2aBbBa3d2a0jBa2gBBg1nB0n1gB1g1a0jBa0d1aBbBaBdBa0bBaB0aBbBaBB0l0BBfB0fBB2b3aBbBa0bBBBbBcB0c1bB", "16x18:2cBB0a1cBBBc0cBa2bBeBd1f1aBbBa1aBBbBBcBc3bBBaBcBaBaBBgB2dBa2b0Ba21aBdBbBbBBaBaBBB3aBzdBaB000a1aB0b2bBd1aB2aBBb2aBd2BgBBaBaBcBaB0b2cBc1BbB1a2aBbBaBfBd1e1b2aBcBc2B0cBaBBBcB", "16x18:Ba2jBaBd0fBf20b2bBb10g2d2hBh1c2Be1Be0Bb3c0b1c2e2b1bBbBc0dB0bBBdBBdB0bBBd1cBbBbBb1eBc2bBc0b10eB1eBBcBh1h0d2gB2b1b1b03fBfBd0aBj2aB", "16x18:fBBBBf10aBhBa21cBaBd3aBc2a2b0aBBaBb2a0gBBh0bBf2b1rBaBB2dBBBaBa1aBaBfBaBaBBaBaBfBaBaBa0a1BBd0B2a4rBbBfBbBhB1gBaBb2aBBa2b0aBcBaBdBaBc0Ba2hBaB1fBB1Bf", "16x18:c1BdBbBB0a0c101d0aBbBBeBaBaBaBaBa2aBa0aBg1aBBBl1BBd1jBaBB1fBa1dBf1a0b0c0ziB1Bb1c210bB1aBB1aBaBb2c0BaBa1cBqBcBaBBcBbBaBcBBb0c1Bd1aBBBgBaBc1d2BaBBB", "16x18:a2a1e2eBBd0iBBhBb3aBaBBc1b0d4d1mB0aBaBc1f0Bd1eBd1aBfBBBa2dBc0a2a2cBBB1fBbBcBbBBBb3aBcBb2BBBd3bBBa32aBgBBeBa1dBBb0a1cBb3cBbBb1d3eBa0cBBaBh0d1bBBa0a2aBBc", "16x18:d2a3eBbBb0d2jBcBB2dBa2b1aBfBhB0c1c0aBaBaBBb12i1gBb0BBBBaBc1m2hBb0h1mBc0aBB0B0b1gBi10b12a3aBa1c2c1Bh1fBaBbBaBdBBBcBj3d0bBb0eBaBd", "16x18:eBaBaBaBBkBbBa0c1b0c3uBdBb0BBbBb3h1eBb2hBe1c1dBbB2dBzb1d1BbBdBc1e1h1b4eBhBb0bBBBb0d1u3c1bBc2a0bBkBBaBaBa3e", "16x18:a1B1aBBBBBBBcBd2aBB2bB0b1fBhBbBiBBaBBj1e2a0Bc2b01oBa1b2aBc1aB1dBb2hBcBBc0h0bBdBBa1c1aBb1aBo1Bb0c10a1e2j10a01iBbBhBf1b11bBBBaBdBcBB0BBBBa2B0a", "16x18:Ba11a1bBaBo1BiBBBaBa2b2aBbBaBm2f2c0iBhB10Bb2BaBBlBbBgB2fBd0eBeB1aBtBbBb2aBd2Ba0bBi0d00e01c1fBBb0a0c2aBaBbBjBcBaB1dBcBBa1b1aBaB", "16x18:1e0eBfBcBf0a0Bc0fBa01hBa2sBa2BhBfBB2c0c2Bh1a2aBBBaBaB0aBaBaBl0bBd00a1f2BbBi0c2Bb3b1Bf3cBa3jBa1a3c0bBBgBBc0c10a0j2gBbBaBeBb2Bb3c", "16x18:aBa00e0BBBBBdBBcBbB1aBh2eBBa1dBaBcBcBa1aBd3b00bBBBBaBh2fB0cBaBcBbB3cB1BcB1a10bBeBj0BfBcBaBe2fBb1a10aBaBb3e0bBBBBaBbBiBa3fB1aBBc2b11c1cBa0BBcBa1a2cBBBa2aBdBdBBBaBBaBBa", "16x18:bBcBB1d1b3d2cB1fBb2f0cBgBBb1fBfBa0iBfBbBb00Ba2BcBd0f0eBa2dB0d1aBg1Bd1aBc0f0eBaBbB11a12cBi1f2b0bBf0a0kB1bBe1b2fBc11dBcBBgBcBBBd2b", "16x18:0bBcBBcBbBa1Bb1d1b2BdBb3b0b4eBb3dBb2bBeBb1eBBBa2BaBBBBaBBaBBzf0cBa2bBa0cBBcBaBbBaBc1zfBBaB1aB1BBaBBa01BeBbBe1b2bBd1b3eBb1b2b2dB0b2dBbB0a2bBcBBcBbB", "16x18:eBb2aBaBBd1B1bBBbBBc2fBbBd2fBBc0f3cBcBBbBbBaBaBbBaB0c1aB3c2bBe0aBi1iBB0b1c0f0B0bBc1b0i1eBBc1bBeBa3a3aBb2aBBcBb4cBcB1b3g00c0d0fBbBd1bBB0bB0bBBhBb1aBaBBb", "16x18:e1dBb2d11dBbBaBh1a0a0bBBBa10kBdBfBb1aBd1f1aBd0Bc1eBa2cBb1bBfBe0cBdBaBa00aBa0a1a1k0aBbBc1bB00gBc2d1a1a2aBBbBBaBBBBaBBaBaBiB1cBBb3aB2b0d3b2aB2cBdBaBgBa2d1bB", "16x18:B1c2bBdBaBbBBg1Ba4aBeBb2b0bBcB2aBa0d1j2bBbBgBgBbBa1Be0Bd0BaBaBa0cBeBaBdBcBB2b2aBd0cBB0a1Ba1a1a1c1eBaBBe0Bj0gBiBbBb2dBBa0aBdBb1e0b1b2bBbBBg11a3aB0c1b0dBaB", "16x18:0a1bBf21f2aBBc2cBaBa1kB2c2d1bBaBBeB0g2e1a2aBd1cBaBe1a0cB1BiBe1Bd0b0fBd0BfB2BeBa0bBaBb0aB0b0aBa11Ba01BBb1aBeBaBbBB1bBk0fBbBBBa1g2bBc1BaB2c1a2k1e02aBa", "16x18:1e0f3c3cBe1bBBBb1aBeBc2aBaBBeBbBi2bBaBbBaBBcBBB1bBB1B1Ba2dBBB1dBBaBbB1Bg01aBaBbBb1bBb1aBB1d1BbBBcBe11aBe2bBBcBa0a2dBcBB1dBbBaBaBaB2e1B1a3c0eBcBb2hBc0BdBbBa2aBa1c1bBcBBd", "16x18:aBb0aBc0dBbBk1a1BBp2d11cBB0b2a1lBaB1a0b0aBf1h2c1aBbBe3aBf2eBe2B2cBaBbBBBa1f1cBa1m1b0dBa0aBaBaBBaB0a10dBaBq1b1c1a0e1eBeBaBb2a2d1f0eBb", "16x18:b2aBeBc0aBbBBb0bB1Bd1dBbBlBaBa0a1b1cB1aBiBBi10h21c2cBd0d1fBBiBBd1iBBgBd1f3e10c0c3a20iBBf0Ba1o1a0aBaBb1a1d0bBfBb1BbBbBBBeBaBe0cBa", "16x18:bBd2aB0c0iBgBa2c0BaBbBBaBhBgBd0d3e0a2a21bBBaBa2a0Bb2a2d2bBBBcBBhBaBa2d01aBd3bBg1aBaBBbBaBc1aBaBBBa0BBc2aBcBBdBb4aBa0oBd2b2cBaBf0B1c0fBd1BeBa2b0b2bB0d1fBa", "16x18:BaBbBb0BdBBiB2BbBb2f0gBbBa3aBdBaBBBBd3dBd1jBBa2B1aBdBBbBb1b1c1dBb1Bh0Bf1BfBBhB1b1d2cBb0b0b11dBaBBBaBBjBd0dBdBB0BaBdBa2a2bBg2fBbBbBBBiB1dBBbBb3aB", "16x18:d2bBBBeBa1aBcBBb2cBaB1Bd0aBa3a2a1dBbBbBBBBbBb0Bb1b3bBc4bB1BbBfBaBhBa1fB2g1aB0Bp1aBb0cBe2lBb1B00d0fBeBBaBbB1cBe2BBBa3c0jBaBBg12cBa1dBc1dBaBd2bBBaBa2d", "16x18:aBBaB2fBbB1cBbBb0dBcBaBBBBbBb0b1BBb1iBr00BeBc1BdB2d1Bh2cBa1Bb2B1BBeBfB1B0e0kBc0aB0b1BdB2dB1fBBBe1cB2pBB0bBlBaBBB0bBbBaBc0bBb1dBa2BaBBf0b1", "16x18:BlBd1BB1dBc2BBc3b00b2BBaBcBkBc0Bd1aBe1c0aBb0c2dBBnBaBBa1c2aBBaBBBBh1cBBBaBb2cB0BeBaBi2h0a0fBbBfB1cBaB0c2c1d1BBBa2Ba4bBBj4f1aBc1BBgB1cBBBdBaBb", "16x18:Bb1h1b11dBBB1BBd1eBa2Ba1e0nBaBl1qBaBcBb1cBaBaBBBb1bBbB0BbBcBBB1BBc1b1cBBBBBBcBbBB3b1bBb0BBaBaBcBb3cBaBq2lBaBnBe1a1BaBeBd01000BdB1bBh1b1", "16x18:aBb1BaBBa10b0eB1dB1eB2j2BeBfBeBe2BeBbBd1b1d2d1hBh1dBgBaBBdBBa1d3aBBd1Ba1g1dBhBhBdBdBb2dBb1eB2eBe1fBe1Bj0BeBBd11eBbB0aBBaB1bBa", "16x18:jBb3aBdBa1aBaBe0aBa2aBa3aBbBb0b1Bi0bBaBBb1Bc1BeBd1f1Ba1BdB1aBb2BcBa0aBg1fBbBaBjBb1aBg3a1aBg0Ba2BdB0aBbBBcBd1fBa2aB1bBBc1BbBbBBiBaBa2aBaBa1a1bBf0a0a1a1o1b0a1", "16x18:0a1jBgBeB1d1a1b2d0aBBg0BiBb0bBcBb2a2i2BBbBaBd1BBbBa2q1dBbBaB2dBBd03aBbBdBqBaBb1BBd1a2b3BBiBa1bBcBb1bBiBBg1BaBdBbBa1dB2eBgBj2aB", "17x19:2aBc3fBbBaBfBj0cBaBc02aBaBcBBBgBa3a1Bb1c1BgBbBfB0aBbBBi1cBBa0b1BdBcBc0bBaBB1Be0bBc3b2b2cBb1eBBBBaBbBc3cBd10b0aB3c0i0Bb2a00fBb0g11cBbB2aBaBg10BcBaBaB0cBaBcBjBf1aBb2f2c2aB", "17x19:e0dBaBcB0b3b1a1e10aBB2aBaBd1Bb2c0BBaB0Ba2Be1d0bBBdBgBh0c0iBdBaBaBb0c1aBBBaBaBb3aBi0dBb1c0fBb1aBiBaBaBbBcBaB1BaBa2i2dBeBh1bBd2b1Bd1dBBBaBBBaB2eBB2a2aBd2Bb2a0b3b0aBe1BfBdBa0cB", "17x19:B1g11aBB1cBjBbBcBb0b0BBbBaBBbBeBe0aBcBjBc3cBa0BaBBc1c1dBbBaBa2b1a0Ba1f1gBaBBaBcBcBa0a2bB3bB0aB0hBa3d0dBb1a2bBa2a1aB1bBbBcBcBb2BBdBb0d1fBeBBdBBb2b2B1f2a0cB2c1o0e2cBa1f1aBd", "17x19:aBaBBeBBaBd2BaBa3a02dB0d1Bc1cBcBd1eBrBa1jBaBa1aBcBb0g12bBBa1gBfBa1e001aBb1aBBcB0BcBBbBbBa0eBBaBdBaBbB12cBp1bB00aBdBbBeBaBBeBa1a2bBBcBB2dBb3bBBeBa3cBb2fBcBBfB1Ba2d0eBb", "17x19:g1aBb1cBc0fB01cBcBbBbBg0a1a12cBBBBdBaBd00e0a0BBBa0aBBa1fB10b0aBBe2iBbBdBc0a2eBbBaB0l11hBBfB2b1fBd1dBa1d1a0BeBbBcB1aB1B1bBBc0b0bBd1eBi2aBBb10eBn2aBaBBaBa4cB1aBcBb3aBb", "17x19:eBa3aBb1eBb3g2c1bBBbBcBBaB1bB2aBBbBBfBdBBa1b1a2hBdBe3aBa12a3gBd0b3cBB0aBdBg1a1aBaBB1BbBkBbBBB0a1a0aBg2d0aBBBcBb2dBg2aBBaBa0e4dBhBa2bBaB1d2fBBb0BaBBbB2aB1c2b11b0cBgBb1e1bBa1aBe", "17x19:b1aBBaBaBbBBBgBc1a2BaBbB3d1dBaB1d2f2dBc3eBbB2c01bBc1bB0eBBf2aBdBaBb1b1Be1h1bBaBe2aBbBa22jBBb2bBfBbBa2dBaBb11f1d1b0dBBdBBaBBa2a3b2c0aBB1aBeBb0iBfBB0f1f2bBB1bBaBe2B2b1cBh", "17x19:Ba2aBc0BcBb1BhB2aBBb0bBa0dBBa1d0e0s0f0aB1d1BBa0c00cB0aB1Bb2aBe3BdBa4iBgB0a1BBa0BdBhBc2gBBaBB1b0Bd1aBiB0aBBBbBaBdB1dBBBa2cBBiBfBBe2lBaBdB1aBdBh1BaB2bBBa2a2cB1cBb1", "17x19:d0d1c1a0a2bBd2a1fBaBBaBeBc0aBdBcBa0cBBdBcBBbBBBBBa0bBBcBa1Ba2c0BfB1a1aB2aBd1l1Ba3Bb1a2BBa0aBaBBc1dBBBdBaB2eBB0B0a2c1bBaBbBbBbBB1aBaBBbBfBc0cBa1a1B0j0aBBe0c2BaBa1fBbBd1a11BaBaBaBBbBgBcBg1b2b2bB", "17x19:1BdB0bBaBB1dBBhBa2aBbBb0a0a1bBfBb0dBBBaB1B2d1BBBBBeBaBoBcBc11qBfBc2d0BbBbB1a2fBkBcBg1d2g1bBb2Bc1b2b2bBBBaBBa1cBd0BBcBeBc1d2dBaBaBcBcBBb1bBc2b0eBBbBa0d1b0aBBBaBBgB", "17x19:BcBcBbBBe3BBBaBg1dBb20a2cBa0bBBfB2a0d1BdBhBbBc2bBbBaBbBaBBa0c1cBBaBBa1bB1Bh3hBa0Bg1iBa0aBBdBj1bBaBd1cBb1c2aB2aBa12a1aBa1hBkBa1B2a2aB1jBiBbBc1BBc0B1f2BBi0BBBgBaBaBc", "17x19:pBBa0g3cBbBaBa2bBaBaBa2d2BBbBcBBkBcBBcB1b0f4aBaBbB0BaBb0cBaBb2f1BcBBb3cBbBBa1eBd02b0BBd3aBh0cBBBBbBbBB0Bc1cBaBbBa2a0b2a11e1a2bBaBf1a0b1gBa11f1bBd1bBb2c1mBb0f2aBbBaBjBaBaB", "17x19:bBe2e0sB2a3cBa1cBaBBBcBbBaBbBcB1bBc0aBc3bBBfBaBfBcBb0Ba2Bb1c1e1cBeBg0aBi00iBBiBa2g1e0c2eBc1bBBaBBb0c1f0aBfBBbBcBaBcBbBBcBbBa1b2c1BBa2cBa1cBaBBs0e0e2b", "17x19:BfBaBfBbBa3aBaBa1aBa3c4aBB2bBbBBBa3d2aBaBB1aBa1j2aBk1cBc2jBc1gBbBgBbBaB1Bd3aBd1BBeBb3b0e0BBdBa2dBB1a1b1gBb0gBcBjBc2c2k3a1j2aBa1B0aBaBd1aBBBbBbB11a3cBaBaBaBa2a3aBb0f2aBfB", "17x19:aBBaBaB1aB1aBaBBaBa2d0aBdBaBdBBeBBe0a1aB0Ba1BBa2a2dBi1c0f0aBfBaBbBbBaBbBbBb02cBc4c2BeBBeBBf3kBf2BeB0e0Bc3cBcB2b1bBbBaBbBbBaBfBaBf2c1iBd0aBaBBBaBBBaBaBeB1eBBdBa3dBaBd2aBaBBaBaBBaB2aBaBBa", "17x19:a1aB2gBBaBcBdBa0d3eBcBaBc2h0b3b2f12BcB0Bc1B1dBiBcBB1b0Bc0BbBBBh0h2a3bBe1bBaBaBaBaBeBa3aBaBa4bBeBbBaBh1hB1BbBBc2BbBBBcBiBdBB1c1BBc120f1b2bBh1c1a1cBe2dBaBd3cBaB0gBBa2a", "17x19:aBdBa1BBa3aBbBd1b0d2bBBb3a1fBBBBnB0BaB1gBhBbBb0f2bBaB1dBaBBeB1a2b1BaB0bBaB1Bd2dBBh3b2cBbBhBBdBd200aBbB1a00bBaBBeB2aBd12aBbBf0bBbBh1gBBa01Bn0BB0f1aBb21bBd0bBdBbBaBaBB0a1d1a", "17x19:c2a0Bb2bB1e2bBaBaBaBb2eBd0dBBBfBaBBb11aBd2a0B0bBeBaBgB1B3eBB2gBdBBcBbBaBbB0cBb1gBaBa0BeB2aBbBBBa1aBb3gBaBa0Bd2bBaBbB0cBBBBg2dBBBg1BBBg2a0BBb1eBf2a2BbB0a2e2dBdBBBcBb2aBa2aBb1e1aBBbBbB0c", "17x19:a3aBaBa2f1aBbB1Ba2aBa3aBdBd2Be1aBaBa2b1cB0dBa1aB1h1bBbBcBd2bB1i0cBeBa10Be1aBa2bBe0B1iBa1BdBBa0cBaBfBaB1aBb2a1bB1B1bBb1d1fB1BeBd0fBbBBB2i1a2c2dBe1dBBeBa2n0jBBaBe0eB1BB", "17x19:aBc1b1cBb0b1aBB0c2c2a1c0BdBb0e0bBaBBcB0b1bBbBcBb1d2b1aB1bBlBc2dBb2Bc1hB1cBBc3Bb1aBb0eBBbBh10BcBBbBa0b0e2hB1fBcBdBb0BaBaBBb1i0bBcBbBd2aBb0aBBc22b2d10dBb2f2a2BBc1cBaBbBc1bBcBbBa", "17x19:B1bBb1aBk1dBB1BB1cBgBcBdBpBaBc2aBiBb1BBBBa3BBaBa1BhBdBaBbBb3dBaBa1d2cBbBd1b11B1g2BBBbBd2b0c2d0aBa2dBbBbBaBdBhBBa1a0B2aBBB2BbBiBaBcBa2pBd0cBgBc1BBBB0d0kBa0bBb2B", "17x19:cBaB1aBaBBa2c1a0Bi1BaBf0a0a1jBbBB1bBd0bBBgB0b1hBk2dBd1e111Be1BB1bBdBb4bBd0dBb2aBbBdBdBbBbBd0bBB11eBBB1e2dBdBkBh0b0BgB3bBdBbB1Bb2jBa1aBf1aB1iBBaBcBaB2aBaBBa0c", "17x19:bBc0aBd1gBd0d1hBeB1d1e2bBa3eB0c0h1e2dBaBaBa0a2jBfBa0c0b2eB10aBaBf0g00f1bBeB1b1fBa0BrBmBkBB0bBBbBBBg0bBb1Ba1dB2dBaBaBa0c2a2BaBaBhBcBd1c2cBaBBBb3a", "17x19:BaBBBaBa1bBb10aBBaBbBc3aBe0aBBdBdBaBaBaBbBB2cBcBd13aBaBaBBb0aBc2dBc2a0aBbBbBaBb1c2b0aBcBeBiBaBc0aBBBeBaBgBgBaBc0aBBBa1a1cBeBcBb1b1a2bBc2aBc0d2c2aBeB1a1aBaB0bBbBa2b1BBcBcBa1aBBdBd0aBBBaBb2cBaBdBaBBBaBaBb3bB2a", "17x19:aBB1BgBB1Bb0b2aBBBB0aBbBf3e1kBc1jB2e0BeBa0cBa1c0a1s01d1a0dB0bBaBaBe2aBaBsBa4aBeBa2aBb1Bd0aBdBBsBa1c3aBc2aBe1BeB2jBc1kBeBfBb1aB1B0BaBb0bB1BBgBBBBa", "17x19:2aBaBBc0cBeBc2bBBaBaBd1aBBaB1a3d3bBBBBb0dBcBaBaBcBa0cBcBaBcBbBBB1a2BBbBa3aBaBb1cBfBi0a2bBc2aBiBaB2b1BaBhB0dBBBa000fBaBBbBB1aBdBaBeBcB0b3aBc3a2dBa1aBcBaBeB1bBBBcBB1iBBBcBaBb200f2aBb1cB1c1bB0eBd", "17x19:B1b3aB1a1bBa1a1cBaBcBfBi2i1bB0BbBBaBbBbBa0e2d0e2BBaBcBaBcBBBc2cB0bBbBgBg2aBBfBa1a1BaBc0bBBa2cBBa0f2aBe2eBd0a1aBc1c2BBBf1B1bBbBBgBcBBdBaBdBb2c1c2B0c0aBdBaBbBe2d3h1iBb2aBf", "17x19:fBB1dBBg2fBa0c3b0BaBa1b0aBa2BBdBbBfB1d02c1aBb0aBa0d2cBa1hBc1jBg2dBaB0aBa0bBbB3dBBbBb2b2bB1dBBb2bBa2aBBaBdBgBjBcBhBa3cBd0aBa3bBaBc11dBBf2bBd2BBaBaBb0aBaB1b2cBaBfBg12dBB0f", "17x19:Bc1aB0fBa0a4bBb0c0eBcBd1d0bBd2Bb0aBaBbBhBhBdBa1b1BBBcBaBBBBaBcBbB2fBbB0bBbBb12dBaBa1c0hBa0h01dBa1a3cBf1bB1bBbBaBa2BBBaBc2b2BaBd1aBbBBBBkBh0d0Bb1a1aBbBBcBdBd2cBb2b2c2eBcBaBBfBaB", "17x19:e1e0a0cB0c0b0eB0eBmBBbBcBBa2k1dBg1BBg4aBBB2aBgBbBb0bBeBb0dBdBB2g3e0gBeBgBB2dBdBb0e0bBbBb0g0aBB1Ba4gBBBgBd2kBa02c1bB1m2e0Be0b1c01c1aBeBe", "18x20:c2b02cBa1e1bBc2e0e12cBa1aBe0bBiBb1BBaBbBb2cB1eBbBc1dBa0cBe0d2c1e2p1aBa1dBk0fB1aBBBeBfBBaBB1b1aBaBd0i1n1eBd1c1b0bBcBd1a2d2b0b1c0Bg2iBbB0Bb1Bc1aBaBeBa1bBc2e2fBbBBc2aBd", "18x20:cBnB3bBbBb1B0a0eBm1bBe0aBgBd3dBb2b1aBb2b2a1cBBaBbBlBBaB0aBBc1d2bBaB2aBpBbBc2aBd2cBb3cBaBdBcBBpBBBc1d1bBaB0mBBa1Bc2bBaBcB0aBbBd0d1b0bBaBaBe0aBgBb2mBa1BbBbBb1B0a2f1n", "18x20:BBn1BBBcBBdB1c1Bc4aBa0bBaBaBe4aBbBbBbBaBcBcBBaB1a02c0s1cBcBBc1cBBb0a3a1bBa3a1bB1eBBbBBeBbBlBdBl1bBe20bBBe0Bb1aBaBb2a3aBb1Bc0cBBc2cBs1c1Ba02aB1c2c1a3bBb2bBaBe3aBaBb2a3a3cBBcB0dB1cBBBBnBB", "18x20:b3a2aBBbBBa3a3bBbBc1b2cBbBaB10BcBBcB01BaBp11g01gBaBB1bBd0b000v0aBfBa1gBBa2BBBaBBd1BBa0aBBbBBa2aB1BBB0aBaBBbBBaBa1BBdBBaBB21aBBg1aBf0aBvBBBbBd2bB10a1g1BgBBpBaB2BBcBBcBBB1a2bBcBb1cBbBbBa1a11bBBaBa2b", "18x20:B1b3aBaBBe2eBaBBBb2aBcBBa2aBaBBd3b0bBbBBcBBaBcBa4e1b1c1aBdB2BBBd0cBaBBaBd10e2c1cBd0dBcBdBBfBaB2fB0d0bBbBBa1aBd2aBBeBaBaBbBcBaBdBBbBb1c1Bb0bBBBb1Bb0bBd2dBh2fBaB0aBbBcBaBBeBBbBBB2bB1cBB1bBaBe2aBaBB2aBBBcBcBc1eBa3cBBe", "18x20:bBBaBa0cBeBaB1fB0d2hBaB0BcBB0e1BdBa3a1aBBaBe1a3aBBcBBa2BcBBu2d1aBcBcBaBdBBd3b1a0f2bBa2b0b0BfBbBf0BbBb0aBb1fBaBbBd2BdBa0c2cBa0d2uBBcBBaB0cBBaBa1e0aB0aBa0aBdB0eBB0cBB0aBhBdB0f1Ba2e0cBaBaBBb", "18x20:Bh2bBBa2f2aBBBe1fBd1cBaBBBB1b1bBB1b2b2a2Bb2bBaBaBBcBcB1c0d0cBBBBBa2aBiBBg2b2BBBBb2bBaBaBaBbBcBBaBaBa2wB1bBBB1cBbB0bBB1aBfBB2bBaBBaBa010b00BBdB0aBdBf2Bh1cBb2dBBBdB1BaBBc1b3bBeBBBa0cBdBaBaB0aBc02f1BfBd01f", "18x20:a1aBa3eBBbBaB2cBaB2hBBa1cBbBbBBBfBa0Bc1eBeBBb0BaBa2bBbBaBb2bBa0gBa0dBc0b1c1b1bBd1e2cBBdBd1a1e0b1f0gBb1fBf21d2d0a2aBbBbBd1eBBaBd2c0b0cBa1bBb1aBjBBbBBa0a0b0d1a02c1e1cBcBb2b1B0dBcBaB2hB1aBa1aBeB0b2aB", "18x20:f1dBc0d00e0fBBdBB3aBcBa22aBa3bBb4c1aBb2BbBe3aB0c2a1aBdB1dBhBcBa2bBBa2c4b1a00aBfBe0aBcBaBf2e2BBaBlBaBB1e2fBa1cBaBeBfBaBBaBbBc0aB0bBaBc2hBdBBdBa1aBcBBa0eBbBBb3a2c2bBb3aBa1Ba2cBaB1BdBBf0e00d2cBdBf", "18x20:dBh0d2bBBa2Bb1BaB1b2b0c1dBc2eBaBf3aBc1a1cBd2c1aB1dBBd0BdBdBh2d1a1a2h2a0aBe2aBb1a2ztBaBbBaBe2aBa1hBa2a0dBhBdBd1Bd0Bd00aBc3dBc1aBcBaBfBa1e2cBd1c2b1bBBa21bBBa22bBd0hBd", "18x20:aBb2aBBaBBBd1gB0b0b2cBaBj3pBbBBa0a11bBbBa1c0cBBaBg3bBbBaBbBb2zg0f11aBc0Bb0B1gB1b11bBB1gB0fBf11aBuBb1bBj11a1gBb1b1aB2bBb0a2cBnBbB0aBaBj1kB2b1b1cBa2bBaBBaBB1d1a", "18x20:Bc0BlBB0cBbBq2cBa1bBcBaBc2bB1dBd1b2Bb2aBB0Ba2bBm4aBi0hBBBaB1BBBBdBa1b1fBBB10a1dBcBa3aBaBfBbB0eBb0bBBBc0bBgBb3cBBhBBaBfBbBa1cBc0aBBaBf03a1cBBd2b1f0d0f0c1B0aBdBfBe1aBb11aBaBdBcBBbBB1a2b", "18x20:BBBf1d1cBBbBBB2Bg1BfBa2c1eBa1aBcBaBbBaBaBd0aBBeBb1BaBa0aBeB1gBe1aBb0aBb0j2fBa3bBi2aBc2aB1b2c2bBbBb1cBbB0a3cBa2i0bBaBfBjBb1aBb0a0e1gB1e2a2a2a01bBeBBaBdBa2aBb2aBcBaBa2e1cBaBfB0gB0000bBBc0dBfBBB", "18x20:Ba0gBaBbBBcBBa1a1BeBa0Be12iBaBdBeBb2a0BB1cBlBa2aBb1c02BdBe2d2aB0a1aBBaBd1a2eBfBcBB11g1fBaBb1f0bBa0f0g1BBBc1f1eBa1d3a2Ba1aBBaBdBeBdB0BcBbBaBa1l2cBBBBa1b0eBd0aBi3BeBBaBe1BaBaB0cBBbBaBg1a1", "18x20:a1b2gBc0aBbBfBaBB0aBc12a1gBiBe3dBaBBbBd03bBBBa2aBB0b1eBcBaBd1Ba0bB0a2bB02aB1i02hBa2a2g2gBBb1BcBaBcBjBa3a1e0dBbBBd2aBBaB1BeBBfBa1c2d0aBd1f1f1cBBbBe1Bi2bBBcBfBcBa1c2BBcB0a1k2aBaBaBBBa2aBa1a", "18x20:cBd2BaBaBa2BfB0BaBBaBBe4a1eBdBbBBeB0Bd3aBcBbBbBBBdB1aBb1aBBBbB1cBBBa1Bc1aB2aBa0a0bBb1gBbBBaBcBa0bBa0BfBbBaBbBdBBaBaB0c1aBBaBBcB00B2aBBb2b0aBeBbBBBaBb2d1BBa1bBaBa2Bb0a2B0dBaB1bB1aBBcBmBa1hBcBeBBbBBaBc1Ba0aBB0aB0BBbBBd0a0aBaBB0c1bBbBcBBB", "18x20:Bc0dBaBBeBbBBa1b2a0iBBB1aBaB11d0a2BaBeBcBb1aBaBb1cBbBd2e1BBaBbBa21cBBcBBBa22cBaBfBfBbBB1a2cBbBb2BaBBcBc2aBaBbBaBBa2a0fBbB0a1BiB1a0dBaBaBBBbBbB0dB1cBBeBBa1B1BbBa0eBaBBs1Bb2cBeBe3B0eBBbBBB1eBb2aB12aBa1a1BjBaBaBd", "18x20:2eBe0aBdBBBBa3b0e2aB1a2aBdBB1b4bBc3cBeBcBBjBb2a1j0aBdBaB0a1kBBBB1bBc2Be1d1BcBdBBaBBd2f0b1e1cBB1bBkBaBe2BcBeBaBaBd2aBBBa1c3c0aBfBBcB2aBaB2b1b1c0oBaBbB1dBBbBdBBBaBc12aBb2a0hBb2f1a1aBBeBBb", "18x20:b2aBBc1cBBbBaBaBa1aBaBaB0cBb1aBaBg2aBb10bBBeBi2BfBfB1cBa2dBBaBa12c0fBbBfBeBBcB1aB2BBbBB2d3BaBdBBaBdBBaBBbBbBBaBdBBaBBb21BBb2BBdBBaBeBe1Bc1BaBBcBfBbBcB0cBaBd1Ba1a0c21f0f2BbBBe1gBa2aBg1aBcBaBa1a2a0a00cBcBaBBc1cBBb1", "18x20:BeBe1BBb2b3cBbBbBe1aBBeBcBcBcBa2e1b21aBd1cBBf0BBe0cBeBa0BbBc0f10dBaBBb0dBhBBeBa01bBd2aBBBBaBe2dBaBBBBaBjBBe1a0Be2aBBbBdBcBBbBc2f11aBe3c2eBeBcB0f1BcBa0eBbBBa03aBBeBcBc0b1c1b3bBeBeBeBB1b0", "18x20:dBBa1aBBa0aBaBbBa1eBBd3h21a2BdBBBa1aBcBbBbBbBe1BdBBcBd1gBeBcBbBa10g1d0bBBa1Ba2cBbBiBj1a2BaB0eBb1eB1a01aBjBiBbBc1a01aB0b2d1gBBa1b1c2eBg1dBc21d10eBbBb0b1c1a2aBBBd0BaBBhBdBBe1aBb1aBa0aBBa3aB1d", "18x20:bBBBBa2fBbB2b0bBfBa2g2a1b0aB1aB0bBe0bBcBBaB1B0c1Ba2BgBfBBaBaBBBbB1c0a1bBBa1aB11aB1cBbBBBb3bBa1dBBb2bBcBBcBaBcBcBi2Bg1a0cBfBc2BgBdBaBBa20aBa0Bb1dBdBaBBhBaBBBa1BBa2d1cBeBf1BkB1Bc2a1c0cBBBBaBBaBBh2aBB1cBaBBa3bBc", "18x20:bBb1BcBBb3a1a1f2aBj0Bb0BbBaBBa0bBBd3o1dBBBBaBiBBBBcBB0aBd1Ba2bBa0c2aB1aBaB2eBbBbB0fBdBaBaBdBa0BaBB3iBhBa1gBBb1bBbBc2c20fBa0B0d3aBiBBBf1d0c1fBd3b1f0c0o3g1BaBBBbBc1BBaBe1aBaBBBc1aBaBb0c", "18x20:Ba2c00dBaBBl00Bi1a1BbBBBBa3aBa1cBBaBBaBaBcBbB0b2aBaBBa3bBBcBBBi1bBB1Bb1BcBcBaBd2e3cBBaBeBBB11aB0aBbBBc1aBaBaBcBB0bBa2cBBcBBaBkBaBaB2hBf3a1gBe1aBd01aBbBa20l1fBfBkBa1BBcB0a1d2aBd3a3aBBBB2aBbBgBaBaBaBBBBBBb10a", "18x20:bBe0b1bBbB2Bc0011dBhBdBBa0BcBbBaBbBf2bB1aBaBaBB1bBaB1h1cB1aBfB1bBkB1d00b00a0e1a20fBB1cBaBBaBBB1dBBaBb22b1aBBd2BBBaBBa3cBBBfB2aBeBa1Bb2BdBBkBbBBf2a1BcBh0BaBb2BBa2a2a0Bb0fBbBa1bBcBBaBBdBh1dBB11c0BBb1b3b0eBb", "18x20:aBbBbB2aBBBBkBaBc2bBf1d0aBa3e1Ba3eBcBbB0iB2bBfBaBaBBBi00e11aB0d0fBcBBb1f1aBa1e2b11hBaBbBB0e1b0BeBa0eB0a2aB1b1b0f0e2d0aBBaB1cBa1e0jBaBBfBaBbBbBc21c1BBcB2cBe1aBB0aBbBfBiBa0aBbBf1bBbBBaBBa1b", "18x20:aBBaBBBBaBaB1cBBa1BBaBBB3bBaBBBbBaBaB0cBa2g4aBBc3a3b0hBBa1cBaBc2BhBd0B1b11aB1a1h0Ba2bBBe1dBcBBaBb0cB1a0cBcBbBeBBBBc1aBe1dBe0BBa10BBbBaBBB0Bd11aBd2c1aBb2hBb2cBBiBBBcBlBb1a2a3aB1c0gBcBe02a1BbBbBBb2a01bBb3f1hBb", "18x20:BaBdBbBdBaBc2BBfB11j2bBh0B0bBBb01b1BBaBaBc0dBcBa1b2aBaBdBa1a0iBb0iBcBBBBBBcBcBn2c2a3b1bBbBa1d1aBbBbBb1aBc2n1cBc1BBBBBc1iBb2i1aBaBd2a2aBbBaBc1dBcBa0a1B1bBBb10b0BBh1b1jBB1f1B1c1aBd1bBdBaB", "18x20:00d0aB0aBdBBc2bBa0BaBb4eBaBBbB1bBBa3dBBaBBBbB10aBBbB1aBjBaBBd0BBaBBaBB1dBeBBBBB1eB1c2cBBcBc1eBaBbBa3eBBdB1bB2dBBB1d2Bb1BdBBeBaBbBaBeBc1cBBc2c2Be1BBBBBe0dBBBa2BaBBBdB1aBj0a1BbBBaB1BbBBBaBBdBaBBbBBbBBaBe3b1aBBa0b4c1BdBaBBaBdBB", "18x20:b1l0gBBaBBa0Be1BBBj2BBBbB1jB2i0b0j1Bb2bBb0Bc1b2bBBbB2bBbBbBBdB2dBBbBB0c1d2cBBBcBBhB1fBBh0Bc2BBc1dBcBB2bB1d0BdBBb3bBbBBb2BbBbBc1BbBb1b02jBb0iB1j1Bb1BBBjBBB2eBBa2BaB1gBlBb"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 19;
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
        LightUpManager.currentPack = 19;
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