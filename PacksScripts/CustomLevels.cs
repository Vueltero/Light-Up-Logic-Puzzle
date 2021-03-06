using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomLevels : MonoBehaviour
{
    string[] puzzles =
    {
        "100x100:EE0EEWEEEEEEEEEEEEEEEEEEEEEEE1EE11EEEEEEEE1EEEEEEW1EEEEEEWEEEEEEEE10EE0EEEEEEEEEEEEEEEEEEEEEEE0EE0EEEEEEEEEE1EEEWEEE1EEEE1WWWEEEE1EEEEEEEEEEEE1EEEEEEEEEEEEEE1EEEEEEEEEEEEWEEEEWWWWEEEE1EEEWEEEWEEEEEEEE2EEEEEEWWEEEE1EWEEEWEEEEEE0EE1EEEEEEWWWWEEEEE1EEEEEEEEWEEEEE1WWWEEEEEEWEE2EEEEEE2EEE1EWEEEEWWEEEEEE0EEE11EEEWEWEEE0EEEEWEEWWEE1EEEEE1WEEWEE1EEE1EWEE011WEEWEWEEEWEE1EE10EEEEE0EE01EEWEEEE1EEE1E0EEE1WEEEEEE11EEEWE1EEE2EEEEWEEW0EEWEEEEEW1EE1EEWEEE1EWEEEEEEEEWEWEEE1EEWEE1WEEEEEWEEWWEEWEEEE2EEE1E0EEE01EEEWEEEEEE0WEEEEWEWEEE1EEEEEE0EEWEEEEEE11WWEEEEEWEEEEEEEE0EEEEE1WWWEEEEEE1EE1EEEEEE0EEE1EWEEEEWWEEEEEE0EEEEEEEEWEEE1EEE2EEEE1WWWEEEEWEEEEEEEEEEEEWEEEEEEEEEEEEEE1EEEEEEEEEEEEWEEEE1WWWEEEE2EEE1EEEWEEEEEEEEEEWEEWEEEEEEEEEEEEEEEEEEEEEEEWEEWWEEEEEEEE1EEEEEE11EEEEEEWEEEEEEEEW0EE0EEEEEEEEEEEEEEEEEEEEEEEWEEWEEEWW0WWWEWWWW0EEE1WWWWWWWWWWWWWWWWWWWWWWWWWWWWW1EEEEEEWW11WWW1WWW0WWWWWWWWWWWWWWWWWW1EEEWWWWWEWW00W2EEEEEEEEEWEEEEEEEE2EEE2EEEWEEE2EEE0EEE0EEEWEEEWEEEEEEEEWEEE2EEEWEEEWEEE1EEE2EEEWEEEWEEEEEEEEWEEEEEEEEEEEW1EEEWEE0EEEEEEE1EEEEEEE0EEEEEEE1EEEEEEE1EEEEEEEEEEEEWEEEEEEE1EEEEEEE1EEEEEEE2EEEEEEEWEE1EEEW0EEEEEEEEEEEWEWWEEEEEEE1EEEWEEE0EEEEEEE0EEE2EEEWEEEEE22EEEEEWEEE2EEEWEEEEEEE0EEE1EEE0EEEEEEEW0EWEEEEEEEEE1EEEE1EWEEEEE0W0EEEEEWW1EEEEEE01WEEEEEEEEEEEEEE2EEWEEEEEEEEEEEEEEWW1EEEEEEWW1EEEEEWW2EEEEE1E1EEEEWEEEWEE1EEEEEEEEEEEW2EEEE1EEEEEEEWEEWEEEEEEEEEEEEEWEE1EEEEEEEEEEEEEWEEWEEEEEEE0EEEE00EEEEEEEEEEE1EE3EEEEE0WEEEEEEE2EEEEEEWEEEEEEEEEEEWEEE1EEE2WWEEEEE1EEEE2EEEEEWW1EEEWEEEWEEEEEEEEEEEWEEEEEE2EEEEEEEWWEEEEE2EE0EEEEEE0EE3EEEEWEEEEEW01EEE1EE1EW2EEWEEEEEWEEEEWEEEEE1EEW1E0EE2EEE11WEEEEE1EEEE2EEWEEEEEE0EE1EEEWEEEEWE1EEE1EEE4EEEEWEE11EEEEEE1EEEEEEEEWEEEE1EE22EE0EEEEWEEEEEEEE0EEEEEE00EE1EEEE2EEEWEEE1EWEEEE1EEEEEEEEEWWEEEWEEEWEEEWE2EEEEEEEEEEE1EEEE1EEEEEWE1EEWE2EEEEEWEEEE0EEEEEEEEEEE0E0EEE2EEE1EEE1WEEEEEEEEEEEEEEEEWEEEEWEEEEWEEE1EEEEEEEEWWE2W2EW1EEEEE1EE1EEWEE2EEEEE00E1W2EWWEEEEEEEEWEEE2EEEEWEEEEWEEEEEEEEEEW110EEWE2WEE2EEEE4EEWEEE0WEEWEEEE1EEEEEEEEEWE2EEEE1E1EEEEEEEEE3EEEEWEE12EEEWEE2EEEEWEE0WEWEE11WWEEEEEEEEEEWEEEEEE1EEEE2EE0EEEEE1EEEEEEEEWEEEEEWEEWEEEEWEE1EEEEEWEEEEEEEEWEEEEEWEE2EEEEWEEEEEEWEEEEEEEEEWEEEEWEWWEEEEEE2WEEEEEWEEEEEWEE20EWEEWEEEEE1EEWW11W0EEWEEEEE2EEWE01EEWEEEEEWEEEEE0WEEEEEE1WEWEEEEWEEWEW1E1EWEEE1EEEEEWWEEEE1EEEEW1WEEE1EEE1EEE1EEEEEEEEEEEEWEEE2EEEWEEEW0WEEEE2EEEEWWEEEEE2EEEWEWEW2EWEEWEWWEWEWEE1W0EEE1EE02EEEW1EEEEEEEEE1EEWEEEWEEEEEEEEEEEEWEEE0EE2EEEEEEEEEWWEEE20EE1EEEWW2EEWEWE2WEWEE1EEEE1EWEEEWEEEWEEEEE3EEEEW1EEEEEEEE11WEEEWWWWWW11WWWWWWEEE0WWEEEEEEEEWWEEEE2EEEEE1EEE1EEEWEWEEEEWEEEEEEEEEW1EEEEEEWEEEEEE2EEEEEWWEEEEEEEEEEE1EEEEEEEEEEEEEEWEEEEEEEEEEE2WEEEEE2EEEEEE2EEEEEEWWEEEEEEEEEE0000EEWEEEEEEWEEEWEEE1EEEEEEE2EEEEEEEEEEWEEEEEEEEEEEEEE1EEEEEEEEEEWEEEEEEE1EEE1EEEWEEEEEEWEEW001EEEEEEEEEEWE1WEEE1EEEWEEEEWEEWEEEEEEEEEWEEEEEEEEE1EEEE1EEEEEEEEE1EEEEEEEEE2EEWEEEE0EEEWEEE22EWEEEEEEEEEEEEEEEEWEEEEEE1EEEEEEEE1EEEWWWWWWWWWWWWW1WWWWWEEEEEEWWWWWWWWWWWWW1WWWWWEEEWEEEEEEEE1EEEEEEWEEEEEEEEW10EE0WWW0EEEEEEEEEE1WWEE2EEWEEEEEEEEEEEE2EEEEEEEWWEEEEEEE1EEEEEEEEEEEEWEEWEE01WEEEEEEEEEEWWWWWEE2W0EEEEEEEEWEEEEEEEEEEWEEWEE2EEWE1EEEEWE1EEEEEEEEEEWWWWEEEEEEEEEE1EWEEEE2EWEE2EEWEEWEEEEEEEEEEWEEEEEEEEEEEEEEEEWEEE2WWEEEWEEEWEEEWEWEE2EEWEEE2EEEEEWEEEWWW0EEE1EEEEE1EEE1EE2EEWE2EEEWEEEWEEE2WWEEEWEEEEEEEEWEEW1EE1WEEEWEE11EWEE1EEEEEE2EEEE0EEEEE2EE1EEWEEEWWEEEWEE0EE1EEEEEWEEEEWEEEEEE1EE3EW1EEWEEEW1EE11EEWWEE00EE1W2EEWEEEEEEEE0EEEEEEWEEE0EEEEEEE2EE1EE2EEEEEEWEE1EE1EEEEEEE2EEEWEEEEEEWEEEEEEEE0EE1W1EEWWEE1EEEEEEEEWEEEE1EEEE3EEEEEEEEEWEEWEEWEEE1EE2EEEEE3EEEEWEEEEE3EE1EEEWEE2EEWEEEEEEEEE1EEEEWEEEEWEEEEEEEEEEEEEEEEWE0WEEWWE3W3EWWEEEEEWEWEEEEWEWEEEEEEEEEE2EE0EEEEEEEEEEWEWEEEEWEWEEEEEW3E1W1E3WEEW0EWEEEEEEEEEE0WWWEEWEEEEEEEEE3EEEE1EEEEWEEEEEEE4EEEEEEEEEEEEWWEEEEEEEEEEEE4EEEEEEEWEEEEWEEEE1EEEEEEEEEWEEW10WEEEEWEEWEEWWEEEEEWEEEEEEEEWEEWWEWEEEEWEEE1EEEWEEEEEEEEEEEEWEEE1EEEWEEEEWEW1EEWEEEEEEEE2EEEEE1WEEWEEWEEEEWEEWEEWEEEEEE2EEWE0WEE0EEEWEE1EE1EEEEEEEWW1EEEEEEEEEEWWWEEEEEEE1EEWEEWEEEWEE11E3EE1EEEEEEWEEWEEWEEEE0W0WEEWEE2EEWEEEWEEEWWWEEEWEEE1EEEE1EEEEEWEEE2EEEE1EEE1EEEEE1EEEE1EEEWEEEWWWEEEWEEEWEE2EEWEEW1WWEEEEEEEEEEWEEEEEWEE0EEEEEEEEEEWEEEE2EEEEEEEEEEEEEWEEEE1EEEEEEEEEEEEEWEEEEWEEEEEEEEEE1EEWEEEEEWEEEEEEEEEEEEEEEEW0EEEEWWWEEEEEEEEEEE1WEEEE2EEEEEEW1EEWWWWWWWWWWEE1WEEEEEEWEEEE1WEEEEEEEEEEEWWWEEEE1WEEEEEEEE1WEEEE11WEEEEEEEEEEEEEEEEW1EWEEEWEEEEEWEE1EEEEEEEEEEEEEEEE1EE0EEEEE3EEEWEWWEEEEEEEEEEEEEEEEWW2EEEEWWEEEEEEEEWE21EEEEEEEEEEW1WEEEWEEEEWEEEWWWEEEEE2EEEEEEEE2EEEEEWWWEEEWEEEEWEEE1W2EEEEEEEEEE11EWEEEEEEEEEEEEEEEEWEEEEEEEEEEEW1EEWEEEWEE1EEEEEE1EEEEEWEEEEEEEEEEWEEEEEWEEEEEEWEEWEEE1EEWWEEEEEEEEEEEWEEEEEEEEEE21WWEEWWEEEEEEEE12EEEEWEEEWEEE0EEEEEEEEWE2EEEE1EE1EEEE1E0EEEEEEEE2EEEWEEEWEEEEW1EEEEEEEEWWEE2WW2EEEEEEEEEE2EEEEEEEWWEEEEEEWEEEWEEEE0EEEEEEEWEEEE1EWEEWE1EEEEWEEEEEEE3EEEEWEEEWEEEEEEW1EEEEEEEWEEEEEEEEEEEEEEEEEEEEEE01EEE2WWEEWEEWEEEEEE1EEEE1WWEEEEEE1EE1EEEEEEWW2EEEEWEEEEEEWEEWEEW1WEEEW2EEEEEEEEEEEEEEEEE2EEEEEEEE1WEEE1WEEWEEWEEEEE21EEE2EEEEEWEEE1W1EEEE1W1EEEWEEEEE1EEE01EEEEEWEEWEE01EEEWWEEEEEEEEWEEEWEEWEEEWEEEWEEEE1EEEEWEEWEEEEWWW1EEEWEEEEWEEEEEEE11EEEEEEE1EEEEWEEE1WWWEEEEWEEWEEEE1EEEEWEEE1EEEWEE11EEWEEE1EEE1EEEEWEEEEWEEWEEEEWWW1EEEWEEEEWEEEEEEE11EEEEEEEWEEEEWEEE1WWWEEEEWEEWEEEEWEEEEWEEE1EEEWEEWEEE1EEEEEEEEWWEEE1WEEWEEWEEEEEWWEEE2EEEEEWEEE1W1EEEE1W1EEE1EEEEE1EEEWWEEEEEWEEWEEW1EEEW0EEEEEEEE2EEEEEEEEEEEEEEEEEW2EEEW02EEWEE2EEEEEE3EEEEW1WEEEEEE1EE1EEEEEEWW0EEEEWEEEEEE2EEWEEWW1EEEWWEEEEEEEEEEEEEEEEEEEEEEWEEEEEEE11EEEEEEWEEEWEEEEWEEEEEEEWEEEE1EWEEWE1EEEEWEEEEEEE0EEEEWEEEWEEEEEEW2EEEEEEE1EEEEEEEEEEW1W2EEWWEEEEEEEEWWEEEEWEEEWEEE2EEEEEEEEWE2EEEE1EE1EEEE1EWEEEEEEEEWEEEWEEEWEEEEW2EEEEEEEE1WEE01W0EEEEEEEEEEWEEEEEEEEEEE2WEEWEEEWEE2EEEEEE1EEEEEWEEEEEEEEEEWEEEEEWEEEEEE3EEWEEE1EEW2EEEEEEEEEEE1EEEEEEEEEEEEEEEEWEW1EEEEEEEEEEWWWEEEWEEEEWEEEWWWEEEEE2EEEEEEEE2EEEEEWW1EEE0EEEEWEEEWWWEEEEEEEEEEW0EWEEEEEEEE1WEEEE0WWEEEEEEEEEEEEEEEE21EWEEE0EEEEE1EE1EEEEEEEEEEEEEEEE1EEWEEEEE1EEEWE1WEEEEEEEEEEEEEEEEW10EEEE01EEEEEEEEW0EEEEWWWEEEEEEEEEEEW1EEEEWEEEEEEW1EEWWWWWWWWWWEE1WEEEEEEWEEEE1WEEEEEEEEEEEWW0EEEEWWEEEEEEEEEEEEEEEEWEEEEEWEE3EEEEEEEEEEWEEEE0EEEEEEEEEEEEEWEEEE0EEEEEEEEEEEEEWEEEEWEEEEEEEEEE1EEWEEEEEWEEEEEEEEEE11W1EEWEE2EEWEEEWEEE2WWEEEWEEE0EEEE1EEEEEWEEE0EEEE0EEEWEEEEE1EEEE2EEEWEEEW11EEEWEEEWEE3EEWEEWW1WEEEE1EEWEEWEEEEEEWEEWEW2EEWEEEWEEWEE2EEEEEEEWWWEEEEEEEEEE1WWEEEEEEE0EE3EEWEEE1EEWWE2EE1EEEEEEWEEWEEWEEEEWEE1EEWWEEEEE0EEEEEEEE0EEWWEWEEEE2EEE1EEE0EEEEEEEEEEEEWEEE1EEEWEEEEWEW2EEWEEEEEEEE1EEEEEWWEEWEE1EEEE1W11EE1EEEEEEEEE0EEEEWEEEEWEEEEEEE4EEEEEEEEEEEE2WEEEEEEEEEEEE4EEEEEEEWEEEE1EEEE2EEEEEEEEEWEEWWW1EEEEEEEEEEWE11EEWWE0W0E10EEEEEWEWEEEEWE2EEEEEEEEEE1EE0EEEEEEEEEEWEWEEEE0EWEEEEEW2E2W2E2WEE11EWEEEEEEEEEEEEEEEE1EEEE1EEEE0EEEEEEEEEWEEWEE2EEE2EE1EEEEEWEEEE1EEEEE0EEWEEE2EEWEEWEEEEEEEEE2EEEEWEEEEWEEEEEEEEWEE1WEEWWWEEWEEEEEEEE2EEEEEE0EEE0EEEEEEEWEE3EEWEEEEEE1EE1EE1EEEEEEEWEEEWEEEEEE1EEEEEEEEWEE1W1EEWWEE10EE00EEWWEEE1EEWWE1EEWEEEEEEWEEEE0EEEEEWEE2EEWEEE0WEEE2EEWEE1EEEEE0EEEEWEEEEEE1EE2EWWEE1EEEW1EEWWEE1EEEEEEEEWEEE01WEEEWEEEWEEE3EWEE1EEWEEE2EEEEE0EEEWWW0EEE3EEEEE2EEE0EE1EEWE1EEEWEEEWEEE2WWEEEWEEEEEEEEEEEEEEEEWEEEEEEEEEE1EEWEE1EEWEWEEEE0EWEEEEEEEEEEWWWWEEEEEEEEEE2EWEEEE1EWEEWEEWEE0EEEEEEEEEEWEEEEEEEEW10EEWW1W1EEEEEEEEEEWW1EEWEEWEEEEEEEEEEEE1EEEEEEEWWEEEEEEE2EEEEEEEEEEEEWEEWEE00WEEEEEEEEEE1WWW2EE1WWEEEEEEEEWEEEEEE1EEEEEEEEWEEEWWWWWWWWWWWW1W1WWWWEEEEEEWWWWWWWWWWWWWWWWWWWEEE1EEEEEEEEWEEEEEEWEEEEEEEEEEEEEEEEWE11EEEWEEE2EEEEWEEWEEEEEEEEEWEEEEEEEEE3EEEE1EEEEEEEEE2EEEEEEEEE1EEWEEEE0EEEWEEE21EWEEEEEEEEEE1W11EEWEEEEEE2EEE1EEE1EEEEEEE2EEEEEEEEEEWEEEEEEEEEEEEEEWEEEEEEEEEE1EEEEEEEWEEE2EEEWEEEEEEWEEW1W0EEEEEEEEEEW1EEEEEEWEEEEEEWEEEEEW1EEEEEEEEEEE1EEEEEEEEEEEEEE1EEEEEEEEEEEW2EEEEEWEEEEEE1EEEEEE1WEEEEEEEEEWEEEEWEWEEE2EEE1EEEEE0EEEE00EEEEEEEEWWWEEEWWWW1WWWWWWWWWEEEWWWEEEEEEEEWWEEEE0EEEEEWEEE1EEEWE1EEEE1EEWE2WEWEWEE2W2EEEWEEWWEEE2WEEEEEEEEE2EEWEEEWEEEEEEEEEEEEWEEEWEEWEEEEEEEEE2WEEEWWEE0EEE1W0EE0EWEW0EWEEWEWWEWEWEEE1EEEEEW1EEEE1EEEEWWWEEEWEEEWEEEWEEEEEEEEEEEE2EEEWEEE1EEE21WEEEE2EEEEWWEEEEE0EEEWEWEW1EWEEWEEEE1EW2EEEEEE2WEEEEE1EEEEE0EE11E2EE0EEEEE1EE1W0WWWEEWEEEEE0EE2EWWEE1EEEEEWEEEEE10EEEEEE0WEWEEEEWEEEEEEEEEWEEEEEEWEEEE1EEWEEEEEWEEEEEEEE0EEEEEWEEWEEEE1EE1EEEEE1EEEEEEEE1EEEEEWEE2EEEE1EEEEEEWEEEEEEEEEEW0W2EEWE11EE2EEEE2EE0EEEW2EEWEEEE2EEEEEEEEE0EWEEEEWEWEEEEEEEEE1EEEE1EE12EEEWEE0EEEEWEE22EWEE0WW0EEEEEEEEEEWEEEEWEEEE2EEE1EEEEEEEEW0E0W2E2WEEEEE0EE0EE0EE1EEEEEW2E1W1E2WEEEEEEEEWEEEWEEEEWEEEEWEEEEEEEEEEEEEEEEW1EEEWEEE2EEEWE3EEEEEEEEEEE0EEEEWEEEEEWE0EE0EWEEEEE1EEEE1EEEEEEEEEEE3E1EEEWEEEWEEEWWEEEEEEEEE2EEEE2E2EEEWEEE2EEEEWEEW1EEEEEEWEEEEEEEE1EEEE1EE1WEE2EEEEWEEEEEEEE1EEEEEE0WEEWEEEE2EEEWEEE1EWEEEE1EEE2EE2EEEEEEWEE1EEEE2EEEEEWWWEEE2EE0EWWEEWEEEEEWEEEEWEEEEEWEEWWE2EEWEEEWWWEEEEE1EEEE1EEWEEEEEE2EE1EEEEE22EEEEEEE2EEEEEEWEEEEEEEEEEEWEEEWEEE2WWEEEEE2EEEEWEEEEEW0WEEEWEEEWEEEEEEEEEEE0EEEEEEWEEEEEEE22EEEEE2EE3EEEEEEEEEEEWWEEEE2EEEEEEEWEEWEEEEEEEEEEEEEWEE1EEEEEEEEEEEEE2EEWEEEEEEEWEEEEW0EEEEEEEEEEE1EEWEEE1EEEE2EWEEEEEWW0EEEEE1W3EEEEEE0E0EEEEEEEEEEEEEEWEE2EEEEEEEEEEEEEEWW1EEEEEE1W2EEEEEW11EEEEEWE1EEEE1EEEEEEEEEWE10EEEEEEE1EEE2EEEWEEEEEEE1EEE2EEEWEEEEE2WEEEEEWEEE1EEEWEEEEEEE2EEE2EEEWEEEEEEE12EWEEEEEEEEEEE2WEEEWEE1EEEEEEE1EEEEEEE0EEEEEEE1EEEEEEEWEEEEEEEEEEEEWEEEEEEE0EEEEEEEWEEEEEEE0EEEEEEE2EEWEEEW0EEEEEEEEEEEWEEEEEEEE0EEEWEEEWEEE3EEE1EEEWEEE1EEEWEEEEEEEE0EEE2EEEWEEE1EEE2EEEWEEEWEEE2EEEEEEEE1EEEEEEEEEWW10WWEWWWWWEEE1WWWWWWWWWWWWWWWWWWWWWWWWWWWWW1EEEEEE1WWWWWWWWW1WWWWWWWWWWWWWWWWWWW1EEEWWW1WEWWWWW1EEE1EE1EEEEEEEEEEEEEEEEEEEEEEEWEEW2EEEEEEEEWEEEEEEW0EEEEEEWEEEEEEEEWWEEWEEEEEEEEEEEEEEEEEEEEEEE2EEWEEEEEEEEEEWEEE1EEEWEEEE1WWWEEEEWEEEEEEEEEEEEWEEEEEEEEEEEEEE2EEEEEEEEEEEE1EEEEWWW1EEEE1EEE2EEEWEEEEEEEEWEEEEEEWWEEEE0EWEEE2EEEEEE1EE2EEEEEEWWW1EEEEEWEEEEEEEE0EEEEEWWWWEEEEEE0EEWEEEEEE1EEEWEWEEEEW2EEEEEEWEEEW1EEEWE1EEE1EEEEWEEWWEE1EEEEEW0EE0EEWEEEEE0EEEEEEEE0EEEEE1EEWEE00EEEEE1EEWWEE0EEEE2EEEWEWEEEW1EEEEEE11EEEWE1EEEWEEEEWEEW0EEWEEEEEW0EE1EEWEEEEE0EE10W1EEWEEEEEWEE1EEW0EEEEE1EEWWEE0EEEE0EEE1EWEEE1WEEE1EEEEEE1WEEEE3EWEEE2EEEEEE1EE0EEEEEEWWWWEEEEEWEEEEEEEE1EEEEEWW0WEEEEEEWEEWEEEEEE1EEEWEWEEEEWWEEEEEE2EEEEEEEE2EEEWEEE1EEEEWWWWEEEEWEEEEEEEEEEEE2EEEEEEEEEEEEEEWEEEEEEEEEEEE1EEEE1WWWEEEEWEEE1EEE1EEEEEEEEEE1EEWEEEEEEEEEEEEEEEEEEEEEEEWEE1WEEEEEEEE1EEEEEE1WEEEEEE0EEEEEEEE1WEEWEEEEEEEEEEEEEEEEEEEEEEEWEE2EE",
        "10x18:1EEEEEEEEEEEEEEEEE2EEE1EEEE1EEEEEEEE1EEEEEEE2EWEEEEEEEEEEEEEEEEEEEEEEEEEEWEE1EEEEEEEEEE1EEEEWEEEEEEEEEE1EE2EEEEEEEEEEEEEEEEEEEEEEEEEE1E2EEEEEEEWEEEEEEEE2EEEE1EEE2EEEEEEEEEEEEEEEEE1",
        "20x36:EEEEEEEEEEEEEEEEEEEEEEWEEE3EEEWEEE1EEE0EEWEEE1EEE1EEE2EEE1EEEEE1EEE2EEEWEEEWEEEEEEEEWEEE2EEEWEEE2EEEEE0EEEWEEEWEEE2EEEWEEWEEE1EEE2EEE1EEE1EEEEE1EEEWEEE2EEE1EEEEEEEE3EEE1EEE1EEE1EEEEE1EEE1EEE1EEE1EEE1EEWEEE1EEEWEEE1EEE2EEEEE1EEEWEEE0EEE2EEEEEEEE1EEEWEEEWEEE2EEEEE1EEE1EEE1EEE2EEE1EEWEEEWEEEWEEE3EEEWEEEEE2EEE1EEE1EEEWEEEEEEEE1EEE2EEEWEEE2EEEEEWEEE2EEE2EEE1EEE1EE1EEE2EEE2EEE0EEE1EEEEE1EEE1EEE2EEE1EEEEEEEE2EEEWEEE2EEEWEEEEE1EEE1EEEWEEE1EEE1EE1EEE1EEE1EEE2EEE2EEEEE2EEE1EEEWEEEWEEEEEEEE1EEE2EEE2EEE1EEEEEWEEE1EEE2EEE0EEEWEE0EEE2EEEWEEEWEEE1EEEEEWEEEWEEEWEEE1EEEEEEEE1EEEWEEE1EEEWEEEEE2EEEWEEE1EEE1EEE2EEWEEE2EEE2EEE1EEE2EEEEE2EEE2EEEWEEEWEEEEEEEEWEEE1EEE1EEE0EEEEEWEEEWEEE1EEEWEEE1EE4EEEWEEE1EEEWEEE1EEEEEEEEEEEEEEEEEEEEEE",
        "20x36:00000000000000000000EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWEEEWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWEEEEEEEWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWEEEEEEEEEEEWEEEEEEEEEEEEEEEEEEEEEEEEEWEEEEEEEEEEEEEEEWEEEEEEEEEEEEEEEEEEEEEWEEEEEEEEEE0EWEWEWEWEWEWEWE0EWEEEEEEEEEEEEEEEEEEEEWWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWWEWWWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWWWEWWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWWEEEEEEEEEEEEEEEEEEEEWE0EWEWEWEWEWEWEWE0EEEEEEEEEEWEEEEEEEEEEEEEEEEEEEEEWEEEEEEEEEEEEEEEWEEEEEEEEEEEEEEEEEEEEEEEEEWEEEEEEEEEEEWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWEEEEEEEWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWEEEWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE00000000000000000000"
    };
    public Sprite img0, img1, img2, img3, img4, imgB, imgB2, imgE, imgL, imgW, imgXE, imgXL;
    public GameObject whatToSpawnPrefab;
    private LightUp LightUpManager;

    public void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
    }

    public void SelectPuzzle()
    {
        string[] splitLevelName = EventSystem.current.currentSelectedGameObject.name.Split('-');
        string[] splitPuzzle = puzzles[int.Parse(splitLevelName[1]) - 1].Split('x', ':');
        LightUpManager.mapX = short.Parse(splitPuzzle[0]);
        LightUpManager.mapY = short.Parse(splitPuzzle[1]);
        char[] map = splitPuzzle[2].ToCharArray();
        int i = 0, j = 0;
        Vector3 pos;
        GameObject newTile;
        var posX = -375f;
        var posY = 375f;
        foreach (var letra in map)
        {
            switch (letra)
            {
                //0 1 2 3 4 B B2 E L W XE XL
                case '0':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = img0;
                    break;
                case '1':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = img1;
                    break;
                case '2':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = img2;
                    break;
                case '3':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = img3;
                    break;
                case '4':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = img4;
                    break;
                case 'B':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = imgB;
                    break;
                case 'E':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = imgE;
                    break;
                case 'W':
                    pos = new Vector3(posX, posY, 0f);
                    newTile = Instantiate(whatToSpawnPrefab, pos, transform.rotation);
                    newTile.transform.SetParent(GameObject.Find("CanvasDynamic").transform, false);
                    newTile.name = "tile-" + i + "-" + j;
                    newTile.gameObject.transform.GetComponent<Image>().sprite = imgW;
                    break;
            }
            posX += 125f;
            j++;
            if (j == LightUpManager.mapX)
            {
                posX = -375f;
                posY -= 125f;
                j = 0;
                i++;
            }
        }
        //LightUpManager.ChangeTabs("playMode");
    }
}
