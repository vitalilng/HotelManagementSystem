using HotelManagementSystem.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Shared
{
    public class AvailableRoomsStateContainer
    {
        /// <summary>
        /// Value of available roomsDto
        /// </summary>
        public RoomDto[] Value { get; set; }

        /// <summary>
        /// OnStateChange is an event that is raised when the Room object is modified.
        /// </summary>
        public event Action? OnStateChange;

        /// <summary>
        ///  SetValue()  sets the value of the Value property.
        /// </summary>
        /// <param name="roomValue"></param>
        public void SetValue(RoomDto[] roomValue)
        {
            Value = roomValue;
            NotifyStateChanged();
        }

        //NotifyStateChanged() is defined to raise the OnStateChange event.
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}