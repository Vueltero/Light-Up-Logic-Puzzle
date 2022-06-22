using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocalizerUI : MonoBehaviour
{
    TextMeshProUGUI textField;

    public string key;

    [SerializeField] private LightUp LightUpScript;

    private string langKey, langColor;

    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        VerifyKey(key, LocalizationSystem.GetLocalizedValue(key));

        GameEvents.current.onLanguageTriggerEnter += LanguageOpen;
        GameEvents.current.onVolumeTriggerEnter += VolumeChanged;
        GameEvents.current.onThemeTriggerEnter += ThemeChanged;
        GameEvents.current.onLevelChangedTriggerEnter += LevelChanged;
        GameEvents.current.onLevelWonTriggerEnter += LevelWon;
        GameEvents.current.onTimeTrialWonTriggerEnter += TimeTrialWon;
        GameEvents.current.onHintsFoundTriggerEnter += HintsFound;
        GameEvents.current.onThemeBoughtTriggerEnter += ThemeBought;
        GameEvents.current.onHintsBoughtTriggerEnter += HintsBought;
        GameEvents.current.onAdsRemovedTriggerEnter += AdsRemoved;
        GameEvents.current.onLanguageChangedTriggerEnter += LanguageChanged;
    }

    private void LanguageOpen()
    {
        VerifyKey(key, LocalizationSystem.GetLocalizedValue(key));
    }

    private void VolumeChanged()
    {
        if (key == "soundText")
        {
            if (LightUpScript.volume == 0)
                textField.text = LocalizationSystem.GetLocalizedValue("soundOff");
            else
            {
                string value = LocalizationSystem.GetLocalizedValue(key);
                textField.text = value.Replace("<key>", (LightUpScript.volume * 10).ToString());
            }
        }
        ChangeFontsHiThCJK();
    }

    private void ThemeChanged()
    {
        if (key == "themeName")
        {
            switch (LightUpScript.themeSelected)
            {
                case 0: textField.text = LocalizationSystem.GetLocalizedValue("themeClassicTheme"); break;
                case 1: textField.text = LocalizationSystem.GetLocalizedValue("themePaper"); break;
                case 2: textField.text = LocalizationSystem.GetLocalizedValue("themeStitches"); break;
                case 3: textField.text = LocalizationSystem.GetLocalizedValue("themeForest"); break;
                case 4: textField.text = LocalizationSystem.GetLocalizedValue("themeDarkMode"); break;
                case 5: textField.text = LocalizationSystem.GetLocalizedValue("themeWater"); break;
                case 6: textField.text = LocalizationSystem.GetLocalizedValue("themeAkari"); break;
                case 7: textField.text = LocalizationSystem.GetLocalizedValue("themeLightOut"); break;
                case 8: textField.text = LocalizationSystem.GetLocalizedValue("themeExplosive"); break;
                case 9: textField.text = LocalizationSystem.GetLocalizedValue("themeMedieval"); break;
            }
        }
        ChangeFontsHiThCJK();
    }

    private void LevelChanged()
    {
        if (key == "level")
        {
            textField.text = LocalizationSystem.GetLocalizedValue("level") + " " + (LightUpScript.currentLevel + 1);
            if (LocalizationSystem.language == LocalizationSystem.Language.Vietnamese)
                textField.text = textField.text.Replace("\n", "").Replace("\r", "");
            ChangeFontsHiThCJK();
        }
    }

    private void LevelWon()
    {
        if (key == "youSolvedTheLevelIn")
        {
            float minutes = Mathf.FloorToInt(LightUpScript.currentTime / 60);
            float seconds = Mathf.FloorToInt(LightUpScript.currentTime % 60);
            textField.text = LocalizationSystem.GetLocalizedValue("youSolvedTheLevelIn") + " " + minutes + ":" + seconds;
        }
        ChangeFontsHiThCJK();
    }

    private void TimeTrialWon()
    {
        if (key == "youSolvedXinY")
            VerifyTimeTrialWon();
    }

    private void VerifyTimeTrialWon()
    {
        //You solved <k> <p> in <c>
        string value = LocalizationSystem.GetLocalizedValue("youSolvedXinY").Replace("<k>", LightUpScript.timeTrialSolved.ToString());
        if (LightUpScript.timeTrialSolved == 1)
            value = value.Replace("<p>", LocalizationSystem.GetLocalizedValue("puzzleS"));
        else
            value = value.Replace("<p>", LocalizationSystem.GetLocalizedValue("puzzleP"));
        switch (LightUpScript.timeTrialMinutesChoice)
        {
            case 1: value = value.Replace("<c>", LocalizationSystem.GetLocalizedValue("1Minute")); break;
            case 2: value = value.Replace("<c>", LocalizationSystem.GetLocalizedValue("2Minutes")); break;
            case 4: value = value.Replace("<c>", LocalizationSystem.GetLocalizedValue("4Minutes")); break;
            case 5: value = value.Replace("<c>", LocalizationSystem.GetLocalizedValue("8Minutes")); break;
        }
        textField.text = value;
        ChangeFontsHiThCJK();
    }

    private void HintsFound()
    {
        if (key == "thereAreXMistakes")
            textField.text = LocalizationSystem.GetLocalizedValue("thereAreXMistakes").Replace("<key>", LightUpScript.errors.ToString());
    }

    private void ThemeBought()
    {
        if (key == "waterX")
        {
            if (LightUpScript.themeUnlocked0 == 1) textField.text = LocalizationSystem.GetLocalizedValue("water");
            else textField.text = LocalizationSystem.GetLocalizedValue("water") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        if (key == "akariX")
        {
            if (LightUpScript.themeUnlocked1 == 1) textField.text = LocalizationSystem.GetLocalizedValue("akari");
            else textField.text = LocalizationSystem.GetLocalizedValue("akari") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        if (key == "lightOutX")
        {
            if (LightUpScript.themeUnlocked2 == 1) textField.text = LocalizationSystem.GetLocalizedValue("lightOut");
            else textField.text = LocalizationSystem.GetLocalizedValue("lightOut") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        if (key == "explosiveX")
        {
            if (LightUpScript.themeUnlocked3 == 1) textField.text = LocalizationSystem.GetLocalizedValue("explosive");
            else textField.text = LocalizationSystem.GetLocalizedValue("explosive") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        if (key == "medievalX")
        {
            if (LightUpScript.themeUnlocked4 == 1) textField.text = LocalizationSystem.GetLocalizedValue("medieval");
            else textField.text = LocalizationSystem.GetLocalizedValue("medieval") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        if (key == "unlockAllThemesX")
            textField.text = LocalizationSystem.GetLocalizedValue("unlockAllThemes") + " <size=80%><color=#333c57>($1.99)</color>";
        if (key == "colorYourGameX")
        {
            if (LightUpScript.packsUnlocked[6] || LightUpScript.packsUnlocked[7] || LightUpScript.packsUnlocked[8] || LightUpScript.packsUnlocked[9] ||
                LightUpScript.packsUnlocked[10] || LightUpScript.packsUnlocked[11] || LightUpScript.packsUnlocked[13] || LightUpScript.packsUnlocked[14] ||
                LightUpScript.packsUnlocked[20] || LightUpScript.packsUnlocked[21] || LightUpScript.packsUnlocked[22] || LightUpScript.packsUnlocked[23] ||
                LightUpScript.packsUnlocked[24] || LightUpScript.boughtHints || LightUpScript.themeUnlocked0 == 1 || LightUpScript.themeUnlocked1 == 1 ||
                LightUpScript.themeUnlocked2 == 1 || LightUpScript.themeUnlocked3 == 1 || LightUpScript.themeUnlocked4 == 1)
                textField.text = LocalizationSystem.GetLocalizedValue("colorYourGame1");
            else
                textField.text = LocalizationSystem.GetLocalizedValue("colorYourGame2");
        }
        ChangeFontsHiThCJK();
    }

    private void HintsBought()
    {
        if (key == "xHintsRemaining")
            textField.text = LocalizationSystem.GetLocalizedValue("xHintsRemaining").Replace("<key>", LightUpScript.hints.ToString());
    }

    private void AdsRemoved()
    {
        if (key == "removeAdsByPurchasing")
        {
            if (LightUpScript.packsUnlocked[6] || LightUpScript.packsUnlocked[7] || LightUpScript.packsUnlocked[8] || LightUpScript.packsUnlocked[9] ||
                LightUpScript.packsUnlocked[10] || LightUpScript.packsUnlocked[11] || LightUpScript.packsUnlocked[13] || LightUpScript.packsUnlocked[14] ||
                LightUpScript.packsUnlocked[20] || LightUpScript.packsUnlocked[21] || LightUpScript.packsUnlocked[22] || LightUpScript.packsUnlocked[23] ||
                LightUpScript.packsUnlocked[24] || LightUpScript.boughtHints || LightUpScript.themeUnlocked0 == 1 || LightUpScript.themeUnlocked1 == 1 ||
                LightUpScript.themeUnlocked2 == 1 || LightUpScript.themeUnlocked3 == 1 || LightUpScript.themeUnlocked4 == 1)
                textField.text = LocalizationSystem.GetLocalizedValue("adsRemoved");
            else
                textField.text = LocalizationSystem.GetLocalizedValue("removeAdsByPurchasing");
        }
    }

    private void LanguageChanged()
    {
        if (key == "languageX")
        {
            switch (LightUpScript.lang)
            {
                case 1: langKey = "chineseSimplified"; langColor = "FFCD75"; break;
                case 2: langKey = "chineseTraditional"; langColor = "A7F070"; break;
                case 3: langKey = "Dutch"; langColor = "38B764"; break;
                case 4: langKey = "English"; langColor = "257179"; break;
                case 5: langKey = "French"; langColor = "3B5DC9"; break;
                case 6: langKey = "German"; langColor = "41A6F6"; break;
                case 7: langKey = "Hindi"; langColor = "3B5DC9"; break;
                case 8: langKey = "Indonesian"; langColor = "5D275D"; break;
                case 9: langKey = "Italian"; langColor = "B13E53"; break;
                case 10: langKey = "Japanese"; langColor = "EF7D57"; break;
                case 11: langKey = "Korean"; langColor = "FFCD75"; break;
                case 12: langKey = "Polish"; langColor = "257179"; break;
                case 13: langKey = "Portuguese"; langColor = "3B5DC9"; break;
                case 14: langKey = "Russian"; langColor = "41A6F6"; break;
                case 15: langKey = "Spanish"; langColor = "73EFF7"; break;
                case 16: langKey = "Swedish"; langColor = "94B0C2"; break;
                case 17: langKey = "Thai"; langColor = "5D275D"; break;
                case 18: langKey = "Turkish"; langColor = "B13E53"; break;
                case 19: langKey = "Vietnamese"; langColor = "EF7D57"; break;
            }
            textField.text = LocalizationSystem.GetLocalizedValue("language") + ": <color=#" + langColor + ">" + LocalizationSystem.GetLocalizedValue(langKey) + "</color>";
        }
        ChangeFontsHiThCJK();
    }

    private void VerifyKey(string key, string value)
    {
        if (key == "soundText")
        {
            if (LightUpScript.volume == 0)
                textField.text = LocalizationSystem.GetLocalizedValue("soundOff");
            else
                textField.text = value.Replace("<key>", (LightUpScript.volume * 10).ToString());
        }
        else if (key == "themeName")
        {
            switch (LightUpScript.themeSelected)
            {
                case 0: textField.text = LocalizationSystem.GetLocalizedValue("themeClassicTheme"); break;
                case 1: textField.text = LocalizationSystem.GetLocalizedValue("themePaper"); break;
                case 2: textField.text = LocalizationSystem.GetLocalizedValue("themeStitches"); break;
                case 3: textField.text = LocalizationSystem.GetLocalizedValue("themeForest"); break;
                case 4: textField.text = LocalizationSystem.GetLocalizedValue("themeDarkMode"); break;
                case 5: textField.text = LocalizationSystem.GetLocalizedValue("themeWater"); break;
                case 6: textField.text = LocalizationSystem.GetLocalizedValue("themeAkari"); break;
                case 7: textField.text = LocalizationSystem.GetLocalizedValue("themeLightOut"); break;
                case 8: textField.text = LocalizationSystem.GetLocalizedValue("themeExplosive"); break;
                case 9: textField.text = LocalizationSystem.GetLocalizedValue("themeMedieval"); break;
            }
        }
        else if (key == "byVueltero")
            textField.text = value.Replace("<key>", "\u0022");
        else if (key == "20HintsX")
            textField.text = LocalizationSystem.GetLocalizedValue("20Hints") + " <size=80%><color=#333c57>($2.99)</color>";
        else if (key == "5HintsX")
            textField.text = LocalizationSystem.GetLocalizedValue("5Hints") + " <size=80%><color=#333c57>($0.99)</color>";
        else if (key == "30x30ManiaDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("30x30ManiaDesc") + " <size=80%>($0.99)";
        else if (key == "35x35ManiaDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("35x35ManiaDesc") + " <size=80%>($0.99)";
        else if (key == "40x40ManiaDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("40x40ManiaDesc") + " <size=80%>($0.99)";
        else if (key == "45x45ManiaDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("45x45ManiaDesc") + " <size=80%>($0.99)";
        else if (key == "50x50ManiaDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("50x50ManiaDesc") + " <size=80%>($0.99)";
        else if (key == "extremeJumboDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("extremeJumboDesc") + " <size=80%>($1.99)";
        else if (key == "intervalPack2DescX")
            textField.text = LocalizationSystem.GetLocalizedValue("intervalPack2Desc") + " <size=80%>($1.99)";
        else if (key == "extremeIntervalDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("extremeIntervalDesc") + " <size=80%>($1.99)";
        else if (key == "jumboRectangle2DescX")
            textField.text = LocalizationSystem.GetLocalizedValue("jumboRectangle2Desc") + " <size=80%>($1.99)";
        else if (key == "4WayMirrorDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("4WayMirrorDesc") + " <size=80%>($0.99)";
        else if (key == "4WayRotationalDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("4WayRotationalDesc") + " <size=80%>($0.99)";
        else if (key == "extremeNoSymDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("extremeNoSymDesc") + " <size=80%>($1.99)";
        else if (key == "kidsPackDescX")
            textField.text = LocalizationSystem.GetLocalizedValue("kidsPackDesc") + " <size=80%>($0.99)";
        else if (key == "level")
            textField.text = LocalizationSystem.GetLocalizedValue("level") + " " + (LightUpScript.currentLevel + 1);
        else if (key == "youSolvedTheLevelIn")
        {
            float minutes = Mathf.FloorToInt(LightUpScript.currentTime / 60);
            float seconds = Mathf.FloorToInt(LightUpScript.currentTime % 60);
            textField.text = LocalizationSystem.GetLocalizedValue("youSolvedTheLevelIn") + " " + minutes + ":" + seconds;
        }
        else if (key == "youSolvedXinY")
            VerifyTimeTrialWon();
        else if (key == "thereAreXMistakes")
            textField.text = LocalizationSystem.GetLocalizedValue("thereAreXMistakes").Replace("<key>", LightUpScript.errors.ToString());
        else if (key == "waterX")
        {
            if (LightUpScript.themeUnlocked0 == 1) textField.text = LocalizationSystem.GetLocalizedValue("water");
            else textField.text = LocalizationSystem.GetLocalizedValue("water") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        else if (key == "akariX")
        {
            if (LightUpScript.themeUnlocked1 == 1) textField.text = LocalizationSystem.GetLocalizedValue("akari");
            else textField.text = LocalizationSystem.GetLocalizedValue("akari") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        else if (key == "lightOutX")
        {
            if (LightUpScript.themeUnlocked2 == 1) textField.text = LocalizationSystem.GetLocalizedValue("lightOut");
            else textField.text = LocalizationSystem.GetLocalizedValue("lightOut") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        else if (key == "explosiveX")
        {
            if (LightUpScript.themeUnlocked3 == 1) textField.text = LocalizationSystem.GetLocalizedValue("explosive");
            else textField.text = LocalizationSystem.GetLocalizedValue("explosive") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        else if (key == "medievalX")
        {
            if (LightUpScript.themeUnlocked4 == 1) textField.text = LocalizationSystem.GetLocalizedValue("medieval");
            else textField.text = LocalizationSystem.GetLocalizedValue("medieval") + " <size=80%><color=#333c57>($0.99)</color>";
        }
        else if (key == "unlockAllThemesX")
            textField.text = LocalizationSystem.GetLocalizedValue("unlockAllThemes") + " <size=80%><color=#333c57>($1.99)</color>";
        else if (key == "colorYourGameX")
        {
            if (LightUpScript.packsUnlocked[6] || LightUpScript.packsUnlocked[7] || LightUpScript.packsUnlocked[8] || LightUpScript.packsUnlocked[9] ||
            LightUpScript.packsUnlocked[10] || LightUpScript.packsUnlocked[11] || LightUpScript.packsUnlocked[13] || LightUpScript.packsUnlocked[14] ||
            LightUpScript.packsUnlocked[20] || LightUpScript.packsUnlocked[21] || LightUpScript.packsUnlocked[22] || LightUpScript.packsUnlocked[23] ||
            LightUpScript.packsUnlocked[24] || LightUpScript.boughtHints || LightUpScript.themeUnlocked0 == 1 || LightUpScript.themeUnlocked1 == 1 ||
            LightUpScript.themeUnlocked2 == 1 || LightUpScript.themeUnlocked3 == 1 || LightUpScript.themeUnlocked4 == 1)
                textField.text = LocalizationSystem.GetLocalizedValue("colorYourGame1");
            else
                textField.text = LocalizationSystem.GetLocalizedValue("colorYourGame2");
        }
        else if (key == "xHintsRemaining")
            textField.text = LocalizationSystem.GetLocalizedValue("xHintsRemaining").Replace("<key>", LightUpScript.hints.ToString());
        else if (key == "removeAdsByPurchasing")
        {
            if (LightUpScript.packsUnlocked[6] || LightUpScript.packsUnlocked[7] || LightUpScript.packsUnlocked[8] || LightUpScript.packsUnlocked[9] ||
                LightUpScript.packsUnlocked[10] || LightUpScript.packsUnlocked[11] || LightUpScript.packsUnlocked[13] || LightUpScript.packsUnlocked[14] ||
                LightUpScript.packsUnlocked[20] || LightUpScript.packsUnlocked[21] || LightUpScript.packsUnlocked[22] || LightUpScript.packsUnlocked[23] ||
                LightUpScript.packsUnlocked[24] || LightUpScript.boughtHints || LightUpScript.themeUnlocked0 == 1 || LightUpScript.themeUnlocked1 == 1 ||
                LightUpScript.themeUnlocked2 == 1 || LightUpScript.themeUnlocked3 == 1 || LightUpScript.themeUnlocked4 == 1)
                textField.text = LocalizationSystem.GetLocalizedValue("adsRemoved");
            else
                textField.text = LocalizationSystem.GetLocalizedValue("removeAdsByPurchasing");
        }
        else if (key == "thankYouPurchase")
            textField.text = LocalizationSystem.GetLocalizedValue("thankYouPurchase") + "<br>" + LocalizationSystem.GetLocalizedValue("youUnlockedAll");
        else if (key == "languageX")
        {
            switch (LightUpScript.lang)
            {
                case 1: langKey = "chineseSimplified"; langColor = "FFCD75"; break;
                case 2: langKey = "chineseTraditional"; langColor = "A7F070"; break;
                case 3: langKey = "Dutch"; langColor = "38B764"; break;
                case 4: langKey = "English"; langColor = "257179"; break;
                case 5: langKey = "French"; langColor = "3B5DC9"; break;
                case 6: langKey = "German"; langColor = "41A6F6"; break;
                case 7: langKey = "Hindi"; langColor = "3B5DC9"; break;
                case 8: langKey = "Indonesian"; langColor = "5D275D"; break;
                case 9: langKey = "Italian"; langColor = "B13E53"; break;
                case 10: langKey = "Japanese"; langColor = "EF7D57"; break;
                case 11: langKey = "Korean"; langColor = "FFCD75"; break;
                case 12: langKey = "Polish"; langColor = "257179"; break;
                case 13: langKey = "Portuguese"; langColor = "3B5DC9"; break;
                case 14: langKey = "Russian"; langColor = "41A6F6"; break;
                case 15: langKey = "Spanish"; langColor = "73EFF7"; break;
                case 16: langKey = "Swedish"; langColor = "94B0C2"; break;
                case 17: langKey = "Thai"; langColor = "5D275D"; break;
                case 18: langKey = "Turkish"; langColor = "B13E53"; break;
                case 19: langKey = "Vietnamese"; langColor = "EF7D57"; break;
            }
            textField.text = LocalizationSystem.GetLocalizedValue("language") + ": <color=#" + langColor + ">" + LocalizationSystem.GetLocalizedValue(langKey) + "</color>";
        }
        else
            textField.text = value;
        ChangeFontsHiThCJK();
    }

    private void ChangeFontsHiThCJK()
    {
        //for some reason for the vietnamese language all strings ends with ", maybe it has sth to do with it being the last language in the csv file, idk
        if (LocalizationSystem.language == LocalizationSystem.Language.Vietnamese)
        {
            if (textField.text != null)
                textField.text = textField.text.Replace("\u0022", string.Empty);
            if (key == "waterX" || key == "akariX" || key == "lightOutX" || key == "explosiveX" || key == "medievalX" || key == "unlockAllThemesX" || key == "languageX" ||
                key == "20HintsX" || key == "5HintsX" || key == "level" || key == "youSolvedTheLevelIn")
            {
                textField.text = textField.text.Replace("\r", string.Empty);
                textField.text = textField.text.Replace("\n", string.Empty);
            }
        }

        else if (LocalizationSystem.language == LocalizationSystem.Language.Hindi)
            textField.text = "<font=\u0022NotoSerifDevanagari-VariableFont_wdth,wght SDF\u0022>" + textField.text + "</font>";
        else if (LocalizationSystem.language == LocalizationSystem.Language.Thai)
            textField.text = "<font=\u0022NotoSansThaiLooped-Regular SDF\u0022>" + textField.text + "</font>";

        else if (LocalizationSystem.language == LocalizationSystem.Language.ChineseSimplified)
            textField.text = "<font=\u0022NotoSansSC-Regular SDF\u0022>" + textField.text + "</font>";
        else if (LocalizationSystem.language == LocalizationSystem.Language.ChineseTraditional)
            textField.text = "<font=\u0022NotoSansTC-Regular SDF\u0022>" + textField.text + "</font>";
        else if (LocalizationSystem.language == LocalizationSystem.Language.Japanese)
            textField.text = "<font=\u0022NotoSansJP-Regular SDF\u0022>" + textField.text + "</font>";
        else if (LocalizationSystem.language == LocalizationSystem.Language.Korean)
            textField.text = "<font=\u0022NotoSansKR-Regular SDF\u0022>" + textField.text + "</font>";
    }
}
