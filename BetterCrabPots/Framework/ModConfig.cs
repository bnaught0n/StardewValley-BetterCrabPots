using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCrabPots.Framework
{
    class ModConfig
    {
        private List<WeightedQuality> _qualityWeightsGoodFortune;
        private List<WeightedQuality> _qualityWeightsExtraLuck;
        private List<WeightedQuality> _qualityWeightsNeutral;
        private List<WeightedQuality> _qualityWeightsPeturbed;
        private List<WeightedQuality> _qualityWeightsVeryDispleased;

        public bool LogToConsole = false;
        public List<WeightedQuality> QualityWeightsGoodFortune
        {
            get { return _qualityWeightsGoodFortune; }
            set { _qualityWeightsGoodFortune = value; }
        }

        public List<WeightedQuality> QualityWeightsExtraLuck
        {
            get { return _qualityWeightsExtraLuck; }
            set { _qualityWeightsExtraLuck = value; }
        }
        public List<WeightedQuality> QualityWeightsNeutral
        {
            get { return _qualityWeightsNeutral; }
            set { _qualityWeightsNeutral = value; }
        }
        public List<WeightedQuality> QualityWeightsPeturbed
        {
            get { return _qualityWeightsPeturbed; }
            set { _qualityWeightsPeturbed = value; }
        }
        public List<WeightedQuality> QualityWeightsVeryDispleased
        {
            get { return _qualityWeightsVeryDispleased; }
            set { _qualityWeightsVeryDispleased = value; }
        }

        public ModConfig()
        {
            this.QualityWeightsExtraLuck = new List<WeightedQuality>()
            {               
                {new WeightedQuality() { Quality = "None", Weight = 100 }},
                {new WeightedQuality() { Quality = "Silver", Weight = 40 }},
                {new WeightedQuality() { Quality = "Gold", Weight = 30 }},
                {new WeightedQuality() { Quality = "Iridium", Weight = 20 }}
            };

            this.QualityWeightsGoodFortune = new List<WeightedQuality>()
            {
                {new WeightedQuality() { Quality = "None", Weight = 100 }},
                {new WeightedQuality() { Quality = "Silver", Weight = 30 }},
                {new WeightedQuality() { Quality = "Gold", Weight = 20 }},
                {new WeightedQuality() { Quality = "Iridium", Weight = 10 }}
            };

            this.QualityWeightsNeutral = new List<WeightedQuality>()
            {
                {new WeightedQuality() { Quality = "None", Weight = 100 }},
                {new WeightedQuality() { Quality = "Silver", Weight = 20}},
                {new WeightedQuality() { Quality = "Gold", Weight = 10 }},
                {new WeightedQuality() { Quality = "Iridium", Weight = 0 }}
            };

            this.QualityWeightsPeturbed = new List<WeightedQuality>()
            {
                {new WeightedQuality() { Quality = "None", Weight = 100 }},
                {new WeightedQuality() { Quality = "Silver", Weight = 10 }},
                {new WeightedQuality() { Quality = "Gold", Weight = 0 }},
                {new WeightedQuality() { Quality = "Iridium", Weight = 0 }}
            };

            this.QualityWeightsVeryDispleased = new List<WeightedQuality>()
            {
                {new WeightedQuality() { Quality = "None", Weight = 100 }},
                {new WeightedQuality() { Quality = "Silver", Weight = 0 }},
                {new WeightedQuality() { Quality = "Gold", Weight = 0 }},
                {new WeightedQuality() { Quality = "Iridium", Weight = 0 }}
            };
        }
    }
}
