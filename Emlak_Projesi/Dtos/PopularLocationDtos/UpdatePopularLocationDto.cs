﻿namespace Emlak_Projesi.Dtos.PopularLocationDtos
{
    public class UpdatePopularLocationDto
    {
        public int PopularLocationID { get; set; }
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
    }
}
