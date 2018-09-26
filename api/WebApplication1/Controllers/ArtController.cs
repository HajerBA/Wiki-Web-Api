using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArtController : ApiController
    {
        public IHttpActionResult GetArt()
        {
             
        var Arts = new ArtEntities();
            return Ok(Arts.Article.ToList());
        }
        public string DeleteArt(int artId)
        {
            var Arts = new ArtEntities();
            Article art = Arts.Article.Where(x => x.IDArt == artId).Single<Article>();
            Arts.Article.Remove(art);
            Arts.SaveChanges();
            return "Record has successfully Deleted";
        }
        [HttpDelete]
        public string DeleteArts(int id)
        {
            return DeleteArt(id);
        }
    }
}
