namespace GISServer.Domain.Model
{
    public interface IGeoObjectRepository
    {
        public Task<List<GeoObject>> GetGeoObjects();
        public Task<GeoObject> GetGeoObject(Guid id);
        public Task<GeoObject> UpdateGeoObject(GeoObject geoObject);
        public Task<GeoObject> AddGeoObject(GeoObject geoObject);
        public Task<(bool, string)> DeleteGeoObject(Guid id);
    }
}
