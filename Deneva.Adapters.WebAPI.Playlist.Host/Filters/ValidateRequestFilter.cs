using Deneva.Core.Domain.Builders;
using Deneva.Core.Domain.SecondaryPorts.Persistencia.RequestAttributes;
using Deneva.Core.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Deneva.Adapters.WebAPI.Playlist.Host.Filters
{
    public class ValidateRequestFilter : Attribute, IAsyncResourceFilter
    {
        private IStructRequestAttributesRepository _repo;
        private ILogger logger;
        public ValidateRequestFilter(IStructRequestAttributesRepository repo, ILogger<ValidateRequestFilter> log)
        {
            _repo=repo;
            logger = log;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            logger.LogInformation("[VALIDATE REQUEST FILTER]: REC REQUEST=" + context.HttpContext.Request.Path.ToString());

            var pidUrl = context.HttpContext.Request.RouteValues["PID"].ToString();
            var xToken = context.HttpContext.Request.Headers["X-Token"];
            var xPid = context.HttpContext.Request.Headers["X-Pid"];

            if (!ValidateRequest(pidUrl,xToken,xPid))
            {
                context.Result = new ContentResult()
                {
                    StatusCode=403
                };
                logger.LogInformation("[VALIDATE REQUEST FILTER]: SEND Status 403 (Forbidden). Request=" + context.HttpContext.Request.Path.ToString());
                return;
            }
            else
            {
                logger.LogInformation("[VALIDATE REQUEST FILTER]: SEND Status 200 (OK). Request=" + context.HttpContext.Request.Path.ToString());
                await next();
            }
        }
        private bool ValidateRequest(string pid,string xToken, string xPid)
        {
            bool tmpReturn=false;
            try
            {
                //1.- Valido el token y las cabeceras de la petición.
                XToken Today,Yesterday,Tomorrow,tmp;

                var builder = new XTokenBuilder()
                    .WithPID(pid)
                    .WithDay(DateTime.Now);
                Today = builder.Build();

                builder=new XTokenBuilder()
                    .WithPID(pid)
                    .WithDay(DateTime.Now.AddDays(-1));
                Yesterday = builder.Build();

                builder = new XTokenBuilder()
                    .WithPID(pid)
                    .WithDay(DateTime.Now.AddDays(+1));
                Tomorrow = builder.Build();

                builder = new XTokenBuilder()
                    .WitTokenString(xToken);
                tmp = builder.Build();

                //Comparamos con el token de hoy, el de ayer o el de mañana.
                if ((pid.Equals(xPid)) && (tmp.Equals(Today) || tmp.Equals(Tomorrow) || tmp.Equals(Yesterday)))
                {
                    tmpReturn=true;
                }

                //2.- Si la petición es valida, busco ese PID en la cache o en BBDD para ver si es de nuestro sistema o no.
                if (tmpReturn)
                {
                    if (_repo.GetByPIDAsync(pid).Result == null)
                    {
                        tmpReturn = false;
                        logger.LogInformation("[VALIDATE REQUEST FILTER]: PID NO encontrado en BBDD. PID=" + pid);
                    }
                }
            }
            catch
            {
                tmpReturn= false;
            }
            return tmpReturn;
        }
    }
}
