﻿using FinCRM.ApplicationServices.API.Domain.Requests;
using FinCRM.ApplicationServices.API.Domain.Responses;

namespace FinCRM.Controllers
{
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using System.Threading.Tasks;

	//[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class ApplicationsController : ApiControllerBase
	{

		public ApplicationsController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet]
		[Route("")]
		public Task<IActionResult> GetAllApplications([FromQuery] GetApplicationsRequest request)
		{
			return this.HandleRequest<GetApplicationsRequest, GetApplicationsResponse>(request);
		}

		[HttpGet]
		[Route("{applicationId}")]
		public Task<IActionResult> GetById([FromRoute] int applicationId)
		{
			var request = new GetApplicationByIdRequest()
			{
				ApplicationId = applicationId
			};
			return this.HandleRequest<GetApplicationByIdRequest, GetApplicationByIdResponse>(request);
		}


		[HttpPut]
		[Route("{applicationId}")]
		public Task<IActionResult> UpdateById([FromRoute] int applicationId, [FromBody] UpdateApplicationByIdRequest request)
		{
			request.Id = applicationId;

			return this.HandleRequest<UpdateApplicationByIdRequest, UpdateApplicationByIdResponse>(request);
		}


		[HttpPost]
		[Route("")]
		public Task<IActionResult> AddApplication([FromBody] AddApplicationRequest request)
		{
			return this.HandleRequest<AddApplicationRequest, AddApplicationResponse>(request);
		}

		[HttpDelete]
		[Route("{applicaionId}")]
		public Task<IActionResult> DeleteById([FromRoute] int applicaionId)
		{
			var request = new DeleteApplicationByIdRequest()
			{
				Id = applicaionId
			};

			return this.HandleRequest<DeleteApplicationByIdRequest, DeleteApplicationByIdResponse>(request);
		}


	}
}
