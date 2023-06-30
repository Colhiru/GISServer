using GISServer.Domain.Model;
using GISServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GISServer.Infrastructure.Service
{
    public class GeoObjectRepository : IGeoObjectRepository
    {
        private readonly Context _context;

        public GeoObjectRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GeoObject>> GetGeoObjects()
        {
            return await _context.GeoObjects
                .Include(gnf => gnf.GeoNameFeature)
                .Include(gv => gv.GeometryVersion)
                .Include(goi => goi.GeoObjectInfo)
                .Include(pgo => pgo.ParentGeoObjects)
                .Include(cgo => cgo.ChildGeoObjects)
                .Include(otl => otl.OutputTopologyLinks)
                .Include(itl => itl.InputTopologyLinks)
                .ToListAsync();
        }

        public async Task<GeoObject> GetGeoObject(Guid id)
        {
            return await _context.GeoObjects
                .Where(go => go.Id == id)
                .Include(gnf => gnf.GeoNameFeature)
                .Include(gv => gv.GeometryVersion)
                .Include(goi => goi.GeoObjectInfo)
                .Include(pgo => pgo.ParentGeoObjects)
                .Include(cgo => cgo.ChildGeoObjects)
                .Include(otl => otl.OutputTopologyLinks)
                .Include(itl => itl.InputTopologyLinks)
                .FirstOrDefaultAsync();
        }

        public async Task<GeoObject> AddGeoObject(GeoObject geoObject)
        {
            await _context.GeoObjects.AddAsync(geoObject);
            await _context.SaveChangesAsync();
            return await GetGeoObject(geoObject.Id);
        }

        public async Task<GeoObject> UpdateGeoObject(GeoObject geoObject)
        {
            _context.Entry(geoObject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return geoObject;
        }

        public async Task<(bool, string)> DeleteGeoObject(Guid id)
        {
            var dbGeoObject = await GetGeoObject(id);
            if (dbGeoObject == null)
            {
                return (false, "GeoObeject could not be found");
            }
            _context.GeoObjects.Remove(dbGeoObject);
            await _context.SaveChangesAsync();
            return (true, "GeoObject got deleted");
        }
    }
}
