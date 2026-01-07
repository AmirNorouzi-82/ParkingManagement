using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.ParkingLog.Requests.Commands;

public class DeleteParkingLogRequest : IRequest
{
    public DeleteParkingLogDTO DeleteParkingLogDTO { get; set; }
}
