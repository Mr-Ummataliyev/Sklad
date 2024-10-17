using MediatR;
using Sklad.Domain.DTOs;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Commands
{
    public class CreateBasketCommand : BasketDTO, IRequest<Response>
    {

    }
}
