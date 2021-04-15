using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbourhood : Place
{
    public Neighbourhood(string name, double lat, double lon)
    {
        displayName = name;
        latitude = lat;
        longitude = lon;
    }

    //Store neighbourhood-specific info
    public static Neighbourhood WestHumberClairville = new Neighbourhood("West Humber-Clairville", 43.713165283203125, -79.59501647949219);
    public static Neighbourhood MountOliveSilverstoneJamestown = new Neighbourhood("Mount Olive-Silverstone-Jamestown", 43.744873046875, -79.59306335449219);
    public static Neighbourhood ThistletownBeaumondHeights = new Neighbourhood("Thistletown-Beaumond Heights", 43.737648010253906, -79.56346893310547);
    public static Neighbourhood RexdaleKipling = new Neighbourhood("Rexdale-Kipling", 43.72358322143555, -79.56682586669922);
    public static Neighbourhood ElmsOldRexdale = new Neighbourhood("Elms-Old Rexdale", 43.72114562988281, -79.5484848022461);
    public static Neighbourhood KingsviewVillageTheWestway = new Neighbourhood("Kingsview Village-The Westway", 43.697410583496094, -79.54520416259766);
    public static Neighbourhood WillowridgeMartingroveRichview = new Neighbourhood("Willowridge-Martingrove-Richview", 43.683353424072266, -79.55520629882812);
    public static Neighbourhood HumberHeightsWestmount = new Neighbourhood("Humber Heights-Westmount", 43.69316864013672, -79.52312469482422);
    public static Neighbourhood EdenbridgeHumberValley = new Neighbourhood("Edenbridge-Humber Valley", 43.670108795166016, -79.5213394165039);
    public static Neighbourhood PrincessRosethorn = new Neighbourhood("Princess-Rosethorn", 43.665061950683594, -79.54405212402344);
    public static Neighbourhood EringateCentennialWestDeane = new Neighbourhood("Eringate-Centennial-West Deane", 43.65760040283203, -79.58052062988281);
    public static Neighbourhood MarklandWood = new Neighbourhood("Markland Wood", 43.63292694091797, -79.57304382324219);
    public static Neighbourhood EtobicokeWestMall = new Neighbourhood("Etobicoke West Mall", 43.64509582519531, -79.56883239746094);
    public static Neighbourhood IslingtonCityCentreWest = new Neighbourhood("Islington-City Centre West", 43.642642974853516, -79.53729248046875);
    public static Neighbourhood KingswaySouth = new Neighbourhood("Kingsway South", 43.65349197387695, -79.50820922851562);
    public static Neighbourhood StonegateQueensway = new Neighbourhood("Stonegate-Queensway", 43.63494110107422, -79.50135803222656);
    public static Neighbourhood MimicoincludesHumberBayShores = new Neighbourhood("Mimico (includes Humber Bay Shores)", 43.615482330322266, -79.50027465820312);
    public static Neighbourhood NewToronto = new Neighbourhood("New Toronto", 43.6003532409668, -79.51111602783203);
    public static Neighbourhood LongBranch = new Neighbourhood("Long Branch", 43.592315673828125, -79.53368377685547);
    public static Neighbourhood Alderwood = new Neighbourhood("Alderwood", 43.604881286621094, -79.54170989990234);

    public static Neighbourhood HumberSummit = new Neighbourhood("Humber Summit", 43.75946044921875, -79.55706024169922);
    public static Neighbourhood Humbermede = new Neighbourhood("Humbermede", 43.742183685302734, -79.54190063476562);
    public static Neighbourhood PelmoParkHumberlea = new Neighbourhood("Pelmo Park-Humberlea", 43.714813961983, -79.5299279616753);
    public static Neighbourhood BlackCreek = new Neighbourhood("Black Creek", 43.765872955322266, -79.51968383789062);
    public static Neighbourhood GlenfieldJaneHeights = new Neighbourhood("Glenfield-Jane Heights", 43.74549865722656, -79.51351928710938);
    public static Neighbourhood DownsviewRodingCFB = new Neighbourhood("Downsview-Roding-CFB", 43.73141860961914, -79.4930419921875);
    public static Neighbourhood YorkUniversityHeights = new Neighbourhood("York University Heights", 43.7649617769749, -79.4940841539049);
    public static Neighbourhood Rustic = new Neighbourhood("Rustic", 43.711788177490234, -79.49748992919922);
    public static Neighbourhood MapleLeaf = new Neighbourhood("Maple Leaf", 43.71546173095703, -79.48094940185547);
    public static Neighbourhood BrookhavenAmesbury = new Neighbourhood("Brookhaven-Amesbury", 43.70072937011719, -79.48483276367188);
    public static Neighbourhood YorkdaleGlenPark = new Neighbourhood("Yorkdale-Glen Park", 43.71609878540039, -79.4573974609375);
    public static Neighbourhood EnglemountLawrence = new Neighbourhood("Englemount-Lawrence", 43.72050857543945, -79.43740844726562);
    public static Neighbourhood ClantonPark = new Neighbourhood("Clanton Park", 43.742759704589844, -79.44693756103516);
    public static Neighbourhood BathurstManor = new Neighbourhood("Bathurst Manor", 43.765167236328125, -79.45532989501953);
    public static Neighbourhood WestminsterBranson = new Neighbourhood("Westminster-Branson", 43.77915573120117, -79.45269012451172);
    public static Neighbourhood NewtonbrookWest = new Neighbourhood("Newtonbrook West", 43.78539276123047, -79.4312744140625);
    public static Neighbourhood WillowdaleWest = new Neighbourhood("Willowdale West", 43.772132873535156, -79.42571258544922);
    public static Neighbourhood LansingWestgate = new Neighbourhood("Lansing-Westgate", 43.75436019897461, -79.42453002929688);
    public static Neighbourhood BedfordParkNortown = new Neighbourhood("Bedford Park-Nortown", 43.73137664794922, -79.4211654663086);
    public static Neighbourhood StAndrewWindfields = new Neighbourhood("St.Andrew-Windfields", 43.7560312016808, -79.3791273502423);

    public static Neighbourhood BridlePathSunnybrookYorkMills = new Neighbourhood("Bridle Path-Sunnybrook-York Mills", 43.7298583984375, -79.3740234375);
    public static Neighbourhood BanburyDonMills = new Neighbourhood("Banbury-Don Mills", 43.7380256652832, -79.3494873046875);
    public static Neighbourhood VictoriaVillage = new Neighbourhood("Victoria Village", 43.728336334228516, -79.31478881835938);
    public static Neighbourhood FlemingdonPark = new Neighbourhood("Flemingdon Park", 43.7120246887207, -79.33027648925781);
    public static Neighbourhood ParkwoodsDonalda = new Neighbourhood("Parkwoods-Donalda", 43.75599670410156, -79.32954406738281);
    public static Neighbourhood PleasantView = new Neighbourhood("Pleasant View", 43.787559509277344, -79.33480834960938);
    public static Neighbourhood DonValleyVillage = new Neighbourhood("Don Valley Village", 43.783897399902344, -79.35287475585938);
    public static Neighbourhood HillcrestVillage = new Neighbourhood("Hillcrest Village", 43.802879333496094, -79.35521697998047);
    public static Neighbourhood BayviewWoodsSteeles = new Neighbourhood("Bayview Woods-Steeles", 43.79585647583008, -79.38314819335938);
    public static Neighbourhood NewtonbrookEast = new Neighbourhood("Newtonbrook East", 43.7914924621582, -79.40629577636719);
    public static Neighbourhood WillowdaleEast = new Neighbourhood("Willowdale East", 43.77063751220703, -79.40247344970703);
    public static Neighbourhood BayviewVillage = new Neighbourhood("Bayview Village", 43.776268005371094, -79.3785400390625);
    public static Neighbourhood HenryFarm = new Neighbourhood("Henry Farm", 43.77103042602539, -79.34063720703125);
    public static Neighbourhood OConnorParkview = new Neighbourhood("O'Connor-Parkview", 43.70771789550781, -79.31116485595703);
    public static Neighbourhood ThorncliffePark = new Neighbourhood("Thorncliffe Park", 43.70827102661133, -79.34967041015625);
    public static Neighbourhood LeasideBennington = new Neighbourhood("Leaside-Bennington", 43.707157135009766, -79.367431640625);
    public static Neighbourhood BroadviewNorth = new Neighbourhood("Broadview North", 43.688560485839844, -79.35527801513672);
    public static Neighbourhood OldEastYork = new Neighbourhood("Old East York", 43.696449279785156, -79.33545684814453);
    public static Neighbourhood DanforthEastYork = new Neighbourhood("Danforth-East York", 43.6900121929735, -79.3298443091676);
    public static Neighbourhood WoodbineLumsden = new Neighbourhood("Woodbine-Lumsden", 43.69453430175781, -79.31195831298828);

    public static Neighbourhood TaylorMassey = new Neighbourhood("Taylor-Massey", 43.69656753540039, -79.29638671875);
    public static Neighbourhood EastEndDanforth = new Neighbourhood("East End-Danforth", 43.688377380371094, -79.2950210571289);
    public static Neighbourhood TheBeaches = new Neighbourhood("The Beaches", 43.671119689941406, -79.2992935180664);
    public static Neighbourhood WoodbineCorridor = new Neighbourhood("Woodbine Corridor", 43.67714309692383, -79.31573486328125);
    public static Neighbourhood GreenwoodCoxwell = new Neighbourhood("Greenwood-Coxwell", 43.672698974609375, -79.32433319091797);
    public static Neighbourhood Danforth = new Neighbourhood("Danforth", 43.68364715576172, -79.33065032958984);
    public static Neighbourhood PlayterEstatesDanforth = new Neighbourhood("Playter Estates-Danforth", 43.67943572998047, -79.35504150390625);
    public static Neighbourhood NorthRiverdale = new Neighbourhood("North Riverdale", 43.67112731933594, -79.35106658935547);
    public static Neighbourhood BlakeJones = new Neighbourhood("Blake-Jones", 43.67619323730469, -79.33739471435547);
    public static Neighbourhood SouthRiverdale = new Neighbourhood("South Riverdale", 43.65065002441406, -79.33999633789062);
    public static Neighbourhood CabbagetownSouthStJamesTown = new Neighbourhood("Cabbagetown-South St. James Town", 43.667633056640625, -79.3660659790039);
    public static Neighbourhood RegentPark = new Neighbourhood("Regent Park", 43.66065216064453, -79.36048889160156);
    public static Neighbourhood MossPark = new Neighbourhood("Moss Park", 43.65620803833008, -79.3674545288086);
    public static Neighbourhood NorthStJamesTown = new Neighbourhood("North St. James Town", 43.6697883605957, -79.37480926513672);
    public static Neighbourhood ChurchYongeCorridor = new Neighbourhood("Church-Yonge Corridor", 43.65983581542969, -79.37847900390625);
    public static Neighbourhood BayStreetCorridor = new Neighbourhood("Bay Street Corridor", 43.657772064208984, -79.38618469238281);
    public static Neighbourhood WaterfrontCommunitiesTheIsland = new Neighbourhood("Waterfront Communities-The Island", 43.63925552368164, -79.37921905517578);
    public static Neighbourhood KensingtonChinatown = new Neighbourhood("Kensington-Chinatown", 43.65308380126953, -79.39724731445312);
    public static Neighbourhood University = new Neighbourhood("University", 43.6627225464794, -79.4015021891874);
    public static Neighbourhood PalmerstonLittleItaly = new Neighbourhood("Palmerston-Little Italy", 43.659427642822266, -79.41729736328125);

    public static Neighbourhood TrinityBellwoods = new Neighbourhood("Trinity-Bellwoods", 43.649810791015625, -79.41563415527344);
    public static Neighbourhood Niagara = new Neighbourhood("Niagara", 43.64347839355469, -79.40826416015625);
    public static Neighbourhood DufferinGrove = new Neighbourhood("Dufferin Grove", 43.6548591051871, -79.4371813081079);
    public static Neighbourhood LittlePortugal = new Neighbourhood("Little Portugal", 43.64776611328125, -79.42911529541016);
    public static Neighbourhood SouthParkdale = new Neighbourhood("South Parkdale", 43.63629913330078, -79.43846130371094);
    public static Neighbourhood Roncesvalles = new Neighbourhood("Roncesvalles", 43.64613342285156, -79.44277954101562);
    public static Neighbourhood HighParkSwansea = new Neighbourhood("High Park-Swansea", 43.64570236206055, -79.4670181274414);
    public static Neighbourhood HighParkNorth = new Neighbourhood("High Park North", 43.65731430053711, -79.46633911132812);
    public static Neighbourhood RunnymedeBloorWestVillage = new Neighbourhood("Runnymede-Bloor West Village", 43.65935516357422, -79.48542785644531);
    public static Neighbourhood JunctionArea = new Neighbourhood("Junction Area", 43.667152404785156, -79.47119140625);
    public static Neighbourhood WestonPellamPark = new Neighbourhood("Weston-Pellam Park", 43.67402267456055, -79.4631576538086);
    public static Neighbourhood CorsoItaliaDavenport = new Neighbourhood("Corso Italia-Davenport", 43.67790603637695, -79.44523620605469);
    public static Neighbourhood DovercourtWallaceEmersonJunction = new Neighbourhood("Dovercourt-Wallace Emerson-Junction", 43.6654052734375, -79.43853759765625);
    public static Neighbourhood Wychwood = new Neighbourhood("Wychwood", 43.67667770385742, -79.42462158203125);
    public static Neighbourhood Annex = new Neighbourhood("Annex", 43.67242431640625, -79.40483093261719);
    public static Neighbourhood CasaLoma = new Neighbourhood("Casa Loma", 43.679847717285156, -79.41254425048828);
    public static Neighbourhood YongeStClair = new Neighbourhood("Yonge-St.Clair", 43.689701080322266, -79.39752197265625);
    public static Neighbourhood RosedaleMoorePark = new Neighbourhood("Rosedale-Moore Park", 43.68193435668945, -79.37940979003906);
    public static Neighbourhood MountPleasantEast = new Neighbourhood("Mount Pleasant East", 43.70505905151367, -79.38489532470703);
    public static Neighbourhood YongeEglinton = new Neighbourhood("Yonge-Eglinton", 43.704795837402344, -79.40341186523438);

    public static Neighbourhood ForestHillSouth = new Neighbourhood("Forest Hill South", 43.69449234008789, -79.41431427001953);
    public static Neighbourhood ForestHillNorth = new Neighbourhood("Forest Hill North", 43.704010009765625, -79.42815399169922);
    public static Neighbourhood LawrenceParkSouth = new Neighbourhood("Lawrence Park South", 43.71698760986328, -79.40583038330078);
    public static Neighbourhood MountPleasantWest = new Neighbourhood("Mount Pleasant West", 43.704288482666016, -79.39330291748047);
    public static Neighbourhood LawrenceParkNorth = new Neighbourhood("Lawrence Park North", 43.730369567871094, -79.40306854248047);
    public static Neighbourhood HumewoodCedarvale = new Neighbourhood("Humewood-Cedarvale", 43.69010925292969, -79.4276351928711);
    public static Neighbourhood OakwoodVillage = new Neighbourhood("Oakwood Village", 43.6908073425293, -79.43748474121094);
    public static Neighbourhood BriarHillBelgravia = new Neighbourhood("Briar Hill - Belgravia", 43.69948196411133, -79.45464324951172);
    public static Neighbourhood CaledoniaFairbank = new Neighbourhood("Caledonia-Fairbank", 43.6885986328125, -79.45484924316406);
    public static Neighbourhood KeelesdaleEglintonWest = new Neighbourhood("Keelesdale-Eglinton West", 43.68527603149414, -79.47122192382812);
    public static Neighbourhood RockcliffeSmythe = new Neighbourhood("Rockcliffe-Smythe", 43.67424774169922, -79.49485778808594);
    public static Neighbourhood BeechboroughGreenbrook = new Neighbourhood("Beechborough-Greenbrook", 43.69281768798828, -79.4802017211914);
    public static Neighbourhood Weston = new Neighbourhood("Weston", 43.70175552368164, -79.51432037353516);
    public static Neighbourhood LambtonBabyPoint = new Neighbourhood("Lambton Baby Point", 43.6563550946296, -79.4952598328673);
    public static Neighbourhood MountDennis = new Neighbourhood("Mount Dennis", 43.688472747802734, -79.5001220703125);
    public static Neighbourhood Steeles = new Neighbourhood("Steeles", 43.81217575073242, -79.32637786865234);
    public static Neighbourhood LAmoreaux = new Neighbourhood("L'Amoreaux", 43.79219436645508, -79.3138656616211);
    public static Neighbourhood TamOShanterSullivan = new Neighbourhood("Tam O'Shanter-Sullivan", 43.77798080444336, -79.31124114990234);
    public static Neighbourhood WexfordMaryvale = new Neighbourhood("Wexford/Maryvale", 43.748538970947266, -79.29878234863281);
    public static Neighbourhood ClairleaBirchmount = new Neighbourhood("Clairlea-Birchmount", 43.7161979675293, -79.28279113769531);

    public static Neighbourhood Oakridge = new Neighbourhood("Oakridge", 43.69758605957031, -79.27957153320312);
    public static Neighbourhood BirchcliffeCliffside = new Neighbourhood("Birchcliffe-Cliffside", 43.69552230834961, -79.26456451416016);
    public static Neighbourhood Cliffcrest = new Neighbourhood("Cliffcrest", 43.72130584716797, -79.23560333251953);
    public static Neighbourhood KennedyPark = new Neighbourhood("Kennedy Park", 43.72478103637695, -79.26162719726562);
    public static Neighbourhood Ionview = new Neighbourhood("Ionview", 43.73506164550781, -79.27039337158203);
    public static Neighbourhood DorsetPark = new Neighbourhood("Dorset Park", 43.758033752441406, -79.28008270263672);
    public static Neighbourhood Bendale = new Neighbourhood("Bendale", 43.76324462890625, -79.25562286376953);
    public static Neighbourhood AgincourtSouthMalvernWest = new Neighbourhood("Agincourt South-Malvern West", 43.78655242919922, -79.2702865600586);
    public static Neighbourhood AgincourtNorth = new Neighbourhood("Agincourt North", 43.80495071411133, -79.26618957519531);
    public static Neighbourhood Milliken = new Neighbourhood("Milliken", 43.8189811706543, -79.281005859375);
    public static Neighbourhood Rouge = new Neighbourhood("Rouge", 43.82293701171875, -79.17745208740234);
    public static Neighbourhood Malvern = new Neighbourhood("Malvern", 43.80220031738281, -79.22386932373047);
    public static Neighbourhood CentennialScarborough = new Neighbourhood("Centennial Scarborough", 43.781917572021484, -79.1472396850586);
    public static Neighbourhood HighlandCreek = new Neighbourhood("Highland Creek", 43.790443420410156, -79.1761474609375);
    public static Neighbourhood Morningside = new Neighbourhood("Morningside", 43.78215026855469, -79.20699310302734);
    public static Neighbourhood WestHill = new Neighbourhood("West Hill", 43.768436431884766, -79.17540740966797);
    public static Neighbourhood Woburn = new Neighbourhood("Woburn", 43.766441345214844, -79.22850799560547);
    public static Neighbourhood EglintonEast = new Neighbourhood("Eglinton East", 43.740135192871094, -79.244140625);
    public static Neighbourhood ScarboroughVillage = new Neighbourhood("Scarborough Village", 43.738651275634766, -79.21421813964844);
    public static Neighbourhood Guildwood = new Neighbourhood("Guildwood", 43.749420166015625, -79.19461822509766);

    public static Neighbourhood[] allNeighbourhoodsInNumericalOrder = {
    WestHumberClairville,
    MountOliveSilverstoneJamestown,
    ThistletownBeaumondHeights,
    RexdaleKipling,
    ElmsOldRexdale,
    KingsviewVillageTheWestway,
    WillowridgeMartingroveRichview,
    HumberHeightsWestmount,
    EdenbridgeHumberValley,
    PrincessRosethorn,
    EringateCentennialWestDeane,
    MarklandWood,
    EtobicokeWestMall,
    IslingtonCityCentreWest,
    KingswaySouth,
    StonegateQueensway,
    MimicoincludesHumberBayShores,
    NewToronto,
    LongBranch,
    Alderwood,

    HumberSummit,
    Humbermede,
    PelmoParkHumberlea,
    BlackCreek,
    GlenfieldJaneHeights,
    DownsviewRodingCFB,
    YorkUniversityHeights,
    Rustic,
    MapleLeaf,
    BrookhavenAmesbury,
    YorkdaleGlenPark,
    EnglemountLawrence,
    ClantonPark,
    BathurstManor,
    WestminsterBranson,
    NewtonbrookWest,
    WillowdaleWest,
    LansingWestgate,
    BedfordParkNortown,
    StAndrewWindfields,

    BridlePathSunnybrookYorkMills,
    BanburyDonMills,
    VictoriaVillage,
    FlemingdonPark,
    ParkwoodsDonalda,
    PleasantView,
    DonValleyVillage,
    HillcrestVillage,
    BayviewWoodsSteeles,
    NewtonbrookEast,
    WillowdaleEast,
    BayviewVillage,
    HenryFarm,
    OConnorParkview,
    ThorncliffePark,
    LeasideBennington,
    BroadviewNorth,
    OldEastYork,
    DanforthEastYork,
    WoodbineLumsden,

    TaylorMassey,
    EastEndDanforth,
    TheBeaches,
    WoodbineCorridor,
    GreenwoodCoxwell,
    Danforth,
    PlayterEstatesDanforth,
    NorthRiverdale,
    BlakeJones,
    SouthRiverdale,
    CabbagetownSouthStJamesTown,
    RegentPark,
    MossPark,
    NorthStJamesTown,
    ChurchYongeCorridor,
    BayStreetCorridor,
    WaterfrontCommunitiesTheIsland,
    KensingtonChinatown,
    University,
    PalmerstonLittleItaly,

    TrinityBellwoods,
    Niagara,
    DufferinGrove,
    LittlePortugal,
    SouthParkdale,
    Roncesvalles,
    HighParkSwansea,
    HighParkNorth,
    RunnymedeBloorWestVillage,
    JunctionArea,
    WestonPellamPark,
    CorsoItaliaDavenport,
    DovercourtWallaceEmersonJunction,
    Wychwood,
    Annex,
    CasaLoma,
    YongeStClair,
    RosedaleMoorePark,
    MountPleasantEast,
    YongeEglinton,

    ForestHillSouth,
    ForestHillNorth,
    LawrenceParkSouth,
    MountPleasantWest,
    LawrenceParkNorth,
    HumewoodCedarvale,
    OakwoodVillage,
    BriarHillBelgravia,
    CaledoniaFairbank,
    KeelesdaleEglintonWest,
    RockcliffeSmythe,
    BeechboroughGreenbrook,
    Weston,
    LambtonBabyPoint,
    MountDennis,
    Steeles,
    LAmoreaux,
    TamOShanterSullivan,
    WexfordMaryvale,
    ClairleaBirchmount,

    Oakridge,
    BirchcliffeCliffside,
    Cliffcrest,
    KennedyPark,
    Ionview,
    DorsetPark,
    Bendale,
    AgincourtSouthMalvernWest,
    AgincourtNorth,
    Milliken,
    Rouge,
    Malvern,
    CentennialScarborough,
    HighlandCreek,
    Morningside,
    WestHill,
    Woburn,
    EglintonEast,
    ScarboroughVillage,
    Guildwood
    };

    public static Neighbourhood[] allNeighbourhoodsInAlphabeticalOrder = {
    AgincourtNorth,
    AgincourtSouthMalvernWest,
    Alderwood,
    Annex,

    BanburyDonMills,
    BathurstManor,
    BayStreetCorridor,
    BayviewVillage,
    BayviewWoodsSteeles,
    BedfordParkNortown,
    BeechboroughGreenbrook,
    Bendale,
    BirchcliffeCliffside,
    BlackCreek,
    BlakeJones,
    BriarHillBelgravia,
    BridlePathSunnybrookYorkMills,
    BroadviewNorth,
    BrookhavenAmesbury,

    CabbagetownSouthStJamesTown,
    CaledoniaFairbank,
    CasaLoma,
    CentennialScarborough,
    ChurchYongeCorridor,
    ClairleaBirchmount,
    ClantonPark,
    Cliffcrest,
    CorsoItaliaDavenport,

    Danforth,
    DanforthEastYork,
    DonValleyVillage,
    DorsetPark,
    DovercourtWallaceEmersonJunction,
    DownsviewRodingCFB,
    DufferinGrove,

    EastEndDanforth,
    EdenbridgeHumberValley,
    EglintonEast,
    ElmsOldRexdale,
    EnglemountLawrence,
    EringateCentennialWestDeane,
    EtobicokeWestMall,

    FlemingdonPark,
    ForestHillNorth,
    ForestHillSouth,

    GlenfieldJaneHeights,
    GreenwoodCoxwell,
    Guildwood,

    HenryFarm,
    HighParkNorth,
    HighParkSwansea,
    HighlandCreek,
    HillcrestVillage,
    HumberHeightsWestmount,
    HumberSummit,
    Humbermede,
    HumewoodCedarvale,

    Ionview,
    IslingtonCityCentreWest,

    JunctionArea,

    KeelesdaleEglintonWest,
    KennedyPark,
    KensingtonChinatown,
    KingsviewVillageTheWestway,
    KingswaySouth,

    LAmoreaux,
    LambtonBabyPoint,
    LansingWestgate,
    LawrenceParkNorth,
    LawrenceParkSouth,
    LeasideBennington,
    LittlePortugal,
    LongBranch,

    Malvern,
    MapleLeaf,
    MarklandWood,
    Milliken,
    MimicoincludesHumberBayShores,
    Morningside,
    MossPark,
    MountDennis,
    MountOliveSilverstoneJamestown,
    MountPleasantEast,
    MountPleasantWest,

    NewToronto,
    NewtonbrookEast,
    NewtonbrookWest,
    Niagara,
    NorthRiverdale,
    NorthStJamesTown,

    OConnorParkview,
    Oakridge,
    OakwoodVillage,
    OldEastYork,

    PalmerstonLittleItaly,
    ParkwoodsDonalda,
    PelmoParkHumberlea,
    PlayterEstatesDanforth,
    PleasantView,
    PrincessRosethorn,

    RegentPark,
    RexdaleKipling,
    RockcliffeSmythe,
    Roncesvalles,
    RosedaleMoorePark,
    Rouge,
    RunnymedeBloorWestVillage,
    Rustic,

    ScarboroughVillage,
    SouthParkdale,
    SouthRiverdale,
    StAndrewWindfields,
    Steeles,
    StonegateQueensway,

    TamOShanterSullivan,
    TaylorMassey,
    TheBeaches,
    ThistletownBeaumondHeights,
    ThorncliffePark,
    TrinityBellwoods,

    University,

    VictoriaVillage,

    WaterfrontCommunitiesTheIsland,
    WestHill,
    WestHumberClairville,
    WestminsterBranson,
    Weston,
    WestonPellamPark,
    WexfordMaryvale,
    WillowdaleEast,
    WillowdaleWest,
    WillowridgeMartingroveRichview,
    Woburn,
    WoodbineCorridor,
    WoodbineLumsden,
    Wychwood,

    YongeEglinton,
    YongeStClair,
    YorkUniversityHeights,
    YorkdaleGlenPark
    };

    //Store neighbourhoods with highest CURRENT case count values
    public static List<Neighbourhood>[] neighbourhoodsWithMaxCaseCount = new List<Neighbourhood>[9];

    public static List<Neighbourhood> NeighbourhoodsWithMaxCaseCount(NeighbourhoodCaseDataType caseDataType)
    {
        return neighbourhoodsWithMaxCaseCount[(int)caseDataType];
    }

    //Store placedays with highest case count values EVER reported in history
    public static List<PlaceDay>[] placeDaysWithMaxCaseCount = new List<PlaceDay>[3];

    public static List<PlaceDay> PlaceDaysWithMaxCaseCount(NeighbourhoodDailyCaseDataType caseDataType)
    {
        return placeDaysWithMaxCaseCount[(int)caseDataType];
    }

    //Make the latest the default value for first episode date for the sake of finding the actual first episode date on record.
    public static DateTime firstEpisodeDate = DateTime.Today;
    //Make the oldest day the default value for last episode date for the sake of finding the actual last episode date on record.
    public static DateTime lastEpisodeDate;
    //Total place days is technically not total episode days, since the code auto generate & insert place days when no episode days are found on record.
    //The total episode days found on record should never be more than total place days.
    public static int totalPlaceDays;
}