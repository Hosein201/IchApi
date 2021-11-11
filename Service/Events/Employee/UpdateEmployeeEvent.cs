using Data;
using MediatR;
using Service.Dto;
using System;
using Utility.Enums;

namespace Service.Events.Employee
{
    public class UpdateEmployeeEvent : CommonEvent<EmployeeDto>, INotification
    {
        public UpdateEmployeeEvent(EmployeeDto modelEvent, string commandName, DateTime eventDate, TypeEvent typeEvent, string nameEvent)
            : base(modelEvent, commandName, eventDate, typeEvent, nameEvent)
        {
        }
    }
}
