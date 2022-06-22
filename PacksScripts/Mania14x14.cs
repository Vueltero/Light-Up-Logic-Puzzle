﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Mania14x14 : MonoBehaviour
{
    string[] puzzles =
    {
        "14x14:b1bBb0b0bBlBbBbBbBb0b2cBd0cBBd0bBd1aBcBbBc2aBb1aBbBaBbBBb0a1bBa0b2aBc1bBcBaBdBb2dBBcBdBc2bBbBbBb0b3lBb1bBbBbBb", "14x14:Ba3aBdBn1aBe2bBBfBaBa2aBc21dBd0c1b0b2a1bBmBcB2cBm2bBa2b2bBc3dBdBBc2a3aBaBfB1b2e3aBnBdBa2aB", "14x14:d0d1d0aBBfB1aBc1aBB1BaBe2h0pBcBd2cBb1bBb2bBdBb3b1bBb1c3dBc0pBh2eBaBB1Ba2c0a0BfB2aBd2dBd", "14x14:bBcBBc1b0lBBBcBb3cBBc3a0BBBaBd1bBaBBa2bBpBcBb1cBb1c0bBc2pBbBaBBaBbBdBa2BB2aBcBBcBbBcBB1lBbBc21c1b", "14x14:aBBa2f2aB2BB2c100bBc1aBc1aB3c2fBeBaBc0BdBBbBaBa0B0bBdBcBBBa02aBaBb2Bh1BdBdBb1g1b10dBaBh0aBe0c1c1aBf10eB11a1aBBBB", "14x14:dBaB1aBb0c2aBBcBoBc0b2e3a3cBbBeBBbBbBaB1gBc1g1BBf2a2j2a3BaBBgBbBbBB1cB1bBBBa0cBaBBaBa1e4cBaB2dBdBeBa0", "14x14:BBbBaBeBBBb3dB2cBbBBb2d1m1Bb1cBaBeBa2eBaBh2Be2aB2aBe2Bh2aBe1aBeBaBcBbB1mBdBb1Bb2cB1d1b1B2e0aBbBB", "14x14:a1b2eBBBg11dB2c2a2aBh2bBBaBb1cBaBBB1bBdB1bBiBcBcBe1cBc2eBBb2j1aB1BBb2f2bBBa1b1eBaBaBl10dBBa0b1e01Ba", "14x14:aBe1aBb1a2f2eBcBdBa0eBh0b2dBj2b1Ba00dB0dBB1j1BBdB2d1BaB1b0j0dBbBhBe0a1d0cBe0fBa2b2a2eBa", "14x14:0c0b3aBBfBBdBkBd2Bc2BbBcBBa1gBaBbB0b2Bd4cBBdBBd1d0d2BdB1cBd11bBBb1aBg0aB2cBb1Bc2BdBkBdBBfBBa0bBc0", "14x14:aBBaBcBdB1eBa0a2iBBBaB1c2c0j3e01c0aBBB2f0a1aBBgBdB1gBdBBBBfBaBb0eB2cBaBc1nB21aB1bBe3aBaBdBBa0cBdB", "14x14:bBBc0b1g2l3Ba0fB1fBB1aBaBcBg2BdBc0fBbBa1eBdBeBaBb2f0cBd2BgBcBa0a1BBfB2f0aBBl0gBb0cB2b", "14x14:a1dBBaBa2a0BgBeBBb0b01aBdB0gB1Bo0d1jBc2bBfBc0b3d1d1wB2gB01aBBbBbBBaBcBgBfBd12a1a1aB", "14x14:g0b2a2f2fB1aBaBe0BcBBaBa01Ba1aBfBeBbBd11cBdB1dBbBc1BBdBbBc1dB0c0hBeBb11Ba2aBBBaBaBc0a1eB1h0f01gBb2aBa", "14x14:aBeBBa0e02a1b0aBb22aBaBhBaBbB0d0l1dBdBBcBB1bBcBb1Be2cBbBBdBd2BcB10j0eBb1BdBcBaBaBhBbBBa4bBa2b1a0eBBaBc", "14x14:b00bBa3aBjBbBbBBaBi4bB2bBcBBbBn0dBBk0d0aBeB0cBe1a2aBf2b0bBd0aBcBa2bBbBg0d2b2j1Ba0BBf1aBdBa", "14x14:cBBb2a1a1c1aB1bBd1a0iBe2cBe1B0d1fBBi1d11hBfBh0Bd2iBBfBd2BBeBc1e3iBaBdBbBBa3c0aBa1bBBc", "14x14:Bb2BiBa3aBd3aBi0B0Bf3b1Bh2aBBdB0gBc0h0f2dBfBhBcBg1BdBBaBhB1b2fB0BBiBa0d3aBaBiBBbB", "14x14:aB0cBBc1BaBlBBbBbBBbBb1q0f0c00bBdBb2Bf11l1BfB0bBdBbB2c1f1qBb0b1Bb0bBBlBaB1cB1cBBa", "14x14:cBeBBaBcBBb2BqB1BaB0a0Bb0b1a0s0dBd2e21dBa0eB1d1e0d1r1BaBBbBbBa1kB0BbB1b11iBeBBaBa", "14x14:b1b1b1b2cB0g1aBa3d1aBd0Ba2gBg0Ba0Ba2dBe1d0aBbBaBc1BhB0cBaBb1a1dBe1dBa01aB2g1gBa1BdBa0dBa2aBg00cBb1b0bBb", "14x14:Bd2bBaBBaBdBiBa3aBB0b0aBbBoBeBb0BaBcBaBBc0a0e3b0bBdBbBbBe2aBcB2a0cBaB1bBe2oBbBa1b1BBa1a0i1d1aB1aBb1dB", "14x14:Ba2bBa1bBbBx1bB1aBcBBaBg1BcB1hB2aBBdBBb0aBB0bBfBbBBBaBbB2dB2aB1h1Bc1BgBaBBcBa0BbBx2bBb0aBbBaB", "14x14:Bd1bBaBbBd0e1hBa0a0dB2n1bB1e2a1h1a2a2bBc0BaBh0aBBc1b1a1a1hBa1eB0b1n0Bd1a1a2hBeBd0bBa3b1d1", "14x14:dBaB1a1eB0c1Bc0Bc2cBBc3cBjBbBB1fBB0f2b0hBBdBBf1BdB2hBb2fB00fB0BbBjBc2cB0c2c21cBBc01e2aB0a1d", "14x14:BdBBBBd1c30d1Bh1b1hBf1cBaBBfB2aB1c3dBc0dBBbBBhBBb0BdBc0d2cBBa2BfBBaBc0fBh0bBh0BdB2c1dBBB2dB", "14x14:0cBa11a1cB0lBc2a1bBa1e1a2aBBaBa1bBl1aBaBf1aBb0dB1dBb0d1BdBbBa2f2a1a1l0b2a2a02a3aBe3aBb3a2cBl10cBa2Ba1c0", "14x14:bBdBcBf3e1c0a2BeBa2a1aBbBfBdBa21aBa11a0j0dBc2r1c0dBj1a00aBa00a3dBfBbBa3aBa3eB3aBcBe1fBcBdBb", "14x14:bBBe1j1aBg1a2f2a0dBc1Bc01b2dBaB1cBaBBBbBq2b1q2bBB0a1cBBaBd0b21cB0c1dBa2f1a1g1aBj0e0Bb", "14x14:d1dBhBd2d1b2b1BbBb2fBBgBdBBdBbBbBa11a0b1eBdBhBd0e0b1aBBa0bBbBdBBd1gB1f2bBbB1b2b0d2dBhBdBd", "14x14:1aBa0BaBc11h10eBeBnBBe1fBb0bB0c2bBe2c0bBd0eBbBdBb0c1b2eB1f1bBb0gB0eBeBnBBeBa0a1Ba2c10a", "14x14:Ba1B1b3bB0hBaBaBe0o0b2BBaBa2hBbB2cBB0d2aBa3BbBfBfBf2bB2aBa0d1B1c1BbBhBaBa1BBb2oBe1aBaBhBBbBb0BBaB", "14x14:a1aBfBdBaBa0aBBB0e4cBf0BbBgBaBBBBB1a2cBbBoBBaBb2fBa1eBdBdBbBc3d0cBaBbBaBaBe2bBbBhBaBBaBa2a0f2eB1a1bBaBBb", "14x14:a21bBb1bB0dBaBbBa1q11a1aBBBBaBa01d2d2fBb2b1bBb1lB0l0bBb0bBbBfBdBdBBaBaB00BaBa20q2a1b1a2dBBb0bBbB0a", "14x14:e0bBe2a2h0aBfB1u3aBaBbBa3aBcBc1BcBcBBa2dBa1BbBBaBdBaBBcBc31c1cBa1aBbBa2aBu0BfBa1h0aBe1b3e", "14x14:a1BBa2b2bBBBk1dBcBeBBcBb2bB1Bc1hBeBhBa1aBB0BaBe0bBeBa1BBBaBa3h2eBh2cBB3bBbBcBBe0c3d1kBB1b1bBaB0Ba", "14x14:a0iBhBBb1b11bBBd0eBdBbBa0d2BbBa2b1f1j0g1BaBb0a00gBj1fBb2a0b22d3a2b0d3e1d11bBBb1b0Bh0i1a", "14x14:a0c1cBBaBlBB2dBa1cBBb1b00e0b2e1bB1bBa0a0B2bBg1dBdBdBdBdBg0b002a2aBbBBbBe1b2eB2bBbBBc3aBdB1BlBaBBcBcBa", "14x14:i3a2b0bBBaBiBc0cBa1BfBaBjBbBBcB0b1b3dBeBd2dBc0d0dB0b1bBdBgBbBBc2fBa2gBcBcBaBBBb20a2pBa1b", "14x14:d1dBp2dBbBbBbBc1b1BbBBa1f1b4aB0bBlBbB1cBBd0iBi1cBaBa1B3cBeBb2aBBa1BaBbBcBdB2a3aBcBaBdBBa1aBBBBaBb3cBBa", "14x14:bBbBb2bBpBcBdBcB1aBcBBc1a1BcBd2c1a0b2aBBa1b1zd0bBaBBaBbBaBcBdBc1Ba0cB0c0aBBcBd3cBpBb1bBb0b", "14x14:bB1BBbBB1Bg1bBfBjBe0aB0a0f0h1cBBBfBB1cBa3dBa1dBaBdBaBc1BBf2BBcBhBf1a1Ba0e2jBf1bBg2BBBbBBB2b", "14x14:gBBbBdBB1a0Ba3cBBaBc0bBBbB0aBbB1a2b1k1g1cB1bBhBf00fBh0b1Bc0gBk1bBa2Bb2aBBb0BbBcBaBBc0aBBa2B1dBbBBg", "14x14:aBaBdBa2aBaBBbBBa2cBBBa2a0jBj2aBe2BeBaBeBbBb2b2f1BhB1fBbBb1b2e0aBe1BeBaBjBj3a3aBBBc2aBBbBBaBaBa1dBaBa", "14x14:c1bB1bBcB2BhB01b1hBc1aBf0a0dB1a1BaBBq1bBbBBb2bBBbBbBBbBbBq10aBBa0Bd3aBfBa1cBh2bBBBhB2Bc1b21bBc", "14x14:bBbBb2aBh0bB2B0c01b2e1aBBBgBe1aBjB0i2BBzb2BBiBBjBaBe2gBB1a0e1bBBcBBB0b1hBa1bBb0b", "14x14:b0aBaBa3pBc0hBb2b1a0aBBaBgBbBBbBb1Bd3Ba1hBBcBB0bBBb0B2cBBhBaBBd20b2bBBbBg3aB1a2a1b0b1h2cBp1a1a2aBb", "14x14:b2BBBb2aBbBdBqBc0b1aBa11iBcBd0b0b1a0g10aBBBBhBfBaBa2BBBaBb2a0bBd1e0c2eBcBb0a1bBBaB10bBb1a0c0BBcBeBh2b", "14x14:0b0f1bBf1Bi2bBBb1g2d1eB0a2d1aBBaBBaBfBa01zb00aBfBaB2aB2aBd0aBBeBdBg2b1Bb4i00fBbBfBbB", "14x14:0eBd12d1BhB2hBBf0e0a11jBa2bBa1b3a1B0BdB0BBa3e1a1c0bBd1e1bBcBc1f21aBa0a0c0gBa0aBeBcBgBbBB2aBbBaBaBb01b", "14x14:iB2cBB3aBcBBdBcBa2BaB2b0fBa1BcBa10BBm0Bb2b0aBaBxBa1a0bBbBBm1B11aBc0Ba2f1bBBaB2aBcBd1BcBa3BBcBBi", "14x14:aBiBB1cBBd21d2bBBk2cB0d0aBaBb3BB2h0bBBdB1aBgBaBbBa2gBaB3dB1bBhBBBBb2aBaBdBBcBk3Bb4dBBdB1cBB0iBa", "14x14:kBBaBgBBaBbBB1c3c0gBcBeBc0a2aBb0a2a11aBaBl0BaBcB2a10Bb1BjBcBaBaBBdBaBiBb3aB2c1f0Ba1a11e2bBdBcBaBbBcBa1a", "14x14:aB2aB0bBd0a1a2f0hBa1nBBbB0c2BjBbBd1d3aBBe0b0d2c0fBBeBBf2a2aBe2aBaBcB0aB1bBh1k2e11e0gBB", "14x14:BaBbBa1cBdBh2c0Bd01cBd1i1bBbBb0dBaBhBa1Bg2BBa1aBa0gBBBcBa0b10aBa1iBcB2BeB2bBcBb0Ba1aBbBa2c2kB1b1aBb10c", "14x14:a2cB2aBa2bBbBjBhB1cBB2aBlBBcBa0Bb1e1BBa1a2bBa0aBe3fBeBa2a1bBa2aBBBe0bBBa2cB0lBaBB1c0BhBj1bBb3a2aB1cBa", "14x14:BaBaB1fBBbBeBdBc3BaBa2eBaBgB0eB1j2a1b1d0bB0aBdBbB1a1Ba0d1b1Bb2aBb2d0eBBi1a0g10eBBa0aBg0eBd0BaBaBBf1B", "14x14:aBe0bBcBcBbBa2a1d2b20fBjBeBcBB3b0d2dBaBd1cBBaB1hBaBaBB1b0BaBaB1a2kBdBb2b01c2aBcBg0eBaBdBdBBBc2cBaB2aBaB", "14x14:eBBeBaBjBBaB0a2aBd2Be0BaB0aBdBdBaBBcBb1dBeBc0c3aBb0fBBa2h1c3a1bBa2mBa1c02aBBBBBBaBaBd0a1hBdBc1c2c0Bc0", "14x14:e1b1gBBaBbBaB0c1bBd2bBa1b10dB3bBd1dBdBbBaBbBaBb11lBBlBBb0a1bBaBbBdBd0dBbBBdBBbBa3bBd2b0cB2aBb2aB1gBbBe", "14x14:d1k3eBBaBc1bBcB1b0eBBa0aBe01BBb0aBBBaBa01gBfBBr02fBgB2a0aB11a1bBBBBeBaBa01e1bB1c1bBcBaBBe3kBd", "14x14:b0e1gB1a101e12cBBcBbBeB0aBBcBB0b01Bc0i1a3bBdBi2bBa0kBa0d0aBbBBhBdB1BBcBc2BfB2bBBeBbBBb3c2e2aBc1bB", "14x14:Ba0h0aB0b1a1bBaBbB0dBb1d1e0bBjBBBBfB2aBaBBa1a1BbBaBa3bBa1aBb2aBaBbBaBa1bB1aBaBBaBaBBf1B12jBbBeBd0bBdB1b0aBb1a1bBBaBh1a1", "14x14:0lBa1bBBdBaBc1cB1cBc0b1c0k3c0aBdBaBB2BcBc3bBbB0a0dBa0BbBb1cBcBBB0aBdBa0cBk2cBb2c3cB2cBcBa1dBBb4aBlB", "14x14:dBBbBBdBB2b0h0aBeBaBa3c1b2kB2BbB1k0hBcBdBaBbBaB3f0b1BBBaBBBc3a0BbBaBBBbBd4aBfBe2aBdBBcBd2c00c01d1f", "14x14:dBeBa3f2e4f2c1Bb3d2eB0dBiBdBb2a1a2aBdBa2b0c0aBb2aBb1c0aBbBbBaBa0aBc3iBeBeB0g2cBBbBf2e3fBe3aBa", "14x14:b00d0hBaBcBa000sBa2cBb2mBaB1BBbBc2b2bBa1d2BaBb2BaBBbBl1nBf0cBbB11bBBf3e1Ba2BBaBdBi2d", "14x14:a2aBc1c1t0aBa2bBc1e2b1a01f0gBeBe3c1c1BBa1bBa0fBcBaB0bBfBBaBcBa02xB1dBa3a2c3aB0bBdBaBaBbBcBa", "14x14:n0cBaB2a3cBcBa4bBaBcBbBbBBb1b2eBbBfB1aBBb1BaBBb1BaB1bBBaBBbB1aBBbBBaB1bBBaBBbBBaB1f2bBe1bBbBBbBbBcBaBbBa2c0cBa3Ba3cBn", "14x14:a3aBBaBbBb2cB1bBaBd21aBBaBbB1fBa3fBaBcBa3c0dBBhBBbBmBmB1hB0e3a1cBf2aBfBaBBaB2aBb11fBBb0aBd1a1aBBa1b1b2a", "14x14:dBaBbBaBdB1b2cB1aBb2BbBa1b0aBa2b1aBh1eB0c0BbBc0gBd1fBb1f1dBg1c1b02c0Be0hBaBb2aBaBbBaBbBBbBaBBcBbB2dBaBb2a1d", "14x14:b0BaBbBaB0eBfBc0c1B1BBBc0a1BbBBB1b2Bf1bBfBaBfBaBaBc3d0cB2cBd2cBa2aBf1a0fBb1fBBbBB0BbBBa1c2B1BB1cBcBfBeBBaBbBaB2b", "14x14:a0aBaBeBhBb0aBa3BBaBmBfBBaBa4bB1cBj0bBcBh1cBbBcBhBc3b1jBc0Bb1aBaBBf2mBa2B2aBa2bBhBe1aBa3a", "14x14:BaBb2c1k2fB1d1c1eB11eBeBcBBa2c2n0BbBa2a3d0BdBaBa3bB1n0c1aBBc1eBeB0Be1cBdBBf0k2c2bBa2", "14x14:0cBjBd11BaBBaBe0bBc3bBBbBc1bBcBb0b2b2b2d0aBaBf2c2e0B2BeBcBfBaBaBdBbBbBbBb0c1b2c1bB2bBcBbBeBaB0aBB2d1j0cB", "14x14:aBd2e0b2bBBBb1b0aBb0eBBcBBeBe1aBdBaB2fB2aBaBBc0BaBBa1dBaBBbBBa0dBaBBcB1aBa3BcB0a2dBaBBdB0eBeBBb1e01d1bB1Bb3b2bBdBeBa", "14x14:0BaBfBa2Bf1Bj1d0eBbBdBb1a0b3aB0B1aBbBb4h1cBbBd1bBb1b1dBb2c1hBb0b2aB01BaBbBaBbBdBb4e0dBjB1f01a1f2aBB", "14x14:BbBBdBc1b2a00a1a1n0aBc0j111cBbBc00d1d0b1b1xBb0bBd2dBBc1bBc11Bj0cBaBn2a2aBBa3b0cBdBBbB", "14x14:c1e0e0h1aBbBc0cBcB1BBe2a2BaBBbBBb1a1b2a0aB2a3aBcB0cBbBc01a0cBbBcBBa1aBaBBaBaBcB0a1bBBb0a3bBaBB1e2a3BaBa0c1c3cBa0h3aBdBeBd", "14x14:b1bBBaBBcBm1a1iBaBdBa3b0c1cBaBfBbBeBb0BfB2gB1g11fB2bBe2bBf3aBc2c1bBaBdBa1iBaBmBcBBa2Bb2b", "14x14:dBf2bB0cB0dBb00f1c1e00i2aBmBc1B10cBBaBeBaBa1iBcBc2f1s1b2bBb3bBaBa0hBBBbBbBBdBaB2bBaBb0c", "14x14:hBb1Ba11cBf1aBaBBcBcBeB2bBbB2j2a1cBcBgBc20t0BcBg0c0c2a1jB0bBb10e0cBc02aBa1fBcBBaB0b0h", "14x14:aBbBa1BaBbBdBaBbBa3d2dBBd2gB1f0Bb3BBBBBbBBaBj1b0aBa1bBa0aBbBaBa1bBaBaBb0jBaBBbBBBBBBbBBfB1g1dBBd1dBa3bBa4d0b2aBBaBbBa", "14x14:1b1cBbBbBa2c0a0b1BkBBB2b0BlBbB1aB1a0eBe0c1o1a2cBf2b0dBBcBaBmBeBBb0b00cBc1g0d1bB0cBeBb0c", "14x14:Ba0a1a2aBc0aBa2aBc2cBd4a2aBc1aBb2bBb3bBe1a0lBbBBdBa1aBb01gB1dBeBBaB0c0a1a0cBbB1bBa1a1c3cBeBb2BdBb1aBBaBBc02aBBcBBBb1Bd1aB", "14x14:bBaB0a1c1BaBmBf0BBcBd4kBbBdBbBbBcBbBc22aBeBj0eBa1BcBb2cBbBb1dBb1kBdBc0B2fBmBa2BcBaB1aBb", "14x14:bBaBa1aBjBcBBbBb0h1aBcBd2bB0Bg2bBaBb010a0b3dBe1a2c10bB3cBaBeBd1bBaBBBbBaBbBgBBBb0d2c0aBh2b0bB1c2jBaBa1aBb", "14x14:BaBBh2c3bB1o1dBbBaBBe1c0dBb0dBbBa3Be0Bb1fBh0f1b01e1Ba3bBdBb1dBcBe0Ba2b3dBoB0bBcBhBBa1", "14x14:BaBcBBc2aBa112aBbBaBB1dBa2bBa3gBdBgBaBBBBaBc0cBdBc11d2b1dBBdBbBd01c4d2cBcBaBBB1aBg2d3gBaBbBaBdBB1aBbBa1B2aBa1cB1cBa2", "14x14:bBaBaBd0gBb01a2bB2c1gBfBbBe1a1a0Bf2a2d1bBa0BiB1BbBBb1BBiB2aBbBd2aBfBBaBaBeBb2f1gBc2BbBaB1bBg1dBa2aBb", "14x14:c2fBdBcBbBc1a1l0cBaBb1a1d2cB0B1cBdB0dBBc0a2cB0cBa2BaBc0BcBaBc2Bd12d2c0BB0c2d2a0bBa1cBlBa2cBb0c2dBfBc", "14x14:dBbBaBe1b1Bd4aBcBhBc3fBBdBbBa1f11cBcBaBb0a2d0p2d2aBb0aBcBc2BfBaBbBdB1f2c1h1cBa1d21b1eBaBbBd", "14x14:b0BBdBbBcBb0dB2a11eBa20cBaBb2f1b1b10bBrBa0b0BBaBc2bBb1BBaBcBnBaBb0Bb2gBbBfBb1e2a0Bc1b1bBd12aBb0BBdBbBa", "14x14:eBbB1eBBe2c1cBeBb01f1bBe0c1bBa1dBB0BaBbBaBb0d4aBBlBBaBd0bBaBbBaB2BBdBaBbBc0eBb2f12bBe1c1c1eB0eB1b2e", "14x14:c0e01i1a2eBa2cBcBb2e1d2aBa1gBdB1Bf1dBc1fBf1BdBa3hBcBBaBa0bBcBb2aBB1B1c1e1BaBf2aBeBgBBa0BBBBdBBBBB", "14x14:fBeBBb2a0aBB2aBa2gBBgBB1d3a1g0bBBcBBbBa1kBc00bBbB2b0bBBc1k1aBbBBc02bBg1aBdBB1gBBg1aBa0B0a3aBb01eBf", "14x14:BB0dBb2e21gBfBc20a1cBaBaBjBBBc2bBd1eBe0dB2aB1Ba2bBa0BBaBBdBe1e1d1b0c20BjBaBa3c0aB1c1f2gBBeBbBdBBB", "14x14:b1c0eBBaB0e1aBa2f02b1BgBeBaB11a1aBBiBBbBBcBdBf0Bd0a1aBaBcB1BiBa0p0aBdBBBb11a2c0a1BBbBc4c1cBa0dB0e0d", "14x14:g2aBaBBcBhBaB1B0gBa1aBa0i1aBaBcBBc2bBc2Bf2Bf1b2cBa0a0aBb2bBd1h0bBc0oB0bBh3bBBl1Bb1aBa2g2c", "14x14:c3aBa1eBa1bBb1B0cBb2BBg0Ba3bBhB2a2bBaBb1Bh1i1fB1bBb1fBBbBf2g1aBbBa2bB2cBb0hBb2BBg0Ba2bBbB10cBcBaBa0e0", "14x14:d1dBBb1a1kBaBb0b0eBc2dBfBe2c1cBBb1iBB1aBaBaBhBaBa0aB0BiBbBBc2c0eBf1d2c1e1b1bBaBk3aBb1Bd0d", "14x14:cBb1h12h2a2c1tBBb1h0BnBg1h1a0d1a1BaBaBb0n2bB1cBk2i2bBBc1aBB1BeBBhBc2b", "14x14:cBf1aBBaBB0f0c1e1eBb1e2dBd2BcBe0Bb1b210b2aBaBb0cBBcBaBbBcBBcB3bBbBB1b1dBBcBfBe1dBaBe2e2b3BBfBf1f1aBB", "14x14:c2Bb2dBBdBdBB2cBBBnBb0aBd1a3eBaBaBdBBaBc3d2aBbBaBb2d3b3aBbBaBd1cBaBBd0aBa3e2aBdBa1bBnBB3cBB0dBd01d1b1Bc", "14x14:b1d0aBdBBb0e1bBbBa0d0Bb2jBaBaBaBdB101b1a3BBBBB0znB0BB1BBaBb2BB1dBaBaBaBjBbBBdBa3b1bBe2bBBd2aBd2b", "14x14:l0aBc2a3aB0dBa00h1bBaBa11c00bBg1a1d0a00g1h1m0g2aBBgBaBg2a2d2a0a10cBBb2aB1hBaBcBaBa00p0a", "14x14:aBaBdBeBb1a11Bb3jBbBaBf0dBbB1aBdBl4bBc0BhB0f0BhBBcBb1l0dBa13bBd1f3aBbBj0b1B1a1bBeBdBaBa", "14x14:1bBb3aBaB0b0fBBBB1BgBBkB0cBbB00a0a0BdB2j0b0aBB00a1a1fBBBBa0a0o1bBa00a1aB0dBBfBBcBbBfB0f2fBBBBB3aBb1bBaBaBBb", "14x14:jBdBd2a00d1fBBd1eBa1aBa1e20BaBa0b3a01h1c2aB2aBa1d1bBBBeBa0a0aBaBe1fBBBBdBBfBBdBcBd01dBjBaB11aBa2dBaBd", "14x14:h1a10BaB2aBBgBaBaBc0bBaBb0eBBd3c1a0d2bBaBe2jBdBaBBdB1aBd2j1eBa2bBdBaBcBd00eBb2a2bBcBaBa2g0Ba2BaBBBa2h", "14x14:aBa1b2c0j1dB0Bc0BBBc2k0bBc21bBBgBb0Ba1a1b02p1b2aBe2b0e2a1hBd0aBk1e01c0a1i3fBbBB1BdB0c", "14x14:aBf1bBaB2a2aBBfBc0BiBf1hB1dBdBa1dBd1cB1f2d2B1fBdBBdBd0dB0dBd1g2iB2i23a2a20fBbBf0b1aB", "14x14:BBBB2dBBeBc1c0e3aBb1a1a1fBBaBk1f0cBaBb0gBaBa3bBBb2bBaBaBbBBb0c0aBbBkBfBe0Ba2hBa3bBaBa1dBc2c1cBBBBBdBBc", "14x14:b2a1aBBa1bBc1cBa20dBcBa0bB1bBaBcBbB1aB0c1Bj1aBmBe0a2f1a1e2m0aBj01c1BaB1b1c3aBbBBb0a0c2dB2aBc0c1b2aBBaBaBb", "14x14:fBaBBaBbBbB1c1Bb4f0b2aBbBBb1gBc0eBBbBg1aBa0a0cBaBb0e1b0a1bBe1fBaBaBaBc0eB3b1bBb2gBg1bBaBbBBbB0c0BbBgBaBBa3b", "14x14:Bf3aBh0aBa3a1b0aBfBaBb1a2h1bBc1b0f1lBbBa3a0jBaBcBBBBb2c0c2bBeBc3cBcBbBe11aBBbBbB2dBBk1c2h0c", "14x14:kBaBd0cBBcBbBbB1d1c2d10e2cB1b2Ba0a1c0b1b1dB1Bd0c1a1aB0dBcBaBcBbBbBd2cBBbBBaBaBb4d02eBbBbB2d2f3cBBcBkBaB", "14x14:dBaBcBe3bBa0c3f1j1hBa2fBaB1BBeBeBaBa2bBa2fBbBaBaBfBbBb1e3a2aBfBaBBBBd1hBa0e3k3b3a1cBfBa1c2c", "14x14:a3aBbBBbBa0dBBdBBs2c2BcBbBbBBdB0bBaB3cBBcB3e1dBhBd0eBBc1BcBBa1bB2d1BbBbBc1Bc2s0BdB0d3aBbB2b1a2a", "14x14:0f0k1g0a1a2BaB0a0Bh1f2a0i2i2a1Ba2f1bBb31aB0aBBbBbBfBa1BaBi3i2aBf2hB0aBBaBBaBa2g2k0f1", "14x14:e0eBBBa10d2aBa2Bc1aBb2hBeBb1gBaBa11e2fBe0bBaBBbBB0a0fBBBBd1cB2bBBaBg1BBf1gBg11c2b0a2c1b0BcBBa1f1dBa", "14x14:f0Bh0cBaBBa3aB2dB2bBcBgB1bBBf1k1BBc0aBcBaBBbBBc3bBaBBb1BcBdB10cBaBg1oBBbB0a1d1Bb2cBb2cBaBBa0aBfB1f", "14x14:aBBaBiBe2dBaBaBaBbBbBa3aBaBa0a1Bh3eB2dBdBjBaBbBdB2iBBcBcB2c0k1c2cBb3a2bBeBgB1a01a2bBg0iBeB", "14x14:b10a1bBaBBbBaBh2a2aBc0bBcBc3c00c3bBcBdBcBBeBBeBBBBa2d2aBBBBB0aBdBa1BBBe0BeBBcBd1cBb0c1BcBc0cBb0c4aBaBhBaBbBBaBb1aBBb", "14x14:1a1aBBdBbBcBBa10b0fBiBBBeBBb12h1dBBc1iBa2a0Bg1bBg0BaBaBiBcB1d1hBBb1BeB23i0fBb0BaBBcBbBdBBa1aB", "14x14:aBBb0aBe1bBbBc0eBBfBb11b0d3j112aBBBdBb0iBaBa0cBaBBaBaBg2Ba3cBdBbBdBaBa0a1d2BfBi000BbBb0dBcBa2bB0c2aBg0a", "14x14:cBaBb1eBa3aBd2a4dBa1eBaBfBgB010Be0aBlBBc11bB1aBa1a0b1BbB0a0aBaBkBBb1B0BeBaBg2g2b2aBe2a3a0aBaBd1aBeBaBbBe", "14x14:2fBdB1b0bBa20eBBf2b1a1Be11o2fBBdBf3dBbBa1d2a1b4d1fBd11f0oBBeB0aBb3fBBeBBa0b1bBBdBfB", "14x14:aBd0cBdBb1f1Ba1b1c0fBBf1a21dB2BBlB0b0BbBBa1BiBBaBBiBBd10b1Bb0BbBB1BhB2f2a2BbBbBc0g1bBfB2b1d1cBc", "14x14:o2j0aBdB001dBa0b1d1b0b0cBBB0c1f0B1BfBBb0bBb01bBBbBb1bBBfBBBBf2c1BBBc2bBb1dBbBaBdB1B0dBa1jBo", "14x14:o01BgBaBaBaBBa0a1eBg1eBBb2Bd1pBaBaBaBaBBdBa0a2aBaBBd1mBB1bB0d0c0gBfBaB0aBa1f2BBgBa1n", "14x14:n1a01fBBaBBcB00B0Bc2a1j2q0b1bBbBb0eB1e10eBBeBbBb1b2bBqBj0aBc11BBBBcB2a10fB1aBn", "14x14:a0a1aBcBBh0bBa1b2i2d1BbBc2d1BaBg1dBa0aBbBc0Bzb20c0b0aBaBd1g2aB1d0cBb3Bd2i0b2a3b1hBBcBaBaBa", "14x14:b2aBf1aBc2a3bB2cBa2bBdBBcBt3aBBd0fBfB1dBa0b1bBb0a1dB1f2f1d0Ba2t0c10d1b2aBc00bBaBc1aBfBaBb", "14x14:b2dBbBcBbBbBcBa3c2bBBBeB1eBBd4b1aBjBd1dBaBBaBe0BaB0d10aB0e1a0BaBd1dBj2aBbBd01eB1eBBBbBc1a1cBbBbBcBb3d2b", "14x14:dB11bBo1c3f1sBdBBf1bBcBb2cBhBBcBBc11hBc1b0cBbBfB1d2sBf1c3oBbBBBd", "14x14:00a0cBaBb1d2f2d2bBBm2aB1b0aBdBb1eBe1hBBBcBB1a0B2b2BBaBBBcB1BhBeBeBb2dBaBb12aBm10bBdBf1d0bBaBcBaBB", "14x14:bBdB1f0a1Bj0bBa2aBaBfBa3f1BdBdB10b1a0bBc2BBaBbBBBBBdBBBbBBBBBdBBBBa2b2cBB1aBdBdBBBeBa2f2Ba0bBaBaBa2d1aB1k1dBBe", "14x14:aBe0Bb3aBb000cBcBh1i2aBdBdBdBdBhBf1aBaBb3c10dBBcBbBaBa1fBh3dBd0d2dBa1i0hBcBcB1Bb1a2b11e2a", "14x14:dBd0e3bBaB2a1bBcBBBdB11bBdB2BBdBeBb0f1aBaBb1a1a0zd0a0a0b0a0a0fBbBe0d1BBBdBb1BBdB11c3bBa3BaBb0eBdBd", "14x14:eBa2a1f0B2aBgBrBbBb2c1a2i3a0BhBd1b2aBcBhB2cBaBa1c0gB1f1b2fBfBaBa1d0b0BbBa00cBcBBB2e1b1eB", "14x14:e2c1Ba2d1dBBc3a0bBdBiB2aBe0f1dBBaB1fBa00b1BB1c0bBcBBBBc2b1c1BfBaB1a1f1d1BeB1aBf0bBdBg1dBBcBe3cB2aBa", "14x14:b2d2dBaBb2bBc1fBd1dBaBc00dB2hB2g2a11BaBa0c0cBcBa0aBbBa1aBcBcBcBaBaB2Ba1gB2h11dB1c1a1dBdBf1c2b1bBa0d2dBb", "14x14:a1d0d0c0BcBBeBdBbBBbB1B0BcBaBaB0i0g1aB1a0aBnBBa0dBa2BnBaBaBBa2gBiBBa0a2c0B0BBb2Bb1d0eB1cB1cBd0d0a", "14x14:bBkB2c0d1dBBb1aBaBbBaBaBbB1aBb21cBl1e1a1BBa2Ba2fBBc0aBf1Bd1eBaBB1aBbBkBaBb02aBb2BbBBbBaBa2b3a1Bc0d1eBk", "14x14:a2a1bBo3d0eBB3i00aBcBb0gBbBdBcBb2b2dBaBeB0a1BaB1eBaBd2b0b2c0d1bBgBbBc0aB1iB01e1dBo2b1a1a", "14x14:b1eBb1fB1aBf0dBcBc1cB3bBb1e2b2d3aBa0eBb3aBBbBaBbBBBjBB1b2a3b0Ba2bBeBa0aBdBb2e3bBbBBc0cBcBd1f3aB0f0b2eBb", "14x14:BdBb2dBoBc2bBcBb0bBBb10b1b0aBf1aBb2d2BdBfBb2j1bBfBd02d0b0a2fBaBbBbBBbB2bBbBc2b2cBo1d0b2dB", "14x14:bBBf11c1aB1d2Ba1pBcBb1cBaBaBa2a3BaBa2aBd1d0zj1dBd2a3a0aB2a2aBa3aBc1bBcBpBaBBd1BaBcBBf1Bb", "14x14:d1d0eBj0c3c11cBc1aBfBaBa00cBbBcB0bBc2Bc2dBBaBb0aB1d1BaBbBa0Bd0cBBcBb0Bc1bBcB0aBaBf2aBcBcB2c2c4j1e1dBd"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 4;
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
        LightUpManager.currentPack = 4;
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