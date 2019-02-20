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

        public static Perlin biomeMapTemp;
        public static Perlin biomeMapHumid;
        public static Perlin biomeMapHeight;

        public static int height;
        public static int width;

        public static bool genPNG = false;
        public static bool genLogs = false;

        public static Bitmap bmp;

        public BiomeMapTester()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TempFreqTextBox.Text = "0.005";
            this.TempLacTextBox.Text = "1";
            this.TempOctTextBox.Text = "2";
            this.TempPersTextBox.Text = "5";
            this.HumidFreqTextBox.Text = "0.005";
            this.HumidLacTextBox.Text = "1";
            this.HumidOctTextBox.Text = "2";
            this.HumidPersTextBox.Text = "5";
            this.HeightFreqTextBox.Text = "0.004";
            this.HeightLacTextBox.Text = "2";
            this.HeightOctTextBox.Text = "4";
            this.HeightPersTextBox.Text = "2.2";
            this.HumidOffsetTextBox.Text = "1";
            this.HeightOffsetTextBox.Text = "2";
            this.SeedTextBox.Text = "0";
            this.WidthTextBox.Text = "1024";
            this.HeightTextBox.Text = "1024";
            this.TundraPictureBox.BackColor = Biome.Tundra.BiomeColor;
            this.TaigaPictureBox.BackColor = Biome.Taiga.BiomeColor;
            this.MtnGrassPictureBox.BackColor = Biome.MntneGrass.BiomeColor;
            this.IceLandsPictureBox.BackColor = Biome.Icelands.BiomeColor;
            this.TempConForPictureBox.BackColor = Biome.TempConForest.BiomeColor;
            this.SnowCoastPictureBox.BackColor = Biome.SnowCoast.BiomeColor;
            this.ColdDesertPictureBox.BackColor = Biome.ColdDesert.BiomeColor;
            this.TempDecForPictureBox.BackColor = Biome.TempDeciForest.BiomeColor;
            this.MediScrubPictureBox.BackColor = Biome.MediScrub.BiomeColor;
            this.MtnLakePictureBox.BackColor = Biome.MtnLake.BiomeColor;
            this.MtnMeadowPictureBox.BackColor = Biome.MtnMeadow.BiomeColor;
            this.TropConForPictureBox.BackColor = Biome.TropConForest.BiomeColor;
            this.TropGrassPictureBox.BackColor = Biome.TropGrass.BiomeColor;
            this.JunglePictureBox.BackColor = Biome.Jungle.BiomeColor;
            this.JungleCoastPictureBox.BackColor = Biome.JungleCoast.BiomeColor;
            this.MtnJunglePictureBox.BackColor = Biome.MtnJungle.BiomeColor;
            this.FloodGrassPictureBox.BackColor = Biome.FloodGrass.BiomeColor;
            this.WetlandPictureBox.BackColor = Biome.Wetland.BiomeColor;
            this.WarmSwampPictureBox.BackColor = Biome.WarmSwamp.BiomeColor;
            this.MtnSwampPictureBox.BackColor = Biome.MtnSwamp.BiomeColor;
            this.MangrovePictureBox.BackColor = Biome.Mangrove.BiomeColor;
            this.DesertPictureBox.BackColor = Biome.Desert.BiomeColor;
            this.MesaPictureBox.BackColor = Biome.Mesa.BiomeColor;
            this.CanyonsPictureBox.BackColor = Biome.Canyons.BiomeColor;
            this.PillarsPictureBox.BackColor = Biome.Pillars.BiomeColor;
            this.VolcanoPictureBox.BackColor = Biome.Volcano.BiomeColor;
            this.MshrmForPictureBox.BackColor = Biome.MshrmForest.BiomeColor;
            this.LittoralPictureBox.BackColor = Biome.Littoral.BiomeColor;
            this.KelpForPictureBox.BackColor = Biome.KelpForest.BiomeColor;
            this.CoralPictureBox.BackColor = Biome.Coral.BiomeColor;
            this.NeriticPictureBox.BackColor = Biome.Neritic.BiomeColor;
            this.PelagicPictureBox.BackColor = Biome.Pelagic.BiomeColor;
            this.OceanDesertPictureBox.BackColor = Biome.OceanDesert.BiomeColor;
            this.BenthicPictureBox.BackColor = Biome.Benthic.BiomeColor;
            this.AbyssalPictureBox.BackColor = Biome.Abyssal.BiomeColor;
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
                genPNG = this.GeneratePNGCheckBox.CheckState == CheckState.Checked;
                genLogs = this.GenerateLogsCheckBox.CheckState == CheckState.Checked;
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
                MessageBox.Show("Dumbass y u not put numbers in teh boxes???\n\nOctave Counts, Offsets, Seed, Width, and Height must be WHOLE NUMBERS, all other values can be DECIMAL. NUMBERS ONLY, no sneaky alphabet characters dumb dumb.");
                goto end;
            }
            bmp = new Bitmap(width, height);
            if(genLogs)
            {
                Biome.logBeforeNorm.Add("Temperature,Humidity,Height");
                Biome.logAfterNorm.Add("Temperature,Humidity,Height");
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
            end:;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.TempFreqTextBox.Text = "0.005";
            this.TempLacTextBox.Text = "1";
            this.TempOctTextBox.Text = "2";
            this.TempPersTextBox.Text = "5";
            this.HumidFreqTextBox.Text = "0.005";
            this.HumidLacTextBox.Text = "1";
            this.HumidOctTextBox.Text = "2";
            this.HumidPersTextBox.Text = "5";
            this.HeightFreqTextBox.Text = "0.004";
            this.HeightLacTextBox.Text = "2";
            this.HeightOctTextBox.Text = "4";
            this.HeightPersTextBox.Text = "2.2";
            this.HumidOffsetTextBox.Text = "1";
            this.HeightOffsetTextBox.Text = "2";
            this.SeedTextBox.Text = "0";
            this.WidthTextBox.Text = "1024";
            this.HeightTextBox.Text = "1024";
        }
    }

    public class Biome
    {
        // Biome List
        #region
        public static readonly Biome Tundra = new Biome(Color.Lavender);
        public static readonly Biome Taiga = new Biome(Color.AntiqueWhite);
        public static readonly Biome MntneGrass = new Biome(Color.NavajoWhite);
        public static readonly Biome Icelands = new Biome(Color.Snow);
        public static readonly Biome TempConForest = new Biome(Color.DarkOliveGreen);
        public static readonly Biome SnowCoast = new Biome(Color.Cornsilk);
        public static readonly Biome ColdDesert = new Biome(Color.RosyBrown);

        public static readonly Biome TempDeciForest = new Biome(Color.Green);
        public static readonly Biome MediScrub = new Biome(Color.Olive);
        public static readonly Biome MtnLake = new Biome(Color.DarkSeaGreen);
        public static readonly Biome MtnMeadow = new Biome(Color.YellowGreen);

        public static readonly Biome TropConForest = new Biome(Color.SpringGreen);
        public static readonly Biome TropGrass = new Biome(Color.LightGreen);
        public static readonly Biome Jungle = new Biome(Color.Lime);
        public static readonly Biome JungleCoast = new Biome(Color.LawnGreen);
        public static readonly Biome MtnJungle = new Biome(Color.PaleGreen);

        public static readonly Biome FloodGrass = new Biome(Color.Thistle);
        public static readonly Biome Wetland = new Biome(Color.Plum);
        public static readonly Biome WarmSwamp = new Biome(Color.Fuchsia);
        public static readonly Biome MtnSwamp = new Biome(Color.MediumPurple);
        public static readonly Biome Mangrove = new Biome(Color.Indigo);

        public static readonly Biome Desert = new Biome(Color.Khaki);
        public static readonly Biome Mesa = new Biome(Color.DarkKhaki);
        public static readonly Biome Canyons = new Biome(Color.Tomato);
        public static readonly Biome Pillars = new Biome(Color.OrangeRed);

        public static readonly Biome Volcano = new Biome(Color.Red);

        public static readonly Biome MshrmForest = new Biome(Color.DeepPink);

        public static readonly Biome Littoral = new Biome(Color.PaleTurquoise);
        public static readonly Biome KelpForest = new Biome(Color.CadetBlue);
        public static readonly Biome Coral = new Biome(Color.MediumSlateBlue);
        public static readonly Biome Neritic = new Biome(Color.RoyalBlue);
        public static readonly Biome Pelagic = new Biome(Color.MediumBlue);
        public static readonly Biome OceanDesert = new Biome(Color.Blue);
        public static readonly Biome Benthic = new Biome(Color.MidnightBlue);
        public static readonly Biome Abyssal = new Biome(Color.Black);
        #endregion
        // End of Biome List

        public static Biome[,,] Biomes = new Biome[4, 4, 4] {
        //Columns X, Rows Y, Units Z
        //                          OCEAN                                              COAST                                                  MIDLANDS                                              HIGHLANDS
        //        DRY                               WET          |  DRY                                 WET         |  DRY                                       WET            |  DRY                                WET
        /*COLD*/{{Abyssal,     Benthic,    Benthic, Benthic},      {SnowCoast,  Tundra,    Tundra,      Tundra},      {Taiga,         Tundra,    TempConForest,  TempConForest},  {MntneGrass, Taiga,      Taiga,     Icelands}}, // COLD
        /*MILD*/{{OceanDesert, KelpForest, Pelagic, Pelagic},      {ColdDesert, SnowCoast, SnowCoast,   FloodGrass},  {TropConForest, SnowCoast, MshrmForest,    MtnSwamp},       {MntneGrass, MntneGrass, Taiga,     Taiga}},    // MID-COLD
        /*WARM*/{{Neritic,     Neritic,    Pelagic, Coral},        {Desert,     Mesa,      WarmSwamp,   Wetland},     {MediScrub,     Mesa,      TempDeciForest, MtnLake},        {Canyons,    Pillars,    MtnMeadow, MtnLake}},  // MID-HOT
        /*HOT */{{Littoral,    Neritic,    Coral,   KelpForest},   {Desert,     MediScrub, JungleCoast, Mangrove},    {MediScrub,     MediScrub, TropGrass,      Jungle},         {Volcano,    Volcano,    MtnJungle, MtnJungle}},// HOT
        };

        public Color BiomeColor;

        public Biome(Color color)
        {
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
            biomeTemp = Clamp(biomeTemp, -8, 8);
            biomeHeight = Clamp(biomeHeight, -8, 8);
            biomeHumid = Clamp(biomeHumid, -8, 8);
            int indexX = 0;
            int indexY = 0;
            int indexZ = 0;
            // Temp, X value
            if(biomeTemp <= -3.2)
            {
                indexX = 0;
            }
            else if(biomeTemp > -3.2 && biomeTemp <= 0)
            {
                indexX = 1;
            }
            else if(biomeTemp > 0 && biomeTemp <= 3.2)
            {
                indexX = 2;
            }
            else
            {
                indexX = 3;
            }
            // Height, Y value
            if(biomeHeight <= -3.2)
            {
                indexY = 0;
            }
            else if(biomeHeight > -3.2 && biomeHeight <= 0)
            {
                indexY = 1;
            }
            else if(biomeHeight > 0 && biomeHeight <= 3.2)
            {
                indexY = 2;
            }
            else
            {
                indexY = 3;
            }
            // Humidity, Z value
            if(biomeHumid <= -3.2)
            {
                indexZ = 0;
            }
            else if(biomeHumid > -3.2 && biomeHumid <= 0)
            {
                indexZ = 1;
            }
            else if(biomeHumid > 0 && biomeHumid <= 3.2)
            {
                indexZ = 2;
            }
            else
            {
                indexZ = 3;
            }
            if(BiomeMapTester.genLogs)
            {
                logAfterNorm.Add($@"{indexX.ToString()},{indexZ.ToString()},{indexY.ToString()}");
            }
            return Biomes[indexX, indexY, indexZ];
        }

        public static T Clamp<T>(T value, T min, T max)
        where T : System.IComparable<T>
        {
            T result = value;
            if(value.CompareTo(max) > 0)
            {
                result = max;
            }
            if(value.CompareTo(min) < 0)
            {
                result = min;
            }
            return result;
        }
    }
}
