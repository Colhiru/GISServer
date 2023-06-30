using GISServer.API.Service;
using GISServer.Domain.Model;
using GISServer.Infrastructure.Data;
using GISServer.Infrastructure.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IGeoObjectRepository, GeoObjectRepository>();
builder.Services.AddScoped<IGeoObjectService, GeoObjectService>();
builder.Services.AddSingleton<GeoObjectMapper>();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

/*
using (Context context = new Context())
{
    GeoNamesFeature geoNamesFeature1 = new GeoNamesFeature
    {
        CommentsRu = "Тест"
    };
    GeoNamesFeature geoNamesFeature2 = new GeoNamesFeature
    {
        CommentsRu = "Тест2"
    };
    context.GeoNamesFeatures.AddRange(geoNamesFeature1, geoNamesFeature2);

    GeoObject geoObject1 = new GeoObject
    {
        Name = "Test1",
        GeoNameFeature = geoNamesFeature1
    };
    GeoObject geoObject2 = new GeoObject
    {
        Name = "Test2",
        GeoNameFeature = geoNamesFeature2
    };
    context.GeoObjects.AddRange(geoObject1, geoObject2);

    GeometryVersion geometryVersion1 = new GeometryVersion
    {
        Version = 1,
        GeographicalObject = geoObject1
    };
    GeometryVersion geometryVersion2 = new GeometryVersion
    {
        Version = 2,
        GeographicalObject = geoObject2
    };
    context.GeometryVersions.AddRange(geometryVersion1, geometryVersion2);

    GeoObjectInfo geoObjectInfo1 = new GeoObjectInfo
    {
        GeographicalObject = geoObject1,
        ShortName = "T1"
    };
    GeoObjectInfo geoObjectInfo2 = new GeoObjectInfo
    {
        GeographicalObject = geoObject2,
        ShortName = "T2"
    };
    context.GeoObjectInfos.AddRange(geoObjectInfo1, geoObjectInfo2);

    TopologyLink topologyLink1 = new TopologyLink
    {
        Predicate = "FAFAFA1",
        GeographicalObjectIn = geoObject1,
        GeographicalObjectOut = geoObject2
    };
    TopologyLink topologyLink2 = new TopologyLink
    {
        Predicate = "FAFAFA2",
        GeographicalObjectIn = geoObject2,
        GeographicalObjectOut = geoObject1
    };
    context.TopologyLinks.AddRange(topologyLink1, topologyLink2);
    context.SaveChanges();
}*/


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();