using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;

public class Square : MonoBehaviour
{
    public Image squareImage;
    public Sprite imgB, imgB2, imgE, imgL, imgXE, imgXL,
                  imgBPaper, imgB2Paper, imgEPaper, imgLPaper, imgXEPaper, imgXLPaper,
                  imgBWater, imgB2Water, imgEWater, imgLWater, imgXEWater, imgXLWater,
                  imgBTheme4, imgB2Theme4, imgETheme4, imgLTheme4, imgXETheme4, imgXLTheme4,
                  imgBTheme5, imgB2Theme5, imgETheme5, imgLTheme5, imgXETheme5, imgXLTheme5,
                  imgBDark, imgB2Dark, imgEDark, imgLDark, imgXEDark, imgXLDark,
                  imgBAkari, imgB2Akari, imgEAkari, imgLAkari, imgXEAkari, imgXLAkari,
                  imgBLightOut, imgB2LightOut, imgELightOut, imgLLightOut, imgXELightOut, imgXLLightOut,
                  imgBMinesweeper, imgB2Minesweeper, imgEMinesweeper, imgLMinesweeper, imgXEMinesweeper, imgXLMinesweeper,
                  imgBMedieval, imgB2Medieval, imgEMedieval, imgLMedieval, imgXEMedieval, imgXLMedieval;

    private int mapX;
    private int mapY;
    public int[,] vecL;
    private LightUp manager;
    public List<Tuple<int, int>> verticalB2;
    public List<Tuple<int, int>> horizontalB2;
    private bool isBigPuzzle;

    public void Start()
    {
        mapX = GameObject.Find("GameManager").GetComponent<LightUp>().mapX;
        mapY = GameObject.Find("GameManager").GetComponent<LightUp>().mapY;
        vecL = new int[mapX + mapY, 2];
        manager = GameObject.Find("GameManager").GetComponent<LightUp>();
        if ((mapX >= 32) && (mapY >= 32))   //1024 buttons
            isBigPuzzle = true;
        else
            isBigPuzzle = false;

        imgB = manager.imgB;
        imgB2 = manager.imgB2;
        imgE = manager.imgE;
        imgL = manager.imgL;
        imgXE = manager.imgXE;
        imgXL = manager.imgXL;
    }

    public void Click()
    {
        if ((manager.camera1.transform.position == manager.lastPos) || manager.isManufacturerSamsung)
        {
            if (manager.HintsClicked)
            {
                string imageNameHints;
                for (int i = 0; i < mapY; i++)
                {
                    for (int j = 0; j < mapX; j++)
                    {
                        imageNameHints = GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite.name;
                        switch (imageNameHints)
                        {
                            case "B2Error":
                                GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgB2;
                                break;
                            case "BError":
                                GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgB;
                                break;
                            case "EError":
                                GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgE;
                                break;
                            case "LError":
                                GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgL;
                                break;
                            case "XEError":
                                GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgXE;
                                break;
                            case "XLError":
                                GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgXL;
                                break;
                        }
                    }
                }
                manager.HintsClicked = false;
            }
            mapX = GameObject.Find("GameManager").GetComponent<LightUp>().mapX;
            mapY = GameObject.Find("GameManager").GetComponent<LightUp>().mapY;
            string imageName = squareImage.gameObject.transform.GetComponent<Image>().sprite.name;
            if (imageName.StartsWith("B-"))
            {
                squareImage.gameObject.transform.GetComponent<Image>().sprite = imgXE;
                manager.litTiles--;
                FindObjectOfType<AudioManager>().Play("switch1");
            }
            if (imageName.StartsWith("B2-"))
            {
                squareImage.gameObject.transform.GetComponent<Image>().sprite = imgXL;
                FindObjectOfType<AudioManager>().Play("switch1");
            }
            if (imageName.StartsWith("E-"))
            {
                squareImage.gameObject.transform.GetComponent<Image>().sprite = imgB;
                manager.litTiles++;
                FindObjectOfType<AudioManager>().Play("switch1");
            }
            if (imageName.StartsWith("L-"))
            {
                squareImage.gameObject.transform.GetComponent<Image>().sprite = imgB2;
                FindObjectOfType<AudioManager>().Play("switch1");
            }
            if (imageName.StartsWith("XE-"))
            {
                squareImage.gameObject.transform.GetComponent<Image>().sprite = imgE;
            }
            if (imageName.StartsWith("XL-"))
            {
                squareImage.gameObject.transform.GetComponent<Image>().sprite = imgL;
            }
            string[] posList = squareImage.name.Split('-');
            var clickedX = int.Parse(posList[1]);
            var clickedY = int.Parse(posList[2]);
            int x, y;
            string imageName2;
            string clickedImage = GameObject.Find("tile-" + clickedX + "-" + clickedY).GetComponent<Image>().sprite.name;
            int cont = 0;

            if (clickedImage.StartsWith("B-") || clickedImage.StartsWith("B2-"))
            {
                manager.listB.Add(new Tuple<int, int>(clickedX, clickedY));
                x = clickedX;
                y = clickedY;
                x--;
                if (x >= 0)
                {
                    imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) && (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (x >= 0))
                    {
                        vecL[cont, 0] = x;
                        vecL[cont, 1] = y;
                        cont++;
                        if (imageName2.StartsWith("E-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgL;
                            manager.litTiles++;
                        }
                        if (imageName2.StartsWith("XE-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgXL;
                            manager.litTiles++;
                        }
                        if (imageName2.StartsWith("B-"))
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgB2;
                        x--;
                        if (x >= 0)
                            imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    }
                }

                x = clickedX;
                y = clickedY;
                y++;
                if (y < mapX)
                {
                    imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) && (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (y < mapX))
                    {
                        vecL[cont, 0] = x;
                        vecL[cont, 1] = y;
                        cont++;
                        if (imageName2.StartsWith("E-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgL;
                            manager.litTiles++;
                        }
                        if (imageName2.StartsWith("XE-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgXL;
                            manager.litTiles++;
                        }
                        if (imageName2.StartsWith("B-"))
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgB2;
                        y++;
                        if (y < mapX)
                            imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    }
                }

                x = clickedX;
                y = clickedY;
                x++;
                if (x < mapY)
                {
                    imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) && (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (x < mapY))
                    {
                        vecL[cont, 0] = x;
                        vecL[cont, 1] = y;
                        cont++;
                        if (imageName2.StartsWith("E-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgL;
                            manager.litTiles++;
                        } 
                        if (imageName2.StartsWith("XE-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgXL;
                            manager.litTiles++;
                        }
                        if (imageName2.StartsWith("B-"))
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgB2;
                        x++;
                        if (x < mapY)
                            imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    }
                }

                x = clickedX;
                y = clickedY;
                y--;
                if (y >= 0)
                {
                    imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) && (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (y >= 0))
                    {
                        vecL[cont, 0] = x;
                        vecL[cont, 1] = y;
                        cont++;
                        if (imageName2.StartsWith("E-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgL;
                            manager.litTiles++;
                        }
                        if (imageName2.StartsWith("XE-"))
                        {
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgXL;
                            manager.litTiles++;
                        }
                        if (imageName2.StartsWith("B-"))
                            GameObject.Find("tile-" + x + "-" + y).gameObject.transform.GetComponent<Image>().sprite = imgB2;
                        y--;
                        if (y >= 0)
                            imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                    }
                }

                while (cont < mapX + mapY)
                {
                    vecL[cont, 0] = -1;
                    vecL[cont, 1] = -1;
                    cont++;
                }
            }

            if (clickedImage.StartsWith("XE-") || clickedImage.StartsWith("XL-"))
            {
                manager.listB.RemoveAll(item => item.Item1 == clickedX && item.Item2 == clickedY);
                int i = 0;
                bool vecEnd = false;
                while ((i < mapX + mapY) && (vecEnd != true))
                {
                    if (vecL[i, 0] != -1)
                    {
                        if (GameObject.Find("tile-" + vecL[i, 0] + "-" + vecL[i, 1]).GetComponent<Image>().sprite.name.StartsWith("L-"))
                        {
                            GameObject.Find("tile-" + vecL[i, 0] + "-" + vecL[i, 1]).gameObject.transform.GetComponent<Image>().sprite = imgE;
                            manager.litTiles--;
                        }                            
                        if (GameObject.Find("tile-" + vecL[i, 0] + "-" + vecL[i, 1]).GetComponent<Image>().sprite.name.StartsWith("XL-"))
                        {
                            GameObject.Find("tile-" + vecL[i, 0] + "-" + vecL[i, 1]).gameObject.transform.GetComponent<Image>().sprite = imgXE;
                            manager.litTiles--;
                        }                            
                    }
                    else
                        vecEnd = true;
                    i++;
                }

                int Lx, Ly;
                foreach (var tuple in manager.listB)
                {
                    i = 0;
                    vecEnd = false;
                    while ((i < mapX + mapY) && (vecEnd != true))
                    {
                        if (GameObject.Find("tile-" + tuple.Item1 + "-" + tuple.Item2).GetComponentInChildren<Square>().vecL[i, 0] != -1)
                        {
                            Lx = GameObject.Find("tile-" + tuple.Item1 + "-" + tuple.Item2).GetComponentInChildren<Square>().vecL[i, 0];
                            Ly = GameObject.Find("tile-" + tuple.Item1 + "-" + tuple.Item2).GetComponentInChildren<Square>().vecL[i, 1];
                            if (GameObject.Find("tile-" + Lx + "-" + Ly).GetComponent<Image>().sprite.name.StartsWith("E-"))
                            {
                                GameObject.Find("tile-" + Lx + "-" + Ly).gameObject.transform.GetComponent<Image>().sprite = imgL;
                                manager.litTiles++;
                            }
                            if (GameObject.Find("tile-" + Lx + "-" + Ly).GetComponent<Image>().sprite.name.StartsWith("XE-"))
                            {
                                GameObject.Find("tile-" + Lx + "-" + Ly).gameObject.transform.GetComponent<Image>().sprite = imgXL;
                                manager.litTiles++;
                            }
                        }
                        else
                            vecEnd = true;
                        i++;
                    }
                }

                if (clickedImage.StartsWith("XL-"))
                {
                    verticalB2 = new List<Tuple<int, int>>();
                    horizontalB2 = new List<Tuple<int, int>>();
                    int x2, y2;

                    x = clickedX;
                    y = clickedY;
                    x--;
                    if (x >= 0)
                    {
                        imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) &&
                               (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (!imageName2.StartsWith("E-")) && (!imageName2.StartsWith("XE-")) && (x >= 0))
                        {
                            if (imageName2.StartsWith("B2-"))
                            {
                                verticalB2.Add(new Tuple<int, int>(x, y));
                                x2 = x;
                                y2 = y;
                                string imageName3;
                                y2++;
                                if (y2 < mapX)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (y2 < mapX))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            verticalB2.Add(new Tuple<int, int>(x2, y2));
                                        y2++;
                                        if (y2 < mapX)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }

                                x2 = x;
                                y2 = y;
                                y2--;
                                if (y2 >= 0)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (y2 >= 0))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            verticalB2.Add(new Tuple<int, int>(x2, y2));
                                        y2--;
                                        if (y2 >= 0)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }
                            }
                            x--;
                            if (x >= 0)
                                imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        }
                    }

                    x = clickedX;
                    y = clickedY;
                    y++;
                    if (y < mapX)
                    {
                        imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) &&
                               (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (!imageName2.StartsWith("E-")) && (!imageName2.StartsWith("XE-")) && (y < mapX))
                        {
                            if (imageName2.StartsWith("B2-"))
                            {
                                horizontalB2.Add(new Tuple<int, int>(x, y));
                                x2 = x;
                                y2 = y;
                                string imageName3;
                                x2--;
                                if (x2 >= 0)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (x2 >= 0))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            horizontalB2.Add(new Tuple<int, int>(x2, y2));
                                        x2--;
                                        if (x2 >= 0)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }

                                x2 = x;
                                y2 = y;
                                x2++;
                                if (x2 < mapY)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (x2 < mapY))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            horizontalB2.Add(new Tuple<int, int>(x2, y2));
                                        x2++;
                                        if (x2 < mapY)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }
                            }
                            y++;
                            if (y < mapX)
                                imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        }
                    }

                    x = clickedX;
                    y = clickedY;
                    x++;
                    if (x < mapY)
                    {
                        imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) &&
                               (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (!imageName2.StartsWith("E-")) && (!imageName2.StartsWith("XE-")) && (x < mapY))
                        {
                            if (imageName2.StartsWith("B2-"))
                            {
                                verticalB2.Add(new Tuple<int, int>(x, y));
                                x2 = x;
                                y2 = y;
                                string imageName3;
                                y2++;
                                if (y2 < mapX)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (y2 < mapX))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            verticalB2.Add(new Tuple<int, int>(x2, y2));
                                        y2++;
                                        if (y2 < mapX)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }

                                x2 = x;
                                y2 = y;
                                y2--;
                                if (y2 >= 0)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (y2 >= 0))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            verticalB2.Add(new Tuple<int, int>(x2, y2));
                                        y2--;
                                        if (y2 >= 0)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }
                            }
                            x++;
                            if (x < mapY)
                                imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        }
                    }

                    x = clickedX;
                    y = clickedY;
                    y--;
                    if (y >= 0)
                    {
                        imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        while ((!imageName2.StartsWith("W-")) && (!imageName2.StartsWith("0-")) && (!imageName2.StartsWith("1-")) && (!imageName2.StartsWith("2-")) &&
                               (!imageName2.StartsWith("3-")) && (!imageName2.StartsWith("4-")) && (!imageName2.StartsWith("E-")) && (!imageName2.StartsWith("XE-")) && (y >= 0))
                        {
                            if (imageName2.StartsWith("B2-"))
                            {
                                horizontalB2.Add(new Tuple<int, int>(x, y));
                                x2 = x;
                                y2 = y;
                                string imageName3;
                                x2--;
                                if (x2 >= 0)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (x2 >= 0))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            horizontalB2.Add(new Tuple<int, int>(x2, y2));
                                        x2--;
                                        if (x2 >= 0)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }

                                x2 = x;
                                y2 = y;
                                x2++;
                                if (x2 < mapY)
                                {
                                    imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    while ((!imageName3.StartsWith("W-")) && (!imageName3.StartsWith("0-")) && (!imageName3.StartsWith("1-")) && (!imageName3.StartsWith("2-")) &&
                                           (!imageName3.StartsWith("3-")) && (!imageName3.StartsWith("4-")) && (x2 < mapY))
                                    {
                                        if (imageName3.StartsWith("B2-"))
                                            horizontalB2.Add(new Tuple<int, int>(x2, y2));
                                        x2++;
                                        if (x2 < mapY)
                                            imageName3 = GameObject.Find("tile-" + x2 + "-" + y2).GetComponent<Image>().sprite.name;
                                    }
                                }
                            }
                            y--;
                            if (y >= 0)
                                imageName2 = GameObject.Find("tile-" + x + "-" + y).GetComponent<Image>().sprite.name;
                        }
                    }

                    if (verticalB2.Count == 1)
                        GameObject.Find("tile-" + verticalB2[0].Item1 + "-" + verticalB2[0].Item2).gameObject.transform.GetComponent<Image>().sprite = imgB;
                    if (horizontalB2.Count == 1)
                        GameObject.Find("tile-" + horizontalB2[0].Item1 + "-" + horizontalB2[0].Item2).gameObject.transform.GetComponent<Image>().sprite = imgB;

                    verticalB2.RemoveRange(0, verticalB2.Count);
                    horizontalB2.RemoveRange(0, horizontalB2.Count);
                }
            }
            if (manager.playMode.activeSelf)
                GameObject.Find("/CanvasStatic/playMode/litProgress/litProgressText").GetComponent<TextMeshProUGUI>().text = (Mathf.FloorToInt((manager.litTiles * 100) / manager.tilesToWin)).ToString() + "%";           
        }

        if (!isBigPuzzle)
        {
            if ((squareImage.gameObject.transform.GetComponent<Image>().sprite == imgB) || (squareImage.gameObject.transform.GetComponent<Image>().sprite == imgXL))
            {
                if (manager.playMode.activeSelf)
                    manager.DoneClick();
                else
                    manager.DoneClickTimeTrial();
            }
        }
    }
}