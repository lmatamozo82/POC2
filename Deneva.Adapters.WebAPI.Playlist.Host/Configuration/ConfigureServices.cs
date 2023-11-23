using Deneva.Core.Domain.PrimaryPorts.RequestAttributes;
using Deneva.Core.Domain.SecondaryPorts.Storage;
using Deneva.Core.Application.PrimaryPorts.RequestAttributes;
using Deneva.Core.Application.PrimaryPorts.Playlist;
using Deneva.Adapters.Storage.Filesystem;
using Microsoft.Extensions.DependencyInjection;
using Deneva.Core.Domain.PrimaryPorts.Playlist;
using Deneva.Adapters.Storage.Filesystem.Playlist;
using Microsoft.Extensions.Configuration;
using Deneva.Core.Domain.SecondaryPorts.Persistencia.RequestAttributes;
using Deneva.Adapters.Database.MySQL.Repositories;

namespace Deneva.Adapters.WebAPI.Playlist.Host.Configuration
{
    public static class ConfigureServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<IDispositivosPlaylistTimestampRepository, DispositivosPlaylistTimestampRepository>();
            //services.AddScoped<IGetAllDispositivosPlaylistTimestamosUseCase, GetAllDispositivosPlaylistTimestampsUseCase>();
            //services.AddScoped<IGetByObjIDDispositivosPlaylistTimestampsUseCase, GetByObjIDDispositivosPlaylistTimestampsUseCase>();

            ////Cache
            //services.AddScoped<ICompany_PID_ObjID_MapperRepository, Company_PID_ObjID_MapperRepository>();
            //services.AddScoped<IGetByPIDCompany_PID_ObjID_MapperUseCase, GetByPIDCompany_PID_ObjID_MapperUseCase>();
            //services.AddMemoryCache();
            //services.AddScoped<MapPIDsObjIdsComapanysCache>();


            ////Ficheros Playlist
            //services.AddScoped<IPlaylistFileStorage, PlaylistFileStorageFileSystem>();
            //services.AddScoped<IGetPlaylistFileByObjIDUseCase, GetPlaylistFileByObjIDUseCase>();

            services.AddPrimaryPorts();
            services.AddSecondaryPorts();
        }


        private static void AddPrimaryPorts(this IServiceCollection services)
        {
            services.AddScoped<IGetByPIDStructRequestAttributes, GetByPIDStructRequestAttributes>();
            services.AddScoped<IGetByObjIDPlaylistFile, GetByObjIDPlaylistFile>();
        }

        private static void AddSecondaryPorts(this IServiceCollection services)
        {
            services.AddScoped<IPlaylistFileStorage, PlaylistFileStorageFileSystem>();
            services.AddScoped<IStructRequestAttributesRepository, StructRequestAttributesRepository>();
        }     
    }
}
