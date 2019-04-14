using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventData  {

    public static OctoGameType.GameEvent DrinksDefAddEvent = new OctoGameType.GameEvent("知名動漫與本土連鎖飲料橙汁內推出聯名吸管，供不應求"
        , OctoGameType.StoreType.Drinks, 50);

    public static OctoGameType.GameEvent FoodsDefAddEvent = new OctoGameType.GameEvent("科學家發明吃東西不會辣的軟膏，大家爭相嘗鮮，麻辣鍋生意大漲"
        , OctoGameType.StoreType.Foods, 50);

    public static OctoGameType.GameEvent ApparelsDefAddEvent = new OctoGameType.GameEvent("一年一度的光頭節，只要頂上無毛，不論當季過季商品都買一送十，婆婆媽媽不惜剃成光頭也要搶一波便宜服飾"
        , OctoGameType.StoreType.Apparels, 50);


    public static OctoGameType.GameEvent DrinksDefSubtractEvent = new OctoGameType.GameEvent("知名網紅演唱新歌\"大腳桶\"，但因為涉嫌抄襲國外原創單曲，引起年輕族群反復古飲料風潮"
       , OctoGameType.StoreType.Drinks, -50);

    public static OctoGameType.GameEvent FoodsDefSubtractEvent = new OctoGameType.GameEvent("毒蛋事件人心惶惶，雞蛋糕公會仍堅持宣稱雞蛋糕絕無添加任何天然雞蛋，所以不會有毒，各地雞蛋糕客仍半信半疑"
        , OctoGameType.StoreType.Foods, -50);

    public static OctoGameType.GameEvent ApparelsDefSubtractEvent = new OctoGameType.GameEvent("下海有優惠！知名夜市拍賣者\"下海哥\"近日在海邊舉辦快閃活動-\"下海濕幾件，半價就幾件\"，引起大量粉絲參與。不過參與下海的民眾常因為一次穿太多件而很難順利上岸，因而淹死了很多服裝店粉絲"
        , OctoGameType.StoreType.Apparels, -50);


    public static OctoGameType.GameEvent ResisitanceStartEventLv1 = new OctoGameType.GameEvent("ResisitanceStartEvent"
        , OctoGameType.StoreType.All, 0); //數值由ResisitanceManager特化負責


    public static OctoGameType.GameEvent ResisitanceStartEventLv2 = new OctoGameType.GameEvent("ResisitanceStartEvent Next (LV2)"
        , OctoGameType.StoreType.All, 0); //數值由ResisitanceManager特化負責

    public static OctoGameType.GameEvent ResisitanceStartEventLv3 = new OctoGameType.GameEvent("ResisitanceStartEvent Next (LV3)"
       , OctoGameType.StoreType.All, 0); //數值由ResisitanceManager特化負責
}
