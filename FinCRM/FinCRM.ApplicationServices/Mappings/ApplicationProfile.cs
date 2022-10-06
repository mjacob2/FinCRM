using FinCRM.ApplicationServices.API.Domain.Requests;

namespace FinCRM.ApplicationServices.Mappings
{
    using AutoMapper;
    using FinCRM.ApplicationServices.API.Domain;
    using System.Collections.Generic;
    using System.Linq;

    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //GET APPLICATIONS
            this.CreateMap<DataAccess.Entities.Application, FinCRM.ApplicationServices.API.Domain.Models.Applications>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Goal, y => y.MapFrom(z => z.Goal))
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount))
                .ForMember(x => x.CommissionAmount, y => y.MapFrom(z => z.CommissionAmount))
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ForMember(x => x.ClientsLastNames, y => y.MapFrom(z => z.Clients != null ? z.Clients.Select(x => x.LastName) : new List<string>()))
                ;

            // GET CLIENT BY ID
            this.CreateMap<DataAccess.Entities.Application, FinCRM.ApplicationServices.API.Domain.Models.Application>()

                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Goal, y => y.MapFrom(z => z.Goal))
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount))
                .ForMember(x => x.CommissionPercentage, y => y.MapFrom(z => z.CommissionPercentage))
                .ForMember(x => x.CommissionAmount, y => y.MapFrom(z => z.CommissionAmount))
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
                .ForMember(x => x.SubmitedDat, y => y.MapFrom(z => z.SubmitedDat))
                .ForMember(x => x.FinishDate, y => y.MapFrom(z => z.FinishDate))
                .ForMember(x => x.Broker, y => y.MapFrom(z => z.Broker))
                .ForMember(x => x.WithdrawalDate, y => y.MapFrom(z => z.WithdrawalDate))
                .ForMember(x => x.SellerName, y => y.MapFrom(z => z.SellerName))
                .ForMember(x => x.SellerPhoneNumber, y => y.MapFrom(z => z.SellerPhoneNumber))
                .ForMember(x => x.SellerEmail, y => y.MapFrom(z => z.SellerEmail))
                .ForMember(x => x.SellerURL, y => y.MapFrom(z => z.SellerURL))
                .ForMember(x => x.SellerAddress, y => y.MapFrom(z => z.SellerAddress))
                .ForMember(x => x.SellerInvestName, y => y.MapFrom(z => z.SellerInvestName))
                .ForMember(x => x.MortgageRegisterNumber, y => y.MapFrom(z => z.MortgageRegisterNumber))
                .ForMember(x => x.DeadlineDate, y => y.MapFrom(z => z.DeadlineDate))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ForMember(x => x.ClientsLastNames, y => y.MapFrom(z => z.Clients != null ? z.Clients.Select(x => x.LastName) : new List<string>()))
                ;
            

            // POST APPLICATION
            this.CreateMap<AddApplicationRequest, DataAccess.Entities.Application >()

                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Goal, y => y.MapFrom(z => z.Goal))
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount))
                .ForMember(x => x.CommissionPercentage, y => y.MapFrom(z => z.CommissionPercentage))
                .ForMember(x => x.CommissionAmount, y => y.MapFrom(z => z.CommissionAmount))
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
                .ForMember(x => x.SubmitedDat, y => y.MapFrom(z => z.SubmitedDat))
                .ForMember(x => x.FinishDate, y => y.MapFrom(z => z.FinishDate))
                .ForMember(x => x.Broker, y => y.MapFrom(z => z.Broker))
                .ForMember(x => x.WithdrawalDate, y => y.MapFrom(z => z.WithdrawalDate))
                .ForMember(x => x.SellerName, y => y.MapFrom(z => z.SellerName))
                .ForMember(x => x.SellerPhoneNumber, y => y.MapFrom(z => z.SellerPhoneNumber))
                .ForMember(x => x.SellerEmail, y => y.MapFrom(z => z.SellerEmail))
                .ForMember(x => x.SellerURL, y => y.MapFrom(z => z.SellerURL))
                .ForMember(x => x.SellerAddress, y => y.MapFrom(z => z.SellerAddress))
                .ForMember(x => x.SellerInvestName, y => y.MapFrom(z => z.SellerInvestName))
                .ForMember(x => x.MortgageRegisterNumber, y => y.MapFrom(z => z.MortgageRegisterNumber))
                .ForMember(x => x.DeadlineDate, y => y.MapFrom(z => z.DeadlineDate))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                ;


            //PUT APPLICATION
            this.CreateMap<UpdateApplicationByIdRequest, DataAccess.Entities.Application>()

                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Goal, y => y.MapFrom(z => z.Goal))
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount))
                .ForMember(x => x.CommissionPercentage, y => y.MapFrom(z => z.CommissionPercentage))
                .ForMember(x => x.CommissionAmount, y => y.MapFrom(z => z.CommissionAmount))
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
                .ForMember(x => x.SubmitedDat, y => y.MapFrom(z => z.SubmitedDat))
                .ForMember(x => x.FinishDate, y => y.MapFrom(z => z.FinishDate))
                .ForMember(x => x.Broker, y => y.MapFrom(z => z.Broker))
                .ForMember(x => x.WithdrawalDate, y => y.MapFrom(z => z.WithdrawalDate))
                .ForMember(x => x.SellerName, y => y.MapFrom(z => z.SellerName))
                .ForMember(x => x.SellerPhoneNumber, y => y.MapFrom(z => z.SellerPhoneNumber))
                .ForMember(x => x.SellerEmail, y => y.MapFrom(z => z.SellerEmail))
                .ForMember(x => x.SellerURL, y => y.MapFrom(z => z.SellerURL))
                .ForMember(x => x.SellerAddress, y => y.MapFrom(z => z.SellerAddress))
                .ForMember(x => x.SellerInvestName, y => y.MapFrom(z => z.SellerInvestName))
                .ForMember(x => x.MortgageRegisterNumber, y => y.MapFrom(z => z.MortgageRegisterNumber))
                .ForMember(x => x.DeadlineDate, y => y.MapFrom(z => z.DeadlineDate))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                ;

            //DELETE APPLICATION
            this.CreateMap<DeleteApplicationByIdRequest, DataAccess.Entities.Application>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                ;
        }
    }
}
