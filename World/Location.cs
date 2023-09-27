using TextGame.Crafting;

namespace TextGame.World
{
    public class Location
    {
        private string locationName;
        public string LocationName
        {
            get { return locationName; }
        }
        private bool gatheringAvaiable;
        public bool GateringAvaiable { get { return gatheringAvaiable; } }
        private List<Material> materialsAvaiable = new List<Material>();

        public Location(string locationName, bool gatheringAvaiable)
        {
            this.locationName = locationName;
            this.gatheringAvaiable = gatheringAvaiable;
        }

        public List<Material> GetAvaiableMaterials()
        {
            return materialsAvaiable;
        }

        public void AddMaterial(Material material)
        {
            materialsAvaiable.Add(material);
        }

        public string ToString()
        {
            string locationString = locationName + "\nMaterials:";
            foreach (Material material in materialsAvaiable)
            {
                locationString += "\n" + material.MaterialName;
            }

            return locationString;
        }

        public bool ContainsMaterial(Material material)
        {
            if (materialsAvaiable.Contains(material)) return true;
            return false;
        }


    }    
}
