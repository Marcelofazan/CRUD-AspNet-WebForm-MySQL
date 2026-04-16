using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Simples
{
    /// <summary>
    /// Descrição resumida de ImageHttpHandler
    /// </summary>
    public class ImageHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //// 1. Obter o ID ou Nome da imagem da query string
            //string imageId = context.Request.QueryString["1"];

            //if (!string.IsNullOrEmpty(imageId))
            //{
            //    // 2. BUSQUE A IMAGEM (Banco de dados ou Arquivo)
            //    // byte[] imageBytes = ObterImagemDoBanco(imageId);
            //    // Exemplo fictício:
            //    byte[] imageBytes = File.ReadAllBytes(context.Server.MapPath("~/Images/foto.jpg"));

            //    // 3. Configurar o tipo de conteúdo
            //    context.Response.ContentType = "image/jpeg"; // Ou image/png
            //    context.Response.BinaryWrite(imageBytes);
            //}
            //else
            //{
            //    // Opcional: Retornar imagem padrão caso não encontre
            //    context.Response.StatusCode = 404;
            //}
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}