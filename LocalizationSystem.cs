using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem
{
    public enum Language
    {
        ChineseSimplified,
        ChineseTraditional,
        Dutch,
        English,
        French,
        German,
        Hindi,
        Indonesian,
        Italian,
        Japanese,
        Korean,
        Polish,
        Portuguese,
        Russian,
        Spanish,
        Swedish,
        Thai,
        Turkish,
        Vietnamese
    }

    public static Language language = Language.English;

    private static Dictionary<string, string> localizedZH;
    private static Dictionary<string, string> localizedZHTW;
    private static Dictionary<string, string> localizedNL;
    private static Dictionary<string, string> localizedEN;
    private static Dictionary<string, string> localizedFR;
    private static Dictionary<string, string> localizedDE;
    private static Dictionary<string, string> localizedHI;
    private static Dictionary<string, string> localizedID;
    private static Dictionary<string, string> localizedIT;
    private static Dictionary<string, string> localizedJA;
    private static Dictionary<string, string> localizedKO;
    private static Dictionary<string, string> localizedPL;
    private static Dictionary<string, string> localizedPT;
    private static Dictionary<string, string> localizedRU;
    private static Dictionary<string, string> localizedES;
    private static Dictionary<string, string> localizedSV;
    private static Dictionary<string, string> localizedTH;
    private static Dictionary<string, string> localizedTR;
    private static Dictionary<string, string> localizedVI;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localizedZH = csvLoader.GetDictionaryValues("zh");
        localizedZHTW = csvLoader.GetDictionaryValues("zhtw");
        localizedNL = csvLoader.GetDictionaryValues("nl");
        localizedEN = csvLoader.GetDictionaryValues("en");
        localizedFR = csvLoader.GetDictionaryValues("fr");
        localizedDE = csvLoader.GetDictionaryValues("de");
        localizedHI = csvLoader.GetDictionaryValues("hi");
        localizedID = csvLoader.GetDictionaryValues("id");
        localizedIT = csvLoader.GetDictionaryValues("it");
        localizedJA = csvLoader.GetDictionaryValues("ja");
        localizedKO = csvLoader.GetDictionaryValues("ko");
        localizedPL = csvLoader.GetDictionaryValues("pl");
        localizedPT = csvLoader.GetDictionaryValues("pt");
        localizedRU = csvLoader.GetDictionaryValues("ru");
        localizedES = csvLoader.GetDictionaryValues("es");
        localizedSV = csvLoader.GetDictionaryValues("sv");
        localizedTH = csvLoader.GetDictionaryValues("th");
        localizedTR = csvLoader.GetDictionaryValues("tr");
        localizedVI = csvLoader.GetDictionaryValues("vi");

        isInit = true;
    }

    public static string GetLocalizedValue(string key)
    {
        if (!isInit) { Init(); }

        string value = key;

        switch (language)
        {
            case Language.ChineseSimplified: localizedZH.TryGetValue(key, out value); break;
            case Language.ChineseTraditional: localizedZHTW.TryGetValue(key, out value); break;
            case Language.Dutch: localizedNL.TryGetValue(key, out value); break;
            case Language.English: localizedEN.TryGetValue(key, out value); break;
            case Language.French: localizedFR.TryGetValue(key, out value); break;
            case Language.German: localizedDE.TryGetValue(key, out value); break;
            case Language.Hindi: localizedHI.TryGetValue(key, out value); break;
            case Language.Indonesian: localizedID.TryGetValue(key, out value); break;
            case Language.Italian: localizedIT.TryGetValue(key, out value); break;
            case Language.Japanese: localizedJA.TryGetValue(key, out value); break;
            case Language.Korean: localizedKO.TryGetValue(key, out value); break;
            case Language.Polish: localizedPL.TryGetValue(key, out value); break;
            case Language.Portuguese: localizedPT.TryGetValue(key, out value); break;
            case Language.Russian: localizedRU.TryGetValue(key, out value); break;
            case Language.Spanish: localizedES.TryGetValue(key, out value); break;
            case Language.Swedish: localizedSV.TryGetValue(key, out value); break;
            case Language.Thai: localizedTH.TryGetValue(key, out value); break;
            case Language.Turkish: localizedTR.TryGetValue(key, out value); break;
            case Language.Vietnamese: localizedVI.TryGetValue(key, out value); break;
        }

        return value;
    }

    public static void SetLanguage(Language newLanguage)
    {
        language = newLanguage;
    }
}
