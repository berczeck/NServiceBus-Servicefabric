using ClientWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ClientWebApi.Controllers
{
    /// <summary>
    /// Sale controller API
    /// </summary>
    [RoutePrefix("sale")]
    public class SaleController : ApiController
    {
        /// <summary>
        /// Get Sales
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [ResponseType(typeof(IEnumerable<SalesModel>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        /// <summary>
        /// Get Sale By Id
        /// </summary>
        /// <remarks>
        /// Remak used by get sale by id
        /// </remarks>
        /// <param name="id">Sale id</param>
        /// <returns></returns>
        /// <response code="200">Sale found</response>
        /// <response code="404">Sale not foundd</response>
        [ResponseType(typeof(SalesModel))]
        public HttpResponseMessage GetById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ResponseType(typeof(SalesModel))]
        [Route("postear")]
        public HttpResponseMessage Post(SalesModel model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        /// <summary>
        /// Crea
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(CreateCardOrderResponse))]
        [Route("create")]
        public HttpResponseMessage Create(CreateCardOrderRequest request)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }
    }
}
