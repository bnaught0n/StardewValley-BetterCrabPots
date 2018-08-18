using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BetterCrabPots.Framework;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.TerrainFeatures;

namespace BetterCrabPots
{
    public class ModEntry : Mod
    {
        private ModConfig Config;
        private float[] RandomFloats;

        private WeightedGeneric<int>[] Quality;
        internal static MersenneTwister Twister { get; private set; }

        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();
            this.RandomFloats = new float[256];
            ModEntry.Twister = new MersenneTwister();
            this.RandomFloats.FillFloats();
           
            TimeEvents.AfterDayStarted += TimeEvents_AfterDayStarted;
        }
        
        private void TimeEvents_AfterDayStarted(object sender, EventArgs e)
        {
            this.Quality = GetDailyQuality();
            foreach (GameLocation location in Game1.locations)
            {
                foreach (var locationObject in location.objects.Pairs)
                {
                    if (locationObject.Value is StardewValley.Objects.CrabPot)
                    {
                        if ( locationObject.Value.heldObject.Value != null)
                        {
                            if (locationObject.Value.heldObject.Value.Category != StardewValley.Object.junkCategory)
                            {
                                locationObject.Value.heldObject.Value.Quality = DetermineQuality();
                                this.Monitor.Log(string.Format("Updated {0} to quality {1}.", locationObject.Value.heldObject.Value.Name, Enum.GetName(typeof(QualityIDs), locationObject.Value.heldObject.Value.Quality)));
                            }
                            else
                            {
                                this.Monitor.Log(string.Format("Skipped junk item {0}.", locationObject.Value.heldObject.Value.Name));
                            }
                        }
                        else
                        {
                            this.Monitor.Log("Skipping empty crabpot.");
                        }
                    }                    
                }
            }
        }

        private int DetermineQuality()
        {
            this.RandomFloats.FillFloats();
            int targetQuality = this.Quality.Choose().TValue;
            return targetQuality;
        }

        private WeightedGeneric<int>[] GetDailyQuality() {
            double gameDailyLuck = Game1.dailyLuck * 100;
            this.Monitor.Log(string.Format("Daily Luck is {0}.", (int)gameDailyLuck));

            List<Framework.WeightedQuality> qualityList;

            if (gameDailyLuck >= 2)
            {
                if (gameDailyLuck >= 7) // The spirits are very happy today! They will do their best to shower everyone with good fortune. 
                {
                    qualityList = this.Config.QualityWeightsGoodFortune;
                }
                else // The spirits are in good humor today. I think you'll have a little extra luck. 
                {
                    qualityList= this.Config.QualityWeightsExtraLuck;
                }
            }
            else if (gameDailyLuck <= -2)
            {
                if (gameDailyLuck <= -7) // The spirits are very displeased today. They will do their best to make your life difficult. . 
                {
                    qualityList = this.Config.QualityWeightsVeryDispleased;
                }
                else // The spirits are somewhat annoyed / mildly perturbed today. Luck will not be on your side. 
                {
                    qualityList = this.Config.QualityWeightsPeturbed;
                }
            }
            // Handling both neutrals in the same place
            // This is rare. The spirits feel absolutely neutral today. 
            // The spirits feel neutral today.The day is in your hands. 
            else
            {
                qualityList = this.Config.QualityWeightsNeutral;
            }

            WeightedGeneric<int>[] quality = new[]
            {
                WeightedGeneric<int>.Create(qualityList[0].Weight, (int)System.Enum.Parse(typeof(QualityIDs), qualityList[0].Quality, true)),
                WeightedGeneric<int>.Create(qualityList[1].Weight, (int)System.Enum.Parse(typeof(QualityIDs), qualityList[1].Quality, true)),
                WeightedGeneric<int>.Create(qualityList[2].Weight, (int)System.Enum.Parse(typeof(QualityIDs), qualityList[2].Quality, true)),
                WeightedGeneric<int>.Create(qualityList[3].Weight, (int)System.Enum.Parse(typeof(QualityIDs), qualityList[3].Quality, true))
            };

            return quality;
        }
        

        //public static int GetQuality(List<WeightedQuality> weightedQualities)
        //{
        //    int totalWeight = 0;
        //    foreach (WeightedQuality weightedQuality in weightedQualities)
        //    {
        //        totalWeight += weightedQuality.Weight;
        //    }
        //    // totalWeight is the sum of all qualities' weight
        //    int randomNumber = _rnd.Next(0, totalWeight);

        //    WeightedQuality selectedQuality = null;
        //    foreach (WeightedQuality weightedQuality in weightedQualities)
        //    {
        //        if (randomNumber < weightedQuality.Weight)
        //        {
        //            selectedQuality = weightedQuality;
        //            break;
        //        }
        //        randomNumber = randomNumber - weightedQuality.Weight;
        //    }
        //    return (int)System.Enum.Parse(typeof(QualityIDs), selectedQuality.Quality, true) + 1;
        //} 
    }


}
