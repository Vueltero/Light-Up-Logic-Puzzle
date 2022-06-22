﻿using UnityEngine;
using UnityEngine.EventSystems;

public class IntervalPack : MonoBehaviour
{
    string[] puzzles =
    {
        "7x7:d0c2b01gBg1gB1b3cBd", "13x13:eBc0e1gBBg0a2d01cBBBBaBc2a1bBBaBB2rB1iBf3c0g3i0BbBc1Bb1gBeB3aBfBbBaBBa0b", "16x16:dBgBBd2BBBa1aBaBa3cB1hBBa2d1c2bBBd2aBcBc1d1BeBfBcBaBe3bBbBBBd0dBb3aBBdBdBb1b2a2eBb3bB1eBf1bBaBc1c0dBcBc0bBBe0BhBBa0cBBBBa2a1aBaBf2gB1b", "24x24:dBa1a1bBBbBaBa2d00Be1b01bBe00Ba0c0l0cBbBBrBBc1fBBBBBBfBcBB1a01BbBbBbB1BaB00a0fBaBBbBBaBf0cBa0aBbB2BBbBaBa0j1aBdBa0h3B1fBBBBfB0Bc2aBb0aBdBaBb0a2bB1bBbBbBBB2bBbBbBBBBb1bBbBBBBbBbBbBBbBaBbBa0d0a2bBaBc00BfB2BBf0B0hBaBd2aBj1aBaBbBBBBbBaBaBc0f0aBBbBBaBfBa10Ba0B0b2bBb1BBaB12cBfBBBBBBfBcB0rBBbBcBl0cBa011eBb11bBe00BdBaBaBb1Bb0a1aBd", "20x20:cB2cBB1bBBa1a0aB10d1bBc1cBgBeBBb1a1aBa1aBbBaBbBfBkBb1a2bBB3bBB2c1b2BeBaBbBeBb2bBdBBlBa0eBaBb2iBB1cBeBd3bBBb0dBe1cBBBi0b1a0e0aBlB1dBb0bBeBbBaBe1Bb4cBBBbBBBb0aBbBk0f1b1aBbBa3aBaBaBbBBeBg0c2cBb2d2BBaBaBaB2bBB2c0Bc", "14x14:cBa3aBgB1dBb2a1fBfBbBa0bBc4bBdBc03hBfBaB21hBfBh2B2aBfBh30cBd1b2c1b3a2b1f2f0aBb0dBBgBa3a2c", "20x20:Ba2b0bBbBbBb3aBBh0BhBa1a0aBa0d0aBaBaBaBBaBdBBBBdBaBBbBcBf3c0f3d1BdBd0aBBcBdBc12aBe1aBaBBaBaBgBa20aBB0BBBaBBa2b0eB0dBBeBBeBBdB0eBb0aBBa0BB1BBaBBaBgBa0aBBaBaBeBaB2cBdBc21aBdBdBBd2f3cBfBcBbBBaBdBB21d1aBBaBa1aBa0d1aBa2aBaBhB2hBBa2b0b1b2bBbBaB", "11x11:b2e1dBeBc1a0c3hBaBB0aBc21BdBf0dBa0e0hB1BaBo2cBBBb0eBa", "11x11:Bb0a1bBaBa3gBa1m0c2bBdBa3d2iBdBaBd1b0cBm2aBgBaBa2bBa2bB", "12x12:aBc1BcBn1h0a0jBBb0aB0aBbBaBcB1cBbBcBBc0a2b2aBBa1bBBj1a2h2nBcBBcBa", "23x23:dBBbBb0b2b11eBiBi0bBcB1BB0c00BBBc2a0a2a0BcBBBBBcBBaBa1cBc2bBBBb0c1cBaBaBBB1gBBBBaBa1eBk0h2a3cBc1cBa1c1Ba0Bc0BBa101cB1aBBBb0BmBBbBa1fB0c11f3d02aBbBc1bBa2BdBfB1cBBfBaBb0BmBBbBBBa0Bc3B1aBBBcBBaB1cBaBcBcBc3aBh2kBeBaBaBBBBgBBB2a2aBcBcBbB1BbBcBcBa2a3BcBBBB2cBBa3a0a0cB0B00cBBBBBcBb1i0i0eB0b2bBb2bB1d", "23x23:bBcB1b1aBbBBcBbBaBaBa1bBBBB0b2aBaBaBa2b0mBb1bBBeBe0e2BfBbBe2b2gB1BbBbBa2bBbBB2b1e4a3e2aBeBBa3bBbBBaBaBBbBb1aBBBc1BBBbBb2B1Bc1B0aBdBb3aBb2dBaBf1bB1aBBbBfBaBBaBkBaB0a1fBbBBaBBbBf2a2dBbBa1bBdBaBB1cBBBBb0bBBBBcBBBa1bBbB0aBaBBb2b0aB1eBaBeBaBeBbBBBb2bBa0b1bBB2gBbBe2b0fBBe1eBe11b1b0mBbBaBaBa3aBbBBBB1bBa2a1aBbBcB2bBaBbBBcBb", "14x14:fB1h0a2dBa1eBa2bBaBdBjBbBaBf4aBeBBbB2f0cB1c0d1c1Bc0f21b01eBaBf2aBb1j1d3a1bBaBeBa3d2a1hBBf", "11x11:aBaBe2fBaBc1cBdBd3aBe2gBBlBgB2d0a0e0cBdBfBa0dBa0e2a", "17x17:a2a0e2a1bBe0bBd0aBb3BbBa1BbBaBf2a0c1eB0BBdBaBcBaBdBB2fBd1f0gBaBBaBaBb1a1a0c3kBkBc0a0a1bBa2a1Ba2gBf2dBfBBBd1aBcBa3dBB2Be1cBaBf2aBbB0aBb32b0aBd2bBeBbBaBe0aBa", "17x17:b1bB0c0m1bBBa2Bc0b2kBa1bBc2rB0a01c0b1bBbBeBB0bBBBcBeBgBaBaBc2d0iBd3cBaBa3g2e0c3BBbBB1e1bBb2bBc1Ba00rBcBb2aBk2bBc00a0BbBmBc1BbBb", "9x9:0c0cBaBa1aBa0lB1aB1m22aBBl0aBaBa2aBc1cB", "15x15:b1dBBbBBl3a2bB1aBbBgB0f2aBbBcBdBk0a0c0eBfBb1a0bBb3b2aBbBbBbBaBbBf1e1c1a0k1dBc0b3aBfBBgBbBaB1b1aBlBBbBBd2b", "21x21:aBB2g1a1B0k0a1gB00BaBbBbBkBBa0bBbBaBl0aBg3bBa3cBaBbBc0cBBa3a1a1c1BdBa0aBBeBBBBjBBaBBBbBa0c1a20bBeBbBB0d3bBd3d10i1aBbBg0dBbBdBdB0aBc1aB2b0eBbBBBjBBa112bBbB2d0aBaBBeBBBBb1cBc2BaBaBaBbBaBgBbBa3c2a1bBb0aBlBb1bBkBBgBa3gB1BBbB1Bg1a0BBe", "19x19:eBa3c1a0fBfBBBf3aBa1dBBaBBdBaBb0cBe2c1c0Ba1a1Bc1BaBaBBfBgBf1B0c1c1cBB0d1aBc1cBaBdBaBeBeBaBaBd2cBcBdBa1aBe1eBa0dBaBcBc3aBd2B0cBc2cBB0f2gBf00aBaBBcBBaBa01c0cBe1cBbBaBdBBa01d3aBa3fB1Bf4fBa2cBaBe", "17x17:1a1aBc1cBaBaB1cBgBcBbBd2aBd3cBBa2g1aBBbBm2s1f0f2bBBB0gBBBBaBe0c0eBaB1B1g1B12b1fBfBsBmBb00a1gBaBBc1d3aBdBb1cBg0cBBa2aBc0cBa2aB", "10x10:gB1a2cBb0b1BlBk3a0bBaBkBlBBb2bBc2a0Bg", "19x19:aBBaBBBkBa2aBBBg01aBBBaBBBc0e0BaBaBa0B0a2bBoBbBbBe3aBa1f2bBaBb0cB1c2bBaBBBe0oBgBa0a1d1aBBaBc2g0cBa11aBdBaBa1gBoBeBB0aBbBcBBc2b2a0b3f1a2aBeBbBb1o1b1aBBBaBaBaBBe1cBB1aBB0a00gB1BaBa0k0BBaBBa", "22x22:d1b2aBBdBb21aBa2BaBcBaBa3a2aBf1gBaBaBBcBcBdBB0aBa3a3aB1aBbBgBdBa2eBBb1d1BaBaBeBa2a1aBa2dBB2d0BbB2aBbBaBfBB1iBaB1eBBBdBd0dB2aBcB1bBaBa0eBBaBBcBbBaBdBa0bBc13aBBe2a2a2b1Bc2aBBd0dBdBBBeBBaBiBBBf1a0b1aBBbBBdBB1d0aBa1aBa2e2aBaB0d0bBBeBaBd0gBbBaB2aBaBa1a2B0d1c1cBBa1aBgBfBaBaBaBaBcBaB1aBa1Bb3dBBaBb2d", "7x7:d1c4jBa0aBcBh0Bb3h", "9x9:d2e3aBcBn1b1aBbBa3b0aBbBn2c2a2eBd", "7x7:e0a0b1fBd02a2Bd3f1bBa0e", "9x9:a21eBf2bBb1aBdBbBaBbBBb21e1cBaBaBe2cBa0bBaB1g", "7x7:aBa3i1g0bBbBg1iBa2a", "7x7:1cBbBc2e1bBj3aBBb3bBa1f", "11x11:e2e2bBcBbBBiB0BbBaBb0BdBa1h1aBhBaBd01bBaBb2B1iBBb2cBbBe1e", "18x18:aBbBdBBjBBBb2dB1a0bBgB11eBaBc2BaB1BcBb21Be2dBBeBb2gB0b0b3aBc1dBhBfBa0cBBaBaBeBe0BbB1e1eBaBaB2cBa0f1h1d0c1a2bBbBBg2bBe0BdBeB02bBcB1Ba01c1aBe0B0g0bBa2BdBb2BBjBBd1bBa", "25x25:bBbBdBBa01d2bBc3aB2a2k3aBBa3aB0Be2a1c0aBeBBBcBBBdBc1dBBBdBBBa1aB2gBBaBaB1Be1o2e0bBBb0BeB0bBBbBa1bBa10aBcBcBa00aBb0h1gBiBg1aBaBa3g2cBaB01e1eBBBa1bBd2d1cBd2dBbBgBaBaBg2b0dBdBcBdBdBbBa2BBe3eBBBa2cBg2aBaBaBg1iBgBhBbBa0BaBc0c0a1BaBb2a2bBBbBBe11b0BbBeBoBeB2BaBaBBg1Ba1aBB2dBBBd1cBdBBBcBBBe2a2c1a1eBBBaBaBBa3kBa0Ba3c3bBd0Ba00d1bBb", "15x15:e1cBf2bBa0f1c1a1bBaBbBgBBn10d12a0a1c0d1b2i2BBa2c1a0b1b1a1c3aBBBiBbBd2cBa0a1Bd2BnBBg0b0a1b2a1cBfBa1b1f0c0e", "16x16:0a1BhB0aBf2b1l0BB1h0b2dBbBbBn1bBj0c1aBaBd2aBa2aBb0cB1cBbB2bBcBBc1bBaBaBa2d1aBa1c0j1bBn1bBb1d1b1h12BBl1b0f1aB1hBBa2", "23x23:a2B1aBBcBBa0bBcB2j0aBbB1bBcBaBgBbBbBBBBcBBBc0BBa2bBaBaBeBa12dBBBa1c2a3bBBBa1B2BbB0hB2dBaBcBaBBfBa1aBaBf2eBB1bBcBBBbBbBB1eB0Ba2B1dBaB1bBBdBeBBfBBgBcBBcBBa1BBa3aBa1a0B0aBaB0BaBc2cBbBBBBaBaBcBBa2BaBBaBBcB1bB1cBdBBaBaBc2cBBBBBcBcBBaBfBcBBBa3dBa2a3cBb0aBe2Bb1BcBcBaBBa2aBBe0bBBb2aB1aBaBBBBBbBcBBa1g2c1a0aB1cBdB2b0aBBBgBBa1aB1BaBaBg1bBa1eBBaBaBaBa", "9x9:j00a102dBb3a2gBgBb2fBd0b1a1b1BaBB2k", "20x20:bBaBBaBg1e3bBaBe03aBa1Bb1BBBBBdBdBfBb1aB1aBhBbBBc0b1l1fBd1a1kBd0BcBa11bBbBBb1BeBaBBf2dBB0bBe1bBBe1a1i1aBc1g3cBBc1BcBaBdBb3aBdBbBcBbBBc1bB1b2dBgBBBBfBa1BBeB2cB0cBd2BfBaB2b2d1bBBcBbBbB1i0a2aBbB0bBc0bBe1bBcBB", "9x9:k12bBcBbBb3h1c0a1a2cBhBbBb2cBb0Bk", "12x12:c1Bb0d0bBaBj2e0BeBa1g3bBf1b3b0bB02BbBb1b1f1bBg0aBeB2e2jBaBb1dBb10c", "15x15:Ba2d0fB1cBb0Bb21g1a1b2aB3kBgBb2cBBBbBBf1Ba2BaBhBaBi2aBcBd3a1iB0BeBb2aBd10dBb2aBB1BBcBf1f10BBaBb1bBfB0fBBa1a10e0b", "8x8:g1BBeBpBc2c2c1b2d011i", "19x19:e1d0BdBBaB1Ba2b1bBaBb2BBaB1d1eBbBa3b1Bd2dBBn0BfBd1aBaBaBcBdBa1BBb3b0b1c2bBgBdBa1aBaB3bBfBk0B1b1b2BBkBfBb01aBaBa2d2gBbBc3bBb1bBB2a2dBcBa0a1aBdBf1Bn0Bd1dBBb1a1b1eBdBBaB10b0aBb0b1a3BBaBBdBBdBe", "21x21:b3f1Bc1cBBaBcBBbBb11bBeBaB2bBiBa3aBeBbB1c1b0aBd1BhBBeBbBdBc02aBBb1a0a0dBcBe0bBeBBBb4aBkBbBeBb1c1a2b0cBcBaBb1bBbBBdBa2BaBaBBa1d1Bb2bBbBaBc2cBbBaBc1bBeBbBkBa2bBB0eBbBeBc1dBa0aBbB0aBBcBd0bBeB2h2BdBa2bBc01bBe2aBa1iBbBBaBeBb2Bb0bBBcBaBBcBcBBf3b", "20x20:1e0aBb0aBeBaBB1BdBBdBB11c0BbBf2bBBdBdBaBBaBd0b1c3a3aBB11aBaBcBa1e1BbBBeBc1BdBbBd3Bb1c10hBBc0bBf0BfBeBBBBbBBb2BBBf1BBBbBBbBBBBe1fB1f3bBc2BhB1cBb0Bd2bBdBBcBeB1bBBeBa3c0a2aBBBBaBa0c1bBdBaB0a3d0dB1bBfBbBBcB1B2dB1d11B0aBeBaBbBaBeB", "22x22:BhBBc2aBdBb1c0BbBa0eB2c20d2aBaBc0aBBBBb1Ba1eBbBjBdBcBcB1a1cBc1b2d3aBBh1a1Bd1Bh1aBd2d1bBbBBaBBd0cBoBcBcBBa1fBaBbBaBaBe1a1BbBaBB1Ba2bB2aBeBaBa4b2aBfBaB1c0c2o2cBdBBa2BbBb1dBdBa1h01dB1a1hBBa2d1bBcBcBaBBcBc0d2j2bBe3a0BbBBB0aBcBa2aBdB2cB1e2aBb01cBbBdBaBcBBhB", "24x24:a1b0b1cBB0BBb0bBgBcBa0cBBBbBa4a1dBaBcBb1hBc1aBc0bBa1aBBBaBbBb1B2BhBb1aBBBBb1BBbBBB1b2Ba2aBBaBaBBg1bBBbBBBa2b3bBeBdB2aBBBdBc1dBa2aB1BbBaBaBaBBa2Ba1aBaBfBa2a2a11g0bBd1pBBdB0eB1aBaB1cBb1aBbB2bBaBBfBaBa2cB1bBa1Be2jBcBdBdBiBBBb2aB3dBa3bBcBa2aBBjBb1b1bBBc2iBe0dBBh1bBB1d1B0h0Bc3aBa0bBb2a1h3cBBaBBBaBc2aBaBBaBBaBa2BbBaBBaBaBaBBbBB0f2lBBaBBBBBa", "23x23:a0bB0bBaBaBb2bBBaBbBa3aBBbBeBB1aBbBBdBaB2d0Bf2eBe2aBBb0c2bBa1cBe00BaBb2gB1e1Bb2aBbBaBB2c1a0BdBbBa2bBaBBBaBhBdBB1Bb2iBa10bBhB1d2BBlBfBc0aB0c0B1hBBaBbBBBB1BBaBb3fBcBaBBcBB1dBBdB0BlBi2aBBbBeBBBaBhBdB2BBa1BcBa00d2b3aBbBe2Be1Bb2aBb2aB1aBc2eBBBaBbBgBeBaBBb0cBbBdBaB0dBBfBb1a4aBBbBeBB0a0b2aBbBBbBa3aBb1bB1aBa", "14x14:Bb0BbB2dBe0q1g21b1b2b1bBbBdBbB2h2bBaBbBbBBlBBbBbBaBb2hB0b2d2bBbBbBb1bB1gBqBe2dBBb2Bb1", "18x18:eBbB1b1h0b0dBb3dBnBc0a0a1B1BB1a2aBfBc1BcBdBBaBb2BbBBb1aB1BB1b2bB2bBb2BBeBfBm1BpBBmBf2e1B2bBb1Bb2bB1B1BaBb1BbBBbBa2BdBcB1cBfBaBa01BBB1aBaBc2n0d2bBdBb3h1b1Bb1e", "24x24:c2bBcBBa1gBb1aBdBa1g0BgBaBBb3Ba00BcBaBaBaBbBbBi1a0b11c2BBBbBaBbBeBBaBBa2b2cBj2BeB2BaBaBa11aBa0BBbBBbBgBfBBaBBBa0BcBaBBiBaBiBBb3aBcBa1c1aBd2BdBaBB0bBbBb1aBbBdBfBaBbBcBBBBb10c1b2aBd11BbBB21bBBa0e1d2aBBcBcBBBBgBcBBBbBa3a2c3a1e0aBBBBBgBe0c1Bd0BcBbBcBB0mBdBBaBf2c1B1cBBa2bBaBBBaBaBd3aB1f2dBdBaBbB2b0a1aBbBBc1bBaBeBbBcB1aB12cBaBaBBf0bBBbBbBa2a", "24x24:BBaBa2aBaBBBBdBeBbBBaBg1Bd1aBaBa1BbBB2BaBd3c2aBBdBfBB1cBa2BBa2BaBBBB0cBdBaBbBg0gBd2b0aBBBBg0aBbBgBeBBBa0Bf2Bd0aBb0dBa2fBBcBc1bBfBBBaBcBc2a0d1bBbBdBbBBaBBb1eB0c0c0a1bBBb1a1cBcB0eBb1BaBBb0d2b0b3dBa2cBcBa1BBfBbBc1cB1fBa1d1bBaBd0Bf00a0B0eBg0b0aBgBBBBaBb0dBg1g1bBa2d2c1BBBBaB2aBB2aBc3BBfBdB1a1cBd2aBBBBbB0a2a1aBd00g1aBBbBe0dBBBBaBaBaBaBB", "21x21:dBeBb2bBBa2a2cBaBaBaB1j3c1g0a10o1BfBbBc3aBBc1d1b0dBcBlBa0aB0bBBa1eBb2B1dB1d1BcBcBbBi1a1cBBBc2b0a0g12c2aBa2bBB1aB1c1eB2aBa00cBaBd0c3aBBf2aBBBB1Bd2aB0a1dBBa2gBkBb1B0c0aBiBeBdBa1lBa0BaBaBaBaB1f1aBbBaBbBaBaBb1g2a2a1aBBaBaBe2bBb1b1h2aBBb", "25x25:b2aBc1cBcBcBa2eBb1Ba0aBBBa0a0Bb3cBaBBBoBB1aB1bBcBdBd0cBbBBbBBd1Bc12d01bBBBBBbB1BgBBBbBBBBaB2h2aBh0BaBBbBa3bBeBbBaBbBBkBBBqBbBb0b3bBhBaBaBBbBBaBBbBBa2aBb3cBb00BBBaB1BBBbBcBbBBhBhBBbBcBbBB2B1aBBBBBbBcBb1aBaBBbBBaBBbB0a1a2h0b1bBb2bBqBBBk2Bb1aBbBe2bBaBbBBaBBh2aBhBBaBBBBbB1BgBB0b2BBBBbBBd01c2BdB1bBBbBc2dBd0cBbB0a0BBoBBBa0cBb0Ba3aBBBa1a11bBeBaBcBcBcBcBa1b", "24x24:Bb1dBb1aBa1bB2bBlBa2dBeBaBe2BaBaBBcB1c0c0c1BaBcBk0hBb3aB00BhBBb2BiB1a2Ba02b1b1bBBcBdBeBbB0c1aBbBaBB2f1BgBpBe1a1e0B0b0aBBBBa2h1Bb1bBB1bBBBgB0b1eBBbBBBgBBbBe0a1BBBa2hB0bBb1eBe1aBeBB0eBBg2n2bBBc1a2b2aBBBd01b1bBbBBc2dBfB1bBBi1BaB1bBhBbBaB000g3cBBa2cBiBaBe01aBaB1cBBc2kBaBdBe0b1d1b2aBa1bBBb1a", "25x25:c2c1c0aBd2aBBB2aBbBaBbBiBa1BdB2eBaB2eBgBbBBBd3bBBbBcBBBaBBBaBB1g0a3b0bBa2aB2bBdBc0b3dBe2bBb0f3aBBBaBBa0bBBeBBb0cBbBb1e1a0aBaBd1dBhBcBBBa0d2bBBcBf2bBaBa0aBd0c0BdBa30d0j0BaBBaBe1d2BaBa2aBBBaBBBBBjBfBBbBBb2a2f1b1cBBaB1bBbBaBe0c0BbBaBBb2cBc2aBgB12dBaBb1Bc0b0iBBc10BbBcB1aB0bBB1BaBk1bBaBBBBb2eBdBbBaB1bBa1a1e1b1BBBbBB1dBcBa2gBBa3BaBBa1BB1bBaBBbBBaBdB1aBbBBhBaBBa2dBbB2a", "13x13:eBBcBBc2hBaBaBaB0a1BdB1c1a0c2d0dB2fBl2aBc0Bh0bBbBh1b3f3f200BBc1h2aBi2a2g1", "10x10:fBaBe1f1BaBb0a2b2bBaBbBr2bBaBb0bBa1b1a1Bf1eBa0f", "19x19:b00aBaBcBa2aBBdBcB1cB1cBb1BdBB1aBBBd2Bd3bBc0b0d2d2g1dBtBBb0b1aBbBbB1bBbBbBcBb1bBc3m3eBkBe3mBcBbBbBc1b0b2bBBb3bBaBbBb1BtBd0gBdBdBb2cBb1d2Bd0BBa1B1dB2b0cBBcBBc0dB1aBaBcBa2aBBb", "10x10:c02b1lBdBi1cBbB2BBcBBcBBB2b1cBiBdBl1bB1c", "10x10:Ba0aBBaBaBu012bBBBvBB1bBB2uBa3aBBaBaB", "14x14:a2dBdBBbBfB12eBaBa2BcB1bBaBc3dBa2bBBaBcBBd0lBBBc1Ba1e3a2bBBb2gBaBa4gBdBh0a0iBBdBeBaB1dBBaB2BaBBaBdBe", "17x17:2c1c2aBc3dB0fBa1b4f2cBaBaB2lB0f1b01iBg2d01Ba0BbB1s1a0BaB2b1d2iBd1b1Ba01aBsB0b01a100d0g1i10b1fB2l0Ba3a2c2f1bBaBf0Bd1c1aBc1c0", "22x22:a2a2BbBfBbBBa2b0BeBBb20eBBdBBa0a1BbBBa0a1BfBb1hBb2cBBrBBaBaBe0BBBeBaBe1a0h0aBdBeBa2d0aBe0c20bBf2b0BcBaBc2aB0b01aBcBaBaBdBh1d0b1dBhBdBa0a1cBa11bB1aBc0aBc10bBfBb0BcBeBa0dBaBeBdBaBh2a1eBa0eBBBBe1aBa2Br1BcBb2hBbBfB2aBaBBbBBa0a11d12eB1bB1eB1bBaBBbBfBbBBaBa", "8x8:i1001BBkBbBd2b2k1BBB01i", "22x22:bBfBBd2bBa2a2c1a1d3a0bBh2aBaBaBdBiBcBjBBaB2cBb1BBh2B1cBBBBfBb0aBaBbB1B1BbBdBb0b1B1aBdBfB0hBaBf3BBd0a10bBe1BBc1bBe0BgBBaBBa3aBe0bBb0f4aB0fBaB2BbBfBc00BfBjBaBe2b0B1dBB2bBc0eBaBd0b3bBcBb0d01bBcBaBa1g0cBgBa2fBcBgBBaBB2d1aB0b21Be1fBb0e2aBeBfBBaBaBcBb3bB", "14x14:aBbBaBBa1bBbBBhB1p4d11dBcBb1bBbBbB2BhBB1cB1dB1fB1dBBcBB0hB2BbBbBb2b2c0dBBdBpBBhB1bBbBa20a1bBa", "21x21:aBa1fBc2cB1aBaB1BBg2aBc1aB2cBb3aBbBb1bBdBB1bBa2aBa0eBd01BbBaBBaBBbBaBa2lBBb3bBaB1bBa0cBcBb2cBcBbBB1c2aBd2dBBdBaBjBBBBa0a0d2a3b10bBa0a11aB2aBaBb2BbBaBdBa1aBBBBj1a2dB1dBdBaBcBBBbBc1cBb1c1c1a0b1BaBb1bBBl2aBa1bBBa0Ba2bBBBd0e1aBaBaBb1B0dBb0bBb1a0bBcBBa2cBaBg0BBBaBaBBc0c0f1aBa", "25x25:1a0c0BBBBc2c1BdBb1eB0bBdBb1bBcBBBeBaBcBa1BdBaBaBa0d1BbBa1BBa0aB1BBBcBa1cBbBBaBBaB1aBBbBc2aB0g2aB1bBBaBaB1eBBc2bBdBb1BbBB3b1c2a2bBBBa2BcBBdBBcB3aBBBBBg1bBbBa1dBeBe1BBBaBBaBcBBa0d1aBBaB1aBaBaBBaBBBBbBe2b1oBbBe1bBBB2aBBaBaBaBBa00a0d1aBBcBaB2aBBBBeBe0d1aBbBb2gBBBBBaBBcBBdB2cBBa1BBb2aBc2bB20bBBbBdBbBcBBe1BaBaBBbBBaBgBBaBcBbBBaBBaBBaBBbBc2aBcBBBB2a2aBB1a2bB2dBaBa2aBdBBaBc0a1e1BBcBbBbBdBbB0e1b1dB0cBcBBBB1cBaB", "10x10:aBg1aBBkBb22d1bBBb2dBdBdBg1b3BfBbBBbB2h1g1", "19x19:aBBbBBBaBaBb0dBb4bBcBaBBeBcB2b0cBaBc1aBaBbBBeB1eBaBaBc2c1e3cBaB0bB1aBaBbBiBaBaBeBBBBbBb2BbB1cBBc3bBc01Ba1cBBcB1BkBc2bBcBB1a3cBB2BbBbB3bB2c0iBa2aBeBcBaBBbB0aBaBbBaBa0a2c1c1fBaBb1BeB2d2cBBb1cBaBcBBb0bBcBaB3fBBbBBBaBaBbBd", "18x18:0BcBbBBaBiBiBaBBb100aB2cBc0b2fBbBb0eBa2cBiBa1cBBaBb0bBa1eBBc2n1BB1aBaB1b1hBBBbBa1jBBBbBa3hB0BBa0a0Bb0d01cBiBc1Ba2b1b0aBb1aBcBiBgBbBb1f0BBaB1cBcBb2cBiBa2BaB1c2bBBaBf", "13x13:1BaBa2b0cBe0f0cBb1bBe0gBa2Be1qBBbBa0a1a0aBb2BqBeB2a2g1e3b2bBc0f2eBc0bBa1aBB", "9x9:b1aBaBk0a3c1a1cBa0fBa0f0aBc1a0c1aBk1aBa0b", "16x16:d01aBg1B1c1aBBdBBbB1eBaB2b1b2eBaB0a3hBBi1aBe1Bb1Bf1iBfBc2BBBbBBbBBBBcBf3i0fB2bBBe3aBi01hBa1Ba2e1bBb20aBeBBbB0d0Ba0cBBBgBaB1d", "13x13:a2i2d10c00g1a2aBdBcBcBc0cBbBb3c0a2gBaBBkB0a3gBa1c3b3bBc0cBc1cBdBa1aBgBBcB0d0i1a", "14x14:c1bBa0dBb2c2a0B00fBhBBBbBe1aBd3aBb0aBa2gBBcBb2eBa0aBaBgBaBhBBbBB2eBjBbBb3aBcBbBa1BaBaB2d2hBB2aBcBe1Bb1b", "17x17:cBeB0f1a22cBBf2bBi1a1bBb1c1c3d1aBbBc1f0aBb1b0v1gBB1BfBaBa30e1Ba1BdBc0BBBfBa0a1k0g1b2k0bBc1f1a1bBc1c2d3b1iBa2bBBaBBc00f1dBeBBf", "7x7:g2Bc2Bb1a2k2a1bBBcBBg", "24x24:eBc2c2bBBaBa2c4f1BBdB01aBBa2aBb0eBc1kBb1bBdBaBB1a2b1b2BbBc100cBbBBB2fBBbBbBa2aBBaBeBBBbB11cB0bBb3fBBaBcBbBeBaBaBdBaBaBb2BBdBcBb1dBBBBd1c1c2a2BB1aBiBb1BB1BbBdBa0d4cBbBl1bBc0d2aBd1bBBBBBbBi0aB0B1a1cBcBdB0BBdBbBcBd0BBbBaBa2dBa2aBeBb2cBaBBfBb2bBBcB0Bb1B1e2aBBaBaBb1bBBf10BBbBcBB1cBbBBb2bBa2BBaBd0bBbBk0c2e3bBa1aB0aBBBd0B2f0cBaBaBBbBcBcBe", "9x9:a1gBBb1bBd1Ba4c2hBbBBa2lBgBk3d", "20x20:BBB1BaBkBBeBBBBBaBBb2eBaBa21b0BBcBBd2dBdBa4aBBeBa1e1a4b1c0BdBaBcBaBe1f0Be1a0dBj2Bf1B1bB11b0dBeBc3aBaBdBBaBb1BdBaBBBa1BBjBc1BBaBa2aBaB1BaBb1Bd3aBBBbBa0aBBaBa0cBBb3b1c1aBBaBvB0B0BaBc0Bd2iBaBf3aBBb2b11dBB1aB1bBcBBa2cBBBeBaBa0eBBB", "15x15:aBBBc2c0BBfB2aBBh2g3i0BBg0b3b2bBbBbB12aBcBaBB1zuBB1a1cBa2BBbBb1bBb2bBgBBBi2g1hBBaB0fB1Bc3c0BBa", "8x8:i3cBBb1b2e1jBe2b3bB1cBi", "15x15:bB1bBBBb1BbBaBd0d0aBa01iB1fB2aBBkBB2g0bBe0b2aBcBe1cBBf1fBBc0e1c0a2b1eBb1g11Bk0BaB1f2BiB1a2a1d2dBaBbBBbBB1b0Bb", "12x12:a1c1Bc1aBeB3a3fBcBaBe0aBb3a1a2a1cBcBBd1B0aBbBa0c1b1q0a2cBBB1a0cB0aBaBa2g1jBBb", "18x18:aBb1a1bBaBaBbBa2iBBb3BaBaBd0a1dBeBb1bBB2cBd2a201hB0bBiBaBfBBc1cBe0a2aBfBeBcBb1a02cBcBBd2Bc4c1Ba0b2c2e1fBa0aBe1cBc1BfBa1i1b1Bh1BBaBd0cBBBb2bBeBdBa2d2aBa2Bb0BiBaBbBaBa2b1aBb3a", "23x23:eBB0fBBBBb3aBa01c1d0eBBBeB1bBf1b3hBj0aBaBa1c0dBb0b0BbBfBBb2BB3dBbBbBcBBaBBBdB0b3aBBBb2Ba2BBbB1BaBb2BbBbBdBb0bBBBBbBdBBbBBg1a2lBBd2BeB1dBa01dBc1aB0aBBa2cBd3Ba1dBBeBBd0BlBaBgBBbBBd0bBBBBb3bBd0bBbBBbBa2BBb0B0aBBb2BBaBbBBdBBBaBBcBb1bBdBBBBbBBf0bBBb2b1d2c2a1aBaBj0h3b1f0bBBe0BBe1dBc2BaBa1bBBBBf1BBe", "25x25:bBrBaBaBcBeBaBBaBa2bBdBa4a2eBa1aBf2b1aBdB0cBdBB2cBBa3bBBaBBBcB0bBc2BBfBbBB2c1aBbB1aBe1dBbBBaBaBb1BdBe1a0dBaBeBa2d0eB2cBb3eBdBBcBe1B2a1a1bBBBbBaBBgBeBbB2bBaBd1BBBbB1bBcBfBc2aBa1a2b1aBb1bB2BBBbBBaB1a1aBgBBcBdBaBeBbBc0BcBB1aBbBbBBa20cBe3aBBa2aBBBbBbBeBBaBbBjBe3c2BeBb1aBfBcBbBBBj1e12aB2BBBb2bB1BfBgBBaBBdBaBBb0aBBeBaBB2aBcBB1cBaBc3BBaBaBc1cBaBBaBBfBaBBBBaBBa1bBBb2fB1a", "21x21:a0Bb2bBb10aBa1aB1eBcBbBc20aBBbBf2l0d2aBb1h1B2bBgB0aBa2BdBBBb0e0bBB1aBBbBBb1p2cBBdBc2BhBc1eBaBcBBa0BaBfBaB21b1dBcBBaBaB1h0BBa0B1aBhB111j0Bc2Bf0b00dBbBh2cB1d2aBaBb0a02a2cBa0eBB2aBe2BdBBc1cBhBa0l00d1c3aBaBcBBB1eBfBaBbBgBb01h", "8x8:a0BbBi0f2lBaBf2c0a3dBdBc", "19x19:dBe2aBBe2c2fBaBa2bBf1cBBBe1d2BBfBaBb1f0d2c0aBb0aBdBBaBdBBfBB2d1bB0BBBBb2BBg0cBd0bBaBe1BaBaBBdBBc0f2b1j0Bc1cB1a1BBaBa2b1a1fBbBa1dBf1aBhBcBaBb2Bb2j1gBbB12bBBaBeBBBb1fB2a1aBaBBiBhBaBBbBb1a", "12x12:d1aBgBaBc1Bc2b1aBc3bBd1nBB12aB1pBBaB00Bn0d2b2cBa0bBcBBcBa3g2a0d", "15x15:d1bBe0Ba3d3a1a0h01bBbBcBBcB1a0aBc2aBa1b0BBfBf1Ba2b2cBgBBc3aBb0e0aBc1jBdBBa1aB0bBa1a0c3cBBhBaBaBb1aBd1e4aBb1d1aBaBb11bBkBBa", "11x11:aBBb3bB0n1aBaBa0b2dBdBbBe2c1gBcBeBb3d1d0bBaBaBa2nBBbBbB0a", "12x12:Bc1c2aBc3bBBd2b0BBBaBiBbBpB1b3aBaBa0BkBdBBBa0bB2cBeBaBcB10bBaBd1e3BBf1Bb", "7x7:2bBg0aBeBb1a0hBeBa3BbBc", "19x19:2b1aBd0d1bBg2b1bBaBi2aBBBBgBBcBB2BBaB2eBdBe2c2e0mBb2cBbB2dBbBBd2Bf1aBbBa1aB2Ba2bBBa0d1BdBBkBBdBBd0aB1bBaBB1a3a2b2a3fBBd3BbBdBBbBc1bBm3eBcBeBdBe1BaBBB1BcBBgBBBBa1i0aBb1b3gBb1dBdBa2b1", "23x23:aBaBb3aBB1bBBaBaB1BbBa3eBbB2dBdBeB1Ba3aBaBa3dBe0BcBcBaBcBBB2bBdBaBc3bBb1Ba2B1g0aBBcBc2dBbB2aBdBBbBaBaBd1BaBbBcBm3aBaBb1BB1eB10aBdBBc2cB2a1bBBBeBaBBdBBBa0b2aB2BBBBBaBBaBeBBg0Bb0cBb1fB0e1bBBa1fBBaBeBgBc2d1bBgBa11aBaBb2dBa0bBaBBbBbBaBBBbBc0f0e3f1Bb2aBa2eBaBb1bBfB3aBBB1dBc1gBaBBaBdBBBbB2cBBe4d2bB1c2a10cBBcBBf1aBa", "11x11:a20f0BjBaBB2aBc0fB2a0bBa2za1a0bBa0BfBcBaBB1a0jBBf10a", "25x25:Bb1e1hBaB0aBBBb1dBBb2a2BlBBb0BfBBh2cBg010b10c101BcBf0BaBaBB1aB1Bj1cBbB2h2bBBcBeBBa2jB1aBa0BcBBBf2dBa2Bd2aBaBbBB0b11bBBbBBBaBa1a3aBaBe1Ba2aBBaBBBbBBc1kBc2aBb2aBBd0eBaBB1bBaBBBBBaBb1BBaBe2dB1a2bBaBc1kBcBBbBBBaB1aBa1BeBaBaBa2aBa2BBbB1b11bB1BbBa3aBdBBa1dBfBBBcBBaBaBBjBaB2eBc01bBh2Bb1c1j0BBaBBBaBaBBfBc01B1cB0bBB0gBcBh1BfB1bB1lBBa2b11dBb2BBaBBa2h1eBbB", "17x17:0cBfBcBc01BaBBa3a0a0bBdBBbBb0cBBe1a2c0b1BBbBb2BeBb1Ba0d3cBg00aBbBc2BBdBBBa2BBaBBc2b0BeBBaBBBh0aBb1eB1dBdBa2bBbB2BB1dBbBa1dBd1b31aB0fBdBaBaBc0BBb1b0BaBcBaBdB2f3e3bBbBBfB", "22x22:BB0Bc2aBBBa3c0e1gBaBb2d1B0b1a2hBBBa0jBc0Bb0bBeBa2h0eBB2b1c0b0aBB1cBB2bB1BBBhBa1BBbBaBBa0eBaB0aBb1g1gBeBcBd2dBbBbBa10BBaBf1b3a1fB0bBbBaBBdBaBb0Be0eBcBBb1bBBa0cBb1aB1Ba2bBBh11gBdBaBbBb0c11bBBbBb2c1gBBa1bBa2BaB2BaBg0aBBaB1cBd1d2BgBBBaBa1a2a0BbB0BaBc0bBBBBdBaB1bBB0c1BBBaBaBc0dBgBaB", "14x14:1b20f0dBa2B0a1aBfBe2aBfBa0h0aBe00cBcBBk21B1aBaB0dBBa2a1BBBkBBc1c01e3a1hBaBf4aBeBfBaBaB12a3dBfBBbB", "10x10:aBaB0a2eBdBc3f1h2BaBcBl1cBg12B2d1c1r", "14x14:0eBiBcB2b1cB1a1bBaBaBcBd3c1Bi1aBc1aBjBB2aBBd21bBBbB1dBBbBBa0jBB1f2a1c1aBdBc01cB0a2bBa1aBe1cBBb1cBe0g", "12x12:c0cBm2bBaBbBa2h1aBe3dBBc2bBbBbBa3aBa0bBbBaBa01dB1c2e2aBeBa3b2aBm0e0cBd", "16x16:d1BdB1BBa0cBBBa2b2a2c10Bb2BaBBcBcBdBi2k00a1f0bBd2a1BaBa0cBeBdBa12aBi2dBc0bBgBbBa1bBb1e21b1eBbB1h2g1e1bBc3b0cBBc0002aBc2Ba1aBgBa2cBbB", "8x8:cB0lBd0b00bBBb0Bb2Bb0d2l2Bc", "16x16:a1aBc1bBB1c2dBcBcBaBaBdBB2eBpBa1bB0c2dBhBcBb0cBd1f1b2aB11aBbBb1bBk20aBhBaBaBfB2aBBd2c1aBBc0cBa2c0aBcBB2aBeBdBBBcBBa1eBa1BdB0b12b0d0aBc", "17x17:cBB2c0fBbB0Be2aBB1kBa2c2gBa1bB1fB1a2b0cBaBb2i1cBBd2B0iBB1eBa0BbBBb1cBe1B1Bh2g1aBb1aBb2cBBaBBgBBBa01a4aBd2dBcBdB1e2a1fBaBbBdBc2cB0B2aBcBdB1gBBh0b", "18x18:BaBa1fBBBeBb1cBa3bBdBBBgBd1hBa00d0b1b111Bb1eBBaBa1cBeBaBaBeBBBBBb1a20aBaBa0aBBb0bBB1bBdBaBd0Bc1fBBeBe2aBa3Bc1aBbBaBaBBcBaB1eBBBBBdBBaBb2aB1b1aBiBeBaBbBa1aBbBdBa4eB2b1b0aBcB2B0bBd0fBdBaBaBe2aBB", "13x13:bBbBa1b2e2e1d3BaBc2aBBaBaBc0cBa2b1bBaBbBcBbBcBb2g1g3b1cBbBcBbBa2bBb0aBcBc2aBa1Ba0c2a12dBeBeBb1aBbBb", "8x8:a1d3cBi1f1a0eBaBf1e0f1dBa", "13x13:kBaBb010a1a0BaBBaBaBBcBaBjBbBBBd3bB0aBdBh2cBf3e0h1BdBb0BaBi1bB2aBaBBcBaBaBbB1Ba0aBBaBkBa", "8x8:cBg1a1c1l0021l0cBaBg2c", "13x13:c1dBb3b1c3BaBf1BcB1bBk0BdBaBk2a1e1BaB1eBBa01eBa0k1aBdB1kBbBBc01fBa2Bc1b2bBd0c", "16x16:c0hBh00BB02i1f1e1e10e0bB0BBBd101BBc1c1bBcBeBh2eBBbB0B0b1Bd21b0B0BbBBeBhBe1cBbBcBcBB1B1d0BBB1b1eB1e2e2f0iBBBBB1hBh2c", "25x25:a1d0l0fBdBB0a10b3e1BB1BaBaBcBBbBa3b1a1gBaBa0aBdBBaBa1cB0cBc2aBB111cBaBaBe1c2c0BcBBa4cB0e2eBdBaBa3e1BcBBa2aBa0BBaBa1cBBBBcBbBa1eBcBBBBa00d1BaBbBeBc0Be1cBaBc2e1bBbBcBBaBBa2e1b1b2aBBdBc2iBcBd12a3bBb0e2aBBa2BcBbBbBeBc3aBc2eBBc0e0bBaBBdBBaBBB2cBeBaBbBcBBBBcBaBa2BBa1aBa3Bc21e2aBaBdBeBe10cBaB2cBBcBcBeBaBaBc1BBB0a1cBc1BcBaBaBBd0aBaBaBg0a0bBa2b0BcBa2a00B0BeBb0BaBB0dBf0l1dBa", "24x24:0b1cB1BBBBaBBc1aBeBaB0d0b0a0e1BiBBbB1f11B1a0B0BaBBiBaBe1dB2b1BdBa2bBBeBa2aBBBBaBbBBBBBaBa11dBBBBBB2BBa2bB1cBBc2jB2dBBaBbBa1bBa02aBaBBaBa1aBb3Ba1aBc0Ba1B0a1cBBBbBeBiBaBcBb1cB1cBb1d1bBd0bBc1Bc2bBc2aBi2eBb3BBc1aBBBaBBcBaBaBBbBa3aBaBBaBa02aBbBa3bBaBBdBBj2cBBcBBb2aBBBBBBBBBd21aBaBBBBBb2aBBB1aBa0eB1b1aBdBBbBBd1eBaBiB0aBBB0aBBB0fBBbB0iBBeBa1b3dBBaBe2a1cBBaBBBBB1c1bB", "8x8:eBc1b12aBm1d0m1a03bBcBe", "7x7:h1c2b0a3aBi0a2aBbBcBh", "19x19:c1fBBaBa0BBa1BaBBb2eBaBBcBBgBcBc2c0aBb1b2BBgBBa0fBBaBa2c1Ba0BB0e0a2jBBBeBf10a1B0b1fBcBcBBBbBBbB0aBBhBd3aBBd2b2b1eBBBa2BBa1aBbBa2BbBBBBcBaBBaBbBa3bBh1bBbBaBbBf0cBgBbBbBe1aBBa3BBd1a11aBaBaBaBb0h1aBcBeB0c1bBa1aBb1B", "12x12:eB2e1bBdBb0cBa2BaBd2Bf0Be1b0dBjBBjBd1b0eB1fB3d0aB0aBc0bBd3bBe1Be", "25x25:BaBbBb1aBBb3aBb2b2cBb3cBg2aBeBBi2bBdBBcBaBa1BcBfBdBBBbBBaBBaBc2B1dBaBBaB2c21B1aBBbB1e1dBBhBdBBbBa1a3b1bBc0BB0cB01dBBbBj1BfBB1B1aBBBb0c0gB1f2a2dBaBaBdBdB0cBb0hBa0d0BbBdBBB0a000aBBd0bBb2cBhBa2dBBbBbBd0a1aBdBd0BcBBbBcBg00f3jB0fBBBBBaBBa2cB1BBcB12dBBbBh1dBBbBaBa2bBbBBBBaBBbBBe3dB2a2aBBa4c2BBd1a1BaBBbBaB1cBf0dB2BbBBi1bBdBBcBbBbBcBgBaBe3BaBbBb0a1BbBaBbBbBb", "13x13:BaBb01aBBb2oBbBc2BaBBaBj1cBcBn2aBBe1eBBa0n1c1cBjBaB0aBBcBbBo1b11aBBbBaB", "15x15:BbB2jBa0c2fBdBBcBc1bBd0bBb2eBa2dB1aBeBcBBgBBc1j2aBe0a0j1cBBg10c2eBa3Bd1aBeBb1b0d0b3cBcB0d2fBcBaBj0BbB", "22x22:b1dBa2bBaBd0bB1Ba0c1dBc0aBBBBtBb0a0a1c01c0a0aBcBhBBh2fBbBBb00b0fB0b1b1d0b1b2BcBB1lBBBbBd1b0d2b1d1Be1b0b3bBeBBc2bBBaBBa2Bb1cB1cBbB2aB1aB1b1cBBeBbBbBbBeBBdBbBd3bBdBb1B1l1B0c00bBb0d0b1b00f2bB1bBBb0fBhBBh2c0aBaBc11cBaBaBbBtBB1Ba0c1dBc2aB0BbBdBa2b2aBdBb", "24x24:BbBpBbBaB1a0Bb2aBbBaBbB0aB2a1dBe2BeBdBBBcBBdBBd21cBB0BaBBBc0Bb2Bc2BBaBBaBaBp0aBc2cBb2d1b0c1cBBaBaBa1fBa0aBaB2aBb2b1c10B1c0b1bBBBaBb1j0bBaBBaBb0d1BbB0dBb3aBcBbBb2bBb1bBcB1c0b2bBbBb0b0cBaBbBdBBbBBdBbBaBBaBbBj0bBaBBBb2bBc2B10cBbBbBaBBaBaBaBfBaBa1aB2c3c1bBd1bBc2c2aBpBaBaBBaB1BcBBb3BcBB2aBBBBcB1dBBd0BcBBBd1eBBe0dBaBBaBBbBa2bBa0bBBaBBa2b2p1bB", "18x18:BbBaBb2aB1aBBbBb0dBe0h1d01bBb1aBk0d2BBBbBa0cBc1e2aBe0B2c10c0BaBjBa1dBbB1a1b2c0eBBg3Bg1BeBcBbBaBBb0d1aBj0aBBcBBcB20e1aBe3c2c0aBbBBBBd3kBaBb1bBBdBhBe2d3b0bBBaB0a1b2aBbB", "23x23:aBaBb1aB0cBBBBBaBeBi0bBBc4aBaBa1b100Bb1aBa2bBaBa1a2BbBBf0dBBa2e0c1mBdB1aBdBb1B0dB1BbB1dBBBb0BaBBaBB0fBcB1eB1bBaBBe2e0aBbBaBBdBBBaBbB2Bc1aBaBaB2cB0a0s1i0s1aB0c02aBaBaBcBBBbBaB1BdB0aBbBa0eBeBBaBbBBeB1cBfBBBaB2aBBbB1BdBBb3BBdBBBbBd3aBBdBmBc1eBaBBd1fBBbB2aBa2aBb1a3aBb00B0b1aBaBaBcBBb1iBe2aBBBB1cB1aBbBa3a", "12x12:Bc0fBaB1b0c20bBaBf0hBa0eB1b2c2j2b1jBcBbBBe3a0hBfBa1bB1c1bB1a0f2cB", "16x16:aB0c1e1BBaBdBb1d1aBBBa2a1e1c11b0aBa2d0Bd1e1BnBc211eBbBg1a0bBBc2b1f0bBcBBb1aBgBb0eBBBc1n00eBd3Bd1a2aBbBBc0eBa0aBBBa1d1bBdBaBBBeBc12a", "22x22:a3aBg0BbB0c0aBbBbBeBeBaBbB2b3a2c3a2e1cBaBBaBBa0Bc3bBBaBa2a2cBBhBaBaBaBcBaBBBBBaBBgBaBb1a1aBBaBBBa2b2BbBcBBaB0bBBcBbBBdBB0aBaBbBdBBBc2a0e1BcB1bBB2b0aBBaBcBb00b1bBb0aB1aBc1bBBbBbBb1a1eBBcBBbBBBd1BBa0aBb1dBBBbBc1BaBBbBBc2bBBb1bBaBaBBaBB1aBbBBbBc2aBBBB3aB1gBBa2cBBh1aBaBb3aBBaBBa1BcBbB0aBbBBbBa1c2a2eBbBb1b3eBeBa3b3aBg01bB1cBa", "20x20:B0aBaBb0eBBaBc0b1BBc2a1BBaBbBdBBBaB2b1bBb3Ba0b1e1a1c1bBa1Ba0aBaBBeB1aBBdBBB0eBrBa3cBeBBb0hB0B21aBg1aBBaBbBcBf0Bc2cBBc3cBBfBcBbBaB0aBg1a1BBBBh1b10eBc3aBr2eBB1BdBBaBBeBBaBa1a2BaBb2c1a1eBb1aBBbBb1bBBaBBBd1b4aBB0aBcBBBbBcBaB1e2bBaBaBB", "21x21:BcBdB11aBdBaBc1aBcBa1cBe3bBc3e2a0a2e0bB2b0hBBgBBb1cBeBaBBb0bBe1BaBa3e2Ba1aBfB1c0aBdBdB1BaBa3iBbBBc1eB2f2eBb1aBBBc2cBcBc3cBBBa1b1eBfBBe1cB0bBiBa2aB12d1d2aBcBBfBaBaBBe4a1aBBe4bBb10a3eBcBbBBgBBhBbB3bBe0a0a1eBcBbBeBcBa0c2a2c1aBd0aBBBd1cB", "20x20:d0B1bBkBa2bBBe4aBBB1bBbB2aBbBj1aBa1bBe2aBaBbBb3bBB1b1bBa3aBcBe2fB1aBa1d1Bb2b1dBBd0h1aBaBBjBeBBe2c1dBbBBc01c00bBd2c2eBBeBjBBaBa2h0d01d0bBb1Bd2aBaB1f1eBc1a3aBb1bBB2bBbBbBa4a1e2bBa2aBj0b3aBBb0bBBB2a1eB2b2aBkBbBBBd", "20x20:c01a3bBb2aB2aBgBbB1cBd3a1a2c1b2c0bBBb11oBBBaBaBBBbBaBb0a1f3bBBBc0aBaBa0d0aBBa0c1aBBdBBcBcBdBb3aBBd1eBa2a1Ba2a1BaBBb0Ba0dBeBaBBb1BaBdBi0e0a0aBBa1aB0c1c1dBb3aBBb0aBBaBc2aBBdBbBbB01c1a1aBaBc1a1B1bBaBbBaBdB1o01B1a2cBbBcBbB1gBbBBcBdBd01aBb2bBaB0a1b", "10x10:BaBBBeBBaBe3aBBgBf1bBb3g1Ba2eBaBq0c1c2a0dBcB", "21x21:BfBb1b2fBa3aBaBBBbBb1BBaBaBaBB2BBkB01B1iBaBk2cB2aBaBaBBc1eB0aBa2cBa1aB0c0sBB2a2c1e2cBaBBBs1cB1kBBcB1cBBc1cBBc0Bc1Bk20cBsBBBa0cBe2c0aBB0sBc12aBaBc2a2a11e1cBBa0aBaBBc2k0a1iBBBB2kBBBBBaBaBa200b1b0BBaBa3aBf1b1bBfB", "18x18:bBaBcBcBcBa0BaBb02cB1b2b0cBa2e1c3BeBhBbBa00Ba3aBB0a0dB1aBBBcBeBBBc3aBaB0bBbBB1BfBdBaBBdBaBBBa1fBBBd0d0b0a0Bc3fBBbBe3Bb0aBBaBBeBbBaBB2dBb1BcBBBcBBe2fBbBBfBb2b2d1c1h1b011b0B1BaBBa0fBaBBc1g", "11x11:a0eBBd1c2b10hBcB0Bb2a0bBcB2aBf01cBaBhB0B0BfBcBaBc3aBmBc1a2BaB", "11x11:BdBa1bBm0d10b0a0bBp0bBc0b0p3bBaBbBBd0m0b0a1dB", "9x9:bBb1cBg1bB1cBg4b1bBa3bBb0gBc10b1gBc0bBb", "17x17:d0g0d0dBa1aBa2d0B1d1c2d1BfBc0i0a1a101a0aBd2fBf0bBa1a0aBaBaBa1a1aB1eBaBe01bBbBaBaBa1b1bBBeBa2eBBaBa3aBaBaBaBa0aBbBfBf2dBaBaB1BaBa0iBcBf11d3c1dB11dBa2a1aBd2d1gBd", "21x21:Ba3cBBBa0aBB0cBaB0BeBb0b2e2BaBBaB1dBdB1aB0b0aBcBbBb2c1aBe1k2iBB0e1BBeBb1a0c10Bc1a0bBaBg1BBgBaBdBaBeBaBd1b4aBb2BcBBbBa0eBBdBB0dBBe1a2bB0cB0b2aBbBdBaBe1aBd1aBg0B0gBa3bBaBc00Bc0aBb2eBB1eBB1i0kBeBaBcBbBb2cBaBbBBa22dBd11aB1aBBeBbBbBeBBBaBcBB0a1aBBBcBaB", "10x10:dBBf0d2c1f0c2dBe2bBfBb0eBd1c1fBcBd2f20d", "15x15:0c0bBgBcBbBc3BaBa1aB0a1aBmBfB0aBg0bBdBBa00b0fBd2bB2aBaBeBcBa2B2bBdBb02aBd3BaBBb1d1aBg1bBhBf0aBa10a1a2f2cBbBcB0a1BcBbBg", "18x18:sBBaBc00cBa22e3h1dB1aBaBaBBBBa2a2a2BcBBBBBbBBBBBcBBbB2bB3bBBb1BgBbBh2a1b0aBBaBbBa1f0BdBBj1BdBBfBa0b1aB2aBb2aBhBbBgB1bBBbB0b2Bb1Bc1BBB2bBBBBBc1BaBaBaBBB1aBaBaBBdBh2eBBa0c30cBaBBs", "22x22:Ba2cBBaBbBg1BBBh3aBaBa1cBgBbB0BaB1bBc1cBb12aBdBc1e2c0c2l2g1eBkBa0cBa0c0BBaBaB1BgBc1b1b0b1cBaBc30hBBf0aBeBaB0aBb2c0BbBB1d2aBBbBBa1dB0Bb1Bc1b2aBBa1e1aBfBBh11cBa4cBbBbBbBcBgBBBa1aB12c2a1cBaBk1eBg4lBc2cBe2cBdBa3Bb2cBcBbB2a3BBbBg2c0a1aBa3hBBBBgBbBaBBc2aB"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 12;
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
        LightUpManager.currentPack = 12;
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