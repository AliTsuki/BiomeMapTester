using System;
using System.Drawing;
using System.Windows.Forms;

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
        // Biome Map Noise Generators
        public static readonly Perlin biomeMapTemp = new Perlin()
        {
            Frequency = TempFreq,
            Lacunarity = TempLac,
            OctaveCount = TempOct,
            Persistence = TempPers,
            Seed = Seed,
        };
        public static readonly Perlin biomeMapHumid = new Perlin()
        {
            Frequency = HumidFreq,
            Lacunarity = HumidLac,
            OctaveCount = HumidOct,
            Persistence = HumidPers,
            Seed = Seed + HumidOffset,
        };
        public static readonly Perlin biomeMapHeight = new Perlin()
        {
            Frequency = HeightFreq,
            Lacunarity = HeightLac,
            OctaveCount = HeightOct,
            Persistence = HeightPers,
            Seed = Seed + HeightOffset,
        };

        public static int height = 1080;
        public static int width = 1920;
        public static Bitmap bmp;

        public BiomeMapTester()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dumbass y u not put numbers in teh boxes???");
            }
            bmp = new Bitmap(width, height);
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    bmp.SetPixel(x, y, Biome.GetBiome(x, y).BiomeColor);
                }
            }
            this.BiomeMapPictureBox.Image = bmp;
            bmp.Save(Application.StartupPath + "\\BiomeMap.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }

    public class Biome
    {
        // Biome List
        public static readonly Biome Tundra = new Biome(Color.AliceBlue);
        public static readonly Biome Taiga = new Biome(Color.AliceBlue);
        public static readonly Biome MntneGrass = new Biome(Color.AliceBlue);
        public static readonly Biome TempConForest = new Biome(Color.AliceBlue);
        public static readonly Biome Icelands = new Biome(Color.AliceBlue);
        public static readonly Biome TempDeciForest = new Biome(Color.AliceBlue);
        public static readonly Biome TropConForest = new Biome(Color.AliceBlue);
        public static readonly Biome TropGrass = new Biome(Color.AliceBlue);
        public static readonly Biome MediScrub = new Biome(Color.AliceBlue);
        public static readonly Biome Jungle = new Biome(Color.AliceBlue);
        public static readonly Biome Desert = new Biome(Color.AliceBlue);
        public static readonly Biome Mesa = new Biome(Color.AliceBlue);
        public static readonly Biome Canyons = new Biome(Color.AliceBlue);
        public static readonly Biome WarmSwamp = new Biome(Color.AliceBlue);
        public static readonly Biome MtnLake = new Biome(Color.AliceBlue);
        public static readonly Biome MtnMeadow = new Biome(Color.AliceBlue);
        public static readonly Biome Pillars = new Biome(Color.AliceBlue);
        public static readonly Biome Volcano = new Biome(Color.AliceBlue);
        public static readonly Biome MshrmForest = new Biome(Color.AliceBlue);
        public static readonly Biome MtnSwamp = new Biome(Color.AliceBlue);
        public static readonly Biome FloodGrass = new Biome(Color.AliceBlue);
        public static readonly Biome Wetland = new Biome(Color.AliceBlue);
        public static readonly Biome JungleCoast = new Biome(Color.AliceBlue);
        public static readonly Biome MtnJungle = new Biome(Color.AliceBlue);
        public static readonly Biome Littoral = new Biome(Color.AliceBlue);
        public static readonly Biome Mangrove = new Biome(Color.AliceBlue);
        public static readonly Biome SnowCoast = new Biome(Color.AliceBlue);
        public static readonly Biome ColdDesert = new Biome(Color.AliceBlue);
        public static readonly Biome KelpForest = new Biome(Color.AliceBlue);
        public static readonly Biome Coral = new Biome(Color.AliceBlue);
        public static readonly Biome Neritic = new Biome(Color.AliceBlue);
        public static readonly Biome Pelagic = new Biome(Color.AliceBlue);
        public static readonly Biome OceanDesert = new Biome(Color.AliceBlue);
        public static readonly Biome Benthic = new Biome(Color.AliceBlue);
        public static readonly Biome Abyssal = new Biome(Color.AliceBlue);
        // End of Biome List
        public static readonly Biome ErrorBiome = new Biome(Color.AliceBlue);

        public static Biome[,,] Biomes = new Biome[4, 4, 4] {
        //Columns X, Rows Y, Units Z
        //                          OCEAN                                              COAST                                                  MIDLANDS                                              HIGHLANDS
        //        DRY                               WET          |  DRY                                 WET         |  DRY                                       WET            |  DRY                                WET
        /*COLD*/{{Abyssal,     Benthic,    Benthic, Benthic},      {SnowCoast,  Tundra,    Tundra,      Tundra},      {Taiga,         Tundra,    TempConForest,  TempConForest},  {MntneGrass, Taiga,      Taiga,     Icelands}}, // COLD
        /*MILD*/{{OceanDesert, KelpForest, Pelagic, Pelagic},      {ColdDesert, SnowCoast, SnowCoast,   FloodGrass},  {TropConForest, SnowCoast, MshrmForest,    MtnSwamp},       {MntneGrass, MntneGrass, Taiga,     Taiga}},    // MID-COLD
        /*WARM*/{{Neritic,     Neritic,    Pelagic, Coral},        {Desert,     Mesa,      WarmSwamp,   Wetland},     {MediScrub,     Mesa,      TempDeciForest, MtnLake},        {Canyons,    Pillars,    MtnMeadow, MtnLake}},  // MID-HOT
        /*HOT */{{Littoral,    Neritic,    Coral,   KelpForest},   {Desert,     MediScrub, JungleCoast, Mangrove},    {MediScrub,     MediScrub, TropGrass,      Jungle},         {Volcano,    Volcano,    MtnJungle, MtnJungle}},// HOT
        };

        // OLD MAP
        //{{Abyssal, SnowCoast, Taiga, MontaneGrasslands},                       {Benthic,Tundra,TemperateConiferousForest,Taiga},        {Benthic,Tundra,TemperateConiferousForest,Taiga},                  {Benthic,Tundra,TemperateConiferousForest,IceLands}},                 // COLD
        //{{OceanDesert,ColdDesert,TropicalConiferousForest,MontaneGrasslands},  {KelpForest,SnowCoast,TemperateBroadleafForest,23},      {Pelagic,SnowCoast,MushroomForest,27},                             {Pelagic,FloodedGrasslands,MountainousSwamp,Taiga}},                // MID-COLD
        //{{Neritic,Desert,MediterraneanScrub,Canyonlands},                      {Neritic,Mesa,TemperateDeciduousForest,Pillars},         {Pelagic,WarmSwamp,TemperateDeciduousForest,MountainMeadow},       {Coral,Wetland,Lake,MountainLake}},                                        // MID-HOT
        //{{Littoral,Desert,MediterraneanScrub,Volcano},                         {Neritic,MediterraneanScrub,TropicalGrasslands,Volcano}, {Coral,JungleCoast,TropicalGrasslands,MountainJungle},             {KelpForest,Mangrove,TropicalMoistBroadleafForest,MountainJungle}}, // HOT
        //};

        public Color BiomeColor;

        public Biome(Color color)
        {
            this.BiomeColor = color;
        }

        // Returns a byte array for color representing the Biome at location, given Pixel Coords
        public static Biome GetBiome(int x, int y)
        {
            int z = 0;
            float biomeTemp = (float)BiomeMapTester.biomeMapTemp.GetValue(x, y, z);
            float biomeHumid = (float)BiomeMapTester.biomeMapHumid.GetValue(x, y, z);
            float biomeHeight = (float)BiomeMapTester.biomeMapHeight.GetValue(x, y, z);
            int indexX = (int)Math.Round((biomeTemp + 1) * 2);
            int indexY = (int)Math.Round((biomeHeight + 1) * 2);
            int indexZ = (int)Math.Round((biomeHumid + 1) * 2);
            return Biomes[indexX, indexY, indexZ];
        }
    }
}
