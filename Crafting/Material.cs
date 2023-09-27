namespace TextGame.Crafting
{
    public class Material
    {
        private string materialName; public string MaterialName => materialName;
        private int materialLevel = 0; public int MaterialLevel => materialLevel;
        private int materialHardness = 0; public int MaterialHardness => materialHardness;
        private int materialDifficulty = 0; public int MaterialDifficulty => materialDifficulty;
        public Material(string materialName)
        {
            this.materialName = materialName;
        }

        public new string ToString()
        {
            return materialName + "\n " + 
                   "Level: " + materialLevel + "\n " +
                   "Hardness: " + materialHardness + "\n " +
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
        
        private void SetMaterialDifficulty(int difficulty)
        {
            materialDifficulty = difficulty;
        }

        public void SetMaterialProperties(int level, int hardness, int difficulty)
        {
            SetMaterialLevel(level);
            SetMaterialHardness(hardness);
            SetMaterialDifficulty(difficulty);
        }




    }   
}