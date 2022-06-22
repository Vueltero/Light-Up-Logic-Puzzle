using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class LightUp : MonoBehaviour
{
    // Camera pan and zoom
    Vector3 touchStart;
    private float zoomOutMin = 1;
    private float zoomOutMax = 40;
    public Camera camera1;

    // Spawners
    public GameObject whatToSpawnPrefab;

    // Map vars
    public Int16 mapX, mapY;

    public Sprite img0, img1, img2, img3, img4, imgB, imgB2, imgE, imgL, imgW, imgXE, imgXL,
                  imgSelected, imgTick, imgLock, imgEError, imgXEError, imgB2Error, imgBError, imgLError, imgXLError,
                  img0Paper, img1Paper, img2Paper, img3Paper, img4Paper, imgBPaper, imgB2Paper, imgEPaper, imgLPaper, imgWPaper, imgXEPaper, imgXLPaper,
                  img0Water, img1Water, img2Water, img3Water, img4Water, imgBWater, imgB2Water, imgEWater, imgLWater, imgWWater, imgXEWater, imgXLWater,
                  img0Theme4, img1Theme4, img2Theme4, img3Theme4, img4Theme4, imgBTheme4, imgB2Theme4, imgETheme4, imgLTheme4, imgWTheme4, imgXETheme4, imgXLTheme4,
                  img0Theme5, img1Theme5, img2Theme5, img3Theme5, img4Theme5, imgBTheme5, imgB2Theme5, imgETheme5, imgLTheme5, imgWTheme5, imgXETheme5, imgXLTheme5,
                  img0Dark, img1Dark, img2Dark, img3Dark, img4Dark, imgBDark, imgB2Dark, imgEDark, imgLDark, imgWDark, imgXEDark, imgXLDark,
                  img0Akari, img1Akari, img2Akari, img3Akari, img4Akari, imgBAkari, imgB2Akari, imgEAkari, imgLAkari, imgWAkari, imgXEAkari, imgXLAkari,
                  img0LightOut, img1LightOut, img2LightOut, img3LightOut, img4LightOut, imgBLightOut, imgB2LightOut, imgELightOut, imgLLightOut, imgWLightOut, imgXELightOut, imgXLLightOut,
                  img0Minesweeper, img1Minesweeper, img2Minesweeper, img3Minesweeper, img4Minesweeper, imgBMinesweeper, imgB2Minesweeper, imgEMinesweeper, imgLMinesweeper, imgWMinesweeper, imgXEMinesweeper, imgXLMinesweeper,
                  img0Medieval, img1Medieval, img2Medieval, img3Medieval, img4Medieval, imgBMedieval, imgB2Medieval, imgEMedieval, imgLMedieval, imgWMedieval, imgXEMedieval, imgXLMedieval,
                  img0Classic, img1Classic, img2Classic, img3Classic, img4Classic, imgBClassic, imgB2Classic, imgEClassic, imgLClassic, imgWClassic, imgXEClassic, imgXLClassic,
                  title256, titlePaper, titleStitches, titleForest, titleDark, titleWater, titleAkari, titleLightOut, titleExplosive, titleMedieval;

    public List<Tuple<int, int>> listB;

    public GameObject mainMenu, freePlay, playMode, classicPack, mania7x7, mania10x10, mania12x12,
                      mania14x14, mania25x25, mania30x30, mania35x35, mania40x40, mania45x45,
                      mania50x50, extremeJumboPack, intervalPack, intervalPack2, extremeInterval,
                      towerPack, rectanglePack, extremePack, jumboPack, jumboRectangle,
                      jumboRectangle2, mirrorPack4way, rotationalPack4way, extremeNoSymmetryPack,
                      kidsPack, lastPackSelected, fromPlayMode, store, fromStore, completedLevelPlayMode,
                      mistakesMsgPopUp, timeTrial, fromTimeTrial, timeTrialPlayMode, fromTimeTrialPlayMode,
                      completedTimeTrial, purchaseSuccessfulPopUp, settings, fromSettings, CanvasDynamic,
                      about, credits, hint1, hint2, hint3, hint4, hint5, howToPlay, fromAbout, exitPopUp,
                      hintsPopUp, getHintsPopUp, freeHintsPopUp, themes, fromThemes, classicTheme,
                      paperTheme, stitchesTheme, forestTheme, darkModeTheme, waterTheme, akariTheme,
                      lightOutTheme, explosiveTheme, medievalTheme, unlockAllThemes, titleObj,
                      languages, fromLanguages;

    private bool PanAndZoom = false;

    private string[] packsNames =
    {
        "classicPackButton", "7x7ManiaButton", "10x10ManiaButton", "12x12ManiaButton", "14x14ManiaButton",
        "25x25ManiaButton", "30x30ManiaButton", "35x35ManiaButton", "40x40ManiaButton", "45x45ManiaButton",
        "50x50ManiaButton", "extremeJumboPackButton", "intervalPackButton", "intervalPack2Button", "extremeIntervalButton",
        "towerPackButton", "rectanglePackButton", "extremePackButton", "jumboPackButton", "jumboRectangleButton",
        "jumboRectangle2Button", "4-wayMirrorPackButton", "4-wayRotationalPackButton", "extremeNoSymmetryPackButton", "kidsPackButton"
    };

    private float freePlayPacksPos;
    private float storePacksPos;

    private string shareMessage;

    public string previousLevelID;
    public string nextLevelID;

    public int currentPack;
    public int currentLevel;

    public int timeTrialSolved = 0;

    public TextMeshProUGUI timeRemainingText;
    public float currentTime;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI litProgressText;

    private bool hasEnded = false;
    private bool onPlayMode = false;

    public float[] ClassicPackTimes, Mania7x7Times, Mania10x10Times, Mania12x12Times, Mania14x14Times,
                   Mania25x25Times, Mania30x30Times, Mania35x35Times, Mania40x40Times, Mania45x45Times,
                   Mania50x50Times, ExtremeJumboPackTimes, IntervalPackTimes, IntervalPack2Times, ExtremeIntervalTimes,
                   TowerPackTimes, RectanglePackTimes, ExtremePackTimes, JumboPackTimes, JumboRectangleTimes,
                   JumboRectangle2Times, MirrorPack4wayTimes, RotationalPack4wayTimes, ExtremeNoSymmetryPackTimes, KidsPackTimes;
    public int[] TimeTrial7x7Solved, TimeTrial10x10Solved, TimeTrial12x12Solved, TimeTrial14x14Solved;
    public bool[] packsUnlocked;
    public int hints;
    public bool boughtHints;
    public int themeUnlocked0, themeUnlocked1, themeUnlocked2, themeUnlocked3, themeUnlocked4; //0 = false, 1 = true
    public int themeSelected; //0, 1, 2, .., 9

    public int timeTrialMinutesChoice;

    private bool timeTrialHasEnded;

    public int boardSize = -7;

    private bool playNewLevelInPack = true;

    private float timeForInterstitialAd = 0;
    private AdManager AdManager;

    private bool onSettings = false;

    public float volume = 0.8f;

    public Vector3 lastPos;

    public bool isManufacturerSamsung = false;

    public string versionUrl = "";
    public string currentVersion;
    private string latestVersion;
    public GameObject newVersionAvailable;

    public GameObject[] backButtons;

    public bool HintsClicked = false;

    public int errors;

    public Button viewAdButton;

    public int tilesToWin;
    public int litTiles;

    public float timeSinceRewardedAd = 0;
    public bool rewardedAdEnded = false;

    public string lastThemeSelected;

    public TextMeshProUGUI signInOutText;
    public TextMeshProUGUI cloudSyncText;
    public int cloudSync;
    public TextMeshProUGUI timeSinceLastModifiedText;
    public TextMeshProUGUI localSaveCreationTimeText;
    public string dataPosta;
    public TextMeshProUGUI dataPostaText;
    public TMP_InputField textToSaveInputField;

    private PlayGamesScript PlayGamesScriptManager;

    public bool achievementsChecked;
    public bool rookieAchiUnlocked;

    public int lang;
    private bool isLoadingLangFirstTime = true;

    //for checking if it's the first time the app opens, before changing the language.
    //To use the Application.systemLanguage as default
    public int isLangFirstTime = 1;

    public GameObject allPacksUnlockedText, storeText, hintsButton20, hintsButton5, hintsRemainingText;
    public TextMeshProUGUI hintsButton5Child;

    public void Start()
    {
        PlayGamesScriptManager = GameObject.Find("PlayGamesScriptManager").GetComponent<PlayGamesScript>();
        Application.targetFrameRate = 60;
        LoadSettings();
        LoadPlayer();
        if (!achievementsChecked)
            PlayGamesScriptManager.LoadAchisIfFirstTime();
        else
            PlayGamesScriptManager.SignIn();
        VerifyMainMenuThemes();
        listB = new List<Tuple<int, int>>();
        lastPackSelected = mainMenu;
        AdManager = GameObject.Find("AdManager").GetComponent<AdManager>();
        if (SystemInfo.deviceModel.Contains("samsung"))
            isManufacturerSamsung = true;
        StartCoroutine(LoadTxtData(versionUrl));
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void LoadSettings()
    {
        volume = PlayerPrefs.GetFloat("volume", 1f); //previous default was = 0.8f
        lang = PlayerPrefs.GetInt("lang", 4); //default language is english (en = 4)
        isLangFirstTime = PlayerPrefs.GetInt("isLangFirstTime", 1);
        if (isLangFirstTime == 1)
        {
            if (Application.systemLanguage == SystemLanguage.ChineseSimplified) lang = 1;
            else if (Application.systemLanguage == SystemLanguage.ChineseTraditional) lang = 2;
            else if (Application.systemLanguage == SystemLanguage.Dutch) lang = 3;
            else if (Application.systemLanguage == SystemLanguage.English) lang = 4;
            else if (Application.systemLanguage == SystemLanguage.French) lang = 5;
            else if (Application.systemLanguage == SystemLanguage.German) lang = 6;
            //there's no key for Hindi..
            else if (Application.systemLanguage == SystemLanguage.Indonesian) lang = 8;
            else if (Application.systemLanguage == SystemLanguage.Italian) lang = 9;
            else if (Application.systemLanguage == SystemLanguage.Japanese) lang = 10;
            else if (Application.systemLanguage == SystemLanguage.Korean) lang = 11;
            else if (Application.systemLanguage == SystemLanguage.Polish) lang = 12;
            else if (Application.systemLanguage == SystemLanguage.Portuguese) lang = 13;
            else if (Application.systemLanguage == SystemLanguage.Russian) lang = 14;
            else if (Application.systemLanguage == SystemLanguage.Spanish) lang = 15;
            else if (Application.systemLanguage == SystemLanguage.Swedish) lang = 16;
            else if (Application.systemLanguage == SystemLanguage.Thai) lang = 17;
            else if (Application.systemLanguage == SystemLanguage.Turkish) lang = 18;
            else if (Application.systemLanguage == SystemLanguage.Vietnamese) lang = 19;
            else lang = 4;
            isLangFirstTime = 0;
            SaveSettings();
        }
        ChangeLanguage(lang);
        isLoadingLangFirstTime = false;
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetInt("lang", lang);
        PlayerPrefs.SetInt("isLangFirstTime", isLangFirstTime);
    }

    public void Update()
    {
        if (PanAndZoom)
            CameraPanAndZoom();
        if (lastPackSelected == timeTrialPlayMode)
        {
            if ((currentTime > 0) && (!timeTrialHasEnded))
            {
                currentTime -= Time.deltaTime;
                timeRemainingText.text = string.Format("{0:0}:{1:00}", Mathf.FloorToInt(currentTime / 60), Mathf.FloorToInt(currentTime % 60));
            }
            else if (!timeTrialHasEnded)
            {
                currentTime = 0;
                timeRemainingText.text = string.Format("{0:0}:{1:00}", Mathf.FloorToInt(currentTime / 60), Mathf.FloorToInt(currentTime % 60));
                timeTrialHasEnded = true;
                CanvasGroupChangerActive(true, completedTimeTrial);
                GameObject.Find("/CanvasStatic/timeTrialPlayMode/restartLevelButton").GetComponent<Button>().interactable = false;
                GameObject.Find("/CanvasStatic/timeTrialPlayMode/doneButton").GetComponent<Button>().interactable = false;
                int minutesPos = 0;
                switch (timeTrialMinutesChoice)
                {
                    case 1: minutesPos = 0; break;
                    case 2: minutesPos = 1; break;
                    case 4: minutesPos = 2; break;
                    case 8: minutesPos = 3; break;
                }
                switch (currentPack)
                {
                    case -7:
                        GameEvents.current.TimeTrialWonTriggerEnter();
                        if (timeTrialSolved > TimeTrial7x7Solved[minutesPos])
                        {
                            TimeTrial7x7Solved[minutesPos] = timeTrialSolved;
                            GameObject.Find("/CanvasStatic/timeTrialPlayMode/bestSolvedText").GetComponent<TextMeshProUGUI>().text = timeTrialSolved.ToString();
                        }
                        break;
                    case -10:
                        GameEvents.current.TimeTrialWonTriggerEnter();
                        if (timeTrialSolved > TimeTrial10x10Solved[minutesPos])
                        {
                            TimeTrial10x10Solved[minutesPos] = timeTrialSolved;
                            GameObject.Find("/CanvasStatic/timeTrialPlayMode/bestSolvedText").GetComponent<TextMeshProUGUI>().text = timeTrialSolved.ToString();
                        }
                        break;
                    case -12:
                        GameEvents.current.TimeTrialWonTriggerEnter();
                        if (timeTrialSolved > TimeTrial12x12Solved[minutesPos])
                        {
                            TimeTrial12x12Solved[minutesPos] = timeTrialSolved;
                            GameObject.Find("/CanvasStatic/timeTrialPlayMode/bestSolvedText").GetComponent<TextMeshProUGUI>().text = timeTrialSolved.ToString();
                        }
                        break;
                    case -14:
                        GameEvents.current.TimeTrialWonTriggerEnter();
                        if (timeTrialSolved > TimeTrial14x14Solved[minutesPos])
                        {
                            TimeTrial14x14Solved[minutesPos] = timeTrialSolved;
                            GameObject.Find("/CanvasStatic/timeTrialPlayMode/bestSolvedText").GetComponent<TextMeshProUGUI>().text = timeTrialSolved.ToString();
                        }
                        break;
                }
                SavePlayer();
            }
        }
        else if (hasEnded)
        {
            currentTime += Time.deltaTime;
            currentTimeText.text = string.Format("{0:0}:{1:00}", Mathf.FloorToInt(currentTime / 60), Mathf.FloorToInt(currentTime % 60));
            timeForInterstitialAd += Time.deltaTime;
        }
        if (rewardedAdEnded)
        {
            timeSinceRewardedAd += Time.deltaTime;
            if (timeSinceRewardedAd >= 120)
                rewardedAdEnded = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //Escape = device back button (and Esc for PC)
        {
            if (!exitPopUp.activeSelf)
            {
                int i = 0;
                bool found = false;
                while ((i < backButtons.Length) && !found)
                {
                    if (backButtons[i].activeInHierarchy)
                    {
                        CanvasGroupChangerActive(false, mistakesMsgPopUp);
                        CanvasGroupChangerActive(false, purchaseSuccessfulPopUp);
                        CanvasGroupChangerActive(false, completedLevelPlayMode);
                        CanvasGroupChangerActive(false, completedTimeTrial);
                        CanvasGroupChangerActive(false, newVersionAvailable);
                        backButtons[i].GetComponent<Button>().onClick.Invoke();
                        found = true;
                    }
                    i++;
                }
                if (!found)
                {
                    FindObjectOfType<AudioManager>().Play("question_001");
                    CanvasGroupChangerActive(true, exitPopUp);
                }
            }
            else
                CanvasGroupChangerActive(false, exitPopUp);
        }
    }

    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            for (int i = 0; i < 150; i++)
            {
                ClassicPackTimes[i] = data.ClassicPackTimes[i];
                Mania7x7Times[i] = data.Mania7x7Times[i];
                Mania10x10Times[i] = data.Mania10x10Times[i];
                Mania12x12Times[i] = data.Mania12x12Times[i];
                Mania14x14Times[i] = data.Mania14x14Times[i];
                Mania25x25Times[i] = data.Mania25x25Times[i];
                Mania30x30Times[i] = data.Mania30x30Times[i];
                Mania35x35Times[i] = data.Mania35x35Times[i];
                Mania40x40Times[i] = data.Mania40x40Times[i];
                Mania45x45Times[i] = data.Mania45x45Times[i];
                Mania50x50Times[i] = data.Mania50x50Times[i];
                ExtremeJumboPackTimes[i] = data.ExtremeJumboPackTimes[i];
                IntervalPackTimes[i] = data.IntervalPackTimes[i];
                IntervalPack2Times[i] = data.IntervalPack2Times[i];
                ExtremeIntervalTimes[i] = data.ExtremeIntervalTimes[i];
                TowerPackTimes[i] = data.TowerPackTimes[i];
                RectanglePackTimes[i] = data.RectanglePackTimes[i];
                ExtremePackTimes[i] = data.ExtremePackTimes[i];
                JumboPackTimes[i] = data.JumboPackTimes[i];
                JumboRectangleTimes[i] = data.JumboRectangleTimes[i];
                JumboRectangle2Times[i] = data.JumboRectangle2Times[i];
                MirrorPack4wayTimes[i] = data.MirrorPack4wayTimes[i];
                RotationalPack4wayTimes[i] = data.RotationalPack4wayTimes[i];
                ExtremeNoSymmetryPackTimes[i] = data.ExtremeNoSymmetryPackTimes[i];
            }
            for (int i = 0; i < 120; i++)
                KidsPackTimes[i] = data.KidsPackTimes[i];
            for (int i = 0; i < 4; i++)
            {
                TimeTrial7x7Solved[i] = data.TimeTrial7x7Solved[i];
                TimeTrial10x10Solved[i] = data.TimeTrial10x10Solved[i];
                TimeTrial12x12Solved[i] = data.TimeTrial12x12Solved[i];
                TimeTrial14x14Solved[i] = data.TimeTrial14x14Solved[i];
            }
            for (int i = 0; i < 25; i++)
                packsUnlocked[i] = data.packsUnlocked[i];
            hints = data.hints;
            boughtHints = data.boughtHints;
            themeUnlocked0 = data.themeUnlocked0;
            themeUnlocked1 = data.themeUnlocked1;
            themeUnlocked2 = data.themeUnlocked2;
            themeUnlocked3 = data.themeUnlocked3;
            themeUnlocked4 = data.themeUnlocked4;
            themeSelected = data.themeSelected;
            switch (themeSelected)
            {
                case 0: lastThemeSelected = "classicThemeButton"; break;
                case 1: lastThemeSelected = "paperThemeButton"; break;
                case 2: lastThemeSelected = "stitchesThemeButton"; break;
                case 3: lastThemeSelected = "forestThemeButton"; break;
                case 4: lastThemeSelected = "darkModeThemeButton"; break;
                case 5: lastThemeSelected = "waterThemeButton"; break;
                case 6: lastThemeSelected = "akariThemeButton"; break;
                case 7: lastThemeSelected = "lightOutThemeButton"; break;
                case 8: lastThemeSelected = "explosiveThemeButton"; break;
                case 9: lastThemeSelected = "medievalThemeButton"; break;
            }
            achievementsChecked = data.achievementsChecked;
            rookieAchiUnlocked = data.rookieAchiUnlocked;
        }
        else
        {
            for (int i = 0; i < 150; i++)
            {
                ClassicPackTimes[i] = 0;
                Mania7x7Times[i] = -1;
                Mania10x10Times[i] = -1;
                Mania12x12Times[i] = -1;
                Mania14x14Times[i] = -1;
                Mania25x25Times[i] = -1;
                Mania30x30Times[i] = -1;
                Mania35x35Times[i] = -1;
                Mania40x40Times[i] = -1;
                Mania45x45Times[i] = -1;
                Mania50x50Times[i] = -1;
                ExtremeJumboPackTimes[i] = -1;
                IntervalPackTimes[i] = -1;
                IntervalPack2Times[i] = -1;
                ExtremeIntervalTimes[i] = -1;
                TowerPackTimes[i] = 0;
                RectanglePackTimes[i] = 0;
                ExtremePackTimes[i] = -1;
                JumboPackTimes[i] = 0;
                JumboRectangleTimes[i] = 0;
                JumboRectangle2Times[i] = 0;
                MirrorPack4wayTimes[i] = 0;
                RotationalPack4wayTimes[i] = 0;
                ExtremeNoSymmetryPackTimes[i] = 0;
            }
            for (int i = 0; i < 120; i++)
                KidsPackTimes[i] = 0;
            Mania7x7Times[0] = 0;
            Mania10x10Times[0] = 0;
            Mania12x12Times[0] = 0;
            Mania14x14Times[0] = 0;
            Mania25x25Times[0] = 0;
            Mania30x30Times[0] = 0;
            Mania35x35Times[0] = 0;
            Mania40x40Times[0] = 0;
            Mania45x45Times[0] = 0;
            Mania50x50Times[0] = 0;
            ExtremeJumboPackTimes[0] = 0;
            IntervalPackTimes[0] = 0;
            IntervalPack2Times[0] = 0;
            ExtremeIntervalTimes[0] = 0;
            ExtremePackTimes[0] = 0;
            for (int i = 0; i < 4; i++)
            {
                TimeTrial7x7Solved[i] = 0;
                TimeTrial10x10Solved[i] = 0;
                TimeTrial12x12Solved[i] = 0;
                TimeTrial14x14Solved[i] = 0;
            }
            packsUnlocked[0] = true;    //classicPack
            packsUnlocked[1] = true;    //7x7Mania
            packsUnlocked[2] = true;    //10x10Mania
            packsUnlocked[3] = true;    //12x12Mania
            packsUnlocked[4] = true;    //14x14Mania
            packsUnlocked[5] = true;    //25x25Mania
            packsUnlocked[6] = false;   //30x30Mania
            packsUnlocked[7] = false;   //35x35Mania
            packsUnlocked[8] = false;   //40x40Mania
            packsUnlocked[9] = false;   //45x45Mania
            packsUnlocked[10] = false;  //50x50Mania
            packsUnlocked[11] = false;  //extremeJumboPack
            packsUnlocked[12] = true;   //intervalPack
            packsUnlocked[13] = false;  //intervalPack2
            packsUnlocked[14] = false;  //extremeInterval
            packsUnlocked[15] = true;   //towerPack
            packsUnlocked[16] = true;   //rectanglePack
            packsUnlocked[17] = true;   //extremePack
            packsUnlocked[18] = true;   //jumboPack
            packsUnlocked[19] = true;   //jumboRectangle
            packsUnlocked[20] = false;  //jumboRectangle2
            packsUnlocked[21] = false;  //4-wayMirrorPack
            packsUnlocked[22] = false;  //4-wayRotationalPack
            packsUnlocked[23] = false;  //extremeNoSymmetryPackB
            packsUnlocked[24] = false;  //kidsPack
            hints = 3;
            boughtHints = false;
            themeUnlocked0 = 0;
            themeUnlocked1 = 0;
            themeUnlocked2 = 0;
            themeUnlocked3 = 0;
            themeUnlocked4 = 0;
            themeSelected = 0;
            lastThemeSelected = "classicThemeButton";
            achievementsChecked = true;
            rookieAchiUnlocked = false;
        }
    }

    public void SettingsButtonClick(string op)
    {
        switch (op)
        {
            case "volumeUp":
                if (volume < 1)
                    volume += 0.1f;
                volume = Mathf.Round(volume * 10f) / 10f;
                SaveSettings();
                FindObjectOfType<AudioManager>().Play("toggle_002");
                break;
            case "volumeDown":
                if (volume > 0)
                    volume -= 0.1f;
                volume = Mathf.Round(volume * 10f) / 10f;
                SaveSettings();
                FindObjectOfType<AudioManager>().Play("toggle_001");
                break;
        }
        // change soundText.text based on language
        GameEvents.current.VolumeTriggerEnter();
    }

    public void CameraPanAndZoom()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = camera1.ScreenToWorldPoint(Input.mousePosition);
            lastPos = camera1.transform.position;
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;
            Zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - camera1.ScreenToWorldPoint(Input.mousePosition);
            camera1.transform.position += direction;
        }
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    public void Zoom(float increment)
    {
        camera1.orthographicSize = Mathf.Clamp(camera1.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    private void IncrementAllCompleteXLevels(int steps)
    {
        //by mystake, GPGSIds.achievement_novice is not an incremental achi, so it goes separate
        IncrementAchi(GPGSIds.achievement_novice, steps);
        IncrementAchi(GPGSIds.achievement_amateur, steps);
        IncrementAchi(GPGSIds.achievement_pro, steps);
        IncrementAchi(GPGSIds.achievement_star, steps);
        IncrementAchi(GPGSIds.achievement_master, steps);
        IncrementAchi(GPGSIds.achievement_champion, steps);
        IncrementAchi(GPGSIds.achievement_world_champion, steps);
        IncrementAchi(GPGSIds.achievement_leet, steps);
        IncrementAchi(GPGSIds.achievement_electrician, steps);
        IncrementAchi(GPGSIds.achievement_chief_electrician, steps);
        IncrementAchi(GPGSIds.achievement_master_electrician, steps);
        IncrementAchi(GPGSIds.achievement_champion_electrician, steps);
        IncrementAchi(GPGSIds.achievement_world_champion_electrician, steps);
        IncrementAchi(GPGSIds.achievement_challenge_accepted, steps);
    }

    public void VerifyAchisIfNotChecked()
    {
        int score = 0;
        int[] pack = new int[25];
        for (int i = 0; i < 150; i++)
        {
            if (ClassicPackTimes[i] > 0) { score++; pack[0]++; }
            if (Mania7x7Times[i] > 0) { score++; pack[1]++; }
            if (Mania10x10Times[i] > 0) { score++; pack[2]++; }
            if (Mania12x12Times[i] > 0) { score++; pack[3]++; }
            if (Mania14x14Times[i] > 0) { score++; pack[4]++; }
            if (Mania25x25Times[i] > 0) { score++; pack[5]++; }
            if (Mania30x30Times[i] > 0) { score++; pack[6]++; }
            if (Mania35x35Times[i] > 0) { score++; pack[7]++; }
            if (Mania40x40Times[i] > 0) { score++; pack[8]++; }
            if (Mania45x45Times[i] > 0) { score++; pack[9]++; }
            if (Mania50x50Times[i] > 0) { score++; pack[10]++; }
            if (ExtremeJumboPackTimes[i] > 0) { score++; pack[11]++; }
            if (IntervalPackTimes[i] > 0) { score++; pack[12]++; }
            if (IntervalPack2Times[i] > 0) { score++; pack[13]++; }
            if (ExtremeIntervalTimes[i] > 0) { score++; pack[14]++; }
            if (TowerPackTimes[i] > 0) { score++; pack[15]++; }
            if (RectanglePackTimes[i] > 0) { score++; pack[16]++; }
            if (ExtremePackTimes[i] > 0) { score++; pack[17]++; }
            if (JumboPackTimes[i] > 0) { score++; pack[18]++; }
            if (JumboRectangleTimes[i] > 0) { score++; pack[19]++; }
            if (JumboRectangle2Times[i] > 0) { score++; pack[20]++; }
            if (MirrorPack4wayTimes[i] > 0) { score++; pack[21]++; }
            if (RotationalPack4wayTimes[i] > 0) { score++; pack[22]++; }
            if (ExtremeNoSymmetryPackTimes[i] > 0) { score++; pack[23]++; }
        }
        for (int i = 0; i < 120; i++)
            if (KidsPackTimes[i] > 0) { score++; pack[24]++; }
        IncrementAllCompleteXLevels(score);
        IncrementAchi(GPGSIds.achievement_classic_pack_complete, pack[0]);
        IncrementAchi(GPGSIds.achievement_7x7_mania_complete, pack[1]);
        IncrementAchi(GPGSIds.achievement_10x10_mania_complete, pack[2]);
        IncrementAchi(GPGSIds.achievement_12x12_mania_complete, pack[3]);
        IncrementAchi(GPGSIds.achievement_14x14_mania_complete, pack[4]);
        IncrementAchi(GPGSIds.achievement_25x25_mania_complete, pack[5]);
        IncrementAchi(GPGSIds.achievement_30x30_mania_complete, pack[6]);
        IncrementAchi(GPGSIds.achievement_35x35_mania_complete, pack[7]);
        IncrementAchi(GPGSIds.achievement_40x40_mania_complete, pack[8]);
        IncrementAchi(GPGSIds.achievement_45x45_mania_complete, pack[9]);
        IncrementAchi(GPGSIds.achievement_50x50_mania_complete, pack[10]);
        IncrementAchi(GPGSIds.achievement_extreme_jumbo_pack_complete, pack[11]);
        IncrementAchi(GPGSIds.achievement_interval_pack_complete, pack[12]);
        IncrementAchi(GPGSIds.achievement_interval_pack_2_complete, pack[13]);
        IncrementAchi(GPGSIds.achievement_extreme_interval_complete, pack[14]);
        IncrementAchi(GPGSIds.achievement_tower_pack_complete, pack[15]);
        IncrementAchi(GPGSIds.achievement_rectangle_pack_complete, pack[16]);
        IncrementAchi(GPGSIds.achievement_extreme_pack_complete, pack[17]);
        IncrementAchi(GPGSIds.achievement_jumbo_pack_complete, pack[18]);
        IncrementAchi(GPGSIds.achievement_jumbo_rectangle_complete, pack[19]);
        IncrementAchi(GPGSIds.achievement_jumbo_rectangle_2_complete, pack[20]);
        IncrementAchi(GPGSIds.achievement_4way_mirror_pack_complete, pack[21]);
        IncrementAchi(GPGSIds.achievement_4way_rotational_pack_complete, pack[22]);
        IncrementAchi(GPGSIds.achievement_extreme_no_symmetry_pack_complete, pack[23]);
        IncrementAchi(GPGSIds.achievement_kids_pack_complete, pack[24]);
        if (score > 9)
        {
            UnlockAchi(GPGSIds.achievement_rookie);
            rookieAchiUnlocked = true;
        }
        achievementsChecked = true;
        SavePlayer();
    }

    public void DoneClick()
    {
        string packName = packsNames[currentPack].Replace("Button", string.Empty);
        string containerName = "";
        GameObject obj;
        if (WinVerify())
        {
            IncrementAllCompleteXLevels(1);
            FindObjectOfType<AudioManager>().Play("confirmation_002");
            hasEnded = false;
            switch (currentPack)
            {
                case 0: VerifySaveBestTime(ClassicPackTimes, currentPack); break;
                case 1: VerifySaveBestTime(Mania7x7Times, currentPack); break;
                case 2: VerifySaveBestTime(Mania10x10Times, currentPack); break;
                case 3: VerifySaveBestTime(Mania12x12Times, currentPack); break;
                case 4: VerifySaveBestTime(Mania14x14Times, currentPack); break;
                case 5: VerifySaveBestTime(Mania25x25Times, currentPack); break;
                case 6: VerifySaveBestTime(Mania30x30Times, currentPack); break;
                case 7: VerifySaveBestTime(Mania35x35Times, currentPack); break;
                case 8: VerifySaveBestTime(Mania40x40Times, currentPack); break;
                case 9: VerifySaveBestTime(Mania45x45Times, currentPack); break;
                case 10: VerifySaveBestTime(Mania50x50Times, currentPack); break;
                case 11: VerifySaveBestTime(ExtremeJumboPackTimes, currentPack); break;
                case 12: VerifySaveBestTime(IntervalPackTimes, currentPack); break;
                case 13: VerifySaveBestTime(IntervalPack2Times, currentPack); break;
                case 14: VerifySaveBestTime(ExtremeIntervalTimes, currentPack); break;
                case 15: VerifySaveBestTime(TowerPackTimes, currentPack); break;
                case 16: VerifySaveBestTime(RectanglePackTimes, currentPack); break;
                case 17: VerifySaveBestTime(ExtremePackTimes, currentPack); break;
                case 18: VerifySaveBestTime(JumboPackTimes, currentPack); break;
                case 19: VerifySaveBestTime(JumboRectangleTimes, currentPack); break;
                case 20: VerifySaveBestTime(JumboRectangle2Times, currentPack); break;
                case 21: VerifySaveBestTime(MirrorPack4wayTimes, currentPack); break;
                case 22: VerifySaveBestTime(RotationalPack4wayTimes, currentPack); break;
                case 23: VerifySaveBestTime(ExtremeNoSymmetryPackTimes, currentPack); break;
                case 24: VerifySaveBestTime(KidsPackTimes, currentPack); break;
            }
            switch (currentPack)
            {
                case 0: VerifyUnlockNextLevel(ClassicPackTimes); break;
                case 1: VerifyUnlockNextLevel(Mania7x7Times); break;
                case 2: VerifyUnlockNextLevel(Mania10x10Times); break;
                case 3: VerifyUnlockNextLevel(Mania12x12Times); break;
                case 4: VerifyUnlockNextLevel(Mania14x14Times); break;
                case 5: VerifyUnlockNextLevel(Mania25x25Times); break;
                case 6: VerifyUnlockNextLevel(Mania30x30Times); break;
                case 7: VerifyUnlockNextLevel(Mania35x35Times); break;
                case 8: VerifyUnlockNextLevel(Mania40x40Times); break;
                case 9: VerifyUnlockNextLevel(Mania45x45Times); break;
                case 10: VerifyUnlockNextLevel(Mania50x50Times); break;
                case 11: VerifyUnlockNextLevel(ExtremeJumboPackTimes); break;
                case 12: VerifyUnlockNextLevel(IntervalPackTimes); break;
                case 13: VerifyUnlockNextLevel(IntervalPack2Times); break;
                case 14: VerifyUnlockNextLevel(ExtremeIntervalTimes); break;
                case 15: VerifyUnlockNextLevel(TowerPackTimes); break;
                case 16: VerifyUnlockNextLevel(RectanglePackTimes); break;
                case 17: VerifyUnlockNextLevel(ExtremePackTimes); break;
                case 18: VerifyUnlockNextLevel(JumboPackTimes); break;
                case 19: VerifyUnlockNextLevel(JumboRectangleTimes); break;
                case 20: VerifyUnlockNextLevel(JumboRectangle2Times); break;
                case 21: VerifyUnlockNextLevel(MirrorPack4wayTimes); break;
                case 22: VerifyUnlockNextLevel(RotationalPack4wayTimes); break;
                case 23: VerifyUnlockNextLevel(ExtremeNoSymmetryPackTimes); break;
                case 24: VerifyUnlockNextLevel(KidsPackTimes); break;
            }
            if (!rookieAchiUnlocked)
            {
                if (CalculateLevelsCompleted() > 9)
                {
                    UnlockAchi(GPGSIds.achievement_rookie);
                    if (PlayGamesScriptManager.IsSignedIn())
                        rookieAchiUnlocked = true;
                }
            }
            SavePlayer();
            CanvasGroupChangerActive(true, lastPackSelected);
            switch (currentLevel)
            {
                case int n when (n >= 0 && n <= 28): containerName = "1-30Container"; break;
                case int n when (n >= 29 && n <= 58): containerName = "31-60Container"; break;
                case int n when (n >= 59 && n <= 88): containerName = "61-90Container"; break;
                case int n when (n >= 89 && n <= 118): containerName = "91-120Container"; break;
                case int n when (n >= 119 && n <= 149): containerName = "121-150Container"; break;
            }
            if (currentLevel != 149)
            {
                obj = GameObject.Find("/CanvasStatic/" + packName + "/container/levels/" + containerName + "/level-" + (currentLevel + 2));
                if (obj.GetComponent<Button>().enabled == false)
                {
                    obj.GetComponent<Button>().enabled = true;
                    obj.GetComponent<Image>().sprite = imgSelected;
                    GameObject.Find("/CanvasStatic/playMode/nextLevelButton").GetComponent<Button>().interactable = true;
                }
            }
            switch (currentLevel)
            {
                case int n when (n >= 0 && n <= 29): containerName = "1-30Container"; break;
                case int n when (n >= 30 && n <= 59): containerName = "31-60Container"; break;
                case int n when (n >= 60 && n <= 89): containerName = "61-90Container"; break;
                case int n when (n >= 90 && n <= 119): containerName = "91-120Container"; break;
                case int n when (n >= 120 && n <= 149): containerName = "121-150Container"; break;
            }
            GameObject.Find("/CanvasStatic/" + packName + "/container/levels/" + containerName + "/level-" + (currentLevel + 1)).GetComponent<Image>().sprite = imgTick;
            GameObject.Find("/CanvasStatic/" + packName + "/container/levels/" + containerName + "/level-" + (currentLevel + 1)).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(253, 204, 113, 255);
            CanvasGroupChangerActive(false, lastPackSelected);
            CanvasGroupChangerActive(true, completedLevelPlayMode);
            GameEvents.current.LevelWonTriggerEnter();
            if (nextLevelID == "empty")
            {
                GameObject.Find("/CanvasStatic/completedLevelPlayMode/nextLevelButton").SetActive(false);
                GameObject.Find("/CanvasStatic/completedLevelPlayMode/nextPackButton").SetActive(true);
            }
        }
        if ((mapX >= 32) && (mapY >= 32))
        {
            if (!WinVerify())
            {
                CanvasGroupChangerActive(true, mistakesMsgPopUp);
                FindObjectOfType<AudioManager>().Play("lowThreeTone");
            }
        }
    }

    private void VerifyUnlockNextLevel(float[] PackTimes)
    {
        if (currentLevel < 149)
        {
            if (PackTimes[currentLevel + 1] == -1)
                PackTimes[currentLevel + 1] = 0;
        }
    }

    public void DoneClickTimeTrial()
    {
        if (WinVerify())
        {
            FindObjectOfType<AudioManager>().Play("confirmation_002");
            timeTrialSolved++;
            GameObject.Find("/CanvasStatic/timeTrialPlayMode/currentSolvedText").GetComponent<TextMeshProUGUI>().text = timeTrialSolved.ToString();
            for (int i = 0; i < mapY; i++)
                for (int j = 0; j < mapX; j++)
                    Destroy(GameObject.Find("tile-" + i + "-" + j));
            listB.RemoveRange(0, listB.Count);
            switch (currentPack)
            {
                case -7: GameObject.Find("PacksManager").GetComponent<TimeTrial7x7>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
                case -10: GameObject.Find("PacksManager").GetComponent<TimeTrial10x10>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
                case -12: GameObject.Find("PacksManager").GetComponent<TimeTrial12x12>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
                case -14: GameObject.Find("PacksManager").GetComponent<TimeTrial14x14>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
            }
        }
    }

    public void CheckVersion()
    {
        Debug.Log(currentVersion);
        Debug.Log(latestVersion);
        Version versionDevice = new Version(currentVersion);
        Version versionServer = new Version(latestVersion);
        int result = versionDevice.CompareTo(versionServer);
        if ((latestVersion != "") && (result < 0)) //if was able to read the online version and this one is higher than the one on the user device
        {
            FindObjectOfType<AudioManager>().Play("question_001");
            newVersionAvailable.SetActive(true);
        }
        /*if (result > 0)
            Console.WriteLine("version1 is greater");
        else if (result < 0)
            Console.WriteLine("version2 is greater");
        else
            Console.WriteLine("versions are equal");*/
    }

    IEnumerator LoadTxtData(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        latestVersion = www.text;
        CheckVersion();
    }

    public void HowToPlay(int hint)
    {
        FindObjectOfType<AudioManager>().Play("drop_004");
        switch (hint)
        {
            case -1:
                CanvasGroupChangerActive(false, howToPlay);
                CanvasGroupChangerActive(true, mainMenu);
                break;
            case 0:
                CanvasGroupChangerActive(false, mainMenu);
                CanvasGroupChangerActive(false, hint2);
                CanvasGroupChangerActive(false, hint3);
                CanvasGroupChangerActive(false, hint4);
                CanvasGroupChangerActive(false, hint5);
                CanvasGroupChangerActive(true, howToPlay);
                CanvasGroupChangerActive(true, hint1);
                break;
            case 1:
                CanvasGroupChangerActive(false, hint2);
                CanvasGroupChangerActive(true, hint1);
                break;
            case 2:
                CanvasGroupChangerActive(false, hint1);
                CanvasGroupChangerActive(false, hint3);
                CanvasGroupChangerActive(true, hint2);
                break;
            case 3:
                CanvasGroupChangerActive(false, hint2);
                CanvasGroupChangerActive(false, hint4);
                CanvasGroupChangerActive(true, hint3);
                break;
            case 4:
                CanvasGroupChangerActive(false, hint3);
                CanvasGroupChangerActive(false, hint5);
                CanvasGroupChangerActive(true, hint4);
                break;
            case 5:
                CanvasGroupChangerActive(false, hint4);
                CanvasGroupChangerActive(true, hint5);
                break;
        }
    }

    public void ClosePopUp(GameObject obj)
    {
        if (obj == completedLevelPlayMode)
        {
            GameObject.Find("/CanvasStatic/completedLevelPlayMode/nextPackButton").SetActive(false);
            GameObject.Find("/CanvasStatic/completedLevelPlayMode/nextLevelButton").SetActive(true);
            CanvasGroupChangerActive(false, completedLevelPlayMode);
        }
        else if (obj == mistakesMsgPopUp)
            CanvasGroupChangerActive(false, mistakesMsgPopUp);
        else if (obj == completedTimeTrial)
            CanvasGroupChangerActive(false, completedTimeTrial);
        else if (obj == purchaseSuccessfulPopUp)
            CanvasGroupChangerActive(false, purchaseSuccessfulPopUp);
        else if (obj == newVersionAvailable)
            CanvasGroupChangerActive(false, newVersionAvailable);
        else if (obj == exitPopUp)
            CanvasGroupChangerActive(false, exitPopUp);
        else if (obj == hintsPopUp)
            CanvasGroupChangerActive(false, hintsPopUp);
        else if (obj == getHintsPopUp)
        {
            CanvasGroupChangerActive(false, getHintsPopUp);
            if (!(packsUnlocked[6] || packsUnlocked[7] || packsUnlocked[8] || packsUnlocked[9] ||
            packsUnlocked[10] || packsUnlocked[11] || packsUnlocked[13] || packsUnlocked[14] ||
            packsUnlocked[20] || packsUnlocked[21] || packsUnlocked[22] || packsUnlocked[23] ||
            packsUnlocked[24] || boughtHints || themeUnlocked0 == 1 || themeUnlocked1 == 1 ||
            themeUnlocked2 == 1 || themeUnlocked3 == 1 || themeUnlocked4 == 1))
                if (AdManager.isRewardedAdReady())
                {
                    FindObjectOfType<AudioManager>().Play("drop_004");
                    CanvasGroupChangerActive(true, freeHintsPopUp);
                }
        }
        else if (obj == freeHintsPopUp)
            CanvasGroupChangerActive(false, freeHintsPopUp);
    }

    public void PlayRewardedAd()
    {
        AdManager.PlayRewardedVideoAd();
        rewardedAdEnded = true;
    }

    public bool WinVerify()
    {
        string imageName;
        string imageNameNumbers;
        int cantNeededToWin = 0;
        int cantOn = 0;
        int cantRedBulbs = 0;
        int contNumbers = 0;
        bool win = true;
        for (int i = 0; i < mapY; i++)
        {
            for (int j = 0; j < mapX; j++)
            {
                imageName = GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite.name;
                if ((!imageName.StartsWith("0-")) && (!imageName.StartsWith("1-")) && (!imageName.StartsWith("2-")) &&
                    (!imageName.StartsWith("3-")) && (!imageName.StartsWith("4-")) && (!imageName.StartsWith("W-")))
                    cantNeededToWin++;
                if (imageName.StartsWith("B-") || imageName.StartsWith("L-") || imageName.StartsWith("XL-"))
                    cantOn++;
                if (imageName.StartsWith("B2-"))
                    cantRedBulbs++;
                for (int side = 0; side < 5; side++)
                {
                    if (imageName.StartsWith(side + "-"))
                    {
                        if (i - 1 >= 0)
                        {
                            imageNameNumbers = GameObject.Find("tile-" + (i - 1) + "-" + j).GetComponent<Image>().sprite.name;
                            if (imageNameNumbers.StartsWith("B-") || imageNameNumbers.StartsWith("B2-"))
                                contNumbers++;
                        }
                        if (j + 1 < mapX)
                        {
                            imageNameNumbers = GameObject.Find("tile-" + i + "-" + (j + 1)).GetComponent<Image>().sprite.name;
                            if (imageNameNumbers.StartsWith("B-") || imageNameNumbers.StartsWith("B2-"))
                                contNumbers++;
                        }
                        if (i + 1 < mapY)
                        {
                            imageNameNumbers = GameObject.Find("tile-" + (i + 1) + "-" + j).GetComponent<Image>().sprite.name;
                            if (imageNameNumbers.StartsWith("B-") || imageNameNumbers.StartsWith("B2-"))
                                contNumbers++;
                        }
                        if (j - 1 >= 0)
                        {
                            imageNameNumbers = GameObject.Find("tile-" + i + "-" + (j - 1)).GetComponent<Image>().sprite.name;
                            if (imageNameNumbers.StartsWith("B-") || imageNameNumbers.StartsWith("B2-"))
                                contNumbers++;
                        }
                        if (contNumbers != side)
                            win = false;
                    }
                    contNumbers = 0;
                }
                if ((cantOn != cantNeededToWin) || (cantRedBulbs > 0))
                    win = false;
            }
        }
        return win;
    }

    public void SelectNextPackFromPopUp()
    {
        GameObject.Find("/CanvasStatic/completedLevelPlayMode/nextPackButton").SetActive(false);
        GameObject.Find("/CanvasStatic/completedLevelPlayMode/nextLevelButton").SetActive(true);
        CanvasGroupChangerActive(false, completedLevelPlayMode);
        for (int i = 0; i < mapY; i++)
            for (int j = 0; j < mapX; j++)
                Destroy(GameObject.Find("tile-" + i + "-" + j));
        listB.RemoveRange(0, listB.Count);
        PanAndZoom = false;
        CanvasGroupChangerActive(false, playMode);
        ChangeTabs(freePlay);
    }

    private (float, float) VerifyFreePlayPacks(float[] PackTimes)
    {
        int i, iMax = 150;
        float cont = 0, time = 0;
        if (PackTimes == KidsPackTimes)
            iMax = 120;
        for (i = 0; i < iMax; i++)
            if (PackTimes[i] > 0)
            {
                cont++;
                time += PackTimes[i];
            }
        return (cont, time);
    }

    public void ChangeTabs(GameObject obj)
    {
        if (obj == classicPack || obj == mania7x7 || obj == mania10x10 || obj == mania12x12 || obj == mania14x14 ||
            obj == mania25x25 || obj == mania30x30 || obj == mania35x35 || obj == mania40x40 || obj == mania45x45 ||
            obj == mania50x50 || obj == extremeJumboPack || obj == intervalPack || obj == intervalPack2 || obj == extremeInterval ||
            obj == towerPack || obj == rectanglePack || obj == extremePack || obj == jumboPack || obj == jumboRectangle ||
            obj == jumboRectangle2 || obj == mirrorPack4way || obj == rotationalPack4way || obj == extremeNoSymmetryPack || obj == kidsPack)
        {
            UnloadFreePlayPacks();
            CanvasGroupChangerActive(false, freePlay);
            CanvasGroupChangerActive(true, obj);
            lastPackSelected = obj;
            if (obj == classicPack) VerifyPack(ClassicPackTimes, obj);
            if (obj == mania7x7) VerifyPack(Mania7x7Times, obj);
            if (obj == mania10x10) VerifyPack(Mania10x10Times, obj);
            if (obj == mania12x12) VerifyPack(Mania12x12Times, obj);
            if (obj == mania14x14) VerifyPack(Mania14x14Times, obj);
            if (obj == mania25x25) VerifyPack(Mania25x25Times, obj);
            if (obj == mania30x30) VerifyPack(Mania30x30Times, obj);
            if (obj == mania35x35) VerifyPack(Mania35x35Times, obj);
            if (obj == mania40x40) VerifyPack(Mania40x40Times, obj);
            if (obj == mania45x45) VerifyPack(Mania45x45Times, obj);
            if (obj == mania50x50) VerifyPack(Mania50x50Times, obj);
            if (obj == extremeJumboPack) VerifyPack(ExtremeJumboPackTimes, obj);
            if (obj == intervalPack) VerifyPack(IntervalPackTimes, obj);
            if (obj == intervalPack2) VerifyPack(IntervalPack2Times, obj);
            if (obj == extremeInterval) VerifyPack(ExtremeIntervalTimes, obj);
            if (obj == towerPack) VerifyPack(TowerPackTimes, obj);
            if (obj == rectanglePack) VerifyPack(RectanglePackTimes, obj);
            if (obj == extremePack) VerifyPack(ExtremePackTimes, obj);
            if (obj == jumboPack) VerifyPack(JumboPackTimes, obj);
            if (obj == jumboRectangle) VerifyPack(JumboRectangleTimes, obj);
            if (obj == jumboRectangle2) VerifyPack(JumboRectangle2Times, obj);
            if (obj == mirrorPack4way) VerifyPack(MirrorPack4wayTimes, obj);
            if (obj == rotationalPack4way) VerifyPack(RotationalPack4wayTimes, obj);
            if (obj == extremeNoSymmetryPack) VerifyPack(ExtremeNoSymmetryPackTimes, obj);
            if (obj == kidsPack) VerifyPack(KidsPackTimes, obj);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == mainMenu)
        {
            UnloadFreePlayPacks();
            CanvasGroupChangerActive(false, freePlay);
            CanvasGroupChangerActive(true, mainMenu);
            lastPackSelected = obj;
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == settings)
        {
            CanvasGroupChangerActive(false, about);
            if (onPlayMode)
            {
                CanvasGroupChangerActive(false, playMode);
                CanvasGroupChangerActive(false, CanvasDynamic);
            }
            else if (lastPackSelected == timeTrialPlayMode)
            {
                CanvasGroupChangerActive(false, timeTrialPlayMode);
                CanvasGroupChangerActive(false, CanvasDynamic);
            }
            else
                CanvasGroupChangerActive(false, lastPackSelected);
            CanvasGroupChangerActive(true, settings);
            PanAndZoom = false;
            volume = Mathf.Round(volume * 10f) / 10f;
            GameEvents.current.VolumeTriggerEnter(); //change soundText.text based on language
            GameEvents.current.ThemeTriggerEnter();
            FindObjectOfType<AudioManager>().Play("drop_004");
            onSettings = true;
        }
        if (obj == fromSettings)
        {
            CanvasGroupChangerActive(false, settings);
            PanAndZoom = true;
            if (onPlayMode)
            {
                CanvasGroupChangerActive(true, playMode);
                CanvasGroupChangerActive(true, CanvasDynamic);
            }
            else if (lastPackSelected == timeTrialPlayMode)
            {
                CanvasGroupChangerActive(true, timeTrialPlayMode);
                CanvasGroupChangerActive(true, CanvasDynamic);
            }
            else
                CanvasGroupChangerActive(true, lastPackSelected);
            FindObjectOfType<AudioManager>().Play("drop_004");
            onSettings = false;
        }
        if (obj == freePlay)
        {
            CanvasGroupChangerActive(false, mainMenu);
            CanvasGroupChangerActive(false, lastPackSelected);
            CanvasGroupChangerActive(true, freePlay);
            for (int i = 0; i < 25; i++)
                if (packsUnlocked[i] == true)
                    GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i]).SetActive(true);
            for (int i = 0; i < 25; i++)
            {
                if (GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i]).activeSelf)
                {
                    int max = 150;
                    var result = (0f, 0f);
                    switch (i)
                    {
                        case 0: result = VerifyFreePlayPacks(ClassicPackTimes); break;
                        case 1: result = VerifyFreePlayPacks(Mania7x7Times); break;
                        case 2: result = VerifyFreePlayPacks(Mania10x10Times); break;
                        case 3: result = VerifyFreePlayPacks(Mania12x12Times); break;
                        case 4: result = VerifyFreePlayPacks(Mania14x14Times); break;
                        case 5: result = VerifyFreePlayPacks(Mania25x25Times); break;
                        case 6: result = VerifyFreePlayPacks(Mania30x30Times); break;
                        case 7: result = VerifyFreePlayPacks(Mania35x35Times); break;
                        case 8: result = VerifyFreePlayPacks(Mania40x40Times); break;
                        case 9: result = VerifyFreePlayPacks(Mania45x45Times); break;
                        case 10: result = VerifyFreePlayPacks(Mania50x50Times); break;
                        case 11: result = VerifyFreePlayPacks(ExtremeJumboPackTimes); break;
                        case 12: result = VerifyFreePlayPacks(IntervalPackTimes); break;
                        case 13: result = VerifyFreePlayPacks(IntervalPack2Times); break;
                        case 14: result = VerifyFreePlayPacks(ExtremeIntervalTimes); break;
                        case 15: result = VerifyFreePlayPacks(TowerPackTimes); break;
                        case 16: result = VerifyFreePlayPacks(RectanglePackTimes); break;
                        case 17: result = VerifyFreePlayPacks(ExtremePackTimes); break;
                        case 18: result = VerifyFreePlayPacks(JumboPackTimes); break;
                        case 19: result = VerifyFreePlayPacks(JumboRectangleTimes); break;
                        case 20: result = VerifyFreePlayPacks(JumboRectangle2Times); break;
                        case 21: result = VerifyFreePlayPacks(MirrorPack4wayTimes); break;
                        case 22: result = VerifyFreePlayPacks(RotationalPack4wayTimes); break;
                        case 23: result = VerifyFreePlayPacks(ExtremeNoSymmetryPackTimes); break;
                        case 24: result = VerifyFreePlayPacks(KidsPackTimes); max = 120; break;
                    }
                    GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i] + "/Text (TMP) (1)").GetComponent<TextMeshProUGUI>().text = result.Item1 + " / " + max;
                    if (((i != 24) && (result.Item1 == 150)) || ((i == 24) && (result.Item1 == 120)))
                        GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i] + "/Text (TMP) (1)").GetComponent<TextMeshProUGUI>().color = new Color32(253, 204, 113, 255);
                    float hours = Mathf.FloorToInt(result.Item2 / 3600);
                    float minutes = Mathf.FloorToInt(result.Item2 / 60);
                    float seconds = Mathf.FloorToInt(result.Item2 % 60);

                    //minutes = 187
                    float minutesHours = Mathf.FloorToInt(minutes / 60);
                    minutes = ((minutes / 60) - minutesHours) * 60;

                    if (result.Item2 != 0)
                        GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i] + "/packTimeText").GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
                    else
                        GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i] + "/packTimeText").GetComponent<TextMeshProUGUI>().text = "";
                }
            }
            LoadFreePlayPacks();
            lastPackSelected = obj;
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == playMode)
        {
            CanvasGroupChangerActive(true, lastPackSelected);
            CanvasGroupChangerActive(true, playMode);
            onPlayMode = true;
            switch (currentPack)
            {
                case 0: VerifyLoadBestTime(ClassicPackTimes); break;
                case 1: VerifyLoadBestTime(Mania7x7Times); break;
                case 2: VerifyLoadBestTime(Mania10x10Times); break;
                case 3: VerifyLoadBestTime(Mania12x12Times); break;
                case 4: VerifyLoadBestTime(Mania14x14Times); break;
                case 5: VerifyLoadBestTime(Mania25x25Times); break;
                case 6: VerifyLoadBestTime(Mania30x30Times); break;
                case 7: VerifyLoadBestTime(Mania35x35Times); break;
                case 8: VerifyLoadBestTime(Mania40x40Times); break;
                case 9: VerifyLoadBestTime(Mania45x45Times); break;
                case 10: VerifyLoadBestTime(Mania50x50Times); break;
                case 11: VerifyLoadBestTime(ExtremeJumboPackTimes); break;
                case 12: VerifyLoadBestTime(IntervalPackTimes); break;
                case 13: VerifyLoadBestTime(IntervalPack2Times); break;
                case 14: VerifyLoadBestTime(ExtremeIntervalTimes); break;
                case 15: VerifyLoadBestTime(TowerPackTimes); break;
                case 16: VerifyLoadBestTime(RectanglePackTimes); break;
                case 17: VerifyLoadBestTime(ExtremePackTimes); break;
                case 18: VerifyLoadBestTime(JumboPackTimes); break;
                case 19: VerifyLoadBestTime(JumboRectangleTimes); break;
                case 20: VerifyLoadBestTime(JumboRectangle2Times); break;
                case 21: VerifyLoadBestTime(MirrorPack4wayTimes); break;
                case 22: VerifyLoadBestTime(RotationalPack4wayTimes); break;
                case 23: VerifyLoadBestTime(ExtremeNoSymmetryPackTimes); break;
                case 24: VerifyLoadBestTime(KidsPackTimes); break;
            }
            if (playNewLevelInPack)
            {
                camera1.transform.position = new Vector3(0, 0, 0);
                camera1.orthographicSize = 5;
            }
            PanAndZoom = true;
            if (previousLevelID == "empty")
                GameObject.Find("/CanvasStatic/playMode/previousLevelButton").GetComponent<Button>().interactable = false;
            else
                GameObject.Find("/CanvasStatic/playMode/previousLevelButton").GetComponent<Button>().interactable = true;
            string packName = packsNames[currentPack].Replace("Button", string.Empty);
            string containerName = "";
            switch (currentLevel)
            {
                case int n when (n >= 0 && n <= 28): containerName = "1-30Container"; break;
                case int n when (n >= 29 && n <= 58): containerName = "31-60Container"; break;
                case int n when (n >= 59 && n <= 88): containerName = "61-90Container"; break;
                case int n when (n >= 89 && n <= 118): containerName = "91-120Container"; break;
                case int n when (n >= 119 && n <= 149): containerName = "121-150Container"; break;
            }
            GameEvents.current.LevelChangedTriggerEnter();
            GameObject.Find("/CanvasStatic/playMode/currentLevelDimensionText").GetComponent<TextMeshProUGUI>().text = mapX + "x" + mapY;

            if ((nextLevelID == "empty") || ((nextLevelID != "empty") && (GameObject.Find("/CanvasStatic/" + packName + "/container/levels/" + containerName + "/level-" + (currentLevel + 2)).GetComponent<Button>().enabled == false)))
                GameObject.Find("/CanvasStatic/playMode/nextLevelButton").GetComponent<Button>().interactable = false;
            else
                GameObject.Find("/CanvasStatic/playMode/nextLevelButton").GetComponent<Button>().interactable = true;
            CanvasGroupChangerActive(false, lastPackSelected);
            currentTime = 0;
            hasEnded = true;
            FindObjectOfType<AudioManager>().Play("drop_004");
            if (hints != 0)
                GameObject.Find("/CanvasStatic/playMode/hintsText").GetComponent<TextMeshProUGUI>().text = hints + " x";
            else
                GameObject.Find("/CanvasStatic/playMode/hintsText").GetComponent<TextMeshProUGUI>().text = "+";
            InvokeRepeating("CheckRewardedAd", 0, 5);
        }
        if (obj == fromPlayMode)
        {
            for (int i = 0; i < mapY; i++)
                for (int j = 0; j < mapX; j++)
                    Destroy(GameObject.Find("tile-" + i + "-" + j));
            listB.RemoveRange(0, listB.Count);
            PanAndZoom = false;
            CanvasGroupChangerActive(false, playMode);
            onPlayMode = false;
            CanvasGroupChangerActive(true, lastPackSelected);
            hasEnded = false;
            playNewLevelInPack = true;
            FindObjectOfType<AudioManager>().Play("drop_004");
            CancelInvoke("CheckRewardedAd");
        }
        if (obj == store)
        {
            if (lastPackSelected == playMode)
                CanvasGroupChangerInteractable(false, playMode);
            if (onSettings)
                CanvasGroupChangerActive(false, settings);
            else if (lastPackSelected == freePlay)
            {
                UnloadFreePlayPacks();
                CanvasGroupChangerActive(false, freePlay);
            }
            else
                CanvasGroupChangerActive(false, mainMenu);
            //CanvasGroupChangerActive(false, settings);
            CanvasGroupChangerActive(true, store);
            LoadStore();
            if (packsUnlocked[6] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[6]).SetActive(false);
            if (packsUnlocked[7] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[7]).SetActive(false);
            if (packsUnlocked[8] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[8]).SetActive(false);
            if (packsUnlocked[9] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[9]).SetActive(false);
            if (packsUnlocked[10] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[10]).SetActive(false);
            if (packsUnlocked[11] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[11]).SetActive(false);
            if (packsUnlocked[13] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[13]).SetActive(false);
            if (packsUnlocked[14] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[14]).SetActive(false);
            if (packsUnlocked[20] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[20]).SetActive(false);
            if (packsUnlocked[21] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[21]).SetActive(false);
            if (packsUnlocked[22] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[22]).SetActive(false);
            if (packsUnlocked[23] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[23]).SetActive(false);
            if (packsUnlocked[24] == true) GameObject.Find("/CanvasStatic/store/" + packsNames[24]).SetActive(false);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == fromStore)
        {
            UnloadStore();
            CanvasGroupChangerActive(false, store);
            if (lastPackSelected == playMode)
                CanvasGroupChangerInteractable(true, playMode);
            else if (lastPackSelected == freePlay)
            {
                CanvasGroupChangerActive(true, freePlay);
                ChangeTabs(freePlay);
            }
            else if (onSettings)
                CanvasGroupChangerActive(true, settings);
            else if (hasEnded)
            {
                CanvasGroupChangerActive(true, playMode);
                CanvasGroupChangerActive(true, CanvasDynamic);
            }
            else if (lastPackSelected == timeTrialPlayMode)
            {
                CanvasGroupChangerActive(true, timeTrialPlayMode);
                CanvasGroupChangerActive(true, CanvasDynamic);
            }
            else
                CanvasGroupChangerActive(true, lastPackSelected);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == timeTrial)
        {
            CanvasGroupChangerActive(false, mainMenu);
            CanvasGroupChangerActive(true, timeTrial);
            lastPackSelected = obj;
            switch (boardSize)
            {
                case -7: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial7x7Solved); break;
                case -10: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial10x10Solved); break;
                case -12: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial12x12Solved); break;
                case -14: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial14x14Solved); break;
            }
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == fromTimeTrial)
        {
            CanvasGroupChangerActive(false, timeTrial);
            CanvasGroupChangerActive(true, mainMenu);
            lastPackSelected = mainMenu;
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == timeTrialPlayMode)
        {
            CanvasGroupChangerActive(true, timeTrialPlayMode);
            camera1.transform.position = new Vector3(0, 0, 0);
            camera1.orthographicSize = 5;
            PanAndZoom = true;
            lastPackSelected = obj;
            int minutesPos = 0;
            switch (timeTrialMinutesChoice)
            {
                case 1: minutesPos = 0; break;
                case 2: minutesPos = 1; break;
                case 4: minutesPos = 2; break;
                case 8: minutesPos = 3; break;
            }
            switch (currentPack)
            {
                case -7: VerifyTimeTrialSolved(TimeTrial7x7Solved, minutesPos); break;
                case -10: VerifyTimeTrialSolved(TimeTrial10x10Solved, minutesPos); break;
                case -12: VerifyTimeTrialSolved(TimeTrial12x12Solved, minutesPos); break;
                case -14: VerifyTimeTrialSolved(TimeTrial14x14Solved, minutesPos); break;
            }
            CanvasGroupChangerActive(false, timeTrial);
            timeTrialHasEnded = false;
            GameObject.Find("/CanvasStatic/timeTrialPlayMode/restartLevelButton").GetComponent<Button>().interactable = true;
            GameObject.Find("/CanvasStatic/timeTrialPlayMode/doneButton").GetComponent<Button>().interactable = true;
        }
        if (obj == fromTimeTrialPlayMode)
        {
            for (int i = 0; i < mapY; i++)
                for (int j = 0; j < mapX; j++)
                    Destroy(GameObject.Find("tile-" + i + "-" + j));
            listB.RemoveRange(0, listB.Count);
            PanAndZoom = false;
            GameObject.Find("/CanvasStatic/timeTrialPlayMode/currentSolvedText").GetComponent<TextMeshProUGUI>().text = "0";
            CanvasGroupChangerActive(false, timeTrialPlayMode);
            CanvasGroupChangerActive(true, timeTrial);
            timeTrialHasEnded = true;
            timeTrialSolved = 0;
            switch (boardSize)
            {
                case -7: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial7x7Solved); break;
                case -10: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial10x10Solved); break;
                case -12: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial12x12Solved); break;
                case -14: VerifyTimeTrialMinutesSolvedByBoard(TimeTrial14x14Solved); break;
            }
            FindObjectOfType<AudioManager>().Play("drop_004");
            if (completedTimeTrial.activeSelf)
                CanvasGroupChangerActive(false, completedTimeTrial);
        }
        if (obj == about)
        {
            CanvasGroupChangerActive(false, mainMenu);
            CanvasGroupChangerActive(false, settings);
            CanvasGroupChangerActive(true, about);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == fromAbout)
        {
            CanvasGroupChangerActive(false, about);
            if (onSettings)
                CanvasGroupChangerActive(true, settings);
            else
                CanvasGroupChangerActive(true, mainMenu);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        /*if (obj == credits)
        {
            CanvasGroupChangerActive(false, about);
            CanvasGroupChangerActive(true, credits);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }*/
        if (obj == themes)
        {
            CanvasGroupChangerActive(false, settings);
            CanvasGroupChangerActive(true, themes);
            GameEvents.current.ThemeBoughtTriggerEnter();
            GameObject.Find("/CanvasStatic/themes/" + lastThemeSelected + "/circleImage").SetActive(true);
            if (themeUnlocked0 == 1)
                GameObject.Find("/CanvasStatic/themes/waterThemeButton/lockImage").SetActive(false);
            if (themeUnlocked1 == 1)
                GameObject.Find("/CanvasStatic/themes/akariThemeButton/lockImage").SetActive(false);
            if (themeUnlocked2 == 1)
                GameObject.Find("/CanvasStatic/themes/lightOutThemeButton/lockImage").SetActive(false);
            if (themeUnlocked3 == 1)
                GameObject.Find("/CanvasStatic/themes/explosiveThemeButton/lockImage").SetActive(false);
            if (themeUnlocked4 == 1)
                GameObject.Find("/CanvasStatic/themes/medievalThemeButton/lockImage").SetActive(false);
            if (themeUnlocked0 == 1 && themeUnlocked1 == 1 && themeUnlocked2 == 1 && themeUnlocked3 == 1 && themeUnlocked4 == 1)
                GameObject.Find("/CanvasStatic/themes/unlockAllThemesButton").SetActive(false);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == fromThemes)
        {
            CanvasGroupChangerActive(false, themes);
            CanvasGroupChangerActive(true, settings);
            GameEvents.current.ThemeTriggerEnter();
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == languages)
        {
            CanvasGroupChangerActive(false, settings);
            CanvasGroupChangerActive(true, languages);
            FindObjectOfType<AudioManager>().Play("drop_004");
        }
        if (obj == fromLanguages)
        {
            CanvasGroupChangerActive(false, languages);
            CanvasGroupChangerActive(true, settings);
            FindObjectOfType<AudioManager>().Play("drop_004");
            GameEvents.current.LanguageChangedTriggerEnter();
        }
    }

    public void SettingsMainMenuClick()
    {
        CanvasGroupChangerActive(false, mainMenu);
        CanvasGroupChangerActive(true, settings);
        FindObjectOfType<AudioManager>().Play("drop_004");
    }

    public void CheckRewardedAd()
    {
        if (!(packsUnlocked[6] || packsUnlocked[7] || packsUnlocked[8] || packsUnlocked[9] ||
            packsUnlocked[10] || packsUnlocked[11] || packsUnlocked[13] || packsUnlocked[14] ||
            packsUnlocked[20] || packsUnlocked[21] || packsUnlocked[22] || packsUnlocked[23] ||
            packsUnlocked[24] || boughtHints || themeUnlocked0 == 1 || themeUnlocked1 == 1 ||
            themeUnlocked2 == 1 || themeUnlocked3 == 1 || themeUnlocked4 == 1))
        {
            if (AdManager.isRewardedAdReady())
                viewAdButton.gameObject.SetActive(true);
            else
                viewAdButton.gameObject.SetActive(false);
        }
        //Debug.Log("CheckRewardedAd()");
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);

        // "market" works for android (iOS: put your app link)
        // Application.OpenURL("market://details?id=com.test.testtest");

        // Android, (iOS: put you app store link)
        // Application.OpenURL("https://play.google.com/store/apps/dev?id=1551996653619230352");

        // Feedback
        // Application.OpenURL ("mailto:youremail@gmail.com");
    }

    public void SelectTheme(GameObject obj)
    {
        Sprite[] spriteList;
        spriteList = new Sprite[12];
        if (obj == classicTheme)
        {
            spriteList[0] = img0Classic; spriteList[1] = img1Classic; spriteList[2] = img2Classic; spriteList[3] = img3Classic;
            spriteList[4] = img4Classic; spriteList[5] = imgBClassic; spriteList[6] = imgB2Classic; spriteList[7] = imgEClassic;
            spriteList[8] = imgLClassic; spriteList[9] = imgWClassic; spriteList[10] = imgXEClassic; spriteList[11] = imgXLClassic;
            VerifyThemeSelected(0, "classicThemeButton", spriteList);
            FindObjectOfType<AudioManager>().Play("confirmation_002");
        }
        if (obj == paperTheme)
        {
            spriteList[0] = img0Paper; spriteList[1] = img1Paper; spriteList[2] = img2Paper; spriteList[3] = img3Paper;
            spriteList[4] = img4Paper; spriteList[5] = imgBPaper; spriteList[6] = imgB2Paper; spriteList[7] = imgEPaper;
            spriteList[8] = imgLPaper; spriteList[9] = imgWPaper; spriteList[10] = imgXEPaper; spriteList[11] = imgXLPaper;
            VerifyThemeSelected(1, "paperThemeButton", spriteList);
            FindObjectOfType<AudioManager>().Play("confirmation_002");
        }
        if (obj == stitchesTheme)
        {
            spriteList[0] = img0Theme4; spriteList[1] = img1Theme4; spriteList[2] = img2Theme4; spriteList[3] = img3Theme4;
            spriteList[4] = img4Theme4; spriteList[5] = imgBTheme4; spriteList[6] = imgB2Theme4; spriteList[7] = imgETheme4;
            spriteList[8] = imgLTheme4; spriteList[9] = imgWTheme4; spriteList[10] = imgXETheme4; spriteList[11] = imgXLTheme4;
            VerifyThemeSelected(2, "stitchesThemeButton", spriteList);
            FindObjectOfType<AudioManager>().Play("confirmation_002");
        }
        if (obj == forestTheme)
        {
            spriteList[0] = img0Theme5; spriteList[1] = img1Theme5; spriteList[2] = img2Theme5; spriteList[3] = img3Theme5;
            spriteList[4] = img4Theme5; spriteList[5] = imgBTheme5; spriteList[6] = imgB2Theme5; spriteList[7] = imgETheme5;
            spriteList[8] = imgLTheme5; spriteList[9] = imgWTheme5; spriteList[10] = imgXETheme5; spriteList[11] = imgXLTheme5;
            VerifyThemeSelected(3, "forestThemeButton", spriteList);
            FindObjectOfType<AudioManager>().Play("confirmation_002");
        }
        if (obj == darkModeTheme)
        {
            spriteList[0] = img0Dark; spriteList[1] = img1Dark; spriteList[2] = img2Dark; spriteList[3] = img3Dark;
            spriteList[4] = img4Dark; spriteList[5] = imgBDark; spriteList[6] = imgB2Dark; spriteList[7] = imgEDark;
            spriteList[8] = imgLDark; spriteList[9] = imgWDark; spriteList[10] = imgXEDark; spriteList[11] = imgXLDark;
            VerifyThemeSelected(4, "darkModeThemeButton", spriteList);
            FindObjectOfType<AudioManager>().Play("confirmation_002");
        }
        if (obj == waterTheme)
        {
            if (themeUnlocked0 == 1)
            {
                spriteList[0] = img0Water; spriteList[1] = img1Water; spriteList[2] = img2Water; spriteList[3] = img3Water;
                spriteList[4] = img4Water; spriteList[5] = imgBWater; spriteList[6] = imgB2Water; spriteList[7] = imgEWater;
                spriteList[8] = imgLWater; spriteList[9] = imgWWater; spriteList[10] = imgXEWater; spriteList[11] = imgXLWater;
                VerifyThemeSelected(5, "waterThemeButton", spriteList);
                FindObjectOfType<AudioManager>().Play("confirmation_002");
            }
            else
                IAPManager.instance.BuyThemeWater();
        }
        if (obj == akariTheme)
        {
            if (themeUnlocked1 == 1)
            {
                spriteList[0] = img0Akari; spriteList[1] = img1Akari; spriteList[2] = img2Akari; spriteList[3] = img3Akari;
                spriteList[4] = img4Akari; spriteList[5] = imgBAkari; spriteList[6] = imgB2Akari; spriteList[7] = imgEAkari;
                spriteList[8] = imgLAkari; spriteList[9] = imgWAkari; spriteList[10] = imgXEAkari; spriteList[11] = imgXLAkari;
                VerifyThemeSelected(6, "akariThemeButton", spriteList);
                FindObjectOfType<AudioManager>().Play("confirmation_002");
            }
            else
                IAPManager.instance.BuyThemeAkari();
        }
        if (obj == lightOutTheme)
        {
            if (themeUnlocked2 == 1)
            {
                spriteList[0] = img0LightOut; spriteList[1] = img1LightOut; spriteList[2] = img2LightOut; spriteList[3] = img3LightOut;
                spriteList[4] = img4LightOut; spriteList[5] = imgBLightOut; spriteList[6] = imgB2LightOut; spriteList[7] = imgELightOut;
                spriteList[8] = imgLLightOut; spriteList[9] = imgWLightOut; spriteList[10] = imgXELightOut; spriteList[11] = imgXLLightOut;
                VerifyThemeSelected(7, "lightOutThemeButton", spriteList);
                FindObjectOfType<AudioManager>().Play("confirmation_002");
            }
            else
                IAPManager.instance.BuyThemeLightOut();
        }
        if (obj == explosiveTheme)
        {
            if (themeUnlocked3 == 1)
            {
                spriteList[0] = img0Minesweeper; spriteList[1] = img1Minesweeper; spriteList[2] = img2Minesweeper; spriteList[3] = img3Minesweeper;
                spriteList[4] = img4Minesweeper; spriteList[5] = imgBMinesweeper; spriteList[6] = imgB2Minesweeper; spriteList[7] = imgEMinesweeper;
                spriteList[8] = imgLMinesweeper; spriteList[9] = imgWMinesweeper; spriteList[10] = imgXEMinesweeper; spriteList[11] = imgXLMinesweeper;
                VerifyThemeSelected(8, "explosiveThemeButton", spriteList);
                FindObjectOfType<AudioManager>().Play("confirmation_002");
            }
            else
                IAPManager.instance.BuyThemeExplosive();
        }
        if (obj == medievalTheme)
        {
            if (themeUnlocked4 == 1)
            {
                spriteList[0] = img0Medieval; spriteList[1] = img1Medieval; spriteList[2] = img2Medieval; spriteList[3] = img3Medieval;
                spriteList[4] = img4Medieval; spriteList[5] = imgBMedieval; spriteList[6] = imgB2Medieval; spriteList[7] = imgEMedieval;
                spriteList[8] = imgLMedieval; spriteList[9] = imgWMedieval; spriteList[10] = imgXEMedieval; spriteList[11] = imgXLMedieval;
                VerifyThemeSelected(9, "medievalThemeButton", spriteList);
                FindObjectOfType<AudioManager>().Play("confirmation_002");
            }
            else
                IAPManager.instance.BuyThemeMedieval();
        }
        if (obj == unlockAllThemes)
        {
            IAPManager.instance.BuyUnlockAllThemes();
        }
    }

    private void VerifyThemeSelected(int themeSelectedNumber, string lastThemeSelectedText, Sprite[] spriteList)
    {
        themeSelected = themeSelectedNumber;
        SavePlayer();
        GameObject.Find("/CanvasStatic/themes/" + lastThemeSelected + "/circleImage").SetActive(false);
        GameObject.Find("/CanvasStatic/themes/" + lastThemeSelectedText + "/circleImage").SetActive(true);
        lastThemeSelected = lastThemeSelectedText;
        if (onPlayMode)
        {
            CanvasGroupChangerActive(true, CanvasDynamic);
            for (int i = 0; i < mapY; i++)
            {
                for (int j = 0; j < mapX; j++)
                {
                    GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j + "/SquareManager").GetComponent<Square>().imgB = spriteList[5];
                    GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j + "/SquareManager").GetComponent<Square>().imgB2 = spriteList[6];
                    GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j + "/SquareManager").GetComponent<Square>().imgE = spriteList[7];
                    GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j + "/SquareManager").GetComponent<Square>().imgL = spriteList[8];
                    GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j + "/SquareManager").GetComponent<Square>().imgXE = spriteList[10];
                    GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j + "/SquareManager").GetComponent<Square>().imgXL = spriteList[11];
                    string imageName = GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite.name;
                    if (imageName.StartsWith("0-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[0];
                    if (imageName.StartsWith("1-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[1];
                    if (imageName.StartsWith("2-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[2];
                    if (imageName.StartsWith("3-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[3];
                    if (imageName.StartsWith("4-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[4];
                    if (imageName.StartsWith("B-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[5];
                    if (imageName.StartsWith("B2-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[6];
                    if (imageName.StartsWith("W-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[9];
                    if (imageName.StartsWith("E-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[7];
                    if (imageName.StartsWith("L-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[8];
                    if (imageName.StartsWith("XE-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[10];
                    if (imageName.StartsWith("XL-"))
                        GameObject.Find("/CanvasDynamic/tile-" + i + "-" + j).GetComponent<Image>().sprite = spriteList[11];
                }
            }
            CanvasGroupChangerActive(false, CanvasDynamic);
        }
        VerifyMainMenuThemes();
    }

    private void VerifyMainMenuThemes()
    {
        switch (themeSelected)
        {
            case 0: titleObj.GetComponent<Image>().sprite = title256; break;
            case 1: titleObj.GetComponent<Image>().sprite = titlePaper; break;
            case 2: titleObj.GetComponent<Image>().sprite = titleStitches; break;
            case 3: titleObj.GetComponent<Image>().sprite = titleForest; break;
            case 4: titleObj.GetComponent<Image>().sprite = titleDark; break;
            case 5: titleObj.GetComponent<Image>().sprite = titleWater; break;
            case 6: titleObj.GetComponent<Image>().sprite = titleAkari; break;
            case 7: titleObj.GetComponent<Image>().sprite = titleLightOut; break;
            case 8: titleObj.GetComponent<Image>().sprite = titleExplosive; break;
            case 9: titleObj.GetComponent<Image>().sprite = titleMedieval; break;
        }
    }

    private void VerifyPack(float[] PackTimes, GameObject obj)
    {
        string containerName = "";
        int i, iMax = 150;
        if (obj == kidsPack)
            iMax = 120;
        for (i = 0; i < iMax; i++)
        {
            switch (i)
            {
                case int n when (n >= 0 && n <= 29): containerName = "1-30Container"; break;
                case int n when (n >= 30 && n <= 59): containerName = "31-60Container"; break;
                case int n when (n >= 60 && n <= 89): containerName = "61-90Container"; break;
                case int n when (n >= 90 && n <= 119): containerName = "91-120Container"; break;
                case int n when (n >= 120 && n <= 149): containerName = "121-150Container"; break;
            }
            if (PackTimes[i] == -1) // -1 = locked
            {
                obj.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.Find(containerName + "/level-" + (i + 1)).GetComponent<Button>().enabled = false;
                obj.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.Find(containerName + "/level-" + (i + 1)).GetComponent<Image>().sprite = imgLock;
            }
            else if (PackTimes[i] == 0) // 0 = unlocked
            {
                obj.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.Find(containerName + "/level-" + (i + 1)).GetComponent<Button>().enabled = true;
                obj.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.Find(containerName + "/level-" + (i + 1)).GetComponent<Image>().sprite = imgSelected;
            }
            else // sth else = completed
            {
                obj.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.Find(containerName + "/level-" + (i + 1)).GetComponent<Button>().enabled = true;
                obj.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.Find(containerName + "/level-" + (i + 1)).GetComponent<Image>().sprite = imgTick;
                obj.gameObject.transform.GetChild(0).GetChild(0).gameObject.transform.Find(containerName + "/level-" + (i + 1)).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(253, 204, 113, 255);
            }
        }
    }

    private void VerifyLoadBestTime(float[] PackTimes)
    {
        if (PackTimes[currentLevel] > 0)
            GameObject.Find("/CanvasStatic/playMode/bestTime/bestTimeText").GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}:{1:00}", Mathf.FloorToInt(PackTimes[currentLevel] / 60), Mathf.FloorToInt(PackTimes[currentLevel] % 60));
        else
            GameObject.Find("/CanvasStatic/playMode/bestTime/bestTimeText").GetComponent<TextMeshProUGUI>().text = "-";
    }

    private void VerifySaveBestTime(float[] PackTimes, int currentPack)
    {
        if (GameObject.Find("/CanvasStatic/playMode/bestTime/bestTimeText").GetComponent<TextMeshProUGUI>().text == "-")
        {
            switch (currentPack)
            {
                case 0: IncrementAchi(GPGSIds.achievement_classic_pack_complete, 1); break;
                case 1: IncrementAchi(GPGSIds.achievement_7x7_mania_complete, 1); break;
                case 2: IncrementAchi(GPGSIds.achievement_10x10_mania_complete, 1); break;
                case 3: IncrementAchi(GPGSIds.achievement_12x12_mania_complete, 1); break;
                case 4: IncrementAchi(GPGSIds.achievement_14x14_mania_complete, 1); break;
                case 5: IncrementAchi(GPGSIds.achievement_25x25_mania_complete, 1); break;
                case 6: IncrementAchi(GPGSIds.achievement_30x30_mania_complete, 1); break;
                case 7: IncrementAchi(GPGSIds.achievement_35x35_mania_complete, 1); break;
                case 8: IncrementAchi(GPGSIds.achievement_40x40_mania_complete, 1); break;
                case 9: IncrementAchi(GPGSIds.achievement_45x45_mania_complete, 1); break;
                case 10: IncrementAchi(GPGSIds.achievement_50x50_mania_complete, 1); break;
                case 11: IncrementAchi(GPGSIds.achievement_extreme_jumbo_pack_complete, 1); break;
                case 12: IncrementAchi(GPGSIds.achievement_interval_pack_complete, 1); break;
                case 13: IncrementAchi(GPGSIds.achievement_interval_pack_2_complete, 1); break;
                case 14: IncrementAchi(GPGSIds.achievement_extreme_interval_complete, 1); break;
                case 15: IncrementAchi(GPGSIds.achievement_tower_pack_complete, 1); break;
                case 16: IncrementAchi(GPGSIds.achievement_rectangle_pack_complete, 1); break;
                case 17: IncrementAchi(GPGSIds.achievement_extreme_pack_complete, 1); break;
                case 18: IncrementAchi(GPGSIds.achievement_jumbo_pack_complete, 1); break;
                case 19: IncrementAchi(GPGSIds.achievement_jumbo_rectangle_complete, 1); break;
                case 20: IncrementAchi(GPGSIds.achievement_jumbo_rectangle_2_complete, 1); break;
                case 21: IncrementAchi(GPGSIds.achievement_4way_mirror_pack_complete, 1); break;
                case 22: IncrementAchi(GPGSIds.achievement_4way_rotational_pack_complete, 1); break;
                case 23: IncrementAchi(GPGSIds.achievement_extreme_no_symmetry_pack_complete, 1); break;
                case 24: IncrementAchi(GPGSIds.achievement_kids_pack_complete, 1); break;
            }
        }
        if ((GameObject.Find("/CanvasStatic/playMode/bestTime/bestTimeText").GetComponent<TextMeshProUGUI>().text == "-") || (currentTime < PackTimes[currentLevel]))
        {
            PackTimes[currentLevel] = currentTime;
            GameObject.Find("/CanvasStatic/playMode/bestTime/bestTimeText").GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}:{1:00}", Mathf.FloorToInt(currentTime / 60), Mathf.FloorToInt(currentTime % 60));
        }
    }

    private void VerifyTimeTrialSolved(int[] op, int min)
    {
        if (op[min] > 0)
            GameObject.Find("/CanvasStatic/timeTrialPlayMode/bestSolvedText").GetComponent<TextMeshProUGUI>().text = op[min].ToString();
        else
            GameObject.Find("/CanvasStatic/timeTrialPlayMode/bestSolvedText").GetComponent<TextMeshProUGUI>().text = "-";
    }

    private void VerifyTimeTrialMinutesSolvedByBoard(int[] op)
    {
        if (op[0] != 0)
            GameObject.Find("timeTrial/minute1Button/solved1MinText").GetComponent<TextMeshProUGUI>().text = op[0].ToString();
        else
            GameObject.Find("timeTrial/minute1Button/solved1MinText").GetComponent<TextMeshProUGUI>().text = "-";
        if (op[1] != 0)
            GameObject.Find("timeTrial/minute2Button/solved2MinText").GetComponent<TextMeshProUGUI>().text = op[1].ToString();
        else
            GameObject.Find("timeTrial/minute2Button/solved2MinText").GetComponent<TextMeshProUGUI>().text = "-";
        if (op[2] != 0)
            GameObject.Find("timeTrial/minute4Button/solved4MinText").GetComponent<TextMeshProUGUI>().text = op[2].ToString();
        else
            GameObject.Find("timeTrial/minute4Button/solved4MinText").GetComponent<TextMeshProUGUI>().text = "-";
        if (op[3] != 0)
            GameObject.Find("timeTrial/minute8Button/solved8MinText").GetComponent<TextMeshProUGUI>().text = op[3].ToString();
        else
            GameObject.Find("timeTrial/minute8Button/solved8MinText").GetComponent<TextMeshProUGUI>().text = "-";
    }

    public void PlayATimeTrial(int minutes)
    {
        timeTrialMinutesChoice = minutes;
        switch (currentPack)
        {
            case -7: GameObject.Find("PacksManager").GetComponent<TimeTrial7x7>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
            case -10: GameObject.Find("PacksManager").GetComponent<TimeTrial10x10>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
            case -12: GameObject.Find("PacksManager").GetComponent<TimeTrial12x12>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
            case -14: GameObject.Find("PacksManager").GetComponent<TimeTrial14x14>().SelectPuzzleByID(UnityEngine.Random.Range(0, 1000)); break;
        }
        currentTime = (minutes * 60) + 1;
        FindObjectOfType<AudioManager>().Play("drop_004");
    }

    public void PlayATimeTrialAgain()
    {
        timeTrialSolved = 0;
        GameObject.Find("/CanvasStatic/timeTrialPlayMode/currentSolvedText").GetComponent<TextMeshProUGUI>().text = "0";
        CanvasGroupChangerActive(false, completedTimeTrial);
        for (int i = 0; i < mapY; i++)
            for (int j = 0; j < mapX; j++)
                Destroy(GameObject.Find("tile-" + i + "-" + j));
        listB.RemoveRange(0, listB.Count);
        ResetZoom();
        PlayATimeTrial(timeTrialMinutesChoice);
        FindObjectOfType<AudioManager>().Play("drop_004");
    }

    public void CanvasGroupChangerActive(bool x, GameObject y)
    {
        if (x)
        {
            y.gameObject.SetActive(true);
            return;
        }
        y.SetActive(false);
    }

    public void CanvasGroupChangerInteractable(bool x, GameObject y)
    {
        if (x)
        {
            y.GetComponent<CanvasGroup>().alpha = 1;
            y.GetComponent<CanvasGroup>().interactable = true;
            y.GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        y.GetComponent<CanvasGroup>().alpha = 0;
        y.GetComponent<CanvasGroup>().interactable = false;
        y.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void LoadFreePlayPacks()
    {
        float posY = 600f;
        int cont = 0;
        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == true)
                cont++;
        GameObject.Find("/CanvasStatic/freePlay/Packs").GetComponent<RectTransform>().sizeDelta = new Vector2(1080, 303 + 358.75f + 173 + 150 * cont);
        GameObject.Find("/CanvasStatic/freePlay/Packs").transform.localPosition = new Vector3(0, ((303 + 358.75f + 173 + 150 * cont) - 1920) / (-2), 0);
        GameObject.Find("/CanvasStatic/freePlay/transparentWall").GetComponent<RectTransform>().sizeDelta = new Vector2(1080, 303 + 358.75f + 173 + 150 * cont);
        GameObject.Find("/CanvasStatic/freePlay/transparentWall").transform.localPosition = new Vector3(0, ((303 + 358.75f + 173 + 150 * cont) - 1920) / (-2), 0);
        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == true)
            {
                GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i]).transform.localPosition = new Vector3(0, posY, 0);
                posY -= 150;
            }
        posY -= 35;
        GameObject.Find("/CanvasStatic/freePlay/getMoreLevelsButton").transform.localPosition = new Vector3(0, posY, 0);
        posY -= 92.5f;

        //posY -= 92.5f;   //when I add achievements, uncomment these and remore the "- 92.5f" from packs and transparentWall sizeDelta and localPosition
        //GameObject.Find("/CanvasStatic/freePlay/viewAchievementsButton").transform.localPosition = new Vector3(0, posY, 0);
        //DONE ;)

        posY -= 92.5f;
        GameObject.Find("/CanvasStatic/freePlay/viewAchievementsButton").transform.localPosition = new Vector3(0, posY, 0);

        posY -= 138.75f;
        GameObject.Find("/CanvasStatic/freePlay/removeAdsButton").transform.localPosition = new Vector3(0, posY, 0);
        GameObject.Find("/CanvasStatic/freePlay/levelsText").transform.localPosition = new Vector3(0, 805.6f, 0); //previous posY was 840
        GameObject.Find("/CanvasStatic/freePlay/Packs").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/container").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/transparentWall").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/levelsText").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform, true);
        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == true)
                GameObject.Find("/CanvasStatic/freePlay/" + packsNames[i]).transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/getMoreLevelsButton").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/viewAchievementsButton").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/removeAdsButton").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform, true);
        freePlayPacksPos = GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform.localPosition.y;
    }

    public void UnloadFreePlayPacks()
    {
        GameObject.Find("/CanvasStatic/freePlay/container/Packs/levelsText").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/").transform, true);
        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == true)
                GameObject.Find("/CanvasStatic/freePlay/container/Packs/" + packsNames[i]).transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/container/Packs/getMoreLevelsButton").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/container/Packs/viewAchievementsButton").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/container/Packs/removeAdsButton").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform.localPosition = new Vector3(0, freePlayPacksPos, 0);
        GameObject.Find("/CanvasStatic/freePlay/container/Packs/transparentWall").transform.localPosition = new Vector3(0, freePlayPacksPos, 0);
        GameObject.Find("/CanvasStatic/freePlay/container/Packs/transparentWall").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/").transform, true);
        GameObject.Find("/CanvasStatic/freePlay/container/Packs").transform.SetParent(GameObject.Find("/CanvasStatic/freePlay/").transform, true);
    }

    public void LoadStore()
    {
        float posY = 240f;
        int cont = 0;
        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == false)
                cont++;
        GameObject.Find("/CanvasStatic/store/Packs").GetComponent<RectTransform>().sizeDelta = new Vector2(1080, 100 + 633 + 35 + 173 + 30 + 150 * cont);
        GameObject.Find("/CanvasStatic/store/Packs").transform.localPosition = new Vector3(0, ((100 + 633 + 35 + 173 + 30 + 150 * cont) - 1920) / (-2), 0);
        GameObject.Find("/CanvasStatic/store/transparentWall").GetComponent<RectTransform>().sizeDelta = new Vector2(1080, 100 + 633 + 35 + 173 + 30 + 150 * cont);
        GameObject.Find("/CanvasStatic/store/transparentWall").transform.localPosition = new Vector3(0, ((100 + 633 + 35 + 173 + 30 + 150 * cont) - 1920) / (-2), 0);
        //height = (posY * -2) + 1920
        //633 + 35
        //height = 633 + 35 + 150 * cont

        //437
        GameObject.Find("/CanvasStatic/store/20HintsButton").transform.localPosition = new Vector3(-292.6f, posY, 0);
        GameObject.Find("/CanvasStatic/store/5HintsButton").transform.localPosition = new Vector3(292.18f, posY, 0);
        GameObject.Find("/CanvasStatic/store/hintsRemainingText").transform.localPosition = new Vector3(0, posY - 61, 0);
        GameEvents.current.HintsBoughtTriggerEnter();
        posY = -13;

        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == false)
            {
                GameObject.Find("/CanvasStatic/store/" + packsNames[i]).transform.localPosition = new Vector3(0, posY, 0);
                posY -= 150;
            }
        posY -= 35;
        GameObject.Find("/CanvasStatic/store/restorePurchasesButton").transform.localPosition = new Vector3(0, posY, 0);
        GameObject.Find("/CanvasStatic/store/storeText").transform.localPosition = new Vector3(0, 805.6f, 0); //previous posY was 840
        GameObject.Find("/CanvasStatic/store/removeAdsText").transform.localPosition = new Vector3(0, 640, 0);
        GameObject.Find("/CanvasStatic/store/unlockAllPacksButton").transform.localPosition = new Vector3(0, 440, 0);
        GameObject.Find("/CanvasStatic/store/Packs").transform.SetParent(GameObject.Find("/CanvasStatic/store/container").transform, true);
        GameObject.Find("/CanvasStatic/store/transparentWall").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/store/storeText").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/store/removeAdsText").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/store/unlockAllPacksButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);

        GameObject.Find("/CanvasStatic/store/20HintsButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/store/5HintsButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/store/hintsRemainingText").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);

        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == false)
                GameObject.Find("/CanvasStatic/store/" + packsNames[i]).transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);
        GameObject.Find("/CanvasStatic/store/restorePurchasesButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/container/Packs").transform, true);
        storePacksPos = GameObject.Find("/CanvasStatic/store/container/Packs").transform.localPosition.y;

        int cont2 = 0;
        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == true)
                cont2++;
        if (cont2 == 25)
        {
            GameObject.Find("/CanvasStatic/store/container/Packs/allPacksUnlockedText").SetActive(true);
            GameObject.Find("/CanvasStatic/store/container/Packs/allPacksUnlockedText").transform.localPosition = new Vector3(0, 0, 0);
            GameObject.Find("/CanvasStatic/store/container/Packs/removeAdsText").SetActive(false);
            GameObject.Find("/CanvasStatic/store/container/Packs/unlockAllPacksButton").SetActive(false);
        }
        if (packsUnlocked[6] || packsUnlocked[7] || packsUnlocked[8] || packsUnlocked[9] || packsUnlocked[10] || packsUnlocked[11] ||
            packsUnlocked[13] || packsUnlocked[14] || packsUnlocked[20] || packsUnlocked[21] || packsUnlocked[22] || packsUnlocked[23] ||
            packsUnlocked[24] || boughtHints || themeUnlocked0 == 1 || themeUnlocked1 == 1 ||
            themeUnlocked2 == 1 || themeUnlocked3 == 1 || themeUnlocked4 == 1)
            GameEvents.current.AdsRemovedTriggerEnter();

        //FR DE ID IT PL RU ES
        //and fix VI
        /*if (packsUnlocked[6] && packsUnlocked[7] && packsUnlocked[8] && packsUnlocked[9] && packsUnlocked[10] && packsUnlocked[11] &&
            packsUnlocked[13] && packsUnlocked[14] && packsUnlocked[20] && packsUnlocked[21] && packsUnlocked[22] && packsUnlocked[23] &&
            packsUnlocked[24])
        {
            if (lang == 5 || lang == 6 || lang == 8 || lang == 9 || lang == 14 || lang == 15)
            {
                allPacksUnlockedText.transform.localPosition = new Vector3(0f, 115f, 0f);
                allPacksUnlockedText.GetComponent<RectTransform>().sizeDelta = new Vector2(1080f, 141f); //new Vector2(width, height);

                storeText.transform.localPosition = new Vector3(0f, 415f, 0f);
                storeText.GetComponent<RectTransform>().sizeDelta = new Vector2(1080f, 141f);

                hintsButton20.transform.localPosition = new Vector3(-194.4f, -115f, 0f);
                hintsButton20.GetComponent<RectTransform>().sizeDelta = new Vector2(656f, 60f);

                hintsButton5.transform.localPosition = new Vector3(-194.4f, -215f, 0f);
                hintsButton5.GetComponent<RectTransform>().sizeDelta = new Vector2(656f, 60f);

                hintsRemainingText.transform.localPosition = new Vector3(0f, -315f, 0f);
                hintsRemainingText.GetComponent<RectTransform>().sizeDelta = new Vector2(1044.6f, 45f);

                hintsButton5Child.alignment = TextAlignmentOptions.Left;
            }
            else
            {
                allPacksUnlockedText.transform.localPosition = new Vector3(0f, 403.8f, 0f);
                allPacksUnlockedText.GetComponent<RectTransform>().sizeDelta = new Vector2(1080f, 141f);

                storeText.transform.localPosition = new Vector3(0f, 840f, 0f);
                storeText.GetComponent<RectTransform>().sizeDelta = new Vector2(1080f, 141f);

                hintsButton20.transform.localPosition = new Vector3(-320f, 75.29f, 0f);
                hintsButton20.GetComponent<RectTransform>().sizeDelta = new Vector2(405.21f, 60f);

                hintsButton5.transform.localPosition = new Vector3(264f, 75.29f, 0f);
                hintsButton5.GetComponent<RectTransform>().sizeDelta = new Vector2(371.58f, 60f);

                hintsRemainingText.transform.localPosition = new Vector3(0f, 8.1f, 0f);
                hintsRemainingText.GetComponent<RectTransform>().sizeDelta = new Vector2(1044.82f, 57.43f);

                hintsButton5Child.alignment = TextAlignmentOptions.Right;
            }
        }*/
    }

    public void UnloadStore()
    {
        GameObject.Find("/CanvasStatic/store/container/Packs/storeText").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);

        GameObject.Find("/CanvasStatic/store/container/Packs/20HintsButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        GameObject.Find("/CanvasStatic/store/container/Packs/5HintsButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        GameObject.Find("/CanvasStatic/store/container/Packs/hintsRemainingText").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);

        for (int i = 0; i < 25; i++)
            if (packsUnlocked[i] == false)
                GameObject.Find("/CanvasStatic/store/container/Packs/" + packsNames[i]).transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        GameObject.Find("/CanvasStatic/store/container/Packs/removeAdsText").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        GameObject.Find("/CanvasStatic/store/container/Packs/unlockAllPacksButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        GameObject.Find("/CanvasStatic/store/container/Packs/restorePurchasesButton").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        GameObject.Find("/CanvasStatic/store/container/Packs").transform.localPosition = new Vector3(0, storePacksPos, 0);
        GameObject.Find("/CanvasStatic/store/container/Packs/transparentWall").transform.localPosition = new Vector3(0, storePacksPos, 0);
        GameObject.Find("/CanvasStatic/store/container/Packs/transparentWall").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
        GameObject.Find("/CanvasStatic/store/container/Packs").transform.SetParent(GameObject.Find("/CanvasStatic/store/").transform, true);
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();
        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());
        Destroy(ss);
        new NativeShare().AddFile(filePath)
            .SetSubject("Light Up: Logic Puzzle").SetText(shareMessage)
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }

    private int CalculateLevelsCompleted()
    {
        int score = 0;
        for (int i = 0; i < 150; i++)
        {
            if (ClassicPackTimes[i] > 0) score++;
            if (Mania7x7Times[i] > 0) score++;
            if (Mania10x10Times[i] > 0) score++;
            if (Mania12x12Times[i] > 0) score++;
            if (Mania14x14Times[i] > 0) score++;
            if (Mania25x25Times[i] > 0) score++;
            if (Mania30x30Times[i] > 0) score++;
            if (Mania35x35Times[i] > 0) score++;
            if (Mania40x40Times[i] > 0) score++;
            if (Mania45x45Times[i] > 0) score++;
            if (Mania50x50Times[i] > 0) score++;
            if (ExtremeJumboPackTimes[i] > 0) score++;
            if (IntervalPackTimes[i] > 0) score++;
            if (IntervalPack2Times[i] > 0) score++;
            if (ExtremeIntervalTimes[i] > 0) score++;
            if (TowerPackTimes[i] > 0) score++;
            if (RectanglePackTimes[i] > 0) score++;
            if (ExtremePackTimes[i] > 0) score++;
            if (JumboPackTimes[i] > 0) score++;
            if (JumboRectangleTimes[i] > 0) score++;
            if (JumboRectangle2Times[i] > 0) score++;
            if (MirrorPack4wayTimes[i] > 0) score++;
            if (RotationalPack4wayTimes[i] > 0) score++;
            if (ExtremeNoSymmetryPackTimes[i] > 0) score++;
        }
        for (int i = 0; i < 120; i++)
            if (KidsPackTimes[i] > 0) score++;
        return score;
    }

    public void ClickShareButton()
    {
        int score = 0;
        for (int i = 0; i < 150; i++)
        {
            if (ClassicPackTimes[i] > 0) score++;
            if (Mania7x7Times[i] > 0) score++;
            if (Mania10x10Times[i] > 0) score++;
            if (Mania12x12Times[i] > 0) score++;
            if (Mania14x14Times[i] > 0) score++;
            if (Mania25x25Times[i] > 0) score++;
            if (Mania30x30Times[i] > 0) score++;
            if (Mania35x35Times[i] > 0) score++;
            if (Mania40x40Times[i] > 0) score++;
            if (Mania45x45Times[i] > 0) score++;
            if (Mania50x50Times[i] > 0) score++;
            if (ExtremeJumboPackTimes[i] > 0) score++;
            if (IntervalPackTimes[i] > 0) score++;
            if (IntervalPack2Times[i] > 0) score++;
            if (ExtremeIntervalTimes[i] > 0) score++;
            if (TowerPackTimes[i] > 0) score++;
            if (RectanglePackTimes[i] > 0) score++;
            if (ExtremePackTimes[i] > 0) score++;
            if (JumboPackTimes[i] > 0) score++;
            if (JumboRectangleTimes[i] > 0) score++;
            if (JumboRectangle2Times[i] > 0) score++;
            if (MirrorPack4wayTimes[i] > 0) score++;
            if (RotationalPack4wayTimes[i] > 0) score++;
            if (ExtremeNoSymmetryPackTimes[i] > 0) score++;
        }
        for (int i = 0; i < 120; i++)
            if (KidsPackTimes[i] > 0) score++;
        Debug.Log(score);
        shareMessage = "I can't believe I beat " + score + " levels in Light Up: Logic Puzzle! Can you? https://play.google.com/store/apps/details?id=com.IMIan.LightUpLogicPuzzle";
        StartCoroutine(TakeScreenshotAndShare());
        if (completedLevelPlayMode.activeSelf == true)
            completedLevelPlayMode.SetActive(false);
    }

    public void PlayModeLevelSelector(string op)
    {
        for (int i = 0; i < mapY; i++)
            for (int j = 0; j < mapX; j++)
                Destroy(GameObject.Find("tile-" + i + "-" + j));
        listB.RemoveRange(0, listB.Count);
        switch (op)
        {
            case "restart":
                CancelInvoke("CheckRewardedAd");
                playNewLevelInPack = false;
                break;
            case "previous":
                CancelInvoke("CheckRewardedAd");
                playNewLevelInPack = false;
                currentLevel--;
                break;
            case "next":
                CancelInvoke("CheckRewardedAd");
                if (timeForInterstitialAd >= 120 && !rewardedAdEnded)
                {
                    AdManager.PlayInterstitialAd();
                    timeForInterstitialAd = 0;
                    timeSinceRewardedAd = 0;
                }
                playNewLevelInPack = false;
                currentLevel++;
                break;
        }
        switch (currentPack)
        {
            case -7: GameObject.Find("PacksManager").GetComponent<TimeTrial7x7>().SelectPuzzleByID(currentLevel); break;
            case -10: GameObject.Find("PacksManager").GetComponent<TimeTrial10x10>().SelectPuzzleByID(currentLevel); break;
            case -12: GameObject.Find("PacksManager").GetComponent<TimeTrial12x12>().SelectPuzzleByID(currentLevel); break;
            case -14: GameObject.Find("PacksManager").GetComponent<TimeTrial14x14>().SelectPuzzleByID(currentLevel); break;
            case 0: GameObject.Find("PacksManager").GetComponent<ClassicPack>().SelectPuzzleByID(currentLevel); break;
            case 1: GameObject.Find("PacksManager").GetComponent<Mania7x7>().SelectPuzzleByID(currentLevel); break;
            case 2: GameObject.Find("PacksManager").GetComponent<Mania10x10>().SelectPuzzleByID(currentLevel); break;
            case 3: GameObject.Find("PacksManager").GetComponent<Mania12x12>().SelectPuzzleByID(currentLevel); break;
            case 4: GameObject.Find("PacksManager").GetComponent<Mania14x14>().SelectPuzzleByID(currentLevel); break;
            case 5: GameObject.Find("PacksManager").GetComponent<Mania25x25>().SelectPuzzleByID(currentLevel); break;
            case 6: GameObject.Find("PacksManager").GetComponent<Mania30x30>().SelectPuzzleByID(currentLevel); break;
            case 7: GameObject.Find("PacksManager").GetComponent<Mania35x35>().SelectPuzzleByID(currentLevel); break;
            case 8: GameObject.Find("PacksManager").GetComponent<Mania40x40>().SelectPuzzleByID(currentLevel); break;
            case 9: GameObject.Find("PacksManager").GetComponent<Mania45x45>().SelectPuzzleByID(currentLevel); break;
            case 10: GameObject.Find("PacksManager").GetComponent<Mania50x50>().SelectPuzzleByID(currentLevel); break;
            case 11: GameObject.Find("PacksManager").GetComponent<ExtremeJumboPack>().SelectPuzzleByID(currentLevel); break;
            case 12: GameObject.Find("PacksManager").GetComponent<IntervalPack>().SelectPuzzleByID(currentLevel); break;
            case 13: GameObject.Find("PacksManager").GetComponent<IntervalPack2>().SelectPuzzleByID(currentLevel); break;
            case 14: GameObject.Find("PacksManager").GetComponent<ExtremeInterval>().SelectPuzzleByID(currentLevel); break;
            case 15: GameObject.Find("PacksManager").GetComponent<TowerPack>().SelectPuzzleByID(currentLevel); break;
            case 16: GameObject.Find("PacksManager").GetComponent<RectanglePack>().SelectPuzzleByID(currentLevel); break;
            case 17: GameObject.Find("PacksManager").GetComponent<ExtremePack>().SelectPuzzleByID(currentLevel); break;
            case 18: GameObject.Find("PacksManager").GetComponent<JumboPack>().SelectPuzzleByID(currentLevel); break;
            case 19: GameObject.Find("PacksManager").GetComponent<JumboRectangle>().SelectPuzzleByID(currentLevel); break;
            case 20: GameObject.Find("PacksManager").GetComponent<JumboRectangle2>().SelectPuzzleByID(currentLevel); break;
            case 21: GameObject.Find("PacksManager").GetComponent<MirrorPack4way>().SelectPuzzleByID(currentLevel); break;
            case 22: GameObject.Find("PacksManager").GetComponent<RotationalPack4way>().SelectPuzzleByID(currentLevel); break;
            case 23: GameObject.Find("PacksManager").GetComponent<ExtremeNoSymmetryPack>().SelectPuzzleByID(currentLevel); break;
            case 24: GameObject.Find("PacksManager").GetComponent<KidsPack>().SelectPuzzleByID(currentLevel); break;
        }
        if (op == "next")
            if (completedLevelPlayMode.activeSelf == true)
                completedLevelPlayMode.SetActive(false);
    }

    public void ResetZoom()
    {
        camera1.transform.position = new Vector3(0, 0, 0);
        camera1.orthographicSize = 5;
    }

    public void HintClick()
    {
        if (hints > 0)
        {
            if (!HintsClicked)
            {
                string imageName;
                string imageNameNumbers;
                int contNumbers = 0;
                errors = 0;
                for (int i = 0; i < mapY; i++)
                {
                    for (int j = 0; j < mapX; j++)
                    {
                        imageName = GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite.name;
                        
                        if (imageName.StartsWith("E-"))
                        {
                            GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgEError;
                            errors++;
                        }
                        if (imageName.StartsWith("XE-"))
                        {
                            GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgXEError;
                            errors++;
                        }
                        if (imageName.StartsWith("B2-"))
                        {
                            GameObject.Find("tile-" + i + "-" + j).GetComponent<Image>().sprite = imgB2Error;
                            errors++;
                        }
                        for (int side = 0; side < 5; side++)
                        {
                            List<Tuple<int, int>> numbersErrorList;
                            numbersErrorList = new List<Tuple<int, int>>();
                            int contAvailable = 0;
                            if (imageName.StartsWith(side + "-"))
                            {
                                if (i - 1 >= 0)
                                {
                                    contAvailable++;
                                    imageNameNumbers = GameObject.Find("tile-" + (i - 1) + "-" + j).GetComponent<Image>().sprite.name;
                                    if (imageNameNumbers.StartsWith("B-") || (imageNameNumbers == "BError") || imageNameNumbers.StartsWith("B2-") || (imageNameNumbers == "B2Error"))
                                        contNumbers++;
                                    numbersErrorList.Add(new Tuple<int, int>(i - 1, j));
                                }
                                if (j + 1 < mapX)
                                {
                                    contAvailable++;
                                    imageNameNumbers = GameObject.Find("tile-" + i + "-" + (j + 1)).GetComponent<Image>().sprite.name;
                                    if (imageNameNumbers.StartsWith("B-") || (imageNameNumbers == "BError") || imageNameNumbers.StartsWith("B2-") || (imageNameNumbers == "B2Error"))
                                        contNumbers++;
                                    numbersErrorList.Add(new Tuple<int, int>(i, j + 1));
                                }
                                if (i + 1 < mapY)
                                {
                                    contAvailable++;
                                    imageNameNumbers = GameObject.Find("tile-" + (i + 1) + "-" + j).GetComponent<Image>().sprite.name;
                                    if (imageNameNumbers.StartsWith("B-") || (imageNameNumbers == "BError") || imageNameNumbers.StartsWith("B2-") || (imageNameNumbers == "B2Error"))
                                        contNumbers++;
                                    numbersErrorList.Add(new Tuple<int, int>(i + 1, j));
                                }
                                if (j - 1 >= 0)
                                {
                                    contAvailable++;
                                    imageNameNumbers = GameObject.Find("tile-" + i + "-" + (j - 1)).GetComponent<Image>().sprite.name;
                                    if (imageNameNumbers.StartsWith("B-") || (imageNameNumbers == "BError") || imageNameNumbers.StartsWith("B2-") || (imageNameNumbers == "B2Error"))
                                        contNumbers++;
                                    numbersErrorList.Add(new Tuple<int, int>(i, j - 1));
                                }
                                if (contNumbers != side)
                                {
                                    for (int k = 0; k < contAvailable; k++)
                                    {
                                        imageNameNumbers = GameObject.Find("tile-" + numbersErrorList[k].Item1 + "-" + numbersErrorList[k].Item2).GetComponent<Image>().sprite.name;
                                        
                                        if (imageNameNumbers.StartsWith("E-"))
                                        {
                                            GameObject.Find("tile-" + numbersErrorList[k].Item1 + "-" + numbersErrorList[k].Item2).GetComponent<Image>().sprite = imgEError;
                                            errors++;
                                        }
                                        if (imageNameNumbers.StartsWith("XE-"))
                                        {
                                            GameObject.Find("tile-" + numbersErrorList[k].Item1 + "-" + numbersErrorList[k].Item2).GetComponent<Image>().sprite = imgXEError;
                                            errors++;
                                        }
                                        if (imageNameNumbers.StartsWith("B-"))
                                        {
                                            GameObject.Find("tile-" + numbersErrorList[k].Item1 + "-" + numbersErrorList[k].Item2).GetComponent<Image>().sprite = imgBError;
                                            errors++;
                                        }
                                        if (imageNameNumbers.StartsWith("B2-"))
                                        {
                                            GameObject.Find("tile-" + numbersErrorList[k].Item1 + "-" + numbersErrorList[k].Item2).GetComponent<Image>().sprite = imgB2Error;
                                            errors++;
                                        }
                                        if (imageNameNumbers.StartsWith("L-"))
                                        {
                                            GameObject.Find("tile-" + numbersErrorList[k].Item1 + "-" + numbersErrorList[k].Item2).GetComponent<Image>().sprite = imgLError;
                                            errors++;
                                        }
                                        if (imageNameNumbers.StartsWith("XL-"))
                                        {
                                            GameObject.Find("tile-" + numbersErrorList[k].Item1 + "-" + numbersErrorList[k].Item2).GetComponent<Image>().sprite = imgXLError;
                                            errors++;
                                        }
                                    }
                                }
                            }
                            contNumbers = 0;
                            numbersErrorList.RemoveRange(0, numbersErrorList.Count);
                        }
                    }
                }
                CanvasGroupChangerActive(true, hintsPopUp);
                if (errors != 0)
                    FindObjectOfType<AudioManager>().Play("question_001");
                else
                    FindObjectOfType<AudioManager>().Play("confirmation_002");
                GameObject.Find("CanvasStatic/hintsPopUp/puzzlesSolvedText").GetComponent<TextMeshProUGUI>().text = "There are " + errors + " mistakes in the puzzle solution";

                GameEvents.current.HintsFoundTriggerEnter();

                HintsClicked = true;
            }
            else
            {
                CanvasGroupChangerActive(true, hintsPopUp);
                if (errors != 0)
                    FindObjectOfType<AudioManager>().Play("question_001");
                else
                    FindObjectOfType<AudioManager>().Play("confirmation_002");
            }
            hints--;
            SavePlayer();
            if (hints != 0)
                GameObject.Find("/CanvasStatic/playMode/hintsText").GetComponent<TextMeshProUGUI>().text = hints + " x";
            else
                GameObject.Find("/CanvasStatic/playMode/hintsText").GetComponent<TextMeshProUGUI>().text = "+";
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("drop_004");
            CanvasGroupChangerActive(true, getHintsPopUp);
        }
    }

    public void SaveGame(int saveNum, string gameID)
    {
        //1:2:7x7:eLcBa1LaBaBa1LBLLLLLDD1a0aBD3b0a0LCdXYL
        PlayerPrefs.SetString("save" + saveNum, gameID);
    }

    public void GenerateSaveID()
    {
        string gameID = currentPack + ":" + currentLevel + ":" + mapX + "x" + mapY + ":";
        string squareImg = GameObject.Find("/CanvasDynamic/tile-" + 0 + "-" + 0).GetComponent<Image>().sprite.name;

        bool foundObject = false;
        int maxPos = mapX * mapY;
        int pos = 0, numEmpty = 0, x = 0, y = 0;
        while (pos < maxPos)
        {
            while ((foundObject == false) && (pos < maxPos))
            {
                squareImg = GameObject.Find("/CanvasDynamic/tile-" + x + "-" + y).GetComponent<Image>().sprite.name; //0-256
                if (squareImg != "0-256" && squareImg != "1-256" && squareImg != "2-256" &&
                    squareImg != "3-256" && squareImg != "4-256" && squareImg != "W-256" &&
                    squareImg != "B-256" && squareImg != "B2-256" && squareImg != "L-256" &&
                    squareImg != "XE-256" && squareImg != "XL-256")
                    numEmpty++;
                else
                    foundObject = true;
            }

            foundObject = false;
            //gameID += (numEmpty + 96);
            //a-z = 1-26
            //si hay mas de 26 espacios vacios, error
            //26 = z, 27 = za, 81 = zzzc
            if (numEmpty > 26)
            {
                int aux = numEmpty / 26; // 81 / 26 = 3
                for (int k = 0; k < aux; k++)
                    gameID += "z"; //zzz
                                   //26 * aux = 78
                                   //numEmpty = 81
                gameID += ((char)(numEmpty - (26 * aux))).ToString();
            }
            else
                gameID += ((char)(numEmpty + 96)).ToString();
            for (int j = 0; j < numEmpty; j++)
            {
                pos++;
                y++;
                if (y == mapX)
                {
                    y = 0;
                    x++;
                }
            }
            numEmpty = 0;

            if (pos < maxPos)
            {
                if (squareImg == "0-256") gameID += "0";
                else if (squareImg == "1-256") gameID += "1";
                else if (squareImg == "2-256") gameID += "2";
                else if (squareImg == "3-256") gameID += "3";
                else if (squareImg == "4-256") gameID += "4";
                else if (squareImg == "W-256") gameID += "B";
                else if (squareImg == "B-256") gameID += "C";
                else if (squareImg == "B2-256") gameID += "D";
                else if (squareImg == "L-256") gameID += "L";
                else if (squareImg == "XE-256") gameID += "X";
                else if (squareImg == "XL-256") gameID += "Y";
                pos++;
                y++;
                if (y == mapX)
                {
                    y = 0;
                    x++;
                }
            }
        }
        Debug.Log(gameID);
    }

    public void LoadMenu(int id)
    {
        LoadSavedID(PlayerPrefs.GetString("save" + id));
    }

    //"1:2:7x7:eLcBa1LaBaBa1LBLLLLLDD1a0aBD3b0a0LCdXYL"
    //pack:level:widthxhight:id
    public void LoadSavedID(string gameID)
    {
        /*p1: l2: 7x7: eLcBa1LaBaBa1LBLLLLLDD1a0aBD3b0a0LCdXYL
         * 1 - ClassicPackTimes
         * 25 - kids
         */

        switch (themeSelected)
        {
            case 0: img0 = img0Classic; img1 = img1Classic; img2 = img2Classic; img3 = img3Classic; img4 = img4Classic; imgB = imgBClassic; imgB2 = imgB2Classic; imgE = imgEClassic; imgL = imgLClassic; imgW = imgWClassic; imgXE = imgXEClassic; imgXL = imgXLClassic; break;
            case 1: img0 = img0Paper; img1 = img1Paper; img2 = img2Paper; img3 = img3Paper; img4 = img4Paper; imgB = imgBPaper; imgB2 = imgB2Paper; imgE = imgEPaper; imgL = imgLPaper; imgW = imgWPaper; imgXE = imgXEPaper; imgXL = imgXLPaper; break;
            case 2: img0 = img0Theme4; img1 = img1Theme4; img2 = img2Theme4; img3 = img3Theme4; img4 = img4Theme4; imgB = imgBTheme4; imgB2 = imgB2Theme4; imgE = imgETheme4; imgL = imgLTheme4; imgW = imgWTheme4; imgXE = imgXETheme4; imgXL = imgXLTheme4; break;
            case 3: img0 = img0Theme5; img1 = img1Theme5; img2 = img2Theme5; img3 = img3Theme5; img4 = img4Theme5; imgB = imgBTheme5; imgB2 = imgB2Theme5; imgE = imgETheme5; imgL = imgLTheme5; imgW = imgWTheme5; imgXE = imgXETheme5; imgXL = imgXLTheme5; break;
            case 4: img0 = img0Dark; img1 = img1Dark; img2 = img2Dark; img3 = img3Dark; img4 = img4Dark; imgB = imgBDark; imgB2 = imgB2Dark; imgE = imgEDark; imgL = imgLDark; imgW = imgWDark; imgXE = imgXEDark; imgXL = imgXLDark; break;
            case 5: img0 = img0Water; img1 = img1Water; img2 = img2Water; img3 = img3Water; img4 = img4Water; imgB = imgBWater; imgB2 = imgB2Water; imgE = imgEWater; imgL = imgLWater; imgW = imgWWater; imgXE = imgXEWater; imgXL = imgXLWater; break;
            case 6: img0 = img0Akari; img1 = img1Akari; img2 = img2Akari; img3 = img3Akari; img4 = img4Akari; imgB = imgBAkari; imgB2 = imgB2Akari; imgE = imgEAkari; imgL = imgLAkari; imgW = imgWAkari; imgXE = imgXEAkari; imgXL = imgXLAkari; break;
            case 7: img0 = img0LightOut; img1 = img1LightOut; img2 = img2LightOut; img3 = img3LightOut; img4 = img4LightOut; imgB = imgBLightOut; imgB2 = imgB2LightOut; imgE = imgELightOut; imgL = imgLLightOut; imgW = imgWLightOut; imgXE = imgXELightOut; imgXL = imgXLLightOut; break;
            case 8: img0 = img0Minesweeper; img1 = img1Minesweeper; img2 = img2Minesweeper; img3 = img3Minesweeper; img4 = img4Minesweeper; imgB = imgBMinesweeper; imgB2 = imgB2Minesweeper; imgE = imgEMinesweeper; imgL = imgLMinesweeper; imgW = imgWMinesweeper; imgXE = imgXEMinesweeper; imgXL = imgXLMinesweeper; break;
            case 9: img0 = img0Medieval; img1 = img1Medieval; img2 = img2Medieval; img3 = img3Medieval; img4 = img4Medieval; imgB = imgBMedieval; imgB2 = imgB2Medieval; imgE = imgEMedieval; imgL = imgLMedieval; imgW = imgWMedieval; imgXE = imgXEMedieval; imgXL = imgXLMedieval; break;
        }

        //tilesToWin = 0;
        //litTiles = 0;

        //"1:2:7x7:eLcBa1LaBaBa1LBLLLLLDD1a0aBD3b0a0LCdXYL"
        string[] splitPuzzle = gameID.Split(':');
        //splitPuzzle[0] = "1"
        //splitPuzzle[1] = "2"
        //splitPuzzle[2] = "7x7"
        //splitPuzzle[3] = "eLcBa1LaBaBa1LBLLLLLDD1a0aBD3b0a0LCdXYL"
        string[] aux = splitPuzzle[2].Split('x');
        //aux[0] = "7"
        //aux[1] = "7"
        mapX = short.Parse(aux[0]);
        mapY = short.Parse(aux[1]);
        char[] map = splitPuzzle[3].ToCharArray();
        int pos = 0, i = 0, numEmpty = 0, x = 0, y = 0;
        GameObject newTile;
        var posX = -375f;
        var posY = 375f;
        bool foundObject = false;

        int mapLength = map.Length;
        int maxPos = mapX * mapY;
        char letra = '\0';

        //while ((i < mapLength) && (pos < maxPos)) - original
        while (pos < maxPos)
        {
            while ((foundObject == false) && (i < mapLength))
            {
                letra = map[i];
                i++;
                if (letra != '0' && letra != '1' && letra != '2' &&
                    letra != '3' && letra != '4' && letra != 'B' &&
                    letra != 'C' && letra != 'D' && letra != 'L' &&
                    letra != 'X' && letra != 'Y')
                    numEmpty += (letra - 96);
                else
                    foundObject = true;
            }
            foundObject = false;
            for (int j = 0; j < numEmpty; j++)
            {
                newTile = Instantiate(whatToSpawnPrefab, new Vector3(posX, posY, 0f), transform.rotation);
                newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                newTile.name = "tile-" + x + "-" + y;
                newTile.gameObject.transform.GetComponent<Image>().sprite = imgE;
                tilesToWin++;

                pos++;
                posX += 125;
                y++;
                if (y == mapX)
                {
                    posX = -375;
                    posY -= 125;
                    y = 0;
                    x++;
                }
            }
            numEmpty = 0;
            //if ((i < mapLength) && (pos < maxPos)) - original
            if (pos < maxPos)
            {
                newTile = Instantiate(whatToSpawnPrefab, new Vector3(posX, posY, 0f), transform.rotation);
                newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                newTile.name = "tile-" + x + "-" + y;
                switch (letra)
                {
                    //img0, img1, img2, img3, img4, imgB, imgB2, imgE, imgL, imgW, imgXE, imgXL
                    case '0': newTile.gameObject.transform.GetComponent<Image>().sprite = img0; break;
                    case '1': newTile.gameObject.transform.GetComponent<Image>().sprite = img1; break;
                    case '2': newTile.gameObject.transform.GetComponent<Image>().sprite = img2; break;
                    case '3': newTile.gameObject.transform.GetComponent<Image>().sprite = img3; break;
                    case '4': newTile.gameObject.transform.GetComponent<Image>().sprite = img4; break;
                    case 'B': newTile.gameObject.transform.GetComponent<Image>().sprite = imgW; break;
                    case 'C': newTile.gameObject.transform.GetComponent<Image>().sprite = imgB; break;
                    case 'D': newTile.gameObject.transform.GetComponent<Image>().sprite = imgB2; break;
                    case 'L': newTile.gameObject.transform.GetComponent<Image>().sprite = imgL; break;
                    case 'X': newTile.gameObject.transform.GetComponent<Image>().sprite = imgXE; break;
                    case 'Y': newTile.gameObject.transform.GetComponent<Image>().sprite = imgXL; break;
                }
                pos++;
                posX += 125;
                y++;
                if (y == mapX)
                {
                    posX = -375;
                    posY -= 125;
                    y = 0;
                    x++;
                }
            }
        }
    }

    public void LoadGameID(string gameID)
    {
        switch (themeSelected)
        {
            case 0: img0 = img0Classic; img1 = img1Classic; img2 = img2Classic; img3 = img3Classic; img4 = img4Classic; imgB = imgBClassic; imgB2 = imgB2Classic; imgE = imgEClassic; imgL = imgLClassic; imgW = imgWClassic; imgXE = imgXEClassic; imgXL = imgXLClassic; break;
            case 1: img0 = img0Paper; img1 = img1Paper; img2 = img2Paper; img3 = img3Paper; img4 = img4Paper; imgB = imgBPaper; imgB2 = imgB2Paper; imgE = imgEPaper; imgL = imgLPaper; imgW = imgWPaper; imgXE = imgXEPaper; imgXL = imgXLPaper; break;
            case 2: img0 = img0Theme4; img1 = img1Theme4; img2 = img2Theme4; img3 = img3Theme4; img4 = img4Theme4; imgB = imgBTheme4; imgB2 = imgB2Theme4; imgE = imgETheme4; imgL = imgLTheme4; imgW = imgWTheme4; imgXE = imgXETheme4; imgXL = imgXLTheme4; break;
            case 3: img0 = img0Theme5; img1 = img1Theme5; img2 = img2Theme5; img3 = img3Theme5; img4 = img4Theme5; imgB = imgBTheme5; imgB2 = imgB2Theme5; imgE = imgETheme5; imgL = imgLTheme5; imgW = imgWTheme5; imgXE = imgXETheme5; imgXL = imgXLTheme5; break;
            case 4: img0 = img0Dark; img1 = img1Dark; img2 = img2Dark; img3 = img3Dark; img4 = img4Dark; imgB = imgBDark; imgB2 = imgB2Dark; imgE = imgEDark; imgL = imgLDark; imgW = imgWDark; imgXE = imgXEDark; imgXL = imgXLDark; break;
            case 5: img0 = img0Water; img1 = img1Water; img2 = img2Water; img3 = img3Water; img4 = img4Water; imgB = imgBWater; imgB2 = imgB2Water; imgE = imgEWater; imgL = imgLWater; imgW = imgWWater; imgXE = imgXEWater; imgXL = imgXLWater; break;
            case 6: img0 = img0Akari; img1 = img1Akari; img2 = img2Akari; img3 = img3Akari; img4 = img4Akari; imgB = imgBAkari; imgB2 = imgB2Akari; imgE = imgEAkari; imgL = imgLAkari; imgW = imgWAkari; imgXE = imgXEAkari; imgXL = imgXLAkari; break;
            case 7: img0 = img0LightOut; img1 = img1LightOut; img2 = img2LightOut; img3 = img3LightOut; img4 = img4LightOut; imgB = imgBLightOut; imgB2 = imgB2LightOut; imgE = imgELightOut; imgL = imgLLightOut; imgW = imgWLightOut; imgXE = imgXELightOut; imgXL = imgXLLightOut; break;
            case 8: img0 = img0Minesweeper; img1 = img1Minesweeper; img2 = img2Minesweeper; img3 = img3Minesweeper; img4 = img4Minesweeper; imgB = imgBMinesweeper; imgB2 = imgB2Minesweeper; imgE = imgEMinesweeper; imgL = imgLMinesweeper; imgW = imgWMinesweeper; imgXE = imgXEMinesweeper; imgXL = imgXLMinesweeper; break;
            case 9: img0 = img0Medieval; img1 = img1Medieval; img2 = img2Medieval; img3 = img3Medieval; img4 = img4Medieval; imgB = imgBMedieval; imgB2 = imgB2Medieval; imgE = imgEMedieval; imgL = imgLMedieval; imgW = imgWMedieval; imgXE = imgXEMedieval; imgXL = imgXLMedieval; break;
        }

        tilesToWin = 0;
        litTiles = 0;

        //"12x12:c1b1dB0h2a2lBd3cBaB1a1aBaB1aBB1xBBBa02a3aBaBBa2cBdBlBaBh1BdBb1c"
        string[] splitPuzzle = gameID.Split(':');
        //splitPuzzle[0] = "12x12"
        //splitPuzzle[1] = "c1b1dB0h2a2lBd3cBaB1a1aBaB1aBB1xBBBa02a3aBaBBa2cBdBlBaBh1BdBb1c"
        string[] aux = splitPuzzle[0].Split('x');
        //aux[0] = "12"
        //aux[1] = "12"
        mapX = short.Parse(aux[0]);
        mapY = short.Parse(aux[1]);
        char[] map = splitPuzzle[1].ToCharArray();
        int pos = 0, i = 0, numEmpty = 0, x = 0, y = 0;
        GameObject newTile;
        var posX = -375f;
        var posY = 375f;
        bool foundObject = false;

        int mapLength = map.Length;
        int maxPos = mapX * mapY;
        char letra = '\0';
            
        //while ((i < mapLength) && (pos < maxPos)) - original
        while (pos < maxPos)
        {
            while ((foundObject == false) && (i < mapLength))
            {
                letra = map[i];
                i++;
                if (letra != '0' && letra != '1' && letra != '2' &&
                    letra != '3' && letra != '4' && letra != 'B')
                    numEmpty += (letra - 96);
                else
                    foundObject = true;
            }
            foundObject = false;
            for (int j = 0; j < numEmpty; j++)
            {
                newTile = Instantiate(whatToSpawnPrefab, new Vector3(posX, posY, 0f), transform.rotation);
                newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                newTile.name = "tile-" + x + "-" + y;
                newTile.gameObject.transform.GetComponent<Image>().sprite = imgE;
                tilesToWin++;

                pos++;
                posX += 125;
                y++;
                if (y == mapX)
                {
                    posX = -375;
                    posY -= 125;
                    y = 0;
                    x++;
                }
            }
            numEmpty = 0;
            //if ((i < mapLength) && (pos < maxPos)) - original
            if (pos < maxPos)
            {
                newTile = Instantiate(whatToSpawnPrefab, new Vector3(posX, posY, 0f), transform.rotation);
                newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                newTile.name = "tile-" + x + "-" + y;
                switch (letra)
                {
                    case '0': newTile.gameObject.transform.GetComponent<Image>().sprite = img0; break;
                    case '1': newTile.gameObject.transform.GetComponent<Image>().sprite = img1; break;
                    case '2': newTile.gameObject.transform.GetComponent<Image>().sprite = img2; break;
                    case '3': newTile.gameObject.transform.GetComponent<Image>().sprite = img3; break;
                    case '4': newTile.gameObject.transform.GetComponent<Image>().sprite = img4; break;
                    case 'B': newTile.gameObject.transform.GetComponent<Image>().sprite = imgW; break;
                }
                pos++;
                posX += 125;
                y++;
                if (y == mapX)
                {
                    posX = -375;
                    posY -= 125;
                    y = 0;
                    x++;
                }
            }
        }
        if (lastPackSelected == timeTrial || lastPackSelected == timeTrialPlayMode)
            ChangeTabs(timeTrialPlayMode);
        else
        {
            ChangeTabs(playMode);
            GameObject.Find("/CanvasStatic/playMode/litProgress/litProgressText").GetComponent<TextMeshProUGUI>().text = "0%";
            if ((mapX >= 32) && (mapY >= 32)) //1024 buttons
            {
                GameObject.Find("/CanvasStatic/playMode/doneButton").SetActive(true);
                GameObject.Find("/CanvasStatic/playMode/restartLevelButton").transform.localPosition = new Vector3(-475, -836.46f, 0);
            }
            else
            {
                GameObject.Find("/CanvasStatic/playMode/doneButton").SetActive(false);
                GameObject.Find("/CanvasStatic/playMode/restartLevelButton").transform.localPosition = new Vector3(0, -836.46f, 0);
            }
        }

        //Automatic camera position and size
        float cameraSize;
        camera1.transform.position = new Vector3((mapX - 7) * 0.325f, (mapY - 7) * -0.325f, 0);
        if (mapX > mapY)
            cameraSize = mapX;
        else
        {
            if (mapX < mapY)
                cameraSize = mapY;
            else
                cameraSize = mapX;
        }
        if (mapX < mapY)
            camera1.orthographicSize = (float)((float)mapY / 2) + 0.5f;
        else
            camera1.orthographicSize = ((cameraSize - 7) * 0.55f) + 5;
    }

    public void IncrementAchi(string id, int steps)
    {
        PlayGamesScriptManager.IncrementAchievement(id, steps);
    }

    public void UnlockAchi(string id)
    {
        PlayGamesScriptManager.UnlockAchievement(id);
    }

    public void ShowAchievements()
    {
        FindObjectOfType<AudioManager>().Play("drop_004");
        PlayGamesScriptManager.ShowAchievementsUI();
    }

    public void SignIn()
    {
        PlayGamesScriptManager.SignIn();
    }

    public void ChangeLanguage(int id)
    {
        switch (id)
        {
            case 1: LocalizationSystem.SetLanguage(LocalizationSystem.Language.ChineseSimplified); break;
            case 2: LocalizationSystem.SetLanguage(LocalizationSystem.Language.ChineseTraditional); break;
            case 3: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Dutch); break;
            case 4: LocalizationSystem.SetLanguage(LocalizationSystem.Language.English); break;
            case 5: LocalizationSystem.SetLanguage(LocalizationSystem.Language.French); break;
            case 6: LocalizationSystem.SetLanguage(LocalizationSystem.Language.German); break;
            case 7: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Hindi); break;
            case 8: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Indonesian); break;
            case 9: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Italian); break;
            case 10: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Japanese); break;
            case 11: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Korean); break;
            case 12: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Polish); break;
            case 13: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Portuguese); break;
            case 14: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Russian); break;
            case 15: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Spanish); break;
            case 16: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Swedish); break;
            case 17: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Thai); break;
            case 18: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Turkish); break;
            case 19: LocalizationSystem.SetLanguage(LocalizationSystem.Language.Vietnamese); break;
        }
        GameEvents.current.LanguageTriggerEnter();
        GameEvents.current.LevelChangedTriggerEnter();
        if (!isLoadingLangFirstTime)
        {
            FindObjectOfType<AudioManager>().Play("click1");
            lang = id;
            SaveSettings();
        }
    }

    /*public void PlayAd(int id)
    {
        switch (id)
        {
            case 1: AdManager.ShowInterstitialAd(); break;
            case 2: AdManager.ShowRewardedAd(); break;
        }
    }*/
    }
