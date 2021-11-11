using Data;
using MediatR;
using Service.Dto;
using Service.Events;
using System;
using Utility.Enums;

namespace Service.Employee.Events
{
    public class AddEmployeeEvent : CommonEvent<EmployeeDto>, INotification
    {
        public AddEmployeeEvent(EmployeeDto modelEvent, string commandName, DateTime eventDate, TypeEvent typeEvent, string nameEvent)
            : base(modelEvent, commandName, eventDate, typeEvent, nameEvent)
        {
        }
    }
}