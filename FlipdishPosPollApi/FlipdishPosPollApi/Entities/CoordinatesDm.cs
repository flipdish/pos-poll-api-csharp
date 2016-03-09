namespace FlipdishPosPollApi.Entities
{
    public class CoordinatesDm
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
    }
}