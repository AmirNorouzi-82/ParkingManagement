using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.ParkingLog.Requests.Queries;

public class GetAllParkingLogsRequest : IRequest<List<ParkingLogDTO>>
{
}
