using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Domain.Exception;

namespace TerosOpenBanking.Application.Mediator.Commands
{
    public class BaseObjectCommand : IRequest<RequestDataModel>
    {
        private string _name = string.Empty;
        private string _image = string.Empty;
        private string _discovery = string.Empty;
        private string _organizationId = string.Empty;


        public string OrganizationId
        {
            get => _organizationId;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _organizationId = value;
                else
                    throw new BaseException("Name not found - Please, check. ");
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    throw new BaseException("Name not found - Please, check. ");
            }
        }
        public string Image
        {
            get => _image;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _image = value;
                else
                    throw new BaseException("Image not found - Please, check. ");
            }
        }
        public string Discovery
        {
            get => _discovery;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _discovery = value;
                else
                    throw new BaseException("Discovery not found - Please, check. ");
            }
        }

        public RequestDataModel GetToMapping()
        {
            return new RequestDataModel()
            {
                OrganisationId = this.OrganizationId,
                Discovery = this.Discovery,
                Image = this.Image,
                Name = this.Name
            };

        }
    }
}
