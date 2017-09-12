using System.Collections.Generic;

namespace CityInfo.DtoModels
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int GetNumberOfPointsOfInterest() => PointsOfInterest.Count;

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
            = new List<PointOfInterestDto>();
    }
}