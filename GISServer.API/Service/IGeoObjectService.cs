using GISServer.API.Model;

namespace GISServer.API.Service
{
    public interface IGeoObjectService
    {
        public Task<List<GeoObjectDTO>> GetGeoObjects();
        public Task<GeoObjectDTO> GetGeoObject(Guid id);
        public Task<GeoObjectDTO> UpdateGeoObject(GeoObjectDTO geoObjectDTO);
        public Task<GeoObjectDTO> AddGeoObject(GeoObjectDTO geoObjectDTO);
        public Task<(bool, string)> DeleteGeoObject(Guid id);
    }
}
