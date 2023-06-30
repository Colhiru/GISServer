using GISServer.API.Model;
using GISServer.Domain.Model;


namespace GISServer.API.Service
{
    public class GeoObjectMapper
    {
        public async Task<GeoObjectDTO> ObjectToDTO(GeoObject geoObject)
        {
            GeoObjectDTO geoObjectDTO = new GeoObjectDTO();
            geoObjectDTO.Id = geoObject.Id;
            geoObjectDTO.Name = geoObject.Name;
            geoObjectDTO.GeoNameId = geoObject.GeoNameId;
            geoObjectDTO.Status = geoObject.Status;
            geoObjectDTO.UpdateTime = geoObject.UpdateTime;
            geoObjectDTO.CreationTime = geoObject.CreationTime;
            if (geoObject.GeoNameFeatureId != null)
            {
                geoObjectDTO.GeoNameFeature = new GeoNamesFeatureDTO
                {
                    Id = geoObject.GeoNameFeature.Id,
                    GeoNamesFeatureCode = geoObject.GeoNameFeature.GeoNamesFeatureCode,
                    GeoNamesFeatureKind = geoObject.GeoNameFeature.GeoNamesFeatureKind,
                    FeatureKindNameEn = geoObject.GeoNameFeature.FeatureKindNameEn,
                    FeatureNameEn = geoObject.GeoNameFeature.FeatureNameEn,
                    FeatureKindNameRu = geoObject.GeoNameFeature.FeatureKindNameRu,
                    FeatureNameRu = geoObject.GeoNameFeature.FeatureNameRu,
                    CommentsEn = geoObject.GeoNameFeature.CommentsEn,
                    CommentsRu = geoObject.GeoNameFeature.CommentsRu,
                };
            }
            if (geoObject.GeometryVersion != null)
            {
                foreach (var geometryVersion in geoObject.GeometryVersion)
                {
                    geoObjectDTO.GeometryVersion.Add(new GeometryVersionDTO
                    {
                        Id = geometryVersion.Id,
                        AuthoritativeKnowledgeSource = geometryVersion.AuthoritativeKnowledgeSource,
                        Version = geometryVersion.Version,
                        Status = geometryVersion.Status,
                        ArchiveTime = geometryVersion.ArchiveTime,
                        UpdateTime = geometryVersion.UpdateTime,
                        CreationTime = geometryVersion.CreationTime,
                        BorderGeocodes = geometryVersion.BorderGeocodes,
                        AreaValue = geometryVersion.AreaValue,
                        WestToEastLength = geometryVersion.WestToEastLength,
                        NorthToSouthLength = geometryVersion.NorthToSouthLength
                    });
                }
            }
            if (geoObject.GeoObjectInfo != null)
            {
                geoObjectDTO.GeoObjectInfo = new GeoObjectInfoDTO
                {
                    Id = geoObject.GeoObjectInfo.Id,
                    FullName = geoObject.GeoObjectInfo.FullName,
                    ShortName = geoObject.GeoObjectInfo.ShortName,
                    AuthoritativeKnowledgeSource = geoObject.GeoObjectInfo.AuthoritativeKnowledgeSource,
                    Version = geoObject.GeoObjectInfo.Version,
                    LanguageCode = geoObject.GeoObjectInfo.LanguageCode,
                    Language = geoObject.GeoObjectInfo.Language,
                    Status = geoObject.GeoObjectInfo.Status,
                    ArchiveTime = geoObject.GeoObjectInfo.ArchiveTime,
                    UpdateTime = geoObject.GeoObjectInfo.UpdateTime,
                    CreationTime = geoObject.GeoObjectInfo.CreationTime,
                    CommonInfo = geoObject.GeoObjectInfo.CommonInfo
                };
            }
            if (geoObject.ParentGeoObjects != null)
            {
                foreach (var parentGeoObject in geoObject.ParentGeoObjects)
                {
                    geoObjectDTO.ParentGeoObjects.Add(new ParentChildObjectLinkDTO
                    {
                        Id = parentGeoObject.Id,
                        ParentGeographicalObjectName = parentGeoObject.ParentGeographicalObjectName,
                        ChildGeographicalObjectName = parentGeoObject.ChildGeographicalObjectName,
                        CompletelyIncludedFlag = parentGeoObject.CompletelyIncludedFlag,
                        IncludedPercent = parentGeoObject.IncludedPercent,
                        CreationDateTime = parentGeoObject.CreationDateTime,
                        LastUpdatedDateTime = parentGeoObject.LastUpdatedDateTime
                    });
                }
            }
            if (geoObject.ChildGeoObjects != null)
            {
                foreach (var childGeoObject in geoObject.ChildGeoObjects)
                {
                    geoObjectDTO.ChildGeoObjects.Add(new ParentChildObjectLinkDTO
                    {
                        Id = childGeoObject.Id,
                        ParentGeographicalObjectName = childGeoObject.ParentGeographicalObjectName,
                        ChildGeographicalObjectName = childGeoObject.ChildGeographicalObjectName,
                        CompletelyIncludedFlag = childGeoObject.CompletelyIncludedFlag,
                        IncludedPercent = childGeoObject.IncludedPercent,
                        CreationDateTime = childGeoObject.CreationDateTime,
                        LastUpdatedDateTime = childGeoObject.LastUpdatedDateTime
                    });
                }
            }
            if (geoObject.OutputTopologyLinks != null)
            {
                foreach (var outputTopologyLink in geoObject.OutputTopologyLinks)
                {
                    geoObjectDTO.OutputTopologyLinks.Add(new TopologyLinkDTO
                    {
                        Id = outputTopologyLink.Id,
                        Predicate = outputTopologyLink.Predicate,
                        Status = outputTopologyLink.Status,
                        CreationDateTime = outputTopologyLink.CreationDateTime,
                        LastUpdatedDateTime = outputTopologyLink.LastUpdatedDateTime,
                        CommonBorder = outputTopologyLink.CommonBorder
                    });
                }
            }
            if (geoObject.InputTopologyLinks != null)
            {
                foreach (var inputTopologyLink in geoObject.InputTopologyLinks)
                {
                    geoObjectDTO.InputTopologyLinks.Add(new TopologyLinkDTO
                    {
                        Id = inputTopologyLink.Id,
                        Predicate = inputTopologyLink.Predicate,
                        Status = inputTopologyLink.Status,
                        CreationDateTime = inputTopologyLink.CreationDateTime,
                        LastUpdatedDateTime = inputTopologyLink.LastUpdatedDateTime,
                        CommonBorder = inputTopologyLink.CommonBorder
                    });
                }
            }
            return geoObjectDTO;
        }
        public async Task<GeoObject> DTOToObject(GeoObjectDTO geoObjectDTO)
        {
            GeoObject geoObject = new GeoObject();
            if (geoObjectDTO.Id != null) {
                geoObject.Id = (Guid) geoObjectDTO.Id;
            }
            geoObject.Name = geoObjectDTO.Name;
            geoObject.GeoNameId = (int)geoObjectDTO.GeoNameId;
            geoObject.Status = (Status)geoObjectDTO.Status;
            geoObject.UpdateTime = (DateTime)geoObjectDTO.UpdateTime;
            geoObject.CreationTime = (DateTime)geoObjectDTO.CreationTime;
            if (geoObjectDTO.GeoNameFeature != null)
            {
                geoObject.GeoNameFeature = new GeoNamesFeature
                {
                    Id = (Guid)geoObjectDTO.GeoNameFeature.Id,
                    GeoNamesFeatureCode = geoObjectDTO.GeoNameFeature.GeoNamesFeatureCode,
                    GeoNamesFeatureKind = geoObjectDTO.GeoNameFeature.GeoNamesFeatureKind,
                    FeatureKindNameEn = geoObjectDTO.GeoNameFeature.FeatureKindNameEn,
                    FeatureNameEn = geoObjectDTO.GeoNameFeature.FeatureNameEn,
                    FeatureKindNameRu = geoObjectDTO.GeoNameFeature.FeatureKindNameRu,
                    FeatureNameRu = geoObjectDTO.GeoNameFeature.FeatureNameRu,
                    CommentsEn = geoObjectDTO.GeoNameFeature.CommentsEn,
                    CommentsRu = geoObjectDTO.GeoNameFeature.CommentsRu,
                };
            }
            if (geoObjectDTO.GeometryVersion != null)
            {
                foreach (var geometryVersion in geoObjectDTO.GeometryVersion)
                {
                    geoObject.GeometryVersion.Add(new GeometryVersion
                    {
                        Id = (Guid)geometryVersion.Id,
                        AuthoritativeKnowledgeSource = geometryVersion.AuthoritativeKnowledgeSource,
                        Version = (int)geometryVersion.Version,
                        Status = (Status)geometryVersion.Status,
                        ArchiveTime = (DateTime)geometryVersion.ArchiveTime,
                        UpdateTime = (DateTime)geometryVersion.UpdateTime,
                        CreationTime = (DateTime)geometryVersion.CreationTime,
                        BorderGeocodes = geometryVersion.BorderGeocodes,
                        AreaValue = (double)geometryVersion.AreaValue,
                        WestToEastLength = (double)geometryVersion.WestToEastLength,
                        NorthToSouthLength = (double)geometryVersion.NorthToSouthLength
                    });
                }
            }
            if (geoObjectDTO.GeoObjectInfo != null)
            {
                geoObject.GeoObjectInfo = new GeoObjectInfo
                {
                    Id = (Guid)geoObjectDTO.GeoObjectInfo.Id,
                    FullName = geoObjectDTO.GeoObjectInfo.FullName,
                    ShortName = geoObjectDTO.GeoObjectInfo.ShortName,
                    AuthoritativeKnowledgeSource = geoObjectDTO.GeoObjectInfo.AuthoritativeKnowledgeSource,
                    Version = (int)geoObjectDTO.GeoObjectInfo.Version,
                    LanguageCode = geoObjectDTO.GeoObjectInfo.LanguageCode,
                    Language = geoObjectDTO.GeoObjectInfo.Language,
                    Status = (Status)geoObjectDTO.GeoObjectInfo.Status,
                    ArchiveTime = (DateTime)geoObjectDTO.GeoObjectInfo.ArchiveTime,
                    UpdateTime = (DateTime)geoObjectDTO.GeoObjectInfo.UpdateTime,
                    CreationTime = (DateTime)geoObjectDTO.GeoObjectInfo.CreationTime,
                    CommonInfo = geoObjectDTO.GeoObjectInfo.CommonInfo
                };
            }
            if (geoObjectDTO.ParentGeoObjects != null)
            {
                foreach (var parentGeoObject in geoObjectDTO.ParentGeoObjects)
                {
                    geoObject.ParentGeoObjects.Add(new ParentChildObjectLink
                    {
                        Id = (Guid)parentGeoObject.Id,
                        ParentGeographicalObjectName = parentGeoObject.ParentGeographicalObjectName,
                        ChildGeographicalObjectName = parentGeoObject.ChildGeographicalObjectName,
                        CompletelyIncludedFlag = (bool)parentGeoObject.CompletelyIncludedFlag,
                        IncludedPercent = (double)parentGeoObject.IncludedPercent,
                        CreationDateTime = (DateTime)parentGeoObject.CreationDateTime,
                        LastUpdatedDateTime = (DateTime)parentGeoObject.LastUpdatedDateTime
                    });
                }
            }
            if (geoObjectDTO.ChildGeoObjects != null)
            {
                foreach (var childGeoObject in geoObjectDTO.ChildGeoObjects)
                {
                    geoObject.ChildGeoObjects.Add(new ParentChildObjectLink
                    {
                        Id = (Guid)childGeoObject.Id,
                        ParentGeographicalObjectName = childGeoObject.ParentGeographicalObjectName,
                        ChildGeographicalObjectName = childGeoObject.ChildGeographicalObjectName,
                        CompletelyIncludedFlag = (bool)childGeoObject.CompletelyIncludedFlag,
                        IncludedPercent = (double)childGeoObject.IncludedPercent,
                        CreationDateTime = (DateTime)childGeoObject.CreationDateTime,
                        LastUpdatedDateTime = (DateTime)childGeoObject.LastUpdatedDateTime
                    });
                }
            }
            if (geoObjectDTO.OutputTopologyLinks != null)
            {
                foreach (var outputTopologyLink in geoObjectDTO.OutputTopologyLinks)
                {
                    geoObject.OutputTopologyLinks.Add(new TopologyLink
                    {
                        Id = (Guid)outputTopologyLink.Id,
                        Predicate = outputTopologyLink.Predicate,
                        Status = (Status)outputTopologyLink.Status,
                        CreationDateTime = (DateTime)outputTopologyLink.CreationDateTime,
                        LastUpdatedDateTime = (DateTime)outputTopologyLink.LastUpdatedDateTime,
                        CommonBorder = outputTopologyLink.CommonBorder
                    });
                }
            }
            if (geoObjectDTO.InputTopologyLinks != null)
            {
                foreach (var inputTopologyLink in geoObjectDTO.InputTopologyLinks)
                {
                    geoObject.InputTopologyLinks.Add(new TopologyLink
                    {
                        Id = (Guid)inputTopologyLink.Id,
                        Predicate = inputTopologyLink.Predicate,
                        Status = (Status)inputTopologyLink.Status,
                        CreationDateTime = (DateTime)inputTopologyLink.CreationDateTime,
                        LastUpdatedDateTime = (DateTime)inputTopologyLink.LastUpdatedDateTime,
                        CommonBorder = inputTopologyLink.CommonBorder
                    });
                }
            }
            return geoObject;
        }
    }
}
