using Data;
using MediatR;
using Service.Dto;
using System;
using Utility.Enums;

namespace Service.Employee.Events
{
    public class DeleteEmployeeEvent : CommonEvent<EmployeeDto>, INotification
    {
        public DeleteEmployeeEvent(EmployeeDto modelEvent, string commandName, DateTime eventDate, TypeEvent typeEvent, string nameEvent)
            : base(modelEvent, commandName, eventDate, typeEvent, nameEvent)
        {
        }
    }
}