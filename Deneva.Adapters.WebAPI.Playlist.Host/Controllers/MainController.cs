using Deneva.Adapters.WebAPI.Playlist.Host.Filters;
using Deneva.Core.Application.PrimaryPorts.RequestAttributes;

using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Deneva.Core.Application.PrimaryPorts.Playlist;
using Deneva.Core.Domain.PrimaryPorts.RequestAttributes;
using Deneva.Core.Domain.PrimaryPorts.Playlist;

namespace Deneva.Adapters.WebAPI.Playlist.Host.Controllers
{
    [ApiController]
    [Route("api/v1/Playlist")]
    [ServiceFilter(typeof(ValidateRequestFilter))]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> logger;
        private readonly IGetByPIDStructRequestAttributes getByPIDStruct;
        private readonly IGetByObjIDPlaylistFile getByOjbIdPLFile;

        public MainController(ILogger<MainController> log,
            IGetByPIDStructRequestAttributes getByPIDStruct,
            IGetByObjIDPlaylistFile getByOjbIdPLFile)
        {
            logger = log;
            this.getByPIDStruct = getByPIDStruct;
            this.getByOjbIdPLFile = getByOjbIdPLFile;
        }



        [HttpGet("GetPlaylist/{PID}")]
        public async Task<ContentResult> GetPlaylist(string PID)
        {
            logger.LogDebug("[MAINCONTROLLER]: GetPlaylist. PID=" + PID);

            Microsoft.Extensions.Primitives.StringValues lastModifiedHeader;

            Request.Headers.TryGetValue("If-Modified-Since", out lastModifiedHeader);
            DateTime lastModified = DateTime.Parse(lastModifiedHeader.ToString());


            var data = await getByPIDStruct.ExecuteAsync(PID);
            var ficheroPlaylist = await getByOjbIdPLFile.ExecuteAsync(data.ObjectID);

            if ((ficheroPlaylist != null) && (ficheroPlaylist.LastModified.Subtract(lastModified).TotalSeconds > 0))
            {
                //LMM, la fecha del fichero en disco es más actual que la que viene en la cabecera de la petición
                logger.LogDebug("[MAINCONTROLLER]: Return 200 (OK). LastModified=" + ficheroPlaylist.LastModified.ToString());

                return new ContentResult() { Content = ficheroPlaylist.Content.ToString(), StatusCode = (int)HttpStatusCode.OK };
                //return Content(ficheroPlaylist.Content.ToString(), "text/xml", System.Text.Encoding.UTF8);
            }
            else
            {
                logger.LogDebug("[MAINCONTROLLER]: Return 304 (NotModified).");
                return new ContentResult() { Content = String.Empty, StatusCode = (int)HttpStatusCode.NotModified };
            }
        }

    }
}
