using GISServer.API.Model;
using GISServer.Domain.Model;

namespace GISServer.API.Service
{
    public class GeoObjectService : IGeoObjectService
    {
        private readonly IGeoObjectRepository _repository;
        private readonly GeoObjectMapper _geoObjectMapper;

        public GeoObjectService(IGeoObjectRepository repository, GeoObjectMapper geoObjectMapper)
        {
            _repository = repository;
            _geoObjectMapper = geoObjectMapper;
        }

        public async Task<List<GeoObjectDTO>> GetGeoObjects()
        {
            try
            {
                List<GeoObject> geoObjectsFromDB = new List<GeoObject>(await _repository.GetGeoObjects());
                List<GeoObjectDTO> geoObjects = new List<GeoObjectDTO>();
                foreach (var geoObject in geoObjectsFromDB)
                {
                    geoObjects.Add(await _geoObjectMapper.ObjectToDTO(geoObject));
                }
                return geoObjects;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GeoObjectDTO> GetGeoObject(Guid id)
        {
            try
            {
                GeoObjectDTO geoObject = await _geoObjectMapper.ObjectToDTO(await _repository.GetGeoObject(id));
                return geoObject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GeoObjectDTO> AddGeoObject(GeoObjectDTO geoObjectDTO)
        {
           try
           {
               GeoObject geoObject = await _geoObjectMapper.DTOToObject(geoObjectDTO);
               return await _geoObjectMapper.ObjectToDTO(await _repository.AddGeoObject(geoObject));
            }
           catch (Exception ex)
           {
               return null;
           }
        }


        public async Task<GeoObjectDTO> UpdateGeoObject(GeoObjectDTO geoObjectDTO)
        {
           try
           {
               GeoObject geoObject = await _geoObjectMapper.DTOToObject(geoObjectDTO);
               await _repository.UpdateGeoObject(geoObject);
               return geoObjectDTO;
           }
           catch (Exception ex)
           {
               return null;
           }
        }
        public async Task<(bool, string)> DeleteGeoObject(Guid id)
        {
           try
           {
               return await _repository.DeleteGeoObject(id);
           }
           catch (Exception ex)
           {
               return (false, $"An error occured. Error Message: {ex.Message}");
           }
        }
    }
}
