namespace TextGame.Crafting
{
    public class Material
    {
        private string materialName; public string _MaterialName => materialName;
        private int materialLevel = 0; public int _MaterialLevel => materialLevel;
        private int materialHardness = 0; public int _MaterialHardness => materialHardness;
        private int materialMagic = 0; public int _MaterialMagic => materialMagic;
        private int materialDifficulty = 0; public int _MaterialDifficulty => materialDifficulty;
        public Material(string materialName)
        {
            this.materialName = materialName;
        }

        public new string ToString()
        {
            return materialName + "\n " + 
                   "Level: " + materialLevel + "\n " +
                   "Hardness: " + materialHardness + "\n " +
                   "Magic: " + materialMagic + "\n " +
                   "Difficulty: " + materialDifficulty;

        }

        private void SetMaterialLevel(int level)
        {
            materialLevel = level;
        }

        private void SetMaterialHardness(int hardness)
        {
            materialHardness = hardness;
        }

        private void SetMaterialMagic(int magic)
        {
            materialMagic = magic;
        }
        
        private void SetMaterialDifficulty()
        {
            materialDifficulty = materialMagic + (int)Math.Round(materialHardness * 1.5M);
        }

        public void SetMaterialProperties(int level, int hardness, int magic)
        {
            SetMaterialLevel(level);
            SetMaterialHardness(hardness);
            SetMaterialMagic(magic);
            SetMaterialDifficulty();
        }




    }   
}