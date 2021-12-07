using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class ContaController : Controller
    {
        [Authorize]     // forçando a autorização do usuário
        public async Task<ActionResult> Login()
        {
            // "~/" ->  calcula o endereço em tempo de execução para a home page
            return Redirect(Url.Content("~/"));
        }

        [Authorize]
        public async Task Logout()
        {
            //atualizar os cookies (autenticação local)
            await HttpContext.SignOutAsync("Cookies");
            //faz o desconexão no IdentityServer
            await HttpContext.SignOutAsync("OpenIdConnect");
        }
    }
}
