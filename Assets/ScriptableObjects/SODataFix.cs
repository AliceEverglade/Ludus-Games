using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SODataFix : MonoBehaviour
{
    #region SOs
    [SerializeField] private PlayerSO Player;
    [SerializeField] private GameStateSO GameState;
    [SerializeField] private EncounterSO Forest1;
    [SerializeField] private EncounterSO Forest2;
    [SerializeField] private EncounterSO Desert1;
    [SerializeField] private EncounterSO Desert2;
    [SerializeField] private EncounterSO Mountain1;
    [SerializeField] private EncounterSO Mountain2;
    [SerializeField] private EncounterSO Mountain3;
    [SerializeField] private EnemySO Hedgehog;
    [SerializeField] private EnemySO Skunk;
    [SerializeField] private EnemySO FoxBandits;
    [SerializeField] private EnemySO KomodoDragon;
    [SerializeField] private EnemySO FennecFox;
    [SerializeField] private EnemySO Snake;
    [SerializeField] private EnemySO Raven;
    [SerializeField] private EnemySO Pidgeon;
    [SerializeField] private EnemySO Seagull;
    [SerializeField] private EnemySO Roc;

    #endregion
    #region PlayerStats
    public new string Playername;

    public bool PlayerisDead;
    public bool PlayerisDefending;

    public int PlayeractionPoints;

    public float PlayermaxHP;
    public float PlayercurrentHP;
    public float PlayermaxMana;
    public float PlayercurrentMana;
    public float PlayermeleeDamage;
    public float PlayerrangedDamage;
    public float Playermagic1Damage;
    public float Playermagic1ManaCost;
    public float Playermagic2Damage;
    public float Playermagic2ManaCost;
    public float PlayercritChance;
    public float PlayercritDamage;
    public float Playerdefense;
    public float Playerhealing;

    [SerializeField] public GameObject Playerprefab;
    #endregion
    #region GameStateStats
    private int GameStateEncounterIndex = 1;
    private List<EncounterSO> GameStateEncounterList;
    #endregion
    #region Forest1Stats
    private string Forest1name = "Forest 1";
    private bool Forest1isBossEncounter = false;

    private int Forest1index;

    private float Forest1difficultyModifier;

    private EnemySO Forest1enemy1;
    private EnemySO Forest1enemy2;

    private GameObject Forest1prefab;
    #endregion
    #region Forest2Stats
    private string Forest2name;
    private bool Forest2isBossEncounter;

    private int Forest2index;

    private float Forest2difficultyModifier;

    private EnemySO Forest2enemy1;
    private EnemySO Forest2enemy2;

    private GameObject Forest2prefab;
    #endregion
    #region Desert1Stats
    private string Desert1name;
    private bool Desert1isBossEncounter;

    private int Desert1index;

    private float Desert1difficultyModifier;

    private EnemySO Desert1enemy1;
    private EnemySO Desert1enemy2;

    private GameObject Desert1prefab;
    #endregion
    #region Desert2Stats
    private string Desert2name;
    private bool Desert2isBossEncounter;

    private int Desert2index;

    private float Desert2difficultyModifier;

    private EnemySO Desert2enemy1;
    private EnemySO Desert2enemy2;

    private GameObject Desert2prefab;
    #endregion
    #region Mountain1Stats
    private string Mountain1name;
    private bool Mountain1isBossEncounter;

    private int Mountain1index;

    private float Mountain1difficultyModifier;

    private EnemySO Mountain1enemy1;
    private EnemySO Mountain1enemy2;

    private GameObject Mountain1prefab;
    #endregion
    #region Mountain2Stats
    private string Mountain2name;
    private bool Mountain2isBossEncounter;

    private int Mountain2index;

    private float Mountain2difficultyModifier;

    private EnemySO Mountain2enemy1;
    private EnemySO Mountain2enemy2;

    private GameObject Mountain2prefab;
    #endregion
    #region Mountain3Stats
    private string Mountain3name;
    private bool Mountain3isBossEncounter;

    private int Mountain3index;

    private float Mountain3difficultyModifier;

    private EnemySO Mountain3enemy1;
    private EnemySO Mountain3enemy2;

    private GameObject Mountain3prefab;
    #endregion
    #region HedgehogStats
    private string Hedgehogname;

    private bool HedgehogisDead;
    private bool HedgehogisBoss;

    private int HedgehogactionPoints;

    private float HedgehogmaxHP;
    private float HedgehogcurrentHP;
    private float Hedgehogdamage;
    private float HedgehogspecialDamage;
    private float HedgehogcritChance;
    private float HedgehogcritDamage;
    private float Hedgehoghealing;

    private GameObject Hedgehogprefab;
    #endregion
    #region SkunkStats
    private string Skunkname;

    private bool SkunkisDead;
    private bool SkunkisBoss;

    private int SkunkactionPoints;

    private float SkunkmaxHP;
    private float SkunkcurrentHP;
    private float Skunkdamage;
    private float SkunkspecialDamage;
    private float SkunkcritChance;
    private float SkunkcritDamage;
    private float Skunkhealing;

    private GameObject Skunkprefab;
    #endregion
    #region FoxBanditsStats
    private string FoxBanditsname;

    private bool FoxBanditsisDead;
    private bool FoxBanditsisBoss;

    private int FoxBanditsactionPoints;

    private float FoxBanditsmaxHP;
    private float FoxBanditscurrentHP;
    private float FoxBanditsdamage;
    private float FoxBanditsspecialDamage;
    private float FoxBanditscritChance;
    private float FoxBanditscritDamage;
    private float FoxBanditshealing;

    private GameObject FoxBanditsprefab;
    #endregion
    #region KomodoDragonStats
    private string KomodoDragonname;

    private bool KomodoDragonisDead;
    private bool KomodoDragonisBoss;

    private int KomodoDragonactionPoints;

    private float KomodoDragonmaxHP;
    private float KomodoDragoncurrentHP;
    private float KomodoDragondamage;
    private float KomodoDragonspecialDamage;
    private float KomodoDragoncritChance;
    private float KomodoDragoncritDamage;
    private float KomodoDragonhealing;

    private GameObject KomodoDragonprefab;
    #endregion
    #region FennecFoxStats
    private string FennecFoxname;

    private bool FennecFoxisDead;
    private bool FennecFoxisBoss;

    private int FennecFoxactionPoints;

    private float FennecFoxmaxHP;
    private float FennecFoxcurrentHP;
    private float FennecFoxdamage;
    private float FennecFoxspecialDamage;
    private float FennecFoxcritChance;
    private float FennecFoxcritDamage;
    private float FennecFoxhealing;

    private GameObject FennecFoxprefab;
    #endregion
    #region SnakeStats
    private string Snakename;

    private bool SnakeisDead;
    private bool SnakeisBoss;

    private int SnakeactionPoints;

    private float SnakemaxHP;
    private float SnakecurrentHP;
    private float Snakedamage;
    private float SnakespecialDamage;
    private float SnakecritChance;
    private float SnakecritDamage;
    private float Snakehealing;

    private GameObject Snakeprefab;
    #endregion
    #region RavenStats
    private string Ravenname;

    private bool RavenisDead;
    private bool RavenisBoss;

    private int RavenactionPoints;

    private float RavenmaxHP;
    private float RavencurrentHP;
    private float Ravendamage;
    private float RavenspecialDamage;
    private float RavencritChance;
    private float RavencritDamage;
    private float Ravenhealing;

    private GameObject Ravenprefab;
    #endregion
    #region PidgeonStats
    private string Pidgeonname;

    private bool PidgeonisDead;
    private bool PidgeonisBoss;

    private int PidgeonactionPoints;

    private float PidgeonmaxHP;
    private float PidgeoncurrentHP;
    private float Pidgeondamage;
    private float PidgeonspecialDamage;
    private float PidgeoncritChance;
    private float PidgeoncritDamage;
    private float Pidgeonhealing;

    private GameObject Pidgeonprefab;
    #endregion
    #region SeagullStats
    private string Seagullname;

    private bool SeagullisDead;
    private bool SeagullisBoss;

    private int SeagullactionPoints;

    private float SeagullmaxHP;
    private float SeagullcurrentHP;
    private float Seagulldamage;
    private float SeagullspecialDamage;
    private float SeagullcritChance;
    private float SeagullcritDamage;
    private float Seagullhealing;

    private GameObject Seagullprefab;
    #endregion
    #region RocStats
    private string Rocname;

    private bool RocisDead;
    private bool RocisBoss;

    private int RocactionPoints;

    private float RocmaxHP;
    private float RoccurrentHP;
    private float Rocdamage;
    private float RocspecialDamage;
    private float RoccritChance;
    private float RoccritDamage;
    private float Rochealing;

    private GameObject Rocprefab;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region PlayerStats
        Player.name = Playername;

        Player.isDead = PlayerisDead;
        Player.isDefending = PlayerisDefending;

        Player.actionPoints = PlayeractionPoints;

        Player.maxHP = PlayermaxHP;
        Player.currentHP = PlayercurrentHP;
        Player.maxMana = PlayermaxMana;
        Player.currentMana = PlayercurrentMana;
        Player.meleeDamage = PlayermeleeDamage;
        Player.rangedDamage = PlayerrangedDamage;
        Player.magic1Damage = Playermagic1Damage;
        Player.magic1ManaCost = Playermagic1ManaCost;
        Player.magic2Damage = Playermagic2Damage;
        Player.magic2ManaCost = Playermagic2ManaCost;
        Player.critChance = PlayercritChance;
        Player.critDamage = PlayercritDamage;
        Player.defense = Playerdefense;
        Player.healing = Playerhealing;

        Player.prefab = Playerprefab;
        #endregion
        #region GameStateStats
        GameState.EncounterIndex = GameStateEncounterIndex;
        GameState.EncounterList = GameStateEncounterList;
        #endregion
        #region Forest1Stats
        Forest1.name = Forest1name;
        Forest1.isBossEncounter = Forest1isBossEncounter;

        Forest1.index = Forest1index;

        Forest1.difficultyModifier = Forest1difficultyModifier;

        Forest1.enemy1 = Forest1enemy1;
        Forest1.enemy2 = Forest1enemy2;

        Forest1.prefab = Forest1prefab;
        #endregion
        #region Forest2Stats
        Forest2.name = Forest2name;
        Forest2.isBossEncounter = Forest2isBossEncounter;

        Forest2.index = Forest2index;

        Forest2.difficultyModifier = Forest2difficultyModifier;

        Forest2.enemy1 = Forest2enemy1;
        Forest2.enemy2 = Forest2enemy2;

        Forest2.prefab = Forest2prefab;
        #endregion
        #region Desert1Stats
        Desert1.name = Desert1name;
        Desert1.isBossEncounter = Desert1isBossEncounter;

        Desert1.index = Desert1index;

        Desert1.difficultyModifier = Desert1difficultyModifier;

        Desert1.enemy1 = Desert1enemy1;
        Desert1.enemy2 = Desert1enemy2;

        Desert1.prefab = Desert1prefab;
        #endregion
        #region Desert2Stats
        Desert2.name = Desert2name;
        Desert2.isBossEncounter = Desert2isBossEncounter;

        Desert2.index = Desert2index;

        Desert2.difficultyModifier = Desert2difficultyModifier;

        Desert2.enemy1 = Desert2enemy1;
        Desert2.enemy2 = Desert2enemy2;

        Desert2.prefab = Desert2prefab;
        #endregion
        #region Mountain1Stats
        Mountain1.name = Mountain1name;
        Mountain1.isBossEncounter = Mountain1isBossEncounter;

        Mountain1.index = Mountain1index;

        Mountain1.difficultyModifier = Mountain1difficultyModifier;

        Mountain1.enemy1 = Mountain1enemy1;
        Mountain1.enemy2 = Mountain1enemy2;

        Mountain1.prefab = Mountain1prefab;
        #endregion
        #region Mountain2Stats
        Mountain2.name = Mountain2name;
        Mountain2.isBossEncounter = Mountain2isBossEncounter;

        Mountain2.index = Mountain2index;

        Mountain2.difficultyModifier = Mountain2difficultyModifier;

        Mountain2.enemy1 = Mountain2enemy1;
        Mountain2.enemy2 = Mountain2enemy2;

        Mountain2.prefab = Mountain2prefab;
        #endregion
        #region Mountain3Stats
        Mountain3.name = Mountain3name;
        Mountain3.isBossEncounter = Mountain3isBossEncounter;

        Mountain3.index = Mountain3index;

        Mountain3.difficultyModifier = Mountain3difficultyModifier;

        Mountain3.enemy1 = Mountain3enemy1;
        Mountain3.enemy2 = Mountain3enemy2;

        Mountain3.prefab = Mountain3prefab;
        #endregion
        #region HedgehogStats
        Hedgehog.name = Hedgehogname;

        Hedgehog.isDead = HedgehogisDead;
        Hedgehog.isBoss = HedgehogisBoss;

        Hedgehog.actionPoints = HedgehogactionPoints;

        Hedgehog.maxHP = HedgehogmaxHP;
        Hedgehog.currentHP = HedgehogcurrentHP;
        Hedgehog.damage = Hedgehogdamage;
        Hedgehog.specialDamage = HedgehogspecialDamage;
        Hedgehog.critChance = HedgehogcritChance;
        Hedgehog.critDamage = HedgehogcritDamage;
        Hedgehog.healing = Hedgehoghealing;

        Hedgehog.prefab = Hedgehogprefab;
        #endregion
        #region SkunkStats
        Skunk.name = Skunkname;

        Skunk.isDead = SkunkisDead;
        Skunk.isBoss = SkunkisBoss;

        Skunk.actionPoints = SkunkactionPoints;

        Skunk.maxHP = SkunkmaxHP;
        Skunk.currentHP = SkunkcurrentHP;
        Skunk.damage = Skunkdamage;
        Skunk.specialDamage = SkunkspecialDamage;
        Skunk.critChance = SkunkcritChance;
        Skunk.critDamage = SkunkcritDamage;
        Skunk.healing = Skunkhealing;

        Skunk.prefab = Skunkprefab;
        #endregion
        #region FoxBanditsStats
        FoxBandits.name = FoxBanditsname;

        FoxBandits.isDead = FoxBanditsisDead;
        FoxBandits.isBoss = FoxBanditsisBoss;

        FoxBandits.actionPoints = FoxBanditsactionPoints;

        FoxBandits.maxHP = FoxBanditsmaxHP;
        FoxBandits.currentHP = FoxBanditscurrentHP;
        FoxBandits.damage = FoxBanditsdamage;
        FoxBandits.specialDamage = FoxBanditsspecialDamage;
        FoxBandits.critChance = FoxBanditscritChance;
        FoxBandits.critDamage = FoxBanditscritDamage;
        FoxBandits.healing = FoxBanditshealing;

        FoxBandits.prefab = FoxBanditsprefab;
        #endregion
        #region KomodoDragonStats
        KomodoDragon.name = KomodoDragonname;

        KomodoDragon.isDead = KomodoDragonisDead;
        KomodoDragon.isBoss = KomodoDragonisBoss;

        KomodoDragon.actionPoints = KomodoDragonactionPoints;

        KomodoDragon.maxHP = KomodoDragonmaxHP;
        KomodoDragon.currentHP = KomodoDragoncurrentHP;
        KomodoDragon.damage = KomodoDragondamage;
        KomodoDragon.specialDamage = KomodoDragonspecialDamage;
        KomodoDragon.critChance = KomodoDragoncritChance;
        KomodoDragon.critDamage = KomodoDragoncritDamage;
        KomodoDragon.healing = KomodoDragonhealing;

        KomodoDragon.prefab = KomodoDragonprefab;
        #endregion
        #region FennecFoxStats
        FennecFox.name = FennecFoxname;

        FennecFox.isDead = FennecFoxisDead;
        FennecFox.isBoss = FennecFoxisBoss;

        FennecFox.actionPoints = FennecFoxactionPoints;

        FennecFox.maxHP = FennecFoxmaxHP;
        FennecFox.currentHP = FennecFoxcurrentHP;
        FennecFox.damage = FennecFoxdamage;
        FennecFox.specialDamage = FennecFoxspecialDamage;
        FennecFox.critChance = FennecFoxcritChance;
        FennecFox.critDamage = FennecFoxcritDamage;
        FennecFox.healing = FennecFoxhealing;

        FennecFox.prefab = FennecFoxprefab;
        #endregion
        #region SnakeStats
        Snake.name = Snakename;

        Snake.isDead = SnakeisDead;
        Snake.isBoss = SnakeisBoss;

        Snake.actionPoints = SnakeactionPoints;

        Snake.maxHP = SnakemaxHP;
        Snake.currentHP = SnakecurrentHP;
        Snake.damage = Snakedamage;
        Snake.specialDamage = SnakespecialDamage;
        Snake.critChance = SnakecritChance;
        Snake.critDamage = SnakecritDamage;
        Snake.healing = Snakehealing;

        Snake.prefab = Snakeprefab;
        #endregion
        #region RavenStats
        Raven.name = Ravenname;

        Raven.isDead = RavenisDead;
        Raven.isBoss = RavenisBoss;

        Raven.actionPoints = RavenactionPoints;

        Raven.maxHP = RavenmaxHP;
        Raven.currentHP = RavencurrentHP;
        Raven.damage = Ravendamage;
        Raven.specialDamage = RavenspecialDamage;
        Raven.critChance = RavencritChance;
        Raven.critDamage = RavencritDamage;
        Raven.healing = Ravenhealing;

        Raven.prefab = Ravenprefab;
        #endregion
        #region PidgeonStats
        Pidgeon.name = Pidgeonname;

        Pidgeon.isDead = PidgeonisDead;
        Pidgeon.isBoss = PidgeonisBoss;

        Pidgeon.actionPoints = PidgeonactionPoints;

        Pidgeon.maxHP = PidgeonmaxHP;
        Pidgeon.currentHP = PidgeoncurrentHP;
        Pidgeon.damage = Pidgeondamage;
        Pidgeon.specialDamage = PidgeonspecialDamage;
        Pidgeon.critChance = PidgeoncritChance;
        Pidgeon.critDamage = PidgeoncritDamage;
        Pidgeon.healing = Pidgeonhealing;

        Pidgeon.prefab = Pidgeonprefab;
        #endregion
        #region SeagullStats
        Seagull.name = Seagullname;

        Seagull.isDead = SeagullisDead;
        Seagull.isBoss = SeagullisBoss;

        Seagull.actionPoints = SeagullactionPoints;

        Seagull.maxHP = SeagullmaxHP;
        Seagull.currentHP = SeagullcurrentHP;
        Seagull.damage = Seagulldamage;
        Seagull.specialDamage = SeagullspecialDamage;
        Seagull.critChance = SeagullcritChance;
        Seagull.critDamage = SeagullcritDamage;
        Seagull.healing = Seagullhealing;

        Seagull.prefab = Seagullprefab;
        #endregion
        #region RocStats
        Roc.name = Rocname;

        Roc.isDead = RocisDead;
        Roc.isBoss = RocisBoss;

        Roc.actionPoints = RocactionPoints;

        Roc.maxHP = RocmaxHP;
        Roc.currentHP = RoccurrentHP;
        Roc.damage = Rocdamage;
        Roc.specialDamage = RocspecialDamage;
        Roc.critChance = RoccritChance;
        Roc.critDamage = RoccritDamage;
        Roc.healing = Rochealing;

        Roc.prefab = Rocprefab;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
