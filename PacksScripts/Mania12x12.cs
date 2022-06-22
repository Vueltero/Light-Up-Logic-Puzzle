﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Mania12x12 : MonoBehaviour
{
    string[] puzzles =
    {
        "12x12:0b2aBB1bBfBe1cBbBfBb1e1f1g0dBaBa1b2a0aBdBg2fBeBb2fBb0cBe3fBb1BBaBbB", "12x12:p0bBdBa0a1bBaBa3cBd2c2b1BbBBbBBjBBjBBb11b00bBc2d1cBa2aBb0aBaBd1bBp", "12x12:a2hBaBj1bBb1Bb2d2BdB0bBbBd1bBaBh2b1hBaBb0d1bBb00d1Bd1bBBb0b2j2a1hBa", "12x12:c1Bb10c1jBb2f0eBdBcBB1fBBBBj1BjBBB3fB1Bc3dBe1fBb1jBc01b10c", "12x12:dB1BBe3b1bBb2bBhBc3fBoBBb0BbBBbBBb02bB1oBfBc2hBbBbBb1b1eBBBBd", "12x12:b1Bk1c11n1a0a1a02aBaBBa2cBi0c1Bf1BcBiBc0aB0a2aB1aBa2a0n0BcBkB0b", "12x12:BaBa0fBbBd0aBc3aBaBdB1i2cBb2b0cBi1dBi1c0b0b3cBiB2dBaBaBcBaBd1b2fBaBa2", "12x12:Bb1d0bBa1h2e0bBhBbBd2a0aBb0a2a2b0a1bBaBdBaBbBaBb1a1a1bBa1a1dBb1hBbBe3hBaBbBd1b1", "12x12:0dBBd2mBhBb0aBd2a2dBa10aBf2aB0aBfBaB0aBfBaB1a0d0aBdBaBb1h1m0dB0dB", "12x12:a2fBBi0fBjBa1eB3dBa1aBj1c1bBcBj4aBa0dBBe1a1jBfBi2Bf2a", "12x12:c0aBeBaBlBc2bBcBa2d1a2bBa2bBdBdBa1b1f1aBbBc0a0bBd3aBaBd2aBcBc0b2c3mBaBeB", "12x12:BfBc1aBBa0cBaBk1b2b1bBd3b0BbB2aBz0a2BbB0bBdBb2bBbBkBa1c1aB0a1cBfB", "12x12:2aBb2dBBiBBBa0cBdBbBa21c1b3B0cBbBc0n0c0bBBi0a1Be1gBhB3f0fBb1Be", "12x12:e0cBBf1b1B0b0cBB0e1B1f1cBaB2Bg3aBa1aBbBcBe0d1cBaBcBBaBBBe32dBb0aBeBBj1fB", "12x12:bBdBBBaBa1dBg1aBb21eB0Bb1f1c0gBiBB1aBcBbBc3c2B1b1a4bBd3b3f0gBaB1bBBcB1aBcBa", "12x12:bBf01aBa1a1aBeBdBd0Bf2oBbBa2aB0bBd2b0Ba1a3b0o3fBBdBdBeBa2a0a0a0BfBb", "12x12:gBcBc2c1eBbBdBaBb3Bb2aBgBbBaBc1e1BdBeBBgBbBa2dB2bBa3d3b2dBa3c1cBk0cB", "12x12:cBaB2aBbBa1f1eBeBd4a1gBh0BbBBa1bBiBg1Bb0e3aBfB0BeBaBgBBa4b0e1BhB", "12x12:BaBBa2BaBBaByBbBb0bBeBb1eBa2d0aBb0a0d2aBeBb1eBb0b0b0yBa0BaB1a1BaB", "12x12:b2aBBg2e1BgBa1d1a0Bc1b2b00BmB2aBaBaBd0BbB0b0aBhBBcB0aBbBBiB0dBd21b10bBBf", "12x12:c1cBbBc0e0aB1aBc11fBaBf0h0dBd2aBBf11a2d0dBh2f0a2f11cBaB1aBe3cBb1c2c", "12x12:bBeBcBb3c0b0eBaBBaBBa2cBbBc1bBg2dBk0j1g2aBcBb1cBd0a0BaBBa3bBc1b1cBe1c", "12x12:a0BdB1dBB3cBpB0dBBdBb0d1a2e1f11fBe2a1d3bBdBBd0Bp2c011dBBdBBa", "12x12:bBjBbBa0aBdBaBbBBb0a1e2aBd0eB2f1eBe0e1c2e20c1e1aBdBa0bB3b1b1b0a2aBeBi", "12x12:aBaBa2dBbBBe2bBb1aBb0aBaBjBd0Bh0bBBb21cBbB1bBBeB2q2cBaBbBa2aBa2BeBbBaBaBa0dBa", "12x12:cBi3BiBaBBc22d4bBd1dBcB2aBBf0e31e0f10a01cBd1dBbBdBBc0BaBiBBi2c", "12x12:c1d1aBaBbBcBi4f1i0BaBoBBb2d2b1BoBaBBi1f3iBc0b0a2a1dBc", "12x12:a1Bf1gBi4bB1BbBdB2c3aBb1BbBi22lB1iBbBBbBaBcB2dBb2BBbBi1gBf2Ba", "12x12:nBf4eB0bBBc11hBB0BcBBcBBbBa2bBa1d0aBbBaBbBBcB1cBBB0hBBc1Bb21e0f1n", "12x12:g0d0c2a1lBh1b1Ba3hBaBc1b0g1c0BBBBB2BBb1c2d1b1d2mBaBBl1a2cBBaB", "12x12:0dBaBa2n1dBbBe1bBcBBaB1a2a1bBa2iBf0i2a2b1a1a2Ba0BcBb3eBb0dBnBaBa2dB", "12x12:m2a11b00aBbBhBa1b1d1b1dBbBe1BfBBb10fB1e0bBdBbBd2bBa1hBb2aB1bBBa3m", "12x12:d3gBa0bBa0b1k0k0cBaBdBBh0c1g0cBbBa3d01k0k0a0a0bBa3b0eBg", "12x12:c0cB2aBbBdBbBc2bBa0c4aBaBaBdBaBb2a1e3aBcBgBcBiBa1eBaBaBaBd3aBa2bBa0cBbBd1bBe1cBBa3a", "12x12:b1cBe0eBd2bBc2f1hBc1cBb3aBc00bBBaBb2aB1bB2c2a2bBcBcBh3f0c1b2dBe1e1c0b", "12x12:c1b1dB0h2a2lBd3cBaB1a1aBaB1aBB1xBBBa02a3aBaBBa2cBdBlBaBh1BdBb1c", "12x12:BcBbBcB1g2dBa2aBa2eB0Bb3lBg1bBd0cBb1d2g0e1BBbBfBa0aBaBdBg2cBcBb2cB", "12x12:b02cBaBiBdBj2cBcB1bB2BaBBBa1kBhBkBaB2BaBBBb21cBc1jBdBi1a1cB2b", "12x12:c2d0p2c01c0a2cBBB1cBBa2f1aBBjBBjBBa0f2aBBc1B10cBa1cBBcBp0d2c", "12x12:2jBhB2b1b1bBf2fBaBcBdBBa2b1b3aBb1dBbBa2bBbBaB3dBc0a1fBf0b2bBbB1hBjB", "12x12:aBb0cBaBaBd0eBf1dBBa21bBcBBh3bBg1h1g2b0hBBcBb2Ba00d1fBe2d1aBaBcBb2a", "12x12:a2Bd2a2gBeBBa0fBaBd1g2gBm2b1mBgBg2dBa1fBaB0e2g1aBd1Ba", "12x12:c1e0d3b0b1cBbBa2d2b0g2a1uB2b1BuBa0g2bBdBaBbBcBbBbBd2e3c", "12x12:c1bBa2a1iBcB2Bd3aBg1fBBdBbB2aBfBdBfBd11d2bBBfBfB11dBa3jBf1b1aBaBa", "12x12:0d01c2a1BhBcBaBcBgBbBbBhBb1b2dBa1d1dBa1jBbBe1b0bBcBaBcBcBBhBaBd20cBa", "12x12:1d21d1dBaBhBd0d0bBbBcBBbBBBdBBb0bBc0gBa2a1c1b0f0k1e1b2Bc0Bf0bBeBe", "12x12:bBBbBa3dBcBkBe0aBeBB1b1b3cBcBfBcBgBc0aBbBc2cBa2eB1BgBe3a0cBhBBbBaBc", "12x12:d02b1f2d1bBeBh0b0f2BgB0b1aBb0aBB0s2aB1i3aBaBaBBbBb1e3a2c2a1aBcBb1d", "12x12:1a2a1a1e1g2d1h1d2e0b1BBb0bBBdBc2bBa2BgBBcBaBbBbBBaBc2vBaBd3b3fBBb", "12x12:a1c0h0BbBaBb0gBb1bBh2cBc0fBb0B1dB1dB0BbBfBc0cBhBb1bBgBb3a2b13hBcBa", "12x12:0Bc2aBkB00BkBaB3b0a1b0d2j3eB0fBBeBj0d0b3a2bBBaBk0B0BkBa1c00", "12x12:h10c3aBaBdBaBcBgBbBa3bBaBfBcBi01aBb2a00i2cBfBaBb0a2bBgBcBa3d2aBaBcB0h", "12x12:0a2bBBi1e2aBc0cBlBc2aB1aB2f1fB1i0bBlBaBd3a3aBa0cBbBBaBa1g0cBaBa1a0d", "12x12:1aBbBb0cBbBcBcBc02g2hBgBi1aBbBBa0c0aBbB0a0eBf0h2eBBgBbBc2cBBa0bBbBc", "12x12:1kBb2bBBaBoBaBBeB1d2B2b2bBfBBcBfBBgB12bBc0aB0eB1l0b0bB0a1bBk", "12x12:a1hBbBh2iBBd0j1d3bBe4aBc00bBBcBa1e0b0d1j1dB1i1hBbBh0a", "12x12:d0bBfBf0b0b1d0b1nBBdBBbBb0aB1a1bBBbBa0Ba0bBbB0dB2n2b0dBbBb0f1f2b0d", "12x12:aBa2eBb2bB1a1lBf2Bf4bBa1dBBaBcBcBf1c1c2lBc2aBeBb3aBa3aBBoBBbBbBaB1", "12x12:dB1a1B00aBa4bBfBe1c1aBkBj1bBgB0B2gBbBjBkBaBc2eBfBb2a1a2BBBaBBd", "12x12:c1i3cBaBBa2eBaBBe2iBaB0c1bBdBaBe3bBe2aBd0b4cBBaBiBeBBaBeBaB0aBcBi1c", "12x12:a1h1bBbBB11bBoBaBbBaBb1b1Bb01bBcBd1fBdBc2b10b0Bb2bBa1bBa0o1b0001b0b0h0a", "12x12:c3a2kBc0c0mBBaBaBbBf1aBfBBBBc0BB1cBBB0fBa0fBb0aBaBBm3c3c0k0a1c", "12x12:BBaBeBc01d2kBb2e1a2aBa2Ba3cBaBaBaBeBd1f0d2bBcBaBa2aBdBa3aBa1BgBbBbB2d2dBBaBe1b", "12x12:hBbB2aBB1gBBa0Bd0r1c1b0j0BcBb1dB1c1bB011hBb2b2f0b1b1b0g2Bd2aBb", "12x12:1dBBdBdBb4d0a0fBa0p0b0dBj01j2d0bBpBaBfBa0dBb1d0dBBdB", "12x12:0c0bBc0p0b1d10b1b0b0BbBf1f1BBBh0BBBf3fBbB2b1bBbB1d1b1p2cBb1c1", "12x12:a0BaBa1d0aBBaBm11c1a0B3dBBrBaBaBBa00a0Ba3a1r1Bd0B2aBcB0m1aBBa0d1aBaBBa", "12x12:Ba2a0b0cBd0b1a1bBgBB2bBe0BBbBBnBBc2BcBBeBdBBa0a2bBb2hBb0d0BbBb1fBa1Bc0Ba2e", "12x12:aBaBBBa1bBb0aBBB1cBbB1a1c2a11aBj11a3aBb1lBaBbBb0c1b2a1i1f0m1bBBbB1c10aBi0B", "12x12:a1BaBbBj1a0b0hBb2a100b1a1c2j1a2a1p0aBaBjBc0a1bB1BaBbBh0b0a2jBbBaB0a", "12x12:2dBa1a0eB0a2fBe2aBaBf1c3a1b0eBbBBBg2BBBgB1Bb1e2bBaBc2fBa0aBe0fBaB0e0aBa2d1", "12x12:hB1c2a1fBa1a21b1hBg0b3cBa2BeBcBb2b3b1cBe3BaBcBbBgBh1bB1a3a0f1aBcBBh", "12x12:m1bBd2BbBc0a1Be1kBgBf11b0d3b1BfBg1k1eB2a0cBb2BdBb1m", "12x12:b1a2bBa0BbBeBb1b2cB2cBBd1BaBb3bB1eBBzbBBeBBb3b1a1BdBBcBBc2b0b1eBbBBaBbBa2b", "12x12:cB1b10d3h2c1bB1b2cBhBa1j1aBaBd1a0bBa2dBaBa1jBaBh3cBbBBb4cBhBd00bBBc", "12x12:0aBf3aBn2fBb11hB1c2aB0aBcBa1fBa1Ba0f1a1cBaB2aBc1BhBBb1f2n1a1f1aB", "12x12:bBfBcBb1b2b3a3b1d3bBaBh3eBb2d1bBdBbB0b1d1bBdBb0eBhBaBb0d2bBa1bBbBb3cBfBb", "12x12:aBcB0c0b3cBBc0c3fBeB1b1BpBaBdBa2bBa1d0a1pB0b10e2f2cBcBBcBb1cB1cBa", "12x12:0f2cBaBa0f2i0e0c0cBa0dBiBc0hBc1i2d1a3c0cBeBiBf0aBa2c1f1", "12x12:a0b1l0aBaBa0a2mBb4aBdBbBBaBc1cBaBBBbBbBbBBBa2c2cBaB2b3dBa4bBmBaBa2aBa1lBb1a", "12x12:b0cBbBbBd0eBaBd2n2d2gB0g1b1bBb1g2BgBdBn2d0aBeBdBb0bBc0b", "12x12:1a1e0bBb01b3bBcBbBeB11i2e1b1aBc0t0c2a2b0e1i21BeBbBc1b1bBBbBb0e2a1", "12x12:2i1bB1d1Bc3cBlBa2c1m0d0a2f0aBd1m0cBa0lBcBcB3dB2b0iB", "12x12:aBi1bBBB2a3aBb2b2bBdBBcBc0kBa01a0d1Be1dB1lBaBB0cBcBc0bBb1d3b0B2BaBaBcBiB", "12x12:iBaBcBbB2a0d3cBdBaBBa1aBb0cBBBBd11c1kBj2BBBd1BbB1aBaBb2dBcBdBc3bBBaBkBaB", "12x12:e2dBBaBcBc3f0BBfBa1b2BBaBbBa1cBbBhBa1iBaBcBa1cBb1b1a1bBB2aBeBB2fBc2cBgBd1B", "12x12:jBaBb0dBBcBcBBaBdB2d0b0d4a2hBdBaBdBaBd0hBaBd2b1dB2d2a22cBcBBd2bBaBj", "12x12:2a2bBBa2b1fBhBg01hBf0a11dBBb2fB0fBb01dBBa2f1hBBg0h0f2b1aBBbBa0", "12x12:1jB1b1d1b0dBb1dBjBB2b1b1bBBb2aBbBa1d1aBbBaBbB2bBbBbBB2j0d1bBdBb1d0b1BjB", "12x12:b2bBaBBbBBg2f0c3d0BaBeB2aBc1cBBcBf0bBBb2f2c00cBcBaB1eBa1BdBcBfBgB2bB1aBb1b", "12x12:a1a1d0cBh1bBa2m1aBaBj0b0Be0d0a1aBbBl2dBa3eBaBa0b2Ba03a2cBcBd1bBd0aBBc", "12x12:aBb1b0b2b0hBb0h1eBbBf2b1BbBbBBh1B00h1Bb1b11bBf2b1e1h1b0h1bBbBb2bBa", "12x12:bBc3eBdBa3hBB1cBb3cB0cBmBaBa0c1bBBa2a2cBb2mBc0Bc1eBBBcBa1d3a2f1c2e", "12x12:f2aBaBl2Ba1BhBc1b20hBcBB2aB12aBaBaBbBgBBbBdB2fB1gBBcBbBBcB0b2hBdBBBa2Ba", "12x12:cBa1Ba0c1j0BjBcBa10aBdBhBa2bBd0bBBb1dBbBa2h3dBaB0a1cBjB0jBc0a1Ba0c", "12x12:BbBc2a3aBc1iBaBBBbBa1hBb1bBc1kBa2r2hBaBfBaBa2c1dBBaB2bB0d3a0dBbBbB", "12x12:eBg0a1e1e2a3b0BaBa0bBj2cBaBdBbBaBcBbBbBaBcBc2c1a0c2b1jBa0b2Ba1a1aBe0gBf", "12x12:0c0fBBbBiB2b1b0fBb2Bb2h1d1cBe00Bc2eBBgBgBbBBb3b1Bb0bBcBbBh1c2fB", "12x12:gBBaBBBa30bBaBj3b2dB1eBb0fBa0Bx1BaBf1b0eB3dBbBj2a2bB2aB0BaBBg", "12x12:lBBB0aBBa1B00eBBe2a3b0BbBaBa3aBd3a2aBjBBjBa2a1dBaBaBa2b1Bb2a3eBBeB1BBaBBaBBBBl", "12x12:2eBaBbBa2b0e2gB3dBcBa3g0e2aBa2aBBa0Bj0BaB0a1a0aBe1gBaBcBdB1g0eBb3aBb1aBeB", "12x12:aBc1c0aBBcBgBfBBa2a2a3aBaBaB2e1hBc1bBcBBc1b2cBh2eBBa1a2a1a2a1aBBfBg2cBBaBc2cBa", "12x12:i2BaBBaBbBc1aBa1dBaBe2dBaBc2c1fBb2n2bBfBcBcBaBd0eBa3dBaBaBc2b2aBBa1Bi", "12x12:c0e01Ba3b1aBdB2eBcBaBjBeBb2d1a0bBj4bBa2d0bBe2jBa3cBeB2dBa4b2aBBBeBc", "12x12:aBBBdB10zb21bBBcBa2f0a1cB0bBBfBBb1Bc0a3fBa0cB1bBBzb0B2dBBBa", "12x12:0dBdBB0fBd01c1BdBfBa3c1dBbB2bBBa1bBjBBdB0aBBbBBdB2jBcBBcBaBd3b2a1cBBc0dB", "12x12:aBhBd0BB2B1dBhBbBhBc1bB2bBcBhBbBhBc2b1BbBc3hBbBhBdB1BB1BdBh2a", "12x12:bBiBd0BaBbBa10dBa3cBqBBBdBa1d0a12a1d0a2dB01q0c1a2d0Ba1bBaB1d1iBb", "12x12:1a0c3bBBc2aBe1aBcBBkBa111bBbBbBbBc11fBbBnBa2c2bBcBaBdBa3cBB2aB1aBa3bBgBa3bBcBa", "12x12:BcBi2a0bBc1dBc2c0e0B2gBb1f12h0d1c0bBlBBaB2bB1Bc2B1hBa2dBd1eBb2a", "12x12:aBbBbBb2a2c1bBcBeB2e1aBbB0b1a2c2dBzdBdBc1a0b0BbBa1e1BeBcBbBcBa1b2b1bBa", "12x12:0dBbB1b0aBd0h2dBaBaB1bBBb0cBc1aBkBBBiBB0c0c2a2eBBbBBbBf0dBaBBa2d0d1dBbB2b", "12x12:c1BbBa3aBf2cBc1dBcBc1bBcBd1aBaBcBa0dBaBaBb1dBa0a1dBaBaBcBcBbBcBc3dBcBf0cBdB2bBaBaB", "12x12:n0a1aBa1hBb1a1b0Bc2oBb2aBeBdBe0aBb2oBcBBbBa0b4h0a3aBaBn", "12x12:cBaBBa2o3jBbBBBBBBBBc2a2d0a2z0aBd0aBcBB11BBB1bBjBoBa1Ba1c", "12x12:aBfBaBBc11BdBa0d1aBd0d21c3c0cBdBjBb2c2d1BbBdBf3aBcBbBBcBbBb3c2e0hBf", "12x12:0bB1b1aBa0h2c2a1c1a11c20hB2jBb1r0b1jB0hBBc1Ba2c0a2cBhBaBaBbBBbB", "12x12:a3dBd1b2b1eBd2a1bBbBBdBBa1b1i1aBiBb1i1aBiBb0a12d1Bb0bBaBdBe1bBb1d0d1a", "12x12:BgBaBc2b1BBeBdBBBBa0a0m1b2BaBB1a1b0dBb0dB3g2Bd1BfBeBaBdBbBc0B0cBb1Bd1gB", "12x12:cBeBb0c0a1aBcBe1c0aBc0aBbBbBb20bBdBc1aBb2c1b1aB20cBdBiBcBBBBdBa0aB1d0cBb1B1aBk", "12x12:a1cBb1a2aBd0e1e0b1c3aBdBg1m1Bb1B1BBBbBBm1g1d0a1c0bBe3eBd1aBa2bBc2a", "12x12:b1c0aBd1cBd2b1a31h0oBa1cBb2l1Bb0d0g1b1cB00a1cBb2aBlB2c1BBBcBaBb1a", "12x12:b0nBg1d2g2a1d11B1d2eBa0p0bBm3b2b1dBe10dBBg1bBfBBb2b", "12x12:dBaBhBaBBg2bBaBa0B11aBBb3d1B3cBBl0d1bBBBhBaBbBa1BbBf1c1BbBb2BaBc2d2dBgBBb", "12x12:0c0fBf2BbBc0BcBbBo0b0b2dB0bBd0BaB0b0d2BbBbBbBqB0c2bBg01b1a2cBfB", "12x12:cBBh3Be2Ba1BdBeBaBb0cBkBBa32aBa0b0Bc1aBa0b0BkB1aBaBb1cBcBdBeBa2Be2Ba1cBBg", "12x12:d0aBm3eBbBaBaBc1h3d2d0Bb1BBbBdBBBBBb2dBBc1dB3c1h3c1bBa1a2j2g1a2e", "12x12:eBBb2d4o0BaBa1a1aBaBcBb2fBBeBa0aBgBa2aBe2f11dBaBaBcBh2BaBaBb3nB2bBb", "12x12:aBbBbBb2mB3h1Bc0dBd2Ba1b0aB2c0f2dBfBcB2a1bBa01d3dBcBBhB0mBb1b1bBa", "12x12:b2b0BbBcBcBBc3oBfBcBb1b0bBcBa0bBaBd3a1b0aBc3b0b0b2c1fBoBcBBc0cBb0Bb1b", "12x12:a2dBBhB1c2a3a2b1nBdBbBbBbBBaBc2eBbBe3c1a11bBbBbBdBnBb1a1a0cB2h1Bd1a", "12x12:aBa0e0b1cB01Bh01bBcBa2fB0f0k0b1hBb1h1f0a0f03e0BbBcBcBB11e2aBe1b", "12x12:g1h1dBBe3aBe1b3b1c0aBcB00a000aBBoBdBb1b2aB10l1kBaBaBc2aBg1aB1c0a", "12x12:gBe2aBb0c4c3a3dBe3d1aBa0dBcBc2cBB1hBBBcBcBc3d1a3aBdBeBd2a3cBc0b3aBe1g", "12x12:a3aBl0a0a2BhBe1aBf1dBfBcBc0a1Bb1aBc1bBh01b3aBBa3c1dBBhBd1e3bBeBBbBb", "12x12:eBBc3cB1d1bBjBc4cBb1BBBBe0eBbBf2gBoB0cBb2BBe2cBBa3b0BhBd1aBd1", "12x12:aB1g1jB2a1Bd1a11cBBmBc1i1aB1aB1aB1aBi1c1m11c0Ba0d1BaB2j2gBBa", "12x12:b2Bd2d2aBb2bB2lBiBfB1Ba0cB2Be0f1eB0BcBa1BBfBi2lB0b1b2aBdBdB1b", "12x12:e00fBb1c2a2e2b1e1a2cBBeBBe2BaBjB0j2a10e00eBBcBaBeBbBeBa4cBb0fB1e", "12x12:c011aBbBB1jBb1e2iBbBaBh1eBaBcBbB1b2c4aBe1h3aBbBiBeBbBj3B0b1aBBBc", "12x12:bB0b0lB1aBc3dBg1e1a0B1bBbBdBa2c2d101bB1BaBfBc0eBhBaBd2bB1BB0a1BeBBBfBa2c", "12x12:a1bBb0b1b0b0bBb0n12b00bBBdBdBe3fBdBfBeBdBdBBb12b02nBb1b0b0b0bBb1bBa", "12x12:b1Bl0bBBBcBbBeBa1a2d4c1Bd0b2dBiBaBiB1d0bBc1a4d1c0aBbBeBe1b01Bd1Bh", "12x12:a0aBdBaBbBh2aBbBd0b2d4bBeBaBdBa0a1jB1jBaBaBd2aBeBbBd1b0dBbBaBh1b1a0d2a0a", "12x12:Bg2d1a1BcBc2h1aBcBeB1e2aBaBBjBbBBb2j1Ba0a0e20eBc1a0h3cBc1BaBd0gB", "12x12:BbBcBc1aBa0f3i2e2cBcB0Bn1pBn01BcBc1e3iBf0aBaBcBc0bB", "12x12:cBa2g3cB1jBBb0a0bB1i20b0aBc1iBBjBBb1Bb1aBcBbBBmB1b1a0a2cB2hBaBf", "12x12:BbBe1a0a3bB1iBo2b1aBb1dBaB2c1dBaBdBd1aBa0bBdBaBBg2b0dBiBbB0f1bBeBaB", "12x12:c1BBBa1a2e0aBBnBa1e0BbBl2eBBa2f2aBBe1lBbB3eBaBnBBaBe0a2aBBB1c", "12x12:aBb3dB2aBdBaBcBBoBh2f2bBj1bBj2b2f0hBo0Bc1aBdBa2Bd3bBa"
    };
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        LightUpManager.currentPack = 3;
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
        LightUpManager.currentPack = 3;
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