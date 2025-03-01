namespace RayCaster
{
    internal class RayCasterMain
    {
        internal string worldFolder;
        internal WorldJson.Rootobject[] chunks;

        internal Dictionary<string, int> position = new Dictionary<string, int>();

        public RayCasterMain(string worldDirectory)
        {
            worldFolder = worldDirectory;
        }

        public void CastRays()
        {

        }
    }
}
