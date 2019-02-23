using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using SharpNoise.Modules;

namespace BiomeMapTester
{
    public partial class BiomeMapTester : Form
    {
        // Biome Map Fields
        public static float TempFreq;
        public static float TempLac;
        public static int TempOct;
        public static float TempPers;
        public static float HumidFreq;
        public static float HumidLac;
        public static int HumidOct;
        public static float HumidPers;
        public static float HeightFreq;
        public static float HeightLac;
        public static int HeightOct;
        public static float HeightPers;
        public static int HeightOffset;
        public static int HumidOffset;
        public static int Seed;

        public static float FirstCutoff;
        public static float SecondCutoff;

        public static Perlin biomeMapTemp;
        public static Perlin biomeMapHumid;
        public static Perlin biomeMapHeight;

        public static int height;
        public static int width;

        public static bool genPNG = false;
        public static bool genLogs = false;
        public static bool genSettings = false;

        public static Bitmap bmp;
        public static List<string> SettingsList = new List<string>();

        public BiomeMapTester()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TempFreqTextBox.Text = "0.005";
            this.TempLacTextBox.Text = "1";
            this.TempOctTextBox.Text = "2";
            this.TempPersTextBox.Text = "2";
            this.HumidFreqTextBox.Text = "0.005";
            this.HumidLacTextBox.Text = "1";
            this.HumidOctTextBox.Text = "2";
            this.HumidPersTextBox.Text = "2";
            this.HeightFreqTextBox.Text = "0.005";
            this.HeightLacTextBox.Text = "3";
            this.HeightOctTextBox.Text = "2";
            this.HeightPersTextBox.Text = "5";
            this.HumidOffsetTextBox.Text = "1";
            this.HeightOffsetTextBox.Text = "2";
            this.SeedTextBox.Text = "0";
            this.WidthTextBox.Text = "1000";
            this.HeightTextBox.Text = "1000";
            this.FirstCutoffTextBox.Text = "0.5";
            this.SecondCutoffTextBox.Text = "1.3";
            this.HimalayanPictureBox.BackColor = Biome.Himalayan.BiomeColor;
            this.SnowcappedMountainPictureBox.BackColor = Biome.SnowcappedMountain.BiomeColor;
            this.IcePillarsPictureBox.BackColor = Biome.IcePillars.BiomeColor;
            this.TaigaPictureBox.BackColor = Biome.Taiga.BiomeColor;
            this.MontaneGrasslandsPictureBox.BackColor = Biome.MontaneGrasslands.BiomeColor;
            this.TundraPictureBox.BackColor = Biome.Tundra.BiomeColor;
            this.FrozenCoastPictureBox.BackColor = Biome.FrozenCoast.BiomeColor;
            this.MountainMeadowPictureBox.BackColor = Biome.MountainMeadow.BiomeColor;
            this.MountainLakePictureBox.BackColor = Biome.MountainLake.BiomeColor;
            this.MountainConifersPictureBox.BackColor = Biome.MountainConifers.BiomeColor;
            this.TemperateConiferousForestPictureBox.BackColor = Biome.TemperateConiferousForest.BiomeColor;
            this.TemperateMixedForestPictureBox.BackColor = Biome.TemperateMixedForest.BiomeColor;
            this.TemperateDeciduousForestPictureBox.BackColor = Biome.TemperateDeciduousForest.BiomeColor;
            this.RedwoodForestPictureBox.BackColor = Biome.RedwoodForest.BiomeColor;
            this.BriarPatchPictureBox.BackColor = Biome.BriarPatch.BiomeColor;
            this.TemperateGrasslandsPictureBox.BackColor = Biome.TemperateGrasslands.BiomeColor;
            this.MediterraneanScrubPictureBox.BackColor = Biome.MediterraneanScrub.BiomeColor;
            this.MountainMushroomForestPictureBox.BackColor = Biome.MountainMushroomForest.BiomeColor;
            this.MushroomForestPictureBox.BackColor = Biome.MushroomForest.BiomeColor;
            this.MushroomCoastPictureBox.BackColor = Biome.MushroomCoast.BiomeColor;
            this.MountainJunglePictureBox.BackColor = Biome.MountainJungle.BiomeColor;
            this.TropicalConiferousForestPictureBox.BackColor = Biome.TropicalConiferousForest.BiomeColor;
            this.JunglePictureBox.BackColor = Biome.Jungle.BiomeColor;
            this.TropicalGrasslandsPictureBox.BackColor = Biome.TropicalGrasslands.BiomeColor;
            this.CoastalJunglePictureBox.BackColor = Biome.CoastalJungle.BiomeColor;
            this.MangrovePictureBox.BackColor = Biome.Mangrove.BiomeColor;
            this.MountainSwampPictureBox.BackColor = Biome.MountainSwamp.BiomeColor;
            this.AcidSwampPictureBox.BackColor = Biome.AcidSwamp.BiomeColor;
            this.FloodedGrasslandsPictureBox.BackColor = Biome.FloodedGrasslands.BiomeColor;
            this.WetlandPictureBox.BackColor = Biome.Wetland.BiomeColor;
            this.SandstonePillarsPictureBox.BackColor = Biome.SandstonePillars.BiomeColor;
            this.MesaPictureBox.BackColor = Biome.Mesa.BiomeColor;
            this.CanyonlandsPictureBox.BackColor = Biome.Canyonlands.BiomeColor;
            this.DesertPictureBox.BackColor = Biome.Desert.BiomeColor;
            this.BlackDesertPictureBox.BackColor = Biome.BlackDesert.BiomeColor;
            this.RuinsPictureBox.BackColor = Biome.Ruins.BiomeColor;
            this.BadlandsPictureBox.BackColor = Biome.Badlands.BiomeColor;
            this.BoulderlandsPictureBox.BackColor = Biome.Boulderlands.BiomeColor;
            this.CoastalCliffsPictureBox.BackColor = Biome.CoastalCliffs.BiomeColor;
            this.CrystalShardsPictureBox.BackColor = Biome.CrystalShards.BiomeColor;
            this.VolcanoPictureBox.BackColor = Biome.Volcano.BiomeColor;
            this.DeadlandsPictureBox.BackColor = Biome.Deadlands.BiomeColor;
            this.BonefieldsPictureBox.BackColor = Biome.Bonefields.BiomeColor;
            this.FrozenOceanPictureBox.BackColor = Biome.FrozenOcean.BiomeColor;
            this.NeriticZonePictureBox.BackColor = Biome.NeriticZone.BiomeColor;
            this.LittoralZonePictureBox.BackColor = Biome.LittoralZone.BiomeColor;
            this.CoralReefPictureBox.BackColor = Biome.CoralReef.BiomeColor;
            this.KelpForestPictureBox.BackColor = Biome.KelpForest.BiomeColor;
            this.PelagicZonePictureBox.BackColor = Biome.PelagicZone.BiomeColor;
            this.BenthicZonePictureBox.BackColor = Biome.BenthicZone.BiomeColor;
            this.ThermalZonePictureBox.BackColor = Biome.ThermalZone.BiomeColor;
            this.OceanDeadZonePictureBox.BackColor = Biome.OceanDeadZone.BiomeColor;
            this.AbyssalZonePictureBox.BackColor = Biome.AbyssalZone.BiomeColor;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                TempFreq = float.Parse(this.TempFreqTextBox.Text);
                TempLac = float.Parse(this.TempLacTextBox.Text);
                TempOct = int.Parse(this.TempOctTextBox.Text);
                TempPers = float.Parse(this.TempPersTextBox.Text);
                HumidFreq = float.Parse(this.HumidFreqTextBox.Text);
                HumidLac = float.Parse(this.HumidLacTextBox.Text);
                HumidOct = int.Parse(this.HumidOctTextBox.Text);
                HumidPers = float.Parse(this.HumidPersTextBox.Text);
                HeightFreq = float.Parse(this.HeightFreqTextBox.Text);
                HeightLac = float.Parse(this.HeightLacTextBox.Text);
                HeightOct = int.Parse(this.HeightOctTextBox.Text);
                HeightPers = float.Parse(this.HeightPersTextBox.Text);
                HumidOffset = int.Parse(this.HumidOffsetTextBox.Text);
                HeightOffset = int.Parse(this.HeightOffsetTextBox.Text);
                Seed = int.Parse(this.SeedTextBox.Text);
                width = int.Parse(this.WidthTextBox.Text);
                height = int.Parse(this.HeightTextBox.Text);
                FirstCutoff = float.Parse(this.FirstCutoffTextBox.Text);
                SecondCutoff = float.Parse(this.SecondCutoffTextBox.Text);
                genPNG = this.GeneratePNGCheckBox.CheckState == CheckState.Checked;
                genLogs = this.GenerateLogsCheckBox.CheckState == CheckState.Checked;
                genSettings = this.GenerateSettingsCheckBox.CheckState == CheckState.Checked;
                // Biome Map Noise Generators
                biomeMapTemp = new Perlin()
                {
                    Frequency = TempFreq,
                    Lacunarity = TempLac,
                    OctaveCount = TempOct,
                    Persistence = TempPers,
                    Seed = Seed,
                };
                biomeMapHumid = new Perlin()
                {
                    Frequency = HumidFreq,
                    Lacunarity = HumidLac,
                    OctaveCount = HumidOct,
                    Persistence = HumidPers,
                    Seed = Seed + HumidOffset,
                };
                biomeMapHeight = new Perlin()
                {
                    Frequency = HeightFreq,
                    Lacunarity = HeightLac,
                    OctaveCount = HeightOct,
                    Persistence = HeightPers,
                    Seed = Seed + HeightOffset,
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dumbass y u not put numbers in teh boxes???\n\nOctave Counts, Offsets, Seed, Width, and Height must be WHOLE NUMBERS, all other values can be DECIMAL.\n\nNUMBERS ONLY, no sneaky alphabet characters dumb dumb.");
                goto end;
            }
            bmp = new Bitmap(width, height);
            if(genLogs)
            {
                Biome.logBeforeNorm.Add("Temperature,Humidity,Height");
                Biome.logAfterNorm.Add("Temperature,Humidity,Height,Biome");
            }
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    bmp.SetPixel(x, y, Biome.GetBiome(x, y, biomeMapTemp, biomeMapHumid, biomeMapHeight).BiomeColor);
                }
            }
            this.BiomeMapPictureBox.Image = bmp;
            if(genPNG)
            {
                bmp.Save(Application.StartupPath + "\\BiomeMap.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            if(genLogs)
            {
                System.IO.File.WriteAllLines(Application.StartupPath + "\\LogBeforeNormalization.csv", Biome.logBeforeNorm);
                System.IO.File.WriteAllLines(Application.StartupPath + "\\LogAfterNormalization.csv", Biome.logAfterNorm);
                Biome.logBeforeNorm.Clear();
                Biome.logAfterNorm.Clear();
            }
            if(genSettings)
            {
                SettingsList.Add($@"TEMPERATURE MAP SETTINGS");
                SettingsList.Add($@"Temperature Frequency: {TempFreq.ToString()}");
                SettingsList.Add($@"Temperature Lacunarity: {TempLac.ToString()}");
                SettingsList.Add($@"Temperature Octave Count: {TempOct.ToString()}");
                SettingsList.Add($@"Temperature Persistence: {TempPers.ToString()}");
                SettingsList.Add($@"HUMIDITY MAP SETTINGS");
                SettingsList.Add($@"Humidity Frequency: {HumidFreq.ToString()}");
                SettingsList.Add($@"Humidity Lacunarity: {HumidLac.ToString()}");
                SettingsList.Add($@"Humidity Octave Count: {HumidOct.ToString()}");
                SettingsList.Add($@"Humidity Persistence: {HumidPers.ToString()}");
                SettingsList.Add($@"HEIGHT MAP SETTINGS");
                SettingsList.Add($@"Height Frequency: {HeightFreq.ToString()}");
                SettingsList.Add($@"Height Lacunarity: {HeightLac.ToString()}");
                SettingsList.Add($@"Height Octave Count: {HeightOct.ToString()}");
                SettingsList.Add($@"Height Persistence: {HeightPers.ToString()}");
                SettingsList.Add($@"SEED SETTINGS");
                SettingsList.Add($@"Humidity Seed Offset: {HumidOffset.ToString()}");
                SettingsList.Add($@"Height Seed Offset: {HeightOffset.ToString()}");
                SettingsList.Add($@"Seed: {Seed.ToString()}");
                SettingsList.Add($@"OFFSET SETTINGS");
                SettingsList.Add($@"First Cutoff: {FirstCutoff.ToString()}");
                SettingsList.Add($@"Second Cutoff: {SecondCutoff.ToString()}");
                System.IO.File.WriteAllLines(Application.StartupPath + "\\Settings.txt", SettingsList);
                SettingsList.Clear();
            }
            end:;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.TempFreqTextBox.Text = "0.005";
            this.TempLacTextBox.Text = "1";
            this.TempOctTextBox.Text = "2";
            this.TempPersTextBox.Text = "2";
            this.HumidFreqTextBox.Text = "0.005";
            this.HumidLacTextBox.Text = "1";
            this.HumidOctTextBox.Text = "2";
            this.HumidPersTextBox.Text = "2";
            this.HeightFreqTextBox.Text = "0.005";
            this.HeightLacTextBox.Text = "3";
            this.HeightOctTextBox.Text = "2";
            this.HeightPersTextBox.Text = "5";
            this.HumidOffsetTextBox.Text = "1";
            this.HeightOffsetTextBox.Text = "2";
            this.SeedTextBox.Text = "0";
            this.WidthTextBox.Text = "1000";
            this.HeightTextBox.Text = "1000";
            this.FirstCutoffTextBox.Text = "0.5";
            this.SecondCutoffTextBox.Text = "1.3";
        }

        private void HelpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.HelpLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("https://code.google.com/archive/p/fractalterraingeneration/wikis/Fractional_Brownian_Motion.wiki");
        }
    }

    public class Biome
    {
        // Biome List
        #region
        // COLD MOUNTAINS
        public static readonly Biome Himalayan = new Biome("Himalayan", Color.Snow);
        public static readonly Biome SnowcappedMountain = new Biome("Snowcapped Mountain", Color.Gainsboro);
        public static readonly Biome IcePillars = new Biome("Ice Pillars", Color.LightSlateGray);
        public static readonly Biome Taiga = new Biome("Taiga", Color.Gray);
        public static readonly Biome MontaneGrasslands = new Biome("Montane Grasslands", Color.AntiqueWhite);
        // COLD LOWLANDS
        public static readonly Biome Tundra = new Biome("Tundra", Color.Ivory);
        public static readonly Biome FrozenCoast = new Biome("Frozen Coast", Color.DarkSlateGray);
        // TEMPERATE FORESTS
        public static readonly Biome MountainMeadow = new Biome("Mountain Meadow", Color.DarkSeaGreen);
        public static readonly Biome MountainLake = new Biome("Mountain Lake", Color.MediumAquamarine);
        public static readonly Biome MountainConifers = new Biome("Mountain Conifers", Color.DarkOliveGreen);
        public static readonly Biome TemperateConiferousForest = new Biome("Temperate Coniferous Forest", Color.OliveDrab);
        public static readonly Biome TemperateMixedForest = new Biome("Temperate Mixed Forest", Color.DarkGreen);
        public static readonly Biome TemperateDeciduousForest = new Biome("Temperate Deciduous Forest", Color.ForestGreen);
        public static readonly Biome RedwoodForest = new Biome("Redwood Forest", Color.Olive);
        // TEMPERATE GRASS/SHRUBS
        public static readonly Biome BriarPatch = new Biome("Briar Patch", Color.RosyBrown);
        public static readonly Biome TemperateGrasslands = new Biome("Temperate Grasslands", Color.SandyBrown);
        public static readonly Biome MediterraneanScrub = new Biome("Mediterranean Scrub", Color.BurlyWood);
        // MUSHROOMS
        public static readonly Biome MountainMushroomForest = new Biome("Mountain Mushroom Forest", Color.OrangeRed);
        public static readonly Biome MushroomForest = new Biome("Mushroom Forest", Color.DarkOrange);
        public static readonly Biome MushroomCoast = new Biome("Mushroom Coast", Color.Orange);
        // TROPICS
        public static readonly Biome MountainJungle = new Biome("Mountain Jungle", Color.MediumSeaGreen);
        public static readonly Biome TropicalConiferousForest = new Biome("Tropical Coniferous Forest", Color.LightGreen);
        public static readonly Biome Jungle = new Biome("Jungle", Color.Lime);
        public static readonly Biome TropicalGrasslands = new Biome("Tropical Grasslands", Color.LawnGreen);
        public static readonly Biome CoastalJungle = new Biome("Coastal Jungle", Color.LimeGreen);
        public static readonly Biome Mangrove = new Biome("Mangrove", Color.PaleGreen);
        // SWAMPS
        public static readonly Biome MountainSwamp = new Biome("Mountain Swamp", Color.DarkViolet);
        public static readonly Biome AcidSwamp = new Biome("Acid Swamp", Color.Indigo);
        public static readonly Biome FloodedGrasslands = new Biome("Flooded Grasslands", Color.MediumPurple);
        public static readonly Biome Wetland = new Biome("Wetland", Color.MediumOrchid);
        // DESERTS
        public static readonly Biome SandstonePillars = new Biome("Sandstone Pillars", Color.DarkRed);
        public static readonly Biome Mesa = new Biome("Mesa", Color.Firebrick);
        public static readonly Biome Canyonlands = new Biome("Canyonlands", Color.Red);
        public static readonly Biome Desert = new Biome("Desert", Color.Crimson);
        public static readonly Biome BlackDesert = new Biome("Black Desert", Color.IndianRed);
        public static readonly Biome Ruins = new Biome("Ruins", Color.DarkSalmon);
        public static readonly Biome Badlands = new Biome("Badlands", Color.LightSalmon);
        // ROCKY AREAS
        public static readonly Biome Boulderlands = new Biome("Boulderlands", Color.Lavender);
        public static readonly Biome CoastalCliffs = new Biome("Coastal Cliffs", Color.Plum);
        // SPECIAL ZONES
        public static readonly Biome CrystalShards = new Biome("Crystal Shards", Color.Fuchsia);
        public static readonly Biome Volcano = new Biome("Volcano", Color.Violet);
        public static readonly Biome Deadlands = new Biome("Deadlands", Color.Thistle);
        public static readonly Biome Bonefields = new Biome("Bonefields", Color.Orchid);
        // SHALLOW OCEAN
        public static readonly Biome FrozenOcean = new Biome("Frozen Ocean", Color.Aqua);
        public static readonly Biome NeriticZone = new Biome("Neritic Zone", Color.PaleTurquoise);
        public static readonly Biome LittoralZone = new Biome("Littoral Zone", Color.Aquamarine);
        public static readonly Biome CoralReef = new Biome("Coral Reef", Color.MediumTurquoise);
        public static readonly Biome KelpForest = new Biome("Kelp Forest", Color.CadetBlue);
        // DEEP OCEAN
        public static readonly Biome PelagicZone = new Biome("Pelagic Zone", Color.Blue);
        public static readonly Biome BenthicZone = new Biome("Benthic Zone", Color.DarkBlue);
        public static readonly Biome ThermalZone = new Biome("Thermal Zone", Color.DodgerBlue);
        public static readonly Biome OceanDeadZone = new Biome("Ocean Dead Zone", Color.MediumSlateBlue);
        public static readonly Biome AbyssalZone = new Biome("Abyssal Zone", Color.Black);
        #endregion
        // End of Biome List

        public static Biome[,,] Biomes = new Biome[5, 5, 5] {
        //Columns X, Rows Y, Units Z
        //                                   DEEP OCEAN                                                         SHELF OCEAN                                                       LOWLANDS/COAST                                               MIDLANDS                                                                                HIGHLANDS
        //              ARID        DRY         TEMPERATE   MOIST       HUMID            ARID        DRY         TEMPERATE   MOIST       HUMID             ARID        DRY         TEMPERATE     MOIST     HUMID                      ARID   DRY    TEMPERATE MOIST HUMID                                                         ARID      DRY                TEMPERATE          MOIST      HUMID
        /* FREEZING */{{AbyssalZone,BenthicZone,ThermalZone,PelagicZone,PelagicZone},   {FrozenOcean,FrozenOcean,NeriticZone,NeriticZone,NeriticZone},    {FrozenCoast,FrozenCoast,CoastalCliffs,Deadlands,Deadlands},               {Tundra,Tundra,Taiga,Taiga,AcidSwamp},                                                      {Himalayan,SnowcappedMountain,SnowcappedMountain,IcePillars,Taiga}}, // FREEZING
        /* CHILLY   */{{BenthicZone,PelagicZone,PelagicZone,PelagicZone,BenthicZone},   {FrozenOcean,NeriticZone,LittoralZone,NeriticZone,NeriticZone},   {Bonefields,CrystalShards,CoastalCliffs,RedwoodForest,FloodedGrasslands},  {Ruins,CrystalShards,TemperateConiferousForest,TemperateMixedForest,AcidSwamp},             {SnowcappedMountain,MontaneGrasslands,MountainConifers,MontaneGrasslands,MontaneGrasslands}}, // CHILLY
        /* MODERATE */{{PelagicZone,PelagicZone,BenthicZone,ThermalZone,AbyssalZone},   {NeriticZone,LittoralZone,NeriticZone,LittoralZone,LittoralZone}, {Badlands,BriarPatch,TemperateGrasslands,RedwoodForest,FloodedGrasslands}, {Desert,Boulderlands,TemperateConiferousForest,TemperateDeciduousForest,FloodedGrasslands}, {Boulderlands,Boulderlands,MountainConifers,MountainMeadow,MountainLake}}, // MODERATE
        /* WARM     */{{OceanDeadZone,PelagicZone,PelagicZone,PelagicZone,PelagicZone}, {NeriticZone,NeriticZone,CoralReef,KelpForest,CoralReef},         {Desert,MediterraneanScrub,TemperateGrasslands,MushroomCoast,Wetland},     {Desert,Mesa,TropicalConiferousForest,MushroomForest,Wetland},                              {SandstonePillars,Mesa,MountainMushroomForest,MountainMeadow,MountainSwamp}}, // WARM
        /* HOT      */{{PelagicZone,PelagicZone,AbyssalZone,BenthicZone,PelagicZone},   {CoralReef,NeriticZone,KelpForest,CoralReef,KelpForest},          {Desert,MediterraneanScrub,TropicalGrasslands,CoastalJungle,Mangrove},     {BlackDesert,MediterraneanScrub,TropicalConiferousForest,Jungle,Jungle},                    {Volcano,Canyonlands,Canyonlands,MountainJungle,MountainJungle}}, // HOT
        };

        public Color BiomeColor;
        public string BiomeName;

        public Biome(string name, Color color)
        {
            this.BiomeName = name;
            this.BiomeColor = color;
        }

        public static List<string> logBeforeNorm = new List<string>();
        public static List<string> logAfterNorm = new List<string>();

        public static Biome GetBiome(int x, int z, Perlin biomeMapTemp, Perlin biomeMapHumid, Perlin biomeMapHeight)
        {
            int y = 1;
            float biomeTemp = (float)biomeMapTemp.GetValue(x, y, z);
            float biomeHumid = (float)biomeMapHumid.GetValue(x, y, z);
            float biomeHeight = (float)biomeMapHeight.GetValue(x, y, z);
            if(BiomeMapTester.genLogs)
            {
                logBeforeNorm.Add($@"{biomeTemp.ToString()},{biomeHumid.ToString()},{biomeHeight.ToString()}");
            }
            int indexX = 0;
            int indexY = 0;
            int indexZ = 0;
            // Temp, X value
            if(biomeTemp <= -BiomeMapTester.SecondCutoff)
            {
                indexX = 0;
            }
            else if(biomeTemp > -BiomeMapTester.SecondCutoff && biomeTemp <= -BiomeMapTester.FirstCutoff)
            {
                indexX = 1;
            }
            else if(biomeTemp > -BiomeMapTester.FirstCutoff && biomeTemp <= BiomeMapTester.FirstCutoff)
            {
                indexX = 2;
            }
            else if(biomeTemp > BiomeMapTester.FirstCutoff && biomeTemp <= BiomeMapTester.SecondCutoff)
            {
                indexX = 3;
            }
            else
            {
                indexX = 4;
            }
            // Height, Y value
            if(biomeHeight <= -BiomeMapTester.SecondCutoff)
            {
                indexY = 0;
            }
            else if(biomeHeight > -BiomeMapTester.SecondCutoff && biomeHeight <= -BiomeMapTester.FirstCutoff)
            {
                indexY = 1;
            }
            else if(biomeHeight > -BiomeMapTester.FirstCutoff && biomeHeight <= BiomeMapTester.FirstCutoff)
            {
                indexY = 2;
            }
            else if(biomeHeight > BiomeMapTester.FirstCutoff && biomeHeight <= BiomeMapTester.SecondCutoff)
            {
                indexY = 3;
            }
            else
            {
                indexY = 4;
            }
            // Humidity, Z value
            if(biomeHumid <= -BiomeMapTester.SecondCutoff)
            {
                indexZ = 0;
            }
            else if(biomeHumid > -BiomeMapTester.SecondCutoff && biomeHumid <= -BiomeMapTester.FirstCutoff)
            {
                indexZ = 1;
            }
            else if(biomeHumid > -BiomeMapTester.FirstCutoff && biomeHumid <= BiomeMapTester.FirstCutoff)
            {
                indexZ = 2;
            }
            else if(biomeHumid > BiomeMapTester.FirstCutoff && biomeHumid <= BiomeMapTester.SecondCutoff)
            {
                indexZ = 3;
            }
            else
            {
                indexZ = 4;
            }
            if(BiomeMapTester.genLogs)
            {
                logAfterNorm.Add($@"{indexX.ToString()},{indexZ.ToString()},{indexY.ToString()},{Biomes[indexX, indexY, indexZ].BiomeName}");
            }
            return Biomes[indexX, indexY, indexZ];
        }
    }
}
