﻿using MediatR;
using System;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class UpdateClientByIdRequest : RequestBase, IRequest<UpdateClientByIdResponse>
    {

        public int Id;
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; } = "";
        public string SneakPeak { get; set; } = "";
        public string CorrespondenceAddress { get; set; } = "";
        public string FirstName { get; set; }  
        public string LastName { get; set; } = ""; 
        public string PhoneNumber { get; set; } = ""; 
        public string Email { get; set; } = ""; 
        public string Source { get; set; } = ""; 
        public string Stage { get; set; } = ""; 
        public string Note { get; set; } = ""; 
    }
}